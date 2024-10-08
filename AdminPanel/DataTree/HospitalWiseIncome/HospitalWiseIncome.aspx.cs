﻿using GNForm3C.BAL;
using iTextSharp.text.html;
using iTextSharp.text.xml;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class AdminPanel_Account_ACC_IncomeList_ACC_IncomeListPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadHospitals();
        }
    }

    private void LoadHospitals()
    {

        // Call the stored procedure without parameters to get all hospitals
        HospitalDataTreeBAL aCC_IncomeListBAL = new HospitalDataTreeBAL();
        DataTable dtHospitals = aCC_IncomeListBAL.SelectPage(SqlInt32.Null, SqlInt32.Null);

        // Bind the hospital data to the repeater
        rptHospitals.DataSource = dtHospitals;
        rptHospitals.DataBind();
    }

    protected void rptHospitals_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "LoadFinYears")
        {

            Panel panelFinYears = (Panel)e.Item.FindControl("pnlFinYears");
            Button btnshowFinYears = (Button)e.Item.FindControl("btnShowFinYears");


            if (panelFinYears != null)
            {
                if (panelFinYears.Visible)
                {
                    panelFinYears.Visible = false;
                    btnshowFinYears.Text = "+";
                    btnshowFinYears.CssClass = "btn btn-transparent rounded btn-xs btn-outline green-jungle active tooltips rounded-button"; // Set background to green

                }
                else
                {
                    int hospitalID = Convert.ToInt32(e.CommandArgument);

                    // Find the nested repeater for Financial Years
                    Repeater rptFinYears = (Repeater)e.Item.FindControl("rptFinYears"); 


                    // Fetch Financial Years for the selected HospitalID
                    HospitalDataTreeBAL aCC_IncomeListBAL = new HospitalDataTreeBAL();
                    DataTable dtFinYears = aCC_IncomeListBAL.SelectPage(hospitalID, SqlInt32.Null);

                    // Bind the Financial Years data to the nested repeater
                    btnshowFinYears.Text = "-";
                    btnshowFinYears.CssClass = "btn btn-transparent rounded btn-xs btn-outline red active tooltips rounded-button"; // Apply green button class
                 



                    rptFinYears.DataSource = dtFinYears;
                    rptFinYears.DataBind();
                    panelFinYears.Visible = true;
                }
                // Set the Panel visibility to true

            }



        }
    }

    protected void rptFinYears_ItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "LoadIncomes")
        {
            Panel panelIncomes = (Panel)e.Item.FindControl("pnlIncomes");
            Button btnShowIncomes = (Button)e.Item.FindControl("btnShowIncomes");


            if (panelIncomes != null)
            {
                if (panelIncomes.Visible)
                {
                    panelIncomes.Visible = false;
                    btnShowIncomes.Text = "+";
                    btnShowIncomes.CssClass = "btn btn-transparent rounded btn-xs btn-outline green-jungle active tooltips rounded-button"; // Set background to green
                }
                else
                {

                    int finYearID = Convert.ToInt32(e.CommandArgument);

                    // Find the parent RepeaterItem of this financial year (to get HospitalID)
                    RepeaterItem parentItem = (RepeaterItem)((Repeater)sender).NamingContainer;
                    HiddenField hdnHospitalID = (HiddenField)parentItem.FindControl("hdnHospitalID");
                    int hospitalID = Convert.ToInt32(hdnHospitalID.Value);

                    // Find the nested repeater for Income
                    Repeater rptIncomes = (Repeater)e.Item.FindControl("rptIncomes");

                    // Fetch Incomes for the selected HospitalID and FinYearID
                    HospitalDataTreeBAL aCC_IncomeListBAL = new HospitalDataTreeBAL();
                    DataTable dtIncomes = aCC_IncomeListBAL.SelectPage(hospitalID, finYearID);

                    // Bind the Financial Years data to the nested repeater
                    btnShowIncomes.Text = "-";
                    btnShowIncomes.CssClass = "btn btn-transparent rounded btn-xs btn-outline red active tooltips rounded-button"; // Apply green button class

                    // Bind the Income data to the nested repeater
                    rptIncomes.DataSource = dtIncomes;
                    rptIncomes.DataBind();

                    panelIncomes.Visible = true;

                }
            }
        }
    }
}