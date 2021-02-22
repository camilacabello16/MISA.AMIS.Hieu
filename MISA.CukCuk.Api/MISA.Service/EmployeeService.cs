using MISA.Common.Models;
using MISA.DataLayer.interfaces;
using MISA.Service.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Service
{
    public class EmployeeService : BaseService<Employee>, IEmployeeService
    {
        #region DECLARE
        IEmployeeRepository _employeeRepository;
        #endregion

        #region CONSTRUCTOR
        public EmployeeService(IEmployeeRepository employeeRepository) : base(employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        #endregion

        #region METHOD
        /// <summary>
        /// Lấy ra mã code lớn nhất của nhân viên
        /// </summary>
        /// <returns>Mã nhân viên lớn nhất</returns>
        /// CreatedBy: BDHIEU (10/02/2021)
        public string GetMaxEmployeeCode()
        {
            return _employeeRepository.GetMaxEmployeeCode();
        }

        /// <summary>
        /// Lấy danh sách nhân viên theo vị trí công việc
        /// </summary>
        /// <param name="positionId">Vị trí công việc</param>
        /// <returns>ServiceResult</returns>
        /// CreatedBy: BDHIEU (10/02/2021)
        public ServiceResult GetEmployeeByPosition(int positionId)
        {
            var serviceResult = new ServiceResult();
            serviceResult.Data = _employeeRepository.GetEmployeeByPosition(positionId);
            return serviceResult;
        }

        /// <summary>
        /// Lấy danh sách nhân viên theo phòng ban
        /// </summary>
        /// <param name="positionId">Phòng ban</param>
        /// <returns>ServiceResult</returns>
        /// CreatedBy: BDHIEU (10/02/2021)
        public ServiceResult GetEmployeeByDepartment(int departmentId)
        {
            var serviceResult = new ServiceResult();
            serviceResult.Data = _employeeRepository.GetEmployeeByDepartment(departmentId);
            return serviceResult;
        }

        /// <summary>
        /// Lấy danh sách nhân viên theo phòng ban và vị trí công việc
        /// </summary>
        /// <param name="departmentId">Phòng ban</param>
        /// <param name="positionId">Vị trí công việc</param>
        /// <returns>ServiceResult</returns>
        /// CreatedBy: BDHIEU (10/02/2021)
        public ServiceResult GetEmployeeByDepartmentAndPosition(int departmentId, int positionId)
        {
            var serviceResult = new ServiceResult();
            serviceResult.Data = _employeeRepository.GetEmployeeByDepartmentAndPosition(departmentId, positionId);
            return serviceResult;
        }

        /// <summary>
        /// Validate dữ liệu khi thêm mới nhân viên
        /// </summary>
        /// <param name="employee">Nhân viên cần thêm mới</param>
        /// <param name="errorMsg">Thông báo lỗi</param>
        /// <returns>true - validate thành công, false - validate có lỗi</returns>
        /// CreatedBy: BDHIEU (10/02/2021)
        protected override bool ValidateData(Employee employee, ErrorMsg errorMsg = null)
        {
            var isValid = true;
            if (employee.EmployeeCode == "")
            {
                errorMsg.devMsg.Add(MISA.Common.Properties.Resources.ErrorService_NullEmployeeCode_dev);
                errorMsg.userMsg.Add(MISA.Common.Properties.Resources.ErrorService_NullEmployeeCode_user);
                isValid = false;
            }
            var isExist = _employeeRepository.CheckEmployeeCodeExist(employee.EmployeeCode);
            if (isExist == true)
            {
                errorMsg.devMsg.Add(MISA.Common.Properties.Resources.ErrorService_DuplicateEmployeeCode_dev);
                errorMsg.userMsg.Add(MISA.Common.Properties.Resources.ErrorService_DuplicateEmployeeCode_user);
                isValid = false;
            }
            if (employee.FullName == "")
            {
                errorMsg.devMsg.Add(MISA.Common.Properties.Resources.ErrorService_NullFullName_dev);
                errorMsg.userMsg.Add(MISA.Common.Properties.Resources.ErrorService_NullFullName_user);
                isValid = false;
            }
            if(employee.IdentifyNumber != "")
            {
                isExist = _employeeRepository.CheckIdNumberExist(employee.IdentifyNumber);
                if (isExist == true)
                {
                    errorMsg.devMsg.Add(MISA.Common.Properties.Resources.ErrorService_DuplicateIdNumber_dev);
                    errorMsg.userMsg.Add(MISA.Common.Properties.Resources.ErrorService_DuplicateIdNumber_user);
                    isValid = false;
                }
            }
            return isValid;
        }
        #endregion
    }
}
