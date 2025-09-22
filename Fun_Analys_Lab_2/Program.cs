using System;

namespace Lab_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            double[,] C = {
            { 0, 4.0 / 7.0, 2.0 / 7.0 },
            { -1.0 / 3.0, 0, 1.0 / 3.0 },
            { 0.5, -0.25, 0 }
            };

            double[] d = { -12.0 / 7.0, 4.0 / 3.0, 5.0 / 2.0 };

            int n = 3;
            double epsilon = 0.001;

            // Початкове наближення x^(0)
            double[] x_current = new double[n]; // Всі елементи ініціалізуються нулями за замовчуванням
            double[] x_prev = new double[n];

            int iteration = 0;
            double maxDiff = double.MaxValue;

            Console.WriteLine("Метод простих ітерацій для системи:");
            Console.WriteLine("-7x1 + 4x2 + 2x3 = 12");
            Console.WriteLine("x1 + 3x2 - x3 = 4");
            Console.WriteLine("2x1 - x2 - 4x3 = -10\n");

            Console.WriteLine($"Початкове наближення x^{(0)} = [{x_current[0]:F4}, {x_current[1]:F4}, {x_current[2]:F4}]");

            while (maxDiff >= epsilon)
            {
                iteration++;
                Array.Copy(x_current, x_prev, n); // Зберігаємо попередні значення

                for (int i = 0; i < n; i++)
                {
                    double sum = 0;
                    for (int j = 0; j < n; j++)
                    {
                        sum += C[i, j] * x_prev[j];
                    }
                    x_current[i] = sum + d[i];
                }

                // Обчислення максимальної різниці для умови зупинки
                maxDiff = 0;
                for (int i = 0; i < n; i++)
                {
                    double diff = Math.Abs(x_current[i] - x_prev[i]);
                    if (diff > maxDiff)
                    {
                        maxDiff = diff;
                    }
                }

                Console.WriteLine($"\nІтерація {iteration}:");
                Console.WriteLine($"x^{(iteration)} = [{x_current[0]:F4}, {x_current[1]:F4}, {x_current[2]:F4}]");
                Console.WriteLine($"Максимальна різниця між ітераціями: {maxDiff:F6}");
            }

            Console.WriteLine("\n------------------------------------------------");
            Console.WriteLine($"Розв'язок системи з точністю {epsilon} досягнуто за {iteration} ітерацій:");
            Console.WriteLine($"x1 = {x_current[0]:F4}");
            Console.WriteLine($"x2 = {x_current[1]:F4}");
            Console.WriteLine($"x3 = {x_current[2]:F4}");
        }
    }
}