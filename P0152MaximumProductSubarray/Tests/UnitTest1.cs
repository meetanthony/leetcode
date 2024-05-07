using Common.TestData;
using P0152MaximumProductSubarray;

namespace Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var brutforceArrays = new BruteForceArrays<int>(5, -3, 3);
            foreach (var nums in brutforceArrays)
            {
                var solveStupid = Stupid.Solve(nums);
                var solveFromBorders = Caterpillar.SolveFromBorders(nums);
                var solveSequentially = Caterpillar.SolveSequentially(nums);

                Assert.True(solveStupid == solveFromBorders);
                Assert.True(solveFromBorders == solveSequentially);
            }
        }
    }
}