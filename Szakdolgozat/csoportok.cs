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
    public partial class csoportok : Form
    {
        static string sql = "";
        class Csoportok
        {
            public string csoportNev;
            public string telephely;
            public int csoportLetszam;
            public List<Dolgozo> telephelyek;

            public Csoportok(string csoportNev, string telephely, int csoportLetszam, List<Dolgozo> telephelyek)
            {
                this.csoportNev = csoportNev;
                this.telephely = telephely;
                this.csoportLetszam = csoportLetszam;
                this.telephelyek = telephelyek;
            }
        }
        class Dolgozo
        {
            public string nev;
            public string beosztas;

            public Dolgozo(string nev, string beosztas)
            {
                this.nev = nev;
                this.beosztas = beosztas;
            }
        }
        static List<Csoportok> adatok = new List<Csoportok>();
        static List<Dolgozo> dolgozok = new List<Dolgozo>();
        public csoportok()
        {
            InitializeComponent();
        }
       
        private void sugóToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ez a súgó szövege", "Súgó");
        }
        static List<string> keszCsoportok = new List<string>();
        private void mentesButton_Click(object sender, EventArgs e)
        {

            bool ellenoriz = true;
            csopNevTextBox.BackColor = Color.White;
            dolgozokCombo.BackColor = Color.White;
            csoportLetszamNum.BackColor = Color.White;

            string hibakod = "";
            string csoportNev = csopNevTextBox.Text;
            string telephely = telephelyKivalaszt.SelectedItem.ToString();
            int csoportLetszam = Convert.ToInt32(csoportLetszamNum.Value);
            string dolgozoNev = "", dolgozoBeosztas = "";
            string munkavegzesHelye = telephely;
            string csoport = csoportNev;


            //Csoport Neve Ellenörzése
            if (csoportNev.Length > 30 || csoportNev == "")
            {
                ellenoriz = false;
                csopNevTextBox.BackColor = Color.Red;
                hibakod = "A pirossal jelölt területek hibásak!";
            }
            //

            //Csoport Létszám Ellenörzése
            if (csoportLetszam > 100 || csoportLetszam == 0)
            {
                ellenoriz = false;
                csoportLetszamNum.BackColor = Color.Red;
                hibakod = "A pirossal jelölt területek hibásak!";
            }
            //

            //Dolgozók ellenörzése
            if (dolgozokCombo.Items.Count == 0)
            {
                ellenoriz = false;
                hibakod = "A pirossal jelölt területek hibásak!";
                dolgozokCombo.BackColor = Color.Red;
            }
            //
 
            if (ellenoriz)
            {
                try
                {
                    Program.sqlCommand = new MySqlCommand(Program.conn.ToString());
                    Program.sqlCommand.Connection = Program.conn;
                    Program.sqlCommand.CommandText = "INSERT INTO csoportok(csoportNeve,telephely,csoportLetszam) VALUES(?,?,?)";
                    Program.sqlCommand.Parameters.Add("csoportNeve", MySqlDbType.VarChar).Value = csoportNev;
                    Program.sqlCommand.Parameters.Add("telephely", MySqlDbType.VarChar).Value = telephely;
                    Program.sqlCommand.Parameters.Add("csoportLetszam", MySqlDbType.Int32).Value = csoportLetszam;
                    Program.sqlCommand.ExecuteNonQuery();
                    foreach (var item in dolgozok)
                    {
                        Program.sqlCommand = new MySqlCommand(Program.conn.ToString());
                        Program.sqlCommand.Connection = Program.conn;
                        dolgozoNev = item.nev;
                        dolgozoBeosztas = item.beosztas;
                        Program.sqlCommand.CommandText = "INSERT INTO dolgozok(dolgozoNeve,dolgozoBeosztasa,munkavegzesHelye,csoport) VALUES(?,?,?,?)";
                        Program.sqlCommand.Parameters.Add("dolgozoNeve", MySqlDbType.VarChar).Value = dolgozoNev;
                        Program.sqlCommand.Parameters.Add("dolgozoBeosztasa", MySqlDbType.VarChar).Value = dolgozoBeosztas;
                        Program.sqlCommand.Parameters.Add("munkavegzesHelye", MySqlDbType.VarChar).Value = munkavegzesHelye;
                        Program.sqlCommand.Parameters.Add("csoport", MySqlDbType.VarChar).Value = csoport;
                        Program.sqlCommand.ExecuteNonQuery();
                    }
                    dolgozokCombo.Items.Clear();
                    dolgozok.Clear();
                    keszCsoportCombo.Items.Clear();
                    sql = "SELECT csoportNeve FROM csoportok";
                    using (var cmd = new MySqlCommand(sql, Program.conn))
                    {
                        MySqlDataReader rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {
                            keszCsoportCombo.Items.Add(rdr.GetString(0));
                            keszCsoportok.Add(rdr.GetString(0));
                        }
                    }
                    this.Refresh();
                    MessageBox.Show("Sikeres mentés!");
                    foreach (Control ctr in groupBox1.Controls)
                    {
                        if (ctr is TextBox)
                        {
                            ctr.Text = "";
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Hiba a mentés során!");
                }
                int csoportokSzama = 0;
                sql = "SELECT csoportokSzama FROM intezmeny";
                using (var cmd = new MySqlCommand(sql, Program.conn))
                {
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        csoportokSzama = Convert.ToInt32(rdr.GetString(0));
                    }
                }
                if (csoportokSzama <= keszCsoportCombo.Items.Count)
                {
                    string szoveg = "";
                    groupBox1.Enabled = false;
                    szoveg = "Csoportok száma elérte a maximális értéket!\nLétrehozott csoportok száma: " + keszCsoportCombo.Items.Count+"\n";
                    MessageBox.Show(szoveg);
                }
                else
                    return;
            }
            if (ellenoriz == false || hibakod.Length > 0)
            {
                MessageBox.Show(hibakod);
            }
        }

        private void hozzaadButton_Click(object sender, EventArgs e)
        {
            bool ellenoriz = true;
            string hibakod = "";
            dolgozoNevTextBox.BackColor = Color.White;
            dolgozoBeosztasTextBox.BackColor = Color.White;
            //Dolgozó Neve ellenőrzése
            if (dolgozoNevTextBox.Text == "" || dolgozoNevTextBox.Text.Length > 100)
            {
                ellenoriz = false;
                hibakod = "A pirossal jelölt területek hibásak!";
                dolgozoNevTextBox.BackColor = Color.Red;
            }
            for (int i = 0; i < dolgozoNevTextBox.Text.Length; i++)
            {
                if(Char.IsDigit(dolgozoNevTextBox.Text[i]))
                {
                    ellenoriz = false;
                    hibakod = "A pirossal jelölt területek hibásak!";
                    dolgozoNevTextBox.BackColor = Color.Red;
                }
            }
            /////////////////////////////////////////////////////////////////////////////
            //Dolgozó Beosztása ellenőrzése
            if (dolgozoBeosztasTextBox.Text == "" || dolgozoBeosztasTextBox.Text.Length > 50)
            {
                ellenoriz = false;
                hibakod = "A pirossal jelölt területek hibásak!";
                dolgozoBeosztasTextBox.BackColor = Color.Red;
            }
            /////////////////////////////////////////////////////////////////////////////
            if (ellenoriz)
            {
                Dolgozo uj = new Dolgozo(dolgozoNevTextBox.Text, dolgozoBeosztasTextBox.Text);
                dolgozok.Add(uj);
                string dolgozo = uj.nev;
                dolgozokCombo.Items.Add(dolgozo);
                MessageBox.Show("Hozzáadva!");
            }
            else if (hibakod.Length > 0 && ellenoriz == false)
            {
                MessageBox.Show(hibakod);
            }
        }

        private void csoportok_Load(object sender, EventArgs e)
        {
            sql = "SELECT telephelyEk FROM intezmeny";
            using (var cmd = new MySqlCommand(sql, Program.conn))
            {
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    string[] tordel = rdr.GetString(0).Split(',');
                    
                    foreach (var item in tordel)
                    {
                        telephelyKivalaszt.Items.Add(item);
                    }
                    telephelyKivalaszt.SelectedItem = tordel[0];
                }
            }
            csoportHozzaadButton.Enabled = false;
            sql = "SELECT csoportNeve FROM csoportok";
            using (var cmd = new MySqlCommand(sql, Program.conn))
            {
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    keszCsoportCombo.Items.Add(rdr.GetString(0));
                    keszCsoportok.Add(rdr.GetString(0));
                }
            }
            int csoportokSzama = 0;
            sql = "SELECT csoportokSzama FROM intezmeny";
            using (var cmd = new MySqlCommand(sql, Program.conn))
            {
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    csoportokSzama = Convert.ToInt32(rdr.GetString(0));
                }
            }
            if (csoportokSzama <= keszCsoportCombo.Items.Count)
            {
                string szoveg = "";
                groupBox1.Enabled = false;
                szoveg = "Csoportok száma elérte a maximális értéket!\nLétrehozott csoportok száma: " + keszCsoportCombo.Items.Count+"\n";
                MessageBox.Show(szoveg);
            }
            else
                return;
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

        private void gyermekFelveteleButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Program.form_felvétele.Show();
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

        private void csoportok_FormClosing(object sender, FormClosingEventArgs e)
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

        private void torles_Button_Click(object sender, EventArgs e)
        {
            DialogResult dlgresult = MessageBox.Show("Biztosan törli a listát?",
                   "Lista üritése",
                   MessageBoxButtons.YesNo,
                   MessageBoxIcon.Information);
            if (dlgresult == DialogResult.No)
            {
                return;
            }
            else
            {
                dolgozokCombo.Items.Clear();
                dolgozok.Clear();
            }
        }
    }
}
