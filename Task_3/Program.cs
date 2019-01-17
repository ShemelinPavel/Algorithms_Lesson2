/*

Shemelin Pavel

3

Исполнитель «Калькулятор» преобразует целое число, записанное на экране. У исполнителя две команды, каждой присвоен номер: 
1. Прибавь 1.
2. Умножь на 2.
Первая команда увеличивает число на экране на 1, вторая увеличивает его в 2 раза. Определить, сколько существует программ, которые преобразуют число 3 в число 20:
а. С использованием массива.
b. *С использованием рекурсии.

*/

using System;
using System.Collections.Generic;

namespace Task_3
{
    class Program
    {
        /// <summary>
        /// посчет числа комманд преобразования одного числа в другое, используя массив (словарь)
        /// </summary>
        /// <param name="numA">начальное число</param>
        /// <param name="NumB">конечное число</param>
        /// <returns>число команд</returns>
        public static int Command_Calc_Dict( int numA, int NumB )
        {
            Dictionary<int, int> commandList = new Dictionary<int, int>();

            int res_Plus1 = 0;
            int res_Mult2 = 0;
            int i = NumB;
            while (i >= numA)
            {
                commandList.Add( i, 0 );

                res_Plus1 = i + 1;
                res_Mult2 = i * 2;

                if (res_Plus1 <= NumB) commandList[i] = commandList[i] + commandList[res_Plus1] + ( ( res_Plus1 == NumB ) ? 1 : 0 );
                if (res_Mult2 <= NumB) commandList[i] = commandList[i] + commandList[res_Mult2] + ( ( res_Mult2 == NumB ) ? 1 : 0 );

                i--;
            }
            return ( commandList.Count == 0 ) ? 0 : commandList[numA];
        }

        /// <summary>
        /// посчет числа комманд преобразования одного числа в другое, используя рекурсию
        /// </summary>
        /// <param name="numA">начальное число</param>
        /// <param name="numB">конечное число</param>
        /// <param name="res">число команд</param>
        public static void Command_Calc_Rec( int numA, int numB, ref int res )
        {
            if (numA > numB) return;
            else if (numA == numB)
            {
                res++;
            }
            else
            {
                Command_Calc_Rec( numA + 1, numB, ref res );
                Command_Calc_Rec( numA * 2, numB, ref res );
            }
        }

        static void Main( string[] args )
        {
            Console.BufferWidth = 100;
            Console.WindowWidth = 100;

            int num1 = 3;
            int num2 = 20;
            int res = 0;

            res = Command_Calc_Dict( num1, num2 );
            Console.WriteLine( $"Количество программ преобразования числа: {num1} в число {num2} через массив (словарь): {res}" );

            res = 0;
            Command_Calc_Rec( num1, num2, ref res );
            Console.WriteLine( $"Количество программ преобразования числа: {num1} в число {num2} через рекурсию: {res}" );

            Console.ReadKey();
        }
    }
}