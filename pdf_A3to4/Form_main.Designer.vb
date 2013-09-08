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
        Me.ListBox_A3pdf = New System.Windows.Forms.ListBox()
        Me.Button_Convert_AsItIs = New System.Windows.Forms.Button()
        Me.Button_Exit = New System.Windows.Forms.Button()
        Me.Button_Convert_A3toA4 = New System.Windows.Forms.Button()
        Me.GroupBox_Progress = New System.Windows.Forms.GroupBox()
        Me.ProgressBar2 = New System.Windows.Forms.ProgressBar()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.ListBox_A4pdfInOne = New System.Windows.Forms.ListBox()
        Me.Label_tgtFile = New System.Windows.Forms.Label()
        Me.Label_tgtPage = New System.Windows.Forms.Label()
        Me.GroupBox_Progress.SuspendLayout()
        Me.SuspendLayout()
        '
        'TextBox_InputDir
        '
        Me.TextBox_InputDir.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBox_InputDir.Location = New System.Drawing.Point(15, 29)
        Me.TextBox_InputDir.Name = "TextBox_InputDir"
        Me.TextBox_InputDir.Size = New System.Drawing.Size(452, 24)
        Me.TextBox_InputDir.TabIndex = 0
        Me.TextBox_InputDir.Text = "C:\Users\10007434\Desktop\pdf_input"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(287, 17)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Input directory (A3-size pdf files to convert)"
        '
        'Button_BrowseInputDir
        '
        Me.Button_BrowseInputDir.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button_BrowseInputDir.Location = New System.Drawing.Point(473, 29)
        Me.Button_BrowseInputDir.Name = "Button_BrowseInputDir"
        Me.Button_BrowseInputDir.Size = New System.Drawing.Size(71, 24)
        Me.Button_BrowseInputDir.TabIndex = 2
        Me.Button_BrowseInputDir.Text = "Browse..."
        Me.Button_BrowseInputDir.UseVisualStyleBackColor = True
        '
        'Button_BrowseOutputDir
        '
        Me.Button_BrowseOutputDir.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button_BrowseOutputDir.Location = New System.Drawing.Point(473, 175)
        Me.Button_BrowseOutputDir.Name = "Button_BrowseOutputDir"
        Me.Button_BrowseOutputDir.Size = New System.Drawing.Size(71, 24)
        Me.Button_BrowseOutputDir.TabIndex = 4
        Me.Button_BrowseOutputDir.Text = "Browse..."
        Me.Button_BrowseOutputDir.UseVisualStyleBackColor = True
        '
        'TextBox_OutputDir
        '
        Me.TextBox_OutputDir.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBox_OutputDir.Location = New System.Drawing.Point(15, 175)
        Me.TextBox_OutputDir.Name = "TextBox_OutputDir"
        Me.TextBox_OutputDir.Size = New System.Drawing.Size(452, 24)
        Me.TextBox_OutputDir.TabIndex = 3
        Me.TextBox_OutputDir.Text = "C:\Users\10007434\Desktop\pdf_output"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 155)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(242, 17)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Output directory (for converted files)"
        '
        'ListBox_A3pdf
        '
        Me.ListBox_A3pdf.FormattingEnabled = True
        Me.ListBox_A3pdf.HorizontalScrollbar = True
        Me.ListBox_A3pdf.ItemHeight = 12
        Me.ListBox_A3pdf.Location = New System.Drawing.Point(15, 59)
        Me.ListBox_A3pdf.Name = "ListBox_A3pdf"
        Me.ListBox_A3pdf.Size = New System.Drawing.Size(525, 88)
        Me.ListBox_A3pdf.TabIndex = 6
        '
        'Button_Convert_AsItIs
        '
        Me.Button_Convert_AsItIs.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button_Convert_AsItIs.Location = New System.Drawing.Point(278, 221)
        Me.Button_Convert_AsItIs.Name = "Button_Convert_AsItIs"
        Me.Button_Convert_AsItIs.Size = New System.Drawing.Size(266, 51)
        Me.Button_Convert_AsItIs.TabIndex = 7
        Me.Button_Convert_AsItIs.Text = "Split a multipage PDF into single pages - keep original page size"
        Me.Button_Convert_AsItIs.UseVisualStyleBackColor = True
        '
        'Button_Exit
        '
        Me.Button_Exit.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button_Exit.Location = New System.Drawing.Point(473, 278)
        Me.Button_Exit.Name = "Button_Exit"
        Me.Button_Exit.Size = New System.Drawing.Size(71, 37)
        Me.Button_Exit.TabIndex = 8
        Me.Button_Exit.Text = "Exit"
        Me.Button_Exit.UseVisualStyleBackColor = True
        '
        'Button_Convert_A3toA4
        '
        Me.Button_Convert_A3toA4.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button_Convert_A3toA4.Location = New System.Drawing.Point(12, 221)
        Me.Button_Convert_A3toA4.Name = "Button_Convert_A3toA4"
        Me.Button_Convert_A3toA4.Size = New System.Drawing.Size(265, 51)
        Me.Button_Convert_A3toA4.TabIndex = 10
        Me.Button_Convert_A3toA4.Text = "Split a multipage PDF into single pages - A3 to A4 x 2"
        Me.Button_Convert_A3toA4.UseVisualStyleBackColor = True
        '
        'GroupBox_Progress
        '
        Me.GroupBox_Progress.Controls.Add(Me.Label_tgtPage)
        Me.GroupBox_Progress.Controls.Add(Me.Label_tgtFile)
        Me.GroupBox_Progress.Controls.Add(Me.ProgressBar2)
        Me.GroupBox_Progress.Controls.Add(Me.ProgressBar1)
        Me.GroupBox_Progress.Controls.Add(Me.ListBox_A4pdfInOne)
        Me.GroupBox_Progress.Location = New System.Drawing.Point(12, 272)
        Me.GroupBox_Progress.Name = "GroupBox_Progress"
        Me.GroupBox_Progress.Size = New System.Drawing.Size(528, 216)
        Me.GroupBox_Progress.TabIndex = 13
        Me.GroupBox_Progress.TabStop = False
        Me.GroupBox_Progress.Text = "progress"
        '
        'ProgressBar2
        '
        Me.ProgressBar2.ForeColor = System.Drawing.Color.Yellow
        Me.ProgressBar2.Location = New System.Drawing.Point(6, 33)
        Me.ProgressBar2.MarqueeAnimationSpeed = 10
        Me.ProgressBar2.Name = "ProgressBar2"
        Me.ProgressBar2.Size = New System.Drawing.Size(443, 10)
        Me.ProgressBar2.Step = 1
        Me.ProgressBar2.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ProgressBar2.TabIndex = 15
        '
        'ProgressBar1
        '
        Me.ProgressBar1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ProgressBar1.Location = New System.Drawing.Point(6, 12)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(443, 20)
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
        Me.ListBox_A4pdfInOne.Size = New System.Drawing.Size(516, 165)
        Me.ListBox_A4pdfInOne.TabIndex = 13
        '
        'Label_tgtFile
        '
        Me.Label_tgtFile.AutoSize = True
        Me.Label_tgtFile.BackColor = System.Drawing.Color.White
        Me.Label_tgtFile.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label_tgtFile.Location = New System.Drawing.Point(6, 53)
        Me.Label_tgtFile.Name = "Label_tgtFile"
        Me.Label_tgtFile.Size = New System.Drawing.Size(82, 15)
        Me.Label_tgtFile.TabIndex = 16
        Me.Label_tgtFile.Text = "Label_tgtFile"
        '
        'Label_tgtPage
        '
        Me.Label_tgtPage.AutoSize = True
        Me.Label_tgtPage.BackColor = System.Drawing.Color.White
        Me.Label_tgtPage.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label_tgtPage.Location = New System.Drawing.Point(6, 68)
        Me.Label_tgtPage.Name = "Label_tgtPage"
        Me.Label_tgtPage.Size = New System.Drawing.Size(90, 15)
        Me.Label_tgtPage.TabIndex = 17
        Me.Label_tgtPage.Text = "Label_tgtPage"
        '
        'Form_main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(557, 491)
        Me.Controls.Add(Me.Button_Exit)
        Me.Controls.Add(Me.GroupBox_Progress)
        Me.Controls.Add(Me.Button_Convert_A3toA4)
        Me.Controls.Add(Me.Button_Convert_AsItIs)
        Me.Controls.Add(Me.ListBox_A3pdf)
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
    Friend WithEvents ListBox_A3pdf As System.Windows.Forms.ListBox
    Friend WithEvents Button_Convert_AsItIs As System.Windows.Forms.Button
    Friend WithEvents Button_Exit As System.Windows.Forms.Button
    Friend WithEvents Button_Convert_A3toA4 As System.Windows.Forms.Button
    Friend WithEvents GroupBox_Progress As System.Windows.Forms.GroupBox
    Friend WithEvents ProgressBar2 As System.Windows.Forms.ProgressBar
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents ListBox_A4pdfInOne As System.Windows.Forms.ListBox
    Friend WithEvents Label_tgtFile As System.Windows.Forms.Label
    Friend WithEvents Label_tgtPage As System.Windows.Forms.Label

End Class
