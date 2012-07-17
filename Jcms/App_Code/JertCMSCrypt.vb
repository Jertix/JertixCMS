Imports Microsoft.VisualBasic
Imports System.Security.Cryptography

Namespace JertCMSCrypt

    Public Class JertCMSCrypt
        Private Shared cryptDES3 As New TripleDESCryptoServiceProvider()
        Private Shared cryptMD5Hash As New MD5CryptoServiceProvider()

        Public Function Decrypt(ByVal PhraseToDecrypt As String) As String
            Dim plainText As String
            Dim cipherText As String = PhraseToDecrypt

            Dim passPhrase As String
            Dim saltValue As String
            Dim hashAlgorithm As String
            Dim passwordIterations As Integer
            Dim initVector As String
            Dim keySize As Integer

            plainText = ""

            passPhrase = "e5tyu8i_o908h"        ' can be any string
            saltValue = "rhuh_oj8908"        ' can be any string
            hashAlgorithm = "SHA1"             ' can be "MD5"
            passwordIterations = 2                  ' can be any number
            initVector = "@1B2c3D4e5F6g7H8" ' must be 16 bytes
            keySize = 256                ' can be 192 or 128

            plainText = Decrypt(cipherText, passPhrase, saltValue, hashAlgorithm, passwordIterations, initVector, keySize)

            Return plainText
        End Function

        Public Function Encrypt(ByVal PhraseToEncrypt As String) As String
            Dim plainText As String
            Dim cipherText As String

            Dim passPhrase As String
            Dim saltValue As String
            Dim hashAlgorithm As String
            Dim passwordIterations As Integer
            Dim initVector As String
            Dim keySize As Integer

            plainText = PhraseToEncrypt

            passPhrase = "e5tyu8i_o908h"        ' can be any string
            saltValue = "rhuh_oj8908"        ' can be any string
            hashAlgorithm = "SHA1"             ' can be "MD5"
            passwordIterations = 2                  ' can be any number
            initVector = "@1B2c3D4e5F6g7H8" ' must be 16 bytes
            keySize = 256                ' can be 192 or 128

            cipherText = Encrypt(plainText, passPhrase, saltValue, hashAlgorithm, passwordIterations, initVector, keySize)

            Return cipherText
        End Function

        Public Function Encrypt(ByVal plainText As String, ByVal passPhrase As String, ByVal saltValue As String, ByVal hashAlgorithm As String, ByVal passwordIterations As Integer, ByVal initVector As String, ByVal keySize As Integer) As String
            Dim initVectorBytes As Byte() = Encoding.ASCII.GetBytes(initVector)
            Dim saltValueBytes As Byte() = Encoding.ASCII.GetBytes(saltValue)
            Dim plainTextBytes As Byte() = Encoding.UTF8.GetBytes(plainText)
            Dim password As New Rfc2898DeriveBytes(passPhrase, saltValueBytes, passwordIterations)
            Dim keyBytes As Byte()= password.GetBytes(keySize / 8)
            Dim symmetricKey As RijndaelManaged = New RijndaelManaged()
            symmetricKey.Mode = CipherMode.CBC
            Dim encryptor As ICryptoTransform = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes)
            Dim memoryStream As IO.MemoryStream = New IO.MemoryStream()
            Dim cryptoStream As CryptoStream = New CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write)
            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length)
            cryptoStream.FlushFinalBlock()
            Dim cipherTextBytes As Byte() = memoryStream.ToArray()
            memoryStream.Close()
            cryptoStream.Close()
            Dim cipherText As String = Convert.ToBase64String(cipherTextBytes)
            Encrypt = cipherText
        End Function

        Public Function Decrypt(ByVal cipherText As String, ByVal passPhrase As String, ByVal saltValue As String, ByVal hashAlgorithm As String, ByVal passwordIterations As Integer, ByVal initVector As String, ByVal keySize As Integer) As String
            Dim initVectorBytes As Byte() = Encoding.ASCII.GetBytes(initVector)
            Dim saltValueBytes As Byte() = Encoding.ASCII.GetBytes(saltValue)
            Dim cipherTextBytes As Byte() = Convert.FromBase64String(cipherText)
            Dim password As New Rfc2898DeriveBytes(passPhrase, saltValueBytes, passwordIterations)
            Dim keyBytes As Byte() = password.GetBytes(keySize / 8)
            Dim symmetricKey As RijndaelManaged = New RijndaelManaged()
            symmetricKey.Mode = CipherMode.CBC
            Dim decryptor As ICryptoTransform = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes)
            Dim memoryStream As IO.MemoryStream = New IO.MemoryStream(cipherTextBytes)
            Dim cryptoStream As CryptoStream = New CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read)
            Dim plainTextBytes As Byte()
            ReDim plainTextBytes(cipherTextBytes.Length)
            Dim decryptedByteCount As Integer = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length)
            memoryStream.Close()
            cryptoStream.Close()
            Dim plainText As String = Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount)
            Decrypt = plainText
        End Function

    End Class

End Namespace