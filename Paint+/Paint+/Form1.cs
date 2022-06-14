using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint_
{
    public partial class Form1 : Form
    {
        Graphics g;
        int x = -1;
        int y = -1;
        bool moving = false;
        Pen pen;
        int mode = 0;
        string mode2 = "Default";
        int x2 = 0;
        int y2 = 0;
        bool beg = true;

        void prcs_vis(bool state)
        {
            label3.Visible = state;
            label4.Visible = state;
            textBox1.Visible = state;
            textBox2.Visible = state;
            button17.Visible = state;
        }
        void button_modes()
        {
            button12.Enabled = true;
            button13.Enabled = true;
            button16.Enabled = true;
        }

        void buttons()
        {
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
            button10.Enabled = true;
            button11.Enabled = true;
        }

        public Form1()
        {
            InitializeComponent();
            g = panel1.CreateGraphics();
            pen = new Pen(Color.Black, 5);
            mode = 0;
            button7.Enabled = false;            
            button14.Enabled = false;
            button16.Enabled = false;            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (mode == 0)
            {
                moving = true;
                x = e.X;
                y = e.Y;
            }
            else if (mode == 1 && mode2 == "Default")
            {
                if (beg == true)
                {
                    beg = false;
                    x2 = e.X;
                    y2 = e.Y;
                }
                else
                {
                    beg = true;
                    g.DrawLine(pen, new Point(x2, y2), e.Location);
                }
            }
            else if (mode == 2 && mode2 == "Default")
            {
                if (beg == true)
                {
                    beg = false;
                    x2 = e.X;
                    y2 = e.Y;
                }
                else
                {
                    beg = true;
                    g.DrawLine(pen, new Point(x2, y2), new Point(x2,e.Y));
                    g.DrawLine(pen, new Point(x2, y2), new Point(e.X, y2));
                    g.DrawLine(pen, new Point(x2, e.Y), new Point(e.X, e.Y));
                    g.DrawLine(pen, new Point(e.X, y2), new Point(e.X, e.Y));
                }
            }
            else if (mode == 1 && mode2 == "Precise")
            {
                x2 = e.X;
                y2 = e.Y;
                button17.Enabled = true;
            }
            else if (mode == 2 && mode2 == "Precise")
            {
                x2 = e.X;
                y2 = e.Y;
                button17.Enabled = true;
            }

        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mode == 0)
            {
                if (moving && x != -1 && y != -1)
                {
                    g.DrawLine(pen, new Point(x, y), e.Location);
                    x = e.X;
                    y = e.Y;
                }
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            if (mode == 0)
            {
                moving = false;
                x = -1;
                y = -1;
            }           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            buttons();
            pen.Color = Color.Red;
            button6.Enabled = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            buttons();
            pen.Color = Color.Orange;
            button5.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            buttons();
            pen.Color = Color.Yellow;
            button4.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            buttons();
            pen.Color = Color.Lime;
            button3.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            buttons();
            pen.Color = Color.Cyan;
            button2.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            buttons();
            pen.Color = Color.Blue;
            button1.Enabled = false;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            buttons();
            pen.Color = Color.Fuchsia;
            button11.Enabled = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            buttons();
            pen.Color = Color.Silver;
            button9.Enabled = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            buttons();
            pen.Color = Color.Gray;
            button8.Enabled = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            buttons();
            pen.Color = Color.Black;
            button7.Enabled = false;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            buttons();
            pen.Color = Color.White;
            button10.Enabled = false;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            pen.Width = trackBar1.Value;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {
            button_modes();
            mode = 0;
            button16.Enabled = false;
            button14.Enabled = false;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            button_modes();
            mode = 2;
            button12.Enabled = false;
            button14.Enabled = true;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            button_modes();
            mode = 1;
            button13.Enabled = false;
            button14.Enabled = true;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if(mode2 == "Default" && mode!= 0)
            {
                mode2 = "Precise";
                label6.Text = "Mode: " + mode2;
                prcs_vis(true);
                button17.Enabled = false;
            }
            else if (mode2 == "Precise" && mode != 0)
            {
                mode2 = "Default";
                label6.Text = "Mode: " + mode2;
                prcs_vis(false);
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (mode == 1 && mode2 == "Precise")
            {
                g.DrawLine(pen, new Point(x2, y2), new Point(x2+Convert.ToInt32(textBox1.Text), y2-Convert.ToInt32(textBox2.Text)));
            }
            else if (mode == 2 && mode2 == "Precise")
            {
                g.DrawLine(pen, new Point(x2, y2), new Point(x2, y2 - Convert.ToInt32(textBox2.Text)));
                g.DrawLine(pen, new Point(x2, y2), new Point(x2 + Convert.ToInt32(textBox1.Text), y2));
                g.DrawLine(pen, new Point(x2, y2 - Convert.ToInt32(textBox2.Text)), new Point(x2 + Convert.ToInt32(textBox1.Text), y2 - Convert.ToInt32(textBox2.Text)));
                g.DrawLine(pen, new Point(x2 + Convert.ToInt32(textBox1.Text), y2), new Point(x2 + Convert.ToInt32(textBox1.Text), y2 - Convert.ToInt32(textBox2.Text)));
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (button15.Text == "i")
            {
                label5.Visible = true;
                button15.Text = "x";
            }
            else if (button15.Text == "x")
            {
                label5.Visible = false;
                button15.Text = "i";
            }
        }
    }
}