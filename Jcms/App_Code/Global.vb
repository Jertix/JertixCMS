Imports Microsoft.VisualBasic
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Data

Namespace Jertix.Functions
    'Versione: 0.6

    Public Class TestFunctions

        Private m_DebuggingModeEnabled As Boolean = False

        Sub New()
            m_DebuggingModeEnabled = False
        End Sub

        Sub New(ByVal EnableDebugging As Boolean)
            m_DebuggingModeEnabled = EnableDebugging
        End Sub

        Public Function PrintDebug(ByVal TestString As String) As String
            If m_DebuggingModeEnabled = True Then
                Return TestString
            Else
                Return ""
            End If
        End Function
    End Class

    Public Class DBFunctions
        Inherits System.Web.HttpApplication

        Public NomeTabella() As String = {}

        Dim ConnString As String
        Public cmd As OleDbCommand
        Public cn As OleDbConnection

        Dim ConnStringSetting As String
        Public cmdSetting As OleDbCommand
        Public cnSetting As OleDbConnection
        Public debugSQLString As String = ""

        ''' <summary>
        ''' Open a Connection with Database ciao NORMAN
        ''' </summary>
        ''' <remarks>
        ''' Remarks for OpenConn
        ''' </remarks>
        ''' <param name="SQLString">
        ''' Default is HttpContext.Current.Session("ConnString")
        ''' </param>
        ''' <param name="OnlyDatabaseName">
        ''' if is = "" then Default is HttpContext.Current.Session("ConnString")
        ''' else FolderName/OnlyDatabaseName/".mdb"
        ''' </param>
        Public Sub OpenConn(ByVal SQLString As String, Optional ByVal OnlyDatabaseName As String = "", Optional ByVal FolderName As String = "", Optional ByVal UseExternalConn As Boolean = False, Optional ByRef ExternalOleDbConnection As OleDbConnection = Nothing, Optional ByRef ExternalOleDbCommand As OleDbCommand = Nothing, Optional ByVal ConnectionString As String = "")
            ' Try
            If OnlyDatabaseName = "" Then
                If ConnectionString = "" Then
                    'ConnString = HttpContext.Current.Session("ConnString")
                    ConnString = ConfigurationManager.ConnectionStrings("jCMS").ConnectionString
                Else
                    ConnString = ConnectionString
                End If
            Else
                If FolderName = "" Then FolderName = "App_Data"
                'TODO --> Max Pool Size=200 funziona su access?
                If ConnectionString = "" Then
                    ConnString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & HttpContext.Current.Server.MapPath("~/" & FolderName & "/" & OnlyDatabaseName & ".mdb") & ";"
                Else
                    ConnString = ConnectionString
                End If
            End If

            debugSQLString = SQLString

            If UseExternalConn Then
                'If ExternalOleDbConnection.State = Data.ConnectionState.Open Then ExternalOleDbConnection.Close()

                If ExternalOleDbConnection.State = Data.ConnectionState.Closed Then
                    ExternalOleDbConnection = New OleDbConnection(ConnString)
                End If

                'ExternalOleDbConnection = New OleDbConnection(ConnString)
                ExternalOleDbCommand = New OleDbCommand(SQLString, ExternalOleDbConnection)
                ExternalOleDbCommand.CommandTimeout = 100
                If ExternalOleDbConnection.State = Data.ConnectionState.Closed Then
                    ExternalOleDbConnection.Open()
                End If
            Else
                cn = New OleDbConnection(ConnString)
                cmd = New OleDbCommand(SQLString, cn)
                cmd.CommandTimeout = 100
                cn.Open()
            End If


            'Catch ex As Exception
            '    debugSQLString &= vbCrLf & " -> " & ex.Message.ToString

            '    If UseExternalConn Then
            '        If ExternalOleDbConnection.State <> Data.ConnectionState.Open Then ExternalOleDbConnection.Close()
            '        'ExternalOleDbConnection.Close()

            '        Try
            '            ExternalOleDbConnection = New OleDbConnection(ConnString)
            '            ExternalOleDbCommand = New OleDbCommand(SQLString, ExternalOleDbConnection)
            '            ExternalOleDbCommand.CommandTimeout = 0 '0 = no limit

            '            ExternalOleDbConnection.Open()
            '        Catch ex2 As Exception
            '            debugSQLString &= vbCrLf & "Errore in -> Global.vb"
            '        End Try
            '    Else
            '        If cn.State <> Data.ConnectionState.Open Then cn.Close()
            '        'cn.Close()

            '        Try
            '            cn = New OleDbConnection(ConnString)
            '            cmd = New OleDbCommand(SQLString, cn)
            '            cmd.CommandTimeout = 0 '0 = no limit
            '            cn.Open()
            '        Catch ex2 As Exception
            '            debugSQLString &= vbCrLf & "Errore in -> Global.vb"
            '        End Try
            '    End If
            'End Try
        End Sub

        ''' <summary>
        ''' This function is for Read Settings
        ''' </summary>
        ''' <param name="Campo"></param>
        ''' <param name="TableName"></param>
        ''' <param name="OnlyDatabaseName"></param>
        ''' <param name="FolderName"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function ReadSetting(ByVal Campo As String, Optional ByVal TableName As String = "Settaggi", Optional ByVal OnlyDatabaseName As String = "", Optional ByVal FolderName As String = "") As String
            Try
                If OnlyDatabaseName = "" Then
                    'ConnStringSetting = HttpContext.Current.Session("ConnString")
                    ConnStringSetting = ConfigurationManager.ConnectionStrings("jCMS").ConnectionString
                Else
                    If FolderName = "" Then FolderName = "App_Data"

                    ConnStringSetting = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & HttpContext.Current.Server.MapPath("~/" & FolderName & "/" & OnlyDatabaseName & ".mdb") & ";"
                End If

                cnSetting = New OleDbConnection(ConnStringSetting)
                cmdSetting = New OleDbCommand("Select valore from " & TableName & " where campo = '" & Campo & "'", cnSetting)
                cnSetting.Open()

                Dim Reader As OleDbDataReader = cmdSetting.ExecuteReader()

                If Reader.HasRows = True Then
                    Reader.Read()
                    Return Reader("valore").ToString.Trim
                Else
                    Return ""
                End If
            Catch ex As Exception
                Return False
            Finally
                cnSetting.Close()
            End Try
        End Function

        Public Function ReadIntSetting(ByVal Campo As String, Optional ByVal TableName As String = "Settaggi", Optional ByVal OnlyDatabaseName As String = "", Optional ByVal FolderName As String = "") As Integer
            Try
                Return CInt(ReadSetting(Campo, TableName, OnlyDatabaseName, FolderName))
            Catch ex As Exception
                Return 0
            End Try
        End Function

        Public Function WriteSetting(ByVal Campo As String, ByVal Valore As String, Optional ByVal TableName As String = "Settaggi", Optional ByVal OnlyDatabaseName As String = "", Optional ByVal FolderName As String = "") As Boolean
            Try
                If OnlyDatabaseName = "" Then
                    'ConnStringSetting = HttpContext.Current.Session("ConnString")
                    ConnStringSetting = ConfigurationManager.ConnectionStrings("jCMS").ConnectionString
                Else
                    If FolderName = "" Then FolderName = "App_Data"

                    ConnStringSetting = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & HttpContext.Current.Server.MapPath("~/" & FolderName & "/" & OnlyDatabaseName & ".mdb") & ";"
                End If

                cnSetting = New OleDbConnection(ConnStringSetting)
                cmdSetting = New OleDbCommand("UPDATE " & TableName & " Set Valore = '" & Valore.Trim & "' WHERE Campo = '" & Campo & "'", cnSetting)
                cnSetting.Open()

                cmdSetting.ExecuteNonQuery()

                Return True
            Catch ex As Exception
                Return False
            Finally
                cnSetting.Close()
            End Try
        End Function

        Public Sub ExecuteNonQuery(Optional ByVal UseExternalConn As Boolean = False, Optional ByRef ExternalOleDbCommand As OleDbCommand = Nothing)
            debugSQLString &= ""
            If UseExternalConn Then
                ExternalOleDbCommand.ExecuteNonQuery()
            Else
                cmd.ExecuteNonQuery()
            End If
        End Sub

        Public Function ExecuteReader(Optional ByVal UseExternalConn As Boolean = False, Optional ByRef ExternalOleDbCommand As OleDbCommand = Nothing) As OleDbDataReader
            debugSQLString &= ""
            If UseExternalConn Then
                Return ExternalOleDbCommand.ExecuteReader()
                'Return ExternalOleDbCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
            Else
                'Try
                Return cmd.ExecuteReader()
                'Catch ex As Exception
                '    HttpContext.Current.Response.ClearContent()
                '    HttpContext.Current.Response.Write("Error SQL: " & "<br />" & debugSQLString & "<br />" & "<br />" & "Error Message: " & "<br />" & ex.Message & "<br />" & "<br />" & "Stack: " & "<br />" & ex.StackTrace)
                '    HttpContext.Current.Response.End()
                'End Try
            End If
        End Function

        Public Function GetStringColumn(ByVal stringColumn As String) As String
            Dim Reader As OleDbDataReader = cmd.ExecuteReader()

            If Reader.HasRows = True Then
                Reader.Read()
                Return Reader(stringColumn).ToString
            Else
                Return ""
            End If

            CloseConn()
        End Function

        Public Function GetLongColumn(ByVal longColumn As String) As Long
            Dim Reader As OleDbDataReader = cmd.ExecuteReader()

            If Reader.HasRows = True Then
                Reader.Read()
                Return CType(Reader(longColumn), Long)
            Else
                Return -1
            End If

            CloseConn()
        End Function

        Public Function GetDecimalColumn(ByVal decimalColumn As String) As Decimal
            Dim Reader As OleDbDataReader = cmd.ExecuteReader()

            If Reader.HasRows = True Then
                Reader.Read()
                Return CType(Reader(decimalColumn), Decimal)
            Else
                Return -1
            End If

            CloseConn()
        End Function

        Public Function GetSQLString(Optional ByVal AddMessage As String = "") As String
            Return AddMessage & " " & debugSQLString
        End Function

        Public Function ExecuteScalar(Optional ByVal UseExternalConn As Boolean = False, Optional ByRef ExternalOleDbCommand As OleDbCommand = Nothing) As Long
            debugSQLString &= ""
            If UseExternalConn Then
                Return ExternalOleDbCommand.ExecuteScalar()
            Else
                Return cmd.ExecuteScalar
            End If

        End Function

        Public Function GetLastID(ByVal TableName As String, Optional ByVal idFieldName As String = "id") As Long
            'TODO: sostituire con  "SELECT @@IDENTITY FROM  [TableName]"

            Dim id As Long = -1

            Try
                OpenConn("Select Max(" & idFieldName & ") FROM " & TableName & ";")
                Dim tmpReader As OleDbDataReader
                tmpReader = ExecuteReader()
                tmpReader.Read()
                id = tmpReader(0)

            Catch ex As Exception

            End Try

            Return id

            CloseConn()
        End Function

        Public Sub CloseConn(Optional ByVal UseExternalConn As Boolean = False, Optional ByRef ExternalOleDbConnection As OleDbConnection = Nothing, Optional ByVal CloseDB As Boolean = True)
            Try
                If UseExternalConn Then
                    If CloseDB Then ExternalOleDbConnection.Close()
                Else
                    If CloseDB Then cn.Close()
                End If
            Catch ex As Exception
            End Try
        End Sub

        Function GetData(ByVal queryString As String, ByVal ConnectionString As String) As DataSet
            Dim ds As New DataSet()
            Try
                OpenConn(queryString, , , , , , ConnectionString)
                Dim adapter As New OleDbDataAdapter(queryString, cn)
                adapter.Fill(ds)
                CloseConn()
            Catch ex As Exception
            End Try
            Return ds
        End Function

        Public Function CheckDbNull(ByVal dbText As Object) As String
            If TypeOf dbText Is DBNull Then Return ""
            Return dbText
        End Function

    End Class

    Public Class TextFunctions

        Public Function QueryStringEncode(ByVal TextToEncode As String) As String
            Return HttpUtility.UrlPathEncode(TextToEncode)
        End Function

        Public Function QueryStringDecode(ByVal TextToDecode As String) As String
            Return HttpUtility.UrlDecode(TextToDecode)
        End Function

        Public Function Plurale(ByVal NumeroDaVerificare As Long, ByVal CaratteriFinaliSingolari As String, ByVal CaratteriFinaliPlurali As String) As String
            Return IIf(NumeroDaVerificare = 1, CaratteriFinaliSingolari, CaratteriFinaliPlurali)
        End Function

        Public Function HTMLSpecial(ByVal Name As String) As String
            Dim returnString As String = ""

            'From: http://htmlhelp.com/reference/html40/entities/latin1.html
            If Name.IndexOf("space") Or Name.IndexOf("spazio") > 0 Then returnString = "&#160;" '&nbsp;
            If Name.StartsWith("à") = True Then returnString = "&#224;" '&agrave;

            Return returnString
        End Function
    End Class

End Namespace

