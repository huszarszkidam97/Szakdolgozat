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
            neme_comboBox.SelectedIndex = 0;
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
            string neme = "";
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
                        try
                        {
                            szulIdo = rdr.GetString(2);
                        }
                        catch (Exception m)
                        {
                            szulIdo = "hiba";
                            MessageBox.Show(m.Message + rdr.GetString(2).ToString());
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
                        neme = rdr.GetString(10);
                    }
                }
            }
            gyermekNeveTextBox.Text = gyermekNeve;
            omAzonMask.Text = omazon;
            csoportKivalaszCombo.SelectedItem = csoport;
            anyjaNeveTextBox.Text = anyjaNeve;
            gyVHatTextBox.Text = gyV;
            szulIdoText.Text = szulIdo;
            neme_comboBox.SelectedItem = neme;
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
            csoport_Letszam_Mutato_Label.Text = listView1.Items.Count.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            mentesButton.Visible = true;
            torles_Button.Visible = true;
            torles_Button.Enabled = true;
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
                DialogResult dlgresult = MessageBox.Show("Biztosan törli?",
                              "Gyermek törlése az adatbázisból",
                              MessageBoxButtons.YesNo,
                              MessageBoxIcon.Question);
                if (dlgresult == DialogResult.No)
                {
                    return;
                }
                else
                {
                    Program.sqlCommand = new MySqlCommand(Program.conn.ToString());
                    Program.sqlCommand.Connection = Program.conn;
                    Program.sqlCommand.CommandText = "DELETE FROM `gyermekek` WHERE azon= '" + azon + "'";
                    Program.sqlCommand.ExecuteNonQuery();
                    DialogResult dlgresult2 = MessageBox.Show("Sikeresen törölve lett a " + azon + " azonosítójú gyermek ( " + selectedItem + " )","",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Exclamation);
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
                    int csoportLetszam = Convert.ToInt32(csoport_Letszam_Mutato_Label.Text);
                    if (csoportLetszam >= 0)
                    csoportLetszam -= 1;
                    csoport_Letszam_Mutato_Label.Text = csoportLetszam.ToString();
                    listView1.Clear();
                    foreach (var item in adatok)
                    {
                        if (item.csoport == csoportSelectCombo.SelectedItem.ToString())
                        {
                            listView1.Items.Add(item.nev);
                        }
                    }
                    torles_Button.Enabled = false;
                    foreach (Control ctr in groupBox1.Controls)
                    {
                        if (ctr is TextBox)
                        {
                            ctr.Text = "";
                        }
                    }
                    omAzonMask.Text = "";
                    csoportKivalaszCombo.Text = "";
                    gyVHatTextBox.Text = "";
                    HHvagyHHHCheck.Checked = false;
                    gyVErvenyesLabel.Visible = false;
                    gyVervenyesText.Visible = false;
                    groupBox1.Enabled = false;
                    hhVAGYhhhText.Visible = false;
                    HervenyesLabel.Visible = false;
                    HHHvagyHHErvenyesText.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        string ervenyes = "";
        string hervenyes = "";
        private void mentesButton_Click(object sender, EventArgs e)
        {
            try
            {
                string nev = gyermekNeveTextBox.Text;
                string szulido = szulIdoText.Text;
                string omAzon = omAzonMask.Text;
                string anyjaneve = anyjaNeveTextBox.Text;

                string gyV = gyVHatTextBox.Text;
                ervenyes = gyVervenyesText.Text;
                string hhvagyhhh = hhVAGYhhhText.Text;
                hervenyes = HHHvagyHHErvenyesText.Text;

                string csoport = csoportKivalaszCombo.SelectedItem.ToString();
                string neme = neme_comboBox.SelectedItem.ToString();

                if (gyV.Length == 0 || gyV == "nincs")
                {
                    gyV = "nincs";
                    ervenyes = "-";
                }
                if (HHvagyHHHCheck.Checked == false)
                {
                    hhvagyhhh = "nincs";
                    hervenyes = "-";
                }
                Program.sqlCommand = new MySqlCommand(Program.conn.ToString());
                Program.sqlCommand.Connection = Program.conn;
                Program.sqlCommand.CommandText = "UPDATE `gyermekek` SET nev = @1, " +
                                                 "szuletesiIdo = @2, " +
                                                 "omazon = @3, " +
                                                 "anyjaNeve = @4, " +
                                                 "gyV = @5, " +
                                                 "gyVervenyes = @6, " +
                                                 "hhvagyhhh = @7, " +
                                                 "ervenyes = @8, " +
                                                 "csoport = @9, " +
                                                 "neme = @10 " +
                                                 "WHERE (azon = '" + azon + "')";


                Program.sqlCommand.Parameters.AddWithValue("@1", nev);
                Program.sqlCommand.Parameters.AddWithValue("@2", szulido);
                Program.sqlCommand.Parameters.AddWithValue("@3", omAzon);
                Program.sqlCommand.Parameters.AddWithValue("@4", anyjaneve);
                Program.sqlCommand.Parameters.AddWithValue("@5", gyV);
                Program.sqlCommand.Parameters.AddWithValue("@6", ervenyes);
                Program.sqlCommand.Parameters.AddWithValue("@7", hhvagyhhh);
                Program.sqlCommand.Parameters.AddWithValue("@8", hervenyes);
                Program.sqlCommand.Parameters.AddWithValue("@9", csoport);
                Program.sqlCommand.Parameters.AddWithValue("@10", neme);
                Program.sqlCommand.ExecuteNonQuery();
                MessageBox.Show("Sikeres mentés!");

                string sql = "SELECT nev,csoport FROM gyermekek";
                adatok.Clear();
                using (var cmd = new MySqlCommand(sql, Program.conn))
                {
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Gyermek uj = new Gyermek(rdr.GetString(0), rdr.GetString(1));
                        adatok.Add(uj);
                    }
                }
                listView1.Clear();
                foreach (var item in adatok)
                {
                    if (item.csoport == csoportSelectCombo.SelectedItem.ToString())
                    listView1.Items.Add(item.nev);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Hiba a mentés során!", "információ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void HHvagyHHHCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (HHvagyHHHCheck.Checked == true)
            {
                hhVAGYhhhText.Visible = true;
                HervenyesLabel.Visible = true;
                HHHvagyHHErvenyesText.Visible = true;
            }
            else
            {
                hhVAGYhhhText.Visible = false;
                HervenyesLabel.Visible = false;
                HHHvagyHHErvenyesText.Visible = false;
                ervenyes = "-";
                hervenyes = "-";
            }
        }

        private void gyVHatTextBox_TextChanged(object sender, EventArgs e)
        {
            if (gyVHatTextBox.Text == "" || gyVHatTextBox.Text == "nincs")
            {
                gyVErvenyesLabel.Visible = false;
                gyVervenyesText.Visible = false;
            }
            else
            {
                gyVErvenyesLabel.Visible = true;
                gyVervenyesText.Visible = true;
            }
        }
    }
}