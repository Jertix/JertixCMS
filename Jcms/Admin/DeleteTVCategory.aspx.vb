Imports JertCMSUsers
Imports JertCMSFunctions
Imports Resources
Imports Jertix.Functions
Imports System.Data.OleDb

Partial Class Admin_DeleteTVCategory
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
        myMasterPage.PageTitle.Text = Admin.litH1DeleteTVCategory
    End Sub

    Private Sub LoadLabels()
        litDescriptionDeleteTVCategory.Text = Admin.litDescriptionDeleteTVCategory

        litSelTVCategory.Text = Admin.litSelTVCategory
        imglitSelTVCategories.Text = jCMS.CreateImgTooltip(litSelTVCategory.Text, Admin.litHelpMessaggioCategorieTV)

        btnEliminaCategoriaTV.Text = Admin.btnEliminaCategoria
    End Sub

    Protected Sub btnEliminaCategoriaTV_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEliminaCategoriaTV.Click

        Dim idCategoria As Long = DropDownListTVCategories.SelectedValue

        If idCategoria = -1 Then
            myMasterPage.cmsMessagges.Text = jCMS.PrintWarning(Admin.messWarningSelezionaCategoria)
        Else
            jCMS.DeleteTVCategory(idCategoria)

            jCMS.LoadListCategorieTemplateVariable(DropDownListTVCategories)
            Dim tmpDbCommand As New OleDbCommand : Dim tmpDbConnection As New OleDbConnection : myMasterPage.WriteWebSiteTree(tmpDbCommand, tmpDbConnection)

            myMasterPage.cmsMessagges.Text = jCMS.PrintOK(Admin.messTVCategoryDeleted)
        End If

    End Sub

    Protected Sub DropDownListTVCategories_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListTVCategories.SelectedIndexChanged
        If DropDownListTVCategories.SelectedIndex > 0 Then

        End If
    End Sub
End Class


