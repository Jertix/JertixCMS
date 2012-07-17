<%@ Page Title="" ValidateRequest="false" Language="VB" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="false" CodeFile="EditTemplate.aspx.vb" Inherits="Admin_EditTemplate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentRight" Runat="Server">

				<!-- [Tab] -->
				<div style="display: none;">	
				
					<div class="form">
						<p><asp:Literal ID="litDescriptionEditTemplate" runat="server"></asp:Literal></p>
 						<div class="clear"></div>	
					</div>
	
					<div class="form dropdown">				
						<div class="label"><label><asp:Literal ID="litSelTemplate" runat="server"></asp:Literal></label></div>	
						<div class="baloon"><asp:Literal ID="imgEditTemplate" runat="server"></asp:Literal></div>					
						<div class="input"><asp:DropDownList ID="DropDownListTemplates" runat="server" AutoPostBack="true"></asp:DropDownList></div>
 						<div class="clear"></div>	
					</div>

					<div class="form">				
						<div class="label"><label><asp:Literal ID="litEditTemplateName" runat="server"></asp:Literal></label></div>	
						<div class="baloon"><asp:Literal ID="imgEditTitoloTemplate" runat="server"></asp:Literal></div>					
						<div class="input"><asp:TextBox ID="txtTemplateName" runat="server"></asp:TextBox></div>
 						<div class="clear"></div>	
					</div>

					<div class="form">				
						<div class="label"><label><asp:Literal ID="litCommand" runat="server"></asp:Literal></label></div>
						<div class="baloon"><asp:Literal ID="imglitCommand" runat="server"></asp:Literal></div>
                        <div class="input"><asp:DropDownList ID="DropDownListCommandType" runat="server" AutoPostBack="true"></asp:DropDownList></div>		
                        <div class="input"><asp:DropDownList ID="DropDownListElements" runat="server" AutoPostBack="true"></asp:DropDownList></div>		
						<div class="input"><asp:TextBox ID="txtCommand" runat="server" TextMode="MultiLine"></asp:TextBox></div>
 						<div class="clear"></div>	
					</div>	

					<div class="form textarea">				
						<div class="label"><asp:Literal ID="litTextTemplate" runat="server"></asp:Literal></div>
                        <div class="baloon"><asp:Literal ID="imgTextTemplate" runat="server"></asp:Literal></div>	
						<div class="input"><asp:TextBox ID="txtTemplate" runat="server" CssClass="form-input" TextMode="MultiLine" Rows="20"></asp:TextBox></div>	
   						<div class="clear"></div>	
					</div>
					
					<div class="form last">				
						<asp:Button ID="btnSalvaModificheTemplate" runat="server" Text="" CssClass="submit" /> 
   						<div class="clear"></div>	
					</div>
			
				<div class="clear"></div></div>		
				<!-- [/End Tab] -->	

				<!-- [Tab] -->
				<div style="display: none;">
					<div id="dashboard" class="column-1">
						<div class="dashboard">	                	
                            <ul class="dash1">
                                <asp:Literal ID="litLiTVList" runat="server"></asp:Literal>
                            </ul>
                         </div>
                    </div>
				    <div class="clear"></div>
                </div>		
				<!-- [/End Tab] -->	
					
</asp:Content>

