<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FileBrowser.aspx.vb" Inherits="Admin_FileBrowser" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">


<head>
	<title>JCMS Admin</title>
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<link rel="stylesheet" type="text/css" href="css/default.css"/>

	<link rel="shortcut icon" href="favicon.ico" />	
	<!--[if IE 8]><link rel="stylesheet" type="text/css" href="css/ie8.css"/><![endif]-->	
	<!-- [JavaScripts] -->    
	<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.4/jquery.min.js"></script>
	<script type="text/javascript" src="js/jquery.js"></script>  
    <script type="text/javascript" src="js/script.js"></script>
    
    <asp:Literal id="litJsHeader" runat="server"></asp:Literal>

</head>

<body id="browse">
<form id="Form1" runat="server">

<!-- [Header] -->
<div id="header-wrapper">
	<div id="header-wrapper-2">
		<div id="header">	

			<!-- [Main Menu] -->			
			<div id="mainmenu">
				<ul>
					<li>JertixCMS Browse</li>						
				</ul>		
			</div>
			<!-- [/End Main Menu] -->

			<!-- [Buttons] -->			
			<div id="buttons">
				<ul>
					<li class="btn-save"><a href="#salva">Salva</a></li>
					<li class="btn-delete"><a href="#" onclick="window.parent.Shadowbox.close()">Chiudi</a></li>	
				</ul>		
			</div>

			<!-- [/End Buttons] -->
		</div><div class="shadow"></div>	
	</div>
</div>
<!-- [/End Header] -->

<!-- [Container] -->
<div id="container">
    <!-- [Left Menu] -->
    <div id="left">

		<div class="sidebar-left">		
			<!-- Website Tree --> 
			<h2><asp:Literal ID="litUploadfile" runat="server"></asp:Literal><span></span></h2>

			<ul id="browser-upload" class="filetree">		
				<li class="upload"><input type="file" /></li>
				<li class="btn-upload"><input type="submit" value="Upload" class="submit" /></li>
			</ul> 			
		</div>	

		<!-- [Cartelle Context Menu] -->       
            <asp:Literal id="litContextMenu" runat="server"></asp:Literal>
		<!-- [/End Cartelle Context Menu] -->	

		<!-- [Cartelle Menu] --> 	
		<div class="sidebar-left"> 		   
			<h2><asp:Literal ID="litFolders" runat="server"></asp:Literal></h2>
			<ul id="browser-admin" class="filetree">
                <asp:Literal ID="litImmagini" runat="server"></asp:Literal>
				<asp:Literal ID="litVideo" runat="server"></asp:Literal>
				<asp:Literal ID="litFiles" runat="server"></asp:Literal>           
			</ul>   		
		</div>
 		<!-- [/End Development Menu] --> 

    </div>
	<!-- [/End Left Menu] -->

	<!-- [Content] -->
	<div id="content">

		<!-- [Gallery] --> 	
		<div class="gallery">
			<!-- [Img] --> 		
            <div class="gallery-wrapper">
				<a class="gallery-img" href="popup2.htm"><img alt="#" src="img/pics/img06.jpg" /></a>
				<a class="gallery-edit" title="Edita Titolo Immagine" href="#"></a>
				<a class="gallery-move" title="Sposta immagine" href="#"></a>				
				<a class="gallery-delete" title="Elimina Immagine" href="#"></a>
				<div class="gallery-info">wireless-usb-01.jpg</div>
			</div>
			<!-- [/End Img] --> 			

        <div class="clear"></div></div>
		<!-- [/End Gallery] --> 	

	</div>
	<!-- [/End Content] -->

</div>
<!-- [/End Container] -->

</form>
</body>

</html>