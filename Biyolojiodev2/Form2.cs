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
    public partial class Form2 : Form
    {
        int query_lenght, target_lenght, k_val;
        string query, target;

        public Form2(string query, string target, int k_val)
        {
            InitializeComponent();
            this.query = query; this.target = target; this.k_val = k_val;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            query_lenght = query.Length; target_lenght = target.Length;
            dataGridView1.ColumnCount = query_lenght + 2;
            dataGridView1.RowCount = target_lenght + 1;

            //TARGET IN TABLODA YAZILMASI
            for (int i = 0; i < query_lenght; i++)
            {
                dataGridView1.Columns[1].Name = "j";
                dataGridView1.Columns[i + 2].Name = (i + 1).ToString();
                for (int j = 0; j < target_lenght; j++)
                {
                    dataGridView1.Rows[j + 1].Cells[1].Value = target[j];
                }
            }

            //QUERY NİN TABLODA YAZILMASI
            for (int i = 0; i < target_lenght; i++)
            {
                dataGridView1.Rows[0].Cells[0].Value = "i";
                dataGridView1.Rows[i + 1].Cells[0].Value = i + 1;
                for (int j = 0; j < query_lenght; j++)
                {
                    dataGridView1.Rows[0].Cells[j + 2].Value = query[j];

                }

            }



            for (int i = 0; i < target_lenght; i++)
            {
                for (int j = 0; j < query_lenght; j++)
                {
                    if (target[i] == query[j])
                    {

                        dataGridView1.Rows[i + 1].Cells[j + 2].Value = "*";

                    }
                }
            }






            int kontrol = 0;
            int kontrol2 = 0;
            for (int i = 0; i < target_lenght; i++)
            {

                for (int j = 0; j < query_lenght; j++)
                {

                    // suan icinde bulundugumuz 2 for dongusuyle bütün hücrelere tek tek bakıyoruz 

                    int r = 0;
                    if (target[i] == query[j])
                    {

                        kontrol = 1;
                        int i1 = i, i2 = i; int j1 = j;
                        int kontrol_target = target_lenght - i; int kontrol_query = query_lenght - j;
                        int min = Math.Min(kontrol_query, kontrol_target);

                        //target ve query arasında esitlik buldugumuzda "aynı sırada" baska esitlikler de var mı diye 
                        //asagıdaki for dongusunde bakıyoruz ve bu for dongusu min kadar donuyor 

                        //Random rnd = new Random();
                        Color random_color;
                        for (int q = 0; q < min; q++)
                        {

    
                            if (i2 == target_lenght - 1 || j1 == query_lenght - 1)
                            {
                                break;
                            }


                            if (target[i2 + 1] == query[j1 + 1])
                            {
                                kontrol += 1;
                              
                            }
                            else
                            {
                                break;
                            }
                            i2 += 1; j1 += 1;


                        }



                        if (kontrol >= k_val)
                            kontrol2 += 1;
                        Color[] color_array = new Color[kontrol2];
                        Random rnd;

                        for (int s = 0; s < kontrol2; s++)
                        {
                            rnd = new Random();
                            random_color = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                            color_array[s] = random_color;

                        }

                        int kontrol3 = 0;
                        if (kontrol >= k_val)
                        {
                            kontrol3 += 1;

                            dataGridView1.Rows[i + 1].Cells[j + 2].Style.BackColor = Color.Green;//color_array[r++];
                            dataGridView1.Rows[i + 1].Cells[j + 2].Value += "1";
                            

                        }
                        else
                        {

                            if(dataGridView1.Rows[i].Cells[j + 1].Style.BackColor == Color.Green)
                            {
                                dataGridView1.Rows[i + 1].Cells[j + 2].Style.BackColor = Color.Green;//color_array[r++];
                            }
                        }

                      


                    }

                    

                }
            }

            
        }
    }
}
