Imports JertCMSUsers
Imports JertCMSFunctions
Imports Resources
Imports Jertix.Functions
Imports System.Data.OleDb

Partial Class Admin_EditTemplateVariable
    Inherits System.Web.UI.Page

    Dim myMasterPage As Admin_MasterPage
    Dim myLogin As New JertCMSUsers.JertCMSUsers
    Dim jCMS As New JertCMSFunctions.JertCMSFunctions

    Dim tmpTVVar As _cmsTVVariable

    Dim TemplateVariablesTypes As _cmsTemplateVariablesTypes

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not myLogin.isLogged Then Response.Redirect("~/Admin/Login.aspx", False)
        jCMS.InitPage()
        InitPage()

        LoadLabels()
        TemplateVariablesTypes = jCMS.TipiDiVariabiliTemplate

        jCMS.LoadChkTemplateList(panelElencoTemplate)

        If Not Page.IsPostBack Then
            jCMS.LoadListCategorieTemplateVariable(DropDownListCategorieTemplateVariable)

            If Request.QueryString("category") Is Nothing Then

            Else
                DropDownListCategorieTemplateVariable.SelectedIndex = DropDownListCategorieTemplateVariable.Items.IndexOf(DropDownListCategorieTemplateVariable.Items.FindByValue(Request.QueryString("category")))
                DropDownListCategorieTemplateVariable.SelectedValue = Request.QueryString("category")
                DropDownListCategorieTemplateVariable_SelectedIndexChanged(sender, e)

                'TODO... aggiungere un try catch per le query strings..
                tmpTVVar = jCMS.LoadTVByID(Convert.ToInt32(Request.QueryString("id")))

                LoadTVVar(tmpTVVar)
            End If

            jCMS.LoadListTemplateVariableTypes(DropDownListTipiTemplateVariable)

            DropDownListTipiTemplateVariable.SelectedIndex = DropDownListCategorieTemplateVariable.Items.IndexOf(DropDownListCategorieTemplateVariable.Items.FindByValue(tmpTVVar.Type))
            DropDownListTipiTemplateVariable.SelectedValue = tmpTVVar.Type
            DropDownListTipiTemplateVariable_SelectedIndexChanged(sender, e)
        Else
            tmpTVVar = jCMS.LoadTVByID(Session("idTVVar"))
        End If
    End Sub

    Private Sub LoadTVVar(ByVal TVVar As _cmsTVVariable)
        With TVVar
            '.idTV
            txtTemplateVariableName.Text = .Name
            txtTemplateVariableCaption.Text = .Caption
            txtTemplateVariableDescription.Text = .Description
            .idTVCategoria = -1

            '.Type 

            '.Inherit
            '.OuterTVHtml

            '.HideIfEmpty

            Session("idTVCategory") = .idTVCategoria
            Session("idTVVar") = .idTV
        End With

        For Each tmpChk As Object In panelElencoTemplate.Controls
            If TypeOf (tmpChk) Is CheckBox Then
                tmpChk.Checked = jCMS.CheckIfTVIsAssociatedWithTempalte(tmpChk.id, TVVar.idTV)
            End If
        Next
    End Sub

    Private Sub InitPage()
        myMasterPage = CType(Me.Master, Admin_MasterPage)
        myMasterPage.PageTitle.Text = Admin.litH1EditTemplateVariable
    End Sub

    Private Sub LoadLabels()
        litDescriptionEditTemplateVariable.Text = Admin.litDescriptionEditTemplateVariable
        litSelCategoriaTemplateVariable.Text = Admin.litSelCategoriaTemplateVariable
        imglitSelCategoriaTemplateVariable.Text = jCMS.CreateImgTooltip(litSelCategoriaTemplateVariable.Text, Admin.litHelpMessaggioCategorieTemplateVariable)

        litTemplateVariableName.Text = Admin.litTemplateVariableName
        imglitTemplateVariableName.Text = jCMS.CreateImgTooltip(litTemplateVariableName.Text, Admin.litHelpMessaggioTitoloTemplateVariable)

        litTemplateVariableCaption.Text = Admin.litTemplateVariableCaption
        imglitTemplateVariableCaption.Text = jCMS.CreateImgTooltip(litTemplateVariableCaption.Text, Admin.litHelpMessaggioCaptionTemplateVariable)

        litTemplateVariableDescription.Text = Admin.litTemplateVariableDescription
        imglitTemplateVariableDescription.Text = jCMS.CreateImgTooltip(litTemplateVariableDescription.Text, Admin.litHelpMessaggioDescrizioneTemplateVariable)

        btnSalvaNuovoTemplateVariable.Text = Admin.btnSalvaNuovoTemplateVariable

        litSelTipoTemplateVariable.Text = Admin.litSelTipoTemplateVariable
        imglitSelTipoTemplateVariable.Text = jCMS.CreateImgTooltip(litSelTipoTemplateVariable.Text, Admin.litHelpMessaggioElencoTipiTemplateVariable)

        LinkButtonNuovaCategoria.Text = Admin.LinkButtonNuovaCategoria
        lblNuovaCategoria.Text = Admin.lblNuovaCategoria
        btnSalvaNuovaCategoria.Text = Admin.btnSalvaNuovaCategoria

    End Sub

    Protected Sub LinkButtonNuovaCategoria_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButtonNuovaCategoria.Click
        If PanelNuovaCategoria.Visible = True Then
            PanelNuovaCategoria.Visible = False
        Else
            PanelNuovaCategoria.Visible = True
        End If
    End Sub

    Protected Sub btnSalvaNuovaCategoria_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalvaNuovaCategoria.Click
        Dim NomeCategoria As String = ""
        NomeCategoria = txtNuovaCategoria.Text.Trim

        If NomeCategoria.Length > 0 Then
            If jCMS.TemplateVariableCategoriaExist(NomeCategoria) Then
                myMasterPage.cmsMessagges.Text = jCMS.PrintWarning(Admin.messWarningCategoriaEsistente)
            Else
                PanelNuovaCategoria.Visible = False
                jCMS.AddNewCategoriaTemplateVariable(txtNuovaCategoria.Text)
                myMasterPage.cmsMessagges.Text = jCMS.PrintOK(Admin.messChunkCategoriaAggiunta)
                jCMS.LoadListCategorieTemplateVariable(DropDownListCategorieTemplateVariable)
            End If
        Else
            myMasterPage.cmsMessagges.Text = jCMS.PrintWarning(Admin.messWarningInserireCategoria)
        End If
    End Sub

    Protected Sub DropDownListTipiTemplateVariable_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListTipiTemplateVariable.SelectedIndexChanged
        With TemplateVariablesTypes
            'Select Case DropDownListTipiTemplateVariable.SelectedValue
            '    Case .DateID
            '        With PanelEsempioTemplateVariable
            '            Dim x As New Calendar
            '            .Controls.Add(x)
            '        End With
            '    Case .ImageID
            '        With PanelEsempioTemplateVariable
            '            Dim x As New Image
            '            .Controls.Add(x)
            '        End With
            '    Case .LinkID
            '        With PanelEsempioTemplateVariable
            '            Dim x As New HyperLink
            '            .Controls.Add(x)
            '        End With
            '    Case .NumberID
            '        With PanelEsempioTemplateVariable
            '            Dim x As New TextBox
            '            x.Text = "55"

            '            .Controls.Add(x)
            '        End With
            '    Case .TextAreaEditorID
            '        With PanelEsempioTemplateVariable
            '            Dim x As New TextBox
            '            x.TextMode = TextBoxMode.MultiLine

            '            .Controls.Add(x)
            '        End With
            '    Case .TextAreaID
            '        With PanelEsempioTemplateVariable
            '            Dim x As New TextBox
            '            x.TextMode = TextBoxMode.MultiLine

            '            .Controls.Add(x)
            '        End With
            '    Case .TextID
            '        With PanelEsempioTemplateVariable
            '            Dim x As New TextBox
            '            .Controls.Add(x)
            '        End With
            '    Case .VideoID
            '        With PanelEsempioTemplateVariable
            '            Dim x As New TextBox
            '            x.TextMode = TextBoxMode.MultiLine
            '            x.Text = "<object width=""480"" height=""385""><param name=""movie"" value=""http://www.youtube.com/v/dPM7X4jR3jo&hl=it_IT&fs=1&""></param><param name=""allowFullScreen"" value=""true""></param><param name=""allowscriptaccess"" value=""always""></param><embed src=""http://www.youtube.com/v/dPM7X4jR3jo&hl=it_IT&fs=1&"" type=""application/x-shockwave-flash"" allowscriptaccess=""always"" allowfullscreen=""true"" width=""480"" height=""385""></embed></object>"

            '            .Controls.Add(x)
            '        End With
            'End Select

            'PanelEsempioTemplateVariable.Visible = True

        End With
    End Sub

    Protected Sub btnSalvaNuovoTemplateVariable_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalvaNuovoTemplateVariable.Click
        If jCMS.TemplateVariableNameExist(txtTemplateVariableName.Text, DropDownListCategorieTemplateVariable.SelectedValue, tmpTVVar.idTV) = False Then
            If txtTemplateVariableName.Text.Trim.Length > 0 Then
                If txtTemplateVariableCaption.Text.Trim.Length > 0 Then
                    If DropDownListCategorieTemplateVariable.SelectedValue > 0 Then
                        If jCMS.CountTemplateChecked(panelElencoTemplate) > 0 Then
                            jCMS.UpdateTemplateVariable(tmpTVVar.idTV, txtTemplateVariableName.Text, txtTemplateVariableCaption.Text, txtTemplateVariableDescription.Text, DropDownListCategorieTemplateVariable.SelectedValue, DropDownListTipiTemplateVariable.SelectedValue, panelElencoTemplate)
                            myMasterPage.cmsMessagges.Text = jCMS.PrintOK(Admin.messTVSalvata)

                            Dim tmpDbCommand As New OleDbCommand : Dim tmpDbConnection As New OleDbConnection : myMasterPage.WriteWebSiteTree(tmpDbCommand, tmpDbConnection)
                        Else
                            myMasterPage.cmsMessagges.Text = jCMS.PrintWarning(Admin.messErroreNoTemplateSelected)
                        End If
                    Else
                        myMasterPage.cmsMessagges.Text = jCMS.PrintWarning(Admin.messErroreTVCategoriaNulla)
                    End If
                Else
                    myMasterPage.cmsMessagges.Text = jCMS.PrintWarning(Admin.messErroreTVCaptionNulla)
                End If
            Else
                myMasterPage.cmsMessagges.Text = jCMS.PrintWarning(Admin.messErroreTVNulla)
            End If
        Else
            myMasterPage.cmsMessagges.Text = jCMS.PrintWarning(Admin.messErroreTV)
        End If
    End Sub

    Protected Sub DropDownListCategorieTemplateVariable_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListCategorieTemplateVariable.SelectedIndexChanged

    End Sub
End Class
