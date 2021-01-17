using System;
using System.IO;
using System.Threading;
using System.Diagnostics;
namespace hilos_deber
{
    class program
    {
        const string path = @"C:\Users\User\Desktop\Consolas\Hilos_Deber\archivos_Hilos\";
        static void Main(string[] args)
        {
            Console.WriteLine("Steven Chinchin");

            Console.WriteLine(" el que saque 10 0 5 gana ");
            for (int i = 1; i < 50; i++)
            {
                ThreadPool.QueueUserWorkItem(Create, i);
            }
            while (ThreadPool.PendingWorkItemCount > 0) ;
        }
        static void Create(Object data)
        {
            var tw = Stopwatch.StartNew();
         
            // creamos valor ramdomico 
            Random aleatorio = new Random();
            int num = aleatorio.Next(1,11);
            
            int i = (int)data; // creacionde archivos 
          
            while (tw.ElapsedMilliseconds <= 10000)
            {
                using (var sw = new StreamWriter(path + i + ".txt"))
                {
                    if (num == 10 || num == 1)
                    {

                        sw.WriteLine("Eganado  =  " + Thread.CurrentThread.ManagedThreadId + " me demore {0} segundos "  , tw.ElapsedMilliseconds / 1000.0);
                        Console.Read();
                        tw.Stop();
                    }
                    else
                    {
                        Console.WriteLine("Hola soy el hilo" + Thread.CurrentThread.ManagedThreadId + "  =sigo partidipando  con " + num  +" me demore {0} segundos ",tw.ElapsedMilliseconds/1000.0);
                        Console.WriteLine("aun nadie gana ");
                        Console.Read();
                        tw.Stop();
                    }
                }
            }

            Console.Read();

        }
    }
}