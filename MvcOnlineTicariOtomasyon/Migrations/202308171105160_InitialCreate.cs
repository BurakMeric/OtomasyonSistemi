namespace MvcOnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Caris",
                c => new
                    {
                        CariId = c.Int(nullable: false, identity: true),
                        CariAd = c.String(maxLength: 10, unicode: false),
                        CariSoyad = c.String(maxLength: 10, unicode: false),
                        CariSehir = c.String(maxLength: 13, unicode: false),
                        CariMail = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.CariId);
            
            CreateTable(
                "dbo.SatisHarekets",
                c => new
                    {
                        SatisId = c.Int(nullable: false, identity: true),
                        Tarih = c.DateTime(nullable: false),
                        Adet = c.Int(nullable: false),
                        Fiyat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Toplamutar = c.Decimal(nullable: false, precision: 18, scale: 2),
                        cari_CariId = c.Int(),
                        personel_PersonelID = c.Int(),
                        urun_UrunId = c.Int(),
                    })
                .PrimaryKey(t => t.SatisId)
                .ForeignKey("dbo.Caris", t => t.cari_CariId)
                .ForeignKey("dbo.Personels", t => t.personel_PersonelID)
                .ForeignKey("dbo.Uruns", t => t.urun_UrunId)
                .Index(t => t.cari_CariId)
                .Index(t => t.personel_PersonelID)
                .Index(t => t.urun_UrunId);
            
            CreateTable(
                "dbo.Personels",
                c => new
                    {
                        PersonelID = c.Int(nullable: false, identity: true),
                        PersonelAd = c.String(maxLength: 30, unicode: false),
                        PersonelSoyad = c.String(maxLength: 30, unicode: false),
                        PersonelGorsel = c.String(maxLength: 250, unicode: false),
                        Departmans_DepartmanId = c.Int(),
                    })
                .PrimaryKey(t => t.PersonelID)
                .ForeignKey("dbo.Departmen", t => t.Departmans_DepartmanId)
                .Index(t => t.Departmans_DepartmanId);
            
            CreateTable(
                "dbo.Departmen",
                c => new
                    {
                        DepartmanId = c.Int(nullable: false, identity: true),
                        DepartmanAd = c.String(maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => t.DepartmanId);
            
            CreateTable(
                "dbo.Uruns",
                c => new
                    {
                        UrunId = c.Int(nullable: false, identity: true),
                        UrunAd = c.String(maxLength: 30, unicode: false),
                        Marka = c.String(maxLength: 30, unicode: false),
                        Stok = c.Short(nullable: false),
                        AlisFiyat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SatisFiyat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Durum = c.Boolean(nullable: false),
                        UrunGorsel = c.String(maxLength: 250, unicode: false),
                        Kategoriid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UrunId)
                .ForeignKey("dbo.Kategoris", t => t.Kategoriid, cascadeDelete: true)
                .Index(t => t.Kategoriid);
            
            CreateTable(
                "dbo.Kategoris",
                c => new
                    {
                        KategoriId = c.Int(nullable: false, identity: true),
                        KategoriAd = c.String(maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => t.KategoriId);
            
            CreateTable(
                "dbo.FaturaKalems",
                c => new
                    {
                        FaturaKaleId = c.Int(nullable: false, identity: true),
                        Aciklama = c.String(maxLength: 100, unicode: false),
                        Miktar = c.Int(nullable: false),
                        BirimFiyat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Tutar = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Faturalar_FaturaId = c.Int(),
                    })
                .PrimaryKey(t => t.FaturaKaleId)
                .ForeignKey("dbo.Faturalars", t => t.Faturalar_FaturaId)
                .Index(t => t.Faturalar_FaturaId);
            
            CreateTable(
                "dbo.Faturalars",
                c => new
                    {
                        FaturaId = c.Int(nullable: false, identity: true),
                        FaturaSeriNo = c.String(maxLength: 1, fixedLength: true, unicode: false),
                        FaturaSıraNo = c.String(maxLength: 6, unicode: false),
                        Tarih = c.DateTime(nullable: false),
                        VergiDairesi = c.String(maxLength: 60, unicode: false),
                        Saat = c.DateTime(nullable: false),
                        TesliEden = c.String(maxLength: 30, unicode: false),
                        teslimAlan = c.String(maxLength: 10, unicode: false),
                    })
                .PrimaryKey(t => t.FaturaId);
            
            CreateTable(
                "dbo.Giders",
                c => new
                    {
                        GiderId = c.Int(nullable: false, identity: true),
                        Aciklama = c.String(maxLength: 100, unicode: false),
                        Tarih = c.DateTime(nullable: false),
                        Tutar = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.GiderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FaturaKalems", "Faturalar_FaturaId", "dbo.Faturalars");
            DropForeignKey("dbo.SatisHarekets", "urun_UrunId", "dbo.Uruns");
            DropForeignKey("dbo.Uruns", "Kategoriid", "dbo.Kategoris");
            DropForeignKey("dbo.SatisHarekets", "personel_PersonelID", "dbo.Personels");
            DropForeignKey("dbo.Personels", "Departmans_DepartmanId", "dbo.Departmen");
            DropForeignKey("dbo.SatisHarekets", "cari_CariId", "dbo.Caris");
            DropIndex("dbo.FaturaKalems", new[] { "Faturalar_FaturaId" });
            DropIndex("dbo.Uruns", new[] { "Kategoriid" });
            DropIndex("dbo.Personels", new[] { "Departmans_DepartmanId" });
            DropIndex("dbo.SatisHarekets", new[] { "urun_UrunId" });
            DropIndex("dbo.SatisHarekets", new[] { "personel_PersonelID" });
            DropIndex("dbo.SatisHarekets", new[] { "cari_CariId" });
            DropTable("dbo.Giders");
            DropTable("dbo.Faturalars");
            DropTable("dbo.FaturaKalems");
            DropTable("dbo.Kategoris");
            DropTable("dbo.Uruns");
            DropTable("dbo.Departmen");
            DropTable("dbo.Personels");
            DropTable("dbo.SatisHarekets");
            DropTable("dbo.Caris");
        }
    }
}
