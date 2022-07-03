using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp22
{
    public class CACtor
    {
        public int XD, YD;
        public Bitmap im;
        public int XS, YS;
    }
    public class grwnd
    {
        public int x, y;
        public Bitmap im;
    }
    public class hblts
    {
        public int x, y;
        public Bitmap im;
    }
    public class boss
    {
        public int x, y;
        public Bitmap im;
    }
    public class fene
    {
        public int x, y;
        public Bitmap im;
    }
    public class spaceenemy
    {
        public int x, y;
        public Bitmap im;
    }
    public class sebllt
    {
        public int x, y;
        public Bitmap im;
    }
    public class grwndenm
    {
        public int x, y;
        public Bitmap im;
    }
    public class elevator
    {
        public int x, y,w,h;
    }
    public class twr
    {
        public int x, y;
        public Bitmap im;
    }
    public class hro
    {
        public int x, y;
        public Bitmap im;
    }
    public partial class Form1 : Form
    {
        List<CACtor> LActs = new List<CACtor>();
        List<hblts> hb = new List<hblts>();
        List<fene> fe = new List<fene>();
        List<boss> b = new List<boss>();
        List<sebllt> seb = new List<sebllt>();
        List<spaceenemy> se = new List<spaceenemy>();
        List<grwndenm> ge = new List<grwndenm>();
        List<grwnd> gr = new List<grwnd>();
        List<elevator> ee = new List<elevator>();
        List<twr> t = new List<twr>();
        List<hro> h = new List<hro>();
        Bitmap off;
        public int xh;
        public int gey;
        public int xlol = 0;
        public int ct = 0;
        public int mflg;
        public int bh =300;
        public string s;
        int ctj = 0;
        public int move;
        public Bitmap sebim = new Bitmap("ebullet.bmp");
        public Bitmap fenim = new Bitmap("fene.bmp");
        public Bitmap seim = new Bitmap("1.bmp");
        public Bitmap gim = new Bitmap("ground.bmp");
        public Bitmap bim = new Bitmap("boss.bmp");
        public Bitmap hbim = new Bitmap("hb.bmp");
        public Bitmap tim = new Bitmap("tower.bmp");
        public Bitmap geim = new Bitmap("ge.bmp");
        public Bitmap fr = new Bitmap("fire.bmp");
        public Bitmap hs = new Bitmap("hstand.bmp");
        public Bitmap hmr = new Bitmap("rmove.bmp");
        public Bitmap hml = new Bitmap("lmove.bmp");
        public Bitmap hj = new Bitmap("jump.bmp");
        Timer tt = new Timer();
        Bitmap myBK = new Bitmap("jungle.bmp");
        public Form1()
        {
            InitializeComponent();
            tt.Tick += Tt_Tick;
            tt.Start();
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            this.Load += Form1_Load;
            this.Paint += Form1_Paint;
            this.KeyDown += Form1_KeyDown;
            this.KeyUp += Form1_KeyUp;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            move = 0;
            mflg = 0;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {


            if (e.KeyCode == Keys.D)
            {
                LActs[0].XD -= 5;
                ctj = 0;
                move = 1;
                mflg = 1;
                h[0].x += 5;
            }

            if (h[0].x > 0)
            {
                if (e.KeyCode == Keys.A)
                {
                    LActs[0].XD += 5;
                    ctj = 0;
                    move = 1;
                    mflg = 2;
                    h[0].x -= 5;
                }
            }
            if (ctj == 0 || ctj == 1)
            {
                if (e.KeyCode == Keys.W)
                {
                    ctj++;
                    move = 1;
                    mflg =3;
                    h[0].y -= 50;
                }

                if (e.KeyCode == Keys.E)
                {
                    ctj++;
                    move = 1;
                    mflg = 3;
                    h[0].y -= 50;
                    h[0].x += 30;
                }

                if (e.KeyCode == Keys.Q)
                {
                    ctj++;
                    move = 1;
                    mflg = 3;
                    h[0].y -= 50;
                    h[0].x -= 30;
                }
            }
            if (e.KeyCode == Keys.S)
            {
                ctj = 0;
                move = 1;
                mflg = 3;
                h[0].y += 50;
            }
            if (e.KeyCode == Keys.Space)
            {
                move = 1;
                mflg = 4;
                hblts pnn = new hblts();
                pnn.x = h[0].x + h[0].im.Width + 6;
                pnn.y= h[0].y + h[0].im.Height /2;
                pnn.im = hbim;
               pnn.im.MakeTransparent(pnn.im.GetPixel(0, 0));
                hb.Add(pnn);
            }


        }

        private void Tt_Tick(object sender, EventArgs e)
        {
            ct++;
            s = "BOSS HEALth" + ":" + bh;
            for (int i = 0; i < gr.Count(); i++)
            {
                if (h[0].y + h[0].im.Height < gr[i].y  && h[0].x + h[0].im.Width > gr[i].x && h[0].x < gr[i].x + gr[i].im.Width)
                {
                    h[0].y += 5;
                    
                }
            }
            for (int i = 0; i < hb.Count; i++)
            {
                hb[i].x += 5;
            }
            for (int i = 0; i < hb.Count; i++)
            {
                if(hb[i].x > t[0].x && hb[i].x < t[0].x +t[0].im.Width)
                {
                    hb.RemoveAt(i);
                }
            }
            for (int i = 0; i < fe.Count(); i++)
            {
                if (fe[i].y > this.Height)
                {
                    fe[i].y = 0;
                }
            }
            for (int i = 0; i < fe.Count(); i++)
            {
                if (fe[i].y +fe[i].im.Height > h[0].y  && fe[i].y  < h[0].y  +h[0].im.Height  && h[0].x+h[0].im.Width > fe[i].x && h[0].x< fe[i].x + fe[i].im.Width)
                {
                    tt.Stop();
                }
            }
            for (int i=0;i<fe.Count();i++)
            {
                fe[i].y += 6;
            }
            if (se[0].x < 350 && se[0].y == 0)
            {
                se[0].x += 3;
                if (se[0].x >= 350)
                {
                    se[0].y = 1;
                }
            }
            if (se[0].x > 0 && se[0].y == 1)///////////////////////////////////enemey move
            {
                se[0].x -= 5;
                if (se[0].x <= 0)
                {
                    se[0].y = 0;
                }
            }
            ////////////////////////////////

            if (ge[0].x  <800 && ge[0].y == 678)
            {
                ge[0].x += 3;
                if (ge[0].x >= 800)
                {
                    ge[0].y = 677;
                }
            }
            if (ge[0].x > 435 && ge[0].y == 677)///////////////////////////////////enemey move
            {
                ge[0].x -= 5;
                if (ge[0].x  <= 435)
                {
                    ge[0].y =678;
                }
            }
            if(ge[0].x < h[0].x+h[0].im.Width && ge[0].x +ge[0].im.Width >h[0].x && h[0].y>= ge[0].y )
            {
                tt.Stop();
            }
            for (int i = 0; i < hb.Count; i++)
            {
                if (hb[i].x > b[0].x && hb[i].x < b[0].x + b[0].im.Width && hb[i].y >= b[0].y)
                {
                    bh -= 10;
                    hb.RemoveAt(i);
                }
            }
            if (bh==0)
            {
                tt.Stop();
            }
            ///////////////////////////////



            if (ct % 30 == 0)
            {
                Random RR = new Random();
                int r = RR.Next(10, 325);
                if (se[0].x >= r && r < se[0].x + se[0].im.Width)
                {
                    sebllt pnn = new sebllt();
                    pnn.x = se[0].x + se[0].im.Width /2;
                    pnn.y = se[0].y + se[0].im.Height + 2;
                    pnn.im = sebim;
                    pnn.im.MakeTransparent(pnn.im.GetPixel(0, 0));
                    seb.Add(pnn);
                }

            }
            for (int i = 0; i < seb.Count(); i++)
            {
                seb[i].y += 3;
            }
            for (int i = 0; i < seb.Count(); i++)
            {

                if (seb[i].x + seb[i].im.Width > h[0].x && h[0].x + h[0].im.Width > seb[i].x &&                 h[0].y < seb[i].y + seb[i].im.Height && h[0].y + h[0].im.Height > seb[i].y)
                {
                    tt.Stop();
                }
            }

            if (h[0].x < ee[0].x+ee[0].w && h[0].y <ee[0].y && ee[0].y >= 250)
                {
                  //  h[0].y = ee[0].y - 43 ;
                    ee[0].y -= 3;
                }
            if(ee[0].y<=250 && ee[0].x+ ee[0].w <= 300 && h[0].x < ee[0].x + ee[0].w && h[0].x +h[0].im.Width > ee[0].x && h[0].y < ee[0].y)
            {
                //h[0].y = ee[0].y - 43;
                ee[0].x += 2;
                //ee[0].y = t[1].y;
            }
            if ( h[0].x +h[0].im.Width > ee[0].x && h[0].x  < ee[0].x+ee[0].w && h[0].y < ee[0].y)
            {
                h[0].y = ee[0].y - 43;
            }

            for (int i = 0; i < gr.Count(); i++)
            {
                if (h[0].y + h[0].im.Height > gr[i].y && h[0].y < gr[i].y + gr[i].im.Height  && h[0].x+h[0].im.Width > gr[i].x && h[0].x < gr[i].x + gr[i].im.Width)
                {
                    h[0].y = gr[i].y - h[0].im.Height;
                }
            
            }
            for (int i = 0; i < t.Count(); i++)
            {
                if (h[0].x + h[0].im.Width > t[i].x && h[0].x < t[i].x + t[i].im.Width  )
                {
                    if (h[0].y > t[1].y || h[0].y > t[0].y)
                    {
                        h[0].x = t[i].x - h[0].im.Width;
                    }
                }
            }
            for (int i = 0; i < t.Count(); i++)
            {
                if (h[0].y + h[0].im.Height < t[i].y && h[0].x + h[0].im.Width > t[i].x && h[0].x < t[i].x + t[i].im.Width)
                {
                    h[0].y += 5;

                }
            }
            for (int i = 0; i < t.Count(); i++)
            {
                if (h[0].y + h[0].im.Height > t[1].y&& h[0].x +h[0].im.Width> t[1].x&& h[0].x < t[1].x + t[1].im.Width)
                {
                    h[0].y = t[1].y - h[0].im.Height;
                }
            }


            DrawDubb(CreateGraphics());
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawDubb(e.Graphics);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            off = new Bitmap(ClientSize.Width, ClientSize.Height);
            myBK.MakeTransparent(Color.White);
            off = new Bitmap(ClientSize.Width, ClientSize.Height);

            CACtor pnn = new CACtor();
            pnn.XD = 0;
            pnn.YD = 0;
            pnn.XS = 0;
            pnn.YS = 0;
            pnn.im = new Bitmap("jungle.bmp");
            LActs.Add(pnn);

            crtobj();
        }
        void crtobj()
        {

            for (; ; )
            {
                grwnd pnng = new grwnd();
                pnng.x = xlol;
                pnng.im = gim;
                pnng.im.MakeTransparent(pnng.im.GetPixel(0, 0));
                pnng.y = 729;
                gr.Add(pnng);
                xlol += pnng.im.Width - 2;
                if (pnng.x >= this.Width)
                {
                    break;
                }

            }
            grwnd pnn = new grwnd();
            pnn.x = 150;
            pnn.im = gim;
            pnn.im.MakeTransparent(pnn.im.GetPixel(0, 0));
            pnn.y = 600;
            gr.Add(pnn);
            pnn = new grwnd();
            pnn.x = 75;
            pnn.im = gim;
            pnn.im.MakeTransparent(pnn.im.GetPixel(0, 0));
            pnn.y = 500;
            gr.Add(pnn);
            pnn = new grwnd();
            pnn.x = 150;
            pnn.im = gim;
            pnn.im.MakeTransparent(pnn.im.GetPixel(0, 0));
            pnn.y = 400;
            gr.Add(pnn);

            ///////////////////////////////////////////////////////////////////////////////////////
            int yy = 400;
            for (int i = 0; i < 2; i++)
            {
                twr pnnt = new twr();
                pnnt.x = 325;
                pnnt.y = yy;
                pnnt.im = tim;
                pnnt.im.MakeTransparent(pnnt.im.GetPixel(0, 0));
                t.Add(pnnt);
                yy -= 200;
            }
            ///////////////////////////////////////////////////////

            elevator pnne = new elevator();
            pnne.x = 0;
            pnne.y = 350;
            pnne.w = 150;
            pnne.h = 20;
            ee.Add(pnne);
            ///////////////////////////////////////////////////////////////
            hro pnnh = new hro();
            pnnh.im = hs;
            pnnh.im.MakeTransparent(pnnh.im.GetPixel(0, 0));
            pnnh.x = pnnh.im.Width;
            pnnh.y = gr[0].y - pnnh.im.Height;
            //this.Text=   pnnh.im.Height.ToString() 
            h.Add(pnnh);
            ////////////////////////////////
            spaceenemy pnnse = new spaceenemy();
            pnnse.x = 0;
            pnnse.y = 0;
            pnnse.im = seim;
            pnnse.im.MakeTransparent(pnnse.im.GetPixel(0, 0));
            se.Add(pnnse);
            ////////////////////////////////
            grwndenm pnnem = new grwndenm();
            xh= t[0].x + t[0].im.Width + 20;
            pnnem.x = xh;
            pnnem.im = geim;
            pnnem.im.MakeTransparent(pnnem.im.GetPixel(0, 0));
            pnnem.y= gr[0].y - pnnem.im.Height;
            gey = pnnem.y;
            this.Text = gey.ToString();
            ge.Add(pnnem);
            fene pnnf = new fene();
            pnnf.x = xh+ 150;
            pnnf.y = 0;
            pnnf.im = fenim;
            fe.Add(pnnf);
            xh += 150;
            for(int i=0;i<4;i++)
            {
                 pnnf = new fene();
                pnnf.x = xh ;
                pnnf.y = 0;
                pnnf.im = fenim;
                pnnf.im.MakeTransparent(pnnf.im.GetPixel(0, 0));
                fe.Add(pnnf);
                xh += 150;
            }
            boss pnnb = new boss();
            pnnb.im = bim;
            pnnb.im.MakeTransparent(pnnb.im.GetPixel(0, 0));
            pnnb.x = this.Width - pnnb.im.Width;
            pnnb.y= gr[0].y - pnnb.im.Height;
            b.Add(pnnb);
        }
        void DrawDubb(Graphics g)
        {
            Graphics g2 = Graphics.FromImage(off);
            DrawScene(g2);
            g.DrawImage(off, 0, 0);
        }
        void DrawScene(Graphics g)
        {
            g.Clear(Color.White);
 
                Rectangle rcDest = new Rectangle(0, 0, myBK.Width, myBK.Height);
                Rectangle rcSrc = new Rectangle(0,0,myBK.Width , myBK.Height );
                g.DrawImage(myBK,rcDest, rcSrc,GraphicsUnit.Pixel);
            
            for (int i = 0; i < seb.Count(); i++)
            {
       
                g.DrawImage(seb[i].im, seb[i].x, seb[i].y);
            }
            for (int i = 0; i < fe.Count(); i++)
            {

                g.DrawImage(fe[i].im, fe[i].x, fe[i].y);
            }
            for (int i = 0; i < gr.Count(); i++)
            {
                g.DrawImage(gr[i].im, gr[i].x, gr[i].y);
            }

            for (int i = 0; i < t.Count(); i++)
            {
                g.DrawImage(t[i].im, t[i].x, t[i].y);
            }
            ///////////////////////////////////////////////////////////////
            g.FillRectangle(Brushes.Gray, ee[0].x, ee[0].y, ee[0].w, ee[0].h);
            Random RR = new Random();
            int r = RR.Next(1, 3);
            se[0].im = new Bitmap(r + ".bmp");
            se[0].im.MakeTransparent(se[0].im.GetPixel(0, 0));
            g.DrawImage(se[0].im, se[0].x, se[0].y);
            g.DrawImage(ge[0].im, ge[0].x, ge[0].y);
            g.DrawImage(b[0].im, b[0].x, b[0].y);
            if (move == 0 && mflg == 0)
            {
                h[0].im = hs;
                h[0].im.MakeTransparent(h[0].im.GetPixel(0, 0));
                g.DrawImage(h[0].im, h[0].x, h[0].y);
            }
            if (move == 1 && mflg == 1)
            {
                h[0].im = hmr;
                h[0].im.MakeTransparent(h[0].im.GetPixel(0, 0));
                g.DrawImage(h[0].im, h[0].x, h[0].y);
            }
            if (move == 1 && mflg == 2)
            {
                h[0].im = hml;
                h[0].im.MakeTransparent(h[0].im.GetPixel(0, 0));
                g.DrawImage(h[0].im, h[0].x, h[0].y);
            }
            if (move == 1 && mflg == 3)
            {
                h[0].im = hj;
                h[0].im.MakeTransparent(h[0].im.GetPixel(0, 0));
                g.DrawImage(h[0].im, h[0].x, h[0].y);
            }
            if (move == 1 && mflg == 4)
            {
                h[0].im = fr;
                h[0].im.MakeTransparent(h[0].im.GetPixel(0, 0));
                g.DrawImage(h[0].im, h[0].x, h[0].y);
            }
            if (move == 3)
            {
                h[0].im = hj;
                h[0].im.MakeTransparent(h[0].im.GetPixel(0, 0));            
                g.DrawImage(h[0].im, h[0].x, h[0].y);
            }
            for (int i = 0; i < hb.Count; i++)
            {
                g.DrawImage(hb[i].im, hb[i].x, hb[i].y);
            }
            Font drawFont = new Font("Arial", 16);
            SolidBrush drawBrush = new SolidBrush(Color.Red);
            g.DrawString(s, drawFont , drawBrush,this.Width-300, 0);
            // g.FillEllipse(Brushes.Red, this.Width / 2, this.Height / 2, 20, 200);
        }

    }
}
