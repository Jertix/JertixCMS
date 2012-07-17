Imports JertCMSUsers
Imports JertCMSFunctions
Imports Resources
Imports Jertix.Functions

Partial Class Admin_FileBrowser
    Inherits System.Web.UI.Page

    Dim myLogin As New JertCMSUsers.JertCMSUsers
    Dim jCMS As New JertCMSFunctions.JertCMSFunctions

    Dim myDir As New DirectoryManipulation
    Dim myFile As New FileManipulation

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not myLogin.isLogged Then Response.Redirect("~/Admin/Login.aspx", False)
        jCMS.InitPage()
        InitPage()

        LoadLabels()

        If Not Page.IsPostBack Then
            myDir.BuildSpecialFoldersTree(jCMS)

            WriteFilesTree()
        End If
    End Sub

    Private Sub InitPage()

    End Sub

    Private Sub LoadLabels()
        litFolders.Text = FileBrowser.folders
        litUploadfile.Text = FileBrowser.uploadfile
    End Sub

    Private Sub WriteFilesTree()
        Dim tmpDirectory As _cms_DirectoryInfo
        Dim idToStart As Long = 0

        Dim ServerPath As String = HttpContext.Current.Server.MapPath("~")

        litJsHeader.Text = "<script type=""text/javascript"">$(document).ready(function () {"

        tmpDirectory = jCMS.JertCMS_WritePublicFilesTree(idToStart, jCMS.Paths.PathPublic & jCMS.Paths.PathFiles, jCMS.Paths.PathFiles.Replace("_cms_", "").Replace("\", ""), ServerPath)

        litFiles.Text &= tmpDirectory.TreeStructure
        litJsHeader.Text &= tmpDirectory.jQueryString
        litContextMenu.Text &= tmpDirectory.ContextMenu
        idToStart = tmpDirectory.LastIDULIndex

        '    litVideo.Text = jCMS.JertCMS_WritePublicFilesTree(jCMS.Paths.PathPublic & jCMS.Paths.PathVideos, jCMS.Paths.PathVideos.Replace("_cms_", "").Replace("\", ""))
        '    litImmagini.Text = jCMS.JertCMS_WritePublicFilesTree(jCMS.Paths.PathPublic & jCMS.Paths.PathImagesPages, jCMS.Paths.PathImagesPages.Replace("_cms_", "").Replace("\", ""))
        '

        tmpDirectory = jCMS.JertCMS_WritePublicFilesTree(idToStart, jCMS.Paths.PathPublic & jCMS.Paths.PathImagesPages, jCMS.Paths.PathImagesPages.Replace("_cms_", "").Replace("\", ""), ServerPath)

        litImmagini.Text &= tmpDirectory.TreeStructure
        litJsHeader.Text &= tmpDirectory.jQueryString
        litContextMenu.Text &= tmpDirectory.ContextMenu
        idToStart = tmpDirectory.LastIDULIndex


        tmpDirectory = jCMS.JertCMS_WritePublicFilesTree(idToStart, jCMS.Paths.PathPublic & jCMS.Paths.PathVideos, jCMS.Paths.PathVideos.Replace("_cms_", "").Replace("\", ""), ServerPath)

        litVideo.Text &= tmpDirectory.TreeStructure
        litJsHeader.Text &= tmpDirectory.jQueryString
        litContextMenu.Text &= tmpDirectory.ContextMenu
        idToStart = tmpDirectory.LastIDULIndex

        litJsHeader.Text &= "});</script>"

    End Sub

End Class
