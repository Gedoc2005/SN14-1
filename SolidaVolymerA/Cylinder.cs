using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidaVolymerA
{
    public class Cylinder : Solid
    {
        public override double BaseArea//todo implementera formler!
        {
            get { throw new NotImplementedException(); }
        }

        public override double SurfaceArea
        {
            get { throw new NotImplementedException(); }
        }

        public override double Volume
        {
            get { throw new NotImplementedException(); }
        }

        public Cylinder(double radius, double height)
            : base(radius, height)
        {

        }
    }
}
