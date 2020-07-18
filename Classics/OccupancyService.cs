using System;

namespace AgeRangeBenchmark.Classics
{
    public class OccupancyService
    {
        public AgeRangeTypes IsInType(OccupancyDefinition definition, int age)
        {
            var adult = definition.Adult;
            if (adult.LowerBound <= age && age <= adult.UpperBound)
                return AgeRangeTypes.Adult;

            var teenager = definition.Teenager;
            if (teenager != null)
            {
                if (teenager.LowerBound <= age && age <= teenager.UpperBound)
                    return AgeRangeTypes.Teenager;
            }

            var child = definition.Child;
            if (child != null)
            {
                if (child.LowerBound <= age && age <= child.UpperBound)
                    return AgeRangeTypes.Child;
            }

            var infant = definition.Infant;
            if (infant != null)
            {
                if (infant.LowerBound <= age && age <= infant.UpperBound)
                    return AgeRangeTypes.Infant;
            }

            //there are no overlapping ranges, because we check that on input, so we must never go here
            throw new NotImplementedException();
        }
    }
}
