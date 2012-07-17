Imports Microsoft.VisualBasic
Imports Jertix.Functions
Imports JertCMSFunctions
Imports System.Xml
Imports System.Data.OleDb

Namespace Jertix.Cache

    Public Structure _cms_Cache
        Dim PageHeader As String
        Dim PageBodyOpen As String
        Dim ContentPage As String
        Dim PageBodyClose As String

        Dim _WarningMessagge As String
    End Structure


    Public Class JertCMSCache

        Dim jCMS As New JertCMSFunctions.JertCMSFunctions
        Dim cmsPage As _cmsPage
        Dim PageCache As _cms_Cache
        Dim cmsPaths As _cms_Paths

        Dim db As New DBFunctions

        Dim myDir As New DirectoryManipulation
        Dim myFile As New FileManipulation

        Public Function CreatePageCache(ByVal MenuID As Long) As Boolean
            Dim retValue As Boolean = False

            Dim tmpMenu As _cmsVoceDiMenu
            tmpMenu = jCMS.GetVoceMenuFromFolderPath(jCMS.GetFolderPathFromIdVoce(MenuID).Replace("/", "\"))
            cmsPage = jCMS.JertCMS_ReadAllPage(tmpMenu, True)

            With cmsPage
                PageCache.PageHeader = .HTMLCompletoHeadPagina
                PageCache.PageBodyOpen = .HTMLBodyOpen
                PageCache.ContentPage = .HTMLCompletoPagina
                PageCache.PageBodyClose = .HTMLBodyClose


                If Not IsNothing(._CMS_Warning) AndAlso ._CMS_Warning.Length > 0 Then
                    PageCache._WarningMessagge = ._CMS_Warning & " <br /><br />Time: " & jCMS.PageInfo.m_Date
                    PageCache._WarningMessagge &= "<br /><br />*************************************** PAGE ***************************************<br />" & .HTMLFullPage.Replace("<", "&lt;").Replace(">", "&gt;").Replace(vbCrLf, "<br/>")
                Else
                    PageCache._WarningMessagge = ""
                End If
            End With

            cmsPaths = jCMS.Paths

            Dim DirectoryPath As String = cmsPaths.PathPublic & cmsPaths.PathCache
            Dim FilePath As String = DirectoryPath & MenuID & ".xml"

            If myDir.DirectoryExist(DirectoryPath, True) = False Then myDir.CreateDirectory(DirectoryPath, True)
            If myFile.FileExists(FilePath) Then myFile.DeleteFile(FilePath)

            Dim XMLCachePage As New JertCMSXMLClass(HttpContext.Current.Server.MapPath(FilePath))
            With XMLCachePage
                .WriteStartDocument("Page")
                .WriteAttributeString("MenuId", MenuID)

                .WriteStartElement("PageHeader")
                .WriteElementString("Value", PageCache.PageHeader)
                .WriteEndElement()

                .WriteStartElement("PageBodyOpen")
                .WriteElementString("Value", PageCache.PageBodyOpen)
                .WriteEndElement()

                .WriteStartElement("ContentPage")
                .WriteElementString("Value", PageCache.ContentPage)
                .WriteEndElement()

                .WriteStartElement("PageBodyClose")
                .WriteElementString("Value", PageCache.PageBodyClose)
                .WriteEndElement()

                .WriteStartElement("_WarningMessagge")
                .WriteElementString("Value", PageCache._WarningMessagge)
                .WriteEndElement()

                .WriteEndDocument()
            End With

            Return retValue
        End Function

        Public Function CreateAllPageCache(ByVal ReturnOutput As Boolean) As String
            Dim retValue As String = ""

            Dim tmpDbCommand As New OleDbCommand
            Dim tmpDbConnection As New OleDbConnection
            Dim tmpReader As OleDbDataReader

            db.OpenConn("SELECT idVoce From Menu", , , True, tmpDbConnection, tmpDbCommand)
            tmpReader = db.ExecuteReader(True, tmpDbCommand)

            Dim StartTime As Integer = Environment.TickCount

            While tmpReader.Read
                CreatePageCache(tmpReader("idVoce"))
            End While

            Dim EndTime As Integer = Environment.TickCount
            Dim ExecutionTime As Double = Convert.ToDouble((EndTime - StartTime)) / 1000.0

            tmpReader.Close()
            db.CloseConn(True, tmpDbConnection)

            If ReturnOutput Then retValue = "Page execution time: " & ExecutionTime & " seconds"
            Return retValue
        End Function

        Public Function DeleteAllPageCache(ByVal ReturnOutput As Boolean) As String
            Dim retValue As String = ""

            Dim tmpDbCommand As New OleDbCommand
            Dim tmpDbConnection As New OleDbConnection
            Dim tmpReader As OleDbDataReader

            db.OpenConn("SELECT idVoce From Menu", , , True, tmpDbConnection, tmpDbCommand)
            tmpReader = db.ExecuteReader(True, tmpDbCommand)

            Dim StartTime As Integer = Environment.TickCount

            cmsPaths = jCMS.Paths
            Dim DirectoryPath As String = cmsPaths.PathPublic & cmsPaths.PathCache
            Dim FilePath As String

            While tmpReader.Read
                FilePath = DirectoryPath & tmpReader("idVoce") & ".xml"
                myFile.DeleteFile(FilePath)
            End While

            Dim EndTime As Integer = Environment.TickCount
            Dim ExecutionTime As Double = Convert.ToDouble((EndTime - StartTime)) / 1000.0

            tmpReader.Close()
            db.CloseConn(True, tmpDbConnection)

            If ReturnOutput Then retValue = "All cache files deleted in: " & ExecutionTime & " seconds"
            Return retValue
        End Function

        Public Function ReadCache(ByVal MenuID As Long) As _cmsPage
            Dim retValue As New _cmsPage
            retValue.CacheFound = False
            retValue._CMS_Warning = ""

            cmsPaths = jCMS.Paths

            Dim DirectoryPath As String = cmsPaths.PathPublic & cmsPaths.PathCache
            Dim FilePath As String = DirectoryPath & MenuID & ".xml"

            If myFile.FileExists(FilePath) Then
                retValue.CacheFound = True

                Dim path As String = HttpContext.Current.Server.MapPath(FilePath)
                Dim Doc As New XmlDocument()
                Doc.Load(path)
                Dim node As XmlNodeList = Doc.SelectNodes("//Page")

                For numElemento As Integer = 0 To node.Count - 1
                    For j As Integer = 0 To node(numElemento).ChildNodes.Count - 1

                        Dim NomeElemento As String = node(numElemento).ChildNodes(j).Name
                        Dim ValoreElemento As String = node(numElemento).ChildNodes(j).InnerText

                        Select Case NomeElemento
                            Case "PageHeader" : retValue.HTMLCompletoHeadPagina = ValoreElemento
                            Case "PageBodyOpen" : retValue.HTMLBodyOpen = ValoreElemento
                            Case "ContentPage" : retValue.HTMLCompletoPagina = ValoreElemento
                            Case "PageBodyClose" : retValue.HTMLBodyClose = ValoreElemento

                            Case "_WarningMessagge" : retValue._CMS_Warning = ValoreElemento
                        End Select
                    Next
                Next
            End If

            Return retValue
        End Function

    End Class
End Namespace

