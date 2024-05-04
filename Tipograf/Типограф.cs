namespace Tipograf
{
    public partial class Typographer : Form
    {
        public Typographer()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Метод удаляет пробелы
        /// </summary>
        public string DontMoreSpace(string text)
        {
            int statusSpace = 0;
            char[] chars = text.ToCharArray();
            var newTextList = new List<char>();
            for (int i = 0; i < chars.Length; i++)
            {
                if (chars[i] == ' ' && statusSpace == 0)
                {
                    statusSpace = 1;
                    newTextList.Add(chars[i]);
                }
                else if (chars[i] == ' ' && statusSpace == 1)
                {
                    continue;
                }
                else
                {
                    newTextList.Add(chars[i]);
                    statusSpace = 0;
                }
            }
            return string.Join(String.Empty, newTextList);
        }
        /// <summary>
        /// Метод заносит в скобки числовые значения такого вида: 433,92±0,2
        /// </summary>
        public string NumericValuesInStaples(string text)
        {
            var searchOccurrences = new SearchOccurrences();
            var indOccurrence = searchOccurrences.ValueOccurrenceIndexes(text);
            char[] chars = text.ToCharArray();
            var newTextList = new List<char>();
            foreach (char c in chars)
            {
                newTextList.Add(c);
            }
            int res;
            for (int i = 0; i < indOccurrence.Count; i++)
            {
                indOccurrence = searchOccurrences.ValueOccurrenceIndexes(string.Join(String.Empty, newTextList));
                int k = -1;
                if (indOccurrence[i] + k >= 0)
                {
                    while (int.TryParse(newTextList[indOccurrence[i] + k].ToString(), out res)
                || newTextList[indOccurrence[i] + k] == ',')
                    {
                        if (indOccurrence[i] + k - 1 < 0)
                        {
                            break;
                        }
                        k--;
                    }
                }
                int j = 1;
                if (indOccurrence[i] + j < newTextList.Count)
                {
                    while (int.TryParse(newTextList[indOccurrence[i] + j].ToString(), out res) == true
                || newTextList[indOccurrence[i] + j] == ',')
                    {
                        if (indOccurrence[i] + j + 1 >= newTextList.Count)
                        {
                            break;
                        }
                        j++;
                    }
                }
                if (k != -1)
                {
                    if(indOccurrence[i] + k == 0)
                    {
                        newTextList.Insert(indOccurrence[i] + k, '(');
                    }
                    else
                    {
                        newTextList.Insert(indOccurrence[i] + k + 1, '(');

                    }
                }
                if (j != 1)
                {
                    newTextList.Insert(indOccurrence[i] + j + 1, ')');
                }
            }
            return string.Join(String.Empty, newTextList);
        }
        /// <summary>
        /// Метод заносит в скобки числовые значения такого вида: 433,92∓0,2
        /// </summary>
        public string NumericValuesInStaples2(string text)
        {
            var searchOccurrences = new SearchOccurrences();
            var indOccurrence = searchOccurrences.ValueOccurrenceIndexes2(text);
            char[] chars = text.ToCharArray();
            var newTextList = new List<char>();
            foreach (char c in chars)
            {
                newTextList.Add(c);
            }
            int res;
            for (int i = 0; i < indOccurrence.Count; i++)
            {
                indOccurrence = searchOccurrences.ValueOccurrenceIndexes2(string.Join(String.Empty, newTextList));
                int k = -1;
                if (indOccurrence[i] + k >= 0)
                {
                    while (int.TryParse(newTextList[indOccurrence[i] + k].ToString(), out res)
                || newTextList[indOccurrence[i] + k] == ',')
                    {
                        if (indOccurrence[i] + k - 1 < 0)
                        {
                            break;
                        }
                        k--;
                    }
                }
                int j = 1;
                if (indOccurrence[i] + j < newTextList.Count)
                {
                    while (int.TryParse(newTextList[indOccurrence[i] + j].ToString(), out res) == true
                || newTextList[indOccurrence[i] + j] == ',')
                    {
                        if (indOccurrence[i] + j + 1 >= newTextList.Count)
                        {
                            break;
                        }
                        j++;
                    }
                }
                if (k != -1)
                {
                    if (indOccurrence[i] + k == 0)
                    {
                        newTextList.Insert(indOccurrence[i] + k, '(');
                    }
                    else
                    {
                        newTextList.Insert(indOccurrence[i] + k + 1, '(');

                    }
                }
                if (j != 1)
                {
                    newTextList.Insert(indOccurrence[i] + j + 1, ')');
                }
            }
            return string.Join(String.Empty, newTextList);
        }
        /// <summary>
        /// Метод меняет +- на ±
        /// </summary>
        public string CheckPlusAndMinus(string text)
        {
            return text.Replace("+-", "\u00B1");
        }
        /// <summary>
        /// Метод меняет ^3 на ³
        /// </summary>
        public string CheckDegreeCube(string text)
        {
            return text.Replace("^3", "\u00B3");
        }
        /// <summary>
        /// Метод меняет ^2 на ²
        /// </summary>
        public string CheckDegreeSquare(string text)
        {
            return text.Replace("^2", "\u00B2");
        }
        /// <summary>
        /// Метод меняет -+ на ∓
        /// </summary>
        public string CheckMinusAndPlus(string text)
        {
            return text.Replace("-+", "\u2213");
        }
        /// <summary>
        /// Метод меняет ... на …
        /// </summary>
        public string ReplaceEllipsis(string text)
        {
            return text.Replace("...", "\u2026");
        }
        private void UserText_TextChanged(object sender, EventArgs e)
        {
            TypographerText.Text = NumericValuesInStaples(NumericValuesInStaples2(DontMoreSpace(CheckPlusAndMinus
                (CheckMinusAndPlus(ReplaceEllipsis(CheckDegreeCube(CheckDegreeSquare(UserText.Text))))))));
        }
    }
}
