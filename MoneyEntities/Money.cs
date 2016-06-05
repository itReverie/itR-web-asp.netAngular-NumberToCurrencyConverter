namespace MoneyEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Money")]
    public partial class Money
    {
        [Key]
        public long CurrencyId { get; set; }

        public decimal? CurrencyValue { get; set; }

        [StringLength(50)]
        public string CurrencyType { get; set; }
    }
}
