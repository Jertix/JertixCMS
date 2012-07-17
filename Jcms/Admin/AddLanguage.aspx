<%@ Page Title="" Language="VB" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="false" CodeFile="AddLanguage.aspx.vb" Inherits="Admin_AddLanguage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentRight" Runat="Server">

				<!-- [Tab] -->
				<div style="display: none;">
				
					<div class="form">
						<p><asp:Literal ID="litDescriptionAddLanguage" runat="server"></asp:Literal></p>
						<div class="clear"></div>	
					</div>	
					
					<div class="form dropdown">				
						<div class="label"><label><asp:Literal ID="litSelLingua" runat="server"></asp:Literal></label></div>
						<div class="baloon"><asp:Literal ID="imgHelpMessaggioLingue" runat="server"></asp:Literal></div>											
						<div class="input"><asp:DropDownList ID="DropDownListLingue" runat="server"></asp:DropDownList></div>						
						<div class="clear"></div>	
					</div>		
    
 					<div class="form last">	
						<asp:Button ID="btnAggiungiLingua" runat="server" Text="" CssClass="submit" /> <asp:Button ID="btnRimuoviLingua" runat="server" Text="" CssClass="submit" /> 
						<div class="clear"></div>	
					</div>
					
 
	
				<div class="clear"></div></div>		
				<!-- [/End Tab] -->		
	
</asp:Content>

