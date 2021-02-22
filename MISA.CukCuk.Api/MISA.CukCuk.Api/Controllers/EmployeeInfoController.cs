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
    [Route("api/v1/employee-info")]
    [ApiController]
    public class EmployeeInfoController : BaseController<EmployeeInfo>
    {
        #region DECLARE
        IEmployeeInfoService _employeeInfoService;
        #endregion

        #region CONSTRUCTOR
        public EmployeeInfoController(IEmployeeInfoService employeeInfoService) : base(employeeInfoService)
        {
            _employeeInfoService = employeeInfoService;
        }
        #endregion

        #region METHOD
        /// <summary>
        /// Lấy danh sách nhân viên theo từ khóa tìm kiếm
        /// </summary>
        /// <param name="searchText">Từ khóa</param>
        /// <returns>Danh sách nhân viên theo từ khóa tìm kiếm</returns>
        /// CreatedBy: BDHIEU (19/02/2021)
        [HttpGet("search")]
        public IActionResult GetEmployeeBySearchText([FromQuery] string searchText)
        {
            var res = _employeeInfoService.GetEmployeeBySearchText(searchText);
            var data = res.Data as List<EmployeeInfo>;
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
