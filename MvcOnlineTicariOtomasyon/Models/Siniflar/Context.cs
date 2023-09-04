using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace MvcOnlineTicariOtomasyon.Models.Sınıflar
{
    public class Context: DbContext
    {
        [Key]
        
        public DbSet <Cari> Caris { get; set; }
        public DbSet <Departman> Departmens { get; set; }
        public DbSet <FaturaKalem> FatuaKalems { get; set; }
        public DbSet <Faturalar> Faturalars { get; set; }
        public DbSet<Gider> Giders { get; set; }    
        public DbSet<Kategori> Kategoris { get; set; }  
        public DbSet<SatisHareket> SatisHarekets { get; set; }  
        public DbSet<Urun> Uruns { get; set; }  

    }
}