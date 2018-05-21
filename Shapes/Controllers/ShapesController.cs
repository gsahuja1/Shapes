using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shapes.Models;
using System.Text.RegularExpressions;
using Shapes.Services;

namespace Shapes.Controllers
{
    public class ShapesController : Controller
    {
       private readonly IShapeService _shapeService;

       public ShapesController(IShapeService shapeService)
       {
          _shapeService = shapeService;
       }
       
 
        public ActionResult Index(string shapeText)
        {
           if(shapeText == "") //there should be something
              ViewData["Error"] = "Empty shape text";

           //Validate user input
           Dictionary<ShapesModel.Shapes, Dictionary<string, long>> dict = _shapeService.HandleShapeRequest(shapeText);
           if(dict == null) //user did not adhere to specified format
              ViewData["Error"] = "Could not interpret shape. Check input.";

           //we have a specific shape if we are here. Lets draw it now
           else if (dict.ContainsKey(ShapesModel.Shapes.Circle))
           {
              ViewData["shapeViewPath"] = "CircleView";
              ViewData["radius"] = dict.Values.FirstOrDefault().Values.FirstOrDefault();
           }
           else if (dict.ContainsKey(ShapesModel.Shapes.Rectangle))
           {
              ViewData["shapeViewPath"] = "RectangleView";
              var data = dict.Values.FirstOrDefault();
              long width, height;
              data.TryGetValue("width", out width);
              data.TryGetValue("height", out height);

              ViewData["width"] = width;
              ViewData["height"] = height;
           }
           else if (dict.ContainsKey(ShapesModel.Shapes.IsoscelesTriangle))
           {
              ViewData["shapeViewPath"] = "IsoscelesTriangleView";
              var data = dict.Values.FirstOrDefault();
              long width, height;
              data.TryGetValue("width", out width);
              data.TryGetValue("height", out height);

              ViewData["width"] = width;
              ViewData["height"] = height;
           } 

           return View();
        }
    }
}
