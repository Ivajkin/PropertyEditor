using System.Data.Entity;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;

namespace PropertyEditor.Models
{
    public class PropertyDBContext : DbContext
    {
        public DbSet<Property> Properties { get; set; }
    }
}