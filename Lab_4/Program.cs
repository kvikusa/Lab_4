using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Практика_3;

namespace Lab_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int z = Proverka.InputIntegerWithValidation($"Введите номер задачи (от 1 до 4) -> ", 1, 4); ;
            if (z == 1)
            {
                List<string> L1 = new List<string>();
                int n;
                while (true)
                {
                    Console.Write("Введите размер списка L1 -> ");
                    if (int.TryParse(Console.ReadLine(), out n))
                        break;
                    else
                        Console.WriteLine("Некорректный ввод. Пожалуйста, введите целое число размерa списка L1 ->");
                }
                ListTask.ListInt<string>(n, L1);
                Console.Write("L1 -> ");
                ListTask.PrintList<string>(L1);

                List<string> L2 = new List<string>();
                int m;
                while (true)
                {
                    Console.Write("Введите размер списка L2 -> ");
                    if (int.TryParse(Console.ReadLine(), out m))
                        break;
                    else
                        Console.WriteLine("Некорректный ввод. Пожалуйста, введите целое число размерa списка L2 ->");
                }
                ListTask.ListInt<string>(m, L2);
                Console.Write("L2 -> ");
                ListTask.PrintList<string>(L2);

                List<string> L = ListTask.Task1(L1, L2);
                Console.Write("L -> ");
                ListTask.PrintList<string>(L);
            }
            if (z == 2) 
            {
                LinkedList<int> list = new LinkedList<int>();
                Console.WriteLine("Введите целые числа для заполнения списка. Введите 'stop' для завершения ввода.");
                ListTask.VvodLinkList(list);

                if (list.Count == 0)
                {
                    Console.WriteLine("Список пуст. Программа завершена.");
                    return;
                }

                Console.WriteLine("список: " );
                ListTask.PrintListLink(list);

                int i, j;
                while (true)
                {
                    Console.Write("Введите индекс i (от 0 до {0}): ", list.Count-1);
                    if (int.TryParse(Console.ReadLine(), out i) && i >= 0 && i < list.Count-1)
                        break;
                    else
                        Console.WriteLine("Некорректный ввод. Пожалуйста, введите целое число в указанном диапазоне.");
                }

                while (true)
                {
                    Console.Write("Введите индекс j (от {0} до {1}): ", i + 1, list.Count-1);
                    if (int.TryParse(Console.ReadLine(), out j) && j > i && j < list.Count)
                        break;
                    else
                        Console.WriteLine("Некорректный ввод. Пожалуйста, введите целое число в указанном диапазоне.");
                }
                
                bool sim = ListTask.Symmetric(list, i, j);
                Console.WriteLine($"Участок списка с {i} по {j} является симметричным: {sim}");
            }
            if (z == 3)
            {
                ListTask.HashSet();
            }
            if (z == 4) 
            { 
                string fileName = "textEng.txt"; //чтение файла
                ListTask.Bukv(fileName);
            }
        }
    }
}
