using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Shapes.Models;
using Shapes.Services;
using Shapes.Services.Helpers;

namespace Shapes
{
   /// <summary>
   /// ShapeService class
   /// </summary>
   public class ShapeService : IShapeService
   {
      /// <summary>
      /// ShapeHelper object
      /// </summary>
      private ShapeHelper _shapeHelper;

      /// <summary>
      /// Handles user's shape request.
      /// </summary>
      /// <param name="shapeRequest">the shape string</param>
      /// <returns>Dictionary of shape and relevant parameters necessary to draw the shape</returns>
      public Dictionary<ShapesModel.Shapes, Dictionary<string, long>> HandleShapeRequest(string shapeRequest)
      {
         //Build supported shapes string and parse the user request
         var pattern = "^Draw (an|a) " + buildShapesSet() + " ";
         if (!Regex.IsMatch(shapeRequest, pattern, RegexOptions.IgnoreCase))
            return null; //invalid request

         //pull out the shape and dimensions(there are pulled by shape specific class as it knows what exactly to look for)
         Match m = Regex.Match(shapeRequest, pattern, RegexOptions.IgnoreCase);
         var shape = ShapesModel.shapeText.SingleOrDefault(x => x.Value.ToLower() == m.Groups[2].ToString().ToLower()).Key;

         if (shape == ShapesModel.Shapes.Circle)
            _shapeHelper = new CircleHelper(new string[]{"with a radius of "}, "^(with a radius of \\d*)$");
         else if (shape == ShapesModel.Shapes.Rectangle)
            _shapeHelper = new RectangleHelper(new string[]{"width of ","and a height of "}, "^(with a width of \\d* and a height of \\d*)$");
         else if (shape == ShapesModel.Shapes.IsoscelesTriangle)
            _shapeHelper = new IsoscelesTriangleHelper(new string[]{ "height of ", "and a width of " }, "^(with a height of \\d* and a width of \\d*)$");
         else
            return null; //unsupported shape

         //Pass on the request to respective shape helper
         var innerShapeText = shapeRequest.Substring(m.Groups[0].Length);
         return _shapeHelper.ValidateShape(innerShapeText); //shape specific class validates itself
      }
      
     
      /// <summary>
      /// Builds whole set of supported shapes string
      /// </summary>
      /// <returns> supported shapes delimited by "|" </returns>
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
}