Imports JertCMSUsers
Imports JertCMSFunctions
Imports Resources
Imports Jertix.Functions
Imports System.Data.OleDb

Partial Class Admin_EditTVCategory
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
        myMasterPage.PageTitle.Text = Admin.litH1EditTVCategory
    End Sub

    Private Sub LoadLabels()
        litDescriptionEditTVCategory.Text = Admin.litDescriptionEditTVCategory

        litSelTVCategory.Text = Admin.litSelTVCategory
        imglitSelCategoriesTV.Text = jCMS.CreateImgTooltip(litSelTVCategory.Text, Admin.litHelpMessaggioCategorieTV)

        btnSalvaModificheTVCategory.Text = Admin.btnSalvaModificheTVCategory
        litEditTVCategoryName.Text = Admin.litEditTVCategoryName

        imglitCategoryName.Text = jCMS.CreateImgTooltip(litEditTVCategoryName.Text, Admin.litHelpMessaggioCategorieTVEdit)

    End Sub

    Protected Sub btnSalvaModificheTVCategory_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalvaModificheTVCategory.Click

        Dim idCategoria As Long = DropDownListTVCategories.SelectedValue

        Dim NomeCategoria As String = ""
        NomeCategoria = txtCategoryName.Text.Trim

        If idCategoria = -1 Then
            myMasterPage.cmsMessagges.Text = jCMS.PrintWarning(Admin.messWarningSelezionaCategoria)
        Else
            If NomeCategoria.Length > 0 Then
                If jCMS.TemplateVariableCategoriaExist(NomeCategoria, idCategoria) Then
                    myMasterPage.cmsMessagges.Text = jCMS.PrintWarning(Admin.messWarningCategoriaEsistente)
                Else
                    jCMS.EditCategoriaTV(idCategoria, NomeCategoria)
                    myMasterPage.cmsMessagges.Text = jCMS.PrintOK(Admin.messTVCategoriaModificata)
                    jCMS.LoadListCategorieTemplateVariable(DropDownListTVCategories)

                    Dim tmpDbCommand As New OleDbCommand : Dim tmpDbConnection As New OleDbConnection : myMasterPage.WriteWebSiteTree(tmpDbCommand, tmpDbConnection)
                End If
            Else
                myMasterPage.cmsMessagges.Text = jCMS.PrintWarning(Admin.messWarningInserireCategoria)
            End If
        End If

    End Sub

    Protected Sub DropDownListTVCategories_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListTVCategories.SelectedIndexChanged
        If DropDownListTVCategories.SelectedIndex > 0 Then
            txtCategoryName.Text = DropDownListTVCategories.SelectedItem.Text
        End If
    End Sub
End Class
