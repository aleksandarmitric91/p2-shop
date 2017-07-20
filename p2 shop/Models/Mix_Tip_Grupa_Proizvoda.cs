using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace p2_shop.Models
{
    public partial class Mix_Tip_Grupa_Proizvoda
    {
        public List<Grupa_tipa_proizvoda> Grupa_listi;
        public List<Tip_Proizvoda> Tipovi;

        public Mix_Tip_Grupa_Proizvoda(List<Grupa_tipa_proizvoda> Grupa_listi, List<Tip_Proizvoda> Tipovi)
        {
            this.Grupa_listi = Grupa_listi;
            this.Tipovi = Tipovi;
        }

        public IEnumerable<p2_shop.Models.Grupa_tipa_proizvoda> Grupa_tipa_proizvoda { get; set; }
        public IEnumerable<p2_shop.Models.Tip_Proizvoda> Tip_proizvoda { get; set; }

        public virtual Mix_Tip_Grupa_Proizvoda Mix_Tip_Grupa_Proizvodas { get; set; }
    }
}