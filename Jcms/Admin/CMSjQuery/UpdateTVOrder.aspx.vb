Imports Jertix.Functions

Partial Class Admin_CMSjQuery_UpdateTVOrder
    Inherits System.Web.UI.Page

    Dim jCMS As New JertCMSFunctions.JertCMSFunctions

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim idTemplateVariablesInTemplate As Long

        For Each key As String In Request.Form

            Dim IdsArray As Array = Request.Form(key).Split(",")
            Dim TVOrderInTemplate As Long = 1

            For Each elem In IdsArray
                idTemplateVariablesInTemplate = Convert.ToInt32(elem)

                'idTV - OrderNumber
                jCMS.SaveTVOrderInTemplate(idTemplateVariablesInTemplate, TVOrderInTemplate)

                TVOrderInTemplate += 1
            Next

        Next
    End Sub
End Class
