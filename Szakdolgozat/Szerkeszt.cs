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
    public partial class Szerkeszt : Form
    {
        int azon = 0;
        public Szerkeszt()
        {
            InitializeComponent();
        }

        private void kezdőlapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Program.form_nyito.Show();
        }

        private void Szerkeszt_Load(object sender, EventArgs e)
        {
            string sql = "SELECT dolgozoNeve FROM dolgozok";
            using (var cmd = new MySqlCommand(sql, Program.conn))
            {
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    dolgozok_View.Items.Add(rdr.GetString(0));
                }
            }
            sql = "SELECT csoportNeve FROM csoportok";
            using (var cmd = new MySqlCommand(sql, Program.conn))
            {
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    csoport_Box.Items.Add(rdr.GetString(0));
                }
            }
        }

        private void dolgozok_View_SelectedIndexChanged(object sender, EventArgs e)
        {

            box_szerkesztes.Enabled = false;
            mentesButton.Enabled = false;
            if (dolgozok_View.SelectedItems.Count > 0)
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
            foreach (var item in dolgozok_View.SelectedItems)
            {
                string dolgozo = item.ToString();
                string szerkesztettdolgozo = "";
                bool mehet = false;
                for (int i = 0; i < dolgozo.Length; i++)
                {
                    if (dolgozo[i] == '{')
                        mehet = true;
                    if (dolgozo[i] == '}')
                        mehet = false;
                    if (mehet == true && dolgozo[i] != '{')
                        szerkesztettdolgozo += dolgozo[i];
                }

                string sql = "SELECT * FROM dolgozok WHERE dolgozoNeve = '" + szerkesztettdolgozo + "'";
                using (var cmd = new MySqlCommand(sql, Program.conn))
                {
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        dolgozoneve_Text.Text = rdr.GetString(1);
                        beosztas_Text.Text = rdr.GetString(2);
                        azon = Convert.ToInt32(rdr.GetString(0));
                        csoport_Box.SelectedItem = rdr.GetString(4);
                    }
                }
            }

        }

        private void mentesButton_Click(object sender, EventArgs e)
        {
            try
            {
                string nev = dolgozoneve_Text.Text;
                string beosztas = beosztas_Text.Text;
                string munkavegzesHelye = "";
                string sql = "SELECT telephely FROM csoportok WHERE csoportNeve ='" + csoport_Box.SelectedItem.ToString() + "'";
                using (var cmd = new MySqlCommand(sql, Program.conn))
                {
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        munkavegzesHelye = rdr.GetString(0);
                    }
                }
                string csoport = csoport_Box.SelectedItem.ToString();


                Program.sqlCommand = new MySqlCommand(Program.conn.ToString());
                Program.sqlCommand.Connection = Program.conn;



                Program.sqlCommand.CommandText = "UPDATE `dolgozok` SET dolgozoNeve = @1, dolgozoBeosztasa = @2, munkavegzesHelye = @3, csoport = @4 WHERE (dolgozoAzon = '" + azon + "')";


                Program.sqlCommand.Parameters.AddWithValue("@1", nev);
                Program.sqlCommand.Parameters.AddWithValue("@2", beosztas);
                Program.sqlCommand.Parameters.AddWithValue("@3", munkavegzesHelye);
                Program.sqlCommand.Parameters.AddWithValue("@4", csoport);
                Program.sqlCommand.ExecuteNonQuery();
                MessageBox.Show("Sikeres mentés!");
            }
            catch (Exception)
            {
                MessageBox.Show("Hiba a mentés során!", "információ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dolgozok_View.SelectedItems.Clear();
            string searchValue = textBox1.Text;
            int i = 0;
            if (textBox1.Text != "")
            {
                foreach (var item in dolgozok_View.Items)
                {
                    string itemnev = "";
                    bool mehet = false;
                    string itemszoveg = item.ToString();
                    for (int j = 0; j < itemszoveg.Length; j++)
                    {
                        if (itemszoveg[j] == '}')
                        {
                            mehet = false;
                        }
                        if (itemszoveg[j] == '{')
                        {
                            mehet = true;
                        }
                        if (mehet && itemszoveg[j] != '{')
                        {
                            itemnev += itemszoveg[j];
                        }
                    }
                    string tesztNev = "";
                    if (searchValue.Length <= itemnev.Length)
                    {
                        for (int j = 0; j < searchValue.Length; j++)
                        {
                            tesztNev += itemnev[j];
                        }
                    }
                    if (tesztNev == searchValue)
                    {
                        dolgozok_View.Items[i].Selected = true;
                        dolgozok_View.Items[i].Focused = true;
                    }
                    i++;
                }
            }
            else
            {
                beosztas_Text.Text = "";
                dolgozoneve_Text.Text = "";
                csoport_Box.SelectedItem = " ";
            }

        }
        bool elsokatt = false;
        private void textBox1_Click(object sender, EventArgs e)
        {
            if (elsokatt == false)
            {
                textBox1.Text = "";
                elsokatt = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            box_szerkesztes.Enabled = true;
            mentesButton.Enabled = true;
        }

        private void dolgozókToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Szerkeszt_FormClosing(object sender, FormClosingEventArgs e)
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
                Environment.Exit(1);
            }
        }

        private void csoportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Program.csoport_szerkeszt.Show();
        }

        private void intézményToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Program.intezmenyszerkeszt.Show();
        }
    }
}
