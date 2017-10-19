namespace CurrencyConverterFrontend
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CurrencyModel : DbContext
    {
        public CurrencyModel()
            : base("name=CurrencyModel")
        {
        }

        public virtual DbSet<Conversion> Conversions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Conversion>()
                .Property(e => e.SourceCurrency)
                .IsUnicode(false);

            modelBuilder.Entity<Conversion>()
                .Property(e => e.DestinationCurrency)
                .IsUnicode(false);

            modelBuilder.Entity<Conversion>()
                .Property(e => e.Amount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Conversion>()
                .Property(e => e.ConvertedAmount)
                .HasPrecision(19, 4);
        }
    }
}
