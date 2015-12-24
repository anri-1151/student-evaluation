using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types; 


namespace IBSU
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            init();
        }
       
        private string[] rootDirectories;
        private void init()
        {
            rootDirectories = new String[1];
            rootDirectories[0] = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
                Form5 f5 = new Form5();
                this.Hide();
                f5.Show();
                Label saxeli = new Label();
                saxeli.Show();
                saxeli.Parent = f5;
                saxeli.Location = new Point(20, 50);
                saxeli.Text = "Name and Surname";
                saxeli.Font = new Font("Micrososoft San Serif", 12);
                saxeli.AutoSize = true;
                TextBox saxeli1 = new TextBox();
                saxeli.Show();
                saxeli1.Location = new Point(240, 50);
                saxeli1.Parent = f5;
                saxeli1.Size = new Size(185, 40);
               // int y = 50;
                Label stnumber = new Label();
                stnumber.Show();
                stnumber.Parent = f5;
                stnumber.Text = "Student Number";
                stnumber.Font = new Font("Micrososoft San Serif", 12);
                stnumber.AutoSize = true;
                stnumber.Location = new Point(20, 80);
                TextBox stnumber1 = new TextBox();
                stnumber1.Show();
                stnumber1.Parent = f5;
                stnumber1.Size = new Size(185, 40);
                stnumber1.Location = new Point(240, 80);
                int y = 80;
                Label label1 = new Label();
                label1.Show();
                label1.Parent = f5;
                label1.Location = new Point(240, 0);
                label1.AutoSize = true;
                label1.Text = "Enter the\nPoints";
                label1.Font = new Font("Micrososoft San Serif", 12);
                Label label2 = new Label();
                label2.Show();
                label2.Parent = f5;
                label2.Location = new Point(335, 0);
                label2.AutoSize = true;
                label2.Text = "Enter the\nPercent %";
                label2.Font = new Font("Micrososoft San Serif", 12);
                int cnt = 0;
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    if (checkedListBox1.GetItemChecked(i))
                        cnt++;
                }
                Label[] lbl = new Label[cnt];
                TextBox[] txt1 = new TextBox[cnt];
                TextBox[] txt2 = new TextBox[cnt];
                Button button2 = new Button();
                button2.Parent = f5;
                button2.AutoSize = true;
                button2.Location = new Point(107, 400);
                button2.Visible = false;
                Button button3 = new Button();
                button3.Parent = f5;
                button3.AutoSize = true;
                button3.Location = new Point(195, 400);
                button3.Visible = false;
                Button btn = new Button();
                btn.Show();
                btn.Parent = f5;
                btn.Location = new Point(20, 400);
                btn.Text = "Calculate";
                btn.Font = new Font("Micrososoft San Serif", 12);
                btn.AutoSize = true;
                Button again = new Button();
                again.Location = new Point(880, 20);
                again.Text = "Enter the next\nStudent's Scores";
                again.Font = new Font("Micrososoft San Serif", 10);
                again.AutoSize = true; again.Parent = f5;
                Label label3 = new Label();
                label3.Parent = f5; label3.Visible = false;
                int cnt1 = 0;
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    if (checkedListBox1.GetItemChecked(i))
                    {


                        string str = (string)checkedListBox1.Items[i];
                        if (str != (string)checkedListBox1.Items[6] && str != (string)checkedListBox1.Items[5])
                        {
                            y += 30;
                            lbl[cnt1] = new Label();
                            lbl[cnt1].Show();
                            lbl[cnt1].Parent = f5;
                            lbl[cnt1].AutoSize = true;
                            lbl[cnt1].Location = new Point(20, y);
                            lbl[cnt1].Text = str;
                            lbl[cnt1].Font = new Font("Micrososoft San Serif", 12);
                            txt1[cnt1] = new TextBox();
                            txt1[cnt1].Show();
                            txt1[cnt1].Parent = f5;
                            txt1[cnt1].Size = new Size(41, 20);
                            txt1[cnt1].Location = new Point(240, y);
                            txt2[cnt1] = new TextBox();
                            txt2[cnt1].Show();
                            txt2[cnt1].Parent = f5;
                            txt2[cnt1].Size = new Size(41, 20);
                            txt2[cnt1].Location = new Point(335, y);
                            y += 20;
                            cnt1++;
                        }
                        if (str == (string)checkedListBox1.Items[6])
                        {


                            button3.Show();
                            button3.Visible = true;
                            button3.Text = "Enter\nHomeworks";
                            button3.Font = new Font("Micrososoft San Serif", 12);

                        }
                        if (str == (string)checkedListBox1.Items[5])
                        {

                            button2.Show();
                            button2.Visible = true;
                            button2.Text = "Enter\nQuizs";
                            button2.Font=new Font("Micrososoft San Serif", 12);
                                
                        }


                    }
                }



                int x = 0; double jamiqvizi = 0;
                double[] a = new double[50];
                double pqvizebi = 0;

                button2.Click += (sender1, Args) =>
                    {
                        Form quiz = new Form();
                        quiz.Size = new Size(362, 288);
                        quiz.Show();
                        quiz.Text = "Enter the score of Quizzes";
                        quiz.MinimumSize = new Size(0, 0);
                        quiz.MaximumSize = new Size(362, 288);
                        DataGridView monacemebi = new DataGridView();
                        monacemebi.Show();
                        monacemebi.Parent = quiz;
                        monacemebi.Location = new Point(10, 10);
                        monacemebi.Size = new Size(165, 150);
                        monacemebi.AutoGenerateColumns = false;
                        DataGridViewColumn column = new DataGridViewTextBoxColumn();
                        column.DataPropertyName = "Enter the score\nof Quizzes";
                        column.Name = "Enter the Quiz's scores";
                        column.Width = 265;
                        monacemebi.Columns.Add(column);
                        Button gilaki = new Button();
                        gilaki.Show(); gilaki.Parent = quiz; gilaki.AutoSize = true;
                        gilaki.Location = new Point(20, 200);
                        gilaki.Text = "Calculate";
                        Label plbl = new Label(); plbl.Show(); plbl.Parent = quiz; plbl.AutoSize = true;
                        plbl.Location = new Point(200, 20);
                        plbl.Text = "Enter the\nPercent %";
                        plbl.Font = new Font("Micrososoft San Serif", 9);
                        TextBox ptxt = new TextBox();
                        ptxt.Show(); ptxt.Parent = quiz; ptxt.AutoSize = true;
                        ptxt.Location = new Point(200, 50);
                        gilaki.Click += (sender5, args) =>
                            {
                                pqvizebi = Convert.ToDouble(ptxt.Text);
                                for (int i = 0; i < monacemebi.Rows.Count - 1; i++)
                                {
                                    a[i] = Convert.ToDouble(monacemebi.Rows[i].Cells[0].Value.ToString());
                                    jamiqvizi += a[i];
                                    x++;
                                }
                                quiz.Close();
                            };
                    };





                int z = 0; double jamidavalebebi = 0;
                double[] b = new double[50];
                double pdavalebebi = 0;
                button3.Click += (sender2, Args) =>
                    {
                        Form davaleba = new Form();
                        davaleba.Size = new Size(362, 288);
                        davaleba.Show();
                        davaleba.MaximumSize = new Size(362, 288);
                        davaleba.MinimumSize = new Size(0, 0);
                        davaleba.Text = "Enter Homeworks";
                        DataGridView monacemebi = new DataGridView();
                        monacemebi.Show();
                        monacemebi.Parent = davaleba;
                        monacemebi.Location = new Point(10, 10);
                        monacemebi.Size = new Size(165, 150);
                        monacemebi.AutoGenerateColumns = false;
                        DataGridViewColumn column = new DataGridViewTextBoxColumn();
                        column.DataPropertyName = "Enter the score of Homeworks";
                        column.Name = "Enter the score of Homeworks";
                        column.Width = 165;
                        monacemebi.Columns.Add(column);
                        Button gilaki = new Button();
                        gilaki.Show(); gilaki.Parent = davaleba; gilaki.AutoSize = true;
                        gilaki.Location = new Point(20, 200);
                        gilaki.Text = "Calculate";
                        Label plbl = new Label(); plbl.Show(); plbl.Parent = davaleba; plbl.AutoSize = true;
                        plbl.Location = new Point(200, 20);
                        plbl.Text = "Enter the\nPercent %";
                        plbl.Font = new Font("Micrososoft San Serif", 9);
                        TextBox ptxt = new TextBox();
                        ptxt.Show(); ptxt.Parent = davaleba; ptxt.AutoSize = true;
                        ptxt.Location = new Point(200, 50);
                        gilaki.Click += (sender5, args) =>
                            {
                                pdavalebebi = Convert.ToDouble(ptxt.Text);
                                for (int i = 0; i < monacemebi.Rows.Count - 1; i++)
                                {
                                    b[i] = Convert.ToDouble(monacemebi.Rows[i].Cells[0].Value.ToString());
                                    jamidavalebebi += b[i];
                                    z++;
                                }
                                davaleba.Close();
                            };


                    };
                btn.Click += (sender3, Args) =>
                {


                    double jami = 0; double h = 0; double h1 = 0;
                    double[] a1 = new double[cnt1];
                    double[] a2 = new double[cnt1];
                    for (int i = 0; i < cnt1 - 1; i++)
                        a1[i] = Convert.ToDouble(txt1[i].Text);
                    for (int i = 0; i < cnt1 - 1; i++)
                        a2[i] = Convert.ToDouble(txt2[i].Text);
                    for (int i = 0; i < cnt1 - 1; i++)
                        jami += a1[i] * a2[i] / 100;
                    double final; double pfinal; double x1 = 0; double x2 = 0;
                    final = Convert.ToDouble(txt1[cnt1 - 1].Text);
                    pfinal = Convert.ToDouble(txt2[cnt1 - 1].Text);
                    string s = saxeli1.Text;
                    if (x != 0)
                    {
                        h = jamiqvizi / x;
                        h = h * pqvizebi / 100;
                    }
                    if (z != 0)
                    {
                        h1 = jamidavalebebi / z;
                        h1 = h1 * pdavalebebi / 100;
                    }
                    jami = jami + h1 + h;
                    jami = jami / 0.6;
                    jami = Math.Round(jami);
                    double saboloo = jami * 0.6 + final * pfinal / 100;
                    saboloo = Math.Round(saboloo);
                    label3.Visible = true;
                    label3.Location = new Point(20, 480);
                    label3.Text = x1.ToString() + " " + x2.ToString() + " " + jami.ToString();
                    label3.Text = s + "\nMidterm - " + jami.ToString() + " Final - " + final.ToString() + " Cross Grade - " + saboloo.ToString();
                    label3.AutoSize = true;
                    label3.Font = new Font("Micrososoft San Serif", 12);
                 
                    string chasaweri = s + "  Midterm - " + jami.ToString() + " Final - " + final.ToString() + " Cross Grade - " + saboloo.ToString();
                    string misamarti = rootDirectories[0] + "//The Score Of Students.txt";
                    if (File.Exists(misamarti) == false)
                    {

                        FileStream outfile = new FileStream(misamarti, FileMode.Create, FileAccess.Write);
                        StreamWriter writer = new StreamWriter(outfile);
                        writer.WriteLine(chasaweri);
                        writer.Close();
                        outfile.Close();
                    }
                    else
                    {
                        FileStream outfile = new FileStream(misamarti, FileMode.Append, FileAccess.Write);
                        StreamWriter writer = new StreamWriter(outfile);
                        writer.WriteLine(chasaweri);
                        writer.Close();
                        outfile.Close();
                    }

                    string oradb = "Data Source=localhost;User Id=sis;Password=oraxe;";
                    OracleConnection conn = new OracleConnection(oradb);  
                    conn.Open();
                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "update students set midterm=" + jami.ToString() + ", final=" + final.ToString() + ",cross_grade=" + saboloo.ToString() + "where st_id='" + stnumber1.Text + "'";
                    int rowsUpdated = cmd.ExecuteNonQuery();
                    if (rowsUpdated == 0)
                        MessageBox.Show("Record not inserted");
                    else
                        MessageBox.Show("Success!"); 
                    conn.Dispose();

                  
                   


                };
               again.Click+=(sender4, Args)=>
            {
                label3.Text = "";
                label3.Visible = false;
                for (int i = 0; i < cnt1 - 1; i++)
                {   

                    txt1[i].Text = "";
                    txt2[i].Text="";

                }
                txt1[cnt1 - 1].Text = "";
                txt2[cnt1 - 1].Text = "";
                saxeli1.Text = "";
                stnumber1.Text = "";
                for (int i = 0; i < 50; i++)
                    a[i] = 0;
                for (int i = 0; i < 50; i++)
                    b[i] = 0;
                pdavalebebi = 0;
                pqvizebi = 0;
            };
                
            }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

      
     }
  }

