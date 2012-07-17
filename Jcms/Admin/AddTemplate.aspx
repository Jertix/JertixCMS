<%@ Page Title="" ValidateRequest="false" Language="VB" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="false" CodeFile="AddTemplate.aspx.vb" Inherits="Admin_AddTemplate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentRight" Runat="Server">

				<!-- [Tab] -->
				<div style="display: none;">	
				
					<div class="form">
						<p><asp:Literal ID="litDescriptionAddTemplate" runat="server"></asp:Literal></p>
 						<div class="clear"></div>	
					</div>	

					<div class="form dropdown">				
						<div class="label"><label><asp:Literal ID="litImportTemplate" runat="server"></asp:Literal></label></div>
						<div class="baloon"><asp:Literal ID="imglitImportTemplate" runat="server"></asp:Literal></div>			
						<div class="input"><asp:DropDownList ID="DropDownListTemplates" runat="server" AutoPostBack="true"></asp:DropDownList></div>				
 						<div class="clear"></div>	
					</div>	

					<div class="form">				
						<div class="label"><label><asp:Literal ID="litTemplateName" runat="server"></asp:Literal></label></div>
						<div class="baloon"><asp:Literal ID="imglitTemplateName" runat="server"></asp:Literal></div>
						<div class="input"><asp:TextBox ID="txtTemplateName" runat="server"></asp:TextBox></div>
 						<div class="clear"></div>	
					</div>	

					<div class="form textarea">				
						<div class="label"><label><asp:Literal ID="litTextTemplate" runat="server"></asp:Literal></label></div>
                        <div class="baloon"><asp:Literal ID="imgTextTemplate" runat="server"></asp:Literal></div>
						<div class="input"><asp:TextBox ID="txtTemplate" runat="server" TextMode="MultiLine" Rows="20"></asp:TextBox></div>	
  						<div class="clear"></div>	
					</div>	

					<div class="form last">				
						<asp:Button ID="btnSalvaNuovoTemplate" runat="server" Text="" CssClass="submit" />
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

