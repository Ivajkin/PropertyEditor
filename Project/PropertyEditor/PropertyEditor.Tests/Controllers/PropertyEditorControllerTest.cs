using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PropertyEditor;
using PropertyEditor.Controllers;
using PropertyEditor.Models;

namespace PropertyEditor.Tests.Controllers
{
    [TestClass]
    public class PropertyEditorControllerTest
    {
        [TestMethod]
        public void Index()
        {
            /*// Arrange
            PropertyEditorController controller = new PropertyEditorController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            //Assert.AreEqual("Welcome to ASP.NET MVC!", result.ViewBag.Message);*/
        }

        [TestMethod]
        public void Add()
        {
            // Arrange
            PropertyEditorController controller = new PropertyEditorController();

            // Act
            ViewResult result = controller.Add(new Property { Name = "TEST_PROPERTY", Type = (int)property_type.integer_type, Value = "128" }) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Delete()
        {
            /*// Arrange
            PropertyEditorController controller = new PropertyEditorController();

            // Act
            ViewResult result = controller.Add(new Property { Name = "TEST_PROPERTY2", Type = (int)property_type.string_type, Value = "test" }) as ViewResult;

            // Assert
            Assert.IsNotNull(result);

            // Act
            result = controller.Delete("TEST_PROPERTY2") as ViewResult;

            // Assert
            Assert.IsNotNull(result);*/
        }

        [TestMethod]
        public void Edit()
        {
            // Arrange
            PropertyEditorController controller = new PropertyEditorController();
            Property property = new Property { Name = "TEST_PROPERTY4", Type = (int)property_type.integer_type, Value = "500" };

            // Act
            ViewResult result = controller.Add(property) as ViewResult;

            // Assert
            Assert.IsNotNull(result);

            // Act
            result = controller.Edit(property) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
