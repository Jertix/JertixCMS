Imports Microsoft.VisualBasic
Imports System.IO
Imports System.Web
Imports System
Imports System.Reflection
Imports System.Collections.Generic

Namespace Jertix.Functions

    Public Structure _cms_DirectoryInfo
        Dim jQueryString As String
        Dim FolderName As String
        Dim ContextMenu As String
        Dim LastIDULIndex As Long
        Dim TreeStructure As String
    End Structure

    Public Class DirectoryManipulation

        Public Function GetSubDirectories(ByVal virtualFolderPath As String, Optional ByVal UseRootPath As Boolean = False) As ArrayList
            Dim arrayList As New ArrayList

            Dim rootPathFolder As String
            If UseRootPath = True Then
                rootPathFolder = "~\"
            Else
                rootPathFolder = ""
            End If

            Dim FolderPath As String
            FolderPath = HttpContext.Current.Server.MapPath(rootPathFolder) & virtualFolderPath

            Dim myDirInfo As New DirectoryInfo(FolderPath)

            Dim myDir As DirectoryInfo
            Try
                For Each myDir In myDirInfo.GetDirectories
                    arrayList.Add(myDir)
                Next
            Catch ex As Exception
            End Try

            Return arrayList
        End Function

        Public Function GetFileListFromDirectoryPath(ByVal virtualFolderPath As String, Optional ByVal UseRootPath As Boolean = False, Optional ByVal SearchPatternsCommaSeparated As String = "*.*") As List(Of FileInfo)
            Dim arrayFileList As New List(Of FileInfo)

            Dim arrSearchPatterns() As String = SearchPatternsCommaSeparated.Split(";")

            Dim rootPathFolder As String
            If UseRootPath = True Then
                rootPathFolder = "~\"
            Else
                rootPathFolder = ""
            End If

            Dim FolderPath As String
            FolderPath = HttpContext.Current.Server.MapPath(rootPathFolder) & virtualFolderPath

            Dim myDirInfo As New DirectoryInfo(FolderPath)

            Dim File As FileInfo
            Try
                For i As Integer = 0 To arrSearchPatterns.GetUpperBound(0)
                    For Each File In myDirInfo.GetFiles(arrSearchPatterns(i))
                        arrayFileList.Add(File)
                    Next
                Next
            Catch ex As Exception
            End Try

            Return arrayFileList
        End Function

        Public Function CreateDirectory(ByVal virtualFolderPath As String, Optional ByVal UseRootPath As Boolean = False) As Boolean

            Dim rootPathFolder As String
            If UseRootPath = True Then
                rootPathFolder = "~\"
            Else
                rootPathFolder = ""
            End If

            Dim FolderPath As String
            FolderPath = HttpContext.Current.Server.MapPath(rootPathFolder) & virtualFolderPath

            Try
                If Directory.Exists(FolderPath) Then
                    Return False
                End If

                Dim di As DirectoryInfo = Directory.CreateDirectory(FolderPath)
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Function DirectoryExist(ByVal virtualFolderPath As String, Optional ByVal UseRootPath As Boolean = False) As Boolean

            Dim rootPathFolder As String
            If UseRootPath = True Then
                rootPathFolder = "~\"
            Else
                rootPathFolder = ""
            End If

            Dim FolderPath As String
            FolderPath = HttpContext.Current.Server.MapPath(rootPathFolder) & virtualFolderPath

            If Directory.Exists(FolderPath) Then
                Return True
            Else
                Return False
            End If
        End Function

        Public Function DeleteDirectory(ByVal virtualFolderPath As String, Optional ByVal UseRootPath As Boolean = False, Optional ByVal Recursive As Boolean = False) As Boolean

            Dim rootPathFolder As String
            If UseRootPath = True Then
                rootPathFolder = "~\"
            Else
                rootPathFolder = ""
            End If

            Dim FolderPath As String
            FolderPath = HttpContext.Current.Server.MapPath(rootPathFolder) & virtualFolderPath
            FolderPath = FolderPath.Replace("\\", "\")

            Try
                If Directory.Exists(FolderPath) = False Then
                    Return False
                End If

                'Questa riga elimina le variabili di sessione...
                StopFCNMonitoring()
                Directory.Delete(FolderPath, Recursive)

                'FileDelete(FolderPath)

                Return True
            Catch ex As System.Exception
                Return False
            End Try
        End Function

        Public Sub StopFCNMonitoring()
            Dim mess As String = ""

            'Touching the web.config or the bin still causes the application to restart.
            Dim p As PropertyInfo = GetType(System.Web.HttpRuntime).GetProperty("FileChangesMonitor", BindingFlags.NonPublic Or BindingFlags.[Public] Or BindingFlags.[Static])
            Dim o As Object = p.GetValue(Nothing, Nothing)
            Dim f As FieldInfo = o.[GetType]().GetField("_dirMonSubdirs", BindingFlags.Instance Or BindingFlags.NonPublic Or BindingFlags.IgnoreCase)
            Dim monitor As Object = f.GetValue(o)
            Dim m As MethodInfo = monitor.[GetType]().GetMethod("StopMonitoring", BindingFlags.Instance Or BindingFlags.NonPublic)
            m.Invoke(monitor, New Object() {})
        End Sub

        Private Sub FileDelete(ByVal Path As String)
            'TODO da aggiungere il parametro ricorsivo

            Dim st As String()
            st = Directory.GetFiles(Path)
            Dim i As Integer
            For i = 0 To st.Length - 1
                Try
                    File.Delete(st.GetValue(i).ToString())
                Catch
                End Try
            Next
        End Sub


        Public Function MoveDirectory(ByVal OriginalDirectoryName As String, ByVal DestinationDirectoryName As String, ByVal tmpjCMSPaths As JertCMSFunctions._cms_Paths, Optional ByVal isVirtualPath As Boolean = True) As Boolean
            Dim myDirOrigin As String
            Dim myDirDestin As String

            If isVirtualPath Then
                myDirOrigin = HttpContext.Current.Server.MapPath(OriginalDirectoryName.TrimEnd("\"))
                myDirDestin = HttpContext.Current.Server.MapPath(DestinationDirectoryName.TrimEnd("\"))
            Else
                myDirOrigin = OriginalDirectoryName.TrimEnd("\")
                myDirDestin = DestinationDirectoryName.TrimEnd("\")
            End If

            Dim ServerPath As String = HttpContext.Current.Server.MapPath("~")
            Dim DestinityFolder As String = ""

            If Not tmpjCMSPaths.PathPublic Is Nothing Then
                DestinityFolder = myDirOrigin.Substring(ServerPath.Length - 1)
                DestinityFolder = CleanPublicFolderPath(tmpjCMSPaths, DestinityFolder, False)
                If DestinityFolder.Contains("\") Then
                    DestinityFolder = DestinityFolder.Substring(1, DestinityFolder.IndexOf("\"))
                End If
                If Not DestinityFolder.StartsWith("\") Then DestinityFolder = "\" & DestinityFolder

                myDirDestin &= DestinityFolder
            End If

            If Directory.Exists(myDirOrigin) Then
                If Directory.Exists(myDirDestin) Then
                    Return False
                Else
                    StopFCNMonitoring()
                    Directory.Move(myDirOrigin, myDirDestin)
                    Return True
                End If
            Else
                Return False
            End If
        End Function

        Public Function FolderNameFromCurrentUrl(Optional ByVal GetSegmentNumber As Integer = -1) As String
            Dim segmentFolder() As String = HttpContext.Current.Request.Url.Segments

            If GetSegmentNumber = -1 Then
                Return segmentFolder(segmentFolder.Length - 2).Replace("/", "")
            Else
                If GetSegmentNumber > segmentFolder.Length Then
                    GetSegmentNumber = segmentFolder.Length
                End If
                Return segmentFolder(GetSegmentNumber).Replace("/", "")
            End If
        End Function

        Sub BuildSpecialFoldersTree(ByRef jcms As JertCMSFunctions.JertCMSFunctions)
            With jcms
                .CheckAndBuildFilesFolders()
            End With
        End Sub

        Public Function PublicFolderPathIsValid(ByVal tmpjCMSPaths As JertCMSFunctions._cms_Paths, ByVal FolderPath As String) As Boolean
            Dim retValue As Boolean = False

            If FolderPath.StartsWith(tmpjCMSPaths.PathPublic) Then retValue = True

            Return retValue
        End Function

        Public Function CleanPublicFolderPath(ByVal tmpjCMSPaths As JertCMSFunctions._cms_Paths, ByVal FolderPath As String, Optional ByVal ReplaceSpecialFolders As Boolean = True) As String
            Dim retValue As String = FolderPath
            With tmpjCMSPaths
                If FolderPath.StartsWith(.PathPublic & .PathFiles) Then
                    Dim tmpRoot As String = "\" & FolderPath.Substring(0, (.PathPublic & .PathFiles).Length).Replace(.PathPublic, "").Replace("_cms_", "").Replace("\", "") & "\"
                    Dim tmpResto As String = FolderPath.Substring((.PathPublic & .PathFiles).Length, FolderPath.Length - (.PathPublic & .PathFiles).Length)

                    If ReplaceSpecialFolders Then
                        retValue = tmpRoot & tmpResto
                    Else
                        retValue = tmpResto
                    End If
                End If

                If FolderPath.StartsWith(.PathPublic & .PathImagesPages) Then
                    Dim tmpRoot As String = "\" & FolderPath.Substring(0, (.PathPublic & .PathImagesPages).Length).Replace(.PathPublic, "").Replace("_cms_", "").Replace("\", "") & "\"
                    Dim tmpResto As String = FolderPath.Substring((.PathPublic & .PathImagesPages).Length, FolderPath.Length - (.PathPublic & .PathImagesPages).Length)

                    If ReplaceSpecialFolders Then
                        retValue = tmpRoot & tmpResto
                    Else
                        retValue = tmpResto
                    End If
                End If

                If FolderPath.StartsWith(.PathPublic & .PathVideos) Then
                    Dim tmpRoot As String = "\" & FolderPath.Substring(0, (.PathPublic & .PathVideos).Length).Replace(.PathPublic, "").Replace("_cms_", "").Replace("\", "") & "\"
                    Dim tmpResto As String = FolderPath.Substring((.PathPublic & .PathVideos).Length, FolderPath.Length - (.PathPublic & .PathVideos).Length)

                    If ReplaceSpecialFolders Then
                        retValue = tmpRoot & tmpResto
                    Else
                        retValue = tmpResto
                    End If
                End If

            End With


            Return retValue
        End Function

    End Class

    Public Class FileManipulation

        Public Function ReadTextFile(ByVal FileName As String) As String

            Try
                Dim sr As StreamReader
                sr = File.OpenText(HttpContext.Current.Server.MapPath(FileName))
                Dim strContents As String = sr.ReadToEnd()

                'Return strContents
                Return strContents.Replace(vbCrLf, "<br />")

                sr.Close()
            Catch ex As Exception
                Return "Error to read file: " & FileName
            End Try

        End Function

        Public Function ReadTextFileAtPosition(ByVal Filename As String, ByVal StartPosition As Integer, ByVal LenghtOfString As String) As String

            Try
                Dim fs As New System.IO.FileStream(HttpContext.Current.Server.MapPath(Filename), IO.FileMode.Open)
                Dim buffer(LenghtOfString) As Byte
                fs.Read(buffer, StartPosition, LenghtOfString)
                fs.Close()
                Dim filechars() As Char = System.Text.Encoding.ASCII.GetChars(buffer)
                Dim filestring As String = New String(filechars)
                Return filestring

            Catch ex As Exception
                Return ""
            End Try

        End Function

        Public Function FileExists(ByVal FileName As String, Optional ByVal isRelative As Boolean = True) As Boolean
            If isRelative Then
                If File.Exists(HttpContext.Current.Server.MapPath(FileName)) = True Then
                    Return True
                Else
                    Return False
                End If
            Else
                If File.Exists(FileName) = True Then
                    Return True
                Else
                    Return False
                End If
            End If
        End Function

        Public Function ReadHtmlFile(ByVal FileName As String) As String
            Dim FilePath As String = HttpContext.Current.Server.MapPath(FileName)
            Dim sr As StreamReader
            Dim fi As New FileInfo(FilePath)
            Dim Input As String = "<pre>"
            If File.Exists(FilePath) Then
                sr = File.OpenText(FilePath)
                Input += HttpContext.Current.Server.HtmlEncode(sr.ReadToEnd())
                sr.Close()
            End If
            Input += "</pre>"
            Return Input
        End Function

        Public Function CreateTextFile(ByVal FileName As String, ByVal ContentText As String) As Boolean
            Dim fp As StreamWriter
            Try
                fp = File.CreateText(HttpContext.Current.Server.MapPath(FileName))
                fp.WriteLine(ContentText)
                Return True
                fp.Close()
            Catch err As Exception
                Return False
            End Try
        End Function

        Public Function DeleteAllFilesInFolder(ByVal PathFolder As String) As Boolean
            PathFolder = HttpContext.Current.Server.MapPath("~\" & PathFolder)

            Dim Dire() As DirectoryInfo
            Dim file() As FileInfo
            Dim i As Integer
            If PathFolder <> "" Then
                Dim dir As New DirectoryInfo(PathFolder)
                Dire = dir.GetDirectories()
                file = dir.GetFiles()
                If Dire.Length > 0 Then
                    For i = 0 To Dire.Length - 1
                        Dire(i).Delete(True)
                    Next
                End If
                If file.Length > 0 Then
                    For i = 0 To file.Length - 1
                        file(i).Delete()
                    Next
                End If
                Return True
            Else
                Return False
            End If
        End Function


        Public Function DeleteFile(ByVal FileName As String, Optional ByVal isRelative As Boolean = True) As Boolean

            If isRelative Then
                Dim myFile As String = HttpContext.Current.Server.MapPath(FileName)

                If File.Exists(myFile) Then
                    File.Delete(myFile)
                    Return True
                Else
                    Return False
                End If
            Else
                If File.Exists(FileName) = True Then
                    File.Delete(FileName)
                    Return True
                Else
                    Return False
                End If
            End If

        End Function

        Public Function MoveFile(ByVal OriginalFileName As String, ByVal DestinationFileName As String) As Boolean

            Dim myFileOrigin As String = HttpContext.Current.Server.MapPath(OriginalFileName)
            Dim myFileDestin As String = HttpContext.Current.Server.MapPath(DestinationFileName)

            If File.Exists(myFileOrigin) Then
                If File.Exists(myFileDestin) Then
                    Return False
                Else
                    File.Move(myFileOrigin, myFileDestin)
                    Return True
                End If
            Else
                Return False
            End If
        End Function

        Public Function FilterFileName(ByVal FileName As String, Optional ByVal ReplaceSpaceWith As String = "") As String
            For i As Long = 0 To Path.GetInvalidFileNameChars.GetUpperBound(0)
                If FileName.IndexOf(Path.GetInvalidFileNameChars(i)) >= 0 Then
                    FileName = FileName.Replace(Path.GetInvalidFileNameChars(i), "")
                End If
            Next i

            If ReplaceSpaceWith.Length = 0 Then
                Return FileName
            Else
                Return FileName.Replace(" ", ReplaceSpaceWith)
            End If
        End Function

        Public Function CopyFile(ByVal OriginalFileName As String, ByVal DestinationFileName As String) As Boolean

            Dim myFileOrigin As String = HttpContext.Current.Server.MapPath(OriginalFileName)
            Dim myFileDestin As String = HttpContext.Current.Server.MapPath(DestinationFileName)

            If File.Exists(myFileOrigin) Then
                If File.Exists(myFileDestin) Then
                    Return False
                Else
                    File.Copy(myFileOrigin, myFileDestin)
                    Return True
                End If
            Else
                Return False
            End If
        End Function

    End Class

End Namespace
