using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Point : Vector
    {
        private PointF A;
        
        public float X
        {
            get { return A.X; }
            set { A.X = value; }
        }

        public float Y
        {
            get { return A.Y; }
            set { A.Y = value; }
        
        }
        private PointF B;
        public float Xb
        {
            get { return B.X; }
            set { B.X = value; }
        }

        public float Yb
        {
            get { return B.Y; }
            set { B.Y = value; }

        }
    }
}
