using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Daybook
{
    public class AwsConnection
    {
        public MySqlConnection sqlConnection = new MySqlConnection("Server=denek-1.cua7nr2cnq3x.us-east-2.rds.amazonaws.com;Database=daybook;Uid=masterUserAdem;Pwd=********;");
    }
}
    
