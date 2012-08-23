using System.Data.Entity;
using System.Collections.Generic;

namespace PropertyEditor.Models
{
    public class PropertyDBContext : DbContext
    {
        public DbSet<Property> Properties { get; set; }
    }
}