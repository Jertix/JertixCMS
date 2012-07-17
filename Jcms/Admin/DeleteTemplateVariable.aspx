<%@ Page Title="" Language="VB" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="false" CodeFile="DeleteTemplateVariable.aspx.vb" Inherits="Admin_DeleteTemplateVariable" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentRight" Runat="Server">

				<!-- [Tab] -->
				<div style="display: none;">	
				
					<div class="form">
						<p><asp:Literal ID="litDescriptionDeleteTV" runat="server"></asp:Literal></p>
 						<div class="clear"></div>	
					</div>	
					
					<div class="form dropdown">				
						<div class="label"><label><asp:Literal ID="litSelectTV" runat="server"></asp:Literal></label></div>	
						<div class="baloon"><asp:Literal ID="imglitSelTV" runat="server"></asp:Literal></div>	
						<div class="input"><asp:DropDownList ID="DropDownListTVs" runat="server" AutoPostBack="true"></asp:DropDownList></div>	
 						<div class="clear"></div>	
					</div>
	
					<div class="form last">	   
						<asp:Button ID="btnEliminaTV" runat="server" Text="" CssClass="submit" />
 						<div class="clear"></div>	
					</div>
					
				<div class="clear"></div></div>		
				<!-- [/End Tab] -->		
				
</asp:Content>

