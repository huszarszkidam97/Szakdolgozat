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
using Microsoft.Office.Interop.Excel;

namespace Szakdolgozat
{
    public partial class Kimutatás : Form
    {
        static string sql = "";
        static int oszlop = 1;
        public Kimutatás()
        {
            InitializeComponent();
        }

        private void Kimutatas_Load(object sender, EventArgs e)
        {
            this.Refresh();
            comboBox1.Text = "Típus...";
            sql = "SELECT csoportNeve FROM csoportok";
            using (var cmd = new MySqlCommand(sql, Program.conn))
            {
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    comboBox2.Items.Add(rdr.GetString(0));
                }
            }
            comboBox2.SelectedItem = "Összes";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = "Keresés....";
            if (comboBox1.SelectedItem.ToString() == "Csoportok")
                oszlop = 0;
            else
                oszlop = 1;

            if (comboBox1.SelectedItem.ToString() == "Intézmény")
                textBox1.Visible = false;
            else
                textBox1.Visible = true;


            if (comboBox1.SelectedItem.ToString() == "Csoportok")
            {
                comboBox2.Visible = false;
                dataGridView1.Columns.Clear();
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Add("Azon", "Azonosító");
                dataGridView1.Columns.Add("Csoport Neve", "Csoport Neve");
                dataGridView1.Columns.Add("Csoport Neve", "Telephely");
                dataGridView1.Columns.Add("Csoport Neve", "Csoport Létszám");
                //Csoportok feltöltése /////////////////////////////////////////////////////////////////////////////////////////////
                sql = "SELECT * FROM csoportok";
                using (var cmd = new MySqlCommand(sql, Program.conn))
                {
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        string azon = rdr.GetString(0);
                        string csoportneve = rdr.GetString(1);
                        string telephely = rdr.GetString(2);
                        int csoportLetszam = rdr.GetInt32(3);
                        dataGridView1.Rows.Add(azon, csoportneve, telephely, csoportLetszam);
                    }
                }

                dataGridView1.AutoResizeColumns();
                dataGridView1.AutoResizeRows();
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            }
            if (comboBox1.SelectedItem.ToString() == "Intézmény")
            {
                comboBox2.Visible = false;
                dataGridView1.Columns.Clear();
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Add("Intézmény Neve", "Intézmény Neve");
                dataGridView1.Columns.Add("Intézmény Címe", "Címe");
                dataGridView1.Columns.Add("Csoportok Száma", "Csoportok Száma");
                dataGridView1.Columns.Add("Telephely(ek)", "Telephely(ek)");
                //Intézmény feltöltése /////////////////////////////////////////////////////////////////////////////////////////////
                sql = "SELECT * FROM intezmeny";
                using (var cmd = new MySqlCommand(sql, Program.conn))
                {
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        string IntezmenyNeve = rdr.GetString(0);
                        string Telephely = rdr.GetString(3);
                        string CsoportokSzama = rdr.GetInt32(2).ToString();
                        string IntezmenyCime = rdr.GetString(1);
                        dataGridView1.Rows.Add(IntezmenyNeve, Telephely, CsoportokSzama, IntezmenyCime);
                    }
                }

