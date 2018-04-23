Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Web
Imports System.Web.SessionState
Imports System.ComponentModel
Imports System.Collections
Imports System.Collections.Specialized

Public Class GridDataSource
	Private ReadOnly Property Session() As HttpSessionState
		Get
			Return HttpContext.Current.Session
		End Get
	End Property

	Public Function GetMasterRows() As DataTable
		Return TryCast(GetDataSource().Tables("MasterTable"), DataTable)
	End Function

	Public Function GetDetailRows(ByVal masterId As Integer) As DataView
		Dim detailTable As DataTable = GetDataSource().Tables("DetailTable")
		Dim dataView As New DataView(detailTable)
		dataView.RowFilter = "MasterID = " & Session("MasterID").ToString()
		Return dataView
	End Function

	Public Sub InsertRow(ByVal newValues As OrderedDictionary, ByVal isDetail As Boolean)
		Dim dataTable As DataTable = GetDataTable(isDetail)
		Dim row As DataRow = dataTable.NewRow()
		newValues("ID") = dataTable.Rows.Count
		Dim enumerator As IDictionaryEnumerator = newValues.GetEnumerator()
		enumerator.Reset()
		Do While enumerator.MoveNext()
			If enumerator.Key.ToString() <> "Count" Then
				row(enumerator.Key.ToString()) = enumerator.Value
			End If
		Loop
		If (Not isDetail) Then
			row("Description") = "Auto generated description for Master Row " & newValues("ID").ToString()
		End If
		dataTable.Rows.Add(row)
	End Sub

	Public Function GetRowCount(ByVal isDetail As Boolean) As Integer
		Return GetDataTable(isDetail).Rows.Count
	End Function

	Private Function GetDataTable(ByVal isDetail As Boolean) As DataTable
		If isDetail Then
			Return GetDataSource().Tables("DetailTable")
		Else
			Return GetDataSource().Tables("MasterTable")
		End If
	End Function

	Private Function GetDataSource() As DataSet
		If Session("GridDataSource") Is Nothing Then
			CreateGridDataSource()
		End If
		Return TryCast(Session("GridDataSource"), DataSet)
	End Function

	Private Sub CreateGridDataSource()
		'Create a master table's structure
		Dim masterTable As New DataTable("MasterTable")
		masterTable.Columns.Add("ID", GetType(Integer))
		masterTable.Columns.Add("Data", GetType(String))
		masterTable.Columns.Add("Description", GetType(String))
		masterTable.PrimaryKey = New DataColumn() { masterTable.Columns("ID") }

		'Create a detail table's structure
		Dim detailTable As New DataTable("DetailTable")
		detailTable.Columns.Add("ID", GetType(Integer))
		detailTable.Columns.Add("MasterID", GetType(Integer))
		detailTable.Columns.Add("DetailData", GetType(String))
		detailTable.PrimaryKey = New DataColumn() { detailTable.Columns("ID") }

		'Populate data tables
		Dim index As Integer = 0
		For i As Integer = 0 To 14
			masterTable.Rows.Add(New Object() { i, "Master Row " & i.ToString(), "Description for Master Row " & i.ToString() })
			For j As Integer = 0 To 4
				detailTable.Rows.Add(New Object() { index, i, "Detail Row " & j.ToString() })
				index += 1
			Next j
		Next i
		'Add tables to a data source, and store it within a Session 
		Dim ds As New DataSet()
		ds.Tables.AddRange(New DataTable() { masterTable, detailTable })
		Session("GridDataSource") = ds
	End Sub
End Class