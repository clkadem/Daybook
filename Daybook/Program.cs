using System;

namespace Daybook
{
    class Program
    {
        static void Main(string[] args)
        {
            AwsUser awsUser = new AwsUser();
            awsUser.GetUserId("text@deneme.com", "123456");
        }
    }
}
