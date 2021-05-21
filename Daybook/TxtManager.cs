using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleApp1
{
    class TxtManager
    {
        public void Yazma(int test)
        {
            string dosyaYolu = "C:\\Users\\Adem\\source\\repos\\ConsoleApp1\\ConsoleApp1\\UID.txt";
            File.WriteAllText(dosyaYolu, string.Empty);
            FileStream fileStream = new FileStream(dosyaYolu, FileMode.Open, FileAccess.Write);
            StreamWriter writer = new StreamWriter(fileStream, Encoding.UTF8);
            writer.WriteLine(test);
            writer.Close();
        }

        public int Okuma()
        {
            string dosyaYolu = "C:\\Users\\Adem\\source\\repos\\ConsoleApp1\\ConsoleApp1\\UID.txt";
            FileStream fileStream = new FileStream(dosyaYolu, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamReader reader = new StreamReader(fileStream);
            
            
            string satir = reader.ReadLine();

            reader.Close();

            return int.Parse(satir);
        }
    }
}
    