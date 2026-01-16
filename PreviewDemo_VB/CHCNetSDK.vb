Imports System
Imports System.Runtime.InteropServices

Public Module CHCNetSDK


    Public Const SDK_PLAYMPEG4 As Integer = 1   ' Library pemutaran (playback)
    Public Const SDK_HCNETSDK As Integer = 2    ' Library jaringan (network)

    Public Const NAME_LEN As Integer = 32       ' Panjang maksimum username
    Public Const PASSWD_LEN As Integer = 16     ' Panjang maksimum password
    Public Const GUID_LEN As Integer = 16       ' Panjang GUID
    Public Const DEV_TYPE_NAME_LEN As Integer = 24  ' Panjang nama tipe perangkat
    Public Const MAX_NAMELEN As Integer = 16    ' Panjang nama login lokal DVR
    Public Const MAX_RIGHT As Integer = 32      ' Jumlah hak akses yang didukung perangkat (1-12 lokal, 13-32 remote)
    Public Const SERIALNO_LEN As Integer = 48   ' Panjang nomor seri
    Public Const MACADDR_LEN As Integer = 6     ' Panjang alamat MAC
    Public Const MAX_ETHERNET As Integer = 2    ' Maksimum jumlah port Ethernet yang bisa dikonfigurasi
    Public Const MAX_NETWORK_CARD As Integer = 4 ' Maksimum jumlah kartu jaringan yang bisa dikonfigurasi
    Public Const PATHNAME_LEN As Integer = 128  ' Panjang path

    Public Const MAX_NUMBER_LEN As Integer = 32 ' Panjang maksimum nomor (string angka)
    Public Const MAX_NAME_LEN As Integer = 128  ' Panjang maksimum nama perangkat

    Public Const MAX_TIMESEGMENT_V30 As Integer = 8  ' Maksimum jumlah segmen waktu (seri 9000)
    Public Const MAX_TIMESEGMENT As Integer = 4      ' Maksimum jumlah segmen waktu (seri 8000)
    Public Const MAX_ICR_NUM As Integer = 8          ' Jumlah preset ICR (filter IR) pada kamera (snapshot)

    Public Const MAX_SHELTERNUM As Integer = 4       ' Maksimum jumlah area “shelter/遮挡” (masking) (seri 8000)
    Public Const PHONENUMBER_LEN As Integer = 32     ' Panjang maksimum nomor dial PPPoE

    Public Const MAX_DISKNUM As Integer = 16         ' Maksimum jumlah harddisk (seri 8000)
    Public Const MAX_DISKNUM_V10 As Integer = 8      ' Maksimum harddisk untuk versi sebelum 1.2

    Public Const MAX_WINDOW_V30 As Integer = 32      ' Maksimum jumlah window playback lokal (seri 9000)
    Public Const MAX_WINDOW As Integer = 16          ' Maksimum jumlah window (seri 8000)
    Public Const MAX_VGA_V30 As Integer = 4          ' Maksimum jumlah output VGA (seri 9000)
    Public Const MAX_VGA As Integer = 1              ' Maksimum jumlah output VGA (seri 8000)

    Public Const MAX_USERNUM_V30 As Integer = 32     ' Maksimum jumlah user (seri 9000)
    Public Const MAX_USERNUM As Integer = 16         ' Maksimum jumlah user (seri 8000)
    Public Const MAX_EXCEPTIONNUM_V30 As Integer = 32 ' Maksimum jumlah penanganan exception (seri 9000)
    Public Const MAX_EXCEPTIONNUM As Integer = 16    ' Maksimum jumlah penanganan exception (seri 8000)
    Public Const MAX_LINK As Integer = 6             ' Maksimum koneksi stream video per channel (seri 8000)
    Public Const MAX_ITC_EXCEPTIONOUT As Integer = 32 ' Maksimum output alarm pada kamera capture/snapshot

    Public Const MAX_DECPOOLNUM As Integer = 4       ' Maksimum jumlah decode dalam loop per channel decoder (single-channel decoder)
    Public Const MAX_DECNUM As Integer = 4           ' Maksimum jumlah channel decode (sebenarnya 1, sisanya reserved)
    Public Const MAX_TRANSPARENTNUM As Integer = 2   ' Maksimum jumlah channel transparan yang dapat dikonfigurasi
    Public Const MAX_CYCLE_CHAN As Integer = 16      ' Maksimum channel untuk mode cycle/round-robin
    Public Const MAX_CYCLE_CHAN_V30 As Integer = 64  ' Maksimum channel cycle/round-robin (extended)
    Public Const MAX_DIRNAME_LENGTH As Integer = 80  ' Panjang maksimum nama direktori

    Public Const MAX_STRINGNUM_V30 As Integer = 8    ' Maksimum jumlah baris OSD (seri 9000)
    Public Const MAX_STRINGNUM As Integer = 4        ' Maksimum jumlah baris OSD (seri 8000)
    Public Const MAX_STRINGNUM_EX As Integer = 8     ' Ekstensi kustom untuk seri 8000
    Public Const MAX_AUXOUT_V30 As Integer = 16      ' Maksimum output tambahan/aux (seri 9000)
    Public Const MAX_AUXOUT As Integer = 4           ' Maksimum output tambahan/aux (seri 8000)
    Public Const MAX_HD_GROUP As Integer = 16        ' Maksimum grup harddisk (seri 9000)
    Public Const MAX_NFS_DISK As Integer = 8         ' Maksimum disk NFS (seri 8000)

    Public Const IW_ESSID_MAX_SIZE As Integer = 32        ' Panjang SSID WiFi
    Public Const IW_ENCODING_TOKEN_MAX As Integer = 32    ' Maksimum byte untuk kunci enkripsi WiFi
    Public Const WIFI_WEP_MAX_KEY_COUNT As Integer = 4
    Public Const WIFI_WEP_MAX_KEY_LENGTH As Integer = 33
    Public Const WIFI_WPA_PSK_MAX_KEY_LENGTH As Integer = 63
    Public Const WIFI_WPA_PSK_MIN_KEY_LENGTH As Integer = 8
    Public Const WIFI_MAX_AP_COUNT As Integer = 20
    Public Const MAX_SERIAL_NUM As Integer = 64           ' Maksimum jumlah jalur channel transparan yang didukung

    Public Const MAX_DDNS_NUMS As Integer = 10            ' Maksimum jumlah DDNS (seri 9000)
    Public Const MAX_EMAIL_ADDR_LEN As Integer = 48       ' Panjang maksimum alamat email
    Public Const MAX_EMAIL_PWD_LEN As Integer = 32        ' Panjang maksimum password email

    Public Const MAXPROGRESS As Integer = 100             ' Progres maksimum saat playback (persentase)
    Public Const MAX_SERIALNUM As Integer = 2             ' Jumlah port serial (1=RS232, 2=RS485)
    Public Const CARDNUM_LEN As Integer = 20              ' Panjang nomor kartu
    Public Const CARDNUM_LEN_OUT As Integer = 32          ' Panjang nomor kartu pada struktur eksternal
    Public Const MAX_VIDEOOUT_V30 As Integer = 4          ' Maksimum output video (seri 9000)
    Public Const MAX_VIDEOOUT As Integer = 2              ' Maksimum output video (seri 8000)

    Public Const MAX_PRESET_V30 As Integer = 256          ' Jumlah preset PTZ yang didukung (seri 9000)
    Public Const MAX_TRACK_V30 As Integer = 256           ' Jumlah track/jejak PTZ yang didukung (seri 9000)
    Public Const MAX_CRUISE_V30 As Integer = 256          ' Jumlah cruise PTZ yang didukung (seri 9000)
    Public Const MAX_PRESET As Integer = 128              ' Jumlah preset PTZ yang didukung (seri 8000)
    Public Const MAX_TRACK As Integer = 128               ' Jumlah track/jejak PTZ yang didukung (seri 8000)
    Public Const MAX_CRUISE As Integer = 128              ' Jumlah cruise PTZ yang didukung (seri 8000)

    Public Const CRUISE_MAX_PRESET_NUMS As Integer = 32   ' Maksimum jumlah titik preset dalam 1 cruise

    Public Const MAX_SERIAL_PORT As Integer = 8           ' Jumlah port serial RS232 yang didukung (seri 9000)
    Public Const MAX_PREVIEW_MODE As Integer = 8          ' Maksimum mode preview (1,4,9,16, dst.)
    Public Const MAX_MATRIXOUT As Integer = 16            ' Maksimum jumlah output matrix analog
    Public Const LOG_INFO_LEN As Integer = 11840          ' Panjang info tambahan log
    Public Const DESC_LEN As Integer = 16                 ' Panjang string deskripsi PTZ
    Public Const PTZ_PROTOCOL_NUM As Integer = 200        ' Maksimum jumlah protokol PTZ (seri 9000)

    Public Const MAX_AUDIO As Integer = 1                 ' Jumlah channel audio intercom (seri 8000)
    Public Const MAX_AUDIO_V30 As Integer = 2             ' Jumlah channel audio intercom (seri 9000)
    Public Const MAX_CHANNUM As Integer = 16              ' Maksimum jumlah channel (seri 8000)
    Public Const MAX_ALARMIN As Integer = 16              ' Maksimum jumlah input alarm (seri 8000)
    Public Const MAX_ALARMOUT As Integer = 4              ' Maksimum jumlah output alarm (seri 8000)

    ' 9000 IPC (dukungan channel analog/alarm analog)
    Public Const MAX_ANALOG_CHANNUM As Integer = 32       ' Maksimum 32 channel analog
    Public Const MAX_ANALOG_ALARMOUT As Integer = 32      ' Maksimum 32 output alarm analog
    Public Const MAX_ANALOG_ALARMIN As Integer = 32       ' Maksimum 32 input alarm analog

    Public Const MAX_IP_DEVICE As Integer = 32            ' Maksimum perangkat IP yang dapat ditambahkan
    Public Const MAX_IP_DEVICE_V40 As Integer = 64        ' Maksimum perangkat IP yang dapat ditambahkan (v4.0)
    Public Const MAX_IP_CHANNEL As Integer = 32           ' Maksimum channel IP yang dapat ditambahkan
    Public Const MAX_IP_ALARMIN As Integer = 128          ' Maksimum input alarm IP yang dapat ditambahkan
    Public Const MAX_IP_ALARMOUT As Integer = 64          ' Maksimum output alarm IP yang dapat ditambahkan
    Public Const MAX_IP_ALARMIN_V40 As Integer = 4096     ' Maksimum input alarm IP (v4.0)
    Public Const MAX_IP_ALARMOUT_V40 As Integer = 4096    ' Maksimum output alarm IP (v4.0)

    Public Const MAX_RECORD_FILE_NUM As Integer = 20      ' Maksimum jumlah file record yang dihapus/backup per operasi

    ' SDK_V31 ATM
    Public Const MAX_ATM_NUM As Integer = 1                 ' Maksimum jumlah ATM
    Public Const MAX_ACTION_TYPE As Integer = 12            ' Maksimum tipe aksi
    Public Const ATM_FRAMETYPE_NUM As Integer = 4           ' Jumlah tipe frame ATM
    Public Const MAX_ATM_PROTOCOL_NUM As Integer = 1025     ' Maksimum jumlah protokol ATM
    Public Const ATM_PROTOCOL_SORT As Integer = 4           ' Kategori/kelompok protokol ATM
    Public Const ATM_DESC_LEN As Integer = 32               ' Panjang deskripsi ATM
    ' SDK_V31 ATM

    ' Maksimum channel yang didukung = maksimum analog + maksimum IP
    Public Const MAX_CHANNUM_V30 As Integer = MAX_ANALOG_CHANNUM + MAX_IP_CHANNEL      ' 64
    Public Const MAX_ALARMOUT_V30 As Integer = MAX_ANALOG_ALARMOUT + MAX_IP_ALARMOUT   ' 96
    Public Const MAX_ALARMIN_V30 As Integer = MAX_ANALOG_ALARMIN + MAX_IP_ALARMIN      ' 160

    Public Const MAX_CHANNUM_V40 As Integer = 512
    Public Const MAX_ALARMOUT_V40 As Integer = MAX_IP_ALARMOUT_V40 + MAX_ANALOG_ALARMOUT ' 4128
    Public Const MAX_ALARMIN_V40 As Integer = MAX_IP_ALARMIN_V40 + MAX_ANALOG_ALARMOUT   ' 4128 (sesuai sumber)
    Public Const MAX_MULTI_AREA_NUM As Integer = 24

    Public Const MAX_HUMAN_PICTURE_NUM As Integer = 10      ' Maksimum jumlah foto
    Public Const MAX_HUMAN_BIRTHDATE_LEN As Integer = 10    ' Panjang tanggal lahir (YYYY-MM-DD)

    Public Const MAX_LAYERNUMS As Integer = 32              ' Maksimum jumlah layer

    Public Const MAX_ROIDETECT_NUM As Integer = 8           ' Jumlah area ROI yang didukung
    Public Const MAX_LANERECT_NUM As Integer = 5            ' Maksimum jumlah area pengenalan plat (lane)
    Public Const MAX_FORTIFY_NUM As Integer = 10            ' Maksimum jumlah area/zone “fortify” (area pengamanan)
    Public Const MAX_INTERVAL_NUM As Integer = 4            ' Maksimum jumlah interval waktu
    Public Const MAX_CHJC_NUM As Integer = 3                ' Maksimum jumlah karakter singkatan provinsi kendaraan
    Public Const MAX_VL_NUM As Integer = 5                  ' Maksimum jumlah garis virtual (virtual line)
    Public Const MAX_DRIVECHAN_NUM As Integer = 16          ' Maksimum jumlah lajur/jalur kendaraan (drive channel)
    Public Const MAX_COIL_NUM As Integer = 3                ' Maksimum jumlah coil/loop
    Public Const MAX_SIGNALLIGHT_NUM As Integer = 6         ' Maksimum jumlah lampu sinyal

    Public Const LEN_32 As Integer = 32
    Public Const LEN_31 As Integer = 31

    Public Const MAX_CABINET_COUNT As Integer = 8           ' Maksimum jumlah kabinet yang didukung
    Public Const MAX_ID_LEN As Integer = 48                 ' Panjang maksimum ID
    Public Const MAX_PARKNO_LEN As Integer = 16             ' Panjang maksimum nomor parkir
    Public Const MAX_ALARMREASON_LEN As Integer = 32        ' Panjang maksimum alasan alarm
    Public Const MAX_UPGRADE_INFO_LEN As Integer = 48       ' Info pencocokan file upgrade (upgrade fuzzy)
    Public Const MAX_CUSTOMDIR_LEN As Integer = 32          ' Panjang maksimum direktori kustom

    Public Const MAX_TRANSPARENT_CHAN_NUM As Integer = 4    ' Maksimum channel transparan per port serial
    Public Const MAX_TRANSPARENT_ACCESS_NUM As Integer = 4  ' Maksimum host yang dapat mengakses per port monitoring

    ' ITS (Intelligent Traffic System)
    Public Const MAX_PARKING_STATUS As Integer = 8          ' Status parkir: 0=tidak ada mobil, 1=ada mobil, 2=menekan garis (prioritas tertinggi), 3=parkir khusus
    Public Const MAX_PARKING_NUM As Integer = 4             ' Maksimum 4 slot parkir per channel (dari kiri ke kanan: index 0-3)

    Public Const MAX_ITS_SCENE_NUM As Integer = 16          ' Maksimum jumlah scene
    Public Const MAX_SCENE_TIMESEG_NUM As Integer = 16      ' Maksimum jumlah time-segment per scene
    Public Const MAX_IVMS_IP_CHANNEL As Integer = 128       ' Maksimum jumlah channel IP (iVMS)

    Public Const DEVICE_ID_LEN As Integer = 48              ' Panjang ID perangkat
    Public Const MONITORSITE_ID_LEN As Integer = 48         ' Panjang ID titik monitoring
    Public Const MAX_AUXAREA_NUM As Integer = 16            ' Maksimum jumlah area tambahan (aux)
    Public Const MAX_SLAVE_CHANNEL_NUM As Integer = 16      ' Maksimum jumlah channel slave

    Public Const MAX_SCH_TASKS_NUM As Integer = 10          ' Maksimum jumlah task jadwal

    Public Const MAX_SERVERID_LEN As Integer = 64           ' Panjang maksimum Server ID
    Public Const MAX_SERVERDOMAIN_LEN As Integer = 128      ' Panjang maksimum domain server
    Public Const MAX_AUTHENTICATEID_LEN As Integer = 64     ' Panjang maksimum ID autentikasi
    Public Const MAX_AUTHENTICATEPASSWD_LEN As Integer = 32 ' Panjang maksimum password autentikasi
    Public Const MAX_SERVERNAME_LEN As Integer = 64         ' Panjang maksimum username server
    Public Const MAX_COMPRESSIONID_LEN As Integer = 64      ' Panjang maksimum ID kompresi/encoding
    Public Const MAX_SIPSERVER_ADDRESS_LEN As Integer = 128 ' Panjang alamat SIP server (domain atau IP)

    ' Alarm “tekan garis” (line-press alarm)
    Public Const MAX_PlATE_NO_LEN As Integer = 32           ' Panjang maksimum nomor plat (2013-09-27)
    Public Const UPNP_PORT_NUM As Integer = 12              ' Jumlah port mapping UPnP

    Public Const MAX_LOCAL_ADDR_LEN As Integer = 96         ' Maksimum jumlah segmen jaringan lokal untuk SOCKS
    Public Const MAX_COUNTRY_NAME_LEN As Integer = 4        ' Panjang singkatan nama negara

    Public Const THERMOMETRY_ALARMRULE_NUM As Integer = 40  ' Jumlah aturan alarm termometri (thermal)

    Public Const ACS_CARD_NO_LEN As Integer = 32            ' Panjang nomor kartu akses (access control)
    Public Const MAX_ID_NUM_LEN As Integer = 32             ' Panjang maksimum nomor identitas
    Public Const MAX_ID_NAME_LEN As Integer = 128           ' Panjang maksimum nama
    Public Const MAX_ID_ADDR_LEN As Integer = 280           ' Panjang maksimum alamat
    Public Const MAX_ID_ISSUING_AUTHORITY_LEN As Integer = 128 ' Panjang maksimum instansi penerbit

    Public Const MAX_CARD_RIGHT_PLAN_NUM As Integer = 4     ' Maksimum jumlah rencana hak akses kartu
    Public Const MAX_GROUP_NUM_128 As Integer = 128         ' Maksimum jumlah grup
    Public Const MAX_CARD_READER_NUM As Integer = 64        ' Maksimum jumlah card reader
    Public Const MAX_SNEAK_PATH_NODE As Integer = 8         ' Maksimum jumlah node “sneak path” (pembaca lanjutan)
    Public Const MAX_MULTI_DOOR_INTERLOCK_GROUP As Integer = 8 ' Maksimum grup interlock multi-pintu
    Public Const MAX_INTER_LOCK_DOOR_NUM As Integer = 8     ' Maksimum jumlah pintu dalam 1 grup interlock
    Public Const MAX_CASE_SENSOR_NUM As Integer = 8         ' Maksimum jumlah case sensor
    Public Const MAX_DOOR_NUM_256 As Integer = 256          ' Maksimum jumlah pintu
    Public Const MAX_READER_ROUTE_NUM As Integer = 16       ' Maksimum rute urutan pembacaan kartu
    Public Const MAX_FINGER_PRINT_NUM As Integer = 10       ' Maksimum jumlah sidik jari
    Public Const MAX_CARD_READER_NUM_512 As Integer = 512   ' Maksimum jumlah card reader (varian)
    Public Const NET_SDK_MULTI_CARD_GROUP_NUM_20 As Integer = 20 ' Maksimum grup multi-kartu per pintu
    Public Const CARD_PASSWORD_LEN As Integer = 8           ' Panjang password kartu
    Public Const MAX_DOOR_CODE_LEN As Integer = 8           ' Panjang kode ruangan
    Public Const MAX_LOCK_CODE_LEN As Integer = 8           ' Panjang kode kunci

    Public Const MAX_NOTICE_NUMBER_LEN As Integer = 32      ' Panjang maksimum nomor pengumuman
    Public Const MAX_NOTICE_THEME_LEN As Integer = 64       ' Panjang maksimum tema pengumuman
    Public Const MAX_NOTICE_DETAIL_LEN As Integer = 1024    ' Panjang maksimum detail pengumuman
    Public Const MAX_NOTICE_PIC_NUM As Integer = 6          ' Maksimum jumlah gambar pada pengumuman
    Public Const MAX_DEV_NUMBER_LEN As Integer = 32         ' Panjang maksimum nomor perangkat
    Public Const LOCK_NAME_LEN As Integer = 32              ' Panjang nama kunci

    Public Const NET_SDK_EMPLOYEE_NO_LEN As Integer = 32    ' Panjang nomor pegawai

    Public Const VCA_MAX_POLYGON_POINT_NUM As Integer = 10  ' Area deteksi polygon mendukung max 10 titik
    Public Const MAX_RULE_NUM As Integer = 8                ' Maksimum jumlah aturan
    Public Const MAX_TARGET_NUM As Integer = 30             ' Maksimum jumlah target
    Public Const MAX_CALIB_PT As Integer = 6                ' Maksimum titik kalibrasi
    Public Const MIN_CALIB_PT As Integer = 4                ' Minimum titik kalibrasi
    Public Const MAX_TIMESEGMENT_2 As Integer = 2           ' Maksimum jumlah segmen waktu
    Public Const MAX_LICENSE_LEN As Integer = 16            ' Panjang maksimum plat kendaraan
    Public Const MAX_PLATE_NUM As Integer = 3               ' Jumlah plat (maks)
    Public Const MAX_MASK_REGION_NUM As Integer = 4         ' Maksimum 4 area masking
    Public Const MAX_SEGMENT_NUM As Integer = 6             ' Maksimum jumlah garis sampel kalibrasi kamera
    Public Const MIN_SEGMENT_NUM As Integer = 3             ' Minimum jumlah garis sampel kalibrasi kamera
    Public Const MAX_CATEGORY_LEN As Integer = 8            ' Panjang maksimum info tambahan plat
    Public Const SERIAL_NO_LEN As Integer = 16              ' Panjang nomor seri slot parkir

    ' Mode koneksi stream
    Public Const NORMALCONNECT As Integer = 1
    Public Const MEDIACONNECT As Integer = 2

    ' Model perangkat (kategori besar)
    Public Const HCDVR As Integer = 1
    Public Const MEDVR As Integer = 2
    Public Const PCDVR As Integer = 3
    Public Const HC_9000 As Integer = 4
    Public Const HF_I As Integer = 5
    Public Const PCNVR As Integer = 6
    Public Const HC_76NVR As Integer = 8

    ' Tipe NVR
    Public Const DS8000HC_NVR As Integer = 0
    Public Const DS9000HC_NVR As Integer = 1
    Public Const DS8000ME_NVR As Integer = 2

    ' ******************* Kode Error Global - BEGIN *******************

    Public Const NET_DVR_NOERROR As Integer = 0                  ' Tidak ada error
    Public Const NET_DVR_PASSWORD_ERROR As Integer = 1           ' Username atau password salah
    Public Const NET_DVR_NOENOUGHPRI As Integer = 2              ' Hak akses tidak cukup
    Public Const NET_DVR_NOINIT As Integer = 3                   ' Belum diinisialisasi
    Public Const NET_DVR_CHANNEL_ERROR As Integer = 4            ' Nomor channel salah
    Public Const NET_DVR_OVER_MAXLINK As Integer = 5             ' Jumlah client terhubung ke DVR melebihi batas maksimum
    Public Const NET_DVR_VERSIONNOMATCH As Integer = 6           ' Versi tidak cocok
    Public Const NET_DVR_NETWORK_FAIL_CONNECT As Integer = 7     ' Gagal konek ke server/perangkat
    Public Const NET_DVR_NETWORK_SEND_ERROR As Integer = 8       ' Gagal mengirim data ke server/perangkat
    Public Const NET_DVR_NETWORK_RECV_ERROR As Integer = 9       ' Gagal menerima data dari server/perangkat
    Public Const NET_DVR_NETWORK_RECV_TIMEOUT As Integer = 10    ' Timeout saat menerima data dari server/perangkat
    Public Const NET_DVR_NETWORK_ERRORDATA As Integer = 11       ' Data yang ditransmisikan salah/korup
    Public Const NET_DVR_ORDER_ERROR As Integer = 12             ' Urutan pemanggilan fungsi salah
    Public Const NET_DVR_OPERNOPERMIT As Integer = 13            ' Operasi tidak diizinkan (tidak punya hak)
    Public Const NET_DVR_COMMANDTIMEOUT As Integer = 14          ' Timeout eksekusi perintah di DVR
    Public Const NET_DVR_ERRORSERIALPORT As Integer = 15         ' Nomor port serial salah
    Public Const NET_DVR_ERRORALARMPORT As Integer = 16          ' Port alarm salah
    Public Const NET_DVR_PARAMETER_ERROR As Integer = 17         ' Parameter salah
    Public Const NET_DVR_CHAN_EXCEPTION As Integer = 18          ' Channel perangkat dalam status error/exception
    Public Const NET_DVR_NODISK As Integer = 19                  ' Tidak ada harddisk
    Public Const NET_DVR_ERRORDISKNUM As Integer = 20            ' Nomor harddisk salah
    Public Const NET_DVR_DISK_FULL As Integer = 21               ' Harddisk penuh
    Public Const NET_DVR_DISK_ERROR As Integer = 22              ' Harddisk error
    Public Const NET_DVR_NOSUPPORT As Integer = 23               ' Tidak didukung oleh perangkat
    Public Const NET_DVR_BUSY As Integer = 24                    ' Perangkat/server sedang sibuk
    Public Const NET_DVR_MODIFY_FAIL As Integer = 25             ' Gagal melakukan perubahan konfigurasi
    Public Const NET_DVR_PASSWORD_FORMAT_ERROR As Integer = 26   ' Format password tidak benar
    Public Const NET_DVR_DISK_FORMATING As Integer = 27          ' Harddisk sedang diformat, operasi tidak dapat dilakukan
    Public Const NET_DVR_DVRNORESOURCE As Integer = 28           ' Resource DVR tidak cukup
    Public Const NET_DVR_DVROPRATEFAILED As Integer = 29         ' Operasi DVR gagal
    Public Const NET_DVR_OPENHOSTSOUND_FAIL As Integer = 30      ' Gagal membuka audio PC
    Public Const NET_DVR_DVRVOICEOPENED As Integer = 31          ' Kanal voice talk perangkat sedang dipakai
    Public Const NET_DVR_TIMEINPUTERROR As Integer = 32          ' Input waktu tidak benar
    Public Const NET_DVR_NOSPECFILE As Integer = 33              ' File yang diminta tidak ada di perangkat (saat playback)
    Public Const NET_DVR_CREATEFILE_ERROR As Integer = 34        ' Gagal membuat file
    Public Const NET_DVR_FILEOPENFAIL As Integer = 35            ' Gagal membuka file
    Public Const NET_DVR_OPERNOTFINISH As Integer = 36           ' Operasi sebelumnya belum selesai
    Public Const NET_DVR_GETPLAYTIMEFAIL As Integer = 37         ' Gagal mendapatkan waktu playback saat ini
    Public Const NET_DVR_PLAYFAIL As Integer = 38                ' Playback gagal
    Public Const NET_DVR_FILEFORMAT_ERROR As Integer = 39        ' Format file tidak benar
    Public Const NET_DVR_DIR_ERROR As Integer = 40               ' Path/direktori salah
    Public Const NET_DVR_ALLOC_RESOURCE_ERROR As Integer = 41    ' Gagal alokasi resource
    Public Const NET_DVR_AUDIO_MODE_ERROR As Integer = 42        ' Mode sound card/audio salah
    Public Const NET_DVR_NOENOUGH_BUF As Integer = 43            ' Buffer terlalu kecil
    Public Const NET_DVR_CREATESOCKET_ERROR As Integer = 44      ' Gagal membuat socket
    Public Const NET_DVR_SETSOCKET_ERROR As Integer = 45         ' Gagal set socket
    Public Const NET_DVR_MAX_NUM As Integer = 46                 ' Jumlah sudah mencapai batas maksimum
    Public Const NET_DVR_USERNOTEXIST As Integer = 47            ' User tidak ada
    Public Const NET_DVR_WRITEFLASHERROR As Integer = 48         ' Gagal menulis ke FLASH
    Public Const NET_DVR_UPGRADEFAIL As Integer = 49             ' Upgrade perangkat gagal
    Public Const NET_DVR_CARDHAVEINIT As Integer = 50            ' Kartu decoder sudah pernah diinisialisasi
    Public Const NET_DVR_PLAYERFAILED As Integer = 51            ' Ada fungsi di library player yang gagal
    Public Const NET_DVR_MAX_USERNUM As Integer = 52             ' Jumlah user di perangkat sudah mencapai maksimum
    Public Const NET_DVR_GETLOCALIPANDMACFAIL As Integer = 53    ' Gagal mendapatkan IP/MAC di sisi client
    Public Const NET_DVR_NOENCODEING As Integer = 54             ' Channel tidak memiliki encoding
    Public Const NET_DVR_IPMISMATCH As Integer = 55              ' Alamat IP tidak cocok
    Public Const NET_DVR_MACMISMATCH As Integer = 56             ' Alamat MAC tidak cocok
    Public Const NET_DVR_UPGRADELANGMISMATCH As Integer = 57     ' Bahasa firmware upgrade tidak cocok
    Public Const NET_DVR_MAX_PLAYERPORT As Integer = 58          ' Port player mencapai batas maksimum
    Public Const NET_DVR_NOSPACEBACKUP As Integer = 59           ' Tidak cukup ruang di perangkat backup
    Public Const NET_DVR_NODEVICEBACKUP As Integer = 60          ' Perangkat backup yang diminta tidak ditemukan
    Public Const NET_DVR_PICTURE_BITS_ERROR As Integer = 61      ' Bit gambar tidak sesuai (hanya mendukung 24-bit)
    Public Const NET_DVR_PICTURE_DIMENSION_ERROR As Integer = 62 ' Dimensi gambar melebihi batas (maks 128x256)
    Public Const NET_DVR_PICTURE_SIZ_ERROR As Integer = 63       ' Ukuran gambar melebihi batas (maks 100KB)
    Public Const NET_DVR_LOADPLAYERSDKFAILED As Integer = 64     ' Gagal load Player SDK dari direktori saat ini
    Public Const NET_DVR_LOADPLAYERSDKPROC_ERROR As Integer = 65 ' Entry function pada Player SDK tidak ditemukan
    Public Const NET_DVR_LOADDSSDKFAILED As Integer = 66         ' Gagal load DSsdk dari direktori saat ini
    Public Const NET_DVR_LOADDSSDKPROC_ERROR As Integer = 67     ' Entry function pada DsSdk tidak ditemukan
    Public Const NET_DVR_DSSDK_ERROR As Integer = 68             ' Pemanggilan fungsi di DsSdk gagal (hardware decode)
    Public Const NET_DVR_VOICEMONOPOLIZE As Integer = 69         ' Sound card sedang dikunci/dimonopoli
    Public Const NET_DVR_JOINMULTICASTFAILED As Integer = 70     ' Gagal join grup multicast
    Public Const NET_DVR_CREATEDIR_ERROR As Integer = 71         ' Gagal membuat direktori file log
    Public Const NET_DVR_BINDSOCKET_ERROR As Integer = 72        ' Gagal bind socket
    Public Const NET_DVR_SOCKETCLOSE_ERROR As Integer = 73       ' Koneksi socket terputus (umumnya karena koneksi putus/tujuan tidak dapat dijangkau)
    Public Const NET_DVR_USERID_ISUSING As Integer = 74          ' Saat logout, user ID sedang melakukan operasi
    Public Const NET_DVR_SOCKETLISTEN_ERROR As Integer = 75      ' Gagal listen socket
    Public Const NET_DVR_PROGRAM_EXCEPTION As Integer = 76       ' Exception pada program
    Public Const NET_DVR_WRITEFILE_FAILED As Integer = 77        ' Gagal menulis file
    Public Const NET_DVR_FORMAT_READONLY As Integer = 78         ' Dilarang format harddisk yang bersifat read-only
    Public Const NET_DVR_WITHSAMEUSERNAME As Integer = 79        ' Ada username yang sama pada struktur konfigurasi user
    Public Const NET_DVR_DEVICETYPE_ERROR As Integer = 80        ' Tipe/model perangkat tidak cocok saat impor parameter
    Public Const NET_DVR_LANGUAGE_ERROR As Integer = 81          ' Bahasa tidak cocok saat impor parameter
    Public Const NET_DVR_PARAVERSION_ERROR As Integer = 82       ' Versi software/parameter tidak cocok saat impor
    Public Const NET_DVR_IPCHAN_NOTALIVE As Integer = 83         ' Channel IP eksternal offline saat preview
    Public Const NET_DVR_RTSP_SDK_ERROR As Integer = 84          ' Gagal load library RTSP (StreamTransClient.dll)
    Public Const NET_DVR_CONVERT_SDK_ERROR As Integer = 85       ' Gagal load library transcoding
    Public Const NET_DVR_IPC_COUNT_OVERFLOW As Integer = 86      ' Melebihi jumlah maksimum channel IP yang bisa ditambahkan

    ' --- Error codes dari NET_PLAYM4 (Player) ---
    Public Const NET_PLAYM4_NOERROR As Integer = 500                 ' Tidak ada error
    Public Const NET_PLAYM4_PARA_OVER As Integer = 501               ' Parameter input tidak valid
    Public Const NET_PLAYM4_ORDER_ERROR As Integer = 502             ' Urutan pemanggilan fungsi salah
    Public Const NET_PLAYM4_TIMER_ERROR As Integer = 503             ' Gagal membuat clock multimedia
    Public Const NET_PLAYM4_DEC_VIDEO_ERROR As Integer = 504         ' Gagal decode data video
    Public Const NET_PLAYM4_DEC_AUDIO_ERROR As Integer = 505         ' Gagal decode data audio
    Public Const NET_PLAYM4_ALLOC_MEMORY_ERROR As Integer = 506      ' Gagal alokasi memori
    Public Const NET_PLAYM4_OPEN_FILE_ERROR As Integer = 507         ' Gagal membuka file
    Public Const NET_PLAYM4_CREATE_OBJ_ERROR As Integer = 508        ' Gagal membuat thread atau event
    Public Const NET_PLAYM4_CREATE_DDRAW_ERROR As Integer = 509      ' Gagal membuat objek DirectDraw
    Public Const NET_PLAYM4_CREATE_OFFSCREEN_ERROR As Integer = 510  ' Gagal membuat off-screen surface
    Public Const NET_PLAYM4_BUF_OVER As Integer = 511                ' Buffer overflow
    Public Const NET_PLAYM4_CREATE_SOUND_ERROR As Integer = 512      ' Gagal membuat device audio
    Public Const NET_PLAYM4_SET_VOLUME_ERROR As Integer = 513        ' Gagal set volume
    Public Const NET_PLAYM4_SUPPORT_FILE_ONLY As Integer = 514       ' Fungsi hanya mendukung pemutaran file
    Public Const NET_PLAYM4_SUPPORT_STREAM_ONLY As Integer = 515     ' Fungsi hanya mendukung pemutaran stream
    Public Const NET_PLAYM4_SYS_NOT_SUPPORT As Integer = 516         ' Sistem tidak mendukung
    Public Const NET_PLAYM4_FILEHEADER_UNKNOWN As Integer = 517      ' Header file tidak ada/tidak dikenal
    Public Const NET_PLAYM4_VERSION_INCORRECT As Integer = 518       ' Versi decoder dan encoder tidak kompatibel
    Public Const NET_PALYM4_INIT_DECODER_ERROR As Integer = 519      ' Gagal inisialisasi decoder
    Public Const NET_PLAYM4_CHECK_FILE_ERROR As Integer = 520        ' Data file tidak dikenal
    Public Const NET_PLAYM4_INIT_TIMER_ERROR As Integer = 521        ' Gagal inisialisasi clock multimedia
    Public Const NET_PLAYM4_BLT_ERROR As Integer = 522               ' Operasi Blt gagal
    Public Const NET_PLAYM4_UPDATE_ERROR As Integer = 523            ' Update gagal
    Public Const NET_PLAYM4_OPEN_FILE_ERROR_MULTI As Integer = 524   ' Gagal open file, streamtype=multi
    Public Const NET_PLAYM4_OPEN_FILE_ERROR_VIDEO As Integer = 525   ' Gagal open file, streamtype=video
    Public Const NET_PLAYM4_JPEG_COMPRESS_ERROR As Integer = 526     ' JPEG compress error
    Public Const NET_PLAYM4_EXTRACT_NOT_SUPPORT As Integer = 527     ' Versi file tidak didukung untuk extract
    Public Const NET_PLAYM4_EXTRACT_DATA_ERROR As Integer = 528      ' Gagal extract data video

    ' ******************* Kode Error Global - END *******************

    ' *************************************************
    ' Nilai balik NET_DVR_IsSupport()
    ' Bit 1-9 mewakili kemampuan berikut (bitwise AND = True berarti didukung)
    ' *************************************************

    Public Const NET_DVR_SUPPORT_DDRAW As Integer = 1
    ' Mendukung DirectDraw; jika tidak didukung maka player tidak dapat bekerja

    Public Const NET_DVR_SUPPORT_BLT As Integer = 2
    ' VGA/display card mendukung operasi BLT; jika tidak didukung maka player tidak dapat bekerja

    Public Const NET_DVR_SUPPORT_BLTFOURCC As Integer = 4
    ' BLT mendukung konversi warna; jika tidak didukung, player akan memakai konversi RGB lewat software

    Public Const NET_DVR_SUPPORT_BLTSHRINKX As Integer = 8
    ' BLT mendukung pengecilan sumbu X; jika tidak didukung, sistem memakai metode software

    Public Const NET_DVR_SUPPORT_BLTSHRINKY As Integer = 16
    ' BLT mendukung pengecilan sumbu Y; jika tidak didukung, sistem memakai metode software

    Public Const NET_DVR_SUPPORT_BLTSTRETCHX As Integer = 32
    ' BLT mendukung pembesaran sumbu X; jika tidak didukung, sistem memakai metode software

    Public Const NET_DVR_SUPPORT_BLTSTRETCHY As Integer = 64
    ' BLT mendukung pembesaran sumbu Y; jika tidak didukung, sistem memakai metode software

    Public Const NET_DVR_SUPPORT_SSE As Integer = 128
    ' CPU mendukung instruksi SSE (Intel Pentium III ke atas mendukung SSE)

    Public Const NET_DVR_SUPPORT_MMX As Integer = 256
    ' CPU mendukung instruksi MMX (komentar sumber menyebut Pentium III; intinya fitur CPU)


    ' ********************** Perintah Kontrol PTZ - BEGIN ************************

    Public Const LIGHT_PWRON As Integer = 2     ' Menyalakan lampu (power lampu)
    Public Const WIPER_PWRON As Integer = 3     ' Menyalakan wiper (penghapus hujan)
    Public Const FAN_PWRON As Integer = 4       ' Menyalakan kipas
    Public Const HEATER_PWRON As Integer = 5    ' Menyalakan heater/pemanas
    Public Const AUX_PWRON1 As Integer = 6      ' Menyalakan perangkat tambahan (AUX 1)
    Public Const AUX_PWRON2 As Integer = 7      ' Menyalakan perangkat tambahan (AUX 2)

    Public Const SET_PRESET As Integer = 8      ' Set preset PTZ
    Public Const CLE_PRESET As Integer = 9      ' Hapus preset PTZ

    Public Const ZOOM_IN As Integer = 11        ' Zoom in pada kecepatan SS (perbesar)
    Public Const ZOOM_OUT As Integer = 12       ' Zoom out pada kecepatan SS (perkecil)
    Public Const FOCUS_NEAR As Integer = 13     ' Fokus near pada kecepatan SS
    Public Const FOCUS_FAR As Integer = 14      ' Fokus far pada kecepatan SS
    Public Const IRIS_OPEN As Integer = 15      ' Iris membuka pada kecepatan SS
    Public Const IRIS_CLOSE As Integer = 16     ' Iris menutup pada kecepatan SS

    Public Const TILT_UP As Integer = 21        ' PTZ tilt ke atas pada kecepatan SS
    Public Const TILT_DOWN As Integer = 22      ' PTZ tilt ke bawah pada kecepatan SS
    Public Const PAN_LEFT As Integer = 23       ' PTZ pan ke kiri pada kecepatan SS
    Public Const PAN_RIGHT As Integer = 24      ' PTZ pan ke kanan pada kecepatan SS
    Public Const UP_LEFT As Integer = 25        ' PTZ atas + kiri pada kecepatan SS
    Public Const UP_RIGHT As Integer = 26       ' PTZ atas + kanan pada kecepatan SS
    Public Const DOWN_LEFT As Integer = 27      ' PTZ bawah + kiri pada kecepatan SS
    Public Const DOWN_RIGHT As Integer = 28     ' PTZ bawah + kanan pada kecepatan SS
    Public Const PAN_AUTO As Integer = 29       ' PTZ auto-scan kiri-kanan pada kecepatan SS

    Public Const FILL_PRE_SEQ As Integer = 30   ' Tambahkan preset ke urutan cruise/sequence
    Public Const SET_SEQ_DWELL As Integer = 31  ' Set waktu berhenti (dwell) pada titik cruise
    Public Const SET_SEQ_SPEED As Integer = 32  ' Set kecepatan cruise/sequence
    Public Const CLE_PRE_SEQ As Integer = 33    ' Hapus preset dari urutan cruise/sequence

    Public Const STA_MEM_CRUISE As Integer = 34 ' Mulai rekam track/cruise (rekam jejak)
    Public Const STO_MEM_CRUISE As Integer = 35 ' Stop rekam track/cruise
    Public Const RUN_CRUISE As Integer = 36     ' Jalankan track/cruise
    Public Const RUN_SEQ As Integer = 37        ' Mulai sequence/cruise
    Public Const STOP_SEQ As Integer = 38       ' Stop sequence/cruise
    Public Const GOTO_PRESET As Integer = 39    ' Lompat cepat ke preset

    ' ********************** Perintah Kontrol PTZ - END ************************


    ' *************************************************
    ' Perintah kontrol playback
    ' Untuk: NET_DVR_PlayBackControl / NET_DVR_PlayControlLocDisplay / NET_DVR_DecPlayBackCtrl
    ' Detail dukungan lihat dokumentasi fungsi terkait
    ' *************************************************

    Public Const NET_DVR_PLAYSTART As Integer = 1          ' Mulai playback
    Public Const NET_DVR_PLAYSTOP As Integer = 2           ' Stop playback
    Public Const NET_DVR_PLAYPAUSE As Integer = 3          ' Pause playback
    Public Const NET_DVR_PLAYRESTART As Integer = 4        ' Lanjutkan (resume) playback
    Public Const NET_DVR_PLAYFAST As Integer = 5           ' Fast forward
    Public Const NET_DVR_PLAYSLOW As Integer = 6           ' Slow motion
    Public Const NET_DVR_PLAYNORMAL As Integer = 7         ' Kecepatan normal
    Public Const NET_DVR_PLAYFRAME As Integer = 8          ' Playback per frame (single frame)
    Public Const NET_DVR_PLAYSTARTAUDIO As Integer = 9     ' Nyalakan audio
    Public Const NET_DVR_PLAYSTOPAUDIO As Integer = 10     ' Matikan audio
    Public Const NET_DVR_PLAYAUDIOVOLUME As Integer = 11   ' Atur volume audio
    Public Const NET_DVR_PLAYSETPOS As Integer = 12        ' Set progress playback file
    Public Const NET_DVR_PLAYGETPOS As Integer = 13        ' Get progress playback file
    Public Const NET_DVR_PLAYGETTIME As Integer = 14       ' Get waktu yang sudah diputar (valid untuk playback file)
    Public Const NET_DVR_PLAYGETFRAME As Integer = 15      ' Get jumlah frame yang sudah diputar (valid untuk playback file)
    Public Const NET_DVR_GETTOTALFRAMES As Integer = 16    ' Get total frame file (valid untuk playback file)
    Public Const NET_DVR_GETTOTALTIME As Integer = 17      ' Get total durasi file (valid untuk playback file)
    Public Const NET_DVR_THROWBFRAME As Integer = 20       ' Buang frame-B
    Public Const NET_DVR_SETSPEED As Integer = 24          ' Set kecepatan stream
    Public Const NET_DVR_KEEPALIVE As Integer = 25         ' Kirim heartbeat (disarankan tiap 2 detik bila callback lambat)
    Public Const NET_DVR_PLAYSETTIME As Integer = 26       ' Seek berdasarkan waktu absolut
    Public Const NET_DVR_PLAYGETTOTALLEN As Integer = 27   ' Get total panjang semua file dalam range waktu playback
    Public Const NET_DVR_PLAY_FORWARD As Integer = 29      ' Ubah dari reverse ke forward
    Public Const NET_DVR_PLAY_REVERSE As Integer = 30      ' Ubah dari forward ke reverse
    Public Const NET_DVR_SET_TRANS_TYPE As Integer = 32    ' Set tipe transmisi/packaging
    Public Const NET_DVR_PLAY_CONVERT As Integer = 33      ' Ubah mode playback (sesuai definisi SDK)


    ' --------------------------------------------------
    ' Definisi tombol remote (key value) untuk program CONFIG
    ' --------------------------------------------------

    Public Const KEY_CODE_1 As Integer = 1
    Public Const KEY_CODE_2 As Integer = 2
    Public Const KEY_CODE_3 As Integer = 3
    Public Const KEY_CODE_4 As Integer = 4
    Public Const KEY_CODE_5 As Integer = 5
    Public Const KEY_CODE_6 As Integer = 6
    Public Const KEY_CODE_7 As Integer = 7
    Public Const KEY_CODE_8 As Integer = 8
    Public Const KEY_CODE_9 As Integer = 9
    Public Const KEY_CODE_0 As Integer = 10
    Public Const KEY_CODE_POWER As Integer = 11
    Public Const KEY_CODE_MENU As Integer = 12
    Public Const KEY_CODE_ENTER As Integer = 13
    Public Const KEY_CODE_CANCEL As Integer = 14
    Public Const KEY_CODE_UP As Integer = 15
    Public Const KEY_CODE_DOWN As Integer = 16
    Public Const KEY_CODE_LEFT As Integer = 17
    Public Const KEY_CODE_RIGHT As Integer = 18
    Public Const KEY_CODE_EDIT As Integer = 19
    Public Const KEY_CODE_ADD As Integer = 20
    Public Const KEY_CODE_MINUS As Integer = 21
    Public Const KEY_CODE_PLAY As Integer = 22
    Public Const KEY_CODE_REC As Integer = 23
    Public Const KEY_CODE_PAN As Integer = 24
    Public Const KEY_CODE_M As Integer = 25
    Public Const KEY_CODE_A As Integer = 26
    Public Const KEY_CODE_F1 As Integer = 27
    Public Const KEY_CODE_F2 As Integer = 28

    ' Tombol untuk kontrol PTZ via remote
    Public Const KEY_PTZ_UP_START As Integer = KEY_CODE_UP
    Public Const KEY_PTZ_UP_STOP As Integer = 32

    Public Const KEY_PTZ_DOWN_START As Integer = KEY_CODE_DOWN
    Public Const KEY_PTZ_DOWN_STOP As Integer = 33

    Public Const KEY_PTZ_LEFT_START As Integer = KEY_CODE_LEFT
    Public Const KEY_PTZ_LEFT_STOP As Integer = 34

    Public Const KEY_PTZ_RIGHT_START As Integer = KEY_CODE_RIGHT
    Public Const KEY_PTZ_RIGHT_STOP As Integer = 35

    Public Const KEY_PTZ_AP1_START As Integer = KEY_CODE_EDIT   ' Iris +
    Public Const KEY_PTZ_AP1_STOP As Integer = 36

    Public Const KEY_PTZ_AP2_START As Integer = KEY_CODE_PAN    ' Iris -
    Public Const KEY_PTZ_AP2_STOP As Integer = 37

    Public Const KEY_PTZ_FOCUS1_START As Integer = KEY_CODE_A   ' Fokus +
    Public Const KEY_PTZ_FOCUS1_STOP As Integer = 38

    Public Const KEY_PTZ_FOCUS2_START As Integer = KEY_CODE_M   ' Fokus -
    Public Const KEY_PTZ_FOCUS2_STOP As Integer = 39

    Public Const KEY_PTZ_B1_START As Integer = 40               ' Zoom +
    Public Const KEY_PTZ_B1_STOP As Integer = 41

    Public Const KEY_PTZ_B2_START As Integer = 42               ' Zoom -
    Public Const KEY_PTZ_B2_STOP As Integer = 43

    ' Tambahan untuk seri 9000
    Public Const KEY_CODE_11 As Integer = 44
    Public Const KEY_CODE_12 As Integer = 45
    Public Const KEY_CODE_13 As Integer = 46
    Public Const KEY_CODE_14 As Integer = 47
    Public Const KEY_CODE_15 As Integer = 48
    Public Const KEY_CODE_16 As Integer = 49


    ' ************************* Perintah Konfigurasi - BEGIN ******************************
    ' Untuk NET_DVR_SetDVRConfig dan NET_DVR_GetDVRConfig (perhatikan struktur konfigurasi yang sesuai)
    ' ***********************************************************************************

    Public Const NET_DVR_GET_DEVICECFG As Integer = 100      ' Ambil parameter perangkat
    Public Const NET_DVR_SET_DEVICECFG As Integer = 101      ' Set parameter perangkat
    Public Const NET_DVR_GET_NETCFG As Integer = 102         ' Ambil parameter jaringan
    Public Const NET_DVR_SET_NETCFG As Integer = 103         ' Set parameter jaringan
    Public Const NET_DVR_GET_PICCFG As Integer = 104         ' Ambil parameter gambar
    Public Const NET_DVR_SET_PICCFG As Integer = 105         ' Set parameter gambar
    Public Const NET_DVR_GET_COMPRESSCFG As Integer = 106    ' Ambil parameter kompresi
    Public Const NET_DVR_SET_COMPRESSCFG As Integer = 107    ' Set parameter kompresi
    Public Const NET_DVR_GET_RECORDCFG As Integer = 108      ' Ambil parameter jadwal rekam
    Public Const NET_DVR_SET_RECORDCFG As Integer = 109      ' Set parameter jadwal rekam
    Public Const NET_DVR_GET_DECODERCFG As Integer = 110     ' Ambil parameter decoder
    Public Const NET_DVR_SET_DECODERCFG As Integer = 111     ' Set parameter decoder
    Public Const NET_DVR_GET_RS232CFG As Integer = 112       ' Ambil parameter port RS232
    Public Const NET_DVR_SET_RS232CFG As Integer = 113       ' Set parameter port RS232
    Public Const NET_DVR_GET_ALARMINCFG As Integer = 114     ' Ambil parameter input alarm
    Public Const NET_DVR_SET_ALARMINCFG As Integer = 115     ' Set parameter input alarm
    Public Const NET_DVR_GET_ALARMOUTCFG As Integer = 116    ' Ambil parameter output alarm
    Public Const NET_DVR_SET_ALARMOUTCFG As Integer = 117    ' Set parameter output alarm
    Public Const NET_DVR_GET_TIMECFG As Integer = 118        ' Ambil waktu DVR
    Public Const NET_DVR_SET_TIMECFG As Integer = 119        ' Set waktu DVR
    Public Const NET_DVR_GET_PREVIEWCFG As Integer = 120     ' Ambil parameter preview
    Public Const NET_DVR_SET_PREVIEWCFG As Integer = 121     ' Set parameter preview
    Public Const NET_DVR_GET_VIDEOOUTCFG As Integer = 122    ' Ambil parameter output video
    Public Const NET_DVR_SET_VIDEOOUTCFG As Integer = 123    ' Set parameter output video
    Public Const NET_DVR_GET_USERCFG As Integer = 124        ' Ambil parameter user
    Public Const NET_DVR_SET_USERCFG As Integer = 125        ' Set parameter user
    Public Const NET_DVR_GET_EXCEPTIONCFG As Integer = 126   ' Ambil parameter exception
    Public Const NET_DVR_SET_EXCEPTIONCFG As Integer = 127   ' Set parameter exception
    Public Const NET_DVR_GET_ZONEANDDST As Integer = 128     ' Ambil zona waktu & DST
    Public Const NET_DVR_SET_ZONEANDDST As Integer = 129     ' Set zona waktu & DST
    Public Const NET_DVR_GET_SHOWSTRING As Integer = 130     ' Ambil parameter OSD string overlay
    Public Const NET_DVR_SET_SHOWSTRING As Integer = 131     ' Set parameter OSD string overlay
    Public Const NET_DVR_GET_EVENTCOMPCFG As Integer = 132   ' Ambil parameter rekam saat event
    Public Const NET_DVR_SET_EVENTCOMPCFG As Integer = 133   ' Set parameter rekam saat event

    Public Const NET_DVR_GET_AUXOUTCFG As Integer = 140      ' Ambil setting output bantu saat alarm-trigger
    Public Const NET_DVR_SET_AUXOUTCFG As Integer = 141      ' Set setting output bantu saat alarm-trigger
    Public Const NET_DVR_GET_PREVIEWCFG_AUX As Integer = 142 ' Ambil preview konfigurasi output ganda (-s series)
    Public Const NET_DVR_SET_PREVIEWCFG_AUX As Integer = 143 ' Set preview konfigurasi output ganda (-s series)

    Public Const NET_DVR_GET_PICCFG_EX As Integer = 200      ' Ambil parameter gambar (perintah ekstensi SDK_V14)
    Public Const NET_DVR_SET_PICCFG_EX As Integer = 201      ' Set parameter gambar (perintah ekstensi SDK_V14)
    Public Const NET_DVR_GET_USERCFG_EX As Integer = 202     ' Ambil parameter user (perintah ekstensi SDK_V15)
    Public Const NET_DVR_SET_USERCFG_EX As Integer = 203     ' Set parameter user (perintah ekstensi SDK_V15)
    Public Const NET_DVR_GET_COMPRESSCFG_EX As Integer = 204 ' Ambil parameter kompresi (ekstensi SDK_V15, 2006-05-15)
    Public Const NET_DVR_SET_COMPRESSCFG_EX As Integer = 205 ' Set parameter kompresi (ekstensi SDK_V15, 2006-05-15)

    Public Const NET_DVR_GET_NETAPPCFG As Integer = 222      ' Ambil parameter aplikasi network: NTP/DDNS/EMAIL
    Public Const NET_DVR_SET_NETAPPCFG As Integer = 223      ' Set parameter aplikasi network: NTP/DDNS/EMAIL
    Public Const NET_DVR_GET_NTPCFG As Integer = 224         ' Ambil parameter NTP
    Public Const NET_DVR_SET_NTPCFG As Integer = 225         ' Set parameter NTP
    Public Const NET_DVR_GET_DDNSCFG As Integer = 226        ' Ambil parameter DDNS
    Public Const NET_DVR_SET_DDNSCFG As Integer = 227        ' Set parameter DDNS

    Public Const NET_DVR_GET_EMAILCFG As Integer = 228       ' Ambil parameter EMAIL
    Public Const NET_DVR_SET_EMAILCFG As Integer = 229       ' Set parameter EMAIL

    Public Const NET_DVR_GET_NFSCFG As Integer = 230         ' Konfigurasi NFS disk (ambil)
    Public Const NET_DVR_SET_NFSCFG As Integer = 231         ' Konfigurasi NFS disk (set)

    Public Const NET_DVR_GET_SHOWSTRING_EX As Integer = 238  ' Ambil OSD string overlay (ekstensi, mendukung 8 baris)
    Public Const NET_DVR_SET_SHOWSTRING_EX As Integer = 239  ' Set OSD string overlay (ekstensi, mendukung 8 baris)

    Public Const NET_DVR_GET_NETCFG_OTHER As Integer = 244   ' Ambil parameter jaringan (other)
    Public Const NET_DVR_SET_NETCFG_OTHER As Integer = 245   ' Set parameter jaringan (other)

    Public Const NET_DVR_GET_EMAILPARACFG As Integer = 250   ' Ambil parameter EMAIL (struktur EMAILCFG)
    Public Const NET_DVR_SET_EMAILPARACFG As Integer = 251   ' Set parameter EMAIL (struktur EMAILCFG)

    Public Const NET_DVR_GET_DDNSCFG_EX As Integer = 274     ' Ambil parameter DDNS (ekstensi)
    Public Const NET_DVR_SET_DDNSCFG_EX As Integer = 275     ' Set parameter DDNS (ekstensi)

    Public Const NET_DVR_SET_PTZPOS As Integer = 292         ' Set posisi PTZ
    Public Const NET_DVR_GET_PTZPOS As Integer = 293         ' Ambil posisi PTZ
    Public Const NET_DVR_GET_PTZSCOPE As Integer = 294       ' Ambil range/lingkup PTZ

    Public Const NET_DVR_GET_AP_INFO_LIST As Integer = 305   ' Ambil info resource jaringan wireless (AP list)
    Public Const NET_DVR_SET_WIFI_CFG As Integer = 306       ' Set parameter WiFi perangkat IP
    Public Const NET_DVR_GET_WIFI_CFG As Integer = 307       ' Ambil parameter WiFi perangkat IP
    Public Const NET_DVR_SET_WIFI_WORKMODE As Integer = 308  ' Set mode kerja port jaringan/WiFi perangkat IP
    Public Const NET_DVR_GET_WIFI_WORKMODE As Integer = 309  ' Ambil mode kerja port jaringan/WiFi perangkat IP
    Public Const NET_DVR_GET_WIFI_STATUS As Integer = 310    ' Ambil status koneksi WiFi saat ini

    ' *************************** Smart Server / VCA - BEGIN *****************************
    ' Tipe perangkat “smart”
    Public Const DS6001_HF_B As Integer = 60     ' Deteksi perilaku abnormal: DS6001-HF/B
    Public Const DS6001_HF_P As Integer = 61     ' Pengenalan plat: DS6001-HF/P
    Public Const DS6002_HF_B As Integer = 62     ' Dual-camera: DS6002-HF/B
    Public Const DS6101_HF_B As Integer = 63     ' Deteksi perilaku abnormal: DS6101-HF/B
    Public Const IDS52XX As Integer = 64         ' Smart analytic IVMS
    Public Const DS9000_IVS As Integer = 65      ' DVR smart seri 9000
    Public Const DS8004_AHL_A As Integer = 66    ' Smart ATM: DS8004AHL-S/A
    Public Const DS6101_HF_P As Integer = 67     ' Pengenalan plat: DS6101-HF/P

    ' Perintah untuk mengambil “ability/kapabilitas”
    Public Const VCA_DEV_ABILITY As Integer = 256         ' Kapabilitas total analitik perangkat
    Public Const VCA_CHAN_ABILITY As Integer = 272        ' Kapabilitas deteksi perilaku abnormal per channel
    Public Const MATRIXDECODER_ABILITY As Integer = 512   ' Kapabilitas tampilan/decode multi-channel decoder matrix

    ' Perintah konfigurasi VCA/Smart
    Public Const NET_DVR_SET_PLATECFG As Integer = 150    ' Set parameter pengenalan plat
    Public Const NET_DVR_GET_PLATECFG As Integer = 151    ' Ambil parameter pengenalan plat

    Public Const NET_DVR_SET_RULECFG As Integer = 152     ' Set aturan deteksi perilaku abnormal
    Public Const NET_DVR_GET_RULECFG As Integer = 153     ' Ambil aturan deteksi perilaku abnormal

    Public Const NET_DVR_SET_LF_CFG As Integer = 160      ' Set konfigurasi kalibrasi dual-camera
    Public Const NET_DVR_GET_LF_CFG As Integer = 161      ' Ambil konfigurasi kalibrasi dual-camera

    Public Const NET_DVR_SET_IVMS_STREAMCFG As Integer = 162 ' Set parameter stream untuk IVMS analytic
    Public Const NET_DVR_GET_IVMS_STREAMCFG As Integer = 163 ' Ambil parameter stream untuk IVMS analytic

    Public Const NET_DVR_SET_VCA_CTRLCFG As Integer = 164  ' Set parameter kontrol smart/VCA
    Public Const NET_DVR_GET_VCA_CTRLCFG As Integer = 165  ' Ambil parameter kontrol smart/VCA

    Public Const NET_DVR_SET_VCA_MASK_REGION As Integer = 166 ' Set area masking (VCA)
    Public Const NET_DVR_GET_VCA_MASK_REGION As Integer = 167 ' Ambil area masking (VCA)

    Public Const NET_DVR_SET_VCA_ENTER_REGION As Integer = 168 ' Set area “enter region” (ATM/VCA)
    Public Const NET_DVR_GET_VCA_ENTER_REGION As Integer = 169 ' Ambil area “enter region” (ATM/VCA)

    Public Const NET_DVR_SET_VCA_LINE_SEGMENT As Integer = 170 ' Set line segment (kalibrasi garis)
    Public Const NET_DVR_GET_VCA_LINE_SEGMENT As Integer = 171 ' Ambil line segment (kalibrasi garis)

    Public Const NET_DVR_SET_IVMS_MASK_REGION As Integer = 172 ' Set area masking (IVMS)
    Public Const NET_DVR_GET_IVMS_MASK_REGION As Integer = 173 ' Ambil area masking (IVMS)

    Public Const NET_DVR_SET_IVMS_ENTER_REGION As Integer = 174 ' Set area enter region (IVMS)
    Public Const NET_DVR_GET_IVMS_ENTER_REGION As Integer = 175 ' Ambil area enter region (IVMS)

    Public Const NET_DVR_SET_IVMS_BEHAVIORCFG As Integer = 176 ' Set aturan perilaku untuk IVMS analytic
    Public Const NET_DVR_GET_IVMS_BEHAVIORCFG As Integer = 177 ' Ambil aturan perilaku untuk IVMS analytic

    ' Pencarian playback IVMS
    Public Const NET_DVR_IVMS_SET_SEARCHCFG As Integer = 178 ' Set parameter pencarian playback IVMS
    Public Const NET_DVR_IVMS_GET_SEARCHCFG As Integer = 179 ' Ambil parameter pencarian playback IVMS

    ' *************************** Smart Server / VCA - END *****************************

    ' *************************** DS9000 perintah baru (_V30) - BEGIN *****************************

    ' Jaringan (struktur NET_DVR_NETCFG_V30)
    Public Const NET_DVR_GET_NETCFG_V30 As Integer = 1000 ' Ambil parameter jaringan
    Public Const NET_DVR_SET_NETCFG_V30 As Integer = 1001 ' Set parameter jaringan

    ' Gambar (struktur NET_DVR_PICCFG_V30)
    Public Const NET_DVR_GET_PICCFG_V30 As Integer = 1002 ' Ambil parameter gambar
    Public Const NET_DVR_SET_PICCFG_V30 As Integer = 1003 ' Set parameter gambar

    ' Gambar (struktur NET_DVR_PICCFG_V40)
    Public Const NET_DVR_GET_PICCFG_V40 As Integer = 6179 ' Ambil parameter gambar V40 (ekstensi)
    Public Const NET_DVR_SET_PICCFG_V40 As Integer = 6180 ' Set parameter gambar V40 (ekstensi)

    ' Jadwal rekam (struktur NET_DVR_RECORD_V30)
    Public Const NET_DVR_GET_RECORDCFG_V30 As Integer = 1004 ' Ambil parameter rekam
    Public Const NET_DVR_SET_RECORDCFG_V30 As Integer = 1005 ' Set parameter rekam

    Public Const NET_DVR_GET_RECORDCFG_V40 As Integer = 1008 ' Ambil parameter rekam (ekstensi)
    Public Const NET_DVR_SET_RECORDCFG_V40 As Integer = 1009 ' Set parameter rekam (ekstensi)

    ' User (struktur NET_DVR_USER_V30)
    Public Const NET_DVR_GET_USERCFG_V30 As Integer = 1006 ' Ambil parameter user
    Public Const NET_DVR_SET_USERCFG_V30 As Integer = 1007 ' Set parameter user

    ' Parameter DDNS 9000 (struktur NET_DVR_DDNSPARA_V30)
    Public Const NET_DVR_GET_DDNSCFG_V30 As Integer = 1010 ' Ambil DDNS (ekstensi 9000)
    Public Const NET_DVR_SET_DDNSCFG_V30 As Integer = 1011 ' Set DDNS (ekstensi 9000)

    ' EMAIL (struktur NET_DVR_EMAILCFG_V30)
    Public Const NET_DVR_GET_EMAILCFG_V30 As Integer = 1012 ' Ambil parameter EMAIL
    Public Const NET_DVR_SET_EMAILCFG_V30 As Integer = 1013 ' Set parameter EMAIL

    ' Cruise (struktur NET_DVR_CRUISE_PARA)
    Public Const NET_DVR_GET_CRUISE As Integer = 1020
    Public Const NET_DVR_SET_CRUISE As Integer = 1021

    ' Alarm Input (struktur NET_DVR_ALARMINCFG_V30)
    Public Const NET_DVR_GET_ALARMINCFG_V30 As Integer = 1024
    Public Const NET_DVR_SET_ALARMINCFG_V30 As Integer = 1025

    ' Alarm Output (struktur NET_DVR_ALARMOUTCFG_V30)
    Public Const NET_DVR_GET_ALARMOUTCFG_V30 As Integer = 1026
    Public Const NET_DVR_SET_ALARMOUTCFG_V30 As Integer = 1027

    ' Video Output (struktur NET_DVR_VIDEOOUT_V30)
    Public Const NET_DVR_GET_VIDEOOUTCFG_V30 As Integer = 1028
    Public Const NET_DVR_SET_VIDEOOUTCFG_V30 As Integer = 1029

    ' OSD/String Overlay (struktur NET_DVR_SHOWSTRING_V30)
    Public Const NET_DVR_GET_SHOWSTRING_V30 As Integer = 1030
    Public Const NET_DVR_SET_SHOWSTRING_V30 As Integer = 1031

    ' Exception (struktur NET_DVR_EXCEPTION_V30)
    Public Const NET_DVR_GET_EXCEPTIONCFG_V30 As Integer = 1034
    Public Const NET_DVR_SET_EXCEPTIONCFG_V30 As Integer = 1035

    ' RS232 (struktur NET_DVR_RS232CFG_V30)
    Public Const NET_DVR_GET_RS232CFG_V30 As Integer = 1036
    Public Const NET_DVR_SET_RS232CFG_V30 As Integer = 1037

    ' Network Disk (struktur NET_DVR_NET_DISKCFG)
    Public Const NET_DVR_GET_NET_DISKCFG As Integer = 1038 ' Ambil konfigurasi Network Disk
    Public Const NET_DVR_SET_NET_DISKCFG As Integer = 1039 ' Set konfigurasi Network Disk

    ' Kompresi (struktur NET_DVR_COMPRESSIONCFG_V30)
    Public Const NET_DVR_GET_COMPRESSCFG_V30 As Integer = 1040
    Public Const NET_DVR_SET_COMPRESSCFG_V30 As Integer = 1041

    ' Decoder 485 (struktur NET_DVR_DECODERCFG_V30)
    Public Const NET_DVR_GET_DECODERCFG_V30 As Integer = 1042 ' Ambil parameter decoder
    Public Const NET_DVR_SET_DECODERCFG_V30 As Integer = 1043 ' Set parameter decoder

    ' Preview (struktur NET_DVR_PREVIEWCFG_V30)
    Public Const NET_DVR_GET_PREVIEWCFG_V30 As Integer = 1044 ' Ambil parameter preview
    Public Const NET_DVR_SET_PREVIEWCFG_V30 As Integer = 1045 ' Set parameter preview

    ' Preview AUX (struktur NET_DVR_PREVIEWCFG_AUX_V30)
    Public Const NET_DVR_GET_PREVIEWCFG_AUX_V30 As Integer = 1046 ' Ambil parameter preview AUX
    Public Const NET_DVR_SET_PREVIEWCFG_AUX_V30 As Integer = 1047 ' Set parameter preview AUX

    ' Konfigurasi IP access (struktur NET_DVR_IPPARACFG)
    Public Const NET_DVR_GET_IPPARACFG As Integer = 1048 ' Ambil konfigurasi IP access
    Public Const NET_DVR_SET_IPPARACFG As Integer = 1049 ' Set konfigurasi IP access

    ' Konfigurasi IP access (struktur NET_DVR_IPPARACFG_V40)
    Public Const NET_DVR_GET_IPPARACFG_V40 As Integer = 1062 ' Ambil konfigurasi IP access (V40)
    Public Const NET_DVR_SET_IPPARACFG_V40 As Integer = 1063 ' Set konfigurasi IP access (V40)

    ' Konfigurasi IP alarm input (struktur NET_DVR_IPALARMINCFG)
    Public Const NET_DVR_GET_IPALARMINCFG As Integer = 1050 ' Ambil konfigurasi IP alarm input
    Public Const NET_DVR_SET_IPALARMINCFG As Integer = 1051 ' Set konfigurasi IP alarm input

    ' Konfigurasi IP alarm output (struktur NET_DVR_IPALARMOUTCFG)
    Public Const NET_DVR_GET_IPALARMOUTCFG As Integer = 1052 ' Ambil konfigurasi IP alarm output
    Public Const NET_DVR_SET_IPALARMOUTCFG As Integer = 1053 ' Set konfigurasi IP alarm output

    ' Manajemen HDD (struktur NET_DVR_HDCFG)
    Public Const NET_DVR_GET_HDCFG As Integer = 1054 ' Ambil konfigurasi manajemen HDD
    Public Const NET_DVR_SET_HDCFG As Integer = 1055 ' Set konfigurasi manajemen HDD

    ' Manajemen grup HDD (struktur NET_DVR_HDGROUP_CFG)
    Public Const NET_DVR_GET_HDGROUP_CFG As Integer = 1056 ' Ambil konfigurasi manajemen grup HDD
    Public Const NET_DVR_SET_HDGROUP_CFG As Integer = 1057 ' Set konfigurasi manajemen grup HDD

    ' Audio compression / talk encoding (struktur NET_DVR_COMPRESSION_AUDIO)
    Public Const NET_DVR_GET_COMPRESSCFG_AUD As Integer = 1058 ' Ambil parameter encoding audio/talk
    Public Const NET_DVR_SET_COMPRESSCFG_AUD As Integer = 1059 ' Set parameter encoding audio/talk

    ' Konfigurasi IP access (struktur NET_DVR_IPPARACFG_V31)
    Public Const NET_DVR_GET_IPPARACFG_V31 As Integer = 1060 ' Ambil konfigurasi IP access (V31)
    Public Const NET_DVR_SET_IPPARACFG_V31 As Integer = 1061 ' Set konfigurasi IP access (V31)

    ' Device config (struktur NET_DVR_DEVICECFG_V40)
    Public Const NET_DVR_GET_DEVICECFG_V40 As Integer = 1100 ' Ambil parameter perangkat
    Public Const NET_DVR_SET_DEVICECFG_V40 As Integer = 1101 ' Set parameter perangkat

    ' Multi-NIC config (struktur NET_DVR_NETCFG_MULTI)
    Public Const NET_DVR_GET_NETCFG_MULTI As Integer = 1161
    Public Const NET_DVR_SET_NETCFG_MULTI As Integer = 1162

    ' Network bonding (struktur NET_DVR_NETWORK_BONDING)
    Public Const NET_DVR_GET_NETWORK_BONDING As Integer = 1254
    Public Const NET_DVR_SET_NETWORK_BONDING As Integer = 1255

    ' NAT mapping config (struktur NET_DVR_NAT_CFG)
    Public Const NET_DVR_GET_NAT_CFG As Integer = 6111 ' Ambil parameter NAT mapping
    Public Const NET_DVR_SET_NAT_CFG As Integer = 6112 ' Set parameter NAT mapping

    ' Nama preset: ambil & set
    Public Const NET_DVR_GET_PRESET_NAME As Integer = 3383
    Public Const NET_DVR_SET_PRESET_NAME As Integer = 3382

    ' Rule config V41
    Public Const NET_VCA_GET_RULECFG_V41 As Integer = 5011 ' Ambil parameter deteksi perilaku abnormal
    Public Const NET_VCA_SET_RULECFG_V41 As Integer = 5012 ' Set parameter deteksi perilaku abnormal

    ' Traverse plane detection (deteksi pelanggaran garis/batas)
    Public Const NET_DVR_GET_TRAVERSE_PLANE_DETECTION As Integer = 3360 ' Ambil konfigurasi deteksi melintas batas
    Public Const NET_DVR_SET_TRAVERSE_PLANE_DETECTION As Integer = 3361 ' Set konfigurasi deteksi melintas batas

    ' Thermometry alarm rule & trigger
    Public Const NET_DVR_GET_THERMOMETRY_ALARMRULE As Integer = 3627 ' Ambil rule alarm pengukuran suhu (preset)
    Public Const NET_DVR_SET_THERMOMETRY_ALARMRULE As Integer = 3628 ' Set rule alarm pengukuran suhu (preset)
    Public Const NET_DVR_GET_THERMOMETRY_TRIGGER As Integer = 3632 ' Ambil konfigurasi linkage/trigger thermometry
    Public Const NET_DVR_SET_THERMOMETRY_TRIGGER As Integer = 3633 ' Set konfigurasi linkage/trigger thermometry

    ' Manual thermometry basic param & data
    Public Const NET_DVR_SET_MANUALTHERM_BASICPARAM As Integer = 6716 ' Set parameter dasar thermometry manual
    Public Const NET_DVR_GET_MANUALTHERM_BASICPARAM As Integer = 6717 ' Ambil parameter dasar thermometry manual
    Public Const NET_DVR_SET_MANUALTHERM As Integer = 6708           ' Set data/konfigurasi thermometry manual

    ' Multi-stream compression config
    Public Const NET_DVR_GET_MULTI_STREAM_COMPRESSIONCFG As Integer = 3216 ' Ambil parameter kompresi multi-stream (remote)
    Public Const NET_DVR_SET_MULTI_STREAM_COMPRESSIONCFG As Integer = 3217 ' Set parameter kompresi multi-stream (remote)

    ' Video intercom signal processing
    Public Const NET_DVR_VIDEO_CALL_SIGNAL_PROCESS As Integer = 16032 ' Proses sinyal video intercom (panggilan)

    ' *************************** DS9000 perintah baru (_V30) - END *****************************


    ' ************************ DVR LOG - BEGIN ************************

    ' Alarm
    Public Const MAJOR_ALARM As Integer = 1 ' Jenis utama: Alarm

    ' Jenis minor untuk Alarm
    Public Const MINOR_ALARM_IN As Integer = 1            ' Alarm input
    Public Const MINOR_ALARM_OUT As Integer = 2           ' Alarm output
    Public Const MINOR_MOTDET_START As Integer = 3        ' Deteksi gerak mulai
    Public Const MINOR_MOTDET_STOP As Integer = 4         ' Deteksi gerak selesai
    Public Const MINOR_HIDE_ALARM_START As Integer = 5    ' Alarm tamper/penutupan kamera mulai
    Public Const MINOR_HIDE_ALARM_STOP As Integer = 6     ' Alarm tamper/penutupan kamera selesai
    Public Const MINOR_VCA_ALARM_START As Integer = 7     ' Alarm analitik (VCA) mulai
    Public Const MINOR_VCA_ALARM_STOP As Integer = 8      ' Alarm analitik (VCA) berhenti

    ' Exception (kondisi abnormal)
    Public Const MAJOR_EXCEPTION As Integer = 2 ' Jenis utama: Exception

    ' Jenis minor untuk Exception
    Public Const MINOR_VI_LOST As Integer = 33                 ' Sinyal video hilang
    Public Const MINOR_ILLEGAL_ACCESS As Integer = 34          ' Akses ilegal
    Public Const MINOR_HD_FULL As Integer = 35                 ' HDD penuh
    Public Const MINOR_HD_ERROR As Integer = 36                ' HDD error
    Public Const MINOR_DCD_LOST As Integer = 37                ' MODEM putus (reserved/tidak dipakai)
    Public Const MINOR_IP_CONFLICT As Integer = 38             ' Konflik IP
    Public Const MINOR_NET_BROKEN As Integer = 39              ' Jaringan terputus
    Public Const MINOR_REC_ERROR As Integer = 40               ' Rekam error
    Public Const MINOR_IPC_NO_LINK As Integer = 41             ' Koneksi IPC abnormal
    Public Const MINOR_VI_EXCEPTION As Integer = 42            ' Video input abnormal (khusus channel analog)
    Public Const MINOR_IPC_IP_CONFLICT As Integer = 43         ' Konflik IP pada IPC

    ' Platform video terintegrasi
    Public Const MINOR_FANABNORMAL As Integer = 49             ' Status kipas abnormal
    Public Const MINOR_FANRESUME As Integer = 50               ' Status kipas kembali normal
    Public Const MINOR_SUBSYSTEM_ABNORMALREBOOT As Integer = 51 ' Subsystem (dm6467) reboot abnormal
    Public Const MINOR_MATRIX_STARTBUZZER As Integer = 52      ' dm6467 abnormal, buzzer dinyalakan

    ' Operation (aktivitas/operasi)
    Public Const MAJOR_OPERATION As Integer = 3 ' Jenis utama: Operation

    ' Jenis minor Operation (lokal)
    Public Const MINOR_START_DVR As Integer = 65                ' Boot / start
    Public Const MINOR_STOP_DVR As Integer = 66                 ' Shutdown normal
    Public Const MINOR_STOP_ABNORMAL As Integer = 67            ' Shutdown abnormal
    Public Const MINOR_REBOOT_DVR As Integer = 68               ' Reboot lokal perangkat

    Public Const MINOR_LOCAL_LOGIN As Integer = 80              ' Login lokal
    Public Const MINOR_LOCAL_LOGOUT As Integer = 81             ' Logout lokal
    Public Const MINOR_LOCAL_CFG_PARM As Integer = 82           ' Konfigurasi parameter lokal
    Public Const MINOR_LOCAL_PLAYBYFILE As Integer = 83         ' Playback/download lokal by file
    Public Const MINOR_LOCAL_PLAYBYTIME As Integer = 84         ' Playback/download lokal by time
    Public Const MINOR_LOCAL_START_REC As Integer = 85          ' Mulai rekam lokal
    Public Const MINOR_LOCAL_STOP_REC As Integer = 86           ' Stop rekam lokal
    Public Const MINOR_LOCAL_PTZCTRL As Integer = 87            ' Kontrol PTZ lokal
    Public Const MINOR_LOCAL_PREVIEW As Integer = 88            ' Preview lokal (reserved)
    Public Const MINOR_LOCAL_MODIFY_TIME As Integer = 89        ' Ubah waktu lokal (reserved)
    Public Const MINOR_LOCAL_UPGRADE As Integer = 90            ' Upgrade lokal
    Public Const MINOR_LOCAL_RECFILE_OUTPUT As Integer = 91     ' Backup file rekaman lokal
    Public Const MINOR_LOCAL_FORMAT_HDD As Integer = 92         ' Format HDD lokal
    Public Const MINOR_LOCAL_CFGFILE_OUTPUT As Integer = 93     ' Export file konfigurasi lokal
    Public Const MINOR_LOCAL_CFGFILE_INPUT As Integer = 94      ' Import file konfigurasi lokal
    Public Const MINOR_LOCAL_COPYFILE As Integer = 95           ' Copy/backup file lokal
    Public Const MINOR_LOCAL_LOCKFILE As Integer = 96           ' Lock file rekaman lokal
    Public Const MINOR_LOCAL_UNLOCKFILE As Integer = 97         ' Unlock file rekaman lokal
    Public Const MINOR_LOCAL_DVR_ALARM As Integer = 98          ' Trigger/clear alarm manual lokal
    Public Const MINOR_IPC_ADD As Integer = 99                  ' Tambah IPC lokal
    Public Const MINOR_IPC_DEL As Integer = 100                 ' Hapus IPC lokal
    Public Const MINOR_IPC_SET As Integer = 101                 ' Set IPC lokal
    Public Const MINOR_LOCAL_START_BACKUP As Integer = 102      ' Mulai backup lokal
    Public Const MINOR_LOCAL_STOP_BACKUP As Integer = 103       ' Stop backup lokal
    Public Const MINOR_LOCAL_COPYFILE_START_TIME As Integer = 104 ' Waktu mulai backup lokal
    Public Const MINOR_LOCAL_COPYFILE_END_TIME As Integer = 105   ' Waktu selesai backup lokal
    Public Const MINOR_LOCAL_ADD_NAS As Integer = 106           ' Tambah network disk/NAS lokal
    Public Const MINOR_LOCAL_DEL_NAS As Integer = 107           ' Hapus NAS lokal
    Public Const MINOR_LOCAL_SET_NAS As Integer = 108           ' Set NAS lokal

    ' Jenis minor Operation (remote)
    Public Const MINOR_REMOTE_LOGIN As Integer = 112            ' Login remote
    Public Const MINOR_REMOTE_LOGOUT As Integer = 113           ' Logout remote
    Public Const MINOR_REMOTE_START_REC As Integer = 114        ' Mulai rekam remote
    Public Const MINOR_REMOTE_STOP_REC As Integer = 115         ' Stop rekam remote
    Public Const MINOR_START_TRANS_CHAN As Integer = 116        ' Mulai transparent transmission
    Public Const MINOR_STOP_TRANS_CHAN As Integer = 117         ' Stop transparent transmission
    Public Const MINOR_REMOTE_GET_PARM As Integer = 118         ' Ambil parameter remote
    Public Const MINOR_REMOTE_CFG_PARM As Integer = 119         ' Konfigurasi parameter remote
    Public Const MINOR_REMOTE_GET_STATUS As Integer = 120       ' Ambil status remote
    Public Const MINOR_REMOTE_ARM As Integer = 121              ' Arm (aktifkan) remote
    Public Const MINOR_REMOTE_DISARM As Integer = 122           ' Disarm (nonaktifkan) remote
    Public Const MINOR_REMOTE_REBOOT As Integer = 123           ' Reboot remote
    Public Const MINOR_START_VT As Integer = 124                ' Mulai voice talk
    Public Const MINOR_STOP_VT As Integer = 125                 ' Stop voice talk
    Public Const MINOR_REMOTE_UPGRADE As Integer = 126          ' Upgrade remote
    Public Const MINOR_REMOTE_PLAYBYFILE As Integer = 127       ' Playback remote by file
    Public Const MINOR_REMOTE_PLAYBYTIME As Integer = 128       ' Playback remote by time
    Public Const MINOR_REMOTE_PTZCTRL As Integer = 129          ' Kontrol PTZ remote
    Public Const MINOR_REMOTE_FORMAT_HDD As Integer = 130       ' Format HDD remote
    Public Const MINOR_REMOTE_STOP As Integer = 131             ' Shutdown remote
    Public Const MINOR_REMOTE_LOCKFILE As Integer = 132         ' Lock file remote
    Public Const MINOR_REMOTE_UNLOCKFILE As Integer = 133       ' Unlock file remote
    Public Const MINOR_REMOTE_CFGFILE_OUTPUT As Integer = 134   ' Export konfigurasi remote
    Public Const MINOR_REMOTE_CFGFILE_INTPUT As Integer = 135   ' Import konfigurasi remote
    Public Const MINOR_REMOTE_RECFILE_OUTPUT As Integer = 136   ' Export rekaman remote
    Public Const MINOR_REMOTE_DVR_ALARM As Integer = 137        ' Trigger/clear alarm manual remote
    Public Const MINOR_REMOTE_IPC_ADD As Integer = 138          ' Tambah IPC remote
    Public Const MINOR_REMOTE_IPC_DEL As Integer = 139          ' Hapus IPC remote
    Public Const MINOR_REMOTE_IPC_SET As Integer = 140          ' Set IPC remote
    Public Const MINOR_REBOOT_VCA_LIB As Integer = 141          ' Reboot library analitik (VCA)
    Public Const MINOR_REMOTE_ADD_NAS As Integer = 142          ' Tambah NAS remote
    Public Const MINOR_REMOTE_DEL_NAS As Integer = 143          ' Hapus NAS remote
    Public Const MINOR_REMOTE_SET_NAS As Integer = 144          ' Set NAS remote

    ' Tambahan tipe log platform video (2009-12-16)
    Public Const MINOR_SUBSYSTEMREBOOT As Integer = 160                 ' dm6467 reboot normal
    Public Const MINOR_MATRIX_STARTTRANSFERVIDEO As Integer = 161       ' Matrix switch mulai transfer video
    Public Const MINOR_MATRIX_STOPTRANSFERVIDEO As Integer = 162        ' Matrix switch stop transfer video
    Public Const MINOR_REMOTE_SET_ALLSUBSYSTEM As Integer = 163         ' Set info semua subsystem 6467
    Public Const MINOR_REMOTE_GET_ALLSUBSYSTEM As Integer = 164         ' Get info semua subsystem 6467
    Public Const MINOR_REMOTE_SET_PLANARRAY As Integer = 165            ' Set grup plan polling
    Public Const MINOR_REMOTE_GET_PLANARRAY As Integer = 166            ' Get grup plan polling
    Public Const MINOR_MATRIX_STARTTRANSFERAUDIO As Integer = 167       ' Matrix switch mulai transfer audio
    Public Const MINOR_MATRIX_STOPRANSFERAUDIO As Integer = 168         ' Matrix switch stop transfer audio
    Public Const MINOR_LOGON_CODESPITTER As Integer = 169               ' Login ke code-splitter
    Public Const MINOR_LOGOFF_CODESPITTER As Integer = 170              ' Logout dari code-splitter

    ' Informasi tambahan log
    Public Const MAJOR_INFORMATION As Integer = 4 ' Jenis utama: Informasi tambahan
    Public Const MINOR_HDD_INFO As Integer = 161      ' Informasi HDD
    Public Const MINOR_SMART_INFO As Integer = 162    ' Informasi SMART
    Public Const MINOR_REC_START As Integer = 163     ' Mulai rekam
    Public Const MINOR_REC_STOP As Integer = 164      ' Stop rekam
    Public Const MINOR_REC_OVERDUE As Integer = 165   ' Hapus rekaman kadaluarsa
    Public Const MINOR_LINK_START As Integer = 166    ' Koneksi ke perangkat front-end
    Public Const MINOR_LINK_STOP As Integer = 167     ' Putus koneksi perangkat front-end
    Public Const MINOR_NET_DISK_INFO As Integer = 168 ' Informasi network disk

    ' Jika MAJOR_OPERATION=3 dan MINOR=MINOR_LOCAL_CFG_PARM (0x52) atau MINOR_REMOTE_GET_PARM (0x76)
    ' atau MINOR_REMOTE_CFG_PARM (0x77), maka dwParaType valid. Makna dwParaType:
    Public Const PARA_VIDEOOUT As Integer = 1
    Public Const PARA_IMAGE As Integer = 2
    Public Const PARA_ENCODE As Integer = 4
    Public Const PARA_NETWORK As Integer = 8
    Public Const PARA_ALARM As Integer = 16
    Public Const PARA_EXCEPTION As Integer = 32
    Public Const PARA_DECODER As Integer = 64       ' Decoder
    Public Const PARA_RS232 As Integer = 128
    Public Const PARA_PREVIEW As Integer = 256
    Public Const PARA_SECURITY As Integer = 512
    Public Const PARA_DATETIME As Integer = 1024
    Public Const PARA_FRAMETYPE As Integer = 2048   ' Tipe frame
    Public Const PARA_VCA_RULE As Integer = 4096    ' Aturan perilaku/Rule VCA

    ' ************************ DVR LOG - END ************************


    ' ******************* Nilai balik fungsi pencarian file/log ************************
    Public Const NET_DVR_FILE_SUCCESS As Integer = 1000     ' Berhasil mendapatkan informasi file
    Public Const NET_DVR_FILE_NOFIND As Integer = 1001      ' Tidak ada file
    Public Const NET_DVR_ISFINDING As Integer = 1002        ' Sedang mencari file
    Public Const NET_DVR_NOMOREFILE As Integer = 1003       ' Tidak ada file lagi
    Public Const NET_DVR_FILE_EXCEPTION As Integer = 1004   ' Exception saat mencari file


    ' ********************* Jenis callback - BEGIN ************************

    Public Const COMM_ALARM As Integer = &H1100
    ' Upload alarm 8000 (aktif push), struktur: NET_DVR_ALARMINFO

    Public Const COMM_ALARM_RULE As Integer = &H1102
    ' Alarm analitik perilaku abnormal, struktur: NET_VCA_RULE_ALARM

    Public Const COMM_ALARM_PDC As Integer = &H1103
    ' Alarm statistik people counting, struktur: NET_DVR_PDC_ALRAM_INFO

    Public Const COMM_ALARM_ALARMHOST As Integer = &H1105
    ' Alarm dari network alarm host, struktur: NET_DVR_ALARMHOST_ALARMINFO

    Public Const COMM_ALARM_FACE As Integer = &H1106
    ' Alarm face detect/recognition, struktur: NET_DVR_FACEDETECT_ALARM

    Public Const COMM_RULE_INFO_UPLOAD As Integer = &H1107
    ' Upload data event/rule

    Public Const COMM_ALARM_AID As Integer = &H1110
    ' Alarm insiden lalu lintas

    Public Const COMM_ALARM_TPS As Integer = &H1111
    ' Alarm statistik parameter lalu lintas

    Public Const COMM_UPLOAD_FACESNAP_RESULT As Integer = &H1112
    ' Upload hasil face snap/recognition

    Public Const COMM_ALARM_FACE_DETECTION As Integer = &H4010
    ' Alarm deteksi wajah

    Public Const COMM_ALARM_TFS As Integer = &H1113
    ' Alarm pengambilan bukti lalu lintas

    Public Const COMM_ALARM_TPS_V41 As Integer = &H1114
    ' Alarm TPS V41 (ekstensi)

    Public Const COMM_ALARM_AID_V41 As Integer = &H1115
    ' Alarm AID V41 (ekstensi)

    Public Const COMM_ALARM_VQD_EX As Integer = &H1116
    ' Alarm diagnosa kualitas video (VQD)

    Public Const COMM_SENSOR_VALUE_UPLOAD As Integer = &H1120
    ' Upload data analog/sensor real-time

    Public Const COMM_SENSOR_ALARM As Integer = &H1121
    ' Upload alarm analog/sensor

    Public Const COMM_SWITCH_ALARM As Integer = &H1122
    ' Alarm input switch/digital

    Public Const COMM_ALARMHOST_EXCEPTION As Integer = &H1123
    ' Alarm kerusakan pada alarm host

    Public Const COMM_ALARMHOST_OPERATEEVENT_ALARM As Integer = &H1124
    ' Upload alarm event operasi

    Public Const COMM_ALARMHOST_SAFETYCABINSTATE As Integer = &H1125
    ' Status safety cabin / proteksi

    Public Const COMM_ALARMHOST_ALARMOUTSTATUS As Integer = &H1126
    ' Status output alarm/sirene

    Public Const COMM_ALARMHOST_CID_ALARM As Integer = &H1127
    ' Upload alarm CID report

    Public Const COMM_ALARMHOST_EXTERNAL_DEVICE_ALARM As Integer = &H1128
    ' Upload alarm perangkat eksternal alarm host

    Public Const COMM_ALARMHOST_DATA_UPLOAD As Integer = &H1129
    ' Upload data alarm

    Public Const COMM_UPLOAD_VIDEO_INTERCOM_EVENT As Integer = &H1132
    ' Upload event video intercom

    Public Const COMM_ALARM_AUDIOEXCEPTION As Integer = &H1150
    ' Alarm audio exception

    Public Const COMM_ALARM_DEFOCUS As Integer = &H1151
    ' Alarm defocus (out of focus)

    Public Const COMM_ALARM_BUTTON_DOWN_EXCEPTION As Integer = &H1152
    ' Alarm tombol ditekan (button down)

    Public Const COMM_ALARM_ALARMGPS As Integer = &H1202
    ' Upload alarm GPS

    Public Const COMM_TRADEINFO As Integer = &H1500
    ' ATMDVR push info transaksi

    Public Const COMM_UPLOAD_PLATE_RESULT As Integer = &H2800
    ' Upload informasi plat nomor

    Public Const COMM_ITC_STATUS_DETECT_RESULT As Integer = &H2810
    ' Upload hasil deteksi status real-time (Smart HD IPC)

    Public Const COMM_IPC_AUXALARM_RESULT As Integer = &H2820
    ' Upload PIR/wireless/duress alarm, dll

    Public Const COMM_UPLOAD_PICTUREINFO As Integer = &H2900
    ' Upload informasi gambar

    Public Const COMM_SNAP_MATCH_ALARM As Integer = &H2902
    ' Upload hasil pencocokan (non-allowlist/blacklist match)

    Public Const COMM_ITS_PLATE_RESULT As Integer = &H3050
    ' Upload gambar/hasil terminal (ITS)

    Public Const COMM_ITS_TRAFFIC_COLLECT As Integer = &H3051
    ' Upload statistik traffic (ITS)

    Public Const COMM_ITS_GATE_VEHICLE As Integer = &H3052
    ' Upload data capture kendaraan gate masuk/keluar

    Public Const COMM_ITS_GATE_FACE As Integer = &H3053
    ' Upload data capture wajah gate masuk/keluar

    Public Const COMM_ITS_GATE_COSTITEM As Integer = &H3054
    ' Upload detail biaya kendaraan gate (2013-11-19)

    Public Const COMM_ITS_GATE_HANDOVER As Integer = &H3055
    ' Upload data handover shift gate (2013-11-19)

    Public Const COMM_ITS_PARK_VEHICLE As Integer = &H3056
    ' Upload data parkir

    Public Const COMM_ITS_BLOCKLIST_ALARM As Integer = &H3057
    ' Alarm blocklist (daftar blokir)

    Public Const COMM_ALARM_TPS_REAL_TIME As Integer = &H3081
    ' Upload data TPS real-time (traffic)

    Public Const COMM_ALARM_TPS_STATISTICS As Integer = &H3082
    ' Upload data TPS statistik (traffic)

    Public Const COMM_ALARM_V30 As Integer = &H4000
    ' Alarm push untuk seri 9000

    Public Const COMM_IPCCFG As Integer = &H4001
    ' Seri 9000: push info alarm saat konfigurasi IPC berubah

    Public Const COMM_IPCCFG_V31 As Integer = &H4002
    ' Seri 9000: ekstensi V31 untuk perubahan konfigurasi IPC

    Public Const COMM_IPCCFG_V40 As Integer = &H4003
    ' IVMS-2000 encoder server/NVR: push perubahan konfigurasi IPC

    Public Const COMM_ALARM_DEVICE As Integer = &H4004
    ' Alarm perangkat (ekstensi karena nilai channel > 256)

    Public Const COMM_ALARM_CVR As Integer = &H4005
    ' CVR 2.0.X jenis alarm eksternal

    Public Const COMM_ALARM_HOT_SPARE As Integer = &H4006
    ' Alarm hot spare exception (mode N+1)

    Public Const COMM_ALARM_V40 As Integer = &H4007
    ' Alarm push V40: motion, video loss, tamper, IO, dll; data alarm length variabel

    Public Const COMM_ITS_ROAD_EXCEPTION As Integer = &H4500
    ' Alarm exception perangkat persimpangan/road (ITS)

    Public Const COMM_ITS_EXTERNAL_CONTROL_ALARM As Integer = &H4520
    ' Alarm external control (ITS)

    Public Const COMM_SCREEN_ALARM As Integer = &H5000
    ' Alarm multi-screen controller

    Public Const COMM_DVCS_STATE_ALARM As Integer = &H5001
    ' Alarm controller video wall terdistribusi

    Public Const COMM_ALARM_ACS As Integer = &H5002
    ' Alarm access control system (ACS)

    Public Const COMM_ID_INFO_ALARM As Integer = &H5200
    ' Upload informasi KTP/ID

    Public Const COMM_PASSNUM_INFO_ALARM As Integer = &H5201
    ' Upload jumlah orang lewat (pass number)

    Public Const COMM_ALARM_VQD As Integer = &H6000
    ' VQD alarm push

    Public Const COMM_PUSH_UPDATE_RECORD_INFO As Integer = &H6001
    ' Upload informasi rekaman (mode push)

    Public Const COMM_ISAPI_ALARM As Integer = &H6009
    ' ISAPI alarm

    Public Const COMM_DIAGNOSIS_UPLOAD As Integer = &H5100
    ' Diagnosis server: upload alarm VQD

    Public Const COMM_UPLOAD_AIOP_VIDEO As Integer = &H4021
    ' Perangkat terhubung AI Open Platform: upload data deteksi video

    Public Const COMM_UPLOAD_AIOP_PICTURE As Integer = &H4022
    ' Perangkat terhubung AI Open Platform: upload data deteksi gambar

    Public Const COMM_UPLOAD_AIOP_POLLING_SNAP As Integer = &H4023
    ' Perangkat terhubung AI Open Platform: upload hasil polling snapshot (NET_AIOP_POLLING_SNAP_HEAD)

    Public Const COMM_UPLOAD_AIOP_POLLING_VIDEO As Integer = &H4024
    ' Perangkat terhubung AI Open Platform: upload hasil polling video (NET_AIOP_POLLING_VIDEO_HEAD)

    ' ********************* Jenis callback - END ************************

    'Baris 15625 di file csharp
    '*********************************************************
    ' Fungsi : REALDATACALLBACK
    ' Deskripsi : Callback untuk data pratinjau (preview) real-time
    '
    ' Parameter:
    '   lRealHandle : Handle pratinjau saat ini
    '   dwDataType  : Jenis data
    '   pBuffer     : Pointer ke buffer data
    '   dwBufSize   : Ukuran buffer data
    '   pUser       : Data user
    '
    ' Return : Tidak ada (Sub)
    '*********************************************************
    <DllImport("HCNetSDK.dll")>
    Public Sub REALDATACALLBACK(ByVal lRealHandle As Int32, ByVal dwDataType As UInt32, ByVal pBuffer As IntPtr, ByVal dwBufSize As UInt32, ByVal pUser As IntPtr)
    End Sub
    ' Import DLL HCNetSDK

    <DllImport("HCNetSDK.dll")>
    Function NET_DVR_Init() As Boolean
    End Function


End Module
