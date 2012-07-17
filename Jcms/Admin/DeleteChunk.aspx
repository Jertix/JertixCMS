<%@ Page Title="" Language="VB" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="false" CodeFile="DeleteChunk.aspx.vb" Inherits="Admin_DeleteChunk" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentRight" Runat="Server">

				<!-- [Tab] -->
				<div style="display: none;">
				
					<div class="form">
						<p><asp:Literal ID="litDescriptionDeleteChunk" runat="server"></asp:Literal></p>
 						<div class="clear"></div>	
					</div>
	
					<div class="form dropdown">				
						<div class="label"><label><asp:Literal ID="litSelectChunk" runat="server"></asp:Literal></label></div>
						<div class="baloon"><asp:Literal ID="imglitSelChunk" runat="server"></asp:Literal></div>
						<div class="input"><asp:DropDownList ID="DropDownListChunkChunks" runat="server" AutoPostBack="true"></asp:DropDownList></div>
						<div class="clear"></div>	
					</div>	
					
					<div class="form last">	
						<asp:Button ID="btnEliminaChunk" runat="server" Text="" CssClass="submit" />  
						<div class="clear"></div>	
					</div>	
					
				<div class="clear"></div></div>		
				<!-- [/End Tab] -->						
					
</asp:Content>

