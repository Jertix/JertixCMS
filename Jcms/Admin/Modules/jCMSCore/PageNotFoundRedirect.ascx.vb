Partial Class Admin_Modules_jCMSCore_PageNotFoundRedirect
    Inherits System.Web.UI.UserControl

    Dim jCMS As New JertCMSFunctions.JertCMSFunctions

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        jCMS.InitPage()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim RedirectPath As String = ConfigurationManager.AppSettings("jCMSRedirectPathPageNotFound")

        Dim ThisPage As String = "http://" & HttpContext.Current.Session("SiteName") & (Page.TemplateSourceDirectory & "/").Replace("//", "/") & IIf(Page.ClientQueryString.Length > 0, "?" & Page.ClientQueryString, "")

        'Dim tmpMessage As String = ""
        'tmpMessage &= "<br />File: /Admin/Modules/jCMSCore/PageNotFoundRedirect.ascx.vb"
        'tmpMessage &= "<br />Function: Page_Load()"
        'tmpMessage &= "<br />Param: "
        'tmpMessage &= "<br /><br />Error: Page not found - " & ThisPage
        'Dim jCommerceFunctions As New jCommerce.DBFunctions
        'jCommerceFunctions.SendDebugEmail(tmpMessage)

        If String.IsNullOrEmpty(RedirectPath) Then
            RedirectPath = "~"
        Else
            RedirectPath = RedirectPath.Replace("%sitename%", HttpContext.Current.Session("SiteName"))
        End If

        If ThisPage <> RedirectPath Then
            Response.Redirect(RedirectPath)
        End If
    End Sub
End Class
