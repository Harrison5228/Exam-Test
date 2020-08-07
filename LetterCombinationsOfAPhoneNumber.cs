public List<string> LetterCombinationsOfAPhoneNumber(string digits)
{
    String[] combinationsInKeys = { "", "", "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz" };

    List<string> result = new List<string>();

    if (digits == "")
        return result;

    if (digits.Length == 1)
        return split(combinationsInKeys[Convert.ToInt32(digits)]);

    Dictionary<string, List<string>> number_keys = new Dictionary<string, List<string>>();
    var index = 0;
    foreach(var item in combinationsInKeys)
    {
        number_keys.Add(index.ToString(), split(item));
        index++;
    }

    result = Combine(number_keys.FirstOrDefault(f => f.Key == digits[0].ToString()).Value, number_keys.FirstOrDefault(f => f.Key == digits[1].ToString()).Value);

    if (digits.Length > 2)
        for(int i = 2; i< digits.Length; i++)
            result = Combine(result, number_keys.FirstOrDefault(f => f.Key == digits[i].ToString()).Value);

    return result;

}

public List<string> split (string s)
{
    List<string> result = new List<string>();

    for (int i = 0; i < s.Length; i++)
    {
        result.Add(s[i].ToString());
    }

    return result;
}

public List<string> Combine(List<string> s1, List<string> s2)
{
    List<string> result = new List<string>();

    if (s1.Count == 0)
        return s2;
    else if (s2.Count == 0)
        return s1;

    foreach(var item1 in s1)
    {
        foreach(var item2 in s2)
        {
            result.Add(item1 + item2);
        }
    }
    return result;
}
