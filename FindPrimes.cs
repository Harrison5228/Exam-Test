int m = 1;
int n = 50;
List<int> result = new List<int>();

for (int i = m; i <= n; i++)
{
    bool notPrime = false;

    if (i == 1)
        continue;

    int Sqrt = Convert.ToInt32(Math.Sqrt(i));
    for(int j = 2; j <= Sqrt; j++)
    {
        if (i % j == 0)
            notPrime = true;
    }
    if (!notPrime)
        result.Add(i);
}

return result;
