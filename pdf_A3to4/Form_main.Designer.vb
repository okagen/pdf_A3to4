<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_main
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TextBox_InputDir = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button_BrowseInputDir = New System.Windows.Forms.Button()
        Me.Button_BrowseOutputDir = New System.Windows.Forms.Button()
        Me.TextBox_OutputDir = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button_Convert_AsItIs = New System.Windows.Forms.Button()
        Me.Button_Exit = New System.Windows.Forms.Button()
        Me.Button_Convert_A3toA4 = New System.Windows.Forms.Button()
        Me.GroupBox_Progress = New System.Windows.Forms.GroupBox()
        Me.Label_tgtPage = New System.Windows.Forms.Label()
        Me.Label_tgtFile = New System.Windows.Forms.Label()
        Me.ProgressBar2 = New System.Windows.Forms.ProgressBar()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.ListBox_A4pdfInOne = New System.Windows.Forms.ListBox()
        Me.CheckedListBox_orgPdf = New System.Windows.Forms.CheckedListBox()
        Me.Button_chkAll = New System.Windows.Forms.Button()
        Me.Button_UnchkAll = New System.Windows.Forms.Button()
        Me.Label_ChkFileCount = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBox_A4W = New System.Windows.Forms.TextBox()
        Me.TextBox_A4H = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextBox_A3H = New System.Windows.Forms.TextBox()
        Me.TextBox_A3W = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox_Progress.SuspendLayout()
        Me.SuspendLayout()
        '
        'TextBox_InputDir
        '
        Me.TextBox_InputDir.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBox_InputDir.Location = New System.Drawing.Point(15, 29)
        Me.TextBox_InputDir.Name = "TextBox_InputDir"
        Me.TextBox_InputDir.Size = New System.Drawing.Size(529, 24)
        Me.TextBox_InputDir.TabIndex = 0
        Me.TextBox_InputDir.Text = "C:\Users\10007434\Desktop\input"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(435, 17)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Input directory (pdf files which contain multi-size pages to convert)"
        '
        'Button_BrowseInputDir
        '
        Me.Button_BrowseInputDir.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button_BrowseInputDir.Location = New System.Drawing.Point(550, 29)
        Me.Button_BrowseInputDir.Name = "Button_BrowseInputDir"
        Me.Button_BrowseInputDir.Size = New System.Drawing.Size(71, 24)
        Me.Button_BrowseInputDir.TabIndex = 2
        Me.Button_BrowseInputDir.Text = "Browse..."
        Me.Button_BrowseInputDir.UseVisualStyleBackColor = True
        '
        'Button_BrowseOutputDir
        '
        Me.Button_BrowseOutputDir.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button_BrowseOutputDir.Location = New System.Drawing.Point(550, 228)
        Me.Button_BrowseOutputDir.Name = "Button_BrowseOutputDir"
        Me.Button_BrowseOutputDir.Size = New System.Drawing.Size(71, 24)
        Me.Button_BrowseOutputDir.TabIndex = 4
        Me.Button_BrowseOutputDir.Text = "Browse..."
        Me.Button_BrowseOutputDir.UseVisualStyleBackColor = True
        '
        'TextBox_OutputDir
        '
        Me.TextBox_OutputDir.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBox_OutputDir.Location = New System.Drawing.Point(15, 228)
        Me.TextBox_OutputDir.Name = "TextBox_OutputDir"
        Me.TextBox_OutputDir.Size = New System.Drawing.Size(529, 24)
        Me.TextBox_OutputDir.TabIndex = 3
        Me.TextBox_OutputDir.Text = "C:\Users\10007434\Desktop\output"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 208)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(242, 17)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Output directory (for converted files)"
        '
        'Button_Convert_AsItIs
        '
        Me.Button_Convert_AsItIs.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button_Convert_AsItIs.Location = New System.Drawing.Point(278, 280)
        Me.Button_Convert_AsItIs.Name = "Button_Convert_AsItIs"
        Me.Button_Convert_AsItIs.Size = New System.Drawing.Size(266, 45)
        Me.Button_Convert_AsItIs.TabIndex = 7
        Me.Button_Convert_AsItIs.Text = "- keep original page size"
        Me.Button_Convert_AsItIs.UseVisualStyleBackColor = True
        '
        'Button_Exit
        '
        Me.Button_Exit.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button_Exit.Location = New System.Drawing.Point(552, 292)
        Me.Button_Exit.Name = "Button_Exit"
        Me.Button_Exit.Size = New System.Drawing.Size(69, 33)
        Me.Button_Exit.TabIndex = 8
        Me.Button_Exit.Text = "Exit"
        Me.Button_Exit.UseVisualStyleBackColor = True
        '
        'Button_Convert_A3toA4
        '
        Me.Button_Convert_A3toA4.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button_Convert_A3toA4.Location = New System.Drawing.Point(12, 280)
        Me.Button_Convert_A3toA4.Name = "Button_Convert_A3toA4"
        Me.Button_Convert_A3toA4.Size = New System.Drawing.Size(265, 45)
        Me.Button_Convert_A3toA4.TabIndex = 10
        Me.Button_Convert_A3toA4.Text = "- divide A3 in A4 x 2"
        Me.Button_Convert_A3toA4.UseVisualStyleBackColor = True
        '
        'GroupBox_Progress
        '
        Me.GroupBox_Progress.Controls.Add(Me.Label_tgtPage)
        Me.GroupBox_Progress.Controls.Add(Me.Label_tgtFile)
        Me.GroupBox_Progress.Controls.Add(Me.ProgressBar2)
        Me.GroupBox_Progress.Controls.Add(Me.ProgressBar1)
        Me.GroupBox_Progress.Controls.Add(Me.ListBox_A4pdfInOne)
        Me.GroupBox_Progress.Location = New System.Drawing.Point(12, 331)
        Me.GroupBox_Progress.Name = "GroupBox_Progress"
        Me.GroupBox_Progress.Size = New System.Drawing.Size(609, 221)
        Me.GroupBox_Progress.TabIndex = 13
        Me.GroupBox_Progress.TabStop = False
        Me.GroupBox_Progress.Text = "progress"
        '
        'Label_tgtPage
        '
        Me.Label_tgtPage.AutoSize = True
        Me.Label_tgtPage.BackColor = System.Drawing.Color.White
        Me.Label_tgtPage.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label_tgtPage.Location = New System.Drawing.Point(6, 70)
        Me.Label_tgtPage.Name = "Label_tgtPage"
        Me.Label_tgtPage.Size = New System.Drawing.Size(90, 15)
        Me.Label_tgtPage.TabIndex = 17
        Me.Label_tgtPage.Text = "Label_tgtPage"
        '
        'Label_tgtFile
        '
        Me.Label_tgtFile.AutoSize = True
        Me.Label_tgtFile.BackColor = System.Drawing.Color.White
        Me.Label_tgtFile.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label_tgtFile.Location = New System.Drawing.Point(6, 55)
        Me.Label_tgtFile.Name = "Label_tgtFile"
        Me.Label_tgtFile.Size = New System.Drawing.Size(82, 15)
        Me.Label_tgtFile.TabIndex = 16
        Me.Label_tgtFile.Text = "Label_tgtFile"
        '
        'ProgressBar2
        '
        Me.ProgressBar2.ForeColor = System.Drawing.Color.Yellow
        Me.ProgressBar2.Location = New System.Drawing.Point(6, 35)
        Me.ProgressBar2.MarqueeAnimationSpeed = 10
        Me.ProgressBar2.Name = "ProgressBar2"
        Me.ProgressBar2.Size = New System.Drawing.Size(596, 10)
        Me.ProgressBar2.Step = 1
        Me.ProgressBar2.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ProgressBar2.TabIndex = 15
        '
        'ProgressBar1
        '
        Me.ProgressBar1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ProgressBar1.Location = New System.Drawing.Point(6, 14)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(597, 20)
        Me.ProgressBar1.Step = 1
        Me.ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ProgressBar1.TabIndex = 14
        '
        'ListBox_A4pdfInOne
        '
        Me.ListBox_A4pdfInOne.BackColor = System.Drawing.Color.White
        Me.ListBox_A4pdfInOne.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListBox_A4pdfInOne.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ListBox_A4pdfInOne.ForeColor = System.Drawing.Color.Gray
        Me.ListBox_A4pdfInOne.FormattingEnabled = True
        Me.ListBox_A4pdfInOne.HorizontalScrollbar = True
        Me.ListBox_A4pdfInOne.ItemHeight = 15
        Me.ListBox_A4pdfInOne.Location = New System.Drawing.Point(6, 49)
        Me.ListBox_A4pdfInOne.Name = "ListBox_A4pdfInOne"
        Me.ListBox_A4pdfInOne.Size = New System.Drawing.Size(597, 165)
        Me.ListBox_A4pdfInOne.TabIndex = 13
        '
        'CheckedListBox_orgPdf
        '
        Me.CheckedListBox_orgPdf.CheckOnClick = True
        Me.CheckedListBox_orgPdf.FormattingEnabled = True
        Me.CheckedListBox_orgPdf.HorizontalScrollbar = True
        Me.CheckedListBox_orgPdf.Location = New System.Drawing.Point(15, 59)
        Me.CheckedListBox_orgPdf.Name = "CheckedListBox_orgPdf"
        Me.CheckedListBox_orgPdf.Size = New System.Drawing.Size(529, 144)
        Me.CheckedListBox_orgPdf.TabIndex = 14
        '
        'Button_chkAll
        '
        Me.Button_chkAll.Location = New System.Drawing.Point(550, 150)
        Me.Button_chkAll.Name = "Button_chkAll"
        Me.Button_chkAll.Size = New System.Drawing.Size(71, 24)
        Me.Button_chkAll.TabIndex = 15
        Me.Button_chkAll.Text = "Check all"
        Me.Button_chkAll.UseVisualStyleBackColor = True
        '
        'Button_UnchkAll
        '
        Me.Button_UnchkAll.Location = New System.Drawing.Point(550, 180)
        Me.Button_UnchkAll.Name = "Button_UnchkAll"
        Me.Button_UnchkAll.Size = New System.Drawing.Size(71, 23)
        Me.Button_UnchkAll.TabIndex = 16
        Me.Button_UnchkAll.Text = "Unchk all"
        Me.Button_UnchkAll.UseVisualStyleBackColor = True
        '
        'Label_ChkFileCount
        '
        Me.Label_ChkFileCount.AutoSize = True
        Me.Label_ChkFileCount.Location = New System.Drawing.Point(550, 132)
        Me.Label_ChkFileCount.Name = "Label_ChkFileCount"
        Me.Label_ChkFileCount.Size = New System.Drawing.Size(57, 12)
        Me.Label_ChkFileCount.TabIndex = 17
        Me.Label_ChkFileCount.Text = "0 checked"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(15, 260)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(253, 17)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Split a multipage PDF into single pages"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(645, 62)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(25, 12)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "A4 :"
        '
        'TextBox_A4W
        '
        Me.TextBox_A4W.Location = New System.Drawing.Point(676, 59)
        Me.TextBox_A4W.Name = "TextBox_A4W"
        Me.TextBox_A4W.Size = New System.Drawing.Size(36, 19)
        Me.TextBox_A4W.TabIndex = 20
        '
        'TextBox_A4H
        '
        Me.TextBox_A4H.Location = New System.Drawing.Point(735, 59)
        Me.TextBox_A4H.Name = "TextBox_A4H"
        Me.TextBox_A4H.Size = New System.Drawing.Size(36, 19)
        Me.TextBox_A4H.TabIndex = 21
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(718, 62)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(11, 12)
        Me.Label5.TabIndex = 22
        Me.Label5.Text = "x"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(718, 87)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(11, 12)
        Me.Label6.TabIndex = 26
        Me.Label6.Text = "x"
        '
        'TextBox_A3H
        '
        Me.TextBox_A3H.Location = New System.Drawing.Point(735, 84)
        Me.TextBox_A3H.Name = "TextBox_A3H"
        Me.TextBox_A3H.Size = New System.Drawing.Size(36, 19)
        Me.TextBox_A3H.TabIndex = 25
        '
        'TextBox_A3W
        '
        Me.TextBox_A3W.Location = New System.Drawing.Point(676, 84)
        Me.TextBox_A3W.Name = "TextBox_A3W"
        Me.TextBox_A3W.Size = New System.Drawing.Size(36, 19)
        Me.TextBox_A3W.TabIndex = 24
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(645, 87)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(25, 12)
        Me.Label7.TabIndex = 23
        Me.Label7.Text = "A3 :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(627, 36)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(146, 12)
        Me.Label8.TabIndex = 27
        Me.Label8.Text = "Paper Size in Pixels (72ppi)"
        '
        'Form_main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(792, 560)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TextBox_A3H)
        Me.Controls.Add(Me.TextBox_A3W)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TextBox_A4H)
        Me.Controls.Add(Me.TextBox_A4W)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label_ChkFileCount)
        Me.Controls.Add(Me.Button_UnchkAll)
        Me.Controls.Add(Me.Button_chkAll)
        Me.Controls.Add(Me.CheckedListBox_orgPdf)
        Me.Controls.Add(Me.Button_Exit)
        Me.Controls.Add(Me.GroupBox_Progress)
        Me.Controls.Add(Me.Button_Convert_A3toA4)
        Me.Controls.Add(Me.Button_Convert_AsItIs)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button_BrowseOutputDir)
        Me.Controls.Add(Me.TextBox_OutputDir)
        Me.Controls.Add(Me.Button_BrowseInputDir)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBox_InputDir)
        Me.Name = "Form_main"
        Me.Text = "Convert A3 to A4 x 2"
        Me.GroupBox_Progress.ResumeLayout(False)
        Me.GroupBox_Progress.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextBox_InputDir As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button_BrowseInputDir As System.Windows.Forms.Button
    Friend WithEvents Button_BrowseOutputDir As System.Windows.Forms.Button
    Friend WithEvents TextBox_OutputDir As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button_Convert_AsItIs As System.Windows.Forms.Button
    Friend WithEvents Button_Exit As System.Windows.Forms.Button
    Friend WithEvents Button_Convert_A3toA4 As System.Windows.Forms.Button
    Friend WithEvents GroupBox_Progress As System.Windows.Forms.GroupBox
    Friend WithEvents ProgressBar2 As System.Windows.Forms.ProgressBar
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents ListBox_A4pdfInOne As System.Windows.Forms.ListBox
    Friend WithEvents Label_tgtFile As System.Windows.Forms.Label
    Friend WithEvents Label_tgtPage As System.Windows.Forms.Label
    Friend WithEvents CheckedListBox_orgPdf As System.Windows.Forms.CheckedListBox
    Friend WithEvents Button_chkAll As System.Windows.Forms.Button
    Friend WithEvents Button_UnchkAll As System.Windows.Forms.Button
    Friend WithEvents Label_ChkFileCount As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextBox_A4W As System.Windows.Forms.TextBox
    Friend WithEvents TextBox_A4H As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TextBox_A3H As System.Windows.Forms.TextBox
    Friend WithEvents TextBox_A3W As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label

End Class
