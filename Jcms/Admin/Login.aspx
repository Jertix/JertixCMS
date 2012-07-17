<%@ Page Language="VB" AutoEventWireup="true" CodeFile="Login.aspx.vb" Inherits="Admin_Login" %><!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<title>JCMS Login</title>
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<link rel="stylesheet" type="text/css" href="css/default.css"/>
	<link rel="shortcut icon" href="favicon.ico" />	
	<!--[if IE 8]><link rel="stylesheet" type="text/css" href="css/ie8.css"/><![endif]-->	
	<!-- [JavaScripts] -->    
	<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.4/jquery.min.js"></script>
	<script type="text/javascript" src="js/jquery.js"></script>   
	<script type="text/javascript" src="js/script.js"></script>	
</head>

<body class="login">
    <form id="form1" runat="server">
	
<!-- [Header] -->
<div id="header-wrapper">
	<div id="header-wrapper-2">
		<div id="header">	

			<!-- [Top Menu] -->
			<div id="topmenu">
				<ul>
					<li class="last">&nbsp;</li>	
				</ul>	
			</div>
			<!-- [/End Top Menu] -->

			<!-- [Main Menu] -->			
			<div id="mainmenu">
		        <ul>
					<li class="mainmenu-home"><a href="#"><img src="img/general/logo.png" alt="JCMS" title="JCMS  <asp:Literal ID="litcmsVersion" runat="server"></asp:Literal>" /></a><span class="mainmenu-separator"></span></li>	
		        </ul>			
			</div>
			<!-- [/End Main Menu] -->

		</div><div class="shadow"></div>	
	</div>
</div>
<!-- [/End Header] -->

<!-- [Container] -->
<div id="container">

    <div id="content">
		<!-- [Left Menu] -->
		<div id="left">
		<div class="sidebar-left"> 
			<div class="tree-title"><h2><asp:Literal ID="litNomeSito" runat="server"></asp:Literal></h2></div>
			
				<!-- [Form] -->			
				<div class="form">		
					<div class="label"><label><asp:Literal ID="litUserName" runat="server"></asp:Literal></label></div>
					<div class="baloon"><asp:Literal ID="imglitUserName" runat="server"></asp:Literal></div>					
					<div class="input"><asp:TextBox ID="txtUserName" runat="server"></asp:TextBox></div>
				</div>	

				<div class="form">
					<div class="label"><label><asp:Literal ID="litPassword" runat="server"></asp:Literal></label></div>
					<div class="baloon"><asp:Literal ID="imglitPassword" runat="server"></asp:Literal></div>
					<div class="input"><asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox></div>
				</div>	

				<div class="form checkbox">						
					<asp:Button ID="btnLogin" runat="server" Text="" CssClass="submit"/> 
					<div class="input"><asp:CheckBox ID="checkbox" runat="server"/><asp:literal ID="lblMessaggio" runat="server"></asp:literal></div>
					<div class="clear"></div>
				</div>	
				<!-- [/End Form] -->
				
		</div>        
		</div>
		<!-- [/End Left Menu] -->   
    <div class="forgotpass"><asp:LinkButton ID="lnkPasswordDimenticata" runat="server"></asp:LinkButton></div>  
    </div>
	<!-- [/End Content] -->
	
</div>
<!-- [/End Container] -->

<!-- [Footer] -->
<div id="footer">
	<div><p><strong><a href="mailto:info@jertix.org"><asp:Literal ID="litRichiediSupporto" runat="server"></asp:Literal></a></strong>  - Copyright &copy; <asp:Literal ID="litYear" runat="server"></asp:Literal> JCMS - <asp:Literal ID="litTuttiIDiritti" runat="server"></asp:Literal></p></div>
</div>
<!-- [/End Footer] -->

    </form>
</body>
</html>
