Imports JertCMSUsers
Imports JertCMSFunctions
Imports Resources
Imports Jertix.Functions
Imports jCMSModules
Imports System.Data.OleDb

Partial Class Admin_EditComponent
    Inherits System.Web.UI.Page

    Dim myMasterPage As Admin_MasterPage
    Dim myLogin As New JertCMSUsers.JertCMSUsers
    Dim jCMS As New JertCMSFunctions.JertCMSFunctions
    Dim jModule As New jCMSModules.jertCMSModules
    Dim jRegEx As New Jertix.Functions.RegExClass
    Dim jCMSCommands As JertCMSCommands.JertCMSCommands

    Dim idModule As Long
    Dim idComponent As Long

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not myLogin.isLogged Then Response.Redirect("~/Admin/Login.aspx", False)
        jCMS.InitPage()
        InitPage()

        jCMSCommands = New JertCMSCommands.JertCMSCommands

        LoadLabels()

        If Not Page.IsPostBack Then
            jModule.LoadListModules(DropDownListModules)

            If Request.QueryString("Module") Is Nothing Then

            Else
                idModule = Request.QueryString("Module")

                DropDownListModules.SelectedIndex = DropDownListModules.Items.IndexOf(DropDownListModules.Items.FindByValue(idModule))
                DropDownListModules.SelectedValue = idModule
                DropDownListModules_SelectedIndexChanged(sender, e)

                idComponent = Request.QueryString("id")

                DropDownListComponents.SelectedIndex = DropDownListComponents.Items.IndexOf(DropDownListComponents.Items.FindByValue(idComponent))
                DropDownListComponents.SelectedValue = idComponent
                DropDownListComponents_SelectedIndexChanged(sender, e)
            End If

        Else
            idComponent = Request.QueryString("id")
        End If
    End Sub

    Private Sub InitPage()
        myMasterPage = CType(Me.Master, Admin_MasterPage)

        myMasterPage.Tabs.Text = jCMS.GenerateHTMLTabasList(Admin.tabsComponent)

        myMasterPage.PageTitle.Text = Admin.litH1EditComponent

        myMasterPage.EditAreaText = "<script language=""Javascript"" type=""text/javascript"" src=""edit_area/edit_area_full.js""></script>" & vbCrLf
        myMasterPage.EditAreaText &= jCMS.CreateEditAreaJavascript(txtTextComponentExample.ClientID)
    End Sub

    Private Sub LoadLabels()
        litDescriptionEditComponent.Text = Admin.litDescriptionEditComponent

        litSelModule.Text = Admin.litSelModule
        imgSelModule.Text = jCMS.CreateImgTooltip(litSelModule.Text, Admin.litHelpMessaggioEditComponent)

        litSelComponent.Text = Admin.litSelComponent
        imgSelComponent.Text = jCMS.CreateImgTooltip(litSelComponent.Text, Admin.litHelpMessaggioSelComponent)

        litEditComponentName.Text = Admin.litEditComponentName
        imgEditComponentName.Text = jCMS.CreateImgTooltip(litEditComponentName.Text, Admin.litHelpMessaggioComponentName)

        litEditComponentFileName.Text = Admin.litEditComponentFileName
        imgEditComponentFileName.Text = jCMS.CreateImgTooltip(litEditComponentFileName.Text, Admin.litHelpMessaggioComponentFileName)

        litTextComponentExample.Text = Admin.litTextComponentExample
        imgTextComponentExample.Text = jCMS.CreateImgTooltip(litTextComponentExample.Text, Admin.litHelpMessaggioComponentExample)

        btnSalvaModificheComponente.Text = Admin.btnSalvaModificheComponente
    End Sub

    Protected Sub btnSalvaModificheComponente_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalvaModificheComponente.Click
        If DropDownListComponents.SelectedValue > -1 And DropDownListModules.SelectedValue > -1 Then
            If txtEditComponentName.Text.Trim.Length > 0 Then
                If txtEditComponentFileName.Text.Trim.Length > 0 Then
                    idModule = DropDownListModules.SelectedValue
                    idComponent = DropDownListComponents.SelectedValue

                    If jModule.ComponentNameExist(idModule, idComponent, txtEditComponentName.Text.Trim) = False Then
                        'Non esiste un componente con lo stesso nome, possiamo aggiornare il nome...
                        jModule.EditComponent(idComponent, txtEditComponentName.Text.Trim, txtEditComponentFileName.Text.Trim, txtTextComponentExample.Text.Trim)

                        jModule.LoadListModules(DropDownListModules)

                        myMasterPage.cmsMessagges.Text = jCMS.PrintOK(Admin.messComponenteAggiornato)
                        Dim tmpDbCommand As New OleDbCommand : Dim tmpDbConnection As New OleDbConnection : myMasterPage.WriteWebSiteTree(tmpDbCommand, tmpDbConnection)

                        DropDownListModules.SelectedIndex = DropDownListModules.Items.IndexOf(DropDownListModules.Items.FindByValue(idModule))
                        DropDownListModules.SelectedValue = idModule
                        DropDownListModules_SelectedIndexChanged(sender, e)
                        DropDownListComponents.SelectedIndex = DropDownListComponents.Items.IndexOf(DropDownListComponents.Items.FindByValue(idComponent))
                        DropDownListComponents.SelectedValue = idComponent
                        DropDownListComponents_SelectedIndexChanged(sender, e)
                    Else
                        myMasterPage.cmsMessagges.Text = jCMS.PrintWarning(Admin.messErroreEsisteComponenteConStessoNome)
                    End If
                Else
                    myMasterPage.cmsMessagges.Text = jCMS.PrintWarning(Admin.messErroreNomeFileComponenteNullo)
                End If
            Else
                myMasterPage.cmsMessagges.Text = jCMS.PrintWarning(Admin.messErroreNomeComponenteNullo)
            End If
        Else
            myMasterPage.cmsMessagges.Text = jCMS.PrintWarning(Admin.messErroreComponenteEModuloNonSelezionato)
        End If
    End Sub

    Protected Sub DropDownListModules_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListModules.SelectedIndexChanged
        If DropDownListModules.SelectedIndex > 0 Then
            jModule.LoadListComponents(DropDownListComponents, DropDownListModules.SelectedValue)
            DropDownListComponents_SelectedIndexChanged(sender, e)
        End If
    End Sub

    Protected Sub DropDownListComponents_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListComponents.SelectedIndexChanged
        If DropDownListComponents.SelectedIndex > 0 Then
            idComponent = DropDownListComponents.SelectedValue

            Dim tmpComponent As _cms_Component
            tmpComponent = jModule.GetComponentFromModuleId(idComponent)

            With tmpComponent
                txtEditComponentName.Text = .ComponentName
                txtEditComponentFileName.Text = .FileName
                txtTextComponentExample.Text = .Example
            End With

        End If
    End Sub
End Class
