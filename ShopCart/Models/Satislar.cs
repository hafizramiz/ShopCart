//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ShopCart.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Satislar
    {
        public int satisId { get; set; }
        public Nullable<int> sepetId { get; set; }
        public Nullable<int> kargoBilgisiId { get; set; }
        public Nullable<int> odemeYontemiId { get; set; }
        public Nullable<int> bolgeId { get; set; }
        public int satisTutari { get; set; }
        public Nullable<System.DateTime> satisTarihi { get; set; }
        public string satisDurumu { get; set; }
    
        public virtual Bolgeler Bolgeler { get; set; }
        public virtual KargoBilgisi KargoBilgisi { get; set; }
        public virtual OdemeYontemleri OdemeYontemleri { get; set; }
        public virtual Sepetler Sepetler { get; set; }
    }
}
