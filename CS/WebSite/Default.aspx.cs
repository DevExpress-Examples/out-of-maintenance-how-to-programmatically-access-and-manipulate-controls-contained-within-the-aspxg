using System;
using DevExpress.Web.ASPxGridView;
using DevExpress.Web.ASPxTabControl;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void GridView_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e){
        ASPxGridView gridView = (ASPxGridView)sender;

        GridDataSource gridDataSource = new GridDataSource();
        gridDataSource.InsertRow(e.NewValues, gridView.SettingsDetail.IsDetailGrid);
        
        gridView.CancelEdit();
        e.Cancel = true;

        //Navigate to the newly inserted row within the grid and open its details
        gridView.MakeRowVisible(e.NewValues["ID"]);
        gridView.DetailRows.ExpandRowByKey(e.NewValues["ID"]);

        activeTabIndex = 1;
    }

    private int? activeTabIndex;

    protected void ASPxPageControl1_DataBound(object sender, EventArgs e){
        if (activeTabIndex.HasValue){
            //Change the ASPxPageControl's active tab page, and switch the detail grid to insert mode
            ASPxPageControl pageControl = sender as ASPxPageControl;
            pageControl.ActiveTabIndex = activeTabIndex.Value;
            ASPxGridView detailGrid = pageControl.FindControl("WebUserControl2").FindControl("gvDetail") as ASPxGridView;
            detailGrid.AddNewRow();
        }
    }
}
