using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shapes.Models;
using System.Text.RegularExpressions;

namespace Shapes.Controllers
{
    public class ShapesController : Controller
    {
       private readonly ShapeHelper _shapeHelper = new ShapeHelper();
        // GET: Shapes
        public ActionResult Index(string shapeText)
        {
           if(shapeText == "")
              ViewData["Error"] = "Empty shape text";

           _shapeHelper.ValidateShape(shapeText);
          // parseText(shapeText);
           return View();
        }

       private ShapesModel.Shapes parseText(string shapeText)
       {
          var pattern = "^Draw (an|a) " + buildShapesSet();
          if(!Regex.IsMatch(shapeText, pattern, RegexOptions.IgnoreCase))
             return ShapesModel.Shapes.Invalid;

          Match m = Regex.Match(shapeText, pattern);
          var shape = m.Groups[2];
          ShapeHelper _helper = new CircleHelper();



         // var shape = shapeText.Substring(m.Groups[0].Length, shapeText.)
          var isValid =  Regex.IsMatch(shapeText, pattern);
          if(!isValid)
             return ShapesModel.Shapes.Invalid;

          //shapeText.Split( )
          return ShapesModel.Shapes.Invalid;
       }

       private string buildShapesSet()
       {
          string shapes = "";
          var shapeEnums = Enum.GetValues(typeof(ShapesModel.Shapes));
          for(int i = 0; i < shapeEnums.Length; i++)
          {
             shapes += shapeEnums.GetValue(i) + "|";
          }

          return "(" + shapes + ")";
       }
    }
}
