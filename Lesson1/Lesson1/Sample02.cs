using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1;

class ThreadControl
{
    
    public bool IsActive { get; set; }

}

internal class Sample02
{
    static void Main(string[] args)
    {
        Console.WriteLine("Начало работы приложения ...");

        Task1();
        Task2();

        Console.WriteLine("Завершение работы приложения ...");
        Console.ReadKey();
    }

    static void Task2()
    {
        DateTime start = DateTime.Now;
        float[] arr = new float[200_000_000];

        AutoResetEvent[] waitHandlers = new AutoResetEvent[2];
        for (int i = 0; i < waitHandlers.Length; i++)
            waitHandlers[i] = new AutoResetEvent(false);
        
        Thread[] threads = new Thread[2];

        threads[0] = new Thread((o) =>
        {
            for (int i = 0; i < arr.Length / 2; i++)
                arr[i] = 1;

            for (int i = 0; i < arr.Length / 2; i++)
                arr[i] = (float)(arr[i]
                    * Math.Sin(0.2f + i / 5)
                    * Math.Cos(0.2f + i / 5)
                    * Math.Cos(0.4f + i / 2));

            ((AutoResetEvent)o).Set();
        });

        threads[1] = new Thread((o) =>
        {
            for (int i = arr.Length / 2; i < arr.Length; i++)
                arr[i] = 1;

            for (int i = arr.Length / 2; i < arr.Length; i++)
                arr[i] = (float)(arr[i]
                    * Math.Sin(0.2f + i / 5)
                    * Math.Cos(0.2f + i / 5)
                    * Math.Cos(0.4f + i / 2));
            
            ((AutoResetEvent)o).Set();
        });

        threads[0].Start(waitHandlers[0]);
        threads[1].Start(waitHandlers[1]);


        WaitHandle.WaitAll(waitHandlers);


        DateTime finish = DateTime.Now;
        Console.WriteLine($"Инициализация массива заняла у нас:  " +
            $"{finish - start} сек.");
    }


    static void Task1()
    {
        DateTime start = DateTime.Now;
        float[] arr = new float[200_000_000];

        for (int i = 0; i < arr.Length; i++)
            arr[i] = 1;

        for (int i = 0; i < arr.Length; i++)
            arr[i] = (float)(arr[i]
                * Math.Sin(0.2f + i / 5)
                * Math.Cos(0.2f + i / 5)
                * Math.Cos(0.4f + i / 2));

        DateTime finish = DateTime.Now;
        Console.WriteLine($"Инициализация массива заняла у нас:  " +
            $"{finish - start} сек.");
    }
}
