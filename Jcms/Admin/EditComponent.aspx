<%@ Page Title="" ValidateRequest="false" Language="VB" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="false" CodeFile="EditComponent.aspx.vb" Inherits="Admin_EditComponent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentRight" Runat="Server">

				<!-- [Tab] -->
				<div style="display: none;">	
				
					<div class="form">
						<p><asp:Literal ID="litDescriptionEditComponent" runat="server"></asp:Literal></p>
 						<div class="clear"></div>	
					</div>
	
					<div class="form dropdown">				
						<div class="label"><label><asp:Literal ID="litSelModule" runat="server"></asp:Literal></label></div>	
						<div class="baloon"><asp:Literal ID="imgSelModule" runat="server"></asp:Literal></div>					
						<div class="input"><asp:DropDownList ID="DropDownListModules" runat="server" AutoPostBack="true"></asp:DropDownList></div>
 						<div class="clear"></div>	
					</div>

					<div class="form dropdown">				
						<div class="label"><label><asp:Literal ID="litSelComponent" runat="server"></asp:Literal></label></div>	
						<div class="baloon"><asp:Literal ID="imgSelComponent" runat="server"></asp:Literal></div>					
						<div class="input"><asp:DropDownList ID="DropDownListComponents" runat="server" AutoPostBack="true"></asp:DropDownList></div>
 						<div class="clear"></div>	
					</div>

					<div class="form">				
						<div class="label"><label><asp:Literal ID="litEditComponentName" runat="server"></asp:Literal></label></div>	
						<div class="baloon"><asp:Literal ID="imgEditComponentName" runat="server"></asp:Literal></div>					
						<div class="input"><asp:TextBox ID="txtEditComponentName" runat="server"></asp:TextBox></div>
 						<div class="clear"></div>	
					</div>

					<div class="form">				
						<div class="label"><label><asp:Literal ID="litEditComponentFileName" runat="server"></asp:Literal></label></div>	
						<div class="baloon"><asp:Literal ID="imgEditComponentFileName" runat="server"></asp:Literal></div>					
						<div class="input"><asp:TextBox ID="txtEditComponentFileName" runat="server"></asp:TextBox></div>
 						<div class="clear"></div>	
					</div>

					<div class="form textarea">				
						<div class="label"><asp:Literal ID="litTextComponentExample" runat="server"></asp:Literal></div>
                        <div class="baloon"><asp:Literal ID="imgTextComponentExample" runat="server"></asp:Literal></div>	
						<div class="input"><asp:TextBox ID="txtTextComponentExample" runat="server" CssClass="form-input" TextMode="MultiLine" Rows="20"></asp:TextBox></div>	
   						<div class="clear"></div>	
					</div>
					
					<div class="form last">				
						<asp:Button ID="btnSalvaModificheComponente" runat="server" Text="" CssClass="submit" /> 
   						<div class="clear"></div>	
					</div>
			
				<div class="clear"></div></div>		
				<!-- [/End Tab] -->	
</asp:Content>

