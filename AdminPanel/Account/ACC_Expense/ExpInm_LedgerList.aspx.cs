using GNForm3C;
using GNForm3C.BAL;
using GNForm3C.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Account_ACC_Expense_ExpInm_LedgerList : System.Web.UI.Page
{
    #region 11.0 Variables

    // Define any necessary variables here
    private int PageRecordSize = CV.PageRecordSize; // Size of records per page
    private int PageDisplaySize = CV.PageDisplaySize;
    private int DisplayIndex = CV.DisplayIndex;

    #endregion 11.0 Variables

    #region 12.0 Page Load Event

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Redirect(CV.LoginPageURL);
        }

        if (!IsPostBack)
        {
            #region 12.1 Set Default Values

            SetDefaultDates();

            #endregion 12.1 Set Default Values

            #region 12.2 Search Records

            Search(1);

            #endregion 12.2 Search Records
        }
    }

    #endregion 12.0 Page Load Event

    #region 13.0 Set Default Dates

    private void SetDefaultDates()
    {
        var today = DateTime.Today;
        var firstDay = new DateTime(today.Year, today.Month, 1);
        var lastDay = firstDay.AddMonths(1).AddDays(-1);

        FromDate.Text = firstDay.ToString("dd/MM/yyyy");
        ToDate.Text = lastDay.ToString("dd/MM/yyyy");
    }

    #endregion 13.0 Set Default Dates

    #region 14.0 Search

    protected void ShowButton_Click(object sender, EventArgs e)
    {
        Search(1);
    }

    private void Search(int PageNo)
    {
        #region Parameters

        DateTime fromDate;
        DateTime toDate;
        Int32 Offset = (PageNo - 1) * PageRecordSize;
        Int32 TotalRecords = 0;
        Int32 TotalPages = 1;
        string selectedType = Type.SelectedValue; // Rename the variable

        #endregion Parameters

        #region Gather Data

        if (!DateTime.TryParseExact(FromDate.Text.Trim(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out fromDate))
        {
            // Handle invalid from date
            return;
        }

        if (!DateTime.TryParseExact(ToDate.Text.Trim(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out toDate))
        {
            // Handle invalid to date
            return;
        }

        #endregion Gather Data

        // Create the SQL type parameter, handling null or empty case
        SqlString sqlType = string.IsNullOrEmpty(selectedType) ? SqlString.Null : new SqlString(selectedType); // Rename local variable here

        ExpInm_LedgerListBAL balExpInm_LedgerList = new ExpInm_LedgerListBAL();
        DataTable dt = balExpInm_LedgerList.SelectPage(Offset, PageRecordSize, out TotalRecords, fromDate, toDate, sqlType); // Use renamed local variable

        if (dt != null && dt.Rows.Count > 0)
        {
            gvLedgerList.DataSource = dt;
            gvLedgerList.DataBind();

            TotalPages = (int)Math.Ceiling((double)TotalRecords / PageRecordSize);

            ViewState["TotalPages"] = TotalPages;
            ViewState["CurrentPage"] = PageNo;

            // Calculate totals
            decimal total = 0;

            foreach (DataRow row in dt.Rows)
            {
                string ledgerType = row["LedgerType"].ToString();
                decimal ledgerAmount = Convert.ToDecimal(row["LedgerAmount"]);
                total += ledgerAmount;
            }

            // Update footer row
            if (gvLedgerList.FooterRow != null)
            {
                gvLedgerList.FooterRow.Cells[0].Text = "Total : ";
                gvLedgerList.FooterRow.Cells[2].Text = total.ToString("C");
            }
        }
        else
        {
            gvLedgerList.DataSource = null;
            gvLedgerList.DataBind();
        }
    }




    #endregion 14.0 Search

    #region 15.0 Pagination

    protected void PageChange_Click(object sender, EventArgs e)
    {
        LinkButton lbtn = (LinkButton)sender;
        int Value = Convert.ToInt32(lbtn.CommandArgument);
        string Name = lbtn.CommandName.ToString();

        if (Name == "PageNo" || Name == "FirstPage")
            Search(Value);
        else if (Name == "PreviousPage")
            Search(Convert.ToInt32(ViewState["CurrentPage"]) - Value);
        else if (Name == "NextPage")
            Search(Convert.ToInt32(ViewState["CurrentPage"]) + Value);
        else if (Name == "LastPage")
            Search(Convert.ToInt32(ViewState["TotalPages"]));
    }

    #endregion 15.0 Pagination

    #region 16.0 Clear Controls

    protected void btnClear_Click(object sender, EventArgs e)
    {
        ClearControls();
    }

    private void ClearControls()
    {
        FromDate.Text = string.Empty;
        ToDate.Text = string.Empty;
        gvLedgerList.DataSource = null;
        gvLedgerList.DataBind();
    }

    #endregion 16.0 Clear Controls

    #region 17.0 Export Data

    protected void lbtnExport_Click(object sender, EventArgs e)
    {
        // Implement export logic here if needed
    }

    #endregion 17.0 Export Data

    protected void gvLedgerList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // Get the LedgerType field value
            string ledgerType = DataBinder.Eval(e.Row.DataItem, "LedgerType").ToString();

            // Set the row color based on the LedgerType
            if (ledgerType == "Income")
            {
                e.Row.BackColor = System.Drawing.Color.LightGreen;
            }
            else if (ledgerType == "Expense")
            {
                e.Row.BackColor = System.Drawing.Color.LightCoral;
            }
        }
    }
    protected int CurrentPage
    {
        get
        {
            // Get the current page from ViewState or default to 1
            return ViewState["CurrentPage"] != null ? (int)ViewState["CurrentPage"] : 1;
        }
        set
        {
            ViewState["CurrentPage"] = value;
        }
    }

    protected void btnDeleteSelected_Click(object sender, EventArgs e)
    {
        List<string> selectedIds = new List<string>();

        foreach (GridViewRow row in gvLedgerList.Rows)
        {
            CheckBox chkSelect = (CheckBox)row.FindControl("chkSelect");
            if (chkSelect != null && chkSelect.Checked)
            {
                string ledgerId = gvLedgerList.DataKeys[row.RowIndex].Value.ToString();
                selectedIds.Add(ledgerId);
            }
        }

        if (selectedIds.Count > 0)
        {
            string ledgerIds = string.Join(",", selectedIds);
            ExpInm_LedgerListBALBase bal = new ExpInm_LedgerListBALBase();
            bal.DeleteMultipleLedgers(ledgerIds);

            if (string.IsNullOrEmpty(bal.Message))
            {
                // Success
                // Re-bind data after deletion
                Search(CurrentPage); // Pass the current page number to the Search method
            }
            else
            {
                // Handle the error message
            }
        }
    }


}
