//shapes view model
var ShapesViewModel = function() {
   self.userText = ko.observable('Draw an isosceles triangle with a height of 200 and a width of 100');

   self.drawShape = function() {
      window.location.href = '/Shapes?shapeText=' + self.userText();
      return;
   }
};