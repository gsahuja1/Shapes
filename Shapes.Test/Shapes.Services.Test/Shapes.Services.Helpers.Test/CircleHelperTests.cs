using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shapes.Models;
using Shapes.Services.Helpers;

namespace Shapes.Test.Shapes.Services.Test.Shapes.Services.Helpers.Test
{
   [TestClass]
   public class CircleHelperTests
   {
      private ShapeHelper _shapeHelper;

      [TestInitialize]
      public void TestSetup()
      {
         _shapeHelper = new CircleHelper(new string[] { "with a radius of " }, "^(with a radius of \\d*)$");
      }
      
      [TestMethod]
      public void ValidateShape_Valid_Circle_Request()
      {
         //Assign
         string shapeText = "with a radius of 50";

         //Act
         Dictionary<ShapesModel.Shapes, Dictionary<string, long>>  actual = _shapeHelper.ValidateShape(shapeText);

         //Assert
         Assert.AreEqual(actual.Count, 1);
         Assert.AreEqual(actual.ContainsKey(ShapesModel.Shapes.Circle), true);
         Assert.AreEqual(actual.FirstOrDefault().Value.Keys.Contains("radius"), true);
         Assert.AreEqual(actual.FirstOrDefault().Value.Values.Contains(50), true);
      }

      [TestMethod]
      public void ValidateShape_Invalid_Circle_Request_Returns_Null()
      {
         //Assign
         string shapeText = "with a diameter of 100";

         //Act
         Dictionary<ShapesModel.Shapes, Dictionary<string, long>> actual = _shapeHelper.ValidateShape(shapeText);

         //Assert
         Assert.IsNull(actual);
      }
   }
}
