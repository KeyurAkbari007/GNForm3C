using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace GNForm3C
{
    public class MST_BranchIntakeBALBase
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
        public MST_BranchIntakeBALBase()
        {

        }
        #endregion Constructor

        #region Select BranchIntake Data
        //public DataTable GetBranchIntakeData()
        //{
        //    MST_BranchIntakeDAL dalMST_BranchIntake = new MST_BranchIntakeDAL();

        //    return dalMST_BranchIntake.GetBranchIntakeData();
        //}


        #endregion Select BranchIntake Data

        #region Insert/Update Intake DATA
        //public void SaveBranchIntakeData(string branch, int year2022, int year2023, int year2024)
        //{
        //    MST_BranchIntakeDAL dalMST_BranchIntake = new MST_BranchIntakeDAL();
        //    dalMST_BranchIntake.SaveBranchIntakeData(branch, 2022, year2022);
        //    dalMST_BranchIntake.SaveBranchIntakeData(branch, 2023, year2023);
        //    dalMST_BranchIntake.SaveBranchIntakeData(branch, 2024, year2024);
        //}

        public void SaveBranchIntakeData(string branch, Dictionary<int, int> intakeData)
        {
            MST_BranchIntakeDAL dalMST_BranchIntake = new MST_BranchIntakeDAL();

            foreach (var entry in intakeData)
            {
                dalMST_BranchIntake.SaveBranchIntakeData(branch, entry.Key, entry.Value);
            }
        }

        #endregion Insert/Update Intake DATA

        #region Delete BranchIntake Data
        public void DeleteBranchIntakeData(string branch)
        {
            MST_BranchIntakeDAL dalMST_BranchIntake = new MST_BranchIntakeDAL();

            dalMST_BranchIntake.DeleteBranchIntakeData(branch);
        }

        #endregion Delete BranchIntake Data

        public DataTable GetBranchIntakeData()
        {
            MST_BranchIntakeDAL dal = new MST_BranchIntakeDAL();
            return dal.GetBranchIntakeData();
        }

    }
}