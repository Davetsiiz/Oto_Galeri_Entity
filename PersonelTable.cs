//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Oto_Galeri
{
    using System;
    using System.Collections.Generic;
    
    public partial class PersonelTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PersonelTable()
        {
            this.IslemTable = new HashSet<IslemTable>();
            this.PSifreTable = new HashSet<PSifreTable>();
        }
    
        public int P_ID { get; set; }
        public string P_AD { get; set; }
        public Nullable<int> S_ID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IslemTable> IslemTable { get; set; }
        public virtual SubeTable SubeTable { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PSifreTable> PSifreTable { get; set; }
    }
}
