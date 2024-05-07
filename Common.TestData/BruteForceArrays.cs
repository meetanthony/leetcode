using System.Collections;
using System.Numerics;

namespace Common.TestData;

public class BruteForceArrays<T> : IEnumerable<T[]> where T : INumber<T>
{
    public class Enumerator : IEnumerator<T[]>
    {
        public T MinPossibleValue { get; }
        public T MaxPossibleValue { get; }

        public Enumerator(int itemsCount, T minPossibleValue, T maxPossibleValue)
        {
            MinPossibleValue = minPossibleValue;
            MaxPossibleValue = maxPossibleValue;
            
            Current = new T[itemsCount];
            Reset();
        }

        public bool MoveNext()
        {
            return Increment(Current, MinPossibleValue, MaxPossibleValue);
        }

        private static bool Increment(T[] nums, T minPossibleValue, T maxPossibleValue)
        {
            int currentElement = 0;
            while (currentElement < nums.Length)
            {
                if (nums[currentElement] != maxPossibleValue)
                {
                    nums[currentElement]++;
                    return true;
                }
                    
                nums[currentElement] = minPossibleValue;
                currentElement++;
            }

            return false;
        }

        public void Reset()
        {
            Array.Fill(Current, MinPossibleValue);
            if (Current.Length > 0)
                Current[0]--;
        }

        public T[] Current { get; }

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            // nothing
        }
    }

    public int ItemsCount { get; }
    public T MinPossibleValue { get; }
    public T MaxPossibleValue { get; }

    public long CasesCount { get; }

    public BruteForceArrays(int itemsCount, T minPossibleValue, T maxPossibleValue)
    {
        ItemsCount = itemsCount;
        MinPossibleValue = minPossibleValue; 
        MaxPossibleValue = maxPossibleValue;

        T diff = MaxPossibleValue - MinPossibleValue;
        
        CasesCount = (long)Math.Pow(Convert.ToInt64(diff) + 1, ItemsCount);
    }

    public IEnumerator<T[]> GetEnumerator()
    {
        return new Enumerator(ItemsCount, MinPossibleValue, MaxPossibleValue);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}