using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_build.Helper
{
    internal class Common
    {
        public static string ConnString = "Data Source=localhost;" +
                                        "Initial Catalog=pos_dataset;" +
                                        "Persist Security Info=True;" +
                                        "User ID =sa;Encrypt=False;Password=mssql_p@ss";
    }
}
