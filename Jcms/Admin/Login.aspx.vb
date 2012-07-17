Imports JertCMSUsers
Imports JertCMSFunctions
Imports Resources
Imports Jertix.Functions

Partial Class Admin_Login
    Inherits System.Web.UI.Page

    Dim jCookie As New JertCMSCookies
    Dim myLogin As JertCMSUsers.JertCMSUsers
    Dim jCMS As New JertCMSFunctions.JertCMSFunctions
    Dim myDir As New DirectoryManipulation

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        jCMS.InitPage()
        LoadLabels()

        myLogin = New JertCMSUsers.JertCMSUsers

        If Not Page.IsPostBack Then
            SetCookies()

            lblMessaggio.Visible = False
        End If
    End Sub

    Private Sub SetCookies()
        With jCookie
            If .ReadCookie("remember") = "1" Then
                checkbox.Checked = True

                txtUserName.Text = .ReadCookie("user")
                txtPassword.Text = .ReadCookie("pass")
            End If
        End With
    End Sub

    Private Sub LoadLabels()
        litcmsVersion.Text = " v" & jCMS.cmsSettings.JertixCMSVersion.ToString.Replace(",", ".") & "." & jCMS.cmsSettings.JertixCMSBuild & " .Net " & jCMS.cmsSettings.DotNETFrameworkVersion

        litNomeSito.Text = Admin.strLogin & " <a href=""http://" & Session("SiteName") & """ target=""_blank"">" & Session("SiteName") & "</a>"

        btnLogin.Text = Admin.btnLogin
        lnkPasswordDimenticata.Text = Admin.lnkPassDimenticata

        litUserName.Text = Admin.strUserName
        imglitUserName.Text = jCMS.CreateImgTooltip(litUserName.Text, Admin.litHelpMessaggioUserName)

        litPassword.Text = Admin.strPassword
        imglitPassword.Text = jCMS.CreateImgTooltip(litUserName.Text, Admin.litHelpMessaggioPassword)

        checkbox.Text = Admin.checkbox

        litRichiediSupporto.Text = Admin.litRichiediSupporto
        litYear.Text = Year(Now)
        litTuttiIDiritti.Text = Admin.litTuttiIDiritti
    End Sub

    Private Sub SaveCookies()
        With jCookie
            If checkbox.Checked Then
                .SaveCookie("remember", "1")
                .SaveCookie("user", txtUserName.Text.Trim)
                .SaveCookie("pass", txtPassword.Text.Trim)
            Else
                .DeleteCookie("remember")
                .DeleteCookie("user")
                .DeleteCookie("pass")
            End If
        End With
    End Sub

    Protected Sub btnLogin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        Dim AlternativeLoginConnectionString As String = ConfigurationManager.AppSettings("AlternativeLoginConnectionString")
        Dim AlternativeUsersTable As String = ConfigurationManager.AppSettings("AlternativeUsersTable")
        Dim AlternativeidUserName As String = ConfigurationManager.AppSettings("AlternativeidUserName")
        Dim AlternativeUserFieldName As String = ConfigurationManager.AppSettings("AlternativeUserFieldName")
        Dim AlternativeUserPasswordName As String = ConfigurationManager.AppSettings("AlternativeUserPasswordName")
        Dim AlternativeRedirectUrl As String = ConfigurationManager.AppSettings("AlternativeRedirectUrl")

        If myLogin.Login(txtUserName.Text, txtPassword.Text, AlternativeLoginConnectionString, AlternativeUsersTable, AlternativeUserFieldName, AlternativeUserPasswordName, AlternativeidUserName) Then
            SaveCookies()

            Dim tmpUserID As Long = HttpContext.Current.Session("idUser")

            If HttpContext.Current.Session("idRole") = myLogin.UserLevels.L3_BackOfficeUser Then
                Dim redirectURL As String
                redirectURL = myLogin.getRedirectURL(tmpUserID, myLogin.GetDefaultModuleID(tmpUserID))

                If Not IsNothing(redirectURL) And Not IsNothing(AlternativeRedirectUrl) Then
                    If redirectURL.Length = 0 And AlternativeRedirectUrl.Length > 0 Then
                        redirectURL = AlternativeRedirectUrl
                    End If
                End If

                If redirectURL.Length > 0 Then
                    Response.Redirect(redirectURL, False)
                Else
                    Response.Redirect("~/Admin/", False)
                End If
            Else
                Response.Redirect("~/Admin/", False)
            End If

        Else
            lblMessaggio.Visible = True
            lblMessaggio.Text = jCMS.PrintError(Admin.lblMessaggio)
        End If
    End Sub
End Class
