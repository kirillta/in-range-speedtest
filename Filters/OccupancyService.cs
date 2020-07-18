using System.Collections.Generic;

namespace AgeRangeBenchmark.Filters
{
    public class OccupancyService
    {
        public OccupancyService(OccupancyDefinition definition)
        {
            _filter = new Dictionary<int, AgeRangeTypes>(definition.Ranges.Count);

            //assuming there are no overlapping ranges, because we check that on input
            foreach (var range in definition.Ranges)
            {
                /*if (range.Type == AgeRangeTypes.Adult)
                    continue;*/

                var type = range.Type;
                for (var i = range.LowerBound; i < range.UpperBound + 1; i++)
                    _filter.Add(i, type);
            }
        }


        public AgeRangeTypes IsInRange(int age) 
            => _filter.TryGetValue(age, out AgeRangeTypes type) ? type : AgeRangeTypes.Adult;


        private readonly Dictionary<int, AgeRangeTypes> _filter;
    }
}
