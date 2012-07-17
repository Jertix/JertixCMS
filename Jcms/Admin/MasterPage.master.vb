Imports JertCMSUsers
Imports JertCMSFunctions
Imports Resources
Imports System.Data.OleDb
Imports Jertix.Functions

Partial Class Admin_MasterPage
    Inherits System.Web.UI.MasterPage

    Dim myLogin As New JertCMSUsers.JertCMSUsers
    Dim jCMS As New JertCMSFunctions.JertCMSFunctions

    Dim tmpDbCommand As New OleDbCommand
    Dim tmpDbConnection As New OleDbConnection
    Dim db As New DBFunctions

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not myLogin.isLogged Then Response.Redirect("~/Admin/Login.aspx")
        jCMS.InitPage()

        LoadLabels()

        If Not Page.IsPostBack Then
            Dim SiteName As String = "http://" & HttpContext.Current.Session("SiteName")

            linkAnteprimaSito.NavigateUrl = SiteName
            litNomeSito.Text = SiteName
            litHomeAdmin.Text = "<a href=""" & SiteName & "/admin/" & " "">"
            litHomeAdminCloseTag.Text = "</a>"

            litModulesList.Text = jCMS.WriteModulesList(SiteName)

            WriteWebSiteTree(tmpDbCommand, tmpDbConnection)
        Else
            cmsMessagges.Text = ""
        End If
    End Sub

    Public Sub WriteWebSiteTree(Optional ByRef tmpDbCommand As OleDbCommand = Nothing, Optional ByRef tmpDbConnection As OleDbConnection = Nothing)
        Dim retValue As _cms_AdminMenuTree

        'http://www.tvidesign.co.uk/blog/improve-your-jquery-25-excellent-tips.aspx#tip17
        ' view plaincopy to clipboardprint?
        '$('#forms').load('content/headerForms.html', function() {  
        '    // Code here runs once the content has loaded  
        '    // Put all your event handlers etc. here.              
        '});

        If Not Session("AdminMenuTree") Is Nothing Then
            retValue = Session("AdminMenuTree")
        Else
            retValue = jCMS.JertCMS_WriteAdminWebSiteTree(tmpDbCommand, tmpDbConnection)
            Session("AdminMenuTree") = retValue
        End If

        litWebSiteTree.Text = retValue.HTMLMenu
        litContextMenu.Text = retValue.HTMLContextMenu
        litjQueryContextMenu.Text = retValue.jQueryFunctions

        Dim retValueAdmin As _cms_AdminAdministratorMenuTree = jCMS.JertCMS_WriteAdministrationTree(tmpDbCommand, tmpDbConnection)

        litAdministrationTree.Text = retValueAdmin.HTMLMenu
        litAdministratorContextMenu.Text = retValueAdmin.HTMLContextMenu
        litjQueryContextMenuAdministrator.Text = retValueAdmin.jQueryFunctions

        db.CloseConn(True, tmpDbConnection)
        GC.Collect() 'Chiude eventuali connessioni ancora aperte

        Dim SitePath As String = "http://" & HttpContext.Current.Session("SiteName")
        Dim pageFolder As String = SitePath & Page.TemplateSourceDirectory & "/"

        If retValue.isNewTree And (pageFolder <> SitePath & "/admin/") Then
            'Elimina problema di refresh del menu quando viene creata la prima lingua in automatico
            Response.Redirect("~/Admin/")
        End If
    End Sub

    Public Property EditAreaText() As String
        Get
            Return litEditArea.Text
        End Get
        Set(ByVal value As String)
            litEditArea.Text = value
        End Set
    End Property

    Public WriteOnly Property InsertTinyJs(ByVal TinyScript As String) As Boolean
        Set(ByVal Insert As Boolean)
            If Insert Then
                litTinyInclude.Text = "<script type=""text/javascript"" src=""tinymce/jscripts/tiny_mce/jquery.tinymce.js""></script>"
                litTinyFunction.Text = TinyScript
            Else
                litTinyInclude.Text = ""
                litTinyFunction.Text = ""
            End If
        End Set
    End Property


    Public Property HeaderButtons() As Panel
        Get
            Return PanelButtons
        End Get
        Set(ByVal PanelWithButtons As Panel)
            PanelButtons = PanelWithButtons
        End Set
    End Property

    Public Property cmsjQueryVariousScripts() As Literal
        Get
            Return litjQueryVariousScripts
        End Get
        Set(ByVal ScriptText As Literal)
            litjQueryVariousScripts = ScriptText
        End Set
    End Property

    Public Property cmsMessagges() As Literal
        Get
            Return litMessagges
        End Get
        Set(ByVal Messagge As Literal)
            litMessagges = Messagge
        End Set
    End Property

    Public Property Tabs() As Literal
        Get
            Return tabsList
        End Get
        Set(ByVal literalTabList As Literal)
            tabsList = literalTabList
        End Set
    End Property

    Public Property PageTitle() As Literal
        Get
            Return PageH1
        End Get
        Set(ByVal literalPageH1 As Literal)
            PageH1 = literalPageH1
        End Set
    End Property

    Private Sub LoadLabels()
        litcmsVersion.Text = " v" & jCMS.cmsSettings.JertixCMSVersion.ToString.Replace(",", ".") & "." & jCMS.cmsSettings.JertixCMSBuild & " .Net " & jCMS.cmsSettings.DotNETFrameworkVersion

        linkLogOut.Text = Admin.linkLogOut
        litUserName.Text = HttpContext.Current.Session("UserName")
        litBenvenuto.Text = Admin.litBenvenuto
        'litRichiediSupporto.Text = Admin.litRichiediSupporto
        'litYear.Text = Year(Now)
        'litTuttiIDiritti.Text = Admin.litTuttiIDiritti
        linkAnteprimaSito.Text = Admin.linkAnteprimaSito

        litAdmin.Text = Admin.litAdmin
    End Sub

    Protected Sub linkLogOut_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles linkLogOut.Click
        myLogin.LogOut()
        Response.Redirect("~/Admin/Login.aspx", False)
    End Sub
End Class

