using System.Collections.Generic;
using System.Linq;

namespace HackerRank_Exercises
{
    public class Algoritmo
    {
        public string[] testBalancedBrackets(string[] values)
        {
            string[] retorno = new string[values.Length];
            for (int i = 0; i < values.Length; i++)
            {
                int checkValue = 0;
                bool huboError = false;
                for (int j = 0; j < values[i].Length; j++)
                {
                    try
                    {
                        if (values[i][j] == '(' && (values[i][j + 1] == '}' || values[i][j + 1] == ']'))
                        {
                            retorno[i] = "NO";
                            huboError = true;
                            break;
                        }
                        else if (values[i][j] == '[' && (values[i][j + 1] == ')' || values[i][j + 1] == '}'))
                        {
                            retorno[i] = "NO";
                            huboError = true;
                            break;
                        }
                        else if (values[i][j] == '{' && (values[i][j + 1] == ')' || values[i][j + 1] == ']'))
                        {
                            retorno[i] = "NO";
                            huboError = true;
                            break;
                        }
                    }
                    catch
                    {
                        retorno[i] = "NO";
                        huboError = true;
                        break;
                    }
                    if (!huboError)
                    {
                        if (values[i][j] == '(' || values[i][j] == '[' || values[i][j] == '{')
                            checkValue++;
                        if (values[i][j] == '}' || values[i][j] == ']' || values[i][j] == ')')
                            checkValue--;
                        if (checkValue < 0)
                        {
                            retorno[i] = "NO";
                            break;
                        }
                    }
                }

                if (!huboError)
                    retorno[i] = checkValue == 0 ? "YES" : "NO";
            }
            return retorno;
        }

        public int equalStacks(int[] h1, int[] h2, int[] h3)
        {
            var totalH1 = 0;
            var totalH2 = 0;
            var totalH3 = 0;

            List<int> sumasH1 = new List<int>();
            List<int> sumasH2 = new List<int>();
            List<int> sumasH3 = new List<int>();

            for (int i = h1.Length - 1; i >= 0; i--)
            {
                totalH1 += h1[i];
                sumasH1.Add(totalH1);
            }
            for (int i = h2.Length - 1; i >= 0; i--)
            {
                totalH2 += h2[i];
                sumasH2.Add(totalH2);
            }
            for (int i = h3.Length - 1; i >= 0; i--)
            {
                totalH3 += h3[i];
                sumasH3.Add(totalH3);
            }

            if (totalH1 == totalH2 && totalH2 == totalH3)
                return totalH1;

            sumasH1.Sort((a, b) => -1 * a.CompareTo(b));
            sumasH2.Sort((a, b) => -1 * a.CompareTo(b));
            sumasH3.Sort((a, b) => -1 * a.CompareTo(b));

            var dicH1 = sumasH1.ToDictionary(k => k);
            var dicH2 = sumasH2.ToDictionary(k => k);
            var dicH3 = sumasH3.ToDictionary(k => k);


            if (sumasH1.Count <= sumasH2.Count && sumasH1.Count <= sumasH3.Count)
            {
                foreach (var sumah1 in sumasH1)
                {
                    if (dicH2.ContainsKey(sumah1))
                    {
                        if (dicH3.ContainsKey(sumah1))
                        {
                            return sumah1;
                        }
                    }
                }
            }
            if (sumasH2.Count <= sumasH1.Count && sumasH2.Count <= sumasH3.Count)
            {
                foreach (var sumah2 in sumasH2)
                {
                    if (dicH1.ContainsKey(sumah2))
                    {
                        if (dicH3.ContainsKey(sumah2))
                        {
                            return sumah2;
                        }
                    }
                }
            }
            if (sumasH3.Count <= sumasH1.Count && sumasH3.Count <= sumasH2.Count)
            {
                foreach (var sumah3 in sumasH3)
                {
                    if (dicH1.ContainsKey(sumah3))
                    {
                        if (dicH2.ContainsKey(sumah3))
                        {
                            return sumah3;
                        }
                    }
                }
            }
            return 0;
        }

        public int sockMerchant(int n, int[] ar)
        {
            var dictionaryColors = new Dictionary<int, int>();
            for (int i = 0; i < ar.Length; i++)
            {
                dictionaryColors[ar[i]] = dictionaryColors.ContainsKey(ar[i]) ? dictionaryColors[ar[i]] + 1 : 1;
            }

            var countSocksColor = 0;

            foreach (int sock in dictionaryColors.Values)
            {
                int resultado = sock / 2;
                countSocksColor += resultado;
            }
            return countSocksColor;
        }

        public int countingValleys(int n, string s)
        {
            int level = 0;
            int countValleys = 0;
            foreach (char letter in s)
            {
                var previousLevel = level;

                if (letter == 'U')
                    level++;
                if (letter == 'D')
                    level--;

                if (level < 0 && previousLevel == 0)
                    countValleys++;
            }
            return countValleys;

        }
    }
}
