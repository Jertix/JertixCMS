Imports JertCMSUsers
Imports JertCMSFunctions
Imports Resources
Imports Jertix.Functions

Partial Class Admin_MoveFileFolder
    Inherits System.Web.UI.Page

    Dim myLogin As New JertCMSUsers.JertCMSUsers
    Dim jCMS As New JertCMSFunctions.JertCMSFunctions

    Dim myDir As New DirectoryManipulation
    Dim myFile As New FileManipulation

    Dim Menu As _cms_MenuQueryStrings
    Dim Param As _cms_MenuParameters
    Dim QueryMenu As _cms_MenuQueryStrings
    Dim FolderPath As String
    Dim FromPath As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not myLogin.isLogged Then Response.Redirect("~/Admin/Login.aspx", False)

        jCMS.InitPage()

        LoadLabels()

        If Not Page.IsPostBack Then
            If Request.QueryString("FolderPath") Is Nothing Then
                litErrMess.Text = FileBrowser.litErrMessCartellaNonImpostata
                FolderPath = ""
            Else
                FolderPath = Request.QueryString("FolderPath")

                If myDir.PublicFolderPathIsValid(jCMS.Paths, FolderPath) Then
                    litDescriptionMoveFolder.Text &= " <strong>" & myDir.CleanPublicFolderPath(jCMS.Paths, FolderPath) & "</strong>" & "?"
                    If FolderPath.StartsWith("\") Then FolderPath = FolderPath.Substring(1)
                    FromPath = FolderPath
                    WriteFileTree()
                Else
                    litErrMess.Text = FileBrowser.litErrMessPathNonValido
                    FolderPath = ""
                End If
            End If
        Else
            ' btnMoveFolderYes.Enabled = False

            FolderPath = Request.QueryString("FolderPath")

            If myDir.PublicFolderPathIsValid(jCMS.Paths, FolderPath) Then
                litDescriptionMoveFolder.Text &= " <strong>" & myDir.CleanPublicFolderPath(jCMS.Paths, FolderPath) & "</strong>" & "?"
                If FolderPath.StartsWith("\") Then FolderPath = FolderPath.Substring(1)
                FromPath = FolderPath
            Else
                litErrMess.Text = FileBrowser.litErrMessPathNonValido
                FolderPath = ""
            End If
        End If
    End Sub

    Private Sub LoadLabels()
        litDescriptionMoveFolder.Text = FileBrowser.litDescriptionMoveFolder
        litSelezionaDestinazione.Text = FileBrowser.litSelezionaDestinazione

        'litFolderName
        'imgFolderName
        'txtFolderName

        btnMoveFolderYes.Text = FileBrowser.btnMoveFolderYes
        btnMoveFolderNo.Text = FileBrowser.btnMoveFolderNo

        'litDescrizioneBreveMenu.Text = Admin.litDescrizioneBreveMenu
        'imgDescrizioneBreveMenu.Text = jCMS.CreateImgTooltip(litDescrizioneBreveMenu.Text, Admin.litHelpMessaggioDescrizioneVoceDiMenu)
    End Sub

    Protected Sub btnMoveFolderYes_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnMoveFolderYes.Click
        Dim ServerPath As String = HttpContext.Current.Server.MapPath("~")

        If listFileFoldersTree.SelectedItem Is Nothing Then
            litErrMess.Text = "Nessuna destinazione selezionata..."

            btnMoveFolderYes.Enabled = False
            Exit Sub
        End If

        Dim link1 As String = ServerPath & FromPath.TrimEnd("\")
        Dim link2 As String = listFileFoldersTree.SelectedItem.Value.TrimEnd("\")

        If link1 = link2 Then
            litErrMess.Text = "Origine è destinazione coincidono.. impossibile spostare.."

            btnMoveFolderYes.Enabled = False
        Else
            myDir.MoveDirectory(ServerPath & FromPath, listFileFoldersTree.SelectedItem.Value, jCMS.Paths, False)
            Response.Redirect("~/Admin/FileBrowser.aspx", False)
        End If
    End Sub

    Protected Sub btnMoveFolderNo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnMoveFolderNo.Click
        Response.Redirect("~/Admin/FileBrowser.aspx", False)
    End Sub

    Private Sub WriteFileTree()
        Dim ServerPath As String = HttpContext.Current.Server.MapPath("~")
        jCMS.JertCMS_LoadPublicFilesTree(listFileFoldersTree, 1, jCMS.Paths.PathPublic & jCMS.Paths.PathFiles, jCMS.Paths.PathFiles.Replace("_cms_", "").Replace("\", ""), ServerPath, 0)
        jCMS.JertCMS_LoadPublicFilesTree(listFileFoldersTree, 1, jCMS.Paths.PathPublic & jCMS.Paths.PathImagesPages, jCMS.Paths.PathImagesPages.Replace("_cms_", "").Replace("\", ""), ServerPath, 0)
        jCMS.JertCMS_LoadPublicFilesTree(listFileFoldersTree, 1, jCMS.Paths.PathPublic & jCMS.Paths.PathVideos, jCMS.Paths.PathVideos.Replace("_cms_", "").Replace("\", ""), ServerPath, 0)
    End Sub

    Protected Sub listFileFoldersTree_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles listFileFoldersTree.SelectedIndexChanged
        Dim ServerPath As String = HttpContext.Current.Server.MapPath("~")
        'litErrMess.Text = "Originale: " & ServerPath & FromPath & "<br />"
        'litErrMess.Text &= "Selezionato: " & listFileFoldersTree.SelectedItem.Value

        Dim link1 As String = ServerPath & FromPath.TrimEnd("\")
        Dim link2 As String = listFileFoldersTree.SelectedItem.Value.TrimEnd("\")

        If link1 = link2 Then
            litErrMess.Text = "Selezionare una cartella di destinazione..."
            btnMoveFolderYes.Enabled = False
        Else
            btnMoveFolderYes.Enabled = True
            litErrMess.Text = "Originale: " & myDir.CleanPublicFolderPath(jCMS.Paths, "\" & FolderPath) & "<br />"
            litErrMess.Text &= "Destinazione: " & myDir.CleanPublicFolderPath(jCMS.Paths, "\" & listFileFoldersTree.SelectedItem.Value.Replace(ServerPath, ""))
        End If
    End Sub
End Class