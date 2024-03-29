﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using NcLibrary;

namespace WinNcCopy
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            label1.Text = "";

            timer1.Start();
            timer1.Tick += LoadEvent;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnDraw_Click(object sender, EventArgs e)
        {

            string pathfile;
            decimal Xmax, Ymax,max,scale;

            openFileDialogLoad.Filter = "G-code file (*.nc)|*.nc";
            
            openFileDialogLoad.ShowDialog();

            pathfile = openFileDialogLoad.FileName;
           
            Gcode gcode = new Gcode();
            
            //set scale
            gcode.SetCadres(GcodeIO.Load(pathfile));
            Xmax = gcode.GetMaxX();
            Ymax = gcode.GetMaxY();
            max = Xmax > Ymax ? Xmax : Ymax;
            scale = (500 / max)*0.9M;

            //MessageBox.Show(openFileDialog1.FileName);

            Draws(pathfile,scale);

            label1.Text = "file " + openFileDialogLoad.SafeFileName + " is load";

            Session.Instance.SetOriginal(gcode.GetCadres());
        }

        public void LoadEvent(object sender, EventArgs e)
        {
           // label1.Text = "Load";

            

           // Draws();
        }

        public void DrawLinePB()
        {

        }

        public void Draws(string pathFile, decimal scale)
        {
    
            DrawShapes d = new DrawShapes(pb2DGrafics.CreateGraphics());
       
            pb2DGrafics.Size = d.SetViewport(700, 500);
            d.SetScale(scale);
            d.Axis();
            

            GcodeDraw draw = new GcodeDraw();

            draw.SetCadres(GcodeIO.Load(pathFile));

            d.SetShapes(draw.GetShapes());
            d.Shapes();
          

        }

        public void DrawsString(List<string> program, decimal scale)
        {

            DrawShapes d = new DrawShapes(pb2DGrafics.CreateGraphics());

            pb2DGrafics.Size = d.SetViewport(700, 500);
            d.SetScale(scale);
            d.Axis();


            GcodeDraw draw = new GcodeDraw();

            draw.SetCadres(program);

            d.SetShapes(draw.GetShapes());
            d.Shapes();


        }


        public void btnCopyApply_Click(object sender, EventArgs e)
        {
            decimal Xmax, Ymax, max, scale;

            int x = (int)numByX.Value;
            int y = (int)numByY.Value;
            int offset = (int)numOffset.Value;

            Instantiation inst = new Instantiation();
            Session.Instance.SetModified(inst.CreateCopyXY(Session.Instance.GetOriginal(),x,y,offset));

            Gcode gcode = new Gcode();

            gcode.SetCadres(Session.Instance.GetModified());
            Xmax = gcode.GetMaxX();
            Ymax = gcode.GetMaxY();
            max = Xmax > Ymax ? Xmax : Ymax;
            scale = (500 / max) * 0.9M;

            DrawsString(Session.Instance.GetModified(),scale);
           
        }
    }
}
