using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MathExtended;

namespace MatrixEquasions
{
    public partial class TestConsole : Form
    {
        public TestConsole()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            richTextBox2.Text = "";
            string path = @"C:\Users\patdu\Desktop\ntd.txt";
            using (StreamReader reader = new StreamReader(path))
            {
                List<bool> eguals = new List<bool>();
                string inside;
                while (reader.Peek() != -1)
                {
                    inside = reader.ReadLine();

                    double value = Convert.ToDouble(inside);

                    double valueComb = 0;
                    foreach (char item in inside)
                    {
                        int i = Convert.ToInt32(new string(item, 1));
                        valueComb += Silnia(Convert.ToDouble(new string(item, 1)));
                    }

                    if (value == valueComb)
                    {
                        richTextBox1.Text += "equals\n";
                        eguals.Add(true);
                    }
                    else 
                    {
                        richTextBox1.Text += " not equals\n";
                        eguals.Add(false);
                    }

                    richTextBox2.Text += value.ToString() + " -> "+ valueComb.ToString() + '\n';

                }
            }
        }

        private double Silnia(double n)
        {
            if (n == 0) return 1;
            return n * Silnia(n-1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            IntervalsEquasion iq = new IntervalsEquasion();
            bool fe = iq.CheckIfValueIsNatural(-12.0);
        }
    }
}
