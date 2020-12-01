<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class fMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fMain))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.eFrom = New System.Windows.Forms.TextBox()
        Me.eTo = New System.Windows.Forms.TextBox()
        Me.eRename = New System.Windows.Forms.TextBox()
        Me.bFrom = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.bVai = New System.Windows.Forms.Button()
        Me.bTo = New System.Windows.Forms.Button()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.cbRinomina = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(117, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Trasferisci da percorso:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(111, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Trasferisci a percorso:"
        '
        'eFrom
        '
        Me.eFrom.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.eFrom.Location = New System.Drawing.Point(12, 25)
        Me.eFrom.Name = "eFrom"
        Me.eFrom.ReadOnly = True
        Me.eFrom.Size = New System.Drawing.Size(420, 20)
        Me.eFrom.TabIndex = 0
        '
        'eTo
        '
        Me.eTo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.eTo.Location = New System.Drawing.Point(12, 74)
        Me.eTo.Name = "eTo"
        Me.eTo.ReadOnly = True
        Me.eTo.Size = New System.Drawing.Size(420, 20)
        Me.eTo.TabIndex = 2
        '
        'eRename
        '
        Me.eRename.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.eRename.Enabled = False
        Me.eRename.Location = New System.Drawing.Point(12, 133)
        Me.eRename.Name = "eRename"
        Me.eRename.Size = New System.Drawing.Size(451, 20)
        Me.eRename.TabIndex = 5
        Me.ToolTip1.SetToolTip(Me.eRename, "Se lasciato vuoto non verrà creata la cartella")
        '
        'bFrom
        '
        Me.bFrom.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bFrom.Image = Global.FotoTeR.My.Resources.Resources.folder_picture
        Me.bFrom.Location = New System.Drawing.Point(438, 23)
        Me.bFrom.Name = "bFrom"
        Me.bFrom.Size = New System.Drawing.Size(25, 25)
        Me.bFrom.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.bFrom, "Scegli cartella ...")
        Me.bFrom.UseVisualStyleBackColor = True
        '
        'ToolTip1
        '
        Me.ToolTip1.IsBalloon = True
        Me.ToolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTip1.ToolTipTitle = "Informazione"
        '
        'bVai
        '
        Me.bVai.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bVai.Image = Global.FotoTeR.My.Resources.Resources.accept
        Me.bVai.Location = New System.Drawing.Point(407, 172)
        Me.bVai.Name = "bVai"
        Me.bVai.Size = New System.Drawing.Size(56, 25)
        Me.bVai.TabIndex = 6
        Me.bVai.Text = "Vai"
        Me.bVai.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ToolTip1.SetToolTip(Me.bVai, "Inizia il processo di trasferimento e rinomina")
        Me.bVai.UseVisualStyleBackColor = True
        '
        'bTo
        '
        Me.bTo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bTo.Image = Global.FotoTeR.My.Resources.Resources.folder_picture
        Me.bTo.Location = New System.Drawing.Point(438, 72)
        Me.bTo.Name = "bTo"
        Me.bTo.Size = New System.Drawing.Size(25, 25)
        Me.bTo.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.bTo, "Scegli cartella ...")
        Me.bTo.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProgressBar1.Location = New System.Drawing.Point(12, 172)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(389, 25)
        Me.ProgressBar1.TabIndex = 6
        Me.ProgressBar1.Visible = False
        '
        'cbRinomina
        '
        Me.cbRinomina.AutoSize = True
        Me.cbRinomina.Location = New System.Drawing.Point(12, 110)
        Me.cbRinomina.Name = "cbRinomina"
        Me.cbRinomina.Size = New System.Drawing.Size(84, 17)
        Me.cbRinomina.TabIndex = 4
        Me.cbRinomina.Text = "Rinomina in:"
        Me.cbRinomina.UseVisualStyleBackColor = True
        '
        'fMain
        '
        Me.AcceptButton = Me.bVai
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(477, 209)
        Me.Controls.Add(Me.cbRinomina)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.bVai)
        Me.Controls.Add(Me.bTo)
        Me.Controls.Add(Me.bFrom)
        Me.Controls.Add(Me.eRename)
        Me.Controls.Add(Me.eTo)
        Me.Controls.Add(Me.eFrom)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(800, 1000)
        Me.MinimumSize = New System.Drawing.Size(335, 39)
        Me.Name = "fMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FotoTeR"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents eFrom As System.Windows.Forms.TextBox
    Friend WithEvents eTo As System.Windows.Forms.TextBox
    Friend WithEvents eRename As System.Windows.Forms.TextBox
    Friend WithEvents bFrom As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents bTo As System.Windows.Forms.Button
    Friend WithEvents bVai As System.Windows.Forms.Button
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents cbRinomina As CheckBox
End Class
