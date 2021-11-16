using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MvcMovie.Models
{
    [Table("Students")]
    public class Student
    {
        [Key]
        [Display(Name="Mã sinh viên")]

        public String StudenID { get; set; }
         [Display(Name="Tên sinh viên")]
        public string StudentName { get; set; }
        [Display(Name="Địa chỉ")]
        public string Address { get; set; } 
    }
}