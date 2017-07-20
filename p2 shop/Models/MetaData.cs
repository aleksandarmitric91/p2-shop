using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace p2_shop.Models
{
    public class Tip_ProizvodaMetaData
    {
        [Key]
        public long Tip_Proizvoda_ID { get; set; }

        [Required(ErrorMessage = "Polje naziv tipa nije popunjeno")]
        [Display(Name = "Naziv tipa")]
        public string Naziv_Tipa { get; set; }

        [Required(ErrorMessage = "Polje grupa proizvoda nije popunjeno")]
        [Display(Name = "Grupa proizvoda")]
        public Nullable<long> FK_Grupa_tipa_proizvoda { get; set; }
    }

    public class Grupa_tipa_proizvodaMetaData
    {
        [Key]
        public long Grupa_tipa_proizvoda_ID { get; set; }

        [Required(ErrorMessage = "Polje naziv grupe nije popunjeno")]
        [Display(Name = "Naziv grupe")]
        public string Naziv_grupe_tipa_proizvoda { get; set; }
    }

    public class KorisniciMetaData
    {
        [Key]
        public long Korisnik_ID { get; set; }

        //[Required(ErrorMessage = "Polje ime nije popunjeno")]
        [Display(Name = "Ime")]
        public string Ime { get; set; }

        //[Required(ErrorMessage = "Polje prezime nije popunjeno")]
        [Display(Name = "Prezime")]
        public string Prezime { get; set; }

        //[Required(ErrorMessage = "Polje email nije popunjeno")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Polje korisničko ime nije popunjeno")]
        [Display(Name = "Korisničko ime")]
        public string Korisničko_ime { get; set; }

        [Required(ErrorMessage = "Polje šifra nije popunjeno")]
        [Display(Name = "Šifra")]
        [DataType(DataType.Password)]
        public string Šifra { get; set; }
    }

    public class PreglediMetaData
    {
        [Key]
        public long Pregled_ID { get; set; }

        [Display(Name = "Pregledač")]
        public string Pregledac { get; set; }

        [Required(ErrorMessage = "Polje ocjena nije popunjeno")]
        [Display(Name = "Ocjena")]
        [Range(0, 5, ErrorMessage = "Unijeta ocjena nije u intervalu od 0 do 5")]
        public Nullable<long> Ocjena { get; set; }

        [Required(ErrorMessage = "Polje komentar nije popunjeno")]
        [Display(Name = "Komentar")]
        public string Komentar { get; set; }

        //[Required(ErrorMessage = "Polje datum ocjene nije popunjeno")]
        [Display(Name = "Datum ocjene")]
        //[DataType(DataType.Date)]
        public Nullable<System.DateTime> Datum_ocjenjivanja { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Polje proizvod nije popunjeno")]
        [Display(Name = "Proizvod")]
        public Nullable<long> FK_Proizvod_ID { get; set; }
    }

    public class ProizvodiMetaData
    {
        [Key]
        public long Proizvod_ID { get; set; }

        [Required(ErrorMessage = "Polje naziv nije popunjeno")]
        [Display(Name = "Naziv")]
        public string Naziv { get; set; }

        [Required(ErrorMessage = "Polje cijena nije popunjeno")]
        [Display(Name = "Cijena")]
        [Range(0, double.MaxValue, ErrorMessage = "Vrednost polja cijena ne smije biti negativna")]
        public Nullable<double> Cijena { get; set; }

        [Required(ErrorMessage = "Polje opis nije popunjeno")]
        [Display(Name = "Opis")]
        public string Opis { get; set; }

        [Display(Name = "Naziv slike")]
        public string Naziv_Slike { get; set; }

        [Display(Name = "Aktivan")]
        [DefaultValue(true)]
        public bool Active { get; set; }

        [Required(ErrorMessage = "Polje tip proizvoda nije popunjeno")]
        [Display(Name = "Tip proizvoda")]
        public Nullable<long> FK_Tip_Proizvoda { get; set; }

        [Display(Name = "Istaknuti")]
        [DefaultValue(false)]
        public bool Istaknuti { get; set; }

        [Display(Name = "Akcija")]
        [DefaultValue(false)]
        public bool Akcija { get; set; }
    }

    public class Proizvodi_KorisniciMetaData
    {
        [Key]
        public long Kupovina_ID { get; set; }

        [Required(ErrorMessage = "Polje proizvod nije popunjeno")]
        [Display(Name = "Proizvod")]
        public Nullable<long> FK_Proizvodi { get; set; }

        [Required(ErrorMessage = "Polje korisnik nije popunjeno")]
        [Display(Name = "Korisnik")]
        public Nullable<long> FK_Korisnici { get; set; }
    }
}