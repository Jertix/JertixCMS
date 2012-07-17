<%@ Page Title="" ValidateRequest="false" Language="VB" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="false" CodeFile="AddChunk.aspx.vb" Inherits="Admin_AddChunk" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentRight" Runat="Server">

				<!-- [Tab] -->
				<div style="display: none;">	

					<div class="form">
						<p><asp:Literal ID="litDescriptionAddChunk" runat="server"></asp:Literal></p>					
						<div class="clear"></div>	
					</div>	

					<div class="form dropdown">
						<div class="label"><label><asp:Literal ID="litSelCategoriaChunk" runat="server"></asp:Literal></label></div>
						<div class="baloon"><asp:Literal ID="imglitExistingCategories" runat="server"></asp:Literal></div>						
						<div class="input"><asp:DropDownList ID="DropDownListCategorieChunk" runat="server" AutoPostBack="true"></asp:DropDownList></div>
						<div class="clear"></div>	
					</div>

					<div class="form dropdown">				
						<div class="label"><label><asp:Literal ID="litSelChunk" runat="server"></asp:Literal></label></div>
						<div class="baloon"><asp:Literal ID="imglitListChunks" runat="server"></asp:Literal></div>						
						<div class="input"><asp:DropDownList ID="DropDownListChunks" runat="server" AutoPostBack="true"></asp:DropDownList></div>
						<div class="clear"></div>	
					</div>

					<div class="form">		
						<div class="label"><label><asp:Literal ID="litChunkName" runat="server"></asp:Literal></label></div>
						<div class="baloon"><asp:Literal ID="imgChunkName" runat="server"></asp:Literal></div>						
						<div class="input"><asp:TextBox ID="txtChunkName" runat="server"></asp:TextBox></div>
						<div class="clear"></div>	
					</div>

					<div class="form textarea">					
						<div class="label"><label><asp:Literal ID="litTextChunk" runat="server"></asp:Literal></label></div>
						<div class="input"><asp:TextBox ID="txtChunk" runat="server" TextMode="MultiLine" Rows="20"></asp:TextBox></div> 
						<div class="clear"></div>
					</div>	 
					
 					<div class="form last">	
						<asp:Button ID="btnSalvaNuovoChunk" runat="server" Text="" CssClass="submit" />
						<div class="clear"></div>	
					</div>
					
					<div>
						<br /><asp:LinkButton ID="LinkButtonNuovaCategoria" runat="server"></asp:LinkButton>  
						<asp:Panel ID="PanelNuovaCategoria" runat="server" Visible="false">
							<asp:Label ID="lblNuovaCategoria" runat="server" Text="Label"></asp:Label>
							<asp:TextBox ID="txtNuovaCategoria" runat="server"></asp:TextBox>
							<asp:Button ID="btnSalvaNuovaCategoria" runat="server" Text="" />
						</asp:Panel>    
					</div>  

				<div class="clear"></div></div>		
				<!-- [/End Tab] -->					
					
</asp:Content>