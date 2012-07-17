Imports Microsoft.VisualBasic
Imports System.IO
Imports System.Drawing.Imaging
Imports System.ComponentModel

Namespace Jertix.Functions
    'Versione: 0.4

    Public Class ImageManipulation
        Dim myFile As New FileManipulation

        Public Function CreateThumbnail(ByVal FileUploadObject As FileUpload, ByVal OriginalName As String, ByVal PrefixThumbnailImage As String, ByVal ImageFolderName As String, ByVal ThumbFolderName As String, ByVal ThumbnailSize As Integer, ByVal OriginalImageResize As Integer, ByVal FormatToSave As ImageFormat, ByVal DeleteOriginalFile As Boolean) As Boolean

            'EXSAMPLE TO CLASS USAGE
            'If FileUpload1.HasFile Then
            'Dim objImg As New Functions.ImageManipulation
            '    If objImg.CreateThumbnail(FileUpload1, "Cippa", "thumb", "img\test\", "img\test\", 100, 777, ImageFormat.Jpeg, True) = True Then
            '        Image1.ImageUrl = "~\img\test\" & "thumb" & "Cippa" & ".jpg"
            '    End If
            'End If

            'BUG: Non elimina l'immagine originale che viene salvata con formato jpg estensione .originale

            Dim imgInfo As ImageInfo = New ImageInfo
            Dim UploadedFileName As String = imgInfo.GetFileNameFromUploadedImage(FileUploadObject)

            If OriginalName = "" Then
                OriginalName = UploadedFileName
            End If

            Dim imageUrl As String = ImageFolderName & OriginalName & imgInfo.GetImageExtensionFromUploadedFile(FileUploadObject)
            Dim ImagePath As String = HttpContext.Current.Request.PhysicalApplicationPath & imageUrl

            FileUploadObject.PostedFile.SaveAs(ImagePath)

            'Try

            Dim imageHeight As Integer
            Dim imageWidth As Integer

            If imgInfo.ImageIsVertical(ImagePath) = True Then
                imageHeight = ThumbnailSize
                imageWidth = (imgInfo.GetImageWidth(ImagePath) * ThumbnailSize) / imgInfo.GetImageHeight(ImagePath)
            Else
                imageHeight = (imgInfo.GetImageHeight(ImagePath) * ThumbnailSize) / imgInfo.GetImageWidth(ImagePath)
                imageWidth = ThumbnailSize
            End If

            If (imageUrl.IndexOf("/") >= 0 And imageUrl.IndexOf("\\") >= 0) Then
                HttpContext.Current.Response.End()
            End If

            Dim fullSizeImg As System.Drawing.Image = System.Drawing.Image.FromFile(HttpContext.Current.Server.MapPath("~\" & imageUrl))

            Dim dummyCallBack As System.Drawing.Image.GetThumbnailImageAbort = New System.Drawing.Image.GetThumbnailImageAbort(AddressOf ThumbnailCallBack)
            Dim thumbNailImg As System.Drawing.Image = fullSizeImg.GetThumbnailImage(imageWidth, imageHeight, dummyCallBack, IntPtr.Zero)

            'thumbNailImg.Save(HttpContext.Current.Request.PhysicalApplicationPath & ThumbFolderName & PrefixThumbnailImage & OriginalName & "." & FormatToSave.ToString, FormatToSave)
            thumbNailImg.Save(HttpContext.Current.Server.MapPath("~\" & ThumbFolderName & PrefixThumbnailImage & OriginalName & "." & FormatToSave.ToString), FormatToSave)
            thumbNailImg.Dispose()

            If imgInfo.ImageIsVertical(ImagePath) = True Then
                imageHeight = OriginalImageResize
                imageWidth = (imgInfo.GetImageWidth(ImagePath) * OriginalImageResize) / imgInfo.GetImageHeight(ImagePath)
            Else
                imageHeight = (imgInfo.GetImageHeight(ImagePath) * OriginalImageResize) / imgInfo.GetImageWidth(ImagePath)
                imageWidth = OriginalImageResize
            End If
            Dim thumbNailImg2 As System.Drawing.Image = fullSizeImg.GetThumbnailImage(imageWidth, imageHeight, dummyCallBack, IntPtr.Zero)
            thumbNailImg2.Save(HttpContext.Current.Request.PhysicalApplicationPath & ImageFolderName & OriginalName & "." & FormatToSave.ToString, FormatToSave)
            thumbNailImg2.Dispose()

            thumbNailImg2 = Nothing
            fullSizeImg.Dispose()

            FileUploadObject.PostedFile.InputStream.Dispose()

            FileUploadObject.Dispose()
            imgInfo = Nothing
            dummyCallBack = Nothing
            thumbNailImg = Nothing
            fullSizeImg = Nothing
            FileUploadObject = Nothing

            GC.Collect()

            Dim OriginalFile As FileInfo = New FileInfo(ImagePath)

            If DeleteOriginalFile = True Then
                If File.Exists(ImagePath) Then
                    Try
                        OriginalFile.Delete()
                    Catch ex As Exception
                        '.. invio di email...
                        'HttpContext.Current.Response.Write("An error occurred - " + Replace(ex.ToString(), vbCrLf, "<br/>"))
                        'OriginalFile.Delete()
                        Return True
                    End Try
                End If
            End If

            Return True


            ' Catch ex As Exception
            'SEND ERROR BY MAIL
            'HttpContext.Current.Response.Write("An error occurred - " + Replace(ex.ToString(), vbCrLf, "<br/>"))
            'Return False
            'End Try
        End Function

        Public Function CreateThumbnail(ByVal OriginalName As String, ByVal OriginalPath As String, ByVal DestinationNamePath As String, ByVal DestinationName As String, ByVal Width As Integer, ByVal Height As Integer) As Boolean
            Try
                Dim imageUrl As String = OriginalPath & OriginalName
                Dim ImagePath As String = DestinationNamePath & DestinationName

                Dim ImageFile As FileInfo = New FileInfo(imageUrl)

                If myFile.FileExists(ImagePath, False) Then
                    myFile.DeleteFile(ImagePath, False)
                End If

                ImageFile.CopyTo(ImagePath)

                Dim imageHeight As Integer
                Dim imageWidth As Integer


                imageHeight = Height
                imageWidth = Width


                Dim fullSizeImg As System.Drawing.Image = System.Drawing.Image.FromFile(imageUrl)

                Dim dummyCallBack As System.Drawing.Image.GetThumbnailImageAbort = New System.Drawing.Image.GetThumbnailImageAbort(AddressOf ThumbnailCallBack)
                Dim thumbNailImg As System.Drawing.Image = fullSizeImg.GetThumbnailImage(imageWidth, imageHeight, dummyCallBack, IntPtr.Zero)

                'thumbNailImg.Save(HttpContext.Current.Request.PhysicalApplicationPath & ThumbFolderName & PrefixThumbnailImage & OriginalName & "." & FormatToSave.ToString, FormatToSave)
                thumbNailImg.Save(DestinationNamePath & DestinationName, ImageFormat.Jpeg)
                thumbNailImg.Dispose()

                fullSizeImg.Dispose()

                dummyCallBack = Nothing
                thumbNailImg = Nothing
                fullSizeImg = Nothing

                GC.Collect()

                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Function ThumbnailCallBack() As Boolean
            Return False
        End Function

    End Class


    Public Class ImageInfo

        Public Function GetFileNameFromUploadedImage(ByRef FileUploadObject As FileUpload) As String
            Dim UploadedFile As String = FileUploadObject.PostedFile.FileName
            Dim ExtractPos As Integer = UploadedFile.LastIndexOf("\\") + 1
            Dim UploadedFileName As String = UploadedFile.Substring(ExtractPos, UploadedFile.Length - ExtractPos)
            Return FileUploadObject.PostedFile.FileName
        End Function

        Public Function ImageIsVertical(ByVal ImageFileName As String) As Boolean
            If GetImageHeight(ImageFileName) > GetImageWidth(ImageFileName) Then
                Return True
            Else
                Return False
            End If
        End Function

        Public Function GetImageHeight(ByVal FileName As String) As Integer
            Dim objImage As System.Drawing.Image
            objImage = System.Drawing.Image.FromFile(FileName)

            Return objImage.Height
        End Function

        Public Function GetImageWidth(ByVal FileName As String) As Integer
            Dim objImage As System.Drawing.Image
            objImage = System.Drawing.Image.FromFile(FileName)

            Return objImage.Width
        End Function

        Public Function GetImageSizeFromUploadedFile(ByRef FileUploadObject As FileUpload) As Integer
            Return FileUploadObject.PostedFile.ContentLength
        End Function

        Public Function GetImageExtensionFromUploadedFile(ByRef FileUploadObject As FileUpload) As String
            Return Path.GetExtension(FileUploadObject.PostedFile.FileName)
        End Function

        Public Function GetImageExtensionFromFileName(ByVal FileName As String) As String
            Return Path.GetExtension(FileName)
        End Function
    End Class
End Namespace

