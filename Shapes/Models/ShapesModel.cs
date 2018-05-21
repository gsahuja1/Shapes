using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shapes.Models
{
   public static class ShapesModel
   {
      public enum Shapes
      {
         Circle,
         Rectangle,
         Square,
         Triangle,
         IsoscelesTriangle,

         Invalid
      };

      //Dictionary of supported shapes text
      public static Dictionary<Shapes, string> shapeText = new Dictionary<Shapes, string>()
      {
         {Shapes.Circle, "Circle"},
         {Shapes.Rectangle, "Rectangle"},
         {Shapes.Square, "Square"},
         {Shapes.IsoscelesTriangle, "Isosceles Triangle"}
      };
   }
}