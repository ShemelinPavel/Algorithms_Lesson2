/*

Shemelin Pavel

2

Реализовать функцию возведения числа a в степень b:
a. без рекурсии;
b. рекурсивно;
c. *рекурсивно, используя свойство чётности степени.

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    class Program
    {
        /// <summary>
        /// возведение в степень (рекурсия)
        /// </summary>
        /// <param name="val">число, возводимое в степень</param>
        /// <param name="pow">значение степени</param>
        /// <param name="fast">быстрый алгоритм true/false</param>
        /// <param name="counter">счетчик шагов</param>
        /// <returns>результат</returns>
        public static UInt64 Power_Rec( uint val, uint pow, bool fast, ref uint counter )
        {
            if (fast)
            {
                counter++;
                if (pow == 0) return 1;
                else
                {
                    if (pow % 2 == 0) return Power_Rec( val * val, pow/2, fast, ref counter );
                    else return val * Power_Rec( val, pow - 1, fast, ref counter );
                }
            }
            else
            {
                counter++;
                if (pow == 0) return 1;
                else return val * Power_Rec( val, pow - 1, fast, ref counter );
            }
        }

        /// <summary>
        /// возведение в степень
        /// </summary>
        /// <param name="val">число, возводимое в степень</param>
        /// <param name="pow">значение степени</param>
        /// <param name="counter">счетчик шагов</param>
        /// <returns>результат</returns>
        public static UInt64 Power( uint val, uint pow, ref uint counter )
        {
            UInt64 res = 1;
            while (pow > 0)
            {
                res *= val;
                pow--;
                counter++;
            }
            return res;
        }

        static void Main( string[] args )
        {
            uint Value = 2;
            uint Pow = 10;
            uint counter;
            UInt64 res;

            counter = 0;
            res = Power( Value, Pow, ref counter );
            Console.WriteLine( $"Возведение (без рекурсии) {Value} в степень {Pow}: {res}. Количество шагов: {counter}" );

            counter = 0;
            res = Power_Rec( Value, Pow, false, ref counter );
            Console.WriteLine( $"Возведение (рекурсия) {Value} в степень {Pow}: {res}. Количество шагов: {counter}" );

            counter = 0;
            res = Power_Rec( Value, Pow, true, ref counter );
            Console.WriteLine( $"Возведение (рекурсия, четность) {Value} в степень {Pow}: {res}. Количество шагов: {counter}" );

            Console.ReadKey();
        }
    }
}
