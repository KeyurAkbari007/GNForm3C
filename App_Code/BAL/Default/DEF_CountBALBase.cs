using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using GNForm3C;
using GNForm3C.DAL;
using GNForm3C.ENT;

namespace GNForm3C.BAL
{
    public class DEF_CountBALBase
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

		#region Constructor

        public DEF_CountBALBase()
		{

		}

		#endregion Constructor

        #region Select
        public DataTable SelectCount()
        {
            DEF_CountDAL dalDEF_Count = new DEF_CountDAL();
            return dalDEF_Count.SelectCount();
        }

        public DataTable TOP10IncomeList()
        {
            DEF_CountDAL dalDEF_Count = new DEF_CountDAL();
            return dalDEF_Count.TOP10IncomeList();
        }

        public DataTable TOP10ExpenseList()
        {
            DEF_CountDAL dalDEF_Count = new DEF_CountDAL();
            return dalDEF_Count.TOP10ExpenseList();
        }
        public DataTable SelectDayWiseMonthWiseIncome(SqlInt32 HospitalID)
        {
            DEF_CountDAL dalDEF_Count = new DEF_CountDAL();
            return dalDEF_Count.SelectDayWiseMonthWiseIncome(HospitalID);
        } 
        public DataTable SelectDayWiseMonthWiseExpense(SqlInt32 HospitalID)
        {
            DEF_CountDAL dalDEF_Count = new DEF_CountDAL();
            return dalDEF_Count.SelectDayWiseMonthWiseExpense(HospitalID);
        } 
        public DataTable SelectTreatmentSummary(SqlInt32 HospitalID)
        {
            DEF_CountDAL dalDEF_Count = new DEF_CountDAL();
            return dalDEF_Count.SelectTreatmentSummary(HospitalID);
        }
        #endregion Select
        #region Total Income/Expense
        public DataTable SelectTotalIncomeExpense(SqlInt32 HositalID)
        {
            DEF_CountDAL dalDEF_Count = new DEF_CountDAL();
            return dalDEF_Count.SelectTotalIncomeExpense(HositalID);
        }
        #endregion Total Income/Expense

    }
}