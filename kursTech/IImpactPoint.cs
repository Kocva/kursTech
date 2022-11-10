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
        public int Power = 80; // сила притяжения
        public float X;
        public float Y;
        public float antiRadius = 80;

        public abstract void ImpactParticle(Particle particle);

        public void Render(Graphics g)
        {
            g.DrawEllipse(
                    new Pen(Color.Red),
                    X - Power / 2,
               Y - Power / 2,
               Power,
               Power
                );
        }

        public class AntiPoint : IImpactPoint
        {
            

            
            public override void ImpactParticle(Particle particle)
            {
                float gX = X - particle.X;
                float gY = Y - particle.Y;
                double r = Math.Sqrt(gX * gX + gY * gY);
                
                if (r + particle.Radius < Power / 2 + particle.Radius*2)
                {
                    float r2 = (float)Math.Max(100, gX * gX + gY * gY);

                    particle.SpeedX -= gX * (Power+370) / r2;
                    particle.SpeedY -= gY * (Power+370) / r2;
                }
                    
            }
        }
    }
}
