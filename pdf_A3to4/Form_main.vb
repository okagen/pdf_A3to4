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

        '隠しデータ設定
        Me.TextBox_A4W.Text = PageSize.A4.Width.ToString()
        Me.TextBox_A4H.Text = PageSize.A4.Height.ToString()
        Me.TextBox_A3W.Text = PageSize.A3.Width.ToString()
        Me.TextBox_A3H.Text = PageSize.A3.Height.ToString()

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
            bRet = convertPDF(inputFilePath, outputFilePath, True)

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
            bRet = convertPDF(inputFilePath, outputFilePath, False)

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
    'convert main
    '--------------------------------------------------------
    Private Function convertPDF(ByVal sourcePdf As String, _
                                  ByVal baseNameOutPdf As String, _
                                  ByVal divA4 As Boolean) As Boolean

        Dim reader As iTextSharp.text.pdf.PdfReader = Nothing
        Dim readerPageCount As Integer = 0
        Dim readerCurrentPage As Integer = 1
        Dim pageSizeID As Integer = 0
        Dim bRet As Boolean

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
                    'page sizeを取得
                    pageSizeID = chkPageSizeA4(reader, i)

                    '出力
                    If divA4 = True And pageSizeID = 3 Then
                        bRet = ExportPdfByPage_A3toA4(reader, i, baseNameOutPdf)
                    Else
                        bRet = SplitPdfByPage_AsItIs(reader, i, baseNameOutPdf)
                    End If

                    readerCurrentPage += 1
                Next i
            End If
            reader.Close()
            convertPDF = True
        Catch ex As Exception
            Throw ex
            convertPDF = False
        End Try
    End Function

    '====================================================
    'Get page size
    '幅だけで判断　誤差 10 pixels
    '1:A4サイズより小さい
    '2:A4サイズ
    '3:A4サイズより大きい
    '----------------------------------------------------
    Private Function chkPageSizeA4(ByVal reader As PdfReader, _
                                   ByVal pageNo As Long) As Integer
        Dim PageSize As Rectangle = reader.GetPageSize(pageNo)

        If PageSize.Width < CInt(Me.TextBox_A4W.Text) - 10 Then
            chkPageSizeA4 = 1
        ElseIf CInt(Me.TextBox_A4W.Text) - 10 <= PageSize.Width And _
             PageSize.Width <= CInt(Me.TextBox_A4W.Text) + 10 Then
            chkPageSizeA4 = 2
        ElseIf CInt(Me.TextBox_A4W.Text) + 10 < PageSize.Width Then
            chkPageSizeA4 = 3
        Else
            chkPageSizeA4 = 0
        End If
    End Function

    '========================================================
    'Split a multipage PDF into single pages - A3 to A4 x 2
    '--------------------------------------------------------
    Private Function ExportPdfByPage_A3toA4(ByVal reader As PdfReader, _
                                            ByVal pageNo As Long, _
                                            ByVal baseNameOutPdf As String
                                            ) As Boolean
        Try
            '出力用ファイル名を2種類準備
            Dim outfileName1 As String = String.Empty
            Dim outfileName2 As String = String.Empty
            Dim ext As String = Path.GetExtension(baseNameOutPdf)
            outfileName1 = baseNameOutPdf.Replace(ext, "_" & pageNo.ToString("000") & "-1" & ext)
            outfileName2 = baseNameOutPdf.Replace(ext, "_" & pageNo.ToString("000") & "-2" & ext)

            'A4サイズのdocインスタンスを生成
            Dim doc1 As iTextSharp.text.Document = Nothing
            Dim doc2 As iTextSharp.text.Document = Nothing
            doc1 = New iTextSharp.text.Document(PageSize.A4)
            doc2 = New iTextSharp.text.Document(PageSize.A4)

            'MSを使ってdocとwriterを関連付け(writer <- MS -> doc)
            Dim ms1 = New MemoryStream()
            Dim writer1 = PdfWriter.GetInstance(doc1, ms1)
            Dim ms2 = New MemoryStream()
            Dim writer2 = PdfWriter.GetInstance(doc2, ms2)

            'docを開き、cbに展開(cb = writer <- MS -> doc)
            Dim cb1 As PdfContentByte
            Dim cb2 As PdfContentByte
            doc1.Open()
            cb1 = writer1.DirectContent
            doc2.Open()
            cb2 = writer2.DirectContent

            'pageを取得
            Dim page1 As iTextSharp.text.pdf.PdfImportedPage = Nothing
            Dim page2 As iTextSharp.text.pdf.PdfImportedPage = Nothing
            page1 = writer1.GetImportedPage(reader, pageNo)
            page2 = writer2.GetImportedPage(reader, pageNo)

            'pageをcbに入れる(reader <- page = cb = writer <- MS -> doc)
            cb1.AddTemplate(page1, 1.0F, 0, 0, 1.0F, 0, 0)
            doc1.Close()
            File.WriteAllBytes(outfileName1, ms1.GetBuffer())

            'pageをA4幅分左にずらして、cbに入れる
            cb2.AddTemplate(page2, 1.0F, 0, 0, 1.0F, -PageSize.A4.Width, 0)
            doc2.Close()
            File.WriteAllBytes(outfileName2, ms2.GetBuffer())

            ExportPdfByPage_A3toA4 = True
        Catch ex As Exception
            Throw ex
            ExportPdfByPage_A3toA4 = False
        End Try
    End Function


    '========================================================
    'Split a multipage PDF into single pages - keep original page size
    '--------------------------------------------------------
    Private Function SplitPdfByPage_AsItIs(ByVal reader As PdfReader, _
                                            ByVal pageNo As Long, _
                                            ByVal baseNameOutPdf As String
                                            ) As Boolean

        Try
            '出力用ファイル名
            Dim outfileName As String = String.Empty
            Dim ext As String = Path.GetExtension(baseNameOutPdf)
            outfileName = baseNameOutPdf.Replace(ext, "_" & pageNo.ToString("000") & ext)

            'A4サイズのDOCのCopy用インスタンスを生成()
            Dim doc As iTextSharp.text.Document = Nothing
            doc = New iTextSharp.text.Document(PageSize.A4)
            Dim pdfCpy As iTextSharp.text.pdf.PdfCopy = Nothing
            pdfCpy = New iTextSharp.text.pdf.PdfCopy(doc, New FileStream(outfileName, FileMode.Create))
            doc.Open()

            'pageを取得
            Dim page As iTextSharp.text.pdf.PdfImportedPage = Nothing
            page = pdfCpy.GetImportedPage(reader, pageNo)

            'pageを追加し、Docを閉じる
            pdfCpy.AddPage(page)
            doc.Close()

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
