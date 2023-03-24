using System.ComponentModel.DataAnnotations;

namespace bitirmeSonProje.Models
{
    public class DersProgrami
    {
        [Key]

        public string Gun { get; set; }
        public string DersSaati { get; set; }

        public string DersKod { get; set; }

        public string DersAdi { get; set; }

        public string OnKosul { get; set; }
    }
}
