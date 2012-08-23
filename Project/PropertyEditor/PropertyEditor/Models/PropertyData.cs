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
                    Type = (int)property_type.integer_type,
                    Value = "800"
                },
                new Property
                {
                    Name = "height",
                    Type = (int)property_type.integer_type,
                    Value = "600"
                },
                new Property
                {
                    Name = "title",
                    Type = (int)property_type.string_type,
                    Value = "GuruPoint project"
                },
                new Property
                {
                    Name = "subtitle",
                    Type = (int)property_type.string_type,
                    Value = "Demo task"
                }
            }.ForEach(a => context.Properties.Add(a));
        }
    }
}