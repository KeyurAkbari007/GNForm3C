using System;
using System.Data.SqlTypes;

namespace GNForm3C.ENT
{
    public abstract class demoENTBase
    {
        #region Properties

        protected SqlInt32 _ID;
        public SqlInt32 ID
        {
            get
            {
                return _ID;
            }
            set
            {
                _ID = value;
            }
        }

        protected SqlString _FName;
        public SqlString FName
        {
            get
            {
                return _FName;
            }
            set
            {
                _FName = value;
            }
        }

        protected SqlString _LName;
        public SqlString LName
        {
            get
            {
                return _LName;
            }
            set
            {
                _LName = value;
            }
        }

        #endregion Properties

        #region Constructor

        public demoENTBase()
        {

        }

        #endregion Constructor

        #region ToString

        public override String ToString()
        {
            String demoTableENTString = String.Empty;

            if (!ID.IsNull)
                demoTableENTString += " ID = " + ID.Value.ToString();

            if (!FName.IsNull)
                demoTableENTString += "| FName = " + FName.Value;

            if (!LName.IsNull)
                demoTableENTString += "| LName = " + LName.Value;

            demoTableENTString = demoTableENTString.Trim();

            return demoTableENTString;
        }

        #endregion ToString
    }
}
