using System.Collections;

namespace Common.TestData;

public class BrutforceArrays : IEnumerable<int[]>
{
    public class Enumerator : IEnumerator<int[]>
    {
        public int MinPossibleValue { get; }
        public int MaxPossibleValue { get; }


        public Enumerator(int itemsCount, int minPossibleValue, int maxPossibleValue)
        {
            MinPossibleValue = minPossibleValue;
            MaxPossibleValue = maxPossibleValue;


            Current = new int[itemsCount];
            Reset();
        }

        public bool MoveNext()
        {
            return Increment(Current, MinPossibleValue, MaxPossibleValue);
        }

        private static bool Increment(int[] nums, int minPossibleValue, int maxPossibleValue)
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

        public int[] Current { get; }

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            // nothing
        }
    }

    public int ItemsCount { get; }
    public int MinPossibleValue { get; }
    public int MaxPossibleValue { get; }

    public int CasesCount { get; }

    public BrutforceArrays(int itemsCount, int minPossibleValue, int maxPossibleValue)
    {
        ItemsCount = itemsCount;
        MinPossibleValue = minPossibleValue; 
        MaxPossibleValue = maxPossibleValue;

        CasesCount = (int)Math.Pow(MaxPossibleValue - MinPossibleValue + 1, ItemsCount);
    }

    public IEnumerator<int[]> GetEnumerator()
    {
        return new Enumerator(ItemsCount, MinPossibleValue, MaxPossibleValue);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}