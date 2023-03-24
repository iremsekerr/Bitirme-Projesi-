using System.ComponentModel.DataAnnotations;

namespace bitirmeSonProje.Models
{
    public class OfisSaati
    {
        [Key]
        public bool MusaitlikDurumu { get; set; }

        public string OfisSaatiGun { get; set; }

        public string OfisSaatiBaslangic { get; set; }

        public string OfisSaatiBitis { get; set; }


    }
}
