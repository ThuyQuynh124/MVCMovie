using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MvcMovie.Models{
    [Table("LoaiSanPhams") ]
    public class LoaiSanPham{
        [Key]
        public string LoaiSanPhamID { get; set; }
        public string LoaiSanPhamName { get; set; }
        public ICollection<SanPham> SanPhams{get; set;}
    }
}