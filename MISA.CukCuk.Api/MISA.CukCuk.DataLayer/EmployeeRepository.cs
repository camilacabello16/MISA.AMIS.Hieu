using Dapper;
using MISA.Common.Models;
using MISA.DataLayer.interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MISA.DataLayer
{
    public class EmployeeRepository : DbContext<Employee>, IEmployeeRepository
    {
        /// <summary>
        /// Kiểm tra mã nhân viên đã tồn tại hay chưa
        /// </summary>
        /// <param name="CustomerCode">Mã nhân viên cần kiểm tra</param>
        /// <returns>true: tồn tại, false: không tồn tại</returns>
        /// CreatedBy: BDHIEU (09/02/2021)
        public bool CheckEmployeeCodeExist(string employeeCode)
        {
            _dbConnection = new MySqlConnection(_sqlConnector);
            var sqlCommand = $"SELECT EmployeeCode FROM Employee WHERE EmployeeCode = '{employeeCode}'";
            var res = _dbConnection.Query<string>(sqlCommand, commandType: CommandType.Text).FirstOrDefault();
            if (res != null)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Kiểm tra số điên thoại nhân viên có tồn tại hay không
        /// </summary>
        /// <param name="phoneNumber">Số điênh thoại kiểm tra</param>
        /// <returns>true: tồn tại, false: không tồn tại</returns>
        /// CreatedBy: BDHIEU (09/02/2021)
        public bool CheckPhoneNumberExist(string phoneNumber)
        {
            _dbConnection = new MySqlConnection(_sqlConnector);
            var sqlCommand = $"SELECT PhoneNumber FROM Employee WHERE PhoneNumber = '{phoneNumber}'";
            var res = _dbConnection.Query<string>(sqlCommand, commandType: CommandType.Text).FirstOrDefault();
            if (res != null)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Kiểm tra số CMTND/ Căn cước nhân viên có tồn tại hay không
        /// </summary>
        /// <param name="phoneNumber">số CMTND/ Căn cước kiểm tra</param>
        /// <returns>true: tồn tại, false: không tồn tại</returns>
        /// CreatedBy: BDHIEU (09/02/2021)
        public bool CheckIdNumberExist(string idNumber)
        {
            _dbConnection = new MySqlConnection(_sqlConnector);
            var sqlCommand = $"SELECT IdentifyNumber FROM Employee WHERE IdentifyNumber = '{idNumber}'";
            var res = _dbConnection.Query<string>(sqlCommand, commandType: CommandType.Text).FirstOrDefault();
            if (res != null)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Kiểm tra email nhân viên có tồn tại hay không
        /// </summary>
        /// <param name="phoneNumber">Email kiểm tra</param>
        /// <returns>true: tồn tại, false: không tồn tại</returns>
        /// CreatedBy: BDHIEU (09/02/2021)
        public bool CheckEmailExist(string email)
        {
            _dbConnection = new MySqlConnection(_sqlConnector);
            var sqlCommand = $"SELECT Email FROM Employee WHERE Email = '{email}'";
            var res = _dbConnection.Query<string>(sqlCommand, commandType: CommandType.Text).FirstOrDefault();
            if (res != null)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Lấy ra mã code lớn nhất của nhân viên
        /// </summary>
        /// <returns>Mã nhân viên lớn nhất</returns>
        /// CreatedBy: BDHIEU (10/02/2021)
        public string GetMaxEmployeeCode()
        {
            var maxEmployeeCode = _dbConnection.Query<string>("SELECT EmployeeCode FROM Employee e ORDER BY e.EmployeeCode DESC limit 1", commandType: CommandType.Text).FirstOrDefault();
            return maxEmployeeCode;
        }

        /// <summary>
        /// Lấy danh sách nhân viên theo vị trí công việc
        /// </summary>
        /// <param name="positionId"></param>
        /// <returns>Danh sách nhân viên theo vị trí công việc</returns>
        /// CreatedBy: BDHIEU (10/02/2021)
        public IEnumerable<Employee> GetEmployeeByPosition(int positionId)
        {
            var employeeInfos = _dbConnection.Query<Employee>("Proc_GetEmployeeByPosition", new { PositionId = positionId }, commandType: CommandType.StoredProcedure);
            return employeeInfos;
        }

        /// <summary>
        /// Lấy danh sách nhân viên theo phòng ban
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns>Danh sách nhân viên theo phòng ban</returns>
        /// CreatedBy: BDHIEU (10/02/2021)
        public IEnumerable<Employee> GetEmployeeByDepartment(int departmentId)
        {
            var employeeInfos = _dbConnection.Query<Employee>("Proc_GetEmployeeByDepartment", new { DepartmentId = departmentId }, commandType: CommandType.StoredProcedure);
            return employeeInfos;
        }

        /// <summary>
        /// Lấy danh sách nhân viên theo phòng ban và vị trí công việc
        /// </summary>
        /// <param name="departmentId">Phòng ban</param>
        /// <param name="positionId">Vị trí công việc</param>
        /// <returns>Danh sách nhân viên theo phòng ban và vị trí công việc</returns>
        /// CreatedBy: BDHIEU (10/02/2021)
        public IEnumerable<Employee> GetEmployeeByDepartmentAndPosition(int departmentId, int positionId)
        {
            var employees = _dbConnection.Query<Employee>($"SELECT * FROM Employee e WHERE e.DepartmentId = {departmentId} AND e.PositionId = {positionId}", commandType: CommandType.Text);
            return employees;
        }
    }
}
