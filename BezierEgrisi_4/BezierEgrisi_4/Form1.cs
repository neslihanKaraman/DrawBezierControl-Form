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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        /// <summary>
        /// radio buton durumuna göre metot ve parametreleri belirledim
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCiz_Click(object sender, EventArgs e)
        {
             if(lineer.Checked==true)
             {
                myBezierCurve.MyDrawBezier(new Pen(Color.Black), Convert.ToSingle(numericUpDown_x1.Value), Convert.ToSingle(numericUpDown_y1.Value), Convert.ToSingle(numericUpDown_x2.Value), Convert.ToSingle(numericUpDown_y2.Value));
               
             }
             else if(quadratik.Checked==true)
             {
                myBezierCurve.MyDrawBezier(new Pen(Color.Red), Convert.ToSingle(numericUpDown_x1.Value), Convert.ToSingle(numericUpDown_y1.Value), Convert.ToSingle(numericUpDown_x2.Value), Convert.ToSingle(numericUpDown_y2.Value), Convert.ToSingle(numericUpDown_x3.Value), Convert.ToSingle(numericUpDown_y3.Value));
             }
             else if(cubic.Checked==true)
             {
                myBezierCurve.MyDrawBezier(new Pen(Color.Green), Convert.ToSingle(numericUpDown_x1.Value),Convert.ToSingle(numericUpDown_y1.Value),Convert.ToSingle(numericUpDown_x2.Value), Convert.ToSingle(numericUpDown_y2.Value), Convert.ToSingle(numericUpDown_x3.Value), Convert.ToSingle(numericUpDown_y3.Value), Convert.ToSingle(numericUpDown_x4.Value), Convert.ToSingle(numericUpDown_y4.Value));
             }
        }
        /// <summary>
        /// linner buton seçildiğinde diğer 4 giriş değerinin sayfada görünmesini engelledim.
        /// Çünkü linner denklem sistemi 4 girişi alan bir yapıya sahip.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lineer_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown_x3.Hide(); label_x3.Hide();
            numericUpDown_y3.Hide(); label_y3.Hide();
            numericUpDown_x4.Hide(); label_x4.Hide();
            numericUpDown_y4.Hide(); label_y4.Hide();

        }
        /// <summary>
        /// Quadratik buton seçildiğinde önceden gizlediğim giriş yerlerinin görünmesini ve 3 giriş alan bir yapının oluşmasını sağladım.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void quadratik_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown_x3.Show(); label_x3.Show();
            numericUpDown_y3.Show(); label_y3.Show();
            numericUpDown_x4.Hide(); label_x4.Hide();
            numericUpDown_y4.Hide(); label_y4.Hide();
        }
        /// <summary>
        /// cubic butonu seçildiğinde daha önce gizlemiş olduğum giriş kısımlarını tekrar görünür hale getirdim
        /// cubic denklemler 8 giriş aldığı için.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cubic_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown_x3.Show();  label_x3.Show();
            numericUpDown_y3.Show();  label_y3.Show();
            numericUpDown_x4.Show();  label_x4.Show();
            numericUpDown_y4.Show();  label_y4.Show();
        }
        /// <summary>
        /// Reset butonuna basılınca çizilen eğrinin ve girilen değerlerin silinmesini sağladım.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void reset_click(object sender, EventArgs e)
        { 
            numericUpDown_x1.Value = 0;  numericUpDown_y1.Value = 0;
            numericUpDown_x2.Value = 0;  numericUpDown_y2.Value = 0;
            numericUpDown_x3.Value = 0;  numericUpDown_y3.Value = 0;
            numericUpDown_x4.Value = 0;  numericUpDown_y4.Value = 0;
            myBezierCurve.Invalidate();
        }
    }
}
