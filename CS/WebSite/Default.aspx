<%-- BeginRegion Page starting tags --%>

<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dxwgv" %>
<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dxe" %>
    
<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dxw" %>
<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dxtc" %>

<%@ Register Src="WebUserControl1.ascx" TagName="WebUserControl1" TagPrefix="uc1" %>
<%@ Register Src="WebUserControl2.ascx" TagName="WebUserControl2" TagPrefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Manipulate Controls within DetailRow Tempate</title>
</head>
<body>
    <form id="form1" runat="server">
<%-- EndRegion --%>
    
<script type="text/javascript">
function DisableEditor(editor, e){
    editor.SetEnabled(false);
}
</script>
 
        <dxwgv:ASPxGridView ID="gvMaster" runat="server" DataSourceID="dsMaster" KeyFieldName="ID" OnRowInserting="GridView_RowInserting" AutoGenerateColumns="False" Width="300px" >
            <Templates>
                <DetailRow>

                    <dxtc:ASPxPageControl ID="ASPxPageControl1" runat="server" OnInit="ASPxPageControl1_DataBound" >
                        <TabPages>
                            <dxtc:TabPage Text="Description">
                                <ContentCollection>
                                    <dxw:ContentControl runat="server">
                                        <uc1:WebUserControl1 ID="WebUserControl1" runat="server" />
                                    </dxw:ContentControl>
                                </ContentCollection>
                            </dxtc:TabPage>
                            <dxtc:TabPage Text="Detail Data">
                                <ContentCollection>
                                    <dxw:ContentControl runat="server">
                                        <uc2:WebUserControl2 ID="WebUserControl2" runat="server">
                                        </uc2:WebUserControl2>                        
                                    </dxw:ContentControl>
                                </ContentCollection>
                            </dxtc:TabPage>
                        </TabPages>
                    </dxtc:ASPxPageControl>
                    
                </DetailRow>
            </Templates>
            <SettingsDetail ShowDetailRow="True" />
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
<%-- BeginRegion Data Column --%>                
                <dxwgv:GridViewDataTextColumn FieldName="Data" VisibleIndex="2">
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

<%-- BeginRegion Master Data Source --%>
        <asp:ObjectDataSource ID="dsMaster" runat="server" SelectMethod="GetMasterRows" TypeName="GridDataSource" >
        </asp:ObjectDataSource>       
<%-- EndRegion --%>
          
<%-- BeginRegion Page ending tags --%>
    </form>
</body>
</html>
<%-- EndRegion --%>
