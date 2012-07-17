Imports JertCMSUsers
Imports JertCMSFunctions
Imports Resources
Imports Jertix.Functions

Partial Class Admin_DeleteTemplate
    Inherits System.Web.UI.Page

    Dim myLogin As New JertCMSUsers.JertCMSUsers
    Dim jCMS As New JertCMSFunctions.JertCMSFunctions
    Dim myMasterPage As Admin_MasterPage

    Dim idTemplate As Long

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not myLogin.isLogged Then Response.Redirect("~/Admin/Login.aspx", False)
        jCMS.InitPage()
        InitPage()

        LoadLabels()

        If Not Page.IsPostBack Then
            Session("idTemplate") = Request.QueryString("id")
            idTemplate = Session("idTemplate")

            jCMS.LoadListTemplates(DropDownListTemplates)

            If Request.QueryString("id") Is Nothing Then

            Else
                DropDownListTemplates.SelectedIndex = DropDownListTemplates.Items.IndexOf(DropDownListTemplates.Items.FindByValue(Request.QueryString("id")))
                DropDownListTemplates.SelectedValue = Request.QueryString("id")
                DropDownListTemplates_SelectedIndexChanged(sender, e)
            End If

        Else
            idTemplate = Session("idTemplate")
        End If
    End Sub

    Private Sub InitPage()
        myMasterPage = CType(Me.Master, Admin_MasterPage)
        myMasterPage.PageTitle.Text = Admin.litH1DeleteTemplate
    End Sub

    Private Sub LoadLabels()
        litDescriptionDeleteTemplate.Text = Admin.litDescriptionDeleteTemplate

        litSelTemplate.Text = Admin.litSelTemplate
        imglitTemplates.Text = jCMS.CreateImgTooltip(litSelTemplate.Text, Admin.litHelpMessaggioDeleteTemplate)

        btnEliminaTemplate.Text = Admin.btnEliminaTemplate
    End Sub

    Protected Sub btnEliminaTemplate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEliminaTemplate.Click
        If DropDownListTemplates.SelectedValue > -1 Then
            jCMS.DeleteTemplate(DropDownListTemplates.SelectedValue)
            jCMS.LoadListTemplates(DropDownListTemplates)
            myMasterPage.cmsMessagges.Text = jCMS.PrintOK(Admin.messTemplateEliminato)
        Else
            myMasterPage.cmsMessagges.Text = jCMS.PrintWarning(Admin.messErroreTemplateDaEliminareNonSelezionato)
        End If
    End Sub

    Protected Sub DropDownListTemplates_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListTemplates.SelectedIndexChanged
        If DropDownListTemplates.SelectedIndex > 0 Then

        End If
    End Sub

End Class
