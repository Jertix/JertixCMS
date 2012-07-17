<%@ Page Language="VB" AutoEventWireup="false" CodeFile="DeleteWebSite.aspx.vb" Inherits="Admin_DeleteWebSite" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="background-color:white">
    <form id="form1" runat="server">
    <div>
    <asp:CheckBox ID="chkDeletePublicFolder" runat="server" Text="Delete Public Folder & Menu & Pages" Checked="true" /><br />
    <asp:CheckBox ID="chkDeleteChunks" runat="server" Text="Delete Chunks" Checked="true" /><br />
    <asp:CheckBox ID="chkDeleteModules" runat="server" Text="Delete Installaed Modules" Checked="false" /><br />
    <asp:CheckBox ID="chkDeleteTemplates" runat="server" Text="Delete Templates" Checked="true" /><br />
    <br />
    <br />
    Press button to DELETE<br />
    <asp:Button ID="btnDelete" runat="server" Text="Delete NOW!" />
    <br />
    <asp:Literal ID="litMess" runat="server"></asp:Literal>
    </div>
    </form>
</body>
</html>
