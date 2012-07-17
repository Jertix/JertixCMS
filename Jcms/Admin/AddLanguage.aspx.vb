Imports JertCMSUsers
Imports JertCMSFunctions
Imports Resources
Imports Jertix.Functions
Imports System.Data.OleDb

Partial Class Admin_AddLanguage
    Inherits System.Web.UI.Page

    Dim myMasterPage As Admin_MasterPage
    Dim myLogin As New JertCMSUsers.JertCMSUsers
    Dim jCMS As New JertCMSFunctions.JertCMSFunctions

    Dim myDir As New DirectoryManipulation

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not myLogin.isLogged Then Response.Redirect("~/Admin/Login.aspx", False)
        jCMS.InitPage()
        InitPage()

        LoadLabels()

        If Not Page.IsPostBack Then
            jCMS.LoadListLingue(DropDownListLingue)

            Try
                DropDownListLingue.SelectedIndex = DropDownListLingue.Items.IndexOf(DropDownListLingue.Items.FindByValue(Request.QueryString("CurrentMenuID")))
            Catch ex As Exception
                DropDownListLingue.SelectedIndex = 0
            End Try
        End If
    End Sub

    Private Sub InitPage()
        myMasterPage = CType(Me.Master, Admin_MasterPage)
        myMasterPage.PageTitle.Text = Admin.litH1AddLanguage
    End Sub

    Private Sub LoadLabels()
        litSelLingua.Text = Admin.litSelLingua
        imgHelpMessaggioLingue.Text = jCMS.CreateImgTooltip(litSelLingua.Text, Admin.litHelpMessaggioLingue)

        litDescriptionAddLanguage.Text = Admin.litDescriptionAddLanguage
        btnAggiungiLingua.Text = Admin.btnAggiungiLingua
        btnRimuoviLingua.Text = Admin.btnRimuoviLingua
    End Sub

    Protected Sub btnAggiungiLingua_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAggiungiLingua.Click
        If myDir.DirectoryExist(jCMS.Paths.PathPublic & DropDownListLingue.SelectedValue & "\", True) Then
            myMasterPage.cmsMessagges.Text = jCMS.PrintWarning(Admin.warningLinguaEsiste & " > " & DropDownListLingue.SelectedItem.Text)
        Else
            jCMS.AddNewLanguageTree(DropDownListLingue.SelectedValue)
            Dim tmpDbCommand As New OleDbCommand : Dim tmpDbConnection As New OleDbConnection : myMasterPage.WriteWebSiteTree(tmpDbCommand, tmpDbConnection)
            myMasterPage.cmsMessagges.Text = jCMS.PrintOK(Admin.okLinguaAggiunta)
        End If
    End Sub

    Protected Sub btnRimuoviLingua_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRimuoviLingua.Click
        If myDir.DirectoryExist(jCMS.Paths.PathPublic & DropDownListLingue.SelectedValue & "\", True) Then
            jCMS.RemoveLanguageTree(DropDownListLingue.SelectedValue)
            Dim tmpDbCommand As New OleDbCommand : Dim tmpDbConnection As New OleDbConnection : myMasterPage.WriteWebSiteTree(tmpDbCommand, tmpDbConnection)
            myMasterPage.cmsMessagges.Text = jCMS.PrintOK(Admin.okLinguaRimossa)
        Else
            myMasterPage.cmsMessagges.Text = jCMS.PrintWarning(Admin.warningLinguaNonEsiste)
        End If
    End Sub
End Class
