Imports Microsoft.VisualBasic
Imports Jertix.Functions
Imports System.Data.OleDb
Imports System.Threading
Imports System.Web.HttpContext
Imports System.Globalization
Imports System.Drawing.Imaging
Imports System.Web.Hosting
Imports System.IO
Imports FredCK
Imports System.Collections.Generic

Namespace JertCMSFunctions

    Public Structure _cms_MenuQueryStrings
        Dim Action As String
        Dim PageType As String
        Dim MenuLang As String
        Dim idPage As String
        Dim codPage As String
        Dim idTemplate As String
        Dim idVoce As String
        Dim codPageMother As String
        Dim ProfonditaLivello As String
    End Structure

    Public Structure _cmsMenuCssClasses
        Dim first As Boolean
        Dim last As Boolean
        Dim level As Boolean
        Dim active As Boolean
        Dim parent As Boolean
        Dim id As Boolean
    End Structure

    Public Structure _cmsTemplate
        Dim idTemplate As Long
        Dim Nome As String
        Dim Header As String
        Dim BodyTagOpen As String
        Dim Content As String
        Dim BodyTagClose As String
        Dim Footer As String
    End Structure

    Public Structure _cmsTemplateDetail
        Dim id As Long
        Dim idTemplate As Long
        Dim TemplateDetailOrder As Long
        Dim Content As String
        Dim ComponentID As Long

        Dim CustomID As String

        '***** Module
        Dim ComponentName As String
        Dim FileName As String
        Dim Name As String
        Dim ModuleFolder As String

        Dim HaveAttributes As Boolean
        Dim AttributesCount As Long

        Dim AttributesList() As _cmsTemplateDetailAttributes
    End Structure

    Public Structure _cmsTemplateDetailAttributes
        Dim id As Long
        Dim idTemplateDetail As Long
        Dim Name As String
        Dim Value As String
    End Structure

    Public Structure _cmsChunksCategoryInfo
        Dim idCategory As Long
        Dim NumberOfChunks As Long
    End Structure

    Public Structure _cmsGeneratedMenuResult
        Dim TotalElements As Long
        Dim NumElements As Long
        Dim HTMLResult As String
        Dim MenuItem As Menu.ClassMenu
    End Structure

    Public Structure _cmsTVCategoryInfo
        Dim idCategory As Long
        Dim NumberOfTVs As Long
    End Structure

    Public Structure _cms_MenuParameters
        Dim queryAND As String

        Dim ActionEdit As Long
        Dim ActionAdd As Long

        Dim PageTypeHome As Long
        Dim PageTypeGeneric As Long
    End Structure

    Public Structure _cms_Settings
        Dim JertixCMSVersion As Double
        Dim JertixCMSBuild As Double
        Dim DotNETFrameworkVersion As String
    End Structure

    Public Structure _cms_AdminMenuTree
        Dim HTMLMenu As String
        Dim HTMLContextMenu As String

        Dim jQueryFunctions As String

        Dim isNewTree As Boolean
    End Structure

    Public Structure _cms_AdminAdministratorMenuTree
        Dim HTMLMenu As String
        Dim HTMLContextMenu As String

        Dim jQueryFunctions As String
    End Structure

    Public Structure _cms_IdOfAdministratorMenuTree
        Dim TemplateID As Long
        Dim TemplateName As String

        Dim ChunksID As Long
        Dim ChunksName As String

        Dim TemplateVariablesID As Long
        Dim TemplateVariableName As String
    End Structure

    Public Structure _cms_TipiDiPagine
        Dim PaginaNormale As Long
        Dim DettaglioGalleriaFotografica As Long
        Dim Tutte As Long
    End Structure

    Public Structure _cms_Immagine
        Dim idImmagine As Long
        Dim codPagina As Long

        Dim Aid As String
        Dim Aclass As String
        Dim Ahref As String
        Dim ADescrizione As String

        Dim IMGsrc As String
        Dim IMGalt As String
        Dim IMGtitle As String
        Dim IMGclass As String

        Dim SlideTitolo As String
        Dim SlideDescrizione As String
        Dim SlideOrder As Long

        Dim Orizzontal As Boolean
    End Structure

    Public Structure _cms_Gallery_Image
        Dim id As Long
        Dim idGallery As Long
        Dim ImageAlt As String
        Dim ImageTitle As String
        Dim InsertionDate As Date
        Dim Orizzontal As Boolean
        Dim Posizione As Long
    End Structure


    Public Structure _cms_Paths
        Dim PathGallery As String
        Dim PathImagesPages As String
        Dim PathGlobal As String
        Dim PathVideos As String
        Dim PathFiles As String

        Dim PathPublic As String

        Dim PathTemplatePage As String
        Dim PathUploadedFiles As String
        Dim PathCache As String

        Dim ComponentsIDPrefix As String

        Dim TemplatePageName As String
        Dim TemplatePageCodeName As String
        Dim AdminModulesPath As String

    End Structure

    Public Structure _cms_PageInfo
        Public m_PATH_INFO As String
        Public m_REMOTE_HOST As String
        Public m_SERVER_SOFTWARE As String
        Public m_URL As String
        Public m_HTTP_ACCEPT_LANGUAGE As String
        Public m_HTTP_HOST As String
        Public m_SCRIPT_NAME As String
        Public m_HTTP_REFERER As String
        Public m_HTTP_USER_AGENT As String

        Public m_Date As DateTime
    End Structure

    Public Structure _cmsLanguage
        Dim idLingua As Long
        Dim Lingua As String
        Dim LinguaCultura As String
    End Structure

    Public Structure _cmsMenuPages
        Dim Page As _cmsPage
        Dim Menu As _cmsVoceDiMenu
    End Structure

    Public Structure _cmsVoceDiMenu
        Dim idVoce As Long
        Dim ProfonditaLivello As Long
        Dim codPagina As Long
        Dim DescrizioneBreveNelMenu As String
        Dim codPaginaMadre As Long
        Dim idLingua As Long
        Dim ordine As Long
        Dim folderpath As String

        'Flag vari temporanei
        Dim NuovaPagina As Boolean

        Dim CompareBy As String
        Dim SortOrder As String
    End Structure

    Public Structure _cmsPage
        Dim idPagina As Long
        Dim codPagina As Long
        Dim filename As String
        Dim idLingua As Long
        Dim Titolo As String
        Dim TitoloH1 As String
        Dim MetaDescription As String
        Dim DataInserimento As Date
        Dim DataUltimaModifica As Date
        Dim LivelloVisibilita As Long
        Dim Tipo As Long

        Dim HTMLPageContent As String 'TV Contenutoprincipale pagina.

        Dim VoceDiMenu As String
        Dim idVoce As Long

        '********* Template
        Dim idTemplate As Long
        Dim HaveDetails As Boolean
        Dim DetailCount As Long
        Dim TemplateDetail() As _cmsTemplateDetail
        '********* Template

        Dim NomeTemplate As String

        Dim _CMS_Warning As String
        Dim _CMS_Stats As String

        Dim HTMLCompletoHeadPagina As String
        Dim HTMLBodyOpen As String
        Dim HTMLCompletoPagina As String
        Dim HTMLBodyClose As String

        Dim HTMLFullPage As String

        'Ottimizzazioni
        Dim FolderPath As String
        Dim DescrizioneBreveNelMenu As String

        'Flag vari temporanei
        Dim NuovaPagina As Boolean
        Dim CacheFound As Boolean
        Dim PageFound As Boolean

        Public PageQueryParameters As _cms_MenuQueryStrings

        'Messaggi di Errore...
        Dim idErrore As Long
        Dim MessaggioDiErrore As String
    End Structure

    Public Structure _cmsTemplateVariablesTypes
        Dim Text As String
        Dim TextArea As String
        Dim TextAreaEditor As String
        Dim Image As String
        Dim Link As String
        Dim Video As String
        Dim Number As String
        Dim [Date] As String

        Dim TextID As Long
        Dim TextAreaID As Long
        Dim TextAreaEditorID As Long
        Dim ImageID As Long
        Dim LinkID As Long
        Dim VideoID As Long
        Dim NumberID As Long
        Dim DateID As Long

        Dim TVPrefix As String
    End Structure

    Public Structure _cmsChunkVariable
        Dim idVariablie As Long
        Dim idCategoria As Long
        Dim NomeVariabile As String
        Dim Contenuto As String
    End Structure

    Public Structure _cmsTVVariable
        Dim idTV As Long
        Dim Name As String
        Dim Caption As String
        Dim Description As String
        Dim idTVCategoria As Long
        Dim Type As Long
        Dim Inherit As Boolean
        Dim OuterTVHtml As String
        Dim HideIfEmpty As Boolean
    End Structure

    Public Class JertCMSFunctions

        Private Const idSelezioneZero As Long = 0
        Private Const idSelezioneNulla As Long = -1
        Private Selezionare As String = GetGlobalResourceObject("Admin", "Select")

        Dim db As New DBFunctions
        Dim myReader As OleDbDataReader
        Dim Sql As String

        Dim jModule As New jCMSModules.jertCMSModules

        Dim myDir As New DirectoryManipulation
        Dim myFile As New FileManipulation
        Dim myPictManip As New ImageManipulation
        Dim myPictInf As New ImageInfo
        Dim myRegex As New RegExClass

        Public cmsSettings As _cms_Settings
        Public cmsPage As _cmsPage

        Public cmsMenuQueryStrings As _cms_MenuQueryStrings
        Public cmsMenuParameters As _cms_MenuParameters

        Private cmsLanguage As _cmsLanguage
        Private m_pageInfo As _cms_PageInfo
        Private cmsPaths As _cms_Paths
        Private cmsVoceMenu As _cmsVoceDiMenu
        Private cmsTipiDiPagine As _cms_TipiDiPagine

        Dim cmsTemplateVariablesTypes As _cmsTemplateVariablesTypes

        Private cms_IdOfAdministratorMenuTree As _cms_IdOfAdministratorMenuTree

        Public Sub New()
            cmsPaths.PathGallery = "_cms_gallery\"
            cmsPaths.PathImagesPages = "_cms_images\"
            cmsPaths.PathGlobal = "_global\"
            cmsPaths.PathVideos = "_cms_videos\"
            cmsPaths.PathFiles = "_cms_files\"

            cmsPaths.PathPublic = "\public\"

            cmsPaths.AdminModulesPath = "Admin\Modules\"


            cmsPaths.PathTemplatePage = "\Template\Page\"
            cmsPaths.TemplatePageName = "Default.aspx"
            cmsPaths.TemplatePageCodeName = cmsPaths.TemplatePageName & ".vb"

            cmsPaths.PathUploadedFiles = "_cms_Files\"
            cmsPaths.PathCache = "_cms_Cache\"

            cmsPaths.ComponentsIDPrefix = "jComp_"

            cmsTipiDiPagine.PaginaNormale = 1
            cmsTipiDiPagine.DettaglioGalleriaFotografica = 2
            cmsTipiDiPagine.Tutte = 3
        End Sub

        Public Sub InitPage(Optional ByVal LinguaCulture As String = "", Optional ByVal HideErrors As Boolean = False)
            'TODO filtrare LinguaCulture se è troppo lunga o non valida..

            If Not HideErrors Then InitMenuQueryStrings()

            InitLanguage(LinguaCulture)
            If Not HideErrors Then InitPageInfo()

            If Not HideErrors Then InitAdministratorMenuID()
            If Not HideErrors Then InitTemplateVariableList()
        End Sub

        Public Sub CloseDB()
            db.CloseConn()
        End Sub

        Private Sub InitMenuQueryStrings()
            With cmsMenuQueryStrings
                .Action = "Action"
                .PageType = "PageType"
                .MenuLang = "MenuLang"
                .idPage = "Page"
                .codPage = "CodPage"
                .idTemplate = "idTemplate"
                .idVoce = "idVoce"
                .codPageMother = "codPageMother"
                .ProfonditaLivello = "depth"
            End With

            Dim startIDIndex As Long = 1

            With cmsMenuParameters
                .queryAND = "&amp;"

                .ActionAdd = startIDIndex
                startIDIndex += 1

                .ActionEdit = startIDIndex
                startIDIndex += 1

                .PageTypeHome = startIDIndex
                startIDIndex += 1

                .PageTypeGeneric = startIDIndex
                startIDIndex += 1
            End With
        End Sub

        Public ReadOnly Property MenuQueryStrings() As _cms_MenuQueryStrings
            Get
                Return cmsMenuQueryStrings
            End Get
        End Property
        Public ReadOnly Property MenuParameters() As _cms_MenuParameters
            Get
                Return cmsMenuParameters
            End Get
        End Property

        Private Sub InitTemplateVariableList()
            Dim startIDIndex As Long = 1

            With cmsTemplateVariablesTypes
                .TVPrefix = "TV_"


                .Date = GetGlobalResourceObject("Admin", "TemplateVariableDate")
                .DateID = startIDIndex
                startIDIndex += 1

                .Image = GetGlobalResourceObject("Admin", "TemplateVariableImage")
                .ImageID = startIDIndex
                startIDIndex += 1

                .Link = GetGlobalResourceObject("Admin", "TemplateVariableLink")
                .LinkID = startIDIndex
                startIDIndex += 1

                .Number = GetGlobalResourceObject("Admin", "TemplateVariableNumber")
                .NumberID = startIDIndex
                startIDIndex += 1

                .Text = GetGlobalResourceObject("Admin", "TemplateVariableText")
                .TextID = startIDIndex
                startIDIndex += 1

                .TextArea = GetGlobalResourceObject("Admin", "TemplateVariableTextArea")
                .TextAreaID = startIDIndex
                startIDIndex += 1

                .TextAreaEditor = GetGlobalResourceObject("Admin", "TemplateVariableTextAreaEditor")
                .TextAreaEditorID = startIDIndex
                startIDIndex += 1

                .Video = GetGlobalResourceObject("Admin", "TemplateVariableVideo")
                .VideoID = startIDIndex
                startIDIndex += 1

            End With
        End Sub

        Private Sub InitAdministratorMenuID()
            Dim startIDIndex As Long = 50000

            With cms_IdOfAdministratorMenuTree
                .TemplateID = startIDIndex
                .TemplateName = GetGlobalResourceObject("Admin", "TemplateName")
                startIDIndex += 1

                .ChunksID = startIDIndex
                .ChunksName = GetGlobalResourceObject("Admin", "ChunksName")
                startIDIndex += 1

                .TemplateVariablesID = startIDIndex
                .TemplateVariableName = GetGlobalResourceObject("Admin", "TemplateVariableName")
                startIDIndex += 1
            End With
        End Sub

        Public Property SiteLanguage() As _cmsLanguage
            Get
                Return cmsLanguage
            End Get
            Set(ByVal LanguageStructure As _cmsLanguage)
                cmsLanguage = LanguageStructure
            End Set
        End Property

        Public ReadOnly Property TipiDiPagine() As _cms_TipiDiPagine
            Get
                Return cmsTipiDiPagine
            End Get
        End Property

        Public ReadOnly Property TipiDiVariabiliTemplate() As _cmsTemplateVariablesTypes
            Get
                Return cmsTemplateVariablesTypes
            End Get
        End Property

        Public ReadOnly Property Paths() As _cms_Paths
            Get
                Return cmsPaths
            End Get
        End Property

        Public ReadOnly Property Settings() As _cms_Settings
            Get
                Return cmsSettings
            End Get
        End Property

        Public ReadOnly Property PageInfo() As _cms_PageInfo
            Get
                Return m_pageInfo
            End Get
        End Property

        Private Sub InitPageInfo()
            cmsSettings.JertixCMSVersion = Current.Session("JertCMSVersion")
            cmsSettings.JertixCMSBuild = Current.Session("JertCMSBuild")
            cmsSettings.DotNETFrameworkVersion = Environment.Version.Major

            'Dim myCI As New CultureInfo(cmsLanguage.LinguaCultura)
            'Dim culture As CultureInfo = CultureInfo.GetCultureInfo(cmsLanguage.LinguaCultura)

            'myCI.DateTimeFormat.DateSeparator = culture.DateTimeFormat.DateSeparator
            'myCI.DateTimeFormat.ShortDatePattern = culture.DateTimeFormat.ShortDatePattern

            'Dim myDate As DateTime
            'Try
            '    myDate = DateTime.Parse(DateAndTime.Now, myCI)
            'Catch ex As Exception
            '    Try
            '        myDate = DateTime.ParseExact(DateAndTime.Now.Date, "dd/mm/yyyy", myCI)
            '    Catch ex2 As Exception
            '        myDate = Now ' DateTime.ParseExact(DateAndTime.Now.Date, "mm/dd/yyyy", myCI)
            '    End Try
            'End Try

            'With m_pageInfo
            '    .m_Date = myDate
            '    .m_HTTP_ACCEPT_LANGUAGE = HttpContext.Current.Request("HTTP_ACCEPT_LANGUAGE")
            '    .m_HTTP_HOST = HttpContext.Current.Request("HTTP_HOST")
            '    .m_REMOTE_HOST = HttpContext.Current.Request("REMOTE_HOST")
            '    .m_SCRIPT_NAME = HttpContext.Current.Request("SCRIPT_NAME")
            '    .m_SERVER_SOFTWARE = HttpContext.Current.Request("SERVER_SOFTWARE")
            '    .m_URL = HttpContext.Current.Request("URL")

            '    .m_HTTP_REFERER = ""
            '    .m_HTTP_USER_AGENT = ""
            '    .m_PATH_INFO = ""

            '    If (Not (System.Web.HttpContext.Current.Request.UrlReferrer) Is Nothing) Then
            '        .m_HTTP_REFERER = IIf(HttpContext.Current.Request.UrlReferrer Is Nothing, "", HttpContext.Current.Request.UrlReferrer.ToString)
            '    End If

            '    If (Not (System.Web.HttpContext.Current.Request.UserAgent) Is Nothing) Then
            '        .m_HTTP_USER_AGENT = IIf(HttpContext.Current.Request.UserAgent Is Nothing, "", HttpContext.Current.Request.UserAgent.ToString)
            '    End If

            '    If (Not (System.Web.HttpContext.Current.Request.PathInfo) Is Nothing) Then
            '        .m_PATH_INFO = IIf(HttpContext.Current.Request.PathInfo Is Nothing, "", HttpContext.Current.Request.PathInfo)
            '    End If
            'End With
        End Sub

        Private Function GetLanguageNameFromPagePath(ByVal pagePath As String, Optional ByVal LinguaTwoDigidits As String = "") As String
            Dim retValue As String = ""
            Dim tmpPublicPath As String = cmsPaths.PathPublic.Replace("\", "/")

            If pagePath.Length > tmpPublicPath.Length Then
                If pagePath.StartsWith(tmpPublicPath) Then
                    pagePath = pagePath.Remove(0, tmpPublicPath.Length)
                    retValue = pagePath.Substring(0, pagePath.IndexOf("/"))
                End If
            End If
            If pagePath = "/" Then
                retValue = LinguaTwoDigidits
            End If

            Return retValue
        End Function

        Private Sub InitLanguage(Optional ByVal LinguaCulture As String = "")
            'Non utilizzare in Sub New
            Dim Lang As String = Thread.CurrentThread.CurrentCulture.ToString
            Dim tmpLang As String = ""


            If LinguaCulture.Length = 0 Then
                Dim pagePath As String = HttpContext.Current.Request("SCRIPT_NAME")
                tmpLang = GetLanguageNameFromPagePath(pagePath)
                If tmpLang.Length > 0 Then
                    Dim culture As CultureInfo = CultureInfo.CreateSpecificCulture(tmpLang)
                    Lang = CultureInfo.CreateSpecificCulture(culture.Name).Name
                End If
                If Lang.Length > 0 Then
                    Dim culture As CultureInfo = CultureInfo.CreateSpecificCulture(Lang)
                    Lang = CultureInfo.CreateSpecificCulture(culture.Name).Name
                End If
            End If

            If LinguaCulture.Length > 0 Then
                'TODO da fare meglio...
                If LinguaCulture.Length <= 3 Then
                    Dim culture As CultureInfo = CultureInfo.CreateSpecificCulture(LinguaCulture)
                    LinguaCulture = CultureInfo.CreateSpecificCulture(culture.Name).Name
                End If

                Lang = LinguaCulture
            End If

            Current.Session("IDLingua") = GetIdLanguageFromName(Lang.Substring(0, 2).ToLower)
            Current.Session("Lingua") = Lang.Substring(0, 2).ToLower
            Current.Session("LinguaCulture") = Lang

            cmsLanguage.idLingua = Current.Session("IDLingua")
            cmsLanguage.Lingua = Current.Session("Lingua")
            cmsLanguage.LinguaCultura = Current.Session("LinguaCulture")
        End Sub

        Public Function JertCMS_ReadAllPage(ByRef Menu As _cmsVoceDiMenu, Optional ByVal HideErrors As Boolean = False) As _cmsPage
            '********************************************************************************
            'Prima delle ottimizzazioni...
            '********************************************************************************
            'Lettura contenuti di pagina in: 0.078
            'Verifica Chunks in: 0.546
            'Lettura comandi List in: 0.562
            'Lettura comando Menu in: 5.788
            'Lettura TV in: 0
            'Lettura TVPage in: 0.592
            'Verifica presenza errori in: 0
            'Tempo TOTALE: 7.566
            '********************************************************************************


            Dim tmpDbCommand As New OleDbCommand
            Dim tmpDbConnection As New OleDbConnection

            HideErrors = True

            Dim StartTime As Integer
            Dim EndTime As Integer
            Dim ExecutionTime As Double

            Dim GlobalStart As Integer
            Dim GlobalEnd As Integer

            Dim DetailsArrayCount As Long = 0
            Dim DetailsAttributesCount As Long = 0

            Dim tmpFullPage As String


            cmsPage._CMS_Stats = ""
            cmsPage.HTMLFullPage = ""

            StartTime = Environment.TickCount
            GlobalStart = StartTime

            '*************************************************************************************************************************
            '************ PAGE CONTENT
            '*************************************************************************************************************************
            JertCMS_ReadPageContent(Menu, cmsPage, , tmpDbCommand, tmpDbConnection)
            EndTime = Environment.TickCount
            ExecutionTime = Convert.ToDouble((EndTime - StartTime)) / 1000.0
            cmsPage._CMS_Stats &= "Lettura contenuti di pagina in: " & ExecutionTime & "<br />"

            If cmsPage.PageFound Then
                '*************************************************************************************************************************
                '************ START PAGEFOUND
                '*************************************************************************************************************************


                '*************************************************************************************************************************
                '************ CHUNKS
                '*************************************************************************************************************************
                StartTime = Environment.TickCount
                If cmsPage.HaveDetails = False Then
                    ParseChuhnksVars(cmsPage, Menu, False, False, 0, HideErrors, tmpDbCommand, tmpDbConnection)
                Else
                    With cmsPage
                        tmpFullPage = .HTMLFullPage

                        .HTMLFullPage = .HTMLCompletoHeadPagina
                        ParseChuhnksVars(cmsPage, Menu, False, False, 0, HideErrors, tmpDbCommand, tmpDbConnection)
                        .HTMLCompletoHeadPagina = .HTMLFullPage

                        .HTMLFullPage = .HTMLBodyOpen
                        ParseChuhnksVars(cmsPage, Menu, False, False, 0, HideErrors, tmpDbCommand, tmpDbConnection)
                        .HTMLBodyOpen = .HTMLFullPage

                        .HTMLFullPage = .HTMLBodyClose
                        ParseChuhnksVars(cmsPage, Menu, False, False, 0, HideErrors, tmpDbCommand, tmpDbConnection)
                        .HTMLBodyClose = .HTMLFullPage

                        For DetailsArrayCount = 0 To .DetailCount - 1
                            If .TemplateDetail(DetailsArrayCount).ComponentID = 0 Then
                                .HTMLFullPage = .TemplateDetail(DetailsArrayCount).Content
                                ParseChuhnksVars(cmsPage, Menu, False, False, 0, HideErrors, tmpDbCommand, tmpDbConnection)
                                .TemplateDetail(DetailsArrayCount).Content = .HTMLFullPage
                            Else
                                For DetailsAttributesCount = 0 To .TemplateDetail(DetailsArrayCount).AttributesCount - 1
                                    .HTMLFullPage = .TemplateDetail(DetailsArrayCount).AttributesList(DetailsAttributesCount).Value
                                    ParseChuhnksVars(cmsPage, Menu, False, False, 0, HideErrors, tmpDbCommand, tmpDbConnection)
                                    .TemplateDetail(DetailsArrayCount).AttributesList(DetailsAttributesCount).Value = .HTMLFullPage
                                Next
                            End If
                        Next

                        .HTMLFullPage = tmpFullPage
                    End With
                End If
                EndTime = Environment.TickCount
                ExecutionTime = Convert.ToDouble((EndTime - StartTime)) / 1000.0
                cmsPage._CMS_Stats &= "Verifica Chunks in: " & ExecutionTime & "<br />"


                '*************************************************************************************************************************
                '************ TEMPLATE VARS - RIPETUTO!!
                '*************************************************************************************************************************
                StartTime = Environment.TickCount
                If cmsPage.HaveDetails = False Then
                    ParseTemplateVars(cmsPage, Menu, False, False, 0, HideErrors, tmpDbCommand, tmpDbConnection)
                Else
                    With cmsPage
                        tmpFullPage = .HTMLFullPage

                        .HTMLFullPage = .HTMLCompletoHeadPagina
                        ParseTemplateVars(cmsPage, Menu, False, False, 0, HideErrors, tmpDbCommand, tmpDbConnection)
                        .HTMLCompletoHeadPagina = .HTMLFullPage

                        .HTMLFullPage = .HTMLBodyOpen
                        ParseTemplateVars(cmsPage, Menu, False, False, 0, HideErrors, tmpDbCommand, tmpDbConnection)
                        .HTMLBodyOpen = .HTMLFullPage

                        .HTMLFullPage = .HTMLBodyClose
                        ParseTemplateVars(cmsPage, Menu, False, False, 0, HideErrors, tmpDbCommand, tmpDbConnection)
                        .HTMLBodyClose = .HTMLFullPage

                        For DetailsArrayCount = 0 To .DetailCount - 1
                            If .TemplateDetail(DetailsArrayCount).ComponentID = 0 Then
                                .HTMLFullPage = .TemplateDetail(DetailsArrayCount).Content
                                ParseTemplateVars(cmsPage, Menu, False, False, 0, HideErrors, tmpDbCommand, tmpDbConnection)
                                .TemplateDetail(DetailsArrayCount).Content = .HTMLFullPage
                            Else
                                For DetailsAttributesCount = 0 To .TemplateDetail(DetailsArrayCount).AttributesCount - 1
                                    .HTMLFullPage = .TemplateDetail(DetailsArrayCount).AttributesList(DetailsAttributesCount).Value
                                    ParseTemplateVars(cmsPage, Menu, False, False, 0, HideErrors, tmpDbCommand, tmpDbConnection)
                                    .TemplateDetail(DetailsArrayCount).AttributesList(DetailsAttributesCount).Value = .HTMLFullPage
                                Next
                            End If
                        Next

                        .HTMLFullPage = tmpFullPage
                    End With
                End If
                EndTime = Environment.TickCount
                ExecutionTime = Convert.ToDouble((EndTime - StartTime)) / 1000.0
                cmsPage._CMS_Stats &= "Lettura TV in: " & ExecutionTime & "<br />"

                '*************************************************************************************************************************
                '************ PAGE VARS - RIPETUTO!! - INNER es: {jcms type=[tvpage] name=[querystring] value=[filter] prefix=[?filter=] /}
                '*************************************************************************************************************************
                StartTime = Environment.TickCount
                If cmsPage.HaveDetails = False Then
                    ParsePageVars(cmsPage, Menu, , , , HideErrors, tmpDbCommand, tmpDbConnection, "{jcms", "/}", "\[", "\]")
                    ParsePageVars(cmsPage, Menu, , , , HideErrors, tmpDbCommand, tmpDbConnection)
                Else
                    With cmsPage
                        tmpFullPage = .HTMLFullPage

                        .HTMLFullPage = .HTMLCompletoHeadPagina
                        ParsePageVars(cmsPage, Menu, , , , HideErrors, tmpDbCommand, tmpDbConnection, "{jcms", "/}", "\[", "\]")
                        ParsePageVars(cmsPage, Menu, , , , HideErrors, tmpDbCommand, tmpDbConnection)
                        .HTMLCompletoHeadPagina = .HTMLFullPage

                        .HTMLFullPage = .HTMLBodyOpen
                        ParsePageVars(cmsPage, Menu, , , , HideErrors, tmpDbCommand, tmpDbConnection, "{jcms", "/}", "\[", "\]")
                        ParsePageVars(cmsPage, Menu, , , , HideErrors, tmpDbCommand, tmpDbConnection)
                        .HTMLBodyOpen = .HTMLFullPage

                        .HTMLFullPage = .HTMLBodyClose
                        ParsePageVars(cmsPage, Menu, , , , HideErrors, tmpDbCommand, tmpDbConnection, "{jcms", "/}", "\[", "\]")
                        ParsePageVars(cmsPage, Menu, , , , HideErrors, tmpDbCommand, tmpDbConnection)
                        .HTMLBodyClose = .HTMLFullPage

                        For DetailsArrayCount = 0 To .DetailCount - 1
                            If .TemplateDetail(DetailsArrayCount).ComponentID = 0 Then
                                .HTMLFullPage = .TemplateDetail(DetailsArrayCount).Content
                                ParsePageVars(cmsPage, Menu, , , , HideErrors, tmpDbCommand, tmpDbConnection, "{jcms", "/}", "\[", "\]")
                                ParsePageVars(cmsPage, Menu, , , , HideErrors, tmpDbCommand, tmpDbConnection)
                                .TemplateDetail(DetailsArrayCount).Content = .HTMLFullPage
                            Else
                                For DetailsAttributesCount = 0 To .TemplateDetail(DetailsArrayCount).AttributesCount - 1
                                    .HTMLFullPage = .TemplateDetail(DetailsArrayCount).AttributesList(DetailsAttributesCount).Value
                                    ParsePageVars(cmsPage, Menu, , , , HideErrors, tmpDbCommand, tmpDbConnection, "{jcms", "/}", "\[", "\]")
                                    ParsePageVars(cmsPage, Menu, , , , HideErrors, tmpDbCommand, tmpDbConnection)
                                    .TemplateDetail(DetailsArrayCount).AttributesList(DetailsAttributesCount).Value = .HTMLFullPage
                                Next
                            End If
                        Next

                        .HTMLFullPage = tmpFullPage
                    End With
                End If
                EndTime = Environment.TickCount
                ExecutionTime = Convert.ToDouble((EndTime - StartTime)) / 1000.0
                cmsPage._CMS_Stats &= "Lettura TVPage in: " & ExecutionTime & "<br />"


                '*************************************************************************************************************************
                '************ LIST COMMAND
                '*************************************************************************************************************************
                StartTime = Environment.TickCount
                If cmsPage.HaveDetails = False Then
                    ParseListCommands(cmsPage, Menu, HideErrors, tmpDbCommand, tmpDbConnection)
                Else
                    With cmsPage
                        tmpFullPage = .HTMLFullPage

                        .HTMLFullPage = .HTMLCompletoHeadPagina
                        ParseListCommands(cmsPage, Menu, HideErrors, tmpDbCommand, tmpDbConnection)
                        .HTMLCompletoHeadPagina = .HTMLFullPage

                        .HTMLFullPage = .HTMLBodyOpen
                        ParseListCommands(cmsPage, Menu, HideErrors, tmpDbCommand, tmpDbConnection)
                        .HTMLBodyOpen = .HTMLFullPage

                        .HTMLFullPage = .HTMLBodyClose
                        ParseListCommands(cmsPage, Menu, HideErrors, tmpDbCommand, tmpDbConnection)
                        .HTMLBodyClose = .HTMLFullPage

                        For DetailsArrayCount = 0 To .DetailCount - 1
                            If .TemplateDetail(DetailsArrayCount).ComponentID = 0 Then
                                .HTMLFullPage = .TemplateDetail(DetailsArrayCount).Content
                                ParseListCommands(cmsPage, Menu, HideErrors, tmpDbCommand, tmpDbConnection)
                                .TemplateDetail(DetailsArrayCount).Content = .HTMLFullPage
                            Else
                                For DetailsAttributesCount = 0 To .TemplateDetail(DetailsArrayCount).AttributesCount - 1
                                    .HTMLFullPage = .TemplateDetail(DetailsArrayCount).AttributesList(DetailsAttributesCount).Value
                                    ParseListCommands(cmsPage, Menu, HideErrors, tmpDbCommand, tmpDbConnection)
                                    .TemplateDetail(DetailsArrayCount).AttributesList(DetailsAttributesCount).Value = .HTMLFullPage
                                Next
                            End If
                        Next

                        .HTMLFullPage = tmpFullPage
                    End With
                End If
                EndTime = Environment.TickCount
                ExecutionTime = Convert.ToDouble((EndTime - StartTime)) / 1000.0
                cmsPage._CMS_Stats &= "Lettura comandi List in: " & ExecutionTime & "<br />"

                '*************************************************************************************************************************
                '************ MENU COMMAND
                '*************************************************************************************************************************
                StartTime = Environment.TickCount
                If cmsPage.HaveDetails = False Then
                    ParseMenuCommands(cmsPage, Menu, HideErrors, tmpDbCommand, tmpDbConnection)
                Else
                    With cmsPage
                        tmpFullPage = .HTMLFullPage

                        .HTMLFullPage = .HTMLCompletoHeadPagina
                        ParseMenuCommands(cmsPage, Menu, HideErrors, tmpDbCommand, tmpDbConnection)
                        .HTMLCompletoHeadPagina = .HTMLFullPage

                        .HTMLFullPage = .HTMLBodyOpen
                        ParseMenuCommands(cmsPage, Menu, HideErrors, tmpDbCommand, tmpDbConnection)
                        .HTMLBodyOpen = .HTMLFullPage

                        .HTMLFullPage = .HTMLBodyClose
                        ParseMenuCommands(cmsPage, Menu, HideErrors, tmpDbCommand, tmpDbConnection)
                        .HTMLBodyClose = .HTMLFullPage

                        For DetailsArrayCount = 0 To .DetailCount - 1
                            If .TemplateDetail(DetailsArrayCount).ComponentID = 0 Then
                                .HTMLFullPage = .TemplateDetail(DetailsArrayCount).Content
                                ParseMenuCommands(cmsPage, Menu, HideErrors, tmpDbCommand, tmpDbConnection)
                                .TemplateDetail(DetailsArrayCount).Content = .HTMLFullPage
                            Else
                                For DetailsAttributesCount = 0 To .TemplateDetail(DetailsArrayCount).AttributesCount - 1
                                    .HTMLFullPage = .TemplateDetail(DetailsArrayCount).AttributesList(DetailsAttributesCount).Value
                                    ParseMenuCommands(cmsPage, Menu, HideErrors, tmpDbCommand, tmpDbConnection)
                                    .TemplateDetail(DetailsArrayCount).AttributesList(DetailsAttributesCount).Value = .HTMLFullPage
                                Next
                            End If
                        Next

                        .HTMLFullPage = tmpFullPage
                    End With
                End If
                EndTime = Environment.TickCount
                ExecutionTime = Convert.ToDouble((EndTime - StartTime)) / 1000.0
                cmsPage._CMS_Stats &= "Lettura comando Menu in: " & ExecutionTime & "<br />"

                '*************************************************************************************************************************
                '************ TEMPLATE VARS
                '*************************************************************************************************************************
                StartTime = Environment.TickCount
                If cmsPage.HaveDetails = False Then
                    ParseTemplateVars(cmsPage, Menu, False, False, 0, HideErrors, tmpDbCommand, tmpDbConnection)
                Else
                    With cmsPage
                        tmpFullPage = .HTMLFullPage

                        .HTMLFullPage = .HTMLCompletoHeadPagina
                        ParseTemplateVars(cmsPage, Menu, False, False, 0, HideErrors, tmpDbCommand, tmpDbConnection)
                        .HTMLCompletoHeadPagina = .HTMLFullPage

                        .HTMLFullPage = .HTMLBodyOpen
                        ParseTemplateVars(cmsPage, Menu, False, False, 0, HideErrors, tmpDbCommand, tmpDbConnection)
                        .HTMLBodyOpen = .HTMLFullPage

                        .HTMLFullPage = .HTMLBodyClose
                        ParseTemplateVars(cmsPage, Menu, False, False, 0, HideErrors, tmpDbCommand, tmpDbConnection)
                        .HTMLBodyClose = .HTMLFullPage

                        For DetailsArrayCount = 0 To .DetailCount - 1
                            If .TemplateDetail(DetailsArrayCount).ComponentID = 0 Then
                                .HTMLFullPage = .TemplateDetail(DetailsArrayCount).Content
                                ParseTemplateVars(cmsPage, Menu, False, False, 0, HideErrors, tmpDbCommand, tmpDbConnection)
                                .TemplateDetail(DetailsArrayCount).Content = .HTMLFullPage
                            Else
                                For DetailsAttributesCount = 0 To .TemplateDetail(DetailsArrayCount).AttributesCount - 1
                                    .HTMLFullPage = .TemplateDetail(DetailsArrayCount).AttributesList(DetailsAttributesCount).Value
                                    ParseTemplateVars(cmsPage, Menu, False, False, 0, HideErrors, tmpDbCommand, tmpDbConnection)
                                    .TemplateDetail(DetailsArrayCount).AttributesList(DetailsAttributesCount).Value = .HTMLFullPage
                                Next
                            End If
                        Next

                        .HTMLFullPage = tmpFullPage
                    End With
                End If
                EndTime = Environment.TickCount
                ExecutionTime = Convert.ToDouble((EndTime - StartTime)) / 1000.0
                cmsPage._CMS_Stats &= "Lettura TV in: " & ExecutionTime & "<br />"

                '*************************************************************************************************************************
                '************ PAGE VARS
                '*************************************************************************************************************************
                StartTime = Environment.TickCount
                If cmsPage.HaveDetails = False Then
                    ParsePageVars(cmsPage, Menu, , , , HideErrors, tmpDbCommand, tmpDbConnection)
                Else
                    With cmsPage
                        tmpFullPage = .HTMLFullPage

                        .HTMLFullPage = .HTMLCompletoHeadPagina
                        ParsePageVars(cmsPage, Menu, , , , HideErrors, tmpDbCommand, tmpDbConnection)
                        .HTMLCompletoHeadPagina = .HTMLFullPage

                        .HTMLFullPage = .HTMLBodyOpen
                        ParsePageVars(cmsPage, Menu, , , , HideErrors, tmpDbCommand, tmpDbConnection)
                        .HTMLBodyOpen = .HTMLFullPage

                        .HTMLFullPage = .HTMLBodyClose
                        ParsePageVars(cmsPage, Menu, , , , HideErrors, tmpDbCommand, tmpDbConnection)
                        .HTMLBodyClose = .HTMLFullPage

                        For DetailsArrayCount = 0 To .DetailCount - 1
                            If .TemplateDetail(DetailsArrayCount).ComponentID = 0 Then
                                .HTMLFullPage = .TemplateDetail(DetailsArrayCount).Content
                                ParsePageVars(cmsPage, Menu, , , , HideErrors, tmpDbCommand, tmpDbConnection)
                                .TemplateDetail(DetailsArrayCount).Content = .HTMLFullPage
                            Else
                                For DetailsAttributesCount = 0 To .TemplateDetail(DetailsArrayCount).AttributesCount - 1
                                    .HTMLFullPage = .TemplateDetail(DetailsArrayCount).AttributesList(DetailsAttributesCount).Value
                                    ParsePageVars(cmsPage, Menu, , , , HideErrors, tmpDbCommand, tmpDbConnection)
                                    .TemplateDetail(DetailsArrayCount).AttributesList(DetailsAttributesCount).Value = .HTMLFullPage
                                Next
                            End If
                        Next

                        .HTMLFullPage = tmpFullPage
                    End With
                End If
                EndTime = Environment.TickCount
                ExecutionTime = Convert.ToDouble((EndTime - StartTime)) / 1000.0
                cmsPage._CMS_Stats &= "Lettura TVPage in: " & ExecutionTime & "<br />"

                '*************************************************************************************************************************
                '************ MODULES
                '*************************************************************************************************************************
                StartTime = Environment.TickCount
                If cmsPage.HaveDetails = False Then
                    ParseModules(cmsPage, Menu, , , , HideErrors, tmpDbCommand, tmpDbConnection)
                Else
                    With cmsPage
                        tmpFullPage = .HTMLFullPage

                        For DetailsArrayCount = 0 To .DetailCount - 1
                            If .TemplateDetail(DetailsArrayCount).ComponentID = 0 Then
                                .HTMLFullPage = .TemplateDetail(DetailsArrayCount).Content
                                ParseModules(cmsPage, Menu, , , , HideErrors, tmpDbCommand, tmpDbConnection)
                                .TemplateDetail(DetailsArrayCount).Content = .HTMLFullPage
                            End If
                        Next

                        .HTMLFullPage = tmpFullPage
                    End With
                End If
                EndTime = Environment.TickCount
                ExecutionTime = Convert.ToDouble((EndTime - StartTime)) / 1000.0
                cmsPage._CMS_Stats &= "Lettura Moduli in: " & ExecutionTime & "<br />"

                '*************************************************************************************************************************
                '************ END PAGEFOUND
                '*************************************************************************************************************************
            End If

            '*************************************************************************************************************************
            '************ ERROR CHECK
            '*************************************************************************************************************************
            StartTime = Environment.TickCount
            If Not HideErrors Then cmsPage._CMS_Warning = JertCMS_CheckErrors("<\s*jcms.[^>]*>", cmsPage.HTMLFullPage, "<br />Pagina (id:" & cmsPage.idPagina & "): """ & Menu.DescrizioneBreveNelMenu & """ -- Template (id: " & cmsPage.idTemplate & "): """ & cmsPage.NomeTemplate & """")
            EndTime = Environment.TickCount
            ExecutionTime = Convert.ToDouble((EndTime - StartTime)) / 1000.0
            cmsPage._CMS_Stats &= "Verifica presenza errori in: " & ExecutionTime & "<br />"

            GlobalEnd = EndTime
            ExecutionTime = Convert.ToDouble((GlobalEnd - GlobalStart)) / 1000.0
            cmsPage._CMS_Stats &= "Tempo TOTALE: <strong>" & ExecutionTime & "</strong><br />"

            db.CloseConn(True, tmpDbConnection)
            GC.Collect() 'Chiude eventuali connessioni ancora aperte

            '*************************************************************************************************************************
            '************ SPLIT TEMPLATE
            '*************************************************************************************************************************
            If Not cmsPage.HaveDetails Then
                Dim tmpTemplate As _cmsTemplate
                tmpTemplate = myRegex.SeparateTemplateHTML(cmsPage.HTMLFullPage)

                cmsPage.HTMLBodyOpen = tmpTemplate.BodyTagOpen
                cmsPage.HTMLBodyClose = tmpTemplate.BodyTagClose & tmpTemplate.Footer
                cmsPage.HTMLCompletoHeadPagina = tmpTemplate.Header
                cmsPage.HTMLCompletoPagina = tmpTemplate.Content
            End If

            Return cmsPage
        End Function

        Private Sub ParseTemplateVars(ByRef cmsPage As _cmsPage, ByRef Menu As _cmsVoceDiMenu, Optional ByVal isInListParse As Boolean = False, Optional ByVal isInMenuParse As Boolean = False, Optional ByVal PageIDInList As Long = 0, Optional ByVal HideErrors As Boolean = False, Optional ByRef tmpDbCommand As OleDbCommand = Nothing, Optional ByRef tmpDbConnection As OleDbConnection = Nothing)
            JertCMS_SubstTemplateVarTAG("<jcms(\s+(?<attribute>\S+?)=[""']?(?<value>[^""']*)[""']?\S)*\s+/>", cmsPage, Menu, isInListParse, isInMenuParse, PageIDInList, HideErrors, tmpDbCommand, tmpDbConnection)
        End Sub

        Private Function ParsePageVars(ByRef cmsPage As _cmsPage, ByRef Menu As _cmsVoceDiMenu, Optional ByVal isInListParse As Boolean = False, Optional ByVal isInMenuParse As Boolean = False, Optional ByVal PageIDInList As Long = 0, Optional ByVal HideErrors As Boolean = False, Optional ByRef tmpDbCommand As OleDbCommand = Nothing, Optional ByRef tmpDbConnection As OleDbConnection = Nothing, Optional ByVal OpenJCmsTAG As String = "<jcms", Optional ByVal CloseJCmsTAG As String = "/>", Optional ByVal OpenDoubleQuote As String = """'", Optional ByVal CloseDoubleQuote As String = """'") As String
            Dim retValue As String = ""
            retValue = JertCMS_SubstPageVarTAG("" & OpenJCmsTAG & "(\s+(?<attribute>\S+?)=[" & OpenDoubleQuote & "]?(?<value>[^" & CloseDoubleQuote & "]*)[" & CloseDoubleQuote & "]?\S)*\s+" & CloseJCmsTAG & "", cmsPage, Menu, isInListParse, isInMenuParse, PageIDInList, HideErrors, tmpDbCommand, tmpDbConnection)
            Return retValue
        End Function

        Private Function ParseModules(ByRef cmsPage As _cmsPage, ByRef Menu As _cmsVoceDiMenu, Optional ByVal isInListParse As Boolean = False, Optional ByVal isInMenuParse As Boolean = False, Optional ByVal PageIDInList As Long = 0, Optional ByVal HideErrors As Boolean = False, Optional ByRef tmpDbCommand As OleDbCommand = Nothing, Optional ByRef tmpDbConnection As OleDbConnection = Nothing) As String
            Dim retValue As String = ""
            retValue = JertCMS_SubstComponentTAG("<jcms(\s+(?<attribute>\S+?)=[""']?(?<value>[^""']*)[""']?\S)*\s+/>", cmsPage, Menu, isInListParse, isInMenuParse, PageIDInList, HideErrors, tmpDbCommand, tmpDbConnection)
            Return retValue
        End Function

        Private Function ParseChuhnksVars(ByRef cmsPage As _cmsPage, ByRef Menu As _cmsVoceDiMenu, Optional ByVal isInListParse As Boolean = False, Optional ByVal isInMenuParse As Boolean = False, Optional ByVal PageIDInList As Long = 0, Optional ByVal HideErrors As Boolean = False, Optional ByRef tmpDbCommand As OleDbCommand = Nothing, Optional ByRef tmpDbConnection As OleDbConnection = Nothing) As String
            Dim retValue As String = ""
            retValue = JertCMS_SubstChunksVarTAG("<jcms(\s+(?<attribute>\S+?)=[""']?(?<value>[^""']*)[""']?\S)*\s+/>", cmsPage, Menu, isInListParse, isInMenuParse, PageIDInList, HideErrors, tmpDbCommand, tmpDbConnection)
            Return retValue
        End Function

        Private Sub ParseListCommands(ByRef cmsPage As _cmsPage, ByRef Menu As _cmsVoceDiMenu, Optional ByVal HideErrors As Boolean = False, Optional ByRef tmpDbCommand As OleDbCommand = Nothing, Optional ByRef tmpDbConnection As OleDbConnection = Nothing)
            JertCMS_SubstListTAG("<jcms(?:\s+(?<attribute>\S+?)=[""']?(?<value>[^""']*)[""']?\S)*>(?<contentList>[\S\s]*?)</jcms>", cmsPage, Menu, HideErrors, tmpDbCommand, tmpDbConnection)
        End Sub

        Private Sub ParseMenuCommands(ByRef cmsPage As _cmsPage, ByRef Menu As _cmsVoceDiMenu, Optional ByVal HideErrors As Boolean = False, Optional ByRef tmpDbCommand As OleDbCommand = Nothing, Optional ByRef tmpDbConnection As OleDbConnection = Nothing)
            JertCMS_SubstMenuTAG("<jcms(?:\s+(?<attribute>\S+?)=[""']?(?<value>[^""']*)[""']?\S)*>(?<contentMenu>[\S\s]*?)</jcms>", cmsPage, Menu, HideErrors, tmpDbCommand, tmpDbConnection)
        End Sub


        Public Sub JertCMS_SubstMenuTAG(ByVal regexTAG As String, ByRef cmsPage As _cmsPage, ByRef Menu As _cmsVoceDiMenu, Optional ByVal HideErrors As Boolean = False, Optional ByRef tmpDbCommand As OleDbCommand = Nothing, Optional ByRef tmpDbConnection As OleDbConnection = Nothing)
            Dim regex As New Regex(regexTAG, RegexOptions.IgnoreCase)
            Dim matches As MatchCollection = regex.Matches(cmsPage.HTMLFullPage)

            Dim type As String = ""
            Dim page_id As String = ""
            Dim exclude_id As String = ""
            Dim show_only_id As String = ""

            Dim order_by_tvpage As String = ""
            Dim order_by_menuindex As String = ""
            Dim custom_order As String = ""

            Dim sort_order As String = ""
            Dim start_depth As String = ""
            Dim depth As String = ""
            Dim show_css_class As String = ""
            Dim hide_children_in_no_active As String = ""


            Dim Value As String = ""
            Dim tmpWarning As String = ""
            Dim ContentOfMenuCommand As String = ""

            Dim match As Match
            For Each match In matches
                type = ""
                page_id = ""
                exclude_id = ""
                show_only_id = ""

                order_by_tvpage = ""
                order_by_menuindex = ""
                custom_order = ""

                sort_order = ""
                start_depth = ""
                depth = ""
                show_css_class = ""
                hide_children_in_no_active = ""

                Value = ""
                tmpWarning = ""
                ContentOfMenuCommand = ""

                For i As Long = 0 To match.Groups("value").Captures.Count - 1
                    Value = match.Groups("value").Captures(i).ToString

                    Select Case match.Groups("attribute").Captures(i).ToString.ToLower
                        Case "type" : type = Value : If type <> "menu" Then Exit For
                        Case "page_id" : page_id = Value
                        Case "exclude_id" : exclude_id = Value
                        Case "show_only_id" : show_only_id = Value
                        Case "order_by_tvpage" : order_by_tvpage = Value
                        Case "order_by_menuindex" : order_by_menuindex = Value
                        Case "custom_order" : custom_order = Value
                        Case "sort_order" : sort_order = Value
                        Case "start_depth" : start_depth = Value
                        Case "depth" : depth = Value
                        Case "show_css_class" : show_css_class = Value
                        Case "hide_children_in_no_active" : hide_children_in_no_active = Value

                        Case Else
                            'TODO da globalizzare..
                            tmpWarning = "<br />--- Attributo non riconosciuto: <strong>" & match.Groups("attribute").Captures(i).ToString.ToLower & "=""" & Value & """</strong> <br />Nel comando: <strong>" & match.Value.ToString.Replace("<", "&lt;").Replace(">", "&gt;") & "</strong>"
                    End Select
                Next i

                ContentOfMenuCommand = match.Groups("contentMenu").ToString.Trim

                If type = "menu" Then
                    If tmpWarning.Length = 0 Then cmsPage.HTMLFullPage = cmsPage.HTMLFullPage.Replace(match.Value.ToString, JertCMS_ReadMenuContent(match.Value.ToString, cmsPage, Menu, ContentOfMenuCommand, page_id, exclude_id, show_only_id, order_by_tvpage, order_by_menuindex, custom_order, sort_order, start_depth, depth, show_css_class, hide_children_in_no_active, HideErrors, tmpDbCommand, tmpDbConnection))
                    If tmpWarning.Length > 0 Then
                        cmsPage._CMS_Warning &= tmpWarning
                    End If
                End If
            Next match
        End Sub

        Private Function JertCMS_ReadMenuContent(ByVal CommandToSearch As String, ByRef cmsPage As _cmsPage, ByRef Menu As _cmsVoceDiMenu, ByVal Content As String, ByVal page_id As String, ByVal exclude_id As String, ByVal show_only_id As String, ByVal order_by_tvpage As String, ByVal order_by_menuindex As String, ByVal custom_order As String, ByVal sort_order As String, ByVal start_depth As String, ByVal depth As String, ByVal menu_show_class As String, ByVal menu_hide_children As String, Optional ByVal HideErrors As Boolean = False, Optional ByRef tmpDbCommand As OleDbCommand = Nothing, Optional ByRef tmpDbConnection As OleDbConnection = Nothing) As String
            'TODO spostare la dichiarazione delle variabili fuori dal ciclo for

            Dim retValue As String = CommandToSearch

            Dim NumMenu As Long = 0
            Dim tmpMenuFound As Boolean = True

            '***********************************************
            Dim arrTemplateHeader As New ArrayList
            Dim arrTemplateContent As New ArrayList
            Dim arrTemplateFooter As New ArrayList
            '***********************************************

            Dim tmpMenuContent As String
            Dim TemplateEmpty As String = ""
            Dim tmpTAG As String = ""

            Do While tmpMenuFound = True
                'TODO e se non ci sono menu?

                NumMenu += 1
                tmpTAG = "menu_" & NumMenu.ToString
                tmpMenuContent = JertCMS_GetContentTAG("(?:<" & tmpTAG & ">(?<" & tmpTAG & ">[\s\S]*?)</" & tmpTAG & ">)", Content, tmpTAG, tmpMenuFound)
                If tmpMenuFound Then
                    tmpTAG = "template_header"
                    arrTemplateHeader.Add(JertCMS_GetContentTAG("(?:<" & tmpTAG & ">(?<" & tmpTAG & ">[\s\S]*?)</" & tmpTAG & ">)", tmpMenuContent, tmpTAG))

                    tmpTAG = "template_content"
                    arrTemplateContent.Add(JertCMS_GetContentTAG("(?:<" & tmpTAG & ">(?<" & tmpTAG & ">[\s\S]*?)</" & tmpTAG & ">)", tmpMenuContent, tmpTAG))

                    tmpTAG = "template_footer"
                    arrTemplateFooter.Add(JertCMS_GetContentTAG("(?:<" & tmpTAG & ">(?<" & tmpTAG & ">[\s\S]*?)</" & tmpTAG & ">)", tmpMenuContent, tmpTAG))
                Else
                    NumMenu -= 1
                End If
            Loop

            If NumMenu = 0 Then
                cmsPage._CMS_Warning &= "<br />--- Inserire almeno un Template: <strong><menu_1></menu_1></strong> <br />Nel comando: <strong>" & CommandToSearch.Replace("<", "&lt;").Replace(">", "&gt;") & "</strong>"
                Return retValue
            End If

            'Ho i Menu....
            tmpTAG = "template_empty"
            Dim tagFound As Boolean = False

            tmpMenuContent = JertCMS_GetContentTAG("(?:<" & tmpTAG & ">(?<" & tmpTAG & ">[\s\S]*?)</" & tmpTAG & ">)", Content, tmpTAG, tagFound)
            If tagFound Then TemplateEmpty = tmpMenuContent

            Dim RootFound As Boolean = False

            If page_id.Length > 0 Then
                If page_id.ToLower = "current" Then page_id = cmsPage.idPagina
                If page_id.ToLower = "root" Then page_id = GetIdRootPageFromIdPage(cmsPage.codPagina, cmsPage.idLingua, tmpDbCommand, tmpDbConnection) : RootFound = True

                If IsNumeric(page_id) Then
                    Dim tmpPageID As Long = Convert.ToInt32(page_id)

                    Dim startDepthList As String = ""

                    Dim tmpPage As New _cmsPage
                    tmpPage = GetPageByID(page_id, tmpDbCommand, tmpDbConnection)

                    If tmpPage.idErrore = 0 Then
                        Dim tmpMenu As _cmsVoceDiMenu
                        'tmpMenu = GetVoceMenuFromFolderPath(GetFolderPathFromCodPaginaAndIdLingua(tmpPage.codPagina, tmpPage.idLingua, tmpDbCommand, tmpDbConnection), tmpPage.idLingua, tmpDbCommand, tmpDbConnection)
                        'tmpMenu = GetVoceMenuFromFolderPath(GetFolderPathFromCodPaginaAndIdLingua(tmpPage.codPagina, tmpPage.idLingua), tmpPage.idLingua)
                        tmpMenu = GetVoceMenuFromFolderPath(tmpPage.FolderPath, tmpPage.idLingua, tmpDbCommand, tmpDbConnection)

                        Dim tmpExclude_id As String() = exclude_id.Split("|")
                        Dim tmpShowOnly_id As String() = show_only_id.Split("|")

                        Dim tmpSortOrder As String = ""
                        Dim tmpStartDepth As Long = -1
                        Dim tmpDepth As Long = -1

                        If sort_order.Length > 0 Then
                            sort_order = sort_order.ToLower

                            If sort_order = "asc" Or sort_order = "desc" Then
                                tmpSortOrder = sort_order
                            Else
                                cmsPage._CMS_Warning &= "<br />--- Attributo non riconosciuto: <strong>sort_order=""" & sort_order & """</strong> <br />Nel comando: <strong>" & CommandToSearch.Replace("<", "&lt;").Replace(">", "&gt;") & "</strong>"
                                Return retValue
                            End If
                        Else
                            tmpSortOrder = "asc"
                        End If

                        If start_depth.Length > 0 Then
                            If HideErrors Then
                                tmpStartDepth = Convert.ToInt32(start_depth)
                            Else
                                If IsNumeric(start_depth) = True Then
                                    tmpStartDepth = Convert.ToInt32(start_depth)
                                Else
                                    cmsPage._CMS_Warning &= "<br />--- Attributo non riconosciuto: <strong>start_depth=""" & start_depth & """</strong> <br />Nel comando: <strong>" & CommandToSearch.Replace("<", "&lt;").Replace(">", "&gt;") & "</strong>"
                                    Return retValue
                                End If
                            End If
                        Else
                            tmpStartDepth = 0
                        End If

                        If depth.Length > 0 Then
                            If HideErrors Then
                                tmpDepth = Convert.ToInt32(depth)
                            Else
                                If IsNumeric(depth) = True Then
                                    tmpDepth = Convert.ToInt32(depth)
                                Else
                                    cmsPage._CMS_Warning &= "<br />--- Attributo non riconosciuto: <strong>depth=""" & depth & """</strong> <br />Nel comando: <strong>" & CommandToSearch.Replace("<", "&lt;").Replace(">", "&gt;") & "</strong>"
                                    Return retValue
                                End If
                            End If

                        Else
                            tmpDepth = 0
                        End If

                        Dim tmpExcludeID_List As String = ""

                        For i As Integer = 0 To tmpExclude_id.Length - 1
                            If tmpExclude_id(i) = "current" Then tmpExclude_id(i) = tmpPageID
                            If HideErrors Then
                                If i < tmpExclude_id.Length - 1 Then
                                    tmpExcludeID_List &= tmpExclude_id(i) & ","
                                Else
                                    tmpExcludeID_List &= tmpExclude_id(i)
                                End If
                            Else
                                If IsNumeric(tmpExclude_id(i)) = True Then
                                    If i < tmpExclude_id.Length - 1 Then
                                        tmpExcludeID_List &= tmpExclude_id(i) & ","
                                    Else
                                        tmpExcludeID_List &= tmpExclude_id(i)
                                    End If
                                End If
                            End If
                        Next


                        Dim tmpShowOnlyID_List As String = ""

                        For i As Integer = 0 To tmpShowOnly_id.Length - 1
                            If tmpShowOnly_id(i) = "current" Then tmpShowOnly_id(i) = tmpPageID
                            If HideErrors Then
                                If i < tmpShowOnly_id.Length - 1 Then
                                    tmpShowOnlyID_List &= tmpShowOnly_id(i) & ","
                                Else
                                    tmpShowOnlyID_List &= tmpShowOnly_id(i)
                                End If
                            Else
                                If IsNumeric(tmpShowOnly_id(i)) = True Then
                                    If i < tmpShowOnly_id.Length - 1 Then
                                        tmpShowOnlyID_List &= tmpShowOnly_id(i) & ","
                                    Else
                                        tmpShowOnlyID_List &= tmpShowOnly_id(i)
                                    End If
                                End If
                            End If
                        Next

                        Dim tmpOrderByMenuIndex As Boolean = False

                        If order_by_menuindex.Length > 0 Then
                            order_by_menuindex = order_by_menuindex.ToLower

                            If order_by_menuindex = "true" Or order_by_menuindex = "false" Then
                                tmpOrderByMenuIndex = Convert.ToBoolean(order_by_menuindex)
                            Else
                                cmsPage._CMS_Warning &= "<br />--- Attributo non riconosciuto: <strong>order_by_menuindex=""" & order_by_menuindex & """</strong> <br />Nel comando: <strong>" & CommandToSearch.Replace("<", "&lt;").Replace(">", "&gt;") & "</strong>"
                                Return retValue
                            End If
                        End If

                        Dim dictCustomOrders As New Dictionary(Of String, String)

                        If custom_order.Length > 0 Then
                            Dim tmpArrEntries As String() = custom_order.Split("|")

                            For i = 0 To tmpArrEntries.Length - 1
                                Dim Value As String() = tmpArrEntries(i).Split(",")

                                If Value.Length = 2 Then
                                    If HideErrors Then
                                        dictCustomOrders.Add(Convert.ToInt16(Value(0)), Value(1))
                                    Else
                                        If IsNumeric(Value(0)) Then
                                            If checkFieldNameExist(Value(1)) Then
                                                dictCustomOrders.Add(Convert.ToInt16(Value(0)), Value(1))
                                            Else
                                                cmsPage._CMS_Warning &= "<br />--- Ordinamento errato [" & Value(1) & "]: <strong>custom_order=""" & custom_order & """</strong> <br />Nel comando: <strong>" & CommandToSearch.Replace("<", "&lt;").Replace(">", "&gt;") & "</strong>"
                                                Return retValue
                                            End If
                                        Else
                                            cmsPage._CMS_Warning &= "<br />--- id Pagina errato [" & Value(0) & "]: <strong>custom_order=""" & custom_order & """</strong> <br />Nel comando: <strong>" & CommandToSearch.Replace("<", "&lt;").Replace(">", "&gt;") & "</strong>"
                                            Return retValue
                                        End If
                                    End If
                                Else
                                    cmsPage._CMS_Warning &= "<br />--- Attributo non riconosciuto: <strong>custom_order=""" & custom_order & """</strong> <br />Nel comando: <strong>" & CommandToSearch.Replace("<", "&lt;").Replace(">", "&gt;") & "</strong>"
                                    Return retValue
                                End If
                            Next

                        End If

                        Dim tmpHideChildren As Boolean = False

                        If menu_hide_children.Length > 0 Then
                            menu_hide_children = menu_hide_children.ToLower

                            If menu_hide_children = "true" Or menu_hide_children = "false" Then
                                tmpHideChildren = Convert.ToBoolean(menu_hide_children)
                            Else
                                cmsPage._CMS_Warning &= "<br />--- Attributo non riconosciuto: <strong>hide_children_in_no_active=""" & menu_hide_children & """</strong> <br />Nel comando: <strong>" & CommandToSearch.Replace("<", "&lt;").Replace(">", "&gt;") & "</strong>"
                                Return retValue
                            End If
                        End If

                        If order_by_tvpage.Length > 0 Then
                            If Not HideErrors Then
                                If checkFieldNameExist(order_by_tvpage) = False Then
                                    cmsPage._CMS_Warning &= "<br />--- Ordinamento errato [" & order_by_tvpage & "]: <strong>order_by_tvpage=""" & order_by_tvpage & """</strong> <br />Nel comando: <strong>" & CommandToSearch.Replace("<", "&lt;").Replace(">", "&gt;") & "</strong>"
                                    Return retValue
                                End If
                            End If
                        End If
                        order_by_tvpage = order_by_tvpage.Trim

                        'Check dei vari order by...
                        If tmpOrderByMenuIndex Then
                            If order_by_tvpage.Length > 0 Then
                                cmsPage._CMS_Warning &= "<br />--- Non possono coesistere i comandi: <strong>order_by_menuindex=""" & order_by_menuindex & """</strong> e <strong>order_by_tvpage=""" & order_by_tvpage & """</strong>, eliminare uno dei due. <br />Nel comando: <strong>" & CommandToSearch.Replace("<", "&lt;").Replace(">", "&gt;") & "</strong>"
                                Return retValue
                            End If
                        End If

                        Dim ShowCSSList As String() = menu_show_class.Split("|")
                        Dim cssClass As New _cmsMenuCssClasses

                        For i As Integer = 0 To ShowCSSList.Length - 1
                            If CheckAndSetCSSClassExist(ShowCSSList(i), cssClass) = False Then
                                cmsPage._CMS_Warning &= "<br />--- classe css errata [" & ShowCSSList(i) & "]: <strong>show_css_class=""" & menu_show_class & """</strong> <br />Nel comando: <strong>" & CommandToSearch.Replace("<", "&lt;").Replace(">", "&gt;") & "</strong>"
                                Return retValue
                            End If
                        Next

                        Dim LEVELDepth As Long = -1

                        'TODO forse CurrentArrTemplateIndex sarà da eliminare.. perchè sostituito da LastMenuItemDepthFound
                        Dim CurrentArrTemplateIndex As Long = 0
                        Dim TotalArrTemplateIndex As Long = arrTemplateContent.Count - 1
                        retValue = ""

                        Dim LastMenuItemDepthFound As Long = -1

                        Dim currentID As Long = cmsPage.idPagina
                        Dim CurrentPageDepth = Menu.ProfonditaLivello

                        Dim arrMenuPage As New List(Of Menu.ClassMenu)

                        arrMenuPage = GenerateMenu(currentID, CurrentPageDepth, TemplateEmpty, LastMenuItemDepthFound, retValue, LEVELDepth, tmpPage, tmpMenu, tmpExcludeID_List, CurrentArrTemplateIndex, TotalArrTemplateIndex, arrTemplateHeader, arrTemplateContent, arrTemplateFooter, tmpShowOnlyID_List, order_by_tvpage, dictCustomOrders, tmpOrderByMenuIndex, tmpSortOrder, tmpStartDepth, tmpDepth, cssClass, tmpHideChildren, True, RootFound, HideErrors, tmpDbCommand, tmpDbConnection)

                        If IsNothing(tmpPage._CMS_Warning) OrElse tmpPage._CMS_Warning.Length = 0 Then
                            If arrMenuPage.Count = 0 Then
                                retValue = TemplateEmpty
                            Else
                                retValue = arrMenuPage(arrMenuPage.Count - 1).HTMLText
                            End If
                        Else
                            cmsPage._CMS_Warning &= tmpPage._CMS_Warning
                        End If
                    Else
                        cmsPage._CMS_Warning &= "<br />--- Id Pagina errato [" & page_id & "] <strong>page_id=""" & page_id & """</strong> <br />Nel comando: <strong>" & CommandToSearch.Replace("<", "&lt;").Replace(">", "&gt;") & "</strong>"
                        Return retValue
                    End If
                Else
                    cmsPage._CMS_Warning &= "<br />--- Id Pagina errato [" & page_id & "] <strong>page_id=""" & page_id & """</strong> <br />Nel comando: <strong>" & CommandToSearch.Replace("<", "&lt;").Replace(">", "&gt;") & "</strong>"
                    Return retValue
                End If
            Else
                cmsPage._CMS_Warning &= "<br />--- Attributo non riconosciuto: <strong>page_id=""" & page_id & """</strong> <br />Nel comando: <strong>" & CommandToSearch.Replace("<", "&lt;").Replace(">", "&gt;") & "</strong>"
                Return retValue
            End If

            Return retValue
        End Function

        Public Function ValueIsInList(ByVal ValueToCheck As String, ByVal List As String, ByVal separator As String, Optional ByVal ifEmptyListReturn As Boolean = False) As Boolean
            Dim retValue As Boolean = False

            Dim tmpArr As String() = List.Split(separator)

            If tmpArr.Length - 1 = 0 And tmpArr(0) = "" Then Return ifEmptyListReturn

            For i As Integer = 0 To tmpArr.Length - 1
                If tmpArr(i) = ValueToCheck Then Return True
            Next
            Return retValue
        End Function

        Private Function GenerateMenu(ByVal CurrentID As Long, ByVal CurrentPageDepth As Long, ByRef TemplateEmpty As String, ByVal LastMenuItemDepthFound As Long, ByVal retValue As String, ByVal LEVELDepth As Long, ByRef tmpPage As _cmsPage, ByRef tmpMenu As _cmsVoceDiMenu, ByRef tmpExclude_id As String, ByRef CurrentArrTemplateIndex As Long, ByRef TotalArrTemplateIndex As Long, ByRef arrTemplateHeader As ArrayList, ByRef arrTemplateContent As ArrayList, ByRef arrTemplateFooter As ArrayList, ByRef tmpShowOnly_id As String, ByVal order_by_tvpage As String, ByRef dictCustomOrders As Dictionary(Of String, String), ByVal tmpOrderByMenuIndex As Boolean, ByRef tmpSortOrder As String, ByRef tmpStartDepth As Long, ByVal tmpDepth As Long, ByRef cssClass As _cmsMenuCssClasses, ByRef menu_hide_children As Boolean, ByVal UseHeaderFooterTemplate As Boolean, ByVal RootFound As Boolean, Optional ByVal HideErrors As Boolean = False, Optional ByRef tmpDbCommand As OleDbCommand = Nothing, Optional ByRef tmpDbConnection As OleDbConnection = Nothing) As List(Of Menu.ClassMenu) ' _cmsGeneratedMenuResult
            LEVELDepth += 1
            retValue = ""

            tmpMenu.CompareBy = order_by_tvpage
            tmpMenu.SortOrder = tmpSortOrder

            Dim tmpGeneratedMenu As String = ""
            Dim thisMenu As Menu.ClassMenu

            Dim currentMenuLevel As Long = LastMenuItemDepthFound

            'TODO tmpMenuResult da eliminare?
            Dim tmpMenuResult As _cmsGeneratedMenuResult
            tmpMenuResult.HTMLResult = ""
            tmpMenuResult.NumElements = 0
            tmpMenuResult.MenuItem = Nothing
            Dim arrMenuPage As New List(Of Menu.ClassMenu)

            If tmpDepth < 0 Then Return arrMenuPage

            'Dim tmpDbCommand As New OleDbCommand
            'Dim tmpDbConnection As New OleDbConnection
            Dim tmpReader As OleDbDataReader

            Dim tmpSqlString As String = ""
            Dim tmpFolderPath = tmpMenu.folderpath

            If tmpStartDepth < 0 Then tmpFolderPath = GetFolderPathParent(tmpFolderPath, tmpStartDepth)

            Dim tmpWhereStringSQL As String = ""

            If tmpMenu.ProfonditaLivello = 1 Then
                If LEVELDepth = 0 Then
                    'Primo Livello...
                    If RootFound Then
                        tmpWhereStringSQL = " WHERE (folderpath like '" & tmpFolderPath & "' OR ProfonditaLivello=" & tmpMenu.ProfonditaLivello & ") AND idLingua = " & tmpMenu.idLingua
                        RootFound = False
                    Else
                        tmpWhereStringSQL = " WHERE (folderpath like '" & tmpFolderPath & "') AND idLingua = " & tmpMenu.idLingua
                    End If
                Else
                    tmpWhereStringSQL = " WHERE (folderpath like '" & tmpFolderPath & "%' OR ProfonditaLivello=" & tmpMenu.ProfonditaLivello & ") AND codPaginaMadre = " & tmpMenu.codPagina & " AND idLingua = " & tmpMenu.idLingua
                End If
            Else
                If LEVELDepth = 0 Then
                    'Primo Livello...
                    If RootFound Then
                        tmpWhereStringSQL = " WHERE (folderpath like '" & tmpFolderPath & "' OR codPaginaMadre=0) AND idLingua = " & tmpMenu.idLingua
                        RootFound = False
                    Else
                        tmpWhereStringSQL = " WHERE (folderpath like '" & tmpFolderPath & "') AND idLingua = " & tmpMenu.idLingua
                    End If
                Else
                    tmpWhereStringSQL = " WHERE folderpath like '" & tmpFolderPath & "%' AND codPaginaMadre = " & tmpMenu.codPagina & " AND idLingua = " & tmpMenu.idLingua
                End If
            End If

            Dim OrderByOrdine As String = " ORDER BY ordine"

            If tmpOrderByMenuIndex Then
                tmpSqlString = "SELECT * FROM Menu " & tmpWhereStringSQL & OrderByOrdine
            Else
                tmpSqlString = "SELECT * FROM Menu " & tmpWhereStringSQL & " "
            End If

            db.OpenConn(tmpSqlString.Replace(" * ", " Count(*) As NumRecords ").Replace(OrderByOrdine, ""), "", "", True, tmpDbConnection, tmpDbCommand)
            tmpReader = db.ExecuteReader(True, tmpDbCommand)

            tmpReader.Read()
            Dim TotRecords As Long = tmpReader("NumRecords")
            Dim CountRecords As Long = 0

            tmpReader.Close()
            'db.CloseConn(True, tmpDbConnection)

            db.OpenConn(tmpSqlString, "", "", True, tmpDbConnection, tmpDbCommand)
            tmpReader = db.ExecuteReader(True, tmpDbCommand)

            Dim tmpThisMenuPage As _cmsMenuPages

            If Not tmpReader.HasRows Then
                tmpReader.Close()
                'db.CloseConn(True, tmpDbConnection)

                Return arrMenuPage
            End If

            Dim tmp2MenuResult As _cmsGeneratedMenuResult
            Dim menuLevelAdded As Boolean = False
            Dim tmpCssClassesStatus As _cmsMenuCssClasses
            Dim ShowSubMenu As Boolean

            Dim tmpOpenMenuTag As String
            Dim tmpCloseMenuTag As String

            While tmpReader.Read
                tmpOpenMenuTag = ""
                tmpCloseMenuTag = ""

                retValue = ""
                tmpCssClassesStatus = New _cmsMenuCssClasses

                tmp2MenuResult.HTMLResult = ""
                tmp2MenuResult.NumElements = 0

                CountRecords += 1

                tmpThisMenuPage = New _cmsMenuPages

                With tmpThisMenuPage
                    With .Menu
                        .codPagina = tmpReader("codPagina")
                        .codPaginaMadre = tmpReader("codPaginaMadre")
                        .DescrizioneBreveNelMenu = tmpReader("DescrizioneBreveNelMenu")
                        .folderpath = tmpReader("folderpath")
                        .idLingua = tmpReader("idLingua")
                        .idVoce = tmpReader("idVoce")

                        .ordine = tmpReader("ordine")
                        .ProfonditaLivello = tmpReader("ProfonditaLivello")
                    End With

                    'JertCMS_ReadPageContent(tmpThisMenuPage.Menu, tmpThisMenuPage.Page, tmpThisMenuPage.Menu.idLingua)
                    JertCMS_ReadPageContent(tmpThisMenuPage.Menu, tmpThisMenuPage.Page, tmpThisMenuPage.Menu.idLingua, tmpDbCommand, tmpDbConnection)

                    If dictCustomOrders.ContainsKey(tmpThisMenuPage.Page.idPagina.ToString) Then
                        tmpThisMenuPage.Menu.CompareBy = dictCustomOrders(tmpThisMenuPage.Page.idPagina.ToString)
                    Else
                        tmpThisMenuPage.Menu.CompareBy = order_by_tvpage
                    End If

                    If CurrentID = tmpThisMenuPage.Page.idPagina Then tmpCssClassesStatus.active = True
                    ShowSubMenu = Not (menu_hide_children And CurrentPageDepth = tmpThisMenuPage.Menu.ProfonditaLivello And (Not tmpCssClassesStatus.active))

                    If Not ValueIsInList(tmpThisMenuPage.Page.idPagina.ToString, tmpExclude_id, ",") Then
                        If ValueIsInList(tmpThisMenuPage.Page.idPagina.ToString, tmpShowOnly_id, ",", True) Then

                            If tmpStartDepth < 0 Then
                                tmpStartDepth = 0

                                If Not menuLevelAdded And LEVELDepth >= tmpStartDepth Then
                                    If TotalArrTemplateIndex > currentMenuLevel Then currentMenuLevel += 1
                                    LastMenuItemDepthFound = currentMenuLevel
                                    menuLevelAdded = True
                                End If

                                thisMenu = New Menu.ClassMenu(tmpThisMenuPage.Page, tmpThisMenuPage.Menu)

                                If ShowSubMenu And tmpThisMenuPage.Menu.codPaginaMadre > 0 And LEVELDepth < (tmpStartDepth + tmpDepth) Then
                                    'thisMenu.Add = GenerateMenu(CurrentID, CurrentPageDepth, TemplateEmpty, LastMenuItemDepthFound, retValue, LEVELDepth, tmpThisMenuPage.Page, tmpThisMenuPage.Menu, tmpExclude_id, CurrentArrTemplateIndex, TotalArrTemplateIndex, arrTemplateHeader, arrTemplateContent, arrTemplateFooter, tmpShowOnly_id, tmpThisMenuPage.Menu.CompareBy, dictCustomOrders, tmpOrderByMenuIndex, tmpSortOrder, tmpStartDepth, tmpDepth, cssClass, menu_hide_children, UseHeaderFooterTemplate, RootFound)
                                    thisMenu.Add = GenerateMenu(CurrentID, CurrentPageDepth, TemplateEmpty, LastMenuItemDepthFound, retValue, LEVELDepth, thisMenu.Page, thisMenu.Menu, tmpExclude_id, CurrentArrTemplateIndex, TotalArrTemplateIndex, arrTemplateHeader, arrTemplateContent, arrTemplateFooter, tmpShowOnly_id, tmpThisMenuPage.Menu.CompareBy, dictCustomOrders, tmpOrderByMenuIndex, tmpSortOrder, tmpStartDepth, tmpDepth, cssClass, menu_hide_children, UseHeaderFooterTemplate, RootFound, HideErrors, tmpDbCommand, tmpDbConnection)
                                    tmp2MenuResult.NumElements = thisMenu.NumOfSubMenu
                                    If thisMenu.NumOfSubMenu > 0 Then tmp2MenuResult.HTMLResult = thisMenu.SubMenuList(thisMenu.NumOfSubMenu - 1).HTMLText
                                End If

                                If tmp2MenuResult.NumElements > 0 Then tmpMenuResult.NumElements += 1 : tmpCssClassesStatus.parent = True
                                tmpMenuResult.TotalElements += tmp2MenuResult.NumElements

                                retValue = arrTemplateContent(currentMenuLevel).ToString.Replace("[[menu]]", tmp2MenuResult.HTMLResult)

                                tmpMenuResult.TotalElements += 1
                                If tmp2MenuResult.NumElements = 0 Then tmpMenuResult.NumElements += 1

                                If UseHeaderFooterTemplate Then
                                    If tmpMenuResult.NumElements = 1 Then
                                        thisMenu.OpenMenuTag = arrTemplateHeader(currentMenuLevel)
                                    End If
                                    If ((CountRecords = TotRecords) And (tmpMenuResult.NumElements > 0)) Then
                                        thisMenu.CloseMenuTag = arrTemplateFooter(currentMenuLevel)
                                    End If
                                End If

                                thisMenu.HTMLText = tmpMenuResult.HTMLResult
                                thisMenu.CurrentMenuLevel = currentMenuLevel

                                tmpMenuResult.MenuItem = thisMenu

                                arrMenuPage.Add(thisMenu)
                            Else
                                If LEVELDepth = tmpStartDepth Then
                                    If Not menuLevelAdded And LEVELDepth >= tmpStartDepth Then
                                        If TotalArrTemplateIndex > currentMenuLevel Then currentMenuLevel += 1
                                        LastMenuItemDepthFound = currentMenuLevel
                                        menuLevelAdded = True
                                    End If

                                    Dim tmpUse As Boolean = UseHeaderFooterTemplate

                                    If UseHeaderFooterTemplate = False Then tmpUse = True

                                    thisMenu = New Menu.ClassMenu(tmpThisMenuPage.Page, tmpThisMenuPage.Menu)

                                    If ShowSubMenu And tmpThisMenuPage.Menu.codPaginaMadre > 0 And LEVELDepth < (tmpStartDepth + tmpDepth) Then
                                        'thisMenu.Add = GenerateMenu(CurrentID, CurrentPageDepth, TemplateEmpty, LastMenuItemDepthFound, retValue, LEVELDepth, tmpThisMenuPage.Page, tmpThisMenuPage.Menu, tmpExclude_id, CurrentArrTemplateIndex, TotalArrTemplateIndex, arrTemplateHeader, arrTemplateContent, arrTemplateFooter, tmpShowOnly_id, tmpThisMenuPage.Menu.CompareBy, dictCustomOrders, tmpOrderByMenuIndex, tmpSortOrder, tmpStartDepth, tmpDepth, cssClass, menu_hide_children, UseHeaderFooterTemplate, RootFound)
                                        thisMenu.Add = GenerateMenu(CurrentID, CurrentPageDepth, TemplateEmpty, LastMenuItemDepthFound, retValue, LEVELDepth, thisMenu.Page, thisMenu.Menu, tmpExclude_id, CurrentArrTemplateIndex, TotalArrTemplateIndex, arrTemplateHeader, arrTemplateContent, arrTemplateFooter, tmpShowOnly_id, tmpThisMenuPage.Menu.CompareBy, dictCustomOrders, tmpOrderByMenuIndex, tmpSortOrder, tmpStartDepth, tmpDepth, cssClass, menu_hide_children, UseHeaderFooterTemplate, RootFound, HideErrors, tmpDbCommand, tmpDbConnection)
                                        tmp2MenuResult.NumElements = thisMenu.NumOfSubMenu
                                        If thisMenu.NumOfSubMenu > 0 Then tmp2MenuResult.HTMLResult = thisMenu.SubMenuList(thisMenu.NumOfSubMenu - 1).HTMLText
                                    End If

                                    If tmp2MenuResult.NumElements > 0 Then tmpMenuResult.NumElements += 1
                                    tmpMenuResult.TotalElements += tmp2MenuResult.NumElements

                                    retValue = arrTemplateContent(currentMenuLevel).ToString.Replace("[[menu]]", tmp2MenuResult.HTMLResult)

                                    tmpMenuResult.TotalElements += 1
                                    If tmp2MenuResult.NumElements = 0 Then tmpMenuResult.NumElements += 1
                                    tmpMenuResult.HTMLResult = retValue
                                    If UseHeaderFooterTemplate Then
                                        If tmpMenuResult.NumElements = 1 Then
                                            thisMenu.OpenMenuTag = arrTemplateHeader(currentMenuLevel)
                                        End If
                                        If ((CountRecords = TotRecords) And (tmpMenuResult.NumElements > 0)) Then
                                            thisMenu.CloseMenuTag = arrTemplateFooter(currentMenuLevel)
                                        End If
                                    End If

                                    thisMenu.HTMLText = tmpMenuResult.HTMLResult
                                    thisMenu.CurrentMenuLevel = currentMenuLevel

                                    tmpMenuResult.MenuItem = thisMenu

                                    arrMenuPage.Add(thisMenu)
                                Else
                                    If LEVELDepth < tmpStartDepth Then
                                        If tmpThisMenuPage.Menu.codPaginaMadre > 0 Then

                                            If Not menuLevelAdded And LEVELDepth >= tmpStartDepth Then
                                                If TotalArrTemplateIndex > currentMenuLevel Then currentMenuLevel += 1
                                                LastMenuItemDepthFound = currentMenuLevel
                                                menuLevelAdded = True
                                            End If

                                            If (LEVELDepth + 1) = tmpStartDepth Then UseHeaderFooterTemplate = False

                                            thisMenu = New Menu.ClassMenu(tmpThisMenuPage.Page, tmpThisMenuPage.Menu)

                                            If ShowSubMenu And tmpThisMenuPage.Menu.codPaginaMadre > 0 And LEVELDepth < (tmpStartDepth + tmpDepth) Then
                                                'thisMenu.Add = GenerateMenu(CurrentID, CurrentPageDepth, TemplateEmpty, LastMenuItemDepthFound, retValue, LEVELDepth, tmpThisMenuPage.Page, tmpThisMenuPage.Menu, tmpExclude_id, CurrentArrTemplateIndex, TotalArrTemplateIndex, arrTemplateHeader, arrTemplateContent, arrTemplateFooter, tmpShowOnly_id, tmpThisMenuPage.Menu.CompareBy, dictCustomOrders, tmpOrderByMenuIndex, tmpSortOrder, tmpStartDepth, tmpDepth, cssClass, menu_hide_children, UseHeaderFooterTemplate, RootFound)
                                                thisMenu.Add = GenerateMenu(CurrentID, CurrentPageDepth, TemplateEmpty, LastMenuItemDepthFound, retValue, LEVELDepth, thisMenu.Page, thisMenu.Menu, tmpExclude_id, CurrentArrTemplateIndex, TotalArrTemplateIndex, arrTemplateHeader, arrTemplateContent, arrTemplateFooter, tmpShowOnly_id, tmpThisMenuPage.Menu.CompareBy, dictCustomOrders, tmpOrderByMenuIndex, tmpSortOrder, tmpStartDepth, tmpDepth, cssClass, menu_hide_children, UseHeaderFooterTemplate, RootFound, HideErrors, tmpDbCommand, tmpDbConnection)
                                                tmp2MenuResult.NumElements = thisMenu.NumOfSubMenu
                                                If thisMenu.NumOfSubMenu > 0 Then tmp2MenuResult.HTMLResult = thisMenu.SubMenuList(thisMenu.NumOfSubMenu - 1).HTMLText
                                            End If

                                            If (LEVELDepth + 1) = tmpStartDepth Then
                                                UseHeaderFooterTemplate = True
                                            Else
                                                UseHeaderFooterTemplate = False
                                            End If


                                            If tmp2MenuResult.NumElements > 0 Then tmpMenuResult.NumElements += 1
                                            tmpMenuResult.TotalElements += tmp2MenuResult.NumElements

                                            If tmp2MenuResult.NumElements > 0 Then
                                                tmpMenuResult.HTMLResult = tmp2MenuResult.HTMLResult
                                                If UseHeaderFooterTemplate Then
                                                    If TotalArrTemplateIndex > currentMenuLevel Then
                                                        If tmpMenuResult.NumElements = 1 Then
                                                            thisMenu.OpenMenuTag = arrTemplateHeader(currentMenuLevel + 1)
                                                        End If
                                                        If ((CountRecords = TotRecords) And (tmpMenuResult.NumElements > 0)) Then
                                                            thisMenu.CloseMenuTag = arrTemplateFooter(currentMenuLevel + 1)
                                                        End If
                                                    Else
                                                        If tmpMenuResult.NumElements = 1 Then
                                                            thisMenu.OpenMenuTag = arrTemplateHeader(currentMenuLevel)
                                                        End If
                                                        If ((CountRecords = TotRecords) And (tmpMenuResult.NumElements > 0)) Then
                                                            thisMenu.CloseMenuTag = arrTemplateFooter(currentMenuLevel)
                                                        End If
                                                    End If
                                                End If
                                            End If

                                            thisMenu.HTMLText = tmpMenuResult.HTMLResult
                                            thisMenu.CurrentMenuLevel = currentMenuLevel

                                            tmpMenuResult.MenuItem = thisMenu

                                            arrMenuPage.Add(thisMenu)
                                        End If
                                    End If
                                    If LEVELDepth > tmpStartDepth Then

                                        If Not menuLevelAdded And LEVELDepth >= tmpStartDepth Then
                                            If TotalArrTemplateIndex > currentMenuLevel Then currentMenuLevel += 1
                                            LastMenuItemDepthFound = currentMenuLevel
                                            menuLevelAdded = True
                                        End If

                                        thisMenu = New Menu.ClassMenu(tmpThisMenuPage.Page, tmpThisMenuPage.Menu)

                                        If ShowSubMenu And tmpThisMenuPage.Menu.codPaginaMadre > 0 And LEVELDepth < (tmpStartDepth + tmpDepth) Then
                                            'thisMenu.Add = GenerateMenu(CurrentID, CurrentPageDepth, TemplateEmpty, LastMenuItemDepthFound, retValue, LEVELDepth, tmpThisMenuPage.Page, tmpThisMenuPage.Menu, tmpExclude_id, CurrentArrTemplateIndex, TotalArrTemplateIndex, arrTemplateHeader, arrTemplateContent, arrTemplateFooter, tmpShowOnly_id, tmpThisMenuPage.Menu.CompareBy, dictCustomOrders, tmpOrderByMenuIndex, tmpSortOrder, tmpStartDepth, tmpDepth, cssClass, menu_hide_children, UseHeaderFooterTemplate, RootFound)
                                            thisMenu.Add = GenerateMenu(CurrentID, CurrentPageDepth, TemplateEmpty, LastMenuItemDepthFound, retValue, LEVELDepth, thisMenu.Page, thisMenu.Menu, tmpExclude_id, CurrentArrTemplateIndex, TotalArrTemplateIndex, arrTemplateHeader, arrTemplateContent, arrTemplateFooter, tmpShowOnly_id, tmpThisMenuPage.Menu.CompareBy, dictCustomOrders, tmpOrderByMenuIndex, tmpSortOrder, tmpStartDepth, tmpDepth, cssClass, menu_hide_children, UseHeaderFooterTemplate, RootFound, HideErrors, tmpDbCommand, tmpDbConnection)
                                            tmp2MenuResult.NumElements = thisMenu.NumOfSubMenu
                                            If thisMenu.NumOfSubMenu > 0 Then tmp2MenuResult.HTMLResult = thisMenu.SubMenuList(thisMenu.NumOfSubMenu - 1).HTMLText
                                        End If

                                        If tmp2MenuResult.NumElements > 0 Then tmpMenuResult.NumElements += 1
                                        tmpMenuResult.TotalElements += tmp2MenuResult.NumElements

                                        retValue = arrTemplateContent(currentMenuLevel).ToString.Replace("[[menu]]", tmp2MenuResult.HTMLResult)

                                        tmpMenuResult.TotalElements += 1
                                        If tmp2MenuResult.NumElements = 0 Then tmpMenuResult.NumElements += 1
                                        tmpMenuResult.HTMLResult = retValue
                                        If UseHeaderFooterTemplate Then
                                            If tmpMenuResult.NumElements = 1 Then
                                                thisMenu.OpenMenuTag = arrTemplateHeader(currentMenuLevel)
                                            End If
                                            If ((CountRecords = TotRecords) And (tmpMenuResult.NumElements > 0)) Then
                                                thisMenu.CloseMenuTag = arrTemplateFooter(currentMenuLevel)
                                            End If
                                        End If

                                        thisMenu.HTMLText = tmpMenuResult.HTMLResult
                                        thisMenu.CurrentMenuLevel = currentMenuLevel

                                        tmpMenuResult.MenuItem = thisMenu

                                        arrMenuPage.Add(thisMenu)
                                    End If
                                End If
                            End If
                        End If
                    End If
                End With
            End While

            tmpReader.Close()
            'db.CloseConn(True, tmpDbConnection)

            If arrMenuPage.Count > 0 Then
                tmpOpenMenuTag = arrMenuPage.Item(0).OpenMenuTag
                tmpCloseMenuTag = arrMenuPage.Item(arrMenuPage.Count - 1).CloseMenuTag

                Dim menu_comparer As New Menu.MenuComparer
                arrMenuPage.Sort(menu_comparer)
                retValue = ""
                Dim tmpClassMenu As Menu.ClassMenu

                For i As Integer = 0 To arrMenuPage.Count - 1
                    tmpClassMenu = arrMenuPage(i)

                    tmpCssClassesStatus = New _cmsMenuCssClasses

                    With tmpCssClassesStatus
                        If i = 0 Then .first = True
                        If i = (arrMenuPage.Count - 1) Then .last = True
                        If tmpClassMenu.NumOfSubMenu > 0 Then .parent = True
                        If CurrentID = tmpClassMenu.Page.idPagina Then .active = True
                    End With

                    tmpClassMenu.HTMLFullPage = tmpClassMenu.HTMLText

                    If tmpClassMenu.HTMLFullPage.Contains("<jcms") Then
                        ParseListCommands(tmpClassMenu.Page, tmpClassMenu.Menu, True, tmpDbCommand, tmpDbConnection)
                        ParseTemplateVars(tmpClassMenu.Page, tmpClassMenu.Menu, False, True, CurrentID, True, tmpDbCommand, tmpDbConnection)
                        tmpClassMenu.HTMLFullPage = ParsePageVars(tmpClassMenu.Page, tmpClassMenu.Menu, False, True, CurrentID, True, tmpDbCommand, tmpDbConnection)
                        tmpClassMenu.HTMLFullPage = ParseChuhnksVars(tmpClassMenu.Page, tmpClassMenu.Menu, , True, , True, tmpDbCommand, tmpDbConnection)
                    End If

                    If Not HideErrors Then
                        If Not IsNothing(tmpClassMenu.Page._CMS_Warning) AndAlso tmpClassMenu.Page._CMS_Warning.Length > 0 Then
                            tmpPage._CMS_Warning &= tmpClassMenu.Page._CMS_Warning
                        End If
                    End If

                    tmpClassMenu.HTMLText = tmpClassMenu.Page.HTMLFullPage
                    tmpClassMenu.HTMLText = tmpClassMenu.HTMLText.Replace("[[css]]", BuildCssClass(cssClass, tmpCssClassesStatus, tmpClassMenu.CurrentMenuLevel, tmpClassMenu.Page.idPagina))
                    retValue &= tmpClassMenu.HTMLText
                Next

                arrMenuPage.Item(0).OpenMenuTag = tmpOpenMenuTag
                arrMenuPage.Item(arrMenuPage.Count - 1).CloseMenuTag = tmpCloseMenuTag
                arrMenuPage.Item(arrMenuPage.Count - 1).HTMLText = tmpOpenMenuTag & retValue & tmpCloseMenuTag
            End If

            Return arrMenuPage
        End Function

        Private Function BuildCssClass(ByVal MenuCssClasses As _cmsMenuCssClasses, ByVal CurrentItemClasses As _cmsMenuCssClasses, ByVal currentMenuLevel As Long, ByVal idPagina As Long) As String
            Dim retValue As String = ""

            With MenuCssClasses
                If .level Then retValue &= "level" & currentMenuLevel + 1 & " "
                If .first And CurrentItemClasses.first And Not CurrentItemClasses.last Then retValue &= "first "
                If .active And CurrentItemClasses.active Then retValue &= "active "
                If .parent And CurrentItemClasses.parent Then retValue &= "parent "
                If .last And CurrentItemClasses.last And Not CurrentItemClasses.first Then retValue &= "last "
                If .id Then retValue &= idPagina
            End With

            Return retValue.Trim
        End Function

        Public Function GetFolderPathParent(ByVal tmpFolderPath As String, ByVal tmpStartDepth As Long, Optional ByVal Separator As String = "\") As String
            Dim tmpArr2 As String() = tmpFolderPath.Split(Separator)
            tmpStartDepth = Math.Abs(tmpStartDepth)

            Dim tmpArr As New ArrayList

            For i As Integer = 0 To tmpArr2.Length - 1
                If tmpArr2(i).Trim <> "" Then
                    tmpArr.Add(tmpArr2(i))
                End If
            Next

            Dim retValue As String = ""

            For i As Integer = 0 To (tmpArr.Count - 1 - tmpStartDepth)
                If i = 0 Then
                    retValue = Separator & tmpArr(i) & Separator
                Else
                    retValue &= tmpArr(i) & Separator
                End If
            Next

            Return retValue
        End Function

        Private Function GetIdRootPageFromIdPage(ByVal codPagina As Long, ByVal idLingua As Long, Optional ByRef tmpDbCommand As OleDbCommand = Nothing, Optional ByRef tmpDbConnection As OleDbConnection = Nothing) As String
            Dim twoDigits As String = GetTwoDigitsFromidLingua(idLingua, tmpDbCommand, tmpDbConnection)
            Dim tmpPage As _cmsPage = GetHomePageByLanguageName(GetLanguageNameFromPagePath(GetFolderPathFromCodPaginaAndIdLingua(codPagina, idLingua, tmpDbCommand, tmpDbConnection).Replace("\", "/"), twoDigits))
            Dim retValue As Long = tmpPage.idPagina
            Return retValue
        End Function

        Public Sub JertCMS_SubstListTAG(ByVal regexTAG As String, ByRef cmsPage As _cmsPage, ByRef Menu As _cmsVoceDiMenu, Optional ByVal HideErrors As Boolean = False, Optional ByRef tmpDbCommand As OleDbCommand = Nothing, Optional ByRef tmpDbConnection As OleDbConnection = Nothing)
            Dim regex As New Regex(regexTAG, RegexOptions.IgnoreCase)
            Dim matches As MatchCollection = regex.Matches(cmsPage.HTMLFullPage)
            Dim match As Match


            Dim type As String = ""
            Dim page_id As String = ""
            Dim order_by_tvpage As String = ""
            Dim sort_order As String = ""
            Dim display As String = ""
            Dim pagination As String = ""
            Dim exclude_id As String = ""
            Dim start_depth As String = ""
            Dim depth As String = ""
            Dim Value As String = ""
            Dim tmpWarning As String = ""
            Dim ContentOfListCommand As String = ""

            For Each match In matches
                type = ""
                page_id = ""
                order_by_tvpage = ""
                sort_order = ""
                display = ""
                pagination = ""
                exclude_id = ""
                start_depth = ""
                depth = ""
                Value = ""
                tmpWarning = ""
                ContentOfListCommand = ""

                For i As Long = 0 To match.Groups("value").Captures.Count - 1
                    Value = match.Groups("value").Captures(i).ToString

                    Select Case match.Groups("attribute").Captures(i).ToString.ToLower
                        Case "type" : type = Value : If type <> "list" Then Exit For
                        Case "page_id" : page_id = Value
                        Case "order_by_tvpage" : order_by_tvpage = Value
                        Case "sort_order" : sort_order = Value
                        Case "display" : display = Value
                        Case "pagination" : pagination = Value
                        Case "exclude_id" : exclude_id = Value
                        Case "start_depth" : start_depth = Value
                        Case "depth" : depth = Value

                        Case Else
                            'TODO da globalizzare..
                            tmpWarning = "<br />--- Attributo non riconosciuto: <strong>" & match.Groups("attribute").Captures(i).ToString.ToLower & "=""" & Value & """</strong> <br />Nel comando: <strong>" & match.Value.ToString.Replace("<", "&lt;").Replace(">", "&gt;") & "</strong>"
                    End Select
                Next i

                ContentOfListCommand = match.Groups("contentList").ToString

                If type = "list" Then
                    If tmpWarning.Length = 0 Then cmsPage.HTMLFullPage = cmsPage.HTMLFullPage.Replace(match.Value.ToString, JertCMS_ReadListContent(match.Value.ToString, cmsPage, Menu, ContentOfListCommand, page_id, order_by_tvpage, sort_order, display, pagination, exclude_id, start_depth, depth, HideErrors, tmpDbCommand, tmpDbConnection))
                    If tmpWarning.Length > 0 Then
                        cmsPage._CMS_Warning &= tmpWarning
                    End If
                End If
            Next match
        End Sub

        Private Function IsInExcludeIDList(ByVal IdList As String(), ByVal IdToCheck As String, ByVal CurrentID As String) As Boolean
            Dim retValue As Boolean = False

            For i As Integer = 0 To IdList.Length - 1
                If IdList(i).ToLower = "current" Then IdList(i) = CurrentID

                If IsNumeric(IdList(i)) = False Then IdList(i) = ""

                If IdList(i) = IdToCheck Then
                    Return True
                End If
            Next

            Return retValue
        End Function

        Public Function JertCMS_GetContentTAG(ByVal regexTAG As String, ByVal TextToParse As String, ByVal RegExGroupToFind As String, Optional ByRef Found As Boolean = False) As String
            Dim retValue As String = ""

            Found = False

            Dim regex As New Regex(regexTAG, RegexOptions.IgnoreCase)
            Dim matches As MatchCollection = regex.Matches(TextToParse)
            Dim match As Match
            For Each match In matches
                retValue &= match.Groups(RegExGroupToFind).ToString
                Found = True
            Next match

            Return retValue
        End Function


        Private Function JertCMS_ReadListContent(ByVal CommandToSearch As String, ByRef cmsPage As _cmsPage, ByRef Menu As _cmsVoceDiMenu, ByVal Content As String, ByVal page_id As String, ByVal order_by_tvpage As String, ByVal sort_order As String, ByVal display As String, ByVal pagination As String, ByVal exclude_id As String, ByVal start_depth As String, ByVal depth As String, Optional ByVal HideErrors As Boolean = False, Optional ByRef tmpDbCommand As OleDbCommand = Nothing, Optional ByRef tmpDbConnection As OleDbConnection = Nothing) As String
            'TODO spostare la dichiarazione delle variabili fuori dal ciclo for

            Dim retValue As String = CommandToSearch

            Dim tmpArrPage_id As String() = page_id.Split("|")
            Dim tmpExclude_id As String() = exclude_id.Split("|")

            Dim tmpListFoundedIDPages As String = ""


            'Template **************************
            Dim Template_Header As String = ""
            Dim Template_Body As String = ""
            Dim Template_Footer As String = ""
            'Fine Template *********************
            'Pagination **************************
            Dim Pagination_First As String = ""
            Dim Pagination_Body As String = ""
            Dim Pagination_Last As String = ""
            'Fine Pagination *********************
            'No Elements **************************
            Dim NoElemnts As String = ""
            'Fine No Elements *********************


            Dim tmpMaxElements As Long = -1
            Dim tmpPagination As Long = -1
            Dim tmpStartDepth As Long = -1
            Dim tmpDepth As Long = -1

            Dim tmpSortOrder As String = ""
            Dim tmpOrderBy As String = ""

            'display è opzionale... -1 = tutti gli elementi..
            If display.Length > 0 Then
                If HideErrors Then
                    tmpMaxElements = Convert.ToInt32(display)
                Else
                    If IsNumeric(display) Then
                        tmpMaxElements = Convert.ToInt32(display)
                    Else
                        cmsPage._CMS_Warning &= "<br />--- Attributo non riconosciuto: <strong>display=""" & display & """</strong> <br />Nel comando: <strong>" & CommandToSearch.Replace("<", "&lt;").Replace(">", "&gt;") & "</strong>"
                        Return retValue
                    End If
                End If
            End If

            'pagination è opzionale... -1 = tutti gli elementi..
            If pagination.Length > 0 Then
                If HideErrors Then
                    tmpPagination = Convert.ToInt32(pagination)
                Else
                    If IsNumeric(pagination) Then
                        tmpPagination = Convert.ToInt32(pagination)
                    Else
                        cmsPage._CMS_Warning &= "<br />--- Attributo non riconosciuto: <strong>pagination=""" & pagination & """</strong> <br />Nel comando: <strong>" & CommandToSearch.Replace("<", "&lt;").Replace(">", "&gt;") & "</strong>"
                        Return retValue
                    End If
                End If
            End If

            If start_depth.Length > 0 Then
                If HideErrors Then
                    tmpStartDepth = Convert.ToInt32(start_depth)
                Else
                    If IsNumeric(start_depth) = True Then
                        tmpStartDepth = Convert.ToInt32(start_depth)
                    Else
                        cmsPage._CMS_Warning &= "<br />--- Attributo non riconosciuto: <strong>start_depth=""" & start_depth & """</strong> <br />Nel comando: <strong>" & CommandToSearch.Replace("<", "&lt;").Replace(">", "&gt;") & "</strong>"
                        Return retValue
                    End If
                End If
            Else
                tmpStartDepth = 0
            End If

            If depth.Length > 0 Then
                If HideErrors Then
                    tmpDepth = Convert.ToInt32(depth)
                Else
                    If IsNumeric(depth) = True Then
                        tmpDepth = Convert.ToInt32(depth)
                    Else
                        cmsPage._CMS_Warning &= "<br />--- Attributo non riconosciuto: <strong>depth=""" & depth & """</strong> <br />Nel comando: <strong>" & CommandToSearch.Replace("<", "&lt;").Replace(">", "&gt;") & "</strong>"
                        Return retValue
                    End If
                End If
            Else
                tmpDepth = 0
            End If

            If order_by_tvpage.Length > 0 Then
                If HideErrors Then
                    tmpOrderBy = order_by_tvpage
                Else
                    If checkFieldNameExist(order_by_tvpage) Then
                        tmpOrderBy = order_by_tvpage
                    Else
                        cmsPage._CMS_Warning &= "<br />--- Attributo non riconosciuto: <strong>order_by_tvpage=""" & order_by_tvpage & """</strong> <br />Nel comando: <strong>" & CommandToSearch.Replace("<", "&lt;").Replace(">", "&gt;") & "</strong>"
                        Return retValue
                    End If
                End If
            Else
                cmsPage._CMS_Warning &= "<br />--- Attributo non riconosciuto: <strong>order_by_tvpage=""" & order_by_tvpage & """</strong> <br />Nel comando: <strong>" & CommandToSearch.Replace("<", "&lt;").Replace(">", "&gt;") & "</strong>"
                Return retValue
            End If

            If sort_order.Length > 0 Then
                sort_order = sort_order.ToLower

                If sort_order = "asc" Or sort_order = "desc" Then
                    tmpSortOrder = sort_order
                Else
                    cmsPage._CMS_Warning &= "<br />--- Attributo non riconosciuto: <strong>sort_order=""" & sort_order & """</strong> <br />Nel comando: <strong>" & CommandToSearch.Replace("<", "&lt;").Replace(">", "&gt;") & "</strong>"
                    Return retValue
                End If
            Else
                tmpSortOrder = "asc"
            End If

            With cmsPage
                If tmpArrPage_id.Length > 0 Then
                    'Ciclo e verifico ogni id...
                    Dim tmpPageID As Long
                    Dim startDepthList As String
                    Dim tmpPage As _cmsPage
                    Dim tmpMenu As _cmsVoceDiMenu

                    For i As Integer = 0 To tmpArrPage_id.Length - 1
                        If tmpArrPage_id(i).ToLower = "current" Then tmpArrPage_id(i) = cmsPage.idPagina

                        If IsNumeric(tmpArrPage_id(i)) Then
                            tmpPageID = Convert.ToInt32(tmpArrPage_id(i))
                            startDepthList = ""
                            tmpPage = New _cmsPage
                            tmpPage = GetPageByID(tmpArrPage_id(i), tmpDbCommand, tmpDbConnection)

                            If tmpPage.idErrore = 0 Then
                                'id Pagina esiste...

                                'tmpMenu = GetVoceMenuFromFolderPath(GetFolderPathFromCodPaginaAndIdLingua(tmpPage.codPagina, tmpPage.idLingua, tmpDbCommand, tmpDbConnection), tmpPage.idLingua, tmpDbCommand, tmpDbConnection)
                                tmpMenu = GetVoceMenuFromFolderPath(tmpPage.FolderPath, tmpPage.idLingua, tmpDbCommand, tmpDbConnection)

                                'Recupero gli id delle pagine...... separati da virgole
                                startDepthList = JertCMS_GetIDListByDepth(tmpExclude_id, tmpPageID, tmpMenu.ProfonditaLivello, tmpMenu.folderpath, tmpStartDepth, tmpDepth, tmpMenu.idLingua, tmpDbCommand, tmpDbConnection)

                                'Creo la lista degli id delle pagine...
                                If tmpListFoundedIDPages.Length > 0 Then
                                    tmpListFoundedIDPages &= "," & startDepthList
                                Else
                                    tmpListFoundedIDPages = startDepthList
                                End If

                            End If
                        Else
                            cmsPage._CMS_Warning &= "<br />--- Id Pagina errato [" & tmpArrPage_id(i) & "] <strong>page_id=""" & page_id & """</strong> <br />Nel comando: <strong>" & CommandToSearch.Replace("<", "&lt;").Replace(">", "&gt;") & "</strong>"
                            Return retValue
                        End If
                    Next
                Else
                    cmsPage._CMS_Warning &= "<br />--- Attributo non riconosciuto: <strong>page_id=""" & page_id & """</strong> <br />Nel comando: <strong>" & CommandToSearch.Replace("<", "&lt;").Replace(">", "&gt;") & "</strong>"
                    Return retValue
                End If


                'Prendo i No elements..
                NoElemnts = JertCMS_GetContentTAG("(?:<no_elements>(?<no_elements>[\s\S]*?)</no_elements>)", Content, "no_elements")

                'Prendo i Pagination..
                Pagination_First = JertCMS_GetContentTAG("(?:<pagination_first>(?<pagination_first>[\s\S]*?)</pagination_first>)", Content, "pagination_first")
                Pagination_Body = JertCMS_GetContentTAG("(?:<pagination>(?<pagination>[\s\S]*?)</pagination>)", Content, "pagination")
                Pagination_Last = JertCMS_GetContentTAG("(?:<pagination_last>(?<pagination_last>[\s\S]*?)</pagination_last>)", Content, "pagination_last")

                'Separo i template..
                Template_Header = JertCMS_GetContentTAG("(?:<template_header>(?<template_header>[\s\S]*?)</template_header>)", Content, "template_header")
                Template_Body = JertCMS_GetContentTAG("(?:<template>(?<template>[\s\S]*?)</template>)", Content, "template")
                Template_Footer = JertCMS_GetContentTAG("(?:<template_footer>(?<template_footer>[\s\S]*?)</template_footer>)", Content, "template_footer")

                'Sostituisco i Paginations nei template...
                Template_Header = SubstPagination(Template_Header, Pagination_First, Pagination_Body, Pagination_Last)
                Template_Body = SubstPagination(Template_Body, Pagination_First, Pagination_Body, Pagination_Last)
                Template_Footer = SubstPagination(Template_Footer, Pagination_First, Pagination_Body, Pagination_Last)


                'Ho gli id delle pagine.....
                If tmpListFoundedIDPages.Length = 0 Then
                    retValue = NoElemnts
                Else
                    Dim tmpSql As String = ""
                    Dim CountElements As Long = 1

                    If tmpMaxElements <> -1 Then
                        tmpSql = "SELECT TOP " & tmpMaxElements & " * FROM Pagine WHERE idPagina IN(" & tmpListFoundedIDPages & ") " & CreateOrderBy(tmpOrderBy, tmpSortOrder)
                    Else
                        tmpSql = "SELECT * FROM Pagine WHERE idPagina IN(" & tmpListFoundedIDPages & ") " & CreateOrderBy(tmpOrderBy, tmpSortOrder)
                    End If

                    retValue = Template_Header

                    Dim tmpDbCommand2 As New OleDbCommand
                    Dim tmpDbConnection2 As New OleDbConnection
                    Dim tmpReader2 As OleDbDataReader

                    If IsNothing(tmpDbConnection) Then
                        db.OpenConn(tmpSql)
                        tmpReader2 = db.ExecuteReader()
                    Else
                        db.OpenConn(tmpSql, , , True, tmpDbConnection, tmpDbCommand)
                        tmpReader2 = db.ExecuteReader(True, tmpDbCommand)
                    End If

                    Dim tmpInListPage As New _cmsPage
                    Dim tmpInListMenu As New _cmsVoceDiMenu

                    While tmpReader2.Read
                        'page_id="list"

                        With tmpInListPage
                            tmpInListPage.idPagina = tmpReader2("idPagina")
                            tmpInListPage.idTemplate = tmpReader2("idTemplate")
                            tmpInListPage.codPagina = tmpReader2("codPagina")
                            tmpInListPage.idLingua = tmpReader2("idLingua")

                            tmpInListPage.HTMLFullPage = Template_Body
                        End With

                        ParseTemplateVars(tmpInListPage, tmpInListMenu, True, , , HideErrors, tmpDbCommand2, tmpDbConnection2)
                        ParsePageVars(tmpInListPage, tmpInListMenu, True, , , HideErrors, tmpDbCommand2, tmpDbConnection2)

                        tmpInListPage.HTMLFullPage = myRegex.ReplaceText("<\s*jcms\s+type=""\s*list_number\s*""\s*/>", tmpInListPage.HTMLFullPage, CountElements)

                        retValue &= tmpInListPage.HTMLFullPage

                        CountElements += 1
                    End While

                    tmpReader2.Close()
                    If IsNothing(tmpDbConnection) Then db.CloseConn()

                    'db.CloseConn(True, tmpDbConnection2)

                    retValue &= Template_Footer
                End If
            End With

            Return retValue
        End Function

        Private Function JertCMS_GetIDListByDepth(ByVal IdList As String(), ByVal PageID As Long, ByVal ProfonditaLivello As Long, ByVal FolderPath As String, ByVal StartDepth As Long, ByVal Depth As Long, ByVal idLingua As Long, Optional ByRef tmpDbCommand As OleDbCommand = Nothing, Optional ByRef tmpDbConnection As OleDbConnection = Nothing) As String
            Dim retValue As String = ""

            Dim tmpSQL As String

            If FolderPath.Length > 1 Then
                tmpSQL = "SELECT Menu.folderpath, Menu.idVoce, Menu.IdLingua FROM Menu WHERE folderpath like """ & FolderPath & "%"""
            Else
                tmpSQL = "SELECT Menu.folderpath, Menu.idVoce, Menu.IdLingua FROM Menu WHERE folderpath like """ & FolderPath & "%"" AND idLingua = " & idLingua
            End If

            Dim tmpDbCommand2 As New OleDbCommand
            Dim tmpDbConnection2 As New OleDbConnection
            Dim tmpReader As OleDbDataReader

            If IsNothing(tmpDbConnection) Then
                db.OpenConn(tmpSQL)
                tmpReader = db.ExecuteReader()
            Else
                db.OpenConn(tmpSQL, , , True, tmpDbConnection, tmpDbCommand)
                tmpReader = db.ExecuteReader(True, tmpDbCommand)
            End If

            Dim tmpIdVociTrovate As String = ""
            Dim tmpFolderPath As String = ""

            Dim tmpIdVoce As Long

            Dim tmpMenu As _cmsVoceDiMenu
            Dim tmpPage As New _cmsPage
            Dim tmpIdLingua As Long = -1

            While tmpReader.Read
                tmpIdVoce = tmpReader("idVoce")
                tmpFolderPath = tmpReader("folderpath")
                tmpIdLingua = tmpReader("IdLingua")

                tmpMenu = GetVoceMenuFromFolderPath(tmpFolderPath.Replace("/", "\"), tmpIdLingua)
                JertCMS_ReadPageContent(tmpMenu, tmpPage, tmpIdLingua, tmpDbCommand2, tmpDbConnection2)

                'Verifico StartDepth e Depth...
                If PathDepthIsValid(ProfonditaLivello, tmpMenu.ProfonditaLivello, StartDepth, Depth) Then
                    If IsInExcludeIDList(IdList, tmpPage.idPagina, PageID) = False Then
                        tmpIdVociTrovate &= tmpPage.idPagina & ","
                    End If
                End If
            End While

            tmpReader.Close()
            'db.CloseConn(True, tmpDbConnection)
            If IsNothing(tmpDbConnection) Then db.CloseConn()

            If tmpIdVociTrovate.EndsWith(",") Then tmpIdVociTrovate = tmpIdVociTrovate.Substring(0, tmpIdVociTrovate.Length - 1)
            retValue = tmpIdVociTrovate

            Return retValue
        End Function

        Private Function PathDepthIsValid(ByVal ProfonditaLivelloPagina As Long, ByVal ProfonditaLivelloPaginaDaVerificare As Long, ByVal StartDepth As Long, ByVal Depth As Long) As Boolean
            Dim retValue As Boolean = False

            If (ProfonditaLivelloPaginaDaVerificare >= (ProfonditaLivelloPagina + StartDepth)) And (ProfonditaLivelloPaginaDaVerificare <= (ProfonditaLivelloPagina + StartDepth + Depth)) Then
                Return True
            End If

            Return retValue
        End Function

        Private Function SubstPagination(ByVal CommandHTML As String, ByVal PaginationFirst As String, ByVal Pagination As String, ByVal PaginationLast As String) As String
            Dim retValue As String = CommandHTML
            CommandHTML = CommandHTML.Replace("<pagination_first>", PaginationFirst).Replace("<pagination>", Pagination).Replace("<pagination_last>", PaginationLast)
            Return retValue
        End Function

        Private Function ParseTags(ByVal HtmlPage As String, ByVal Menu_ProfonditaLivello As Long, ByVal Menu_Ordine As Long, ByVal Menu_FolderPath As String, ByVal Menu_idLingua As Long, ByVal Menu_CodPaginaMadre As Long) As String
            'TODO Funzione da eliminare con relative sottofunzioni..

            Try
                HtmlPage = HtmlPage.Replace("[jcms:slideshow]", JertCMS_WriteSlideShow(Menu_ProfonditaLivello, Menu_FolderPath, Menu_CodPaginaMadre, Menu_idLingua))
                HtmlPage = HtmlPage.Replace("[jcms:h1]", JertCMS_WriteH1(Menu_ProfonditaLivello, Menu_Ordine, Menu_FolderPath, Menu_idLingua))

                HtmlPage = JertCMS_SubstLightboxTAG("\[jcms:lightbox\]", HtmlPage, Menu_FolderPath)

                HtmlPage = JertCMS_SubstGalleryMenuTAG("\[jcms:MenuGallery\]", HtmlPage)
                HtmlPage = JertCMS_SubstImageTAG("\[jcms:img\s(?<idImmagine>\d+)\]", HtmlPage, Menu_ProfonditaLivello, Menu_FolderPath, Menu_CodPaginaMadre, Menu_idLingua)

                HtmlPage = JertCMS_SubstFileTAG("\[jcms:file\s(?<idFile>\d+)\]", HtmlPage)

                HtmlPage = JertCMS_SubstMenuTAG("\[jcms:Menu\]", HtmlPage)

                Return HtmlPage
            Catch ex As Exception
                Return ex.Message
            End Try
        End Function

        Public Function JertCMS_ChunkExist(ByVal regexTAG As String, ByVal HtmlText As String, ByVal NameOfChunk As String, ByVal CategoryOfChunk As String, Optional ByVal SearchAnyChunk As Boolean = False) As Boolean
            Dim retValue As Boolean = False

            Dim regex As New Regex(regexTAG, RegexOptions.IgnoreCase)
            Dim matches As MatchCollection = regex.Matches(HtmlText)
            Dim match As Match
            For Each match In matches
                Dim type As String = ""
                Dim name As String = ""
                Dim category As String = ""

                Dim Value As String = ""

                Dim tmpWarning As String = ""

                For i As Long = 0 To match.Groups("value").Captures.Count - 1
                    Value = match.Groups("value").Captures(i).ToString

                    Select Case match.Groups("attribute").Captures(i).ToString.ToLower
                        Case "type" : type = Value
                        Case "name" : name = Value
                        Case "category" : category = Value
                    End Select
                Next i

                If type = "chunk" Then
                    If SearchAnyChunk = True Then
                        retValue = True
                    Else
                        If name.ToLower.Trim = NameOfChunk.ToLower.Trim And category.ToLower.Trim = CategoryOfChunk.ToLower.Trim Then
                            retValue = True
                        End If
                    End If
                End If
            Next match

            Return retValue
        End Function

        Public Function getArrModulesCommands(ByVal regexTAG As String, ByVal HtmlText As String) As String()
            Dim ListCommands As New ArrayList

            Dim regex As New Regex(regexTAG, RegexOptions.IgnoreCase)
            Dim matches As MatchCollection = regex.Matches(HtmlText)
            Dim match As Match
            For Each match In matches
                Dim type As String = ""
                Dim name As String = ""
                Dim component As String = ""
                Dim CustomID As String = ""

                Dim Value As String = ""

                Dim tmpWarning As String = ""

                For i As Long = 0 To match.Groups("value").Captures.Count - 1
                    Value = match.Groups("value").Captures(i).ToString

                    Select Case match.Groups("attribute").Captures(i).ToString.ToLower
                        Case "type" : type = Value : If type <> "module" Then Exit For
                        Case "name" : name = Value
                        Case "component" : component = Value
                        Case "id" : CustomID = Value
                    End Select
                Next i

                If type = "module" Then
                    ListCommands.Add(match.Value.Trim)
                End If
            Next match

            Return ListCommands.ToArray(GetType(String))
        End Function

        Public Function JertCMS_ModuleExist(ByVal regexTAG As String, ByVal HtmlText As String, ByVal NameOfModule As String, ByVal ComponentOfModule As String, Optional ByVal SearchAnyModule As Boolean = False) As Boolean
            Dim retValue As Boolean = False

            Dim regex As New Regex(regexTAG, RegexOptions.IgnoreCase)
            Dim matches As MatchCollection = regex.Matches(HtmlText)
            Dim match As Match
            For Each match In matches
                Dim type As String = ""
                Dim name As String = ""
                Dim component As String = ""

                Dim Value As String = ""

                Dim tmpWarning As String = ""

                For i As Long = 0 To match.Groups("value").Captures.Count - 1
                    Value = match.Groups("value").Captures(i).ToString

                    Select Case match.Groups("attribute").Captures(i).ToString.ToLower
                        Case "type" : type = Value : If type <> "module" Then Exit For
                        Case "name" : name = Value
                        Case "component" : component = Value
                    End Select
                Next i

                If type = "module" Then
                    If SearchAnyModule = True Then
                        retValue = True
                    Else
                        If name.ToLower.Trim = NameOfModule.ToLower.Trim And component.ToLower.Trim = ComponentOfModule.ToLower.Trim Then
                            retValue = True
                        End If
                    End If
                End If
            Next match

            Return retValue
        End Function

        Public Function GetComponentIDFromModuleCommand(ByVal regexTAG As String, ByVal HtmlText As String, ByRef AttrList As List(Of _cmsTemplateDetailAttributes)) As Long
            Dim retValue As Long = 0

            Dim regex As New Regex(regexTAG, RegexOptions.IgnoreCase)
            Dim matches As MatchCollection = regex.Matches(HtmlText)
            Dim match As Match

            Dim tmpAttr As _cmsTemplateDetailAttributes
            If AttrList.Count > 0 Then AttrList.Clear()

            For Each match In matches
                Dim type As String = ""
                Dim name As String = ""
                Dim component As String = ""
                Dim ComponentID As String = ""

                Dim Value As String = ""

                Dim tmpWarning As String = ""

                For i As Long = 0 To match.Groups("value").Captures.Count - 1
                    Value = match.Groups("value").Captures(i).ToString

                    Select Case match.Groups("attribute").Captures(i).ToString.ToLower
                        Case "type" : type = Value : If type <> "module" Then Exit For
                        Case "name" : name = Value
                        Case "component" : component = Value
                        Case "id" : ComponentID = Value
                        Case Else
                            tmpAttr.Name = match.Groups("attribute").Captures(i).ToString.ToLower
                            tmpAttr.Value = Value
                            AttrList.Add(tmpAttr)
                    End Select
                Next i

                If type = "module" Then
                    retValue = jModule.getComponentIDFromName(name, component)
                Else
                    AttrList.Clear()
                End If
            Next match

            Return retValue
        End Function

        Public Function GetCustomIDFromModuleCommand(ByVal regexTAG As String, ByVal HtmlText As String, ByRef AttrList As List(Of _cmsTemplateDetailAttributes)) As String
            Dim retValue As String = ""

            Dim regex As New Regex(regexTAG, RegexOptions.IgnoreCase)
            Dim matches As MatchCollection = regex.Matches(HtmlText)
            Dim match As Match

            Dim tmpAttr As _cmsTemplateDetailAttributes
            If AttrList.Count > 0 Then AttrList.Clear()

            For Each match In matches
                Dim type As String = ""
                Dim name As String = ""
                Dim component As String = ""
                Dim CustomID As String = ""

                Dim Value As String = ""

                Dim tmpWarning As String = ""

                For i As Long = 0 To match.Groups("value").Captures.Count - 1
                    Value = match.Groups("value").Captures(i).ToString

                    Select Case match.Groups("attribute").Captures(i).ToString.ToLower
                        Case "type" : type = Value : If type <> "module" Then Exit For
                        Case "name" : name = Value
                        Case "component" : component = Value
                        Case "id" : CustomID = Value
                        Case Else
                            tmpAttr.Name = match.Groups("attribute").Captures(i).ToString.ToLower
                            tmpAttr.Value = Value
                            AttrList.Add(tmpAttr)
                    End Select
                Next i

                If type = "module" Then
                    retValue = CustomID
                Else
                    AttrList.Clear()
                End If
            Next match

            Return retValue
        End Function

        Public Function JertCMS_SubstChunksVarTAG(ByVal regexTAG As String, ByRef cmsPage As _cmsPage, ByRef Menu As _cmsVoceDiMenu, Optional ByVal isInListParse As Boolean = False, Optional ByVal isInMenuParse As Boolean = False, Optional ByVal PageIDInList As Long = 0, Optional ByVal HideErrors As Boolean = False, Optional ByRef tmpDbCommand As OleDbCommand = Nothing, Optional ByRef tmpDbConnection As OleDbConnection = Nothing) As String
            Dim retValue As String = ""

            Dim SearchAgain As Boolean = True

            Dim regex As New Regex(regexTAG, RegexOptions.IgnoreCase)
            Dim matches As MatchCollection = regex.Matches(cmsPage.HTMLFullPage)
            Dim tmpMatches As MatchCollection = Nothing
            Dim foundNewSearch As Boolean = False

            Dim match As Match
            Dim type As String = ""
            Dim name As String = ""
            Dim category As String = ""
            Dim Value As String = ""
            Dim tmpWarning As String = ""

            Dim tmpChunkVar As String

            Do While SearchAgain
                If foundNewSearch = True Then
                    matches = tmpMatches
                    foundNewSearch = False
                End If

                SearchAgain = False

                For Each match In matches
                    type = ""
                    name = ""
                    category = ""
                    Value = ""
                    tmpWarning = ""

                    For i As Long = 0 To match.Groups("value").Captures.Count - 1
                        Value = match.Groups("value").Captures(i).ToString

                        Select Case match.Groups("attribute").Captures(i).ToString.ToLower
                            Case "type" : type = Value : If type <> "chunk" Then Exit For
                            Case "name" : name = Value
                            Case "category" : category = Value
                            Case Else
                                'TODO da globalizzare..
                                tmpWarning = "<br />--- Attributo non riconosciuto: <strong>" & match.Groups("attribute").Captures(i).ToString.ToLower & "=""" & Value & """</strong> <br />Nel comando: <strong>" & match.Value.ToString.Replace("<", "&lt;").Replace(">", "&gt;") & "</strong>"
                        End Select
                    Next i

                    If type = "chunk" Then
                        If tmpWarning.Length = 0 Then
                            tmpChunkVar = JertCMS_ReadChunkVar(match.Value.ToString, cmsPage, Menu, name, category, HideErrors, tmpDbCommand, tmpDbConnection)
                            cmsPage.HTMLFullPage = cmsPage.HTMLFullPage.Replace(match.Value.ToString, tmpChunkVar)

                            'Verifico se ci sono chunk dentro il chunk..
                            If IsNothing(cmsPage._CMS_Warning) OrElse cmsPage._CMS_Warning.Length = 0 Then
                                If JertCMS_ChunkExist(regexTAG, tmpChunkVar, "", "", True) Then
                                    SearchAgain = True : foundNewSearch = True
                                    tmpMatches = regex.Matches(tmpChunkVar)
                                End If
                            End If
                        End If
                        If tmpWarning.Length > 0 Then
                            cmsPage._CMS_Warning &= tmpWarning
                        End If
                    End If
                Next match
            Loop

            Return cmsPage.HTMLFullPage
        End Function

        Public Function JertCMS_SubstComponentTAG(ByVal regexTAG As String, ByRef cmsPage As _cmsPage, ByRef Menu As _cmsVoceDiMenu, Optional ByVal isInListParse As Boolean = False, Optional ByVal isInMenuParse As Boolean = False, Optional ByVal PageIDInList As Long = 0, Optional ByVal HideErrors As Boolean = False, Optional ByRef tmpDbCommand As OleDbCommand = Nothing, Optional ByRef tmpDbConnection As OleDbConnection = Nothing) As String
            Dim retValue As String = ""

            Dim regex As New Regex(regexTAG, RegexOptions.IgnoreCase)
            Dim matches As MatchCollection = regex.Matches(cmsPage.HTMLFullPage)


            Dim type As String = ""
            Dim name As String = ""
            Dim component As String = ""

            Dim Value As String = ""
            Dim tmpWarning As String = ""
            Dim match As Match

            For Each match In matches
                type = ""
                name = ""
                component = ""

                Value = ""
                tmpWarning = ""

                For i As Long = 0 To match.Groups("value").Captures.Count - 1
                    Value = match.Groups("value").Captures(i).ToString

                    Select Case match.Groups("attribute").Captures(i).ToString.ToLower
                        Case "type" : type = Value : If type <> "module" Then Exit For
                        Case "name" : name = Value
                        Case "component" : component = Value
                        Case Else
                            'tmpWarning = "<br />--- Attributo non riconosciuto: <strong>" & match.Groups("attribute").Captures(i).ToString.ToLower & "=""" & Value & """</strong> <br />Nel comando: <strong>" & match.Value.ToString.Replace("<", "&lt;").Replace(">", "&gt;") & "</strong>"
                    End Select
                Next i

                If type = "module" Then
                    If tmpWarning.Length = 0 Then cmsPage.HTMLFullPage = cmsPage.HTMLFullPage.Replace(match.Value.ToString, JertCMS_ReadComponentVar(match.Value.ToString, cmsPage, Menu, name, component, isInListParse, isInMenuParse, PageIDInList, HideErrors, tmpDbCommand, tmpDbConnection))
                    If tmpWarning.Length > 0 Then
                        cmsPage._CMS_Warning &= tmpWarning
                    End If
                End If
            Next match

            Return cmsPage.HTMLFullPage
        End Function

        Public Function JertCMS_SubstPageVarTAG(ByVal regexTAG As String, ByRef cmsPage As _cmsPage, ByRef Menu As _cmsVoceDiMenu, Optional ByVal isInListParse As Boolean = False, Optional ByVal isInMenuParse As Boolean = False, Optional ByVal PageIDInList As Long = 0, Optional ByVal HideErrors As Boolean = False, Optional ByRef tmpDbCommand As OleDbCommand = Nothing, Optional ByRef tmpDbConnection As OleDbConnection = Nothing) As String
            Dim retValue As String = ""

            Dim regex As New Regex(regexTAG, RegexOptions.IgnoreCase)
            Dim matches As MatchCollection = regex.Matches(cmsPage.HTMLFullPage)


            Dim type As String = ""
            Dim name As String = ""
            Dim page_menu_name As String
            Dim page_folder_path As String
            Dim depth As String = ""
            Dim page_id As String = ""
            Dim mValue As String = ""
            Dim prefix As String = ""
            Dim Value As String = ""
            Dim tmpWarning As String = ""
            Dim cssclass As String = ""
            Dim separator As String = ""
            Dim linklastelement As String = ""
            Dim overwriteLastTitle As String = ""
            Dim urlappendtext As String = ""

            Dim match As Match

            For Each match In matches
                type = ""
                name = ""
                page_menu_name = ""
                page_folder_path = ""
                depth = ""
                page_id = ""
                mValue = ""
                Value = ""
                tmpWarning = ""
                cssclass = ""
                separator = ""
                linklastelement = ""
                overwriteLastTitle = ""
                urlappendtext = ""

                For i As Long = 0 To match.Groups("value").Captures.Count - 1
                    Value = match.Groups("value").Captures(i).ToString

                    Select Case match.Groups("attribute").Captures(i).ToString.ToLower
                        Case "type" : type = Value : If type <> "tvpage" Then Exit For
                        Case "name" : name = Value
                        Case "page_menu_name" : page_menu_name = Value
                        Case "page_folder_path" : page_folder_path = Value
                        Case "depth" : depth = Value
                        Case "page_id" : page_id = Value
                        Case "cssclass" : cssclass = Value
                        Case "separator" : separator = Value
                        Case "linklastelement" : linklastelement = Value
                        Case "overwriteLastTitle" : overwriteLastTitle = Value
                        Case "urlappendtext" : urlappendtext = Value
                        Case "value" : mValue = Value
                        Case "prefix" : prefix = Value
                        Case Else
                            'TODO da globalizzare..
                            tmpWarning = "<br />--- Attributo non riconosciuto: <strong>" & match.Groups("attribute").Captures(i).ToString.ToLower & "=""" & Value & """</strong> <br />Nel comando: <strong>" & match.Value.ToString.Replace("<", "&lt;").Replace(">", "&gt;") & "</strong>"
                    End Select
                Next i

                If type = "tvpage" Then
                    If tmpWarning.Length = 0 Then cmsPage.HTMLFullPage = cmsPage.HTMLFullPage.Replace(match.Value.ToString, JertCMS_ReadPageVar(match.Value.ToString, cmsPage, Menu, name, depth, page_id, mValue, prefix, separator, cssclass, linklastelement, overwriteLastTitle, urlappendtext, page_menu_name, page_folder_path, isInListParse, isInMenuParse, PageIDInList, HideErrors, tmpDbCommand, tmpDbConnection))
                    If tmpWarning.Length > 0 Then
                        cmsPage._CMS_Warning &= tmpWarning
                    End If
                End If
            Next match

            Return cmsPage.HTMLFullPage
        End Function

        Public Sub JertCMS_SubstTemplateVarTAG(ByVal regexTAG As String, ByRef cmsPage As _cmsPage, ByRef Menu As _cmsVoceDiMenu, Optional ByVal isInListParse As Boolean = False, Optional ByVal isInMenuParse As Boolean = False, Optional ByVal PageIDInList As Long = 0, Optional ByVal HideErrors As Boolean = False, Optional ByRef tmpDbCommand As OleDbCommand = Nothing, Optional ByRef tmpDbConnection As OleDbConnection = Nothing)
            Dim regex As New Regex(regexTAG, RegexOptions.IgnoreCase)
            Dim matches As MatchCollection = regex.Matches(cmsPage.HTMLFullPage)
            Dim match As Match
            For Each match In matches
                Dim type As String = ""
                Dim name As String = ""
                Dim depth As String = ""
                Dim page_id As String = ""

                Dim Value As String = ""

                Dim tmpWarning As String = ""

                For i As Long = 0 To match.Groups("value").Captures.Count - 1
                    Value = match.Groups("value").Captures(i).ToString

                    Select Case match.Groups("attribute").Captures(i).ToString.ToLower
                        Case "type" : type = Value : If type <> "tv" Then Exit For
                        Case "name" : name = Value
                        Case "depth" : depth = Value
                        Case "page_id" : page_id = Value
                        Case Else
                            'TODO da globalizzare..
                            tmpWarning = "<br />--- Attributo non riconosciuto: <strong>" & match.Groups("attribute").Captures(i).ToString.ToLower & "=""" & Value & """</strong> <br />Nel comando: <strong>" & match.Value.ToString.Replace("<", "&lt;").Replace(">", "&gt;") & "</strong>"
                    End Select
                Next i

                If type = "tv" Then
                    If tmpWarning.Length = 0 Then cmsPage.HTMLFullPage = cmsPage.HTMLFullPage.Replace(match.Value.ToString, JertCMS_ReadTemplateVar(match.Value.ToString, cmsPage, Menu, name, depth, page_id, isInListParse, isInMenuParse, PageIDInList, HideErrors, tmpDbCommand, tmpDbConnection))
                    If tmpWarning.Length > 0 Then
                        cmsPage._CMS_Warning &= tmpWarning
                    End If
                End If
            Next match
        End Sub

        Private Function MaxDepthOfMenuPath(ByVal tmpFolderPath As String) As Long
            Dim retValue As Long = 0

            If tmpFolderPath.Length > cmsPaths.PathPublic.Length Then
                'Rimuovo public..
                tmpFolderPath = tmpFolderPath.Remove(0, cmsPaths.PathPublic.Length)
                'Rimuovo la lingua..
                tmpFolderPath = tmpFolderPath.Remove(0, tmpFolderPath.IndexOf("/"))
                'Conto gli slash..
                'Rimuovo primo e ultimo slash..
                If tmpFolderPath.StartsWith("/") Then tmpFolderPath = tmpFolderPath.Substring(1, tmpFolderPath.Length - 1)
                If tmpFolderPath.EndsWith("/") Then tmpFolderPath = tmpFolderPath.Substring(0, tmpFolderPath.Length - 1)

                Dim tmpArr As String() = tmpFolderPath.Split("/")
                retValue = tmpArr.Length
            End If

            Return retValue
        End Function

        Public Function GetMenuPathDepth(ByVal tmpFolderPath As String, ByVal depth As Long) As String
            'TODO Funzione da rifare con le REGEX

            Dim retValue As String = ""

            Dim tmpLang As String = ""

            If tmpFolderPath.Length > cmsPaths.PathPublic.Length Then
                'Rimuovo public..
                tmpFolderPath = tmpFolderPath.Remove(0, cmsPaths.PathPublic.Length)
                'Rimuovo la lingua..
                tmpLang = tmpFolderPath.Substring(0, tmpFolderPath.IndexOf("/"))
                tmpFolderPath = tmpFolderPath.Remove(0, tmpFolderPath.IndexOf("/"))
                'Conto gli slash..
                'Rimuovo primo e ultimo slash..
                If tmpFolderPath.StartsWith("/") Then tmpFolderPath = tmpFolderPath.Substring(1, tmpFolderPath.Length - 1)
                If tmpFolderPath.EndsWith("/") Then tmpFolderPath = tmpFolderPath.Substring(0, tmpFolderPath.Length - 1)

                Dim tmpArr As String() = tmpFolderPath.Split("/")
                For i As Long = 0 To (tmpArr.Length - depth) - 1
                    If i < (tmpArr.Length - depth) - 1 Then
                        retValue &= tmpArr(i) & "/"
                    Else
                        retValue &= tmpArr(i)
                    End If
                Next

                retValue = cmsPaths.PathPublic.Replace("\", "/") & tmpLang & "/" & retValue
            End If

            Return retValue
        End Function

        Private Function CheckAndSetCSSClassExist(ByVal FieldName As String, ByRef CssClass As _cmsMenuCssClasses) As Boolean
            Dim retValue As Boolean = False

            With CssClass
                Select Case FieldName.ToLower
                    Case "first" : retValue = True : .first = True : Return retValue
                    Case "last" : retValue = True : .last = True : Return retValue
                    Case "level" : retValue = True : .level = True : Return retValue
                    Case "active" : retValue = True : .active = True : Return retValue
                    Case "parent" : retValue = True : .parent = True : Return retValue
                    Case "id" : retValue = True : .id = True : Return retValue
                End Select
            End With

            Return retValue
        End Function

        Private Function checkFieldNameExist(ByVal FieldName As String) As Boolean
            Dim retValue As Boolean = False

            Select Case FieldName.ToLower
                Case "title" : retValue = True
                Case "long_title" : retValue = True
                Case "description" : retValue = True
                Case "menu" : retValue = True
                Case "content" : retValue = True
                Case "publish_date" : retValue = True
                Case "last_update_date" : retValue = True
                Case "rel_link" : retValue = True
                Case "abs_link" : retValue = True
                Case "website_link" : retValue = True
                Case "page_id" : retValue = True
            End Select

            Return retValue
        End Function

        Private Function CreateOrderBy(ByVal FieldName As String, ByVal SortOrder As String) As String
            'TODO da vedere come fare per i campi commentati..

            Dim retValue As String = " ORDER BY "

            Select Case FieldName
                Case "title" : retValue &= " Titolo "
                Case "long_title" : retValue &= " TitoloH1 "
                Case "description" : retValue &= " MetaDescription "
                    'Case "menu" : retValue &= "  "
                Case "content" : retValue &= " Content "
                Case "publish_date" : retValue &= " DataInserimento "
                Case "last_update_date" : retValue &= " DataUltimaModifica "
                    'Case "rel_link" : retValue &= "  "
                    'Case "abs_link" : retValue &= "  "
                Case Else
                    retValue = ""
            End Select

            If retValue.Length > 0 Then retValue &= " " & SortOrder

            Return retValue
        End Function

        Private Function JertCMS_ReadChunkVar(ByVal CommandToSearch As String, ByRef cmsPage As _cmsPage, ByRef Menu As _cmsVoceDiMenu, ByVal name As String, ByVal category As String, Optional ByVal HideErrors As Boolean = False, Optional ByRef tmpDbCommand As OleDbCommand = Nothing, Optional ByRef tmpDbConnection As OleDbConnection = Nothing) As String
            'TODO evitare che un chunk entri in loop evitando che richiami se stesso..

            Dim retValue As String = CommandToSearch

            With cmsPage
                If category.Length > 0 Then
                    If Not HideErrors AndAlso ChunkCategoriaExist(category, , tmpDbCommand, tmpDbConnection) = False Then
                        cmsPage._CMS_Warning &= "<br />--- Attributo category non valido: <strong>category=""" & category & """</strong> <br />Nel comando: <strong>" & CommandToSearch.Replace("<", "&lt;").Replace(">", "&gt;") & "</strong>"
                        Return retValue
                    Else
                        If name.Length > 0 Then
                            Dim idCategory As Long = idChunkCategoryFromName(category, tmpDbCommand, tmpDbConnection)
                            If ChunkNameExist(name.Trim, idCategory, , tmpDbCommand, tmpDbConnection) = True Then
                                retValue = ReadChunk(name, idCategory, tmpDbCommand, tmpDbConnection)
                                If Not HideErrors AndAlso JertCMS_ChunkExist("<jcms(\s+(?<attribute>\S+?)=[""']?(?<value>[^""']*)[""']?\S)*\s+/>", retValue, name, category) Then
                                    retValue = CommandToSearch
                                    cmsPage._CMS_Warning &= "<br />--- Attenzione! non è possibile inserire un chunk all'interno di se stesso, verificare!<br />Nel comando: <strong>" & CommandToSearch.Replace("<", "&lt;").Replace(">", "&gt;") & "</strong>"
                                    Return retValue
                                End If
                            Else
                                cmsPage._CMS_Warning &= "<br />--- Attributo name non valido: <strong>name=""" & name & """</strong> <br />Nel comando: <strong>" & CommandToSearch.Replace("<", "&lt;").Replace(">", "&gt;") & "</strong>"
                                Return retValue
                            End If
                        Else
                            cmsPage._CMS_Warning &= "<br />--- Attributo name non valido: <strong>name=""" & name & """</strong> <br />Nel comando: <strong>" & CommandToSearch.Replace("<", "&lt;").Replace(">", "&gt;") & "</strong>"
                            Return retValue
                        End If
                    End If
                Else
                    If name.Length > 0 Then
                        Dim NumChunks As Long = CountChunksByName(name.Trim, tmpDbCommand, tmpDbConnection)

                        If NumChunks = 1 Then
                            retValue = ReadChunk(name.Trim, , tmpDbCommand, tmpDbConnection)
                            If Not HideErrors AndAlso JertCMS_ChunkExist("<jcms(\s+(?<attribute>\S+?)=[""']?(?<value>[^""']*)[""']?\S)*\s+/>", retValue, name, category) Then
                                retValue = CommandToSearch
                                cmsPage._CMS_Warning &= "<br />--- Attenzione! non è possibile inserire un chunk all'interno di se stesso, verificare!<br />Nel comando: <strong>" & CommandToSearch.Replace("<", "&lt;").Replace(">", "&gt;") & "</strong>"
                                Return retValue
                            End If
                        ElseIf Not HideErrors AndAlso (NumChunks = -1 Or NumChunks = 0) Then
                            cmsPage._CMS_Warning &= "<br />--- Attributo name non trovato: <strong>name=""" & name & """</strong> <br />Nel comando: <strong>" & CommandToSearch.Replace("<", "&lt;").Replace(">", "&gt;") & "</strong>"
                            Return retValue
                        ElseIf Not HideErrors AndAlso (NumChunks > 1) Then
                            cmsPage._CMS_Warning &= "<br />--- Esiste più di 1 chunk con il nome=<strong>""" & name & """</strong>, specificare anche l'attributo category: <strong>name=""" & name & """</strong> <br />Nel comando: <strong>" & CommandToSearch.Replace("<", "&lt;").Replace(">", "&gt;") & "</strong>"
                            Return retValue
                        End If
                    End If
                End If
            End With

            Return retValue
        End Function

        Private Function JertCMS_ReadComponentVar(ByVal CommandToSearch As String, ByRef cmsPage As _cmsPage, ByRef Menu As _cmsVoceDiMenu, ByVal name As String, ByVal component As String, Optional ByVal isInListParse As Boolean = False, Optional ByVal isInMenuParse As Boolean = False, Optional ByVal PageIDInList As Long = 0, Optional ByVal HideErrors As Boolean = False, Optional ByRef tmpDbCommand As OleDbCommand = Nothing, Optional ByRef tmpDbConnection As OleDbConnection = Nothing) As String
            Dim retValue As String = CommandToSearch

            '"SELECT ModulesInstalled.idModule, ModuleComponents.idComponent, ModulesInstalled.Name, ModulesInstalled.DataBaseName, ModulesInstalled.DefaultRedirectURL, ModulesInstalled.ModuleFolder, ModuleComponents.ComponentName, ModuleComponents.FileName FROM ModulesInstalled INNER JOIN ModuleComponents ON ModulesInstalled.idModule = ModuleComponents.idModule;"

            Dim tmpSQL As String = ""
            tmpSQL = "SELECT ModulesInstalled.idModule, ModuleComponents.idComponent, ModulesInstalled.Name, ModulesInstalled.DataBaseName, ModulesInstalled.DefaultRedirectURL, ModulesInstalled.ModuleFolder, ModuleComponents.ComponentName, ModuleComponents.FileName FROM ModulesInstalled INNER JOIN ModuleComponents ON ModulesInstalled.idModule = ModuleComponents.idModule"
            tmpSQL &= " WHERE ModulesInstalled.Name = '" & name & "' AND ModuleComponents.ComponentName = '" & component & "'"

            'idModule	idComponent	Name	    DataBaseName    DefaultRedirectURL	    ModuleFolder	ComponentName	FileName
            '1	        3	        jCommerce	Shop	        ~/Modules/BackOffice/	jCommerce	    Test	        Test.ascx



            'If (isInListParse And depth.Length = 0 And page_id.ToLower = "list") Then page_id = cmsPage.idPagina
            'If (isInListParse And depth.Length > 0 And page_id.ToLower = "list") Then page_id = ""

            'If isInMenuParse Then
            '    If (isInMenuParse And page_id.ToLower = "menu") Then
            '        page_id = cmsPage.idPagina
            '    Else
            '        page_id = PageIDInList
            '    End If
            'End If

            'If Not HideErrors Then
            '    If (isInListParse And (Not IsNumeric(page_id) And page_id.Length > 0) And page_id.ToLower <> "list") Then
            '        cmsPage._CMS_Warning &= "<br />--- Attributo page_id non valido (atteso: ""list"" o numerico): <strong>page_id=""" & page_id & """</strong> <br />Nel comando: <strong>" & CommandToSearch.Replace("<", "&lt;").Replace(">", "&gt;") & "</strong>"
            '        Return retValue
            '    End If

            '    If (isInMenuParse And (Not IsNumeric(page_id) And page_id.Length > 0) And page_id.ToLower <> "menu") Then
            '        cmsPage._CMS_Warning &= "<br />--- Attributo page_id non valido (atteso: ""menu"" o numerico): <strong>page_id=""" & page_id & """</strong> <br />Nel comando: <strong>" & CommandToSearch.Replace("<", "&lt;").Replace(">", "&gt;") & "</strong>"
            '        Return retValue
            '    End If
            'End If

            'With cmsPage
            '    If depth.Length = 0 And page_id.Length > 0 Then
            '        If page_id.Length > 0 Then
            '            If IsNumeric(page_id) Then
            '                Dim tmpPageID As Long = Convert.ToInt16(page_id)

            '                If checkFieldNameExist(name) = True Then

            '                    Dim tmpPage As New _cmsPage
            '                    tmpPage = GetPageByID(tmpPageID, tmpDbCommand, tmpDbConnection)

            '                    If tmpPage.idErrore = 0 Then
            '                        'Dim tmpMenu As _cmsVoceDiMenu

            '                        'TODO --> Modificare tutti i GetPageByID
            '                        'TODO --> Modifiche effettuate, se è tutto OK eliminare tutti questi tmpMenu = GetV...

            '                        'SELECT Pagine.*, folderpath FROM Pagine INNER JOIN Menu ON Pagine.codPagina = Menu.codPagina WHERE Pagine.idPagina=15;

            '                        'tmpMenu = GetVoceMenuFromFolderPath(GetFolderPathFromCodPaginaAndIdLingua(tmpPage.codPagina, tmpPage.idLingua, tmpDbCommand, tmpDbConnection), tmpPage.idLingua, tmpDbCommand, tmpDbConnection)

            '                        'Originale...
            '                        'tmpMenu = GetVoceMenuFromFolderPath(GetFolderPathFromCodPaginaAndIdLingua(tmpPage.codPagina, tmpPage.idLingua, tmpDbCommand, tmpDbConnection), , tmpDbCommand, tmpDbConnection)

            '                        'Funziona
            '                        'tmpMenu = GetVoceMenuFromFolderPath(GetFolderPathFromCodPaginaAndIdLingua(tmpPage.codPagina, tmpPage.idLingua))

            '                        Select Case name
            '                            Case "title" : retValue = tmpPage.Titolo
            '                            Case "long_title" : retValue = tmpPage.TitoloH1
            '                            Case "description" : retValue = tmpPage.MetaDescription
            '                            Case "menu" : retValue = tmpPage.DescrizioneBreveNelMenu
            '                            Case "content" : retValue = tmpPage.HTMLPageContent
            '                            Case "publish_date" : retValue = tmpPage.DataInserimento
            '                            Case "last_update_date" : retValue = tmpPage.DataUltimaModifica
            '                            Case "rel_link" : retValue = tmpPage.FolderPath.Replace("\", "/")
            '                            Case "abs_link" : retValue = "http://" & HttpContext.Current.Session("SiteName") & tmpPage.FolderPath.Replace("\", "/")
            '                            Case "website_link" : retValue = HttpContext.Current.Session("SiteName")
            '                        End Select

            '                        Return retValue
            '                    Else
            '                        cmsPage._CMS_Warning &= "<br />--- Attributo page_id non valido: <strong>page_id=""" & page_id & """</strong> <br />Nel comando: <strong>" & CommandToSearch.Replace("<", "&lt;").Replace(">", "&gt;") & "</strong>"
            '                    End If
            '                Else
            '                    cmsPage._CMS_Warning &= "<br />--- Attributo name non valido: <strong>name=""" & name & """</strong> <br />Nel comando: <strong>" & CommandToSearch.Replace("<", "&lt;").Replace(">", "&gt;") & "</strong>"
            '                End If
            '            Else
            '                cmsPage._CMS_Warning &= "<br />--- Attributo non numerico: <strong>page_id=""" & page_id & """</strong> <br />Nel comando: <strong>" & CommandToSearch.Replace("<", "&lt;").Replace(">", "&gt;") & "</strong>"
            '            End If
            '        Else
            '            cmsPage._CMS_Warning &= "<br />--- Attributo non riconosciuto: <strong>page_id=""" & page_id & """</strong> <br />Nel comando: <strong>" & CommandToSearch.Replace("<", "&lt;").Replace(">", "&gt;") & "</strong>"
            '        End If

            '        Return retValue
            '    End If

            '    If depth.Length > 0 And page_id.Length = 0 Then
            '        If isInListParse Then Menu.folderpath = GetFolderPathFromCodPaginaAndIdLingua(.codPagina, .idLingua, tmpDbCommand, tmpDbConnection)

            '        If depth.Length > 0 Then
            '            If IsNumeric(depth) Then
            '                Dim tmpDepth As Long = Convert.ToInt16(depth)
            '                Dim tmpFolderPath = Menu.folderpath.Replace("\", "/")
            '                Dim maxDepth As Long = MaxDepthOfMenuPath(tmpFolderPath)

            '                If tmpDepth < maxDepth Then
            '                    Dim tmpPathPage As String = GetMenuPathDepth(tmpFolderPath, tmpDepth)

            '                    If checkFieldNameExist(name) = True Then
            '                        Dim tmpMenu As _cmsVoceDiMenu
            '                        tmpMenu = GetVoceMenuFromFolderPath(tmpPathPage.Replace("/", "\"), , tmpDbCommand, tmpDbConnection)

            '                        Dim tmpPage As New _cmsPage

            '                        JertCMS_ReadPageContent(tmpMenu, tmpPage, , tmpDbCommand, tmpDbConnection)

            '                        Select Case name
            '                            Case "title" : retValue = tmpPage.Titolo
            '                            Case "long_title" : retValue = tmpPage.TitoloH1
            '                            Case "description" : retValue = tmpPage.MetaDescription
            '                            Case "menu" : retValue = tmpMenu.DescrizioneBreveNelMenu
            '                            Case "content" : retValue = tmpPage.HTMLPageContent
            '                            Case "publish_date" : retValue = tmpPage.DataInserimento
            '                            Case "last_update_date" : retValue = tmpPage.DataUltimaModifica
            '                            Case "rel_link" : retValue = tmpMenu.folderpath.Replace("\", "/")
            '                            Case "abs_link" : retValue = "http://" & HttpContext.Current.Session("SiteName") & tmpMenu.folderpath.Replace("\", "/")
            '                            Case "website_link" : retValue = HttpContext.Current.Session("SiteName")
            '                        End Select

            '                        Return retValue
            '                    Else
            '                        cmsPage._CMS_Warning &= "<br />--- Attributo name non valido: <strong>name=""" & name & """</strong> <br />Nel comando: <strong>" & CommandToSearch.Replace("<", "&lt;").Replace(">", "&gt;") & "</strong>"
            '                    End If
            '                Else
            '                    cmsPage._CMS_Warning &= "<br />--- Attributo con un numero di profondita errato o troppo elevato: <strong>depth=""" & depth & """</strong> <br />Nel comando: <strong>" & CommandToSearch.Replace("<", "&lt;").Replace(">", "&gt;") & "</strong>"
            '                End If
            '            Else
            '                cmsPage._CMS_Warning &= "<br />--- Attributo non numerico: <strong>depth=""" & depth & """</strong> <br />Nel comando: <strong>" & CommandToSearch.Replace("<", "&lt;").Replace(">", "&gt;") & "</strong>"
            '            End If
            '        Else
            '            cmsPage._CMS_Warning &= "<br />--- Attributo non riconosciuto: <strong>depth=""" & depth & """</strong> <br />Nel comando: <strong>" & CommandToSearch.Replace("<", "&lt;").Replace(">", "&gt;") & "</strong>"
            '        End If

            '        Return retValue
            '    End If

            '    Select Case name
            '        Case "title" : retValue = .Titolo
            '        Case "long_title" : retValue = .TitoloH1
            '        Case "description" : retValue = .MetaDescription
            '        Case "menu" : retValue = Menu.DescrizioneBreveNelMenu
            '        Case "content" : retValue = .HTMLPageContent
            '        Case "publish_date" : retValue = .DataInserimento
            '        Case "last_update_date" : retValue = .DataUltimaModifica
            '        Case "rel_link" : retValue = Menu.folderpath.Replace("\", "/")
            '        Case "abs_link" : retValue = "http://" & HttpContext.Current.Session("SiteName") & Menu.folderpath.Replace("\", "/")
            '        Case "website_link" : retValue = HttpContext.Current.Session("SiteName")
            '        Case Else
            '            cmsPage._CMS_Warning &= "<br />--- Attributo non riconosciuto: <strong>name=""" & name & """</strong> <br />Nel comando: <strong>" & CommandToSearch.Replace("<", "&lt;").Replace(">", "&gt;") & "</strong>"
            '    End Select
            'End With

            Return retValue
        End Function

        Private Function JertCMS_ReadPageVar(ByVal CommandToSearch As String, ByRef cmsPage As _cmsPage, ByRef Menu As _cmsVoceDiMenu, ByVal name As String, ByVal depth As String, ByVal page_id As String, ByVal value As String, ByVal prefix As String, ByVal Separator As String, ByVal CssClass As String, ByVal linklastelement As String, ByVal overwriteLastTitle As String, ByVal urlappendtext As String, ByVal page_menu_name As String, ByVal page_folder_path As String, Optional ByVal isInListParse As Boolean = False, Optional ByVal isInMenuParse As Boolean = False, Optional ByVal PageIDInList As Long = 0, Optional ByVal HideErrors As Boolean = False, Optional ByRef tmpDbCommand As OleDbCommand = Nothing, Optional ByRef tmpDbConnection As OleDbConnection = Nothing) As String
            'TODO stringhe di errore da localizzare
            'TODO cambiare tutte le stringhe "title" "longtitle" ecc in variabili..

            Dim retValue As String = CommandToSearch

            If (isInListParse = False And isInMenuParse = False) And (page_id.ToLower = "list" Or page_id.ToLower = "menu") Then Return retValue

            If (isInListParse And depth.Length = 0 And page_id.ToLower = "list") Then page_id = cmsPage.idPagina
            If (isInListParse And depth.Length > 0 And page_id.ToLower = "list") Then page_id = ""

            If isInMenuParse Then
                If (isInMenuParse And page_id.ToLower = "menu") Then
                    page_id = cmsPage.idPagina
                Else
                    page_id = PageIDInList
                End If
            End If

            If Not HideErrors Then
                If (isInListParse And (Not IsNumeric(page_id) And page_id.Length > 0) And page_id.ToLower <> "list") Then
                    cmsPage._CMS_Warning &= "<br />--- Attributo page_id non valido (atteso: ""list"" o numerico): <strong>page_id=""" & page_id & """</strong> <br />Nel comando: <strong>" & CommandToSearch.Replace("<", "&lt;").Replace(">", "&gt;") & "</strong>"
                    Return retValue
                End If

                If (isInMenuParse And (Not IsNumeric(page_id) And page_id.Length > 0) And page_id.ToLower <> "menu") Then
                    cmsPage._CMS_Warning &= "<br />--- Attributo page_id non valido (atteso: ""menu"" o numerico): <strong>page_id=""" & page_id & """</strong> <br />Nel comando: <strong>" & CommandToSearch.Replace("<", "&lt;").Replace(">", "&gt;") & "</strong>"
                    Return retValue
                End If
            End If

            If page_menu_name.Length > 0 And depth.Length > 0 Then page_id = "-1"
            If page_folder_path.Length > 0 Then page_id = "-2"

            With cmsPage
                If (depth.Length = 0 And page_id.Length > 0) Or (page_menu_name.Length > 0 And depth.Length > 0) Or (page_folder_path.Length > 0) Then
                    If page_id.Length > 0 Then
                        If IsNumeric(page_id) Then
                            Dim tmpPageID As Long = Convert.ToInt16(page_id)

                            If checkFieldNameExist(name) = True Then

                                Dim tmpPage As New _cmsPage

                                If tmpPageID > 0 Then
                                    tmpPage = GetPageByID(tmpPageID, tmpDbCommand, tmpDbConnection)
                                ElseIf tmpPageID = -1 Then
                                    Dim tmpDepth As Long = Convert.ToInt16(depth)
                                    tmpPage = GetPageByMenuNameAndPageDepth(page_menu_name.Trim, tmpDepth, tmpDbCommand, tmpDbConnection)
                                ElseIf tmpPageID = -2 Then
                                    tmpPage = GetPageByFolderPath(page_folder_path.Trim, tmpDbCommand, tmpDbConnection)
                                End If

                                If tmpPage.idErrore = 0 Then
                                    'Dim tmpMenu As _cmsVoceDiMenu

                                    'TODO --> Modificare tutti i GetPageByID
                                    'TODO --> Modifiche effettuate, se è tutto OK eliminare tutti questi tmpMenu = GetV...

                                    'SELECT Pagine.*, folderpath FROM Pagine INNER JOIN Menu ON Pagine.codPagina = Menu.codPagina WHERE Pagine.idPagina=15;

                                    'tmpMenu = GetVoceMenuFromFolderPath(GetFolderPathFromCodPaginaAndIdLingua(tmpPage.codPagina, tmpPage.idLingua, tmpDbCommand, tmpDbConnection), tmpPage.idLingua, tmpDbCommand, tmpDbConnection)

                                    'Originale...
                                    'tmpMenu = GetVoceMenuFromFolderPath(GetFolderPathFromCodPaginaAndIdLingua(tmpPage.codPagina, tmpPage.idLingua, tmpDbCommand, tmpDbConnection), , tmpDbCommand, tmpDbConnection)

                                    'Funziona
                                    'tmpMenu = GetVoceMenuFromFolderPath(GetFolderPathFromCodPaginaAndIdLingua(tmpPage.codPagina, tmpPage.idLingua))

                                    Select Case name
                                        Case "title" : retValue = tmpPage.Titolo
                                        Case "long_title" : retValue = tmpPage.TitoloH1
                                        Case "description" : retValue = tmpPage.MetaDescription
                                        Case "menu" : retValue = tmpPage.DescrizioneBreveNelMenu
                                        Case "content" : retValue = tmpPage.HTMLPageContent
                                        Case "publish_date" : retValue = tmpPage.DataInserimento
                                        Case "last_update_date" : retValue = tmpPage.DataUltimaModifica
                                        Case "rel_link" : retValue = tmpPage.FolderPath.Replace("\", "/")
                                        Case "abs_link" : retValue = "http://" & HttpContext.Current.Session("SiteName") & tmpPage.FolderPath.Replace("\", "/")
                                        Case "website_link" : retValue = HttpContext.Current.Session("SiteName")
                                        Case "breadcrumb" : retValue = GenerateBreadCrumb("http://" & HttpContext.Current.Session("SiteName"), tmpPage.FolderPath.Replace("\", "/"), Separator, CssClass, linklastelement, overwriteLastTitle, urlappendtext)
                                        Case "page_id" : retValue = tmpPage.idPagina
                                        Case "querystring"
                                            If Not HttpContext.Current.Request.QueryString(value) Is Nothing Then
                                                retValue = prefix & HttpContext.Current.Request.QueryString(value)
                                            Else
                                                retValue = ""
                                            End If
                                    End Select

                                    Return retValue
                                Else
                                    cmsPage._CMS_Warning &= "<br />--- Attributo page_id non valido: <strong>page_id=""" & page_id & """</strong> <br />Nel comando: <strong>" & CommandToSearch.Replace("<", "&lt;").Replace(">", "&gt;") & "</strong>"
                                End If
                            Else
                                cmsPage._CMS_Warning &= "<br />--- Attributo name non valido: <strong>name=""" & name & """</strong> <br />Nel comando: <strong>" & CommandToSearch.Replace("<", "&lt;").Replace(">", "&gt;") & "</strong>"
                            End If
                        Else
                            cmsPage._CMS_Warning &= "<br />--- Attributo non numerico: <strong>page_id=""" & page_id & """</strong> <br />Nel comando: <strong>" & CommandToSearch.Replace("<", "&lt;").Replace(">", "&gt;") & "</strong>"
                        End If
                    Else
                        cmsPage._CMS_Warning &= "<br />--- Attributo non riconosciuto: <strong>page_id=""" & page_id & """</strong> <br />Nel comando: <strong>" & CommandToSearch.Replace("<", "&lt;").Replace(">", "&gt;") & "</strong>"
                    End If

                    Return retValue
                End If

                If depth.Length > 0 And page_id.Length = 0 Then
                    If isInListParse Then Menu.folderpath = GetFolderPathFromCodPaginaAndIdLingua(.codPagina, .idLingua, tmpDbCommand, tmpDbConnection)

                    If depth.Length > 0 Then
                        If IsNumeric(depth) Then
                            Dim tmpDepth As Long = Convert.ToInt16(depth)
                            Dim tmpFolderPath = Menu.folderpath.Replace("\", "/")
                            Dim maxDepth As Long = MaxDepthOfMenuPath(tmpFolderPath)

                            If tmpDepth < maxDepth Then
                                Dim tmpPathPage As String = GetMenuPathDepth(tmpFolderPath, tmpDepth)

                                If checkFieldNameExist(name) = True Then
                                    Dim tmpMenu As _cmsVoceDiMenu
                                    tmpMenu = GetVoceMenuFromFolderPath(tmpPathPage.Replace("/", "\"), , tmpDbCommand, tmpDbConnection)

                                    Dim tmpPage As New _cmsPage

                                    JertCMS_ReadPageContent(tmpMenu, tmpPage, , tmpDbCommand, tmpDbConnection)

                                    Select Case name
                                        Case "title" : retValue = tmpPage.Titolo
                                        Case "long_title" : retValue = tmpPage.TitoloH1
                                        Case "description" : retValue = tmpPage.MetaDescription
                                        Case "menu" : retValue = tmpMenu.DescrizioneBreveNelMenu
                                        Case "content" : retValue = tmpPage.HTMLPageContent
                                        Case "publish_date" : retValue = tmpPage.DataInserimento
                                        Case "last_update_date" : retValue = tmpPage.DataUltimaModifica
                                        Case "rel_link" : retValue = tmpMenu.folderpath.Replace("\", "/")
                                        Case "abs_link" : retValue = "http://" & HttpContext.Current.Session("SiteName") & tmpMenu.folderpath.Replace("\", "/")
                                        Case "website_link" : retValue = HttpContext.Current.Session("SiteName")
                                        Case "breadcrumb" : retValue = GenerateBreadCrumb("http://" & HttpContext.Current.Session("SiteName"), tmpMenu.folderpath.Replace("\", "/"), Separator, CssClass, linklastelement, overwriteLastTitle, urlappendtext)
                                        Case "page_id" : retValue = tmpPage.idPagina
                                        Case "querystring"
                                            If Not HttpContext.Current.Request.QueryString(value) Is Nothing Then
                                                retValue = prefix & HttpContext.Current.Request.QueryString(value)
                                            Else
                                                retValue = ""
                                            End If
                                    End Select

                                    Return retValue
                                Else
                                    cmsPage._CMS_Warning &= "<br />--- Attributo name non valido: <strong>name=""" & name & """</strong> <br />Nel comando: <strong>" & CommandToSearch.Replace("<", "&lt;").Replace(">", "&gt;") & "</strong>"
                                End If
                            Else
                                cmsPage._CMS_Warning &= "<br />--- Attributo con un numero di profondita errato o troppo elevato: <strong>depth=""" & depth & """</strong> <br />Nel comando: <strong>" & CommandToSearch.Replace("<", "&lt;").Replace(">", "&gt;") & "</strong>"
                            End If
                        Else
                            cmsPage._CMS_Warning &= "<br />--- Attributo non numerico: <strong>depth=""" & depth & """</strong> <br />Nel comando: <strong>" & CommandToSearch.Replace("<", "&lt;").Replace(">", "&gt;") & "</strong>"
                        End If
                    Else
                        cmsPage._CMS_Warning &= "<br />--- Attributo non riconosciuto: <strong>depth=""" & depth & """</strong> <br />Nel comando: <strong>" & CommandToSearch.Replace("<", "&lt;").Replace(">", "&gt;") & "</strong>"
                    End If

                    Return retValue
                End If

                Select Case name
                    Case "title" : retValue = .Titolo
                    Case "long_title" : retValue = .TitoloH1
                    Case "description" : retValue = .MetaDescription
                    Case "menu" : retValue = Menu.DescrizioneBreveNelMenu
                    Case "content" : retValue = .HTMLPageContent
                    Case "publish_date" : retValue = .DataInserimento
                    Case "last_update_date" : retValue = .DataUltimaModifica
                    Case "rel_link" : retValue = Menu.folderpath.Replace("\", "/")
                    Case "abs_link" : retValue = "http://" & HttpContext.Current.Session("SiteName") & Menu.folderpath.Replace("\", "/")
                    Case "website_link" : retValue = HttpContext.Current.Session("SiteName")
                    Case "breadcrumb" : retValue = GenerateBreadCrumb("http://" & HttpContext.Current.Session("SiteName"), Menu.folderpath.Replace("\", "/"), Separator, CssClass, linklastelement, overwriteLastTitle, urlappendtext)
                    Case "page_id" : retValue = .idPagina
                    Case "querystring"
                        If Not HttpContext.Current.Request.QueryString(value) Is Nothing Then
                            retValue = prefix & HttpContext.Current.Request.QueryString(value)
                        Else
                            retValue = ""
                        End If
                    Case Else
                        cmsPage._CMS_Warning &= "<br />--- Attributo non riconosciuto: <strong>name=""" & name & """</strong> <br />Nel comando: <strong>" & CommandToSearch.Replace("<", "&lt;").Replace(">", "&gt;") & "</strong>"
                End Select
            End With

            Return retValue
        End Function

        Private Function JertCMS_ReadTemplateVar(ByVal CommandToSearch As String, ByRef cmsPage As _cmsPage, ByRef Menu As _cmsVoceDiMenu, ByVal name As String, ByVal depth As String, ByVal page_id As String, Optional ByVal isInListParse As Boolean = False, Optional ByVal isInMenuParse As Boolean = False, Optional ByVal PageIDInList As Long = 0, Optional ByVal HideErrors As Boolean = False, Optional ByRef tmpDbCommand As OleDbCommand = Nothing, Optional ByRef tmpDbConnection As OleDbConnection = Nothing) As String
            Dim tmpSQL As String = ""
            tmpSQL = "SELECT TemplateVariablesInPages.idTemplateVariablesInTemplate, TemplateVariablesInPages.idPage, TemplateVariablesInTemplate.idTemplate, TemplateVariablesInPages.TVValue, TemplateVariablesInPages.Param, TemplateVariablesList.Name, TemplateVariablesList.Description "
            tmpSQL &= " FROM TemplateVariablesInPages INNER JOIN (TemplateVariablesInTemplate INNER JOIN TemplateVariablesList "
            tmpSQL &= " ON TemplateVariablesInTemplate.idTemplateVariablesList = TemplateVariablesList.idTV) "
            tmpSQL &= " ON TemplateVariablesInPages.idTemplateVariablesInTemplate = TemplateVariablesInTemplate.idTemplateVariablesInTemplate "
            tmpSQL &= " WHERE idPage = " & cmsPage.idPagina & " AND idTemplate = " & cmsPage.idTemplate & " AND Name = '" & name & "'"

            'Inizializzo retValue a CommandToSearch per la gestione degli errori..
            Dim retValue As String = CommandToSearch

            If (isInListParse And depth.Length = 0 And page_id = "list") Then page_id = cmsPage.idPagina
            If (isInListParse And depth.Length > 0 And page_id = "list") Then page_id = ""

            If isInMenuParse Then
                If (isInMenuParse And page_id.ToLower = "menu") Then
                    page_id = cmsPage.idPagina
                Else
                    page_id = PageIDInList
                End If
            End If

            If Not HideErrors Then
                If (isInListParse And (Not IsNumeric(page_id) And page_id.Length > 0) And page_id.ToLower <> "list") Then
                    cmsPage._CMS_Warning &= "<br />--- Attributo page_id non valido (atteso: ""list"" o numerico): <strong>page_id=""" & page_id & """</strong> <br />Nel comando: <strong>" & CommandToSearch.Replace("<", "&lt;").Replace(">", "&gt;") & "</strong>"
                    Return retValue
                End If

                If (isInMenuParse And (Not IsNumeric(page_id) And page_id.Length > 0) And page_id.ToLower <> "menu") Then
                    cmsPage._CMS_Warning &= "<br />--- Attributo page_id non valido (atteso: ""menu"" o numerico): <strong>page_id=""" & page_id & """</strong> <br />Nel comando: <strong>" & CommandToSearch.Replace("<", "&lt;").Replace(">", "&gt;") & "</strong>"
                    Return retValue
                End If
            End If

            With cmsPage
                If depth.Length = 0 And page_id.Length > 0 Then
                    tmpSQL = ""

                    If page_id.Length > 0 Then
                        If IsNumeric(page_id) Then
                            Dim tmpPageID As Long = Convert.ToInt16(page_id)

                            Dim tmpPage As New _cmsPage
                            tmpPage = GetPageByID(tmpPageID, tmpDbCommand, tmpDbConnection)

                            If tmpPage.idErrore = 0 Then
                                'Dim tmpMenu As _cmsVoceDiMenu
                                'VECCHIO -> 'tmpMenu = GetVoceMenuFromFolderPath(GetFolderPathFromCodPaginaAndIdLingua(tmpPage.codPagina, tmpPage.idLingua, tmpDbCommand, tmpDbConnection), , tmpDbCommand, tmpDbConnection)
                                'tmpMenu = GetVoceMenuFromFolderPath(tmpPage.FolderPath, tmpPage.idLingua, tmpDbCommand, tmpDbConnection)

                                tmpSQL = "SELECT TemplateVariablesInPages.idTemplateVariablesInTemplate, TemplateVariablesInPages.idPage, TemplateVariablesInTemplate.idTemplate, TemplateVariablesInPages.TVValue, TemplateVariablesInPages.Param, TemplateVariablesList.Name, TemplateVariablesList.Description "
                                tmpSQL &= " FROM TemplateVariablesInPages INNER JOIN (TemplateVariablesInTemplate INNER JOIN TemplateVariablesList "
                                tmpSQL &= " ON TemplateVariablesInTemplate.idTemplateVariablesList = TemplateVariablesList.idTV) "
                                tmpSQL &= " ON TemplateVariablesInPages.idTemplateVariablesInTemplate = TemplateVariablesInTemplate.idTemplateVariablesInTemplate "
                                tmpSQL &= " WHERE idPage = " & tmpPage.idPagina & " AND idTemplate = " & tmpPage.idTemplate & " AND Name = '" & name & "'"
                            Else
                                cmsPage._CMS_Warning &= "<br />--- Attributo page_id non valido: <strong>page_id=""" & page_id & """</strong> <br />Nel comando: <strong>" & CommandToSearch.Replace("<", "&lt;").Replace(">", "&gt;") & "</strong>"
                            End If
                        Else
                            cmsPage._CMS_Warning &= "<br />--- Attributo non numerico: <strong>page_id=""" & page_id & """</strong> <br />Nel comando: <strong>" & CommandToSearch.Replace("<", "&lt;").Replace(">", "&gt;") & "</strong>"
                        End If
                    Else
                        cmsPage._CMS_Warning &= "<br />--- Attributo non riconosciuto: <strong>page_id=""" & page_id & """</strong> <br />Nel comando: <strong>" & CommandToSearch.Replace("<", "&lt;").Replace(">", "&gt;") & "</strong>"
                    End If

                    If tmpSQL.Length = 0 Then Return retValue
                End If

                If depth.Length > 0 And page_id.Length = 0 Then
                    If isInListParse Then Menu.folderpath = GetFolderPathFromCodPaginaAndIdLingua(.codPagina, .idLingua, tmpDbCommand, tmpDbConnection)

                    tmpSQL = ""

                    If depth.Length > 0 Then
                        If IsNumeric(depth) Then
                            Dim tmpDepth As Long = Convert.ToInt16(depth)
                            Dim tmpFolderPath = Menu.folderpath.Replace("\", "/")
                            Dim maxDepth As Long = MaxDepthOfMenuPath(tmpFolderPath)

                            If tmpDepth < maxDepth Then
                                Dim tmpPathPage As String = GetMenuPathDepth(tmpFolderPath, tmpDepth)

                                Dim tmpMenu As _cmsVoceDiMenu
                                tmpMenu = GetVoceMenuFromFolderPath(tmpPathPage.Replace("/", "\"), , tmpDbCommand, tmpDbConnection)

                                Dim tmpPage As New _cmsPage

                                tmpSQL = ""

                                JertCMS_ReadPageContent(tmpMenu, tmpPage, , tmpDbCommand, tmpDbConnection)

                                tmpSQL = "SELECT TemplateVariablesInPages.idTemplateVariablesInTemplate, TemplateVariablesInPages.idPage, TemplateVariablesInTemplate.idTemplate, TemplateVariablesInPages.TVValue, TemplateVariablesInPages.Param, TemplateVariablesList.Name, TemplateVariablesList.Description "
                                tmpSQL &= " FROM TemplateVariablesInPages INNER JOIN (TemplateVariablesInTemplate INNER JOIN TemplateVariablesList "
                                tmpSQL &= " ON TemplateVariablesInTemplate.idTemplateVariablesList = TemplateVariablesList.idTV) "
                                tmpSQL &= " ON TemplateVariablesInPages.idTemplateVariablesInTemplate = TemplateVariablesInTemplate.idTemplateVariablesInTemplate "
                                tmpSQL &= " WHERE idPage = " & tmpPage.idPagina & " AND idTemplate = " & tmpPage.idTemplate & " AND Name = '" & name & "'"
                            Else
                                cmsPage._CMS_Warning &= "<br />--- Attributo con un numero di profondita errato o troppo elevato: <strong>depth=""" & depth & """</strong> <br />Nel comando: <strong>" & CommandToSearch.Replace("<", "&lt;").Replace(">", "&gt;") & "</strong>"
                            End If
                        Else
                            cmsPage._CMS_Warning &= "<br />--- Attributo non numerico: <strong>depth=""" & depth & """</strong> <br />Nel comando: <strong>" & CommandToSearch.Replace("<", "&lt;").Replace(">", "&gt;") & "</strong>"
                        End If
                    Else
                        cmsPage._CMS_Warning &= "<br />--- Attributo non riconosciuto: <strong>depth=""" & depth & """</strong> <br />Nel comando: <strong>" & CommandToSearch.Replace("<", "&lt;").Replace(">", "&gt;") & "</strong>"
                    End If

                    If tmpSQL.Length = 0 Then Return retValue
                End If
            End With

            If IsNothing(tmpDbConnection) Then
                db.OpenConn(Sql)
                myReader = db.ExecuteReader()
            Else
                db.OpenConn(Sql, , , True, tmpDbConnection, tmpDbCommand)
                myReader = db.ExecuteReader(True, tmpDbCommand)
            End If

            Dim tmpTrovata As Boolean = False

            While myReader.Read
                retValue = myReader("TVValue") : tmpTrovata = True
                Exit While
            End While

            myReader.Close()
            If IsNothing(tmpDbConnection) Then db.CloseConn()

            If tmpTrovata = False Then
                cmsPage._CMS_Warning &= "<br />--- tv non trovata: <strong>name=""" & name & """</strong> <br />Nel comando: <strong>" & CommandToSearch.Replace("<", "&lt;").Replace(">", "&gt;") & "</strong>"
            End If

            Return retValue
        End Function

        Private Function JertCMS_CheckErrors(ByVal regexTAG As String, ByVal HTMLPage As String, ByVal NomeSezioneErrore As String) As String
            Dim errMess As String = IIf(cmsPage._CMS_Warning Is Nothing, "", cmsPage._CMS_Warning)

            Dim regex As New Regex(regexTAG, RegexOptions.IgnoreCase)
            Dim matches As MatchCollection = regex.Matches(HTMLPage)
            Dim match As Match
            For Each match In matches
                errMess &= "<br />--- Comando non riconosciuto: <br/><strong>" & match.Value.Replace("<", "&lt;").Replace(">", "&gt;") & "</strong>" & NomeSezioneErrore & "<br />"
            Next match
            Return errMess
        End Function

        Public Function JertCMS_SubstImageTAG(ByVal regexTAG As String, ByVal HTMLPage As String, ByVal Menu_ProfonditaLivello As Long, ByVal Menu_FolderPath As String, ByVal Menu_codPaginaMadre As Long, ByVal Menu_idLingua As Long) As String
            Dim regex As New Regex(regexTAG, RegexOptions.IgnoreCase)
            Dim matches As MatchCollection = regex.Matches(HTMLPage)
            Dim match As Match
            For Each match In matches
                HTMLPage = HTMLPage.Replace("[jcms:img " & match.Groups("idImmagine").ToString & "]", JertCMS_WriteImage(Menu_ProfonditaLivello, Menu_FolderPath, Menu_codPaginaMadre, Menu_idLingua, Convert.ToInt32(match.Groups("idImmagine").ToString)))
            Next match
            Return HTMLPage
        End Function

        Public Function JertCMS_SubstFileTAG(ByVal regexTAG As String, ByVal HTMLPage As String) As String
            Dim regex As New Regex(regexTAG, RegexOptions.IgnoreCase)
            Dim matches As MatchCollection = regex.Matches(HTMLPage)
            Dim match As Match
            For Each match In matches
                HTMLPage = HTMLPage.Replace("[jcms:file " & match.Groups("idFile").ToString & "]", JertCMS_WriteFile(Convert.ToInt32(match.Groups("idFile").ToString)))
            Next match
            Return HTMLPage
        End Function

        Public Function JertCMS_SubstMenuTAG(ByVal regexTAG As String, ByVal HTMLPage As String) As String
            Dim regex As New Regex(regexTAG, RegexOptions.IgnoreCase)
            Dim matches As MatchCollection = regex.Matches(HTMLPage)
            Dim match As Match
            For Each match In matches
                HTMLPage = HTMLPage.Replace("[jcms:Menu]", JertCMS_WriteMenu)
            Next match
            Return HTMLPage
        End Function

        Public Function JertCMS_SubstLightboxTAG(ByVal regexTAG As String, ByVal HTMLPage As String, ByVal Menu_FolderPath As String) As String
            Dim regex As New Regex(regexTAG, RegexOptions.IgnoreCase)
            Dim matches As MatchCollection = regex.Matches(HTMLPage)
            Dim match As Match
            For Each match In matches
                HTMLPage = HTMLPage.Replace("[jcms:lightbox]", JertCMS_WriteLightBox(Menu_FolderPath))
            Next match
            Return HTMLPage
        End Function

        Public Function JertCMS_SubstGalleryMenuTAG(ByVal regexTAG As String, ByVal HTMLPage As String) As String
            Dim regex As New Regex(regexTAG, RegexOptions.IgnoreCase)
            Dim matches As MatchCollection = regex.Matches(HTMLPage)
            Dim match As Match
            For Each match In matches
                HTMLPage = HTMLPage.Replace("[jcms:MenuGallery]", JertCMS_WriteGalleryMenu)
            Next match
            Return HTMLPage
        End Function

        Public Function JertCMS_WriteImage(ByVal Menu_ProfonditaLivello As Long, ByVal Menu_FolderPath As String, ByVal Menu_codPaginaMadre As Long, ByVal Menu_idLingua As Long, ByVal ImmaginiPagine_idImmagine As Long) As String
            Dim HTMLImage As String = ""

            'SQL: Originale
            'SELECT *
            'FROM ImmaginiPagine INNER JOIN (Pagine INNER JOIN Menu ON Pagine.codPagina = Menu.codPagina) ON ImmaginiPagine.codPagina = Pagine.codPagina
            'Where Menu.ProfonditaLivello=1 AND Menu.FolderPath='/' AND Menu.codPaginaMadre=0 AND Menu.idLingua = 1 AND ImmaginiPagine.SlideOrder=0 AND ImmaginiPagine.idImmagine = 9

            Sql = " SELECT *"
            Sql &= " FROM ImmaginiPagine INNER JOIN (Pagine INNER JOIN Menu ON Pagine.codPagina = Menu.codPagina) ON ImmaginiPagine.codPagina = Pagine.codPagina"
            Sql &= " Where Menu.ProfonditaLivello=" & Menu_ProfonditaLivello & " AND Menu.FolderPath='" & Menu_FolderPath & "' AND Menu.codPaginaMadre=" & Menu_codPaginaMadre & " AND Menu.idLingua = " & Menu_idLingua & " AND ImmaginiPagine.SlideOrder = 0 " & " AND ImmaginiPagine.idImmagine = " & ImmaginiPagine_idImmagine & " "


            db.OpenConn(Sql)
            myReader = db.ExecuteReader

            While myReader.Read
                HTMLImage = "<img src=""" & myReader("IMGsrc") & """ alt=""" & myReader("IMGalt") & """ title=""" & myReader("IMGtitle") & """ class=""" & myReader("IMGclass") & """ />"
                If myReader("Ahref").ToString.Length > 0 OrElse myReader("Aclass").ToString.Length > 0 OrElse myReader("Aid").ToString.Length OrElse myReader("ADescrizione").ToString.Length > 0 Then
                    HTMLImage = "<a href=""" & myReader("Ahref") & """ id=""" & myReader("Aclass") & """ id=""" & myReader("Aid") & """>" & HTMLImage & myReader("ADescrizione") & "</a>" & vbCrLf
                End If
            End While

            myReader.Close()
            db.CloseConn()

            Return HTMLImage
        End Function

        Public Function JertCMS_WriteFile(ByVal idFile As Long) As String
            Dim HTMLFile As String = ""

            Sql = " SELECT * From Files Where idFile = " & idFile

            db.OpenConn(Sql)
            myReader = db.ExecuteReader

            While myReader.Read
                HTMLFile &= "<img alt="""" title="""">" & myReader("Estensione") & "</img> - "
                HTMLFile &= "<a href=""" & myReader("Path").ToString.Replace("\", "/") & myReader("NomeFile") & "." & myReader("Estensione") & """ target=""_blank"">" & myReader("NomeFile") & "." & myReader("Estensione") & "</a> - Dimensione: <strong>" & FormatNumber(Convert.ToDecimal((myReader("Dimensione"))) / 1024, 1, , , TriState.True) & " Kb</strong>"
                HTMLFile &= "<br />"
            End While

            myReader.Close()
            db.CloseConn()

            Return HTMLFile
        End Function

        Public Function JertCMS_WriteSlideShow(ByVal Menu_ProfonditaLivello As Long, ByVal Menu_FolderPath As String, ByVal Menu_codPaginaMadre As Long, ByVal Menu_idLingua As Long) As String
            Dim HTMLSlideShow As String = ""

            'SQL: Originale
            'SELECT *
            'FROM ImmaginiPagine INNER JOIN (Pagine INNER JOIN Menu ON Pagine.codPagina = Menu.codPagina) ON ImmaginiPagine.codPagina = Pagine.codPagina
            'Where Menu.ProfonditaLivello=1 AND Menu.FolderPath='/' AND Menu.codPaginaMadre=0 AND Menu.idLingua = 1 AND ImmaginiPagine.SlideOrder>0
            'Order By ImmaginiPagine.SlideOrder

            Sql = " SELECT *"
            Sql &= " FROM ImmaginiPagine INNER JOIN (Pagine INNER JOIN Menu ON Pagine.codPagina = Menu.codPagina) ON ImmaginiPagine.codPagina = Pagine.codPagina"
            Sql &= " Where Menu.ProfonditaLivello=" & Menu_ProfonditaLivello & " AND Menu.FolderPath='" & Menu_FolderPath & "' AND Menu.codPaginaMadre=" & Menu_codPaginaMadre & " AND Menu.idLingua = " & Menu_idLingua & " AND ImmaginiPagine.SlideOrder > 0 "
            Sql &= " Order By ImmaginiPagine.SlideOrder"

            db.OpenConn(Sql)
            myReader = db.ExecuteReader

            While myReader.Read
                HTMLSlideShow &= "<li class=""sliderImage""><img src=""" & myReader("IMGsrc") & """ alt=""" & myReader("IMGalt") & """ title=""" & myReader("IMGtitle") & """ /><span class=""bottom""><strong>" & myReader("SlideTitolo") & "</strong>" & myReader("SlideDescrizione") & "</span></li>" & vbCrLf
            End While

            myReader.Close()
            db.CloseConn()

            HTMLSlideShow = vbCrLf & "<div id=""animation""><div id=""slider""><ul id=""sliderContent"">" & HTMLSlideShow & "</ul></div></div>" & vbCrLf

            Return HTMLSlideShow
        End Function

        Public Sub JertCMS_ReadPageContent(ByRef Menu As _cmsVoceDiMenu, ByRef cmsPage As _cmsPage, Optional ByVal ForceidLingua As Long = -1, Optional ByRef tmpDbCommand As OleDbCommand = Nothing, Optional ByRef tmpDbConnection As OleDbConnection = Nothing)
            Sql = " SELECT *"
            Sql &= " FROM (Pagine LEFT JOIN Menu ON Pagine.codPagina = Menu.codPagina) INNER JOIN Templates ON Pagine.idTemplate = Templates.idTemplate "

            Dim tmpIdLingua As Long

            If ForceidLingua = -1 Then
                tmpIdLingua = cmsLanguage.idLingua
            Else
                tmpIdLingua = ForceidLingua
            End If

            If Menu.ProfonditaLivello = 1 Then
                Sql &= " WHERE Menu.folderpath = '" & Menu.folderpath & "' AND Pagine.idLingua = " & tmpIdLingua & ";"
            Else
                Sql &= " WHERE Menu.ProfonditaLivello = " & Menu.ProfonditaLivello & " AND Menu.Ordine = " & Menu.ordine & " AND Menu.folderpath = '" & Menu.folderpath & "' AND Menu.idLingua = " & Menu.idLingua & " AND Pagine.idLingua = " & tmpIdLingua & ";"
            End If

            If IsNothing(tmpDbConnection) Then
                db.OpenConn(Sql)
                myReader = db.ExecuteReader()
            Else
                db.OpenConn(Sql, , , True, tmpDbConnection, tmpDbCommand)
                myReader = db.ExecuteReader(True, tmpDbCommand)
            End If

            cmsPage.PageFound = False

            While myReader.Read
                With cmsPage
                    .PageFound = True

                    .codPagina = myReader("Pagine.codPagina")
                    .DataInserimento = myReader("DataInserimento")
                    .DataUltimaModifica = IIf(IsDBNull(myReader("DataUltimaModifica")), Date.Now, myReader("DataUltimaModifica"))
                    .filename = IIf(IsDBNull(myReader("filename")), "", myReader("filename"))
                    .idLingua = myReader("Pagine.idLingua")
                    .idPagina = myReader("idPagina")
                    .LivelloVisibilita = myReader("LivelloVisibilita")
                    .MetaDescription = myReader("MetaDescription")
                    .TitoloH1 = myReader("TitoloH1")
                    .Tipo = myReader("Tipo")
                    .Titolo = myReader("Titolo")

                    .HTMLPageContent = IIf(IsDBNull(myReader("Content")), "", myReader("Content"))

                    .idTemplate = myReader("Templates.idTemplate")

                    .NomeTemplate = myReader("Nome")
                End With

                Exit While
            End While

            myReader.Close()
            If IsNothing(tmpDbConnection) Then db.CloseConn()

            'Recupero il testo della pagina... in base al Template...
            ReadTemplate(cmsPage, cmsPage.idTemplate, tmpDbCommand, tmpDbConnection)

            cmsPage.HTMLFullPage = cmsPage.HTMLCompletoHeadPagina & cmsPage.HTMLBodyOpen & cmsPage.HTMLCompletoPagina & cmsPage.HTMLBodyClose
        End Sub

        Public Sub ReadTemplate(ByRef cmsPage As _cmsPage, Optional ByVal idTemplate As Long = -1, Optional ByRef tmpDbCommand As OleDbCommand = Nothing, Optional ByRef tmpDbConnection As OleDbConnection = Nothing)
            'Se c'è -1 il template non è impostato...
            Dim tmpSQL As String = "Select Header, BodyTAGOpen, BodyTagClose, Contenuto, HaveDetails, DetailCount From Templates Where idTemplate = " & idTemplate

            If idTemplate = -1 Then
                'TODO Stringa da globalizzare..
                cmsPage._CMS_Warning = "Attenzione, la pagina selezionata non ha un template impostato."
                cmsPage.idErrore = 1
            End If

            If IsNothing(tmpDbConnection) Then
                db.OpenConn(tmpSQL)
                myReader = db.ExecuteReader()
            Else
                db.OpenConn(tmpSQL, , , True, tmpDbConnection, tmpDbCommand)
                myReader = db.ExecuteReader(True, tmpDbCommand)
            End If

            While myReader.Read
                cmsPage.HTMLCompletoHeadPagina = myReader("Header")
                cmsPage.HTMLBodyOpen = myReader("BodyTAGOpen")
                cmsPage.HTMLBodyClose = myReader("BodyTagClose")
                cmsPage.HTMLCompletoPagina = myReader("Contenuto")

                cmsPage.HaveDetails = Convert.ToBoolean(myReader("HaveDetails"))
                cmsPage.DetailCount = myReader("DetailCount")

                Exit While
            End While

            myReader.Close()

            Dim tmpReader As OleDbDataReader
            Dim AttributeCounter As Long = 0

            If cmsPage.HaveDetails Then
                ReDim cmsPage.TemplateDetail(cmsPage.DetailCount - 1)
                Dim TemplateDetailIndex As Long = 0

                tmpSQL = ""
                tmpSQL &= "SELECT TemplateDetails.id, TemplateDetails.CustomID, TemplateDetails.idTemplate, TemplateDetails.TemplateDetailOrder, TemplateDetails.Content, TemplateDetails.ComponentID, TemplateDetails.HaveAttributes, TemplateDetails.AttributesCount, ModuleComponents.ComponentName, ModuleComponents.FileName, ModulesInstalled.Name, ModulesInstalled.ModuleFolder "
                tmpSQL &= "FROM (TemplateDetails LEFT JOIN ModuleComponents ON TemplateDetails.ComponentID = ModuleComponents.idComponent) LEFT JOIN ModulesInstalled ON ModuleComponents.idModule = ModulesInstalled.idModule "
                tmpSQL &= "WHERE(TemplateDetails.idTemplate = " & idTemplate & ") "
                tmpSQL &= "Order By TemplateDetailOrder "


                If IsNothing(tmpDbConnection) Then
                    db.OpenConn(tmpSQL)
                    myReader = db.ExecuteReader()
                Else
                    db.OpenConn(tmpSQL, , , True, tmpDbConnection, tmpDbCommand)
                    myReader = db.ExecuteReader(True, tmpDbCommand)
                End If

                While myReader.Read
                    With cmsPage.TemplateDetail(TemplateDetailIndex)
                        .id = myReader("id")
                        .idTemplate = myReader("idTemplate")
                        .TemplateDetailOrder = myReader("TemplateDetailOrder")
                        .Content = myReader("Content")
                        .ComponentID = myReader("ComponentID")

                        .CustomID = myReader("CustomID")

                        .ComponentName = IIf(IsDBNull(myReader("ComponentName")), "", myReader("ComponentName"))
                        .FileName = IIf(IsDBNull(myReader("FileName")), "", myReader("FileName"))
                        .Name = IIf(IsDBNull(myReader("Name")), "", myReader("Name"))
                        .ModuleFolder = IIf(IsDBNull(myReader("ModuleFolder")), "", myReader("ModuleFolder"))

                        .HaveAttributes = myReader("HaveAttributes")
                        .AttributesCount = myReader("AttributesCount")

                        If .HaveAttributes Then
                            ReDim .AttributesList(.AttributesCount - 1)
                            AttributeCounter = 0

                            tmpSQL = "Select * From TemplateDetailAttributes WHERE idTemplateDetail = " & .id
                            db.OpenConn(tmpSQL, , , True, tmpDbConnection, tmpDbCommand)
                            tmpReader = db.ExecuteReader(True, tmpDbCommand)

                            Do While tmpReader.Read
                                With .AttributesList(AttributeCounter)
                                    .id = tmpReader("id")
                                    .idTemplateDetail = tmpReader("idTemplateDetail")
                                    .Name = tmpReader("AttrName")
                                    .Value = tmpReader("AttrValue")
                                End With

                                AttributeCounter += 1
                            Loop

                            tmpReader.Close()
                        End If
                    End With

                    TemplateDetailIndex += 1
                End While

                myReader.Close()
            End If

            If IsNothing(tmpDbConnection) Then db.CloseConn()

            If cmsPage.PageFound = False Then
                ReDim cmsPage.TemplateDetail(1)

                cmsPage.HaveDetails = True
                cmsPage.DetailCount = 1

                With cmsPage.TemplateDetail(0)
                    .id = -1
                    .idTemplate = -1
                    .TemplateDetailOrder = -1
                    .Content = "Redirect"
                    .ComponentID = -1

                    .CustomID = -1

                    .ComponentName = "jCMSRedirect"
                    .FileName = "PageNotFoundRedirect.ascx"
                    .Name = "Redirect"
                    .ModuleFolder = "jCMSCore"

                    .HaveAttributes = False
                    .AttributesCount = 0
                End With
            End If
        End Sub


        Public Function JertCMS_WriteH1(ByVal Menu_ProfonditaLivello As Long, ByVal Menu_Ordine As Long, ByVal Menu_FolderPath As String, ByVal Menu_idLingua As Long) As String
            Dim HTMLH1 As String = ""

            'SQL: Originale
            'SELECT Pagine.Testo, Pagine.TitoloH1, Pagine.MetaDescription, Pagine.Titolo, Pagine.filename, Pagine.Tipo, Pagine.LivelloVisibilita, Pagine.codPagina, Pagine.DataInserimento, Pagine.DataUltimaModifica, Menu.ProfonditaLivello, Menu.folderpath
            'FROM Pagine LEFT JOIN Menu ON Pagine.codPagina = Menu.codPagina
            'WHERE Menu.ProfonditaLivello = 1 AND Menu.folderpath = '/'

            Sql = " SELECT Pagine.Content, Pagine.TitoloH1, Pagine.MetaDescription, Pagine.Titolo, Pagine.filename, Pagine.Tipo, Pagine.LivelloVisibilita, Pagine.codPagina, Pagine.DataInserimento, Pagine.DataUltimaModifica, Menu.ProfonditaLivello, Menu.folderpath"
            Sql &= " FROM Pagine LEFT JOIN Menu ON Pagine.codPagina = Menu.codPagina"
            Sql &= " WHERE Menu.ProfonditaLivello = " & Menu_ProfonditaLivello & " AND Menu.Ordine = " & Menu_Ordine & " AND Menu.folderpath = '" & Menu_FolderPath & "' AND Menu.idLingua = " & Menu_idLingua & ";"

            db.OpenConn(Sql)
            myReader = db.ExecuteReader

            While myReader.Read
                HTMLH1 &= myReader("Titolo")
            End While

            myReader.Close()
            db.CloseConn()

            Return "<h1>" & HTMLH1 & "</h1>"
        End Function

        Public Sub LoadListImmagini(ByVal dropdownList As DropDownList, ByVal idGalleria As Long)
            With dropdownList
                Sql = "Select * from Images Where idGallery = " & idGalleria & ";"
                db.OpenConn(Sql)
                myReader = db.ExecuteReader()
                .Items.Clear()

                While myReader.Read
                    Dim newListItem As New ListItem()
                    newListItem.Text = myReader("ImageTitle")
                    newListItem.Value = myReader("id")
                    .Items.Add(newListItem)
                End While

                .DataBind()

                myReader.Close()
                db.CloseConn()
            End With
        End Sub

        Public Function LoadListPosizioniImmagini(ByVal dropdownList As DropDownList, ByVal idGalleria As Long, Optional ByVal AggiungiUnoAllaFine As Boolean = False) As Long

            Dim retValue As Long = 0

            With dropdownList
                Sql = "SELECT id, Posizione FROM Images Where idGallery = " & idGalleria & " order By Posizione;"
                db.OpenConn(Sql)
                myReader = db.ExecuteReader()
                .Items.Clear()

                Dim MaxPos As Long = -1

                While myReader.Read
                    Dim newListItem As New ListItem()
                    newListItem.Text = myReader("Posizione")
                    MaxPos = Convert.ToInt32(myReader("Posizione"))
                    newListItem.Value = myReader("id")
                    .Items.Add(newListItem)
                    retValue = MaxPos
                End While

                If AggiungiUnoAllaFine Then
                    MaxPos += 1

                    Dim newListItem As New ListItem()
                    newListItem.Text = MaxPos
                    newListItem.Value = "-1"
                    .Items.Add(newListItem)
                    retValue = MaxPos
                End If

                .DataBind()

                myReader.Close()
                db.CloseConn()
            End With

            Return retValue
        End Function

        Public Sub LoadListCartelle(ByVal dropdownList As DropDownList, ByVal Lingua As String)
            With dropdownList
                Sql = "Select DISTINCT Path from Files Order By Path;"
                db.OpenConn(Sql)
                myReader = db.ExecuteReader()
                .Items.Clear()

                Dim newListItem As New ListItem()
                newListItem.Text = Selezionare
                newListItem.Value = idSelezioneNulla
                .Items.Add(newListItem)

                Dim Count As Long = 1

                While myReader.Read
                    newListItem = New ListItem()
                    newListItem.Text = myReader("Path").ToString.Replace(cmsPaths.PathPublic & Lingua & "\" & cmsPaths.PathUploadedFiles, "").Replace("\", "")
                    newListItem.Value = Count
                    .Items.Add(newListItem)

                    Count += 1
                End While

                .DataBind()

                myReader.Close()
                db.CloseConn()
            End With
        End Sub

        Public Function JertCMS_WriteLinkedFilesList(ByVal PathName As String, ByVal Lingua As String) As String
            Dim FilesHTML As String = ""

            Sql = "Select * from Files WHERE Path = '" & cmsPaths.PathPublic & Lingua & "\" & cmsPaths.PathUploadedFiles & PathName & "\' Order By NomeFile;"
            db.OpenConn(Sql)
            myReader = db.ExecuteReader()

            FilesHTML &= "File presenti in: <strong>" & PathName & "</strong><br/><br/>"

            Dim totSize As Decimal = 0

            While myReader.Read
                FilesHTML &= "<img alt="""" title="""">" & myReader("Estensione") & "</img> - "
                FilesHTML &= "[jcms:file " & myReader("IdFile") & "] <a href=""" & myReader("Path").ToString.Replace("\", "/") & myReader("NomeFile") & "." & myReader("Estensione") & """>" & myReader("NomeFile") & "." & myReader("Estensione") & "</a> - Dimensione: <strong>" & FormatNumber(Convert.ToDecimal((myReader("Dimensione"))) / 1024, 1, , , TriState.True) & " Kb</strong>"
                FilesHTML &= "<br />"

                totSize += Convert.ToDecimal((myReader("Dimensione"))) / 1024
            End While

            myReader.Close()
            db.CloseConn()

            FilesHTML &= "<br />Dimensioni Totali File nella cartella: <strong>" & FormatNumber(totSize, 1, , , TriState.True) & " Kb</strong>"

            Return FilesHTML
        End Function

        Public Sub LoadListImmaginiPagine(ByVal dropdownList As DropDownList, ByVal CodPagina As Long, Optional ByVal LoadSlideShowImages As Boolean = False)
            Dim attachSQL As String = " AND SlideOrder = 0 "

            If LoadSlideShowImages Then
                attachSQL = " AND SlideOrder > 0 "
            End If

            With dropdownList
                Sql = "SELECT ImmaginiPagine.* FROM ImmaginiPagine WHERE ImmaginiPagine.codPagina=" & CodPagina & " " & attachSQL & " ;"
                db.OpenConn(Sql)
                myReader = db.ExecuteReader()
                .Items.Clear()

                While myReader.Read
                    Dim newListItem As New ListItem()
                    If LoadSlideShowImages Then
                        newListItem.Text = "[jcms:slideshow] " & db.CheckDbNull(myReader("ADescrizione")) & " " & db.CheckDbNull(myReader("IMGtitle")) & " " & db.CheckDbNull(myReader("IMGalt"))
                    Else
                        newListItem.Text = "[jcms:img " & myReader("IdImmagine") & "] " & db.CheckDbNull(myReader("ADescrizione")) & " " & db.CheckDbNull(myReader("IMGtitle")) & " " & db.CheckDbNull(myReader("IMGalt"))
                    End If

                    newListItem.Value = myReader("IdImmagine")
                    .Items.Add(newListItem)
                End While

                .DataBind()

                myReader.Close()
                db.CloseConn()
            End With
        End Sub

        Public Sub LoadListGallerie(ByVal dropdownList As DropDownList)
            With dropdownList
                Sql = "Select id, Title from Gallery Order by Title asc;"
                db.OpenConn(Sql)
                myReader = db.ExecuteReader()
                .Items.Clear()

                While myReader.Read
                    Dim newListItem As New ListItem()
                    newListItem.Text = myReader("Title")
                    newListItem.Value = myReader("id")
                    .Items.Add(newListItem)
                End While

                .DataBind()

                myReader.Close()
                db.CloseConn()
            End With
        End Sub

        Public Sub LoadListFiles(ByVal dropdownList As DropDownList, ByVal DirectoryRelativePath As String, Optional ByVal UseRootPath As Boolean = False, Optional ByVal SearchPatternsCommaSeparated As String = "*.*")
            With dropdownList

                .Items.Clear()

                Dim Files As List(Of FileInfo) = myDir.GetFileListFromDirectoryPath(DirectoryRelativePath, UseRootPath, SearchPatternsCommaSeparated)

                Dim newListItem As New ListItem()
                newListItem.Text = "All"
                newListItem.Value = idSelezioneNulla
                .Items.Add(newListItem)

                For Each File As FileInfo In Files
                    newListItem = New ListItem()
                    newListItem.Text = File.Name
                    newListItem.Value = File.FullName
                    .Items.Add(newListItem)
                Next

                myReader.Close()
                db.CloseConn()
            End With
        End Sub

        Public Sub LoadListFolders(ByVal dropdownList As DropDownList, ByVal DirectoryRelativePath As String, Optional ByVal UseRootPath As Boolean = False, Optional ByVal FirstElementDescription As String = "All", Optional ByVal ExcludeFolder As String = "")
            With dropdownList

                Dim arrDirectory As ArrayList

                .Items.Clear()

                arrDirectory = myDir.GetSubDirectories(DirectoryRelativePath, UseRootPath)

                Dim newListItem As New ListItem()
                newListItem.Text = FirstElementDescription
                newListItem.Value = idSelezioneNulla
                .Items.Add(newListItem)

                For Each Directory As DirectoryInfo In arrDirectory
                    If Directory.Name.Trim.ToLower <> ExcludeFolder.Trim.ToLower Then
                        newListItem = New ListItem()
                        newListItem.Text = Directory.Name
                        newListItem.Value = Directory.FullName
                        .Items.Add(newListItem)
                    End If
                Next

                myReader.Close()
                db.CloseConn()
            End With
        End Sub

        Public Sub LoadListTemplates(ByVal dropdownList As DropDownList)
            With dropdownList
                Sql = "Select * from Templates Order by Nome asc;"
                db.OpenConn(Sql)
                myReader = db.ExecuteReader()
                .Items.Clear()

                Dim newListItem As New ListItem()
                newListItem.Text = Selezionare
                newListItem.Value = idSelezioneNulla
                .Items.Add(newListItem)

                While myReader.Read
                    newListItem = New ListItem()
                    newListItem.Text = myReader("Nome")
                    newListItem.Value = myReader("idTemplate")
                    .Items.Add(newListItem)
                End While

                myReader.Close()
                db.CloseConn()
            End With
        End Sub

        Public Sub LoadListChunksCategories(ByVal dropdownList As DropDownList)
            With dropdownList
                Sql = "Select * from ChunkCategorie Order by NomeCategoria asc;"
                db.OpenConn(Sql)
                myReader = db.ExecuteReader()
                .Items.Clear()

                Dim newListItem As New ListItem()
                newListItem.Text = Selezionare
                newListItem.Value = idSelezioneNulla
                .Items.Add(newListItem)

                While myReader.Read
                    newListItem = New ListItem()
                    newListItem.Text = myReader("NomeCategoria")
                    newListItem.Value = myReader("idCategoria")
                    .Items.Add(newListItem)
                End While

                myReader.Close()
                db.CloseConn()
            End With
        End Sub

        Public Function idChunkCategoryFromName(ByVal CategoryName As String, Optional ByRef tmpDbCommand As OleDbCommand = Nothing, Optional ByRef tmpDbConnection As OleDbConnection = Nothing) As Long
            Dim retValue As Long = -1

            Sql = "Select idCategoria from ChunkCategorie Where NomeCategoria = '" & CategoryName.Trim & "';"
            If IsNothing(tmpDbConnection) Then
                db.OpenConn(Sql)
                myReader = db.ExecuteReader()
            Else
                db.OpenConn(Sql, , , True, tmpDbConnection, tmpDbCommand)
                myReader = db.ExecuteReader(True, tmpDbCommand)
            End If

            While myReader.Read
                retValue = myReader("idCategoria")
                Exit While
            End While

            myReader.Close()
            If IsNothing(tmpDbConnection) Then db.CloseConn()

            Return retValue
        End Function

        Public Sub LoadListCategorieChunks(ByVal dropdownList As DropDownList)
            With dropdownList
                Sql = "Select * from ChunkCategorie Order by NomeCategoria asc;"
                db.OpenConn(Sql)
                myReader = db.ExecuteReader()
                .Items.Clear()

                Dim newListItem As New ListItem()
                newListItem.Text = Selezionare
                newListItem.Value = idSelezioneNulla
                .Items.Add(newListItem)

                While myReader.Read
                    newListItem = New ListItem()
                    newListItem.Text = myReader("NomeCategoria")
                    newListItem.Value = myReader("idCategoria")
                    .Items.Add(newListItem)
                End While

                .DataBind()

                myReader.Close()
                db.CloseConn()
            End With
        End Sub

        Public Sub LoadListCategorieTemplateVariable(ByVal dropdownList As DropDownList)
            With dropdownList
                Sql = "Select * from TemplateVariablesCategorie Order by NomeCategoria asc;"
                db.OpenConn(Sql)
                myReader = db.ExecuteReader()
                .Items.Clear()

                Dim newListItem As New ListItem()
                newListItem.Text = Selezionare
                newListItem.Value = idSelezioneNulla
                .Items.Add(newListItem)

                While myReader.Read
                    newListItem = New ListItem()
                    newListItem.Text = myReader("NomeCategoria")
                    newListItem.Value = myReader("idCategoria")
                    .Items.Add(newListItem)
                End While

                .DataBind()

                myReader.Close()
                db.CloseConn()
            End With
        End Sub

        Public Sub LoadListTemplateVariableTypes(ByVal dropdownList As DropDownList)
            With dropdownList
                .Items.Clear()

                With cmsTemplateVariablesTypes

                    Dim newListItem As New ListItem()
                    newListItem.Text = .Date
                    newListItem.Value = .DateID
                    dropdownList.Items.Add(newListItem)

                    newListItem = New ListItem()
                    newListItem.Text = .Image
                    newListItem.Value = .ImageID
                    dropdownList.Items.Add(newListItem)

                    newListItem = New ListItem()
                    newListItem.Text = .Link
                    newListItem.Value = .LinkID
                    dropdownList.Items.Add(newListItem)

                    newListItem = New ListItem()
                    newListItem.Text = .Number
                    newListItem.Value = .NumberID
                    dropdownList.Items.Add(newListItem)

                    newListItem = New ListItem()
                    newListItem.Text = .Text
                    newListItem.Value = .TextID
                    dropdownList.Items.Add(newListItem)

                    newListItem = New ListItem()
                    newListItem.Text = .TextArea
                    newListItem.Value = .TextAreaID
                    dropdownList.Items.Add(newListItem)

                    newListItem = New ListItem()
                    newListItem.Text = .TextAreaEditor
                    newListItem.Value = .TextAreaEditorID
                    dropdownList.Items.Add(newListItem)

                    newListItem = New ListItem()
                    newListItem.Text = .Video
                    newListItem.Value = .VideoID
                    dropdownList.Items.Add(newListItem)

                End With

                .DataBind()
            End With
        End Sub

        Public Sub LoadListChunks(ByVal dropdownList As DropDownList, ByVal idCategoria As Long)
            With dropdownList
                Sql = "SELECT Chunks.idVariabile, Chunks.NomeVariabile, ChunkCategorie.NomeCategoria FROM Chunks INNER JOIN ChunkCategorie ON Chunks.idCategoria = ChunkCategorie.idCategoria Where ChunkCategorie.idCategoria = " & idCategoria & " Order By NomeCategoria, NomeVariabile"
                db.OpenConn(Sql)
                myReader = db.ExecuteReader()
                .Items.Clear()

                Dim newListItem As New ListItem()
                newListItem.Text = Selezionare
                newListItem.Value = idSelezioneNulla
                .Items.Add(newListItem)

                While myReader.Read
                    newListItem = New ListItem()
                    newListItem.Text = myReader("NomeCategoria") & " -> " & myReader("NomeVariabile")
                    newListItem.Value = myReader("idVariabile")
                    .Items.Add(newListItem)
                End While

                .DataBind()

                myReader.Close()
                db.CloseConn()
            End With
        End Sub

        Public Sub LoadListTVs(ByVal dropdownList As DropDownList, ByVal idCategoria As Long)
            With dropdownList
                Sql = "SELECT TemplateVariablesList.idTV, TemplateVariablesList.Name, TemplateVariablesCategorie.NomeCategoria FROM TemplateVariablesList INNER JOIN TemplateVariablesCategorie ON TemplateVariablesList.idTVCategoria = TemplateVariablesCategorie.idCategoria Where TemplateVariablesCategorie.idCategoria = " & idCategoria & " Order By NomeCategoria, Name"
                db.OpenConn(Sql)
                myReader = db.ExecuteReader()
                .Items.Clear()

                Dim newListItem As New ListItem()
                newListItem.Text = Selezionare
                newListItem.Value = idSelezioneNulla
                .Items.Add(newListItem)

                While myReader.Read
                    newListItem = New ListItem()
                    newListItem.Text = myReader("NomeCategoria") & " -> " & myReader("Name")
                    newListItem.Value = myReader("idTV")
                    .Items.Add(newListItem)
                End While

                .DataBind()

                myReader.Close()
                db.CloseConn()
            End With
        End Sub


        Public Sub LoadListLingue(ByVal dropdownList As DropDownList)
            With dropdownList

                .Items.Clear()

                Dim ci As CultureInfo

                For Each ci In CultureInfo.GetCultures(CultureTypes.NeutralCultures)
                    Dim item As New ListItem
                    item.Text = ci.DisplayName & " [" & ci.TwoLetterISOLanguageName & "] >> " & ci.NativeName
                    item.Value = ci.TwoLetterISOLanguageName
                    .Items.Add(item)
                Next ci

            End With
        End Sub

        Public Sub LoadListPagine(ByVal dropdownList As DropDownList, ByVal TipoDiPagine As Long)
            With dropdownList
                If TipoDiPagine <> cmsTipiDiPagine.Tutte Then
                    Sql = "SELECT Pagine.codPagina, Pagine.Titolo FROM Pagine WHERE Tipo = " & TipoDiPagine & " Order By Titolo;"
                Else
                    Sql = "SELECT Pagine.codPagina, Pagine.Titolo FROM Pagine WHERE Tipo > 0 Order By Titolo;"
                End If

                db.OpenConn(Sql)
                myReader = db.ExecuteReader()
                .Items.Clear()

                While myReader.Read
                    Dim newListItem As New ListItem()
                    newListItem.Text = db.CheckDbNull(myReader("Titolo"))
                    newListItem.Value = myReader("codPagina")
                    .Items.Add(newListItem)
                End While

                .DataBind()

                myReader.Close()
                db.CloseConn()
            End With
        End Sub

        Public Sub LoadListPagineConID(ByVal dropdownList As DropDownList, ByVal TipoDiPagine As Long)
            With dropdownList
                If TipoDiPagine = cmsTipiDiPagine.DettaglioGalleriaFotografica Then
                    Sql = "SELECT Pagine.idPagina, Pagine.codPagina, Pagine.Titolo FROM Pagine WHERE Tipo = " & TipoDiPagine & " Order By Titolo;"
                Else
                    Sql = "SELECT Pagine.idPagina, Pagine.codPagina, Pagine.Titolo FROM Pagine WHERE Tipo > 0 Order By Titolo;"
                End If

                db.OpenConn(Sql)
                myReader = db.ExecuteReader()
                .Items.Clear()

                While myReader.Read
                    Dim newListItem As New ListItem()
                    newListItem.Text = db.CheckDbNull(myReader("Titolo"))
                    newListItem.Value = myReader("idPagina")
                    .Items.Add(newListItem)
                End While

                .DataBind()

                myReader.Close()
                db.CloseConn()
            End With
        End Sub


        Public Sub LoadListVociDiMenu(ByVal dropdownList As DropDownList)
            With dropdownList
                Sql = "SELECT Menu.idVoce, Menu.codPagina, Menu.codPaginaMadre, Menu.DescrizioneBreveNelMenu, Menu.ProfonditaLivello, Menu.ordine FROM Pagine INNER JOIN Menu ON Pagine.codPagina = Menu.codPagina Order By Menu.ProfonditaLivello;"
                db.OpenConn(Sql)
                myReader = db.ExecuteReader()
                .Items.Clear()

                While myReader.Read
                    Dim newListItem As New ListItem()
                    newListItem.Text = myReader("DescrizioneBreveNelMenu")
                    newListItem.Value = myReader("idVoce")
                    .Items.Add(newListItem)
                End While

                .DataBind()

                myReader.Close()
                db.CloseConn()
            End With
        End Sub

        Public Sub LoadListIntestazioniPagine(ByVal dropdownList As DropDownList, ByVal TipoDiPagine As Long)
            With dropdownList
                If TipoDiPagine <> cmsTipiDiPagine.Tutte Then
                    Sql = "SELECT Pagine.idPagina, Pagine.Titolo FROM Pagine WHERE Tipo = " & TipoDiPagine & " Order By Pagine.Titolo;"
                Else
                    Sql = "SELECT Pagine.idPagina, Pagine.Titolo FROM Pagine WHERE Tipo > 0 Order By Pagine.Titolo;"
                End If
                db.OpenConn(Sql)
                myReader = db.ExecuteReader()
                .Items.Clear()

                Dim newListItem As New ListItem()
                newListItem.Text = Selezionare
                newListItem.Value = idSelezioneNulla
                .Items.Add(newListItem)

                While myReader.Read
                    newListItem = New ListItem()
                    newListItem.Text = myReader("Titolo")
                    newListItem.Value = myReader("idPagina")
                    .Items.Add(newListItem)
                End While

                .DataBind()

                .SelectedIndex = 0

                myReader.Close()
                db.CloseConn()
            End With
        End Sub

        Public Function ReadTestoHeaderFromIdPagina(ByVal idPagina As Long) As String
            Dim TestoHeader As String = ""

            db.OpenConn("Select TestoHeader from Pagine WHERE idPagina = " & idPagina & ";")
            myReader = db.ExecuteReader
            While myReader.Read
                TestoHeader = IIf(IsDBNull(myReader("TestoHeader")), "", myReader("TestoHeader"))
            End While
            myReader.Close()
            db.CloseConn()

            Return TestoHeader
        End Function


        Public Function PrintWarning(ByVal MessaggioDiAvviso As String) As String
            Return "<div class=""jnotify-container""><div class=""jnotify-notification jnotify-notification-warning""><div class=""jnotify-background""></div><div class=""jnotify-message""><div>" & MessaggioDiAvviso & "</div></div></div></div>"
        End Function

        Public Function PrintError(ByVal MessaggioDiErrore As String) As String
            Return "<div class=""jnotify-container""><div class=""jnotify-notification jnotify-notification-error""><div class=""jnotify-background""></div><div class=""jnotify-message""><div>" & MessaggioDiErrore & "</div></div></div></div>"
        End Function

        Public Function PrintOK(ByVal Messaggio As String) As String
            Return "<div class=""jnotify-container""><div class=""jnotify-notification jnotify-notification""><div class=""jnotify-background""></div><div class=""jnotify-message""><div>" & Messaggio & "</div></div></div></div>"
        End Function

        Public Function GalleriaEsiste(ByVal NomeGalleria As String) As Boolean
            Dim ris As Boolean

            Sql = "Select Count(Title) from Gallery Where Title ='" & NomeGalleria & "'"
            db.OpenConn(Sql)
            ris = IIf(db.ExecuteScalar > 0, True, False)
            db.CloseConn()

            Return ris
        End Function

        Public Sub AddNuovaGalleria(ByVal NomeGalleria As String)
            If myDir.DirectoryExist(cmsPaths.PathPublic & cmsLanguage.Lingua & "\" & cmsPaths.PathGallery & NomeGalleria & "\", True) = False Then
                myDir.CreateDirectory(cmsPaths.PathPublic & cmsLanguage.Lingua & "\" & cmsPaths.PathGallery & NomeGalleria & "\", True)
            End If

            Sql = "INSERT INTO Gallery (Title,FolderName) VALUES ('" & NomeGalleria & "','" & NomeGalleria & "')"
            db.OpenConn(Sql)
            db.ExecuteNonQuery()
            db.CloseConn()

            Dim tmpPage As New _cmsPage
            With tmpPage
                .codPagina = -1
                .DataInserimento = Now
                .DataUltimaModifica = Now
                .filename = "Default.aspx"
                .HTMLCompletoHeadPagina = ""
                .HTMLCompletoPagina = ""
                .idLingua = cmsLanguage.idLingua
                '.idPagina
                '.LivelloVisibilita()
                .MetaDescription = "Galleria Fotografica: " & NomeGalleria
                .TitoloH1 = NomeGalleria.Replace(" ", ", ")
                .NuovaPagina = True
                'TODO
                '.Testo = "[jcms:h1][jcms:MenuGallery]<div id=""footer-navigation"">[jcms:Menu]</div>"
                '.TestoHeader = ""
                .Tipo = cmsTipiDiPagine.DettaglioGalleriaFotografica
                .Titolo = NomeGalleria
            End With

            Dim tmpCodPagina As Long
            'TODO
            'tmpCodPagina = SalvaPagina(tmpPage)

            Dim tmpVoceMenu As New _cmsVoceDiMenu
            With tmpVoceMenu
                .codPagina = tmpCodPagina
                .codPaginaMadre = -1
                .DescrizioneBreveNelMenu = NomeGalleria
                .folderpath = NomeGalleria
                .idLingua = -1
                .idVoce = -1
                .NuovaPagina = True
                .ordine = -1
                .ProfonditaLivello = -1
            End With

            SalvaVoceMenuPerGallery(tmpVoceMenu)
        End Sub


        Public Function GetThumbImageGalleryPathFromIdGallery(ByVal idGallery As Long, ByVal idImage As Long) As String
            Dim FolderName As String = ""

            db.OpenConn("SELECT * FROM Gallery INNER JOIN Images ON Gallery.id = Images.idGallery WHERE Images.idGallery = " & idGallery & " AND Images.id = " & idImage & ";")
            myReader = db.ExecuteReader
            While myReader.Read
                FolderName = myReader("FolderName")
            End While
            myReader.Close()
            db.CloseConn()

            Return cmsPaths.PathPublic & cmsLanguage.Lingua & "\" & cmsPaths.PathGallery & FolderName & "\thumb" & idImage.ToString & ".jpeg"
        End Function

        Public Function GetImageGallery(ByVal idGallery As Long, ByVal idImage As Long) As _cms_Gallery_Image
            Dim tmpIm As New _cms_Gallery_Image

            db.OpenConn("SELECT * FROM Gallery INNER JOIN Images ON Gallery.id = Images.idGallery WHERE Images.idGallery = " & idGallery & " AND Images.id = " & idImage & ";")
            myReader = db.ExecuteReader

            With tmpIm
                While myReader.Read
                    .id = myReader("Images.id")
                    .idGallery = myReader("idGallery")
                    .ImageAlt = db.CheckDbNull(myReader("ImageAlt"))
                    .ImageTitle = db.CheckDbNull(myReader("ImageTitle"))
                    .InsertionDate = myReader("InsertionDate")
                    .Orizzontal = myReader("Orizzontal")
                    .Posizione = myReader("Posizione")
                End While
            End With

            myReader.Close()
            db.CloseConn()

            Return tmpIm
        End Function

        Public Function GetImageInPagina(ByVal idImmagine As Long) As _cms_Immagine
            Dim tmpIm As New _cms_Immagine

            db.OpenConn("SELECT * FROM ImmaginiPagine Where IdImmagine = " & idImmagine)
            myReader = db.ExecuteReader

            With tmpIm
                While myReader.Read
                    .Aclass = db.CheckDbNull(myReader("Aclass"))
                    .ADescrizione = db.CheckDbNull(myReader("ADescrizione"))
                    .Ahref = db.CheckDbNull(myReader("Ahref"))
                    .Aid = db.CheckDbNull(myReader("Aid"))
                    .codPagina = myReader("codPagina")
                    .idImmagine = myReader("idImmagine")
                    .IMGalt = db.CheckDbNull(myReader("IMGalt"))
                    .IMGclass = db.CheckDbNull(myReader("IMGclass"))
                    .IMGsrc = db.CheckDbNull(myReader("IMGsrc"))
                    .IMGtitle = db.CheckDbNull(myReader("IMGtitle"))
                    .Orizzontal = myReader("Orizzontal")
                    .SlideDescrizione = db.CheckDbNull(myReader("SlideDescrizione"))
                    .SlideOrder = myReader("SlideOrder")
                    .SlideTitolo = db.CheckDbNull(myReader("SlideTitolo"))
                End While
            End With

            myReader.Close()
            db.CloseConn()

            Return tmpIm
        End Function

        Public Function GalleryFolderNameFromID(ByVal idGallery As Long) As String
            Dim FolderName As String = ""

            db.OpenConn("Select FolderName from Gallery WHERE id = " & idGallery & ";")
            myReader = db.ExecuteReader
            While myReader.Read
                FolderName = myReader("FolderName")
            End While
            myReader.Close()
            db.CloseConn()

            Return FolderName
        End Function

        Public Function GetTemplateFromID(ByVal idTemplate As Long) As _cmsTemplate
            Dim retValue As New _cmsTemplate

            db.OpenConn("Select * from Templates WHERE idTemplate = " & idTemplate & ";")
            myReader = db.ExecuteReader
            While myReader.Read
                With retValue
                    .BodyTagClose = IIf(IsDBNull(myReader("BodyTagClose")), "", myReader("BodyTagClose"))
                    .BodyTagOpen = IIf(IsDBNull(myReader("BodyTagOpen")), "", myReader("BodyTagOpen"))
                    .Content = IIf(IsDBNull(myReader("Contenuto")), "", myReader("Contenuto"))
                    .Header = IIf(IsDBNull(myReader("Header")), "", myReader("Header"))
                    .idTemplate = IIf(IsDBNull(myReader("idTemplate")), "", myReader("idTemplate"))
                    .Nome = IIf(IsDBNull(myReader("Nome")), "", myReader("Nome"))
                End With
            End While
            myReader.Close()
            db.CloseConn()

            Return retValue
        End Function

        Public Function CreateLiTVList(ByVal idTemplate As Long) As String
            Dim retValue As String = ""

            db.OpenConn("SELECT TemplateVariablesList.Name, TemplateVariablesList.Caption, TemplateVariablesInTemplate.idTemplateVariablesInTemplate FROM TemplateVariablesInTemplate INNER JOIN TemplateVariablesList ON TemplateVariablesInTemplate.idTemplateVariablesList = TemplateVariablesList.idTV WHERE TemplateVariablesInTemplate.idTemplate = " & idTemplate & " Order By TemplateVariablesInTemplate.TVOrderInTemplate;")
            myReader = db.ExecuteReader
            While myReader.Read
                retValue &= "<li id=""" & myReader("idTemplateVariablesInTemplate") & """><div>" & IIf(IsDBNull(myReader("Name")), "", myReader("Name")) & " - " & myReader("Caption") & "</div></li>" & vbCrLf
            End While
            myReader.Close()
            db.CloseConn()

            Return retValue
        End Function

        Public Function GetChunkFromID(ByVal idVariabile As Long) As String
            Dim retValue As String = ""

            db.OpenConn("Select Contenuto from Chunks WHERE idVariabile = " & idVariabile & ";")
            myReader = db.ExecuteReader
            While myReader.Read
                retValue = myReader("Contenuto")
            End While
            myReader.Close()
            db.CloseConn()

            Return retValue
        End Function

        Public Function GetChunkNameFromID(ByVal idVariabile As Long) As String
            Dim retValue As String = ""

            db.OpenConn("Select NomeVariabile from Chunks WHERE idVariabile = " & idVariabile & ";")
            myReader = db.ExecuteReader
            While myReader.Read
                retValue = myReader("NomeVariabile")
            End While
            myReader.Close()
            db.CloseConn()

            Return retValue
        End Function

        Public Sub DeleteGalleria(ByVal idGallery As Long)
            Dim FolderName As String = ""

            FolderName = GalleryFolderNameFromID(idGallery)

            db.OpenConn("Delete * From Gallery WHERE FolderName = '" & FolderName & "'")
            db.ExecuteNonQuery()
            db.CloseConn()

            db.OpenConn("Delete * From Images WHERE idGallery = " & idGallery & ";")
            db.ExecuteNonQuery()
            db.CloseConn()

            Try
                myFile.DeleteAllFilesInFolder(cmsPaths.PathPublic & cmsLanguage.Lingua & "\" & cmsPaths.PathGallery & FolderName & "\")
                myDir.DeleteDirectory(cmsPaths.PathPublic & cmsLanguage.Lingua & "\" & cmsPaths.PathGallery & FolderName & "\", True)
            Catch ex As Exception
                'error...
            End Try
        End Sub

        Public Sub UpdateGalleryImage(ByVal idImage As Long, ByVal ImageTitle As String, ByVal Didascalia As String, ByVal NuovaPosizione As Long)
            db.OpenConn("Update Images Set ImageAlt = '" & Didascalia & "', ImageTitle = '" & ImageTitle & "', InsertionDate = #" & Now & "# WHERE id = " & idImage & ";")
            db.ExecuteNonQuery()
            db.CloseConn()

            SpostaImmagineInGallery(idImage, NuovaPosizione)
        End Sub

        Public Sub DeleteGalleryImage(ByVal FolderName As String, ByVal idImage As Long)

            SpostaImmagineInGallery(idImage, -1)

            db.OpenConn("Delete * From Images WHERE id = " & idImage & ";")
            db.ExecuteNonQuery()
            db.CloseConn()

            Try
                myFile.DeleteFile(cmsPaths.PathPublic & cmsLanguage.Lingua & "\" & cmsPaths.PathGallery & FolderName & "\" & idImage & ".jpg")
                myFile.DeleteFile(cmsPaths.PathPublic & cmsLanguage.Lingua & "\" & cmsPaths.PathGallery & FolderName & "\" & "thumb" & idImage & ".jpg")
                myFile.DeleteFile(cmsPaths.PathPublic & cmsLanguage.Lingua & "\" & cmsPaths.PathGallery & FolderName & "\" & idImage & ".jpeg")
            Catch ex As Exception
                'error...
            End Try
        End Sub

        Public Function UploadImmagineInGallery(ByRef myFileUploaded As FileUpload, ByVal idGallery As Long, ByVal ImageTitle As String, ByVal Didascalia As String, ByVal Lingua As String, ByVal PosizioneImmagine As Long) As String
            Dim imgURL As String = ""
            Dim idImmagine As Long = -1

            If myFileUploaded.HasFile Then
                Dim GalleryFolderName As String
                GalleryFolderName = GalleryFolderNameFromID(idGallery) & "\"
                GalleryFolderName = cmsPaths.PathPublic & Lingua & "\" & cmsPaths.PathGallery & GalleryFolderName

                'Salvo nel db...
                Dim PictName As String = ""

                db.OpenConn("INSERT INTO Images (idGallery,ImageAlt,ImageTitle,InsertionDate,Orizzontal,Posizione) VALUES (" & idGallery & ",'" & Didascalia & "','" & ImageTitle & "',#" & Date.Now.ToShortDateString & "#,TRUE," & PosizioneImmagine & ")")
                db.ExecuteScalar()
                db.CloseConn()

                db.OpenConn("Select id From Images WHERE ImageTitle = '" & ImageTitle & "' AND idGallery = " & idGallery)
                Dim myReader As OleDbDataReader
                myReader = db.ExecuteReader

                While myReader.Read
                    PictName = myReader("id")
                    idImmagine = PictName
                End While

                If myPictManip.CreateThumbnail(myFileUploaded, PictName, "thumb", GalleryFolderName, GalleryFolderName, 156, 610, ImageFormat.Jpeg, True) = True Then
                    'ImageThumb.ImageUrl = Server.MapPath("~\" & GalleryFolderName & "thumb" & PictName & ".Jpeg")
                End If

                imgURL = "~\" & (GalleryFolderName & "thumb" & PictName & ".Jpeg").Replace("\", "/")

                If myPictInf.ImageIsVertical(Current.Server.MapPath("~\" & GalleryFolderName & PictName & ".Jpeg")) = True Then
                    db.OpenConn("UPDATE Images Set Orizzontal = FALSE WHERE idGallery = " & idGallery & " AND id = " & PictName)
                    db.ExecuteNonQuery()
                Else
                    db.OpenConn("UPDATE Images Set Orizzontal = TRUE WHERE idGallery = " & idGallery & " AND id = " & PictName)
                    db.ExecuteNonQuery()
                End If
            End If

            SpostaImmagineInGallery(idImmagine, PosizioneImmagine)

            Return imgURL
        End Function

        Public Function UploadImmagineInGlobal(ByRef myFileUploaded As FileUpload, ByVal Immagine As _cms_Immagine, ByVal Lingua As String) As String
            Dim imgURL As String = ""

            Dim tmpImgSrc As String = ""

            If myFileUploaded.HasFile Then
                Dim FolderName As String
                FolderName = cmsPaths.PathPublic & Lingua & "\" & cmsPaths.PathImagesPages & cmsPaths.PathGlobal

                'Salvo nel db...
                Dim PictName As String = ""

                db.OpenConn("INSERT INTO ImmaginiPagine (codPagina,Aid,Aclass,Ahref,ADescrizione,IMGsrc,IMGalt,IMGtitle,IMGclass,SlideTitolo,SlideDescrizione,SlideOrder) VALUES (" & Immagine.codPagina & ",'" & Immagine.Aid & "','" & Immagine.Aclass & "','" & Immagine.Ahref & "','" & Immagine.ADescrizione & "','" & tmpImgSrc & "','" & Immagine.IMGalt & "','" & Immagine.IMGtitle & "','" & Immagine.IMGclass & "','" & Immagine.SlideTitolo & "','" & Immagine.SlideDescrizione & "'," & Immagine.SlideOrder & ")")
                db.ExecuteScalar()
                db.CloseConn()

                PictName = db.GetLastID("ImmaginiPagine", "IDImmagine")

                If Immagine.IMGsrc = "" Then
                    tmpImgSrc = (FolderName & PictName & ".Jpeg").Replace("\", "/")
                End If

                db.OpenConn("UPDATE ImmaginiPagine Set IMGsrc = '" & tmpImgSrc & "' WHERE IDImmagine = " & PictName)
                db.ExecuteScalar()
                db.CloseConn()

                If Immagine.IMGsrc = "" Then
                    If myPictManip.CreateThumbnail(myFileUploaded, PictName, "thumb", FolderName, FolderName, 156, 610, ImageFormat.Jpeg, True) = True Then
                        'ImageThumb.ImageUrl = Server.MapPath("~\" & GalleryFolderName & "thumb" & PictName & ".Jpeg")
                    End If
                End If

                imgURL = ("~\" & (FolderName & "thumb" & PictName & ".Jpeg")).Replace("\", "/")

                If myPictInf.ImageIsVertical(Current.Server.MapPath("~\" & FolderName & PictName & ".Jpeg")) = True Then
                    db.OpenConn("UPDATE ImmaginiPagine Set Orizzontal = FALSE WHERE IDImmagine = " & PictName)
                    db.ExecuteNonQuery()
                Else
                    db.OpenConn("UPDATE ImmaginiPagine Set Orizzontal = TRUE WHERE IDImmagine = " & PictName)
                    db.ExecuteNonQuery()
                End If
            End If

            Return imgURL
        End Function

        Public Function UploadFile(ByRef myFileUploaded As FileUpload, ByVal Lingua As String, ByVal Directory As String, ByVal NomeFile As String) As String
            Dim retValue As String = ""
            'Quando l'upload del file ha qualche errore
            '"retValue" verrà impostato con il messaggio di errore.

            If myFileUploaded.HasFile Then

                Dim tmpLunghezza As Long
                Dim tmpMime As String
                Dim tmpFileName As String
                Dim tmpEstensione As String

                Directory = myFile.FilterFileName(Directory)

                Dim FolderName As String
                FolderName = cmsPaths.PathPublic & Lingua & "\" & cmsPaths.PathUploadedFiles & Directory & "\"

                tmpLunghezza = myFileUploaded.PostedFile.ContentLength
                tmpMime = myFileUploaded.PostedFile.ContentType
                tmpFileName = myFileUploaded.PostedFile.FileName

                tmpEstensione = myPictInf.GetImageExtensionFromFileName(tmpFileName).Substring(1)

                Dim tmpSaveFile As String
                tmpSaveFile = FolderName

                'Verifico che esista la cartella..
                If myDir.DirectoryExist(FolderName, True) = False Then
                    myDir.CreateDirectory(FolderName, True)
                End If

                tmpSaveFile = (HttpContext.Current.Request.PhysicalApplicationPath & FolderName).Replace("\\", "\")
                tmpSaveFile &= myFile.FilterFileName(NomeFile) & "." & tmpEstensione

                If myFile.FileExists(FolderName.Replace("\\", "\") & myFile.FilterFileName(NomeFile) & "." & tmpEstensione) Then
                    retValue = "Attenzione! un file di nome <strong>" & myFile.FilterFileName(NomeFile) & "." & tmpEstensione & "</strong> è già presente nella cartella, verificare prima di inviare il file."
                    Return retValue
                    Exit Function
                End If

                myFileUploaded.SaveAs(tmpSaveFile)

                db.OpenConn("INSERT INTO Files (NomeFile, Path, Dimensione, Estensione) VALUES ('" & myFile.FilterFileName(NomeFile) & "','" & FolderName & "', " & tmpLunghezza & ",'" & tmpEstensione & "')")
                db.ExecuteNonQuery()
                db.CloseConn()

                retValue = ""
            Else
                retValue = "Non è stato selezionato nessun file."
            End If

            Return retValue
        End Function

        Public Function JertCMS_WriteGalleryThumbs(ByVal idGallery As Long, ByVal Lingua As String) As String
            Dim thumbsHTML As String = ""

            thumbsHTML = "<div class=""gallery"" style=""border-top: none;"">" & vbCrLf

            db.OpenConn("SELECT Gallery.FolderName, Images.id, Images.ImageAlt, Images.ImageTitle, Images.Orizzontal, Images.Posizione FROM Gallery INNER JOIN Images ON Gallery.id = Images.idGallery Where idGallery = " & idGallery & " ORDER By Images.Posizione")
            myReader = db.ExecuteReader

            While myReader.Read
                thumbsHTML &= "<a href=""#"" rel=""gb_pageset[search_sites]""><img class=""" & IIf(myReader("Orizzontal"), "or", "vt") & """ src=""" & (cmsPaths.PathPublic & Lingua & "/" & cmsPaths.PathGallery & myReader("FolderName") & "/thumb" & myReader("id") & ".Jpeg").ToString.Replace("\", "/") & """ alt=""" & myReader("ImageAlt") & """ /><br />" & myReader("ImageTitle") & " - pos:" & myReader("Posizione") & "</a>" & vbCrLf
            End While
            myReader.Close()
            db.CloseConn()

            thumbsHTML &= "<div></div></div>" & vbCrLf
            Return thumbsHTML
        End Function

        Public Function JertCMS_WriteImagesThumbs(ByVal CodPagina As Long, ByVal idLingua As Long, Optional ByVal ForzaLarghezzaInThumbs As Boolean = True, Optional ByVal ShowOnlySlideShow As Boolean = False) As String
            Dim tmpSlideShowSQL As String = " AND SlideOrder = 0 "
            Dim tmpOrderBy As String = ""

            If ShowOnlySlideShow Then
                tmpSlideShowSQL = " AND SlideOrder > 0 "
                tmpOrderBy = " Order By SlideOrder "
            End If


            Dim Size As String = ""
            If ForzaLarghezzaInThumbs Then
                Size = " Width=""100%"" Height=""100%"" "
            End If

            Dim thumbsHTML As String = ""

            thumbsHTML = "<div class=""gallery"" style=""border-top: none;"">" & vbCrLf

            db.OpenConn("SELECT ImmaginiPagine.* FROM ImmaginiPagine INNER JOIN Pagine ON ImmaginiPagine.codPagina = Pagine.codPagina WHERE ImmaginiPagine.CodPagina = " & CodPagina & " " & tmpSlideShowSQL & " AND Pagine.idLingua = " & idLingua & " " & tmpOrderBy)
            myReader = db.ExecuteReader

            While myReader.Read
                If ShowOnlySlideShow Then
                    thumbsHTML &= "<a href=""#"" rel=""gb_pageset[search_sites]""><img src=""" & (myReader("IMGSrc")).ToString.Replace("\", "/") & """ alt=""" & myReader("IMGAlt") & """ title=""" & myReader("IMGTitle") & """  class=""" & myReader("IMGClass") & """ " & Size & "/><br />[jcms:slideshow]</a>" & vbCrLf
                Else
                    thumbsHTML &= "<a href=""#"" rel=""gb_pageset[search_sites]""><img src=""" & (myReader("IMGSrc")).ToString.Replace("\", "/") & """ alt=""" & myReader("IMGAlt") & """ title=""" & myReader("IMGTitle") & """  class=""" & myReader("IMGClass") & """ " & Size & "/><br />[jcms:img " & myReader("IDImmagine") & "]</a>" & vbCrLf
                End If
            End While
            myReader.Close()
            db.CloseConn()

            thumbsHTML &= "<div></div></div>" & vbCrLf
            Return thumbsHTML
        End Function

        Public Function JertCMS_WriteAdministrationTree(Optional ByRef tmpDbCommand As OleDbCommand = Nothing, Optional ByRef tmpDbConnection As OleDbConnection = Nothing) As _cms_AdminAdministratorMenuTree
            Dim retValue As New _cms_AdminAdministratorMenuTree
            Dim AdminId As _cms_IdOfAdministratorMenuTree = cms_IdOfAdministratorMenuTree

            retValue.HTMLMenu &= "<ul id=""browser-admin"" class=""filetree"">" & vbCrLf
            retValue.HTMLMenu &= "  <li class=""closed"" id=""admin" & AdminId.TemplateID & """><span class=""folder""><a href=""#"">" & AdminId.TemplateName & "</a></span>                 " & GenerateHTMLMenuTemplateList(retValue.jQueryFunctions, retValue.HTMLContextMenu, tmpDbCommand, tmpDbConnection) & "</li>" & vbCrLf
            retValue.HTMLMenu &= "  <li class=""closed"" id=""admin" & AdminId.ChunksID & """><span class=""folder""><a href=""#"">" & AdminId.ChunksName & "</a></span>                     " & GenerateHTMLMenuChunksList(retValue.jQueryFunctions, retValue.HTMLContextMenu, tmpDbCommand, tmpDbConnection) & "</li>" & vbCrLf
            retValue.HTMLMenu &= "  <li class=""closed"" id=""admin" & AdminId.TemplateVariablesID & """><span class=""folder""><a href=""#"">" & AdminId.TemplateVariableName & "</a></span>" & GenerateHTMLMenuTemplateVariablesList(retValue.jQueryFunctions, retValue.HTMLContextMenu, tmpDbCommand, tmpDbConnection) & "</li>" & vbCrLf
            retValue.HTMLMenu &= "</ul>" & vbCrLf

            retValue.jQueryFunctions &= "<script type=""text/javascript"">$(document).ready( function() {" & vbCrLf
            retValue.jQueryFunctions &= "  $(""#admin" & AdminId.TemplateID & """).contextMenu({menu: 'menu" & AdminId.TemplateID & "'},{menu: 'menu" & AdminId.TemplateID & "'});" & vbCrLf
            retValue.jQueryFunctions &= "  $(""#admin" & AdminId.ChunksID & """).contextMenu({menu: 'menu" & AdminId.ChunksID & "'},{menu: 'menu" & AdminId.ChunksID & "'});" & vbCrLf
            retValue.jQueryFunctions &= "  $(""#admin" & AdminId.TemplateVariablesID & """).contextMenu({menu: 'menu" & AdminId.TemplateVariablesID & "'},{menu: 'menu" & AdminId.TemplateVariablesID & "'});" & vbCrLf
            retValue.jQueryFunctions &= "});</script>" & vbCrLf

            '--> Template
            retValue.HTMLContextMenu &= "<ul id=""menu" & AdminId.TemplateID & """ class=""contextMenu"">" & vbCrLf
            retValue.HTMLContextMenu &= "<li class=""current""><span>" & AdminId.TemplateName & "</span></li>" & vbCrLf
            retValue.HTMLContextMenu &= "<li class=""edit separator""><a href=""AddTemplate.aspx"">" & GetGlobalResourceObject("Admin", "adminMenuAggiungiTemplate") & "</a></li>" & vbCrLf
            retValue.HTMLContextMenu &= "<li class=""cut""><a href=""EditTemplate.aspx"">" & GetGlobalResourceObject("Admin", "adminMenuModificaTemplate") & "</a></li>" & vbCrLf
            retValue.HTMLContextMenu &= "<li class=""copy""><a href=""DeleteTemplate.aspx"">" & GetGlobalResourceObject("Admin", "adminMenuEliminaTemplate") & "</a></li>" & vbCrLf
            retValue.HTMLContextMenu &= "</ul>" & vbCrLf

            '--> Chunks
            retValue.HTMLContextMenu &= "<ul id=""menu" & AdminId.ChunksID & """ class=""contextMenu"">" & vbCrLf
            retValue.HTMLContextMenu &= "<li class=""current""><span>" & AdminId.ChunksName & "</span></li>" & vbCrLf
            retValue.HTMLContextMenu &= "<li class=""edit separator""><a href=""AddChunkCategory.aspx"">" & GetGlobalResourceObject("Admin", "adminMenuAggiungiChunkCategory") & "</a></li>" & vbCrLf
            retValue.HTMLContextMenu &= "<li class=""edit separator""><a href=""AddChunk.aspx"">" & GetGlobalResourceObject("Admin", "adminMenuAggiungiChunk") & "</a></li>" & vbCrLf
            'retValue.HTMLContextMenu &= "<li class=""cut""><a href=""EditChunk.aspx"">" & GetGlobalResourceObject("Admin", "adminMenuModificaChunk") & "</a></li>" & vbCrLf
            'retValue.HTMLContextMenu &= "<li class=""copy""><a href=""DeleteChunk.aspx"">" & GetGlobalResourceObject("Admin", "adminMenuEliminaChunk") & "</a></li>" & vbCrLf
            retValue.HTMLContextMenu &= "</ul>" & vbCrLf

            '--> Template Variables
            retValue.HTMLContextMenu &= "<ul id=""menu" & AdminId.TemplateVariablesID & """ class=""contextMenu"">" & vbCrLf
            retValue.HTMLContextMenu &= "<li class=""current""><span>" & AdminId.TemplateVariableName & "</span></li>" & vbCrLf
            retValue.HTMLContextMenu &= "<li class=""edit separator""><a href=""AddTVCategory.aspx"">" & GetGlobalResourceObject("Admin", "adminMenuAggiungiTVCategory") & "</a></li>" & vbCrLf
            retValue.HTMLContextMenu &= "<li class=""edit separator""><a href=""AddTemplateVariable.aspx"">" & GetGlobalResourceObject("Admin", "adminMenuAggiungiTemplateVariable") & "</a></li>" & vbCrLf
            'retValue.HTMLContextMenu &= "<li class=""cut""><a href=""EditTemplateVariable.aspx"">" & GetGlobalResourceObject("Admin", "adminMenuModificaTemplateVariable") & "</a></li>" & vbCrLf
            'retValue.HTMLContextMenu &= "<li class=""copy""><a href=""DeleteTemplateVariable.aspx"">" & GetGlobalResourceObject("Admin", "adminMenuEliminaTemplateVariable") & "</a></li>" & vbCrLf
            retValue.HTMLContextMenu &= "</ul>" & vbCrLf

            Return retValue
        End Function

        Public Function JertCMS_WriteAdminWebSiteTree(Optional ByRef tmpDbCommand As OleDbCommand = Nothing, Optional ByRef tmpDbConnection As OleDbConnection = Nothing) As _cms_AdminMenuTree
            CheckAndBuildFilesFolders()

            Dim retValue As New _cms_AdminMenuTree

            Dim arrDirectory As ArrayList
            Dim foundDirectory As DirectoryInfo

            'Cerco i nomi delle lingue...
            arrDirectory = myDir.GetSubDirectories(cmsPaths.PathPublic, True)

            retValue.HTMLMenu &= "<ul id=""browser"" class=""filetree"">" & vbCrLf
            retValue.jQueryFunctions = "<script type=""text/javascript"">$(document).ready( function() {"

            Dim MaxMenuDepth As Long = 0

            Dim LanguageFolderFound As Boolean = False

            If arrDirectory.Count > 0 Then
                retValue.isNewTree = False

                For Each foundDirectory In arrDirectory
                    If foundDirectory.Name <> cmsPaths.PathVideos.Replace("\", "") And foundDirectory.Name <> cmsPaths.PathImagesPages.Replace("\", "") And foundDirectory.Name <> cmsPaths.PathFiles.Replace("\", "") And foundDirectory.Name <> cmsPaths.PathCache.Replace("\", "") Then
                        LanguageFolderFound = True

                        retValue.HTMLMenu &= "<li id=""" & foundDirectory.Name & """><span class=""folder""><a href=""#"">" & foundDirectory.Name & "</a></span>" & vbCrLf

                        Dim tmpPage As _cmsPage = GetHomePageByLanguageName(foundDirectory.Name, tmpDbCommand, tmpDbConnection)
                        If HomePageExist(foundDirectory.Name, tmpDbCommand, tmpDbConnection) = True Then

                            retValue.HTMLContextMenu &= JertCMS_WriteAdminContextMenuHome(tmpPage.idPagina, foundDirectory.Name, tmpPage.codPagina, tmpPage.idTemplate, tmpPage.idVoce)

                            retValue.HTMLMenu &= "<ul><li id=""id" & tmpPage.idPagina & """><span class=""file""><a href=""AddPage.aspx?" & HttpContext.Current.Session("tmpSessionQueryEditHome" & foundDirectory.Name) & """>" & tmpPage.VoceDiMenu & " (Home) <span class=""treeview-id"">(" & tmpPage.idPagina & ")</span></a></span></li>"

                            MaxMenuDepth = GetMaxMenuDepth(foundDirectory.Name, tmpDbCommand, tmpDbConnection)
                            JertCMS_WriteAdminTreeLanguage(foundDirectory.Name, retValue.HTMLMenu, retValue.HTMLContextMenu, retValue.jQueryFunctions, 1, MaxMenuDepth, tmpPage.codPagina, tmpDbCommand, tmpDbConnection)
                            retValue.HTMLMenu &= "</ul>" & vbCrLf

                            retValue.jQueryFunctions &= "$(""#id" & tmpPage.idPagina & """).contextMenu({menu: 'menu" & tmpPage.idPagina & "'},{menu: 'menu" & tmpPage.idPagina & "'});" & vbCrLf
                        End If

                        retValue.HTMLContextMenu &= JertCMS_WriteAdminContextMenuLanguage(foundDirectory.Name, tmpPage)
                        retValue.jQueryFunctions &= "$(""#" & foundDirectory.Name & """).contextMenu({menu: 'menu" & foundDirectory.Name & "'},{menu: 'menu" & foundDirectory.Name & "'});" & vbCrLf
                        retValue.HTMLMenu &= "</li>" & vbCrLf
                    End If
                Next

                If LanguageFolderFound = False Then
                    retValue = AddNewLanguageTree(cmsLanguage.Lingua, tmpDbCommand, tmpDbConnection)
                    retValue.isNewTree = True
                End If

            Else
                'Non ci sono lingue... creo la struttura di base...
                'Utilizzo la lingua di navigazione dell'utente
                retValue = AddNewLanguageTree(cmsLanguage.Lingua, tmpDbCommand, tmpDbConnection)
                retValue.isNewTree = True
            End If

            retValue.HTMLMenu &= "</ul>"
            retValue.jQueryFunctions &= "});</script>"

            Return retValue
        End Function

        Public Function AddNewLanguageTree(ByVal Lingua As String, Optional ByRef tmpDbCommand As OleDbCommand = Nothing, Optional ByRef tmpDbConnection As OleDbConnection = Nothing) As _cms_AdminMenuTree
            Dim retValue As New _cms_AdminMenuTree

            myDir.CreateDirectory(cmsPaths.PathPublic & Lingua, True)

            myDir.CreateDirectory(cmsPaths.PathPublic & Lingua & "\" & cmsPaths.PathUploadedFiles, True)
            myDir.CreateDirectory(cmsPaths.PathPublic & Lingua & "\" & cmsPaths.PathGallery, True)
            myDir.CreateDirectory(cmsPaths.PathPublic & Lingua & "\" & cmsPaths.PathImagesPages, True)

            myDir.CreateDirectory(cmsPaths.PathPublic & Lingua & "\" & cmsPaths.PathImagesPages & cmsPaths.PathGlobal, True)


            retValue.HTMLMenu &= "<li id=""" & Lingua & """><span class=""folder""><a href=""#"">" & Lingua & "</a></span>" & vbCrLf

            Dim tmpPage As New _cmsPage
            tmpPage.idPagina = -100

            retValue.HTMLContextMenu &= JertCMS_WriteAdminContextMenuLanguage(Lingua, tmpPage, tmpDbCommand, tmpDbConnection)
            retValue.HTMLMenu &= "</li>" & vbCrLf

            Return retValue
        End Function

        Public Sub RemoveLanguageTree(ByVal Lingua As String)
            'Attenzione.. verificare prima che le directory non contengano file

            myDir.DeleteDirectory(cmsPaths.PathPublic & Lingua & "\" & cmsPaths.PathImagesPages & cmsPaths.PathGlobal, True)

            myDir.DeleteDirectory(cmsPaths.PathPublic & Lingua & "\" & cmsPaths.PathUploadedFiles, True)
            myDir.DeleteDirectory(cmsPaths.PathPublic & Lingua & "\" & cmsPaths.PathGallery, True)
            myDir.DeleteDirectory(cmsPaths.PathPublic & Lingua & "\" & cmsPaths.PathImagesPages, True)

            myDir.DeleteDirectory(cmsPaths.PathPublic & Lingua, True)

        End Sub

        Public Function JertCMS_WriteAdminContextMenuLanguage(ByVal Language As String, ByVal tmpPage As _cmsPage, Optional ByRef tmpDbCommand As OleDbCommand = Nothing, Optional ByRef tmpDbConnection As OleDbConnection = Nothing) As String
            Dim retValue As String = ""

            Dim Menu As _cms_MenuQueryStrings = cmsMenuQueryStrings
            Dim Param As _cms_MenuParameters = cmsMenuParameters

            retValue &= "<ul id=""menu" & Language & """ class=""contextMenu"">" & vbCrLf
            retValue &= "<li class=""current""><span>" & GetGlobalResourceObject("Admin", "adminMenuLingua") & ": " & GetLanguageNameFromTwoDigits(Language) & "</span></li>" & vbCrLf

            'Verifico se esiste la home page... è la prima pagina da creare...
            If tmpPage.idPagina <> -100 Then
                If HomePageExist(Language, tmpDbCommand, tmpDbConnection) = True Then
                    retValue &= "<li class=""edit separator""><a href=""AddPage.aspx?" & Menu.MenuLang & "=" & Language & Param.queryAND & Menu.Action & "=" & Param.ActionAdd & Param.queryAND & Menu.PageType & "=" & Param.PageTypeGeneric & Param.queryAND & Menu.idPage & "=" & tmpPage.idPagina & Param.queryAND & Menu.codPage & "=" & tmpPage.codPagina & Param.queryAND & Menu.idTemplate & "=" & tmpPage.idTemplate & Param.queryAND & Menu.idVoce & "=" & tmpPage.idVoce & """>Crea Nuova PAGINA</a></li>" & vbCrLf
                    retValue &= "<li class=""cut""><a href=""AddPage.aspx?" & Menu.MenuLang & "=" & Language & Param.queryAND & Menu.Action & "=" & Param.ActionEdit & Param.queryAND & Menu.PageType & "=" & Param.PageTypeHome & Param.queryAND & Menu.idPage & "=" & tmpPage.idPagina & Param.queryAND & Menu.codPage & "=" & tmpPage.codPagina & Param.queryAND & Menu.idTemplate & "=" & tmpPage.idTemplate & Param.queryAND & Menu.idVoce & "=" & tmpPage.idVoce & """>" & GetGlobalResourceObject("Admin", "adminMenuModificaHomePage") & "</a></li>" & vbCrLf
                Else
                    retValue &= "<li class=""edit separator""><a href=""AddPage.aspx?" & Menu.MenuLang & "=" & Language & Param.queryAND & Menu.Action & "=" & Param.ActionAdd & Param.queryAND & Menu.PageType & "=" & Param.PageTypeHome & Param.queryAND & Menu.idPage & "=" & tmpPage.idPagina & Param.queryAND & Menu.codPage & "=" & tmpPage.codPagina & Param.queryAND & Menu.idTemplate & "=" & tmpPage.idTemplate & Param.queryAND & Menu.idVoce & "=" & tmpPage.idVoce & """>" & GetGlobalResourceObject("Admin", "adminMenuAggiungiHomePage") & "</a></li>" & vbCrLf
                End If
            End If
            'TODO Pagine generiche....
            '                'GetGlobalResourceObject("Admin", "adminMenuAggiungiPagina")

            retValue &= "<li class=""edit separator""><a href=""AddLanguage.aspx?" & Menu.MenuLang & "=" & Language & """>" & GetGlobalResourceObject("Admin", "adminMenuAggiungiLingua") & "</a></li>" & vbCrLf
            retValue &= "</ul>" & vbCrLf

            Return retValue
        End Function

        Public Function JertCMS_WriteAdminContextMenuHome(ByVal idPage As String, ByVal Language As String, ByVal codPage As Long, ByVal idTemplate As Long, ByVal idVoceDiMenu As Long) As String
            Dim retValue As String = ""

            Dim Menu As _cms_MenuQueryStrings = cmsMenuQueryStrings
            Dim Param As _cms_MenuParameters = cmsMenuParameters

            retValue &= "<ul id=""menu" & idPage & """ class=""contextMenu"">" & vbCrLf
            retValue &= "<li class=""current""><span>Home Page</span></li>" & vbCrLf

            Dim tmpSessionQueryEditHome As String
            tmpSessionQueryEditHome = Menu.MenuLang & "=" & Language & Param.queryAND & Menu.Action & "=" & Param.ActionEdit & Param.queryAND & Menu.PageType & "=" & Param.PageTypeHome & Param.queryAND & Menu.idPage & "=" & idPage & Param.queryAND & Menu.codPage & "=" & codPage & Param.queryAND & Menu.idTemplate & "=" & idTemplate & Param.queryAND & Menu.idVoce & "=" & idVoceDiMenu
            HttpContext.Current.Session("tmpSessionQueryEditHome" & Language) = tmpSessionQueryEditHome

            retValue &= "<li class=""cut""><a href=""AddPage.aspx?" & tmpSessionQueryEditHome & """>" & GetGlobalResourceObject("Admin", "adminMenuModificaHomePage") & "</a></li>" & vbCrLf
            retValue &= "<li class=""cut""><a href=""" & "http://" & HttpContext.Current.Session("SiteName") & "?lang=" & Language & """ target=""_blank"">" & GetGlobalResourceObject("Admin", "adminOpenInBrowser") & "</a></li>" & vbCrLf

            retValue &= "</ul>" & vbCrLf

            Return retValue
        End Function

        Public Function JertCMS_WriteAdminContextMenuGenericPage(ByVal QueryEditPage As String, ByVal QueryAddPage As String, ByVal DescrizioneVoce As String, ByVal idVoceMenu As String, ByVal Language As String, ByVal codPage As Long, ByVal idTemplate As Long, ByVal idVoceDiMenu As Long, ByVal PathPagina As String) As String
            Dim retValue As String = ""

            Dim Menu As _cms_MenuQueryStrings = cmsMenuQueryStrings
            Dim Param As _cms_MenuParameters = cmsMenuParameters

            retValue &= "<ul id=""menuVoce" & idVoceMenu & """ class=""contextMenu"">" & vbCrLf
            retValue &= "<li class=""current""><span>" & DescrizioneVoce & "</span></li>" & vbCrLf

            'TODO da globalizzare...
            retValue &= "<li class=""edit separator""><a href=""AddPage.aspx?" & QueryAddPage & """>Aggiungi pagina</a></li>" & vbCrLf
            retValue &= "<li class=""cut""><a href=""AddPage.aspx?" & QueryEditPage & """>Modifica pagina</a></li>" & vbCrLf
            retValue &= "<li class=""cut""><a href=""" & "http://" & HttpContext.Current.Session("SiteName") & PathPagina.Replace("\", "/") & """ target=""_blank"">" & GetGlobalResourceObject("Admin", "adminOpenInBrowser") & "</a></li>" & vbCrLf

            'TODO: delete
            'retValue &= "<li class=""edit separator""><a href=""AddPage.aspx?" & QueryString & """>Elimina pagina</a></li>" & vbCrLf

            retValue &= "</ul>" & vbCrLf

            Return retValue
        End Function

        Public Function CreateDragSortjQuery(ByVal FileName As String, ByVal RootSelector As String, ByVal InternalTag As String, ByVal CaptureSelector As String, ByVal AttributeToCapture As String, ByVal PlaceHolderTemplate As String) As String
            Dim retValue As String = ""

            retValue = "<script language=""Javascript"" type=""text/javascript"">" & vbCrLf
            retValue &= "$(document).ready(function () {"
            retValue &= "$(""" & RootSelector & """).dragsort({ dragSelector: """ & InternalTag & """, dragBetween: true, dragEnd: saveOrder, placeHolderTemplate: """ & PlaceHolderTemplate & """ });" & vbCrLf
            retValue &= "function saveOrder() {" & vbCrLf
            retValue &= "var data = $(""" & CaptureSelector & """).map(function() { return $(this).attr(""" & AttributeToCapture & """); }).get();" & vbCrLf
            retValue &= "$.post(""/Admin/CMSjQuery/" & FileName & """, { ids: data } );" & vbCrLf
            retValue &= "};" & vbCrLf
            retValue &= "});" & vbCrLf
            retValue &= "</script>"

            Return retValue
        End Function

        Public Function CreateEditAreaJavascript(ByVal ClientID As String, Optional ByVal DefaultSyntax As String = "html") As String
            Dim retValue As String = ""

            retValue &= "<script language=""Javascript"" type=""text/javascript"">" & vbCrLf
            retValue &= "// initialisation" & vbCrLf
            retValue &= "editAreaLoader.init({" & vbCrLf
            retValue &= "id: """ & ClientID & """	// id of the textarea to transform" & vbCrLf
            retValue &= ",start_highlight: true	// if start with highlight" & vbCrLf
            retValue &= ",allow_resize: ""both""" & vbCrLf
            retValue &= ",font_size: ""11""" & vbCrLf
            retValue &= ",allow_toggle: false" & vbCrLf
            retValue &= ",toolbar: ""search, go_to_line, fullscreen, |, undo, redo, charmap, |, select_font, |, syntax_selection, |, change_smooth_selection, highlight, reset_highlight, |, word_wrap"""
            retValue &= ",syntax_selection_allow: ""css,html,js,php,python,vb,xml,c,cpp,sql,basic,pas,brainfuck""" & vbCrLf
            retValue &= ",word_wrap: true" & vbCrLf
            retValue &= ",plugins: ""charmap""" & vbCrLf
            retValue &= ",charmap_default: ""arrows""" & vbCrLf
            retValue &= ",language: """ & cmsLanguage.Lingua & """" & vbCrLf
            retValue &= ",syntax: """ & DefaultSyntax & """" & vbCrLf
            retValue &= "});" & vbCrLf
            retValue &= "</script>" & vbCrLf

            Return retValue
        End Function

        Public Function CreateTinyJavascript() As String
            Dim retValue As String = ""

            retValue &= "<!-- [Advanced TinyMCE] --> " & vbCrLf
            retValue &= "<script type=""text/javascript""> " & vbCrLf
            retValue &= "	$().ready(function() {" & vbCrLf
            retValue &= "		$('.tiny-advanced textarea').tinymce({" & vbCrLf
            retValue &= "			// Location of TinyMCE script" & vbCrLf
            retValue &= "script_url:  'tinymce/jscripts/tiny_mce/tiny_mce.js'," & vbCrLf
            retValue &= "			// General options" & vbCrLf
            retValue &= "			language : """ & cmsLanguage.Lingua & """," & vbCrLf
            retValue &= "			theme : ""advanced""," & vbCrLf
            retValue &= "			skin : ""o2k7""," & vbCrLf
            retValue &= "			skin_variant : ""silver""," & vbCrLf
            retValue &= "			width : ""100%""," & vbCrLf
            retValue &= "			height: ""450px""," & vbCrLf
            retValue &= "			plugins : ""pagebreak,style,layer,table,advimage,advlink,iespell,inlinepopups,media,searchreplace,print,contextmenu,paste,directionality,fullscreen,noneditable,visualchars,nonbreaking,xhtmlxtras,template,advlist""," & vbCrLf
            retValue &= "			// Theme options" & vbCrLf
            retValue &= "			theme_advanced_buttons1 : ""newdocument,|,bold,italic,underline,forecolor,backcolor,|,justifyleft,justifycenter,justifyright,justifyfull,|,bullist,numlist,|,link,unlink,anchor,image,iespell,media,|,pastetext,pasteword,code,template,|,fullscreen""," & vbCrLf
            retValue &= "			theme_advanced_buttons2 : ""search,|,strikethrough,outdent,indent,blockquote,|,sub,sup,|,styleselect,formatselect,fontselect,fontsizeselect""," & vbCrLf
            retValue &= "			theme_advanced_buttons3 : ""tablecontrols,|,removeformat,visualaid,|,undo,redo,|,print,|,ltr,rtl,|,styleprops""," & vbCrLf
            retValue &= "			theme_advanced_buttons4 : ""insertlayer,moveforward,movebackward,absolute,|,cite,abbr,acronym,del,ins,attribs,|,visualchars,nonbreaking,pagebreak,charmap""," & vbCrLf
            retValue &= "			theme_advanced_toolbar_location : ""top""," & vbCrLf
            retValue &= "			theme_advanced_toolbar_align : ""left""," & vbCrLf
            retValue &= "			theme_advanced_statusbar_location : ""bottom""," & vbCrLf
            retValue &= "			theme_advanced_resizing : true," & vbCrLf
            retValue &= "			// Example content CSS (should be your site CSS)" & vbCrLf
            retValue &= "			content_css : ""tinymce/css/tinymce.css""" & vbCrLf
            retValue &= "		});" & vbCrLf
            retValue &= "	});" & vbCrLf
            retValue &= "</script> " & vbCrLf
            retValue &= "<!-- [/End Advanced TinyMCE] -->" & vbCrLf

            Return retValue
        End Function

        Public Function HomePageExist(ByVal LanguageName As String, Optional ByRef tmpDbCommand As OleDbCommand = Nothing, Optional ByRef tmpDbConnection As OleDbConnection = Nothing) As Boolean
            Dim retValue As Boolean = False

            Dim idLanguage As Long = GetIdLanguageFromName(LanguageName, tmpDbCommand, tmpDbConnection)

            Sql = "Select Count(*) from Menu Where folderpath = ""\"" AND idLingua = " & idLanguage

            If IsNothing(tmpDbConnection) Then
                db.OpenConn(Sql)
                myReader = db.ExecuteReader()
            Else
                db.OpenConn(Sql, , , True, tmpDbConnection, tmpDbCommand)
                myReader = db.ExecuteReader(True, tmpDbCommand)
            End If

            myReader.Read()
            If Convert.ToInt32(myReader(0)) > 0 Then
                retValue = True
            Else
                retValue = False
            End If

            myReader.Close()
            If IsNothing(tmpDbConnection) Then db.CloseConn()

            Return retValue
        End Function

        Public Function TemplateNameExist(ByVal TemplateName As String) As Boolean
            Dim retValue As Boolean = False

            Sql = "Select Count(*) from Templates Where Nome = """ & TemplateName.Trim & """"
            db.OpenConn(Sql)
            myReader = db.ExecuteReader

            myReader.Read()
            If Convert.ToInt32(myReader(0)) > 0 Then
                retValue = True
            Else
                retValue = False
            End If

            myReader.Close()
            db.CloseConn()

            Return retValue
        End Function

        Public Function ChunkNameExist(ByVal ChunkName As String, ByVal idCategoria As Long, Optional ByVal idChunk As Long = -1, Optional ByRef tmpDbCommand As OleDbCommand = Nothing, Optional ByRef tmpDbConnection As OleDbConnection = Nothing) As Boolean
            Dim retValue As Boolean = False

            If idChunk = -1 Then
                Sql = "Select Count(*) from Chunks Where NomeVariabile = '" & ChunkName.Trim & "' And idCategoria = " & idCategoria
            Else
                Sql = "Select Count(*) from Chunks Where NomeVariabile = '" & ChunkName.Trim & "' And idCategoria = " & idCategoria & " AND idVariabile <> " & idChunk
            End If

            If IsNothing(tmpDbConnection) Then
                db.OpenConn(Sql)
                myReader = db.ExecuteReader()
            Else
                db.OpenConn(Sql, , , True, tmpDbConnection, tmpDbCommand)
                myReader = db.ExecuteReader(True, tmpDbCommand)
            End If

            myReader.Read()
            If Convert.ToInt32(myReader(0)) > 0 Then
                retValue = True
            Else
                retValue = False
            End If

            myReader.Close()
            If IsNothing(tmpDbConnection) Then db.CloseConn()

            Return retValue
        End Function

        Public Function CountChunksByName(ByVal ChunkName As String, Optional ByRef tmpDbCommand As OleDbCommand = Nothing, Optional ByRef tmpDbConnection As OleDbConnection = Nothing) As Long
            Dim retValue As Long = -1

            Sql = "Select Count(*) from Chunks Where NomeVariabile = '" & ChunkName.Trim & "'"

            If IsNothing(tmpDbConnection) Then
                db.OpenConn(Sql)
                myReader = db.ExecuteReader()
            Else
                db.OpenConn(Sql, , , True, tmpDbConnection, tmpDbCommand)
                myReader = db.ExecuteReader(True, tmpDbCommand)
            End If

            myReader.Read()
            retValue = Convert.ToInt32(myReader(0))

            myReader.Close()
            If IsNothing(tmpDbConnection) Then db.CloseConn()

            Return retValue
        End Function

        Public Function ReadChunk(ByVal ChunkName As String, Optional ByVal idCategoria As Long = -1, Optional ByRef tmpDbCommand As OleDbCommand = Nothing, Optional ByRef tmpDbConnection As OleDbConnection = Nothing) As String
            Dim retValue As String = ""

            If idCategoria = -1 Then
                Sql = "Select Contenuto from Chunks Where NomeVariabile = '" & ChunkName.Trim & "'"
            Else
                Sql = "Select Contenuto from Chunks Where NomeVariabile = '" & ChunkName.Trim & "' And idCategoria = " & idCategoria
            End If


            If IsNothing(tmpDbConnection) Then
                db.OpenConn(Sql)
                myReader = db.ExecuteReader()
            Else
                db.OpenConn(Sql, , , True, tmpDbConnection, tmpDbCommand)
                myReader = db.ExecuteReader(True, tmpDbCommand)
            End If

            While myReader.Read
                retValue = myReader("Contenuto")
                Exit While
            End While

            myReader.Close()
            If IsNothing(tmpDbConnection) Then db.CloseConn()

            Return retValue
        End Function

        Public Function TemplateVariableNameExist(ByVal TemplateVariableName As String, ByVal idTVCategoria As Long, Optional ByVal idTV As Long = -1) As Boolean
            Dim retValue As Boolean = False

            Sql = "Select Count(*) from TemplateVariablesList Where Name = '" & TemplateVariableName.Trim & "' And idTVCategoria = " & idTVCategoria

            If idTV > -1 Then
                Sql &= " AND idTV <> " & idTV
            End If

            db.OpenConn(Sql)
            myReader = db.ExecuteReader

            myReader.Read()
            If Convert.ToInt32(myReader(0)) > 0 Then
                retValue = True
            Else
                retValue = False
            End If

            myReader.Close()
            db.CloseConn()

            Return retValue
        End Function

        Public Function ChunkCategoriaExist(ByVal NomeCategoria As String, Optional ByVal ExludeID As Long = -1, Optional ByRef tmpDbCommand As OleDbCommand = Nothing, Optional ByRef tmpDbConnection As OleDbConnection = Nothing) As Boolean
            Dim retValue As Boolean = False

            Sql = "Select Count(*) from ChunkCategorie Where NomeCategoria = '" & NomeCategoria.Trim & "'"

            If ExludeID > -1 Then
                Sql &= " AND idCategoria <> " & ExludeID
            End If

            If IsNothing(tmpDbConnection) Then
                db.OpenConn(Sql)
                myReader = db.ExecuteReader()
            Else
                db.OpenConn(Sql, , , True, tmpDbConnection, tmpDbCommand)
                myReader = db.ExecuteReader(True, tmpDbCommand)
            End If

            myReader.Read()
            If Convert.ToInt32(myReader(0)) > 0 Then
                retValue = True
            Else
                retValue = False
            End If

            myReader.Close()
            If IsNothing(tmpDbConnection) Then db.CloseConn()

            Return retValue
        End Function

        Public Function TemplateVariableCategoriaExist(ByVal NomeCategoria As String, Optional ByVal ExludeID As Long = -1) As Boolean
            Dim retValue As Boolean = False

            Sql = "Select Count(*) from TemplateVariablesCategorie Where NomeCategoria = '" & NomeCategoria.Trim & "'"

            If ExludeID > -1 Then
                Sql &= " AND idCategoria <> " & ExludeID
            End If

            db.OpenConn(Sql)
            myReader = db.ExecuteReader

            myReader.Read()
            If Convert.ToInt32(myReader(0)) > 0 Then
                retValue = True
            Else
                retValue = False
            End If

            myReader.Close()
            db.CloseConn()

            Return retValue
        End Function

        Public Function GetIDTemplate(ByVal TemplateName As String) As Long
            Dim retValue As Long = -1

            Sql = "Select idTemplate from Templates Where Nome = """ & TemplateName.Trim & """"
            db.OpenConn(Sql)
            myReader = db.ExecuteReader

            While myReader.Read
                retValue = myReader("idTemplate")
            End While

            myReader.Close()
            db.CloseConn()

            Return retValue
        End Function

        Public Sub GetLanguagesList(ByRef dropDown As DropDownList)
            For Each ci As CultureInfo In CultureInfo.GetCultures(CultureTypes.AllCultures)
                dropDown.Items.Add(New ListItem(ci.NativeName, ci.Name))
            Next
        End Sub

        Public Function GetIdLanguageFromName(ByVal LanguageName As String, Optional ByRef tmpDbCommand As OleDbCommand = Nothing, Optional ByRef tmpDbConnection As OleDbConnection = Nothing) As Long
            'Cerco la lingua...
            Dim idLingua As Long = -1

            Sql = "Select * From Lingue Where Tipo = '" & LanguageName & "'"

            If IsNothing(tmpDbConnection) Then
                db.OpenConn(Sql)
                myReader = db.ExecuteReader()
            Else
                db.OpenConn(Sql, , , True, tmpDbConnection, tmpDbCommand)
                myReader = db.ExecuteReader(True, tmpDbCommand)
            End If

            While myReader.Read
                idLingua = myReader("idLingua")
                Exit While
            End While
            myReader.Close()
            If IsNothing(tmpDbConnection) Then db.CloseConn()

            'Se non esiste la creo e mi prendo l'id...
            If idLingua = -1 Then
                Sql = "INSERT INTO Lingue (Tipo, Descrizione) VALUES ('" & LanguageName & "','" & GetLanguageNameFromTwoDigits(LanguageName) & "')"
                If IsNothing(tmpDbConnection) Then
                    db.OpenConn(Sql)
                    db.ExecuteNonQuery()
                Else
                    db.OpenConn(Sql, , , True, tmpDbConnection, tmpDbCommand)
                    db.ExecuteNonQuery(True, tmpDbCommand)
                End If

                If IsNothing(tmpDbConnection) Then db.CloseConn()
                'Ricorsiva..
                idLingua = GetIdLanguageFromName(LanguageName, tmpDbCommand, tmpDbConnection)
            End If

            Return idLingua
        End Function

        Public Function GetLanguageNameFromTwoDigits(ByVal ShortName As String) As String
            'TODO verificare con lingue strane tipo il cinese...
            Dim ci As CultureInfo = CultureInfo.CreateSpecificCulture(ShortName)
            Return ci.NativeName
        End Function

        Public Function JertCMS_WriteMenu() As String
            Dim MenuHTML As String = ""

            MenuHTML = "<ul>" & vbCrLf

            db.OpenConn("SELECT * From Menu Where codPaginaMadre = 0 And ProfonditaLivello = 1 Order By Ordine")
            myReader = db.ExecuteReader

            While myReader.Read
                MenuHTML &= "<li" & IIf(myReader("codPagina") = cmsPage.codPagina, " class=""current"" ", "") & "><a href=""" & myReader("FolderPath").replace("\", "/") & """><span>" & myReader("DescrizioneBreveNelMenu") & "</span></a></li>" & vbCrLf
            End While
            myReader.Close()
            db.CloseConn()

            MenuHTML &= "</ul>" & vbCrLf
            Return MenuHTML
        End Function


        Public Function JertCMS_WriteGalleryMenu() As String
            Dim GalleryMenuHTML As String = ""

            GalleryMenuHTML = "<div class=""catalogo""><ul>" & vbCrLf

            db.OpenConn("SELECT * From Gallery Order By Ordine")
            myReader = db.ExecuteReader

            While myReader.Read
                GalleryMenuHTML &= "<li><a href=""" & (cmsPaths.PathPublic & cmsLanguage.Lingua & "\" & cmsPaths.PathGallery & myReader("FolderName") & "\").ToString.Replace("\", "/") & """>" & myReader("title") & "</a></li>" & vbCrLf
            End While
            myReader.Close()
            db.CloseConn()

            GalleryMenuHTML &= "</ul></div>" & vbCrLf
            Return GalleryMenuHTML
        End Function


        Public Function JertCMS_WriteLightBox(ByVal Menu_FolderPath As String) As String
            Dim GalleryHTML As String = ""

            GalleryHTML = "<div class=""gallery"">" & vbCrLf

            db.OpenConn("SELECT * FROM Gallery INNER JOIN Images ON Gallery.id = Images.idGallery Where Gallery.FolderName = '" & Menu_FolderPath & "' Order By Images.Posizione ")
            myReader = db.ExecuteReader

            While myReader.Read
                GalleryHTML &= "<a href=""" & (cmsPaths.PathPublic & cmsLanguage.Lingua & "\" & cmsPaths.PathGallery & myReader("FolderName") & "\").ToString.Replace("\", "/") & myReader("Images.id") & ".Jpeg"" rel=""shadowbox[nomegallery]"" title=""" & myReader("ImageTitle") & """ alt=""#"" class=""" & IIf(myReader("Orizzontal"), "or", "vt") & """ ""><img src=""" & (cmsPaths.PathPublic & cmsLanguage.Lingua & "\" & cmsPaths.PathGallery & myReader("FolderName") & "\").ToString.Replace("\", "/") & "thumb" & myReader("Images.id") & ".Jpeg"" alt=""#"" class=""" & IIf(myReader("Orizzontal"), "or", "vt") & """ /><br />" & myReader("ImageTitle") & "</a>" & vbCrLf
            End While
            myReader.Close()
            db.CloseConn()

            GalleryHTML &= "<div></div></div>" & vbCrLf
            Return GalleryHTML
        End Function


        Public Function GetPageByID(ByVal PageID As Long, Optional ByRef tmpDbCommand As OleDbCommand = Nothing, Optional ByRef tmpDbConnection As OleDbConnection = Nothing) As _cmsPage
            Dim tmpPage As New _cmsPage

            With tmpPage
                'Sql = " SELECT * FROM Pagine Where idPagina = " & PageID & ";"
                Sql = " SELECT Pagine.*, folderpath, DescrizioneBreveNelMenu FROM Pagine INNER JOIN Menu ON Pagine.codPagina = Menu.codPagina WHERE Pagine.idPagina= " & PageID & ";"

                If IsNothing(tmpDbConnection) Then
                    db.OpenConn(Sql)
                    myReader = db.ExecuteReader()
                Else
                    db.OpenConn(Sql, , , True, tmpDbConnection, tmpDbCommand)
                    myReader = db.ExecuteReader(True, tmpDbCommand)
                End If

                While myReader.Read
                    With tmpPage
                        .codPagina = myReader("codPagina")
                        .DataInserimento = myReader("DataInserimento")
                        .DataUltimaModifica = myReader("DataUltimaModifica")
                        .filename = IIf(IsDBNull(myReader("filename")), "", myReader("filename"))
                        .idLingua = myReader("idLingua")
                        .idPagina = myReader("idPagina")
                        .LivelloVisibilita = myReader("LivelloVisibilita")
                        .MetaDescription = myReader("MetaDescription")
                        .TitoloH1 = myReader("TitoloH1")

                        'TODO
                        '.TestoHeader = myReader("TestoHeader")
                        '.Testo = myReader("Testo")
                        .HTMLPageContent = IIf(IsDBNull(myReader("Content")), "", myReader("Content"))

                        .Tipo = myReader("Tipo")
                        .Titolo = myReader("Titolo")
                        .idTemplate = myReader("idTemplate")

                        .FolderPath = myReader("folderpath")
                        .DescrizioneBreveNelMenu = myReader("DescrizioneBreveNelMenu")
                    End With

                    Exit While
                End While

                myReader.Close()
                If IsNothing(tmpDbConnection) Then db.CloseConn()

                If .idPagina = 0 Then
                    'Pagina non trovata....
                    .idErrore = 1
                End If

            End With


            Return tmpPage
        End Function

        Public Function GetPageByMenuNameAndPageDepth(ByVal MenuName As String, ByVal PageDepth As Long, Optional ByRef tmpDbCommand As OleDbCommand = Nothing, Optional ByRef tmpDbConnection As OleDbConnection = Nothing) As _cmsPage
            Dim tmpPage As New _cmsPage

            With tmpPage
                Sql = "  SELECT Pagine.*, folderpath, DescrizioneBreveNelMenu FROM Pagine INNER JOIN Menu ON Pagine.codPagina = Menu.codPagina WHERE DescrizioneBreveNelMenu = '" & MenuName & "' AND ProfonditaLivello = " & PageDepth & ";"

                If IsNothing(tmpDbConnection) Then
                    db.OpenConn(Sql)
                    myReader = db.ExecuteReader()
                Else
                    db.OpenConn(Sql, , , True, tmpDbConnection, tmpDbCommand)
                    myReader = db.ExecuteReader(True, tmpDbCommand)
                End If

                While myReader.Read
                    With tmpPage
                        .codPagina = myReader("codPagina")
                        .DataInserimento = myReader("DataInserimento")
                        .DataUltimaModifica = myReader("DataUltimaModifica")
                        .filename = IIf(IsDBNull(myReader("filename")), "", myReader("filename"))
                        .idLingua = myReader("idLingua")
                        .idPagina = myReader("idPagina")
                        .LivelloVisibilita = myReader("LivelloVisibilita")
                        .MetaDescription = myReader("MetaDescription")
                        .TitoloH1 = myReader("TitoloH1")

                        'TODO
                        '.TestoHeader = myReader("TestoHeader")
                        '.Testo = myReader("Testo")
                        .HTMLPageContent = myReader("Content")

                        .Tipo = myReader("Tipo")
                        .Titolo = myReader("Titolo")
                        .idTemplate = myReader("idTemplate")

                        .FolderPath = myReader("folderpath")
                        .DescrizioneBreveNelMenu = myReader("DescrizioneBreveNelMenu")
                    End With

                    Exit While
                End While

                myReader.Close()
                If IsNothing(tmpDbConnection) Then db.CloseConn()

                If .idPagina = 0 Then
                    'Pagina non trovata....
                    .idErrore = 1
                End If

            End With


            Return tmpPage
        End Function

        Public Function GetCodPaginaMadreDaIdVoceDiMenu(ByVal idVoce As Long) As Long
            Dim tmpID As Long = 0

            Sql = " SELECT codPaginaMadre FROM Menu Where idVoce = " & idVoce & ";"

            db.OpenConn(Sql)
            myReader = db.ExecuteReader

            While myReader.Read
                tmpID = myReader("codPaginaMadre")
            End While

            myReader.Close()
            db.CloseConn()

            Return tmpID
        End Function

        Public Function GetCodPaginaDaIdVoceDiMenu(ByVal idVoce As Long) As Long
            Dim tmpID As Long = 0

            Sql = " SELECT codPagina FROM Menu Where idVoce = " & idVoce & ";"

            db.OpenConn(Sql)
            myReader = db.ExecuteReader

            While myReader.Read
                tmpID = myReader("codPagina")
            End While

            myReader.Close()
            db.CloseConn()

            Return tmpID
        End Function

        Public Function GetTotVisitors() As Long
            Dim tmpTOT As Long = 0

            Sql = "SELECT Count(*) FROM (SELECT DISTINCT RemoteHost AS Conta FROM PageCounter)"

            db.OpenConn(Sql, "Counter")
            myReader = db.ExecuteReader

            While myReader.Read
                tmpTOT = myReader(0)
            End While

            myReader.Close()
            db.CloseConn()

            Return tmpTOT
        End Function

        Public Function GetTotPagesView() As Long
            Dim tmpTOT As Long = 0

            Sql = "SELECT Count(*) FROM PageCounter"

            db.OpenConn(Sql, "Counter")
            myReader = db.ExecuteReader

            While myReader.Read
                tmpTOT = myReader(0)
            End While

            myReader.Close()
            db.CloseConn()

            Return tmpTOT
        End Function

        Public Function GetCodPaginaDaFolderPath(ByVal folderpath As String) As Long
            Dim tmpID As Long = 0

            Sql = " SELECT codPagina FROM Menu Where folderpath = '" & folderpath & "';"

            db.OpenConn(Sql)
            myReader = db.ExecuteReader

            While myReader.Read
                tmpID = myReader("codPagina")
            End While

            myReader.Close()
            db.CloseConn()

            Return tmpID
        End Function

        Public Function GetProfonditaLivelloDaIdVoceDiMenu(ByVal idVoce As Long) As Long
            Dim tmpProfondita As Long = 0

            Sql = " SELECT ProfonditaLivello FROM Menu Where idVoce = " & idVoce & ";"

            db.OpenConn(Sql)
            myReader = db.ExecuteReader

            While myReader.Read
                tmpProfondita = myReader("ProfonditaLivello")
            End While

            myReader.Close()
            db.CloseConn()

            Return tmpProfondita
        End Function

        Public Function GetVoceMenuFromFolderPath(ByVal FolderPath As String, Optional ByVal ForceidLingua As Long = -1, Optional ByRef tmpDbCommand As OleDbCommand = Nothing, Optional ByRef tmpDbConnection As OleDbConnection = Nothing) As _cmsVoceDiMenu
            Dim tmpVoce As New _cmsVoceDiMenu
            With tmpVoce

                'If FolderPath.Length > (cmsPaths.PathPublic & cmsLanguage.Lingua & "\" & cmsPaths.PathGallery).Length Then
                '    If FolderPath.StartsWith((cmsPaths.PathPublic & cmsLanguage.Lingua & "\" & cmsPaths.PathGallery)) Then

                '        FolderPath = FolderPath.Replace((cmsPaths.PathPublic & cmsLanguage.Lingua & "\" & cmsPaths.PathGallery), "")

                '        'è una galleria...
                '        .codPagina = GetCodPaginaDaFolderPath(FolderPath)
                '        .codPaginaMadre = -1
                '        .DescrizioneBreveNelMenu = ""
                '        .folderpath = FolderPath
                '        .idLingua = -1
                '        .idVoce = -1
                '        .NuovaPagina = False
                '        .ordine = -1
                '        .ProfonditaLivello = -1
                '        Return tmpVoce
                '    End If
                'End If

                FolderPath = FolderPath.Replace("/", "\")

                If FolderPath.EndsWith("\") Then FolderPath = FolderPath.Substring(0, FolderPath.Length - 1)

                If ForceidLingua = -1 Then
                    Sql = "Select * From Menu Where folderpath = '" & IIf(FolderPath.Trim.Length = 1, "", FolderPath.Trim) & "\" & "' AND idLingua = " & cmsLanguage.idLingua & ";"
                Else
                    Sql = "Select * From Menu Where folderpath = '" & IIf(FolderPath.Trim.Length = 1, "", FolderPath.Trim) & "\" & "' AND idLingua = " & ForceidLingua & ";"
                End If

                Dim tmpReader As OleDbDataReader

                If IsNothing(tmpDbConnection) Then
                    db.OpenConn(Sql)
                    tmpReader = db.ExecuteReader()
                Else
                    db.OpenConn(Sql, , , True, tmpDbConnection, tmpDbCommand)
                    tmpReader = db.ExecuteReader(True, tmpDbCommand)
                End If

                While tmpReader.Read
                    .codPagina = tmpReader("codPagina")
                    .codPaginaMadre = tmpReader("codPaginaMadre")
                    .DescrizioneBreveNelMenu = tmpReader("DescrizioneBreveNelMenu")
                    .folderpath = tmpReader("folderpath")
                    .idLingua = tmpReader("idLingua")
                    .idVoce = tmpReader("idVoce")
                    .NuovaPagina = False
                    .ordine = tmpReader("ordine")
                    .ProfonditaLivello = tmpReader("ProfonditaLivello")

                    Exit While
                End While

                tmpReader.Close()
                If IsNothing(tmpDbConnection) Then db.CloseConn()

                If .idLingua = 0 Then
                    'Non è stato trovato il menu..
                    'Riprovo cambiando lingua..

                    Dim LinguaCulture As String = ""
                    LinguaCulture = SearchNewIDLingua(IIf(ForceidLingua = -1, cmsLanguage.idLingua, ForceidLingua), tmpDbCommand, tmpDbConnection)
                    InitLanguage(LinguaCulture)

                    If ForceidLingua = -1 Then
                        Sql = "Select * From Menu Where folderpath = '" & IIf(FolderPath.Trim.Length = 1, "", FolderPath.Trim) & "\" & "' AND idLingua = " & cmsLanguage.idLingua & ";"
                    Else
                        Sql = "Select * From Menu Where folderpath = '" & IIf(FolderPath.Trim.Length = 1, "", FolderPath.Trim) & "\" & "' AND idLingua = " & ForceidLingua & ";"
                    End If

                    If IsNothing(tmpDbConnection) Then
                        db.OpenConn(Sql)
                        tmpReader = db.ExecuteReader()
                    Else
                        db.OpenConn(Sql, , , True, tmpDbConnection, tmpDbCommand)
                        tmpReader = db.ExecuteReader(True, tmpDbCommand)
                    End If

                    While tmpReader.Read
                        .codPagina = tmpReader("codPagina")
                        .codPaginaMadre = tmpReader("codPaginaMadre")
                        .DescrizioneBreveNelMenu = tmpReader("DescrizioneBreveNelMenu")
                        .folderpath = tmpReader("folderpath")
                        .idLingua = tmpReader("idLingua")
                        .idVoce = tmpReader("idVoce")
                        .NuovaPagina = False
                        .ordine = tmpReader("ordine")
                        .ProfonditaLivello = tmpReader("ProfonditaLivello")
                        Exit While
                    End While

                    tmpReader.Close()
                    If IsNothing(tmpDbConnection) Then db.CloseConn()
                End If
            End With

            Return tmpVoce
        End Function

        Public Function JertCMS_WriteElencoVociDiMenuDaCodPaginaMadre(ByVal CodPaginaMadre As Long, ByVal ProfonditaLivello As Long) As String
            Dim VociHTML As String = ""

            VociHTML = "<div class=""form-input"">" & vbCrLf

            Sql = "SELECT Menu.ordine, Menu.DescrizioneBreveNelMenu, Menu.codPaginaMadre FROM Pagine INNER JOIN Menu ON Pagine.codPagina = Menu.codPagina Where codPaginaMadre = " & CodPaginaMadre & " AND ProfonditaLivello = " & ProfonditaLivello + 1 & " Order By Ordine"
            db.OpenConn(Sql)
            myReader = db.ExecuteReader()

            While myReader.Read
                VociHTML &= "Posizione " & myReader("ordine") & " -> " & myReader("DescrizioneBreveNelMenu") & "<br />" & vbCrLf
            End While

            myReader.Close()
            db.CloseConn()

            VociHTML &= "<div></div></div>" & vbCrLf
            Return VociHTML
        End Function

        Public Function LoadListOrdini(ByVal dropdownList As DropDownList, ByVal CodPaginaMadre As Long, ByVal ProfonditaLivello As Long) As Long
            Dim tmpContaOrdini As Long = 0

            With dropdownList
                Sql = "SELECT Menu.ordine, Menu.DescrizioneBreveNelMenu, Menu.codPaginaMadre FROM Pagine INNER JOIN Menu ON Pagine.codPagina = Menu.codPagina Where codPaginaMadre = " & CodPaginaMadre & " Order By Ordine"
                db.OpenConn(Sql)
                myReader = db.ExecuteReader()
                .Items.Clear()

                While myReader.Read
                    tmpContaOrdini += 1
                    Dim newListItem As New ListItem()
                    newListItem.Text = myReader("ordine")
                    newListItem.Value = myReader("ordine")
                    .Items.Add(newListItem)
                End While

                .DataBind()

                If tmpContaOrdini = 0 Then
                    Dim newListItem As New ListItem()
                    newListItem.Text = 1
                    newListItem.Value = 1
                    .Items.Add(newListItem)
                End If

                myReader.Close()
                db.CloseConn()
            End With

            Return tmpContaOrdini
        End Function

        Public Sub LoadListPagineSuperiori(ByVal dropdownList As DropDownList, ByVal idVoce As Long, ByVal NewMenu As Boolean)
            With dropdownList
                If NewMenu Then
                    Sql = "SELECT Pagine.idPagina, Menu.idVoce, Menu.codPagina, Pagine.Titolo, Menu.DescrizioneBreveNelMenu FROM Pagine INNER JOIN Menu ON Pagine.codPagina = Menu.codPagina Order by ProfonditaLivello"
                Else
                    Sql = "SELECT Pagine.idPagina, Menu.idVoce, Menu.codPagina, Pagine.Titolo, Menu.DescrizioneBreveNelMenu FROM Pagine INNER JOIN Menu ON Pagine.codPagina = Menu.codPagina Where Menu.idVoce <> " & idVoce & " Order by ProfonditaLivello"
                End If

                db.OpenConn(Sql)
                myReader = db.ExecuteReader()
                .Items.Clear()

                Dim newListItem As New ListItem()
                newListItem.Text = Selezionare
                newListItem.Value = idSelezioneZero
                .Items.Add(newListItem)

                While myReader.Read
                    newListItem = New ListItem()
                    newListItem.Text = myReader("DescrizioneBreveNelMenu")
                    newListItem.Value = myReader("codPagina")
                    .Items.Add(newListItem)
                End While

                .DataBind()

                .SelectedIndex = 0

                myReader.Close()
                db.CloseConn()
            End With
        End Sub

        Public Sub SaveChunk(ByVal Name As String, ByVal HTMLCode As String, ByVal idCategoria As Long)
            Sql = "INSERT INTO Chunks (idCategoria, NomeVariabile, Contenuto) VALUES (" & idCategoria & ", '" & Name.Replace("'", "''") & "','" & HTMLCode.Replace("'", "''") & "')"
            db.OpenConn(Sql)
            db.ExecuteNonQuery()
            db.CloseConn()
        End Sub

        Public Sub UpdateChunk(ByVal Name As String, ByVal HTMLCode As String, ByVal idCategoria As Long, ByVal idChunk As Long)
            Sql = "UPDATE Chunks Set idCategoria = " & idCategoria & ", NomeVariabile = '" & Name.Replace("'", "''") & "', Contenuto = '" & HTMLCode.Replace("'", "''") & "' WHERE idVariabile = " & idChunk

            db.OpenConn(Sql)
            db.ExecuteNonQuery()
            db.CloseConn()
        End Sub

        Public Sub SaveTemplateVariable(ByVal Name As String, ByVal Caption As String, ByVal Description As String, ByVal idTVCategoria As Long, ByVal TVType As Long, ByVal PanelOfChkTemplates As Panel)
            Sql = "INSERT INTO TemplateVariablesList (Name, Caption, Description, idTVCategoria, Type) VALUES ('" & Name.Replace("'", "''") & "','" & Caption.Replace("'", "''") & "','" & Description.Replace("'", "''") & "'," & idTVCategoria & "," & TVType & ")"
            db.OpenConn(Sql)
            db.ExecuteNonQuery()
            db.CloseConn()

            Dim idTV As Long = -1
            Sql = "Select idTV From TemplateVariablesList Where Name = '" & Name.Replace("'", "''") & "' AND Caption ='" & Caption.Replace("'", "''") & "' AND Description='" & Description.Replace("'", "''") & "' AND idTVCategoria=" & idTVCategoria & " AND Type=" & TVType & ""
            db.OpenConn(Sql)
            idTV = db.ExecuteScalar
            db.CloseConn()

            UpdateTVInTemplate(idTV, PanelOfChkTemplates)
        End Sub

        Public Sub UpdateTVInTemplate(ByVal idTV As Long, ByVal PanelOfChkTemplates As Panel)
            For Each tmpChk As Object In PanelOfChkTemplates.Controls
                If TypeOf (tmpChk) Is CheckBox Then
                    SaveTVInTemplate(idTV, tmpChk.ID, tmpChk.Checked)
                End If
            Next
        End Sub

        Public Sub UpdateTemplateVariable(ByVal idTV As Long, ByVal Name As String, ByVal Caption As String, ByVal Description As String, ByVal idTVCategoria As Long, ByVal TVType As Long, ByVal PanelOfChkTemplates As Panel)
            Sql = "UPDATE TemplateVariablesList Set Name = '" & Name.Replace("'", "''") & "', Caption = '" & Caption.Replace("'", "''") & "', Description = '" & Description.Replace("'", "''") & "', idTVCategoria = " & idTVCategoria & ", Type = " & TVType & " WHERE idTV = " & idTV
            db.OpenConn(Sql)
            db.ExecuteNonQuery()
            db.CloseConn()

            UpdateTVInTemplate(idTV, PanelOfChkTemplates)
        End Sub

        Public Function CountTemplateChecked(ByVal TemplatePanel As Panel) As Long
            Dim retValue As Long = 0

            For Each tmpChk As Object In TemplatePanel.Controls
                If TypeOf (tmpChk) Is CheckBox Then
                    If CType(tmpChk, CheckBox).Checked Then
                        retValue += 1
                    End If
                End If
            Next

            Return retValue
        End Function

        Private Sub SaveTVInTemplate(ByVal idTV As Long, ByVal tmpChk_ID As String, ByVal tmpChk_Checked As Boolean)
            'Filtro tmpChk_ID
            tmpChk_ID = tmpChk_ID.Replace("chk", "")

            'Verifico se la TV è inserita nel template..
            Sql = "Select * From TemplateVariablesInTemplate Where idTemplateVariablesList = " & idTV & " AND idTemplate = " & tmpChk_ID
            db.OpenConn(Sql)
            myReader = db.ExecuteReader

            Dim idTemplateVariablesInTemplate As Long = -1

            While myReader.Read
                idTemplateVariablesInTemplate = myReader("idTemplateVariablesInTemplate")
            End While

            myReader.Close()
            db.CloseConn()

            If idTemplateVariablesInTemplate = -1 Then
                'La variabile non esiste per questo template..
                'La aggiungo solo se tmpChk_Checked è true
                If tmpChk_Checked Then
                    Dim tmpOrder As Long = 0
                    tmpOrder = getMaxOrderOfTVinTemplate(tmpChk_ID)

                    Sql = "INSERT INTO TemplateVariablesInTemplate (idTemplateVariablesList,idTemplate,TvOrderInTemplate) VALUES (" & idTV & "," & tmpChk_ID & "," & tmpOrder & ")"
                    db.OpenConn(Sql)
                    db.ExecuteNonQuery()
                    db.CloseConn()
                End If
            Else
                'La variabile è presente...
                'Se è presente è true.., non faccio niente..
                If Not tmpChk_Checked Then
                    'E false.. la devo eliminare sia da TemplateVariablesInTemplate che da TemplateVariablesInPages
                    Sql = "Delete * From TemplateVariablesInTemplate Where idTemplateVariablesInTemplate = " & idTemplateVariablesInTemplate
                    db.OpenConn(Sql)
                    db.ExecuteNonQuery()
                    db.CloseConn()

                    Sql = "Delete * From TemplateVariablesInPages Where idTemplateVariablesInTemplate = " & idTemplateVariablesInTemplate
                    db.OpenConn(Sql)
                    db.ExecuteNonQuery()
                    db.CloseConn()
                End If
            End If
        End Sub

        Public Function getMaxOrderOfTVinTemplate(ByVal idTemplate As Long) As Long
            Dim tmpRetVal As Long = 0

            Sql = "Select Max(TVOrderInTemplate) From TemplateVariablesInTemplate Where idTemplate = " & idTemplate
            db.OpenConn(Sql)
            Try
                tmpRetVal = db.ExecuteScalar() + 1
            Catch Invalid As InvalidCastException
                tmpRetVal = 1
            End Try

            db.CloseConn()

            Return tmpRetVal
        End Function

        Public Sub SaveTemplate(ByVal Name As String, ByVal HTMLCode As String, ByVal Header As String, ByVal BodyTagOpen As String, ByVal BodyTagCloseAndFooter As String)
            Sql = "INSERT INTO Templates (Nome, Contenuto, Header, BodyTagOpen, BodyTagClose) VALUES ('" & Name.Replace("'", "''") & "','" & HTMLCode.Replace("'", "''") & "','" & Header.Replace("'", "''") & "','" & BodyTagOpen.Replace("'", "''") & "','" & BodyTagCloseAndFooter.Replace("'", "''") & "')"
            db.OpenConn(Sql)
            db.ExecuteNonQuery()
            db.CloseConn()

            Dim tmpIdTemplate As Long = db.GetLastID("Templates", "idTemplate")

            EditTemplate(tmpIdTemplate, Name, HTMLCode, Header, BodyTagOpen, BodyTagCloseAndFooter)
        End Sub

        Public Sub EditTemplate(ByVal idTemplate As Long, ByVal Name As String, ByVal HTMLCode As String, ByVal Header As String, ByVal BodyTagOpen As String, ByVal BodyTagClose As String)
            Dim tmpHaveDetails As Boolean = False

            'Elimino gli attributi...
            Sql = "DELETE * FROM TemplateDetailAttributes WHERE idTemplateDetail IN (Select id From TemplateDetails Where idTemplate=" & idTemplate & " AND HaveAttributes = True)"
            db.OpenConn(Sql)
            db.ExecuteNonQuery()

            Sql = "DELETE * FROM TemplateDetails WHERE idTemplate = " & idTemplate
            db.OpenConn(Sql)
            db.ExecuteNonQuery()

            db.CloseConn()

            If JertCMS_ModuleExist("<jcms(\s+(?<attribute>\S+?)=[""']?(?<value>[^""']*)[""']?\S)*\s+/>", HTMLCode, "", "", True) Then
                tmpHaveDetails = True

                'Split Code... & Modules...
                Dim arrModulesCommand As String()
                arrModulesCommand = getArrModulesCommands("<jcms(\s+(?<attribute>\S+?)=[""']?(?<value>[^""']*)[""']?\S)*\s+/>", HTMLCode)

                Dim StartIndex As Integer = 0
                Dim EndIndex As Integer = 0
                Dim tmpContentStripped As String = ""

                Dim ComponentID As Long = 0
                Dim Order As Integer = 0
                Dim Content As String = ""
                Dim CustomID As String
                Dim DetailCount As Long = 0

                'Dim tmpAttributeList As Array(Of _cmsTemplateDetailAttributes)
                Dim tmpAttributeList As List(Of _cmsTemplateDetailAttributes)

                For DetailCount = 0 To arrModulesCommand.Length - 1
                    tmpAttributeList = New List(Of _cmsTemplateDetailAttributes)
                    ComponentID = GetComponentIDFromModuleCommand("<jcms(\s+(?<attribute>\S+?)=[""']?(?<value>[^""']*)[""']?\S)*\s+/>", arrModulesCommand(DetailCount), tmpAttributeList)
                    CustomID = GetCustomIDFromModuleCommand("<jcms(\s+(?<attribute>\S+?)=[""']?(?<value>[^""']*)[""']?\S)*\s+/>", arrModulesCommand(DetailCount), tmpAttributeList)

                    EndIndex = HTMLCode.IndexOf(arrModulesCommand(DetailCount), StartIndex)
                    tmpContentStripped = HTMLCode.Substring(StartIndex, EndIndex - StartIndex)

                    'Salvo testo generico..
                    jModule.AddTemplateDetail(idTemplate, Order, tmpContentStripped, 0, "")
                    Order += 1

                    'Salvo il componente..
                    jModule.AddTemplateDetail(idTemplate, Order, arrModulesCommand(DetailCount), ComponentID, CustomID, tmpAttributeList)
                    Order += 1

                    StartIndex = EndIndex + arrModulesCommand(DetailCount).Length

                    If DetailCount = arrModulesCommand.Length - 1 Then
                        tmpContentStripped = HTMLCode.Substring(StartIndex, HTMLCode.Length - StartIndex)
                        If tmpContentStripped.Length > 0 Then
                            jModule.AddTemplateDetail(idTemplate, Order, tmpContentStripped, 0, "")
                        End If
                    End If
                Next

                DetailCount = Order + 1

                Sql = "UPDATE Templates Set DetailCount = " & DetailCount & ", HaveDetails = " & tmpHaveDetails & ", Nome = '" & Name.Replace("'", "''") & "', Contenuto = '" & HTMLCode.Replace("'", "''") & "', Header = '" & Header.Replace("'", "''") & "', BodyTagOpen = '" & BodyTagOpen.Replace("'", "''") & "', BodyTagClose = '" & BodyTagClose.Replace("'", "''") & "' WHERE idTemplate = " & idTemplate
                db.OpenConn(Sql)
                db.ExecuteNonQuery()
                db.CloseConn()
            Else
                Sql = "UPDATE Templates Set DetailCount = 0, HaveDetails = " & tmpHaveDetails & ", Nome = '" & Name.Replace("'", "''") & "', Contenuto = '" & HTMLCode.Replace("'", "''") & "', Header = '" & Header.Replace("'", "''") & "', BodyTagOpen = '" & BodyTagOpen.Replace("'", "''") & "', BodyTagClose = '" & BodyTagClose.Replace("'", "''") & "' WHERE idTemplate = " & idTemplate
                db.OpenConn(Sql)
                db.ExecuteNonQuery()
                db.CloseConn()
            End If
        End Sub

        Public Sub DeleteTemplate(Optional ByVal idTemplate As Long = -1)
            If idTemplate = -1 Then
                Sql = "Delete * From Templates"
                db.OpenConn(Sql)
                db.ExecuteNonQuery()
                db.CloseConn()

                Sql = "Delete * From TemplateDetails"
                db.OpenConn(Sql)
                db.ExecuteNonQuery()
                db.CloseConn()

                Sql = "Delete * From TemplateDetailAttributes"
                db.OpenConn(Sql)
                db.ExecuteNonQuery()
                db.CloseConn()

                Sql = "Delete * From TemplateVariablesList"
                db.OpenConn(Sql)
                db.ExecuteNonQuery()
                db.CloseConn()

                Sql = "Delete * From TemplateVariablesCategorie"
                db.OpenConn(Sql)
                db.ExecuteNonQuery()
                db.CloseConn()

                Sql = "Delete * From TemplateVariablesInPages"
                db.OpenConn(Sql)
                db.ExecuteNonQuery()
                db.CloseConn()

                Sql = "Delete * From TemplateVariablesInTemplate"
                db.OpenConn(Sql)
                db.ExecuteNonQuery()
                db.CloseConn()

            Else
                Sql = "Delete * From Templates WHERE idTemplate = " & idTemplate
                db.OpenConn(Sql)
                db.ExecuteNonQuery()
                db.CloseConn()

                Sql = "DELETE * From TemplateDetailAttributes WHERE idTemplateDetail IN (Select idTemplateDetail FROM TemplateDetailAttributes INNER JOIN TemplateDetails ON TemplateDetailAttributes.idTemplateDetail = TemplateDetails.id Where TemplateDetails.idTemplate = " & idTemplate & ")"
                db.OpenConn(Sql)
                db.ExecuteNonQuery()
                db.CloseConn()

                Sql = "Delete * From TemplateDetails WHERE idTemplate = " & idTemplate
                db.OpenConn(Sql)
                db.ExecuteNonQuery()
                db.CloseConn()

                'TODO......  da fare l'eliminazione in queste 3 tabelle in base all'id del template

                'Sql = "Delete * From TemplateVariablesCategorie"
                'db.OpenConn(Sql)
                'db.ExecuteNonQuery()
                'db.CloseConn()

                'Sql = "Delete * From TemplateVariablesList"
                'db.OpenConn(Sql)
                'db.ExecuteNonQuery()
                'db.CloseConn()

                'Sql = "Delete * From TemplateVariablesInPages"
                'db.OpenConn(Sql)
                'db.ExecuteNonQuery()
                'db.CloseConn()

                'Sql = "Delete * From TemplateVariablesInTemplate"
                'db.OpenConn(Sql)
                'db.ExecuteNonQuery()
                'db.CloseConn()
            End If
        End Sub

        Public Sub DeleteTemplates()
            DeleteTemplate()
        End Sub

        Public Function SalvaPagina(ByRef Pagina As _cmsPage, ByVal PannelloTV As PlaceHolder, Optional ByVal CheckIFPageExist As Boolean = False) As Long
            If CheckIFPageExist Then
                If Pagina.codPagina <= 0 Then
                    Pagina.codPagina = GetCodPaginaDaFolderPath(Pagina.FolderPath)
                    If Pagina.codPagina <= 0 Then
                        Pagina.NuovaPagina = True
                    Else
                        Pagina.NuovaPagina = False
                    End If
                End If
            End If

            With Pagina
                If Pagina.NuovaPagina Then
                    Sql = "SELECT Max(codPagina) + 1 As MaxCOD FROM Pagine Where IdLingua = " & .idLingua
                    db.OpenConn(Sql)
                    myReader = db.ExecuteReader

                    .codPagina = 1
                    While myReader.Read
                        .codPagina = IIf(IsDBNull(myReader("MaxCOD")), 1, myReader("MaxCOD"))
                    End While

                    myReader.Close()
                    db.CloseConn()

                    Sql = "INSERT INTO Pagine (codPagina, Titolo, idLingua, MetaDescription, TitoloH1, DataInserimento, DataUltimaModifica, idTemplate, LivelloVisibilita, Tipo, Content) VALUES (" & .codPagina & ", '" & .Titolo.Replace("'", "''") & "', " & .idLingua & ", '" & .MetaDescription.Replace("'", "''") & "', '" & .TitoloH1.Replace("'", "''") & "', #" & Month(Now()) & " / " & Day(Now()) & " / " & Year(Now()) & "#, #" & Month(Now()) & " / " & Day(Now()) & " / " & Year(Now()) & "#, " & .idTemplate & "," & .LivelloVisibilita & "," & .Tipo & ",'" & .HTMLPageContent.Replace("'", "''") & "');"

                    db.OpenConn(Sql)
                    db.ExecuteNonQuery()
                    db.CloseConn()

                    .idPagina = GetIDLastPage()

                    Dim tmpControlID As Long = 0

                    'Salvo le TV...
                    For Each controlTV As Control In PannelloTV.Controls
                        Try
                            If controlTV.ID.StartsWith(cmsTemplateVariablesTypes.TVPrefix) Then
                                'controlTV.ID = controlTV.ID.Replace(cmsTemplateVariablesTypes.TVPrefix, "")
                                tmpControlID = controlTV.ID.Replace(cmsTemplateVariablesTypes.TVPrefix, "")

                                If TypeOf controlTV Is TextBox Then SaveTVInPages(tmpControlID, .idPagina, CType(controlTV, TextBox).Text.Trim, "", Pagina.NuovaPagina)
                                'TODO cambiare FCKEditor
                                If TypeOf controlTV Is FredCK.FCKeditorV2.FCKeditor Then SaveTVInPages(tmpControlID, .idPagina, CType(controlTV, FredCK.FCKeditorV2.FCKeditor).Value.Trim, "", Pagina.NuovaPagina)
                                'TODO 
                                '-> Internazionalizzare il formato data
                                If TypeOf controlTV Is WebControls.Calendar Then SaveTVInPages(tmpControlID, .idPagina, CType(controlTV, WebControls.Calendar).SelectedDate.Date.ToString("dd/MM/yyyy"), "", Pagina.NuovaPagina)
                                'TODO da fare gli altri tipi...
                            End If
                        Catch
                            'Null reference.. System.NullReferenceException
                        End Try
                    Next
                Else

                    Sql = "UPDATE Pagine Set codPagina = " & .codPagina & ", Titolo = '" & .Titolo.Replace("'", "''") & "', idLingua = " & .idLingua & ", MetaDescription = '" & .MetaDescription.Replace("'", "''") & "', TitoloH1 = '" & .TitoloH1.Replace("'", "''") & "', DataUltimaModifica =  #" & Month(Now()) & " / " & Day(Now()) & " / " & Year(Now()) & "#, idTemplate = " & .idTemplate & ", LivelloVisibilita = " & .LivelloVisibilita & ", Tipo = " & .Tipo & ", Content = '" & .HTMLPageContent.Replace("'", "''") & "' "
                    Sql &= " WHERE idPagina = " & .idPagina

                    db.OpenConn(Sql)
                    db.ExecuteNonQuery()
                    db.CloseConn()

                    Dim tmpControlID As Long = 0

                    'Salvo le TV...

                    'TODO -> Eliminare Tutte le variabili associate al precedente Template se c'è stato un cambio di Template
                    'Tabella: TemplateVariableInPages -> Se si cambia Template rimangono le TV del precedente perchè il salvataggio crea nuovi record.

                    For Each controlTV As Control In PannelloTV.Controls
                        Try
                            If controlTV.ID.StartsWith(cmsTemplateVariablesTypes.TVPrefix) Then
                                'controlTV.ID = controlTV.ID.Replace(cmsTemplateVariablesTypes.TVPrefix, "")
                                tmpControlID = controlTV.ID.Replace(cmsTemplateVariablesTypes.TVPrefix, "")
                                If TypeOf controlTV Is TextBox Then SaveTVInPages(tmpControlID, .idPagina, CType(controlTV, TextBox).Text.Trim, "", Pagina.NuovaPagina)
                                'TODO cambiare editor
                                If TypeOf controlTV Is FredCK.FCKeditorV2.FCKeditor Then SaveTVInPages(tmpControlID, .idPagina, CType(controlTV, FredCK.FCKeditorV2.FCKeditor).Value.Trim, "", Pagina.NuovaPagina)
                                'TODO 
                                '-> Internazionalizzare il formato data
                                If TypeOf controlTV Is WebControls.Calendar Then SaveTVInPages(tmpControlID, .idPagina, CType(controlTV, WebControls.Calendar).SelectedDate.Date.ToString("dd/MM/yyyy"), "", Pagina.NuovaPagina)
                                'TODO da fare gli altri tipi...
                            End If
                        Catch
                            'Null reference.. System.NullReferenceException
                        End Try
                    Next
                End If

                Return .codPagina
            End With
        End Function

        Private Sub SaveTVInPages(ByVal idTVInTemplate As String, ByVal idPagina As Long, ByVal TVValue As String, ByVal TVParam As String, ByVal isNewPage As Boolean)
            TVValue = TVValue.Trim.Replace("'", "''")
            TVParam = TVParam.Trim.Replace("'", "''")

            If isNewPage Then
                Sql = "INSERT INTO TemplateVariablesInPages (idTemplateVariablesInTemplate, idPage, TVValue, Param) VALUES (" & idTVInTemplate & "," & idPagina & ",'" & TVValue & "','" & TVParam & "')"
            Else
                Sql = "DELETE * From TemplateVariablesInPages Where idTemplateVariablesInTemplate = " & idTVInTemplate & " AND idPage = " & idPagina & ""
                db.OpenConn(Sql)
                db.ExecuteNonQuery()
                db.CloseConn()

                Sql = "INSERT INTO TemplateVariablesInPages (idTemplateVariablesInTemplate, idPage, TVValue, Param) VALUES (" & idTVInTemplate & "," & idPagina & ",'" & TVValue & "','" & TVParam & "')"
            End If

            db.OpenConn(Sql)
            db.ExecuteNonQuery()
            db.CloseConn()
        End Sub

        Public Function CreaPathMenu(ByVal ProfonditaLivello As Long, ByVal codPaginaMadre As Long, ByVal Lingua As String, ByVal idLingua As Long, ByVal NomeVoceMenu As String) As String
            Dim tmpPath As String = ""

            NomeVoceMenu = NomeVoceMenu.Replace(" ", "-")

            If codPaginaMadre = 0 And ProfonditaLivello = 0 Then
                'Primo percorso...
                tmpPath = cmsPaths.PathPublic & Lingua & "\" & NomeVoceMenu & "\"
            Else
                If ProfonditaLivello = 1 Then
                    tmpPath = cmsPaths.PathPublic & Lingua & GetFolderPathCodPagina(codPaginaMadre, ProfonditaLivello, idLingua) & NomeVoceMenu & "\"
                Else
                    tmpPath = GetFolderPathCodPagina(codPaginaMadre, ProfonditaLivello - 1, idLingua) & NomeVoceMenu & "\"
                End If
            End If
            Return tmpPath
        End Function

        Public Function GetFolderPathFromCodPaginaAndIdLingua(ByVal codPagina As Long, ByVal idLingua As Long, Optional ByRef tmpDbCommand As OleDbCommand = Nothing, Optional ByRef tmpDbConnection As OleDbConnection = Nothing) As String
            'TODO verificare se questa funzione recupera path univoci, codPagina è univoco all'interno della tabella menu?

            Dim tmpPath As String = ""

            Sql = " SELECT folderpath FROM Menu Where codPagina = " & codPagina & " AND idLingua = " & idLingua & ";"

            If IsNothing(tmpDbConnection) Then
                db.OpenConn(Sql)
                myReader = db.ExecuteReader()
            Else
                db.OpenConn(Sql, , , True, tmpDbConnection, tmpDbCommand)
                myReader = db.ExecuteReader(True, tmpDbCommand)
            End If

            While myReader.Read
                tmpPath = myReader("folderpath")
                Exit While
            End While

            myReader.Close()
            If IsNothing(tmpDbConnection) Then db.CloseConn()

            Return tmpPath
        End Function

        Public Function GetFolderPathFromIdVoce(ByVal idVoce As Long) As String
            Dim tmpPath As String = ""

            Sql = " SELECT folderpath FROM Menu Where idVoce = " & idVoce & ";"

            db.OpenConn(Sql)
            myReader = db.ExecuteReader

            While myReader.Read
                tmpPath = myReader("folderpath")
            End While

            myReader.Close()
            db.CloseConn()

            Return tmpPath
        End Function

        Public Function GetFolderPathCodPagina(ByVal codPagina As Long, ByVal ProfonditaLivello As Long, ByVal idLingua As Long) As String
            Dim tmpPath As String = ""

            Sql = " SELECT folderpath FROM Menu Where codPagina = " & codPagina & " AND ProfonditaLivello = " & ProfonditaLivello & ";"

            db.OpenConn(Sql)
            myReader = db.ExecuteReader

            While myReader.Read
                tmpPath = myReader("folderpath")
            End While

            myReader.Close()
            db.CloseConn()

            Return tmpPath
        End Function


        Public Sub SalvaVoceMenu(ByRef Menu As _cmsVoceDiMenu, Optional ByVal CheckIFPageExist As Boolean = False)
            If CheckIFPageExist Then
                If Menu.idVoce <= 0 Then
                    If Menu.codPaginaMadre = 0 And Menu.ordine = 1 And Menu.ProfonditaLivello = 1 Then
                        Menu.folderpath = "\"
                    End If
                    Menu.idVoce = GetVoceMenuFromFolderPath(Menu.folderpath).idVoce
                    If Menu.idVoce <= 0 Then
                        Menu.NuovaPagina = True
                    Else
                        Menu.NuovaPagina = False
                    End If
                End If
            End If

            With Menu
                If Menu.NuovaPagina Then

                    If Menu.codPaginaMadre = 0 And Menu.ordine = 1 And Menu.ProfonditaLivello = 1 Then
                        .folderpath = "\"
                    End If

                    Sql = "INSERT INTO Menu (ProfonditaLivello,codPagina,DescrizioneBreveNelMenu,codPaginaMadre,idLingua,ordine,folderpath) VALUES (" & .ProfonditaLivello & "," & .codPagina & ",'" & .DescrizioneBreveNelMenu.Replace("'", "''") & "'," & .codPaginaMadre & "," & .idLingua & "," & .ordine & ",'" & .folderpath.Replace("'", "''") & "');"
                    db.OpenConn(Sql)

                    If myDir.DirectoryExist(.folderpath, True) = False Then
                        myDir.CreateDirectory(.folderpath, True)

                        myFile.CopyFile(cmsPaths.PathTemplatePage & cmsPaths.TemplatePageName, .folderpath & cmsPaths.TemplatePageName)
                        myFile.CopyFile(cmsPaths.PathTemplatePage & cmsPaths.TemplatePageCodeName, .folderpath & cmsPaths.TemplatePageCodeName)
                    End If
                    db.ExecuteNonQuery()
                    db.CloseConn()

                    'Recupero idVoce e lo assegno byref
                    Sql = "Select idVoce From Menu Where ProfonditaLivello = " & .ProfonditaLivello & " AND codPagina = " & .codPagina & " AND DescrizioneBreveNelMenu = '" & .DescrizioneBreveNelMenu.Replace("'", "''") & "' AND codPaginaMadre= " & .codPaginaMadre & " AND idLingua= " & .idLingua & " AND ordine= " & .ordine & " AND folderpath='" & .folderpath.Replace("'", "''") & "' "
                    db.OpenConn(Sql)

                    myReader = db.ExecuteReader
                    While myReader.Read
                        .idVoce = myReader("idVoce")
                    End While
                    myReader.Close()
                    db.CloseConn()

                Else

                    'TODO .... MODIFICARE IL PATH DELLA VOCE DI MENU....
                    If myDir.DirectoryExist(.folderpath, True) = False Then
                        myDir.CreateDirectory(.folderpath, True)

                        myFile.CopyFile(cmsPaths.PathTemplatePage & cmsPaths.TemplatePageName, .folderpath & cmsPaths.TemplatePageName)
                        myFile.CopyFile(cmsPaths.PathTemplatePage & cmsPaths.TemplatePageCodeName, .folderpath & cmsPaths.TemplatePageCodeName)
                    End If

                    Sql = "UPDATE Menu Set ProfonditaLivello = " & .ProfonditaLivello & ",codPagina= " & .codPagina & ",DescrizioneBreveNelMenu = '" & .DescrizioneBreveNelMenu.Replace("'", "''") & "',codPaginaMadre= " & .codPaginaMadre & ",idLingua= " & .idLingua & ",ordine=" & .ordine & ",folderpath= '" & .folderpath.Replace("'", "''") & "' WHERE idVoce = " & .idVoce & ";"
                    db.OpenConn(Sql)
                    db.ExecuteNonQuery()
                    db.CloseConn()
                End If
            End With
        End Sub

        Public Sub SalvaVoceMenuPerGallery(ByVal Menu As _cmsVoceDiMenu)
            With Menu
                If Menu.NuovaPagina Then
                    Sql = "INSERT INTO Menu (ProfonditaLivello,codPagina,DescrizioneBreveNelMenu,codPaginaMadre,idLingua,ordine,folderpath) VALUES (" & .ProfonditaLivello & "," & .codPagina & ",'" & .DescrizioneBreveNelMenu & "'," & .codPaginaMadre & "," & .idLingua & "," & .ordine & ",'" & .folderpath & "');"
                    db.OpenConn(Sql)
                Else
                    Sql = "UPDATE Menu Set ProfonditaLivello = " & .ProfonditaLivello & ",codPagina= " & .codPagina & ",DescrizioneBreveNelMenu = '" & .DescrizioneBreveNelMenu & "',codPaginaMadre= " & .codPaginaMadre & ",idLingua= " & .idLingua & ",ordine=" & .ordine & ",folderpath= '" & .folderpath & "' WHERE idVoce = " & .idVoce & ";"
                    db.OpenConn(Sql)
                End If
                db.ExecuteNonQuery()
                db.CloseConn()

                If myDir.DirectoryExist(cmsPaths.PathPublic & cmsLanguage.Lingua & "\" & cmsPaths.PathGallery & .folderpath & "\", True) = True Then
                    myFile.CopyFile(cmsPaths.PathTemplatePage & cmsPaths.TemplatePageName, cmsPaths.PathPublic & cmsLanguage.Lingua & "\" & cmsPaths.PathGallery & .folderpath & "\" & cmsPaths.TemplatePageName)
                    myFile.CopyFile(cmsPaths.PathTemplatePage & cmsPaths.TemplatePageCodeName, cmsPaths.PathPublic & cmsLanguage.Lingua & "\" & cmsPaths.PathGallery & .folderpath & "\" & cmsPaths.TemplatePageCodeName)
                End If

            End With
        End Sub

        Public Sub SpostaImmagineInGallery(ByVal idImmagine As Long, ByVal NuovaPosizione As Long)
            'se NuovaPosizione = -1 allora l'immagine è da eliminare.

            Dim PosizioneAttuale As Long
            Dim idGallery As Long

            'Recupero i dati...
            db.OpenConn("Select * From Images Where id = " & idImmagine)
            myReader = db.ExecuteReader

            myReader.Read()
            PosizioneAttuale = myReader("Posizione")
            idGallery = myReader("idGallery")
            myReader.Close()
            db.CloseConn()

            'Sposto...
            If NuovaPosizione = PosizioneAttuale Then Exit Sub

            If NuovaPosizione = -1 Then
                'Sto eliminando l'immagine, aggiorno tutte le posizioni
                db.OpenConn("Update Images Set Posizione = Posizione - 1 Where idGallery = " & idGallery & " AND (Posizione > " & PosizioneAttuale & ")")
            Else
                If NuovaPosizione < PosizioneAttuale Then
                    'Modifico le posizioni...
                    db.OpenConn("Update Images Set Posizione = Posizione + 1 Where idGallery = " & idGallery & " AND ((Posizione >= " & NuovaPosizione & ") AND (Posizione < " & PosizioneAttuale & "))")
                Else
                    db.OpenConn("Update Images Set Posizione = Posizione - 1 Where idGallery = " & idGallery & " AND ((Posizione > " & PosizioneAttuale & ") AND (Posizione <= " & NuovaPosizione & "))")
                End If
            End If

            db.ExecuteScalar()
            db.CloseConn()

            'Salvo la nuova posizione...
            db.OpenConn("Update Images Set Posizione = " & NuovaPosizione & " WHERE id = " & idImmagine)
            db.ExecuteScalar()
            db.CloseConn()

        End Sub

        Public Sub AddNewCategoriaChunk(ByVal NomeCategoria As String)
            NomeCategoria = NomeCategoria.Trim
            If ChunkCategoriaExist(NomeCategoria) = False Then
                Sql = "INSERT INTO ChunkCategorie (NomeCategoria) VALUES ('" & NomeCategoria & "')"
                db.OpenConn(Sql)
                db.ExecuteNonQuery()
                db.CloseConn()
            End If
        End Sub

        Public Sub EditCategoriaChunk(ByVal idCategoria As Long, ByVal NomeCategoria As String)
            NomeCategoria = NomeCategoria.Trim

            Sql = "Update ChunkCategorie Set NomeCategoria = '" & NomeCategoria & "' Where idCategoria = " & idCategoria
            db.OpenConn(Sql)
            db.ExecuteNonQuery()
            db.CloseConn()
        End Sub

        Public Sub EditCategoriaTV(ByVal idCategoria As Long, ByVal NomeCategoria As String)
            NomeCategoria = NomeCategoria.Trim

            Sql = "Update TemplateVariablesCategorie Set NomeCategoria = '" & NomeCategoria & "' Where idCategoria = " & idCategoria
            db.OpenConn(Sql)
            db.ExecuteNonQuery()
            db.CloseConn()
        End Sub

        Public Sub AddNewCategoriaTemplateVariable(ByVal NomeCategoria As String)
            NomeCategoria = NomeCategoria.Trim
            If ChunkCategoriaExist(NomeCategoria) = False Then
                Sql = "INSERT INTO TemplateVariablesCategorie (NomeCategoria) VALUES ('" & NomeCategoria & "')"
                db.OpenConn(Sql)
                db.ExecuteNonQuery()
                db.CloseConn()
            End If
        End Sub

        Public Sub UpdateImmaginePagine(ByVal Immagine As _cms_Immagine, Optional ByVal IsImageSlideShow As Boolean = False)
            If IsImageSlideShow Then
                Sql = "UPDATE ImmaginiPagine Set codPagina=" & Immagine.codPagina & ", IMGsrc='" & Immagine.IMGsrc & "',IMGalt='" & Immagine.IMGalt & "',IMGtitle='" & Immagine.IMGtitle & "',SlideTitolo='" & Immagine.SlideTitolo & "',SlideDescrizione='" & Immagine.SlideDescrizione & "' Where IdImmagine = " & Immagine.idImmagine
            Else
                Sql = "UPDATE ImmaginiPagine Set codPagina=" & Immagine.codPagina & ",Aid='" & Immagine.Aid & "',Aclass='" & Immagine.Aclass & "',Ahref='" & Immagine.Ahref & "',ADescrizione='" & Immagine.ADescrizione & "',IMGsrc='" & Immagine.IMGsrc & "',IMGalt='" & Immagine.IMGalt & "',IMGtitle='" & Immagine.IMGtitle & "',IMGclass='" & Immagine.IMGclass & "' Where IdImmagine = " & Immagine.idImmagine
            End If

            db.OpenConn(Sql)
            db.ExecuteNonQuery()
            db.CloseConn()
        End Sub

        Public Sub LoadChkTemplateList(ByVal Pannello As Panel)
            Sql = "Select * From Templates Order By Nome"

            Pannello.Controls.Clear()

            Dim titleSelTemplate As String = GetGlobalResourceObject("Admin", "litSelChkTemplate")
            Dim tmpTitleTemplate As New LiteralControl
            tmpTitleTemplate.Text = "<div class=""label""><label>" & titleSelTemplate & "</label></div>"

            Pannello.Controls.Add(tmpTitleTemplate)
            Pannello.Controls.Add(New LiteralControl("<div class=""input"">"))

            db.OpenConn(Sql)
            myReader = db.ExecuteReader
            While myReader.Read
                Dim tmpCheck As New CheckBox
                'tmpCheck.ID = "chk" & myReader("idTemplate")
                tmpCheck.ID = myReader("idTemplate")
                tmpCheck.Text = myReader("Nome")
                Pannello.Controls.Add(tmpCheck)
                Pannello.Controls.Add(New LiteralControl("<br />"))
            End While
            myReader.Close()
            db.CloseConn()

            Pannello.Controls.Add(New LiteralControl("</div>"))

        End Sub

        Public Function CreateImgTooltip(ByVal Caption As String, ByVal HelpMessage As String) As String
            Dim retValue As String = ""
            retValue = "<img src=""img/icons/tooltip-baloon.png"" class=""css_tooltip"" title=""<div><span></span><h2>" & Caption & "</h2><p>" & HelpMessage & "</p></div>"" alt=""" & Caption & """ />"
            Return retValue
        End Function

        Public Sub LoadTVListFromTemplate(ByVal panelControlli As PlaceHolder, ByVal idTemplate As Long, ByVal idPage As Long, ByVal isEditMode As Boolean, ByVal LoadOnlyControls As Boolean)
            If isEditMode Then
                Sql = " SELECT TemplateVariablesList.Name, TemplateVariablesList.Caption, TemplateVariablesList.Description, TemplateVariablesList.Type, TemplateVariablesInTemplate.idTemplate, TemplateVariablesInTemplate.TVOrderInTemplate, TemplateVariablesInTemplate.idTemplateVariablesInTemplate, TemplateVariablesInPages.idPage, TemplateVariablesInPages.TVValue, TemplateVariablesInPages.Param"
                Sql &= " FROM (TemplateVariablesCategorie INNER JOIN (TemplateVariablesInTemplate INNER JOIN TemplateVariablesList ON TemplateVariablesInTemplate.idTemplateVariablesList = TemplateVariablesList.idTV) ON TemplateVariablesCategorie.idCategoria = TemplateVariablesList.idTVCategoria) INNER JOIN TemplateVariablesInPages ON TemplateVariablesInTemplate.idTemplateVariablesInTemplate = TemplateVariablesInPages.idTemplateVariablesInTemplate"
                Sql &= " WHERE(TemplateVariablesInTemplate.idTemplate = " & idTemplate & " And TemplateVariablesInPages.idPage = " & idPage & ")"
                Sql &= " ORDER BY TemplateVariablesInTemplate.TVOrderInTemplate;"
                'Sql &= " Order By TemplateVariablesList.idTV"

            Else
                Sql = " SELECT TemplateVariablesList.Name, TemplateVariablesList.Caption, TemplateVariablesList.Description, "
                Sql &= " TemplateVariablesList.Type, TemplateVariablesInTemplate.idTemplate, TemplateVariablesInTemplate.TVOrderInTemplate, TemplateVariablesInTemplate.idTemplateVariablesInTemplate "
                Sql &= " FROM TemplateVariablesCategorie INNER JOIN (TemplateVariablesInTemplate "
                Sql &= " INNER JOIN TemplateVariablesList ON TemplateVariablesInTemplate.idTemplateVariablesList = TemplateVariablesList.idTV) "
                Sql &= " ON TemplateVariablesCategorie.idCategoria = TemplateVariablesList.idTVCategoria "
                Sql &= " WHERE idTemplate = " & idTemplate
                Sql &= " Order By TVOrderInTemplate"
                'Sql &= " Order By TemplateVariablesList.idTV"
            End If

            With panelControlli
                .Controls.Clear()

                db.OpenConn(Sql)
                myReader = db.ExecuteReader

                Dim tmpIDCounter As Long = 100000

                While myReader.Read
                    Dim tmpName As New LiteralControl
                    tmpName.ID = tmpIDCounter : tmpIDCounter += 1

                    'If Not LoadOnlyControls  Then
                    tmpName.Text = " > " & myReader("Name") & ":" & myReader("TVOrderInTemplate")
                    'End If

                    Dim tmpType As Long = myReader("Type")

                    Dim idTV As String = ""

                    With cmsTemplateVariablesTypes


                        Select Case tmpType
                            Case .TextID
                                Dim tmpHTMLLit As New LiteralControl
                                tmpHTMLLit.ID = tmpIDCounter : tmpIDCounter += 1
                                panelControlli.Controls.Add(tmpHTMLLit)
                                'If Not LoadOnlyControls Then
                                tmpHTMLLit.Text = "<div class=""form""><div class=""label""><label>"
                                'End If


                            Case .TextAreaID
                                Dim tmpHTMLLit As New LiteralControl
                                tmpHTMLLit.ID = tmpIDCounter : tmpIDCounter += 1
                                panelControlli.Controls.Add(tmpHTMLLit)
                                'If Not LoadOnlyControls Then
                                tmpHTMLLit.Text = "<div class=""form""><div class=""label""><label>"
                                'End If


                            Case .TextAreaEditorID
                                Dim tmpHTMLLit As New LiteralControl
                                tmpHTMLLit.ID = tmpIDCounter : tmpIDCounter += 1
                                panelControlli.Controls.Add(tmpHTMLLit)
                                'If Not LoadOnlyControls Then
                                tmpHTMLLit.Text = "<div class=""field fck""><div class=""label""><label>"
                                'End If


                            Case .ImageID
                                Dim tmpHTMLLit As New LiteralControl
                                tmpHTMLLit.ID = tmpIDCounter : tmpIDCounter += 1
                                panelControlli.Controls.Add(tmpHTMLLit)
                                'If Not LoadOnlyControls Then
                                tmpHTMLLit.Text = "<div class=""form""><div class=""label""><label>"
                                'End If


                            Case .LinkID
                                Dim tmpHTMLLit As New LiteralControl
                                tmpHTMLLit.ID = tmpIDCounter : tmpIDCounter += 1
                                panelControlli.Controls.Add(tmpHTMLLit)
                                'If Not LoadOnlyControls Then
                                tmpHTMLLit.Text = "<div class=""form""><div class=""label""><label>"
                                'End If


                            Case .VideoID
                            Case .NumberID
                                Dim tmpHTMLLit As New LiteralControl
                                tmpHTMLLit.ID = tmpIDCounter : tmpIDCounter += 1
                                panelControlli.Controls.Add(tmpHTMLLit)
                                'If Not LoadOnlyControls Then
                                tmpHTMLLit.Text = "<div class=""form""><div class=""label""><label>"
                                'End If


                            Case .DateID
                                'http://flowplayer.org/tools/demos/dateinput/localize.html

                                Dim tmpHTMLLit As New LiteralControl
                                tmpHTMLLit.ID = tmpIDCounter : tmpIDCounter += 1
                                panelControlli.Controls.Add(tmpHTMLLit)
                                'If Not LoadOnlyControls Then
                                tmpHTMLLit.Text = "<div class=""form date""><div class=""label""><label>"
                                'End If


                        End Select

                    End With

                    idTV = cmsTemplateVariablesTypes.TVPrefix & myReader("idTemplateVariablesInTemplate")

                    Dim tmpCaption As New LiteralControl
                    tmpCaption.ID = "tmpCaption" & idTV
                    .Controls.Add(tmpCaption)
                    'If Not LoadOnlyControls Then
                    tmpCaption.Text = myReader("Caption")
                    'End If


                    '.Controls.Add(tmpName)

                    Dim tmpLit As New LiteralControl
                    tmpLit.ID = tmpIDCounter : tmpIDCounter += 1
                    .Controls.Add(tmpLit)
                    'If Not LoadOnlyControls Then
                    tmpLit.Text = "</label></div>"
                    'End If

                    Dim tmpDescription As New LiteralControl
                    tmpDescription.ID = "tmpDescription" & idTV
                    .Controls.Add(tmpDescription)
                    'If Not LoadOnlyControls Then
                    tmpDescription.Text = "<div class=""baloon"">" & CreateImgTooltip(tmpCaption.Text, myReader("Description")) & "</div>"
                    'End If

                    tmpLit = New LiteralControl
                    tmpLit.ID = tmpIDCounter : tmpIDCounter += 1
                    .Controls.Add(tmpLit)
                    'If Not LoadOnlyControls Then
                    tmpLit.Text = "<div class=""input"">"
                    'End If

                    With cmsTemplateVariablesTypes

                        Select Case tmpType
                            Case .TextID
                                Dim tmpText As New TextBox
                                tmpText.ID = idTV
                                panelControlli.Controls.Add(tmpText)
                                If Not LoadOnlyControls And isEditMode Then
                                    tmpText.Text = IIf(IsDBNull(myReader("TVValue")), "", myReader("TVValue"))
                                End If


                            Case .TextAreaID
                                Dim tmpText As New TextBox
                                tmpText.ID = idTV
                                panelControlli.Controls.Add(tmpText)
                                If Not LoadOnlyControls And isEditMode Then
                                    tmpText.TextMode = TextBoxMode.MultiLine
                                    tmpText.Text = IIf(IsDBNull(myReader("TVValue")), "", myReader("TVValue"))
                                End If


                            Case .TextAreaEditorID
                                'Dim tmpText As New TextBox
                                'tmpText.ID = idTV
                                'tmpText.TextMode = TextBoxMode.MultiLine
                                'editAreaJS &= CreateEditAreaJavascript(tmpText.ClientID)

                                'TODO
                                'Dim myfck As New FredCK.FCKeditorV2.FCKeditor
                                'myfck.ID = idTV

                                'panelControlli.Controls.Add(myfck)

                                'myfck.UseBROnCarriageReturn = True
                                'myfck.Height = 400
                                'myfck.Width = 600
                                'myfck.ToolbarSet = "Jertix"

                                'If Not LoadOnlyControls And isEditMode Then
                                '    myfck.Value = IIf(IsDBNull(myReader("TVValue")), "", myReader("TVValue"))
                                'End If


                            Case .ImageID
                                Dim tmpImg As New FileUpload
                                tmpImg.ID = idTV

                                panelControlli.Controls.Add(tmpImg)
                            Case .LinkID
                                Dim tmpText As New TextBox
                                tmpText.ID = idTV
                                panelControlli.Controls.Add(tmpText)
                                If Not LoadOnlyControls And isEditMode Then
                                    tmpText.Text = IIf(IsDBNull(myReader("TVValue")), "", myReader("TVValue"))
                                End If


                            Case .VideoID
                            Case .NumberID
                                Dim tmpText As New TextBox
                                tmpText.ID = idTV
                                panelControlli.Controls.Add(tmpText)
                                If Not LoadOnlyControls And isEditMode Then
                                    tmpText.Text = IIf(IsDBNull(myReader("TVValue")), "", myReader("TVValue"))
                                End If


                            Case .DateID
                                'Dim myDate As New WebControls.Calendar
                                'myDate.ID = idTV
                                'panelControlli.Controls.Add(myDate)
                                'If Not LoadOnlyControls And isEditMode Then
                                '    myDate.SelectionMode = CalendarSelectionMode.Day
                                '    myDate.VisibleDate = Now
                                '    myDate.SelectedDate = Now
                                '    myDate.TodaysDate = Now

                                '    'TODO -> Il formato delle date va internazionalizzato...
                                '    Try
                                '        myDate.SelectedDate = CType(IIf(IsDBNull(myReader("TVValue")), "", myReader("TVValue")), Date)
                                '    Catch
                                '    End Try
                                'End If


                                Dim tmpText As New TextBox
                                tmpText.ID = idTV
                                panelControlli.Controls.Add(tmpText)
                                If Not LoadOnlyControls And isEditMode Then
                                    tmpText.Text = IIf(IsDBNull(myReader("TVValue")), "", myReader("TVValue"))
                                End If

                        End Select

                    End With

                    tmpLit = New LiteralControl
                    tmpLit.ID = tmpIDCounter : tmpIDCounter += 1
                    .Controls.Add(tmpLit)
                    'If Not LoadOnlyControls Then
                    tmpLit.Text = "</div>"
                    'End If

                    tmpLit = New LiteralControl
                    tmpLit.ID = tmpIDCounter : tmpIDCounter += 1
                    .Controls.Add(tmpLit)
                    'If Not LoadOnlyControls Then
                    tmpLit.Text = "<div class=""clear""></div>"

                    tmpLit = New LiteralControl
                    tmpLit.ID = tmpIDCounter : tmpIDCounter += 1
                    .Controls.Add(tmpLit)
                    'If Not LoadOnlyControls Then
                    tmpLit.Text = "</div>"
                    'End If


                End While

                myReader.Close()
                db.CloseConn()
            End With
        End Sub

        Function GenerateHTMLTabasList(ByVal ListTabsCommaSeparated As String) As String
            Dim retValue As String = ""
            Dim tmpArr() As String = ListTabsCommaSeparated.Split(",")

            For Each tabName As String In tmpArr
                retValue &= "<li><a href=""#"">" & tabName & "</a></li>" & vbCrLf
            Next

            Return retValue
        End Function

        Private Function GetIDLastPage() As Long
            Sql = "Select Max(idPagina) From Pagine"
            Dim retValue As Long = 0
            db.OpenConn(Sql)
            retValue = db.ExecuteScalar
            db.CloseConn()

            Return retValue
        End Function

        Public Function GetHomePageByLanguageName(ByVal LanguageName As String, Optional ByRef tmpDbCommand As OleDbCommand = Nothing, Optional ByRef tmpDbConnection As OleDbConnection = Nothing) As _cmsPage
            Dim idLanguage As Long = GetIdLanguageFromName(LanguageName, tmpDbCommand, tmpDbConnection)
            Dim tmpPage As New _cmsPage

            Sql = "Select * from Menu Where folderpath = ""\"" AND idLingua = " & idLanguage

            If IsNothing(tmpDbConnection) Then
                db.OpenConn(Sql)
                myReader = db.ExecuteReader()
            Else
                db.OpenConn(Sql, , , True, tmpDbConnection, tmpDbCommand)
                myReader = db.ExecuteReader(True, tmpDbCommand)
            End If

            While myReader.Read
                With tmpPage
                    .codPagina = myReader("codPagina")
                    .VoceDiMenu = myReader("DescrizioneBreveNelMenu")
                    .idVoce = myReader("idVoce")
                End With
                Exit While
            End While

            myReader.Close()
            If IsNothing(tmpDbConnection) Then db.CloseConn()

            Sql = "Select * from Pagine Where codPagina = " & tmpPage.codPagina & " AND idLingua = " & idLanguage

            If IsNothing(tmpDbConnection) Then
                db.OpenConn(Sql)
                myReader = db.ExecuteReader()
            Else
                db.OpenConn(Sql, , , True, tmpDbConnection, tmpDbCommand)
                myReader = db.ExecuteReader(True, tmpDbCommand)
            End If

            While myReader.Read
                With tmpPage
                    .idPagina = myReader("idPagina")
                    .Titolo = myReader("Titolo")
                    .idTemplate = myReader("idTemplate")
                End With
                Exit While
            End While

            myReader.Close()
            If IsNothing(tmpDbConnection) Then db.CloseConn()

            Return tmpPage
        End Function

        Function GetVoceMenuFromIdVoce(ByVal idVoceDiMenu As Long) As String
            Dim retValue As String = ""
            Sql = " Select DescrizioneBreveNelMenu From Menu Where idVoce = " & idVoceDiMenu

            db.OpenConn(Sql)
            myReader = db.ExecuteReader

            While myReader.Read
                retValue = myReader("DescrizioneBreveNelMenu")
            End While
            myReader.Close()
            db.CloseConn()

            Return retValue
        End Function

        Private Function GenerateHTMLMenuTVListByCategory(ByRef jQueryFunctions As String, ByRef HTMLContextMenu As String, ByVal idCategory As Long, ByRef TVCategoryInfo As _cmsTVCategoryInfo) As String
            'Imposta tutto ByREF
            Dim retValue As String = ""

            Dim tmpDbCommand As New OleDbCommand
            Dim tmpDbConnection As New OleDbConnection
            Dim tmpReader As OleDbDataReader

            Dim sqlString As String = ""
            sqlString = "Select * From TemplateVariablesList WHERE idTVCategoria = " & idCategory & " Order By Name"

            db.OpenConn(sqlString, "", "", True, tmpDbConnection, tmpDbCommand)
            tmpReader = db.ExecuteReader(True, tmpDbCommand)

            Dim HTMLMenu As String = ""

            HTMLMenu &= "<ul>"

            Dim tmpjQueryFunctions As String = ""
            tmpjQueryFunctions &= "<script type=""text/javascript"">$(document).ready( function() {" & vbCrLf

            With TVCategoryInfo
                .idCategory = idCategory
                .NumberOfTVs = 0
            End With

            While tmpReader.Read
                TVCategoryInfo.NumberOfTVs += 1

                HTMLMenu &= "<li id=""tvVar" & tmpReader("idTV") & """><span class=""folder""><a href=""EditTemplateVariable.aspx?id=" & tmpReader("idTV") & "&amp;category=" & idCategory & """>" & tmpReader("Name") & "</a></span></li>" & vbCrLf
                tmpjQueryFunctions &= "  $(""#tvVar" & tmpReader("idTV") & """).contextMenu({menu: 'mnutvVar" & tmpReader("idTV") & "'},{menu: 'mnutvVar" & tmpReader("idTV") & "'});" & vbCrLf

                HTMLContextMenu &= "<ul id=""mnutvVar" & tmpReader("idTV") & """ class=""contextMenu"">" & vbCrLf
                HTMLContextMenu &= "<li class=""current""><span>TV: " & tmpReader("Name") & "</span></li>" & vbCrLf
                HTMLContextMenu &= "<li class=""cut""><a href=""EditTemplateVariable.aspx?id=" & tmpReader("idTV") & "&amp;category=" & idCategory & """>Modifica -> " & tmpReader("Name") & "</a></li>" & vbCrLf
                HTMLContextMenu &= "<li class=""copy""><a href=""DeleteTemplateVariable.aspx?id=" & tmpReader("idTV") & "&amp;category=" & idCategory & """>Elimina -> " & tmpReader("Name") & "</a></li>" & vbCrLf
                HTMLContextMenu &= "</ul>" & vbCrLf
            End While


            HTMLMenu &= "</ul>" & vbCrLf
            tmpjQueryFunctions &= "  });" & vbCrLf & "</script>" & vbCrLf

            tmpReader.Close()
            db.CloseConn(True, tmpDbConnection)

            If TVCategoryInfo.NumberOfTVs > 0 Then
                jQueryFunctions &= tmpjQueryFunctions
            End If

            retValue = HTMLMenu
            Return retValue
        End Function


        Private Function GenerateHTMLMenuTemplateVariablesList(ByRef jQueryFunctions As String, ByRef HTMLContextMenu As String, Optional ByRef tmpDbCommand As OleDbCommand = Nothing, Optional ByRef tmpDbConnection As OleDbConnection = Nothing) As String
            'Imposta tutto ByREF
            Dim retValue As String = ""

            'Dim tmpDbCommand As New OleDbCommand
            'Dim tmpDbConnection As New OleDbConnection
            Dim tmpReader As OleDbDataReader

            Dim tmpjQueryFunctions As String = ""
            Dim tmpHTMLContextMenu As String = ""

            Dim sqlString As String = ""
            sqlString = "Select * From TemplateVariablesCategorie Order By NomeCategoria"

            db.OpenConn(sqlString, "", "", True, tmpDbConnection, tmpDbCommand)
            tmpReader = db.ExecuteReader(True, tmpDbCommand)

            Dim HTMLMenu As String = ""

            HTMLMenu &= "<ul>" & vbCrLf
            tmpjQueryFunctions &= "<script type=""text/javascript"">$(document).ready( function() {" & vbCrLf

            Dim tmpTVCategoryInfo As _cmsTVCategoryInfo

            Dim tmpMenu As String = ""

            Dim tmpClass1 As String = ""
            Dim tmpClass2 As String = ""

            While tmpReader.Read
                tmpMenu = GenerateHTMLMenuTVListByCategory(jQueryFunctions, HTMLContextMenu, tmpReader("idCategoria"), tmpTVCategoryInfo)

                tmpClass1 = IIf(tmpTVCategoryInfo.NumberOfTVs > 0, "class=""closed"" ", "")
                tmpClass2 = IIf(tmpTVCategoryInfo.NumberOfTVs > 0, "folder", "file")

                If tmpTVCategoryInfo.NumberOfTVs = 0 Then tmpMenu = ""

                HTMLMenu &= "<li " & tmpClass1 & "id=""tvCategory" & tmpReader("idCategoria") & """><span class=""" & tmpClass2 & """><a href=""EditTVCategory.aspx?id=" & tmpReader("idCategoria") & """>" & tmpReader("NomeCategoria") & "</a></span>" & tmpMenu & "</li>" & vbCrLf
                tmpjQueryFunctions &= "  $(""#tvCategory" & tmpReader("idCategoria") & """).contextMenu({menu: 'mnutvCategory" & tmpReader("idCategoria") & "'},{menu: 'mnutvCategory" & tmpReader("idCategoria") & "'});" & vbCrLf

                tmpHTMLContextMenu &= "<ul id=""mnutvCategory" & tmpReader("idCategoria") & """ class=""contextMenu"">" & vbCrLf
                tmpHTMLContextMenu &= "<li class=""current""><span>Categoria: " & tmpReader("NomeCategoria") & "</span></li>" & vbCrLf
                tmpHTMLContextMenu &= "<li class=""edit separator""><a href=""AddTemplateVariable.aspx?idCat=" & tmpReader("idCategoria") & """>Aggiungi TV</a></li>" & vbCrLf
                tmpHTMLContextMenu &= "<li class=""cut""><a href=""EditTVCategory.aspx?id=" & tmpReader("idCategoria") & """>Modifica -> " & tmpReader("NomeCategoria") & "</a></li>" & vbCrLf
                tmpHTMLContextMenu &= "<li class=""copy""><a href=""DeleteTVCategory.aspx?id=" & tmpReader("idCategoria") & """>Elimina -> " & tmpReader("NomeCategoria") & "</a></li>" & vbCrLf
                tmpHTMLContextMenu &= "</ul>" & vbCrLf

                HTMLContextMenu &= tmpHTMLContextMenu
            End While

            HTMLMenu &= "</ul>" & vbCrLf
            tmpjQueryFunctions &= "  });" & vbCrLf & "</script>" & vbCrLf

            jQueryFunctions &= tmpjQueryFunctions

            tmpReader.Close()
            db.CloseConn(True, tmpDbConnection)

            retValue = HTMLMenu
            Return retValue
        End Function

        Private Function GenerateHTMLMenuChunksList(ByRef jQueryFunctions As String, ByRef HTMLContextMenu As String, Optional ByRef tmpDbCommand As OleDbCommand = Nothing, Optional ByRef tmpDbConnection As OleDbConnection = Nothing) As String
            'Imposta tutto ByREF
            Dim retValue As String = ""

            'Dim tmpDbCommand As New OleDbCommand
            'Dim tmpDbConnection As New OleDbConnection
            Dim tmpReader As OleDbDataReader

            Dim tmpjQueryFunctions As String = ""
            Dim tmpHTMLContextMenu As String = ""

            Dim sqlString As String = ""
            sqlString = "Select * From ChunkCategorie Order By NomeCategoria"

            db.OpenConn(sqlString, "", "", True, tmpDbConnection, tmpDbCommand)
            tmpReader = db.ExecuteReader(True, tmpDbCommand)

            Dim HTMLMenu As String = ""

            HTMLMenu &= "<ul>" & vbCrLf
            tmpjQueryFunctions &= "<script type=""text/javascript"">$(document).ready( function() {" & vbCrLf

            Dim tmpChunkCategoryInfo As _cmsChunksCategoryInfo

            Dim tmpMenu As String = ""

            Dim tmpClass1 As String = ""
            Dim tmpClass2 As String = ""

            While tmpReader.Read
                tmpMenu = GenerateHTMLMenuChunksListByCategory(jQueryFunctions, HTMLContextMenu, tmpReader("idCategoria"), tmpChunkCategoryInfo)

                tmpClass1 = IIf(tmpChunkCategoryInfo.NumberOfChunks > 0, "class=""closed"" ", "")
                tmpClass2 = IIf(tmpChunkCategoryInfo.NumberOfChunks > 0, "folder", "file")

                If tmpChunkCategoryInfo.NumberOfChunks = 0 Then tmpMenu = ""

                HTMLMenu &= "<li " & tmpClass1 & "id=""chunkCategory" & tmpReader("idCategoria") & """><span class=""" & tmpClass2 & """><a href=""EditChunkCategory.aspx?id=" & tmpReader("idCategoria") & """>" & tmpReader("NomeCategoria") & "</a></span>" & tmpMenu & "</li>" & vbCrLf

                tmpjQueryFunctions &= "  $(""#chunkCategory" & tmpReader("idCategoria") & """).contextMenu({menu: 'mnuchunkCategory" & tmpReader("idCategoria") & "'},{menu: 'mnuchunkCategory" & tmpReader("idCategoria") & "'});" & vbCrLf

                tmpHTMLContextMenu = "<ul id=""mnuchunkCategory" & tmpReader("idCategoria") & """ class=""contextMenu"">" & vbCrLf
                tmpHTMLContextMenu &= "<li class=""current""><span>Categoria: " & tmpReader("NomeCategoria") & "</span></li>" & vbCrLf
                tmpHTMLContextMenu &= "<li class=""edit separator""><a href=""Addchunk.aspx?idCat=" & tmpReader("idCategoria") & """>Aggiungi Chunk</a></li>" & vbCrLf
                tmpHTMLContextMenu &= "<li class=""cut""><a href=""EditChunkCategory.aspx?id=" & tmpReader("idCategoria") & """>Modifica -> " & tmpReader("NomeCategoria") & "</a></li>" & vbCrLf
                tmpHTMLContextMenu &= "<li class=""copy""><a href=""DeleteChunkCategory.aspx?id=" & tmpReader("idCategoria") & """>Elimina -> " & tmpReader("NomeCategoria") & "</a></li>" & vbCrLf
                tmpHTMLContextMenu &= "</ul>" & vbCrLf

                'jQueryFunctions &= tmpjQueryFunctions
                HTMLContextMenu &= tmpHTMLContextMenu
            End While

            HTMLMenu &= "</ul>" & vbCrLf
            tmpjQueryFunctions &= "  });" & vbCrLf & "</script>" & vbCrLf

            jQueryFunctions &= tmpjQueryFunctions

            tmpReader.Close()
            db.CloseConn(True, tmpDbConnection)

            retValue = HTMLMenu
            Return retValue
        End Function

        Private Function GenerateHTMLMenuChunksListByCategory(ByRef jQueryFunctions As String, ByRef HTMLContextMenu As String, ByVal idCategory As Long, ByRef ChunkCategoryInfo As _cmsChunksCategoryInfo) As String
            'Imposta tutto ByREF
            Dim retValue As String = ""

            Dim tmpDbCommand As New OleDbCommand
            Dim tmpDbConnection As New OleDbConnection
            Dim tmpReader As OleDbDataReader

            Dim sqlString As String = ""
            sqlString = "Select * From Chunks WHERE idCategoria = " & idCategory & " Order By NomeVariabile "

            db.OpenConn(sqlString, "", "", True, tmpDbConnection, tmpDbCommand)
            tmpReader = db.ExecuteReader(True, tmpDbCommand)

            Dim HTMLMenu As String = ""
            HTMLMenu &= "<ul>"

            Dim tmpjQueryFunctions As String = ""
            tmpjQueryFunctions &= "<script type=""text/javascript"">$(document).ready( function() {" & vbCrLf

            With ChunkCategoryInfo
                .idCategory = idCategory
                .NumberOfChunks = 0
            End With

            While tmpReader.Read
                ChunkCategoryInfo.NumberOfChunks += 1

                HTMLMenu &= "<li id=""chunkVar" & tmpReader("idVariabile") & """><span class=""file""><a href=""EditChunkVariable.aspx?id=" & tmpReader("idVariabile") & "&amp;category=" & idCategory & """>" & tmpReader("NomeVariabile") & "</a></span></li>" & vbCrLf
                tmpjQueryFunctions &= "  $(""#chunkVar" & tmpReader("idVariabile") & """).contextMenu({menu: 'mnuchunkVar" & tmpReader("idVariabile") & "'},{menu: 'mnuchunkVar" & tmpReader("idVariabile") & "'});" & vbCrLf

                HTMLContextMenu &= "<ul id=""mnuchunkVar" & tmpReader("idVariabile") & """ class=""contextMenu"">" & vbCrLf
                HTMLContextMenu &= "<li class=""current""><span>CHUNK VAR: " & tmpReader("NomeVariabile") & "</span></li>" & vbCrLf
                HTMLContextMenu &= "<li class=""cut""><a href=""EditChunkVariable.aspx?id=" & tmpReader("idVariabile") & "&amp;category=" & idCategory & """>Modifica -> " & tmpReader("NomeVariabile") & "</a></li>" & vbCrLf
                HTMLContextMenu &= "<li class=""copy""><a href=""DeleteChunk.aspx?id=" & tmpReader("idVariabile") & "&amp;category=" & idCategory & """>Elimina -> " & tmpReader("NomeVariabile") & "</a></li>" & vbCrLf
                HTMLContextMenu &= "</ul>" & vbCrLf
            End While


            HTMLMenu &= "</ul>" & vbCrLf
            tmpjQueryFunctions &= "  });" & vbCrLf & "</script>" & vbCrLf

            tmpReader.Close()
            db.CloseConn(True, tmpDbConnection)

            If ChunkCategoryInfo.NumberOfChunks > 0 Then
                jQueryFunctions &= tmpjQueryFunctions
            End If

            retValue = HTMLMenu
            Return retValue
        End Function

        Private Function GenerateHTMLMenuTemplateList(ByRef jQueryFunctions As String, ByRef HTMLContextMenu As String, Optional ByRef tmpDbCommand As OleDbCommand = Nothing, Optional ByRef tmpDbConnection As OleDbConnection = Nothing) As String
            'Imposta tutto ByREF
            Dim retValue As String = ""

            Sql = "Select idTemplate, Nome From Templates Order By Nome"

            If IsNothing(tmpDbConnection) Then
                db.OpenConn(Sql)
                myReader = db.ExecuteReader()
            Else
                db.OpenConn(Sql, , , True, tmpDbConnection, tmpDbCommand)
                myReader = db.ExecuteReader(True, tmpDbCommand)
            End If

            Dim HTMLMenu As String = ""

            HTMLMenu &= "<ul>" & vbCrLf
            jQueryFunctions &= "<script type=""text/javascript"">$(document).ready( function() {" & vbCrLf

            While myReader.Read
                HTMLMenu &= "<li id=""template" & myReader("idTemplate") & """><span class=""folder""><a href=""EditTemplate.aspx?id=" & myReader("idTemplate") & """>" & myReader("Nome") & "</a></span></li>" & vbCrLf
                jQueryFunctions &= "  $(""#template" & myReader("idTemplate") & """).contextMenu({menu: 'mnutemplate" & myReader("idTemplate") & "'},{menu: 'mnutemplate" & myReader("idTemplate") & "'});" & vbCrLf

                HTMLContextMenu &= "<ul id=""mnutemplate" & myReader("idTemplate") & """ class=""contextMenu"">" & vbCrLf
                HTMLContextMenu &= "<li class=""current""><span>Template: " & myReader("Nome") & "</span></li>" & vbCrLf
                HTMLContextMenu &= "<li class=""cut""><a href=""EditTemplate.aspx?id=" & myReader("idTemplate") & """>Modifica -> " & myReader("Nome") & "</a></li>" & vbCrLf
                HTMLContextMenu &= "<li class=""copy""><a href=""DeleteTemplate.aspx?id=" & myReader("idTemplate") & """>Elimina -> " & myReader("Nome") & "</a></li>" & vbCrLf
                HTMLContextMenu &= "</ul>" & vbCrLf
            End While


            HTMLMenu &= "</ul>" & vbCrLf
            jQueryFunctions &= "  });" & vbCrLf & "</script>" & vbCrLf

            myReader.Close()
            If IsNothing(tmpDbConnection) Then db.CloseConn()

            retValue = HTMLMenu
            Return retValue
        End Function

        Private Sub JertCMS_WriteAdminTreeLanguage(ByVal Language As String, ByRef HTMLMenu As String, ByRef HTMLContextMenu As String, ByRef jQueryFunctions As String, ByVal StartLevel As Long, ByVal MenuDepth As Long, ByVal tmpCODPaginaMadre As Long, Optional ByRef tmpDbCommand As OleDbCommand = Nothing, Optional ByRef tmpDbConnection As OleDbConnection = Nothing)
            'Tutto passato byREF

            Dim idLang As Long = GetIdLanguageFromName(Language)

            Dim Menu As _cms_MenuQueryStrings = cmsMenuQueryStrings
            Dim Param As _cms_MenuParameters = cmsMenuParameters

            Dim Sql As String = ""
            Sql = " SELECT * "
            Sql &= " FROM Pagine INNER JOIN Menu ON (Pagine.idLingua = Menu.idLingua) AND (Pagine.codPagina = Menu.codPagina) "
            Sql &= " WHERE (((Menu.ProfonditaLivello)=" & StartLevel & ") AND ((Menu.folderpath)<>""\"")) AND (codPaginaMadre = " & tmpCODPaginaMadre & ") AND (Menu.idLingua = " & idLang & " ) "
            Sql &= " ORDER BY Menu.ordine "

            'Dim tmpDbCommand As New OleDbCommand
            'Dim tmpDbConnection As New OleDbConnection
            Dim tmpReader As OleDbDataReader

            If IsNothing(tmpDbConnection) Then
                db.OpenConn(Sql)
                tmpReader = db.ExecuteReader()
            Else
                db.OpenConn(Sql, , , True, tmpDbConnection, tmpDbCommand)
                tmpReader = db.ExecuteReader(True, tmpDbCommand)
            End If

            Dim tmpMenu As New _cmsVoceDiMenu
            Dim tmpPage As New _cmsPage

            Dim tmpDepth As Long = 0

            HTMLMenu &= "<ul>"

            While tmpReader.Read
                With tmpMenu
                    .codPagina = tmpReader("Pagine.codPagina")
                    .codPaginaMadre = tmpReader("codPaginaMadre")
                    .DescrizioneBreveNelMenu = tmpReader("DescrizioneBreveNelMenu")
                    .folderpath = tmpReader("folderpath")
                    .idLingua = tmpReader("Pagine.idLingua")
                    .idVoce = tmpReader("idVoce")
                    '.NuovaPagina = False 
                    .ordine = tmpReader("ordine")
                    .ProfonditaLivello = tmpReader("ProfonditaLivello")
                    tmpDepth = .ProfonditaLivello

                    tmpPage.idPagina = tmpReader("idPagina")
                    'tmpPage.codPagina()
                    tmpPage.idTemplate = tmpReader("idTemplate")


                    Dim tmpQueryEdit As String
                    Dim tmpQueryAddPage As String

                    tmpQueryEdit = Menu.MenuLang & "=" & Language & Param.queryAND & Menu.Action & "=" & Param.ActionEdit & Param.queryAND & Menu.PageType & "=" & Param.PageTypeGeneric & Param.queryAND & Menu.idPage & "=" & tmpPage.idPagina & Param.queryAND & Menu.codPage & "=" & .codPagina & Param.queryAND & Menu.idTemplate & "=" & tmpPage.idTemplate & Param.queryAND & Menu.idVoce & "=" & .idVoce & Param.queryAND & Menu.codPageMother & "=" & .codPaginaMadre & Param.queryAND & Menu.ProfonditaLivello & "=" & .ProfonditaLivello
                    tmpQueryAddPage = Menu.MenuLang & "=" & Language & Param.queryAND & Menu.Action & "=" & Param.ActionAdd & Param.queryAND & Menu.PageType & "=" & Param.PageTypeGeneric & Param.queryAND & Menu.idPage & "=" & tmpPage.idPagina & Param.queryAND & Menu.codPage & "=" & .codPagina & Param.queryAND & Menu.idTemplate & "=" & tmpPage.idTemplate & Param.queryAND & Menu.idVoce & "=" & .idVoce & Param.queryAND & Menu.codPageMother & "=" & .codPaginaMadre & Param.queryAND & Menu.ProfonditaLivello & "=" & .ProfonditaLivello

                    HttpContext.Current.Session("tmpSessionQueryEditVoce" & .idVoce) = tmpQueryEdit

                    HTMLMenu &= "<li id=""idVoce" & .idVoce & """><span class=""file""><a href=""AddPage.aspx?" & tmpQueryEdit & """>" & .DescrizioneBreveNelMenu & " <span class=""treeview-id"">(" & tmpPage.idPagina & ")</span></a></span>" & vbCrLf

                    HTMLContextMenu &= JertCMS_WriteAdminContextMenuGenericPage(tmpQueryEdit, tmpQueryAddPage, .DescrizioneBreveNelMenu, .idVoce, Language, tmpPage.codPagina, tmpPage.idTemplate, tmpPage.idVoce, tmpMenu.folderpath)

                    jQueryFunctions &= "$(""#idVoce" & .idVoce & """).contextMenu({menu: 'menuVoce" & .idVoce & "'},{menu: 'menuVoce" & .idVoce & "'});" & vbCrLf

                    If (tmpDepth > 0) And (tmpDepth < MenuDepth) Then
                        Dim tmpDbCommand2 As New OleDbCommand
                        Dim tmpDbConnection2 As New OleDbConnection
                        JertCMS_WriteAdminTreeLanguage(Language, HTMLMenu, HTMLContextMenu, jQueryFunctions, tmpDepth + 1, MenuDepth, tmpMenu.codPagina, tmpDbCommand2, tmpDbConnection2)
                        'db.CloseConn(True, tmpDbConnection2)
                        'tmpDbConnection2 = Nothing
                        'tmpDbCommand2 = Nothing
                    End If

                    HTMLMenu &= "</li>"

                End With
            End While

            HTMLMenu &= "</ul>"

            tmpReader.Close()
            db.CloseConn(True, tmpDbConnection)
        End Sub

        Private Function GetMaxMenuDepth(ByVal Language As String, Optional ByRef tmpDbCommand As OleDbCommand = Nothing, Optional ByRef tmpDbConnection As OleDbConnection = Nothing) As Long
            Dim retValue As Long = 0

            'TODO: Sql server nel like utilizza *
            Sql = " SELECT TOP 1 Menu.idVoce, Max(Menu.ProfonditaLivello) AS MaxProfonditaLivello "
            Sql &= " FROM Menu "
            Sql &= " WHERE (((Menu.folderpath) Like '" & cmsPaths.PathPublic & "" & Language & "\%')) "
            Sql &= " GROUP BY Menu.idVoce, Menu.ProfonditaLivello "
            Sql &= " ORDER BY Menu.ProfonditaLivello DESC, Menu.IdVoce "

            If IsNothing(tmpDbConnection) Then
                db.OpenConn(Sql)
                myReader = db.ExecuteReader()
            Else
                db.OpenConn(Sql, , , True, tmpDbConnection, tmpDbCommand)
                myReader = db.ExecuteReader(True, tmpDbCommand)
            End If

            While myReader.Read
                retValue = myReader("MaxProfonditaLivello")
            End While
            myReader.Close()
            If IsNothing(tmpDbConnection) Then db.CloseConn()

            Return retValue
        End Function

        Public Sub DeleteChunkCategory(ByVal idCategoria As Long)
            db.OpenConn("Delete * From ChunkCategorie WHERE idCategoria = " & idCategoria)
            db.ExecuteNonQuery()
            db.CloseConn()

            db.OpenConn("Delete * From Chunks WHERE idCategoria = " & idCategoria)
            db.ExecuteNonQuery()
            db.CloseConn()
        End Sub

        Public Sub DeleteTVCategory(ByVal idCategoria As Long)
            db.OpenConn("Delete * From TemplateVariablesCategorie WHERE idCategoria = " & idCategoria)
            db.ExecuteNonQuery()
            db.CloseConn()

            db.OpenConn("Delete * From TemplateVariablesList WHERE idTVCategoria = " & idCategoria)
            db.ExecuteNonQuery()
            db.CloseConn()

            'TODO verificare gli altri delete....
        End Sub

        Public Sub DeleteChunk(Optional ByVal idChunk As Long = -1)
            If idChunk = -1 Then
                db.OpenConn("Delete * From Chunks")
                db.ExecuteNonQuery()
                db.CloseConn()

                db.OpenConn("Delete * From ChunkCategorie")
                db.ExecuteNonQuery()
                db.CloseConn()
            Else
                db.OpenConn("Delete * From Chunks WHERE idVariabile = " & idChunk)
                db.ExecuteNonQuery()
                db.CloseConn()

                'TODO eliminare le categorie collegate al chunk eliminato...
                'db.OpenConn("Delete * From ChunkCategorie")
                'db.ExecuteNonQuery()
                'db.CloseConn()
            End If

        End Sub

        Public Sub DeleteChunks()
           DeleteChunk
        End Sub

        Public Sub DeleteModule(Optional ByVal idCModule As Long = -1)
            If idCModule = -1 Then
                db.OpenConn("Delete * From ModulesInstalled")
                db.ExecuteNonQuery()
                db.CloseConn()

                db.OpenConn("Delete * From ModuleComponents")
                db.ExecuteNonQuery()
                db.CloseConn()
            Else
                db.OpenConn("Delete * From ModulesInstalled WHERE idModule = " & idCModule)
                db.ExecuteNonQuery()
                db.CloseConn()

                db.OpenConn("Delete * From ModuleComponents WHERE idModule = " & idCModule)
                db.ExecuteNonQuery()
                db.CloseConn()
            End If
        End Sub

        Public Sub DeleteModules()
            DeleteModule()
        End Sub

        Public Sub DeleteTV(ByVal idTV As Long)
            db.OpenConn("Delete * From TemplateVariablesList WHERE idTV = " & idTV)
            db.ExecuteNonQuery()
            db.CloseConn()
        End Sub

        Public Function LoadChunkByID(ByVal idChunkVar As Long) As _cmsChunkVariable
            Dim retValue As New _cmsChunkVariable

            Sql = " SELECT * From Chunks WHERE idVariabile = " & idChunkVar

            db.OpenConn(Sql)
            myReader = db.ExecuteReader

            While myReader.Read
                With retValue
                    .idVariablie = myReader("idVariabile")
                    .idCategoria = myReader("idCategoria")
                    .NomeVariabile = myReader("NomeVariabile")
                    .Contenuto = myReader("Contenuto")
                End With
            End While
            myReader.Close()
            db.CloseConn()

            Return retValue
        End Function

        Public Function LoadTVByID(ByVal idTVVar As Long) As _cmsTVVariable
            Dim retValue As New _cmsTVVariable

            Sql = " SELECT * From TemplateVariablesList WHERE idTV = " & idTVVar

            db.OpenConn(Sql)
            myReader = db.ExecuteReader

            While myReader.Read
                With retValue
                    .idTV = myReader("idTV")
                    .Name = myReader("Name")
                    .Caption = myReader("Caption")
                    .Description = myReader("Description")
                    .idTVCategoria = myReader("idTVCategoria")
                    .Type = myReader("Type")
                    .Inherit = myReader("Inherit")
                    .OuterTVHtml = IIf(IsDBNull(myReader("OuterTVHtml")), "", myReader("OuterTVHtml"))
                    .HideIfEmpty = myReader("HideIfEmpty")
                End With
            End While
            myReader.Close()
            db.CloseConn()

            Return retValue
        End Function

        Function CheckIfTVIsAssociatedWithTempalte(ByVal idTemplate As Long, ByVal idTV As Long) As Boolean
            Dim retValue As Boolean = False

            Sql = "Select Count(*) from TemplateVariablesInTemplate Where idTemplate = " & idTemplate & " AND idTemplateVariablesList = " & idTV & ";"
            db.OpenConn(Sql)
            myReader = db.ExecuteReader

            myReader.Read()
            If Convert.ToInt32(myReader(0)) > 0 Then
                retValue = True
            Else
                retValue = False
            End If

            myReader.Close()
            db.CloseConn()

            Return retValue
        End Function

        Sub SaveTVOrderInTemplate(ByVal idTemplateVariablesInTemplate As Long, ByVal TVOrderInTemplate As Long)
            db.OpenConn("UPDATE TemplateVariablesInTemplate Set TVOrderInTemplate = " & TVOrderInTemplate & " WHERE idTemplateVariablesInTemplate = " & idTemplateVariablesInTemplate)
            db.ExecuteScalar()
            db.CloseConn()
        End Sub

        Public Sub CheckAndBuildFilesFolders()
            Dim FilesFolderFound As Boolean = False
            Dim ImagesFolderFound As Boolean = False
            Dim VideosFolderFound As Boolean = False

            Dim arrDirectory As ArrayList
            Dim foundDirectory As DirectoryInfo

            arrDirectory = myDir.GetSubDirectories(cmsPaths.PathPublic, True)

            If arrDirectory.Count > 0 Then
                For Each foundDirectory In arrDirectory
                    If foundDirectory.Name = cmsPaths.PathVideos.Replace("\", "") Then VideosFolderFound = True
                    If foundDirectory.Name = cmsPaths.PathImagesPages.Replace("\", "") Then ImagesFolderFound = True
                    If foundDirectory.Name = cmsPaths.PathFiles.Replace("\", "") Then FilesFolderFound = True
                Next
            End If

            If Not VideosFolderFound Then myDir.CreateDirectory(cmsPaths.PathPublic & cmsPaths.PathVideos, True)
            If Not ImagesFolderFound Then myDir.CreateDirectory(cmsPaths.PathPublic & cmsPaths.PathImagesPages, True)
            If Not FilesFolderFound Then myDir.CreateDirectory(cmsPaths.PathPublic & cmsPaths.PathFiles, True)
        End Sub

        Private Function GetTwoDigitsFromidLingua(ByVal idLingua As Long, Optional ByRef tmpDbCommand As OleDbCommand = Nothing, Optional ByRef tmpDbConnection As OleDbConnection = Nothing) As String
            Dim retValue As String = ""

            Sql = "Select * From Lingue Where idLingua = " & idLingua & ";"

            If IsNothing(tmpDbConnection) Then
                db.OpenConn(Sql)
                myReader = db.ExecuteReader()
            Else
                db.OpenConn(Sql, , , True, tmpDbConnection, tmpDbCommand)
                myReader = db.ExecuteReader(True, tmpDbCommand)
            End If

            While myReader.Read
                retValue = myReader("Tipo")
                Exit While
            End While
            myReader.Close()
            If IsNothing(tmpDbConnection) Then db.CloseConn()

            Return retValue
        End Function

        Private Function SearchNewIDLingua(ByVal IdLangToExlude As Long, Optional ByRef tmpDbCommand As OleDbCommand = Nothing, Optional ByRef tmpDbConnection As OleDbConnection = Nothing) As String
            Dim retValue As String = ""

            Dim sql As String = "SELECT Lingue.Tipo FROM Menu INNER JOIN Lingue ON Menu.idLingua = Lingue.idLingua WHERE Menu.idLingua <> " & IdLangToExlude & " AND folderpath = '\'"

            If IsNothing(tmpDbConnection) Then
                db.OpenConn(sql)
                myReader = db.ExecuteReader()
            Else
                db.OpenConn(sql, , , True, tmpDbConnection, tmpDbCommand)
                myReader = db.ExecuteReader(True, tmpDbCommand)
            End If

            While myReader.Read
                retValue = myReader("Tipo")
                Exit While
            End While
            myReader.Close()
            If IsNothing(tmpDbConnection) Then db.CloseConn()

            Return retValue
        End Function

        Function CreateContextMenu(ByVal IDNumber As Long, ByVal FolderName As String, ByVal FolderToBuild As String) As String
            Dim retValue As String = ""

            Dim NuovaCartella As String = GetGlobalResourceObject("FileBrowser", "NuovaCartella")
            Dim SpostaCartella As String = GetGlobalResourceObject("FileBrowser", "SpostaCartella")
            Dim EliminaCartella As String = GetGlobalResourceObject("FileBrowser", "EliminaCartella")


            retValue = "<ul id=""menu" & IDNumber & """ class=""contextMenu"">" & vbCrLf
            retValue &= "<li class=""current""><span>" & FolderName & "</span></li>" & vbCrLf
            retValue &= "<li class=""edit separator""><a href=""CreateFileFolder.aspx?FolderPath=" & FolderToBuild & """>" & NuovaCartella & "</a></li>" & vbCrLf
            retValue &= "<li class=""cut""><a href=""MoveFileFolder.aspx?FolderPath=" & FolderToBuild & """>" & SpostaCartella & " " & FolderName & "</a></li>" & vbCrLf
            retValue &= "<li class=""copy""><a href=""DeleteFileFolder.aspx?FolderPath=" & FolderToBuild & """>" & EliminaCartella & " " & FolderName & "</a></li>" & vbCrLf
            retValue &= "</ul>" & vbCrLf

            Return retValue
        End Function

        Function JertCMS_WritePublicFilesTree(ByVal idToStart As Long, ByVal FolderToBuild As String, ByVal FolderName As String, ByVal ServerPath As String) As _cms_DirectoryInfo
            Dim retValue As New StringBuilder

            Dim arrDirectory As ArrayList
            Dim foundDirectory As DirectoryInfo
            Dim DirectoryList As DirectoryInfo()
            Dim FilesList As FileInfo()
            Dim tmpDirectoryInfo As New _cms_DirectoryInfo
            Dim tmpDirectoryInfo2 As New _cms_DirectoryInfo

            tmpDirectoryInfo.LastIDULIndex = idToStart + 1
            tmpDirectoryInfo.ContextMenu &= CreateContextMenu(tmpDirectoryInfo.LastIDULIndex, FolderName, FolderToBuild)

            Dim idUL As String = ""

            arrDirectory = myDir.GetSubDirectories(FolderToBuild, True)

            Dim tmpPathInList As String = myDir.CleanPublicFolderPath(Paths, FolderToBuild.Replace(ServerPath, "\") & "\")
            tmpPathInList = tmpPathInList.Replace("\\", "\")

            retValue.Append("<li><span class=""folder""><a id=""id" & tmpDirectoryInfo.LastIDULIndex & """ href=""?current=" & tmpPathInList & """>" & FolderName & "</a></span>" & vbCrLf)
            tmpDirectoryInfo.jQueryString &= "$(""#id" & tmpDirectoryInfo.LastIDULIndex & """).contextMenu({menu: 'menu" & tmpDirectoryInfo.LastIDULIndex & "'},{menu: 'menu" & tmpDirectoryInfo.LastIDULIndex & "'});" & vbCrLf

            If arrDirectory.Count > 0 Then retValue.Append("<ul>" & vbCrLf)
            For Each foundDirectory In arrDirectory
                FilesList = foundDirectory.GetFiles

                'retValue.Append("<li><span class=""folder""><a href=""#"">" & foundDirectory.Name & "</a></span></li>" & vbCrLf)

                tmpDirectoryInfo.LastIDULIndex += 1

                tmpPathInList = myDir.CleanPublicFolderPath(Paths, foundDirectory.FullName.Replace(ServerPath, "\") & "\")

                retValue.Append("<li><span class=""folder""><a id=""id" & tmpDirectoryInfo.LastIDULIndex & """ href=""?current=" & tmpPathInList & """>" & foundDirectory.Name & "</a></span>" & vbCrLf)

                'TODO foundDirectory.FullName.Replace(ServerPath, "") da fare meglio, rimuovere solo la stringa iniziale e non fare un replace
                tmpDirectoryInfo.ContextMenu &= CreateContextMenu(tmpDirectoryInfo.LastIDULIndex, foundDirectory.Name, foundDirectory.FullName.Replace(ServerPath, "\") & "\")

                tmpDirectoryInfo.jQueryString &= "$(""#id" & tmpDirectoryInfo.LastIDULIndex & """).contextMenu({menu: 'menu" & tmpDirectoryInfo.LastIDULIndex & "'},{menu: 'menu" & tmpDirectoryInfo.LastIDULIndex & "'});" & vbCrLf


                DirectoryList = foundDirectory.GetDirectories()
                For Each DirectoryInfo In DirectoryList
                    With tmpDirectoryInfo
                        tmpDirectoryInfo2 = JertCMS_WritePublicFilesTree(tmpDirectoryInfo.LastIDULIndex, DirectoryInfo.FullName.Replace(ServerPath, "\") & "\", DirectoryInfo.Name, ServerPath)

                        .ContextMenu &= tmpDirectoryInfo2.ContextMenu
                        .FolderName &= tmpDirectoryInfo2.FolderName
                        .jQueryString &= tmpDirectoryInfo2.jQueryString
                        '.TreeStructure &= "<ul>" & tmpDirectoryInfo2.TreeStructure & "</ul>"

                        .LastIDULIndex = tmpDirectoryInfo2.LastIDULIndex


                        retValue.Append("<ul>" & tmpDirectoryInfo2.TreeStructure & "</ul>")
                    End With
                Next
            Next
            If arrDirectory.Count > 0 Then retValue.Append("</ul>" & vbCrLf)
            retValue.Append("</li>" & vbCrLf)

            tmpDirectoryInfo.TreeStructure = retValue.ToString

            Return tmpDirectoryInfo
        End Function

        Public Sub JertCMS_LoadPublicFilesTree(ByVal ListBoxFolders As ListBox, ByVal idToStart As Long, ByVal FolderToBuild As String, ByVal FolderName As String, ByVal ServerPath As String, Optional ByVal DirectoryDepth As Long = 0)
            Dim space As String = "_"

            'ListBoxFolders.Items.Clear()

            Dim arrDirectory As ArrayList
            Dim foundDirectory As DirectoryInfo
            Dim DirectoryList As DirectoryInfo()
            Dim FilesList As FileInfo()
            Dim tmpDirectoryInfo As New _cms_DirectoryInfo
            Dim tmpDirectoryInfo2 As New _cms_DirectoryInfo

            tmpDirectoryInfo.LastIDULIndex = idToStart + 1
            'tmpDirectoryInfo.ContextMenu &= CreateContextMenu(tmpDirectoryInfo.LastIDULIndex, FolderName, FolderToBuild)

            'DirectoryDepth += 1
            Dim Separator As String = New String(space, DirectoryDepth) & " "

            'Dim tmpPathInList As String = myDir.CleanPublicFolderPath(Paths, FolderName.Replace(ServerPath, "\") & "\")
            Dim tmpPathInList As String = myDir.CleanPublicFolderPath(Paths, FolderToBuild.Replace(ServerPath, "\") & "\")
            tmpPathInList = tmpPathInList.Replace("\\", "\")

            'If DirectoryDepth > 0 Then
            '    Separator = New String(space, tmpPathInList.Length)
            'Else
            'tmpPathInList = myDir.CleanPublicFolderPath(Paths, FolderToBuild.Replace(ServerPath, "\"))
            'End If

            Dim item As ListItem

            If FolderToBuild.StartsWith("\") Then FolderToBuild = FolderToBuild.Substring(1)

            item = New ListItem(tmpPathInList, ServerPath & FolderToBuild)
            'item = New ListItem(tmpPathInList, FolderToBuild)

            'ListBoxFolders.Items.Add(Separator & tmpPathInList)
            ListBoxFolders.Items.Add(item)

            Dim idUL As String = ""

            arrDirectory = myDir.GetSubDirectories(FolderToBuild, True)

            'retValue.Append("<li><span class=""folder""><a id=""id" & tmpDirectoryInfo.LastIDULIndex & """ href=""#"">" & FolderName & "</a></span>" & vbCrLf)
            'tmpDirectoryInfo.jQueryString &= "$(""#id" & tmpDirectoryInfo.LastIDULIndex & """).contextMenu({menu: 'menu" & tmpDirectoryInfo.LastIDULIndex & "'},{menu: 'menu" & tmpDirectoryInfo.LastIDULIndex & "'});" & vbCrLf

            DirectoryDepth += 1

            For Each foundDirectory In arrDirectory
                FilesList = foundDirectory.GetFiles

                Separator = New String(space, tmpPathInList.Length)
                'tmpPathInList = myDir.CleanPublicFolderPath(Paths, foundDirectory.FullName.Replace(ServerPath, "\") & "\").Replace(tmpPathInList, "")
                tmpPathInList = myDir.CleanPublicFolderPath(Paths, foundDirectory.FullName.Replace(ServerPath, "\") & "\")

                'If tmpPathInList.StartsWith("\") Then tmpPathInList = tmpPathInList.Substring(1)

                'item = New ListItem(tmpPathInList, ServerPath & tmpPathInList)
                item = New ListItem(tmpPathInList, foundDirectory.FullName)

                'ListBoxFolders.Items.Add(Separator & tmpPathInList)
                ListBoxFolders.Items.Add(item)

                'retValue.Append("<li><span class=""folder""><a href=""#"">" & foundDirectory.Name & "</a></span></li>" & vbCrLf)

                tmpDirectoryInfo.LastIDULIndex += 1
                'retValue.Append("<li><span class=""folder""><a id=""id" & tmpDirectoryInfo.LastIDULIndex & """ href=""#"">" & foundDirectory.Name & "</a></span>" & vbCrLf)

                'TODO foundDirectory.FullName.Replace(ServerPath, "") da fare meglio, rimuovere solo la stringa iniziale e non fare un replace
                'tmpDirectoryInfo.ContextMenu &= CreateContextMenu(tmpDirectoryInfo.LastIDULIndex, foundDirectory.Name, foundDirectory.FullName.Replace(ServerPath, "\") & "\")

                'tmpDirectoryInfo.jQueryString &= "$(""#id" & tmpDirectoryInfo.LastIDULIndex & """).contextMenu({menu: 'menu" & tmpDirectoryInfo.LastIDULIndex & "'},{menu: 'menu" & tmpDirectoryInfo.LastIDULIndex & "'});" & vbCrLf


                DirectoryList = foundDirectory.GetDirectories()
                For Each DirectoryInfo In DirectoryList
                    With tmpDirectoryInfo

                        DirectoryDepth += 1
                        JertCMS_LoadPublicFilesTree(ListBoxFolders, tmpDirectoryInfo.LastIDULIndex, DirectoryInfo.FullName.Replace(ServerPath, "\") & "\", DirectoryInfo.Name, ServerPath, DirectoryDepth)

                        '.ContextMenu &= tmpDirectoryInfo2.ContextMenu
                        .FolderName &= tmpDirectoryInfo2.FolderName
                        '.jQueryString &= tmpDirectoryInfo2.jQueryString
                        '.TreeStructure &= "<ul>" & tmpDirectoryInfo2.TreeStructure & "</ul>"

                        .LastIDULIndex = tmpDirectoryInfo2.LastIDULIndex


                        'retValue.Append("<ul>" & tmpDirectoryInfo2.TreeStructure & "</ul>")
                    End With
                Next
            Next
            'If arrDirectory.Count > 0 Then retValue.Append("</ul>" & vbCrLf)
            ' retValue.Append("</li>" & vbCrLf)

            'tmpDirectoryInfo.TreeStructure = retValue.ToString
        End Sub

        Function WriteModulesList(ByVal SiteReplaceTilde As String, Optional ByVal Tilde As String = "~") As String
            Dim retValue As String = ""

            Dim tmpDbCommand As New OleDbCommand
            Dim tmpDbConnection As New OleDbConnection
            Dim tmpReader As OleDbDataReader

            Dim tmpSql As String = "Select * From ModulesInstalled Order By Name;"

            db.OpenConn(tmpSql, , , True, tmpDbConnection, tmpDbCommand)
            tmpReader = db.ExecuteReader(True, tmpDbCommand)

            While tmpReader.Read
                retValue &= "<li><span class=""file""><a href=""" & tmpReader("DefaultRedirectURL").ToString.Replace(Tilde, SiteReplaceTilde) & """>" & tmpReader("Name") & "</a></span>"
                retValue &= "<ul>" & WriteModuleComponentsList(tmpReader("idModule")) & "</ul>"
                retValue &= "</li>"
            End While

            tmpReader.Close()
            db.CloseConn(True, tmpDbConnection)

            Return retValue
        End Function

        Function WriteModuleComponentsList(ByVal ModuleID As Long) As String
            Dim retValue As String = ""

            Dim tmpDbCommand As New OleDbCommand
            Dim tmpDbConnection As New OleDbConnection
            Dim tmpReader As OleDbDataReader

            Dim tmpSql As String = "Select * From ModuleComponents Where idModule=" & ModuleID & " Order By ComponentName;"

            db.OpenConn(tmpSql, , , True, tmpDbConnection, tmpDbCommand)
            tmpReader = db.ExecuteReader(True, tmpDbCommand)

            While tmpReader.Read
                retValue &= "<li><span class=""file""><a href=""EditComponent.aspx?Module=" & ModuleID & "&id=" & tmpReader("idComponent") & """>" & tmpReader("ComponentName") & "</a></span></li>"
            End While

            tmpReader.Close()
            db.CloseConn(True, tmpDbConnection)

            Return retValue
        End Function

        Public Function DeleteWebSite(ByVal _DeletePublicFolder As Boolean, ByVal _DeleteChunks As Boolean, ByVal _DeleteModules As Boolean, ByVal _DeleteTemplates As Boolean) As String
            Dim retValue As String = ""

            Try
                If _DeletePublicFolder Then myDir.DeleteDirectory(cmsPaths.PathPublic, True, True)
                If _DeleteChunks Then DeleteChunks()
                If _DeleteModules Then DeleteModules()
                If _DeleteTemplates Then DeleteTemplate()

                retValue = "Website DELETED."
            Catch ex As Exception
                retValue = "Error: " & ex.Message
            End Try

            Return retValue
        End Function

        Public Function SeparateColorName(ByVal ColorName As String) As String
            For Each c As Char In ColorName
                If Char.IsUpper(c) Then ColorName = ColorName.Replace(c, " " & c).Trim
            Next

            Return ColorName
        End Function

        Public Function ColorToHexString(ByVal color As Drawing.Color) As String
            Dim hexDigits As Char() = {"0"c, "1"c, "2"c, "3"c, "4"c, "5"c, "6"c, "7"c, "8"c, "9"c, "A"c, "B"c, "C"c, "D"c, "E"c, "F"c}

            Dim bytes As Byte() = New Byte(2) {}
            bytes(0) = color.R
            bytes(1) = color.G
            bytes(2) = color.B
            Dim chars As Char() = New Char(bytes.Length * 2 - 1) {}
            For i As Integer = 0 To bytes.Length - 1
                Dim b As Integer = bytes(i)
                chars(i * 2) = hexDigits(b >> 4)
                chars(i * 2 + 1) = hexDigits(b And &HF)
            Next
            Return "#" & New String(chars)
        End Function

        Public Function GenerateBreadCrumb(ByVal WebSitePath As String, ByVal FolderPath As String, ByVal Separator As String, ByVal mCssClass As String, ByVal LinkLastElement As String, ByVal overwriteLastTitle As String, ByVal urlappendtext As String) As String
            Dim retvalue As String = ""
            Dim cssClass As String = IIf(mCssClass.Length > 0, " class=""" & mCssClass & """", "")

            Dim appendtext As String = ""
            If urlappendtext.Length > 0 Then appendtext = urlappendtext

            Dim StripPath As String = cmsPaths.PathPublic.Replace("\", "/") & cmsLanguage.Lingua & "/"
            If FolderPath.StartsWith(StripPath) Then
                FolderPath = FolderPath.Remove(0, StripPath.Length)
            End If

            Dim ProgressivePath As String = WebSitePath & StripPath
            Dim HomeLink As String = ""
            HomeLink = "<a href=""" & WebSitePath & "/" & appendtext & """" & cssClass & ">Home</a>"

            If FolderPath = "/" Then Return HomeLink

            Dim FoldersNames As String() = FolderPath.Split("/")

            retvalue = HomeLink
            Dim LastTitle As String = ""

            Dim LastElement As Integer = FoldersNames.Length - 1
            If FoldersNames(LastElement) = "" Then LastElement -= 1

            For i As Integer = 0 To LastElement
                LastTitle = FoldersNames(i)

                If LastTitle <> "" Then

                    ProgressivePath &= LastTitle & "/"
                    If i = LastElement Then
                        If overwriteLastTitle.Length > 0 Then LastTitle = overwriteLastTitle

                        If LinkLastElement = "yes" Then
                            retvalue &= Separator & "<a href=""" & ProgressivePath & appendtext & """" & cssClass & ">" & LastTitle.Replace("-", " ") & "</a>"
                        Else
                            retvalue &= Separator & "<span>" & LastTitle.Replace("-", " ") & "</span>"
                        End If
                    Else
                        retvalue &= Separator & "<a href=""" & ProgressivePath & appendtext & """" & cssClass & ">" & LastTitle.Replace("-", " ") & "</a>"
                    End If
                End If
            Next

            Return retvalue
        End Function

        Public Function DeleteMenuVoiceByFolderPathLike(ByVal LikeFolderPath As String) As String
            Dim retValue As String = ""
            db.OpenConn("Delete * From Menu WHERE folderpath Like '" & LikeFolderPath & "' AND len(folderpath) > " & (LikeFolderPath.Length - 1) & " ")
            db.ExecuteNonQuery()
            db.CloseConn()

            Return "Menu Voice " & LikeFolderPath.Replace("%", "") & " deleted.. - "
        End Function

        Public Function DeletePageByContentLike(ByVal LikeFolderPath As String) As String
            Dim retValue As String = ""
            db.OpenConn("Delete * From Pagine WHERE Content Like '" & LikeFolderPath & "'")
            db.ExecuteNonQuery()
            db.CloseConn()

            Return "Pages " & LikeFolderPath.Replace("Exxio Content of ", "").Replace("%", "") & " deleted.. - "
        End Function

        Public Function GetPageByFolderPath(ByVal folderpath As String, Optional ByRef tmpDbCommand As OleDbCommand = Nothing, Optional ByRef tmpDbConnection As OleDbConnection = Nothing) As _cmsPage
            Dim tmpPage As New _cmsPage

            With tmpPage
                Sql = "  SELECT Pagine.*, folderpath, DescrizioneBreveNelMenu FROM Pagine INNER JOIN Menu ON Pagine.codPagina = Menu.codPagina WHERE folderpath = '" & folderpath & "';"

                If IsNothing(tmpDbConnection) Then
                    db.OpenConn(Sql)
                    myReader = db.ExecuteReader()
                Else
                    db.OpenConn(Sql, , , True, tmpDbConnection, tmpDbCommand)
                    myReader = db.ExecuteReader(True, tmpDbCommand)
                End If

                While myReader.Read
                    With tmpPage
                        .codPagina = myReader("codPagina")
                        .DataInserimento = myReader("DataInserimento")
                        .DataUltimaModifica = myReader("DataUltimaModifica")
                        .filename = IIf(IsDBNull(myReader("filename")), "", myReader("filename"))
                        .idLingua = myReader("idLingua")
                        .idPagina = myReader("idPagina")
                        .LivelloVisibilita = myReader("LivelloVisibilita")
                        .MetaDescription = myReader("MetaDescription")
                        .TitoloH1 = myReader("TitoloH1")

                        'TODO
                        '.TestoHeader = myReader("TestoHeader")
                        '.Testo = myReader("Testo")
                        .HTMLPageContent = myReader("Content")

                        .Tipo = myReader("Tipo")
                        .Titolo = myReader("Titolo")
                        .idTemplate = myReader("idTemplate")

                        .FolderPath = myReader("folderpath")
                        .DescrizioneBreveNelMenu = myReader("DescrizioneBreveNelMenu")
                    End With

                    Exit While
                End While

                myReader.Close()
                If IsNothing(tmpDbConnection) Then db.CloseConn()

                If .idPagina = 0 Then
                    'Pagina non trovata....
                    .idErrore = 1
                End If

            End With


            Return tmpPage
        End Function

    End Class
End Namespace
