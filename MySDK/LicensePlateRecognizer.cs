using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.ML.OnnxRuntime;
using Microsoft.ML.OnnxRuntime.Tensors;
using Tesseract;

namespace MySDK
{
    public class PlateDetectionResult
    {
        public bool Success { get; set; }
        public string PlateNumber { get; set; }
        public float Confidence { get; set; }
        public Rectangle Box { get; set; }
        public Bitmap CroppedPlate { get; set; }
        public string RawOcrText { get; set; }
        public string ErrorMessage { get; set; }
    }

    public class LicensePlateRecognizer : IDisposable
    {
        private InferenceSession _session;
        private TesseractEngine _ocrEngine;
        private readonly string _modelPath;
        private readonly string _tessdataPath;

        public LicensePlateRecognizer(string modelPath = null, string tessdataPath = null)
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;

            if (string.IsNullOrEmpty(modelPath))
            {
                string p1 = Path.Combine(baseDir, "models", "license_plate_yolov8n.onnx");
                string p2 = Path.Combine(baseDir, "..", "..", "models", "license_plate_yolov8n.onnx");
                string p3 = Path.Combine(baseDir, "..", "..", "..", "models", "license_plate_yolov8n.onnx");
                _modelPath = File.Exists(p1) ? p1 : (File.Exists(p2) ? Path.GetFullPath(p2) : (File.Exists(p3) ? Path.GetFullPath(p3) : p1));
            }
            else
            {
                _modelPath = modelPath;
            }

            if (string.IsNullOrEmpty(tessdataPath))
            {
                string t1 = Path.Combine(baseDir, "tessdata");
                string t2 = Path.Combine(baseDir, "..", "..", "tessdata");
                string t3 = Path.Combine(baseDir, "..", "..", "..", "tessdata");
                _tessdataPath = Directory.Exists(t1) ? t1 : (Directory.Exists(t2) ? Path.GetFullPath(t2) : (Directory.Exists(t3) ? Path.GetFullPath(t3) : t1));
            }
            else
            {
                _tessdataPath = tessdataPath;
            }

            InitEngines();
        }

        private void InitEngines()
        {
            if (File.Exists(_modelPath))
            {
                var options = new SessionOptions();
                options.GraphOptimizationLevel = GraphOptimizationLevel.ORT_ENABLE_ALL;
                _session = new InferenceSession(_modelPath, options);
            }

            if (Directory.Exists(_tessdataPath))
            {
                _ocrEngine = new TesseractEngine(_tessdataPath, "eng", EngineMode.Default);
                _ocrEngine.SetVariable("tessedit_char_whitelist", "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789. ");
            }
        }

        public PlateDetectionResult ProcessImage(string imagePath)
        {
            var res = new PlateDetectionResult { Success = false };

            if (!File.Exists(imagePath))
            {
                res.ErrorMessage = "File gambar tidak ditemukan: " + imagePath;
                return res;
            }

            if (_session == null)
            {
                res.ErrorMessage = "Model ONNX belum dimuat dari: " + _modelPath;
                return res;
            }

            if (_ocrEngine == null)
            {
                res.ErrorMessage = "Engine Tesseract belum dimuat dari: " + _tessdataPath;
                return res;
            }

            try
            {
                using (var srcBitmap = new Bitmap(imagePath))
                {
                    // 1. Deteksi letak plat nomor dengan YOLOv8
                    var detectedBox = DetectPlateBox(srcBitmap, out float conf);
                    if (detectedBox.Width <= 0 || detectedBox.Height <= 0)
                    {
                        // Fallback jika tidak ada deteksi box yang meyakinkan
                        detectedBox = new Rectangle(
                            (int)(srcBitmap.Width * 0.25),
                            (int)(srcBitmap.Height * 0.45),
                            (int)(srcBitmap.Width * 0.5),
                            (int)(srcBitmap.Height * 0.4)
                        );
                    }

                    res.Box = detectedBox;
                    res.Confidence = conf;

                    // 2. Crop area plat nomor
                    Bitmap cropped = CropBitmap(srcBitmap, detectedBox);
                    res.CroppedPlate = new Bitmap(cropped);

                    // 3. Preprocessing (Scaling, Inversi jika plat hitam, dan Otsu/Adaptive Threshold)
                    using (Bitmap preprocessed = PreprocessPlate(cropped))
                    {
                        // 4. Jalankan OCR
                        using (var page = _ocrEngine.Process(preprocessed, PageSegMode.SingleBlock))
                        {
                            string rawOcr = page.GetText();
                            res.RawOcrText = rawOcr;
                            string cleaned = CleanPlateText(rawOcr);

                            if (string.IsNullOrWhiteSpace(cleaned))
                            {
                                using (var page2 = _ocrEngine.Process(preprocessed, PageSegMode.SingleLine))
                                {
                                    rawOcr = page2.GetText();
                                    cleaned = CleanPlateText(rawOcr);
                                }
                            }

                            res.PlateNumber = cleaned;
                            res.Success = !string.IsNullOrEmpty(cleaned);
                        }
                    }
                    cropped.Dispose();
                }
            }
            catch (Exception ex)
            {
                res.ErrorMessage = "Gagal memproses gambar: " + ex.Message;
            }

            return res;
        }