                dataGridView1.AutoResizeColumns();
                dataGridView1.AutoResizeRows();
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            }
            if (comboBox1.SelectedItem.ToString() == "Dolgozók")
            {
                comboBox2.Visible = false;
                dataGridView1.Columns.Clear();
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Add("Azonosító", "Azon");
                dataGridView1.Columns.Add("Dolgozo Neve", "Neve");
                dataGridView1.Columns.Add("Beosztása", "Beosztása");
                dataGridView1.Columns.Add("Munkavégzés Helye", "Munkavégzés Helye");
                dataGridView1.Columns.Add("Csoport", "Csoport");
                //Dolgozók feltöltése /////////////////////////////////////////////////////////////////////////////////////////////
                sql = "SELECT * FROM dolgozok";
                using (var cmd = new MySqlCommand(sql, Program.conn))
                {
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        string azon = rdr.GetString(0);
                        string dolgozoNeve = rdr.GetString(1);
                        string dolgozoBeosztasa = rdr.GetString(2);
                        string munkavegzesHelye = rdr.GetString(3);
                        string csoport = rdr.GetString(4);
                        dataGridView1.Rows.Add(azon, dolgozoNeve, dolgozoBeosztasa, munkavegzesHelye, csoport);
                    }
                }
                dataGridView1.AutoResizeColumns();
                dataGridView1.AutoResizeRows();
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            }
            if (comboBox1.SelectedItem.ToString() == "Gyermekek")
            {
                comboBox2.Visible = true;
                dataGridView1.Columns.Clear();
                dataGridView1.Rows.Clear();
                dataGridView1.AutoResizeColumns();
                dataGridView1.Columns.Add("Azonosító", "Azon");
                dataGridView1.Columns.Add("Gyermek Neve", "Neve");
                dataGridView1.Columns.Add("Születési ideje", "Születési Ideje");
                dataGridView1.Columns.Add("OM Azonosító", "OM Azonosító");
                dataGridView1.Columns.Add("Anyja Neve", "Anyja Neve");
                dataGridView1.Columns.Add("GyV Határozat Száma", "GyV Határozat Száma");
                dataGridView1.Columns.Add("GyV Érvényes", "GyV Érvényes");
                dataGridView1.Columns.Add("HH vagy HHH", "HH vagy HHH");
                dataGridView1.Columns.Add("Érvényes", "Érvényes");
                dataGridView1.Columns.Add("Csoport", "Csoport");
                //Gyermekek feltöltése /////////////////////////////////////////////////////////////////////////////////////////////
                if (comboBox2.SelectedItem.ToString() == "Összes")
                {
                    sql = "SELECT * FROM gyermekek";
                }
                else
                    sql = "SELECT * FROM gyermekek WHERE csoport = '" + comboBox2.SelectedItem.ToString() + "'";
                using (var cmd = new MySqlCommand(sql, Program.conn))
                {
                    string nincs = "-";
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        string azon = rdr.GetString(0);
                        string nev = rdr.GetString(1);
                        string szuletesiIdo = Convert.ToDateTime(rdr.GetString(2)).ToShortDateString();
                        string omAzon = rdr.GetString(3);
                        string anyjaNeve = rdr.GetString(4);
                        string gyVHatarozatSzama = rdr.GetString(5);
                        string gyVervenyes = rdr.GetString(6);
                        string hhVAGYhhh = rdr.GetString(7);
                        string ervenyes = rdr.GetString(8);
                        string csoport = rdr.GetString(9);
                        if (gyVervenyes == "0000-00-00")
                        {
                            gyVervenyes = nincs;
                        }
                        if (ervenyes == "0000-00-00")
                        {
                            ervenyes = nincs;
                        }
                        dataGridView1.Rows.Add(azon, nev, szuletesiIdo, omAzon, anyjaNeve, gyVHatarozatSzama, gyVervenyes, hhVAGYhhh, ervenyes, csoport);

                    }
                    dataGridView1.AutoResizeColumns();
                    dataGridView1.AutoResizeRows();
                }
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            }

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.AutoResizeRows();
            dataGridView1.AutoResizeColumns();
            dataGridView1.Refresh();
        }

        private void Bezaras_Click(object sender, EventArgs e)
        {
            Program.form_kimutatas.Hide();
        }
        private void Kimutatás_FormClosing(object sender, FormClosingEventArgs e)
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
        private void copyAlltoClipboard()
        {
            dataGridView1.SelectAll();
            DataObject dataObj = dataGridView1.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }
        private void button1_Click(object sender, EventArgs e)
        {
                copyAlltoClipboard();
                Microsoft.Office.Interop.Excel.Application xlexcel;
                Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
                Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;
                xlexcel = new Microsoft.Office.Interop.Excel.Application();
                xlexcel.Visible = true;
                xlWorkBook = xlexcel.Workbooks.Add(misValue);
                xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                Microsoft.Office.Interop.Excel.Range CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 1];
                CR.Select();
                xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Add("Azonosító", "Azon");
            dataGridView1.Columns.Add("Gyermek Neve", "Neve");
            dataGridView1.Columns.Add("Születési ideje", "Születési Ideje");
            dataGridView1.Columns.Add("OM Azonosító", "OM Azonosító");
            dataGridView1.Columns.Add("Anyja Neve", "Anyja Neve");
            dataGridView1.Columns.Add("GyV Határozat Száma", "GyV Határozat Száma");
            dataGridView1.Columns.Add("GyV Érvényes", "GyV Érvényes");
            dataGridView1.Columns.Add("HH vagy HHH", "HH vagy HHH");
            dataGridView1.Columns.Add("Érvényes", "Érvényes");
            dataGridView1.Columns.Add("Csoport", "Csoport");

            //Gyermekek feltöltése/////////////////////////////////////////////////////////////////////////////////////////////
            if (comboBox2.SelectedItem.ToString() == "Összes")
            {
                sql = "SELECT * FROM gyermekek";
            }
            else
                sql = "SELECT * FROM gyermekek WHERE csoport = '" + comboBox2.SelectedItem.ToString() + "'";

            using (var cmd = new MySqlCommand(sql, Program.conn))
            {
                string nincs = "-";
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    string azon = rdr.GetString(0);
                    string nev = rdr.GetString(1);
                    string szuletesiIdo = Convert.ToDateTime(rdr.GetString(2)).ToShortDateString();
                    string omAzon = rdr.GetString(3);
                    string anyjaNeve = rdr.GetString(4);
                    string gyVHatarozatSzama = rdr.GetString(5);
                    string gyVervenyes = rdr.GetString(6);
                    string hhVAGYhhh = rdr.GetString(7);
                    string ervenyes = rdr.GetString(8);
                    string csoport = rdr.GetString(9);
                    if (gyVervenyes == "0000-00-00")
                    {
                        gyVervenyes = nincs;
                    }
                    if (ervenyes == "0000-00-00")
                    {
                        ervenyes = nincs;
                    }
                    dataGridView1.Rows.Add(azon, nev, szuletesiIdo, omAzon, anyjaNeve, gyVHatarozatSzama, gyVervenyes, hhVAGYhhh, ervenyes, csoport);

                }
            }
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dataGridView1.AutoResizeRows();
            dataGridView1.AutoResizeColumns();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            string searchValue = textBox1.Text;
            dataGridView1.ClearSelection();
            if (searchValue.Length != 0)
            {
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                try
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        string tesztNev = "";
                        if (searchValue.Length <= row.Cells[oszlop].Value.ToString().Length)
                            for (int i = 0; i < searchValue.Length; i++)
                            {
                                tesztNev += row.Cells[oszlop].Value.ToString()[i];
                            }
                        if (tesztNev == searchValue)
                        {
                            dataGridView1.Rows[row.Index].Selected = true;
                        }
                    }
                }
                catch
                {
                    return;
                }
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
        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Items.Count > 0)
                comboBox1.SelectedIndex = 0;
            if (comboBox2.Items.Count > 0)
                comboBox2.SelectedIndex = 0;
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();



        }
    }
}
