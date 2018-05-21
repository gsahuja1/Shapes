using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shapes.Models;

namespace Shapes.Services
{
   /// <summary>
   /// Shape service interface
   /// </summary>
   public interface IShapeService
   {
      /// <summary>
      /// Handles user's shape request.
      /// </summary>
      /// <param name="shapeRequest">the shape string</param>
      /// <returns>Dictionary of shape and relevant parameters necessary to draw the shape</returns>
      Dictionary<ShapesModel.Shapes, Dictionary<string, long>> HandleShapeRequest(string shapeRequest);
   }
}
