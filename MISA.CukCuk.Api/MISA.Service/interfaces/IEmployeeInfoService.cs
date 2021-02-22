using MISA.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Service.interfaces
{
    public interface IEmployeeInfoService: IBaseService<EmployeeInfo>
    {
        /// <summary>
        /// Lấy danh sách nhân viên theo từ khóa tìm kiếm
        /// </summary>
        /// <param name="searchText">Từ tìm kiếm</param>
        /// <returns>Danh sách nhân viên theo từ khóa tìm kiếm</returns>
        /// CreatedBy: BDHIEU (19/02/2021)
        ServiceResult GetEmployeeBySearchText(string searchText);
    }
}
