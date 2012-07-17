<%@ Page Title="" ValidateRequest="false" Language="VB" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="false" CodeFile="AddTVCategory.aspx.vb" Inherits="Admin_AddTVCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentRight" Runat="Server">

				<!-- [Tab] -->
				<div style="display: none;">	
				
					<div class="form">
						<p><asp:Literal ID="litDescriptionAddTVCategory" runat="server"></asp:Literal></p>
 						<div class="clear"></div>	
					</div>
					
					<div class="form dropdown">				
						<div class="label"><label><asp:Literal ID="litExistingCategoriesTV" runat="server"></asp:Literal></label></div>
						<div class="baloon"><asp:Literal ID="imglitExistingCategoriesTV" runat="server"></asp:Literal></div>
						<div class="input"><asp:DropDownList ID="DropDownListTVCategories" runat="server" AutoPostBack="true"></asp:DropDownList></div>
						<div class="clear"></div>	
					</div>	

					<div class="form">				
						<div class="label"><label><asp:Literal ID="litAddTVCategoryName" runat="server"></asp:Literal></label></div>	
						<div class="baloon"><asp:Literal ID="imglitTVCategoryName" runat="server"></asp:Literal></div>	
						<div class="input"><asp:TextBox ID="txtCategoryName" runat="server"></asp:TextBox></div>	
						<div class="clear"></div>	
					</div>	
					
					<div class="form last">	    
						<asp:Button ID="btnAddNewTVCategory" runat="server" Text="" CssClass="submit" />  
						<div class="clear"></div>	
					</div>		
					
				<div class="clear"></div></div>		
				<!-- [/End Tab] -->						
	
</asp:Content>