using MISA.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Service.interfaces
{
    public interface IEmployeeService: IBaseService<Employee>
    {
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
        /// <returns>ServiceResult</returns>
        /// CreatedBy: BDHIEU (10/02/2021)
        ServiceResult GetEmployeeByPosition(int positionId);

        /// <summary>
        /// Lấy danh sách nhân viên theo phòng ban
        /// </summary>
        /// <param name="positionId">Phòng ban</param>
        /// <returns>ServiceResult</returns>
        /// CreatedBy: BDHIEU (10/02/2021)
        ServiceResult GetEmployeeByDepartment(int departmentId);

        /// <summary>
        /// Lấy danh sách nhân viên theo phòng ban và vị trí công việc
        /// </summary>
        /// <param name="departmentId">Phòng ban</param>
        /// <param name="positionId">Vị trí công việc</param>
        /// <returns>ServiceResult</returns>
        /// CreatedBy: BDHIEU (10/02/2021)
        ServiceResult GetEmployeeByDepartmentAndPosition(int departmentId, int positionId);
    }
}
