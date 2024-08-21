using GNForm3C;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using GNForm3C.BAL;

public partial class AdminPanel_Reports_RPT_ACC_GNTransaction_RPT_ACC_GNTransactionPatientReceipt : System.Web.UI.Page
{
    #region 11.0 Local Variable 
    private dsGN_Transaction objdsACC_GNTransaction = new dsGN_Transaction();
    #endregion 11.0 Local Variable

    #region 12.0 Page Load Event

    protected void Page_Load(object sender, EventArgs e)
    {
        #region 12.0 Check User Login

        if (Session["UserID"] == null)
            Response.Redirect(CV.LoginPageURL);

        #endregion 12.0 Check User Login

        if (!Page.IsPostBack)
        {
            #region 12.1 DropDown List Fill Section

            FillDropDownList();

            #endregion 12.1 DropDown List Fill Section

            if (Request.QueryString["TransactionID"] != null && Request.QueryString["ReportType"] != null)
            {
                ShowReport();

            }


        }
    }

    #endregion 12.0 Page Load Event

    #region 13.0 FillLabels

    private void FillLabels(String FormName)
    {
    }

    #endregion

    #region 14.0 DropDownList

    #region 14.1 Fill DropDownList

    private void FillDropDownList()
    {
    }

    #endregion 14.1 Fill DropDownList

    #endregion 14.0 DropDownList

    #region 15.0 Search

    #region 15.1 Button Search Click Event

    protected void btnSearch_Click(object sender, EventArgs e)
    {
     

    }

    #endregion 15.1 Button Search Click Event

    #region 15.2 Search Function

    private void Search()
    {
        #region Parameters


        #endregion Parameters

        #region Gather Data


        #endregion Gather Data
     


    }

    #endregion 15.2 Search Function

    #endregion 15.0 Search

    #region 16.0 Repeater Events

    #region 16.1 Item Command Event

