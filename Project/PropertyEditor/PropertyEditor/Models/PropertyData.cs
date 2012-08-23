using System.Data.Entity;
using System.Collections.Generic;

namespace PropertyEditor.Models
{

    public class PropertyData : DropCreateDatabaseIfModelChanges<PropertyDBContext>
    {
        protected override void Seed(PropertyDBContext context)
        {

            new List<Property>
            {
                new Property
                {
                    Name = "width",
                    Type = property_type.integer_type,
                    Value = "800"
                },
                new Property
                {
                    Name = "height",
                    Type = property_type.integer_type,
                    Value = "600"
                },
                new Property
                {
                    Name = "title",
                    Type = property_type.string_type,
                    Value = "GuruPoint project"
                },
                new Property
                {
                    Name = "subtitle",
                    Type = property_type.string_type,
                    Value = "Demo task"
                }
            }.ForEach(a => context.Properties.Add(a));
        }
    }
}