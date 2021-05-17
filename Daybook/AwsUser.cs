using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Daybook
{
    public class AwsUser
    {
        //Parola yenileme ekle
        //Dataresult kullanımı


        public void AddUser(string name, string lastName, string email, string password)
        {
            AwsConnection awsConnection = new AwsConnection();
            awsConnection.sqlConnection.Open();
            if (awsConnection.sqlConnection.State != ConnectionState.Closed)
            {
                MySqlCommand komut = new MySqlCommand();
                string ekleme = "INSERT INTO daybook.User(Name,Lastname,Email,Password) VALUES('" + name + "','" + lastName + "','" + email + "','" + password + "')";

                komut.Connection = awsConnection.sqlConnection;
                komut.CommandText = ekleme;
                komut.ExecuteNonQuery();
                Console.WriteLine("başarılı");

            }
            else
            {
                Console.WriteLine("basarısızzzzzz");
            }
            awsConnection.sqlConnection.Close();


        }
        public void GetUser(string email, string password)
        {
            AwsConnection awsConnection = new AwsConnection();
            awsConnection.sqlConnection.Open();
            if (awsConnection.sqlConnection.State != ConnectionState.Closed)
            {
                MySqlDataReader baglayici;
                MySqlCommand komut = new MySqlCommand();
                string sqlsorgusu = "SELECT * FROM daybook.User Where Email='" + email + "' AND Password='" + password + "'";
                komut.CommandText = sqlsorgusu;
                komut.Connection = awsConnection.sqlConnection;
                baglayici = komut.ExecuteReader();
                if (baglayici.Read())
                {
                    Console.WriteLine("Başarılı");
                }
                else
                {
                    Console.WriteLine("Email veya password hatalı...");
                }
            }
            else
            {
                Console.WriteLine("bağlantı basarısızzzzzz");
            }
            awsConnection.sqlConnection.Close();

        }
        public void GetUserId(string email, string password)
        {
            AwsConnection awsConnection = new AwsConnection();
            awsConnection.sqlConnection.Open();
            if (awsConnection.sqlConnection.State != ConnectionState.Closed)
            {
                MySqlDataAdapter baglayici = new MySqlDataAdapter();
                MySqlCommand komut = new MySqlCommand();
                string sqlsorgusu = "SELECT Id FROM daybook.User Where Email='" + email + "' AND Password='" + password + "'";
                DataTable tablo = new DataTable();

                komut.CommandText = sqlsorgusu;
                komut.Connection = awsConnection.sqlConnection;
                baglayici.SelectCommand = komut;
                baglayici.Fill(tablo);

                // Console.WriteLine(tablo);
                int userId;

                foreach (DataRow dataRow in tablo.Rows)
                {
                    foreach (var item in dataRow.ItemArray)
                    {
                        userId = (int)item;
                        Console.WriteLine(item);
                    }
                }

            }
            else
            {
                Console.WriteLine("basarısızzzzzz");
            }
            awsConnection.sqlConnection.Close();


        }
    }
}
