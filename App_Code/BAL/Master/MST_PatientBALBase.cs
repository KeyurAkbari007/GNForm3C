using GNForm3C.DAL;
using GNForm3C.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MST_PatientBALBase
/// </summary>
public class MST_PatientBALBase
{
    public MST_PatientBALBase()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public SqlInt32 InsertPatient(MST_PatientENTBase entMST_Patient)
    {
        MST_PatientDAL dalMST_ReceiptType = new MST_PatientDAL();
        SqlInt32 patientID = dalMST_ReceiptType.InsertPatient(entMST_Patient);
        return patientID;
    }

    public DataTable SelectView(SqlInt32 PatientID)
    {
        MST_PatientDAL dalMST_Patient = new MST_PatientDAL();
        return dalMST_Patient.SelectView(PatientID);
    }
    public DataTable PatientReport(SqlInt32 TransactionID)
    {
        MST_PatientDAL dalMST_Patient = new MST_PatientDAL();
        return dalMST_Patient.PatientReport(TransactionID);
    }
}