Imports System.IO 'Working With Files
Imports System.Text 'Working With Text

Imports System.Collections.Generic
Imports System.Configuration
Imports System.Net.Mail
Imports System.Security

'iTextSharp Libraries
Imports iTextSharp.text 'Core PDF Text Functionalities
Imports iTextSharp.text.pdf 'PDF Content
Imports iTextSharp.text.pdf.parser 'Content Parser

Public Class Form_main

    '====================================================
    'When the main form is loaded
    '----------------------------------------------------
    Private Sub Form_main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim bRet As Boolean
        bRet = updateFileList(Me.TextBox_InputDir, Me.ListBox_A3pdf)
        bRet = updateFileList(Me.TextBox_OutputDir, Me.ListBox_A4pdfInOne)

        Me.ProgressBar1.Value = 0
        Me.ProgressBar2.Value = 0

        Me.Height = 356
        Me.GroupBox_Progress.Visible = False

        Me.ListBox_A4pdfInOne.Visible = False

    End Sub

    '====================================================
    'ファイルリストの更新
    '----------------------------------------------------
    Private Function updateFileList(ByVal txtBox As Windows.Forms.TextBox, _
                                    ByVal lstBox As Windows.Forms.ListBox) As Boolean
        Dim files As String()

        On Error Resume Next
        files = System.IO.Directory.GetFiles(txtBox.Text, _
                                             "*.pdf", _
                                             System.IO.SearchOption.AllDirectories)
        If Not IsNothing(files) Then
            lstBox.Items.Clear()
            lstBox.Items.AddRange(files)
            updateFileList = True
        Else
            updateFileList = False
        End If

        lstBox.Refresh()

    End Function

    '====================================================
    'Browse botton for input directory.
    '----------------------------------------------------
    Private Sub Button_BrowseInputDir_Click(sender As Object, e As EventArgs) Handles Button_BrowseInputDir.Click
        Dim bRet As Boolean
        Dim strDialogResults As String = SetBrowsePath("Browse for Input Directory", _
                                                       Me.TextBox_InputDir.Text)
        If Not (strDialogResults Is Nothing) Then
            Me.TextBox_InputDir.Text = strDialogResults
            bRet = updateFileList(Me.TextBox_InputDir, Me.ListBox_A3pdf)
        End If
    End Sub

    '====================================================
    'Browse botton for output directory.
    '----------------------------------------------------
    Private Sub Button_BrowseOutputDir_Click(sender As Object, e As EventArgs) Handles Button_BrowseOutputDir.Click
        Dim bRet As Boolean
        Dim strDialogResults As String = SetBrowsePath("Browse for Output Directory", _
                                                       Me.TextBox_OutputDir.Text)

        If Not (strDialogResults Is Nothing) Then
            Me.TextBox_OutputDir.Text = strDialogResults
            bRet = updateFileList(Me.TextBox_OutputDir, Me.ListBox_A4pdfInOne)
        End If
    End Sub

    '====================================================
    'get the path from the browse dialog
    '----------------------------------------------------
    Friend Function SetBrowsePath(ByVal DescrText As String, _
                                  ByVal DefaultDir As String) As String
        Dim FBDialog As New FolderBrowserDialog
        FBDialog.Description = DescrText
        FBDialog.SelectedPath = DefaultDir
        FBDialog.ShowNewFolderButton = True

        If (FBDialog.ShowDialog() = DialogResult.OK) Then
            Return FBDialog.SelectedPath
        Else
            Return ""
        End If
    End Function

    '====================================================
    'Exit button
    '----------------------------------------------------
    Private Sub Button_Exit_Click(sender As Object, e As EventArgs) Handles Button_Exit.Click
        End
    End Sub

    '====================================================
    'Convert button - A3toA4
    '----------------------------------------------------
    Private Sub Button_Convert_A3toA4_Click(sender As Object, e As EventArgs) Handles Button_Convert_A3toA4.Click
        Dim bRet As Boolean
        Dim inputFileSubDir As String
        Dim inputFileName As String
        Dim outputFileDir As String
        Dim outFileName As String
        Dim outFilePath As String

        Me.GroupBox_Progress.Visible = True
        Me.Width = 573
        Me.Height = 531

        'progressbar
        Dim pb1Val As Long = 0
        Me.ProgressBar1.Value = pb1Val
        Me.ProgressBar1.Maximum = Me.ListBox_A3pdf.Items.Count

        For Each inputFilePath In Me.ListBox_A3pdf.Items

            'ファイル名取得
            inputFileName = Path.GetFileName(inputFilePath)
            outFileName = inputFileName

            Me.Label_tgtFile.Text = "converting... " & pb1Val + 1 & "/" & Me.ListBox_A3pdf.Items.Count & " : " & inputFileName
            Me.Label_tgtFile.Refresh()

            'サブディレクトリ取得
            inputFileSubDir = inputFilePath.ToString.Substring(Me.TextBox_InputDir.Text.Length + 1)
            inputFileSubDir = inputFileSubDir.Substring(0, inputFileSubDir.Length - inputFileName.Length - 1)

            '出力先ディレクトリ
            outputFileDir = Me.TextBox_OutputDir.Text & "\" & inputFileSubDir & "\"

            '出力ファイル名フルパス
            outFilePath = Me.TextBox_OutputDir.Text & "\" & inputFileSubDir & "\" & outFileName

            '出力先ディレクトリ作成
            If System.IO.Directory.Exists(outputFileDir) Then
            Else
                System.IO.Directory.CreateDirectory(outputFileDir)
            End If

            'ファイル変換
            bRet = SplitPdfByPage_A3toA4(inputFilePath, outFilePath)

            'progressbar
            pb1Val = pb1Val + 1
            Me.ProgressBar1.Value = pb1Val
            Me.ProgressBar1.Refresh()

        Next

        For Each inputFilePath In Me.ListBox_A3pdf.Items
            inputFileName = Path.GetFileName(inputFilePath)
            outFilePath = Me.TextBox_OutputDir.Text & "\test\" & inputFileName
        Next

        'ファイルリストの更新
        bRet = updateFileList(Me.TextBox_OutputDir, Me.ListBox_A4pdfInOne)

        If bRet = True Then
            MsgBox("complete!", MsgBoxStyle.OkOnly, "Split a multipage PDF into single pages")
        End If

        Me.Label_tgtFile.Text = "*** " & Me.ListBox_A3pdf.Items.Count & " files are converted to " & Me.ListBox_A4pdfInOne.Items.Count & " files."
        Me.Label_tgtFile.BackColor = Color.GreenYellow
        Me.Label_tgtPage.Visible = False
        Me.ListBox_A4pdfInOne.Visible = True

    End Sub


    '====================================================
    'Convert button - keep original page size
    '----------------------------------------------------
    Private Sub Button_Convert_Click(sender As Object, e As EventArgs) Handles Button_Convert_AsItIs.Click
        Dim bRet As Boolean
        Dim inputFileSubDir As String
        Dim inputFileName As String
        Dim outputFileDir As String
        Dim outFileName As String
        Dim outFilePath As String

        Me.GroupBox_Progress.Visible = True
        Me.Width = 573
        Me.Height = 531


        'progressbar
        Dim pb1Val As Long = 0
        Me.ProgressBar1.Value = pb1Val
        Me.ProgressBar1.Maximum = Me.ListBox_A3pdf.Items.Count

        For Each inputFilePath In Me.ListBox_A3pdf.Items
            'ファイル名取得
            inputFileName = Path.GetFileName(inputFilePath)
            outFileName = inputFileName

            'label
            Me.Label_tgtFile.Text = "converting... " & pb1Val + 1 & "/" & Me.ListBox_A3pdf.Items.Count & " : " & inputFileName
            Me.Label_tgtFile.Refresh()

            'サブディレクトリ取得
            inputFileSubDir = inputFilePath.ToString.Substring(Me.TextBox_InputDir.Text.Length + 1)
            inputFileSubDir = inputFileSubDir.Substring(0, inputFileSubDir.Length - inputFileName.Length - 1)

            '出力先ディレクトリ
            outputFileDir = Me.TextBox_OutputDir.Text & "\" & inputFileSubDir & "\"

            '出力ファイル名フルパス
            outFilePath = Me.TextBox_OutputDir.Text & "\" & inputFileSubDir & "\" & outFileName

            '出力先ディレクトリ作成
            If System.IO.Directory.Exists(outputFileDir) Then
            Else
                System.IO.Directory.CreateDirectory(outputFileDir)
            End If

            'ファイル変換
            bRet = SplitPdfByPage_AsItIs(inputFilePath, outFilePath)

            'progressbar
            pb1Val = pb1Val + 1
            Me.ProgressBar1.Value = pb1Val
            Me.ProgressBar1.Refresh()

        Next

        For Each inputFilePath In Me.ListBox_A3pdf.Items
            inputFileName = Path.GetFileName(inputFilePath)
            outFilePath = Me.TextBox_OutputDir.Text & "\test\" & inputFileName
        Next
        'ファイルリストの更新
        bRet = updateFileList(Me.TextBox_OutputDir, Me.ListBox_A4pdfInOne)

        If bRet = True Then
            MsgBox("complete!", MsgBoxStyle.OkOnly, "Split a multipage PDF into single pages")

        End If

        Me.Label_tgtFile.Text = "*** " & Me.ListBox_A3pdf.Items.Count & " files are converted to " & Me.ListBox_A4pdfInOne.Items.Count & " files."
        Me.Label_tgtFile.BackColor = Color.GreenYellow
        Me.Label_tgtPage.Visible = False
        Me.ListBox_A4pdfInOne.Visible = True

    End Sub

    '========================================================
    'Split a multipage PDF into single pages - A3 to A4 x 2
    '--------------------------------------------------------
    Private Function SplitPdfByPage_A3toA4(ByVal sourcePdf As String, _
                                     ByVal baseNameOutPdf As String) As Boolean

        Dim reader As iTextSharp.text.pdf.PdfReader = Nothing
        Dim readerPageCount As Integer = 0
        Dim readerCurrentPage As Integer = 1
        Dim ext As String = Path.GetExtension(baseNameOutPdf)
        Dim outfileName1 As String = String.Empty
        Dim outfileName2 As String = String.Empty
        Dim doc1 As iTextSharp.text.Document = Nothing
        Dim doc2 As iTextSharp.text.Document = Nothing
        Dim cb1 As PdfContentByte
        Dim cb2 As PdfContentByte

        Dim page1 As iTextSharp.text.pdf.PdfImportedPage = Nothing
        Dim page2 As iTextSharp.text.pdf.PdfImportedPage = Nothing

        Try
            '元PDFを取得
            reader = New iTextSharp.text.pdf.PdfReader(sourcePdf)
            readerPageCount = reader.NumberOfPages

            If readerPageCount < 1 Then
                Throw New ArgumentException("Not enough pages in source pdf to split")
            Else


                'progressbar
                Dim pb2Val As Long = 0
                Me.ProgressBar2.Value = pb2Val
                Me.ProgressBar2.Maximum = readerPageCount

                For i As Integer = 1 To readerPageCount
                    '出力用ファイル名を2種類準備
                    outfileName1 = baseNameOutPdf.Replace(ext, "_" & i.ToString("000") & "-1" & ext)
                    outfileName2 = baseNameOutPdf.Replace(ext, "_" & i.ToString("000") & "-2" & ext)

                    'A4サイズのdocインスタンスを生成
                    doc1 = New iTextSharp.text.Document(PageSize.A4)
                    doc2 = New iTextSharp.text.Document(PageSize.A4)

                    'MSを使ってdocとwriterを関連付け(writer <- MS -> doc)
                    Dim ms1 = New MemoryStream()
                    Dim writer1 = PdfWriter.GetInstance(doc1, ms1)
                    Dim ms2 = New MemoryStream()
                    Dim writer2 = PdfWriter.GetInstance(doc2, ms2)

                    'docを開き、cbに展開(cb = writer <- MS -> doc)
                    doc1.Open()
                    cb1 = writer1.DirectContent
                    doc2.Open()
                    cb2 = writer2.DirectContent

                    page1 = writer1.GetImportedPage(reader, readerCurrentPage)
                    page2 = writer2.GetImportedPage(reader, readerCurrentPage)

                    'A3 h:841.89 w:1190.55
                    'A4 h:841.89 w:595.276
                    If page1.Width > 600 Then
                        'pageをcbに入れる(reader <- page = cb = writer <- MS -> doc)
                        cb1.AddTemplate(page1, 1.0F, 0, 0, 1.0F, 0, 0)
                        doc1.Close()
                        File.WriteAllBytes(outfileName1, ms1.GetBuffer())

                        'pageをA4幅分左にずらして、cbに入れる
                        cb2.AddTemplate(page2, 1.0F, 0, 0, 1.0F, -PageSize.A4.Width, 0)
                        doc2.Close()
                        File.WriteAllBytes(outfileName2, ms2.GetBuffer())
                    Else
                        'pageをcbに入れる(reader <- page = cb = writer <- MS -> doc)
                        cb1.AddTemplate(page1, 1.0F, 0, 0, 1.0F, 0, 0)
                        doc1.Close()
                        File.WriteAllBytes(outfileName1, ms1.GetBuffer())
                    End If
                    readerCurrentPage += 1

                    'progressbar
                    pb2Val = pb2Val + 1
                    Me.ProgressBar2.Value = pb2Val
                    Me.ProgressBar2.Refresh()

                    Me.Label_tgtPage.Text = "page... " & pb2Val & "/" & readerPageCount
                    Me.Label_tgtPage.Refresh()

                Next i
            End If
            reader.Close()
            SplitPdfByPage_A3toA4 = True
        Catch ex As Exception
            Throw ex
            SplitPdfByPage_A3toA4 = False
        End Try
    End Function

    '========================================================
    'Split a multipage PDF into single pages - keep original page size
    '--------------------------------------------------------
    Private Function SplitPdfByPage_AsItIs(ByVal sourcePdf As String, _
                                  ByVal baseNameOutPdf As String) As Boolean

        Dim reader As iTextSharp.text.pdf.PdfReader = Nothing
        Dim readerPageCount As Integer = 0
        Dim readerCurrentPage As Integer = 1
        Dim ext As String = Path.GetExtension(baseNameOutPdf)
        Dim outfileName As String = String.Empty
        Dim page As iTextSharp.text.pdf.PdfImportedPage = Nothing
        Dim doc As iTextSharp.text.Document = Nothing
        Dim pdfCpy As iTextSharp.text.pdf.PdfCopy = Nothing

        Try
            '元PDFを取得
            reader = New iTextSharp.text.pdf.PdfReader(sourcePdf)
            readerPageCount = reader.NumberOfPages

            If readerPageCount < 1 Then
                Throw New ArgumentException("Not enough pages in source pdf to split")
            Else
                'progressbar
                Dim pb2Val As Long = 0
                Me.ProgressBar2.Value = pb2Val
                Me.ProgressBar2.Maximum = readerPageCount

                For i As Integer = 1 To readerPageCount
                    outfileName = baseNameOutPdf.Replace(ext, "_" & i.ToString("000") & ext)

                    'A4サイズのDOCインスタンスを生成
                    'doc = New iTextSharp.text.Document(reader.GetPageSizeWithRotation(readerCurrentPage))
                    doc = New iTextSharp.text.Document(PageSize.A4)
                    pdfCpy = New iTextSharp.text.pdf.PdfCopy(doc, New FileStream(outfileName, FileMode.Create))
                    doc.Open()

                    page = pdfCpy.GetImportedPage(reader, readerCurrentPage)
                    pdfCpy.AddPage(page)
                    readerCurrentPage += 1
                    doc.Close()

                    'progressbar
                    pb2Val = pb2Val + 1
                    Me.ProgressBar2.Value = pb2Val
                    Me.ProgressBar2.Refresh()

                    Me.Label_tgtPage.Text = "page... " & pb2Val & "/" & readerPageCount
                    Me.Label_tgtPage.Refresh()
                Next i
            End If
            reader.Close()
            SplitPdfByPage_AsItIs = True

        Catch ex As Exception
            Throw ex
            SplitPdfByPage_AsItIs = False
        End Try
    End Function

    Public Function Print_pdf_document(strFilePath As String)
        ''====レジストリからAcrobat,AcrobatReaderのパス取得====
        'Dim strRegPath As String
        'Dim rKey As Microsoft.Win32.RegistryKey
        ''キーを取得(最初にAcrobat,だめならAdobeReader)
        'strRegPath = "SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\Acrobat.exe"
        'rKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(strRegPath)
        'If rKey Is Nothing Then
        '    strRegPath = "SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\AcroRd32.exe"
        '    rKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(strRegPath)
        'End If
        ''値(exeのパス)を取得(既定の値の場合は空文字指定)
        'Dim location As String
        'Try
        '    '値(exeのパス)を取得(既定の値の場合は空文字指定)
        '    location = DirectCast(rKey.GetValue(""), String)
        'Catch ex As NullReferenceException
        '    Throw New ApplicationException("AcrobatもしくはAdobeReaderがインストールされていないため、PDFファイルの印刷ができません。")
        'Finally
        '    '開いたレジストリキーを閉じる
        '    rKey.Close()
        'End Try

        ''===Acrobatを起動し印刷===
        'Dim filepath As String = "D:\print_test.pdf"
        'Dim pro As New Process()

        ''.Net的書き方(C#でも可能な書き方)
        ''Acrobatのフルパス設定
        'pro.StartInfo.FileName = location
        'pro.StartInfo.Verb = "open"
        ''Acrobatのコマンドライン引数設定
        'pro.StartInfo.Arguments = " /n /t " + filepath
        'pro.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
        ''プロセスを新しいWindowで起動
        'pro.StartInfo.CreateNoWindow = True
        ''プロセス起動
        'pro.Start()
        ''プロセス終了
        'pro.WaitForExit(5000)
        'pro.Kill()


        'VB的書き方
        'Dim procID As Integer
        'procID = Shell(location & " /n /t " & filepath)
        'pro = Process.GetProcessById(procID)
        'pro.WaitForExit(3000)
        'pro.Kill()

        '        On Error GoTo errHandler

        '        Dim Error282Count As Integer  '' Count of "Can't open DDE channel" errors
        '        Dim AcroDDEFailed As Boolean  '' Set to true if a DDE connection cannot be established
        '        Dim sPDFPath As String        '' Path to a PDF file
        '        Dim sCmd As String            '' DDE command
        '        Dim lStatus As Long
        '        Dim n As Integer
        '        Const Max282Errors = 6
        '        Dim sAcroPath As String       ' Path to acrobat, determined by FindExecutable
        '        Dim bCloseAcrobat As Boolean  ' If we open acrobat, we will close it when we are done
        '        Dim PDFArray As Object
        '        Error282Count = Max282Errors      ' checks to see if acrobat is running
        '        AcroDDEFailed = False             ' ErrHandler will set to true if Acro is not running
        '        txtAcrobatDDE.LinkMode = 0        ' Close any current DDE Link
        '        txtAcrobatDDE.LinkTopic = "acroview|control"    ' Acrobat's DDE Application|Topic
        '        txtAcrobatDDE.LinkMode = 2        ' Try to establish 'Manual' DDE Link. This will fail
        '        ' if Acrobat is not ready or running

        '        'This will determine what the default printer is on the system
        '        objPrinter = GetDefaultPrinter()

        '        'This will set the default printer according to the settings in TNClerk
        '        Call SetNewDefaultPrinter()

        '        'Obtain the current settings the printer has
        '        PreviousSettings = Printer.PaperSize

        '        'Check to see if need to print legal or letter size
        '        If Me.optLegal.Value = True Then
        '            If Printer.PaperSize <> 5 Then
        '                Call SetPaperSize(5)
        '            End If
        '        ElseIf Me.optLetter.Value = True Then
        '            If Printer.PaperSize <> 1 Then
        '                Call SetPaperSize(1)
        '            End If
        '        End If

        '        ReDim PDFArray(0 To 0)
        '        PDFArray(0) = strFilePath

        '        If AcroDDEFailed = True Then
        '            ' grab the first pdf path. We assume this file exists
        '            sPDFPath = PDFArray(0)

        '            '' Use the FindExecutable API function to grab the path to our PDF handler.
        '    sAcroPath = String(128, 32)
        '            lStatus = FindExecutable(sPDFPath, vbNullString, sAcroPath)
        '            If lStatus <= 32 Then
        '                MsgBox("Acrobat could not be found on this computer. Printing cancelled", vbCritical, "Problem")

        '                Call ReturnDefaultPrinter()
        '                Exit Function
        '            End If

        '            ' Launch the PDF handler
        '            lStatus = Shell(sAcroPath, vbHide)
        '            If (lStatus >= 0) And (lStatus <= 32) Then
        '                MsgBox("An error occured launching Acrobat. Printing cancelled", vbCritical, "Problem")

        '                Call ReturnDefaultPrinter()
        '                Exit Function
        '            End If
        '            'Try to close Acrobat when we are done
        '            bCloseAcrobat = True
        '        End If

        '        PauseFor 2  '' Lets take a break here to let Acrobat finish loading

        '        Error282Count = 0       '' This time, we will allow all acceptable tries, as
        '        AcroDDEFailed = False   '' Acrobat is running, but may be busy loading its modules
        '        txtAcrobatDDE.LinkMode = 0
        '        txtAcrobatDDE.LinkTopic = "acroview|control"
        '        txtAcrobatDDE.LinkTimeout = 2500 ' 3 minute timeout delay
        '        txtAcrobatDDE.LinkMode = 2

        '        If AcroDDEFailed = True Then
        '            MsgBox("An error occured connecting to Acrobat. Printing cancelled", vbCritical, "Problem")

        '            Call ReturnDefaultPrinter()
        '            Exit Function
        '        End If

        '        '' Send the PDF's to the printer.
        '        For n = 0 To UBound(PDFArray)
        '            '' We need to put the long filenames in quotes. Again, we assume these file exist
        '            sPDFPath = PDFArray(n)
        '            sCmd = "[FilePrintSilent(" & Chr(34) & sPDFPath & Chr(34) & ")]"
        '            txtAcrobatDDE.LinkExecute sCmd
        '        Next

        '        If bCloseAcrobat = True Then
        '            '' [AppExit()] causes memory errors with v6.0 and 6.1, so avoid closing these versions
        '            If InStr(sAcroPath, "6.0") = 0 Then
        '                sCmd = "[AppExit()]"
        '                txtAcrobatDDE.LinkExecute sCmd
        '            End If
        '        End If

        '        '' Close the DDE Connection
        '        txtAcrobatDDE.LinkMode = 0

        '        Call ReturnDefaultPrinter()
        '        Exit Function

        'errHandler:
        '        If err.Number = 282 Then '' Can't open DDE channel
        '            '' This error may happen because Acro is not fully loaded.
        '            '' Give it Max282Errors attempts before returning AcroDDEFailed = True
        '            Error282Count = Error282Count + 1
        '            If Error282Count <= Max282Errors Then
        '                PauseFor 3
        '                Resume
        '            Else
        '                AcroDDEFailed = True
        '                Resume Next
        '            End If
        '        End If

        '        MsgBox "Error in PrintPDFs sub of " & Me.Name & " form. Error# " & err.Number & " " & err.Description & "."
    End Function

    'Private Function printA3toA4(ByVal filePath As String) As Boolean

    '    'IAC objects
    '    Dim pdDoc As Acrobat.CAcroPDDoc
    '    Dim avDoc As Acrobat.CAcroAVDoc

    '    avDoc = CreateObject("AcroExch.AVDoc")

    '    avDoc.Open(filePath, "")
    '    pdDoc = avDoc.GetPDDoc()
    '    pdDoc.Open(filePath)

    '    Dim pageCount As Long
    '    pageCount = pdDoc.GetNumPages()
    '    pdDoc.Close()

    '    avDoc.PrintPagesSilentEx(0, _
    '                       pageCount - 1, _
    '                       2, _
    '                       bBinaryOk:=False, _
    '                       bShrinkToFit:=False, _
    '                       bReverse:=False, _
    '                       bFarEastFontOpt:=False, _
    '                       bEmitHalftones:=False, _
    '                       iPageOption:=-3)

    '    avDoc.Close(bNoSave:=True)
    '    printA3toA4 = True

    'End Function



End Class
