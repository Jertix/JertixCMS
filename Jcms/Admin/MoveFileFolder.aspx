<%@ Page Language="VB" AutoEventWireup="true" CodeFile="MoveFileFolder.aspx.vb" Inherits="Admin_MoveFileFolder" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<title>JCMS Admin</title>

    <meta http-equiv="Page-Enter" content="blendTrans(Duration=0)" />
    <meta http-equiv="Page-Exit" content="blendTrans(Duration=0)" />

	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<link rel="stylesheet" type="text/css" href="css/default.css"/>
	<link rel="shortcut icon" href="favicon.ico" />	
	<!--[if IE 8]><link rel="stylesheet" type="text/css" href="css/ie8.css"/><![endif]-->	
	<!-- [JavaScripts] -->    
	<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.4/jquery.min.js"></script>
	<script type="text/javascript" src="js/jquery.js"></script>   
	<script type="text/javascript" src="js/script.js"></script>	
	<asp:Literal ID="litTinyInclude" runat="server"></asp:Literal>

</head>
<body>
    <form id="form1" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
			<div class="form">
				<p><asp:Literal ID="litDescriptionMoveFolder" runat="server"></asp:Literal></p>
 				<div class="clear"></div>	
			</div>
			<div class="form">				
				<div class="input"><label><asp:Literal ID="litSelezionaDestinazione" runat="server"></asp:Literal></label></div>
                
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="input"><label><asp:ListBox ID="listFileFoldersTree" AutoPostBack="true" runat="server" 
                                Font-Names="courier" Height="168px" Width="600px"></asp:ListBox></label></div>
                    </ContentTemplate>
                </asp:UpdatePanel>

                <div class="clear"></div>	
			</div>            	
			<div class="form">
            
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>            				
				        <div class="input"><label><asp:Literal ID="litErrMess" runat="server"></asp:Literal></label></div>
                    </ContentTemplate>
                </asp:UpdatePanel>


                <div class="clear"></div>	
			</div>

			<div class="form last">	
				<asp:Button ID="btnMoveFolderYes" runat="server" Text="" CssClass="submit" />  
                <asp:Button ID="btnMoveFolderNo" runat="server" Text="" CssClass="submit" />
				<div class="clear"></div>	
			</div>	
    </form>
</body>
</html>
