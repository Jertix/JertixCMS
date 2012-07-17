Imports JertCMSUsers
Imports JertCMSFunctions
Imports Resources
Imports Jertix.Functions
Imports System.Data.OleDb

Partial Class Admin_DeleteChunkCategory
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
        myMasterPage.PageTitle.Text = Admin.litH1DeleteChunkCategory
    End Sub

    Private Sub LoadLabels()
        litDescriptionDeleteChunkCategory.Text = Admin.litDescriptionDeleteChunkCategory

        litSelCategory.Text = Admin.litSelCategoriaChunk
        imglitSelCategories.Text = jCMS.CreateImgTooltip(litSelCategory.Text, Admin.litHelpMessaggioCategorieChunk)

        btnEliminaCategoria.Text = Admin.btnEliminaCategoria
    End Sub

    Protected Sub btnEliminaCategoria_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEliminaCategoria.Click

        Dim idCategoria As Long = DropDownListChunkCategories.SelectedValue

        If idCategoria = -1 Then
            myMasterPage.cmsMessagges.Text = jCMS.PrintWarning(Admin.messWarningSelezionaCategoria)
        Else
            jCMS.DeleteChunkCategory(idCategoria)

            jCMS.LoadListCategorieChunks(DropDownListChunkCategories)
            Dim tmpDbCommand As New OleDbCommand : Dim tmpDbConnection As New OleDbConnection : myMasterPage.WriteWebSiteTree(tmpDbCommand, tmpDbConnection)

            myMasterPage.cmsMessagges.Text = jCMS.PrintOK(Admin.messChunkCategoryDeleted)
        End If

    End Sub

    Protected Sub DropDownListChunkCategories_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListChunkCategories.SelectedIndexChanged
        If DropDownListChunkCategories.SelectedIndex > 0 Then

        End If
    End Sub
End Class

