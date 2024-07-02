namespace P0198HouseRobber;

public class Solution : IRobber
{
    public int Rob(int[] nums)
    {
        if (nums.Length == 0) return 0;
        if (nums.Length == 1) return nums[0];

        IterationsComplete = nums.Length;

        var sums = new int[nums.Length];
        sums[0] = nums[0];
        sums[1] = Math.Max(nums[0], nums[1]);

        for (int i = 2; i < nums.Length; i++)
        {
            var n = nums[i];
            sums[i] = Math.Max(n + sums[i - 2], sums[i - 1]);
        }

        return sums[^1];
    }

    public long IterationsComplete { get; private set; }
}