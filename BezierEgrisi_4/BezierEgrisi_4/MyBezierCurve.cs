using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BezierEgrisi_4
{
    public partial class MyBezierCurve : Control
    {
        float a;
        public MyBezierCurve()
        {
            InitializeComponent();
            
        }
        /// <summary>
        /// Yazmış olduğum method için nesne üretip renk, kordinat noktaları ve kalınlık değerlerini properties pencerisinde kullanıcıdan alıp değer atadım.
        /// Doğruluğunun kontrolünü yapmak için Grafik sınıfının bezier methodundan yararlandım ve doğruluğunu kontrol ettim.
        /// </summary>
        /// <param name="pe"></param>
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            //Pen pen = new Pen(Color.Red,1);
            //pe.Graphics.DrawBezier(pen, 10,20,30,40,50,60,70,80);

        }
        /// <summary>
        /// kübik bir bezier eğrisi çizmek için belirlenen formülün denklemini kod olarak ifade ettim.
        /// yüzde birlik adımlarla nokta oluşturdum ve o noktaları birleştirip eğriyi elde ettim.
        /// daha sonra hafızada yer kaplamaması için dispose kullanarak nesneyi sildim.
        /// </summary>
        /// <param name="pen"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="x3"></param>
        /// <param name="y3"></param>
        /// <param name="x4"></param>
        /// <param name="y4"></param>
        /// 
        public void MyDrawBezier(Pen pen, float x1, float y1, float x2, float y2, float x3, float y3, float x4, float y4)
        {
            float t = 0F;
            float u = 1 - t;
            Graphics g = this.CreateGraphics();
            a = 0.001f;
            float baslangıc_x1 = Convert.ToSingle(Math.Pow(u, 3) * x1 + 3 * Math.Pow(u, 2) * t * x2 + 3 * u * Math.Pow(t, 2) * x3 + Math.Pow(t, 3) * x4);
            float baslangıc_y1 = Convert.ToSingle(Math.Pow(u, 3) * y1 + 3 * Math.Pow(u, 2) * t * y2 + 3 * u * Math.Pow(t, 2) * y3 + Math.Pow(t, 3) * y4);

            for (t = 0.001F; t <= 1.0F;  t += a)
            {
                u = 1 - t;

                float bx2 = Convert.ToSingle(Math.Pow(u, 3) * x1 + 3 * Math.Pow(u, 2) * t * x2 + 3 * u * Math.Pow(t, 2) * x3 + Math.Pow(t, 3) * x4);
                float by2 = Convert.ToSingle(Math.Pow(u, 3) * y1 + 3 * Math.Pow(u, 2) * t * y2 + 3 * u * Math.Pow(t, 2) * y3 + Math.Pow(t, 3) * y4);

                g.DrawLine(pen,baslangıc_x1,  baslangıc_y1, bx2,  + by2);

                baslangıc_x1 = bx2;
                baslangıc_y1 = by2;
            }            
            pen.Dispose();            
        }

        /// <summary>
        /// MyDrawBezier metodunu aşırı yükleyerek kuadratik denklemler için geçerli olan denklem sistemini ifade ettim
        /// </summary>
        /// <param name="pen"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="x3"></param>
        /// <param name="y3"></param>
        public void MyDrawBezier(Pen pen, float x1, float y1, float x2, float y2, float x3, float y3)
        {
            float t = 0F;
            float u = 1 - t;
            Graphics g = this.CreateGraphics();
            a = 0.001F;
            float baslangıc_x1 = Convert.ToSingle(Math.Pow(u, 2) * x1 + 2 * t * u * x2 + Math.Pow(t, 2) * x3);
            float baslangıc_y1 = Convert.ToSingle(Math.Pow(u, 2) * y1 + 2 * t * u * y2 + Math.Pow(t, 2) * y3);
            for (t = 0.001F; t <= 1.0F; t += a)
            {
                u = 1 - t;

                float ax2 = Convert.ToSingle(Math.Pow(u, 2) * x1 + 2 * t * u * x2 + Math.Pow(t, 2) * x3);
                float ay2 = Convert.ToSingle(Math.Pow(u, 2) * y1 + 2 * t * u * y2 + Math.Pow(t, 2) * y3);

                g.DrawLine(pen, baslangıc_x1, baslangıc_y1, ax2, ay2);

                baslangıc_x1 = ax2;
                baslangıc_y1 = ay2;
            }
            pen.Dispose();
        }

        /// <summary>
        /// MyDrawBezier metodunu aşırı yükleyerek linner denklemler için geçerli olan denklem sistemini ifade ettim
        /// </summary>
        /// <param name="pen"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        public void MyDrawBezier(Pen pen, float x1, float y1, float x2, float y2)
        {
            float t = 0F;
            float u = 1 - t;
            Graphics g = this.CreateGraphics();
            a = 0.001F;
            float baslangıc_x1 = Convert.ToSingle(x1 * u + x2 * t);
            float baslangıc_y1 = Convert.ToSingle(y1 * u + y2 * t);

            for (t = 0.001F; t <= 1.0F; t += a)
            {
                u = 1 - t;

                float cx2 = Convert.ToSingle(x1 * u + x2 * t);
                float cy2 = Convert.ToSingle(y1 * u + y2 * t);

                g.DrawLine(pen, + baslangıc_x1,  baslangıc_y1,  + cx2,  + cy2);

                baslangıc_x1 = cx2;
                baslangıc_y1 = cy2;
            }
            pen.Dispose();
        }        
    }
}
