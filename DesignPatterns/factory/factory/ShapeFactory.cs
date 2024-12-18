using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace factory
{
    public class ShapeFactory
    {
        public IShape shape;
        public ShapeFactory()
        {
        }
        public void drawfigure(string shape)
        {
            switch (shape)
            {
                case "Circle":
                    var circle = new Circle();
                    circle.draw();
                    break;
                case "Square": 
                    var square = new Square();
                    square.draw();
                    break;
            }
        }
    }
}
