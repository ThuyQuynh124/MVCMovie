using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MvcMovie.Models
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        [Display(Name="Mã nhân viên")]
        public String EmployeeID { get; set; }
        [Display(Name="Tên nhân viên")]
        public string EmployName { get; set; }
        [Display(Name="Số điện thoại")]
        public string PhoneNumber { get; set; }
        public string Rating { get; set; }
    }
}