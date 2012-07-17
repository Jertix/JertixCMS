<%@ Application Language="VB" %>

<script runat="server">
    
    Public Shared SiteName As String
    Public Shared SiteAddress As String
    Public Shared ConnString As String
    
    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs on application startup
    End Sub
    
    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs on application shutdown
    End Sub
        
    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when an unhandled error occurs
        'Per evitare la perdita delle sessioni..
        'Server.ClearError()
    End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        Session.Timeout = 600 '10 minuti
        
        ' Code that runs when a new session is started
        
        SiteName = Request.ServerVariables("HTTP_HOST")
        SiteAddress = "http://" & SiteName
        ConnString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Server.MapPath("~/App_Data/Data.mdb") & ";"
        
        Session("JertCMSVersion") = 0.7
        Session("JertCMSBuild") = 5
        
        Session("SiteName") = SiteName
        Session("SiteAddress") = SiteAddress
        Session("ConnString") = ConnString
        
        Session("Logged") = False
        Session("idUser") = ""
        Session("UserName") = ""
        Session("Password") = ""
        Session("Livello") = ""
        Session("idRole") = ""
        
        Session("Lingua") = "it" 'it, en
        Session("LinguaCulture") = "it-IT" 'it-IT,en-GB,..
        Session("IDLingua") = 1 'IT
    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when a session ends. 
        ' Note: The Session_End event is raised only when the sessionstate mode
        ' is set to InProc in the Web.config file. If session mode is set to StateServer 
        ' or SQLServer, the event is not raised.
    End Sub
       
</script>