using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MvcMovie.Models{
    [Table("People") ]
    public class Person{
        [Key]
        public int PersonID { get; set; }
        public string FullName { get; set; }
    }
}
