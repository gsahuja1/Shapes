using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Shapes.Models;

namespace Shapes.Services.Helpers
{
   /// <summary>
   /// ShapeHelper class
   /// </summary>
   public abstract class ShapeHelper
   {
      private string[] _splitText;
      private string _pattern;

      public string[] SplitText{
         get { return _splitText; }
         set { _splitText = value; }
      }

      public string Pattern
      {
         get { return _pattern; }
         set { _pattern = value; }
      }

      /// <summary>
      /// Constrcutor
      /// </summary>
      /// <param name="splitText"> the text array used to split user input</param>
      /// <param name="pattern"> the shape matching pattern </param>
      protected ShapeHelper(string[] splitText, string pattern)
      {
         SplitText = splitText;
         Pattern = pattern;
      }

      public abstract Dictionary<ShapesModel.Shapes, Dictionary<string, long>> ValidateShape(string shapeText);
   }

   /// <summary>
   /// CircleHelper class
   /// </summary>
   public class CircleHelper : ShapeHelper
   {
      public CircleHelper(string[] splitText, string pattern): base(splitText, pattern)
      {
      }

      /// <summary>
      /// Validates circle request
      /// </summary>
      /// <param name="shapeText"> input circle string </param>
      /// <returns>
      /// valid request - returns Dictionary of shape and relevant parameters necessary to draw the shape
      /// Invalid request - returns null
      /// </returns>
      public override Dictionary<ShapesModel.Shapes, Dictionary<string, long>> ValidateShape(string shapeText)
      {
         if (!Regex.IsMatch(shapeText, Pattern, RegexOptions.IgnoreCase))
            return null; //invalid shape string

         //Split string using shape's matching pattern
         var radius = Convert.ToInt64(shapeText.ToLower().Split( SplitText , StringSplitOptions.RemoveEmptyEntries)[0]);

         Dictionary<ShapesModel.Shapes, Dictionary<string, long>> data = new Dictionary<ShapesModel.Shapes, Dictionary<string, long>>() { { ShapesModel.Shapes.Circle, new Dictionary<string, long>() { { "radius", radius } } } };

         return data;
      }
   }

   /// <summary>
   /// Rectangle Helper class
   /// </summary>
   public class RectangleHelper : ShapeHelper
   {
      public RectangleHelper(string[] splitText, string pattern)
         : base(splitText, pattern)
      {
      }

      /// <summary>
      /// Validates rectangle request
      /// </summary>
      /// <param name="shapeText"> the rectangle string </param>
      /// <returns>
      /// valid request - returns Dictionary of shape and relevant parameters necessary to draw the shape
      /// Invalid request - returns null
      /// </returns>
      public override Dictionary<ShapesModel.Shapes, Dictionary<string, long>> ValidateShape(string shapeText)
      {
         if (!Regex.IsMatch(shapeText, Pattern, RegexOptions.IgnoreCase))
            return null; //invalid shape string

         //Split string using shape's matching pattern
         var dimensions = shapeText.ToLower().Split(SplitText, StringSplitOptions.RemoveEmptyEntries);
         var width = Convert.ToInt64(dimensions[1]);
         var height = Convert.ToInt64(dimensions[2]);

         Dictionary<ShapesModel.Shapes, Dictionary<string, long>> data = new Dictionary<ShapesModel.Shapes, Dictionary<string, long>>() { { ShapesModel.Shapes.Rectangle, new Dictionary<string, long>() { { "width", width }, { "height", height } } } };

         return data;
      }
   }

   /// <summary>
   /// Isosceles Triangle helper
   /// </summary>
   public class IsoscelesTriangleHelper : ShapeHelper
   {
      public IsoscelesTriangleHelper(string[] splitText, string pattern)
         : base(splitText, pattern)
      {
      }

      /// <summary>
      /// Validates isosceles triangle request
      /// </summary>
      /// <param name="shapeText">shape string</param>
      /// <returns>
      /// valid request - returns Dictionary of shape and relevant parameters necessary to draw the shape
      /// Invalid request - returns null
      /// </returns>
      public override Dictionary<ShapesModel.Shapes, Dictionary<string, long>> ValidateShape(string shapeText)
      {
         if (!Regex.IsMatch(shapeText, Pattern, RegexOptions.IgnoreCase))
            return null; //invalid shape string

         //Split string using shape's matching pattern
         var dimensions = shapeText.ToLower().Split(SplitText, StringSplitOptions.RemoveEmptyEntries);
         var height = Convert.ToInt64(dimensions[1]);
         var width = Convert.ToInt64(dimensions[2]);

         Dictionary<ShapesModel.Shapes, Dictionary<string, long>> data = new Dictionary<ShapesModel.Shapes, Dictionary<string, long>>() { { ShapesModel.Shapes.IsoscelesTriangle, new Dictionary<string, long>() { { "width", width }, { "height", height } } } };

         return data;
      }
   }
}