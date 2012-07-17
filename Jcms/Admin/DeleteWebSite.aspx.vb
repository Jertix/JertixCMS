Imports JertCMSUsers
Imports JertCMSFunctions
Imports Resources
Imports Jertix.Functions
Imports Jertix.Cache

Partial Class Admin_DeleteWebSite
    Inherits System.Web.UI.Page

    Dim myLogin As New JertCMSUsers.JertCMSUsers
    Dim jCMS As New JertCMSFunctions.JertCMSFunctions

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not myLogin.isLogged Then Response.Redirect("~/Admin/Login.aspx", False)
        jCMS.InitPage()

    End Sub

    Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        litMess.Text = jCMS.DeleteWebSite(chkDeletePublicFolder.Checked, chkDeleteChunks.Checked, chkDeleteModules.Checked, chkDeleteTemplates.Checked)
        myLogin.LogOut()
    End Sub
End Class
