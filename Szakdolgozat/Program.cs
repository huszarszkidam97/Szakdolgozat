using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Szakdolgozat
{
    static public class Program
    {
        public static MySqlConnection conn = null;
        public static MySqlCommand sqlCommand = null;
        public static Form form_nyito = null;
        public static Form form_intezmenyek = null;
        public static Form form_csoportok = null;
        public static Form form_felvétele = null;
        public static Form form_kimutatas = null;
        public static Form form_gyermekKeres = null;
        public static Form form_szerkeszt = null;
        public static Form csoport_szerkeszt = null;
        public static Form intezmenyszerkeszt = null;


        [STAThread]
        static void Main()
       {

            MySqlConnectionStringBuilder sb = null;
            sb = new MySqlConnectionStringBuilder();
            sb.Server = "localhost";
            sb.UserID = "root";
            sb.Password = "";
            sb.Database = "ovodanyilvantartas";
            sb.CharacterSet = "utf8";
            conn = new MySqlConnection(sb.ToString());
            try
            {
                conn.Open();
                sqlCommand = conn.CreateCommand();
            }
            catch (MySqlException es)
            {
                MessageBox.Show(es.Message);
                Environment.Exit(0);
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            form_nyito = new Form1();
            form_intezmenyek = new intezmeny();
            form_csoportok = new csoportok();
            form_felvétele = new gyermekfelvetele();
            form_kimutatas = new Kimutatás();
            form_gyermekKeres = new gyermekKeres();
            form_szerkeszt = new Szerkeszt();
            csoport_szerkeszt = new csoport_szerkesztés();
            intezmenyszerkeszt = new intezmenyszerkeszt();
            Application.Run(form_nyito);
        }
    }
}
