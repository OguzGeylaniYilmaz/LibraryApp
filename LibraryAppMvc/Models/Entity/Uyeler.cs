//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LibraryAppMvc.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Uyeler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Uyeler()
        {
            this.Cezalar = new HashSet<Cezalar>();
            this.Hareketler = new HashSet<Hareketler>();
        }
    
        public byte UyeID { get; set; }
        public string UyeAd { get; set; }
        public string UyeSoyad { get; set; }
        public string Mail { get; set; }
        public string KullanıcıAd { get; set; }
        public string Sifre { get; set; }
        public string Fotograf { get; set; }
        public string Telefon { get; set; }
        public string Okul { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cezalar> Cezalar { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Hareketler> Hareketler { get; set; }
    }
}
