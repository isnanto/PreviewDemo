Imports System.Drawing.Drawing2D
Imports System.IO
Imports System.Runtime.CompilerServices.RuntimeHelpers
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports Microsoft.VisualBasic.ApplicationServices

Public Class Form1
    Public Const NET_SDK_INIT_CFG_SDK_PATH As Integer = 2
    Public Const NET_SDK_INIT_CFG_LIBEAY_PATH As Integer = 4
    Public Const NET_SDK_INIT_CFG_SSLEAY_PATH As Integer = 5


    'Menyimpan kode error terakhir (unsigned integer)
    Private iLastErr As UInteger = 0

    'Menyimpan ID user yang didapat dari SDK (default -1 berarti belum login)
    Private m_lUserID As Int32 = -1

    'Menandakan apakah SDK sudah berhasil diinisialisasi
    Private m_bInitSDK As Boolean = False

    'Menandakan apakah sedang dalam proses perekaman
    Private m_bRecord As Boolean = False

    'Menandakan apakah fitur komunikasi suara (talk) sedang aktif
    Private m_bTalk As Boolean = False

    'Handle untuk tampilan real-time video
    Private m_lRealHandle As Int32 = -1

    'Handle untuk komunikasi suara (voice communication)
    Private lVoiceComHandle As Integer = -1

    'Variabel string umum (biasanya untuk pesan atau informasi sementara)
    Private str As String

    'Callback untuk menerima data real-time dari kamera/DVR
    Private RealData As MySDK.CHCNetSDK.REALDATACALLBACK = Nothing

    'Menyimpan konfigurasi posisi PTZ (Pan, Tilt, Zoom)
    Public m_struPtzCfg As MySDK.CHCNetSDK.NET_DVR_PTZPOS

    Public Sub New()
        '
        ' Kode yang diperlukan dan didukung oleh Windows Form Designer
        '
        InitializeComponent()

        '
        ' TODO: Tambahkan kode inisialisasi lain setelah pemanggilan InitializeComponent
        '


    End Sub

    Private Sub BtnLogin_Click(sender As Object, e As EventArgs) Handles BtnLogin.Click

        'Call LoginV40(TxtIPAddress.Text.Trim(), CInt(TxtPort.Text.Trim()), TxtUserID.Text.Trim(), TxtPassword.Text.Trim())
        'Return

        ' Validasi input: IP, Port, Username, dan Password tidak boleh kosong
        If TxtIPAddress.Text = "" OrElse TxtPort.Text = "" OrElse TxtUserID.Text = "" OrElse TxtPassword.Text = "" Then
            MessageBox.Show("Please input IP, Port, User name and Password!")
            Return
        End If

        ' Jika belum login
        If m_lUserID < 0 Then

            ' Alamat IP perangkat atau nama domain
            Dim DVRIPAddress As String = TxtIPAddress.Text.Trim()

            ' Nomor port layanan perangkat
            Dim DVRPortNumber As Int16 = Int16.Parse(TxtPort.Text.Trim)

            ' Username login perangkat
            Dim DVRUserName As String = TxtUserID.Text.Trim

            ' Password login perangkat
            Dim DVRPassword As String = TxtPassword.Text.Trim

            ' Struktur untuk menyimpan informasi perangkat
            Dim DeviceInfo As New MySDK.CHCNetSDK.NET_DVR_DEVICEINFO_V30()

            ' Login ke perangkat
            m_lUserID = MySDK.CHCNetSDK.NET_DVR_Login_V30(
                    DVRIPAddress,
                    DVRPortNumber,
                    DVRUserName,
                    DVRPassword,
                    DeviceInfo)

            If m_lUserID < 0 Then
                ' Login gagal, ambil kode error
                iLastErr = MySDK.CHCNetSDK.NET_DVR_GetLastError()
                str = "NET_DVR_Login_V30 failed, error code= " & iLastErr & vbCrLf & Marshal.PtrToStringAnsi(MySDK.CHCNetSDK.NET_DVR_GetErrorMsg(iLastErr))
                MessageBox.Show(str)
                Return
            Else
                ' Login berhasil
                MessageBox.Show("Login Success!")
                BtnLogin.Text = "Logout"
            End If

        Else
            ' Logout dari perangkat

            ' Pastikan live view sudah dihentikan
            If m_lRealHandle >= 0 Then
                MessageBox.Show("Please stop live view firstly")
                Return
            End If

            ' Proses logout
            If Not MySDK.CHCNetSDK.NET_DVR_Logout(m_lUserID) Then
                iLastErr = MySDK.CHCNetSDK.NET_DVR_GetLastError()
                str = "NET_DVR_Logout failed, error code= " & iLastErr & vbCrLf & Marshal.PtrToStringAnsi(MySDK.CHCNetSDK.NET_DVR_GetErrorMsg(iLastErr))
                MessageBox.Show(str)
                Return
            End If

            ' Reset status login
            m_lUserID = -1
            BtnLogin.Text = "Login"

        End If

        Return

    End Sub

    'Private Function LoginV40(pIP As String, pPort As Integer, puser As String, pPassword As String) As Boolean
    '    Dim loginInfo As New MySDK.CHCNetSDK.NET_DVR_USER_LOGIN_INFO()
    '    Dim m_struDeviceInfoV40 As New MySDK.CHCNetSDK.NET_DVR_DEVICEINFO_V40
    '    loginInfo.sDeviceAddress = "172.16.99.65"
    '    loginInfo.sUserName = "admin"
    '    loginInfo.sPassword = "Admin123"
    '    loginInfo.wPort = 8000 'CUShort(pPort)
    '    loginInfo.bUseAsynLogin = False
    '    loginInfo.byRes1 = New Byte(1) {}
    '    loginInfo.byRes = New Byte(127) {}

    '    m_struDeviceInfoV40.byRes2 = New Byte(255) {}
    '    m_struDeviceInfoV40.struDeviceV30.byRes2 = New Byte(23) {}

    '    m_lUserID = MySDK.CHCNetSDK.NET_DVR_Login_V40(loginInfo, m_struDeviceInfoV40)


    '    If m_lUserID < 0 Then
    '        Dim err = MySDK.CHCNetSDK.NET_DVR_GetLastError()
    '        MessageBox.Show("Login V40 gagal, error = " & err)
    '        Return False
    '    End If

    '    Return True
    'End Function

    Private Sub LivePreview()
        Dim clientInfo As New MySDK.CHCNetSDK.NET_DVR_CLIENTINFO()
        clientInfo.lChannel = 1
        clientInfo.lLinkMode = &H80000000   ' IPC main stream via TCP
        clientInfo.hPlayWnd = RealPlayWnd.Handle

        RealData = New MySDK.CHCNetSDK.REALDATACALLBACK(AddressOf RealDataCallBack)

        m_lRealHandle = MySDK.CHCNetSDK.NET_DVR_RealPlay(m_lUserID, clientInfo)
        'm_lRealHandle = MySDK.CHCNetSDK.NET_DVR_RealPlay(m_lUserID, clientInfo, RealData, IntPtr.Zero)

        If m_lRealHandle < 0 Then
            MessageBox.Show("RealPlay gagal, error = " & MySDK.CHCNetSDK.NET_DVR_GetLastError())
        End If
    End Sub
    Private Sub BtnPreview_Click(sender As Object, e As EventArgs) Handles BtnPreview.Click
        'LivePreview()
        'Return

        If Not RealPlayWnd.IsHandleCreated Then
            MessageBox.Show("Preview window belum siap")
            Exit Sub
        End If

        ' Pastikan user sudah login
        If m_lUserID < 0 Then
            MessageBox.Show("Please login the device firstly")
            Return
        End If

        ' Jika belum melakukan live view
        If m_lRealHandle < 0 Then

            ' Struktur informasi preview
            Dim lpPreviewInfo As New MySDK.CHCNetSDK.NET_DVR_PREVIEWINFO()

            ' Handle window untuk preview
            lpPreviewInfo.hPlayWnd = RealPlayWnd.Handle

            ' Channel perangkat yang akan di-preview
            lpPreviewInfo.lChannel = Int16.Parse(textBoxChannel.Text)

            ' Jenis stream:
            ' 0 = Main stream, 1 = Sub stream, 2 = Stream 3, 3 = Stream 4, dst
            lpPreviewInfo.dwStreamType = 0

            ' Mode koneksi:
            ' 0 = TCP, 1 = UDP, 2 = Multicast, 3 = RTP, 4 = RTP/RTSP, 5 = RTSP/HTTP
            lpPreviewInfo.dwLinkMode = 0

            ' Mode blocking stream
            ' False = Non-blocking, True = Blocking
            lpPreviewInfo.bBlocked = True


            ' Jumlah maksimum buffer frame untuk playback
            lpPreviewInfo.dwDisplayBufNum = 1

            lpPreviewInfo.byProtoType = 0
            lpPreviewInfo.byPreviewMode = 0

            ' Jika menggunakan Stream ID
            If textBoxID.Text <> "" Then
                lpPreviewInfo.lChannel = -1
                Dim byStreamID() As Byte = System.Text.Encoding.Default.GetBytes(textBoxID.Text)
                lpPreviewInfo.byStreamID = New Byte(31) {}
                byStreamID.CopyTo(lpPreviewInfo.byStreamID, 0)
            End If

            'Inisialisasi callback data real-time
            If RealData Is Nothing Then
                RealData = New MySDK.CHCNetSDK.REALDATACALLBACK(AddressOf RealDataCallBack)
            End If

            ' Pointer data user
            Dim pUser As IntPtr = IntPtr.Zero

            ' Memulai live view
            m_lRealHandle = MySDK.CHCNetSDK.NET_DVR_RealPlay_V40(m_lUserID, lpPreviewInfo, Nothing, pUser)  ' ' RealData callback (tidak digunakan di sini)

            If m_lRealHandle < 0 Then
                ' Live view gagal
                iLastErr = MySDK.CHCNetSDK.NET_DVR_GetLastError()
                str = "NET_DVR_RealPlay_V40 failed, error code= " & iLastErr & vbCrLf & Marshal.PtrToStringAnsi(MySDK.CHCNetSDK.NET_DVR_GetErrorMsg(iLastErr))


                MessageBox.Show(str)
                Return
            Else
                ' Live view berhasil
                BtnPreview.Text = "Stop Live View"
            End If

        Else
            ' Menghentikan live view
            If Not MySDK.CHCNetSDK.NET_DVR_StopRealPlay(m_lRealHandle) Then
                iLastErr = MySDK.CHCNetSDK.NET_DVR_GetLastError()
                str = "NET_DVR_StopRealPlay failed, error code= " & iLastErr
                MessageBox.Show(str)
                Return
            End If

            m_lRealHandle = -1
            BtnPreview.Text = "Live View"

        End If

        Return

    End Sub

    ' Callback untuk menerima data stream real-time
    Public Sub RealDataCallBack(
    ByVal lRealHandle As Int32,
    ByVal dwDataType As UInt32,
    ByVal pBuffer As IntPtr,
    ByVal dwBufSize As UInt32,
    ByVal pUser As IntPtr)

        ' Jika ukuran buffer lebih dari 0
        If dwBufSize > 0 Then

            ' Array byte untuk menampung data stream
            Dim sData(dwBufSize - 1) As Byte

            ' Menyalin data dari memory unmanaged ke array managed
            Marshal.Copy(pBuffer, sData, 0, CInt(dwBufSize))

            ' Nama file untuk menyimpan data stream real-time
            Dim fileName As String = "Data_Stream_RealTime.ps"

            ' Membuat file dan menulis data ke dalamnya
            Using fs As New FileStream(fileName, FileMode.Create)
                fs.Write(sData, 0, CInt(dwBufSize))
            End Using

        End If

    End Sub

    Private Sub btnJPEG_Click(sender As Object, e As EventArgs) Handles btnJPEG.Click
        Dim sJpegPicFileName As String
        ' Path dan nama file untuk menyimpan gambar JPEG
        sJpegPicFileName = "JPEG_test.jpg"

        ' Nomor channel perangkat
        Dim lChannel As Int16 = Int16.Parse(textBoxChannel.Text)

        ' Parameter JPEG
        Dim lpJpegPara As New MySDK.CHCNetSDK.NET_DVR_JPEGPARA()
        lpJpegPara.wPicQuality = 2
        ' Kualitas gambar (0 = terbaik, 1 = tinggi, 2 = sedang. semakin besar nilainya kualitas semakin rendah)

        lpJpegPara.wPicSize = &H2
        ' Ukuran gambar:
        ' 2   = 4CIF
        ' &HFF = Otomatis (menggunakan resolusi stream saat ini)
        ' Catatan: ukuran gambar harus didukung oleh perangkat

        ' Mengambil gambar JPEG (capture snapshot)
        If Not MySDK.CHCNetSDK.NET_DVR_CaptureJPEGPicture(
                    m_lUserID,
                    lChannel,
                    lpJpegPara,
                    sJpegPicFileName) Then

            ' Capture gagal
            iLastErr = MySDK.CHCNetSDK.NET_DVR_GetLastError()
            str = "NET_DVR_CaptureJPEGPicture failed, error code= " & iLastErr & vbCrLf & Marshal.PtrToStringAnsi(MySDK.CHCNetSDK.NET_DVR_GetErrorMsg(iLastErr))

            'Dim pMsg As IntPtr = MySDK.CHCNetSDK.NET_DVR_GetErrorMsg(iLastErr)
            'Dim errMsg As String = Marshal.PtrToStringAnsi(pMsg)
            'str = errMsg

            MessageBox.Show(str, "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        Else
            ' Capture berhasil
            str = "Successful to capture the JPEG file and the saved file is " & sJpegPicFileName
            MessageBox.Show(str)
            ResizeImage(sJpegPicFileName, "small.jpg")
        End If

        Return
    End Sub

    Sub ResizeImage(src As String, dst As String)
        Using img = Image.FromFile(src)
            Dim bmp As New Bitmap(640, 360)
            Using g = Graphics.FromImage(bmp)
                g.InterpolationMode = InterpolationMode.HighQualityBicubic
                g.DrawImage(img, 0, 0, 640, 360)
            End Using
            bmp.Save(dst, Imaging.ImageFormat.Jpeg)
        End Using
    End Sub

    Private Sub Btn_Exit_Click(sender As Object, e As EventArgs) Handles Btn_Exit.Click
        ' Menghentikan live view (preview) jika masih berjalan
        If m_lRealHandle >= 0 Then
            MySDK.CHCNetSDK.NET_DVR_StopRealPlay(m_lRealHandle)
            m_lRealHandle = -1
        End If

        ' Logout dari perangkat jika masih login
        If m_lUserID >= 0 Then
            MySDK.CHCNetSDK.NET_DVR_Logout(m_lUserID)
            m_lUserID = -1
        End If

        ' Membersihkan resource SDK
        MySDK.CHCNetSDK.NET_DVR_Cleanup()

        ' Menutup aplikasi
        Application.Exit()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' Inisialisasi SDK
        Environment.CurrentDirectory = Application.StartupPath
        MySDK.CHCNetSDK.NET_DVR_SetConnectTime(3000, 1)
        MySDK.CHCNetSDK.NET_DVR_SetReconnect(10000, True)

        m_bInitSDK = MySDK.CHCNetSDK.NET_DVR_Init()

        If m_bInitSDK = False Then
            MessageBox.Show("NET_DVR_Init error!")
            Return
        Else
            ' Menyimpan log SDK ke file
            MySDK.CHCNetSDK.NET_DVR_SetLogToFile(3, "C:\SdkLog\", True)
        End If


    End Sub
End Class
