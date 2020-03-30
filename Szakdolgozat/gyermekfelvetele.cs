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
    public partial class gyermekfelvetele : Form
    {
        public gyermekfelvetele()
        {
            InitializeComponent();
        }
        private void gyVHatTextBox_TextChanged(object sender, EventArgs e)
        {
            if (gyVHatTextBox.Text != "")
            {
                gyVErvenyesMask.Visible = true;
                gyVErvenyesLabel.Visible = true;
            }
            else
            {
                gyVErvenyesMask.Visible = false;
                gyVErvenyesLabel.Visible = false;
            }
        }

        private void HHvagyHHHCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (HHvagyHHHCheck.Checked == true)
            {
                HHvagyHHHCombo.Visible = true;
                ervenyesMask.Visible = true;
                HervenyesLabel.Visible = true;
            }
            else
            {
                HHvagyHHHCombo.Visible = false;
                ervenyesMask.Visible = false;
                HervenyesLabel.Visible = false;
            }
        }

        private void mentesButton_Click(object sender, EventArgs e)
        {
            bool vaneGyV = true;
            bool vaneHHvagyHHH = false;
            bool ellenoriz = true;
            label8.Visible = false;
            gyermekNeveTextBox.BackColor = Color.White;
            anyjaNeveTextBox.BackColor = Color.White;
            omAzonMask.BackColor = Color.White;
            csoportKivalaszCombo.BackColor = Color.White;
            gyVErvenyesMask.BackColor = Color.White;
            ervenyesMask.BackColor = Color.White;
            
            string hibauzenet = "";
            string gyermekNeve = "";
            DateTime szuletesiIdo = DateTime.Now;
            string omazon = "0000000000";
            string anyjaNeve = "";
            string gyV = "";
            string gyVErvenyes = "";
            string hhVAGYhhh = "";
            string Hervenyes = "";
            string csoport = "";
            
            gyermekNeve = gyermekNeveTextBox.Text;
            szuletesiIdo = Convert.ToDateTime(szulIdoPicker.Value.ToShortDateString());
            omazon = Convert.ToString(omAzonMask.Text);
            anyjaNeve = anyjaNeveTextBox.Text;
            gyV = gyVHatTextBox.Text;
            gyVErvenyes = gyVErvenyesMask.Text;
            Hervenyes = ervenyesMask.Text;
            
            //Gyermek Neve Mező Ellenőrzése
            if (gyermekNeve == "" || gyermekNeve.Length >= 50)
            {
                ellenoriz = false;
                hibauzenet = "A pirossal jelölt mezők hibásak!";
                gyermekNeveTextBox.BackColor = Color.Red;
            }
            if (gyermekNeve.Length > 0)
                for (int i = 0; i < gyermekNeve.Length; i++)
                {
                    if (Char.IsDigit(gyermekNeve[i]) == true)
                    {
                        ellenoriz = false;
                        hibauzenet = "A pirossal jelölt mezők hibásak!";
                        gyermekNeveTextBox.BackColor = Color.Red;
                    }
                }
            //

            //Születési Ideje Mező Ellenörzése
            if (szuletesiIdo == Convert.ToDateTime(DateTime.Now.ToShortDateString()))
            {
                hibauzenet = "A pirossal jelölt mezők hibásak!";
                label8.Visible = true;
                ellenoriz = false;
            }
            //

            //OM Azonosító Mező Ellenörzése
            if (omazon.Length != 11)
            {
                hibauzenet = "A pirossal jelölt mezők hibásak!";
                omAzonMask.BackColor = Color.Red;
            }
            //

            //Anyja Neve Mező Ellenörzése
            if (anyjaNeve == "" || anyjaNeve.Length >= 50)
            {
                ellenoriz = false;
                hibauzenet = "A pirossal jelölt mezők hibásak!";
                anyjaNeveTextBox.BackColor = Color.Red;
            }
            else
            {
                for (int i = 0; i < anyjaNeve.Length; i++)
                {
                    if (Char.IsDigit(anyjaNeve[i]))
                    {
                        ellenoriz = false;
                        hibauzenet = "A pirossal jelölt mezők hibásak!";
                        anyjaNeveTextBox.BackColor = Color.Red;
                    }
                }
            }
            //

            //GyV Határozat Száma; Érvényesség Mező Ellenörzése
            if (gyV == "" || gyV.Length > 30)
            {
                vaneGyV = false;
                gyV = "nincs";
            }
            //

            //GyV Érvényes Menü Ellenőrzése
            if (gyV.Length > 0)
            {
                for (int i = 0; i < gyVErvenyes.Length; i++)
                {
                    if (gyVErvenyes[i] == ' ')
                    {
                        ellenoriz = false;
                        hibauzenet = "A pirossal jelölt mezők hibásak!";
                        gyVErvenyesMask.BackColor = Color.Red;
                    }
                }
            }
            //
            
            //Van-e HH Vagy HHH Check Ellenőrzése
            if (HHvagyHHHCombo.SelectedItem == null)
            {
                hhVAGYhhh = "nincs";
            }
            else
            {
                vaneHHvagyHHH = true;
                if (HHvagyHHHCombo.SelectedItem.ToString() == "HH (Hátrányos helyzetű)")
                    hhVAGYhhh = "HH";
                else
                    hhVAGYhhh = "HHH";

            }
            //

            //HH Vagy HHH Érvényes Mező Ellenőrzése
            if (HHvagyHHHCheck.Checked == true)
            {
                for (int i = 0; i < Hervenyes.Length; i++)
                {
                    if (Hervenyes[i] == ' ')
                    {
                        ellenoriz = false;
                        hibauzenet = "A pirossal jelölt mezők hibásak!";
                        ervenyesMask.BackColor = Color.Red;
                    }
                }
            }
            //
            
            //HH Vagy HHH Határozat; Érvényesség Mező Ellenörzése
            if (HHvagyHHHCheck.Checked == false)
            {
                hhVAGYhhh = "nincs";
            }
            //

            //Csoport Combo Ellenőrzése
            try
            {
                csoport = csoportKivalaszCombo.SelectedItem.ToString();
            }
            catch (Exception ex)
            {
                csoport = "Hibás!";
                csoportKivalaszCombo.BackColor = Color.Red;
                ellenoriz = false;
                hibauzenet = "A pirossal jelölt mezők hibásak!\n";
                MessageBox.Show(ex.Message);
            }
            //
            if (ellenoriz)
            {
                try
                {
                    Program.sqlCommand = new MySqlCommand(Program.conn.ToString());
                    Program.sqlCommand.Connection = Program.conn;
                    Program.sqlCommand.CommandText = "INSERT INTO gyermekek(nev,szuletesiIdo,omazon,anyjaNeve,gyV,gyVervenyes,hhvagyhhh,ervenyes,csoport) VALUES(?,?,?,?,?,?,?,?,?)";
                    Program.sqlCommand.Parameters.Add("nev", MySqlDbType.VarChar).Value = gyermekNeve;
                    Program.sqlCommand.Parameters.Add("szuletesiIdo", MySqlDbType.Date).Value = szuletesiIdo;
                    Program.sqlCommand.Parameters.Add("omazon", MySqlDbType.VarChar).Value = omazon;
                    Program.sqlCommand.Parameters.Add("anyjaNeve", MySqlDbType.VarChar).Value = anyjaNeve;
                    Program.sqlCommand.Parameters.Add("gyV", MySqlDbType.VarChar).Value = gyV;
                    if (vaneGyV)
                        Program.sqlCommand.Parameters.Add("gyVervenyes", MySqlDbType.VarChar).Value = gyVErvenyes;
                    else
                        Program.sqlCommand.Parameters.Add("gyVervenyes", MySqlDbType.VarChar).Value = "-";
                    Program.sqlCommand.Parameters.Add("hhvagyhhh", MySqlDbType.VarChar).Value = hhVAGYhhh;
                    if(vaneHHvagyHHH)
                        Program.sqlCommand.Parameters.Add("ervenyes", MySqlDbType.VarChar).Value = Hervenyes;
                    else
                        Program.sqlCommand.Parameters.Add("ervenyes", MySqlDbType.VarChar).Value = "-";
                    Program.sqlCommand.Parameters.Add("csoport", MySqlDbType.VarChar).Value = csoport;
                    Program.sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Sikeres mentés!");
                }
                catch (Exception ex)
                {
                    if (hibauzenet.Length == 0)
                        MessageBox.Show("Hiba történt a mentés során!"+ex.Message);
                }
            }
            if (hibauzenet.Length>0)
            MessageBox.Show(hibauzenet);
            this.Refresh();
        }

        private void gyermekfelvetele_Load(object sender, EventArgs e)
        {
            HHvagyHHHCombo.SelectedItem = "HH (Hátrányos helyzetű)";
            gyermekFelveteleButton.Enabled = false;
            string sql = "SELECT csoportNeve FROM csoportok";
            using (var cmd = new MySqlCommand(sql, Program.conn))
            {
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    csoportKivalaszCombo.Items.Add(rdr.GetString(0));
                    csoportKivalaszCombo.SelectedItem = rdr.GetString(0);
                }
            }
        }

        private void intHozzaadButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Program.form_intezmenyek.Show();
        }

        private void csoportHozzaadButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Program.form_csoportok.Show();
        }

        private void gyermekKereseseButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Program.form_gyermekKeres.Show();
        }

        private void kezdőlapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Program.form_nyito.Show();
        }

        private void gyermekfelvetele_FormClosing(object sender, FormClosingEventArgs e)
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
    }
}
