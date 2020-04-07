using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Szakdolgozat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            intezmeny intezmeny = new intezmeny();
            this.Hide();
            intezmeny.Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            csoportok csoportok = new csoportok();
            this.Hide();
            csoportok.Show();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Refresh();

            string sql2 = "SELECT * FROM intezmeny";
            using (var cmd2 = new MySqlCommand(sql2, Program.conn))
            {
                MySqlDataReader rdr2 = cmd2.ExecuteReader();
                while (rdr2.Read())
                {
                    intNevTextBox.Text = rdr2.GetString(0);
                    telephelyekTextBox.Text = rdr2.GetString(3);
                    csoportokSzamaTextBox.Text = rdr2.GetInt32(2).ToString();
                    intCimTextBox.Text = rdr2.GetString(1);
                }
            }
            if (intNevTextBox.Text == "" || telephelyekTextBox.Text == "" || csoportokSzamaTextBox.Text == "" || intCimTextBox.Text == "")
            {
                label7.Visible = true;
            }
        }

        private void sugóToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ez a súgó szövege", "Súgó");
        }


        private void button3_Click(object sender, EventArgs e)
        {
            gyermekfelvetele gyermekfelv = new gyermekfelvetele();
            this.Hide();
            gyermekfelv.Show();
        }

        private void kimutatasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.form_kimutatas.Show();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dlgresult = MessageBox.Show("Biztosan kilép a programból?",
                               "Program bezárása",
                               MessageBoxButtons.YesNo,
                               MessageBoxIcon.Information);
            if (dlgresult == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                Application.ExitThread();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Program.form_gyermekKeres.Show();
        }

        private void dolgozóToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Program.form_szerkeszt.Show();
        }

        private void intézményToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Program.intezmenyszerkeszt.Show();
        }

        private void csoportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Program.csoport_szerkeszt.Show();
        }

        private void Ujraindit_button_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

            bool mehet = false;
            string sql = "SELECT felhasznalo, jelszo FROM user";
            using (var cmd = new MySqlCommand(sql, Program.conn))
            {
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    if (textBox1.Text == (rdr["felhasznalo"].ToString()) && textBox2.Text == (rdr["jelszo"].ToString()))
                    {
                        menuStrip1.Visible = true;
                        button1.Visible = true;
                        button2.Visible = true;
                        button3.Visible = true;
                        button4.Visible = true;
                        groupBox1.Visible = true;
                        groupBox2.Visible = false;
                        mehet = true;
                    }
                    else
                    {
                        MessageBox.Show("Rossz felhasználónév vagy jelszó!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                }
            }
            if (mehet)
            {
                this.Refresh();

                string sql2 = "SELECT * FROM intezmeny";
                using (var cmd2 = new MySqlCommand(sql2, Program.conn))
                {
                    MySqlDataReader rdr2 = cmd2.ExecuteReader();
                    while (rdr2.Read())
                    {
                        intNevTextBox.Text = rdr2.GetString(0);
                        telephelyekTextBox.Text = rdr2.GetString(3);
                        csoportokSzamaTextBox.Text = rdr2.GetInt32(2).ToString();
                        intCimTextBox.Text = rdr2.GetString(1);
                        kijelentkezes_Button.Visible = true;
                    }
                }
                if (intNevTextBox.Text == "" || telephelyekTextBox.Text == "" || csoportokSzamaTextBox.Text == "" || intCimTextBox.Text == "")
                {
                    label7.Visible = true;
                }
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                string sql = "SELECT felhasznalo, jelszo FROM user";
                using (var cmd = new MySqlCommand(sql, Program.conn))
                {
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        if (textBox1.Text == (rdr["felhasznalo"].ToString()) && textBox2.Text == (rdr["jelszo"].ToString()))
                        {
                            menuStrip1.Visible = true;
                            button1.Visible = true;
                            button2.Visible = true;
                            button3.Visible = true;
                            button4.Visible = true;
                            groupBox1.Visible = true;
                            groupBox2.Visible = false;
                        }
                        else
                        {
                            MessageBox.Show("Rossz felhasználónév vagy jelszó!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        }
                    }
                }
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
