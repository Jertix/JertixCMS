Imports JertCMSUsers
Imports JertCMSFunctions
Imports Resources
Imports Jertix.Functions
Imports System.Data.OleDb

Partial Class Admin_AddTVCategory
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
            jCMS.LoadListCategorieTemplateVariable(DropDownListTVCategories)

            If Request.QueryString("id") Is Nothing Then

            Else
                DropDownListTVCategories.SelectedIndex = DropDownListTVCategories.Items.IndexOf(DropDownListTVCategories.Items.FindByValue(Request.QueryString("id")))
                DropDownListTVCategories.SelectedValue = Request.QueryString("id")
                DropDownListTVCategories_SelectedIndexChanged(sender, e)
            End If

        Else

        End If
    End Sub

    Private Sub InitPage()
        myMasterPage = CType(Me.Master, Admin_MasterPage)
        myMasterPage.PageTitle.Text = Admin.litH1AddTVCategory
    End Sub

    Private Sub LoadLabels()
        litDescriptionAddTVCategory.Text = Admin.litDescriptionAddChunkCategory

        litExistingCategoriesTV.Text = Admin.litExistingCategoriesTV
        imglitExistingCategoriesTV.Text = jCMS.CreateImgTooltip(litExistingCategoriesTV.Text, Admin.litHelpMessaggioCategorieTVEsistenti)

        btnAddNewTVCategory.Text = Admin.btnAddNewTVCategory
        litAddTVCategoryName.Text = Admin.litAddTVCategoryName

        imglitTVCategoryName.Text = jCMS.CreateImgTooltip(litAddTVCategoryName.Text, Admin.litHelpMessaggioCategorieTVAdd)

    End Sub

    Protected Sub btnAddNewTVCategory_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddNewTVCategory.Click

        Dim idCategoria As Long = DropDownListTVCategories.SelectedValue

        Dim NomeCategoria As String = ""
        NomeCategoria = txtCategoryName.Text.Trim

        If NomeCategoria.Length > 0 Then
            If jCMS.TemplateVariableCategoriaExist(NomeCategoria) Then
                myMasterPage.cmsMessagges.Text = jCMS.PrintWarning(Admin.messWarningCategoriaEsistente)
            Else
                jCMS.AddNewCategoriaTemplateVariable(NomeCategoria)
                myMasterPage.cmsMessagges.Text = jCMS.PrintOK(Admin.messChunkCategoriaAggiunta)
                jCMS.LoadListCategorieTemplateVariable(DropDownListTVCategories)

                Dim tmpDbCommand As New OleDbCommand : Dim tmpDbConnection As New OleDbConnection : myMasterPage.WriteWebSiteTree(tmpDbCommand, tmpDbConnection)
            End If
        Else
            myMasterPage.cmsMessagges.Text = jCMS.PrintWarning(Admin.messWarningInserireCategoria)
        End If

    End Sub

    Protected Sub DropDownListTVCategories_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListTVCategories.SelectedIndexChanged
        If DropDownListTVCategories.SelectedIndex > 0 Then
            txtCategoryName.Text = DropDownListTVCategories.SelectedItem.Text
        End If
    End Sub
End Class
