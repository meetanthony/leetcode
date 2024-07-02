namespace P0198HouseRobber;

public class StupidSolution : IRobber
{
    public int Rob(int[] nums)
    {
        if (nums.Length == 0) return 0;
        if (nums.Length == 1) return nums[0];

        IterationsComplete = 0;

        var max = 0;

        for (int i = 0; i < 2; i++)
        {
            max = Math.Max(max, RobFromThis(nums, i));
        }

        return max;
    }

    public long IterationsComplete { get; private set; }

    private int RobFromThis(int[] nums, int start)
    {
        IterationsComplete++;
        var init = nums[start];
        var max = init;

        for (int i = start + 2; i < nums.Length; i++)
        {
            var result = RobFromThis(nums, i) + init;
            if (result > max)
                max = result;
        }

        return max;
    }
}