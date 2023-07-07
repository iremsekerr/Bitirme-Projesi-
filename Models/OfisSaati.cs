using System;
using System.ComponentModel.DataAnnotations;

namespace bitirmeSonProje.Models
{
    public class OfisSaati
    {
        [Key]
        public int Id { get; set; }
        public bool MusaitlikDurumu { get; set; }
        [Required(ErrorMessage = "Bir gün seçiniz...")]
        public string OfisSaatiGun { get; set; }
        [Required(ErrorMessage = "Başlangıç saati seçiniz...")]
        public string OfisSaatiBaslangic { get; set; }
        [Required(ErrorMessage = "Bitiş saati seçiniz...")]
        public string OfisSaatiBitis { get; set; }

        [Required(ErrorMessage = "Bu alan boş bırakılamaz.")]
        public int KisiId { get; set; }
    }
}
