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
            Console.WriteLine(GeneratePassword());


        }
        /* ===================================================================
         *                  Генерация логина
         * ===================================================================
         * GenerateLogin
         * 
         * С помощью String Builder -Генерирует логин, который имеет размер 
         *  от 6 до 9 символов. Логин имеет 1 символ верхнего регистра, и в 
         *  зависимости от рандома 0 или 2 гласных.
         *  
         *  Возвращает: строку состоящую из логина.
         * 
         * Использует функции: 
         *          GetRandomBoolValue - функция выдает рандомное булевое 
         *           значение.
         *           
         * Использует переменные:
         *          allVowels - массив всех глассных англиского языка.
         *          allConsonants - массив всех соглассных английского языка.
        */
        static string GenerateLogin( char[] allVowels, char[] allConsonants)
        {
            Random random = new Random();
            int rndSizeLogin = random.Next(3, 5);
            int rndNum = default;
            bool rndBool = default;
            int cntVowels = 2;
            //-----> Дальше собирается строка с помощью конструктора.
            StringBuilder sb = new StringBuilder();
            for (int i =  0; i < rndSizeLogin; i++)
            {
                //-----> Геренация первого символа в верхнем регистре.
                if (i == 0)
                {
                    char symbol = (char)random.Next(65, 91);
                    sb.Append(symbol);
                }

                //-----> Рандомное булевое значение для функции ниже.
                rndBool = GetRandomBoolValue();

                //-----> Генерация гласных символов в логине, не больше 2.
                if (rndBool == true && cntVowels > 0)
                {
                    cntVowels--;
                    rndNum = random.Next(0, 6);
                    sb.Append(allVowels[rndNum]);
                }

                //-----> Генерация согласных символов в логине.
                rndNum = random.Next(0, 20);
                sb.Append(allConsonants[rndNum]);
            }
            string result = sb.ToString();

            return result;
        }

        /* ===================================================================
         *                  Генерация пароля
         * ===================================================================
         * GeneratePassword
         * 
         * С помощью String Builder - Генерирует пароль от 6 символов, пароль 
         *  состоит из букв вехнерго, нижнего регистра, так же имеются числа. 
         *  Все это генерируется рандомно.
         *  
         * Возвращает: Строку состоящую из сгенерированого пароля.
         *  
         * Использует функции:
         *          GetRandomBoolValue - функция выдает рандомное булевое 
         *              значение.
         *
        */
        static string GeneratePassword()
        {
            char symbol = default;
            bool rndBool = default;
            Random random = new Random();
            int recommendedSize = 4;

            StringBuilder sb = new StringBuilder();
            for(int i = 0; i < recommendedSize; i++)
            {
                //-----> Генерация символа верхнего регистра.
                rndBool = GetRandomBoolValue();
                if (rndBool)
                {
                    symbol = (char)random.Next(65, 91);
                    sb.Append(symbol);
                }

                //-----> Генерация символа нижнего регистра.
                rndBool = GetRandomBoolValue();
                if (rndBool)
                {
                    symbol = (char)random.Next(97, 123);
                    sb.Append(symbol);
                }

                //-----> Генерация чисел.
                rndBool = GetRandomBoolValue();
                if (rndBool)
                {
                    symbol = (char)random.Next(48, 58);
                    sb.Append(symbol);
                }
            }
            string result = sb.ToString();

            return result;
        }

        static string CombineLoginAndPassword(char [] allVowels, char[] allConsonants)
        {
            string login = GenerateLogin(allVowels, allConsonants);
            string password = GeneratePassword();

            return $@"{login}\{password}";
        }

        static bool Сoincidence(string randomLoginAndPassword)
        {
            return false;
        }

        static bool GetRandomBoolValue()
        {
            Random random = new Random();
            bool rndBool = default;

            return rndBool = random.Next(2) == 0 ? false : true;
        }
    }
}
