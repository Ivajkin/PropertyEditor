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
        [Key]
        public string Name { get; set; }

        public int Type { get; set; }

        public string Value { get; set; }
    }
}