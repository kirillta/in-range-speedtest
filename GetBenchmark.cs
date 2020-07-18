using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace AgeRangeBenchmark
{
    [SimpleJob(RuntimeMoniker.NetCoreApp50)]
    [RPlotExporter, RankColumn, AllStatisticsColumn, MemoryDiagnoser]
    public class GetBenchmark
    {
        static GetBenchmark()
        {
            const int length = 5;
            var ages = new List<object>(length);

            var random = new Random();
            for (var i = 0; i < length; i++)
            {
                var value = random.Next(0, 25);
                ages.Add(value);
            }

            Ages = ages;
        }


        [GlobalSetup]
        public void Setup()
        {
            ClassicDefinition = GetClassicDefinition();
            FilterDefinition = GetFilterDefinition();

            _classicService = new Classics.OccupancyService();
            _filterService = new Filters.OccupancyService(FilterDefinition);
        }


        [Benchmark(Baseline = true)]
        [ArgumentsSource(nameof(Ages))]
        public AgeRangeTypes IsInRange_Classics(int age) 
            => _classicService!.IsInType(ClassicDefinition, age);


        [Benchmark]
        [ArgumentsSource(nameof(Ages))]
        public AgeRangeTypes IsInRange_Filters(int age) 
            => _filterService!.IsInRange(age);


        private static Classics.OccupancyDefinition GetClassicDefinition()
            => new Classics.OccupancyDefinition
            {
                Infant = new Classics.AgeRange
                {
                    LowerBound = 0,
                    UpperBound = 3
                },
                Child = new Classics.AgeRange
                {
                    LowerBound = 4,
                    UpperBound = 11
                },
                Adult = new Classics.AgeRange
                {
                    LowerBound = 12,
                    UpperBound = 200
                }
            };


        private static Filters.OccupancyDefinition GetFilterDefinition()
            => new Filters.OccupancyDefinition
            {
                Ranges = new List<Filters.AgeRange>
                {
                    new Filters.AgeRange(AgeRangeTypes.Infant, 0, 3),
                    new Filters.AgeRange(AgeRangeTypes.Child, 4, 11),
                    new Filters.AgeRange(AgeRangeTypes.Adult, 12, 200)
                }
            };


        public static IEnumerable<object> Ages { get; }

        public Classics.OccupancyDefinition ClassicDefinition = new Classics.OccupancyDefinition();
        public Filters.OccupancyDefinition FilterDefinition = new Filters.OccupancyDefinition();

        private Classics.OccupancyService? _classicService;
        private Filters.OccupancyService? _filterService;
    }
}
