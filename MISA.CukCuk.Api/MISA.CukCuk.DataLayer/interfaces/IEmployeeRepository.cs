using System;
using System.Collections.Generic;
using System.Text;
using MISA.Common.Models;

namespace MISA.DataLayer.interfaces
{
    public interface IEmployeeRepository : IDbContext<Employee>
    {
        /// <summary>
        /// Kiểm tra mã nhân viên đã tồn tại hay chưa
        /// </summary>
        /// <param name="CustomerCode">Mã nhân viên cần kiểm tra</param>
        /// <returns>true: tồn tại, false: không tồn tại</returns>
        /// CreatedBy: BDHIEU (09/02/2021)
        bool CheckEmployeeCodeExist(string employeeCode);

        /// <summary>
        /// Kiểm tra số điên thoại nhân viên có tồn tại hay không
        /// </summary>
        /// <param name="phoneNumber">Số điênh thoại kiểm tra</param>
        /// <returns>true: tồn tại, false: không tồn tại</returns>
        /// CreatedBy: BDHIEU (09/02/2021)
        bool CheckPhoneNumberExist(string phoneNumber);

        /// <summary>
        /// Kiểm tra số CMTND/ Căn cước nhân viên có tồn tại hay không
        /// </summary>
        /// <param name="phoneNumber">số CMTND/ Căn cước kiểm tra</param>
        /// <returns>true: tồn tại, false: không tồn tại</returns>
        /// CreatedBy: BDHIEU (09/02/2021)
        bool CheckIdNumberExist(string idNumber);

        /// <summary>
        /// Kiểm tra email nhân viên có tồn tại hay không
        /// </summary>
        /// <param name="phoneNumber">Email kiểm tra</param>
        /// <returns>true: tồn tại, false: không tồn tại</returns>
        /// CreatedBy: BDHIEU (09/02/2021)
        bool CheckEmailExist(string email);

        /// <summary>
        /// Lấy ra mã code lớn nhất của nhân viên
        /// </summary>
        /// <returns>Mã nhân viên lớn nhất</returns>
        /// CreatedBy: BDHIEU (10/02/2021)
        string GetMaxEmployeeCode();

        /// <summary>
        /// Lấy danh sách nhân viên theo vị trí công việc
        /// </summary>
        /// <param name="positionId">Vị trí công việc</param>
        /// <returns>Danh sách nhân viên theo vị trí công việc</returns>
        /// CreatedBy: BDHIEU (10/02/2021)
        IEnumerable<Employee> GetEmployeeByPosition(int positionId);

        /// <summary>
        /// Lấy danh sách nhân viên theo phòng ban
        /// </summary>
        /// <param name="departmentId">Phòng ban</param>
        /// <returns>Danh sách nhân viên theo phòng ban</returns>
        /// CreatedBy: BDHIEU (10/02/2021)
        IEnumerable<Employee> GetEmployeeByDepartment(int departmentId);

        /// <summary>
        /// Lấy danh sách nhân viên theo phòng ban và vị trí công việc
        /// </summary>
        /// <param name="departmentId">Phòng ban</param>
        /// <param name="positionId">Vị trí công việc</param>
        /// <returns>Danh sách nhân viên theo phòng ban và vị trí công việc</returns>
        /// CreatedBy: BDHIEU (10/02/2021)
        IEnumerable<Employee> GetEmployeeByDepartmentAndPosition(int departmentId, int positionId);
    }
}
