using GNForm3C.BAL;
using GNForm3C;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;

public partial class AdminPanel_Reports_RPT_HospitalWise_FinYearWise_IncomeExpenseList_RPT_FinYearWiseHospitalWiseIncomeExpense : System.Web.UI.Page
{
    #region private variable 

    DataTable dtACC_Ledger = new DataTable();
    private dsACC_IncomeExpense objAcc_income_Expense = new dsACC_IncomeExpense();

    #endregion private variable 
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ShowReport();
        }
    }
    #region ShowReport
    protected void ShowReport()
    {
        ExpInm_LedgerListBAL balACC_Income = new ExpInm_LedgerListBAL();
        DataTable dt = balACC_Income.HospitalWise_FinYearWise_IncomeExpenseList();
        dtACC_Ledger = dt.Copy();
        FillDataSet();

    }
    #endregion ShowReport

    #region FillDataSet
    protected void FillDataSet()
    {
        foreach (DataRow dr in dtACC_Ledger.Rows)
        {
            dsACC_IncomeExpense.dtACC_IncomeExpenseRow drACC_IncomeExpense = objAcc_income_Expense.dtACC_IncomeExpense.NewdtACC_IncomeExpenseRow();
            if (!dr["FinYearName"].Equals(System.DBNull.Value))
            {
                drACC_IncomeExpense.FinYearName = Convert.ToString(dr["FinYearName"]);
            }
            if (!dr["Hospital"].Equals(System.DBNull.Value))
            {
                drACC_IncomeExpense.Hospital = Convert.ToString(dr["Hospital"]);
            }
            if (!dr["TotalIncome"].Equals(System.DBNull.Value))
            {
                drACC_IncomeExpense.TotalIncome = Convert.ToDecimal(dr["TotalIncome"]);
            }
            if (!dr["TotalExpense"].Equals(System.DBNull.Value))
            {
                drACC_IncomeExpense.TotalExpense = Convert.ToDecimal(dr["TotalExpense"]);
            }
            if (!dr["TotalPatients"].Equals(System.DBNull.Value))
            {
                drACC_IncomeExpense.TotalPatients = Convert.ToInt32(dr["TotalPatients"]);
            }

            objAcc_income_Expense.dtACC_IncomeExpense.Rows.Add(drACC_IncomeExpense);

        }
        SetReportParameters();
        this.rvIncomeExpenseLedgerReport.LocalReport.DataSources.Clear();
        this.rvIncomeExpenseLedgerReport.LocalReport.DataSources.Add(new ReportDataSource("dtACC_IncomeExpense", (DataTable)objAcc_income_Expense.dtACC_IncomeExpense));
        this.rvIncomeExpenseLedgerReport.LocalReport.Refresh();
    }
    #endregion FillDataSet
    #region SetReportParameters
    private void SetReportParameters()
    {
        String ReportTitle = "FinYearWise HospitalWise IncomeExpense";
        String SubTitle = "abc";
        DateTime ReportDate = DateTime.Now;

        ReportParameter rptReportTitle = new ReportParameter("ReportTitle", ReportTitle);
        ReportParameter rptReportDate = new ReportParameter("ReportDate", ReportDate.ToString());
        ReportParameter rptReportSubTitle = new ReportParameter("ReportSubTitle", SubTitle.ToString());
        this.rvIncomeExpenseLedgerReport.LocalReport.SetParameters(new ReportParameter[] { rptReportTitle, rptReportDate,rptReportTitle });
    }
    #endregion SetReportParameters
}