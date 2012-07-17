Imports JertCMSUsers
Imports JertCMSFunctions
Imports Resources
Imports Jertix.Functions
Imports System.Data.OleDb

Partial Class Admin_AddChunkCategory
    Inherits System.Web.UI.Page

    Dim myMasterPage As Admin_MasterPage
    Dim myLogin As New JertCMSUsers.JertCMSUsers
    Dim jCMS As New JertCMSFunctions.JertCMSFunctions

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not myLogin.isLogged Then Response.Redirect("~/Admin/Login.aspx", False)
        jCMS.InitPage()
        InitPage()

        LoadLabels()

        If Not Page.IsPostBack Then
            jCMS.LoadListChunksCategories(DropDownListChunkCategories)

            If Request.QueryString("id") Is Nothing Then

            Else
                DropDownListChunkCategories.SelectedIndex = DropDownListChunkCategories.Items.IndexOf(DropDownListChunkCategories.Items.FindByValue(Request.QueryString("id")))
                DropDownListChunkCategories.SelectedValue = Request.QueryString("id")
                DropDownListChunkCategories_SelectedIndexChanged(sender, e)
            End If

        Else

        End If
    End Sub

    Private Sub InitPage()
        myMasterPage = CType(Me.Master, Admin_MasterPage)
        myMasterPage.PageTitle.Text = Admin.litH1AddChunkCategory
    End Sub

    Private Sub LoadLabels()
        litDescriptionAddChunkCategory.Text = Admin.litDescriptionAddChunkCategory

        litExistingCategories.Text = Admin.litExistingCategories
        imglitExistingCategories.Text = jCMS.CreateImgTooltip(litExistingCategories.Text, Admin.litHelpMessaggioCategorieChunkEsistenti)

        btnAddNewCategory.Text = Admin.btnAddNewCategory
        litAddCategoryName.Text = Admin.litAddCategoryName

        imglitCategoryName.Text = jCMS.CreateImgTooltip(litAddCategoryName.Text, Admin.litHelpMessaggioCategorieChunkAdd)

    End Sub

    Protected Sub btnAddNewCategory_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddNewCategory.Click

        Dim idCategoria As Long = DropDownListChunkCategories.SelectedValue

        Dim NomeCategoria As String = ""
        NomeCategoria = txtCategoryName.Text.Trim

        If NomeCategoria.Length > 0 Then
            If jCMS.ChunkCategoriaExist(NomeCategoria) Then
                myMasterPage.cmsMessagges.Text = jCMS.PrintWarning(Admin.messChunkCategoriaEsistente)
            Else
                jCMS.AddNewCategoriaChunk(NomeCategoria)
                myMasterPage.cmsMessagges.Text = jCMS.PrintOK(Admin.messChunkCategoriaAggiunta)
                jCMS.LoadListCategorieChunks(DropDownListChunkCategories)

                Dim tmpDbCommand As New OleDbCommand : Dim tmpDbConnection As New OleDbConnection : myMasterPage.WriteWebSiteTree(tmpDbCommand, tmpDbConnection)
            End If
        Else
            myMasterPage.cmsMessagges.Text = jCMS.PrintWarning(Admin.messWarningInserireCategoria)
        End If

    End Sub

    Protected Sub DropDownListChunkCategories_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListChunkCategories.SelectedIndexChanged
        If DropDownListChunkCategories.SelectedIndex > 0 Then
            txtCategoryName.Text = DropDownListChunkCategories.SelectedItem.Text
        End If
    End Sub
End Class

