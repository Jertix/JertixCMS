<%@ Page Language="VB" AutoEventWireup="false" CodeFile="experiment.aspx.vb" Inherits="Admin_experiment" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script>
        function insertAtCursor(myField, myValue) {
            //IE support
            if (document.selection) {
                myField.focus();
                sel = document.selection.createRange();
                sel.text = myValue;
            }
            //MOZILLA/NETSCAPE support
            else if (myField.selectionStart || myField.selectionStart == '0') {
                var startPos = myField.selectionStart;
                var endPos = myField.selectionEnd;
                myField.value = myField.value.substring(0, startPos)
+ myValue
+ myField.value.substring(endPos, myField.value.length);
            } else {
                myField.value += myValue;
            }
        }    
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:TextBox ID="txt" runat="server" AutoPostBack="True" Height="266px" 
            TextMode="MultiLine" Width="626px"></asp:TextBox>
    
    </div>
    <asp:Button ID="btn1" runat="server" Text="Immagine" />
    <asp:Button ID="btn2" runat="server" Text="Slideshow" />
    <asp:Button ID="btn3" runat="server" Text="Gallery" />
    <asp:Button ID="btn4" runat="server" Text="Altro" />
    </form>
</body>
</html>
