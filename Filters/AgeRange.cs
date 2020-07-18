namespace AgeRangeBenchmark.Filters
{
    public readonly struct AgeRange
    {
        public AgeRange(AgeRangeTypes type, int lowerBound, int upperBound)
        {
            LowerBound = lowerBound;
            Type = type;
            UpperBound = upperBound;
        }


        public int LowerBound { get; }
        public AgeRangeTypes Type { get; }
        public int UpperBound { get; }


        public override bool Equals(object? obj) => obj is AgeRange other && Equals(other);


        public bool Equals(AgeRange other)
            => (LowerBound, UpperBound, Type) == (other.LowerBound, other.UpperBound, other.Type);


        public override int GetHashCode() => (LowerBound, UpperBound, Type).GetHashCode();
    }
}
