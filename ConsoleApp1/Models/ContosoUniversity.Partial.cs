namespace ConsoleApp1.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;

    public partial class ContosoUniversityEntities : DbContext
    {
        public override int SaveChanges()
        {
            var entries = this.ChangeTracker.Entries();

            //foreach (var entry in entries)
            //{
            //    if (entry.Entity is Course && entry.State == EntityState.Modified)
            //    {
            //        entry.CurrentValues.SetValues(new { ModifiedOn = DateTime.Now });
            //    }
            //}

            foreach (var entry in entries.Where(p => p.Entity is Course))
            {
                if (entry.State == EntityState.Modified || entry.State == EntityState.Added)
                {
                    entry.CurrentValues.SetValues(new { ModifiedOn = DateTime.Now });
                }
            }

            return base.SaveChanges();
        }
    }
}