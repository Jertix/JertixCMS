Imports Microsoft.VisualBasic
Imports System.Text.RegularExpressions
Imports JertCMSFunctions
Imports System.Collections.Generic

Namespace Jertix.Functions

    Public Class RegExClass

        Dim xmlClass As New JertCMSXMLClass

        Public Function StripNotAlphanumericChars(ByVal OriginalText As String, Optional ByVal RegExExpression As String = "\W") As String
            Return Regex.Replace(OriginalText, "\W", "")
        End Function

        Public Function StringIsEmpty(ByVal OriginalText As String) As Boolean
            Return Regex.IsMatch(OriginalText, "^\s*$")
        End Function

        Public Function SeparateTemplateHTML(ByVal FullTemplateText As String) As _cmsTemplate
            Dim pattern As String = "(?<header>[\s\S]+(?=<\s*body[^<]*>))<\s*body(?<body_attr>[^<]*)>(?<content>[\s\S]+(?=</body[^<]*>))</body>(?<footer>[\s\S]*)"
            Dim re As New Regex(pattern, RegexOptions.Multiline Or RegexOptions.IgnoreCase)
            Dim myMatch As Match = re.Match(FullTemplateText)

            Dim tmpTemplate As New _cmsTemplate
            With tmpTemplate
                .Header = myMatch.Groups("header").Value
                .BodyTagOpen = IIf(myMatch.Groups("body_attr").Value.Length > 0, "<body " & myMatch.Groups("body_attr").Value.Trim, "<body") & ">"
                .Content = myMatch.Groups("content").Value
                .BodyTagClose = "</body>"
                .Footer = myMatch.Groups("footer").Value
            End With

            Return tmpTemplate
        End Function

        Public Function FindNumberInText(ByVal OriginalText As String) As String
            Dim TheNum As String = Regex.Match(OriginalText, "\d+").Value()
            If TheNum <> "" Then
                Return TheNum
            Else
                Return ""
            End If
        End Function

        Public Function ReplaceText(ByVal regexTAG As String, ByVal FullText As String, ByVal ReplacingText As String) As String
            Dim retValue As String = FullText

            Dim regex As New Regex(regexTAG, RegexOptions.IgnoreCase)
            Dim matches As MatchCollection = regex.Matches(FullText)
            Dim match As Match
            For Each match In matches
                retValue = retValue.Replace(match.Value.ToString(), ReplacingText)
            Next match

            Return retValue
        End Function

        Public Function XMLTagSearch(ByVal XPath As String, ByVal FullText As String) As String
            Dim retValue As String = ""
            retValue = xmlClass.ReadXMLFromText(XPath, FullText)
            Return retValue
        End Function

        Public Function XMLNodeListSearch(ByVal XPath As String, ByVal FullText As String) As List(Of String)
            Dim retValue As New List(Of String)
            retValue = xmlClass.ReadXMLListFromText(XPath, FullText, True)
            Return retValue
        End Function

    End Class
End Namespace