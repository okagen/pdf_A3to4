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

    Dim g_MeWidth_init As Integer = 646
    Dim g_MeHeight_init As Integer = 371
    Dim g_MeWidth_inPrg As Integer = 646
    Dim g_MeHeight_inPrg As Integer = 597

    '====================================================
    'When the main form is loaded
    '----------------------------------------------------
    Private Sub Form_main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim bRet As Boolean

        '画面初期設定
        bRet = updateFileList(Me.TextBox_InputDir, Me.CheckedListBox_orgPdf)
        Me.ProgressBar1.Value = 0
        Me.ProgressBar2.Value = 0
        Me.Height = g_MeHeight_init
        Me.Width = g_MeWidth_init
        Me.GroupBox_Progress.Visible = False
        Me.ListBox_A4pdfInOne.Visible = False
    End Sub

    '====================================================
    'ファイルリストの更新
    '----------------------------------------------------
    Private Function updateFileList(ByVal txtBox As Windows.Forms.TextBox, _
                                    ByVal lstBox As Windows.Forms.ListBox) As Boolean
        Dim files As String()
        Dim i As Long
        Dim fileSubPath As String

        On Error Resume Next
        files = System.IO.Directory.GetFiles(txtBox.Text, _
                                             "*.pdf", _
                                             System.IO.SearchOption.AllDirectories)
        If Not IsNothing(files) Then
            lstBox.Items.Clear()

            For i = 0 To files.Length - 1 Step 1
                fileSubPath = files(i).Substring(txtBox.Text.Count)
                lstBox.Items.Add(fileSubPath)
            Next i

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
            'TextBoxに表示
            Me.TextBox_InputDir.Text = strDialogResults
            'ファイルリストの更新
            bRet = updateFileList(Me.TextBox_InputDir, Me.CheckedListBox_orgPdf)
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
            'TextBoxに表示
            Me.TextBox_OutputDir.Text = strDialogResults
            'ファイルリストの更新
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

        '条件チェック
        If Not chkConditionBeforeExecute() Then
            Exit Sub
        End If

        Dim inputFilePath As String = String.Empty
        Dim inputFileName As String = String.Empty
        Dim outputFileDir As String = String.Empty
        Dim outputFileName As String = String.Empty
        Dim outputFilePath As String = String.Empty

        Me.GroupBox_Progress.Visible = True
        Me.Width = g_MeWidth_inPrg
        Me.Height = g_MeHeight_inPrg

        'progressbar
        Dim pb1Val As Long = 0
        Me.ProgressBar1.Value = pb1Val
        Me.ProgressBar1.Maximum = Me.CheckedListBox_orgPdf.CheckedItems.Count

        For Each inputFileSubPath In Me.CheckedListBox_orgPdf.CheckedItems
            Me.Label_tgtFile.Text = "converting... " & pb1Val + 1 & "/" & Me.CheckedListBox_orgPdf.CheckedItems.Count & " : " & inputFileName
            Me.Label_tgtFile.Refresh()

            'ファイル名、出力パス等取得()
            bRet = getOutputFilePath(inputFileSubPath, _
                                     inputFilePath, _
                                     inputFileName, _
                                     outputFileName, _
                                     outputFileDir, _
                                     outputFilePath)

            '出力先ディレクトリ作成
            If System.IO.Directory.Exists(outputFileDir) Then
            Else
                System.IO.Directory.CreateDirectory(outputFileDir)
            End If

            'ファイル変換
            bRet = SplitPdfByPage_A3toA4(inputFilePath, outputFilePath)

            'progressbar
            pb1Val = pb1Val + 1
            Me.ProgressBar1.Value = pb1Val
            Me.ProgressBar1.Refresh()

        Next

        'ファイルリストの更新
        bRet = updateFileList(Me.TextBox_OutputDir, Me.ListBox_A4pdfInOne)

        If bRet = True Then
            MsgBox("complete!", MsgBoxStyle.OkOnly, "Split a multipage PDF into single pages")
        End If

        '終了処理
        bRet = terminationBeforeEnd()

    End Sub


    '====================================================
    'Convert button - keep original page size
    '----------------------------------------------------
    Private Sub Button_Convert_Click(sender As Object, e As EventArgs) Handles Button_Convert_AsItIs.Click
        Dim bRet As Boolean

        '条件チェック
        If Not chkConditionBeforeExecute() Then
            Exit Sub
        End If

        Dim inputFilePath As String = String.Empty
        Dim inputFileName As String = String.Empty
        Dim outputFileDir As String = String.Empty
        Dim outputFileName As String = String.Empty
        Dim outputFilePath As String = String.Empty

        Me.GroupBox_Progress.Visible = True
        Me.Width = g_MeWidth_inPrg
        Me.Height = g_MeHeight_inPrg

        'progressbar
        Dim pb1Val As Long = 0
        Me.ProgressBar1.Value = pb1Val
        Me.ProgressBar1.Maximum = Me.CheckedListBox_orgPdf.CheckedItems.Count

        For Each inputFileSubPath In Me.CheckedListBox_orgPdf.CheckedItems
            'label
            Me.Label_tgtFile.Text = "converting... " & pb1Val + 1 & "/" & Me.CheckedListBox_orgPdf.CheckedItems.Count & " : " & inputFileName
            Me.Label_tgtFile.Refresh()

            'ファイル名、出力パス等取得()
            bRet = getOutputFilePath(inputFileSubPath, _
                                     inputFilePath, _
                                     inputFileName, _
                                     outputFileName, _
                                     outputFileDir, _
                                     outputFilePath)

            '出力先ディレクトリ作成
            If System.IO.Directory.Exists(outputFileDir) Then
            Else
                System.IO.Directory.CreateDirectory(outputFileDir)
            End If

            'ファイル変換
            bRet = SplitPdfByPage_AsItIs(inputFilePath, outputFilePath)

            'progressbar
            pb1Val = pb1Val + 1
            Me.ProgressBar1.Value = pb1Val
            Me.ProgressBar1.Refresh()

        Next

        'ファイルリストの更新
        bRet = updateFileList(Me.TextBox_OutputDir, Me.ListBox_A4pdfInOne)

        If bRet = True Then
            MsgBox("complete!", MsgBoxStyle.OkOnly, "Split a multipage PDF into single pages")

        End If

        '終了処理
        bRet = terminationBeforeEnd()

    End Sub

    '====================================================
    'Termination
    '----------------------------------------------------
    Private Function terminationBeforeEnd() As Boolean
        Me.Label_tgtFile.Text = "*** " & Me.ListBox_A4pdfInOne.Items.Count & " files are contained in the output directory."
        Me.Label_tgtFile.BackColor = Color.GreenYellow
        Me.Label_tgtPage.Visible = False
        Me.ListBox_A4pdfInOne.Visible = True

        Me.Button_Exit.BackColor = Color.Aquamarine

        terminationBeforeEnd = True
    End Function


    '====================================================
    'Check conditions before execute
    '----------------------------------------------------
    Private Function chkConditionBeforeExecute() As Boolean
        chkConditionBeforeExecute = True

        'input directory
        If Me.TextBox_InputDir.Text.Equals(String.Empty) Then
            MsgBox("Please select input directory.", MsgBoxStyle.Critical, "error")
            chkConditionBeforeExecute = False
            Exit Function
        End If

        'input directory
        If Not System.IO.Directory.Exists(Me.TextBox_InputDir.Text) Then
            MsgBox("The input directory is not exist.", MsgBoxStyle.Critical, "error")
            chkConditionBeforeExecute = False
            Exit Function
        End If

        'input list
        If Me.CheckedListBox_orgPdf.CheckedItems.Count < 1 Then
            MsgBox("Please check more than one item to convert.", MsgBoxStyle.Critical, "error")
            chkConditionBeforeExecute = False
            Exit Function
        End If

        'output directory
        If Me.TextBox_OutputDir.Text.Equals(String.Empty) Then
            MsgBox("Please select output directory.", MsgBoxStyle.Critical, "error")
            chkConditionBeforeExecute = False
            Exit Function
        End If

        'output directory
        If Not System.IO.Directory.Exists(Me.TextBox_OutputDir.Text) Then
            MsgBox("The output directory is not exist.", MsgBoxStyle.Critical, "error")
            chkConditionBeforeExecute = False
            Exit Function
        End If

        'output directory
        Dim files As String() = System.IO.Directory.GetFiles(Me.TextBox_OutputDir.Text, _
                                                             "*", System.IO.SearchOption.AllDirectories)


        If files.Length > 0 Then
            Dim nRet As DialogResult
            nRet = MsgBox("There are some files or folders in the output directory." & _
                   "This functin will overwrite some files. Would you like to continue?", _
                    MsgBoxStyle.YesNo, "Warning")
            If nRet = DialogResult.No Then
                chkConditionBeforeExecute = False
                Exit Function
            End If
        End If




    End Function


    '====================================================
    'get output path and filename from input file path
    '----------------------------------------------------
    Private Function getOutputFilePath(ByVal inputFileSubPath As String, _
                                       ByRef inputFilePath As String, _
                                       ByRef inputFileName As String, _
                                       ByRef outputFileName As String, _
                                       ByRef outputFileDir As String, _
                                       ByRef outputFilePath As String _
                                       ) As Boolean

        Dim inputFileSubDirName As String = String.Empty
        Try
            'ファイル名取得
            inputFileName = Path.GetFileName(inputFileSubPath)

            '出力ファイル名＝入力ファイル名
            outputFileName = inputFileName

            'サブディレクトリ取得
            If inputFileSubPath.Equals("\" & inputFileName) Then
                inputFileSubDirName = String.Empty
            Else
                inputFileSubDirName = inputFileSubPath.Substring(1, inputFileSubPath.Length - inputFileName.Length - 2)
            End If

            '出力先ディレクトリ
            If inputFileSubDirName.Equals(String.Empty) Then
                outputFileDir = Me.TextBox_OutputDir.Text & "\"
            Else
                outputFileDir = Me.TextBox_OutputDir.Text & "\" & inputFileSubDirName & "\"
            End If

            '出力ファイル名フルパス
            outputFilePath = outputFileDir & outputFileName

            '入力ファイル名フルパス
            inputFilePath = Me.TextBox_InputDir.Text & inputFileSubPath

            getOutputFilePath = True
        Catch ex As Exception
            Throw ex
            getOutputFilePath = False
        End Try

    End Function

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


    '========================================================
    'Check All
    '--------------------------------------------------------
    Private Sub Button_chkAll_Click(sender As Object, e As EventArgs) Handles Button_chkAll.Click
        Dim i As Long
        For i = 0 To Me.CheckedListBox_orgPdf.Items.Count - 1
            Me.CheckedListBox_orgPdf.SetItemChecked(i, True)
        Next
        Me.Label_ChkFileCount.Text = Me.CheckedListBox_orgPdf.CheckedItems.Count & " checked."
    End Sub

    '========================================================
    'Uncheck All
    '--------------------------------------------------------
    Private Sub Button_UnchkAll_Click(sender As Object, e As EventArgs) Handles Button_UnchkAll.Click
        Dim i As Long
        For i = 0 To Me.CheckedListBox_orgPdf.Items.Count - 1
            Me.CheckedListBox_orgPdf.SetItemChecked(i, False)
        Next
        Me.Label_ChkFileCount.Text = Me.CheckedListBox_orgPdf.CheckedItems.Count & " checked."
    End Sub

    '========================================================
    'CheckListBox
    '--------------------------------------------------------
    Private Sub CheckedListBox_orgPdf_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CheckedListBox_orgPdf.SelectedIndexChanged
        Me.Label_ChkFileCount.Text = Me.CheckedListBox_orgPdf.CheckedItems.Count & " checked."
    End Sub

End Class
