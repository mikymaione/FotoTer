'MIT License
'Copyright(c) 2018 Michele Maione
'Permission Is hereby granted, free Of charge, to any person obtaining a copy of this software And associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, And/Or sell copies of the Software, And to permit persons to whom the Software Is furnished to do so, subject to the following conditions: The above copyright notice And this permission notice shall be included In all copies Or substantial portions Of the Software.
'THE SOFTWARE Is PROVIDED "AS IS", WITHOUT WARRANTY Of ANY KIND, EXPRESS Or IMPLIED, INCLUDING BUT Not LIMITED To THE WARRANTIES Of MERCHANTABILITY, FITNESS For A PARTICULAR PURPOSE And NONINFRINGEMENT. In NO Event SHALL THE AUTHORS Or COPYRIGHT HOLDERS BE LIABLE For ANY CLAIM, DAMAGES Or OTHER LIABILITY, WHETHER In AN ACTION Of CONTRACT, TORT Or OTHERWISE, ARISING FROM, OUT Of Or In CONNECTION With THE SOFTWARE Or THE USE Or OTHER DEALINGS In THE SOFTWARE.
Public Class Form1

    <Serializable()>
    Structure sOpzioni
        Dim From_, To_ As String

        Sub New(ByVal From__ As String, ByVal To__ As String)
            From_ = From__
            To_ = To__
        End Sub
    End Structure

    Structure TipoFile
        Dim Tipo As String
        Dim Numero As Integer

        Sub New(ByVal Tipo_ As String)
            Tipo = Tipo_
            Numero = 0
        End Sub
    End Structure


    Public Property Opzioni As sOpzioni
        Get
            Dim s = IO.Path.Combine(IO.Directory.GetParent(Application.UserAppDataPath).FullName, "\..\FotoTeR\Opzioni.db")

            If IO.File.Exists(s) Then
                Using fs As New IO.FileStream(s, IO.FileMode.Open)
                    Dim bf As New Runtime.Serialization.Formatters.Binary.BinaryFormatter

                    Return bf.Deserialize(fs)
                End Using
            End If

            Return New sOpzioni("", "")
        End Get
        Set(ByVal value As sOpzioni)
            Dim s As String = IO.Directory.GetParent(Application.UserAppDataPath).FullName + "\..\FotoTeR\Opzioni.db"

            Using fs As New IO.FileStream(s, IO.FileMode.OpenOrCreate)
                Dim bf As New Runtime.Serialization.Formatters.Binary.BinaryFormatter
                bf.Serialize(fs, value)
            End Using
        End Set
    End Property


    Private Sub bVai_Click(ByVal sender As Object, ByVal e As EventArgs) Handles bVai.Click
        Vai()
    End Sub

    Private Sub bFrom_Click(ByVal sender As Object, ByVal e As EventArgs) Handles bFrom.Click
        eFrom.Text = ScegliCartella()
    End Sub

    Private Sub bTo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles bTo.Click
        eTo.Text = ScegliCartella()
    End Sub

    Function ScegliCartella() As String
        Using op As New FolderBrowserDialog
            If op.ShowDialog() = DialogResult.OK Then
                Return op.SelectedPath
            Else
                Return Nothing
            End If
        End Using
    End Function

    Sub Vai()
        Dim ok = False
        Dim erro = "Riempire tutti i campi"
        Dim f = eFrom.Text
        Dim t = eTo.Text
        Dim r = eRename.Text

        Me.Enabled = False
        Application.DoEvents()

        Try
            r = r.Replace("\", "")
            r = r.Replace("/", "")
            r = r.Replace("?", "")
            r = r.Replace(":", "")
            r = r.Replace("*", "")
            r = r.Replace("<", "")
            r = r.Replace(">", "")
            r = r.Replace("|", "")
        Catch ex As Exception
            ok = False
        End Try

        If r <> "" Then
            If IO.Directory.Exists(f) Then
                If t <> "" Then
                    Try
                        t = t & "\" & r
                        IO.Directory.CreateDirectory(t)
                    Catch ex As Exception
                        erro = ex.Message
                        ok = False
                    End Try

                    If IO.Directory.Exists(t) Then
                        Dim p = IO.Directory.GetFiles(f, "*", IO.SearchOption.AllDirectories)
                        Dim tt = -1
                        Dim founded = False
                        Dim typ(99) As TipoFile

                        For y As Integer = 0 To p.Length - 1
                            founded = False

                            If Not typ Is Nothing Then
                                If typ.Length > 0 Then
                                    For z As Integer = 0 To typ.Length - 1
                                        If IO.Path.GetExtension(p(y)) = typ(z).Tipo Then
                                            founded = True
                                            Exit For
                                        End If
                                    Next
                                End If
                            End If

                            If founded = False Then
                                tt += 1
                                typ(tt) = New TipoFile(IO.Path.GetExtension(p(y)))
                            End If
                        Next

                        Dim Type_(tt) As TipoFile

                        Array.Copy(typ, Type_, tt + 1)

                        If Not p Is Nothing Then
                            If p.Length > 0 Then
                                Dim s, d As String

                                Me.ProgressBar1.Visible = True
                                Me.ProgressBar1.Maximum = p.Length
                                Application.DoEvents()

                                If MsgBox("Vuoi copiare " & p.Length & " file ?", vbQuestion Or vbYesNo) = MsgBoxResult.Yes Then
                                    Application.DoEvents()

                                    Array.Sort(p)

                                    For x As Integer = 0 To p.Length - 1
                                        s = p(x)
                                        d = t & "\" & r & " (" & GetNumberByType(Type_, IO.Path.GetExtension(s)) & ")" & IO.Path.GetExtension(s)

                                        Try
                                            IO.File.Copy(s, d, False)
                                        Catch ex As Exception
                                            ok = False
                                        End Try

                                        Me.ProgressBar1.Value = x + 1
                                        Application.DoEvents()
                                    Next

                                    ok = True
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If

        If ok Then
            MsgBox("Finito !", vbInformation)

            Try
                Process.Start(t)
            Catch ex As Exception
                Application.DoEvents()
            End Try

            Spegni()
        Else
            Me.Enabled = True
            MsgBox("Errore : " & erro, vbExclamation)
        End If
    End Sub

    Sub PreSpegni()
        Opzioni = New sOpzioni(eFrom.Text, eTo.Text)
    End Sub

    Sub Spegni()
        PreSpegni()

        Application.DoEvents()
        Me.Close()
    End Sub

    Function GetNumberByType(ByRef Array_() As TipoFile, ByVal Type_ As String) As Integer
        Dim i = 0

        If Not Array_ Is Nothing Then
            If Array_.Length > 0 Then
                For y As Integer = 0 To Array_.Length - 1
                    If Array_(y).Tipo = Type_ Then
                        Array_(y).Numero += 1
                        i = Array_(y).Numero

                        Exit For
                    End If
                Next
            End If
        End If

        Return i
    End Function

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        PreSpegni()
    End Sub

    Public Function DateToStringWithUnderSpace(ByVal dd As Date) As String
        Dim d = dd.Day
        Dim m = dd.Month
        Dim y = Microsoft.VisualBasic.Right(dd.Year, 2)

        If dd.Day < 10 Then d = "0" & d
        If dd.Month < 10 Then m = "0" & m

        Dim s = y & "_" & m & "_" & d

        Return s
    End Function

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim o = Opzioni

        Me.eRename.Text = "_" & DateToStringWithUnderSpace(Now.AddDays(-1))
        Me.eRename.SelectionStart = 0
        Me.eRename.SelectionLength = 0

        If IO.Directory.Exists(o.To_) Then Me.eTo.Text = o.To_
        If IO.Directory.Exists(o.From_) Then Me.eFrom.Text = o.From_
    End Sub


End Class