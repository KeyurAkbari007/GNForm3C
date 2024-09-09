using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

/// <summary>
/// Summary description for WebService_MST_Patient
/// </summary>
[WebService(Namespace = "~/WebServices/WebService_MST_Patient")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class WebService_MST_Patient : System.Web.Services.WebService
{

    public WebService_MST_Patient()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }


    [WebMethod]
    public List<string> GetPatientList(string prefixText, string count)
    {
        SqlString TxtSearch = SqlString.Null;
        SqlString TxtContext = SqlString.Null;

        if (prefixText != "")
            TxtSearch = Convert.ToString(prefixText);

        Console.WriteLine(TxtSearch);

        List<string> list = new List<string>();
        MST_PatientBAL balMST_Patient = new MST_PatientBAL();
        DataTable dt = balMST_Patient.GetPatientAutoComplete(TxtSearch, TxtContext);

        if (dt != null && dt.Rows.Count > 0)
        {
            foreach (DataRow row in dt.Rows)
            {
                string detail = string.Format("{0} - {1} - {2}",
                        row["PatientID"].ToString(),
                        row["PatientName"].ToString(),
                        //row["Age"].ToString(),
                        //row["DOB"].ToString(),
                        row["MobileNo"].ToString()
                    );
                list.Add(detail);
            }

        }

        return list;
    }


}
