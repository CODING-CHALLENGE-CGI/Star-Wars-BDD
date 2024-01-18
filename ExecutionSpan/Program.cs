using RecuperateDatas;
using System;
using System.Diagnostics;
using System.Threading;

namespace ExecutionSpan
{
    class Program
    {
        static Stopwatch stopWatch;
        static TimeSpan ts;
        static string elapsedTime;

        public static void Main(string[] args)
        {
            stopWatch = new Stopwatch();
            GetName();
            stopWatch.Restart();
            GetNameCorrected();
            stopWatch.Restart();
            GetHomePlanet();
            stopWatch.Restart();
            GetHomePlanetCorrected();
            stopWatch.Restart();
            GetCharacterEpisodes();
            stopWatch.Restart();
            GetCharacterEpisodesCorrected();

        }


        public static void GetName()
        {
            stopWatch.Start();
            GetDatas.GetName();
            StopAndDipslay();
            Console.WriteLine("RunTime for GetName is " + elapsedTime);
        }

        public static void GetNameCorrected()
        {
            stopWatch.Start();
            GetDatas.GetNameCorrected();
            StopAndDipslay();
            Console.WriteLine("RunTime for GetNameCorrected is " + elapsedTime);
        }

        public static void GetHomePlanet()
        {
            stopWatch.Start();
            GetDatas.GetHomePlanet();
            StopAndDipslay();
            Console.WriteLine("RunTime for GetHomePlanet is " + elapsedTime);
        }

        public static void GetHomePlanetCorrected()
        {
            stopWatch.Start();
            GetDatas.GetHomePlanetCorrected();
            StopAndDipslay();
            Console.WriteLine("RunTime for GetHomePlanetCorrected is " + elapsedTime);
        }
        public static void GetCharacterEpisodes()
        {
            stopWatch.Start();
            GetDatas.GetCharacterEpisodes();
            StopAndDipslay();
            Console.WriteLine("RunTime for GetCharacterEpisodes is " + elapsedTime);
        }

        public static void GetCharacterEpisodesCorrected()
        {
            stopWatch.Start();
            GetDatas.GetCharacterEpisodesCorrected();
            StopAndDipslay();
            Console.WriteLine("RunTime for GetCharacterEpisodesCorrected is " + elapsedTime);
        }
        private static void StopAndDipslay()
        {
            stopWatch.Stop();
            ts = stopWatch.Elapsed;
            elapsedTime = String.Format("{0:00}.{1:00}",
                ts.Seconds,
                ts.Milliseconds / 10);
        }
    }
}
