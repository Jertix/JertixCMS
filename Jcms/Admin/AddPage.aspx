<%@ Page Title="" ValidateRequest="false" Language="VB" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="false" CodeFile="AddPage.aspx.vb" Inherits="Admin_AddPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentRight" Runat="Server">

				<!-- [Tab] -->
				<div style="display: none;">	
				
					<div class="form">
						<p><asp:Literal ID="litDescriptionAddHomePage" runat="server"></asp:Literal></p>
 						<div class="clear"></div>	
					</div>	
    
					<div class="form dropdown">				
						<div class="label"><label><asp:Literal ID="litSelTemplate" runat="server"></asp:Literal></label></div>
						<div class="baloon"><asp:Literal ID="imglitSelTemplate" runat="server"></asp:Literal></div>						
						<div class="input"><asp:DropDownList ID="DropDownListTemplates" runat="server" AutoPostBack="true"></asp:DropDownList></div>
						<div class="clear"></div>	
					</div>

					<div class="form">				
						<div class="label"><label><asp:Literal ID="litPageTitleCaption" runat="server"></asp:Literal></label></div>
						<div class="baloon"><asp:Literal ID="imgPageTitle" runat="server"></asp:Literal></div>
						<div class="input"><asp:TextBox ID="txtPageTitle" runat="server" ></asp:TextBox></div>
						<div class="clear"></div>	
					</div>

					<div class="form">				
						<div class="label"><label><asp:Literal ID="litTitleH1Caption" runat="server"></asp:Literal></label></div>
						<div class="baloon"><asp:Literal ID="imgTitleH1" runat="server"></asp:Literal></div>
						<div class="input"><asp:TextBox ID="txtTitleH1" runat="server" ></asp:TextBox></div>
						<div class="clear"></div>	
					</div>

					<div class="form">				
						<div class="label"><label><asp:Literal ID="litMetaDescriptionCaption" runat="server"></asp:Literal></label></div>
						<div class="baloon"><asp:Literal ID="imgMetaDescription" runat="server"></asp:Literal></div>
						<div class="input"><asp:TextBox ID="txtMetaDescription" runat="server" ></asp:TextBox></div>
						<div class="clear"></div>	
					</div>
					
					<div class="form">				
						<div class="label"><label><asp:Literal ID="litDescrizioneBreveMenu" runat="server"></asp:Literal></label></div>
						<div class="baloon"><asp:Literal ID="imgDescrizioneBreveMenu" runat="server"></asp:Literal></div>
						<div class="input"><asp:TextBox ID="txtDescrizioneBreveMenu" runat="server" ></asp:TextBox></div>
						<div class="clear"></div>	
					</div>
						
					<div class="form textarea tiny-advanced">
						<div class="label"><label><asp:Literal ID="litPageContent" runat="server"></asp:Literal></label></div>
						<div class="baloon"><asp:Literal ID="imgPageContent" runat="server"></asp:Literal></div>						
						<div class="input"><asp:TextBox ID="txtContent" runat="server" TextMode="MultiLine" Rows="20" Columns="25"></asp:TextBox></div>	
						<div class="clear"></div>	
					</div>
			
				<div class="clear"></div></div>		
				<!-- [/End Tab] -->	
	
				<!-- [Tab] -->
				<div style="display: none;">	
				<asp:PlaceHolder ID="PanelControlli" runat="server" EnableViewState="false"></asp:PlaceHolder>
				<div class="clear"></div></div>		
				<!-- [/End Tab] -->		
	
</asp:Content>

