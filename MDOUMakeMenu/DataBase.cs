using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace MDOUMakeMenu
{
    class DataBase
    {
        static MySqlConnection msConnect;
        public static MySqlCommand msCommand;
        static MySqlDataAdapter msDataAdapter;
        public static string User = "root";
        public static string PassWord = "qwerty";
        private static string localConnectionString = @"Database = mdou_menu;
                                         Data Source = LocalHost;
                                         User = " + User + @";
                                         Password = " + PassWord + ";";

        static public bool Connect()
        {
            try
            {
                msConnect = new MySqlConnection(localConnectionString);
                msConnect.Open();
                msCommand = new MySqlCommand();
                msCommand.Connection = msConnect;
                msDataAdapter = new MySqlDataAdapter(msCommand);

                return true;
            }
            catch (Exception EX)
            {
                System.Windows.Forms.MessageBox.Show(EX.ToString(), "Ошибка");
                return false;
            }
        }

        static public void Close()
        {
            msConnect.Close();
        }
    }

    class DataTable : DataBase
    {

    }
}