        private Rectangle DetectPlateBox(Bitmap src, out float bestConf)
        {
            bestConf = 0f;
            int netW = 640;
            int netH = 640;

            float[] inputData = new float[3 * netH * netW];
            using (var resized = new Bitmap(src, new Size(netW, netH)))
            {
                BitmapData bData = resized.LockBits(new Rectangle(0, 0, netW, netH), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                int stride = bData.Stride;
                IntPtr scan0 = bData.Scan0;

                unsafe
                {
                    byte* p = (byte*)(void*)scan0;
                    for (int y = 0; y < netH; y++)
                    {
                        for (int x = 0; x < netW; x++)
                        {
                            int idx = y * stride + x * 3;
                            byte b = p[idx];
                            byte g = p[idx + 1];
                            byte r = p[idx + 2];

                            inputData[0 * (netH * netW) + y * netW + x] = r / 255.0f;
                            inputData[1 * (netH * netW) + y * netW + x] = g / 255.0f;
                            inputData[2 * (netH * netW) + y * netW + x] = b / 255.0f;
                        }
                    }
                }
                resized.UnlockBits(bData);
            }

            var inputTensor = new DenseTensor<float>(inputData, new[] { 1, 3, netH, netW });
            var inputs = new List<NamedOnnxValue>
            {
                NamedOnnxValue.CreateFromTensor("images", inputTensor)
            };

            using (var results = _session.Run(inputs))
            {
                var output = results.First().AsTensor<float>();
                int rows = output.Dimensions[2];

                float maxConf = 0f;
                float bestCx = 0, bestCy = 0, bestW = 0, bestH = 0;

                for (int i = 0; i < rows; i++)
                {
                    float conf = output[0, 4, i];
                    if (conf > 0.05f && conf > maxConf)
                    {
                        maxConf = conf;
                        bestCx = output[0, 0, i];
                        bestCy = output[0, 1, i];
                        bestW = output[0, 2, i];
                        bestH = output[0, 3, i];
                    }
                }

                bestConf = maxConf;
                if (maxConf > 0.05f)
                {
                    float scaleX = (float)src.Width / netW;
                    float scaleY = (float)src.Height / netH;

                    int x = (int)((bestCx - bestW / 2.0f) * scaleX);
                    int y = (int)((bestCy - bestH / 2.0f) * scaleY);
                    int w = (int)(bestW * scaleX);
                    int h = (int)(bestH * scaleY);

                    // Beri padding 8% agar frame plat utuh
                    int padX = (int)(w * 0.08);
                    int padY = (int)(h * 0.08);

                    x = Math.Max(0, x - padX);
                    y = Math.Max(0, y - padY);
                    w = Math.Min(src.Width - x, w + 2 * padX);
                    h = Math.Min(src.Height - y, h + 2 * padY);

                    return new Rectangle(x, y, w, h);
                }
            }

            return Rectangle.Empty;
        }

        private Bitmap CropBitmap(Bitmap src, Rectangle rect)
        {
            rect.X = Math.Max(0, rect.X);
            rect.Y = Math.Max(0, rect.Y);
            if (rect.Right > src.Width) rect.Width = src.Width - rect.X;
            if (rect.Bottom > src.Height) rect.Height = src.Height - rect.Y;

            if (rect.Width <= 0 || rect.Height <= 0)
                return new Bitmap(src);

            Bitmap target = new Bitmap(rect.Width, rect.Height);
            using (Graphics g = Graphics.FromImage(target))
            {
                g.DrawImage(src, new Rectangle(0, 0, target.Width, target.Height),
                            rect, GraphicsUnit.Pixel);
            }
            return target;
        }

        private Bitmap PreprocessPlate(Bitmap src)
        {
            // Perbesar gambar ke lebar minimum 400px untuk resolusi teks optimal
            int targetWidth = Math.Max(400, src.Width * 2);
            int targetHeight = (int)((float)src.Height / src.Width * targetWidth);

            Bitmap scaled = new Bitmap(targetWidth, targetHeight, PixelFormat.Format24bppRgb);
            using (Graphics g = Graphics.FromImage(scaled))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.DrawImage(src, 0, 0, targetWidth, targetHeight);
            }

            BitmapData data = scaled.LockBits(new Rectangle(0, 0, scaled.Width, scaled.Height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            unsafe
            {
                byte* ptr = (byte*)data.Scan0;
                int stride = data.Stride;

                // Hitung histogram / rata-rata grayscale
                long totalLum = 0;
                int count = scaled.Width * scaled.Height;

                for (int y = 0; y < scaled.Height; y++)
                {
                    byte* row = ptr + (y * stride);
                    for (int x = 0; x < scaled.Width; x++)
                    {
                        int gray = (row[x * 3 + 2] * 299 + row[x * 3 + 1] * 587 + row[x * 3] * 114) / 1000;
                        totalLum += gray;
                    }
                }
                int avgLum = (int)(totalLum / count);

                // Plat nomor standar Indonesia: latar hitam font putih jika avgLum < 128
                // Tesseract membaca lebih akurat pada latar belakang PUTIH font HITAM.
                bool needInvert = (avgLum < 120);

                for (int y = 0; y < scaled.Height; y++)
                {
                    byte* row = ptr + (y * stride);
                    for (int x = 0; x < scaled.Width; x++)
                    {
                        int gray = (row[x * 3 + 2] * 299 + row[x * 3 + 1] * 587 + row[x * 3] * 114) / 1000;
                        if (needInvert)
                        {
                            gray = 255 - gray;
                        }

                        // Tingkatkan kontras (thresholding)
                        byte val = (gray > (needInvert ? 160 : avgLum)) ? (byte)255 : (byte)0;

                        row[x * 3] = val;
                        row[x * 3 + 1] = val;
                        row[x * 3 + 2] = val;
                    }
                }
            }

            scaled.UnlockBits(data);
            return scaled;
        }

        public string CleanPlateText(string rawText)
        {
            if (string.IsNullOrEmpty(rawText)) return string.Empty;

            // Normalisasi teks
            string upper = rawText.ToUpper();
            string cleaned = Regex.Replace(upper, @"[^A-Z0-9\s]", " ");
            cleaned = Regex.Replace(cleaned, @"\s+", " ").Trim();

            // Ekstrak token yang relevan
            var tokens = cleaned.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var plateParts = new List<string>();

            foreach (var t in tokens)
            {
                // Cek kemungkinan token: Wilayah (1-2 huruf), Angka (1-4 digit), Seri akhir (1-3 huruf)
                if (Regex.IsMatch(t, @"^[A-Z]{1,2}$") || Regex.IsMatch(t, @"^[0-9]{1,4}$") || Regex.IsMatch(t, @"^[A-Z]{1,3}$"))
                {
                    plateParts.Add(t);
                }
            }

            string combined = string.Join(" ", plateParts);

            // Cocokkan pola format: [Wilayah] [Nomor] [Seri Belakang]
            var m = Regex.Match(combined, @"\b([A-Z]{1,2})\s*([0-9]{1,4})\s*([A-Z]{1,3})\b");
            if (m.Success)
            {
                return $"{m.Groups[1].Value} {m.Groups[2].Value} {m.Groups[3].Value}";
            }

            // Pola tanpa seri belakang (misal kendaraan khusus / dinas): [Wilayah] [Nomor]
            var m2 = Regex.Match(combined, @"\b([A-Z]{1,2})\s*([0-9]{1,4})\b");
            if (m2.Success)
            {
                return $"{m2.Groups[1].Value} {m2.Groups[2].Value}";
            }

            return combined;
        }

        public void Dispose()
        {
            if (_ocrEngine != null)
            {
                _ocrEngine.Dispose();
                _ocrEngine = null;
            }
            if (_session != null)
            {
                _session.Dispose();
                _session = null;
            }
        }
    }
}
