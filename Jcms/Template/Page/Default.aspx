<%@ Page Title="" Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<asp:Literal id="litPageHeader" runat="server"></asp:Literal>
<asp:Literal id="litBodyOpen" runat="server"></asp:Literal>
    <form id="form1" runat="server">

<%--        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <asp:updatepanel runat="server">
            <ContentTemplate>--%>
                <asp:PlaceHolder runat="server" ID="PlaceContentPage" />
<%--            </ContentTemplate>
        </asp:updatepanel>--%>

    </form>
<asp:Literal id="litBodyClose" runat="server"></asp:Literal>