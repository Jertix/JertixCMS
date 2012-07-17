Imports JertCMSUsers
Imports JertCMSFunctions
Imports Resources
Imports Jertix.Functions
Imports System.Data.OleDb

Partial Class Admin_AddPage
    Inherits System.Web.UI.Page

    Dim myMasterPage As Admin_MasterPage
    Dim myLogin As New JertCMSUsers.JertCMSUsers
    Dim jCMS As New JertCMSFunctions.JertCMSFunctions

    Dim myDir As New DirectoryManipulation

    Dim Menu As _cms_MenuQueryStrings
    Dim Param As _cms_MenuParameters
    Dim QueryMenu As _cms_MenuQueryStrings

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        jCMS.InitPage()

        'Caricamento Controlli Dinamici...
        InitPage()
        AddHeaderButtons(myMasterPage.HeaderButtons)

        ReadQueryStrings()


        If Not Page.IsPostBack Then

        Else
            If Session("idTemplate") > 0 Then

                If QueryMenu.idTemplate = Session("idTemplate") Then

                    If QueryMenu.Action = jCMS.MenuParameters.ActionEdit Then
                        jCMS.LoadTVListFromTemplate(PanelControlli, Session("idTemplate"), Session("idPage"), True, True)
                    End If
                    If QueryMenu.Action = jCMS.MenuParameters.ActionAdd Then
                        jCMS.LoadTVListFromTemplate(PanelControlli, Session("idTemplate"), -1, False, True)
                    End If

                    Session("TvByTemplateLoaded") = 1

                Else
                    Session("idTemplate") = 0
                    Session("TvByTemplateLoaded") = 0
                End If

            End If
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Lettura valori....
        If Not myLogin.isLogged Then Response.Redirect("~/Admin/Login.aspx", False)

        jCMS.InitPage()
        ReadQueryStrings()

        LoadLabels()

        If Not Page.IsPostBack Then
            jCMS.LoadListTemplates(DropDownListTemplates)

            If QueryMenu.Action = jCMS.MenuParameters.ActionAdd Then
                Session("idTemplate") = -1
                Session("TvByTemplateLoaded") = 0
            End If
            If QueryMenu.Action = jCMS.MenuParameters.ActionEdit Then
                Dim idTemplate As Long = CType(QueryMenu.idTemplate, Long)
                DropDownListTemplates.SelectedValue = idTemplate

                Dim idPage As Long = CType(QueryMenu.idPage, Long)
                Dim idVoce As Long = CType(QueryMenu.idVoce, Long)

                LoadPageFields(idPage, idVoce)

                jCMS.LoadTVListFromTemplate(PanelControlli, idTemplate, idPage, True, False)

                Session("idTemplate") = idTemplate
                Session("idPage") = idPage

                Session("TvByTemplateLoaded") = 0
            End If
        Else
            Session("idTemplate") = DropDownListTemplates.SelectedValue

            If QueryMenu.idTemplate <> Session("idTemplate") Then
                'Cambio di Template

                Session("TvByTemplateLoaded") = 1
                QueryMenu.idTemplate = Session("idTemplate")

                If QueryMenu.Action = jCMS.MenuParameters.ActionAdd Then
                    jCMS.LoadTVListFromTemplate(PanelControlli, Session("idTemplate"), -1, False, False)
                End If
                If QueryMenu.Action = jCMS.MenuParameters.ActionEdit Then
                    Dim idTemplate As Long = CType(QueryMenu.idTemplate, Long)
                    DropDownListTemplates.SelectedValue = idTemplate

                    Dim idPage As Long = CType(QueryMenu.idPage, Long)
                    Dim idVoce As Long = CType(QueryMenu.idVoce, Long)

                    LoadPageFields(idPage, idVoce)

                    jCMS.LoadTVListFromTemplate(PanelControlli, idTemplate, idPage, False, False)

                    Session("idTemplate") = idTemplate
                    Session("idPage") = idPage
                End If
            End If

            QueryMenu.idTemplate = Session("idTemplate")

            If Session("TvByTemplateLoaded") = 0 Then
                If QueryMenu.Action = jCMS.MenuParameters.ActionAdd Then
                    jCMS.LoadTVListFromTemplate(PanelControlli, Session("idTemplate"), -1, False, False)
                End If
                If QueryMenu.Action = jCMS.MenuParameters.ActionEdit Then
                    Dim idTemplate As Long = CType(QueryMenu.idTemplate, Long)
                    DropDownListTemplates.SelectedValue = idTemplate

                    Dim idPage As Long = CType(QueryMenu.idPage, Long)
                    Dim idVoce As Long = CType(QueryMenu.idVoce, Long)

                    LoadPageFields(idPage, idVoce)

                    jCMS.LoadTVListFromTemplate(PanelControlli, idTemplate, idPage, True, False)

                    Session("idTemplate") = idTemplate
                    Session("idPage") = idPage
                End If
            End If

            If Session("TvByTemplateLoaded") = 1 Then
                If QueryMenu.Action = jCMS.MenuParameters.ActionEdit Then
                    'Dim idTemplate As Long = CType(QueryMenu.idTemplate, Long)
                    'DropDownListTemplates.SelectedValue = idTemplate

                    'Dim idPage As Long = CType(QueryMenu.idPage, Long)
                    'Dim idVoce As Long = CType(QueryMenu.idVoce, Long)

                    'LoadPageFields(idPage, idVoce)

                    'jCMS.LoadTVListFromTemplate(PanelControlli, idTemplate, idPage, True, False)

                    'Session("idTemplate") = idTemplate
                    'Session("idPage") = idPage
                End If
            End If

            Session("TvByTemplateLoaded") = 0
        End If

    End Sub

    Private Sub ReadQueryStrings()
        Menu = jCMS.MenuQueryStrings
        Param = jCMS.MenuParameters

        With QueryMenu
            .MenuLang = Request.QueryString(Menu.MenuLang)
            .Action = Request.QueryString(Menu.Action)
            .PageType = Request.QueryString(Menu.PageType)
            .idPage = Request.QueryString(Menu.idPage)
            .idTemplate = Request.QueryString(Menu.idTemplate)
            .idVoce = Request.QueryString(Menu.idVoce)
            .codPage = Request.QueryString(Menu.codPage)
            .codPageMother = Request.QueryString(Menu.codPageMother)
            .ProfonditaLivello = Request.QueryString(Menu.ProfonditaLivello)
        End With
    End Sub

    Private Sub InitPage()
        myMasterPage = CType(Me.Master, Admin_MasterPage)
        myMasterPage.InsertTinyJs(jCMS.CreateTinyJavascript()) = True
    End Sub

    Private Sub AddHeaderButtons(ByVal panel As Panel)
        panel.Controls.Clear()
        panel.Controls.Add(New LiteralControl("<ul>"))

        '*******************************************************************
        panel.Controls.Add(New LiteralControl("	<li class=""btn-save"">"))
        Dim tmpLinkSalva As New LinkButton
        tmpLinkSalva.ID = "linkSalva"
        tmpLinkSalva.Text = "Salva"
        AddHandler tmpLinkSalva.Click, AddressOf LinkSalva_Click
        panel.Controls.Add(tmpLinkSalva)
        panel.Controls.Add(New LiteralControl("</li>"))

        panel.Controls.Add(New LiteralControl("	<li class=""btn-preview"">"))
        Dim tmpLinkAnteprima As New LinkButton
        tmpLinkAnteprima.ID = "linkAnteprima"
        tmpLinkAnteprima.Text = "Anteprima"
        AddHandler tmpLinkAnteprima.Click, AddressOf LinkAnteprima_Click
        panel.Controls.Add(tmpLinkAnteprima)
        panel.Controls.Add(New LiteralControl("</li>"))

        panel.Controls.Add(New LiteralControl("	<li class=""btn-delete"">"))
        Dim tmpLinkElimina As New LinkButton
        tmpLinkElimina.ID = "linkElimina"
        tmpLinkElimina.Text = "Elimina"
        AddHandler tmpLinkElimina.Click, AddressOf LinkElimina_Click
        panel.Controls.Add(tmpLinkElimina)
        panel.Controls.Add(New LiteralControl("</li>"))
        '*******************************************************************

        panel.Controls.Add(New LiteralControl("	<li class=""btn-settings"">"))
        panel.Controls.Add(New LiteralControl("		<a href=""#"" class=""btn-addanother"" title=""<div><span></span><h2>Aggiungi un altra pagina</h2><p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.</p></div>"">&nbsp;</a>"))
        panel.Controls.Add(New LiteralControl("		<a href=""#"" class=""btn-continue-editing active"" title=""<div><span></span><h2>Continua ad editare la pagina</h2><p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.</p></div>"">&nbsp;</a>"))
        panel.Controls.Add(New LiteralControl("		<a href=""#"" class=""btn-close"" title=""<div><span></span><h2>Chiudi la pagina</h2><p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.</p></div>"">&nbsp;</a>"))
        panel.Controls.Add(New LiteralControl("	</li>"))
        panel.Controls.Add(New LiteralControl("</ul>"))
    End Sub

    Private Sub LoadLabels()
        myMasterPage.Tabs.Text = jCMS.GenerateHTMLTabasList(Admin.tabsHome)

        If QueryMenu.PageType = jCMS.MenuParameters.PageTypeHome Then
            myMasterPage.PageTitle.Text = Admin.litH1AddHomePage
            litDescriptionAddHomePage.Text = Admin.litDescriptionAddHomePage & " <strong>(" & QueryMenu.MenuLang & ")</strong>"
        End If
        If QueryMenu.PageType = jCMS.MenuParameters.PageTypeGeneric Then
            'TODO da globalizzare..
            myMasterPage.PageTitle.Text = "Aggiungi pagina:"
            litDescriptionAddHomePage.Text = "Descr..."
        End If

        litSelTemplate.Text = Admin.litSelTemplate
        imglitSelTemplate.Text = jCMS.CreateImgTooltip(litSelTemplate.Text, Admin.litHelpMessaggioTemplateInAddPage)

        litPageTitleCaption.Text = Admin.litPageTitleCaption
        imgPageTitle.Text = jCMS.CreateImgTooltip(litPageTitleCaption.Text, Admin.litHelpMessaggioPageTitle)

        litMetaDescriptionCaption.Text = Admin.litMetaDescriptionCaption
        imgMetaDescription.Text = jCMS.CreateImgTooltip(litMetaDescriptionCaption.Text, Admin.litHelpMessaggioMetaDescription)

        litTitleH1Caption.Text = Admin.litTitleH1Caption
        imgTitleH1.Text = jCMS.CreateImgTooltip(litTitleH1Caption.Text, Admin.litHelpMessaggioTitoloH1)

        litDescrizioneBreveMenu.Text = Admin.litDescrizioneBreveMenu
        imgDescrizioneBreveMenu.Text = jCMS.CreateImgTooltip(litDescrizioneBreveMenu.Text, Admin.litHelpMessaggioDescrizioneVoceDiMenu)

        litPageContent.Text = Admin.litPageContent
        imgPageContent.Text = jCMS.CreateImgTooltip(litPageContent.Text, Admin.litHelpMessaggioPageContent)

    End Sub

    Protected Sub DropDownListTemplates_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListTemplates.SelectedIndexChanged
        If DropDownListTemplates.SelectedIndex > 0 Then

        End If
    End Sub

    Protected Sub LinkSalva_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If DropDownListTemplates.SelectedValue <> "" AndAlso DropDownListTemplates.SelectedValue > 0 Then
            Dim tmpPagina As New _cmsPage
            With tmpPagina

                Dim idPage As Long = 0
                Dim codPage As Long = 0
                Dim idVoce As Long = 0

                If QueryMenu.Action = jCMS.MenuParameters.ActionAdd Then
                    .NuovaPagina = True
                Else
                    .NuovaPagina = False
                    idPage = CType(QueryMenu.idPage, Long)
                    codPage = CType(QueryMenu.codPage, Long)
                    idVoce = CType(QueryMenu.idVoce, Long)
                End If

                .idLingua = jCMS.GetIdLanguageFromName(QueryMenu.MenuLang)
                .idPagina = idPage
                .codPagina = codPage
                .idVoce = idVoce

                '.LivelloVisibilita()
                .MetaDescription = txtMetaDescription.Text.Trim
                .TitoloH1 = txtTitleH1.Text.Trim
                .Tipo = jCMS.TipiDiPagine.PaginaNormale
                .Titolo = txtPageTitle.Text.Trim

                .idTemplate = DropDownListTemplates.SelectedValue
                .LivelloVisibilita = myLogin.UserLevels.L4_AmministratoreSito

                .HTMLPageContent = txtContent.Text.Replace("'", "''")

                .PageQueryParameters = QueryMenu

                'tmpPagina è passato byRef per poter aggiornanre .codPagina
                jCMS.SalvaPagina(tmpPagina, PanelControlli)

                If .NuovaPagina Then
                    myMasterPage.cmsMessagges.Text = jCMS.PrintOK("Nuova pagina salvata.")
                End If
            End With

            Dim tmpVoce As New _cmsVoceDiMenu
            With tmpVoce
                .codPagina = tmpPagina.codPagina


                .DescrizioneBreveNelMenu = txtDescrizioneBreveMenu.Text.Trim
                .idLingua = tmpPagina.idLingua
                If tmpPagina.NuovaPagina Then
                    .codPaginaMadre = CType(QueryMenu.codPage, Long)
                    .idVoce = 0 'TODO .... IIf(DropDownListVociDiMenu.Items.Count > 0, DropDownListVociDiMenu.SelectedValue, 0)
                    .ordine = 0 'TODO .... IIf(DropDownListOrdini.Items.Count > 0, DropDownListOrdini.SelectedValue, 1) + 1
                Else
                    .codPaginaMadre = QueryMenu.codPageMother
                    .idVoce = tmpPagina.idVoce
                    .ordine = 0
                End If

                .NuovaPagina = tmpPagina.NuovaPagina

                If .NuovaPagina Then
                    .ProfonditaLivello = 1
                    Dim tmpLev As Long = jCMS.GetProfonditaLivelloDaIdVoceDiMenu(tmpPagina.idVoce)
                    If tmpLev > 1 Then .ProfonditaLivello = tmpLev

                    If tmpPagina.idVoce = 0 Then
                        .ProfonditaLivello = QueryMenu.ProfonditaLivello + 1
                    End If

                Else
                    .ProfonditaLivello = jCMS.GetProfonditaLivelloDaIdVoceDiMenu(tmpPagina.idVoce)
                End If

                .folderpath = jCMS.CreaPathMenu(.ProfonditaLivello, .codPaginaMadre, QueryMenu.MenuLang, .idLingua, .DescrizioneBreveNelMenu.Trim)

                If tmpPagina.PageQueryParameters.PageType = jCMS.MenuParameters.PageTypeHome Then
                    .folderpath = "\"
                End If

                jCMS.SalvaVoceMenu(tmpVoce)

                If .NuovaPagina Then
                    myMasterPage.cmsMessagges.Text = jCMS.PrintOK("Nuova voce di menu salvata.")
                Else
                    myMasterPage.cmsMessagges.Text = jCMS.PrintOK("Voce di menu modificata.")
                End If
            End With

            Session("AdminMenuTree") = Nothing
            Dim tmpDbCommand As New OleDbCommand : Dim tmpDbConnection As New OleDbConnection : myMasterPage.WriteWebSiteTree(tmpDbCommand, tmpDbConnection)

            'TODO.. Response REDIRECT in ... EDIT mode
            If QueryMenu.Action = jCMS.MenuParameters.ActionAdd Then
                If QueryMenu.PageType = jCMS.MenuParameters.PageTypeGeneric Then
                    Response.Redirect("~/Admin/AddPage.aspx?" & Session("tmpSessionQueryEditVoce" & tmpVoce.idVoce).ToString.Replace("&amp;", "&"))
                End If
                If QueryMenu.PageType = jCMS.MenuParameters.PageTypeHome Then
                    Response.Redirect("~/Admin/AddPage.aspx?" & Session("tmpSessionQueryEditHome" & QueryMenu.MenuLang).ToString.Replace("&amp;", "&"))
                End If
            End If

        Else
            myMasterPage.cmsMessagges.Text = jCMS.PrintError("Selezionare un Template prima di salvare.")
        End If
    End Sub

    Protected Sub LinkAnteprima_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        myMasterPage.cmsMessagges.Text = jCMS.PrintOK("Hai premuto ANTEPRIMA")
    End Sub

    Protected Sub LinkElimina_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        myMasterPage.cmsMessagges.Text = jCMS.PrintOK("Hai premuto ELIMINA")
    End Sub

    Private Sub LoadPageFields(ByVal idPage As Long, ByVal idVoceDiMenu As Long)
        Dim tmpPage As New _cmsPage
        tmpPage = jCMS.GetPageByID(idPage)

        With tmpPage
            txtPageTitle.Text = .Titolo
            txtMetaDescription.Text = .MetaDescription
            txtTitleH1.Text = .TitoloH1
            'txtDescrizioneBreveMenu.Text = jCMS.GetVoceMenuFromIdVoce(idVoceDiMenu)
            'Ottimizzazione..
            txtDescrizioneBreveMenu.Text = .DescrizioneBreveNelMenu
            txtContent.Text = .HTMLPageContent
        End With

    End Sub

End Class