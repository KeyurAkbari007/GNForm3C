using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GNForm3C.BAL; // Replace with actual namespace for BAL
using GNForm3C.ENT; // Replace with actual namespace for ENT
using GNForm3C; // Replace with actual namespace for your project
using GNForm3C;
using Microsoft.Office.Interop.Excel;

public partial class AdminPanel_Master_democontent_DemoAddEdit : System.Web.UI.Page
{
    #region 10.0 Local Variables 

    String FormName = "DemoAddEdit";

    #endregion 10.0 Variables 

    #region 11.0 Page Load Event 

    protected void Page_Load(object sender, EventArgs e)
    {
        #region 11.1 Check User Login 

        if (Session["UserID"] == null)
            Response.Redirect(CV.LoginPageURL);

        #endregion 11.1 Check User Login 

        if (!Page.IsPostBack)
        {
            #region 11.2 Fill Labels 

            FillLabels(FormName);

            #endregion 11.2 Fill Labels 

            #region 11.3 Set Control Default Value 

            lblFormHeader.Text = CV.PageHeaderAdd + " Demo";
            upr.DisplayAfter = CV.UpdateProgressDisplayAfter;
            txtFName.Focus();

            #endregion 11.3 Set Control Default Value 

            #region 11.4 Fill Controls 

            FillControls();

            #endregion 11.4 Fill Controls 

            #region 11.5 Set Help Text 

            ucHelp.ShowHelp("Help Text will be shown here");

            #endregion 11.5 Set Help Text 
        }
    }

    #endregion 11.0 Page Load Event

    #region 12.0 Fill Labels 

    private void FillLabels(String FormName)
    {
        // Implementation for filling labels if required
    }

    #endregion 12.0 Fill Labels 

    #region 13.0 Fill Controls By PK  

    private void FillControls()
    {
        if (Request.QueryString["ID"] != null)
        {
            lblFormHeader.Text = CV.PageHeaderEdit + " Demo";
            DemoBAL balDemo = new DemoBAL();
            demoENT entDemo = new demoENT();
            entDemo = balDemo.SelectPK(CommonFunctions.DecryptBase64Int32(Request.QueryString["ID"]));

            if (!entDemo.FName.IsNull)
                txtFName.Text = entDemo.FName.Value.ToString();

            if (!entDemo.LName.IsNull)
                txtLName.Text = entDemo.LName.Value.ToString();
        }
    }

    #endregion 13.0 Fill Controls By PK 

    #region 14.0 Save Button Event 

    protected void btnSave_Click(object sender, EventArgs e)
    {
        Page.Validate();
        if (Page.IsValid)
        {
            try
            {
                DemoBAL balDemo = new DemoBAL();
                demoENT entDemo = new demoENT();

                #region 14.1 Validate Fields 

                String ErrorMsg = String.Empty;
                if (txtFName.Text.Trim() == String.Empty)
                    ErrorMsg += " - " + CommonMessage.ErrorRequiredField("First Name");
                if (txtLName.Text.Trim() == String.Empty)
                    ErrorMsg += " - " + CommonMessage.ErrorRequiredField("Last Name");

                if (ErrorMsg != String.Empty)
                {
                    ErrorMsg = CommonMessage.ErrorPleaseCorrectFollowing() + ErrorMsg;
                    ucMessage.ShowError(ErrorMsg);
                    return;
                }

                #endregion 14.1 Validate Fields

                #region 14.2 Gather Data 

                if (txtFName.Text.Trim() != String.Empty)
                    entDemo.FName = txtFName.Text.Trim();

                if (txtLName.Text.Trim() != String.Empty)
                    entDemo.LName = txtLName.Text.Trim();

               /* entDemo.UserID = Convert.ToInt32(Session["UserID"]);
                entDemo.Created = DateTime.Now;
                entDemo.Modified = DateTime.Now;*/

                #endregion 14.2 Gather Data 

                #region 14.3 Insert, Update 

                if (Request.QueryString["ID"] != null)
                {
                    entDemo.ID = CommonFunctions.DecryptBase64Int32(Request.QueryString["ID"]);
                    if (balDemo.Update(entDemo))
                    {
                        Response.Redirect("Demo.aspx");
                    }
                    else
                    {
                        ucMessage.ShowError(balDemo.Message);
                    }
                }
                else
                {
                    if (balDemo.Insert(entDemo))
                    {
                        ucMessage.ShowSuccess(CommonMessage.RecordSaved());
                        ClearControls();
                    }
                }

                #endregion 14.3 Insert, Update

            }
            catch (Exception ex)
            {
                ucMessage.ShowError(ex.Message);
            }
        }
    }

    #endregion 14.0 Save Button Event 

    #region 15.0 Clear Controls 

    private void ClearControls()
    {
        txtFName.Text = String.Empty;
        txtLName.Text = String.Empty;
        txtFName.Focus();
    }

    #endregion 15.0 Clear Controls 
}
