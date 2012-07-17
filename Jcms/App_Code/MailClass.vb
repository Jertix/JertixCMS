Imports Microsoft.VisualBasic
Imports System.Net.Mail
Imports System.Net
Imports JertCMSCrypt

Namespace Jertix.Functions
    'Versione: 0.4

    Public Class MailClass

        Dim myCrypt As New JertCMSCrypt.JertCMSCrypt

        Public Function Crypt(ByVal TextToCrypt As String) As String
            Return myCrypt.Encrypt(TextToCrypt)
        End Function

        Public Function DeCrypt(ByVal TextToDecrypt As String) As String
            Return myCrypt.Decrypt(TextToDecrypt)
        End Function

        Public Function EncryptSHA256Managed(ByVal ClearString As String) As String
            Dim uEncode As New UnicodeEncoding()
            Dim bytClearString() As Byte = uEncode.GetBytes(ClearString)
            Dim sha As New  _
            System.Security.Cryptography.SHA256Managed()
            Dim hash() As Byte = sha.ComputeHash(bytClearString)
            Return Convert.ToBase64String(hash)
        End Function

        Public Function SendMail(ByVal _From As String, ByVal _To As String, ByVal _Subject As String, ByVal _Body As String, Optional ByVal _CC As String = "", Optional ByVal _BCC As String = "", Optional ByVal isBodyHTML As Boolean = False) As String
            If _From.Trim.Length <= 0 Then Return False
            If _To.Trim.Length <= 0 Then Return False

            Dim SmtpHost As String = ConfigurationManager.AppSettings("SmtpHost")
            Dim SmtpPort As String = ConfigurationManager.AppSettings("SmtpPort")

            Dim Smtp As New SmtpClient(SmtpHost, SmtpPort)
            Smtp.DeliveryMethod = SmtpDeliveryMethod.Network
            Smtp.UseDefaultCredentials = False

            Smtp.Credentials = CredentialCache.DefaultNetworkCredentials

            Dim Mailmsg As New System.Net.Mail.MailMessage
            Mailmsg.To.Clear()
            Mailmsg.To.Add(New System.Net.Mail.MailAddress(_To))

            If _From.ToLower.Contains("@localhost") Then _From = "test@localwebsite.com"

            Mailmsg.From = New System.Net.Mail.MailAddress(_From)

            If _CC.Trim.Length > 0 Then
                'può essere anche un elenco semparato da ;
                Mailmsg.CC.Add(New System.Net.Mail.MailAddress(_CC))
            End If

            If _BCC.Trim.Length > 0 Then
                'può essere anche un elenco semparato da ;
                Mailmsg.Bcc.Add(New System.Net.Mail.MailAddress(_BCC))
            End If

            Mailmsg.Subject = _Subject
            Mailmsg.IsBodyHtml = isBodyHTML

            Try
                Mailmsg.Body = _Body
                Smtp.Send(Mailmsg)
                Return "<br />Messaggio spedito."
            Catch ex As Exception
                Return ("<br />Errore: " & ex.ToString())
            End Try
        End Function

        Public Function SendMailWithOneAttachment(ByVal AttachmentFile As FileUpload, ByVal _From As String, ByVal _To As String, ByVal _Subject As String, ByVal _Body As String, Optional ByVal _CC As String = "", Optional ByVal _BCC As String = "", Optional ByVal isBodyHTML As Boolean = False) As Boolean

            Dim SmtpHost As String = ConfigurationManager.AppSettings("SmtpHost")
            Dim SmtpPort As String = ConfigurationManager.AppSettings("SmtpPort")

            Dim Smtp As New SmtpClient(SmtpHost, SmtpPort)
            Dim Mailmsg As New System.Net.Mail.MailMessage
            Mailmsg.To.Clear()
            Mailmsg.To.Add(New System.Net.Mail.MailAddress(_To)) '"To Name <toname@todomain.com>"
            Mailmsg.From = New System.Net.Mail.MailAddress(_From) '"From Name <fromname@yourfromdomain.com>"
            Mailmsg.Subject = _Subject
            Mailmsg.IsBodyHtml = isBodyHTML

            Try

                If String.IsNullOrEmpty(AttachmentFile.FileName) OrElse AttachmentFile.PostedFile Is Nothing Then
                    Return False
                End If

                Mailmsg.Attachments.Add(New Attachment(AttachmentFile.PostedFile.InputStream, AttachmentFile.FileName))

                Mailmsg.Body = _Body
                Smtp.Send(Mailmsg)
                Return True
            Catch ex As Exception
                Return False
                'HttpContext.Current.Response.Write("Error: " & ex.ToString())
            End Try
        End Function

        Public Function SendMailWithOneAttachment(ByVal AttachmentFileName As String, ByVal _From As String, ByVal _To As String, ByVal _Subject As String, ByVal _Body As String, Optional ByVal _CC As String = "", Optional ByVal _BCC As String = "", Optional ByVal isBodyHTML As Boolean = False) As Boolean

            Dim SmtpHost As String = ConfigurationManager.AppSettings("SmtpHost")
            Dim SmtpPort As String = ConfigurationManager.AppSettings("SmtpPort")

            Dim Smtp As New SmtpClient(SmtpHost, SmtpPort)
            Dim Mailmsg As New System.Net.Mail.MailMessage
            Mailmsg.To.Clear()
            Mailmsg.To.Add(New System.Net.Mail.MailAddress(_To))
            Mailmsg.From = New System.Net.Mail.MailAddress(_From)
            Mailmsg.Subject = _Subject
            Mailmsg.IsBodyHtml = isBodyHTML

            Try

                If String.IsNullOrEmpty(AttachmentFileName) OrElse AttachmentFileName Is Nothing Then
                    Return False
                End If

                Dim myAttach As Net.Mail.Attachment = New Net.Mail.Attachment(AttachmentFileName)
                Mailmsg.Attachments.Add(myAttach)

                Mailmsg.Body = _Body
                Smtp.Send(Mailmsg)
                Return True
            Catch ex As Exception
                Return False
                'HttpContext.Current.Response.Write("Error: " & ex.ToString())
            End Try
        End Function


    End Class
End Namespace
