using System.Threading;
using System;
using lab_csharp_1;

namespace labscahrp1
{
    class Program
    {
        static void Main(string[] args)
        {
            (new Program()).Start();
        }

        void Start()
        {
            int numberOfThreads = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < numberOfThreads; i++)
            {
                int threadId = i + 1;
                Random random = new Random();
                int stepsToAdd = random.Next(1, 11); // Generates random number from 1 to 10
                Thread thread = new Thread(() => CalculateSum(threadId, stepsToAdd));
                thread.Start();
            }

            (new Thread(Stoper)).Start();

            Console.WriteLine(numberOfThreads + " threads are started please wait...");
        }

        void CalculateSum(int threadNumber, int stepsToAdd)
        {
            double sum = 0;
            double sumOfSteps = 0;
            do
            {
                sum += stepsToAdd;
                sumOfSteps++;
            } while (!canStop);

            Console.WriteLine($"Thread {threadNumber}: steps = {sumOfSteps},  sum = {sum}");
        }


        private bool canStop = false;

        public bool CanStop { get => canStop; }

        public void Stoper()
        {
            Thread.Sleep(1000 * 10);
            canStop = true;
        }
    }
}