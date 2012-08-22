using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;

namespace PropertyEditor.Models
{
    public enum property_type
    {
        string_type,
        integer_type
    }
    public class Property
    {
        public string Name { get; set; }
        public property_type Type { get; set; }
        public string Value { get; set; }

        public Expression<Func<string>> TypeString()
        {
            return () => (Type == property_type.integer_type ? "integer" : "string");
        }
    }
}