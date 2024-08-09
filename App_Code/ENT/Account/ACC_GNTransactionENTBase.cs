using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ACC_GNTransactionENTBase
/// </summary>
public class ACC_GNTransactionENTBase
{
    public ACC_GNTransactionENTBase()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region Properties


    protected SqlInt32 _TransactionID;
    public SqlInt32 TransactionID
    {
        get
        {
            return _TransactionID;
        }
        set
        {
            _TransactionID = value;
        }
    }

    protected SqlInt32 _PatientID;
    public SqlInt32 PatientID
    {
        get
        {
            return _PatientID;
        }
        set
        {
            _PatientID = value;
        }
    }


    protected SqlDecimal _Amount;
    public SqlDecimal Amount
    {
        get
        {
            return _Amount;
        }
        set
        {
            _Amount = value;
        }
    }



    protected SqlString _ReferenceDoctor;
    public SqlString ReferenceDoctor
    {
        get
        {
            return _ReferenceDoctor;
        }
        set
        {
            _ReferenceDoctor = value;
        }
    }

    protected SqlInt32 _Count;
    public SqlInt32 Count
    {
        get
        {
            return _Count;
        }
        set
        {
            _Count = value;
        }
    }

    protected SqlInt32 _ReceiptNo;
    public SqlInt32 ReceiptNo
    {
        get
        {
            return _ReceiptNo;
        }
        set
        {
            _ReceiptNo = value;
        }
    }

    protected SqlInt32 _Quantity;

    public SqlInt32 Quantity
    {
        get
        {
            return _Quantity;
        }
        set
        {
            _Quantity = value;
        }
    }
    protected SqlDateTime _Date;
    public SqlDateTime Date
    {
        get
        {
            return _Date;
        }
        set
        {
            _Date = value;
        }
    }

    protected SqlDateTime _DateOfAdmission;
    public SqlDateTime DateOfAdmission
    {
        get
        {
            return _DateOfAdmission;
        }
        set
        {
            _DateOfAdmission = value;
        }
    }

    protected SqlDateTime _DateOfDischarge;
    public SqlDateTime DateOfDischarge
    {
        get
        {
            return _DateOfDischarge;
        }
        set
        {
            _DateOfDischarge = value;
        }
    }

    protected SqlDecimal _Deposite;
    public SqlDecimal Deposite
    {
        get
        {
            return _Deposite;
        }
        set
        {
            _Deposite = value;
        }
    }

    protected SqlDecimal _NetAmount;
    public SqlDecimal NetAmount
    {
        get
        {
            return _NetAmount;
        }
        set
        {
            _NetAmount = value;
        }
    }
    protected SqlInt32 _TreatmentID;
    public SqlInt32 TreatmentID
    {
        get { return _TreatmentID; }
        set { _TreatmentID = value; }
    }


    protected SqlInt32 _NoOfDays;
    public SqlInt32 NoOfDays
    {
        get
        {
            return _NoOfDays;
        }
        set
        {
            _NoOfDays = value;
        }
    }

    protected SqlString _Remarks;
    public SqlString Remarks
    {
        get
        {
            return _Remarks;
        }
        set
        {
            _Remarks = value;
        }
    }

    protected SqlInt32 _HospitalID;
    public SqlInt32 HospitalID
    {
        get
        {
            return _HospitalID;
        }
        set
        {
            _HospitalID = value;
        }
    }

    protected SqlInt32 _FinYearID;
    public SqlInt32 FinYearID
    {
        get
        {
            return _FinYearID;
        }
        set
        {
            _FinYearID = value;
        }
    }

    protected SqlInt32 _ReceiptTypeID;
    public SqlInt32 ReceiptTypeID
    {
        get
        {
            return _ReceiptTypeID;
        }
        set
        {
            _ReceiptTypeID = value;
        }
    }

    protected SqlInt32 _UserID;
    public SqlInt32 UserID
    {
        get
        {
            return _UserID;
        }
        set
        {
            _UserID = value;
        }
    }

    protected SqlDateTime _Created;
    public SqlDateTime Created
    {
        get
        {
            return _Created;
        }
        set
        {
            _Created = value;
        }
    }

    protected SqlDateTime _Modified;
    public SqlDateTime Modified
    {
        get
        {
            return _Modified;
        }
        set
        {
            _Modified = value;
        }
    }

    #endregion Properties


    #region ToString

    public override String ToString()
    {
        String ACC_TransactionENT_String = String.Empty;

        if (!TransactionID.IsNull)
            ACC_TransactionENT_String += " TransactionID = " + TransactionID.Value.ToString();

        if (!PatientID.IsNull)
            ACC_TransactionENT_String += "| Patient = " + PatientID.Value;


        if (!Amount.IsNull)
            ACC_TransactionENT_String += "| Amount = " + Amount.Value.ToString();
        if (!TreatmentID.IsNull)
            ACC_TransactionENT_String += "| Amount = " + TreatmentID.Value.ToString();
        if (!Quantity.IsNull)
            ACC_TransactionENT_String += "| Amount = " + Quantity.Value.ToString();


        if (!ReferenceDoctor.IsNull)
            ACC_TransactionENT_String += "| ReferenceDoctor = " + ReferenceDoctor.Value;

        if (!Count.IsNull)
            ACC_TransactionENT_String += "| Count = " + Count.Value.ToString();

        if (!ReceiptNo.IsNull)
            ACC_TransactionENT_String += "| ReceiptNo = " + ReceiptNo.Value.ToString();

        if (!Date.IsNull)
            ACC_TransactionENT_String += "| Date = " + Date.Value.ToString("dd-MM-yyyy");

        if (!DateOfAdmission.IsNull)
            ACC_TransactionENT_String += "| DateOfAdmission = " + DateOfAdmission.Value.ToString("dd-MM-yyyy");

        if (!DateOfDischarge.IsNull)
            ACC_TransactionENT_String += "| DateOfDischarge = " + DateOfDischarge.Value.ToString("dd-MM-yyyy");

        if (!Deposite.IsNull)
            ACC_TransactionENT_String += "| Deposite = " + Deposite.Value.ToString();

        if (!NetAmount.IsNull)
            ACC_TransactionENT_String += "| NetAmount = " + NetAmount.Value.ToString();

        if (!NoOfDays.IsNull)
            ACC_TransactionENT_String += "| NoOfDays = " + NoOfDays.Value.ToString();

        if (!Remarks.IsNull)
            ACC_TransactionENT_String += "| Remarks = " + Remarks.Value;

        if (!HospitalID.IsNull)
            ACC_TransactionENT_String += "| HospitalID = " + HospitalID.Value.ToString();

        if (!FinYearID.IsNull)
            ACC_TransactionENT_String += "| FinYearID = " + FinYearID.Value.ToString();

        if (!ReceiptTypeID.IsNull)
            ACC_TransactionENT_String += "| ReceiptTypeID = " + ReceiptTypeID.Value.ToString();

        if (!UserID.IsNull)
            ACC_TransactionENT_String += "| UserID = " + UserID.Value.ToString();

        if (!Created.IsNull)
            ACC_TransactionENT_String += "| Created = " + Created.Value.ToString("dd-MM-yyyy");

        if (!Modified.IsNull)
            ACC_TransactionENT_String += "| Modified = " + Modified.Value.ToString("dd-MM-yyyy");


        ACC_TransactionENT_String = ACC_TransactionENT_String.Trim();

        return ACC_TransactionENT_String;
    }

    #endregion ToString
}