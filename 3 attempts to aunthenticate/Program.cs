using System;
using System.Text;

namespace _3_attempts_to_authenticate
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GenerateLogin());

        }

        static string GenerateLogin()
        {
            Random random = new Random();
            int rndNum = random.Next(5, 8);

            //bool rndBool = random.Next(2) == 0 ? false : true;
            //Console.WriteLine(rndBool);

            StringBuilder sb = new StringBuilder();
            for (int i =  0; i < rndNum; i++)
            {
                if (i == 0)
                {
                    char firstSymbol = (char)random.Next(65, 91);
                    sb.Append(firstSymbol);
                    continue;
                }
                char symbol = (char)random.Next(97, 123);
                sb.Append(symbol);
            }
            string result = sb.ToString();

            return result;
        }

        //static char[] GeneratePassword()
        //{

        //}

        static string GetUserLoginAndPassword()
        {
            return null;
        }

        static bool Сoincidence(string randomLoginAndPassword)
        {
            return false;
        }
    }
}
