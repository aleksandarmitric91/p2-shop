//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace p2_shop.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tip_Proizvoda
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tip_Proizvoda()
        {
            this.Proizvodis = new HashSet<Proizvodi>();
        }
    
        public long Tip_Proizvoda_ID { get; set; }
        public string Naziv_Tipa { get; set; }
        public Nullable<long> FK_Grupa_tipa_proizvoda { get; set; }
    
        public virtual Grupa_tipa_proizvoda Grupa_tipa_proizvoda { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Proizvodi> Proizvodis { get; set; }
    }
}
