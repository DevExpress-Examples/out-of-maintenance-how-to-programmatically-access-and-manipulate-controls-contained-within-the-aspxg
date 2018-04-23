Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.Web.ASPxGridView
Imports DevExpress.Web.ASPxTabControl

Partial Public Class _Default
	Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

	End Sub

	Protected Sub GridView_RowInserting(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataInsertingEventArgs)
		Dim gridView As ASPxGridView = CType(sender, ASPxGridView)

		Dim gridDataSource As New GridDataSource()
		gridDataSource.InsertRow(e.NewValues, gridView.SettingsDetail.IsDetailGrid)

		gridView.CancelEdit()
		e.Cancel = True

		'Navigate to the newly inserted row within the grid and open its details
		Dim newRowIndex As Integer = gridView.FindVisibleIndexByKeyValue(e.NewValues("ID"))

		gridView.PageIndex = newRowIndex / gridView.SettingsPager.PageSize
		gridView.DetailRows.ExpandRow(newRowIndex)

		activeTabIndex = 1
	End Sub

	Private activeTabIndex As Nullable(Of Integer)


	Protected Sub ASPxPageControl1_DataBound(ByVal sender As Object, ByVal e As EventArgs)
		If activeTabIndex.HasValue Then
			'Change the ASPxPageControl's active tab page, and switch the detail grid to insert mode
			Dim pageControl As ASPxPageControl = TryCast(sender, ASPxPageControl)
			pageControl.ActiveTabIndex = activeTabIndex.Value
			Dim detailGrid As ASPxGridView = TryCast(pageControl.FindControl("WebUserControl2").FindControl("gvDetail"), ASPxGridView)
			detailGrid.AddNewRow()
		End If
	End Sub
End Class
