public List<string> WordCount(string[] names)
{
    String paragraph = "Wikileaks began on Sunday November 28th publishing 251,287 leaked United States embassy cables, the largest set of confidential documents ever to be released into the public domain. The documents will give people around the world an unprecedented insight into US Government foreign activities."
          + "The cables, which date from 1966 up until the end of February this year, contain confidential communications between 274 embassies in countries throughout the world and the State Department in Washington DC. 15,652 of the cables are classified Secret."
          + "The embassy cables will be released in stages over the next few months. The subject matter of these cables is of such importance, and the geographical spread so broad, that to do otherwise would not do this material justice.";

    paragraph = paragraph.ToLower();
    paragraph = Regex.Replace(paragraph, "[^a-z]", " ");

    var list = paragraph.Split(' ').ToList();
    list.RemoveAll(r => r == "");

    Dictionary<string, int> word_counts = new Dictionary<string, int>();
    foreach(var item in list)
    {
        if(string.IsNullOrEmpty(word_counts.Where(w => w.Key == item).FirstOrDefault().Key))
        {
            word_counts.Add(item, 1);
        }
        else
        {
            word_counts[item] += 1;
        }
    }



    List<string> result = new List<string>();

    var MaxCount = word_counts.Select(s => s.Value).Max();
    var items1 = word_counts.Where(s => s.Value == MaxCount).ToList();
    foreach (var item in items1)
    {
        result.Add(item.Key + "(" + item.Value + ")");
        word_counts.Remove(item.Key);
    }

    MaxCount = word_counts.Select(s => s.Value).Max();
    var items2 = word_counts.Where(s => s.Value == MaxCount).ToList();
    foreach (var item in items2)
    {
        result.Add(item.Key + "(" + item.Value + ")");
        word_counts.Remove(item.Key);
    }

    return result;

}
