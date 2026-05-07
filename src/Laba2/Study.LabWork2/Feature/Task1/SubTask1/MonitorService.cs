using Study.LabWork2.Abstractions.Feature.Task1.SubTask1;
using Study.LabWork2.Abstractions.Feature.Task1.SubTask1.DtoModels;

namespace Study.LabWork2.Feature.Task1.SubTask1;

/// <summary>
/// Версия 1. Использует Monitor (lock) для синхронизации
/// </summary>
public sealed class MonitorService : IPrimeCounter
{
    public PrimeCountResultDto CountPrimes(int start, int end, int threadCount)
    {
        int total = 0;
        var lockObj = new object();
        var threads = new Thread[threadCount];
        var foundPrimes = new List<int>();
        int range = (end - start) / threadCount;

        var stopwatch = Stopwatch.StartNew();

        for (int i = 0; i < threadCount; i++)
        {
            int localStart = start + i * range;
            int localEnd = (i == threadCount - 1) ? end : localStart + range;

            threads[i] = new Thread(() =>
            {
                int localCnt = 0;
                var localPrimes = new List<int>();

                for (int num = localStart; num <= localEnd; num++)
                {
                    if (IsPrime(num))
                    {
                        localCnt++;
                        localPrimes.Add(num);
                    }
                }

                Monitor.Enter(lockObj);
                try
                {
                    total += localCnt;
                    foundPrimes.AddRange(localPrimes);
                }
                finally { Monitor.Exit(lockObj); }
            });
            threads[i].Start();
        }

        foreach (var t in threads) t.Join();
        stopwatch.Stop();

        return new PrimeCountResultDto
        {
            PrimeCount = total,
            ExecutionTime = stopwatch.Elapsed,
            ThreadCount = threadCount,
            SynchronizationType = GetVersionName(),
            FoundPrimes = foundPrimes
        };
    }

    static public string GetVersionName() => "Monitor";

    //функция для проверки
    private static bool IsPrime(int n)
    {
        if (n < 2 && n % 2 == 0) return false;
        if (n == 2) return true;
        for (int i = 3; i * i <= n; ++i)
            if (n % i == 0) return false;
        return true;
    }
}
