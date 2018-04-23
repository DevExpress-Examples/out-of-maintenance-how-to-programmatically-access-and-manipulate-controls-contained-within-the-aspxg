Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.Web.ASPxGridView
Imports DevExpress.Web.ASPxEditors

Partial Public Class WebUserControl2
	Inherits System.Web.UI.UserControl
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

	End Sub

	Protected Sub gvDetail_BeforePerformDataSelect(ByVal sender As Object, ByVal e As EventArgs)
		Session("MasterID") = (TryCast(sender, ASPxGridView)).GetMasterRowKeyValue()
	End Sub
	Protected Sub gvDetail_InitNewRow(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataInitNewRowEventArgs)
                                Session("MasterID") = (TryCast(sender, ASPxGridView)).GetMasterRowKeyValue()
		e.NewValues("MasterID") = Session("MasterID").ToString()
	End Sub

	Protected Sub GridView_RowInserting(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataInsertingEventArgs)
		Dim gridView As ASPxGridView = CType(sender, ASPxGridView)

		Dim gridDataSource As New GridDataSource()
		gridDataSource.InsertRow(e.NewValues, gridView.SettingsDetail.IsDetailGrid)

		gridView.CancelEdit()
		e.Cancel = True
	End Sub
	Protected Sub gvDetail_CellEditorInitialize(ByVal sender As Object, ByVal e As ASPxGridViewEditorEventArgs)
		Dim gridView As ASPxGridView = CType(sender, ASPxGridView)
		If e.Column.FieldName = "MasterID" Then
			Dim textBoxMasterID As ASPxTextBox = CType(e.Editor, ASPxTextBox)
			If textBoxMasterID.Value Is Nothing Then
				textBoxMasterID.Value = gridView.GetMasterRowKeyValue()
			End If
		End If
	End Sub
End Class
