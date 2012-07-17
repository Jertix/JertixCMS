<%@ Page Title="" Language="VB" ValidateRequest="false" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="false" CodeFile="AddTemplateVariable.aspx.vb" Inherits="Admin_AddTemplateVariable" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentRight" Runat="Server">

				<!-- [Tab] -->
				<div style="display: none;">	
				
					<div class="form">
						<p><asp:Literal ID="litDescriptionAddTemplateVariable" runat="server"></asp:Literal></p>
 						<div class="clear"></div>	
					</div>	
    
					<div class="form dropdown">				
						<div class="label"><label><asp:Literal ID="litSelCategoriaTemplateVariable" runat="server"></asp:Literal></label></div>
						<div class="baloon"><asp:Literal ID="imglitSelCategoriaTemplateVariable" runat="server"></asp:Literal></div>
						<div class="input"><asp:DropDownList ID="DropDownListCategorieTemplateVariable" runat="server" AutoPostBack="true"></asp:DropDownList></div>
						<div class="clear"></div>	
					</div>


					<div class="form">				
						<div class="label"><label><asp:Literal ID="litTemplateVariableName" runat="server"></asp:Literal></label></div>
						<div class="baloon"><asp:Literal ID="imglitTemplateVariableName" runat="server"></asp:Literal></div>
						<div class="input"><asp:TextBox ID="txtTemplateVariableName" runat="server"></asp:TextBox></div>
						<div class="clear"></div>	
					</div>


					<div class="form">				
						<div class="label"><label><asp:Literal ID="litTemplateVariableCaption" runat="server"></asp:Literal></label></div>
						<div class="baloon"><asp:Literal ID="imglitTemplateVariableCaption" runat="server"></asp:Literal></div>
						<div class="input"><asp:TextBox ID="txtTemplateVariableCaption" runat="server"></asp:TextBox></div>
						<div class="clear"></div>	
					</div>
    
					<div class="form">				
						<div class="label"><label><asp:Literal ID="litTemplateVariableDescription" runat="server"></asp:Literal></label></div>
						<div class="baloon"><asp:Literal ID="imglitTemplateVariableDescription" runat="server"></asp:Literal></div>
						<div class="input"><asp:TextBox ID="txtTemplateVariableDescription" runat="server" ></asp:TextBox></div>
						<div class="clear"></div>	
					</div>


					<div class="form dropdown">				
						<div class="label"><label><asp:Literal ID="litSelTipoTemplateVariable" runat="server"></asp:Literal></label></div>
						<div class="baloon"><asp:Literal ID="imglitSelTipoTemplateVariable" runat="server"></asp:Literal></div>
						<div class="input"><asp:DropDownList ID="DropDownListTipiTemplateVariable" runat="server" AutoPostBack="true"></asp:DropDownList></div>
 						<div class="clear"></div>	
					</div>
					
					<asp:Panel ID="PanelEsempioTemplateVariable" runat="server"></asp:Panel>

					<div class="form checkbox">				
						<div class="label"><label><asp:Panel ID="panelElencoTemplate" runat="server"></asp:Panel></label></div>
						<div class="input"><asp:Literal ID="imgPanelElencoTemplate" runat="server"></asp:Literal></div>
 						<div class="clear"></div>	
					</div>
					
					<div class="form checkbox">				
						<asp:Button ID="btnSalvaNuovoTemplateVariable" runat="server" Text="" CssClass="submit" />
 						<div class="clear"></div>	
					</div>
					
        <br /><br />

        <asp:LinkButton ID="LinkButtonNuovaCategoria" runat="server"></asp:LinkButton> 
        <asp:Panel ID="PanelNuovaCategoria" runat="server" Visible="false">
            <asp:Label ID="lblNuovaCategoria" runat="server" Text="Label"></asp:Label>
            <asp:TextBox ID="txtNuovaCategoria" runat="server"></asp:TextBox>
            <asp:Button ID="btnSalvaNuovaCategoria" runat="server" Text="" />
        </asp:Panel>
			
				<div class="clear"></div></div>		
				<!-- [/End Tab] -->	
				
</asp:Content>

