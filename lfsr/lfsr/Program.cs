using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lfsr
{
    class Program
    {
        static void Main(string[] args)
        {
            // Считывание размера регистра
            Console.Write("Введите размер регистра: ");
            int size = Int32.Parse(Console.ReadLine());

            // Введение стартового состояния
            bool[] start = new bool[size];
            for(int i = 0; i < size; i++)
            {
                Console.Write("Введите " + (i + 1) + " элемент: ");
                start[i] = Convert.ToBoolean(Convert.ToByte(Console.ReadLine()));
            }

            // Считывание полинома по длине регистра
            string[] polynoms = File.ReadAllLines(size.ToString() + ".txt", Encoding.Default);

            // Запись полиномов в битовой форме
            Console.WriteLine("Полиномы:");
            for (int i = 0; i < polynoms.Length; i++)
                Console.WriteLine(Convert.ToString(Convert.ToInt32(polynoms[i], 16), 2));

            // Вводим выбранный полином
            Console.Write("Введите полином:");
            string pol = Console.ReadLine();

            // Объект выходного файла
            StreamWriter outputFile;
            
            // Объект класса регистра
            lfsr l = new lfsr(size, pol, start);

            // Прохождение сдвигов
            while (true)
            {
                Console.Write("Введите количество итераций: ");
                int n = Convert.ToInt32(Console.ReadLine());
                outputFile = new StreamWriter("output.txt", false);
                for (int i = 0; i < n; i++)
                {
                    l.next();
                    outputFile.WriteLine(l.ToString());
                }
                Console.WriteLine("Выполнено");
                outputFile.Close();
            }
        }
    }
}