using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Common.Models
{
    /// <summary>
    /// Thông tin nhân viên nối với bảng phòng ban
    /// CreatedBy: BDHieu (18/02/2021)
    /// </summary>
    public class EmployeeInfo
    {
        #region Property
        /// <summary>
        /// Khóa chính
        /// </summary>
        public Guid EmployeeId { get; set; }
        /// <summary>
        /// Mã nhân viên
        /// </summary>
        public string EmployeeCode { get; set; }
        /// <summary>
        /// Tên nhân viên
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// Ngày sinh nhân viên
        /// </summary>
        public DateTime DateOfBirth { get; set; }
        /// <summary>
        /// Giới tính nhân viên
        /// </summary>
        public int Gender { get; set; }
        /// <summary>
        /// Khóa ngoài với bảng phòng ban
        /// </summary>
        public int DepartmentId { get; set; }
        /// <summary>
        /// Số CMTND/ Căn cước
        /// </summary>
        public string IdentifyNumber { get; set; }
        /// <summary>
        /// Ngày cấp CMTND/ Căn cước
        /// </summary>
        public DateTime ReleaseDay { get; set; }
        /// <summary>
        /// Chức danh nhân viên
        /// </summary>
        public string EmployeeTitle { get; set; }
        /// <summary>
        /// Nơi cấp CMTND/ Căn cước
        /// </summary>
        public string ReleaseLocation { get; set; }
        /// <summary>
        /// Địa chỉ nhân viên
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Số điện thoại nhân viên
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Số điện thoại cố định của nhân viên
        /// </summary>
        public string FixPhoneNumber { get; set; }
        /// <summary>
        /// Email nhân viên
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Số tài khoản ngân hàng
        /// </summary>
        public string BankNumber { get; set; }
        /// <summary>
        /// Tên ngân hàng
        /// </summary>
        public string BankName { get; set; }
        /// <summary>
        /// Chi nhánh ngân hàng
        /// </summary>
        public string BankAddress { get; set; }
        /// <summary>
        /// Thành phố của ngân hàng
        /// </summary>
        public string BankCity { get; set; }
        /// <summary>
        /// Tên phòng ban nhân viên
        /// </summary>
        public string DepartmentName { get; set; }
        #endregion
    }
}
