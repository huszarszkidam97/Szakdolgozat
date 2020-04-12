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
    public partial class intezmeny : Form
    {     
        class IntezmenyFelvetele
        {
            public string intezmenyNeve;
            public string intezmenyCime;
            public int csoportokSzama;
            public List<string> telephelyek;
            public IntezmenyFelvetele(string intezmenyNeve, string intezmenyCime, int csoportokSzama, List<string> telephelyek)
            {
                this.intezmenyNeve = intezmenyNeve;
                this.intezmenyCime = intezmenyCime;
                this.csoportokSzama = csoportokSzama;
                this.telephelyek = telephelyek;
            }
        }
        static List<string> telephelyek = new List<string>();
        static List<IntezmenyFelvetele> Adatok = new List<IntezmenyFelvetele>();
        public intezmeny()
        {
            InitializeComponent();
        }
        private void hozzaadButton_Click(object sender, EventArgs e)
        {
            if (pluszTelephelyTextBox.Text != "")
            {
                telephelyek.Add(pluszTelephelyTextBox.Text);
                tobbTelephelyCombo.Items.Add(pluszTelephelyTextBox.Text.ToString());
                MessageBox.Show("Hozzádva!");
            }
            else
            {
                MessageBox.Show("A mező üres!");
            }
        }
        bool ujraindit = true;
        private void mentesButton_Click(object sender, EventArgs e)
        {
            intNevTextBox.BackColor = Color.White;
            intCimTextBox.BackColor = Color.White;
            pluszTelephelyTextBox.BackColor = Color.White;
            tobbTelephelyCombo.BackColor = Color.White;
            csoportokSzamaNum.BackColor = Color.White;
            bool ellenoriz = true;
            string hibakod = "";
            if (intNevTextBox.Text != "" && intCimTextBox.Text != "" && csoportokSzamaNum.Value != 0)
            {
                string nev = intNevTextBox.Text;
                string cim = intCimTextBox.Text;
                int csoportszam = Convert.ToInt32(csoportokSzamaNum.Value);
                IntezmenyFelvetele ujadat = new IntezmenyFelvetele(nev,cim,csoportszam,telephelyek);
                Adatok.Add(ujadat);
            }
            string intezmenyNeve ="";
            string intezmenyCime ="";
            int csoportokSzama = 0;
            string telephelyEk = "";
            foreach (var item in Adatok)
            {
                intezmenyNeve = item.intezmenyNeve;
                intezmenyCime = item.intezmenyCime;
                csoportokSzama = item.csoportokSzama;
                foreach (var telephely in telephelyek)
                {
                    telephelyEk += telephely + ";";
                }
            }



            //Csoportok száma ellenőrzése
            if (csoportokSzamaNum.Value == 0)
            {
                csoportokSzamaNum.BackColor = Color.Red;
                ellenoriz = false;
                hibakod = "A pirossal jelölt területek hibásak!";
            }
            //////////////////////////////////////////////////////////////////////
            //Intézmény neve ellenőrzése
            intezmenyNeve = intNevTextBox.Text;
            if (intezmenyNeve.Length > 60 ||intezmenyNeve.Length == 0)
            {
                intNevTextBox.BackColor = Color.Red;
                ellenoriz = false;
                hibakod = "A pirossal jelölt területek hibásak!";
            }
            for (int i = 0; i < intezmenyNeve.Length; i++)
            {
                if(Char.IsDigit(intezmenyNeve[i]))
                {
                    intNevTextBox.BackColor = Color.Red;
                    ellenoriz = false;
                    hibakod = "\nA pirossal jelölt területek hibásak!";
                }
            }
            //////////////////////////////////////////////////////////////////////
            //Intézmény címe ellenőrzése
            intezmenyCime = intCimTextBox.Text;
            if (intezmenyCime.Length > 60 ||intezmenyCime.Length == 0)
            {
                intCimTextBox.BackColor = Color.Red;
                ellenoriz = false;
                hibakod = "\nA pirossal jelölt területek hibásak!";
            }
            /////////////////////////////////////////////////////////////////////
            //Telephely ellenőrzése
            if (tobbTelephelyCombo.Items.Count == 0)
            {
                pluszTelephelyTextBox.BackColor = Color.Red;
                tobbTelephelyCombo.BackColor = Color.Red;
                ellenoriz = false;
                hibakod = "A pirossal jelölt területek hibásak!";
            }
            /////////////////////////////////////////////////////////////////////
            if (ellenoriz)
            {
                try
                {
                    Program.sqlCommand.CommandText = "INSERT INTO intezmeny(intezmenyNeve,intezmenyCime,csoportokSzama,telephelyEk) VALUES(?,?,?,?)";
                    Program.sqlCommand.Parameters.Add("intezmenyNeve", MySqlDbType.VarChar).Value = intezmenyNeve;
                    Program.sqlCommand.Parameters.Add("intezmenyCime", MySqlDbType.VarChar).Value = intezmenyCime;
                    Program.sqlCommand.Parameters.Add("csoportokSzama", MySqlDbType.Int32).Value = csoportokSzama;
                    Program.sqlCommand.Parameters.Add("telephelyEk", MySqlDbType.VarChar).Value = telephelyEk;
                    Program.sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Sikeres mentés!\nÚjraindítás szükséges....");
                    ujraindit = false;
                    Application.Restart();
                }
                catch
                {
                    MessageBox.Show("Hiba a mentés során!");
                }
            }
            if (hibakod.Length > 0 && ellenoriz == false)
            {
                MessageBox.Show(hibakod);
            }
            this.Refresh();
        }
        private void sugóToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ez a súgó szövege", "Súgó");
        }

        private void intezmeny_Load(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM intezmeny";
            string IntezmenyNeve = null, Telephely = null, CsoportokSzama = null, IntezmenyCime = null;
            using (var cmd = new MySqlCommand(sql, Program.conn))
            {
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    IntezmenyNeve = rdr.GetString(0);
                    IntezmenyCime = rdr.GetString(1);
                    CsoportokSzama = rdr.GetString(2);
                    Telephely = rdr.GetString(3);
                }
            }
            intHozzaadButton.Enabled = false;
            if (IntezmenyNeve != null || Telephely != null || CsoportokSzama != null || IntezmenyCime != null)
            {
                intNevTextBox.Text = IntezmenyNeve;
                pluszTelephelyTextBox.Text = Telephely;
                csoportokSzamaNum.Text = CsoportokSzama;
                intCimTextBox.Text = IntezmenyCime;
                groupBox1.Enabled = false;
            }
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

        private void intezmeny_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ujraindit)
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
        }
    }
}
