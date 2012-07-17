Imports JertCMSUsers
Imports JertCMSFunctions
Imports Resources
Imports Jertix.Functions
Imports Jertix.Cache

Partial Class Admin_DeleteCache
    Inherits System.Web.UI.Page

    Dim myLogin As New JertCMSUsers.JertCMSUsers
    Dim jCMS As New JertCMSFunctions.JertCMSFunctions

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not myLogin.isLogged Then Response.Redirect("~/Admin/Login.aspx", False)
        jCMS.InitPage()
        InitPage()

        LoadLabels()

        DeleteAllCache()
    End Sub

    Private Sub InitPage()

    End Sub

    Private Sub LoadLabels()

    End Sub

    Private Sub DeleteAllCache()
        Dim pageCache As New Jertix.Cache.JertCMSCache

        result.Text = pageCache.DeleteAllPageCache(True)

    End Sub

End Class
