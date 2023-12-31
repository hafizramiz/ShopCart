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
    
    public partial class Urunler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Urunler()
        {
            this.FavoriUruns = new HashSet<FavoriUrun>();
            this.SepetUruns = new HashSet<SepetUrun>();
            this.Yorumlars = new HashSet<Yorumlar>();
        }
    
        public int urunId { get; set; }
        public Nullable<int> saticiId { get; set; }
        public Nullable<int> kategoriId { get; set; }
        public Nullable<int> markaId { get; set; }
        public string urunAdi { get; set; }
        public int urunFiyati { get; set; }
        public string urunResmi { get; set; }
        public Nullable<System.DateTime> kayitTarihi { get; set; }
        public int urunStokMiktari { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FavoriUrun> FavoriUruns { get; set; }
        public virtual Kategoriler Kategoriler { get; set; }
        public virtual Kullanicilar Kullanicilar { get; set; }
        public virtual Markalar Markalar { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SepetUrun> SepetUruns { get; set; }
        public virtual UrunOzellikleri UrunOzellikleri { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Yorumlar> Yorumlars { get; set; }
    }
}
