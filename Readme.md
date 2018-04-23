# How to programmatically access and manipulate controls contained within the ASPxGridView's detail row template


<p>This example demonstrates how you can respond to insertion of a new master row into the grid to allow an end-user to enter the corresponding details immediately.</p><p>In this sample, the ASPxGridView is used in master-detail mode. Grid detail rows are represented by an  ASPxPageControl, which is placed within the grid's <strong>DetailRow</strong> template. <br />
The ASPxPageControl has two tab pages, which contain different UserControls. <br />
The first tab page has an ASPxMemo editor displaying master row description info. The second tab page's content is represented by another ASPxGridView control that maintains master row details.<br />
By default, the first tab page is active.</p><p>After an end-user inserts a new master row into the master grid, it is required to focus this row, open its detail row, make the ASPxPageControl's second tab page active and switch the detail grid to the insert mode.</p><p>This behavior is implemented by handling the master ASPxGridView's <strong>RowInserting</strong> event and the ASPxPageControl's <strong>DataBound</strong> event.</p>

<br/>


