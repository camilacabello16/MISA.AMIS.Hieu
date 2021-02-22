using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Common.Models
{
    /// <summary>
    /// Phòng ban nhân viên
    /// CreatedBy: BDHieu (18/02/2021)
    /// </summary>
    public class Department
    {
        #region Property
        /// <summary>
        /// Khóa chính
        /// </summary>
        public int DepartmentId { get; set; }
        /// <summary>
        /// Tên phòng ban
        /// </summary>
        public string DepartmentName { get; set; }
        #endregion
    }
}
