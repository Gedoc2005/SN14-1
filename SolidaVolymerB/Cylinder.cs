﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidaVolymerB
{
    public class Cylinder : Solid
    {
        //Implementera egenskaperna för att returnera värdet, med en cylinders respektive formler:
        public override double BaseArea
        {
            get { return Math.PI * RadiusSquared; }
        }
        public override double SurfaceArea
        {
            get { return 2 * Math.PI * Radius * (Height + Radius); }
        }
        public override double Volume
        {
            get { return Math.PI * RadiusSquared * Height; }
        }

        public Cylinder(double radius, double height)
            : base(radius, height) { }
    }
}
