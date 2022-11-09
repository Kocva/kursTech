using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursTech
{
    public abstract class IImpactPoint
    {
        public float X;
        public float Y;
        public float antiRadius = 80;

        public abstract void ImpactParticle(Particle particle);

        public void Render(Graphics g)
        {
            g.DrawEllipse(
                    new Pen(Color.Red),
                    X - antiRadius / 2,
                    Y - antiRadius / 2,
                    antiRadius,
                    antiRadius
                );
        }

        public class AntiPoint : IImpactPoint
        {
            public int Power = 150; // сила притяжения

            
            public override void ImpactParticle(Particle particle)
            {
                float gX = X - particle.X;
                float gY = Y - particle.Y;
                double r = Math.Sqrt(gX * gX + gY * gY);
                if (r + particle.Radius < Power / 2)
                {
                    float r2 = (float)Math.Max(100, gX * gX + gY * gY);

                    particle.SpeedX -= gX * Power / r2;
                    particle.SpeedY -= gY * Power / r2;
                }
                    
            }
        }
    }
}
