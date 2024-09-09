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
    #region Private Fields

    private string _Message;

    #endregion Private Fields

    #region Public Properties

    public string Message
    {
        get
        {
            return _Message;
        }
        set
        {
            _Message = value;
        }
    }

    #endregion Public Properties

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
    public MST_PatientENT SelectByPK(SqlInt32 PatientID)
    {
        MST_PatientDAL dalMST_GNPatient = new MST_PatientDAL();
        return dalMST_GNPatient.SelectByPK(PatientID);
    }
    #region Update

    public Boolean Update(MST_PatientENT entMST_GNPatient)
    {
        MST_PatientDAL dalMST_GNPatient = new MST_PatientDAL();
        if (dalMST_GNPatient.Update(entMST_GNPatient))

        {
            return true;
        }
        else
        {
            this.Message = dalMST_GNPatient.Message;
            return false;
        }
    }

    #endregion Update

    #region Report

    public DataTable RPT_PatientIDCard(SqlInt32 PatientID)
    {
        MST_PatientDAL dalMST_GNPatient = new MST_PatientDAL();
        return dalMST_GNPatient.RPT_PatientIDCard(PatientID);
    }

    #endregion Report
    #region GetPatientAutoComplete
    public DataTable GetPatientAutoComplete(SqlString txtSearch, SqlString txtContext)
    {
        MST_PatientDAL dal = new MST_PatientDAL();
        return dal.GetPatientAutoComplete(txtSearch, txtContext);
    }
    #endregion GetPatientAutoComplete
}