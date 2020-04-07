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
                        dataGridView1.Rows.Add(IntezmenyNeve, IntezmenyCime, CsoportokSzama, Telephely);
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
                dataGridView1.Columns.Add("Neme", "Neme");
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
                        string szuletesiIdo = rdr.GetString(2);
                        string omAzon = rdr.GetString(3);
                        string anyjaNeve = rdr.GetString(4);
                        string gyVHatarozatSzama = rdr.GetString(5);
                        string gyVervenyes = rdr.GetString(6);
                        string hhVAGYhhh = rdr.GetString(7);
                        string ervenyes = rdr.GetString(8);
                        string csoport = rdr.GetString(9);
                        string neme = rdr.GetString(10);
                        dataGridView1.Rows.Add(azon, nev, neme, szuletesiIdo, omAzon, anyjaNeve, gyVHatarozatSzama, gyVervenyes, hhVAGYhhh, ervenyes, csoport);

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
                Environment.Exit(0);
            }
        }
        private void copyAlltoClipboard()
        {
            dataGridView1.SelectAll();
            DataObject dataObj = dataGridView1.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }
        private void copyAlltoClipboard2()
        {
            dataGridView2.SelectAll();
            DataObject dataObj = dataGridView2.GetClipboardContent();
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
            dataGridView1.Columns.Add("Neme", "Neme");
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
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    string azon = rdr.GetString(0);
                    string nev = rdr.GetString(1);
                    string szuletesiIdo = rdr.GetString(2);
                    string omAzon = rdr.GetString(3);
                    string anyjaNeve = rdr.GetString(4);
                    string gyVHatarozatSzama = rdr.GetString(5);
                    string gyVervenyes = rdr.GetString(6);
                    string hhVAGYhhh = rdr.GetString(7);
                    string ervenyes = rdr.GetString(8);
                    string csoport = rdr.GetString(9);
                    string neme = rdr.GetString(10);
                    dataGridView1.Rows.Add(azon, nev, neme, szuletesiIdo, omAzon, anyjaNeve, gyVHatarozatSzama, gyVervenyes, hhVAGYhhh, ervenyes, csoport);

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

        private void button4_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            button4.Visible = false;
            statisztika_ComboBox.SelectedIndex = 0;
            statisztika_ComboBox2.SelectedIndex = 0;
            Program.form_kimutatas.Text = "Statisztika";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button4.Visible = true;
            groupBox1.Visible = false;
            Program.form_kimutatas.Text = "Kimutatás";
        }

        private void statisztika_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (statisztika_ComboBox.SelectedItem.ToString() == "Összes")
            {
                dataGridView2.Columns.Clear();
                dataGridView2.Rows.Clear();
                dataGridView2.AutoResizeColumns();
                if (statisztika_ComboBox2.SelectedIndex == 0)
                {
                    int fiu = 0;
                    int lany = 0;
                    dataGridView2.Columns.Add("Fiú", "Fiú");
                    dataGridView2.Columns.Add("Lány", "Lány");
                    sql = "SELECT neme FROM gyermekek";
                    using (var cmd = new MySqlCommand(sql, Program.conn))
                    {
                        MySqlDataReader rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {
                            if (rdr.GetString(0) == "lány")
                            {
                                lany++;
                            }
                            else if (rdr.GetString(0) == "fiú")
                            {
                                fiu++;
                            }
                        }

                    }
                    dataGridView2.Rows.Add(fiu, lany);
                    dataGridView2.AutoResizeColumns();
                    dataGridView2.AutoResizeRows();
                }
                if (statisztika_ComboBox2.SelectedIndex == 1)
                {
                    int gyv = 0;
                    int hh = 0;
                    int hhh = 0;
                    dataGridView2.Columns.Add("GyV", "GyV");
                    dataGridView2.Columns.Add("HH", "HH");
                    dataGridView2.Columns.Add("HHH", "HHH");
                    sql = "SELECT gyV, hhvagyhhh FROM gyermekek";
                    using (var cmd = new MySqlCommand(sql, Program.conn))
                    {
                        MySqlDataReader rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {
                            if (rdr.GetString(0) != "nincs")
                            {
                                gyv++;
                            }
                            if (rdr.GetString(1) == "HH")
                            {
                                hh++;
                            }
                            else if (rdr.GetString(1) == "HHH")
                            {
                                hhh++;
                            }
                        }

                    }
                    dataGridView2.Rows.Add(gyv, hh, hhh);
                    dataGridView2.AutoResizeColumns();
                    dataGridView2.AutoResizeRows();
                }
            }
            if (statisztika_ComboBox.SelectedItem.ToString() == "Csoportonként")
            {
                dataGridView2.Columns.Clear();
                dataGridView2.Rows.Clear();
                dataGridView2.AutoResizeColumns();
                adatok.Clear();
                if (statisztika_ComboBox2.SelectedIndex == 0)
                {
                    int fiu = 0;
                    int lany = 0;
                    int gyv = 0;
                    int hh = 0;
                    int hhh = 0;
                    dataGridView2.Columns.Add("Csoport", "Csoport");
                    dataGridView2.Columns.Add("Fiú", "Fiú");
                    dataGridView2.Columns.Add("Lány", "Lány");
                    sql = "SELECT csoportNeve FROM csoportok";
                    List<string> csoportok = new List<string>();
                    using (var cmd = new MySqlCommand(sql, Program.conn))
                    {
                        MySqlDataReader rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {
                            csoportok.Add(rdr.GetString(0));
                        }
                        dataGridView2.AutoResizeColumns();
                        dataGridView2.AutoResizeRows();
                    }

                    foreach (var item in csoportok)
                    {
                        sql = "SELECT neme,gyV,hhvagyhhh FROM gyermekek WHERE csoport ='" + item + "'";
                        using (var cmd2 = new MySqlCommand(sql, Program.conn))
                        {
                            MySqlDataReader rdr2 = cmd2.ExecuteReader();
                            while (rdr2.Read())
                            {
                                if (rdr2.GetString(0) == "lány")
                                {
                                    lany++;
                                }
                                else if (rdr2.GetString(0) == "fiú")
                                {
                                    fiu++;
                                }
                                if (rdr2.GetString(1) != "nincs")
                                {
                                    gyv++;
                                }
                                if (rdr2.GetString(2) == "HH")
                                {
                                    hh++;
                                }
                                else if (rdr2.GetString(2) == "HHH")
                                {
                                    hhh++;
                                }

                            }

                            csoportfiulanygyvhhvhhh uj = new csoportfiulanygyvhhvhhh(item, fiu, lany, gyv, hh, hhh);
                            adatok.Add(uj);
                            lany = 0;
                            fiu = 0;
                            gyv = 0;
                            hh = 0;
                            hhh = 0;
                        }
                    }
                    foreach (var item in adatok)
                    {
                        dataGridView2.Rows.Add(item.csoportnev, item.fiu, item.lany);
                    }

                }
                if (statisztika_ComboBox2.SelectedIndex == 1)
                {
                    int fiu = 0;
                    int lany = 0;
                    int gyv = 0;
                    int hh = 0;
                    int hhh = 0;
                    dataGridView2.Columns.Add("Csoport", "Csoport");
                    dataGridView2.Columns.Add("GyV", "GyV");
                    dataGridView2.Columns.Add("HH", "HH");
                    dataGridView2.Columns.Add("HHH", "HHH");
                    sql = "SELECT csoportNeve FROM csoportok";
                    List<string> csoportok = new List<string>();
                    using (var cmd = new MySqlCommand(sql, Program.conn))
                    {
                        MySqlDataReader rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {
                            csoportok.Add(rdr.GetString(0));
                        }
                        dataGridView2.AutoResizeColumns();
                        dataGridView2.AutoResizeRows();
                    }

                    foreach (var item in csoportok)
                    {
                        sql = "SELECT neme,gyV,hhvagyhhh FROM gyermekek WHERE csoport ='" + item + "'";
                        using (var cmd2 = new MySqlCommand(sql, Program.conn))
                        {
                            MySqlDataReader rdr2 = cmd2.ExecuteReader();
                            while (rdr2.Read())
                            {
                                if (rdr2.GetString(0) == "lány")
                                {
                                    lany++;
                                }
                                else if (rdr2.GetString(0) == "fiú")
                                {
                                    fiu++;
                                }
                                if (rdr2.GetString(1) != "nincs")
                                {
                                    gyv++;
                                }
                                if (rdr2.GetString(2) == "HH")
                                {
                                    hh++;
                                }
                                else if (rdr2.GetString(2) == "HHH")
                                {
                                    hhh++;
                                }

                            }

                            csoportfiulanygyvhhvhhh uj = new csoportfiulanygyvhhvhhh(item, fiu, lany, gyv, hh, hhh);
                            adatok.Add(uj);
                            lany = 0;
                            fiu = 0;
                            gyv = 0;
                            hh = 0;
                            hhh = 0;
                        }
                    }
                    foreach (var item in adatok)
                    {
                        dataGridView2.Rows.Add(item.csoportnev, item.gyv, item.hh, item.hhh);
                    }

                }
            }
            if (statisztika_ComboBox.SelectedItem.ToString() == "Telephelyenként")
            {
                adatok2.Clear();
                dataGridView2.Columns.Clear();
                dataGridView2.Rows.Clear();
                dataGridView2.AutoResizeColumns();

                if (statisztika_ComboBox2.SelectedIndex == 0)
                {
                    int fiu = 0;
                    int lany = 0;
                    int gyv = 0;
                    int hh = 0;
                    int hhh = 0;
                    dataGridView2.Columns.Add("Telephely", "Telephely");
                    dataGridView2.Columns.Add("Fiú", "Fiú");
                    dataGridView2.Columns.Add("Lány", "Lány");
                    sql = "SELECT telephelyEk FROM intezmeny";
                    string tp = "";
                    using (var cmd = new MySqlCommand(sql, Program.conn))
                    {
                        MySqlDataReader rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {
                            tp = rdr.GetString(0);
                        }
                        string[] telephelyek = tp.Split(',');
                        dataGridView2.AutoResizeColumns();
                        dataGridView2.AutoResizeRows();

                        List<string> Lista = new List<string>();
                        foreach (var item in telephelyek)
                        {
                            if (item.ToString().Length > 0)
                            {
                                Lista.Add(item.ToString());
                            }
                        }
                        foreach (var item in Lista)
                        {
                            if (item != " ")
                            {
                                telephely uj = new telephely(item, 0, 0, 0, 0, 0);
                                adatok2.Add(uj);
                            }
                        }
                    }
                    sql = "SELECT csoportNeve FROM csoportok";
                    List<string> csoportok = new List<string>();
                    using (var cmd = new MySqlCommand(sql, Program.conn))
                    {
                        MySqlDataReader rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {
                            csoportok.Add(rdr.GetString(0));
                        }
                        dataGridView2.AutoResizeColumns();
                        dataGridView2.AutoResizeRows();
                    }
                    adatok.Clear();
                    foreach (var item in csoportok)
                    {
                        sql = "SELECT neme,gyV,hhvagyhhh FROM gyermekek WHERE csoport ='" + item + "'";
                        using (var cmd2 = new MySqlCommand(sql, Program.conn))
                        {
                            MySqlDataReader rdr2 = cmd2.ExecuteReader();
                            while (rdr2.Read())
                            {
                                if (rdr2.GetString(0) == "lány")
                                {
                                    lany++;
                                }
                                else if (rdr2.GetString(0) == "fiú")
                                {
                                    fiu++;
                                }
                                if (rdr2.GetString(1) != "nincs")
                                {
                                    gyv++;
                                }
                                if (rdr2.GetString(2) == "HH")
                                {
                                    hh++;
                                }
                                else if (rdr2.GetString(2) == "HHH")
                                {
                                    hhh++;
                                }

                            }
                            csoportfiulanygyvhhvhhh uj = new csoportfiulanygyvhhvhhh(item, fiu, lany, gyv, hh, hhh);
                            adatok.Add(uj);
                            lany = 0;
                            fiu = 0;
                            gyv = 0;
                            hh = 0;
                            hhh = 0;
                        }
                    }
                    foreach (var item in adatok)
                    {
                        sql = "SELECT csoportNeve,telephely FROM csoportok";
                        using (var cmd = new MySqlCommand(sql, Program.conn))
                        {
                            MySqlDataReader rdr = cmd.ExecuteReader();
                            while (rdr.Read())
                            {
                                if (item.csoportnev == rdr.GetString(0))
                                {
                                    foreach (var t in adatok2)
                                    {
                                        if (t.telephelyneve == rdr.GetString(1))
                                        {
                                            t.fiu += item.fiu;
                                            t.lany += item.lany;
                                            t.gyv += item.gyv;
                                            t.hh += item.hh;
                                            t.hhh += item.hhh;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    foreach (var item in adatok2)
                    {
                        dataGridView2.Rows.Add(item.telephelyneve, item.fiu, item.lany);
                    }
                }
                if (statisztika_ComboBox2.SelectedIndex == 1)
                {
                    int fiu = 0;
                    int lany = 0;
                    int gyv = 0;
                    int hh = 0;
                    int hhh = 0;
                    dataGridView2.Columns.Add("Telephely", "Telephely");
                    dataGridView2.Columns.Add("GyV", "GyV");
                    dataGridView2.Columns.Add("HH", "HH");
                    dataGridView2.Columns.Add("HHH", "HHH");
                    sql = "SELECT telephelyEk FROM intezmeny";
                    string tp = "";
                    using (var cmd = new MySqlCommand(sql, Program.conn))
                    {
                        MySqlDataReader rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {
                            tp = rdr.GetString(0);
                        }
                        string[] telephelyek = tp.Split(',');
                        dataGridView2.AutoResizeColumns();
                        dataGridView2.AutoResizeRows();

                        List<string> Lista = new List<string>();
                        foreach (var item in telephelyek)
                        {
                            if (item.ToString().Length > 0)
                            {
                                Lista.Add(item.ToString());
                            }
                        }
                        foreach (var item in Lista)
                        {
                            if (item != " ")
                            {
                                telephely uj = new telephely(item, 0, 0, 0, 0, 0);
                                adatok2.Add(uj);
                            }
                        }
                    }
                    sql = "SELECT csoportNeve FROM csoportok";
                    List<string> csoportok = new List<string>();
                    using (var cmd = new MySqlCommand(sql, Program.conn))
                    {
                        MySqlDataReader rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {
                            csoportok.Add(rdr.GetString(0));
                        }
                        dataGridView2.AutoResizeColumns();
                        dataGridView2.AutoResizeRows();
                    }
                    adatok.Clear();
                    foreach (var item in csoportok)
                    {
                        sql = "SELECT neme,gyV,hhvagyhhh FROM gyermekek WHERE csoport ='" + item + "'";
                        using (var cmd2 = new MySqlCommand(sql, Program.conn))
                        {
                            MySqlDataReader rdr2 = cmd2.ExecuteReader();
                            while (rdr2.Read())
                            {
                                if (rdr2.GetString(0) == "lány")
                                {
                                    lany++;
                                }
                                else if (rdr2.GetString(0) == "fiú")
                                {
                                    fiu++;
                                }
                                if (rdr2.GetString(1) != "nincs")
                                {
                                    gyv++;
                                }
                                if (rdr2.GetString(2) == "HH")
                                {
                                    hh++;
                                }
                                else if (rdr2.GetString(2) == "HHH")
                                {
                                    hhh++;
                                }

                            }
                            csoportfiulanygyvhhvhhh uj = new csoportfiulanygyvhhvhhh(item, fiu, lany, gyv, hh, hhh);
                            adatok.Add(uj);
                            lany = 0;
                            fiu = 0;
                            gyv = 0;
                            hh = 0;
                            hhh = 0;
                        }
                    }
                    foreach (var item in adatok)
                    {
                        sql = "SELECT csoportNeve,telephely FROM csoportok";
                        using (var cmd = new MySqlCommand(sql, Program.conn))
                        {
                            MySqlDataReader rdr = cmd.ExecuteReader();
                            while (rdr.Read())
                            {
                                if (item.csoportnev == rdr.GetString(0))
                                {
                                    foreach (var t in adatok2)
                                    {
                                        if (t.telephelyneve == rdr.GetString(1))
                                        {
                                            t.fiu += item.fiu;
                                            t.lany += item.lany;
                                            t.gyv += item.gyv;
                                            t.hh += item.hh;
                                            t.hhh += item.hhh;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    foreach (var item in adatok2)
                    {
                        dataGridView2.Rows.Add(item.telephelyneve, item.gyv, item.hh, item.hhh);
                    }
                }
            }
        }
        class csoportfiulanygyvhhvhhh
        {
            public string csoportnev;
            public int fiu;
            public int lany;
            public int gyv;
            public int hh;
            public int hhh;

            public csoportfiulanygyvhhvhhh(string csoportnev, int fiu, int lany, int gyv, int hh, int hhh)
            {
                this.csoportnev = csoportnev;
                this.fiu = fiu;
                this.lany = lany;
                this.gyv = gyv;
                this.hh = hh;
                this.hhh = hhh;
            }
        }
        List<csoportfiulanygyvhhvhhh> adatok = new List<csoportfiulanygyvhhvhhh>();
        List<telephely> adatok2 = new List<telephely>();
        class telephely
        {
            public string telephelyneve;
            public int fiu;
            public int lany;
            public int gyv;
            public int hh;
            public int hhh;

            public telephely(string telephelyneve, int fiu, int lany, int gyv, int hh, int hhh)
            {
                this.telephelyneve = telephelyneve;
                this.fiu = fiu;
                this.lany = lany;
                this.gyv = gyv;
                this.hh = hh;
                this.hhh = hhh;
            }
        }
        private void statisztika_ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (statisztika_ComboBox.SelectedItem.ToString() == "Összes")
            {
                dataGridView2.Columns.Clear();
                dataGridView2.Rows.Clear();
                dataGridView2.AutoResizeColumns();
                if (statisztika_ComboBox2.SelectedIndex == 0)
                {
                    int fiu = 0;
                    int lany = 0;
                    dataGridView2.Columns.Add("Fiú", "Fiú");
                    dataGridView2.Columns.Add("Lány", "Lány");
                    sql = "SELECT neme FROM gyermekek";
                    using (var cmd = new MySqlCommand(sql, Program.conn))
                    {
                        MySqlDataReader rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {
                            if (rdr.GetString(0) == "lány")
                            {
                                lany++;
                            }
                            else if (rdr.GetString(0) == "fiú")
                            {
                                fiu++;
                            }
                        }

                    }
                    dataGridView2.Rows.Add(fiu, lany);
                    dataGridView2.AutoResizeColumns();
                    dataGridView2.AutoResizeRows();
                }
                if (statisztika_ComboBox2.SelectedIndex == 1)
                {
                    int gyv = 0;
                    int hh = 0;
                    int hhh = 0;
                    dataGridView2.Columns.Add("GyV", "GyV");
                    dataGridView2.Columns.Add("HH", "HH");
                    dataGridView2.Columns.Add("HHH", "HHH");
                    sql = "SELECT gyV, hhvagyhhh FROM gyermekek";
                    using (var cmd = new MySqlCommand(sql, Program.conn))
                    {
                        MySqlDataReader rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {
                            if (rdr.GetString(0) != "nincs")
                            {
                                gyv++;
                            }
                            if (rdr.GetString(1) == "HH")
                            {
                                hh++;
                            }
                            else if (rdr.GetString(1) == "HHH")
                            {
                                hhh++;
                            }
                        }

                    }
                    dataGridView2.Rows.Add(gyv, hh, hhh);
                    dataGridView2.AutoResizeColumns();
                    dataGridView2.AutoResizeRows();
                }
            }
            if (statisztika_ComboBox.SelectedItem.ToString() == "Csoportonként")
            {
                dataGridView2.Columns.Clear();
                dataGridView2.Rows.Clear();
                dataGridView2.AutoResizeColumns();
                adatok.Clear();
                if (statisztika_ComboBox2.SelectedIndex == 0)
                {
                    int fiu = 0;
                    int lany = 0;
                    int gyv = 0;
                    int hh = 0;
                    int hhh = 0;
                    dataGridView2.Columns.Add("Csoport", "Csoport");
                    dataGridView2.Columns.Add("Fiú", "Fiú");
                    dataGridView2.Columns.Add("Lány", "Lány");
                    sql = "SELECT csoportNeve FROM csoportok";
                    List<string> csoportok = new List<string>();
                    using (var cmd = new MySqlCommand(sql, Program.conn))
                    {
                        MySqlDataReader rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {
                            csoportok.Add(rdr.GetString(0));
                        }
                        dataGridView2.AutoResizeColumns();
                        dataGridView2.AutoResizeRows();
                    }

                    foreach (var item in csoportok)
                    {
                        sql = "SELECT neme,gyV,hhvagyhhh FROM gyermekek WHERE csoport ='" + item + "'";
                        using (var cmd2 = new MySqlCommand(sql, Program.conn))
                        {
                            MySqlDataReader rdr2 = cmd2.ExecuteReader();
                            while (rdr2.Read())
                            {
                                if (rdr2.GetString(0) == "lány")
                                {
                                    lany++;
                                }
                                else if (rdr2.GetString(0) == "fiú")
                                {
                                    fiu++;
                                }
                                if (rdr2.GetString(1) != "nincs")
                                {
                                    gyv++;
                                }
                                if (rdr2.GetString(2) == "HH")
                                {
                                    hh++;
                                }
                                else if (rdr2.GetString(2) == "HHH")
                                {
                                    hhh++;
                                }

                            }

                            csoportfiulanygyvhhvhhh uj = new csoportfiulanygyvhhvhhh(item,fiu,lany,gyv,hh,hhh);
                            adatok.Add(uj);
                            lany = 0;
                            fiu = 0;
                            gyv = 0;
                            hh = 0;
                            hhh = 0;
                        }
                    }
                    foreach (var item in adatok)
                    {
                        dataGridView2.Rows.Add(item.csoportnev, item.fiu, item.lany);
                    }

                }
                if (statisztika_ComboBox2.SelectedIndex == 1)
                {
                    int fiu = 0;
                    int lany = 0;
                    int gyv = 0;
                    int hh = 0;
                    int hhh = 0;
                    dataGridView2.Columns.Add("Csoport", "Csoport");
                    dataGridView2.Columns.Add("GyV", "GyV");
                    dataGridView2.Columns.Add("HH", "HH");
                    dataGridView2.Columns.Add("HHH", "HHH");
                    sql = "SELECT csoportNeve FROM csoportok";
                    List<string> csoportok = new List<string>();
                    using (var cmd = new MySqlCommand(sql, Program.conn))
                    {
                        MySqlDataReader rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {
                            csoportok.Add(rdr.GetString(0));
                        }
                        dataGridView2.AutoResizeColumns();
                        dataGridView2.AutoResizeRows();
                    }

                    foreach (var item in csoportok)
                    {
                        sql = "SELECT neme,gyV,hhvagyhhh FROM gyermekek WHERE csoport ='" + item + "'";
                        using (var cmd2 = new MySqlCommand(sql, Program.conn))
                        {
                            MySqlDataReader rdr2 = cmd2.ExecuteReader();
                            while (rdr2.Read())
                            {
                                if (rdr2.GetString(0) == "lány")
                                {
                                    lany++;
                                }
                                else if (rdr2.GetString(0) == "fiú")
                                {
                                    fiu++;
                                }
                                if (rdr2.GetString(1) != "nincs")
                                {
                                    gyv++;
                                }
                                if (rdr2.GetString(2) == "HH")
                                {
                                    hh++;
                                }
                                else if (rdr2.GetString(2) == "HHH")
                                {
                                    hhh++;
                                }

                            }

                            csoportfiulanygyvhhvhhh uj = new csoportfiulanygyvhhvhhh(item, fiu, lany, gyv, hh, hhh);
                            adatok.Add(uj);
                            lany = 0;
                            fiu = 0;
                            gyv = 0;
                            hh = 0;
                            hhh = 0;
                        }
                    }
                    foreach (var item in adatok)
                    {
                        dataGridView2.Rows.Add(item.csoportnev, item.gyv, item.hh,item.hhh);
                    }

                }
            }
            if (statisztika_ComboBox.SelectedItem.ToString() == "Telephelyenként")
            {
                adatok2.Clear();
                dataGridView2.Columns.Clear();
                dataGridView2.Rows.Clear();
                dataGridView2.AutoResizeColumns();

                if (statisztika_ComboBox2.SelectedIndex == 0)
                {
                    int fiu = 0;
                    int lany = 0;
                    int gyv = 0;
                    int hh = 0;
                    int hhh = 0;
                    dataGridView2.Columns.Add("Telephely", "Telephely");
                    dataGridView2.Columns.Add("Fiú", "Fiú");
                    dataGridView2.Columns.Add("Lány", "Lány");
                    sql = "SELECT telephelyEk FROM intezmeny";
                    string tp = "";
                    using (var cmd = new MySqlCommand(sql, Program.conn))
                    {
                        MySqlDataReader rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {
                            tp = rdr.GetString(0);
                        }
                        string[] telephelyek = tp.Split(',');
                        dataGridView2.AutoResizeColumns();
                        dataGridView2.AutoResizeRows();

                        List<string> Lista = new List<string>();
                        foreach (var item in telephelyek)
                        {
                            if (item.ToString().Length > 0)
                            {
                                Lista.Add(item.ToString());
                            }
                        }
                        foreach (var item in Lista)
                        {
                            if (item != " ")
                            {
                                telephely uj = new telephely(item, 0, 0, 0, 0, 0);
                                adatok2.Add(uj);
                            }
                        }
                    }
                    sql = "SELECT csoportNeve FROM csoportok";
                    List<string> csoportok = new List<string>();
                    using (var cmd = new MySqlCommand(sql, Program.conn))
                    {
                        MySqlDataReader rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {
                            csoportok.Add(rdr.GetString(0));
                        }
                        dataGridView2.AutoResizeColumns();
                        dataGridView2.AutoResizeRows();
                    }
                    adatok.Clear();
                    foreach (var item in csoportok)
                    {
                        sql = "SELECT neme,gyV,hhvagyhhh FROM gyermekek WHERE csoport ='" + item + "'";
                        using (var cmd2 = new MySqlCommand(sql, Program.conn))
                        {
                            MySqlDataReader rdr2 = cmd2.ExecuteReader();
                            while (rdr2.Read())
                            {
                                if (rdr2.GetString(0) == "lány")
                                {
                                    lany++;
                                }
                                else if (rdr2.GetString(0) == "fiú")
                                {
                                    fiu++;
                                }
                                if (rdr2.GetString(1) != "nincs")
                                {
                                    gyv++;
                                }
                                if (rdr2.GetString(2) == "HH")
                                {
                                    hh++;
                                }
                                else if (rdr2.GetString(2) == "HHH")
                                {
                                    hhh++;
                                }

                            }
                            csoportfiulanygyvhhvhhh uj = new csoportfiulanygyvhhvhhh(item, fiu, lany, gyv, hh, hhh);
                            adatok.Add(uj);
                            lany = 0;
                            fiu = 0;
                            gyv = 0;
                            hh = 0;
                            hhh = 0;
                        }
                    }
                    foreach (var item in adatok)
                    {
                        sql = "SELECT csoportNeve,telephely FROM csoportok";
                        using (var cmd = new MySqlCommand(sql, Program.conn))
                        {
                            MySqlDataReader rdr = cmd.ExecuteReader();
                            while (rdr.Read())
                            {
                                if (item.csoportnev == rdr.GetString(0))
                                {
                                    foreach (var t in adatok2)
                                    {
                                        if (t.telephelyneve == rdr.GetString(1))
                                        {
                                            t.fiu += item.fiu;
                                            t.lany += item.lany;
                                            t.gyv += item.gyv;
                                            t.hh += item.hh;
                                            t.hhh += item.hhh;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    foreach (var item in adatok2)
                    {
                        dataGridView2.Rows.Add(item.telephelyneve, item.fiu, item.lany);
                    }
                }
                if (statisztika_ComboBox2.SelectedIndex == 1)
                {
                    int fiu = 0;
                    int lany = 0;
                    int gyv = 0;
                    int hh = 0;
                    int hhh = 0;
                    dataGridView2.Columns.Add("Telephely", "Telephely");
                    dataGridView2.Columns.Add("GyV", "GyV");
                    dataGridView2.Columns.Add("HH", "HH");
                    dataGridView2.Columns.Add("HHH", "HHH");
                    sql = "SELECT telephelyEk FROM intezmeny";
                    string tp = "";
                    using (var cmd = new MySqlCommand(sql, Program.conn))
                    {
                        MySqlDataReader rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {
                            tp = rdr.GetString(0);
                        }
                        string[] telephelyek = tp.Split(',');
                        dataGridView2.AutoResizeColumns();
                        dataGridView2.AutoResizeRows();

                        List<string> Lista = new List<string>();
                        foreach (var item in telephelyek)
                        {
                            if (item.ToString().Length > 0)
                            {
                                Lista.Add(item.ToString());
                            }
                        }
                        foreach (var item in Lista)
                        {
                            if (item != " ")
                            {
                                telephely uj = new telephely(item, 0, 0, 0, 0, 0);
                                adatok2.Add(uj);
                            }
                        }
                    }
                    sql = "SELECT csoportNeve FROM csoportok";
                    List<string> csoportok = new List<string>();
                    using (var cmd = new MySqlCommand(sql, Program.conn))
                    {
                        MySqlDataReader rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {
                            csoportok.Add(rdr.GetString(0));
                        }
                        dataGridView2.AutoResizeColumns();
                        dataGridView2.AutoResizeRows();
                    }
                    adatok.Clear();
                    foreach (var item in csoportok)
                    {
                        sql = "SELECT neme,gyV,hhvagyhhh FROM gyermekek WHERE csoport ='" + item + "'";
                        using (var cmd2 = new MySqlCommand(sql, Program.conn))
                        {
                            MySqlDataReader rdr2 = cmd2.ExecuteReader();
                            while (rdr2.Read())
                            {
                                if (rdr2.GetString(0) == "lány")
                                {
                                    lany++;
                                }
                                else if (rdr2.GetString(0) == "fiú")
                                {
                                    fiu++;
                                }
                                if (rdr2.GetString(1) != "nincs")
                                {
                                    gyv++;
                                }
                                if (rdr2.GetString(2) == "HH")
                                {
                                    hh++;
                                }
                                else if (rdr2.GetString(2) == "HHH")
                                {
                                    hhh++;
                                }

                            }
                            csoportfiulanygyvhhvhhh uj = new csoportfiulanygyvhhvhhh(item, fiu, lany, gyv, hh, hhh);
                            adatok.Add(uj);
                            lany = 0;
                            fiu = 0;
                            gyv = 0;
                            hh = 0;
                            hhh = 0;
                        }
                    }
                    foreach (var item in adatok)
                    {
                        sql = "SELECT csoportNeve,telephely FROM csoportok";
                        using (var cmd = new MySqlCommand(sql, Program.conn))
                        {
                            MySqlDataReader rdr = cmd.ExecuteReader();
                            while (rdr.Read())
                            {
                                if (item.csoportnev == rdr.GetString(0))
                                {
                                    foreach (var t in adatok2)
                                    {
                                        if (t.telephelyneve == rdr.GetString(1))
                                        {
                                            t.fiu += item.fiu;
                                            t.lany += item.lany;
                                            t.gyv += item.gyv;
                                            t.hh += item.hh;
                                            t.hhh += item.hhh;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    foreach (var item in adatok2)
                    {
                        dataGridView2.Rows.Add(item.telephelyneve, item.gyv, item.hh,item.hhh);
                    }
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            copyAlltoClipboard2();
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
    }
}
