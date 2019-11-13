using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevOne.Security.Cryptography.BCrypt;

namespace Data
{
    public class Cls_Ketnoi
    {
        DBDataContext DB;
        public DBDataContext Get_datacontext()
        {
            //string s = @"Data Source=LENOVO_IDEAPAD_\SQLEXPRESS;Initial Catalog=HumanResource_management;Integrated Security=True";
            string s = @"Data Source=LENOVO_IDEAPAD_\SQLEXPRESS;Initial Catalog=DATA_HumanResource;Integrated Security=True";
            DB = new DBDataContext(s);
            DB.Connection.Open();
            return DB;
        }
    }
}
