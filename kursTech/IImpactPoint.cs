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

        public void Render(Graphics g)
        {
            g.DrawEllipse(
                    new Pen(Color.Red),
                    X - radius / 2,
               Y - radius / 2,
               radius,
               radius
                );
            g.DrawString(
            $"кол-во: {counter}", // надпись, можно перенос строки вставлять (если вы Катя, то может не работать и надо использовать \r\n)
            new Font("Verdana", 10), // шрифт и его размер
            new SolidBrush(Color.White), // цвет шрифта
            X, // расположение в пространстве
            Y
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

    }
}
