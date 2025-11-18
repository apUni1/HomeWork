using System;
using System.Data.Common;
using System.Diagnostics;
using System.Threading.Tasks;

namespace apLab3;
public class Program
{
    static void Main()
    {
        bool menuRun = true;
        while (menuRun)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("------ МЕНЮ ------");
            Console.ResetColor();
            Console.WriteLine("1. Отгадай ответ");
            Console.WriteLine("2. Об авторе");
            Console.WriteLine("3. Сортировка массивов");
            Console.WriteLine("4. Игра");
            Console.WriteLine("5. Выход");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("------------------");
            Console.ResetColor();
            string phrase = "Выберите действие: ";
            double choice = UserAnswer(phrase);


            switch (choice)
            {

                case 1:
                    GuessGame();
                    break;

                case 2:
                    Author();
                    break;

                case 3:
                    Box();
                    break;

                case 4:
                    MagicSquare();
                    break;

                case 5:
                    if (ExitControl()) menuRun = false;
                    break;

            }
        }
    }

    static void GuessGame()
    {
        Console.Clear();
        double a = 0;
        double b = 0;
        bool takeA = true;
        bool takeB = true;
        while (takeA)
        {
            string phrase1 = "Введите значение для переменной a: ";
            a = (double)UserAnswer(phrase1);
            if (4 + a / 3 == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Данное число не подойдёт для вычислений. Попробуйте ещё раз.");
                Console.ResetColor();
            }
            else takeA = false;

        }
        while (takeB)
        {
            string phrase2 = "Введите значение для переменной b: ";
            b = (double)UserAnswer(phrase2);
            if (Math.Cos(b) < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Данное число не подойдёт для вычислений. Попробуйте ещё раз.");
                Console.ResetColor();
            }
            else takeB = false;
        }

        double correctAnswer = Func(a, b);
        GuessControl(correctAnswer);

        Console.WriteLine("Для возвращения в главное меню нажмите любую клавишу.");
        Console.ReadKey();
    }
    static void Author()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("---------- Об авторе -----------");
        Console.ResetColor();
        Console.WriteLine("ФИО: Пеганова Анна Станиславовна");
        Console.WriteLine("Группа: 6104-090301D");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("--------------------------------");
        Console.ResetColor();
        Console.WriteLine("Для возвращения в главное меню нажмите любую клавишу.");
        Console.ReadLine();
    }

    static void Box()
    {
        Console.Clear();
        int len = BoxLength();
        int[] box = BoxMaker(len);
        int[] copyBox1 = CopyMaker(box);
        int[] copyBox2 = CopyMaker(box);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Заданный массив: ");
        Console.ResetColor();
        ShowBox(box);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nОтсортированный массив 1: ");
        Console.ResetColor();
        int[] sortedBox1 = GnomeSort(copyBox1);
        ShowBox(sortedBox1);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nОтсортированный массив 2: ");
        Console.ResetColor();
        int[] sortedBox2 = MixSort(copyBox2);
        ShowBox(sortedBox2);

        Console.WriteLine("\nДля возвращения в главное меню нажмите любую клавишу.");
        Console.ReadKey();
    }
    static int BoxLength()
    {
        int ans = 0;
        bool ask = true;
        while (ask)
        {
            string phrase = "Введите длину массива: ";
            int len = UserAnswer(phrase);
            if (len > 0)
            {
                ans = len;
                ask = false;
            }
        }
        return ans;
    }

    static int[] BoxMaker(int len)
    {
        int i = 0;
        Random randomNumbers = new Random();
        int[] numbers = new int[len];
        while (i < len)
        {
            numbers[i] = randomNumbers.Next();
            i++;
        }
        return numbers;
    }

    static int[] CopyMaker(int[] box)
    {
        int[] boxCopy = new int[box.Length];
        for (int i = 0; i < box.Length; i++)
        {
            boxCopy[i] = box[i];
        }
        return boxCopy;
    }

    static void ShowBox(int[] box)
    {
        if (box.Length > 10) Console.WriteLine("Массивы не могут быть выведены на экран, так как длина массива больше 10.");
        else
        {
            int i = 0;
            for (; i < box.Length; i++)
            {
                Console.Write($"{box[i]} ");
            }
        }
    }

    static int[] GnomeSort(int[] box)
    {
        Stopwatch time = new Stopwatch();
        time.Start();
        int i = 1;
        while (i < box.Length)
        {
            if (box[i - 1] < box[i])
            {
                i++;
            }
            else
            {
                int swp = box[i - 1];
                box[i - 1] = box[i];
                box[i] = swp;
                --i;

                if (i == 0)
                {
                    i++;
                }
            }
        }
        time.Stop();
        Console.WriteLine($"Время сортировки: {time.ElapsedMilliseconds} мс");
        return box;
    }

    static int[] MixSort(int[] box)
    {
        Stopwatch time = new Stopwatch();
        time.Start();
        int start = 0;
        int end = box.Length - 1;
        while (start < end)
        {
            for (int i = start; i < end; i++)
            {
                if (box[i] > box[i + 1])
                {
                    int swp = box[i];
                    box[i] = box[i + 1];
                    box[i + 1] = swp;
                }
            }
            end--;

            for (int i = end; i > start; i--)
            {
                if (box[i - 1] > box[i])
                {
                    int swp = box[i - 1];
                    box[i - 1] = box[i];
                    box[i] = swp;
                }
            }
            start++;
        }
        time.Stop();
        Console.WriteLine($"Время сортировки: {time.ElapsedMilliseconds} мс");
        return box;
    }

    static bool ExitControl()
    {

        Console.Clear();
        bool exitRun = true;
        bool ans = false;
        while (exitRun)
        {
            Console.Write("Хотите выйти из программы? (д - да, н - нет): ");
            string exitOrNot = Console.ReadLine()?.ToLower();

            if (exitOrNot == "д")
            {
                ans = true;
                exitRun = false;
            }
            else if (exitOrNot == "н")
            {
                ans = false;
                exitRun = false;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Некорректный ввод данных. Введите 'д' или 'н'");
                Console.ResetColor();
            }
        }
        return ans;
    }

    static int UserAnswer(string phrase)
    {
        bool ask = true;
        int res = 0;
        while (ask)
        {
            Console.Write(phrase);
            string nums = Console.ReadLine();
            if (int.TryParse(nums, out int num))
            {
                res = num;
                ask = false;
            }

            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Некорректный ввод данных. Попробуйте ещё раз.");
                Console.ResetColor();
            }
            
        }
        return res;
    }

    static double Func(double a, double b)
    {
        double correctAnswer = Math.Round(Math.Pow(Math.Sin(3 * Math.PI / 4 + a / 3), 2) + Math.Sqrt(Math.Cos(b)));
        return correctAnswer;
    }

    static void GuessControl(double correctAnswer)
    {
        const int attempts = 3;
        int attemptsLeft = attempts;
        bool goodGuess = false;
        string phrase = "Ваша догадка: ";
        while (attemptsLeft > 0 && !goodGuess)
        {
            Console.WriteLine($"Количество оставшихся попыток: {attemptsLeft} ");
            double userGuess = UserAnswer(phrase);


            userGuess = Math.Round(userGuess, 2);
            if (userGuess == correctAnswer)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Ответ верный! Вы победили!");
                Console.ResetColor();
                goodGuess = true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ответ неверный.");
                Console.ResetColor();
                attemptsLeft--;
            }

        }

        if (!goodGuess)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Вы проиграли. Правильный ответ: {correctAnswer}");
            Console.ResetColor();
        }
    }

    static void MagicSquare()
    {
        Console.Clear();
        int count = 0;
        bool endgame = false;
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("МАГИЧЕСКИЙ КВАДРАТ");
        Console.WriteLine(" --- --- --- ");
        Console.WriteLine("|   |   |   |");
        Console.WriteLine(" --- --- --- ");
        Console.WriteLine("|   |   |   |");
        Console.WriteLine(" --- --- --- ");
        Console.WriteLine("|   |   |   |");
        Console.WriteLine(" --- --- --- ");
        int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        int[] availableNumbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        int[,] board = GameBoard();
        int[] onBoard = new int[9];
        while (!endgame)
        {
            endgame = Turn(board, availableNumbers, onBoard);
            count++;
            GameBoardNow(board);
            if (count == 9)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Вы победили!");
                Console.ResetColor();
                Console.ReadKey();
                endgame = true;
            }
        }
        return;
    }

    static int[,] GameBoard()
    {
        int[,] board = new int[3, 3];
        return board;
    }

    static void GameBoardNow(int[,] board)
    {

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(" --- --- --- ");
        Console.WriteLine($"| {board[0, 0]} | {board[0, 1]} | {board[0, 2]} |");
        Console.WriteLine(" --- --- --- ");
        Console.WriteLine($"| {board[1, 0]} | {board[1, 1]} | {board[1, 2]} |");
        Console.WriteLine(" --- --- --- ");
        Console.WriteLine($"| {board[2, 0]} | {board[2, 1]} | {board[2, 2]} |");
        Console.WriteLine(" --- --- --- ");
        
        
    }

    static bool Turn(int[,] board, int[] avNums, int[] onBoard)
    {
        int num = 0;
        for (int i = 0; i < avNums.Length; i++)
        {
            if (Array.IndexOf(onBoard, avNums[i]) != -1)
            {
                avNums[i] = 0;
            }
        }
        Console.Write("Доступные числа:");
        for (int i = 0; i < avNums.Length; i++)
        {
            if (avNums[i] != 0) Console.Write($" {avNums[i]}");
        }
        num = GetNumber(avNums);
        int[] place= GetPlace(board, onBoard);
        int line = place[0];
        int column = place[1];
        board[line-1, column-1] = num;
        onBoard[line + column] = num;
        
        int[] lines = { board[0, 0] + board[0, 1] + board[0, 2], board[1, 0] + board[1, 1] + board[1, 2], board[2, 0] + board[2, 1] + board[2, 2] };
        int[] columns = { board[0, 0] + board[1, 0] + board[2, 0], board[0, 1] + board[1, 1] + board[2, 1], board[0, 2] + board[1, 2] + board[2, 2] };
        switch (line)
        {
            case 1:
                if ((board[0, 0] != 0 && board[0, 1] != 0 && board[0, 2] != 0) && lines[0] != 15)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Числа расставлены неверно. Вы проиграли.");
                    Console.ReadKey();
                    return true;
                    
                }
                break;
            case 2:
                if ((board[1, 0] != 0 && board[1, 1] != 0 && board[1, 2] != 0) && lines[1] != 15)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Числа расставлены неверно. Вы проиграли.");
                    Console.ReadKey();
                    return true;

                }
                break;
            case 3:
                if ((board[2, 0] != 0 && board[2, 1] != 0 && board[2, 2] != 0) && lines[2] != 15)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Числа расставлены неверно. Вы проиграли.");
                    Console.ReadKey();
                    return true;

                }
                break;
        }
        switch (column)
        {
            case 1:
                if ((board[0, 0] != 0 && board[1, 0] != 0 && board[2, 0] != 0) && columns[0] != 15)
                {
                    Console.WriteLine("Числа расставлены неверно. Вы проиграли.");
                    Console.ReadKey();
                    return true;

                }
                break;
            case 2:
                if ((board[0, 1] != 0 && board[1, 1] != 0 && board[2, 1] != 0) && columns[1] != 15)
                {
                    Console.WriteLine("Числа расставлены неверно. Вы проиграли.");
                    Console.ReadKey();
                    return true;

                }
                break;
            case 3:
                if ((board[0, 2] != 0 && board[1, 2] != 0 && board[2, 2] != 0) && columns[2] != 15)
                {
                    Console.WriteLine("Числа расставлены неверно. Вы проиграли.");
                    Console.ReadKey();
                    return true;

                }
                break;
        }
        return false;

    }

    static int[] GetPlace(int[,] board, int[]onBoard)
    {
        bool ask = true;
        int[] res = new int[2];
        while (ask) 
        { 
            Console.Write("\nВыберите строку: ");
            int num1 = 0;
            while (ask)
            {
                string nums = Console.ReadLine();
                if (int.TryParse(nums, out num1) && num1> 0 && num1<4)
                {
                    switch(num1)
                    {
                        case 1:
                            if (onBoard[0] == 0 || onBoard[1] == 0 || onBoard[2] == 0)
                            {
                                res[0] = num1;
                                ask = false;
                            }
                            break;
                        case 2:
                            if (onBoard[3] == 0 || onBoard[4] == 0 || onBoard[5] == 0)
                            {
                                res[0] = num1;
                                ask = false;
                            }
                            break;
                        case 3:
                            if (onBoard[6] == 0 || onBoard[7] == 0 || onBoard[8] == 0)
                            {
                                res[0] = num1;
                                ask = false;
                            }
                            break;
                        default:
                            Console.WriteLine("Данная строка заполнена. Выберите другую");
                            break;
                    }
                
                
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Некорректный ввод данных. Попробуйте ещё раз.");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
            }
            Console.Write("\nВыберите столбец: ");
            ask = true;
            int num2 = 0;
        
                while (ask)
                {
                    string nums = Console.ReadLine();
                    if (int.TryParse(nums, out num2) && num2 > 0 && num2 < 4)
                    {
                        switch (num2)
                        {
                            case 1:
                                if (onBoard[0] == 0 || onBoard[3] == 0 || onBoard[6] == 0)
                                {
                                    res[1] = num2;
                                    ask = false;
                                }
                                break;
                            case 2:
                                if (onBoard[1] == 0 || onBoard[4] == 0 || onBoard[7] == 0)
                                {
                                    res[1] = num2;
                                    ask = false;
                                }
                                break;
                            case 3:
                                if (onBoard[2] == 0 || onBoard[5] == 0 || onBoard[8] == 0)
                                {
                                    res[1] = num2;
                                    ask = false;
                                }
                                break;
                            default:
                                Console.WriteLine("Данный столбец заполнен. Выберите другой.");
                                break;
                        }


                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Некорректный ввод данных. Попробуйте ещё раз.");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }

                }
                if (board[res[0] - 1, res[1] - 1] != 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Данное место занято. Выберите другое.");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    ask = true;
                }
        }
        return res;
    }
    static int GetNumber(int[] avNums)
    {
        Console.Write("\nВыберите число: ");
        bool ask = true;
        int num = 0;
        int res = 0;
        while (ask)
        {
            string nums = Console.ReadLine();
            if (int.TryParse(nums, out num))
            {
                if (Array.IndexOf(avNums, num) != -1 && num != 0)
                {
                    res = num;
                    ask = false;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ведите число из списка доступных чисел.");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Некорректный ввод данных. Попробуйте ещё раз.");
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
        }
        return res;
    }
}
