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
    public partial class gyermekKeres : Form
    {
        class Gyermek
        {
            public string nev;
            public string csoport;
            public Gyermek(string nev, string csoport)
            {
                this.nev = nev;
                this.csoport = csoport;
            }
        }
        public gyermekKeres()
        {
            InitializeComponent();
        }
        static List<Gyermek> adatok = new List<Gyermek>();
        int azon = 0;
        string selectedItem = "";
        string selectedItem2 = "";
        private void gyermekKeres_Load(object sender, EventArgs e)
        {
            szerkesztButton.Enabled = false;
            gyermekKereseseButton.Enabled = false;
            groupBox1.Enabled = false;
            listView1.Clear();
            //Csoportok feltöltése /////////////////////////////////////////////////////////////////////////////////////////////

            string sql = "SELECT csoportNeve FROM csoportok";
            using (var cmd = new MySqlCommand(sql, Program.conn))
            {
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    string csoportNeve = rdr.GetString(0);
                    csoportKivalaszCombo.Items.Add(csoportNeve);
                    csoportSelectCombo.Items.Add(csoportNeve);
                }
            }

            csoportSelectCombo.Text = "Válassz egy csoportot....";
            sql = "SELECT azon,nev,csoport FROM gyermekek";
            using (var cmd = new MySqlCommand(sql, Program.conn))
            {
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Gyermek uj = new Gyermek(rdr.GetString(1), rdr.GetString(2));
                    adatok.Add(uj);
                    MessageBox.Show(rdr.GetString(0));
                }
            }
        }

        private void gyermekKeres_FormClosing(object sender, FormClosingEventArgs e)
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

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            HHvagyHHHCheck.Checked = false;
            HervenyesLabel.Visible = false;
            hhVAGYhhhText.Visible = false;
            gyVErvenyesLabel.Visible = false;
            gyVervenyesText.Visible = false;
            HHHvagyHHErvenyesText.Visible = false;
            groupBox1.Enabled = false;
            string gyermekNeve = "";
            string szulIdo = "";
            string omazon = "";
            string anyjaNeve = "";
            string gyV = "";
            string gyVErvenyes = "";
            string hhVAGYhhh = "";
            string ervenyes = "";
            string csoport = "";
            string gyermek = "";
            foreach (var item in listView1.SelectedItems)
            {
                string gyermekNeveVizsgalat = item.ToString();
                bool mehet = false;
                for (int i = 0; i < gyermekNeveVizsgalat.Length; i++)
                {
                    if (gyermekNeveVizsgalat[i] == '{')
                        mehet = true;
                    if (gyermekNeveVizsgalat[i] == '}')
                        mehet = false;
                    if (mehet == true && gyermekNeveVizsgalat[i] != '{')
                        gyermek += gyermekNeveVizsgalat[i];
                }
                selectedItem = gyermek;
                string sql = "SELECT * FROM gyermekek WHERE nev = '" + gyermek + "'";
                using (var cmd = new MySqlCommand(sql, Program.conn))
                {
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        azon = Convert.ToInt32(rdr.GetString(0));
                        gyermekNeve = rdr.GetString(1);
                        for (int i = 0; i < rdr.GetString(2).Length; i++)
                        {
                            if (i < 12)
                                szulIdo += rdr.GetString(2)[i];
                        }

                        omazon = rdr.GetString(3);
                        anyjaNeve = rdr.GetString(4);
                        gyV = rdr.GetString(5);
                        try
                        {
                            gyVErvenyes = rdr.GetString(6);
                        }
                        catch
                        {
                            gyVErvenyes = "nincs";
                        }


                        hhVAGYhhh = rdr.GetString(7);
                        try
                        {
                            ervenyes = rdr.GetString(8);
                        }
                        catch
                        {
                            ervenyes = "nincs";
                        }
                        csoport = rdr.GetString(9);
                    }
                }
            }
            gyermekNeveTextBox.Text = gyermekNeve;
            omAzonMask.Text = omazon;
            csoportKivalaszCombo.SelectedItem = csoport;
            anyjaNeveTextBox.Text = anyjaNeve;
            gyVHatTextBox.Text = gyV;
            szulIdoText.Text = szulIdo;
            if (gyV != "nincs")
            {
                gyVErvenyesLabel.Visible = true;
                gyVervenyesText.Visible = true;
                gyVervenyesText.Text = gyVErvenyes;
            }
            if (hhVAGYhhh != "nincs")
            {
                HHvagyHHHCheck.Checked = true;
                HervenyesLabel.Visible = true;
                hhVAGYhhhText.Visible = true;
                HHHvagyHHErvenyesText.Visible = true;
                hhVAGYhhhText.Text = hhVAGYhhh;
                HHHvagyHHErvenyesText.Text = ervenyes;
            }

            if (listView1.SelectedItems.Count > 0)
            {
                szerkesztButton.Enabled = true;
            }
            else
            {
                szerkesztButton.Enabled = false;
            }
        }

        private void gyermekKereseseButton_Click(object sender, EventArgs e)
        {
        }

        private void gyermekFelveteleButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Program.form_felvétele.Show();
        }

        private void csoportHozzaadButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Program.form_csoportok.Show();
        }

        private void intHozzaadButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Program.form_intezmenyek.Show();
        }

        private void kezdőlapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Program.form_nyito.Show();
        }

        private void csoportSelectCombo_SelectedIndexChanged(object sender, EventArgs e)
        {

            listView1.Items.Clear();
            selectedItem2 = csoportSelectCombo.SelectedItem.ToString();
            foreach (var item in adatok)
            {
                if (item.csoport == csoportSelectCombo.SelectedItem.ToString())
                {
                    listView1.Items.Add(item.nev);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            mentesButton.Visible = true;
            torles_Button.Visible = true;
        }

        private void listView1_Leave(object sender, EventArgs e)
        {
            szerkesztButton.Enabled = false;
        }

        private void frissit_Button_Click(object sender, EventArgs e)
        {
            szerkesztButton.Enabled = false;
            gyermekKereseseButton.Enabled = false;
            groupBox1.Enabled = false;
            listView1.Clear();
            adatok.Clear();
            csoportKivalaszCombo.Items.Clear();
            csoportSelectCombo.Items.Clear();
            //Csoportok feltöltése /////////////////////////////////////////////////////////////////////////////////////////////

            string sql = "SELECT csoportNeve FROM csoportok";
            using (var cmd = new MySqlCommand(sql, Program.conn))
            {
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    string csoportNeve = rdr.GetString(0);
                    csoportKivalaszCombo.Items.Add(csoportNeve);
                    csoportSelectCombo.Items.Add(csoportNeve);
                }
            }

            csoportSelectCombo.Text = "Válassz egy csoportot....";
            sql = "SELECT nev,csoport FROM gyermekek";
            using (var cmd = new MySqlCommand(sql, Program.conn))
            {
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Gyermek uj = new Gyermek(rdr.GetString(0), rdr.GetString(1));
                    adatok.Add(uj);
                }
            }
        }

        private void torles_Button_Click(object sender, EventArgs e)
        {
            try
            {
                Program.sqlCommand = new MySqlCommand(Program.conn.ToString());
                Program.sqlCommand.Connection = Program.conn;
                Program.sqlCommand.CommandText = "DELETE FROM `gyermekek` WHERE azon= '" + azon + "'";
                Program.sqlCommand.ExecuteNonQuery();
                MessageBox.Show("Sikeresen törölve lett a " + azon + " azonosítójú gyermek");
                MessageBox.Show(selectedItem);
                adatok.Clear();
                string sql = "SELECT azon,nev,csoport FROM gyermekek";
                using (var cmd = new MySqlCommand(sql, Program.conn))
                {
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Gyermek uj = new Gyermek(rdr.GetString(1), rdr.GetString(2));
                        adatok.Add(uj);
                    }
                }
                csoportSelectCombo.SelectedItem = selectedItem2;
                listView1.Clear();
                foreach (var item in adatok)
                {
                    if (item.csoport == csoportSelectCombo.SelectedItem.ToString())
                    {
                        listView1.Items.Add(item.nev);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}