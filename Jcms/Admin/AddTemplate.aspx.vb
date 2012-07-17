Imports JertCMSUsers
Imports JertCMSFunctions
Imports Resources
Imports Jertix.Functions
Imports System.Data.OleDb

Partial Class Admin_AddTemplate
    Inherits System.Web.UI.Page

    Dim myMasterPage As Admin_MasterPage
    Dim myLogin As New JertCMSUsers.JertCMSUsers
    Dim jCMS As New JertCMSFunctions.JertCMSFunctions
    Dim jRegEx As New Jertix.Functions.RegExClass
    Dim jCMSCommands As JertCMSCommands.JertCMSCommands

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not myLogin.isLogged Then Response.Redirect("~/Admin/Login.aspx", False)
        jCMS.InitPage()

        jCMSCommands = New JertCMSCommands.JertCMSCommands

        InitPage()

        LoadLabels()

        If Not Page.IsPostBack Then
            jCMS.LoadListTemplates(DropDownListTemplates)
        End If
    End Sub

    Private Sub InitPage()
        myMasterPage = CType(Me.Master, Admin_MasterPage)

        myMasterPage.Tabs.Text = jCMS.GenerateHTMLTabasList(Admin.tabsTemplate)

        myMasterPage.PageTitle.Text = Admin.litH1AddTemplate

        myMasterPage.EditAreaText = "<script language=""Javascript"" type=""text/javascript"" src=""edit_area/edit_area_full.js""></script>" & vbCrLf
        myMasterPage.EditAreaText &= jCMS.CreateEditAreaJavascript(txtTemplate.ClientID)

        myMasterPage.cmsjQueryVariousScripts.Text = jCMS.CreateDragSortjQuery("UpdateTVOrder.aspx", ".dash1", "div", ".dash1 li", "id", "<li class='placeHolder'><div></div></li>")
    End Sub

    Private Sub LoadLabels()
        litDescriptionAddTemplate.Text = Admin.litDescriptionAddTemplate

        litImportTemplate.Text = Admin.litImportTemplate
        imglitImportTemplate.Text = jCMS.CreateImgTooltip(litImportTemplate.Text, Admin.litHelpMessaggioTemplate)

        litTemplateName.Text = Admin.litTemplateName
        imglitTemplateName.Text = jCMS.CreateImgTooltip(litTemplateName.Text, Admin.litHelpMessaggioTitoloTemplate)

        litTextTemplate.Text = Admin.litTextTemplate
        imgTextTemplate.Text = jCMS.CreateImgTooltip(litTextTemplate.Text, Admin.litHelpMessaggioTestoTemplate)

        btnSalvaNuovoTemplate.Text = Admin.btnSalvaNuovoTemplate
        litTextTemplate.Text = Admin.litTextTemplate
    End Sub

    Protected Sub btnSalvaNuovoTemplate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalvaNuovoTemplate.Click
        If jCMS.TemplateNameExist(txtTemplateName.Text) = False Then
            If txtTemplateName.Text.Trim.Length > 0 Then

                Dim tmpTemplate As _cmsTemplate
                tmpTemplate = jRegEx.SeparateTemplateHTML(txtTemplate.Text)

                With tmpTemplate
                    jCMS.SaveTemplate(txtTemplateName.Text, .Content, .Header, .BodyTagOpen, .BodyTagClose & .Footer)
                End With

                jCMS.LoadListTemplates(DropDownListTemplates)
                myMasterPage.cmsMessagges.Text = jCMS.PrintOK(Admin.messTemplateSalvato)
                Dim tmpDbCommand As New OleDbCommand : Dim tmpDbConnection As New OleDbConnection : myMasterPage.WriteWebSiteTree(tmpDbCommand, tmpDbConnection)
            Else
                myMasterPage.cmsMessagges.Text = jCMS.PrintWarning(Admin.messErroreTemplateNullo)
            End If
        Else
            myMasterPage.cmsMessagges.Text = jCMS.PrintWarning(Admin.messErroreTemplate)
        End If
    End Sub

    Protected Sub DropDownListTemplates_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListTemplates.SelectedIndexChanged
        If DropDownListTemplates.SelectedIndex > 0 Then
            txtTemplateName.Text = Admin.CopiaDi & DropDownListTemplates.SelectedItem.Text

            Dim tmpTemplate As _cmsTemplate
            tmpTemplate = jCMS.GetTemplateFromID(DropDownListTemplates.SelectedValue)

            txtTemplate.Text = tmpTemplate.Header
            txtTemplate.Text &= tmpTemplate.BodyTagOpen
            txtTemplate.Text &= tmpTemplate.Content
            txtTemplate.Text &= tmpTemplate.BodyTagClose 'AND FOOTER

            litLiTVList.Text = jCMS.CreateLiTVList(DropDownListTemplates.SelectedValue)
        End If
    End Sub
End Class
