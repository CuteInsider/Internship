﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace MDOUMakeMenu
{
    class DataBase
    {
        protected static MySqlConnection msConnect;
        protected static MySqlCommand msCommand;
        protected static MySqlDataAdapter msDataAdapter;
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
                if (msConnect.State == ConnectionState.Closed)
                {
                    msConnect.Open();
                    msCommand = new MySqlCommand
                    {
                        Connection = msConnect
                    };
                    msDataAdapter = new MySqlDataAdapter(msCommand);
                }
                return true;
            }
            catch (Exception EX)
            {
                System.Windows.Forms.MessageBox.Show(EX.ToString(), "Ошибка");
                return false;
            }
        }

        static public bool BackUp(string file)
        {
            using (MySqlBackup backUp = new MySqlBackup(msCommand))
            {
                backUp.ExportToFile(file);
                return true;
            }
        }

        static public bool Restore(string file)
        {
            using (MySqlBackup restore = new MySqlBackup(msCommand))
            {
                restore.ImportFromFile(file);
                return true;
            }
        }

        static public void Close()
        {
            if (msConnect.State == ConnectionState.Open && msConnect != null)
            {
                msConnect.Close();
            }
        }
    }

    class Table : DataBase
    {
        public DataTable DBTable;

        //~Table()
        //{
        //    try
        //    {
        //        if (DBTable != null)
        //            DBTable.Dispose();
        //    }
        //}

        public DataTable newTable(string Query)
        {
            if (Query.StartsWith("SELECT"))
            {
                DBTable = new DataTable();
                msCommand.CommandText = Query;
                DBTable.Clear();
                msDataAdapter.Fill(DBTable);
                return DBTable;
            }
            else
                return null;
        }

        public object Query(string Query)
        {
            try
            {
                msCommand.CommandText = Query;
                if (Query.StartsWith("SELECT"))
                    return msCommand.ExecuteScalar();
                if (Query.StartsWith("INSERT"))
                    return msCommand.ExecuteNonQuery();
                if (Query.StartsWith("UPDATE"))
                    return msCommand.ExecuteNonQuery();
                if (Query.StartsWith("DELETE"))
                    return msCommand.ExecuteNonQuery();
            }
            catch (Exception EX)
            {
                System.Windows.Forms.MessageBox.Show(EX.ToString(), "Ошибка");
            }
            return false;
        }

        //TODO: Генератор запросов
        //public void Query(string QueryType, params string[][] Fields)
        //{
        //    switch (QueryType)
        //    {
        //        case "SELECT":
        //            msCommand.CommandText = "SELECT ";
        //            for (int i = 0; i < Fields[0].Length; i++)
        //            {
        //                msCommand.CommandText += Fields[0][i];
        //                if (Fields[0][i] != Fields[0].Last())
        //                    msCommand.CommandText += ", ";
        //            }
        //            msCommand.CommandText += " FROM ";
        //            for (int i = 0; i < Fields[1].Length; i++)
        //            {
        //                msCommand.CommandText += Fields[1][i];
        //                if (Fields[1][i] != Fields[1].Last())
        //                    msCommand.CommandText += ", ";
        //            }
        //            break;

        //        case "MULTYSELECT":
        //            break;

        //        case "INSERT":
        //            msCommand.CommandText = "INSERT INTO " + Fields[1][0] + " VALUES(";
        //            for (int i = 0; i < Fields[2].Length; i++)
        //            {
        //                if (Int32.TryParse(Fields[2][i], out int parsed))
        //                    msCommand.CommandText += Fields[2][i];
        //                else
        //                    msCommand.CommandText += "'"+Fields[2][i]+"'";
        //                if (Fields[2][i] != Fields[2].Last())
        //                    msCommand.CommandText += ", ";
        //                else
        //                    msCommand.CommandText += ")";
        //            }
        //            break;

        //        case "UPDATE":
        //            msCommand.CommandText = "UPDATE " + Fields[1][0] + " SET ";
        //            for (int i = 0; i < Fields[0].Length; i++)
        //            {
        //                if (Int32.TryParse(Fields[2][i], out int parsed))
        //                    msCommand.CommandText += Fields[0][i] + "= " + parsed;
        //                else
        //                    msCommand.CommandText += Fields[0][i] + "= '" + Fields[2][i] + "'";
        //                if (Fields[0][i] != Fields[0].Last())
        //                    msCommand.CommandText += ", ";
        //            }
        //            break;

        //        case "DELETE":
        //            msCommand.CommandText = "DELETE FROM " + Fields[0][0] + " ";
        //            break;
        //    }
        //    if (Fields[4] != null && QueryType != "INSERT")
        //    {
        //        msCommand.CommandText += " WHERE  ";
        //        for (int i = 0; i < Fields[4].Length; i++)
        //        {
        //            msCommand.CommandText += Fields[4][i];
        //            if (Fields[4][i] != Fields[4].Last())
        //                msCommand.CommandText += " AND ";
        //        }
        //    }
        //    msCommand.CommandText += ";";
        //    System.Windows.Forms.MessageBox.Show(msCommand.CommandText, "Сообщение");
        //    //msCommand.ExecuteNonQuery();
        //}
    }
}
