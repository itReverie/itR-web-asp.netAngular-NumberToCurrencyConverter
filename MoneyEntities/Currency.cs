namespace MoneyEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// Class representing the Currency Table
    /// </summary>
    [Table("Currency")]
    public partial class Currency
    {
        public long CurrencyId { get; set; }

        public decimal? currencyValue { get; set; }

        [StringLength(50)]
        public string currencyType { get; set; }
    }
}
