﻿namespace AgeRangeBenchmark.Classics
{
    public class AgeRange
    {
        public int LowerBound { get; set; }
        public int UpperBound { get; set; }


        public override bool Equals(object? obj) => obj is AgeRange other && Equals(other);


        public bool Equals(AgeRange other)
            => (LowerBound, UpperBound) == (other.LowerBound, other.UpperBound);


        public override int GetHashCode() => (LowerBound, UpperBound).GetHashCode();
    }
}
