﻿using System;
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

       

        public int MousePositionX = 0;
        public int MousePositionY = 0;

        Emitter emitter;

        public Form1()
        {
            InitializeComponent();
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);
            this.emitter = new Emitter
            {
                Direction = 45,
                Spreading = 10,
                SpeedMin = 5,
                SpeedMax = 5,
                ColorFrom = Color.Gold,
                ColorTo = Color.FromArgb(0, Color.Red),
                ParticlesPerTick = 10,
                X = 200,
                Y = 50

            };


            

            

            


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



        private int countOfClicks = 0;
        private void picDisplay_MouseClick(object sender, MouseEventArgs e)
        {
            emitter.impactPoints.Add(new CounterPoint
            {
                X = e.X,
                Y = e.Y,
            }
            );

        }

        private void picDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            MousePositionX = e.X;
            MousePositionY = e.Y;

            
        }
    }
}
