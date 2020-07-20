using System;
using System.Text;

namespace _3_attempts_to_authenticate
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] allVowels = new char[6] { 'a', 'e', 'i', 'o', 'u', 'y' };
            char[] allConsonants = new char[20] { 'b', 'c', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 'p', 'q', 'r', 's', 't', 'v', 'w', 'x', 'z' };
            Console.WriteLine(GenerateLogin(allVowels, allConsonants));


        }

        static string GenerateLogin( char[] allVowels, char[] allConsonants)
        {
            Random random = new Random();
            int rndNum = random.Next(5, 8);
            int rndNumForVowels = default;
            bool rndBool = default;
            char symbol = default;
            int cntVowels = 2;

            StringBuilder sb = new StringBuilder();
            for (int i =  0; i < rndNum; i++)
            {
                if (i == 0)
                {
                    symbol = (char)random.Next(65, 91);
                    sb.Append(symbol);
                    continue;
                }

                rndBool = random.Next(2) == 0 ? false : true;
                if (rndBool == true && cntVowels > 0)
                {
                    rndNumForVowels = random.Next(0, 6);
                    sb.Append(allVowels[rndNumForVowels]);
                    continue;
                }
                symbol = (char)random.Next(0, 21);
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
