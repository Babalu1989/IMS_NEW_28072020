using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;

    public class SessionUsed
    {
        public SessionUsed()
        {

        }
        private string _userName;
        private string _Password;
        private string _Def_Dist;
        private string _Def_Role;
        private string _Def_Dept;

        public string ISValidCAS;
        public string sid;
        public string DistRights;
        public string Dept;
        public string empid;            

        public string UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                _userName = value;
            }
        }
        public string Department
        {
            get
            {
                return _Def_Dept;
            }
            set
            {
                _Def_Dept = value;
            }
        }
        public string Password
        {
            get
            {
                return _Password;
            }
            set
            {
                _Password = value;
            }
        }
        public string DefDist
        {
            get
            {
                return _Def_Dist;
            }
            set
            {
                _Def_Dist = value;
            }
        }
        public string DefRole
        {
            get
            {
                return _Def_Role;
            }
            set
            {
                _Def_Role = value;
            }
        }      
    }

