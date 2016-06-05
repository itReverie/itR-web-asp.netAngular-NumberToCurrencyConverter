namespace MoneyEntities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MoneyModel : DbContext
    {
        public MoneyModel()
            : base("name=MoneyModel")
        {
            Database.SetInitializer<MoneyModel>(null);
        }

        public virtual DbSet<Money> Money { get; set; }
        public virtual DbSet<MoneyChange> MoneyChange { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
