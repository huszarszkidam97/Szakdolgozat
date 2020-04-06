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
    public partial class csoport_szerkesztés : Form
    {
        public csoport_szerkesztés()
        {
            InitializeComponent();
        }

        private void csoport_szerkesztés_Load(object sender, EventArgs e)
        {
            string sql = "SELECT csoportNeve FROM csoportok";
            using (var cmd = new MySqlCommand(sql, Program.conn))
            {
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    csoportok_View.Items.Add(rdr.GetString(0));
                }
            }
            sql = "SELECT telephelyEk FROM intezmeny";
            using (var cmd = new MySqlCommand(sql, Program.conn))
            {
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    string[] tordel = rdr.GetString(0).Split(',');
                    for (int i = 0; i < tordel.Length; i++)
                    {
                        if (tordel[i].ToString().Length > 5)
                        telephely_Box.Items.Add(tordel[i]);
                    }
                }
            }

            List<string> Lista = new List<string>();
            foreach (var item in telephely_Box.Items)
            {
                if (item.ToString().Length > 0 || item.ToString() != " ")
                {
                    Lista.Add(item.ToString());
                }
            }
            telephely_Box.Items.Clear();
            foreach (var item in Lista)
            {
                if (item.ToString() != " ")
                    telephely_Box.Items.Add(item);
            }
        }

        int azon = 0;
        private void dolgozok_View_SelectedIndexChanged(object sender, EventArgs e)
        {
            box_szerkesztes.Enabled = false;
            mentesButton.Enabled = false;
            if (csoportok_View.SelectedItems.Count > 0)
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
            foreach (var item in csoportok_View.SelectedItems)
            {
                string csoportNeve = item.ToString();
                string szerkesztettCsoport = "";
                bool mehet = false;
                for (int i = 0; i < csoportNeve.Length; i++)
                {
                    if (csoportNeve[i] == '{')
                        mehet = true;
                    if (csoportNeve[i] == '}')
                        mehet = false;
                    if (mehet == true && csoportNeve[i] != '{')
                        szerkesztettCsoport += csoportNeve[i];
                }

                string sql = "SELECT * FROM csoportok WHERE csoportNeve = '" + szerkesztettCsoport + "'";
                using (var cmd = new MySqlCommand(sql, Program.conn))
                {
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        csoportNeve_Text.Text = rdr.GetString(1);
                        csoportLetszam_Text.Text = rdr.GetString(3);
                        azon = Convert.ToInt32(rdr.GetString(0));
                        telephely_Box.SelectedItem = rdr.GetString(2);
                        MessageBox.Show(rdr.GetString(2));
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            box_szerkesztes.Enabled = true;
            mentesButton.Enabled = true;
        }

        private void csoport_szerkesztés_FormClosing(object sender, FormClosingEventArgs e)
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

        private void dolgozókToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Program.form_szerkeszt.Show();
        }

        private void kezdőlapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Program.form_nyito.Show();
        }

        private void intézményToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Program.intezmenyszerkeszt.Show();
        }

        private void mentesButton_Click(object sender, EventArgs e)
        {
            try
            {
                string csoportNeve = csoportNeve_Text.Text;
                string csoportLetszam = csoportLetszam_Text.Text;
                string telephely = telephely_Box.SelectedItem.ToString();
                Program.sqlCommand = new MySqlCommand(Program.conn.ToString());
                Program.sqlCommand.Connection = Program.conn;
                Program.sqlCommand.CommandText = "UPDATE `csoportok` SET csoportNeve = @1, telephely = @2, csoportLetszam = @3 WHERE (azon = '" + azon + "')";
                Program.sqlCommand.Parameters.AddWithValue("@1", csoportNeve);
                Program.sqlCommand.Parameters.AddWithValue("@2", telephely);
                Program.sqlCommand.Parameters.AddWithValue("@3", csoportLetszam);
                Program.sqlCommand.ExecuteNonQuery();
                MessageBox.Show("Sikeres mentés!");
            }
            catch (Exception)
            {
                MessageBox.Show("Hiba a mentés során!", "információ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
