using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Daybook
{
    class AwsMeeting
    {

        public Result AddToDo(Meeting meeting)
        {
            AwsConnection awsConnection = new AwsConnection();
            awsConnection.sqlConnection.Open();
            if (awsConnection.sqlConnection.State != ConnectionState.Closed)
            {
                MySqlCommand komut = new MySqlCommand();
                string ekleme = "INSERT INTO daybook.Meeting(UId,from,to,eventName,notes,location,isAllDay,startTimeZone,endTimeZone) VALUES('" + meeting.UId + "','" + meeting.from + "','" + meeting.to + "','" + meeting.eventName + "','" + meeting.notes + "','" + meeting.location + "','" + meeting.isAllDay + "','" + meeting.startTimeZone + "','" + meeting.endTimeZone + "',)";

                komut.Connection = awsConnection.sqlConnection;
                komut.CommandText = ekleme;
                komut.ExecuteNonQuery();
                return new SuccessResult(Message.succces);

            }
            awsConnection.sqlConnection.Close();
            return new ErrorResult(Message.Error);
        }

        public DataResult<ObservableCollection<Meeting>> GetMeeting(int UId)
        {

            AwsConnection awsConnection = new AwsConnection();
            awsConnection.sqlConnection.Open();
            if (awsConnection.sqlConnection.State != ConnectionState.Closed)
            {
                MySqlDataAdapter baglayici = new MySqlDataAdapter();
                MySqlCommand komut = new MySqlCommand();
                string sqlsorgusu = "SELECT * FROM daybook.Meeting Where UId='" + UId + "'";
                DataTable tablo = new DataTable();

                komut.CommandText = sqlsorgusu;
                komut.Connection = awsConnection.sqlConnection;
                baglayici.SelectCommand = komut;
                baglayici.Fill(tablo);

                ObservableCollection<Meeting> collection = new ObservableCollection<Meeting>();


                foreach (DataRow dataRow in tablo.Rows)
                {
                    Meeting meeting = new Meeting();
                    meeting.Id = (int)dataRow["Id"];
                    meeting.UId = (int)dataRow["UId"];
                    meeting.from = (DateTime)dataRow["from"];
                    meeting.to = (DateTime)dataRow["to"];
                    meeting.eventName = (string)dataRow["eventName"];
                    meeting.notes = (string)dataRow["notes"];
                    meeting.location = (string)dataRow["location"];
                    meeting.isAllDay = (bool)dataRow["isAllDay"];
                    meeting.startTimeZone = (string)dataRow["startTimeZone"];
                    meeting.endTimeZone = (string)dataRow["endTimeZone"];

                    collection.Add(meeting);
                }
                return new SuccessDataResult<ObservableCollection<Meeting>>(collection, Message.succces);
            }
            awsConnection.sqlConnection.Close();
            return new ErrorDataResult<ObservableCollection<Meeting>>(Message.Error);
        }
    }
}
