<%-- BeginRegion Page starting tags --%>
<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WebUserControl1.ascx.cs" Inherits="WebUserControl1" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.1, Version=9.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
<%-- EndRegion --%>

<dxe:ASPxLabel ID="ASPxLabel1" runat="server" Text="Master Row Data Description:" >
</dxe:ASPxLabel>
<br />
<dxe:ASPxMemo ID="ASPxMemo1" runat="server" Height="50px" Width="150px" ReadOnly="True" Text='<%# Eval("Description") %>'>
</dxe:ASPxMemo>    