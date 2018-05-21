using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shapes.Models;
using Shapes.Services;

namespace Shapes.Test.Shapes.Services.Test
{
   [TestClass]
   public class ShapeServiceTests
   {
      private IShapeService _shapeService;
      [TestInitialize]
      public void TestSetup()
      {
         _shapeService = new ShapeService();
      }

      #region Circle Tests

      [TestMethod]
      public void HandleShapeRequest_Valid_Circle_Test()
      {
         //Assign
         var circleRequest = "Draw a Circle with a radius of 100";

         //Act
         Dictionary<ShapesModel.Shapes, Dictionary<string, long>> actual = _shapeService.HandleShapeRequest(circleRequest);

         //Assert
         Assert.AreEqual(actual.Count, 1);
         Assert.AreEqual(actual.ContainsKey(ShapesModel.Shapes.Circle), true);
         Assert.AreEqual(actual.FirstOrDefault().Value.Keys.Contains("radius"), true);
         Assert.AreEqual(actual.FirstOrDefault().Value.Values.Contains(100), true);
      }

      [TestMethod]
      public void HandleShapeRequest_Valid_Case_Insensitive_Circle_Test()
      {
         //Assign
         var circleRequest = "drAW A CirclE with a radius of 100";

         //Act
         Dictionary<ShapesModel.Shapes, Dictionary<string, long>> actual = _shapeService.HandleShapeRequest(circleRequest);

         //Assert
         Assert.AreEqual(actual.Count, 1);
         Assert.AreEqual(actual.ContainsKey(ShapesModel.Shapes.Circle), true);
         Assert.AreEqual(actual.FirstOrDefault().Value.Keys.Contains("radius"), true);
         Assert.AreEqual(actual.FirstOrDefault().Value.Values.Contains(100), true);
      }

      [TestMethod]
      public void HandleShapeRequest_Invalid_Circle_Test_Returns_Null()
      {
         //Assign
         var circleRequest = "Draw a circle withh a radius of 100";

         //Act
         Dictionary<ShapesModel.Shapes, Dictionary<string, long>> actual = _shapeService.HandleShapeRequest(circleRequest);

         //Assert
         Assert.IsNull(actual);
      }

      #endregion

      #region Rectangle Tests

      [TestMethod]
      public void HandleShapeRequest_Valid_Rectangle_Test()
      {
         //Assign
         var shapeRequest = "Draw a rectangle with a width of 250 and a height of 100";
         long height = 0, width = 0;

         //Act
         Dictionary<ShapesModel.Shapes, Dictionary<string, long>> actual = _shapeService.HandleShapeRequest(shapeRequest);

         //Assert
         Assert.AreEqual(actual.Count, 1);
         Assert.AreEqual(actual.ContainsKey(ShapesModel.Shapes.Rectangle), true);

         actual.FirstOrDefault().Value.TryGetValue("height", out height);
         Assert.AreEqual(height, 100);

         actual.FirstOrDefault().Value.TryGetValue("width", out width);
         Assert.AreEqual(width, 250);
      }

      [TestMethod]
      public void HandleShapeRequest_Valid_Case_Insensitive_Rectangle_Test()
      {
         //Assign
         var shapeRequest = "DRAW a Rectangle with a Width of 250 and a height of 100";
         long height = 0, width = 0;

         //Act
         Dictionary<ShapesModel.Shapes, Dictionary<string, long>> actual = _shapeService.HandleShapeRequest(shapeRequest);

         //Assert
         Assert.AreEqual(actual.Count, 1);
         Assert.AreEqual(actual.ContainsKey(ShapesModel.Shapes.Rectangle), true);

         actual.FirstOrDefault().Value.TryGetValue("height", out height);
         Assert.AreEqual(height, 100);

         actual.FirstOrDefault().Value.TryGetValue("width", out width);
         Assert.AreEqual(width, 250);
      }

      [TestMethod]
      public void HandleShapeRequest_Invalid_Rectangle_Request_Returns_Null()
      {
         //Assign
         var shapeRequest = "Draw a rectangle with width as 250 and a length of 100";

         //Act
         Dictionary<ShapesModel.Shapes, Dictionary<string, long>> actual = _shapeService.HandleShapeRequest(shapeRequest);

         //Assert
         Assert.IsNull(actual);
      }

      #endregion

      #region Isosceles Triangle Tests

      [TestMethod]
      public void HandleShapeRequest_Valid_Isosceles_Triangle_Test()
      {
         //Assign
         var shapeRequest = "Draw an isosceles triangle with a height of 200 and a width of 100";
         long height = 0, width = 0;

         //Act
         Dictionary<ShapesModel.Shapes, Dictionary<string, long>> actual = _shapeService.HandleShapeRequest(shapeRequest);

         //Assert
         Assert.AreEqual(actual.Count, 1);
         Assert.AreEqual(actual.ContainsKey(ShapesModel.Shapes.IsoscelesTriangle), true);

         actual.FirstOrDefault().Value.TryGetValue("height", out height);
         Assert.AreEqual(height, 200);

         actual.FirstOrDefault().Value.TryGetValue("width", out width);
         Assert.AreEqual(width, 100);
      }

      [TestMethod]
      public void HandleShapeRequest_Valid_Case_Insensitive_Isosceles_Triangle_Test()
      {
         //Assign
         var shapeRequest = "DRAW an isosceles triangle with a height of 200 and a width of 100";
         long height = 0, width = 0;

         //Act
         Dictionary<ShapesModel.Shapes, Dictionary<string, long>> actual = _shapeService.HandleShapeRequest(shapeRequest);

         //Assert
         Assert.AreEqual(actual.Count, 1);
         Assert.AreEqual(actual.ContainsKey(ShapesModel.Shapes.IsoscelesTriangle), true);

         actual.FirstOrDefault().Value.TryGetValue("height", out height);
         Assert.AreEqual(height, 200);

         actual.FirstOrDefault().Value.TryGetValue("width", out width);
         Assert.AreEqual(width, 100);
      }

      [TestMethod]
      public void HandleShapeRequest_Invalid_Isosceles_Triangle_Request_Returns_Null()
      {
         //Assign
         var shapeRequest = "DRAW an isosceles triangle with a length of 200 and a width of 100";

         //Act
         Dictionary<ShapesModel.Shapes, Dictionary<string, long>> actual = _shapeService.HandleShapeRequest(shapeRequest);

         //Assert
         Assert.IsNull(actual);
      }

      #endregion
   }
}
