using System;
using System.Collections.Generic;

namespace Section04
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter Rome number:");
            string roman = Console.ReadLine();

            Console.WriteLine(RomeNumber(roman));
        }

        private static int RomeNumber(string roman)
        {
            /* ДЗ "Парсинг римских чисел"
            Написать функцию, которая принимает на вход строку - римское число, а возвращает это число в арабском виде. 
            Например, если передаём "XV" - должна вернуть 15, если передаём "IV" - должна вернуть 4.
            Вот список римских символов и их отображение на арабские числа:
            I - 1
            V - 5
            X - 10
            L - 50
            C - 100
            D - 500
            M - 1000
            
            Варианты типа IIIV = 5-3 = 2 мы не рассматриваем. Хотя Римляне и пользовались иногда такими видами записей, 
            но есть разная информация о приемлимости оных. В нашем ДЗ такие варианты мы не рассматриваем. Вот выдержка из wiki:
            "Необходимо отметить, что другие способы «вычитания» недопустимы; так, число 99 должно быть записано как XCIX, но не как IC."
            Подсказка. Для решения надо реализовать два правила:
            Правила записи чисел римскими цифрами:
            - если большая цифра стоит перед меньшей, то они складываются (принцип сложения),
            - если меньшая цифра стоит перед большей, то меньшая вычитается из большей (принцип вычитания).
            Защиту от некорректного ввода реализовать по вашему желанию (можно не делать, но для тренировки всегда полезно). */

            //XIV = 10 - 1 + 5 = 14
            //XI = 10 - 1

            int result = 0;
            for (int i = 0; i < roman.Length; i++)
            {
                if (i + 1 < roman.Length && IsSubrtractive(roman[i], roman[i + 1]))
                {
                    result -= map[roman[i]];
                }
                else
                {
                    result += map[roman[i]];
                }
            }
            return result;

            Console.WriteLine($"Arabic number is: {roman}");
        }

        private static bool IsSubrtractive(char c1, char c2)
        {
            return map[c2] > map[c1];
        }

        private static Dictionary<char, int> map = new Dictionary<char, int>
        {
            { 'I', 1},
            { 'V', 5},
            { 'X', 10},
            { 'L', 50},
            { 'C', 100},
            { 'D', 500},
            { 'M', 1000},

        };

    }

}
