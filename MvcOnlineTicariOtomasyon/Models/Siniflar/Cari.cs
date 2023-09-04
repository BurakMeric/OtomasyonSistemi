﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Sınıflar
{
    public class Cari
    {
        [Key] 
        public int CariId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string CariAd { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string CariSoyad { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(13)]
        public string CariSehir { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string CariMail { get; set; }
        public ICollection<SatisHareket> satisHarekets { get; set; }
    }
}