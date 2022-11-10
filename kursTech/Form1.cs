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

namespace kursTech
{
    public partial class Form1 : Form
    {
        AntiPoint point1;

        public int MousePositionX = 0;
        public int MousePositionY = 0;

        Emitter emitter;

        public Form1()
        {
            InitializeComponent();
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);

            this.emitter = new Emitter
            {
                Direction = 0,
                Spreading = 360,
                SpeedMin = 4,
                SpeedMax = 4,
                ColorFrom = Color.Gold,
                ColorTo = Color.FromArgb(0, Color.Red),
                ParticlesPerTick = 10,
                X = 50,
                Y = 50

            };
            point1 = new AntiPoint
            {
                X = 590,
                Y = 200,
            };

            emitter.impactPoints.Add(point1);



        }

        

        private void timer1_Tick(object sender, EventArgs e)
        {
            emitter.UpdateState();
            
          
            using (var g = Graphics.FromImage(picDisplay.Image))
            {
                g.Clear(Color.Black);
                emitter.Render(g);
                
            }
            picDisplay.Invalidate();

        }

        private void picDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            
            
            MousePositionX = e.X;
            MousePositionY = e.Y;

            point1.X = e.X;
            point1.Y = e.Y;
        }
    }
}
