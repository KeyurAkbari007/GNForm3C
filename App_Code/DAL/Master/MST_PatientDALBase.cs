using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using GNForm3C.ENT;

namespace GNForm3C.DAL
{
    public abstract class MST_PatientDALBase : DataBaseConfig
    {
        #region Properties

        private string _Message;
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

        #endregion Properties

        #region Constructor

        public MST_PatientDALBase()
        {

        }

        #endregion Constructor
        

        #region Insert
        public SqlInt32 InsertPatient(MST_PatientENTBase entMST_Patient)
        {
            SqlInt32 PatientID = -1;

            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_GNPatient_Insert");

                sqlDB.AddOutParameter(dbCMD, "@PatientID", SqlDbType.Int, 4);
                sqlDB.AddInParameter(dbCMD, "@PatientName", SqlDbType.NVarChar, entMST_Patient.PatientName);
                sqlDB.AddInParameter(dbCMD, "@Age", SqlDbType.Int, entMST_Patient.Age);
                sqlDB.AddInParameter(dbCMD, "@MobileNo", SqlDbType.NVarChar, entMST_Patient.MobileNo);
                sqlDB.AddInParameter(dbCMD, "@PatientPhotoPath", SqlDbType.NVarChar, entMST_Patient.PatientPhotoPath);
                sqlDB.AddInParameter(dbCMD, "@DOB", SqlDbType.DateTime, entMST_Patient.DOB);
                sqlDB.AddInParameter(dbCMD, "@PrimaryDesc", SqlDbType.NVarChar, entMST_Patient.PrimaryDesc);
                sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, entMST_Patient.UserID);
                sqlDB.AddInParameter(dbCMD, "@Created", SqlDbType.DateTime, entMST_Patient.Created);
                sqlDB.AddInParameter(dbCMD, "@Modified", SqlDbType.DateTime, entMST_Patient.Modified);

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.ExecuteNonQuery(sqlDB, dbCMD);

                if (!(dbCMD.Parameters["@PatientID"].Value).Equals(DBNull.Value))
                {
                    entMST_Patient.PatientID = (SqlInt32)Convert.ToInt32(dbCMD.Parameters["@PatientID"].Value);
                    PatientID = entMST_Patient.PatientID;
                }

