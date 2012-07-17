Imports Microsoft.VisualBasic
Imports System.Net
Imports System.IO

Namespace Jertix.Functions
    Public Class ClassGetWebPage

        Public Function RemoveAccentMarks(ByVal s As String) As String
            Dim normalizedString As String = s.Normalize(NormalizationForm.FormD)
            Dim stringBuilder As New StringBuilder()
            Dim c As Char
            Dim i As Integer
            For i = 0 To normalizedString.Length - 1
                c = normalizedString(i)
                If System.Globalization.CharUnicodeInfo.GetUnicodeCategory(c) <> System.Globalization.UnicodeCategory.NonSpacingMark Then
                    stringBuilder.Append(c)
                End If
            Next
            Return stringBuilder.ToString
        End Function


        Public Function GetPageWithPostData(ByVal UrlPage As String, ByVal PostData As String) As String

            Dim uri As New Uri(UrlPage)
            Dim data As String = PostData 'Es.: campo1=ciao&campo2;si
            If uri.Scheme = uri.UriSchemeHttp Then
                Dim request As HttpWebRequest = HttpWebRequest.Create(uri)
                request.Method = WebRequestMethods.Http.Post
                request.ContentLength = data.Length
                request.ContentType = "application/x-www-form-urlencoded"

                Dim writer As New StreamWriter(request.GetRequestStream)
                writer.Write(data)
                writer.Close()

                Dim oResponse As HttpWebResponse = request.GetResponse()
                Dim reader As New StreamReader(oResponse.GetResponseStream())
                Dim tmp As String = reader.ReadToEnd()
                oResponse.Close()

                Return (tmp)
            End If

            Return ""
        End Function

    End Class
End Namespace

