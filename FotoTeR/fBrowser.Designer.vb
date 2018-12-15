<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class fBrowser
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fBrowser))
        Me.TreeViewFolderBrowser1 = New Raccoom.Windows.Forms.TreeViewFolderBrowser()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.bOK = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TreeViewFolderBrowser1
        '
        Me.TreeViewFolderBrowser1.DataSource = Nothing
        Me.TreeViewFolderBrowser1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeViewFolderBrowser1.HideSelection = False
        Me.TreeViewFolderBrowser1.Location = New System.Drawing.Point(0, 0)
        Me.TreeViewFolderBrowser1.Name = "TreeViewFolderBrowser1"
        Me.TreeViewFolderBrowser1.ShowLines = False
        Me.TreeViewFolderBrowser1.ShowRootLines = False
        Me.TreeViewFolderBrowser1.Size = New System.Drawing.Size(624, 562)
        Me.TreeViewFolderBrowser1.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.bOK)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 562)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(624, 39)
        Me.Panel1.TabIndex = 1
        '
        'bOK
        '
        Me.bOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.bOK.Image = Global.FotoTeR.My.Resources.Resources.accept
        Me.bOK.Location = New System.Drawing.Point(12, 6)
        Me.bOK.Name = "bOK"
        Me.bOK.Size = New System.Drawing.Size(53, 25)
        Me.bOK.TabIndex = 0
        Me.bOK.Text = "Ok"
        Me.bOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bOK.UseVisualStyleBackColor = True
        '
        'fBrowser
        '
        Me.AcceptButton = Me.bOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(624, 601)
        Me.Controls.Add(Me.TreeViewFolderBrowser1)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(200, 200)
        Me.Name = "fBrowser"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FotoTeR"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TreeViewFolderBrowser1 As Raccoom.Windows.Forms.TreeViewFolderBrowser
    Friend WithEvents Panel1 As Panel
    Friend WithEvents bOK As Button
End Class
