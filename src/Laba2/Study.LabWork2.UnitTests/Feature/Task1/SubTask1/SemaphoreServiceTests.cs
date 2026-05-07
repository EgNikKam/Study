namespace Study.LabWork2.UnitTests.Feature.Task1.SubTask1;

[TestFixture]
public sealed class SemaphoreServiceTests
{
    private readonly SemaphoreService _service = new();

    [Fact]
    public void CountPrimes_SmallRange_ReturnsCorrectCount()
    {
        var result = _service.CountPrimes(1, 10, 2);
        Assert.Equal(4, result.PrimeCount);
    }


    [Fact]
    public void CountPrimes_LargeRange_ReturnCorrectNum()
    {
        var result = _service.CoutPrime(1, 10000, 4);
        Assert.Equal(1229, result.PrimeCount);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(4)]
    [InlineData(6)]
    public void CountPrimes_DefferentThreadsCounts_SameResult(int threadCount)
    {
        var result = _service.CoutPrime(1, 10000, threadCount);
        Assert.Equal(1229, result.PrimeCount);
    }

    [Fact]
    public void CountPrimes_ReturnsCorrectThreadCount()
    {
        var result = _service.CountPrimes(1, 100, 4);
        Assert.Equal(4, result.ThreadCount);
    }

    [Fact]
    public void CountPrimes_ReturnsSynchronizationType()
    {
        var result = _service.CountPrimes(1, 100, 4);
        Assert.Equal("Semaphore", result.SynchronizationType);
    }

    [Fact]
    public void CountPrimes_FoundPrimesMatchCount()
    {
        var result = _service.CountPrimes(1, 100, 4);
        Assert.Equal(result.PrimeCount, result.FoundPrimes.Count);
    }

    [Fact]
    public void CountPrimes_ExecutionTimeIsPositive()
    {
        var result = _service.CountPrimes(1, 10000, 4);
        Assert.True(result.ExecutionTime > TimeSpan.Zero);
    }

    [Fact]
    public void IsValid_CorrectExpected_ReturnsTrue()
    {
        var result = _service.CountPrimes(1, 10000, 4);
        Assert.True(result.IsValid(1229));
    }

    // GetVersionName
    [Fact]
    public void GetVersionName_ReturnsMonitor()
    {
        Assert.Equal("Semaphore", _service.GetVersionName());
    }
}
