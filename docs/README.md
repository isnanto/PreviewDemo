# Indeks Dokumentasi Teknis PreviewDemo

Selamat datang di pusat dokumentasi teknis projek **PreviewDemo**. Projek ini mengintegrasikan komunikasi perangkat keras CCTV Hikvision dengan kapabilitas kecerdasan buatan pengenalan plat nomor kendaraan (ALPR).

---

## Berkas Dokumentasi

Berikut dokumen teknis yang tersedia di direktori `docs/`:

1. **[Arsitektur Desain & Spesifikasi Teknis (ARCHITECTURE.md)](ARCHITECTURE.md)**
   * Ringkasan eksekutif dan stack teknologi lengkap (.NET Framework 4.6.1, ONNX Runtime, Tesseract OCR, HCNetSDK).
   * Diagram topologi arsitektur sistem dan batas tanggung jawab tiap modul.
   * Spesifikasi integrasi perangkat CCTV Hikvision DS-2CD1021-I.
   * Penjelasan mendalam pipeline visi komputer AI ALPR (Deteksi Box YOLOv8n, Cropping, Grayscale Binarization, OCR & Regex Plat Nomor Indonesia).
   * Panduan kompilasi MSBuild dan struktur binary deployment.
   * Matriks penanganan masalah teknis (troubleshooting).

2. **[Panduan Operasional & Pengujian (USER_GUIDE.md)](USER_GUIDE.md)**
   * Panduan koneksi ke IP Camera jaringan lokal.
   * Langkah-langkah menjalankan live preview dan snapshot plat nomor.
   * Petunjuk pengujian pengenalan plat nomor secara offline / simulasi gambar.

---

## Lokasi Berkas Fisik di Sistem

* Direktori Dokumentasi: `D:\Project\PreviewDemo\docs\`
* Berkas Arsitektur: `D:\Project\PreviewDemo\docs\ARCHITECTURE.md`
* Berkas Panduan: `D:\Project\PreviewDemo\docs\USER_GUIDE.md`
