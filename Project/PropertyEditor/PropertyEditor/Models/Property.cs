using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PropertyEditor.Models
{
    public class Property
    {
        //[Required]
        //[StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        //[DataType(DataType.Text)]
        [Key]
        public string Name { get; set; }

        public property_type Type { get; set; }

        //[Required]
        //[StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        //[DataType(DataType.Text)]
        public string Value { get; set; }

        public static string TypeString(property_type type)
        {
            return type == property_type.integer_type ? "integer" : "string";
        }
    }
}