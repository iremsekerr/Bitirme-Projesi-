using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace bitirmeSonProje.Models
{
    public class Kisi
    {

        [Key]

        public int Id{ get; set; }
        public string TcKimlikNo { get; set; }
        public string Unvan { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public int KullaniciId { get; set; }

        public string ResimYolu { get; set; }


    }
}
