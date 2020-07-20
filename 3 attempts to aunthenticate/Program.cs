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
        /* ===================================================================
         *                  Генерация логина
         * ===================================================================
         * GenerateLogin
         * 
         * Генерирует логин, который имеет размер от 5 до 7 символов.
         *  Возвращает строку логина.
         * 
         * Использует переменные:
         *          allVowels - массив всех глассных англиского языка.
         *          allConsonants - массив всех соглассных английского языка.
        */
        static string GenerateLogin( char[] allVowels, char[] allConsonants)
        {
            Random random = new Random();
            int rndSizeLogin = random.Next(5, 8);
            int rndNum = default;
            bool rndBool = default;
            int cntVowels = 2;

            StringBuilder sb = new StringBuilder();
            for (int i =  0; i < rndSizeLogin; i++)
            {
                //-----> Геренация первого символа в верхнем регистре.
                if (i == 0)
                {
                    char symbol = (char)random.Next(65, 91);
                    sb.Append(symbol);
                    continue;
                }

                //-----> Рандомное булевое значение.
                rndBool = random.Next(2) == 0 ? false : true;

                //-----> Генерация гласных символов в логине, не больше 2.
                if (rndBool == true && cntVowels > 0)
                {
                    cntVowels--;
                    rndNum = random.Next(0, 6);
                    sb.Append(allVowels[rndNum]);
                    continue;
                }

                //-----> Генерация согласных символов в логине.
                rndNum = random.Next(0, 20);
                sb.Append(allConsonants[rndNum]);
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
