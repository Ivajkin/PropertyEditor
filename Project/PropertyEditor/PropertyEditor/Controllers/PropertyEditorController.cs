﻿using System;
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
        // 
        // GET: /PropertyEditor/
        public ActionResult Index()
        {
            return View(new Property
            {
                Name = "width",
                Type = property_type.integer_type,
                Value = "800"
            });
        }
        // 
        // GET: /PropertyEditor/AddProperty
        public ActionResult AddProperty()
        {
            return View(new Property
            {
                Name = "width",
                Type = property_type.integer_type,
                Value = "800"
            });
        }

    }
}
