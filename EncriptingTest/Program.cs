using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncriptingTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Enter Password");
            string input = Console.ReadLine();
            Console.WriteLine("..............................");
            Console.WriteLine(".......encrypting.......");
            Console.WriteLine("..............................");
            string ency = Encode(input);
            Console.WriteLine("..............................");
            Console.WriteLine($"value = {ency}");
            Console.WriteLine("..............................");
            Console.WriteLine("..............................");
            Console.WriteLine("........Decrypting...........");
            Console.WriteLine("..............................");
            string decy = Decode(ency);
            Console.WriteLine($"value = {decy}");

            Console.ReadLine();

        }

        static private string Encode(String password)
        {
            string encode = "";
            int num = 7;

            for (int i = 0; i < password.Length; i++)
            {
                encode += (char)(password[i] + num);
            }

            return encode;
        }

        static private string Decode(string encryptedPass)
        {
            string decode = "";
            int num = 7;

            for (int i = 0; i < encryptedPass.Length; i++)
            {
                decode += (char)(encryptedPass[i] - num);
            }

            return decode;
        }
    }
}
