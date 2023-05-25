using System.Text.RegularExpressions;
using System.Text;

namespace WordsFinder
{
    public class WordsFinder
    {
        Regex regex = new Regex(@"(?i)(?<![\'])[-a-zа-я\'’]{2,}(?:-[a-zа-я\'’]{2,})?|[-a-zа-я\'’]{3,}(?![\'])", RegexOptions.Compiled);
        Dictionary<string, int> _words = new Dictionary<string, int>();
        Dictionary<string, int> _result = new Dictionary<string, int>();
       
        


        

        private Dictionary<string, int> CountWords(string text)
        {
            text = text;
            foreach (Match match in regex.Matches(text))
            {
                string Word = match.Value;
                Word = Word.ToLower();
                if (_words.ContainsKey(Word))
                {
                    _words[Word]++;
                }
                else { _words.Add(Word, 1); }
            }
            SortWordsList();
            return _result;

        }
        private Dictionary<string, int> SortWordsList()
        {
            _result = _words.AsParallel().OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            return _result;
        }
        
    }
}