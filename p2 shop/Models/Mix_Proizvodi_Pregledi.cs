using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace p2_shop.Models
{
    public partial class Mix_Proizvodi_Pregledi
    {
        public Proizvodi proizvod;
        public List<Pregledi> Grupa_pregleda;

        public Mix_Proizvodi_Pregledi(Proizvodi proizvod, List<Pregledi> Grupa_pregleda)
        {
            this.proizvod = proizvod;
            this.Grupa_pregleda = Grupa_pregleda;
        }

        public IEnumerable<p2_shop.Models.Proizvodi> Proizvodi { get; set; }
        public IEnumerable<p2_shop.Models.Pregledi> Pregledi { get; set; }

        public virtual Mix_Proizvodi_Pregledi Mix_Proizvodi_Pregledis { get; set; }
    }
}