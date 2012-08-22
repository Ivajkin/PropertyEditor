using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PropertyEditor.Models;
using PerpetuumSoft.Knockout;

namespace PropertyEditor.Controllers
{
    public class PropertyEditorController : Controller
    {
        public PropertyEditorController()
        {
            Properties.Add(new Property
            {
                Name = "width",
                Type = property_type.integer_type,
                Value = "800"
            });

            Properties.Add(new Property
            {
                Name = "height",
                Type = property_type.integer_type,
                Value = "600"
            });

            Properties.Add(new Property
            {
                Name = "title",
                Type = property_type.string_type,
                Value = "GuruPoint project"
            });

            Properties.Add(new Property
            {
                Name = "subtitle",
                Type = property_type.string_type,
                Value = "Demo task"
            });
        }

        // 
        // GET: /PropertyEditor/
        public ActionResult Index()
        {
            return View(Properties);
        }

        // 
        // GET: /PropertyEditor/AddPanel
        public ActionResult AddPanel()
        {
            return View();
        }

        // 
        // POST: /PropertyEditor/Add
        [HttpPost]
        public ActionResult Add(Property property)
        {
            Properties.Add(property);
            return View();
        }

        List<Property> Properties = new List<Property>();
    }
}
