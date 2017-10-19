namespace CurrencyConverterFrontend
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Conversion
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ConversionID { get; set; }

        [Required]
        [StringLength(25)]
        public string SourceCurrency { get; set; }

        [Required]
        [StringLength(25)]
        public string DestinationCurrency { get; set; }

        [Column(TypeName = "money")]
        public decimal? Amount { get; set; }

        [Column(TypeName = "money")]
        public decimal? ConvertedAmount { get; set; }
    }
}
