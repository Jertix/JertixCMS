<%@ Page Title="" Language="VB" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="false" CodeFile="DeleteTVCategory.aspx.vb" Inherits="Admin_DeleteTVCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentRight" Runat="Server">

				<!-- [Tab] -->
				<div style="display: none;">	
				
					<div class="form">
						<p><asp:Literal ID="litDescriptionDeleteTVCategory" runat="server"></asp:Literal></p>
 						<div class="clear"></div>	
					</div>
					
					<div class="form dropdown">				
						<div class="label"><label><asp:Literal ID="litSelTVCategory" runat="server"></asp:Literal></label></div>	
						<div class="baloon"><asp:Literal ID="imglitSelTVCategories" runat="server"></asp:Literal></div>	
						<div class="input"><asp:DropDownList ID="DropDownListTVCategories" runat="server" AutoPostBack="true"></asp:DropDownList></div>	
 						<div class="clear"></div>	
					</div>	

			
 					<div class="form last">   
						<asp:Button ID="btnEliminaCategoriaTV" runat="server" Text="" CssClass="submit" /> 
 						<div class="clear"></div>	
					</div>	
			
				<div class="clear"></div></div>		
				<!-- [/End Tab] -->	
						
</asp:Content>

