//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Utamica4.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Natjecanje
    {
        public int Id { get; set; }
        public string NazivUtakmice { get; set; }
        public string Ekipa1 { get; set; }
        public string Ekipa2 { get; set; }
        public System.DateTime Raspored { get; set; }
        public Nullable<int> RezultatE1 { get; set; }
        public Nullable<int> RezultatE2 { get; set; }
    }
}
