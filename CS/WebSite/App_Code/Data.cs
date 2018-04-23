using System;
using System.Data;
using System.Web;
using System.Web.SessionState;
using System.ComponentModel;
using System.Collections;
using System.Collections.Specialized;

public class GridDataSource {
    HttpSessionState Session { get { return HttpContext.Current.Session; } }

    public DataTable GetMasterRows(){
        return GetDataSource().Tables["MasterTable"] as DataTable;
    }

    public DataView GetDetailRows(int masterId){
        DataTable detailTable = GetDataSource().Tables["DetailTable"];
        DataView dataView = new DataView(detailTable);
        dataView.RowFilter = "MasterID = " + Session["MasterID"].ToString();
        return  dataView;
    }

    public void InsertRow(OrderedDictionary newValues, bool isDetail){
        DataTable dataTable = GetDataTable(isDetail);
        DataRow row = dataTable.NewRow();
        newValues["ID"] = dataTable.Rows.Count;
        IDictionaryEnumerator enumerator = newValues.GetEnumerator();
        enumerator.Reset();
        while (enumerator.MoveNext())
            if (enumerator.Key.ToString() != "Count")
                row[enumerator.Key.ToString()] = enumerator.Value;
        if (!isDetail) row["Description"] = "Auto generated description for Master Row " + newValues["ID"].ToString();
        dataTable.Rows.Add(row);
    }

    private DataTable GetDataTable(bool isDetail) {
        return isDetail ? GetDataSource().Tables["DetailTable"] : GetDataSource().Tables["MasterTable"];
    }

    private DataSet GetDataSource(){
        if (Session["GridDataSource"] == null) CreateGridDataSource();
        return Session["GridDataSource"] as DataSet;
    }

    private void CreateGridDataSource(){
        //Create a master table's structure
        DataTable masterTable = new DataTable("MasterTable");
        masterTable.Columns.Add("ID", typeof(int));
        masterTable.Columns.Add("Data", typeof(string));
        masterTable.Columns.Add("Description", typeof(string));
        masterTable.PrimaryKey = new DataColumn[] { masterTable.Columns["ID"] };
        
        //Create a detail table's structure
        DataTable detailTable = new DataTable("DetailTable");
        detailTable.Columns.Add("ID", typeof(int));
        detailTable.Columns.Add("MasterID", typeof(int));
        detailTable.Columns.Add("DetailData", typeof(string));
        detailTable.PrimaryKey = new DataColumn[] { detailTable.Columns["ID"] };

        //Populate data tables
        int index = 0;
        for (int i = 0; i < 15; i++){
            masterTable.Rows.Add(new object[] { i, "Master Row " + i.ToString(), "Description for Master Row " + i.ToString() });
            for (int j = 0; j < 5; j++)
                detailTable.Rows.Add(new object[] { index++, i, "Detail Row " + j.ToString() });
        }

        //Add tables to a data source, and store it within a Session 
        DataSet ds = new DataSet();
        ds.Tables.AddRange(new DataTable[] { masterTable, detailTable });
        Session["GridDataSource"] = ds;
    }
}