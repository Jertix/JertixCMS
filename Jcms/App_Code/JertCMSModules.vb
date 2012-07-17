Imports Microsoft.VisualBasic
Imports System.Data.OleDb
Imports Jertix.Functions
Imports System.Web.HttpContext
Imports System.Collections.Generic
Imports JertCMSFunctions

Namespace jCMSModules

    Public Structure _cms_Component
        Dim idComponent As Long
        Dim idModule As Long
        Dim ComponentName As String
        Dim FileName As String
        Dim Example As String
    End Structure

    Public Class jertCMSModules

        Private Const idSelezioneZero As Long = 0
        Private Const idSelezioneNulla As Long = -1
        Private Selezionare As String = GetGlobalResourceObject("Admin", "Select")

        Dim db As New DBFunctions
        Dim myReader As OleDbDataReader
        Dim Sql As String

        Public Sub LoadListComponents(ByVal dropdownList As DropDownList, ByVal ModuleId As Long)
            With dropdownList
                Sql = "Select * from ModuleComponents Where idModule=" & ModuleId & " Order by ComponentName asc;"
                db.OpenConn(Sql)
                myReader = db.ExecuteReader()
                .Items.Clear()

                Dim newListItem As New ListItem()
                newListItem.Text = Selezionare
                newListItem.Value = idSelezioneNulla
                .Items.Add(newListItem)

                While myReader.Read
                    newListItem = New ListItem()
                    newListItem.Text = myReader("ComponentName")
                    newListItem.Value = myReader("idComponent")
                    .Items.Add(newListItem)
                End While

                myReader.Close()
                db.CloseConn()
            End With
        End Sub

        Public Function getComponentIDFromName(ByVal ComponentName As String, ByVal ModuleName As String) As Long
            Dim retValue As Long = 0

            Sql = "Select ModuleComponents.idComponent FROM ModuleComponents INNER JOIN ModulesInstalled ON ModuleComponents.idModule = ModulesInstalled.idModule WHERE ComponentName = '" & ModuleName.Trim & "' AND Name = '" & ComponentName.Trim & "'"
            db.OpenConn(Sql)
            myReader = db.ExecuteReader

            While myReader.Read
                retValue = myReader("idComponent")
            End While

            myReader.Close()
            db.CloseConn()

            Return retValue
        End Function

        Public Function ComponentNameExist(ByVal idModule As Long, ByVal idComponent As Long, ByVal ComponentName As String) As Boolean
            Dim retValue As Boolean = False

            Sql = "Select Count(*) from ModuleComponents Where idModule=" & idModule & " AND idComponent <> " & idComponent & " AND ComponentName = """ & ComponentName.Trim & """"
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

        Public Sub LoadListModules(ByVal dropdownList As DropDownList)
            With dropdownList
                Sql = "Select * from ModulesInstalled Order by Name asc;"
                db.OpenConn(Sql)
                myReader = db.ExecuteReader()
                .Items.Clear()

                Dim newListItem As New ListItem()
                newListItem.Text = Selezionare
                newListItem.Value = idSelezioneNulla
                .Items.Add(newListItem)

                While myReader.Read
                    newListItem = New ListItem()
                    newListItem.Text = myReader("Name")
                    newListItem.Value = myReader("idModule")
                    .Items.Add(newListItem)
                End While

                myReader.Close()
                db.CloseConn()
            End With
        End Sub

        Function GetComponentFromModuleId(ByVal idComponent As Long) As _cms_Component
            Dim tmpComponent As New _cms_Component
            Dim tmpSQL As String = ""

            Dim tmpDbCommand As New OleDbCommand
            Dim tmpDbConnection As New OleDbConnection
            Dim tmpReader As OleDbDataReader

            tmpSQL = "Select * From ModuleComponents Where idComponent=" & idComponent

            db.OpenConn(tmpSQL, , , True, tmpDbConnection, tmpDbCommand)
            tmpReader = db.ExecuteReader(True, tmpDbCommand)

            While tmpReader.Read
                With tmpComponent
                    .idComponent = tmpReader("idComponent")
                    .idModule = tmpReader("idModule")
                    .ComponentName = tmpReader("ComponentName")
                    .FileName = tmpReader("FileName")
                    .Example = tmpReader("Example")
                End With
            End While

            tmpReader.Close()
            db.CloseConn(True, tmpDbConnection)

            Return tmpComponent
        End Function

        Sub EditComponent(ByVal idComponent As Long, ByVal ComponentName As String, ByVal FileName As String, ByVal Example As String)
            Sql = "UPDATE ModuleComponents Set ComponentName = '" & ComponentName.Replace("'", "''") & "', FileName = '" & FileName.Replace("'", "''") & "', Example = '" & Example.Replace("'", "''") & "' WHERE idComponent = " & idComponent
            db.OpenConn(Sql)
            db.ExecuteNonQuery()
            db.CloseConn()
        End Sub

        Public Sub AddTemplateDetail(ByVal idTemplate As Long, ByVal Order As Integer, ByVal tmpContentStripped As String, ByVal ComponentID As Long, ByVal CustomID As String, Optional ByRef AttrList As List(Of _cmsTemplateDetailAttributes) = Nothing)
            tmpContentStripped = tmpContentStripped.Replace("'", "''") ' .Replace("""", """""")
            CustomID = CustomID.Replace("'", "''").Trim.ToLower ' .Replace("""", """""")

            Dim tmpAttributesCount As Long = 0
            Dim HaveAttributes As Boolean = False
            If Not (AttrList Is Nothing) AndAlso AttrList.Count > 0 Then HaveAttributes = True : tmpAttributesCount = AttrList.Count

            Sql = "INSERT INTO TemplateDetails (idTemplate,TemplateDetailOrder,Content,ComponentID,HaveAttributes,AttributesCount,CustomID) VALUES (" & idTemplate & "," & Order & ",'" & tmpContentStripped & "'," & ComponentID & "," & HaveAttributes & "," & tmpAttributesCount & ",'" & CustomID & "') "
            db.OpenConn(Sql)
            db.ExecuteNonQuery()
            db.CloseConn()

            Dim tmpIdTemplateDetail As Long = db.GetLastID("TemplateDetails")
            If CustomID = "" And ComponentID > 0 Then
                Sql = "UPDATE TemplateDetails Set CustomID = 'id" & tmpIdTemplateDetail.ToString & "' WHERE id = " & tmpIdTemplateDetail
                db.OpenConn(Sql)
                db.ExecuteNonQuery()
                db.CloseConn()
            End If

            'TODO: Salvare gli attributi....
            If Not (AttrList Is Nothing) AndAlso AttrList.Count > 0 Then
                Sql = "Delete * From TemplateDetailAttributes Where idTemplateDetail = " & tmpIdTemplateDetail
                db.OpenConn(Sql)
                db.ExecuteNonQuery()
                'db.CloseConn()

                For i As Long = 0 To AttrList.Count - 1
                    Sql = "INSERT INTO TemplateDetailAttributes (idTemplateDetail,AttrName,AttrValue) VALUES (" & tmpIdTemplateDetail & ",'" & AttrList(i).Name.Replace("'", "''") & "','" & AttrList(i).Value.Replace("'", "''").Replace("[", """").Replace("]", """") & "')"
                    db.OpenConn(Sql)
                    db.ExecuteNonQuery()
                    ' db.CloseConn()
                Next

                db.CloseConn()
            End If

        End Sub

    End Class

End Namespace

