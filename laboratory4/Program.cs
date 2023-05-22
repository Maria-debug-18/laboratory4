using System.Diagnostics;

class Program
{
    static void Main()
    {
        try
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Программа почалась.");
            Console.ResetColor();

            int studentNumber = 16;
            int arraySize = (int)(20 + 0.6 * studentNumber);
            int[] array = GenerateRandomArray(arraySize);
            Console.WriteLine("╔═══════════════════════════════════════╗");
            Console.WriteLine("║            Початковий масив           ║");
            Console.WriteLine("╠════╦════╦════╦════╦════╦════╦════╦════╣");
            PrintArray(array);
            SortArray(array);
            Console.WriteLine("\n╔═══════════════════════════════════════╗");
            Console.WriteLine("║           Вiдсортований масив         ║");
            Console.WriteLine("╠════╦════╦════╦════╦════╦════╦════╦════╣");
            PrintArray(array);
            Console.WriteLine("\n╔════════════════════════════════════╗");
            Console.WriteLine("║        Введiть ключове значення    ║");
            Console.WriteLine("╠════════════════════════════════════╣");
            Console.Write("║                ");
            string keyInput = Console.ReadLine();
            int key;

            if (!int.TryParse(keyInput, out key))
            {
                throw new ArgumentException("Неверный формат числа. Введите целое число.");
            }

            string keyLabel = $"║         Ключове значення: {key}       ║";
            string tableLine = "╠════════════════════════════════════╣";

            int padding = (tableLine.Length - keyLabel.Length) / 2;
            string centeredKeyLabel = keyLabel.PadLeft(padding + keyLabel.Length);

            Console.WriteLine(centeredKeyLabel);
            Console.WriteLine(tableLine);


            int index = SequentialSearch(array, key);

            if (index != -1)
            {
                Console.WriteLine("\n╔═══════════════════════════════════════════╗");
                Console.WriteLine("║             Послiдовний пошук             ║");
                Console.WriteLine("╠═══════════════════════════════════════════╣");
                Console.WriteLine($"║    Значення {key} знайдено на позицiї {index,-5}  ║");
                Console.WriteLine("╚═══════════════════════════════════════════╝");
            }
            else
            {
                Console.WriteLine("\n╔══════════════════════════════════════╗");
                Console.WriteLine("║            Послiдовний пошук         ║");
                Console.WriteLine("╠══════════════════════════════════════╣");
                Console.WriteLine($"║  Значення {key} не знайдено в масивi.   ║");
                Console.WriteLine("╚══════════════════════════════════════╝");
            }      
            stopwatch.Stop();
            TimeSpan elapsed = stopwatch.Elapsed;
            int minutes = (int)elapsed.TotalMinutes;
            int seconds = elapsed.Seconds;

            Console.ForegroundColor = ConsoleColor.Yellow;
            if (minutes > 0)
            {
                Console.WriteLine($"\nПройшло: {minutes} хв. {seconds} сек.");
            }
            else
            {
                Console.WriteLine($"\nПройшло: {seconds} сек.");
            }
            Console.ResetColor();
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("\nПроизошла ошибка:");
            Console.WriteLine(ex.Message);
            PromptUserToContinueOrExit();
        }
        catch (Exception ex)
        {
            Console.WriteLine("\nПроизошла непредвиденная ошибка:");
            Console.WriteLine(ex.Message);
            PromptUserToContinueOrExit();
        }
    }
    static void PromptUserToContinueOrExit()
    {
        Console.WriteLine("\nВыберите действие:");
        Console.WriteLine("1. Продолжить программу.");
        Console.WriteLine("2. Закончить программу.");
        Console.Write("Введите номер действия: ");

        string userInput = Console.ReadLine();

        if (userInput == "1")
        {
            Main();
        }
        else if (userInput == "2")
        {
            Environment.Exit(0);
        }
        else
        {
            Console.WriteLine("Неверный ввод. Пожалуйста, выберите номер действия из списка.");
            PromptUserToContinueOrExit();
        }
    }
    static int[] GenerateRandomArray(int size)
    {
        Random random = new Random();
        int[] array = new int[size];

        for (int i = 0; i < size; i++)
        {
            array[i] = random.Next(10, 101);
        }

        return array;
    }
    static void PrintArray(int[] array)
    {
        Console.Write("║");
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write($"{array[i],-4}│");
            if ((i + 1) % 8 == 0 && i != array.Length - 1)
            {
                Console.WriteLine("\n╠════╬════╬════╬════╬════╬════╬════╬════╣");
                Console.Write("║");
            }
        }
        Console.WriteLine("\n╚════╩════╩════╩════╩════╩════╩════╩════╝");
    }

    static void SortArray(int[] array)
    {
        Array.Sort(array);
    }

    static int CountOccurrences(int[] array, int key)
    {
        return array.Count(num => num == key);
    }

    static int SequentialSearch(int[] array, int key)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == key)
                return i;
        }

        return -1;
    }
}