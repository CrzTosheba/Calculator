using System;

namespace Calculator
{ 

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

    class Program
    {
        static void Main(string[] args)
        {
           
         
            Calc<int> mc1 = new Calc<int>();
        
            Console.WriteLine("Введите число 1");
            int Num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите число 2");
            int Num2 = Convert.ToInt32(Console.ReadLine());
             double res1 = mc1.Add(Num1, Num2);

            Console.WriteLine("Результат сложения = {0}", res1);
            Console.ReadKey();
        }
    }
}