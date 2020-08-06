public int CalculateFormula(string s)
        {
            //string s = "23 + 1 + 2 - 3 =";
            s = s.Replace("=", "");
            List<string> element = new List<string>();
            List<int> index_of_cm = new List<int>();

            var i = 0;
            foreach (var item in s.Split(' '))
            {
                if (item == "*" || item == "/")
                    //紀錄 '*' '/' 優先運算
                    index_of_cm.Add(i);

                element.Add(item);
                i++;
            }

            //先做 '*','/' 並且取代前後字元
            if (index_of_cm.Count() > 0)
            {
                int count = 0;//remove 次數
                foreach (var j in index_of_cm)
                {
                    //因算完之後要remove 2個element 所以 index 會 -2*count
                    int r  = j - count * 2;
                    var ss = 0;
                    if (element[r] == "*")
                        ss = Convert.ToInt32(element[r - 1]) * Convert.ToInt32(element[r + 1]);
                    else
                        ss = Convert.ToInt32(element[r - 1]) / Convert.ToInt32(element[r + 1]);
                    element[r] = ss.ToString();

                    //remove前後
                    element.RemoveAt(r - 1);
                    element.RemoveAt(r);

                    count++;
                }

            }

            //開始做'+', '-'
            var result = 0;
            var indexofAdd_Minus = element.Select((value, index) => new { value, index }).Where(w => w.value == "+" || w.value == "-").ToList();
            foreach (var item in indexofAdd_Minus)
            {
                if(item.index - 1 == 0)
                {
                    if (item.value == "+")
                        result += Convert.ToInt32(element[item.index - 1]) + Convert.ToInt32(element[item.index + 1]);
                    else if (item.value == "-")
                        result += Convert.ToInt32(element[item.index - 1]) - Convert.ToInt32(element[item.index + 1]);
                }
                else
                {
                    if (item.value == "+")
                        result += Convert.ToInt32(element[item.index + 1]);
                    else if (item.value == "-")
                        result -= Convert.ToInt32(element[item.index + 1]);
                }
                
            }

            Console.WriteLine(result);
            return result;
        }
