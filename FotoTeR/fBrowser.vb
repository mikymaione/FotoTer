'MIT License
'Copyright(c) 2018 Michele Maione
'Permission Is hereby granted, free Of charge, to any person obtaining a copy of this software And associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, And/Or sell copies of the Software, And to permit persons to whom the Software Is furnished to do so, subject to the following conditions: The above copyright notice And this permission notice shall be included In all copies Or substantial portions Of the Software.
'THE SOFTWARE Is PROVIDED "AS IS", WITHOUT WARRANTY Of ANY KIND, EXPRESS Or IMPLIED, INCLUDING BUT Not LIMITED To THE WARRANTIES Of MERCHANTABILITY, FITNESS For A PARTICULAR PURPOSE And NONINFRINGEMENT. In NO Event SHALL THE AUTHORS Or COPYRIGHT HOLDERS BE LIABLE For ANY CLAIM, DAMAGES Or OTHER LIABILITY, WHETHER In AN ACTION Of CONTRACT, TORT Or OTHERWISE, ARISING FROM, OUT Of Or In CONNECTION With THE SOFTWARE Or THE USE Or OTHER DEALINGS In THE SOFTWARE.
Public Class fBrowser

    Public Path As String = ""

    Private Sub fBrowser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim shell32Provider As New Raccoom.Windows.Forms.TreeStrategyShell32Provider() With {
            .EnableContextMenu = True,
            .ShowAllShellObjects = True
        }

        TreeViewFolderBrowser1.DataSource = shell32Provider
        TreeViewFolderBrowser1.Populate()
    End Sub

    Private Sub bOK_Click(sender As Object, e As EventArgs) Handles bOK.Click
        Dim n = TreeViewFolderBrowser1.SelectedNode
        Path = n.FullPath
    End Sub

End Class