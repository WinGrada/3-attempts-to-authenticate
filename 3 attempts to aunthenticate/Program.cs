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

            //-----> Генерация рандомного логина и пароля.
            string randomLoginAndPassword = CombineLoginAndPassword(allVowels, allConsonants);
            Console.WriteLine(randomLoginAndPassword);

            //-----> Ввод логина и пароля пользователя.
            Console.WriteLine("Пожалуйста введите логин и пароль ввыше.");
            Console.WriteLine("У вас только 3 попытки!\n");
            string userOption = default;

            //------> Цикл с 3 попытками ввести верный пароль.
            for (int i = 0; i < 3; i++)
            {
                userOption = Console.ReadLine();
                if (i == 2)
                {
                    Console.WriteLine("Хм, Вы не справились за 3 попытки...");
                    Environment.Exit(500);
                }
                if (СoincidenceLoginAndPassword(randomLoginAndPassword, userOption)) break;
            }
            Console.WriteLine("Поздравляю, вы справились с задачей!");


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

            //------------------------------------------------------->
            //-----> Создание динамической строки, содержащей логин.
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

        /* ===================================================================
         *                  Объединение логина и пароля
         * ===================================================================
         * CombineLoginAndPassword
         * 
         * С помощью функций GenerateLogin и GeneratePassword, получает 
         * сгенерированый результат, затем объединяет его и возвращает.
         * 
         * Использует функции:
         *          GenerateLogin - генератор логина.
         *          GeneratePassword - генератор пароля.
         *          
         * Использует переменные:
         *          char [] allVowels - массив всех глассных.
         *          char[] allConsonants - массив всех согласных.
        */
        static string CombineLoginAndPassword(char [] allVowels, char[] allConsonants)
        {
            string login = GenerateLogin(allVowels, allConsonants);
            string password = GeneratePassword();

            return $@"{login}\{password}";
        }

        static bool СoincidenceLoginAndPassword(string randomLoginAndPassword, string userLoginAndPassword)
        {
            if (randomLoginAndPassword == userLoginAndPassword) return true;

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
