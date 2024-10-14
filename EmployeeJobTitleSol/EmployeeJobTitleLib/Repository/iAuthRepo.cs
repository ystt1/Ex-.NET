using EmployeeJobTitleLib.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeJobTitleLib.Repository
{
    public interface iAuthRepo
    {
        Dbaccount Login(string username, string password);
    }
}
