using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BL;

namespace Task_10_1_11_Консоль_
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string[] a = InputMatrix();
                double[,] Matrix = new double[a.Length, 3];
                try
                {
                    for (int i = 0; i < a.Length; i++)
                    {
                        var numbers = a[i].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        for (int k = 0; k < 3; k++)
                        {
                            Matrix[i, k] = Convert.ToDouble(numbers[k]);
                        }
                    }
                    CircleUtility arrCircles = new CircleUtility(Matrix);
                    if (arrCircles.CheckingThatRadiusMoreThan0(arrCircles.Circles))
                    {
                        try
                        {
                            WriteArrInConsole(arrCircles.CircleListToArr(arrCircles.FindAllAloneCircles()));
                            Save(arrCircles.CircleListToArr(arrCircles.FindAllAloneCircles()));
                        }
                        catch
                        {
                            Console.WriteLine("Все круги пересекаются");
                        }

                    }
                    else
                    {
                        Console.WriteLine("Радиусы должны быть больше 0");
                    }
                }
                catch
                {
                    Console.WriteLine("Ошибка");
                }
                Console.WriteLine("Нажмите любую клавишу для продолжения");
                Console.ReadKey();
            }
        }
        public static string[] InputMatrix()
        {
            SavingAndReadingUtils myOpen = new SavingAndReadingUtils();

            Console.WriteLine("Считать матрицу из файла? y/n");
            while (true)
            {
                ConsoleKeyInfo result = Console.ReadKey();
                Console.WriteLine();
                if ((result.KeyChar == 'y') || (result.KeyChar == 'Y'))
                {
                    Console.Write("Введите имя файла:");
                    try
                    {
                        return myOpen.ReadStrArrFromFile(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Ошибка при чтении файла, хотите попробовать считать матрицу из файла снова?");
                    }
                }

                if ((result.KeyChar == 'n') || (result.KeyChar == 'N'))
                {
                    while (true)
                    {
                        Console.Write("Введите длину массива: ");
                        while (true)
                        {
                            try
                            {
                                int k = Convert.ToInt32(Console.ReadLine());
                                string[] inputStrMatrix = new string[k];
                                if (k > 0)
                                {
                                    Console.WriteLine("Введите массив через пробел");
                                    for (int i = 0; i < k; i++)
                                    {
                                        inputStrMatrix[i] = Console.ReadLine();
                                    }
                                    return inputStrMatrix;
                                }
                                else
                                {
                                    Console.WriteLine("Некорректная длина массива.");
                                }
                            }
                            catch
                            {
                                Console.WriteLine("Ошибка, попробуйте ещё раз");
                            }
                        }
                    }
                }
            }
        }
        public static void Save(double[,] resultMatrix)
        {
            SavingAndReadingUtils mySave = new SavingAndReadingUtils();
            while (true)
            {
                Console.WriteLine("Сохранить результат в файл? y/n");
                ConsoleKeyInfo result = Console.ReadKey();
                Console.WriteLine();
                if ((result.KeyChar == 'y') || (result.KeyChar == 'Y'))
                {
                    Console.Write("Введите полное имя файла:");
                    try
                    {
                        string[] matrix = new string[resultMatrix.GetLength(0)];
                        for ( int j = 0; j < matrix.Length; j ++)
                        {
                            for ( int n = 0; n < 3; n ++)
                            {
                                matrix[j] += resultMatrix[j, n] + " ";
                            }
                        }
                        mySave.WriteArrInFile(Console.ReadLine(), matrix);
                        break;
                    }
                    catch
                    {
                        Console.WriteLine("Ошибка при сохранении файла");
                        break;
                    }
                }
                if ((result.KeyChar == 'n') || (result.KeyChar == 'N')) { break; }
            }
        }
        public static void WriteArrInConsole(double[,] arr)
        {
            Console.WriteLine("Круги с такими параметрами не пересекаются:");
            for(int i = 0; i < arr.GetLength(0);i++)
            {
                for ( int k = 0; k < arr.GetLength(1); k ++)
                {
                    Console.Write(arr[i , k] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}