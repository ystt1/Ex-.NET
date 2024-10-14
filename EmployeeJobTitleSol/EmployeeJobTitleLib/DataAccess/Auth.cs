using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeJobTitleLib.DataAccess
{

    public class Auth
    {
        private static Auth _instance = null;
        private static readonly object _instanceLock = new object();
        private Auth() { }
        public static Auth Instance
        {
            get
            {
                lock (_instanceLock)
                {
                    if (_instance == null)
                    {
                        _instance = new Auth();
                    }
                    return _instance;
                }
            }
        }


        public Dbaccount Login(string username, string password)
        {
            Dbaccount dbaccount = null;
            try
            {
                var empDb = new EmployeeJobTitleContext();
                dbaccount = empDb.Dbaccounts.SingleOrDefault(emp => emp.AccountId == username && emp.AccountPassword == password);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dbaccount;
        }
    }
}
