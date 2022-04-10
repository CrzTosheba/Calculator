using System;
using System.Collections;

namespace Calculator
{ 


    class Program
    {
   
        public static void Main(string[] args)
        {
            ICalcLog log = new CalcLog();
            ICalcLog err = new CalcLog();
           
            
            
            Calc<int> mc1 = new Calc<int>();
            while (true)
            {
                

                try
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Введите число 1");
                    int Num1 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите число 2");
                    int Num2 = Convert.ToInt32(Console.ReadLine());
                    double res1 = mc1.Add(Num1, Num2);
                    log.Event("");
                    Console.WriteLine("{0}", res1);
                    string? str = UserMenu();
                    //Console.ReadKey();

                }
                catch (ExitException e)
                {
                    
                    break;

                }
                catch (Exception e)
                {
                    Console.WriteLine($"Ошибка: {e.Message}");
                    err.Error("");

                }


            }
           





        }
        private static string? UserMenu()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Для выхода введите '-q'");
            Console.WriteLine("Или нажмите любую клавишу для повтора");
            string? str = Console.ReadLine();
            if (str == "-q")
                throw new ExitException();
            return str;
        }
    }
    
    // Интерфейс, получающий параметром тип T
    interface ICalculate<T>
    {
        // Объявление методов, которые используют тип T
        double Add(T var1, T var2);

    }


    class Calc<T> : ICalculate<T>
    {
        // Реализация метода, который использует тип T
        public double Add(T var1, T var2)
        {
            double res = Convert.ToDouble(var1) + Convert.ToDouble(var2);
            return res;
        }


    }
    public interface ICalcLog
    {
        void Event(string message);
        
        void Error(string message);

    }
    public class CalcLog : ICalcLog
    {
        public void Event(string message)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Результат сложения");
        }

        public void Error(string message)
        {
            
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Ввели что-то не то ");
        }
    }


}