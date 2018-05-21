# Shapes
Shapes project to draw shapes

Created in VS2013 as Asp.net MVC app.

Design analogy:
As different shapes have different dimensions and associated keywords with those,
the validation of user input is handled by individual shape classes in conjunction 
with generic user input validation by base/generic class for Shapes i.e. 'ShapeHelper.
For example, the CircleHelper class knows it needs to look for 'radius' in user entered 
statement. Similarly, each shape has its own partial view to draw itself. So, adding 
support for new shape is just adding a new class for that shape which implements validation
rule for itself and adding a new partial view for the shape.
