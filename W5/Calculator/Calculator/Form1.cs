using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        Brain brain;
        public Form1()
        {
            InitializeComponent();
            MyDelegate d = new MyDelegate(DisplayText);
            d += DisplayText2;
            brain = new Brain(d);
        }

        private void Btn_Clck(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            brain.Process(btn.Text);
        }



        void DisplayText(string msg)
        {
            textBox1.Text = msg;
        }

        void DisplayText2(string msg)
        {
            MessageBox.Show(msg);
        }
    }

}
