using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PropertyEditor;
using PropertyEditor.Controllers;

namespace PropertyEditor.Tests.Controllers
{
    [TestClass]
    public class PropertyEditorControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            PropertyEditorController controller = new PropertyEditorController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
           // Assert.AreEqual("Welcome to ASP.NET MVC!", result.ViewBag.Message);
        }

        [TestMethod]
        public void AddPanel()
        {
            // Arrange
            PropertyEditorController controller = new PropertyEditorController();

            // Act
            ViewResult result = controller.AddPanel() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Add()
        {
            // Arrange
            PropertyEditorController controller = new PropertyEditorController();

            // Act
            ViewResult result = controller.Add(new PropertyEditor.Models.Property()) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
