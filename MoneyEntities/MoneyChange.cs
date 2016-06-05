namespace MoneyEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MoneyChange")]
    public partial class MoneyChange
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public Guid? MoneyChangeId { get; set; }

        public long? CurrencyId { get; set; }

        public decimal? CurrencyValue { get; set; }

        public int? Quantity { get; set; }

        public DateTime? RequestedTime { get; set; }

        public decimal? Number { get; set; }
    }
}
