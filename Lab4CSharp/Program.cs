using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            // --- ЗАВДАННЯ 1: ПРЯМОКУТНИК ---
            Console.WriteLine("=== ЗАВДАННЯ 1: RECTANGLE ===");
            Rectangle rect = new Rectangle(5, 5, 10);
            rect.Show();
            Console.WriteLine($"rect[0] (сторона a): {rect[0]}");
            rect++;
            Console.WriteLine("Після rect++:");
            rect.Show();
            Console.WriteLine($"Рядок з об'єкта: {rect}");

            // --- ЗАВДАННЯ 2: ВЕКТОР
            Console.WriteLine("\n=== ЗАВДАННЯ 2: VECTOR SHORT ===");
            VectorShort v1 = new VectorShort(3, 10);
            VectorShort v2 = new VectorShort(3, 2);
            Console.Write("V1: "); v1.Display();
            Console.Write("V2: "); v2.Display();
            Console.Write("V1 / V2: "); (v1 / v2).Display();
            Console.Write("V2 << 2: "); (v2 << 2).Display();
            Console.WriteLine($"V1 > V2? {v1 > v2}");
            Console.WriteLine($"Всього об'єктів: {VectorShort.CountVectors()}");

            // --- ЗАВДАННЯ 3: ПОКУПЦІ ---
            Console.WriteLine("\n=== ЗАВДАННЯ 3: ПОКУПЦІ (STRUCTURES/RECORDS) ===");
            List<CustomerRecord> customers = new List<CustomerRecord> {
                new CustomerRecord("Іванов І.І.", "Київ", "093111", "1111"),
                new CustomerRecord("Петров П.П.", "Львів", "093222", "2222"),
                new CustomerRecord("Сидоров С.С.", "Одеса", "093333", "3333"),
                new CustomerRecord("Мартинець М.З.", "Чернівці", "093444", "4444")
            };



            Console.WriteLine("Початковий список:");
            customers.ForEach(c => Console.WriteLine(c));

            // Видаляємо 3 з початку, додаємо 3 в кінець
            if (customers.Count >= 3) customers.RemoveRange(0, 3);
            customers.Add(new CustomerRecord("Новий 1", "Дніпро", "093001", "5555"));
            customers.Add(new CustomerRecord("Новий 2", "Суми", "093002", "6666"));
            customers.Add(new CustomerRecord("Новий 3", "Полтава", "093003", "7777"));

            Console.WriteLine("\nОновлений список (після видалення 3 та додавання 3):");
            customers.ForEach(c => Console.WriteLine(c));

            Console.WriteLine("\nНатисніть будь-яку клавішу для завершення...");
            Console.ReadKey();
        }
    }
}