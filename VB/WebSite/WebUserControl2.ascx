<%-- BeginRegion Page starting tags --%>
<%@ Control Language="vb" AutoEventWireup="true" CodeFile="WebUserControl2.ascx.vb" Inherits="WebUserControl2" %>

<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
	Namespace="DevExpress.Web" TagPrefix="dxwgv" %>
<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
	Namespace="DevExpress.Web" TagPrefix="dxe" %>
<%-- EndRegion --%>

<dxwgv:ASPxGridView ID="gvDetail" runat="server" DataSourceID="dsDetail" KeyFieldName="ID" OnBeforePerformDataSelect="gvDetail_BeforePerformDataSelect" AutoGenerateColumns="False" OnInitNewRow="gvDetail_InitNewRow" OnCellEditorInitialize="gvDetail_CellEditorInitialize" OnRowInserting="GridView_RowInserting">
	<SettingsDetail IsDetailGrid="True" />
	<Columns>
<%-- BeginRegion Command Column --%>
        <dxwgv:GridViewCommandColumn VisibleIndex="0" ShowNewButton="True"/>
<%-- EndRegion --%>  
<%-- BeginRegion ID Column --%>
		<dxwgv:GridViewDataTextColumn FieldName="ID" ReadOnly="True" VisibleIndex="1">
			<PropertiesTextEdit NullText="(Auto generated)">
				<ClientSideEvents Init="DisableEditor" />            
			</PropertiesTextEdit>        
		</dxwgv:GridViewDataTextColumn>
<%-- EndRegion --%>  
<%-- BeginRegion MasterID Column --%>        
		<dxwgv:GridViewDataTextColumn FieldName="MasterID" ReadOnly="True" VisibleIndex="2">
			<PropertiesTextEdit>
				<ClientSideEvents Init="DisableEditor" />
			</PropertiesTextEdit>
		</dxwgv:GridViewDataTextColumn>
<%-- EndRegion --%>  
<%-- BeginRegion DetailData Column --%>
		<dxwgv:GridViewDataTextColumn FieldName="DetailData" VisibleIndex="3">
			<EditFormSettings Caption="Detail&amp;nbsp;Data" />
			<PropertiesTextEdit>
				<ValidationSettings Display="Dynamic" SetFocusOnError="True">
					<RequiredField IsRequired="True" />
				</ValidationSettings>
				<ClientSideEvents Init="function(s, e){s.Focus();}" />
			</PropertiesTextEdit>
		</dxwgv:GridViewDataTextColumn>
<%-- EndRegion --%>  
	</Columns>
	<SettingsEditing EditFormColumnCount="1" />
</dxwgv:ASPxGridView> 

<%-- BeginRegion Detail Data Source --%>
<asp:ObjectDataSource ID="dsDetail" runat="server" SelectMethod="GetDetailRows" TypeName="GridDataSource">
	<SelectParameters>
		<asp:SessionParameter Name="masterId" SessionField="MasterID" Type="Int32" />
	</SelectParameters>
</asp:ObjectDataSource>
<%-- EndRegion --%>  