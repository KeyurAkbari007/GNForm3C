using GNForm3C.DAL;
using GNForm3C.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for HospitalDataTreeBALBase
/// </summary>
public class HospitalDataTreeBALBase
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
    public HospitalDataTreeBALBase()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region SelectOperation
    public DataTable SelectPage(SqlInt32 HospitalID, SqlInt32 FinYearID)
    {
        HospitalDataTreeDAL dalHospitalDataTreeDAL = new HospitalDataTreeDAL();
        return dalHospitalDataTreeDAL.SelectPage(HospitalID, FinYearID);
    }

    #endregion SelectOperation
}