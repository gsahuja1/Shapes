using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using Shapes.Models;

namespace Shapes
{
   //Generic shape helper
   public class ShapeService
   {
      private ShapeService _shapeService; //specific shapehelper
      public ShapeService(ShapesModel.Shapes shape)
      {
         _shapeService = null;

         //instantiate shapehelper with specific shapehelkper instance
         switch()
         _shapeService = new CircleService();
      }

      public ShapeService()
      {
         
      }

      //Validates user input and pull shape dimensions
      public virtual Dictionary<ShapesModel.Shapes,Dictionary<string, long>> ValidateShape(string shapeText)
      {
         var pattern = "^Draw (an|a) " + buildShapesSet() + " ";
         if (!Regex.IsMatch(shapeText, pattern, RegexOptions.IgnoreCase))
            return null;

         //pull out the shape and dimensions(there are pulled by shape specific class as it knows what exactly to look for)
         Match m = Regex.Match(shapeText, pattern, RegexOptions.IgnoreCase);
         var shape = ShapesModel.shapeText.SingleOrDefault(x => x.Value.ToLower() == m.Groups[2].ToString().ToLower()).Key;

         if (shape ==  ShapesModel.Shapes.Circle)
            _shapeService = new CircleService();
         else if (shape == ShapesModel.Shapes.Rectangle)
            _shapeService = new RectangleService();
         else if (shape == ShapesModel.Shapes.IsoscelesTriangle)
            _shapeService = new IsoscelesTriangleService();
         else
            return null;

         var innerShapeText = shapeText.Substring(m.Groups[0].Length);
         return _shapeService.ValidateShape(innerShapeText); //shape specific class validates itself
      }

      //Builds whole set of supported shapes string
      private string buildShapesSet()
      {
         string shapes = "";
         var shapeEnums = Enum.GetValues(typeof(ShapesModel.Shapes));
         for (int i = 0; i < ShapesModel.shapeText.Count; i++)
         {
            shapes += ShapesModel.shapeText.Values.ElementAt(i) + "|";
         }

         return "(" + shapes + ")";
      }
   }

   //The circle helper class
   public class CircleService : ShapeService
   {
      private string splitText = "with a radius of ";
      public override Dictionary<ShapesModel.Shapes, Dictionary<string, long>> ValidateShape(string shapeText)
      {
         var pattern = "^(with a radius of \\d*)$";
         if (!Regex.IsMatch(shapeText, pattern, RegexOptions.IgnoreCase))
             return null;

         var radius = Convert.ToInt64(shapeText.ToLower().Split(new string[]{splitText},StringSplitOptions.RemoveEmptyEntries)[0]);

         Dictionary<ShapesModel.Shapes, Dictionary<string, long>> data = new Dictionary<ShapesModel.Shapes,Dictionary<string, long>>()
         {{ShapesModel.Shapes.Circle, new Dictionary<string, long>(){{"radius", radius}}}};

         return data;
      }
   }

   //The Reactangle helper class
   public class RectangleService : ShapeService
   {
      private readonly string[] splitText = {"width of ","and a height of "};
      public override Dictionary<ShapesModel.Shapes, Dictionary<string, long>> ValidateShape(string shapeText)
      {
         var pattern = "^(with a width of \\d* and a height of \\d*)$";
         if (!Regex.IsMatch(shapeText, pattern, RegexOptions.IgnoreCase))
            return null;

         var dimensions = shapeText.ToLower().Split(splitText, StringSplitOptions.RemoveEmptyEntries);
         var width = Convert.ToInt64(dimensions[1]);
         var height = Convert.ToInt64(dimensions[2]);

         Dictionary<ShapesModel.Shapes, Dictionary<string, long>> data = new Dictionary<ShapesModel.Shapes, Dictionary<string, long>>() { { ShapesModel.Shapes.Rectangle, new Dictionary<string, long>() { { "width", width}, {"height", height} } } };

         return data;
      }
   }

   //The isosceles triangle helper class
   public class IsoscelesTriangleService : ShapeService
   {
      private readonly string[] splitText = { "height of ", "and a width of " };
      public override Dictionary<ShapesModel.Shapes, Dictionary<string, long>> ValidateShape(string shapeText)
      {
         var pattern = "^(with a height of \\d* and a width of \\d*)$";
         if (!Regex.IsMatch(shapeText, pattern, RegexOptions.IgnoreCase))
            return null;

         var dimensions = shapeText.ToLower().Split(splitText, StringSplitOptions.RemoveEmptyEntries);
         var height = Convert.ToInt64(dimensions[1]);
         var width = Convert.ToInt64(dimensions[2]);

         Dictionary<ShapesModel.Shapes, Dictionary<string, long>> data = new Dictionary<ShapesModel.Shapes, Dictionary<string, long>>() { { ShapesModel.Shapes.IsoscelesTriangle, new Dictionary<string, long>() { { "width", width }, { "height", height } } } };

         return data;
      }
   }
}