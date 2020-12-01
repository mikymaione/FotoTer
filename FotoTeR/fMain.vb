'MIT License
'Copyright(c) 2018 Michele Maione
'Permission Is hereby granted, free Of charge, to any person obtaining a copy of this software And associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, And/Or sell copies of the Software, And to permit persons to whom the Software Is furnished to do so, subject to the following conditions: The above copyright notice And this permission notice shall be included In all copies Or substantial portions Of the Software.
'THE SOFTWARE Is PROVIDED "AS IS", WITHOUT WARRANTY Of ANY KIND, EXPRESS Or IMPLIED, INCLUDING BUT Not LIMITED To THE WARRANTIES Of MERCHANTABILITY, FITNESS For A PARTICULAR PURPOSE And NONINFRINGEMENT. In NO Event SHALL THE AUTHORS Or COPYRIGHT HOLDERS BE LIABLE For ANY CLAIM, DAMAGES Or OTHER LIABILITY, WHETHER In AN ACTION Of CONTRACT, TORT Or OTHERWISE, ARISING FROM, OUT Of Or In CONNECTION With THE SOFTWARE Or THE USE Or OTHER DEALINGS In THE SOFTWARE.
Imports System.IO
Imports MediaDevices

Public Class fMain

    Private MioDevice As DevicePath
    Private PercorsoDB As String = Directory.GetParent(Application.UserAppDataPath).FullName & "\..\FotoTeR\Opzioni.db"


    <Serializable()>
    Structure sOpzioni
        Dim From_, To_ As String

        Sub New(ByVal From__ As String, ByVal To__ As String)
            From_ = From__
            To_ = To__
        End Sub
    End Structure

    Structure DevicePath
        Dim device As MediaDevice
        Dim percorso As String
    End Structure

    Structure TipoFile
        Dim Tipo As String
        Dim Numero As Integer

        Sub New(ByVal Tipo_ As String)
            Tipo = Tipo_
            Numero = 0
        End Sub
    End Structure

    Public WriteOnly Property AbilitaInterfaccia As Boolean
        Set(ByVal value As Boolean)
            Cursor.Current = IIf(value, Cursors.Default, Cursors.WaitCursor)

            bFrom.Enabled = value
            bTo.Enabled = value
            bVai.Enabled = value
            cbRinomina.Enabled = value
            eRename.Enabled = value

            Application.DoEvents()
        End Set
    End Property

    Public Property Opzioni As sOpzioni
        Get
            If File.Exists(PercorsoDB) Then
                Try
                    Using fs As New FileStream(PercorsoDB, FileMode.Open)
                        Dim bf As New Runtime.Serialization.Formatters.Binary.BinaryFormatter

                        Return bf.Deserialize(fs)
                    End Using
                Catch ex As Exception
                    MsgBox("Errore: " & ex.Message, MsgBoxStyle.Exclamation)
                End Try
            End If

            Return New sOpzioni("", "")
        End Get
        Set(ByVal value As sOpzioni)
            Using fs As New FileStream(PercorsoDB, FileMode.OpenOrCreate)
                Dim bf As New Runtime.Serialization.Formatters.Binary.BinaryFormatter

                bf.Serialize(fs, value)
            End Using
        End Set
    End Property


    Private Sub bVai_Click(ByVal sender As Object, ByVal e As EventArgs) Handles bVai.Click
        AbilitaInterfaccia = False

        Try
            Vai()
        Catch ex As Exception
            MsgBox("Errore: " & ex.Message, vbExclamation)
        End Try

        AbilitaInterfaccia = True
    End Sub

    Private Sub bFrom_Click(ByVal sender As Object, ByVal e As EventArgs) Handles bFrom.Click
        eFrom.Text = ScegliCartella()
    End Sub

    Private Sub bTo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles bTo.Click
        eTo.Text = ScegliCartella()
    End Sub

    Private Function ScegliCartella() As String
        Using fb As New fBrowser()
            If fb.ShowDialog() = DialogResult.OK Then
                Return fb.Path
            End If
        End Using

        Return ""
    End Function

    Private Sub Vai()
        Dim ok = False
        Dim error_text = "Riempire tutti i campi"
        Dim folder_to = eTo.Text
        Dim folder_from = eFrom.Text
        Dim folder_from_abs = folder_from
        Dim rename_string = If(cbRinomina.Checked, eRename.Text, "")

        rename_string = rename_string.Replace("\", "")
        rename_string = rename_string.Replace("/", "")
        rename_string = rename_string.Replace("?", "")
        rename_string = rename_string.Replace(":", "")
        rename_string = rename_string.Replace("*", "")
        rename_string = rename_string.Replace("<", "")
        rename_string = rename_string.Replace(">", "")
        rename_string = rename_string.Replace("|", "")

        If folder_to <> "" Then
            folder_to = folder_to & "\" & rename_string
            If Not Directory.Exists(folder_to) Then Directory.CreateDirectory(folder_to)

            If Directory.Exists(folder_to) Then
                Dim photographs = GetFilesFromPath(folder_from, folder_from_abs)
                Dim file_types_index = -1
                Dim founded = False
                Dim file_types_0(99) As TipoFile

                For y = 0 To photographs.Length - 1
                    founded = False

                    If Not file_types_0 Is Nothing Then
                        If file_types_0.Length > 0 Then
                            For z = 0 To file_types_0.Length - 1
                                If Path.GetExtension(photographs(y)) = file_types_0(z).Tipo Then
                                    founded = True
                                    Exit For
                                End If
                            Next
                        End If
                    End If

                    If founded = False Then
                        file_types_index += 1
                        file_types_0(file_types_index) = New TipoFile(Path.GetExtension(photographs(y)))
                    End If
                Next

                Dim file_types_1(file_types_index) As TipoFile
                Array.Copy(file_types_0, file_types_1, file_types_index + 1)

                If photographs.Length > 0 Then
                    Dim copy_difference, copy_source, copy_destination As String

                    ProgressBar1.Visible = True
                    ProgressBar1.Maximum = photographs.Length

                    If MsgBox("Vuoi copiare " & photographs.Length & " files (i files già esistenti verrano saltati)?", vbQuestion Or vbYesNo) = MsgBoxResult.Yes Then
                        Array.Sort(photographs)

                        Dim cartellaDestPred = ""

                        For photo_index = 0 To photographs.Length - 1
                            copy_source = photographs(photo_index)
                            copy_difference = copy_source.Replace(folder_from_abs, "")
                            If copy_difference(0) = "\" Then copy_difference = copy_difference.Remove(0, 1)

                            If rename_string = "" Then
                                copy_destination = Path.Combine(folder_to, copy_difference)
                            Else
                                copy_destination = folder_to & "\" & rename_string & " (" & GetNumberByType(file_types_1, Path.GetExtension(copy_source)) & ")" & Path.GetExtension(copy_source)
                            End If

                            Dim cartellaDest = Path.GetDirectoryName(copy_destination)

                            If Not cartellaDestPred.Equals(cartellaDest) Then
                                If Not Directory.Exists(cartellaDest) Then
                                    Directory.CreateDirectory(cartellaDest)
                                End If
                            End If

                            Dim thread As New Threading.Thread(Sub() FileCopyD(copy_source, copy_destination))
                            thread.Start()
                            thread.Join()

                            ProgressBar1.Value = photo_index + 1
                        Next

                        ok = True
                    End If
                End If
            End If
        End If

        If ok Then
            MsgBox("Finito !", vbInformation)

            Process.Start(folder_to)

            Spegni()
        Else
            Enabled = True
            MsgBox("Errore: " & error_text, vbExclamation)
        End If
    End Sub

    Private Sub PreSpegni()
        Opzioni = New sOpzioni(eFrom.Text, eTo.Text)
    End Sub

    Private Sub Spegni()
        PreSpegni()
        Close()
    End Sub

    Private Function GetNumberByType(ByRef Array_() As TipoFile, ByVal Type_ As String) As Integer
        Dim i = 0

        If Not Array_ Is Nothing Then
            If Array_.Length > 0 Then
                For y = 0 To Array_.Length - 1
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

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
        PreSpegni()
    End Sub

    Public Function DateToStringWithUnderSpace(ByVal dd As Date) As String
        Dim d = dd.Day
        Dim m = dd.Month
        Dim y = dd.Year

        If dd.Day < 10 Then d = "0" & d
        If dd.Month < 10 Then m = "0" & m

        Dim s = y & "_" & m & "_" & d

        Return s
    End Function

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Dim o = Opzioni

        eRename.Text = DateToStringWithUnderSpace(Now) & "_"
        eRename.SelectionStart = 0
        eRename.SelectionLength = 0

        If Directory.Exists(o.To_) Then eTo.Text = o.To_
        If Directory.Exists(o.From_) Then eFrom.Text = o.From_
    End Sub

    Private Sub FileCopyD(da As String, a As String)
        If Not File.Exists(a) Then
            If File.Exists(da) Then
                File.Copy(da, a, False)
            Else
                Dim dp = getDevice(da)

                If dp.device Is Nothing Then Throw New Exception("Errore il file " & da & " non esiste!")

                dp.device.DownloadFile(da, a)
            End If
        End If
    End Sub

    Private Function GetFilesFromPath(devPath As String, ByRef devPathAbs As String) As String()
        If Directory.Exists(devPath) Then
            Return Directory.GetFiles(devPath, "*", SearchOption.AllDirectories)
        Else
            MioDevice = getDevice(devPath)

            If MioDevice.device Is Nothing Then
                Return New String() {}
            Else
                MioDevice.device.Connect()

                Dim di = MioDevice.device.GetDirectoryInfo(MioDevice.percorso)
                Dim fi = di.EnumerateFiles("*", SearchOption.AllDirectories)
                Dim files = New List(Of String)

                For Each f In fi
                    files.Add(f.FullName)
                Next

                devPathAbs = di.FullName

                Return files.ToArray()
            End If
        End If
    End Function

    Private Function getDevice(devPath As String) As DevicePath
        If MioDevice.device Is Nothing Then
            Dim s = ""
            Dim percorsi = devPath.Split(New Char() {"\"})
            Dim devices = MediaDevice.GetDevices()

            For i = 0 To percorsi.Length - 1
                For Each d In devices
                    If d.FriendlyName = percorsi(i) Then
                        For x = i + 1 To percorsi.Length - 1
                            s = Path.Combine(s, percorsi(x))
                        Next

                        Return New DevicePath() With {
                            .device = d,
                            .percorso = s
                        }
                    End If
                Next
            Next

            Return New DevicePath() With {
                .device = Nothing,
                .percorso = ""
            }
        Else
            Return MioDevice
        End If
    End Function

    Private Sub CopiaDaDevice(devPath As String)
        Dim devices = MediaDevice.GetDevices()

        For Each d In devices
            If d.FriendlyName = devPath Then
                Using d
                    d.Connect()
                    d.DownloadFolder("", eTo.Text, True)
                    d.Disconnect()
                End Using

                Exit For
            End If
        Next
    End Sub

    Private Sub cbRinomina_CheckedChanged(sender As Object, e As EventArgs) Handles cbRinomina.CheckedChanged
        eRename.Enabled = cbRinomina.Checked
    End Sub

End Class