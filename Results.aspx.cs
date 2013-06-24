using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.OleDb;

public partial class Results : Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        OleDbConnection dConnection = new OleDbConnection(ConfigurationManager.ConnectionStrings["MmsydataConnectionString"].ConnectionString);
        OleDbCommand recordCommand;
        OleDbCommand documentCommand;
        OleDbDataAdapter recordAdapter;
        OleDbDataAdapter documentAdapter;
        System.Data.DataSet recordData = new System.Data.DataSet();
        System.Data.DataSet documentData = new System.Data.DataSet();
        
        string recordQuery = "SELECT * FROM MIMSY1 WHERE counter=" + Request.QueryString["q"];
        string documentQuery = @"SELECT [Document Name], KeyfileObjectID AS [Object ID], DateCreated AS [Creation Date], 
                            PermanentRecord AS Permanent, GovtRequired AS [US Gov't Requirement] FROM DOCUMENTS
                            WHERE counter=" + Request.QueryString["q"];

        recordCommand = new OleDbCommand(recordQuery, dConnection);
        documentCommand = new OleDbCommand(documentQuery, dConnection);
        recordAdapter = new OleDbDataAdapter(recordCommand);
        documentAdapter = new OleDbDataAdapter(documentCommand);

        dConnection.Open();
            recordAdapter.Fill(recordData);
            documentAdapter.Fill(documentData);
        dConnection.Close();

        mimsyRecord.DataSource = recordData;
        mimsyRecord.DataBind();
        documentGrid.DataSource = documentData;
        documentGrid.DataBind();

    }
}