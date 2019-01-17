/*

Shemelin Pavel

1

Реализовать функцию перевода чисел из десятичной системы в двоичную, используя рекурсию.

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    class Program
    {
        /// <summary>
        /// получение строкового представления конвертации десятичного числа в двоичное
        /// </summary>
        /// <param name="num">десятичное число</param>
        /// <returns>строка - представление двоичного числа</returns>
        public static string DecimalConversionToBinary(int num)
        {
            if (num == 1) return "1";
            else
            {
                return DecimalConversionToBinary( num / 2) + (num % 2);
            }
        }

        static void Main( string[] args )
        {
            const int Number = 101;

            string res = DecimalConversionToBinary( Number );

            Console.WriteLine( $"Конвертация десятичного числа в двоичное через рекурсию:   {Number} -> {res}" );
            Console.WriteLine( $"Конвертация (проверочная) средствами среды .Net:           {Number} -> {Convert.ToString( Number, 2 )}" );

            Console.ReadKey();
        }
    }
}
