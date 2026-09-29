# Dokumentasi Sistem PreviewDemo & Automated License Plate Recognition (ALPR)

Dokumentasi komprehensif arsitektur, integrasi perangkat keras CCTV Hikvision, pipeline pengolahan citra kecerdasan buatan (AI/OCR), spesifikasi modul, dan petunjuk operasional sistem.

---

## Daftar Isi
1. [Ringkasan Eksekutif & Tujuan](#1-ringkasan-eksekutif--tujuan)
2. [Stack Teknologi & Prasyarat Sistem](#2-stack-teknologi--prasyarat-sistem)
3. [Arsitektur Sistem & Topologi Solusi](#3-arsitektur-sistem--topologi-solusi)
4. [Integrasi Perangkat Keras Hikvision](#4-integrasi-perangkat-keras-hikvision)
5. [Pipeline Arsitektur ALPR (YOLOv8 + OCR)](#5-pipeline-arsitektur-alpr-yolov8--ocr)
6. [Struktur Kode & Rincian Modul](#6-struktur-kode--rincian-modul)
7. [Panduan Kompilasi, Deployment & Konfigurasi](#7-panduan-kompilasi-deployment--konfigurasi)
8. [Penanganan Kendala (Troubleshooting)](#8-penanganan-kendala-troubleshooting)

---

## 1. Ringkasan Eksekutif & Tujuan

Aplikasi **PreviewDemo** dirancang untuk menghubungkan workstation Windows dengan perangkat kamera pengawas (CCTV / IP Camera / NVR) Hikvision. Sistem ini menyediakan antarmuka terpadu untuk:
* Streaming video real-time (*live preview*).
* Manajemen sesi login dan status perangkat berbasis IP/Port.
* Kontrol mekanikal kamera PTZ (*Pan-Tilt-Zoom*).
* Pengambilan gambar snapshot statis (BMP/JPEG).
* **Automated License Plate Recognition (ALPR)**: Pengenalan plat nomor kendaraan bermotor Indonesia secara otomatis dari gambar snapshot kamera gerbang/portal tanpa memerlukan server AI eksternal (*embedded client-side inference*).

Sistem ini ditargetkan untuk skenario otomatisasi gerbang parkir, verifikasi kendaraan tamu/karyawan faskes, serta pos keamanan gerbang masuk.

---

## 2. Stack Teknologi & Prasyarat Sistem

### 2.1 Framework & Runtime
* **Platform Utama**: Microsoft Windows (Desktop x86 / x64).
* **Target Framework**: .NET Framework 4.6.1.
* **UI Toolkit**: Windows Forms (WinForms).
* **Bahasa Pemrograman**:
  * **C# 7.3**: Core interop library (`MySDK`) & recognizer engine.
  * **VB.NET**: Antarmuka aplikasi interaktif (`PreviewDemo_VB`).

### 2.2 Dependensi & Library Utama
* **Hikvision Device Network SDK (HCNetSDK)**:
  * `HCNetSDK.dll`, `HCCore.dll`, sub-komponen `HCNetSDKCom/`.
  * Interop native via P/Invoke `System.Runtime.InteropServices`.
* **Kecerdasan Buatan & Inferensi ONNX**:
  * `Microsoft.ML.OnnxRuntime` (v1.19.2) & `Microsoft.ML.OnnxRuntime.Managed`.
  * Model: `models/license_plate_yolov8n.onnx` (YOLOv8 Nano deteksi plat nomor).
* **Optical Character Recognition (OCR)**:
  * `Tesseract.NET` (v4.1.1 wrapper untuk Google Tesseract OCR v4 / Leptonica).
  * Data Kamus Karakter: `tessdata/eng.traineddata`.
* **Manipulasi Citra**:
  * `System.Drawing` (GDI+) dengan *unsafe pointers* (`BitmapData`) untuk kalkulasi binarisasi piksel berkecepatan tinggi.

---

## 3. Arsitektur Sistem & Topologi Solusi

Solusi terbagi ke dalam 3 sub-projek modular pada `PreviewDemo.sln`:

```
                       ┌─────────────────────────────────────────┐
                       │           PreviewDemo.sln               │
                       └────────────────────┬────────────────────┘
                                            │
         ┌──────────────────────────────────┼──────────────────────────────────┐
         │                                  │                                  │
         ▼                                  ▼                                  ▼
┌──────────────────┐               ┌──────────────────┐               ┌──────────────────┐
│      MySDK       │               │  PreviewDemo_VB  │               │   PreviewDemo    │
│  (Class Library) │               │ (WinForms Client)│               │  (C# WinForms)   │
└────────┬─────────┘               └────────┬─────────┘               └──────────────────┘
         │                                  │
         │  ◄────── Direct Reference ───────┤
         │                                  │
         ├──────────────────────────────────┼──────────────────────────────────┐
         │                                  │                                  │
         ▼                                  ▼                                  ▼
┌──────────────────┐               ┌──────────────────┐               ┌──────────────────┐
│ Hikvision Native │               │ ONNX Runtime     │               │ Tesseract Engine │
│ HCNetSDK.dll     │               │ onnxruntime.dll  │               │ tesseract41.dll  │
└──────────────────┘               └──────────────────┘               └──────────────────┘
```

### Tanggung Jawab Modul:
1. **`MySDK`**:
   * Menampung `CHCNetSDK.cs` sebagai gerbang deklarasi fungsi P/Invoke C++ native Hikvision.
   * Menampung `LicensePlateRecognizer.cs` sebagai mesin AI ALPR yang mengorkestrasi pipeline YOLOv8 dan OCR.
2. **`PreviewDemo_VB`**:
   * Menangani interaksi UI operator, rendering live preview ke `PictureBox`, tombol capture, serta display hasil nomor plat dan crop visual.
3. **`PreviewDemo`**:
   * Implementasi dasar C# dari vendor Hikvision untuk referensi kontrol PTZ preset.

---

## 4. Integrasi Perangkat Keras Hikvision

Sistem diuji dan dioptimalkan untuk lini IP Camera Hikvision fixed bullet standar (seperti **DS-2CD1021-I / DS-2CD1021-L**):
* **Resolusi**: 2 Megapixel (1920x1080 atau 1280x720).
* **Protokol Komunikasi**: TCP/IP via port default `8000`.
* **Karakteristik Kamera**: Merupakan non-ANPR hardware camera (kamera tidak memiliki NPU internal untuk mendeteksi plat). Seluruh komputasi visi komputer dialihkan ke workstation client.

### Alur Siklus Komunikasi Perangkat:
1. **Inisialisasi SDK**:
   `NET_DVR_Init()` dijalankan saat form dimuat (`Form1_Load`).
2. **Login Perangkat**:
   `NET_DVR_Login_V30(ip, port, user, pass, ref deviceInfo)` menghasilkan `m_lUserID`.
3. **Streaming Feed (Live View)**:
   `NET_DVR_RealPlay_V40` mengaitkan video stream langsung ke handle window `RealPlayWnd.Handle` (`IntPtr`).
4. **Pengambilan Snapshot**:
   `NET_DVR_CaptureJPEGPicture(m_lUserID, channel, ref jpegPara, fileName)` mengambil frame JPEG resolusi penuh langsung dari stream perangkat.

---

## 5. Pipeline Arsitektur ALPR (YOLOv8 + OCR)

Pengenalan plat nomor mengadopsi pipeline 4 tahap deterministik:

```
[ Snapshot Kamera ] ──> (1280x720 / 1920x1080 JPEG)
        │
        ▼
[ 1. Deteksi Plat Nomor (YOLOv8n ONNX) ]
        │ • Resize citra ke 640x640 (RGB)
        │ • Normalisasi float 0.0 - 1.0
        │ • Inferensi: Tensor Shape [1, 3, 640, 640] ──> Output [1, 5, 8400]
        │ • Ekstraksi Bounding Box (cx, cy, w, h) & Confidence Filter
        ▼
[ 2. Crop ROI & Padding ]
        │ • Proyeksikan koordinat 640x640 ke resolusi asli
        │ • Tambahkan margin padding 8% untuk toleransi sudut
        │ • Ekstraksi Bitmap potongan plat
        ▼
[ 3. Pra-Pemrosesan Citra Plat (GDI+ Unsafe Pointers) ]
        │ • Upscaling ke minimal lebar 400px (Bicubic Interpolation)
        │ • Grayscale: Y = (0.299*R + 0.587*G + 0.114*B)
        │ • Deteksi Warna Latar: Hitung rata-rata kecerahan
        │ • Auto-Invert: Bila latar gelap (<120), balik ke latar terang
        │ • Binarisasi adaptif: Threshold kontras tinggi untuk ketajaman font
        ▼
[ 4. Text Recognition & Regex Filter ]
        │ • Tesseract OCR (Karakter whitelist: A-Z, 0-9)
        │ • Regex Sanitizer: `\b([A-Z]{1,2})\s*([0-9]{1,4})\s*([A-Z]{1,3})\b`
        │ • Eliminasi baris bulan/tahun masa berlaku pajak
        ▼
[ Hasil UI WinForms ] ──> TxtPlateNumber ("B 1234 ABC") & PicPlateCrop
```

---

## 6. Struktur Kode & Rincian Modul

### 6.1 `MySDK/LicensePlateRecognizer.cs`
Kelas pembungkus logika AI mandiri.
* **`ProcessImage(string imagePath)`**: Fungsi utama publik yang menerima path file gambar dan mengembalikan objek `PlateDetectionResult`.
* **`DetectPlateBox(Bitmap src, out float bestConf)`**: Menjalankan ONNX Runtime session, membentuk input tensor, dan membaca tensor output `output0` untuk mencari box plat nomor dengan confidence terbaik.
* **`PreprocessPlate(Bitmap src)`**: Melakukan operasi manipulasi piksel tingkat memori (*unsafe pointer*) tanpa overhead marshaling untuk mempersiapkan citra sebelum dibaca Tesseract.
* **`CleanPlateText(string rawText)`**: Membersihkan noise OCR dan memvalidasi struktur plat nomor Indonesia menggunakan ekspresi reguler.

### 6.2 `PreviewDemo_VB/Form1.vb`
Antarmuka pengguna berbasis event.
* **`btnJPEG_Click`**: Handler klik tombol capture. Mengambil gambar via SDK Hikvision, melakukan resize thumbnail `small.jpg`, lalu meneruskan file snapshot ke `RecognizePlateFromSnapshot()`.
* **`RecognizePlateFromSnapshot(filePath As String)`**: Menghubungi instance `MySDK.LicensePlateRecognizer`, menerima hasil plat, mengisi nilai string ke `TxtPlateNumber`, dan menampilkan potongan plat ke `PicPlateCrop`.

---

## 7. Panduan Kompilasi, Deployment & Konfigurasi

### 7.1 Struktur Folder Output Binary
Agar aplikasi dapat berjalan sempurna di mesin produksi Windows, susunan folder pada `bin\Debug\` atau `bin\Release\` harus mengikuti struktur:

```
bin\Release\
├── PreviewDemo_VB.exe                 # Executable utama
├── PreviewDemo_VB.exe.config
├── MySDK.dll                          # Class library bridge
├── Microsoft.ML.OnnxRuntime.dll       # Managed ONNX wrapper
├── onnxruntime.dll                    # Native C++ ONNX runtime (x86/x64)
├── Tesseract.dll                      # Managed Tesseract wrapper
├── x86\                               # Native OCR Binaries (32-bit)
│   ├── leptonica-1.80.0.dll
│   └── tesseract41.dll
├── x64\                               # Native OCR Binaries (64-bit)
│   ├── leptonica-1.80.0.dll
│   └── tesseract41.dll
├── models\
│   └── license_plate_yolov8n.onnx     # Model AI Deteksi Plat
├── tessdata\
│   └── eng.traineddata                # Dataset Karakter Tesseract
└── HCNetSDK.dll                       # Library Native Hikvision
    ├── HCCore.dll
    └── HCNetSDKCom\                   # Folder komponen SDK Hikvision
```

### 7.2 Prosedur Kompilasi via CLI (MSBuild)
Kompilasi dapat dijalankan langsung melalui MSBuild Visual Studio:
```powershell
# Restore dependensi NuGet
& "D:\Project\PreviewDemo\nuget.exe" restore D:\Project\PreviewDemo\PreviewDemo.sln

# Kompilasi Release x86
& "C:\Program Files\Microsoft Visual Studio\18\Community\MSBuild\Current\Bin\MSBuild.exe" `
    D:\Project\PreviewDemo\PreviewDemo.sln /p:Configuration=Release /p:Platform=x86 /t:Build
```

---

## 8. Penanganan Kendala (Troubleshooting)

| Gejala Kendala | Kemungkinan Penyebab | Tindakan Solusi |
|---|---|---|
| `DllNotFoundException: Unable to load DLL 'HCNetSDK.dll'` | File DLL native Hikvision belum disalin ke root binary. | Pastikan `HCNetSDK.dll`, `HCCore.dll`, dan folder `HCNetSDKCom/` berada di satu folder bersama `.exe`. |
| `DllNotFoundException: Unable to load DLL 'tesseract41.dll'` | Folder arsitektur `x86/` atau `x64/` tidak ditemukan di direktori eksekusi. | Verifikasi bahwa MSBuild telah menyalin folder `x86\` dan `x64\` beserta file `tesseract41.dll` dan `leptonica-1.80.0.dll`. |
| `OnnxRuntimeException: No such file or directory: models/...` | Model ONNX tidak ditemukan di path target. | Pastikan file `license_plate_yolov8n.onnx` ada di folder `models\` relatif terhadap direktori kerja aplikasi. |
| Plat nomor terbaca `TIDAK TERBACA` | Sudut kamera terlalu tajam, pencahayaan silau (*glare*), atau jarak kendaraan terlalu jauh. | Posisikan kamera DS-2CD1021-I dengan sudut horizontal < 30 derajat terhadap jalur kendaraan dan jarak optimal 3 - 6 meter. |
| Nomor plat terbaca sebagian | Bounding box terpotong atau font plat terdistorsi. | Tingkatkan margin padding pada `LicensePlateRecognizer.cs` (`padX`/`padY`) atau sesuaikan threshold binarisasi. |
