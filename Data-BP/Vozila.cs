//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Data_BP
{
    using System;
    using System.Collections.Generic;
    
    public partial class Vozila
    {
        public Vozila()
        {
            this.Rezervacija = new HashSet<Rezervacija>();
        }
    
        public int IDVozila { get; set; }
        public string Naziv { get; set; }
        public byte[] Slika { get; set; }
        public string Detalji { get; set; }
        public string Cijena { get; set; }
        public bool Dostupnost { get; set; }
    
        public virtual ICollection<Rezervacija> Rezervacija { get; set; }
    }
}