<%@ Page Title="" ValidateRequest="false" Language="VB" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="false" CodeFile="DeleteTemplate.aspx.vb" Inherits="Admin_DeleteTemplate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentRight" Runat="Server">

				<!-- [Tab] -->
				<div style="display: none;">	
				
					<div class="form">
						<p><asp:Literal ID="litDescriptionDeleteTemplate" runat="server"></asp:Literal></p>
 						<div class="clear"></div>	
					</div>	

					<div class="form dropdown">				
						<div class="label"><label><asp:Literal ID="litSelTemplate" runat="server"></asp:Literal></label></div>	
						<div class="baloon"><asp:Literal ID="imglitTemplates" runat="server"></asp:Literal></div>	
						<div class="input"><asp:DropDownList ID="DropDownListTemplates" runat="server" AutoPostBack="true"></asp:DropDownList></div>	
 						<div class="clear"></div>	
					</div>	

					<div class="form last">						
						<asp:Button ID="btnEliminaTemplate" runat="server" Text="" CssClass="submit" />
 						<div class="clear"></div>	
					</div>	
					
				<div class="clear"></div></div>		
				<!-- [/End Tab] -->						
	
</asp:Content>



