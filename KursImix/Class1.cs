using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursImix
{
    internal class Class1
    {

        private string connectionString = "Data Source=databaseCompany.db;";
        public int GetLogFromBD(string login,string password)
        {

                bool isCorrect = false;
                SQLiteConnection connection = new SQLiteConnection(connectionString);
                connection.Open();
                string sql = $"SELECT * FROM logging WHERE login='{login}' ";

                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {

                    // Выполнение запроса

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            if (password == reader.GetString(1)) isCorrect = true;

                        }
                        else
                        {
                            connection.Close();
                            return 1;
                        }
                    }


                }
                connection.Close();
                if (isCorrect) return 0;
                else return 2;

        }
        public List<String[]> GetAutos()
        {
            List<String[]> autos = new List<String[]>();

            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();
            string sql = $"SELECT * FROM ts";
            // Создание объекта SQLiteCommand
            using (SQLiteCommand command = new SQLiteCommand(sql, connection))
            {


                // Выполнение запроса
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    // Обработка результата запроса
                    while (reader.Read())
                    {
                        String[] s = new String[3];
                        s[0] = reader.GetString(2);
                        s[1] = reader.GetString(3);
                        s[2] = reader.GetInt32(0).ToString();
                        autos.Add(s);

                    }
                }
            }
            connection.Close(); 
            return autos;
        }
        public List<String[]> GetAllOrders(int id)
        {
            List<String[]> ords = new List<String[]>();

            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();
            string sql = $"SELECT * FROM orders Where id_auto={id}";
            // Создание объекта SQLiteCommand
            using (SQLiteCommand command = new SQLiteCommand(sql, connection))
            {

                // Выполнение запроса
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    // Обработка результата запроса
                    while (reader.Read())
                    {
                        String[] s = new string[5];
                        using (SQLiteCommand command1 = new SQLiteCommand($"SELECT FIO,phone FROM client WHERE id={reader.GetInt32(1)}", connection))
                        {

                            // Выполнение запроса
                            using (SQLiteDataReader reader1 = command1.ExecuteReader())
                            {
                                // Обработка результата запроса
                                while (reader1.Read())
                                {
                                    s[0]=reader1.GetString(0);
                                    s[1] = reader1.GetString(1);
                                }
                            }
                        }
                        using (SQLiteCommand command2 = new SQLiteCommand($"SELECT * FROM ts WHERE id={id}", connection))
                        {

                            // Выполнение запроса
                            using (SQLiteDataReader reader2 = command2.ExecuteReader())
                            {
                                // Обработка результата запроса
                                while (reader2.Read())
                                {
                                    s[4] = reader2.GetString(2);
                                }
                            }
                        }
                        s[2] = reader.GetInt32(4).ToString();
                        s[3] = reader.GetString(5);

                        ords.Add(s);
                    }
                }
            }
            return ords;
        }
        public String[] GetFullAutoInfo(int id)
        {
            String[] s = new String[13];
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();
            string sql = $"SELECT * FROM ts Where id={id}";
            // Создание объекта SQLiteCommand
            using (SQLiteCommand command = new SQLiteCommand(sql, connection))
            {

                // Выполнение запроса
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    // Обработка результата запроса
                    while (reader.Read())
                    {
                        
                        
                            s[0] = reader.GetInt32(0).ToString();
                            s[1] = reader.GetString(1);
                            s[2] = reader.GetString(2);
                            s[3] = reader.GetString(3);
                            s[4] = reader.GetString(4);

                            using (SQLiteCommand command1 = new SQLiteCommand($"SELECT * FROM orders WHERE id_auto={reader.GetInt32(0)}", connection)) //получаем название ноутбука из таблицы Ноутбуки по его id
                            {
                                using (SQLiteDataReader reader1 = command1.ExecuteReader())
                                {
                                    while (reader1.Read())
                                    {
                                        s[5] = reader1.GetInt32(1).ToString();
                                    s[6]= reader1.GetInt32(3).ToString();
                                    s[7]=reader1.GetInt32(4).ToString();
                                    s[8] = reader1.GetString(5);

                                }
                                }
                            }
                        using (SQLiteCommand command2 = new SQLiteCommand($"SELECT * FROM client WHERE id={Convert.ToInt32(s[5])}", connection)) //получаем название ноутбука из таблицы Ноутбуки по его id
                        {
                            using (SQLiteDataReader reader2 = command2.ExecuteReader())
                            {
                                while (reader2.Read())
                                {
                                    s[9] = reader2.GetInt32(1).ToString();
                                    s[10] = reader2.GetString(2);
                                    s[11] = reader2.GetString(3);
                                    s[12] = reader2.GetString(4);

                                }
                            }
                        }


                    }
                }
            }
            connection.Close();
                                return s;
        }
    }
}
