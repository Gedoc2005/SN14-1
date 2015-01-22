using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidaVolymerA
{
    public class CircularCone : Solid
    {
        public override double BaseArea//todo här ska jag nog inserta formler!
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

        public CircularCone(double radius, double height)
            : base(radius, height)
        {

        }
    }
}
