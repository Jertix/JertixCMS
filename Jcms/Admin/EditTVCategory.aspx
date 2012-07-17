<%@ Page Title="" ValidateRequest="false" Language="VB" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="false" CodeFile="EditTVCategory.aspx.vb" Inherits="Admin_EditTVCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentRight" Runat="Server">

				<!-- [Tab] -->
				<div style="display: none;">	
				
					<div class="form">
						<p><asp:Literal ID="litDescriptionEditTVCategory" runat="server"></asp:Literal></p>
 						<div class="clear"></div>	
					</div>
					
					<div class="form dropdown">				
						<div class="label"><label><asp:Literal ID="litSelTVCategory" runat="server"></asp:Literal></label></div>
						<div class="baloon"><asp:Literal ID="imglitSelCategoriesTV" runat="server"></asp:Literal></div>
						<div class="input"><asp:DropDownList ID="DropDownListTVCategories" runat="server" AutoPostBack="true"></asp:DropDownList></div>
 						<div class="clear"></div>	
					</div>	

					<div class="form">				
						<div class="label"><label><asp:Literal ID="litEditTVCategoryName" runat="server"></asp:Literal></label></div>
						<div class="baloon"><asp:Literal ID="imglitCategoryName" runat="server"></asp:Literal></div>
						<div class="input"><asp:TextBox ID="txtCategoryName" runat="server"></asp:TextBox></div>
 						<div class="clear"></div>	
					</div>	
					
					<div class="form last">	    
						<asp:Button ID="btnSalvaModificheTVCategory" runat="server" Text="" CssClass="submit" />  
 						<div class="clear"></div>	
					</div>	
			
				<div class="clear"></div></div>		
				<!-- [/End Tab] -->						
	
</asp:Content>

