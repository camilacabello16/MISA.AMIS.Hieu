using Dapper;
using MISA.Common.Models;
using MISA.DataLayer.interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DataLayer
{
    public class EmployeeInfoRepository : DbContext<EmployeeInfo>, IEmployeeInfoRepository
    {
    }
}
