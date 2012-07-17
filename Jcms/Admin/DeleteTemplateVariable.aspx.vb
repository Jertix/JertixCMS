Imports JertCMSUsers
Imports JertCMSFunctions
Imports Resources
Imports Jertix.Functions
Imports System.Data.OleDb

Partial Class Admin_DeleteTemplateVariable
    Inherits System.Web.UI.Page

    Dim myMasterPage As Admin_MasterPage
    Dim myLogin As New JertCMSUsers.JertCMSUsers
    Dim jCMS As New JertCMSFunctions.JertCMSFunctions

    Dim idTVCategory As Long

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not myLogin.isLogged Then Response.Redirect("~/Admin/Login.aspx", False)
        jCMS.InitPage()
        InitPage()

        LoadLabels()

        If Not Page.IsPostBack Then
            Session("idTVCategory") = Request.QueryString("category")
            idTVCategory = Session("idTVCategory")

            jCMS.LoadListTVs(DropDownListTVs, idTVCategory)

            If Request.QueryString("id") Is Nothing Then

            Else
                DropDownListTVs.SelectedIndex = DropDownListTVs.Items.IndexOf(DropDownListTVs.Items.FindByValue(Request.QueryString("id")))
                DropDownListTVs.SelectedValue = Request.QueryString("id")
                DropDownListTVs_SelectedIndexChanged(sender, e)
            End If

        Else
            idTVCategory = Session("idTVCategory")
        End If
    End Sub

    Private Sub InitPage()
        myMasterPage = CType(Me.Master, Admin_MasterPage)
        myMasterPage.PageTitle.Text = Admin.litH1DeleteTV
    End Sub

    Private Sub LoadLabels()
        litDescriptionDeleteTV.Text = Admin.litDescriptionDeleteTV

        litSelectTV.Text = Admin.litSelectTV
        imglitSelTV.Text = jCMS.CreateImgTooltip(litSelectTV.Text, Admin.litHelpMessaggioTVDelete)

        btnEliminaTV.Text = Admin.btnEliminaTV
    End Sub

    Protected Sub btnEliminaTV_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEliminaTV.Click

        Dim idTV As Long = DropDownListTVs.SelectedValue

        If idTV = -1 Then
            myMasterPage.cmsMessagges.Text = jCMS.PrintWarning(Admin.messWarningSelezionaTV)
        Else
            jCMS.DeleteTV(idTV)

            jCMS.LoadListTVs(DropDownListTVs, idTVCategory)
            Dim tmpDbCommand As New OleDbCommand : Dim tmpDbConnection As New OleDbConnection : myMasterPage.WriteWebSiteTree(tmpDbCommand, tmpDbConnection)

            myMasterPage.cmsMessagges.Text = jCMS.PrintOK(Admin.messTVDeleted)
        End If

    End Sub

    Protected Sub DropDownListTVs_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListTVs.SelectedIndexChanged
        If DropDownListTVs.SelectedIndex > 0 Then

        End If
    End Sub
End Class