using System;
using System.Web.UI.WebControls;
using GNForm3C.BAL;
using System.Data.SqlTypes;
using System.Data;
using GNForm3C.ENT;
using System.Web.UI;
using System.Text;

namespace GNForm3C
{
    public partial class ExpInm_LedgerListAddEditMany : System.Web.UI.Page
    {
        #region 10.0  Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDropdowns();
            }
        }
        #endregion Page_Load

        #region 11.0 LoadDropDropwn
        private void LoadDropdowns()
        {
            // Fill Hospital Dropdown
            CommonFillMethods.FillDropDownListHospitalID(ddlHospitalID);
            CommonFillMethods.FillDropDownListFinYearID(ddlFinYearID);



        }
        #endregion LoadDropDropwn

        #region 12.0 ddlHospitalID_SelectedIndexChanged
        //protected void ddlHospitalID_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    SqlInt32 hospitalID = SqlInt32.Null;
        //    if (ddlHospitalID.SelectedIndex > 0)
        //        hospitalID = Convert.ToInt32(ddlHospitalID.SelectedValue);

        //    // Update Financial Year dropdown based on selected HospitalID
        //    CommonFillMethods.FillDropDownListFinYearIDByHospitalID(ddlFinYearID, hospitalID);

        //    // Clear and disable Income Type dropdown
        //    ddlIncomeTypeID.Items.Clear();
        //    ddlIncomeTypeID.Enabled = false;
        //}
        #endregion ddlHospitalID_SelectedIndexChanged

        #region 13.0 onchangeEventOnselectedDropDownFinYear
        //protected void ddlFinYearID_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    // Initialize variables for the selected values
        //    SqlInt32 hospitalID = SqlInt32.Null;
        //    SqlInt32 finYearID = SqlInt32.Null;

        //    // Check if values are selected and convert to SqlInt32
        //    if (ddlHospitalID.SelectedIndex > 0)
        //        hospitalID = new SqlInt32(Convert.ToInt32(ddlHospitalID.SelectedValue));

        //    if (ddlFinYearID.SelectedIndex > 0)
        //        finYearID = new SqlInt32(Convert.ToInt32(ddlFinYearID.SelectedValue));

        //    // Ensure both hospitalID and finYearID have values before calling FillDropDownListIncomeTypeIDByFinYearID
        //    if (!hospitalID.IsNull && !finYearID.IsNull)
        //    {
        //        // Update Income Type dropdown based on selected FinYearID and HospitalID
        //        CommonFillMethods.FillDropDownListIncomeTypeIDByFinYearID(ddlIncomeTypeID, finYearID, hospitalID);
        //        ddlIncomeTypeID.Enabled = true;
        //    }
        //    else
        //    {
        //        // Clear items and disable the dropdown if necessary values are not selected
        //        ddlIncomeTypeID.Items.Clear();
        //        ddlIncomeTypeID.Enabled = false;
        //    }
        //}
        #endregion 13.0 onchangeEventOnselectedDropDownFinYear  

        #region 14.0 Show Button Event
        protected void btnShow_Click(object sender, EventArgs e)
        {
            SqlInt32 hospitalID = SqlInt32.Null;
            SqlInt32 finYearID = SqlInt32.Null;
            //SqlInt32 incomeTypeID = SqlInt32.Null;

            if (ddlHospitalID.SelectedIndex > 0)
                hospitalID = Convert.ToInt32(ddlHospitalID.SelectedValue);

            if (ddlFinYearID.SelectedIndex > 0)
                finYearID = Convert.ToInt32(ddlFinYearID.SelectedValue);

            //if (ddlIncomeTypeID.SelectedIndex > 0)
            //    incomeTypeID = Convert.ToInt32(ddlIncomeTypeID.SelectedValue);

            // Retrieve and display data based on the selected values from dropdowns
            ACC_IncomeBAL balAcc_Account = new ACC_IncomeBAL();
            DataTable dt = balAcc_Account.SelectShow(hospitalID,finYearID);

            // Bind data to controls and handle visibility as required
            foreach (DataColumn dtc in dt.Columns)
            {
                dtc.AutoIncrement = false;
                dtc.AllowDBNull = true;
            }
            dt.AcceptChanges();

            int count = 1 - dt.Rows.Count;
            for (int i = 1; i <= count; i++)
            {
                dt.Rows.Add();
            }

            rpData.DataSource = dt;
            rpData.DataBind();
            Div_ShowResult.Visible = true;
        }
        #endregion 14.0 Show Button Event

        #region 15.0 Save Button Event
        #region 15.0 Save Button Event DataTable

        protected void btnSave_ClickDatatable(object sender, EventArgs e)
        {
            Page.Validate();

            if (Page.IsValid)
            {
                SqlInt32 HospitalID = SqlInt32.Null;
                SqlInt32 FinYearID = SqlInt32.Null;
                if (ddlHospitalID.SelectedIndex > 0)
                    HospitalID = Convert.ToInt32(ddlHospitalID.SelectedValue);
                if (ddlFinYearID.SelectedIndex > 0)
                    FinYearID = Convert.ToInt32(ddlFinYearID.SelectedValue);

                ACC_IncomeBAL balACC_Income = new ACC_IncomeBAL();
                ACC_IncomeENT entACC_Income = new ACC_IncomeENT();

                DataTable dtIncomeTable = new DataTable();
                dtIncomeTable.Columns.Add("IncomeID", typeof(SqlInt32));
                dtIncomeTable.Columns.Add("IncomeTypeID", typeof(SqlInt32));
                dtIncomeTable.Columns.Add("Amount", typeof(SqlDecimal));
                dtIncomeTable.Columns.Add("IncomeDate", typeof(SqlDateTime));
                dtIncomeTable.Columns.Add("Note", typeof(SqlString));
                dtIncomeTable.Columns.Add("Remarks", typeof(SqlString));
                dtIncomeTable.Columns.Add("HospitalID", typeof(SqlInt32));
                dtIncomeTable.Columns.Add("FinYearID", typeof(SqlInt32));
                dtIncomeTable.Columns.Add("UserID", typeof(SqlInt32));
                dtIncomeTable.Columns.Add("Created", typeof(SqlDateTime));
                dtIncomeTable.Columns.Add("Modified", typeof(SqlDateTime));
                dtIncomeTable.Columns.Add("Operation", typeof(string)); // 'I', 'U', or 'D'


                try
                {

                    foreach (RepeaterItem items in rpData.Items)
                    {

                        #region FindControl

                        //var ddlFinYearID = (DropDownList)items.FindControl("ddlFinYearID");
                        var ddlIncomeTypeID = (DropDownList)items.FindControl("ddlIncomeTypeID");

                        var dtpIncomeDate = (TextBox)items.FindControl("dtpIncomeDate");

                        TextBox txtAmount = (TextBox)items.FindControl("txtAmount");
                        TextBox txtRemarks = (TextBox)items.FindControl("txtRemarks");
                        HiddenField Hdfiled = (HiddenField)items.FindControl("hdIncomeID");
                        TextBox txtNote = (TextBox)items.FindControl("txtNote");
                        CheckBox chkIsSelected = (CheckBox)items.FindControl("chkIsSelected");


                        #endregion FindControl

                        #region 15.1.1 Gather Data
                        if (chkIsSelected.Checked)
                        {
                            entACC_Income.HospitalID = Convert.ToInt32(ddlHospitalID.SelectedValue);
                            entACC_Income.FinYearID = Convert.ToInt32(ddlFinYearID.SelectedValue);
                            entACC_Income.IncomeTypeID = Convert.ToInt32(ddlIncomeTypeID.SelectedValue);
                            entACC_Income.IncomeDate = Convert.ToDateTime(dtpIncomeDate.Text);
                            entACC_Income.Amount = Convert.ToDecimal(txtAmount.Text);
                            entACC_Income.Note = Convert.ToString(txtNote.Text);
                            entACC_Income.Remarks = Convert.ToString(txtRemarks.Text);
                            entACC_Income.UserID = Convert.ToInt32(Session["UserID"]);
                            entACC_Income.Created = DateTime.Now;
                            entACC_Income.Modified = DateTime.Now;
                        }
                        #endregion 15.1.1 Gather Data

                        if (Hdfiled.Value != string.Empty)
                        {
                            if (chkIsSelected.Checked)
                            {
                                #region 15.1.2 Update Data
                                if (ddlIncomeTypeID.Text.Trim() == string.Empty)
                                {
                                    ddlIncomeTypeID.Focus();
                                    ucMessage.ShowError("Enter Income Type");
                                    break;
                                }
                                else
                                {
                                    entACC_Income.IncomeID = Convert.ToInt32(Hdfiled.Value);
                                    dtIncomeTable.Rows.Add(
                                        entACC_Income.IncomeID,
                                        entACC_Income.IncomeTypeID,
                                        entACC_Income.Amount,
                                        entACC_Income.IncomeDate,
                                        entACC_Income.Note,
                                        entACC_Income.Remarks,
                                        entACC_Income.HospitalID,
                                        entACC_Income.FinYearID,
                                        entACC_Income.UserID,
                                        entACC_Income.Created,
                                        entACC_Income.Modified,
                                        'U'
                                        );
                                }

                                #endregion 15.1.2 Update Data
                            }
                            else
                            {
                                #region 15.1.3 Delete Data
                                if (ddlIncomeTypeID.Text.Trim() == string.Empty)
                                {
                                    ddlIncomeTypeID.Focus();
                                    ucMessage.ShowError("Enter Income Type");
                                    break;
                                }
                                else
                                {
                                    entACC_Income.IncomeID = Convert.ToInt32(Hdfiled.Value);
                                    //if (balACC_Income.Delete(entACC_Income.IncomeID))
                                    //{
                                    //    ucMessage.ShowSuccess(CommonMessage.DeletedRecord());
                                    //}

                                    dtIncomeTable.Rows.Add(
                                        entACC_Income.IncomeID,
                                        entACC_Income.IncomeTypeID,
                                        entACC_Income.Amount,
                                        entACC_Income.IncomeDate,
                                        entACC_Income.Note,
                                        entACC_Income.Remarks,
                                        entACC_Income.HospitalID,
                                        entACC_Income.FinYearID,
                                        entACC_Income.UserID,
                                        entACC_Income.Created,
                                        entACC_Income.Modified,
                                        'D'
                                        );

                                }

                                #endregion 15.1.3 Delete Data
                            }
                        }
                        else
                        {

                            if (chkIsSelected.Checked)
                            {
                                #region 15.1.4 Insert Data
                                if (ddlIncomeTypeID.Text.Trim() == string.Empty && txtAmount.Text.Trim() != string.Empty)
                                {
                                    ddlIncomeTypeID.Focus();
                                    ucMessage.ShowError("Enter Income Type");
                                }
                                else
                                {
                                    if (ddlIncomeTypeID.Text.Trim() != string.Empty)
                                    {
                                        //if (balACC_Income.Insert(entACC_Income))
                                        //{
                                        //    Div_ShowResult.Visible = false;
                                        //    ucMessage.ShowSuccess(CommonMessage.RecordSaved());
                                        //}
                                        dtIncomeTable.Rows.Add(
                                        entACC_Income.IncomeID,
                                        entACC_Income.IncomeTypeID,
                                        entACC_Income.Amount,
                                        entACC_Income.IncomeDate,
                                        entACC_Income.Note,
                                        entACC_Income.Remarks,
                                        entACC_Income.HospitalID,
                                        entACC_Income.FinYearID,
                                        entACC_Income.UserID,
                                        entACC_Income.Created,
                                        entACC_Income.Modified,
                                        'I'
                                        );

                                    }
                                }
                                #endregion  15.1.4 Insert Data
                            }
                        }
                        Div_ShowResult.Visible = false;

                    }

                    if (balACC_Income.UpsertDatatable(dtIncomeTable))
                    {
                        ucMessage.ShowSuccess(CommonMessage.RecordSaved());
                        ClearControls();
                    }
                    else
                    {
                        ucMessage.ShowError(balACC_Income.Message);
                    }

                }
                catch (Exception ex)
                {
                    ucMessage.ShowError(ex.Message);
                }

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Page.Validate();

            if (Page.IsValid)
            {
                SqlInt32 HospitalID = SqlInt32.Null;
                SqlInt32 FinYearID = SqlInt32.Null;
                if (ddlHospitalID.SelectedIndex > 0)
                    HospitalID = Convert.ToInt32(ddlHospitalID.SelectedValue);
                if (ddlFinYearID.SelectedIndex > 0)
                    FinYearID = Convert.ToInt32(ddlFinYearID.SelectedValue);

                ACC_IncomeBAL balACC_Income = new ACC_IncomeBAL();
                ACC_IncomeENT entACC_Income = new ACC_IncomeENT();


                StringBuilder xmlData = new StringBuilder();
                xmlData.Append("<IncomeData>");
                try
                {
                    foreach (RepeaterItem items in rpData.Items)
                    {

                        #region FindControl

                        //var ddlFinYearID = (DropDownList)items.FindControl("ddlFinYearID");
                        var ddlIncomeTypeID = (DropDownList)items.FindControl("ddlIncomeTypeID");
                        TextBox dtpIncomeDate = (TextBox)items.FindControl("dtpIncomeDate");

                        TextBox txtAmount = (TextBox)items.FindControl("txtAmount");
                        HiddenField Hdfiled = (HiddenField)items.FindControl("hdIncomeID");
                        TextBox txtNote = (TextBox)items.FindControl("txtNote");
                        CheckBox chkIsSelected = (CheckBox)items.FindControl("chkIsSelected");

                        #endregion FindControl

                        #region 15.1.1 Gather Data
                        if (chkIsSelected.Checked)
                        {   

                            String ErrorMsg = String.Empty;
                            if (ddlFinYearID.SelectedIndex == 0)
                                ErrorMsg += " - " + CommonMessage.ErrorRequiredFieldDDL("FInYear");

                            if (ddlIncomeTypeID.SelectedIndex == 0)
                                ErrorMsg += " - " + CommonMessage.ErrorRequiredFieldDDL("IncomeType");

                            if (dtpIncomeDate.Text.ToString().Trim() == String.Empty)
                                ErrorMsg += " - " + CommonMessage.ErrorRequiredField("IncomeDate");

                            if (txtAmount.Text.Trim() == String.Empty)
                                ErrorMsg += " - " + CommonMessage.ErrorRequiredField("Amount");

                            if (ErrorMsg != String.Empty)
                            {
                                ErrorMsg = CommonMessage.ErrorPleaseCorrectFollowing() + ErrorMsg;
                                ucMessage.ShowError(ErrorMsg);
                                ddlFinYearID.Focus();
                                Div_ShowResult.Visible = true;
                                return;
                            }


                            entACC_Income.HospitalID = HospitalID;
                            entACC_Income.FinYearID = Convert.ToInt32(ddlFinYearID.SelectedValue);
                            entACC_Income.IncomeTypeID = Convert.ToInt32(ddlIncomeTypeID.SelectedValue);
                            entACC_Income.IncomeDate = Convert.ToDateTime(dtpIncomeDate.Text);
                            entACC_Income.Amount = Convert.ToDecimal(txtAmount.Text);
                            entACC_Income.Note = txtNote.Text != string.Empty ? Convert.ToString(txtNote.Text) : SqlString.Null;
                            entACC_Income.UserID = Convert.ToInt32(Session["UserID"]);
                            entACC_Income.Created = DateTime.Now;
                            entACC_Income.Modified = DateTime.Now;
                        }
                        #endregion 15.1.1 Gather Data

                        if (Hdfiled.Value != string.Empty)
                        {
                            if (chkIsSelected.Checked)
                            {
                                #region 15.1.2 Update Data

                                if (entACC_Income.IncomeDate.ToString() == string.Empty)
                                {
                                    ddlIncomeTypeID.Focus();
                                    ucMessage.ShowError("Enter IncomeDate");
                                    return;
                                }
                                else
                                {

                                    entACC_Income.IncomeID = Convert.ToInt32(Hdfiled.Value);

                                    xmlData.Append("<Record>");
                                    xmlData.AppendFormat("<IncomeID>{0}</IncomeID>", entACC_Income.IncomeID);
                                    xmlData.AppendFormat("<IncomeTypeID>{0}</IncomeTypeID>", entACC_Income.IncomeTypeID);
                                    xmlData.AppendFormat("<Amount>{0}</Amount>", entACC_Income.Amount);
                                    xmlData.AppendFormat("<IncomeDate>{0}</IncomeDate>", entACC_Income.IncomeDate);
                                    xmlData.AppendFormat("<Note>{0}</Note>", entACC_Income.Note);
                                    xmlData.AppendFormat("<HospitalID>{0}</HospitalID>", entACC_Income.HospitalID);
                                    xmlData.AppendFormat("<FinYearID>{0}</FinYearID>", entACC_Income.FinYearID);
                                    xmlData.AppendFormat("<UserID>{0}</UserID>", entACC_Income.UserID);
                                    xmlData.AppendFormat("<Created>{0}</Created>", entACC_Income.Created);
                                    xmlData.AppendFormat("<Modified>{0}</Modified>", entACC_Income.Modified);
                                    xmlData.AppendFormat("<Operation>{0}</Operation>", "U");
                                    xmlData.Append("</Record>");

                                    //if (balACC_Income.Update(entACC_Income))
                                    //{
                                    //    ucMessage.ShowSuccess(CommonMessage.RecordUpdated());
                                    //}
                                }

                                #endregion 15.1.2 Update Data
                            }
                            else
                            {
                                #region 15.1.3 Delete Data
                                if (ddlIncomeTypeID.Text.Trim() == string.Empty)
                                {
                                    ddlIncomeTypeID.Focus();
                                    ucMessage.ShowError("Enter Income Type");
                                    return;
                                }
                                else
                                {
                                    entACC_Income.IncomeID = Convert.ToInt32(Hdfiled.Value);
                                    xmlData.Append("<Record>");
                                    xmlData.AppendFormat("<IncomeID>{0}</IncomeID>", entACC_Income.IncomeID);
                                    xmlData.AppendFormat("<IncomeTypeID>{0}</IncomeTypeID>", entACC_Income.IncomeTypeID);
                                    xmlData.AppendFormat("<Amount>{0}</Amount>", entACC_Income.Amount);
                                    xmlData.AppendFormat("<IncomeDate>{0}</IncomeDate>", entACC_Income.IncomeDate);
                                    xmlData.AppendFormat("<Note>{0}</Note>", entACC_Income.Note);
                                    xmlData.AppendFormat("<HospitalID>{0}</HospitalID>", entACC_Income.HospitalID);
                                    xmlData.AppendFormat("<FinYearID>{0}</FinYearID>", entACC_Income.FinYearID);
                                    xmlData.AppendFormat("<UserID>{0}</UserID>", entACC_Income.UserID);
                                    xmlData.AppendFormat("<Created>{0}</Created>", entACC_Income.Created);
                                    xmlData.AppendFormat("<Modified>{0}</Modified>", entACC_Income.Modified);
                                    xmlData.AppendFormat("<Operation>{0}</Operation>", "D");
                                    xmlData.Append("</Record>");
                                    //if (balACC_Income.Delete(entACC_Income.IncomeID))
                                    //{
                                    //    ucMessage.ShowSuccess(CommonMessage.DeletedRecord());
                                    //}
                                }

                                #endregion 15.1.3 Delete Data
                            }
                        }
                        else
                        {

                            if (chkIsSelected.Checked)
                            {
                                #region 15.1.4 Insert Data
                                if (ddlIncomeTypeID.Text.Trim() == string.Empty && txtAmount.Text.Trim() != string.Empty)
                                {
                                    ddlIncomeTypeID.Focus();
                                    ucMessage.ShowError("Enter Income Type");
                                }
                                else
                                {
                                    if (ddlIncomeTypeID.Text.Trim() != string.Empty)
                                    {
                                        xmlData.Append("<Record>");
                                        xmlData.AppendFormat("<IncomeID></IncomeID>");
                                        xmlData.AppendFormat("<IncomeTypeID>{0}</IncomeTypeID>", entACC_Income.IncomeTypeID);
                                        xmlData.AppendFormat("<Amount>{0}</Amount>", entACC_Income.Amount);
                                        xmlData.AppendFormat("<IncomeDate>{0}</IncomeDate>", entACC_Income.IncomeDate);
                                        xmlData.AppendFormat("<Note>{0}</Note>", entACC_Income.Note);
                                        xmlData.AppendFormat("<HospitalID>{0}</HospitalID>", entACC_Income.HospitalID);
                                        xmlData.AppendFormat("<FinYearID>{0}</FinYearID>", entACC_Income.FinYearID);
                                        xmlData.AppendFormat("<UserID>{0}</UserID>", entACC_Income.UserID);
                                        xmlData.AppendFormat("<Created>{0}</Created>", entACC_Income.Created);
                                        xmlData.AppendFormat("<Modified>{0}</Modified>", entACC_Income.Modified);
                                        xmlData.AppendFormat("<Operation>{0}</Operation>", "I");
                                        xmlData.Append("</Record>");


                                        //if (balACC_Income.Insert(entACC_Income))
                                        //{
                                        //    Div_ShowResult.Visible = false;
                                        //    ucMessage.ShowSuccess(CommonMessage.RecordSaved());
                                        //}
                                    }
                                }
                                #endregion  15.1.4 Insert Data
                            }
                        }
                        Div_ShowResult.Visible = false;
                    }
                    xmlData.Append("</IncomeData>");

                    if (balACC_Income.Upsert(xmlData.ToString()))
                    {
                        Div_ShowResult.Visible = false;
                        ucMessage.ShowSuccess(CommonMessage.RecordSaved());
                        ClearControls();
                    }
                }
                catch (Exception ex)
                {
                    ucMessage.ShowError(ex.Message);
                }
            }
        }
        #endregion 15.0 Save Button Event DataTable 

        #endregion 15.0 Save Button Event

        #region 16.0 Clear Controls
        private void ClearControls()
        {
            ddlHospitalID.SelectedIndex = 0;
            //ddlFinYearID.SelectedIndex = 0;
            //ddlIncomeTypeID.SelectedIndex = 0;
        }

        #endregion 16.0 Clear Controls

        #region 17.0 Add Row Button
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            var FinYearID = ddlFinYearID.SelectedValue;

            DataTable dt = new DataTable();
            dt.Columns.Add("IncomeDate");
            dt.Columns.Add("Amount");
            dt.Columns.Add("Remarks");
            dt.Columns.Add("Note");
            dt.Columns.Add("IncomeID");
            dt.Columns.Add("IncomeTypeID");
            dt.Columns.Add("FinYearID");

            foreach (RepeaterItem rp in rpData.Items)
            {
                DropDownList IncomeTypeID = (DropDownList)rp.FindControl("ddlIncomeTypeID");
                TextBox dtpIncomeDate = (TextBox)rp.FindControl("dtpIncomeDate");
                TextBox txtNote = (TextBox)rp.FindControl("txtNote");
                TextBox txtAmount = (TextBox)rp.FindControl("txtAmount");
                HiddenField hdIncomeID = (HiddenField)rp.FindControl("hdIncomeID");

                DataRow dr = dt.NewRow();
               
                dr["IncomeDate"] = dtpIncomeDate.Text.ToString().Trim() != String.Empty ? Convert.ToDateTime(dtpIncomeDate.Text.ToString().Trim()).ToString(CV.DefaultDateFormat) : null;
                dr["Amount"] = txtAmount.Text.ToString().Trim();
                dr["Note"] = txtNote.Text.Trim();
                dr["IncomeID"] = hdIncomeID.Value.ToString();
                //dr["FinYearID"] = FinYearID.SelectedValue;
                dr["IncomeTypeID"] = IncomeTypeID.SelectedValue;
                dt.Rows.Add(dr);
            }
            int count = 0;
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["Amount"].ToString().Trim() != string.Empty && FinYearID.ToString().Trim() != string.Empty && dr["IncomeTypeID"].ToString().Trim() != string.Empty)
                    count++;
            }
            if (count == dt.Rows.Count)
            {
                dt.Rows.Add();
            }
            else
            {
                ucMessage.ShowError("Fill All Rows Data");
            }

            rpData.DataSource = dt;
            rpData.DataBind();
        }


        #endregion 17.0 Add Row Button

        #region 18.0 rpData_ItemDataBound
        protected void rpData_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var ddlFinYearID = (DropDownList)e.Item.FindControl("ddlFinYearID");
                var ddlIncomeTypeID = (DropDownList)e.Item.FindControl("ddlIncomeTypeID");
                var txtAmount = (TextBox)e.Item.FindControl("txtAmount");
                var hdIncomeID = (HiddenField)e.Item.FindControl("hdIncomeID");
                var txtNote = (TextBox)e.Item.FindControl("txtNote");
                var chkIsSelected = (CheckBox)e.Item.FindControl("chkIsSelected");
                var dtpIncomeDate = (TextBox)e.Item.FindControl("dtpIncomeDate");

                if (ddlFinYearID != null)
                {
                    CommonFillMethods.FillSingleDropDownListFinYearID(ddlFinYearID);
                    string finYearID = string.Empty;           
                        finYearID = DataBinder.Eval(e.Item.DataItem, "FinYearID").ToString();
                    if (ddlFinYearID.Items.FindByValue(finYearID) != null)
                    {
                        ddlFinYearID.SelectedValue = finYearID;
                    }
                }

                if (ddlIncomeTypeID != null)
                {
                    
                    CommonFillMethods.FillSingleDropDownListIncomeTypeID(ddlIncomeTypeID);
                    string incomeTypeID = DataBinder.Eval(e.Item.DataItem, "IncomeTypeID").ToString();
                    ddlIncomeTypeID.Enabled = true;
                    if (ddlIncomeTypeID.Items.FindByValue(incomeTypeID) != null)
                    {
                        ddlIncomeTypeID.SelectedValue = incomeTypeID;
                    }
                }

                if (txtAmount != null)
                {
                    txtAmount.Text = DataBinder.Eval(e.Item.DataItem, "Amount").ToString();
                }

                if (hdIncomeID != null)
                {
                    hdIncomeID.Value = DataBinder.Eval(e.Item.DataItem, "IncomeID").ToString();
                }

                if (txtNote != null)
                {
                    txtNote.Text = DataBinder.Eval(e.Item.DataItem, "Note").ToString();
                }


                if (dtpIncomeDate != null)
                {
                    DateTime incomeDate;
                    if (DateTime.TryParse(DataBinder.Eval(e.Item.DataItem, "IncomeDate").ToString(), out incomeDate))
                    {
                        dtpIncomeDate.Text = incomeDate.ToString("dd-MM-yyyy");
                    }
                }
            }
        }
        #endregion 18.0 rpData_ItemDataBound
    }

}
