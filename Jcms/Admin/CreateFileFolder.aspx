<%@ Page Language="VB" AutoEventWireup="false" CodeFile="CreateFileFolder.aspx.vb" Inherits="Admin_CreateFileFolder" %>
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
			<div class="form">
				<p><asp:Literal ID="litDescriptionAddFolder" runat="server"></asp:Literal></p>
 				<div class="clear"></div>	
			</div>	
			<div class="form">				
				<div class="label"><label><asp:Literal ID="litFolderName" runat="server"></asp:Literal></label></div>
				<div class="baloon"><asp:Literal ID="imgFolderName" runat="server"></asp:Literal></div>
				<div class="input"><asp:TextBox ID="txtFolderName" runat="server" ></asp:TextBox></div>
				<div class="clear"></div>	
			</div>
			<div class="form">				
				<div class="input"><label><asp:Literal ID="litErrMess" runat="server"></asp:Literal></label></div>
				<div class="clear"></div>	
			</div>

			<div class="form last">	
				<asp:Button ID="btnSalvaNuovaCartella" runat="server" Text="" CssClass="submit" />  
                <asp:Button ID="btnAnnulla" runat="server" Text="" CssClass="submit" />
				<div class="clear"></div>	
			</div>	
    </form>
</body>
</html>
