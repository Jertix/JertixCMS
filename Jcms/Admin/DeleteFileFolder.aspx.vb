Imports JertCMSUsers
Imports JertCMSFunctions
Imports Resources
Imports Jertix.Functions

Partial Class Admin_DeleteFileFolder
    Inherits System.Web.UI.Page

    Dim myLogin As New JertCMSUsers.JertCMSUsers
    Dim jCMS As New JertCMSFunctions.JertCMSFunctions

    Dim myDir As New DirectoryManipulation
    Dim myFile As New FileManipulation

    Dim Menu As _cms_MenuQueryStrings
    Dim Param As _cms_MenuParameters
    Dim QueryMenu As _cms_MenuQueryStrings
    Dim FolderPath As String

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
                    litDescriptionDeleteFolder.Text &= " <strong>" & myDir.CleanPublicFolderPath(jCMS.Paths, FolderPath) & "</strong>" & "?"
                Else
                    litErrMess.Text = FileBrowser.litErrMessPathNonValido
                    FolderPath = ""
                End If
            End If
        Else
            FolderPath = Request.QueryString("FolderPath")

            If myDir.PublicFolderPathIsValid(jCMS.Paths, FolderPath) Then
                litDescriptionDeleteFolder.Text &= " <strong>" & myDir.CleanPublicFolderPath(jCMS.Paths, FolderPath) & "</strong>" & "?"
            Else
                litErrMess.Text = FileBrowser.litErrMessPathNonValido
                FolderPath = ""
            End If
        End If
    End Sub

    Private Sub LoadLabels()
        litDescriptionDeleteFolder.Text = FileBrowser.litDescriptionDeleteFolder

        'litFolderName
        'imgFolderName
        'txtFolderName

        btnDeleteFolderYes.Text = FileBrowser.btnDeleteFolderYes
        btnDeleteFolderNo.Text = FileBrowser.btnDeleteFolderNo

        'litDescrizioneBreveMenu.Text = Admin.litDescrizioneBreveMenu
        'imgDescrizioneBreveMenu.Text = jCMS.CreateImgTooltip(litDescrizioneBreveMenu.Text, Admin.litHelpMessaggioDescrizioneVoceDiMenu)
    End Sub

    Protected Sub btnDeleteFolderYes_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDeleteFolderYes.Click
        myDir.DeleteDirectory(FolderPath, True, True)
        Response.Redirect("~/Admin/FileBrowser.aspx", False)
    End Sub

    Protected Sub btnDeleteFolderNo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDeleteFolderNo.Click
        Response.Redirect("~/Admin/FileBrowser.aspx", False)
    End Sub
End Class