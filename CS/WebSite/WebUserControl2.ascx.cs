using System;
using DevExpress.Web.ASPxGridView;
using DevExpress.Web.ASPxEditors;

public partial class WebUserControl2 : System.Web.UI.UserControl {
    protected void Page_Load(object sender, EventArgs e) {

    }

    protected void gvDetail_BeforePerformDataSelect(object sender, EventArgs e){
        Session["MasterID"] = (sender as ASPxGridView).GetMasterRowKeyValue();
    }
    protected void gvDetail_InitNewRow(object sender, DevExpress.Web.Data.ASPxDataInitNewRowEventArgs e){
        Session["MasterID"] = (sender as ASPxGridView).GetMasterRowKeyValue();
        e.NewValues["MasterID"] = Session["MasterID"].ToString();
    }

    protected void GridView_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e){
        ASPxGridView gridView = (ASPxGridView)sender;

        GridDataSource gridDataSource = new GridDataSource();
        gridDataSource.InsertRow(e.NewValues, gridView.SettingsDetail.IsDetailGrid);

        gridView.CancelEdit();
        e.Cancel = true;
    }
    protected void gvDetail_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e) {
        ASPxGridView gridView = (ASPxGridView)sender;
        if (e.Column.FieldName == "MasterID") {
            ASPxTextBox textBoxMasterID = (ASPxTextBox)e.Editor;
            if (textBoxMasterID.Value == null)
                textBoxMasterID.Value = gridView.GetMasterRowKeyValue();
        }
    }
}
