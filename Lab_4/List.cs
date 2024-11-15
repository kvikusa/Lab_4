using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security;

namespace Lab_4
{
    public class ListTask
    {
        //методы
        //заполнение списка случайными числами
        public static void ListInt<T>(int n, List <string> L) 
        {
            for (int i = 0; i < n; i++)
            {
                L.Add(Console.ReadLine());
            }
        }

        //вывод списка на экран
        public static void PrintList<T> (List<string> list)
        {
            foreach (string str in list)
            {
                Console.Write(str + " ");
            }
            Console.WriteLine();
        }
        //формирует список L, включив в него по одному разу элементы, которые входят в список L1, но не входят в список L2
        public static List<T> Task1<T>(List<T> L1, List<T> L2)
        {
            return L1.Except(L2).ToList();
        }

        
        //проверяет симметричность списка
public static bool Symmetric(LinkedList<string> list, int i, int j)
{
    var first = list.First;
    var last = list.Last;

    for (int k = 0; k <= i; k++) //присваеваем i-му эл-ту значение
        first = first.Next;

    for (int k = 0; k <= list.Count - 1 - j; k++)
        last = last.Previous;

    while (first != last && first.Previous != last)
    {
        if (first.Value != last.Value)
            return false; // Если элементы не равны, возвращаем false

        first = first.Next; //присваеваем следущее значение
        last = last.Previous; //присваеваем следущее значение с конца
    }
    return true; // Если все элементы равны, возвращаем true
}
public static void PrintListLink(LinkedList<string> list)
{
    foreach (string n in list)
    {
        Console.Write(n + " ");
    }
    Console.WriteLine();
}

public static void VvodLinkList(LinkedList<string> l)
{
    while (true)
    {
        Console.Write("Введите число или 'stop': ");
        string input = Console.ReadLine();
        
        if (input.ToLower() == "stop")
            break;

        l.AddLast(input);
    }
}

        //Есть перечень названий шоколада. Определить для каждого наименования шоколада, какие из них нравятся всем n сладкоежкам, какие — некоторым из сладкоежек, и какие — никому из сладкоежек.
        public static void HashSet()
        {
            //Создаем HashSet для каждого покупателя
            HashSet<string> sweetTooth1 = new HashSet<string> { "Alpen Gold", "Milka", "Nesquik", "Ritter sport" };
            HashSet<string> sweetTooth2 = new HashSet<string> { "Ritter sport", "Kinder" };
            HashSet<string> sweetTooth3 = new HashSet<string> { "Alpen Gold", "Ritter sport", "Kinder" } ;
            HashSet<string> sweetTooth4 = new HashSet<string> { "Ritter sport", "Milka" };

            //Создаем HashSet для каждого шоколада
            HashSet<string> chocolate1 = new HashSet<string> { "Alpen Gold" };
            HashSet<string> chocolate2 = new HashSet<string> { "Ritter sport" };
            HashSet<string> chocolate3 = new HashSet<string> { "Milka" };
            HashSet<string> chocolate4 = new HashSet<string> { "Nesquik" };
            HashSet<string> chocolate5 = new HashSet<string> { "Kinder" };
            HashSet<string> chocolate6 = new HashSet<string> { "Dove" };

            //Определяем какой шоколад нравится всем n сладкоежкам
            HashSet<string> all_buyers = new HashSet<string>(sweetTooth1);
            all_buyers.IntersectWith(sweetTooth2);
            all_buyers.IntersectWith(sweetTooth3);
            all_buyers.IntersectWith(sweetTooth4);


            //Определяем какой шоколад приобретался некоторыми из покупателей сладкоежек
            HashSet<string> some_buyers = new HashSet<string>(sweetTooth1);
            some_buyers.UnionWith(sweetTooth2);
            some_buyers.UnionWith(sweetTooth3);
            some_buyers.UnionWith(sweetTooth4);

            //Определяем какой шоколад не приобретался ни одним из покупателей
            HashSet<string> null_choc = new HashSet<string>(chocolate1);
            null_choc.UnionWith(chocolate2);
            null_choc.UnionWith(chocolate3);
            null_choc.UnionWith(chocolate4);
            null_choc.UnionWith(chocolate5);
            null_choc.UnionWith(chocolate6);
            null_choc.ExceptWith(some_buyers);
    
            //Исключаем шоколад который покупали все
            some_buyers.ExceptWith(all_buyers);

            Console.Write("\nШоколад, который нравится всем сладкоежкам -> ");
            foreach (string chocolate in all_buyers)
                Console.WriteLine(chocolate);

            Console.WriteLine("\nШоколад, который нравится некоторым из сладкоежек:");
            foreach (string chocolate in some_buyers)
                Console.WriteLine(chocolate);

            Console.Write("\nШоколад, который не нравится никому из сладкоежек ->  ");
            foreach (string chocolate in null_choc)
                Console.WriteLine(chocolate);
        }

        public static void Bukv (string file)
        {
            // Полный набор букв русского алфавита (включая заглавные и строчные)
            HashSet<char> rusAlphabet = new HashSet<char>
        {
            'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м',
            'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ',
            'ы', 'ь', 'э', 'ю', 'я',
            'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И', 'Й', 'К', 'Л', 'М',
            'Н', 'О', 'П', 'Р', 'С', 'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ъ',
            'Ы', 'Ь', 'Э', 'Ю', 'Я'
        };

            // Создаем HashSet для хранения найденных букв
            HashSet<char> foundBykv = new HashSet<char>();

            try
            {
                string text = File.ReadAllText(file);

                // Проходим по каждому символу в тексте
                foreach (char c in text)
                {
                    // Если символ — буква русского алфавита, добавляем его в HashSet
                    if (rusAlphabet.Contains(char.ToLower(c))) // Приводим к нижнему регистру для унификации
                    {
                        foundBykv.Add(char.ToLower(c));
                    }
                }

                // Находим буквы, которые не встречаются в тексте
                rusAlphabet.ExceptWith(foundBykv);

                // Выводим результат
                Console.WriteLine($"Количество букв, которые не встречаются: {rusAlphabet.Count}");
            }
            catch (Exception)
            {
                Console.WriteLine("Ошибка при чтении файла.");
            }
        }
    }
}
