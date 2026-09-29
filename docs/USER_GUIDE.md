# Panduan Pengoperasian & Pengujian Sistem PreviewDemo

Dokumen ini memuat langkah-langkah praktis menjalankan aplikasi, menghubungkan ke IP Camera Hikvision DS-2CD1021-I, mengambil snapshot, serta memverifikasi pembacaan plat nomor otomatis.

---

## 1. Persiapan Awal

1. Pastikan IP Camera Hikvision aktif dalam satu segmen jaringan lokal (LAN) yang dapat dijangkau oleh komputer (misal IP default: `172.16.99.65` atau `192.168.1.64`).
2. Pastikan port server SDK kamera terbuka (port default: `8000`).
3. Pastikan kredensial user admin kamera sudah terkonfigurasi.

---

## 2. Menjalankan Aplikasi

1. Buka folder output kompilasi:
   `D:\Project\PreviewDemo\PreviewDemo_VB\bin\Release\` (atau `bin\Debug\`).
2. Jalankan berkas `PreviewDemo_VB.exe`.
3. Masukkan parameter login kamera pada panel antarmuka:
   * **IP Address**: Alamat IP kamera (contoh: `172.16.99.65`).
   * **Port**: `8000`.
   * **User ID**: Username kamera (contoh: `admin`).
   * **Password**: Password kamera.
4. Klik tombol **Login**. Jika berhasil, kotak dialog konfirmasi akan muncul.

---

## 3. Streaming Video & Capture Plat Nomor

1. Masukkan nomor channel pada kolom **Chanel** (untuk IP Camera mandiri/standalone gunakan `1`).
2. Klik tombol **Preview** untuk memulai tayangan video real-time. Feed video akan tampil pada panel hitam (*RealPlayWnd*).
3. Ketika kendaraan berada pada posisi yang jelas di depan gerbang:
   * Klik tombol **Capture**.
4. Sistem akan secara otomatis:
   * Mengambil snapshot gambar JPEG langsung dari stream kamera (`JPEG_test.jpg`).
   * Melakukan resize gambar thumbnail (`small.jpg`).
   * Menjalankan model AI YOLOv8 untuk mendeteksi area plat nomor.
   * Melakukan pra-pemrosesan citra (binarisasi dan auto-inversi kontras).
   * Menjalankan ekstraksi teks OCR Tesseract dan sanitasi regex plat nomor Indonesia.
5. Hasil pengenalan akan langsung ditampilkan di antarmuka:
   * Teks plat nomor muncul pada kotak kuning **Plat Nomor** (misal: `B 1234 ABC`).
   * Potongan citra plat nomor yang dideteksi akan tampil pada kotak preview gambar kecil (**PicPlateCrop**) di samping kanan.

---

## 4. Pengujian Mandiri Tanpa Kamera Fisik

Jika sedang tidak terhubung langsung dengan perangkat CCTV fisik, modul ALPR tetap dapat diuji secara independen:
1. Jalankan unit test melalui script / binary penguji:
   * Tempatkan gambar kendaraan uji berformat `.jpg` di root direktori atau panggil via konsol.
2. Hasil ekstraksi teks plat dan crop citra akan disimpan langsung untuk evaluasi akurasi.
