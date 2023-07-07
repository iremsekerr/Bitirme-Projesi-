using System;
using System.ComponentModel.DataAnnotations;

namespace bitirmeSonProje.Models
{
    public class DersProgrami
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="BU ALAN BOŞ BIRAKILAMAZ...")]
        public string DersKod { get; set; }
        public string Gun { get; set; }
        public string DersSaati { get; set; }

        public string DersAdi { get; set; }

        public string OnKosul { get; set; }
        [Required(ErrorMessage = "Bu alan boş bırakılamaz.")]
        public int KisiId { get; set; }
    }
}
