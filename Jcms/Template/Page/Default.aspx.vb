Imports System.Data.OleDb
Imports System.Data
Imports Jertix.Functions
Imports JertCMSFunctions
Imports System.Reflection

Partial Class _Default
    Inherits System.Web.UI.Page

    'Dim visit As New VisitCounter
    Dim db As New DBFunctions
    Dim myReader As OleDbDataReader
    Dim Sql As String

    Dim cmsPage As _cmsPage

    Dim jCMS As New JertCMSFunctions.JertCMSFunctions

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        Dim LinguaCulture As String = IIf(Request.QueryString("lang") Is Nothing, "", Request.QueryString("lang"))

        jCMS.InitPage(LinguaCulture)
        WriteContent(PlaceContentPage)
    End Sub

    Private Sub WriteContent(Optional ByRef tmpPlaceHolder As PlaceHolder = Nothing)
        Dim pageCache As New Jertix.Cache.JertCMSCache

        Dim tmpMenu As _cmsVoceDiMenu
        tmpMenu = jCMS.GetVoceMenuFromFolderPath(Page.TemplateSourceDirectory.Replace("/", "\"))

        '***************** UnComment to See STATS
        'cmsPage._CMS_Warning = ""
        cmsPage.CacheFound = False
        cmsPage = pageCache.ReadCache(tmpMenu.idVoce)
        'cmsPage._CMS_Stats = ""
        '***************** UnComment to See STATS

        If cmsPage.CacheFound = False Then
            cmsPage = jCMS.JertCMS_ReadAllPage(tmpMenu, True)
        End If

        With cmsPage
            litPageHeader.Text = .HTMLCompletoHeadPagina
            litBodyOpen.Text = .HTMLBodyOpen

            If cmsPage.HaveDetails = False Then
                PlaceContentPage.Controls.Add(New LiteralControl(.HTMLCompletoPagina))
            Else
                Dim tmpControl As Control

                For DetailsArrayCount = 0 To .DetailCount - 1
                    If .TemplateDetail(DetailsArrayCount).ComponentID = 0 Then
                        PlaceContentPage.Controls.Add(New LiteralControl(.TemplateDetail(DetailsArrayCount).Content))
                    Else
                        tmpControl = Page.LoadControl("~\" & jCMS.Paths.AdminModulesPath & .TemplateDetail(DetailsArrayCount).ModuleFolder & "\" & .TemplateDetail(DetailsArrayCount).FileName & "")

                        Dim tmpType As Type = tmpControl.GetType
                        Dim tmpProp As PropertyInfo

                        tmpControl.ID = jCMS.Paths.ComponentsIDPrefix & .TemplateDetail(DetailsArrayCount).CustomID

                        For i As Long = 0 To .TemplateDetail(DetailsArrayCount).AttributesCount - 1
                            tmpProp = tmpType.GetProperty(.TemplateDetail(DetailsArrayCount).AttributesList(i).Name, BindingFlags.Public Or BindingFlags.NonPublic Or BindingFlags.Static Or BindingFlags.Instance Or BindingFlags.IgnoreCase)

                            If Not tmpProp Is Nothing Then
                                tmpProp.SetValue(tmpControl, .TemplateDetail(DetailsArrayCount).AttributesList(i).Value, Nothing)

                                'tmpProp.GetValue(tmpControl, Nothing)
                            End If
                        Next

                        PlaceContentPage.Controls.Add(tmpControl)
                    End If
                Next
            End If

            litBodyClose.Text = .HTMLBodyClose

            '***************** UnComment to See STATS
            'If ._CMS_Stats.Length > 0 Then
            '    Dim txtStats As String = ._CMS_Stats & " <br /><br />"
            '    txtStats &= ""
            '    PlaceContentPage.Controls.Add(New LiteralControl(txtStats))
            '    litPageHeader.Text = ""
            '    litBodyOpen.Text = ""
            '    litBodyClose.Text = ""
            '    Exit Sub
            'End If
            '***************** UnComment to See STATS

            If Not IsNothing(._CMS_Warning) AndAlso ._CMS_Warning.Length > 0 Then
                Dim txtWarning As String = ""
                txtWarning = ._CMS_Warning & " <br /><br />Time: " & jCMS.PageInfo.m_Date
                txtWarning &= "<br /><br />*************************************** PAGE ***************************************<br />" & .HTMLFullPage.Replace("<", "&lt;").Replace(">", "&gt;").Replace(vbCrLf, "<br/>")
                PlaceContentPage.Controls.Add(New LiteralControl(txtWarning))
                litPageHeader.Text = ""
                litBodyOpen.Text = ""
                litBodyClose.Text = ""
            End If

        End With

    End Sub
End Class
