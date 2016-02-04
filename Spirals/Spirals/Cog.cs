using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;

namespace Spirals
{
    class Cog
    {
        private PointF position;

        private double radius;

        private RectangleF enclosingRectangle;

        private double angle;

        private double childAngle;  // moves quicker

        private int numberOfLoops = 0;


        Cog parentCog = null;
        Cog childCog;   // later??

        List<PointF> pointList;

        int loopLimit = 0;  

        System.Windows.Forms.TextBox output;

        //----------------------------------------------------------------------
        //
        // Constructor
        //
        //----------------------------------------------------------------------
        public Cog(double radius, PointF position, List<PointF> pointList, Cog parentCog, System.Windows.Forms.TextBox output)
        {
            this.radius = radius;

            this.position = position;

            this.pointList = pointList;

            this.output = output;

            ComputeEnclosingRectangle();

            this.angle = 0;
            this.childAngle = 0;
            
            this.parentCog = parentCog;

            CalculateLoopLimit();
        }


        public void CalculateLoopLimit()
        {

            if (parentCog == null)
            {
                // are we the root cog..
                List<int> radii = new List<int>();

                radii.Add((int)radius);

                Cog c = this;

                while (c.childCog != null)
                {
                    c = c.childCog;

                    radii.Add((int)c.radius);
                }


                // now we can try to calculate the loopLimit...

                loopLimit = 1;

                // lcm(a,b,c) = Lcm(lcm(a,b), c)
                // lcm(1, a) = a
                // lcm(a,b,c) = lcm(lcm(lcm(1,a),b), c);

                int lcm = 1;

                for (int i = 0; i < radii.Count; i++)
                {

                    lcm = MathX.LCM(lcm, radii[i]);



                }
                loopLimit = lcm / radii[0];   // maybe?

                // add code here to generate a string representation of the
                // analysis so we can dump it in the text box
                string s = string.Format("LCM {0}{1}Loop limit {2}{3}", lcm, Environment.NewLine,loopLimit, Environment.NewLine);
                output.Text = s;
            }
        }

        public double Radius
        {
            get { return radius; }
        }

        public PointF Position
        {
            get { return position; }

            set
            {

                position = value;

                ComputeEnclosingRectangle();

            }

        }

        public Cog ChildCog
        {
            get { return childCog; }
        }


        public int NumberOfLoops
        {
            get { return numberOfLoops; }
        }

        public void ComputeEnclosingRectangle()
        {
            enclosingRectangle = new RectangleF(position.X - (float)radius, position.Y - (float)radius, (float)(2 * radius), (float)(2 * radius));

        }

        public void AddChild(double newRadius)
        {
            if (childCog != null)
            {
                childAngle = angle;
                childCog.AddChild(newRadius);
            }
            else
            {

                double fullDistance = radius + newRadius;

                PointF newPosition = new PointF(position.X + (float)(fullDistance * Math.Cos(angle)), position.Y + (float)(fullDistance * Math.Sin(angle)));

                childCog = new Cog(newRadius, newPosition, pointList, this, output);
            }
            CalculateLoopLimit();
        }

        public void RemoveChild()
        {
            throw new NotImplementedException();
        }



        public void Rotate(double deltaAngle, double childAngleOnSurface)
        {
            angle = LimitAngle(angle + deltaAngle);

            if (childCog != null)
            {
                // need to work out the child position and rotate the child proportionally!!!
                double fullDistance = radius + childCog.Radius;

                // child rotates round parent but also turns through childAngleOnsurface
                double childDeltaAngle = radius * childAngleOnSurface / childCog.radius + childAngleOnSurface + deltaAngle;

                Debug.Assert(childDeltaAngle >= 0);

                if ((childAngle + deltaAngle + childAngleOnSurface) >= (2 * Math.PI))
                {
                    numberOfLoops++;
                }

                childAngle = LimitAngle(childAngle + deltaAngle + childAngleOnSurface);

                //output.Text = Environment.NewLine + Convert.ToString(childAngle);
                    //output.Text + Environment.NewLine + Convert.ToString(childAngle);
        
                // compute position
                PointF newPosition = new PointF(position.X + (float)(fullDistance * Math.Cos(childAngle)), position.Y + (float)(fullDistance * Math.Sin(childAngle)));
                childCog.Position = newPosition;

                // deal with rotation
                childCog.Rotate(childDeltaAngle, childDeltaAngle);
            }
            else
            {
                // terminal cog so store plot position...
                PointF plotPosition = new PointF(position.X + (float)(radius * Math.Cos(angle)), position.Y + (float)(radius * Math.Sin(angle)));
                pointList.Add(plotPosition);
            }

            //output.Text = output.Text + Environment.NewLine + Convert.ToString(numberOfLoops);

        }

        public bool CycleCompleted()
        {
            if (parentCog == null)
            {
                return (numberOfLoops >= loopLimit);
            }
            else
            {
                return false;
            }

        }

        public double LimitAngle(double angle)
        {
            if (angle >= 2 * Math.PI)
            {
                angle -= 2 * Math.PI;
                
            }
            if (angle <= 0)
            {
                angle += 2 * Math.PI;
            }
            return angle;

        }

        public void Draw(Graphics g)
        {
            Pen pen1 = new Pen(Color.Gray);


            g.DrawEllipse(pen1, enclosingRectangle);


            for (double theta = 0; theta < 2 * Math.PI; theta += Math.PI / 0.5)
            {

                PointF endPosition = new PointF(position.X + (float)(radius * Math.Cos(angle + theta)), position.Y + (float)(radius * Math.Sin(angle + theta)));

                g.DrawLine(pen1, position, endPosition);

                if (childCog != null)
                {
                    childCog.Draw(g);
                }
            }
        }
    }
}
