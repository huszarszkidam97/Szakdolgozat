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
            if (comboBox1.SelectedItem.ToString() == "Csoportok")
            {
                comboBox2.Visible = false;
                dataGridView1.Columns.Clear();
                dataGridView1.Rows.Clear();
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
                        string csoportneve = rdr.GetString(0);
                        string telephely = rdr.GetString(1);
                        int csoportLetszam = rdr.GetInt32(2);
                        dataGridView1.Rows.Add(csoportneve, telephely, csoportLetszam);
                    }
                }
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
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            }
            if (comboBox1.SelectedItem.ToString() == "Dolgozók")
            {
                comboBox2.Visible = false;
                dataGridView1.Columns.Clear();
                dataGridView1.Rows.Clear();
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
                        string dolgozoNeve = rdr.GetString(0);
                        string dolgozoBeosztasa = rdr.GetString(1);
                        string munkavegzesHelye = rdr.GetString(2);
                        string csoport = rdr.GetString(3);
                        dataGridView1.Rows.Add(dolgozoNeve, dolgozoBeosztasa, munkavegzesHelye, csoport);
                    }
                }
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            }
            if (comboBox1.SelectedItem.ToString() == "Gyermekek")
            {
                comboBox2.Visible = true;
                dataGridView1.Columns.Clear();
                dataGridView1.Rows.Clear();
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
                        string nev = rdr.GetString(0);
                        string szuletesiIdo = Convert.ToDateTime(rdr.GetString(1)).ToShortDateString();
                        string omAzon = rdr.GetString(2);
                        string anyjaNeve = rdr.GetString(3);
                        string gyVHatarozatSzama = rdr.GetString(4);
                        string gyVervenyes = rdr.GetString(5);
                        string hhVAGYhhh = rdr.GetString(6);
                        string ervenyes = rdr.GetString(7);
                        string csoport = rdr.GetString(8);
                        if (gyVervenyes == "0000-00-00")
                        {
                            gyVervenyes = nincs;
                        }
                        if (ervenyes == "0000-00-00")
                        {
                            ervenyes = nincs;
                        }
                        dataGridView1.Rows.Add(nev, szuletesiIdo, omAzon, anyjaNeve, gyVHatarozatSzama, gyVervenyes, hhVAGYhhh, ervenyes, csoport);

                    }
                }
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            }
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
                    string nev = rdr.GetString(0);
                    string szuletesiIdo = Convert.ToDateTime(rdr.GetString(1)).ToShortDateString();
                    string omAzon = rdr.GetString(2);
                    string anyjaNeve = rdr.GetString(3);
                    string gyVHatarozatSzama = rdr.GetString(4);
                    string gyVervenyes = rdr.GetString(5);
                    string hhVAGYhhh = rdr.GetString(6);
                    string ervenyes = rdr.GetString(7);
                    string csoport = rdr.GetString(8);
                    if (gyVervenyes == "0000-00-00")
                    {
                        gyVervenyes = nincs;
                    }
                    if (ervenyes == "0000-00-00")
                    {
                        ervenyes = nincs;
                    }
                    dataGridView1.Rows.Add(nev, szuletesiIdo, omAzon, anyjaNeve, gyVHatarozatSzama, gyVervenyes, hhVAGYhhh, ervenyes, csoport);

                }
            }
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        }
    }
}
