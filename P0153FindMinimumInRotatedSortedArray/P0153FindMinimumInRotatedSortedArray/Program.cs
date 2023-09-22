namespace P0153FindMinimumInRotatedSortedArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    public interface IMinimumFinder
    {
        int FindMin(int[] nums);
    }

    public class Stupid : IMinimumFinder
    {
        public int FindMin(int[] nums)
        {
            var min = int.MinValue;
            foreach (var num in nums)
            {
                if (num > min)
                    min = num;
            }
            return min;
        }
    }
}