                return PatientID;
            }
            catch (SqlException sqlex)
            {
                Message = SQLDataExceptionMessage(sqlex);
                if (SQLDataExceptionHandler(sqlex))
                    throw;
                return PatientID;
            }
            catch (Exception ex)
            {
                Message = ExceptionMessage(ex);
                if (ExceptionHandler(ex))
                    throw;
                return PatientID;
            }
        }

        #endregion

        public DataTable SelectView(SqlInt32 PatientID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Patient_SelectView");

                sqlDB.AddInParameter(dbCMD, "@PatientID", SqlDbType.Int, PatientID);

                DataTable dtACC_GNTransaction = new DataTable("PR_MST_Patient_SelectView");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtACC_GNTransaction);

                return dtACC_GNTransaction;
            }
            catch (SqlException sqlex)
            {
                Message = SQLDataExceptionMessage(sqlex);
                if (SQLDataExceptionHandler(sqlex))
                    throw;
                return null;
            }
            catch (Exception ex)
            {
                Message = ExceptionMessage(ex);
                if (ExceptionHandler(ex))
                    throw;
                return null;
            }
        }
        #region SelectByPK

        public MST_PatientENT SelectByPK(SqlInt32 PatientID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_GNPatient_SelectByPK");

                sqlDB.AddInParameter(dbCMD, "@PatientID", SqlDbType.Int, PatientID);

                MST_PatientENT entMST_GNPatient = new MST_PatientENT();
                DataBaseHelper DBH = new DataBaseHelper();
                using (IDataReader dr = DBH.ExecuteReader(sqlDB, dbCMD))
                {
                    while (dr.Read())
                    {
                        if (!dr["PatientID"].Equals(System.DBNull.Value))
                            entMST_GNPatient.PatientID = Convert.ToInt32(dr["PatientID"]);

                        if (!dr["PatientName"].Equals(System.DBNull.Value))
                            entMST_GNPatient.PatientName = Convert.ToString(dr["PatientName"]);

                        if (!dr["Age"].Equals(System.DBNull.Value))
                            entMST_GNPatient.Age = Convert.ToInt32(dr["Age"]);

                        if (!dr["DOB"].Equals(System.DBNull.Value))
                            entMST_GNPatient.DOB = Convert.ToDateTime(dr["DOB"]);

                        if (!dr["MobileNo"].Equals(System.DBNull.Value))
                            entMST_GNPatient.MobileNo = Convert.ToString(dr["MobileNo"]);

                        if (!dr["PrimaryDesc"].Equals(System.DBNull.Value))
                            entMST_GNPatient.PrimaryDesc = Convert.ToString(dr["PrimaryDesc"]);

                        if (!dr["UserID"].Equals(System.DBNull.Value))
                            entMST_GNPatient.UserID = Convert.ToInt32(dr["UserID"]);

                        if (!dr["PatientPhotoPath"].Equals(System.DBNull.Value))
                            entMST_GNPatient.PatientPhotoPath = Convert.ToString(dr["PatientPhotoPath"]);

                        if (!dr["Created"].Equals(System.DBNull.Value))
                            entMST_GNPatient.Created = Convert.ToDateTime(dr["Created"]);

                        if (!dr["Modified"].Equals(System.DBNull.Value))
                            entMST_GNPatient.Modified = Convert.ToDateTime(dr["Modified"]);

                    }
                }
                return entMST_GNPatient;
            }
            catch (SqlException sqlex)
            {
                Message = SQLDataExceptionMessage(sqlex);
                if (SQLDataExceptionHandler(sqlex))
                    throw;
                return null;
            }
            catch (Exception ex)
            {
                Message = ExceptionMessage(ex);
                if (ExceptionHandler(ex))
                    throw;
                return null;
            }

        }

        #endregion SelectByPK

        #region Patient Report 
        public DataTable PatientReport(SqlInt32 TransactionID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PP_ACC_GNTransaction_PatientReceipt");

                sqlDB.AddInParameter(dbCMD, "@TransactionID", SqlDbType.Int, TransactionID);

                DataTable dtACC_Patient = new DataTable("PP_ACC_GNTransaction_PatientReceipt");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtACC_Patient);

                return dtACC_Patient;
            }
            catch (SqlException sqlex)
            {
                Message = SQLDataExceptionMessage(sqlex);
                if (SQLDataExceptionHandler(sqlex))
                    throw;
                return null;
            }
            catch (Exception ex)
            {
                Message = ExceptionMessage(ex);
                if (ExceptionHandler(ex))
                    throw;
                return null;
            }
        }
        #endregion Patient Report 

        #region Update

        public Boolean Update(MST_PatientENT entMST_GNPatient)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_GNPatient_Update");

                sqlDB.AddInParameter(dbCMD, "@PatientID", SqlDbType.Int, entMST_GNPatient.PatientID);
                sqlDB.AddInParameter(dbCMD, "@PatientName", SqlDbType.NVarChar, entMST_GNPatient.PatientName);
                sqlDB.AddInParameter(dbCMD, "@Age", SqlDbType.Int, entMST_GNPatient.Age);
                sqlDB.AddInParameter(dbCMD, "@MobileNo", SqlDbType.NVarChar, entMST_GNPatient.MobileNo);
                sqlDB.AddInParameter(dbCMD, "@DOB", SqlDbType.DateTime, entMST_GNPatient.DOB);
                sqlDB.AddInParameter(dbCMD, "@PrimaryDesc", SqlDbType.NVarChar, entMST_GNPatient.PrimaryDesc);
                sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, entMST_GNPatient.UserID);
                sqlDB.AddInParameter(dbCMD, "@PatientPhotoPath", SqlDbType.NVarChar, entMST_GNPatient.PatientPhotoPath);
                sqlDB.AddInParameter(dbCMD, "@Modified", SqlDbType.DateTime, entMST_GNPatient.Modified);

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.ExecuteNonQuery(sqlDB, dbCMD);

                //PatientID = entMST_GNPatient.PatientID;

                return true;
            }
            catch (SqlException sqlex)
            {
                Message = SQLDataExceptionMessage(sqlex);
                if (SQLDataExceptionHandler(sqlex))
                    throw;
                return false;
            }
            catch (Exception ex)
            {
                Message = ExceptionMessage(ex);
                if (ExceptionHandler(ex))
                    throw;
                return false;
            }
        }

        #endregion Update


        #region Report

        public DataTable RPT_PatientIDCard()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PP_MST_PatientList");

                DataTable dtACC_Expense = new DataTable("PP_MST_PatientList");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtACC_Expense);

                return dtACC_Expense;
            }
            catch (SqlException sqlex)
            {
                Message = SQLDataExceptionMessage(sqlex);
                if (SQLDataExceptionHandler(sqlex))
                    throw;
                return null;
            }
            catch (Exception ex)
            {
                Message = ExceptionMessage(ex);
                if (ExceptionHandler(ex))
                    throw;
                return null;
            }
        }

        #endregion Report



    }
}