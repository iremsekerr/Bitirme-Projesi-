using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace bitirmeSonProje.Models
{
    public class dbContext : DbContext
    {
        [Key]
        [System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DbSet<Kisi> Kisis { get; set; }
        public DbSet<Duyuru> Duyurus { get; set; }
        public DbSet<Kullanici> Kullanicis { get; set; }
        public DbSet<SiteAyarlar> SiteAyarlars { get; set; }
        public DbSet<DuyuruTuru> DuyuruTurus { get; set; }
        public DbSet<DersProgrami> DersProgramis { get; set; }
        public DbSet<OfisSaati> OfisSaatis { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        {
            optionsBuilder.UseSqlServer("server=LAPTOP-T64G6UVJ; database=DuyuruEkrani; integrated security=true");
        }
    }
}
