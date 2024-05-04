using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tipograf
{
    /// <summary>
    /// Класс содержит методы поиска вхождений в тексте
    /// </summary>
    public class SearchOccurrences
    {   
        public SearchOccurrences() { }

        /// <summary>
        /// Метод ищет вхождения "±" в тексте
        /// </summary>
        public List<int> ValueOccurrenceIndexes(string text)
        {
            var indices = new List<int>();
            string substring = "±";
            int index = text.IndexOf(substring, 0);
            while (index > -1)
            {
                indices.Add(index);
                index = text.IndexOf(substring, index + substring.Length);
            }
            return indices;
        }
        /// <summary>
        /// Метод ищет вхождения "∓" в тексте
        /// </summary>
        public List<int> ValueOccurrenceIndexes2(string text)
        {
            var indices = new List<int>();
            string substring = "∓";
            int index = text.IndexOf(substring, 0);
            while (index > -1)
            {
                indices.Add(index);
                index = text.IndexOf(substring, index + substring.Length);
            }
            return indices;
        }
    }
}

