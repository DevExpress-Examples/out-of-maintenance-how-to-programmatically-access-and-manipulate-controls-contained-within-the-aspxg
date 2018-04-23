<%-- BeginRegion Page starting tags --%>
<%@ Control Language="vb" AutoEventWireup="true" CodeFile="WebUserControl1.ascx.vb" Inherits="WebUserControl1" %>
<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.2.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
	Namespace="DevExpress.Web" TagPrefix="dxe" %>
<%-- EndRegion --%>

<dxe:ASPxLabel ID="ASPxLabel1" runat="server" Text="Master Row Data Description:" >
</dxe:ASPxLabel>
<br />
<dxe:ASPxMemo ID="ASPxMemo1" runat="server" Height="50px" Width="150px" ReadOnly="True" Text='<%#Eval("Description")%>'>
</dxe:ASPxMemo>    