using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static kursTech.IImpactPoint;
using static kursTech.Emitter;

namespace kursTech
{
    public partial class Form1 : Form
    {
        List<Emitter> emitters = new List<Emitter>();
        public int MousePositionX = 0;
        public int MousePositionY = 0;
        Emitter emitter1;
        Emitter emitter2;
        Emitter emitter3;
        Emitter emitter4;
        

        
        

        public Form1()
        {

            InitializeComponent();
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);
            emitter1 = new Emitter
            {
                Direction = 30,
                Spreading = 10,
                SpeedMin = 20,
                SpeedMax = 21,
                ColorFrom = Color.Gold,
                ColorTo = Color.FromArgb(0, Color.Red),
                ParticlesPerTick = 10,
                X = 100,
                Y = 50
        };

            emitter2 = new Emitter
            {
                Direction = 160,
                Spreading = 10,
                SpeedMin = 20,
                SpeedMax = 21,
                ColorFrom = Color.Red,
                ColorTo = Color.FromArgb(0, Color.Purple),
                ParticlesPerTick = 10,
                X = 1200,
                Y = 50

            };
            emitter3 = new Emitter
            {
                Direction = 45,
                Spreading = 10,
                SpeedMin = 24,
                SpeedMax = 25,
                ColorFrom = Color.Blue,
                ColorTo = Color.FromArgb(0, Color.White),
                ParticlesPerTick = 10,
                X = 100,
                Y = 500

            };
            emitter4 = new Emitter
            {
                Direction = 135,
                Spreading = 10,
                SpeedMin = 24,
                SpeedMax = 25,
                ColorFrom = Color.Black,
                ColorTo = Color.FromArgb(0, Color.White),
                ParticlesPerTick = 10,
                X = 1200,
                Y = 500

            };
            point2 = new AntiPoint
            {
                X = 450,
                Y = 150,
            };

            emitter.impactPoints.Add(point2);

            point3 = new AntiPoint
            {
                X = 260,
                Y = 240,
            };

            emitter.impactPoints.Add(point3);
            emitters.Add(emitter1);
            emitters.Add(emitter2);
            emitters.Add(emitter3);
            emitters.Add(emitter4);

        }

        

        private void timer1_Tick(object sender, EventArgs e)
        {

            foreach (var emitter in emitters)
            {
                emitter.UpdateState();
            }

                using (var g = Graphics.FromImage(picDisplay.Image))
                {
                    g.Clear(Color.Black);
                    emitter1.Render(g);
                emitter2.Render(g);
                emitter3.Render(g);
                emitter4.Render(g);
            }
                picDisplay.Invalidate();
            
            

        }



        private void picDisplay_MouseClick(object sender, MouseEventArgs e)
        {
            foreach (var emitter in emitters)
            {
                if (e.Button == MouseButtons.Left)
                {
                    emitter.impactPoints.Add(new CounterPoint
                    {
                        X = e.X,
                        Y = e.Y,
                    }
                );
                    emitter.countOfClicks+= 1;
                }
                else if (e.Button == MouseButtons.Right)
                {
                    emitter.impactPoints.RemoveAt(emitter.countOfClicks - 1);
                    emitter.countOfClicks-= 1;
                }
            }
              
            

        }

        private void picDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            MousePositionX = e.X;
            MousePositionY = e.Y;

            
        }
    }
}
