using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kursTech
{

    public abstract class IimpactPoint2
    {
        public static int Power = 80;
        public static int MousePower = 80;
        public static int MousePowerPlus = 500;
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

        public void RenderMouse(Graphics g)
        {
            g.DrawEllipse(
                    new Pen(Color.Red),
                    X - MousePower / 2,
               Y - MousePower / 2,
               MousePower,
               MousePower
                );
        }

        public class AntiPoint : IimpactPoint2
        {



            public override void ImpactParticle(Particle particle)
            {
                float gX = X - particle.X;
                float gY = Y - particle.Y;
                double r = Math.Sqrt(gX * gX + gY * gY);

                if (r + particle.Radius < Power / 2 + particle.Radius * 2)
                {
                    float r2 = (float)Math.Max(100, gX * gX + gY * gY);
                    particle.SpeedX = 0;
                    particle.SpeedY = 0;
                    particle.SpeedX -= gX * (Power + 500) / r2;
                    particle.SpeedY -= gY * (Power + 500) / r2;
                }

            }


        }

        public class MouseAntiPoint : IimpactPoint2
        {



            public override void ImpactParticle(Particle particle)
            {
                float gX = X - particle.X;
                float gY = Y - particle.Y;
                double r = Math.Sqrt(gX * gX + gY * gY);

                if (r + particle.Radius < MousePower / 2 + particle.Radius * 2)
                {
                    float r2 = (float)Math.Max(100, gX * gX + gY * gY);
                    particle.SpeedX = 0;
                    particle.SpeedY = 0;
                    particle.SpeedX -= gX * (MousePower + MousePowerPlus) / r2;
                    particle.SpeedY -= gY * (MousePower + MousePowerPlus) / r2;
                }

            }


        }

    }
}
