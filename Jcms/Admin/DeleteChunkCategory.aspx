<%@ Page Language="VB" AutoEventWireup="false"  MasterPageFile="~/Admin/MasterPage.master" CodeFile="DeleteChunkCategory.aspx.vb" Inherits="Admin_DeleteChunkCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentRight" Runat="Server">

				<!-- [Tab] -->
				<div style="display: none;">
				
					<div class="form">
						<p><asp:Literal ID="litDescriptionDeleteChunkCategory" runat="server"></asp:Literal></p>
 						<div class="clear"></div>	
					</div>
	
					<div class="form dropdown">				
						<div class="label"><label><asp:Literal ID="litSelCategory" runat="server"></asp:Literal></label></div>	
						<div class="baloon"><asp:Literal ID="imglitSelCategories" runat="server"></asp:Literal></div>	
						<div class="input"><asp:DropDownList ID="DropDownListChunkCategories" runat="server" AutoPostBack="true"></asp:DropDownList></div>	
 						<div class="clear"></div>	
					</div>
					
 					<div class="form last">	   
						<asp:Button ID="btnEliminaCategoria" runat="server" Text="" CssClass="submit" />  
 						<div class="clear"></div>	
					</div>
					
				<div class="clear"></div></div>		
				<!-- [/End Tab] -->	
				
</asp:Content>
