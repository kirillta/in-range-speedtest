using System.Collections.Generic;
using System.Linq;

namespace AgeRangeBenchmark.Filters
{
    public class OccupancyService
    {
        public OccupancyService(OccupancyDefinition definition)
        {
            //assuming there are no overlapping ranges, because we check that on input
            var maxAge = definition.Ranges
                .Where(r => r.Type == AgeRangeTypes.Adult)
                .Select(r => r.UpperBound)
                .First();
            
            _filter = new AgeRangeTypes[maxAge + 1];

            foreach (var range in definition.Ranges)
            {
                var type = range.Type;
                for (var i = range.LowerBound; i < range.UpperBound + 1; i++)
                    _filter[i] = type;
            }
        }


        public AgeRangeTypes IsInRange(int age) 
            => _filter[age];


        private readonly AgeRangeTypes[] _filter;
    }
}
