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
    public abstract class DemoBALBase
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

        public DemoBALBase()
        {

        }

        #endregion Constructor

        #region InsertOperation

        public Boolean Insert(demoENT entDemoTable)
        {
            DemoDAL dalDemoTable = new DemoDAL();
            if (dalDemoTable.Insert(entDemoTable))
            {
                return true;
            }
            else
            {
                this.Message = dalDemoTable.Message;
                return false;
            }
        }

        #endregion InsertOperation

        #region UpdateOperation

        public Boolean Update(demoENT entDemoTable)
        {
            DemoDAL dalDemoTable = new DemoDAL();
            if (dalDemoTable.Update(entDemoTable))
            {
                return true;
            }
            else
            {
                this.Message = dalDemoTable.Message;
                return false;
            }
        }

        #endregion UpdateOperation

        #region DeleteOperation

        public Boolean Delete(SqlInt32 ID)
        {
            DemoDAL dalDemoTable = new DemoDAL();
            if (dalDemoTable.Delete(ID))
            {
                return true;
            }
            else
            {
                this.Message = dalDemoTable.Message;
                return false;
            }
        }

        #endregion DeleteOperation

        #region SelectOperation

        public demoENT SelectPK(SqlInt32 ID)
        {
            DemoDAL dalDemoTable = new DemoDAL();
            return dalDemoTable.SelectPK(ID);
        }
        public DataTable SelectView(SqlInt32 ID)
        {
            DemoDAL dalDemoTable = new DemoDAL();
            return dalDemoTable.SelectView(ID);
        }
        public DataTable SelectAll()
        {
            DemoDAL dalDemoTable = new DemoDAL();
            return dalDemoTable.SelectAll();
        }
        public DataTable SelectPage(SqlInt32 PageOffset, SqlInt32 PageSize, out Int32 TotalRecords,SqlInt32 id, SqlString FName, SqlString LName)
        {
            DemoDAL dalDemoTable = new DemoDAL();
            return dalDemoTable.SelectPage(PageOffset, PageSize, out TotalRecords,id, FName, LName);
        }

        #endregion SelectOperation

     /*   #region ComboBox

        public DataTable SelectComboBox()
        {
            DemoTableDAL dalDemoTable = new DemoTableDAL();
            return dalDemoTable.SelectComboBox();
        }

        #endregion ComboBox*/

    }
}
