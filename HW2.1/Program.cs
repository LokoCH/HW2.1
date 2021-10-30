using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2._1
{
    class Program
    {
        static void PrintArray(int[] arr)
        {
            foreach (var elem in arr)
            {
                Console.Write(elem + " ");
            }
            Console.WriteLine();
        }
        public static int[] Total(int[] arr1, int[] arr2)
        {
            int size = (arr1.Length < arr2.Length) ? arr1.Length : arr2.Length;
            int[] tmp = new int[size];
            int idx = 0; // нужна для итерации по массиву tmp
            bool enter = false; // нужна для определения повторения элемента в массиве tmp

            foreach (var elem1 in arr1)
            {
                foreach (var elem2 in arr2)
                {
                    if (elem1 == elem2)
                    {
                        enter = false;

                        // проверяем есть ли найденный элемент в массиве tmp
                        for (int i = 0; i < idx; i++)
                            if (tmp[i] == elem1)
                            {
                                enter = true;
                                break;
                            }

                        // если элемента в массиве tmp нет, то добавляем его туда и увеличиваем индекс
                        if (!enter)
                        {
                            tmp[idx] = elem1;
                            ++idx;
                        }
                    }
                }
            }

            Array.Resize(ref tmp, idx); // удаляем неиспользованные ячейки
            return tmp;
        }

        static void Main(string[] args)
        {

            int M = 0;
            int N = 0;

            Console.Write("Размер первого массива: ");
            M = Convert.ToInt32(Console.ReadLine());
            int[] arr1 = new int[M];

            Console.Write("Размер второго массива: ");
            N = Convert.ToInt32(Console.ReadLine());
            int[] arr2 = new int[N];

            // заполнение массивов
            Random r = new Random();
            for (int i = 0; i < arr1.Length; i++)
            {
                arr1[i] = r.Next(0, 10);
            }

            for (int i = 0; i < arr2.Length; i++)
            {
                arr2[i] = r.Next(0, 10);
            }

            int[] newInt = Total(arr1, arr2);

            Console.WriteLine("Первый массив:");
            PrintArray(arr1);
            Console.WriteLine("Второй массив:");
            PrintArray(arr2);
            Console.WriteLine("Массив общих элементов:");
            PrintArray(newInt);
        }
    }
}
