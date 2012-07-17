Imports Microsoft.VisualBasic
Imports System.Xml
Imports System.Text
Imports System.Collections.Generic

Namespace Jertix.Functions

    Public Class JertCMSXMLClass

        'Esempio di utilizzo...

        'Dim testXML As New JertCMSXMLClass(Server.MapPath("TestXML.xml"))
        'With testXML
        '    .WriteStartDocument("ProvaRoot")

        '    .WriteStartElement("Stato")
        '    .WriteAttributeString("nome", "Italia")
        '    .WriteAttributeString("abitanti", "65 milioni")
        '    .WriteElementString("Citta", "Milano")
        '    .WriteStartElement("Quartieri")
        '    .WriteElementString("nome", "Filippino 1")
        '    .WriteElementString("nome", "Filippino 2")
        '    .WriteEndElement()
        '    .WriteElementString("Citta", "Cagliari")
        '    .WriteEndElement()
        '    .WriteEndDocument()
        'End With

        'Output:

        '<?xml version="1.0" encoding="utf-8"?>
        '<ProvaRoot>
        '	<Stato nome="Italia" abitanti="65 milioni">
        '		<Citta>Milano</Citta>
        '			<Quartieri>
        '				<nome>Filippino 1</nome>
        '				<nome>Filippino 2</nome>
        '			</Quartieri>
        '		<Citta>Cagliari</Citta>
        '	</Stato>
        '</ProvaRoot>


        Dim writer As XmlTextWriter

        Sub New(ByVal FileName As String)
            writer = New XmlTextWriter(FileName, Encoding.UTF8)
        End Sub

        Sub New()
            ' TODO: Complete member initialization 
        End Sub

        Public Sub WriteStartDocument(ByVal TagName As String)
            writer.WriteStartDocument()
            writer.WriteStartElement(TagName)
        End Sub

        Public Sub WriteEndDocument()
            writer.WriteEndDocument()
            writer.Close()
        End Sub

        Public Sub WriteStartElement(ByVal ElementName As String)
            writer.WriteStartElement(ElementName)
        End Sub

        Public Sub WriteEndElement()
            writer.WriteEndElement()
        End Sub

        Public Sub WriteElementString(ByVal localName As String, ByVal Value As String)
            writer.WriteElementString(localName, Value)
        End Sub

        Public Sub WriteAttributeString(ByVal localName As String, ByVal Value As String)
            writer.WriteAttributeString(localName, Value)
        End Sub

        Public Function ReadXMLSettingInnerText(ByVal XPathQuery As String, Optional ByVal FileName As String = "Setting.xml") As String
            Dim path As String = System.AppDomain.CurrentDomain.BaseDirectory & FileName
            Dim Doc As New XmlDocument()
            Doc.Load(path)
            Dim node As XmlNode = Doc.SelectSingleNode(XPathQuery)
            Return node.InnerText
        End Function

        Public Function ReadXMLFromfile(ByVal XPathQuery As String, ByVal FileName As String) As String
            'Esempio di utilizzo (litXMLFile è <asp:Literal ID="litXMLFile" runat="server"></asp:Literal> dentro il form)
            'litXMLFile.Text = ReadXML("//root/record", "test.xml")

            Dim retValue As String = ""

            Dim path As String = HttpContext.Current.Server.MapPath(FileName)
            Dim Doc As New XmlDocument()
            Doc.Load(path)
            Dim node As XmlNodeList = Doc.SelectNodes(XPathQuery)

            For numElemento As Integer = 0 To node.Count - 1
                retValue &= "Nodo(" & numElemento & ") Nome = " & node(numElemento).Name & "<br/>" & vbCrLf

                For j As Integer = 0 To node(numElemento).ChildNodes.Count - 1

                    Dim NomeElemento As String = node(numElemento).ChildNodes(j).Name
                    Dim ValoreElemento As String = node(numElemento).ChildNodes(j).InnerText

                    retValue &= "->" & NomeElemento & " = " & ValoreElemento & "<br/>" & vbCrLf

                    'Qui ti crei la funzione per salvare i valori nel db..
                    'Es.: SalvaRecord(numElemento,NomeElemento,ValoreElemento)
                Next
            Next

            Return retValue
        End Function

        Public Function ReadXMLFromText(ByVal XPathQuery As String, ByVal TextToRead As String) As String
            Dim retValue As String = ""

            If TextToRead.Trim.Length = 0 Then Return retValue

            Dim Doc As New XmlDocument()

            Doc.LoadXml(TextToRead)

            Dim node As XmlNodeList = Doc.SelectNodes(XPathQuery)

            For numElemento As Integer = 0 To node.Count - 1
                'retValue &= "Nodo(" & numElemento & ") Nome = " & node(numElemento).Name & "<br/>" & vbCrLf
                retValue &= node(numElemento).InnerText
                For j As Integer = 0 To node(numElemento).ChildNodes.Count - 1

                    Dim NomeElemento As String = node(numElemento).ChildNodes(j).Name
                    Dim ValoreElemento As String = node(numElemento).ChildNodes(j).InnerText

                    'retValue &= "->" & NomeElemento & " = " & ValoreElemento & "<br/>" & vbCrLf

                    'Qui ti crei la funzione per salvare i valori nel db..
                    'Es.: SalvaRecord(numElemento,NomeElemento,ValoreElemento)
                Next
            Next

            Return retValue
        End Function

        Public Function ReadXMLListFromText(ByVal XPathQuery As String, ByVal TextToRead As String, ByVal AppendXMLHeaderAndRoot As Boolean) As List(Of String)
            Dim retValue As New List(Of String)

            If TextToRead.Trim.Length = 0 Then Return retValue

            Dim Doc As New XmlDocument()
            Doc.LoadXml(TextToRead)

            Dim node As XmlNodeList = Doc.SelectNodes(XPathQuery)
            Dim tmpXML As String

            For numElemento As Integer = 0 To node.Count - 1
                'retValue &= "Nodo(" & numElemento & ") Nome = " & node(numElemento).Name & "<br/>" & vbCrLf
                tmpXML = node(numElemento).InnerXml

                If AppendXMLHeaderAndRoot = True Then
                    tmpXML = "<?xml version='1.0' encoding='UTF-8'?><root>" & tmpXML & "</root>"
                End If

                retValue.Add(tmpXML)
                'For j As Integer = 0 To node(numElemento).ChildNodes.Count - 1

                '    Dim NomeElemento As String = node(numElemento).ChildNodes(j).Name
                '    Dim ValoreElemento As String = node(numElemento).ChildNodes(j).InnerText

                '    'retValue &= "->" & NomeElemento & " = " & ValoreElemento & "<br/>" & vbCrLf

                '    'Qui ti crei la funzione per salvare i valori nel db..
                '    'Es.: SalvaRecord(numElemento,NomeElemento,ValoreElemento)
                'Next
            Next

            Return retValue
        End Function


        Public Function SaveXMLSettingInnerText(ByVal XPathQuery As String, ByVal Value As String, Optional ByVal FileName As String = "Setting.xml") As Boolean
            Dim path As String = System.AppDomain.CurrentDomain.BaseDirectory & FileName
            Dim Doc As New XmlDocument()
            Doc.Load(path)
            Dim node As XmlNode = Doc.SelectSingleNode(XPathQuery)
            node.InnerText = Value
            Doc.Save(FileName)
            Return True
        End Function

    End Class

End Namespace