    protected void rpData_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
    }

    #endregion 16.1 Item Command Event

    #endregion 16.0 Repeater Events

    #region 17.0 Export Data

    #region 17.1 Excel Export Button Click Event

    private void ExportReport(string format)
    {
        try
        {
            string mimeType, encoding, extension;
            Warning[] warnings;
            string[] streamIds;

            byte[] bytes = rvPatientReceipt.LocalReport.Render(format,
                                                        null,
                                                        out mimeType,
                                                        out encoding,
                                                        out extension,
                                                        out streamIds,
                                                        out warnings);
            string FileName = "Hospital Report";
            Response.Clear();
            Response.ContentType = mimeType;
            Response.AddHeader("Content-Disposition", "attachment; filename="+FileName+"." + extension);
            Response.BinaryWrite(bytes);
            Response.End();

        }
        catch (Exception ex)
        {
        }

    }

    #endregion 17.1 Excel Export Button Click Event

    #endregion 17.0 Export Data

    #region 18.0 Cancel Button Event

    protected void btnClear_Click(object sender, EventArgs e)
    {
        ClearControls();
    }

    #endregion 18.0 Cancel Button Event

    #region 19.0 ClearControls 

    private void ClearControls()
    {

    }

    #endregion 19.0 ClearControls

    #region 20.0 SetDefaultDate
    private void SetDefaultDates()
    {

    }
    #endregion 20.0 SetDefaultDate

    #region 21.0 REPORT

    #region  21.1  ShowReport

    protected void ShowReport()
    {
        if (Request.QueryString["TransactionID"] != null && Request.QueryString["ReportType"] != null)
        {
            SqlInt32 TransactionID = CommonFunctions.DecryptBase64Int32(Request.QueryString["TransactionID"]);
            SqlString ReportType = CommonFunctions.DecryptBase64(Request.QueryString["ReportType"]);

            MST_PatientBAL balACC_GNTransaction = new MST_PatientBAL();

            DataTable dtPatientReceipt = balACC_GNTransaction.PatientReport(TransactionID);

            if (dtPatientReceipt != null)
            {
                FillDataSet(dtPatientReceipt);
            }

            ExportReport(ReportType.ToString());

        }
    }

    #endregion 21.1 ShowReport 

    #region 21.2 FillDataSet

    protected void FillDataSet(DataTable dtPatientReceipt)
    {
        foreach (DataRow dr in dtPatientReceipt.Rows)
        {
            dsGN_Transaction.dtPatientReceiptRow drPatientReceipt = objdsACC_GNTransaction.dtPatientReceipt.NewdtPatientReceiptRow();

            if (!dr["PatientName"].Equals(System.DBNull.Value))
                drPatientReceipt.PatientName = Convert.ToString(dr["PatientName"]);

            if (!dr["Age"].Equals(System.DBNull.Value))
                drPatientReceipt.Age = Convert.ToInt32(dr["Age"]);

            if (!dr["MobileNo"].Equals(System.DBNull.Value))
                drPatientReceipt.MobileNo = Convert.ToString(dr["MobileNo"]);

            if (!dr["DateOfAdmission"].Equals(System.DBNull.Value))
                drPatientReceipt.DateOfAdmission = Convert.ToDateTime(dr["DateOfAdmission"]);

            if (!dr["DateOfDischarge"].Equals(System.DBNull.Value))
                drPatientReceipt.DateOfDischarge = Convert.ToDateTime(dr["DateOfDischarge"]);

            if (!dr["Hospital"].Equals(System.DBNull.Value))
                drPatientReceipt.Hospital = Convert.ToString(dr["Hospital"]);

            if (!dr["ReferenceDoctor"].Equals(System.DBNull.Value))
                drPatientReceipt.ReferenceDoctor = Convert.ToString(dr["ReferenceDoctor"]);

            if (!dr["ReceiptNo"].Equals(System.DBNull.Value))
                drPatientReceipt.ReceiptNo = Convert.ToString(dr["ReceiptNo"]);

            if (!dr["ReceiptTypeName"].Equals(System.DBNull.Value))
                drPatientReceipt.ReceiptTypeName = Convert.ToString(dr["ReceiptTypeName"]);

            if (!dr["Treatment"].Equals(System.DBNull.Value))
                drPatientReceipt.Treatment = Convert.ToString(dr["Treatment"]);

            if (!dr["Rate"].Equals(System.DBNull.Value))
                drPatientReceipt.Rate = Convert.ToDecimal(dr["Rate"]);

            if (!dr["Quantity"].Equals(System.DBNull.Value))
                drPatientReceipt.Quantity = Convert.ToInt32(dr["Quantity"]);

            if (!dr["Amount"].Equals(System.DBNull.Value))
                drPatientReceipt.Amount = Convert.ToDecimal(dr["Amount"]);

            if (!dr["TreatmentDate"].Equals(System.DBNull.Value))
                drPatientReceipt.TreatmentDate = Convert.ToDateTime(dr["TreatmentDate"]);
            if (!dr["FinYearName"].Equals(System.DBNull.Value))
                drPatientReceipt.FinYear = Convert.ToString(dr["FinYearName"]);
            if (!dr["Deposite"].Equals(System.DBNull.Value))
                drPatientReceipt.Deposite = Convert.ToDecimal(dr["Deposite"]);


            objdsACC_GNTransaction.dtPatientReceipt.Rows.Add(drPatientReceipt);

        }

        SetReportParamater();
        this.rvPatientReceipt.LocalReport.DataSources.Clear();
        this.rvPatientReceipt.LocalReport.DataSources.Add(new ReportDataSource("dtPatient", (DataTable)objdsACC_GNTransaction.dtPatientReceipt));
        this.rvPatientReceipt.LocalReport.Refresh();
    }
    #endregion 21.2 FillDataSet

    #region 21.3 SetReportParamater
    protected void SetReportParamater()
    {
        String ReportTitle = "Shree G.T.Sheth Charitable Foundation";
        String ReportSubTitle = "Physiotherapy Center";
        DateTime PrintDate = DateTime.Now;

        ReportParameter rptReportTitle = new ReportParameter("ReportTitle", ReportTitle);
        ReportParameter rptReportSubTitle = new ReportParameter("ReportSubTitle", ReportSubTitle);
        ReportParameter rptPrintDate = new ReportParameter("PrintDate", PrintDate.ToString());

        this.rvPatientReceipt.LocalReport.SetParameters(new ReportParameter[] { rptReportTitle, rptReportSubTitle, rptPrintDate });

    }
    #endregion 21.3 SetReportParamater 

    #endregion 21.0 REPORT
}