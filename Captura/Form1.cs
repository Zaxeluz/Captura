using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using Emgu.CV;
using Emgu.CV.Structure;

namespace Captura
{
    public partial class Form1 : Form
    {
        VideoCapture capture;

        public Form1()
        {
            InitializeComponent();
        }

        private void imagenToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(capture == null)
            {
                capture = new Emgu.CV.VideoCapture(0);
            }

            capture.ImageGrabbed += Capture_ImageGrabbed;
            capture.Start();
        }

        private void Capture_ImageGrabbed(object sender, EventArgs e)
        {
            try
            {
                Mat m = new Mat();
                capture.Retrieve(m);
                pictureBox1.Image = m.ToImage<Bgr, byte>().Bitmap;
            }
            catch (Exception)
            {

            }
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(capture != null)
            {
                capture.Stop();
            }
        }

        private void startToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Videos tipo | *.mp4";

            if(ofd.ShowDialog() == DialogResult.OK)
            {
                capture = new Emgu.CV.VideoCapture(ofd.FileName);
            }
            capture.ImageGrabbed += Capture_ImageGrabbed1;
            capture.Start();
        }

        private void Capture_ImageGrabbed1(object sender, EventArgs e)
        {
            try
            {
                Mat m = new Mat();
                capture.Retrieve(m);
                pictureBox1.Image = m.ToImage<Bgr, byte>().Bitmap;
                Thread.Sleep(1);
            }
            catch (Exception)
            {

            }
        }

        private void stopToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (capture != null)
            {
                capture.Stop();
            }
        }
    }
}
