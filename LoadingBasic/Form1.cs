using System;
using System.Drawing;
using System.Windows.Forms;

namespace LoadingBasic
{
    public partial class Form1 : Form
    {
        Timer t = new Timer();

        double pbUnit;
        int pbWIDTH, pbHEIGHT, pbComplete;

        Bitmap bmp;
        Graphics g;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //get picboxPB dimension
            pbWIDTH = picboxPB.Width;
            pbHEIGHT = picboxPB.Height;

            pbUnit = pbWIDTH / 100.0;

            //pbComplete - This is equal to work completed in % [min = 0 max = 100]
            pbComplete = 0; //0 is the lowest number

            //create bitmap
            bmp = new Bitmap(pbWIDTH, pbHEIGHT);

            //timer
            t.Interval = 80;    //in millisecond
            t.Tick += new EventHandler(this.t_Tick);
            t.Start(); //the beginning of progress
        }

        private void t_Tick(object sender, EventArgs e)
        {
            //graphics
            g = Graphics.FromImage(bmp);

            //clear graphics
            g.Clear(Color.Transparent);

            //draw progressbar
            g.FillRectangle(Brushes.CornflowerBlue, new Rectangle(0, 0, (int)(pbComplete * pbUnit), pbHEIGHT)); //Progress bar color

            g.DrawString("Loading Assets...", new Font("Bahnschrift", pbHEIGHT / 3), Brushes.Black, new PointF(pbWIDTH / 20 - pbHEIGHT, pbHEIGHT / 5)); //Progress bar text

            //load bitmap in picturebox picboxPB
            picboxPB.Image = bmp;

            //To keep things simple I am adding +1 to pbComplete every 50ms
            pbComplete++;
            if (pbComplete > 100)
            {
                g.Dispose();
                t.Stop();
               // If you want the Form to change when completing the upload, you must place it in this part
            }
        }
    }
}
