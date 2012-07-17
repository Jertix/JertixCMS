Imports Microsoft.VisualBasic
Imports System.Globalization
Imports JertCMSFunctions
Imports System.Web.HttpContext
Imports Jertix.Functions
Imports System.Data.OleDb

Namespace JertCMSCommands

    Public Structure _cmsCommandsList
        Dim Selezionare As String

        Dim PageVars As String
        Dim Tv As String
        Dim Chunk As String
        Dim List As String
        Dim Menu As String
        Dim Modules As String
    End Structure

    Public Class JertCMSCommands
        Dim myFunc As New JertCMSFunctions.JertCMSFunctions
        Dim cmsCommandsList As _cmsCommandsList

        Dim db As New DBFunctions
        Dim myReader As OleDbDataReader
        Dim Sql As String

        Dim SelectCMSCommand As String

        Public Sub New()
            Init()
        End Sub

        Private Sub Init()
            With cmsCommandsList
                .Selezionare = GetGlobalResourceObject("Commands", "Select")
                .PageVars = GetGlobalResourceObject("Commands", "PageVars")
                .Tv = GetGlobalResourceObject("Commands", "tv")
                .Chunk = GetGlobalResourceObject("Commands", "Chunk")
                .List = GetGlobalResourceObject("Commands", "List")
                .Menu = GetGlobalResourceObject("Commands", "Menu")
                .Modules = GetGlobalResourceObject("Commands", "Modules")
            End With

            SelectCMSCommand = GetGlobalResourceObject("Commands", "SelectCMSCommand")
        End Sub

        Public Sub LoadListCommandTypes(ByVal dropdownList As DropDownList)
            With dropdownList
                .Items.Clear()

                Dim newListItem As New ListItem()
                newListItem.Text = cmsCommandsList.Selezionare
                newListItem.Value = cmsCommandsList.Selezionare
                .Items.Add(newListItem)

                newListItem = New ListItem()
                newListItem.Text = cmsCommandsList.PageVars
                newListItem.Value = cmsCommandsList.PageVars
                .Items.Add(newListItem)

                newListItem = New ListItem()
                newListItem.Text = cmsCommandsList.Tv
                newListItem.Value = cmsCommandsList.Tv
                .Items.Add(newListItem)

                newListItem = New ListItem()
                newListItem.Text = cmsCommandsList.Chunk
                newListItem.Value = cmsCommandsList.Chunk
                .Items.Add(newListItem)

                newListItem = New ListItem()
                newListItem.Text = cmsCommandsList.List
                newListItem.Value = cmsCommandsList.List
                .Items.Add(newListItem)

                newListItem = New ListItem()
                newListItem.Text = cmsCommandsList.Menu
                newListItem.Value = cmsCommandsList.Menu
                .Items.Add(newListItem)

                newListItem = New ListItem()
                newListItem.Text = cmsCommandsList.Modules
                newListItem.Value = cmsCommandsList.Modules
                .Items.Add(newListItem)

                .DataBind()
            End With
        End Sub

        Public Sub LoadListElements(ByVal dropdownList As DropDownList, ByVal CommandType As String, ByVal idTemplate As Long)
            With dropdownList
                .Items.Clear()

                Dim TvCommand As String = GetGlobalResourceObject("Commands", "tv")
                Dim PageVarsCommand As String = GetGlobalResourceObject("Commands", "PageVars")
                Dim ChunksCommand As String = GetGlobalResourceObject("Commands", "Chunk")
                Dim ListCommand As String = GetGlobalResourceObject("Commands", "List")
                Dim MenuCommand As String = GetGlobalResourceObject("Commands", "Menu")
                Dim ModulesCommand As String = GetGlobalResourceObject("Commands", "Modules")

                Select Case CommandType
                    Case TvCommand
                        Sql = "SELECT TemplateVariablesList.*, TemplateVariablesInTemplate.* FROM TemplateVariablesList INNER JOIN TemplateVariablesInTemplate ON TemplateVariablesList.idTV = TemplateVariablesInTemplate.idTemplateVariablesList Where idTemplate = " & idTemplate & " Order By TVOrderInTemplate"
                        db.OpenConn(Sql)
                        myReader = db.ExecuteReader

                        Dim newListItem As New ListItem()
                        newListItem.Text = SelectCMSCommand
                        newListItem.Value = -1
                        .Items.Add(newListItem)

                        While myReader.Read
                            newListItem = New ListItem()
                            newListItem.Text = "<jcms type=""tv"" name=""" & myReader("Name") & """ />"
                            newListItem.Value = myReader("idTV")

                            .Items.Add(newListItem)
                        End While

                        Dim tmpValue As Long = 1

                        newListItem = New ListItem()
                        newListItem.Text = "<jcms type=""tv"" name=""tvName"" depth=""1"" />"
                        newListItem.Value = tmpValue : tmpValue += 1
                        .Items.Add(newListItem)

                        newListItem = New ListItem()
                        newListItem.Text = "<jcms type=""tv"" name=""tvName"" page-id=""1"" />"
                        newListItem.Value = tmpValue : tmpValue += 1
                        .Items.Add(newListItem)

                        db.CloseConn()
                    Case PageVarsCommand
                        Dim tmpValue As Long = -1

                        Dim newListItem As New ListItem()
                        newListItem.Text = SelectCMSCommand
                        newListItem.Value = tmpValue : tmpValue += 1
                        .Items.Add(newListItem)

                        newListItem = New ListItem()
                        newListItem.Text = "<jcms type=""tvpage"" name=""title"" />"
                        newListItem.Value = tmpValue : tmpValue += 1
                        .Items.Add(newListItem)

                        newListItem = New ListItem()
                        newListItem.Text = "<jcms type=""tvpage"" name=""long_title"" />"
                        newListItem.Value = tmpValue : tmpValue += 1
                        .Items.Add(newListItem)

                        newListItem = New ListItem()
                        newListItem.Text = "<jcms type=""tvpage"" name=""description"" />"
                        newListItem.Value = tmpValue : tmpValue += 1
                        .Items.Add(newListItem)

                        newListItem = New ListItem()
                        newListItem.Text = "<jcms type=""tvpage"" name=""menu"" />"
                        newListItem.Value = tmpValue : tmpValue += 1
                        .Items.Add(newListItem)

                        newListItem = New ListItem()
                        newListItem.Text = "<jcms type=""tvpage"" name=""content"" />"
                        newListItem.Value = tmpValue : tmpValue += 1
                        .Items.Add(newListItem)

                        newListItem = New ListItem()
                        newListItem.Text = "<jcms type=""tvpage"" name=""publish_date"" />"
                        newListItem.Value = tmpValue : tmpValue += 1
                        .Items.Add(newListItem)

                        newListItem = New ListItem()
                        newListItem.Text = "<jcms type=""tvpage"" name=""last_update_date"" />"
                        newListItem.Value = tmpValue : tmpValue += 1
                        .Items.Add(newListItem)

                        newListItem = New ListItem()
                        newListItem.Text = "<jcms type=""tvpage"" name=""rel_link"" />"
                        newListItem.Value = tmpValue : tmpValue += 1
                        .Items.Add(newListItem)

                        newListItem = New ListItem()
                        newListItem.Text = "<jcms type=""tvpage"" name=""abs_link"" />"
                        newListItem.Value = tmpValue : tmpValue += 1
                        .Items.Add(newListItem)

                        newListItem = New ListItem()
                        newListItem.Text = "<jcms type=""tvpage"" name=""content"" depth=""1"" /><!-- name: ""title"", ""content"", ""description"", ecc..."" -->"
                        newListItem.Value = tmpValue : tmpValue += 1
                        .Items.Add(newListItem)

                        newListItem = New ListItem()
                        newListItem.Text = "<jcms type=""tvpage"" name=""content"" page_id=""1"" /><!-- name: ""title"", ""content"", ""description"", ecc..."" -->"
                        newListItem.Value = tmpValue : tmpValue += 1
                        .Items.Add(newListItem)

                        newListItem = New ListItem()
                        newListItem.Text = "<jcms type=""tvpage"" name=""content"" depth=""1"" page_menu_name=""home"" /><!-- depth: {1 = ""Home Page"";2 = ""Home Page -> Sub Menu"";3 = ""Home Page -> Sub Menu -> Sub Sub Menu""; ecc.. --><!-- page_menu_name: must to be unique in each menu depth -->"
                        newListItem.Value = tmpValue : tmpValue += 1
                        .Items.Add(newListItem)

                        newListItem = New ListItem()
                        newListItem.Text = "<jcms type=""tvpage"" name=""website_link"" />"
                        newListItem.Value = tmpValue : tmpValue += 1
                        .Items.Add(newListItem)

                        newListItem = New ListItem()
                        newListItem.Text = "<jcms type=""tvpage"" name=""page_id"" />"
                        newListItem.Value = tmpValue : tmpValue += 1
                        .Items.Add(newListItem)

                        newListItem = New ListItem()
                        newListItem.Text = "<jcms type=""tvpage"" name=""page_id"" page_folder_path=""\public\en\..."" /><!-- page_folder_path: ex: ""\public\en\Menu1\Menu2\"" -->"
                        newListItem.Value = tmpValue : tmpValue += 1
                        .Items.Add(newListItem)

                        newListItem = New ListItem()
                        newListItem.Text = "<jcms type=""tvpage"" name=""breadcrumb"" cssclass="""" separator="" > "" linklastelement=""yes|no"" overwritelasttitle="" />"
                        newListItem.Value = tmpValue : tmpValue += 1
                        .Items.Add(newListItem)

                        newListItem = New ListItem()
                        newListItem.Text = "<jcms type=""tvpage"" name=""querystring"" value=""type_here"" prefix=""?value="" /><!-- ex 1: ""http://www.site.com/category?name=hello&product=shoe"" value: ""name"", ""product"", ecc...""; if name does not exist tvpage return empty string -->" & vbCrLf & "<!-- ex 2 (with prefix): ""http://www.site.com/category?name=hello&product=shoe"" value: ""name"", prefix=""?testvalue="" Result: ""?testvalue=hello""; param prefix is optional -->" & vbCrLf
                        newListItem.Value = tmpValue : tmpValue += 1
                        .Items.Add(newListItem)

                    Case ChunksCommand
                        Sql = "SELECT Chunks.idVariabile, Chunks.NomeVariabile, ChunkCategorie.NomeCategoria FROM Chunks INNER JOIN ChunkCategorie ON Chunks.idCategoria = ChunkCategorie.idCategoria ORDER BY Chunks.NomeVariabile;"
                        db.OpenConn(Sql)
                        myReader = db.ExecuteReader

                        Dim newListItem As New ListItem()
                        newListItem.Text = SelectCMSCommand
                        newListItem.Value = -1
                        .Items.Add(newListItem)

                        While myReader.Read
                            newListItem = New ListItem()
                            newListItem.Text = "<jcms type=""chunk"" name=""" & myReader("NomeVariabile") & """ category=""" & myReader("NomeCategoria") & """ />"
                            newListItem.Value = myReader("idVariabile")
                            .Items.Add(newListItem)
                        End While

                        db.CloseConn()

                    Case ListCommand
                        Dim newListItem As New ListItem()
                        Dim tmpValue As Long = 0

                        '<jcms type="list" page_id="103" order_by_tvpage="title" sort_order="asc" display="100" pagination="10" exclude_id="" start_depth="2" depth="0">
                        '	<template_header>
                        '	    <p><div>Titolo - Siamo nella pagina: <jcms type="tvpage" name="title"> </div></p>	
                        '	</template_header>
                        '	<template>
                        '	    <p><div>Elemento n° <jcms type="list_number">..<jcms type="tvpage" name="title" page_id="list"></div></p>	
                        '	</template>
                        '	<no_elements>
                        '		<p>No elements...</p>
                        '	</no_elements>
                        '</jcms>

                        'TODO .. globalizzare i testi di esempio nel comando LIST

                        Dim tmpList As String = ""
                        tmpList &= "<jcms type=""list"" page_id=""10|78|55"" order_by_tvpage=""title"" sort_order=""asc|desc"" display=""100"" pagination=""10"" exclude_id=""10|78|55"" start_depth=""2"" depth=""0"">" & vbCrLf
                        tmpList &= "<template_header>" & vbCrLf
                        tmpList &= "<p><div>Footer of current Page is: <jcms type=""tvpage"" name=""title"" /></div></p>" & vbCrLf
                        tmpList &= "</template_header>" & vbCrLf
                        tmpList &= "<template>" & vbCrLf
                        tmpList &= "<p><div>List n° <jcms type=""list_number"" />: <jcms type=""tvpage"" name=""title"" page_id=""list"" /></div></p>" & vbCrLf
                        tmpList &= "</template>" & vbCrLf
                        tmpList &= "<template_footer>" & vbCrLf
                        tmpList &= "<p><div>Footer of current Page is: <jcms type=""tvpage"" name=""title"" /></div></p>" & vbCrLf
                        tmpList &= "</template_footer>" & vbCrLf
                        tmpList &= "<no_elements>" & vbCrLf
                        tmpList &= "<p>No elements...</p>" & vbCrLf
                        tmpList &= "</no_elements>" & vbCrLf
                        tmpList &= "</jcms>" & vbCrLf

                        newListItem.Text = SelectCMSCommand
                        newListItem.Value = tmpValue : tmpValue += 1
                        .Items.Add(newListItem)

                        newListItem = New ListItem()
                        newListItem.Text = tmpList
                        newListItem.Value = tmpValue : tmpValue += 1
                        .Items.Add(newListItem)

                    Case MenuCommand
                        Dim newListItem As New ListItem()
                        Dim tmpValue As Long = 0

                        Dim tmpMenu As String = ""
                        tmpMenu &= "<jcms type=""menu"" page_id=""122|123|current|root"" exclude_id=""124|126|current"" show_only_id=""1|5|6"" order_by_tvpage=""menu"" order_by_menuindex=""true"" custom_order=""10,long_title|11,content"" sort_order=""asc"" start_depth=""0"" depth=""0"" show_css_class=""first|last|level|active|parent|id"" hide_children_in_no_active=""true"">" & vbCrLf
                        tmpMenu &= "<!-- menu_1 = Menu DEPTH 1-->" & vbCrLf
                        tmpMenu &= "<menu_1>" & vbCrLf
                        tmpMenu &= "<template_header>" & vbCrLf
                        tmpMenu &= "<ul>" & vbCrLf
                        tmpMenu &= "</template_header>" & vbCrLf
                        tmpMenu &= "<template_content>" & vbCrLf
                        tmpMenu &= "<li class=""[[css]]""><jcms type=""tvpage"" name=""menu"" page_id=""menu"" /> - [[menu]]</li>" & vbCrLf
                        tmpMenu &= "</template_content>" & vbCrLf
                        tmpMenu &= "<template_footer>" & vbCrLf
                        tmpMenu &= "</ul>" & vbCrLf
                        tmpMenu &= "</template_footer>" & vbCrLf
                        tmpMenu &= "</menu_1>" & vbCrLf

                        tmpMenu &= "<template_empty>" & vbCrLf
                        tmpMenu &= "<p>Menu empty...</p>" & vbCrLf
                        tmpMenu &= "</template_empty>" & vbCrLf
                        tmpMenu &= "</jcms>" & vbCrLf

                        newListItem.Text = SelectCMSCommand
                        newListItem.Value = tmpValue : tmpValue += 1
                        .Items.Add(newListItem)

                        newListItem = New ListItem()
                        newListItem.Text = tmpMenu
                        newListItem.Value = tmpValue : tmpValue += 1
                        .Items.Add(newListItem)

                    Case ModulesCommand
                        Sql = "SELECT ModuleComponents.idComponent, ModuleComponents.Example, ModulesInstalled.Name, ModuleComponents.ComponentName FROM ModulesInstalled INNER JOIN ModuleComponents ON ModulesInstalled.idModule = ModuleComponents.idModule Order By ModulesInstalled.Name, ModuleComponents.ComponentName"
                        db.OpenConn(Sql)
                        myReader = db.ExecuteReader

                        Dim newListItem As New ListItem()
                        newListItem.Text = SelectCMSCommand
                        newListItem.Value = -1
                        .Items.Add(newListItem)

                        While myReader.Read
                            newListItem = New ListItem()
                            newListItem.Text = myReader("Example").ToString.Replace("$ModuleName", myReader("Name")).ToString.Replace("$ComponentName", myReader("ComponentName"))
                            newListItem.Value = myReader("idComponent")
                            .Items.Add(newListItem)
                        End While

                        db.CloseConn()
                End Select

                If .Items.Count > 0 Then
                    .SelectedIndex = 0
                End If

                .DataBind()
            End With
        End Sub

    End Class
End Namespace
