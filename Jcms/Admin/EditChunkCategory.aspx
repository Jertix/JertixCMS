<%@ Page Title="" ValidateRequest="false" Language="VB" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="false" CodeFile="EditChunkCategory.aspx.vb" Inherits="Admin_EditChunkCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentRight" Runat="Server"> 

				<!-- [Tab] -->
				<div style="display: none;">	
				
					<div class="form">
						<p><asp:Literal ID="litDescriptionEditChunkCategory" runat="server"></asp:Literal></p>
 						<div class="clear"></div>	
					</div>
					
					<div class="form dropdown">				
						<div class="label"><label><asp:Literal ID="litSelCategory" runat="server"></asp:Literal></label></div>
						<div class="baloon"><asp:Literal ID="imglitSelCategories" runat="server"></asp:Literal></div>
						<div class="input"><asp:DropDownList ID="DropDownListChunkCategories" runat="server" AutoPostBack="true"></asp:DropDownList></div>
 						<div class="clear"></div>	
					</div>					

					<div class="form">				
						<div class="label"><label><asp:Literal ID="litEditTemplateName" runat="server"></asp:Literal></label></div>	
						<div class="baloon"><asp:Literal ID="imglitCategoryName" runat="server"></asp:Literal></div>
						<div class="input"><asp:TextBox ID="txtCategoryName" runat="server"></asp:TextBox></div>		
 						<div class="clear"></div>	
					</div>		
								
 					<div class="form last">	   
						<asp:Button ID="btnSalvaModificheTemplate" runat="server" Text="" CssClass="submit" />  
	 						<div class="clear"></div>	
					</div>	
			
				<div class="clear"></div></div>		
				<!-- [/End Tab] -->	
					
</asp:Content>

