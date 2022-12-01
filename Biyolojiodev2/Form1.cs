using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biyolojiodev2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            bool kontrol = false;
            for (int i = 0; i < textBox1.Text.Length; i++)
            {
                if(textBox1.Text[i]<48 || textBox1.Text[i]>57)
                {
                    kontrol = true;
                }
            }



            int k_val = 0;
            string k = textBox1.Text;
            
            if (k == "")
            {
                string message = "Lutfen K degerini giriniz ( ornek K: 1)";
                string title = "uyari";
                MessageBox.Show(message, title);
            }
            else if(kontrol)
            {
                string message = "Lutfen K degerini dogru giriniz ( ornek K: 1)";
                string title = "uyari";
                MessageBox.Show(message, title);
            }
            else
            {
                k_val = int.Parse(k);
                if (k_val > 0)
                {
                    Form2 form2_ornek1 = new Form2(richTextBox1.Text, richTextBox2.Text, k_val);
                    form2_ornek1.Show();
                }
                else
                {
                    string message2 = "K degeri 0 dan buyuk olmali";
                    string title = "uyari";
                    MessageBox.Show(message2, title);
                }


            }



        }
    }
}
