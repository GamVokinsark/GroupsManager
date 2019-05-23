using System;
using System.Collections.Generic;
using System.Windows;
using MySql.Data.MySqlClient;

namespace AbitMan
{
    class DBUtils
    {
        public static MySqlConnection conn;
        public static bool IsAvailable()
        {
            if (conn == null)
                return false;
            try
            {
                conn.Open();
                return conn.Ping();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                return false;
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
        }

        public static void SetConnection(string host, string port, string schema, string user, string password)
        {
            try
            {
                string cStr = "Server=" + host + ";port=" + port 
                    + ";Database=" + schema + ";User Id=" 
                    + user + ";password=" + password + ";";
                conn = new MySqlConnection(cStr);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Текст ошибки: " + ex.Message, "Ошибка соединения с БД");
            }
        }

        public static int CheckUserExist(string login, string password)
        {
            conn.Open();
            int privs = 0;
            
            string str = "select IsAdmin from Users where Login = @Login and Pswd = @Pswd";
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = str;
            comm.Connection = conn;
            comm.Parameters.Add("@Login", login);
            comm.Parameters.Add("@Pswd", password);

            try
            {
                MySqlDataReader reader = comm.ExecuteReader();
                if (!reader.HasRows)
                    return 0;
                reader.Read();
                privs = ((Boolean)reader["IsAdmin"]) ? 2 : 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Текст ошибки: " + ex.Message, "Ошибка");
                return 0;
            }
            finally
            {
                conn.Close();
            }
            return privs;
        }

        public static void GetGroupList(List<string> DataList)
        {
            conn.Open();
            MySqlDataReader reader = new MySqlCommand
            { CommandText = "select GName from Groupz;", Connection = conn }.ExecuteReader();
            while (reader.Read())
                DataList.Add((string)reader["GName"]);
            reader.Close();
            conn.Close();
        }

        public static void GetFacultyList(List<string> DataList)
        {
            conn.Open();
            MySqlDataReader reader = new MySqlCommand
            { CommandText = "select FName from Faculty;", Connection = conn }.ExecuteReader();
            while (reader.Read())
                DataList.Add((string)reader["FName"]);
            reader.Close();
            conn.Close();
        }

        public static string AddUser(string login, string password, string IsAdmin)
        {
            conn.Open();
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "insert into Users(Login,Pswd,IsAdmin) " +
                               "values (@Login,@Pswd," + IsAdmin +");";
            comm.Connection = conn;
            comm.Parameters.Add("@Login", login);
            comm.Parameters.Add("@Pswd", password);
            try
            {
                comm.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                conn.Close();
            }
            return "Успешно добавлено нового пользователя.";
        }

        public static void GetFromDB(List<Student> DataList, string str)
        {
            conn.Open();
            MySqlDataReader reader = new MySqlCommand
                { CommandText = str, Connection = conn }.ExecuteReader();
            while (reader.Read())
            {
                DataList.Add(new Student(
                    ((int)reader["SID"]).ToString(),
                    (string)reader["SName"],
                    (string)reader["Surname"],
                    ((int)reader["Course"]).ToString() ));
            }
            reader.Close();
            conn.Close();
        }

        public static void GetFromDB(List<Groups> DataList, string str)
        {
            conn.Open();
            MySqlDataReader reader = new MySqlCommand
                { CommandText = str, Connection = conn }.ExecuteReader();
            while (reader.Read())
            {
                DataList.Add(new Groups(
                    ((int)reader["GID"]).ToString(),
                    ((int)reader["Starosta"]).ToString(),
                    ((int)reader["FID"]).ToString(),
                    (string)reader["GName"],
                    ((bool)reader["IsTemp"])?"True":"False"));
            }
            reader.Close();
            conn.Close();
        }

        public static void GetFromDB(List<Disciple> DataList, string str)
        {
            conn.Open();
            MySqlDataReader reader = new MySqlCommand
            { CommandText = str, Connection = conn }.ExecuteReader();
            while (reader.Read())
            {
                DataList.Add(new Disciple(
                    ((int)reader["DID"]).ToString(),
                    (string)reader["Title"],
                    (string)reader["ZvitForm"],
                    ((int)reader["HoursCount"]).ToString()));
            }
            reader.Close();
            conn.Close();
        }

        public static void GetFromDB(List<Faculty> DataList, string str)
        {
            conn.Open();
            MySqlDataReader reader = new MySqlCommand
            { CommandText = str, Connection = conn }.ExecuteReader();
            while (reader.Read())
            {
                DataList.Add(new Faculty(
                    ((int)reader["FID"]).ToString(),
                    (string)reader["FName"]));
            }
            reader.Close();
            conn.Close();
        }

        public static void GetFromDB(List<Stud_Group> DataList, string str)
        {
            conn.Open();
            MySqlDataReader reader = new MySqlCommand
            { CommandText = str, Connection = conn }.ExecuteReader();
            while (reader.Read())
            {
                DataList.Add(new Stud_Group(
                    ((int)reader["SID"]).ToString(),
                    ((int)reader["GID"]).ToString()));
            }
            reader.Close();
            conn.Close();
        }

        public static void GetFromDB(List<Group_Disc> DataList, string str)
        {
            conn.Open();
            MySqlDataReader reader = new MySqlCommand
            { CommandText = str, Connection = conn }.ExecuteReader();
            while (reader.Read())
            {
                DataList.Add(new Group_Disc(
                    ((int)reader["GID"]).ToString(),
                    ((int)reader["DID"]).ToString()));
            }
            reader.Close();
            conn.Close();
        }

        public static void GetFromDB(List<Res1Storage> DataList, string str, string param)
        {
            conn.Open();
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = str;
            comm.Connection = conn;
            comm.Parameters.Add("@Group", param);
            MySqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                DataList.Add(new Res1Storage(
                    (string)reader["SName"],
                    (string)reader["Surname"],
                    (string)reader["GName"],
                    ((int)reader["Course"]).ToString()));
            }
            reader.Close();
            conn.Close();
        }

