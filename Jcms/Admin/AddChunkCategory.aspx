<%@ Page Title="" ValidateRequest="false" Language="VB" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="false" CodeFile="AddChunkCategory.aspx.vb" Inherits="Admin_AddChunkCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentRight" Runat="Server">

				<!-- [Tab] -->
				<div style="display: none;">	

					<div class="form">
						<p><asp:Literal ID="litDescriptionAddChunkCategory" runat="server"></asp:Literal></p>
						<div class="clear"></div>	
					</div>	
			
					<div class="form dropdown">				
						<div class="label"><label><asp:Literal ID="litExistingCategories" runat="server"></asp:Literal></label></div>
						<div class="baloon"><asp:Literal ID="imglitExistingCategories" runat="server"></asp:Literal></div>
						<div class="input"><asp:DropDownList ID="DropDownListChunkCategories" runat="server" AutoPostBack="true"></asp:DropDownList></div>
						<div class="clear"></div>	
					</div>	


					<div class="form">				
						<div class="label"><label><asp:Literal ID="litAddCategoryName" runat="server"></asp:Literal></label></div>
						<div class="baloon"><asp:Literal ID="imglitCategoryName" runat="server"></asp:Literal></div>
						<div class="input"><asp:TextBox ID="txtCategoryName" runat="server"></asp:TextBox></div>
						<div class="clear"></div>	
					</div>	

 					<div class="form last">		   
						<asp:Button ID="btnAddNewCategory" runat="server" Text="" CssClass="submit" />
						<div class="clear"></div>	
					</div>

				<div class="clear"></div></div>		
				<!-- [/End Tab] -->					
					
</asp:Content>