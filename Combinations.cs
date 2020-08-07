List<string> strings = new List<String>();
strings.Add("A");
strings.Add("B");
strings.Add("C");
strings.Add("D");

List<string> result = new List<string>();

for(int i = 0; i < strings.Count; i++)
{
    //C41
    result.Add(strings[i]);

    for (int j = i + 1; j < strings.Count; j++)
    {
        //C42
        result.Add(strings[i] + strings[j]);


        for (int k = j + 1; k < strings.Count; k++)
        {
            //C43
            result.Add(strings[i] + strings[j] + strings[k]);

            for (int l = k + 1; l < strings.Count; l++)
            {
                C44
                result.Add(strings[i] + strings[j] + strings[k] + strings[l]);
            }
        }
    }
}
return result;
