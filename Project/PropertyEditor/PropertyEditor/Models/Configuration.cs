using System.Data.Entity.Migrations;

namespace Core.Persistence
{
    public class Configuration : DbMigrationsConfiguration<PropertyEditor.Models.PropertyDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }
    }
}