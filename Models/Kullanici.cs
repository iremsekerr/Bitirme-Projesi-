using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace bitirmeSonProje.Models
{
    public class Kullanici
    {

        [Key]

        public int Id{ get; set; }
        public string KullaniciAdi { get; set; }
        public string Parola { get; set; }
        public string TamAd { get; set; }
        public bool AktifMi { get; set; }
        public bool OnayliMi { get; set; }
        public int RolId { get; set; }
        public int TipId { get; set; } // 1:akademisyen 2:görevli öğrenci
    }
}