        public static void GetFromDB(List<Res2Storage> DataList, string str, string param)
        {
            conn.Open();
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = str;
            comm.Connection = conn;
            comm.Parameters.Add("@Faculty", param);
            MySqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                DataList.Add(new Res2Storage(
                    (string)reader["SName"],
                    (string)reader["Surname"],
                    (string)reader["GName"],
                    (string)reader["FName"],
                    ((int)reader["Course"]).ToString()));
            }
            reader.Close();
            conn.Close();
        }

        public static void GetFromDB(List<Res3Storage> DataList, string str)
        {
            conn.Open();
            MySqlDataReader reader = new MySqlCommand
            { CommandText = str, Connection = conn }.ExecuteReader();
            while (reader.Read())
            {
                DataList.Add(new Res3Storage(
                    (string)reader["FName"],
                    ((int)reader["Course"]).ToString(),
                    (string)reader["GName"],
                    ((long)reader["Num"]).ToString()));
            }
            reader.Close();
            conn.Close();
        }

        public static void GetFromDB(List<Res4Storage> DataList, string str)
        {
            conn.Open();
            MySqlDataReader reader = new MySqlCommand
            { CommandText = str, Connection = conn }.ExecuteReader();
            while (reader.Read())
            {
                DataList.Add(new Res4Storage(
                    (string)reader["SName"],
                    (string)reader["Surname"],
                    (string)reader["GName"],
                    ((int)reader["Course"]).ToString()));
            }
            reader.Close();
            conn.Close();
        }

        public static void GetFromDB(List<Res5Storage> DataList, string str, string param)
        {
            conn.Open();
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = str;
            comm.Connection = conn;
            comm.Parameters.Add("@Group", param);
            MySqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                DataList.Add(new Res5Storage(
                    (string)reader["GName"],
                    ((decimal)reader["AvgHours"]).ToString()));
            }
            reader.Close();
            conn.Close();
        }

        public static void GetFromDB(List<Res6Storage> DataList, string str)
        {
            conn.Open();
            MySqlDataReader reader = new MySqlCommand
            { CommandText = str, Connection = conn }.ExecuteReader();
            while (reader.Read())
            {
                DataList.Add(new Res6Storage(
                    (string)reader["Title"],
                    ((long)reader["Num"]).ToString()));
            }
            reader.Close();
            conn.Close();
        }
    }
}
