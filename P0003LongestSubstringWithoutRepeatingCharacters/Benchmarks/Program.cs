using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Common.TestData;
using P3LongestSubstringWithoutRepeatingCharacters;

namespace Benchmarks
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<CountersBenchmark>();
        }
    }

    public class CountersBenchmark
    {
        private readonly BruteForceArrays<char> _brutforceArrays = new(8, 'a', 'h');

        [Benchmark]
        public void DictionaryCounter()
        {
            var dictCounter = new DictionaryCounter();
            foreach (var array in _brutforceArrays)
            {
                var str = new string(array);
                dictCounter.GetLength(str);
            }
        }

        [Benchmark]
        public void HashSetCounter()
        {
            var dictCounter = new HashSetCounter();
            foreach (var array in _brutforceArrays)
            {
                var str = new string(array);
                dictCounter.GetLength(str);
            }
        }

        [Benchmark]
        public void SlidingHashSetCounter()
        {
            var dictCounter = new SlidingHashSetCounter();
            foreach (var array in _brutforceArrays)
            {
                var str = new string(array);
                dictCounter.GetLength(str);
            }
        }
    }
}