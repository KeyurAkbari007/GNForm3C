using System;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;

public class ExpInm_LedgerListBALBase
{
    public ExpInm_LedgerListBALBase()
    {
        //
        // TODO: Add constructor logic here
        //
    }

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

    public DataTable SelectPage(SqlInt32 PageOffset, SqlInt32 PageSize, out Int32 TotalRecords, SqlDateTime FromDate, SqlDateTime ToDate, SqlString Type)
    {
        ExpInm_LedgerListDAL dalExpInm_LedgerList = new ExpInm_LedgerListDAL();
        return dalExpInm_LedgerList.SelectPage(PageOffset, PageSize, out TotalRecords, FromDate, ToDate, Type);
    }

    #region Delete Multiple Ledgers

    public void DeleteMultipleLedgers(string ledgerIds)
    {
        try
        {
            ExpInm_LedgerListDAL dalExpInm_LedgerList = new ExpInm_LedgerListDAL();
            dalExpInm_LedgerList.DeleteMultipleLedgers(ledgerIds);
        }
        catch (Exception ex)
        {
            _Message = "An error occurred while deleting records: " + ex.Message;
            // Optionally, rethrow or handle the exception as needed
            throw;
        }
    }

    #endregion Delete Multiple Ledgers
}
