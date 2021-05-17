using System;

namespace Daybook
{
    class Program
    {
        static void Main(string[] args)
        {
            AwsUser awsUser = new AwsUser();
            awsUser.GetUser("asdf", "asd");
        }
    }
}
