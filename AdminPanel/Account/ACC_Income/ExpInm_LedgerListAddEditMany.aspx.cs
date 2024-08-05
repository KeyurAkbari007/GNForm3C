using System;
using System.Web.UI.WebControls;
using GNForm3C.BAL;
using System.Data.SqlTypes;
using System.Data;
using GNForm3C.ENT;
using System.Web.UI;

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

            int count = 10 - dt.Rows.Count;
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
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (Page.IsValid)
            {
                SqlInt32 HospitalID = SqlInt32.Null;
                SqlInt32 FinYearID = SqlInt32.Null;
                SqlInt32 IncomeTypeID = SqlInt32.Null;

                if (ddlHospitalID.SelectedIndex > 0)
                    HospitalID = Convert.ToInt32(ddlHospitalID.SelectedValue);
                if (ddlHospitalID.SelectedIndex > 0)
                    FinYearID = Convert.ToInt32(ddlFinYearID.SelectedValue);
                //if (ddlHospitalID.SelectedIndex > 0)
                //    IncomeTypeID = Convert.ToInt32(ddlIncomeTypeID.SelectedValue);

                ACC_IncomeBAL balACC_IncomeBAL = new ACC_IncomeBAL();
                ACC_IncomeENT entACC_Income = new ACC_IncomeENT();

                foreach (RepeaterItem items in rpData.Items)
                {
                    try
                    {
                        #region FindControl

                        TextBox txtAmount = (TextBox)items.FindControl("txtAmount");
                        TextBox txtIncomeDate = (TextBox)items.FindControl("txtIncomeDate");
                        HiddenField Hdfiled = (HiddenField)items.FindControl("hdIncomeID");
                        TextBox txtNote = (TextBox)items.FindControl("txtNote");
                        TextBox txtRemarks = (TextBox)items.FindControl("txtRemarks");
                        CheckBox chkIsSelected = (CheckBox)items.FindControl("chkIsSelected");
                        var ddlIncomeTypeID = (DropDownList)items.FindControl("ddlIncomeTypeID");



                        #endregion FindControl


                        if (chkIsSelected.Checked)
                        {
                            #region 15.1.1 Gather Data
                            entACC_Income.FinYearID = Convert.ToInt32(ddlFinYearID.SelectedValue);
                            entACC_Income.IncomeTypeID = Convert.ToInt32(ddlIncomeTypeID.SelectedValue);
                            entACC_Income.HospitalID = Convert.ToInt32(ddlHospitalID.SelectedValue);
                            entACC_Income.Amount = Convert.ToDecimal(txtAmount.Text.Trim());
                            entACC_Income.IncomeDate = Convert.ToDateTime(txtIncomeDate.Text.Trim());
                            entACC_Income.Note = (txtNote.Text.Trim());
                            entACC_Income.Remarks = (txtRemarks.Text.Trim());

                            entACC_Income.UserID = Convert.ToInt32(Session["UserID"]);
                            entACC_Income.Created = DateTime.Now;
                            entACC_Income.Modified = DateTime.Now;

                            #endregion 15.1.1 Gather Data
                        }


                        if (Hdfiled.Value != string.Empty)
                        {
                            if (chkIsSelected.Checked)
                            {
                                #region 15.1.2 Update Data
                                if (txtAmount.Text.Trim() == string.Empty)
                                {
                                    txtAmount.Focus();
                                    ucMessage.ShowError("Enter Amount");
                                    break;
                                }
                                else
                                {
                                    entACC_Income.IncomeID = Convert.ToInt32(Hdfiled.Value);
                                    if (balACC_IncomeBAL.Update(entACC_Income))
                                    {
                                        ucMessage.ShowSuccess(CommonMessage.RecordUpdated());
                                    }
                                }

                                #endregion 15.1.2 Update Data
                            }
                            else
                            {
                                #region 15.1.3 Delete Data
                                if (txtAmount.Text.Trim() == string.Empty)
                                {
                                    txtAmount.Focus();
                                    ucMessage.ShowError("Enter Amount");
                                    break;
                                }
                                else
                                {
                                    entACC_Income.IncomeID = Convert.ToInt32(Hdfiled.Value);
                                    if (balACC_IncomeBAL.Delete(entACC_Income.IncomeID))
                                    {
                                        ucMessage.ShowSuccess(CommonMessage.DeletedRecord());
                                    }
                                }

                                #endregion 15.1.3 Delete Data
                            }
                        }
                        else
                        {
                            if (chkIsSelected.Checked)
                            {
                                #region 15.1.4 Insert Data
                                if (txtAmount.Text.Trim() == string.Empty && txtIncomeDate.Text.Trim() != string.Empty && txtNote.Text.Trim() != string.Empty)
                                {
                                    txtAmount.Focus();
                                    ucMessage.ShowError("Enter Amount");
                                }
                                else
                                {
                                    if (txtAmount.Text.Trim() != string.Empty)
                                    {
                                        if (balACC_IncomeBAL.Insert(entACC_Income))
                                        {
                                            Div_ShowResult.Visible = false;
                                            ucMessage.ShowSuccess(CommonMessage.RecordSaved());
                                        }
                                    }
                                }
                                #endregion  15.1.4 Insert Data
                            }
                        }
                        Div_ShowResult.Visible = false;
                    }
                    catch (Exception ex)
                    {
                        ucMessage.ShowError(ex.Message);
                    }
                }
                ClearControls();
            }
        }

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
            DataTable dt = new DataTable();
            dt.Columns.Add("Amount");
            dt.Columns.Add("Note");
            dt.Columns.Add("IncomeDate");
            dt.Columns.Add("IncomeID");
            dt.Columns.Add("Remarks");
            foreach (RepeaterItem rp in rpData.Items)
            {
                TextBox txtAmount = (TextBox)rp.FindControl("txtAmount");
                TextBox txtNote = (TextBox)rp.FindControl("txtNote");
                TextBox txtIncomeDate = (TextBox)rp.FindControl("txtIncomeDate");
                TextBox txtRemarks = (TextBox)rp.FindControl("txtRemarks");
                HiddenField hdIncomeID = (HiddenField)rp.FindControl("hdIncomeID");

                DataRow dr = dt.NewRow();
                dr["Amount"] = txtAmount.Text.Trim();
                dr["Note"] = txtNote.Text.Trim();
                dr["IncomeDate"] = txtIncomeDate.Text.Trim();
                dr["Remarks"] = txtRemarks.Text.Trim();
                dr["IncomeId"] = hdIncomeID.Value.ToString();

                dt.Rows.Add(dr);
            }
            int count = 0;
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["Amount"].ToString() != String.Empty)
                    count++;
            }
            if (count == dt.Rows.Count)
                dt.Rows.Add();

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
