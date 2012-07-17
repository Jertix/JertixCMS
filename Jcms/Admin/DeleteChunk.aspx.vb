Imports JertCMSUsers
Imports JertCMSFunctions
Imports Resources
Imports Jertix.Functions
Imports System.Data.OleDb

Partial Class Admin_DeleteChunk
    Inherits System.Web.UI.Page

    Dim myMasterPage As Admin_MasterPage
    Dim myLogin As New JertCMSUsers.JertCMSUsers
    Dim jCMS As New JertCMSFunctions.JertCMSFunctions

    Dim idChunkCategory As Long

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not myLogin.isLogged Then Response.Redirect("~/Admin/Login.aspx", False)
        jCMS.InitPage()
        InitPage()

        LoadLabels()

        If Not Page.IsPostBack Then
            Session("idChunkCategory") = Request.QueryString("category")
            idChunkCategory = Session("idChunkCategory")

            jCMS.LoadListChunks(DropDownListChunkChunks, idChunkCategory)

            If Request.QueryString("id") Is Nothing Then

            Else
                DropDownListChunkChunks.SelectedIndex = DropDownListChunkChunks.Items.IndexOf(DropDownListChunkChunks.Items.FindByValue(Request.QueryString("id")))
                DropDownListChunkChunks.SelectedValue = Request.QueryString("id")
                DropDownListChunkChunks_SelectedIndexChanged(sender, e)
            End If

        Else
            idChunkCategory = Session("idChunkCategory")
        End If
    End Sub

    Private Sub InitPage()
        myMasterPage = CType(Me.Master, Admin_MasterPage)
        myMasterPage.PageTitle.Text = Admin.litH1DeleteChunk
    End Sub

    Private Sub LoadLabels()
        litDescriptionDeleteChunk.Text = Admin.litDescriptionDeleteChunk

        litSelectChunk.Text = Admin.litSelectChunk
        imglitSelChunk.Text = jCMS.CreateImgTooltip(litSelectChunk.Text, Admin.litHelpMessaggioChunkDelete)

        btnEliminaChunk.Text = Admin.btnEliminaChunk
    End Sub

    Protected Sub btnEliminaChunk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEliminaChunk.Click

        Dim idChunk As Long = DropDownListChunkChunks.SelectedValue

        If idChunk = -1 Then
            myMasterPage.cmsMessagges.Text = jCMS.PrintWarning(Admin.messWarningSelezionaChunk)
        Else
            jCMS.DeleteChunk(idChunk)

            jCMS.LoadListChunks(DropDownListChunkChunks, idChunkCategory)
            Dim tmpDbCommand As New OleDbCommand : Dim tmpDbConnection As New OleDbConnection : myMasterPage.WriteWebSiteTree(tmpDbCommand, tmpDbConnection)

            myMasterPage.cmsMessagges.Text = jCMS.PrintOK(Admin.messChunkDeleted)
        End If

    End Sub

    Protected Sub DropDownListChunkChunks_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListChunkChunks.SelectedIndexChanged
        If DropDownListChunkChunks.SelectedIndex > 0 Then

        End If
    End Sub
End Class