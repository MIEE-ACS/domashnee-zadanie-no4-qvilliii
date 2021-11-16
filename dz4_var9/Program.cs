using System;

namespace dz4_var9
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("          Одномерные массивы          ");
            Console.Write("Введите колличество элементов массива:\t");

            int index = 0;
            while (index < 1)
            {
                index = int.Parse(Console.ReadLine());
                if (index < 1)
                {
                    Console.WriteLine("Некорректный размер массива.");
                }
            }
            double[] Arr = new double[index];
            Random rand = new Random();

            Console.WriteLine("Вывод массива:");
            for (int i = 0; i < Arr.Length; i++)
            {
                Arr[i] = rand.Next(-9999, 9999) / 1000.0;
                Console.Write(Arr[i] + "  ");
            }
            Console.WriteLine();

            Console.Write("Максимальный по модулю элемент массива:\t");
            double maxValue = Arr[0];
            for (int i = 0; i < Arr.Length; i++)
            {
                if (Math.Abs(Arr[i]) > Math.Abs(maxValue))
                {
                    maxValue = Arr[i];
                }
            }
            Console.Write(maxValue);
            Console.WriteLine();

            Console.Write("Сумма элементов массива, расположенных между первым и вторым положительными элементами:\t");
            int FPE = 0;
            int SPE = 0;
            double sum = 0;
            for (int i = 0; i < Arr.Length; i++)
            {
                if (Arr[i] > 0)
                {
                    FPE = i;
                    break;
                }
            }

            for (int i = FPE+1; i < Arr.Length; i++)
            {
                if (Arr[i] > 0)
                {
                    SPE = i;
                    break;
                }
            }
            for (int i = FPE + 1; i < SPE; i++)
            {
                sum += Arr[i];
            }
            Console.WriteLine(Math.Round(sum, 3));
            Console.WriteLine();

            Console.WriteLine("          Двумерные массивы          ");
            int SIZE = 10;
            double[,] Array = new double[SIZE, SIZE];

            Console.WriteLine("Вывод массива 10 x 10:");
            for (int i = 0; i < SIZE; i++)
            {
                for (int j = 0; j < SIZE; j++)
                {
                    Array[i, j] = rand.Next(0, 1000) / 10.0;
                    Console.Write(Array[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            Console.WriteLine("Сглаженная матрица:");
            double[,] SmoothedArray = new double[SIZE, SIZE];
            double total = 0;
            double summ = 0;
            int a = 0, a1 = 0, a2 = 0, a3 = 0, m = 0;

            for (int i = 0; i < SIZE; i++)
            {
                for (int j = 0; j < SIZE; j++)
                {
                    if (i == 0) a = 1;
                    if (i == SIZE - 1) a2 = 1;
                    for (int k = i - 1 + a; k <= i + 1 - a2; k++)
                    {
                        if (j == 0) a1 = 1;
                        if (j == SIZE - 1) a3 = 1;
                        for (int l = j - 1 + a1; l <= j + 1 - a3; l++)
                        {
                            summ = summ + Array[k, l];
                            m++;
                        }
                        a1 = 0;
                        a3 = 0;
                    }

                    SmoothedArray[i, j] = Math.Round((summ - Array[i, j]) / (m - 1), 3);
                    summ = 0;
                    m = 0;
                    a = 0;
                    a2 = 0;
                }
            }
            for (int i = 0; i < SIZE; i++)
            {
                for (int j = 0; j < SIZE; j++)
                {
                    Console.Write(SmoothedArray[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            int p = 0;
            for (int i = p+1; i < SIZE; i++)
            {
                for (int j = 0; j < p+1; j++)
                {
                        total += Math.Abs(SmoothedArray[i, j]);
                }
                p++;                      
            }
            Console.Write("Сумма элементов, расположенных ниже главной диагонали:\t");
            Console.Write(Math.Round(total,3));

            Console.ReadLine(); 
        }
    }

}
