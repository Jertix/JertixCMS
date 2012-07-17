Imports JertCMSUsers
Imports JertCMSFunctions
Imports Resources
Imports Jertix.Functions
Imports System.Data.OleDb

Partial Class Admin_EditTemplate
    Inherits System.Web.UI.Page

    Dim myMasterPage As Admin_MasterPage
    Dim myLogin As New JertCMSUsers.JertCMSUsers
    Dim jCMS As New JertCMSFunctions.JertCMSFunctions
    Dim jRegEx As New Jertix.Functions.RegExClass
    Dim jCMSCommands As JertCMSCommands.JertCMSCommands

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not myLogin.isLogged Then Response.Redirect("~/Admin/Login.aspx", False)
        jCMS.InitPage()
        InitPage()

        jCMSCommands = New JertCMSCommands.JertCMSCommands

        LoadLabels()

        If Not Page.IsPostBack Then
            jCMSCommands.LoadListCommandTypes(DropDownListCommandType)
            jCMS.LoadListTemplates(DropDownListTemplates)

            If Request.QueryString("id") Is Nothing Then

            Else
                DropDownListTemplates.SelectedIndex = DropDownListTemplates.Items.IndexOf(DropDownListTemplates.Items.FindByValue(Request.QueryString("id")))
                DropDownListTemplates.SelectedValue = Request.QueryString("id")
                DropDownListTemplates_SelectedIndexChanged(sender, e)
            End If

        Else

        End If
    End Sub

    Private Sub InitPage()
        myMasterPage = CType(Me.Master, Admin_MasterPage)

        myMasterPage.Tabs.Text = jCMS.GenerateHTMLTabasList(Admin.tabsTemplate)

        myMasterPage.PageTitle.Text = Admin.litH1EditTemplate

        myMasterPage.EditAreaText = "<script language=""Javascript"" type=""text/javascript"" src=""edit_area/edit_area_full.js""></script>" & vbCrLf
        myMasterPage.EditAreaText &= jCMS.CreateEditAreaJavascript(txtTemplate.ClientID)

        myMasterPage.cmsjQueryVariousScripts.Text = jCMS.CreateDragSortjQuery("UpdateTVOrder.aspx", ".dash1", "div", ".dash1 li", "id", "<li class='placeHolder'><div></div></li>")
    End Sub

    Private Sub LoadLabels()
        litDescriptionEditTemplate.Text = Admin.litDescriptionEditTemplate
        litSelTemplate.Text = Admin.litSelTemplate
        imgEditTemplate.Text = jCMS.CreateImgTooltip(litSelTemplate.Text, Admin.litHelpMessaggioEditTemplate)

        litTextTemplate.Text = Admin.litTextTemplate
        imgTextTemplate.Text = jCMS.CreateImgTooltip(litTextTemplate.Text, Admin.litHelpMessaggioTestoTemplate)

        btnSalvaModificheTemplate.Text = Admin.btnSalvaModificheTemplate
        litTextTemplate.Text = Admin.litTextTemplate
        litEditTemplateName.Text = Admin.litEditTemplateName
        imgEditTitoloTemplate.Text = jCMS.CreateImgTooltip(litEditTemplateName.Text, Admin.litHelpMessaggioEditTitoloTemplate)

        litCommand.Text = Admin.litCommand
        imglitCommand.Text = jCMS.CreateImgTooltip(litCommand.Text, Admin.litHelpMessaggioComandiCMS)
    End Sub

    Protected Sub btnSalvaModificheTemplate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalvaModificheTemplate.Click
        If DropDownListTemplates.SelectedValue > -1 Then
            If jCMS.TemplateNameExist(txtTemplateName.Text) = False Then
                If txtTemplateName.Text.Trim.Length > 0 Then

                    Dim tmpTemplate As _cmsTemplate
                    tmpTemplate = jRegEx.SeparateTemplateHTML(txtTemplate.Text)

                    With tmpTemplate
                        jCMS.EditTemplate(DropDownListTemplates.SelectedValue, txtTemplateName.Text, .Content, .Header, .BodyTagOpen, .BodyTagClose & .Footer)
                    End With

                    jCMS.LoadListTemplates(DropDownListTemplates)
                    myMasterPage.cmsMessagges.Text = jCMS.PrintOK(Admin.messTemplateAggiornato)
                    Dim tmpDbCommand As New OleDbCommand : Dim tmpDbConnection As New OleDbConnection : myMasterPage.WriteWebSiteTree(tmpDbCommand, tmpDbConnection)
                    DropDownListTemplates.SelectedIndex = DropDownListTemplates.Items.IndexOf(DropDownListTemplates.Items.FindByValue(Request.QueryString("id")))
                    DropDownListTemplates.SelectedValue = Request.QueryString("id")
                    DropDownListTemplates_SelectedIndexChanged(sender, e)
                Else
                    myMasterPage.cmsMessagges.Text = jCMS.PrintWarning(Admin.messErroreTemplateNullo)
                End If
            Else
                If txtTemplateName.Text.Trim.Length > 0 Then
                    If jCMS.GetIDTemplate(txtTemplateName.Text) = DropDownListTemplates.SelectedValue Then

                        Dim tmpTemplate As _cmsTemplate
                        tmpTemplate = jRegEx.SeparateTemplateHTML(txtTemplate.Text)

                        With tmpTemplate
                            jCMS.EditTemplate(DropDownListTemplates.SelectedValue, txtTemplateName.Text, .Content, .Header, .BodyTagOpen, .BodyTagClose & .Footer)
                        End With

                        jCMS.LoadListTemplates(DropDownListTemplates)
                        myMasterPage.cmsMessagges.Text = jCMS.PrintOK(Admin.messTemplateAggiornato)
                        Dim tmpDbCommand As New OleDbCommand : Dim tmpDbConnection As New OleDbConnection : myMasterPage.WriteWebSiteTree(tmpDbCommand, tmpDbConnection)
                        DropDownListTemplates.SelectedIndex = DropDownListTemplates.Items.IndexOf(DropDownListTemplates.Items.FindByValue(Request.QueryString("id")))
                        DropDownListTemplates.SelectedValue = Request.QueryString("id")
                        DropDownListTemplates_SelectedIndexChanged(sender, e)
                    Else
                        myMasterPage.cmsMessagges.Text = jCMS.PrintWarning(Admin.messErroreTemplateEsistente)
                    End If
                Else
                    myMasterPage.cmsMessagges.Text = jCMS.PrintWarning(Admin.messErroreTemplateNullo)
                End If
            End If
        Else
            myMasterPage.cmsMessagges.Text = jCMS.PrintWarning(Admin.messErroreTemplateNonSelezionato)
        End If
    End Sub

    Protected Sub DropDownListTemplates_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListTemplates.SelectedIndexChanged
        If DropDownListTemplates.SelectedIndex > 0 Then
            txtTemplateName.Text = DropDownListTemplates.SelectedItem.Text

            Dim tmpTemplate As _cmsTemplate
            tmpTemplate = jCMS.GetTemplateFromID(DropDownListTemplates.SelectedValue)

            txtTemplate.Text = tmpTemplate.Header
            txtTemplate.Text &= tmpTemplate.BodyTagOpen
            txtTemplate.Text &= tmpTemplate.Content
            txtTemplate.Text &= tmpTemplate.BodyTagClose 'AND FOOTER

            litLiTVList.Text = jCMS.CreateLiTVList(DropDownListTemplates.SelectedValue)

            DropDownListCommandType_SelectedIndexChanged(sender, e)
        End If
    End Sub

    Protected Sub DropDownListCommandType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListCommandType.SelectedIndexChanged
        If DropDownListCommandType.SelectedIndex > 0 Then
            jCMSCommands.LoadListElements(DropDownListElements, DropDownListCommandType.SelectedValue, DropDownListTemplates.SelectedValue)

            DropDownListElements_SelectedIndexChanged(sender, e)
        End If
    End Sub


    Protected Sub DropDownListElements_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListElements.SelectedIndexChanged
        If DropDownListElements.SelectedIndex > 0 Then
            txtCommand.Text = DropDownListElements.SelectedItem.Text
        End If
    End Sub
End Class
