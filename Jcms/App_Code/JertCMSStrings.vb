Imports Microsoft.VisualBasic

Namespace JertCMSStrings

    Public Structure _cmsDBTables
        Dim ChunkCategorie As _cmsDBTableChunkCategorie
        'Dim Chunks As _cmsDBTableChunks
        'Dim Files As _cmsDBTableFiles
        'Dim Gallery As _cmsDBTableGallery
        'Dim Images As _cmsDBTableImages
        'Dim ImmaginiPagine As _cmsDBTableImmaginiPagine
        'Dim Lingue As _cmsDBTableLingue
        'Dim Menu As _cmsDBTableMenu
        'Dim Pagine As _cmsDBTablePagine
        'Dim Permessi As _cmsDBTablePermessi
        'Dim Roles As _cmsDBTableRoles
        'Dim TableData As _cmsDBTableTableData
        'Dim TableName As _cmsDBTableTableName
        'Dim TableRow As _cmsDBTableTableRow
        'Dim Templates As _cmsDBTableTemplates
        'Dim TemplateTabs As _cmsDBTableTemplateTabs
        'Dim TemplateVariablesCategorie As _cmsDBTableTemplateVariablesCategorie
        'Dim TemplateVariablesInPages As _cmsDBTableTemplateVariablesInPages
        'Dim TemplateVariablesInTemplate As _cmsDBTableTemplateVariablesInTemplate
        'Dim TemplateVariablesList As _cmsDBTableTemplateVariablesList
        'Dim TVGroups As _cmsDBTableTVGroups
        'Dim Utenti As _cmsDBTableUtenti
    End Structure

    Public Structure _cmsDBTableChunkCategorie
        Dim idCategoria As String
        Dim NomeCategoria As String
    End Structure

    Public Class DBStrings
        Dim DBTables As _cmsDBTables

        Dim cmsDBTableChunkCategorie As _cmsDBTableChunkCategorie

        Sub New()
            InitDBStrings()
        End Sub

        Private Sub InitDBStrings()

        End Sub

    End Class

End Namespace