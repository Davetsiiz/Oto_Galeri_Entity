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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Oto_galeriEntities1 : DbContext
    {
        public Oto_galeriEntities1()
            : base("name=Oto_galeriEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ArabaTable> ArabaTable { get; set; }
        public virtual DbSet<IslemTable> IslemTable { get; set; }
        public virtual DbSet<MSifreTable> MSifreTable { get; set; }
        public virtual DbSet<MusteriTable> MusteriTable { get; set; }
        public virtual DbSet<PersonelTable> PersonelTable { get; set; }
        public virtual DbSet<PSifreTable> PSifreTable { get; set; }
        public virtual DbSet<SubeTable> SubeTable { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TipTable> TipTable { get; set; }
        public virtual DbSet<IlTable> IlTable { get; set; }
    }
}
