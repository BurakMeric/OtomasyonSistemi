using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Sınıflar
{
    public class SatisHareket
    {

        [Key]
        public int SatisId { get; set; }
        //ürün
        //cari
        //personel
        public DateTime Tarih { get; set; }
        public int Adet { get; set; }   
        public decimal Fiyat { get; set; }  
        public decimal Toplamutar { get; set; }

        public Urun urun { get; set; }
        public Cari cari { get; set; }
        public Personel personel { get; set; }



    }
}