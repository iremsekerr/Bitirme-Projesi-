using System.Collections.Generic;

namespace bitirmeSonProje.Models
{
    public class SliderDto
    {
        public int KisiId { get; set; }
        public string Image { get; set; }     
        public List<Duyuru> Duyurular { get; set; }
        public List<OfisSaati> OfisSaatleri { get; set; }
        public List<DersProgrami> DersProgramlari { get; set; }
    }

}
