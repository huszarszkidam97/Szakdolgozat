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
    public partial class intezmenyszerkeszt : Form
    {
        public intezmenyszerkeszt()
        {
            InitializeComponent();
        }

        private void intezmenyszerkeszt_FormClosing(object sender, FormClosingEventArgs e)
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
        string azon = "";
        private void intezmenyszerkeszt_Load(object sender, EventArgs e)
        {
            string intezmenyNeve = "";
            string intezmenyCime = "";
            string csoportokSzama = "";
            string tordeloTelepek = "";
            List<string> telephelyEk = new List<string>();
            string sql = "SELECT * FROM intezmeny";
            using (var cmd = new MySqlCommand(sql, Program.conn))
            {
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    intezmenyNeve = rdr.GetString(0);
                    intezmenyCime = rdr.GetString(1);
                    csoportokSzama = rdr.GetString(2);
                    tordeloTelepek = rdr.GetString(3);
                    string[] tordel = tordeloTelepek.Split(',');
                    for (int i = 0; i < tordel.Length; i++)
                    {
                        telephelyEk.Add(tordel[i]);
                    }
                    azon = rdr.GetString(4);
                }
            }
            intezmenyNeve_Text.Text = intezmenyNeve;
            intezmenyCime_Text.Text = intezmenyCime;
            csoportokSzáma_Text.Text = csoportokSzama;
            foreach (var item in telephelyEk)
            {
                if (item.ToString().Length > 0)
                {
                    comboBox1.Items.Add(item);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            box_szerkesztes.Enabled = true;
            mentesButton.Enabled = true;
        }

        private void telephelyTorlese_button_Click(object sender, EventArgs e)
        {
            try
            {
                comboBox1.Items[comboBox1.SelectedIndex] = string.Empty;
                List<string> Lista = new List<string>();
                foreach (var item in comboBox1.Items)
                {
                    if (item.ToString().Length > 0)
                    {
                        Lista.Add(item.ToString());
                    }
                }
                comboBox1.Items.Clear();
                foreach (var item in Lista)
                {
                    comboBox1.Items.Add(item);
                }
            }
            catch
            {
                MessageBox.Show("Hiba!\nNem választotta ki a telephelyet!\nVagy\nNincs mit törölni!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<string> Lista = new List<string>();
            comboBox1.Items.Add(telephelyHozzaad_Text.Text);
            MessageBox.Show("Hozzáadva!");
            foreach (var item in comboBox1.Items)
            {
                if (item.ToString().Length > 0)
                {
                    Lista.Add(item.ToString());
                }
            }
            comboBox1.Items.Clear();
            foreach (var item in Lista)
            {
                comboBox1.Items.Add(item);
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void mentesButton_Click(object sender, EventArgs e)
        {
            try
            {
                string intezmenyNeve = intezmenyNeve_Text.Text;
                string intezmenyCime = intezmenyCime_Text.Text;
                string csoportokSzama = csoportokSzáma_Text.Text;
                string telephelyEk = "";
                foreach (var item in comboBox1.Items)
                {
                    telephelyEk += item + ",";
                }
                Program.sqlCommand = new MySqlCommand(Program.conn.ToString());
                Program.sqlCommand.Connection = Program.conn;
                Program.sqlCommand.CommandText = "UPDATE `intezmeny` SET intezmenyNeve = @1, intezmenyCime = @2, csoportokSzama = @3, telephelyEk = @4 WHERE (azon = '" + azon + "')";


                Program.sqlCommand.Parameters.AddWithValue("@1", intezmenyNeve);
                Program.sqlCommand.Parameters.AddWithValue("@2", intezmenyCime);
                Program.sqlCommand.Parameters.AddWithValue("@3", csoportokSzama);
                Program.sqlCommand.Parameters.AddWithValue("@4", telephelyEk);
                Program.sqlCommand.ExecuteNonQuery();
                MessageBox.Show("Sikeres mentés!\nLépjen be újra....");
                Application.Exit();
            }
            catch (Exception)
            {
                MessageBox.Show("Hiba a mentés sopán!", "információ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void kezdőlapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Program.form_nyito.Show();
        }

        private void csoportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Program.csoport_szerkeszt.Show();
        }

        private void dolgozókToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Program.form_szerkeszt.Show();
        }
    }
}
