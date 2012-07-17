Imports Microsoft.VisualBasic
Imports Jertix.Functions
Imports System.Globalization

Namespace Jertix.Functions
    'Versione: 0.5

    Public Class VisitCounter

        Private DBConn As New Jertix.Functions.DBFunctions

        Private Structure m_VisitorInfo
            Public m_PATH_INFO As String
            Public m_REMOTE_HOST As String
            Public m_SERVER_SOFTWARE As String
            Public m_URL As String
            Public m_HTTP_ACCEPT_LANGUAGE As String
            Public m_HTTP_HOST As String
            Public m_SCRIPT_NAME As String
            Public m_HTTP_REFERER As String
            Public m_HTTP_USER_AGENT As String
            Public LinguaUtilizzata As String

            Public m_Date As DateTime
        End Structure
        Private VisitInfo As m_VisitorInfo

        Sub New(Optional ByVal DataBaseName As String = "")
            SavePageVisit(DataBaseName)
        End Sub

        Private Sub SavePageVisit(Optional ByVal DataBaseName As String = "")
            Dim strSQL As String
            Dim errCode As Long = 0

            Dim myDate As DateTime

            With VisitInfo
                Try

                    Try
                        errCode = 1 : .LinguaUtilizzata = IIf(HttpContext.Current.Session("LinguaCulture") Is Nothing, "it-IT", HttpContext.Current.Session("LinguaCulture"))
                        errCode = 2 : Dim myCI As New CultureInfo(.LinguaUtilizzata)
                        errCode = 3 : myCI.DateTimeFormat.DateSeparator = "/"
                        errCode = 4 : myCI.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
                        errCode = 5 'Dim myDate As DateTime
                        errCode = 6 : myDate = DateTime.Parse(DateAndTime.Now, myCI)
                    Catch ex As Exception
                        'errCode = 2 : Dim myCI As New CultureInfo("it-IT")
                        'errCode = 3 : myCI.DateTimeFormat.DateSeparator = "/"
                        'errCode = 4 : myCI.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
                        'errCode = 5 'Dim myDate As DateTime
                        errCode = 6 : myDate = Date.Now
                    End Try

                    errCode = 7 : .m_Date = myDate
                    errCode = 8 : .m_HTTP_ACCEPT_LANGUAGE = HttpContext.Current.Request("HTTP_ACCEPT_LANGUAGE")
                    errCode = 9 : .m_HTTP_HOST = HttpContext.Current.Request("HTTP_HOST")

                    errCode = 10 : .m_HTTP_USER_AGENT = IIf(HttpContext.Current.Request.UserAgent Is Nothing, "", HttpContext.Current.Request.UserAgent.ToString)
                    errCode = 11 : .m_PATH_INFO = IIf(HttpContext.Current.Request.PathInfo Is Nothing, "", HttpContext.Current.Request.PathInfo)
                    errCode = 12 : .m_REMOTE_HOST = HttpContext.Current.Request("REMOTE_HOST")
                    errCode = 13 : .m_SCRIPT_NAME = HttpContext.Current.Request("SCRIPT_NAME")
                    errCode = 14 : .m_SERVER_SOFTWARE = HttpContext.Current.Request("SERVER_SOFTWARE")
                    errCode = 15 : .m_URL = HttpContext.Current.Request("URL")

                    errCode = 16 : .m_HTTP_REFERER = IIf(HttpContext.Current.Request.UrlReferrer Is Nothing, "", HttpContext.Current.Request.UrlReferrer.ToString)
                Catch EX As Exception
                    .m_HTTP_REFERER = errCode & "> " & EX.Message.Replace("'", "''").Replace("""", """""")
                End Try

                    strSQL = "INSERT INTO PageCounter "
                    strSQL &= "("
                    strSQL &= "Lingua,"
                    strSQL &= "Data,"
                    strSQL &= "AcceptLanguage,"
                    strSQL &= "Host,"
                    strSQL &= "Referer,"
                    strSQL &= "UserAgent,"
                    strSQL &= "PathInfo,"
                    strSQL &= "RemoteHost,"
                    strSQL &= "ScriptName,"
                    strSQL &= "ServerSoftware,"
                    strSQL &= "URL"
                    strSQL &= ") VALUES ("
                    strSQL &= "'" & .LinguaUtilizzata & "',"
                    strSQL &= "#" & .m_Date & "#,"
                    strSQL &= "'" & .m_HTTP_ACCEPT_LANGUAGE & "',"
                    strSQL &= "'" & .m_HTTP_HOST & "',"
                    strSQL &= "'" & .m_HTTP_REFERER & "',"
                    strSQL &= "'" & .m_HTTP_USER_AGENT & "',"
                    strSQL &= "'" & .m_PATH_INFO & "',"
                    strSQL &= "'" & .m_REMOTE_HOST & "',"
                    strSQL &= "'" & .m_SCRIPT_NAME & "',"
                    strSQL &= "'" & .m_SERVER_SOFTWARE & "',"
                    strSQL &= "'" & .m_URL & "'"
                    strSQL &= ")"
            End With

            If errCode > 1 Then
                If DataBaseName = "" Then DataBaseName = "Counter"

                DBConn.OpenConn(strSQL, DataBaseName)
                DBConn.ExecuteNonQuery()
            End If
        End Sub

        Public Function PrintVisitInfo() As String
            Dim IntoText As String = ""
            With VisitInfo
                IntoText += "Lingua: " & .LinguaUtilizzata & "<br />"
                IntoText += "Data: " & .m_Date & "<br />"
                IntoText += "Accept Language: " & .m_HTTP_ACCEPT_LANGUAGE & "<br />"
                IntoText += "Http Host: " & .m_HTTP_HOST & "<br />"
                IntoText += "Referer: " & .m_HTTP_REFERER & "<br />"
                IntoText += "User Agent: " & .m_HTTP_USER_AGENT & "<br />"
                IntoText += "Path Info: " & .m_PATH_INFO & "<br />"
                IntoText += "Remote Host: " & .m_REMOTE_HOST & "<br />"
                IntoText += "Script Name: " & .m_SCRIPT_NAME & "<br />"
                IntoText += "Server Software: " & .m_SERVER_SOFTWARE & "<br />"
                IntoText += "URL: " & .m_URL & "<br />"
            End With

            Return IntoText
        End Function
    End Class

End Namespace
