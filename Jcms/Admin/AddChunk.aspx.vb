Imports JertCMSUsers
Imports JertCMSFunctions
Imports Resources
Imports Jertix.Functions
Imports System.Data.OleDb

Partial Class Admin_AddChunk
    Inherits System.Web.UI.Page

    Dim myMasterPage As Admin_MasterPage
    Dim myLogin As New JertCMSUsers.JertCMSUsers
    Dim jCMS As New JertCMSFunctions.JertCMSFunctions

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not myLogin.isLogged Then Response.Redirect("~/Admin/Login.aspx", False)
        jCMS.InitPage()
        InitPage()

        LoadLabels()

        If Not Page.IsPostBack Then
            jCMS.LoadListCategorieChunks(DropDownListCategorieChunk)

            If Request.QueryString("idCat") Is Nothing Then

            Else
                DropDownListCategorieChunk.SelectedIndex = DropDownListCategorieChunk.Items.IndexOf(DropDownListCategorieChunk.Items.FindByValue(Request.QueryString("idCat")))
                DropDownListCategorieChunk.SelectedValue = Request.QueryString("idCat")
                DropDownListCategorieChunk_SelectedIndexChanged(sender, e)
            End If

        End If
    End Sub

    Private Sub InitPage()
        myMasterPage = CType(Me.Master, Admin_MasterPage)
        myMasterPage.PageTitle.Text = Admin.litH1AddChunk

        'myMasterPage.Tabs.Text = jCMS.GenerateHTMLTabasList(Admin.tabsChunk)

        myMasterPage.EditAreaText = "<script language=""Javascript"" type=""text/javascript"" src=""edit_area/edit_area_full.js""></script>" & vbCrLf
        myMasterPage.EditAreaText &= jCMS.CreateEditAreaJavascript(txtChunk.ClientID)
    End Sub

    Private Sub LoadLabels()
        litDescriptionAddChunk.Text = Admin.litDescriptionAddChunk

        litSelCategoriaChunk.Text = Admin.litSelCategoriaChunk
        imglitExistingCategories.Text = jCMS.CreateImgTooltip(litSelCategoriaChunk.Text, Admin.litHelpMessaggioCategorieChunk)

        litSelChunk.Text = Admin.litSelChunk
        imglitListChunks.Text = jCMS.CreateImgTooltip(litSelChunk.Text, Admin.litHelpMessaggioChunk)

        btnSalvaNuovoChunk.Text = Admin.btnSalvaNuovoChunk
        litTextChunk.Text = Admin.litTextChunk
        litChunkName.Text = Admin.litChunkName
        imgChunkName.Text = jCMS.CreateImgTooltip(litChunkName.Text, Admin.litHelpMessaggioTitoloChunk)

        LinkButtonNuovaCategoria.Text = Admin.LinkButtonNuovaCategoria
        lblNuovaCategoria.Text = Admin.lblNuovaCategoria

        btnSalvaNuovaCategoria.Text = Admin.btnSalvaNuovaCategoria
    End Sub

    Protected Sub btnSalvaNuovoChunk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalvaNuovoChunk.Click
        If jCMS.ChunkNameExist(txtChunkName.Text, DropDownListCategorieChunk.SelectedValue) = False Then
            If txtChunkName.Text.Trim.Length > 0 Then
                jCMS.SaveChunk(txtChunkName.Text, txtChunk.Text, DropDownListCategorieChunk.SelectedValue)
                jCMS.LoadListChunks(DropDownListChunks, DropDownListCategorieChunk.SelectedValue)
                myMasterPage.cmsMessagges.Text = jCMS.PrintOK(Admin.messChunkSalvato)

                Dim tmpDbCommand As New OleDbCommand : Dim tmpDbConnection As New OleDbConnection : myMasterPage.WriteWebSiteTree(tmpDbCommand, tmpDbConnection)
            Else
                myMasterPage.cmsMessagges.Text = jCMS.PrintWarning(Admin.messErroreChunkNullo)
            End If
        Else
            myMasterPage.cmsMessagges.Text = jCMS.PrintWarning(Admin.messErroreChunk)
        End If
    End Sub

    Protected Sub DropDownListChunks_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListChunks.SelectedIndexChanged
        If DropDownListChunks.SelectedIndex > 0 Then
            txtChunkName.Text = Admin.CopiaDi & jCMS.GetChunkNameFromID(DropDownListChunks.SelectedValue)
            txtChunk.Text = jCMS.GetChunkFromID(DropDownListChunks.SelectedValue)
        End If
    End Sub

    Protected Sub DropDownListCategorieChunk_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListCategorieChunk.SelectedIndexChanged
        If DropDownListCategorieChunk.SelectedIndex > 0 Then
            jCMS.LoadListChunks(DropDownListChunks, DropDownListCategorieChunk.SelectedValue)
        End If
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
            If jCMS.ChunkCategoriaExist(NomeCategoria) Then
                myMasterPage.cmsMessagges.Text = jCMS.PrintWarning(Admin.messWarningCategoriaEsistente)
            Else
                PanelNuovaCategoria.Visible = False
                jCMS.AddNewCategoriaChunk(txtNuovaCategoria.Text)
                myMasterPage.cmsMessagges.Text = jCMS.PrintOK(Admin.messChunkCategoriaAggiunta)
                jCMS.LoadListCategorieChunks(DropDownListCategorieChunk)

                Dim tmpDbCommand As New OleDbCommand : Dim tmpDbConnection As New OleDbConnection : myMasterPage.WriteWebSiteTree(tmpDbCommand, tmpDbConnection)
            End If
        Else
            myMasterPage.cmsMessagges.Text = jCMS.PrintWarning(Admin.messWarningInserireCategoria)
        End If
    End Sub
End Class
