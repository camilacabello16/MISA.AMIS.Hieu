using MISA.Common.Models;
using MISA.DataLayer.interfaces;
using MISA.Service.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Service
{
    public class EmployeeInfoService : BaseService<EmployeeInfo>, IEmployeeInfoService
    {
        #region DECLARE
        public IDbContext<EmployeeInfo> _dbContext;
        #endregion

        #region CONSTRUCTOR
        public EmployeeInfoService(IDbContext<EmployeeInfo> dbContext): base(dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion

        #region METHOD
        /// <summary>
        /// Lấy toàn bộ danh sách nhân viên
        /// </summary>
        /// <returns>Toàn bộ danh sách nhân viên</returns>
        /// CreatedBy: BDHIEU (13/02/2021)
        public override ServiceResult GetData()
        {
            var serviceResult = new ServiceResult();
            serviceResult.Data = _dbContext.GetAll("Proc_GetEmployeeInfo", commandType: System.Data.CommandType.StoredProcedure);
            return serviceResult;
        }

        /// <summary>
        /// Lấy danh sách nhân viên theo từ khóa tìm kiếm
        /// </summary>
        /// <param name="searchText">Từ tìm kiếm</param>
        /// <returns>Danh sách nhân viên theo từ khóa tìm kiếm</returns>
        /// CreatedBy: BDHIEU (19/02/2021)
        public ServiceResult GetEmployeeBySearchText(string searchText)
        {
            var serviceResult = new ServiceResult();
            serviceResult.Data = _dbContext.GetDataBySearchText(searchText);
            return serviceResult;
        }
        #endregion
    }
}
