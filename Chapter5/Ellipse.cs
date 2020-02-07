using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capitulo1.Chapter5
{
    public class ReactangleF
    {
        public int height { get; set; }
        public int width { get; set; }
        public int xPosition;
        public int yPosition;

        public ReactangleF(int xPosition, int yPosition, int height, int weight)
        {
            this.xPosition = xPosition;
            this.yPosition = yPosition;
            this.height = height;
            this.width = weight;
        }
    }

    class Ellipse
    {
        public ReactangleF reactangleF { get; set; }

        public Ellipse(ReactangleF reactangleF)
        {
            if (reactangleF.width <= 0)
            {
                throw new ArgumentOutOfRangeException("width", "Ellipse width must to be greater than 0.");
            }

            if (reactangleF.height <= 0)
            {
                throw new ArgumentOutOfRangeException("height", "Ellipse height must to be greater than 0.");
            }
            this.reactangleF = reactangleF;
        }

        public Ellipse(int xPosition, int yPosition, int height, int width): this(new ReactangleF(xPosition, yPosition, height, width))
        {

        }

    }

    class Circle: Ellipse
    {
        public Circle(ReactangleF reactangleF) : base(reactangleF)
        {
            if (reactangleF.width != reactangleF.height)
            {
                throw new ArgumentOutOfRangeException("widht height", "The width and height must to have the same value");
            }

        }

        public Circle(int xPosition, int yPosition, int height, int width) :  this(new ReactangleF(xPosition, yPosition, height, width))
        {

        }
    }

    
}
