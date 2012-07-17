Imports Microsoft.VisualBasic
Imports Jertix.Functions
Imports System.Data.OleDb
Imports JertCMSFunctions
Imports System.Collections.Generic

Namespace Jertix.Functions.Menu

    Public Class ClassMenu
        Private mPage As _cmsPage
        Private mMenu As _cmsVoceDiMenu
        Private mSubMenuList As List(Of Menu.ClassMenu)
        Private mHTMLText As String
        Private mOpenMenuTag As String
        Private mCloseMenuTag As String
        Private mCurrentMenuLevel As Integer

        Sub New(ByVal Page As _cmsPage, ByVal Menu As _cmsVoceDiMenu)
            mPage = Page
            mMenu = Menu
            mSubMenuList = New List(Of Menu.ClassMenu)
        End Sub

        Public Property HTMLFullPage() As String
            Set(ByVal HTMLFullPage As String)
                mPage.HTMLFullPage = HTMLFullPage
            End Set
            Get
                Return mPage.HTMLFullPage
            End Get
        End Property

        Public ReadOnly Property NumOfSubMenu() As Integer
            Get
                'If mSubMenuList.Count = 0 Then Return 0
                Return mSubMenuList.Count
            End Get
        End Property

        Public ReadOnly Property SubMenuList(ByVal Index As Integer) As ClassMenu
            Get
                'Return DirectCast(mSubMenuList(0)(Index), ClassMenu)
                Return mSubMenuList(Index)
            End Get
        End Property

        Public Property OpenMenuTag() As String
            Set(ByVal OpenMenuTag As String)
                mOpenMenuTag = OpenMenuTag
            End Set
            Get
                Return mOpenMenuTag
            End Get
        End Property

        Public Property CurrentMenuLevel() As Integer
            Set(ByVal CurrentMenuLevel As Integer)
                mCurrentMenuLevel = CurrentMenuLevel
            End Set
            Get
                Return mCurrentMenuLevel
            End Get
        End Property

        Public Property CloseMenuTag() As String
            Set(ByVal CloseMenuTag As String)
                mCloseMenuTag = CloseMenuTag
            End Set
            Get
                Return mCloseMenuTag
            End Get
        End Property

        Public Property HTMLText() As String
            Set(ByVal HtmlValue As String)
                mHTMLText = HtmlValue
            End Set
            Get
                Return mHTMLText
            End Get
        End Property

        Public WriteOnly Property Add() As List(Of Menu.ClassMenu)
            Set(ByVal MenuItem As List(Of Menu.ClassMenu))
                If MenuItem.Count = 0 Then Exit Property
                mSubMenuList = MenuItem
            End Set
        End Property

        Public Property Page() As _cmsPage
            Set(ByVal page As _cmsPage)
                mPage = page
            End Set
            Get
                Return mPage
            End Get
        End Property

        Public Property Menu() As _cmsVoceDiMenu
            Set(ByVal menu As _cmsVoceDiMenu)
                mMenu = menu
            End Set
            Get
                Return mMenu
            End Get
        End Property

        Public Overrides Function ToString() As String
            Return "Page: " & mPage.Titolo & "(" & mPage.idPagina & ") NumSubMenu: " & mSubMenuList.Count & " HTML: " & mHTMLText
        End Function

    End Class

    Public Class MenuComparer : Implements IComparer(Of ClassMenu)
        Public Function Compare(ByVal Menu1 As ClassMenu, ByVal Menu2 As ClassMenu) As Integer Implements IComparer(Of ClassMenu).Compare
            Dim sign As Integer = +1

            If Menu1.Menu.SortOrder = "desc" Then sign = -1

            Select Case Menu1.Menu.CompareBy
                Case "title" : Return sign * String.Compare(Menu1.Page.TitoloH1, Menu2.Page.TitoloH1)
                Case "long_title" : Return sign * String.Compare(Menu1.Page.Titolo, Menu2.Page.Titolo)
                Case "description" : Return sign * String.Compare(Menu1.Page.MetaDescription, Menu2.Page.MetaDescription)
                Case "menu" : Return sign * String.Compare(Menu1.Menu.DescrizioneBreveNelMenu, Menu2.Menu.DescrizioneBreveNelMenu)
                Case "content" : Return sign * String.Compare(Menu1.Page.HTMLPageContent, Menu2.Page.HTMLPageContent)
                Case "publish_date" : Return sign * String.Compare(Menu1.Page.DataInserimento, Menu2.Page.DataInserimento)
                Case "last_update_date" : Return sign * String.Compare(Menu1.Page.DataUltimaModifica, Menu2.Page.DataUltimaModifica)
                Case "rel_link" : Return sign * String.Compare(Menu1.Menu.folderpath.Replace("\", "/"), Menu2.Menu.folderpath.Replace("\", "/"))
                Case "abs_link" : Return sign * String.Compare("http://" & HttpContext.Current.Session("SiteName") & Menu1.Menu.folderpath.Replace("\", "/"), "http://" & HttpContext.Current.Session("SiteName") & Menu2.Menu.folderpath.Replace("\", "/"))
                Case "website_link" : Return sign * String.Compare(HttpContext.Current.Session("SiteName"), HttpContext.Current.Session("SiteName"))
                Case Else
                    Return sign * String.Compare(Menu1.Menu.ordine, Menu2.Menu.ordine)
            End Select
        End Function
    End Class

    'Case "last_update_date" : retValue = tmpPage.DataUltimaModifica
    'Case "rel_link" : retValue = tmpMenu.folderpath.Replace("\", "/")
    'Case "abs_link" : retValue = "http://" & HttpContext.Current.Session("SiteName") & tmpMenu.folderpath.Replace("\", "/")
    'Case "website_link" : retValue = HttpContext.Current.Session("SiteName")

End Namespace
