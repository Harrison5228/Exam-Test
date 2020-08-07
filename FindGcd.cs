public int Main()
{
    int[] nums = { 32, 8, 16 };

    int result = gcd(nums[0], nums[1]);

    if (nums.Length == 0)
        return 0;

    if (nums.Length == 1)
        return nums[0];

    if (nums.Length < 3)
    {
        result = gcd(nums[0], nums[1]);
    }
    else
    {
        for (int i = 2; i < nums.Length; i++)
        {
            result = gcd(result, nums[i]);
        }
    }

    return result;

}

//recursive
public int gcd(int a, int b)
{
    if(a == 1 || b == 1)
    {
        return 1;
    }

    if(a < b)
    {
        return gcd(b, a);
    }

    if(a % b == 0)
    {
        return b;
    }
    else
    {
        return gcd(b, a % b);
    }
}
