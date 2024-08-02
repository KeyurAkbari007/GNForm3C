using GNForm3C;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Master_MST_Student_MST_BranchList : System.Web.UI.Page
{
    #region Variables

    String FormName = "Branch Intake";
    static Int32 PageRecordSize = CV.PageRecordSize; // Size of record per page
    Int32 PageDisplaySize = CV.PageDisplaySize;
    Int32 DisplayIndex = CV.DisplayIndex;

    #endregion Variables

    #region Page Load event

    protected void Page_Load(object sender, EventArgs e)
    {
        #region Check User Login

        if (Session["UserID"] == null)
            Response.Redirect(CV.LoginPageURL);

        #endregion Check User Login

        if (!Page.IsPostBack)
        {
            BindData();

            #region Set Help Text
            //ucHelp.ShowHelp("Help Text will be shown here");
            #endregion Set Help Text
        }
    }

    #endregion Page Load event

    private void BindData()
    {
        MST_BranchIntakeBAL balMST_BranchIntake = new MST_BranchIntakeBAL();
        DataTable dt = balMST_BranchIntake.GetBranchIntakeData();

        // Dynamically create table headers
        var headers = dt.Columns.Cast<DataColumn>()
                        .Where(c => c.ColumnName != "Branch")
                        .Select(c => c.ColumnName).ToList();

        // Convert headers to a comma-separated string and store in hidden field
        hfHeaders.Value = string.Join(",", headers);

        // Clear existing columns
        gvBranches.Columns.Clear();

        // Add the Branch column
        gvBranches.Columns.Add(new BoundField
        {
            DataField = "Branch",
            HeaderText = "Branch"
        });

        // Add dynamic columns
        foreach (var header in headers)
        {
            gvBranches.Columns.Add(new TemplateField
            {
                HeaderText = header,
                ItemTemplate = new DynamicTemplate(header)
            });
        }

        // Bind data to GridView
        gvBranches.DataSource = dt;
        gvBranches.DataBind();
    }



    protected void btnSave_Click(object sender, EventArgs e)
    {
        MST_BranchIntakeBAL balMST_BranchIntake = new MST_BranchIntakeBAL();
        var headers = hfHeaders.Value.Split(','); // Using hfHeaders.Value to get headers

        foreach (GridViewRow row in gvBranches.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                string branch = ((BoundField)gvBranches.Columns[0]).DataField; // Assuming 'Branch' is the first column

                Dictionary<int, int> intakeData = new Dictionary<int, int>();

                foreach (var header in headers)
                {
                    var textBox = (TextBox)row.FindControl("txt" + header);
                    if (textBox != null)
                    {
                        int year;
                        if (int.TryParse(header, out year))
                        {
                            int intakeValue;
                            if (int.TryParse(textBox.Text, out intakeValue))
                            {
                                intakeData[year] = intakeValue;
                            }
                        }
                    }
                }

                balMST_BranchIntake.SaveBranchIntakeData(branch, intakeData);
            }
        }

        BindData();
    }







    protected void rptBranches_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {
            string branch = e.CommandArgument.ToString();
            MST_BranchIntakeBAL balMST_BranchIntake = new MST_BranchIntakeBAL();
            balMST_BranchIntake.DeleteBranchIntakeData(branch);
            BindData();
        }
    }

    protected void rptBranches_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            var headers = hfHeaders.Value.Split(',');
            var item = (RepeaterItem)e.Item;

            foreach (var header in headers)
            {
                var textBox = (TextBox)item.FindControl("txt" + header);
                if (textBox != null)
                {
                    // Set the text box value from data source
                    textBox.Text = DataBinder.Eval(e.Item.DataItem, header).ToString() ?? string.Empty;
                }
            }
        }
    }





    //protected void btnClear_Click(object sender, EventArgs e)
    //{
    //    foreach (RepeaterItem item in rptBranches.Items)
    //    {
    //        ((TextBox)item.FindControl("txt2022")).Text = string.Empty;
    //        ((TextBox)item.FindControl("txt2023")).Text = string.Empty;
    //        ((TextBox)item.FindControl("txt2024")).Text = string.Empty;
    //    }
    //}
    protected void gvBranches_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var headers = hfHeaders.Value.Split(',');
            foreach (var header in headers)
            {
                var textBox = (TextBox)e.Row.FindControl("txt" + header);
                if (textBox != null)
                {
                    textBox.Text = DataBinder.Eval(e.Row.DataItem, header).ToString() ?? string.Empty;
                }
            }
        }
    }

}