using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Running;

namespace AgeRangeBenchmark
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var config = DefaultConfig.Instance;
            config.AddColumnProvider(DefaultColumnProviders.Instance);
            config.AddLogger(new ConsoleLogger());
            config.AddDiagnoser(MemoryDiagnoser.Default);
            var summary = BenchmarkRunner.Run<GetBenchmark>(config.WithOptions(ConfigOptions.DisableOptimizationsValidator));

            System.Console.WriteLine(summary);
        }
    }
}
