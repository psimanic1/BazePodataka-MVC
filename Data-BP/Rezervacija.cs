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
    
    public partial class Rezervacija
    {
        public int IDRezervacija { get; set; }
        public int IDKorisnika { get; set; }
        public int IDVozila { get; set; }
        public int IDLokacija { get; set; }
        public int IDVrijemeRezervacije { get; set; }
        public int IDUposlenika { get; set; }
    
        public virtual Korisnik Korisnik { get; set; }
        public virtual Lokacija Lokacija { get; set; }
        public virtual Uposlenici Uposlenici { get; set; }
        public virtual Vozila Vozila { get; set; }
        public virtual Vrijeme Vrijeme { get; set; }
    }
}
