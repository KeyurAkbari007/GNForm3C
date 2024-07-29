using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using GNForm3C.BAL;
using GNForm3C;

public partial class AdminPanel_DemoTable : System.Web.UI.Page
{
    #region Variables

    String TableName = "DemoTable";
    static Int32 PageRecordSize = 10; // Example size of records per page
    Int32 PageDisplaySize = 5;
    Int32 DisplayIndex = 10;

    #endregion Variables

    #region Page Load Event

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            FillDropDownList();
            Search(1);
        }
    }

    #endregion Page Load Event


    #region 14.1 Fill DropDownList

    private void FillDropDownList()
    {
/*        CommonFillMethods.FillDropDownListHospitalID(ddlHospitalID);
*/
        CommonFunctions.GetDropDownPageSize(ddlPageSizeBottom);
        ddlPageSizeBottom.SelectedValue = PageRecordSize.ToString();
    }

    #endregion 14.1 Fill DropDownList

    #region Search Method

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Search(1);
    }

    private void Search(int PageNo)
    {
        #region Parameters

        SqlInt32 id = SqlInt32.Null;
        SqlString Fname = SqlString.Null;
        SqlString Lname = SqlString.Null;
        Int32 Offset = (PageNo - 1) * PageRecordSize;
        Int32 TotalRecords = 0;
        Int32 TotalPages = 1;
        #region Gather Data
        if (txtFirstName.Text.Trim() != String.Empty)
            Fname = txtFirstName.Text.Trim();

        if (txtLastName.Text.Trim() != String.Empty)
            Lname = txtLastName.Text.Trim();

        #endregion Gather Data

        DemoBAL baldemo = new DemoBAL();
        DataTable dt = baldemo.SelectPage(Offset, PageRecordSize, out TotalRecords,id, Fname, Lname);

        if (PageRecordSize == 0 && dt.Rows.Count > 0)
        {
            PageRecordSize = dt.Rows.Count;
            TotalPages = (int)Math.Ceiling((double)((decimal)TotalRecords / Convert.ToDecimal(PageRecordSize)));
        }
        else
            TotalPages = (int)Math.Ceiling((double)((decimal)TotalRecords / Convert.ToDecimal(PageRecordSize)));

        if (dt != null && dt.Rows.Count > 0)
        {
            rpData.DataSource = dt;
            rpData.DataBind();

            if (PageNo > TotalPages)
                PageNo = TotalPages;

            ViewState["TotalPages"] = TotalPages;
            ViewState["CurrentPage"] = PageNo;
            CommonFunctions.BindPageList(TotalPages, TotalRecords, PageNo, PageDisplaySize, DisplayIndex, rpPagination, liPrevious, lbtnPrevious, liFirstPage, lbtnFirstPage, liNext, lbtnNext, liLastPage, lbtnLastPage);

            lblRecordInfoBottom.Text = CommonMessage.PageDisplayMessage(Offset, dt.Rows.Count, TotalRecords, PageNo, TotalPages);
            if (TotalRecords <= CV.SmallestPageSize)
            {
                Div_Pagination.Visible = false;
                Div_GoToPageNo.Visible = false;
                Div_PageSize.Visible = false;
            }
            else
            {
                Div_Pagination.Visible = true;
                Div_GoToPageNo.Visible = true;
                Div_PageSize.Visible = true;
            }
            /*            lblRecordInfoTop.Text = CommonMessage.PageDisplayMessage(Offset, dt.Rows.Count, TotalRecords, PageNo, TotalPages);
            */
        }
        else if (TotalPages < PageNo && TotalPages > 0)
            Search(TotalPages);
        else
        {
            ViewState["TotalPages"] = 0;
            ViewState["CurrentPage"] = 1;

            rpData.DataSource = null;
            rpData.DataBind();

            lblRecordInfoBottom.Text = CommonMessage.NoRecordFound();
/*            lblRecordInfoTop.Text = CommonMessage.NoRecordFound();
*/
            CommonFunctions.BindPageList(0, 0, PageNo, PageDisplaySize, DisplayIndex, rpPagination, liPrevious, lbtnPrevious, liFirstPage, lbtnFirstPage, liNext, lbtnNext, liLastPage, lbtnLastPage);
            ucMessage.ShowError(CommonMessage.NoRecordFound());
        }

        #endregion Parameters
    }

    #endregion Search Method

    #region Repeater Events

    protected void rpData_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        // Handle repeater item command events if needed

        if (e.CommandName == "Delete")
        {
            try
            {
                DemoBAL baldemo = new DemoBAL();
                if (e.CommandArgument.ToString().Trim() != "")
                {
                    if (baldemo.Delete(Convert.ToInt32(e.CommandArgument)))
                    {
                        ucMessage.ShowSuccess(CommonMessage.DeletedRecord());

                        if (ViewState["CurrentPage"] != null)
                        {
                            int Count = rpData.Items.Count;

                            if (Count == 1 && Convert.ToInt32(ViewState["CurrentPage"]) != 1)
                                ViewState["CurrentPage"] = (Convert.ToInt32(ViewState["CurrentPage"]) - 1);
                            Search(Convert.ToInt32(ViewState["CurrentPage"]));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ucMessage.ShowError(ex.Message.ToString());
            }
        }
    }

    #endregion Repeater Events

    #region Pagination Events

    protected void rpPagination_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        // Handle pagination item data bound events if needed
    }

    protected void PageChange_Click(object sender, EventArgs e)
    {
        LinkButton lbtn = (LinkButton)(sender);
        int Value = Convert.ToInt32(lbtn.CommandArgument);
        String Name = lbtn.CommandName.ToString();

        if (Name == "PageNo" || Name == "FirstPage")
            Search(Value);

        else if (Name == "PreviousPage")
            Search(Convert.ToInt32(ViewState["CurrentPage"]) - Value);

        else if (Name == "NextPage")
            Search(Convert.ToInt32(ViewState["CurrentPage"]) + Value);

        else if (Name == "LastPage")
            Search(Convert.ToInt32(ViewState["TotalPages"]));

        else if (Name == "GoPageNo")
        {
            if (txtPageNo.Text.Trim() == String.Empty)
            {
                ucMessage.ShowError(CommonMessage.ErrorRequiredField("Page No"));
                return;
            }
            else
            {
                Value = Convert.ToInt32(txtPageNo.Text);
                if (Value > Convert.ToInt32(ViewState["TotalPages"]))
                {
                    ucMessage.ShowError(CommonMessage.ErrorInvalidField("Page No"));
                    return;
                }
                Search(Value);
            }
        }
    }

    #endregion Pagination Events
    protected void ddlPageSizeBottom_SelectedIndexChanged(object sender, EventArgs e)
    {
        PageRecordSize = Convert.ToInt32(ddlPageSizeBottom.SelectedValue);
        Search(Convert.ToInt32(ViewState["CurrentPage"]));
    }

    #region Export Data

    protected void lbtnExport_Click(object sender, EventArgs e)
    {
        // Handle export button click events if needed
    }

    #endregion Export Data

    #region Clear Controls

    protected void btnClear_Click(object sender, EventArgs e)
    {
        ClearControls();
    }
    #region 22.0 ClearControls

    private void ClearControls()
    {
        // Clear controls logic if needed
        txtFirstName.Text = String.Empty;
        txtLastName.Text = String.Empty;
        CommonFunctions.BindEmptyRepeater(rpData);
        /*Div_SearchResult.Visible = false;*/
        /* Div_ExportOption.Visible = false;*/
        lblRecordInfoBottom.Text = CommonMessage.NoRecordFound();
        /*lblRecordInfoTop.Text = CommonMessage.NoRecordFound();*/
    }

    #endregion 22.0 ClearControls

    #endregion Clear Controls
}
