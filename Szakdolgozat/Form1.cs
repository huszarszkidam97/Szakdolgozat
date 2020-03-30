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
            string sql = "SELECT * FROM intezmeny";
            using (var cmd = new MySqlCommand(sql, Program.conn))
            {
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    intNevTextBox.Text = rdr.GetString(0);
                    telephelyekTextBox.Text = rdr.GetString(3);
                    csoportokSzamaTextBox.Text = rdr.GetInt32(2).ToString();
                    intCimTextBox.Text = rdr.GetString(1);
                }
            }
            if (intNevTextBox.Text == "" || telephelyekTextBox.Text == "" || csoportokSzamaTextBox.Text == "" || intCimTextBox.Text == "")
            {
                if (MessageBox.Show("Még nem adta hozzá az intézményt!", "Tovább az intézmény hozzáadásához", MessageBoxButtons.OK) == DialogResult.OK)
                {
                    this.Hide();
                    Program.form_intezmenyek.Show();
                }
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
                return;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Program.form_gyermekKeres.Show();
        }
    }
}
