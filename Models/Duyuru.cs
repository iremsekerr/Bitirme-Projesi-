using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace bitirmeSonProje.Models
{
    public class Duyuru
    {
        [Key]
        public int Id { get; set; }
        public string DuyuruAdi { get; set; }
        public string ResimYolu { get; set; }
        public string Aciklama { get; set; }
        [Required(ErrorMessage ="Bu alan boş bırakılamaz.")]
        public int KisiId { get; set; }

    }
}
