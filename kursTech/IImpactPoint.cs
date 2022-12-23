using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kursTech
{

    public abstract class IImpactPoint
    {
        public static int radius = 80;
        public int counter;
        public float X;
        public float Y;

        public abstract void ImpactParticle(Particle particle);
        public Color FromColor;
        public Color ToColor;
        public Color ColorFrom = Color.Gold;
        public Color ColorTo = Color.FromArgb(0, Color.Red);
        private int k;
        public int alpha;
        public void RenderCounterPoints(Graphics g)
        {

            if (counter < 2540)
            {
                k = counter / 10;
                alpha = (int)(k * 255);
            }
            else if (counter >= 2540 && counter < 25400)
            {
                k = counter / 100;
                alpha = (int)(k * 255);
            }
            else k = 255;


        var color = Color.FromArgb(k, Color.Green);

            var b = new SolidBrush(color);

            g.FillEllipse(b, X - radius / 2,
               Y - radius / 2,
               radius,
               radius);
            b.Dispose();

            g.DrawString(
            $"кол-во: {counter}",
            new Font("Verdana", 10),
            new SolidBrush(Color.White),
            X-40,
            Y-10
        );
        }

        public void RenderAntiPoints(Graphics g)
        {
            g.DrawEllipse(
                    new Pen(Color.Red),
                    X - radius / 2,
               Y - radius / 2,
               radius,
               radius
                );
        }

        public class CounterPoint : IImpactPoint
        {
            

            
            public override void ImpactParticle(Particle particle)
            {
                float gX = X - particle.X;
                float gY = Y - particle.Y;
                double r = Math.Sqrt(gX * gX + gY * gY);
                
                if (r + particle.Radius < radius / 2 + particle.Radius*2)
                {
                    particle.Life = 0;
                    counter++;
                    
                }
                    
            }

            
        }

        public class AntiPoint : IImpactPoint
        {
            public override void ImpactParticle(Particle particle)
            {
                float gX = X - particle.X;
                float gY = Y - particle.Y;
                double r = Math.Sqrt(gX * gX + gY * gY);

                if (r + particle.Radius < radius / 2 + particle.Radius * 2)
                {
                    float r2 = (float)Math.Max(100, gX * gX + gY * gY);
                    particle.SpeedX = 0;
                    particle.SpeedY = 0;
                    particle.SpeedX -= gX * (radius + 500) / r2;
                    particle.SpeedY -= gY * (radius + 500) / r2;
                }
            }
        }



    }
}
