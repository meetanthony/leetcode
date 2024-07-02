namespace P0198HouseRobber;

public interface IRobber
{
    int Rob(int[] nums);

    long IterationsComplete { get; }
}