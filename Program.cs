using System.Diagnostics;
using System.Collections.Generic;

namespace WordsCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = "D:\\repozitor\\WordsCounter.13\\Text\\Text1.txt";
            var text = File.ReadAllText(path);

            var nopointText = new string(text.Where(c => char.IsLetter(c) || char.IsWhiteSpace(c)).ToArray());
            string[] splitedArr = nopointText.ToLower().Split(new char[] { ' ', ',', '.', '?', '!', ':', '-', '\n', '\t', '<', '>', '(', ')', ';', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> dictcountword = new Dictionary<string, int>();
            for (int i = 0; i < splitedArr.Length; i++)
            {
                if (dictcountword.ContainsKey(splitedArr[i]))
                    dictcountword[splitedArr[i]]++;
                else
                    dictcountword.Add(splitedArr[i], 1);
            }

            var sortedDict = dictcountword.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            List<string> allKeys = new List<string>(sortedDict.Keys);
            List<string> toptenWords = new List<string>();
            for (int i = 0; i < 10; i++)
            {
                toptenWords.Add(allKeys[i]);
            }

            foreach (var st in sortedDict)
            {
                if (toptenWords.Contains(st.Key))
                    Console.WriteLine($"Слово \"{st.Key}\" повторялось {st.Value} раз");

            }
        }
    }
}

