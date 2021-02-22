using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Common.Models;
using MISA.Service.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api.Controllers
{
    [Route("api/v1/employee")]
    [ApiController]
    public class EmployeeController : BaseController<Employee>
    {
        #region DECLARE
        public IEmployeeService _employeeService;
        #endregion

        #region CONSTRUCTOR
        public EmployeeController(IEmployeeService employeeService) : base(employeeService)
        {
            _employeeService = employeeService;
        }
        #endregion

        #region METHOD
        /// <summary>
        /// Lấy mã nhân viên lớn nhất
        /// </summary>
        /// <returns>Mã nhân viên lớn nhất</returns>
        /// CreatedBy: BDHIEU (10/02/2021)
        [HttpGet("employee-max-code")]
        public string GetMaxEmployeeCode()
        {
            return _employeeService.GetMaxEmployeeCode();
        }

        /// <summary>
        /// Lấy danh sách nhân viên theo phòng ban
        /// </summary>
        /// <param name="departmentId">Phòng ban</param>
        /// <returns>Danh sách nhân viên theo phòng ban</returns>
        /// CreatedBy: BDHIEU (10/02/2021)
        [HttpGet("department")]
        public IActionResult GetEmployeeByDepartment([FromQuery] int departmentId)
        {
            var res = _employeeService.GetEmployeeByDepartment(departmentId);
            var data = res.Data as List<Employee>;
            if (data.Count == 0)
            {
                return StatusCode(204, res.Data);
            }
            else
            {
                return StatusCode(200, res.Data);
            }
        }

        /// <summary>
        /// Lấy danh sách nhân viên theo vị trí công việc
        /// </summary>
        /// <param name="departmentId">Vị trí công việc</param>
        /// <returns>Danh sách nhân viên theo vị trí công việc</returns>
        /// CreatedBy: BDHIEU (10/02/2021)
        [HttpGet("position")]
        public IActionResult GetEmployeeByPosition([FromQuery] int positionId)
        {
            var res = _employeeService.GetEmployeeByPosition(positionId);
            var data = res.Data as List<Employee>;
            if (data.Count == 0)
            {
                return StatusCode(204, res.Data);
            }
            else
            {
                return StatusCode(200, res.Data);
            }
        }

        /// <summary>
        /// Lấy danh sách nhân viên theo phòng ban và vị trí công việc
        /// </summary>
        /// <param name="departmentId">Phòng ban</param>
        /// <param name="positionId">Vị trí công việc</param>
        /// <returns>Danh sách nhân viên theo phòng ban và vị trí công việc</returns>
        /// CreatedBy: BDHIEU (10/02/2021)
        [HttpGet("search")]
        public IActionResult GetEmployeeByDepartmentAndPosition(int departmentId, int positionId)
        {
            var res = _employeeService.GetEmployeeByDepartmentAndPosition(departmentId, positionId);
            var data = res.Data as List<Employee>;
            if (data.Count == 0)
            {
                return StatusCode(204, res.Data);
            }
            else
            {
                return StatusCode(200, res.Data);
            }
        }
        #endregion
    }
}
