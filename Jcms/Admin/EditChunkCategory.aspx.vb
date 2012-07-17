Imports JertCMSUsers
Imports JertCMSFunctions
Imports Resources
Imports Jertix.Functions
Imports System.Data.OleDb

Partial Class Admin_EditChunkCategory
    Inherits System.Web.UI.Page

    Dim myMasterPage As Admin_MasterPage
    Dim myLogin As New JertCMSUsers.JertCMSUsers
    Dim jCMS As New JertCMSFunctions.JertCMSFunctions

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not myLogin.isLogged Then Response.Redirect("~/Admin/Login.aspx", False)
        jCMS.InitPage()
        InitPage()

        LoadLabels()

        If Not Page.IsPostBack Then
            jCMS.LoadListChunksCategories(DropDownListChunkCategories)

            If Request.QueryString("id") Is Nothing Then

            Else
                DropDownListChunkCategories.SelectedIndex = DropDownListChunkCategories.Items.IndexOf(DropDownListChunkCategories.Items.FindByValue(Request.QueryString("id")))
                DropDownListChunkCategories.SelectedValue = Request.QueryString("id")
                DropDownListChunkCategories_SelectedIndexChanged(sender, e)
            End If

        Else

        End If
    End Sub

    Private Sub InitPage()
        myMasterPage = CType(Me.Master, Admin_MasterPage)
        myMasterPage.PageTitle.Text = Admin.litH1EditChunkCategory
    End Sub

    Private Sub LoadLabels()
        litDescriptionEditChunkCategory.Text = Admin.litDescriptionEditChunkCategory

        litSelCategory.Text = Admin.litSelCategoriaChunk
        imglitSelCategories.Text = jCMS.CreateImgTooltip(litSelCategory.Text, Admin.litHelpMessaggioCategorieChunk)

        btnSalvaModificheTemplate.Text = Admin.btnSalvaModificheTemplate
        litEditTemplateName.Text = Admin.litEditChunkCategoryName

        imglitCategoryName.Text = jCMS.CreateImgTooltip(litEditTemplateName.Text, Admin.litHelpMessaggioCategorieChunkEdit)

    End Sub

    Protected Sub btnSalvaModificheTemplate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalvaModificheTemplate.Click

        Dim idCategoria As Long = DropDownListChunkCategories.SelectedValue

        Dim NomeCategoria As String = ""
        NomeCategoria = txtCategoryName.Text.Trim

        If idCategoria = -1 Then
            myMasterPage.cmsMessagges.Text = jCMS.PrintWarning(Admin.messWarningSelezionaCategoria)
        Else
            If NomeCategoria.Length > 0 Then
                If jCMS.ChunkCategoriaExist(NomeCategoria, idCategoria) Then
                    'Se il nome è uguale non faccio niente..
                    myMasterPage.cmsMessagges.Text = jCMS.PrintOK(Admin.messChunkCategoriaEsistente)
                Else
                    jCMS.EditCategoriaChunk(idCategoria, NomeCategoria)
                    myMasterPage.cmsMessagges.Text = jCMS.PrintOK(Admin.messChunkCategoriaModificata)
                    jCMS.LoadListCategorieChunks(DropDownListChunkCategories)

                    Dim tmpDbCommand As New OleDbCommand : Dim tmpDbConnection As New OleDbConnection : myMasterPage.WriteWebSiteTree(tmpDbCommand, tmpDbConnection)
                End If
            Else
                myMasterPage.cmsMessagges.Text = jCMS.PrintWarning(Admin.messWarningInserireCategoria)
            End If
        End If

    End Sub

    Protected Sub DropDownListChunkCategories_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListChunkCategories.SelectedIndexChanged
        If DropDownListChunkCategories.SelectedIndex > 0 Then
            txtCategoryName.Text = DropDownListChunkCategories.SelectedItem.Text
        End If
    End Sub
End Class
