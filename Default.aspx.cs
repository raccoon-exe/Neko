﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.OleDb;

public partial class _Default : Page {
    private OleDbConnection _dConnection = new OleDbConnection(ConfigurationManager.ConnectionStrings["MmsydataConnectionString"].ConnectionString);
    private OleDbCommand _dCommand;
    private OleDbDataAdapter _dAdapter;
    private static System.Data.DataSet _mimsyRecordSet;
    private static string _query = "SELECT MIMSY1.counter, MIMSY1.Sorts, MIMSY1.objname AS [Title], MIMSY1.description AS [Description], MIMSY1.objtype AS [Object Type], MIMSY1.Key1 FROM MIMSY1";

    protected void Page_Load(object sender, EventArgs e) {
        if (!Page.IsPostBack) {
            // Query result columns.  These must map to selected columns (MIMSY1.foo) or their aliases (MIMSY1.foo AS [Bar])
            string[] columnNames = {"Sorts", "Title", "Description", "Object Type", "Key1"};
            // Record keys.  These must also map to selected columns or aliases.
            string[] keyNames = {"counter"};

            // Must be inital load -- Setup default page state.            
            ListItem hide = new ListItem("------------------------", "NULL");
            hide.Attributes.Add("disabled", "disabled");
            typesDropDown.AppendDataBoundItems = true;
            typesDropDown.Items.Insert(0, new ListItem("Any Type", "NULL"));
            typesDropDown.Items.Insert(1, hide);
            typesDropDown.DataSourceID = "MmsyDataSource";
            typesDropDown.DataTextField = "objtype";
            typesDropDown.DataValueField = "objtype";

            // Set gridview primary key
            documentGrid.DataKeyNames = keyNames;

            // Set gridview columns
            for (int i = 0; i < keyNames.Length; i++) {
                BoundField tempField = new BoundField();
                tempField.HeaderText = keyNames[i];
                tempField.DataField = keyNames[i];
                tempField.Visible = false;
                documentGrid.Columns.Add(tempField);
            }
            
            for (int i = 0; i < columnNames.Length; i++) {
                BoundField tempField = new BoundField();
                tempField.HeaderText = columnNames[i];
                tempField.DataField = columnNames[i];
                documentGrid.Columns.Add(tempField);
            }
        }
    }
    protected void doSearch(object sender, EventArgs e) {
        bool addAnd = false;
       
        if (typesDropDown.SelectedIndex != 0) {
            _query += " WHERE (MIMSY1.objtype = '" + typesDropDown.SelectedItem.Value + "')";
            addAnd = true;
        }

        if (titleSearchBox.Text.Length > 0) {
            if (addAnd) {
                _query += " AND ";
            }
            else {
                _query += " WHERE ";
            }

            _query += "(MIMSY1.objname LIKE '%" + titleSearchBox.Text + "%')";
        }

        _mimsyRecordSet = new System.Data.DataSet();
        _dCommand = new OleDbCommand(_query, _dConnection);
        _dConnection.Open();
        _dAdapter = new OleDbDataAdapter(_dCommand);
        _dAdapter.Fill(_mimsyRecordSet);
        _dConnection.Close();
        documentGrid.DataSource = _mimsyRecordSet;
        documentGrid.DataBind();
    }

    /* Grid view event handlers */
    private string ConvertSortDirectionToSql(SortDirection sortDirection)
    {
        string newSortDirection = String.Empty;

        switch (sortDirection)
        {
            case SortDirection.Ascending:
                newSortDirection = "ASC";
                break;

            case SortDirection.Descending:
                newSortDirection = "DESC";
                break;
        }

        return newSortDirection;
    }

    protected void gridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        documentGrid.PageIndex = e.NewPageIndex;
        documentGrid.DataSource = _mimsyRecordSet;
        documentGrid.DataBind();
    }

    protected void gridView_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dataTable = documentGrid.DataSource as DataTable;

        if (dataTable != null)
        {
            DataView dataView = new DataView(dataTable);
            dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);

            documentGrid.DataSource = dataView;
            documentGrid.DataBind();
        }
    }

    protected void gridView_getRecord(object sender, EventArgs e)
    {
        GridViewRow row = documentGrid.SelectedRow;
        string docId = documentGrid.DataKeys[documentGrid.SelectedIndex].Value.ToString();
        
    }
}
