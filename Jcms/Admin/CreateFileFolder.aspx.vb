Imports JertCMSUsers
Imports JertCMSFunctions
Imports Resources
Imports Jertix.Functions

Partial Class Admin_CreateFileFolder
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
                    litDescriptionAddFolder.Text &= " <strong>" & myDir.CleanPublicFolderPath(jCMS.Paths, FolderPath) & "</strong>"
                Else
                    litErrMess.Text = FileBrowser.litErrMessPathNonValido
                    FolderPath = ""
                End If
            End If
        Else
            FolderPath = Request.QueryString("FolderPath")

            If myDir.PublicFolderPathIsValid(jCMS.Paths, FolderPath) Then
                litDescriptionAddFolder.Text &= " <strong>" & myDir.CleanPublicFolderPath(jCMS.Paths, FolderPath) & "</strong>"
            Else
                litErrMess.Text = FileBrowser.litErrMessPathNonValido
                FolderPath = ""
            End If
        End If
    End Sub

    Private Sub LoadLabels()
        litDescriptionAddFolder.Text = FileBrowser.litDescriptionAddFolder

        litFolderName.Text = FileBrowser.litFolderName
        'litFolderName
        'imgFolderName
        'txtFolderName

        btnSalvaNuovaCartella.Text = FileBrowser.btnSalvaNuovaCartella
        btnAnnulla.Text = FileBrowser.btnAnnulla

        'litDescrizioneBreveMenu.Text = Admin.litDescrizioneBreveMenu
        'imgDescrizioneBreveMenu.Text = jCMS.CreateImgTooltip(litDescrizioneBreveMenu.Text, Admin.litHelpMessaggioDescrizioneVoceDiMenu)
    End Sub

    Protected Sub btnSalvaNuovaCartella_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalvaNuovaCartella.Click
        If txtFolderName.Text.Trim.Length > 0 Then
            Dim FolderName As String = myFile.FilterFileName(txtFolderName.Text.Trim)

            myDir.CreateDirectory(FolderPath & FolderName, True)

            Response.Redirect("~/Admin/FileBrowser.aspx", False)
        Else
            litErrMess.Text = FileBrowser.litErrMessNomeCartellaAssente
        End If
    End Sub

    Protected Sub btnAnnulla_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAnnulla.Click
        Response.Redirect("~/Admin/FileBrowser.aspx", False)
    End Sub
End Class
