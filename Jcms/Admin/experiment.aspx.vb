
Partial Class Admin_experiment
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            btn1.Attributes.Add("onClick", "insertAtCursor(document." & form1.ClientID & "." & txt.ClientID & ", '[jcms: img 11]')")
            btn2.Attributes.Add("onClick", "insertAtCursor(document." & form1.ClientID & "." & txt.ClientID & ", '[jcms: slideshow]')")
            btn3.Attributes.Add("onClick", "insertAtCursor(document." & form1.ClientID & "." & txt.ClientID & ", '[jcms: gallery]')")
            btn4.Attributes.Add("onClick", "insertAtCursor(document." & form1.ClientID & "." & txt.ClientID & ", '[jcms: altro]')")
        End If
    End Sub
End Class
