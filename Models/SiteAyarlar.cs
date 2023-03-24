using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace bitirmeSonProje.Models
{
    public class SiteAyarlar
    {
        [Key]
        public int Id { get; set; }
        public string  SiteAdi { get; set; }
        public string SiteLogo { get; set; }
        public int SecilenKisiId { get; set; }

    }
}
