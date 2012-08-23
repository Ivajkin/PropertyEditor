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
        private PropertyDBContext db = new PropertyDBContext();

        // 
        // GET: /PropertyEditor/
        public ActionResult Index()
        {
            var properties = db.Properties.ToList();
            return View(properties);
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
            db.Properties.Add(property);
            return View();
        }

    }
}
