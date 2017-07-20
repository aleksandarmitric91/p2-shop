using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace p2_shop.Models
{
    [MetadataType(typeof(Tip_ProizvodaMetaData))]
    public partial class Tip_Proizvoda
    {
    }

    [MetadataType(typeof(Grupa_tipa_proizvodaMetaData))]
    public partial class Grupa_tipa_proizvoda
    {
    }

    [MetadataType(typeof(KorisniciMetaData))]
    public partial class Korisnici
    {
    }

    [MetadataType(typeof(PreglediMetaData))]
    public partial class Pregledi
    {
    }

    [MetadataType(typeof(ProizvodiMetaData))]
    public partial class Proizvodi
    {
    }

    [MetadataType(typeof(Proizvodi_KorisniciMetaData))]
    public partial class Proizvodi_Korisnici
    {
    }
}