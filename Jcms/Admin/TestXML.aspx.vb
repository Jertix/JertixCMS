Imports Jertix.Functions

Partial Class Admin_TestXML
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim xmlClass As New JertCMSXMLClass
        litXMLFile.Text = xmlClass.ReadXMLFromfile("//root/record", "test.xml")
    End Sub
End Class
