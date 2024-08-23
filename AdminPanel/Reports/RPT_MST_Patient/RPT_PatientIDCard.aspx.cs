using GNForm3C;
using GNForm3C.BAL;
using Microsoft.Reporting.WebForms; 
using System; 
using System.Data;
using System.Data.SqlTypes; 
using System.Web.UI; 

public partial class AdminPanel_Reports_RPT_MST_Patient_RPT_PatientIDCard : System.Web.UI.Page
{
    #region Private Variable
    private DataTable dtMST_Patient = new DataTable("dtMST_Patient");
    private dsMST_Patient objdsMST_Patient = new dsMST_Patient();

    #endregion
    #region Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ShowReport();
        }

    }
    #endregion Page Load Event

    #region Show Report
    protected void ShowReport()
    {
        try
        {
            SqlInt32 PatientID = SqlInt32.Null;
            MST_PatientBAL balMST_Patient = new MST_PatientBAL();
            dtMST_Patient = balMST_Patient.RPT_PatientIDCard(PatientID);
            FillDataSet();
        }
        catch (Exception ex)
        {

        }

    }
    #endregion Show Report

    #region FillDataSet

    protected void FillDataSet()
    { 
        foreach (DataRow dr in dtMST_Patient.Rows)
        {
            dsMST_Patient.dtMST_PatientRow drMST_Patient = objdsMST_Patient.dtMST_Patient.NewdtMST_PatientRow();

            if (!dr["PatientID"].Equals(System.DBNull.Value))
                drMST_Patient.PatientID = Convert.ToInt32(dr["PatientID"]);

            if (!dr["PatientName"].Equals(System.DBNull.Value))
                drMST_Patient.PatientName = Convert.ToString(dr["PatientName"]);

            if (!dr["Age"].Equals(System.DBNull.Value))
                drMST_Patient.Age = Convert.ToInt32(dr["Age"]);

            if (!dr["MobileNo"].Equals(System.DBNull.Value))
                drMST_Patient.MobileNo = Convert.ToString(dr["MobileNo"]);
             
            if (!dr["DOB"].Equals(System.DBNull.Value))
                drMST_Patient.DOB = Convert.ToDateTime(dr["DOB"]);


            if (!dr["PrimaryDesc"].Equals(System.DBNull.Value))
                drMST_Patient.PrimaryDesc = Convert.ToString(dr["PrimaryDesc"]);


            if (!dr["FinYearName"].Equals(System.DBNull.Value))
                drMST_Patient.FinYearName = Convert.ToString(dr["FinYearName"]);

            if (!dr["Hospital"].Equals(System.DBNull.Value))
                drMST_Patient.Hospital = Convert.ToString(dr["Hospital"]);

            if (!dr["PatientID"].Equals(System.DBNull.Value))
            {
                drMST_Patient.Barcode = CommonFunctions.GenerateBarcode(drMST_Patient.PatientID.ToString());
            } 
            if (!dr["PatientPhotoPath"].Equals(System.DBNull.Value))
            {
                drMST_Patient.PatientPhotoPath = CommonFunctions.ConvertImagePathToPngBytes(dr["PatientPhotoPath"].ToString());
            }
            else
            {
                drMST_Patient.PatientPhotoPath = CommonFunctions.ConvertImagePathToPngBytes(CV.DefaultNoImagePath);

            }

            objdsMST_Patient.dtMST_Patient.Rows.Add(drMST_Patient);
        }

        this.rvPatientIDCard.LocalReport.EnableExternalImages = true; 
        SetReportParameters();
        this.rvPatientIDCard.LocalReport.DataSources.Clear();
        this.rvPatientIDCard.LocalReport.DataSources.Add(new ReportDataSource("dtMST_Patient", (DataTable)objdsMST_Patient.dtMST_Patient));
        this.rvPatientIDCard.LocalReport.Refresh();
    }
    #endregion FillDataSet


    #region SetReportParameter
    private void SetReportParameters()
    {
        String ReportTitle = "Patient";
        String ReportSubTitle = "Patient ID Card"; 
        DateTime PrintDate = DateTime.Now;

        ReportParameter rptReportTitle = new ReportParameter("ReportTitle", ReportTitle);
        ReportParameter rptReportSubTitle = new ReportParameter("ReportSubTitle", ReportSubTitle);
        ReportParameter rptFooterDate = new ReportParameter("PrintDate", PrintDate.ToString());

        this.rvPatientIDCard.LocalReport.SetParameters(new ReportParameter[] { rptReportTitle, rptReportSubTitle, rptFooterDate });
    }
    #endregion SetReportParameter
}