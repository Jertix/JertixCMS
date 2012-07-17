Imports Microsoft.VisualBasic
Imports System.Xml

Namespace Jertix.Resources

    ''' <summary>
    ''' jCMS: Class to Localize Strings (Reading / Writing)
    ''' </summary>
    ''' <remarks>Class to Localize Strings</remarks>
    Public Class ClassResources

        ''' <summary>
        ''' jCMS: A Simple Read/Write Test
        ''' </summary>
        ''' <remarks>A Simple Read/Write Test</remarks>
        Public Sub TestReadWriteXMLResource()
            Dim fileName As String = HttpContext.Current.Server.MapPath("/App_GlobalResources/Admin.resx")

            Dim tmpDocument As New XmlDocument
            tmpDocument.Load(fileName)


            '<data name="btnLogin" xml:space="preserve">
            '    <value>Accedi</value>
            '</data>

            Dim tmpNodo As XmlNode = tmpDocument.SelectSingleNode("root/data[@name='btnLogin']/value")

            Dim tmpValue As String = ""

            If Not tmpNodo Is Nothing Then
                'Read..
                tmpValue = tmpNodo.InnerText

                'Edit..
                tmpNodo.InnerText = tmpValue & " Edited at " & Now.ToString

                'Save..
                tmpDocument.Save(fileName)
            End If


        End Sub

    End Class

End Namespace


