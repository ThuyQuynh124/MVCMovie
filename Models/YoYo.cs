using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MvcMovie.Models{
    [Table("YaYa")]
    public class YoYo : Person{
        public int IDYoYo { get; set; }
        public string UniversityYoYo { get; set; }
    }
}