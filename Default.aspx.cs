using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.OleDb;


public partial class _Default : Page {
    protected void Page_Load(object sender, EventArgs e) {
        if (!Page.IsPostBack) {
            ListItem hide = new ListItem("------------------------", "NULL");
            hide.Attributes.Add("disabled", "disabled");
            typesDropDown.AppendDataBoundItems = true;
            typesDropDown.Items.Insert(0, new ListItem("Any Type", "NULL"));
            typesDropDown.Items.Insert(1, hide);
            typesDropDown.DataSourceID = "MmsyDataSource";
            typesDropDown.DataTextField = "objtype";
            typesDropDown.DataValueField = "objtype";
        }
    }
    protected void doSearch(object sender, EventArgs e) {
        /* Search query:
         *     SELECT MIMSY1.Sorts, MIMSY1.objname AS [Title], MIMSY1.description AS [Description], MIMSY1.objtype AS [Object Type], MIMSY1.Key1
         *     FROM   (DOCUMENTS INNER JOIN MIMSY1 ON DOCUMENTS.[counter] = MIMSY1.[counter]), Type
         *     << If there's a value in the drop-down, concat WHERE  (MIMSY1.objtype = <<drop down value as string>>) >>
         *     << If there's a value in the text box,
         *         << If there's a value in the drop-down, concat AND >>
         *         concat WHERE (MIMSY1.objname LIKE '*' + text.value + '*')
         *         If title searching, try to sort exact matches at the top...sort decending by relevance
         */
        bool addAnd = false;
        string query = "SELECT MIMSY1.Sorts, MIMSY1.objname AS [Title], MIMSY1.description AS [Description], MIMSY1.objtype AS [Object Type], MIMSY1.Key1 FROM (DOCUMENTS INNER JOIN MIMSY1 ON DOCUMENTS.[counter] = MIMSY1.[counter]), Type";
        OleDbConnection dConnection = new OleDbConnection(ConfigurationManager.ConnectionStrings["MmsydataConnectionString"].ConnectionString);
        OleDbCommand dCommand;
        OleDbDataAdapter dAdapter;
        System.Data.DataSet ds = new System.Data.DataSet();

        if (typesDropDown.SelectedIndex != 0) {
            query += " WHERE (MIMSY1.objtype = '" + typesDropDown.SelectedItem.Value + "')";
            addAnd = true;
        }

        if (titleSearchBox.Text.Length > 0) {
            if (addAnd) {
                query += " AND ";
            }
            else {
                query += " WHERE ";
            }

            query += "(MIMSY1.objname LIKE '%" + titleSearchBox.Text + "%')";
        }

        dCommand = new OleDbCommand(query, dConnection);
        dConnection.Open();
        dAdapter = new OleDbDataAdapter(dCommand);
        dAdapter.Fill(ds);
        dConnection.Close();
        documentGrid.DataSource = ds;
        documentGrid.DataBind();
    }
}
