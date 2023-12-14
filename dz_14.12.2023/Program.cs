using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace dz_14._12._2023
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine("Задача 1");
            Console.WriteLine();
            Thread t1 = new Thread(CountNumbers);
            Thread t2 = new Thread(CountNumbers);
            Thread t3 = new Thread(CountNumbers);

            t1.Start("Поток 1");
            t2.Start("Поток 2");
            t3.Start("Поток 3");

            Thread.Sleep(1500);

            Console.WriteLine("------------------------------------------------------------------------------------------------------------------");

            Console.WriteLine();
            Console.WriteLine("Задача 2");
            Console.WriteLine("Введите число: ");
            int number = int.Parse(Console.ReadLine());
            
            CalculateFactorialAsync(number);
            CalculateSquare(number);

            Thread.Sleep(8500);

            Console.WriteLine("------------------------------------------------------------------------------------------------------------------");

            Console.WriteLine();
            Console.WriteLine("Задача 3");
            
            Refl refl = new Refl();
            Type type = refl.GetType();

            // Получаем информацию о всех методах объекта
            MethodInfo[] methods = type.GetMethods();

            // Выводим имена всех методов
            foreach (MethodInfo method in methods)
            {
                Console.WriteLine(method.Name);
            }

            Console.ReadKey();
        }


        /// <summary>
        /// Реализует вывод числа от 1 до 10
        /// </summary>
        /// <param name="threadName">имя потока, реализующего метод</param>
        static void CountNumbers(object threadName)
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"{threadName}: {i}");
                Thread.Sleep(100);
            }   
        }

        /// <summary>
        /// Вычисляет факториал заданного числа
        /// </summary>
        /// <param name="number">заданное число</param>
        /// <returns></returns>
        static async Task CalculateFactorialAsync(int number)
        {
            Console.WriteLine("Выполняется вычисление факториала...");
            await Task.Delay(8000); // Задержка на 8 секунд
            long factorial = 1;
            if (number > 0)
            {
                for (int i = 1; i <= number; i++)
                {
                    factorial *= i;
                }
                Console.WriteLine($"Факториал числа {number} равен {factorial}");
            }
            else if (number < 0)
            {
                Console.WriteLine("Факориал отрицательного числа не вычисляется");
            }
            else
            {
                Console.WriteLine($"Факториал числа {number} равен {factorial}");
            }
        }

        /// <summary>
        /// Вычисляет квадрат заданного числа
        /// </summary>
        /// <param name="number">заданное число</param>
        static void CalculateSquare(int number)
        {
            Console.WriteLine($"Квадрат числа {number} равен {number * number}");
        }
    }
}
