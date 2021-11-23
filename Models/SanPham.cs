using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MvcMovie.Models{
    [Table("SanPhams") ]
    public class SanPham{
        [Key]
        public int SanPhamID { get; set; }
        public string SanPhamName { get; set; }
        public string LoaiSanPhamID { get; set; }
        public LoaiSanPham LoaiSanPham{get;set;}
    }
}