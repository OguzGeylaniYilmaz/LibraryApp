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
    
    public partial class Cezalar
    {
        public byte CezaID { get; set; }
        public Nullable<byte> Uye { get; set; }
        public Nullable<System.DateTime> Baslangic { get; set; }
        public Nullable<System.DateTime> Bitis { get; set; }
        public Nullable<decimal> Para { get; set; }
        public Nullable<byte> Hareket { get; set; }
    
        public virtual Hareketler Hareketler { get; set; }
        public virtual Uyeler Uyeler { get; set; }
    }
}