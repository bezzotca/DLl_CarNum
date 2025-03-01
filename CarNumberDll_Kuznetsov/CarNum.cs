using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CarNumberDll_Kuznetsov
{
    public class CarNum
    {
        private static readonly string Pattern = "^[АВЕКМНОРСТУХABEKMHOPCTYX]\\d{3}[АВЕКМНОРСТУХABEKMHOPCTYX]{2}\\d{2,3}$";
        private static readonly string LegitLetters = "ABCEHKLMNOPTXYАБВГДЕЖЗИКЛМНОПРСТУФХЦЧШЩЭЮЯ";
        private static readonly int MAX_DIGIT = 999;

        public static bool CheckMark(string mark)
        {
            return Regex.IsMatch(mark, Pattern);
        }

        public static string GetNextMarkAfter(string mark)
        {
            if (!CheckMark(mark)) return "Транспортный номер неправильно введён";

            char letter1 = mark[0];
            int digits = int.Parse(mark.Substring(1, 3));
            char letter2 = mark[4];
            char letter3 = mark[5];
            string region = mark.Substring(6);

            if (digits < MAX_DIGIT)
            {
                digits++;
            }
            else
            {
                digits = 0;
                int index3 = LegitLetters.IndexOf(letter3);
                if (index3 != -1 && index3 < LegitLetters.Length - 1)
                {
                    letter3 = LegitLetters[index3 + 1];
                }
                else
                {
                    letter3 = LegitLetters[0];
                    int index2 = LegitLetters.IndexOf(letter2);
                    if (index2 != -1 && index2 < LegitLetters.Length - 1)
                    {
                        letter2 = LegitLetters[index2 + 1];
                    }
                    else
                    {
                        letter2 = LegitLetters[0];
                        int index1 = LegitLetters.IndexOf(letter1);
                        if (index1 != -1 && index1 < LegitLetters.Length - 1)
                        {
                            letter1 = LegitLetters[index1 + 1];
                        }
                        else
                        {
                            return "Номеров нет";
                        }
                    }
                }
            }

            return $"{letter1}{digits:000}{letter2}{letter3}{region}";
        }

        public static string GetNextMarkAfterInRange(string prevMark, string rangeStart, string rangeEnd)
        {
            if (!CheckMark(prevMark) || !CheckMark(rangeStart) || !CheckMark(rangeEnd)) return "Транспортный номер неправильно введён";
            if (string.Compare(prevMark, rangeEnd) >= 0) return "Номеров нет"; // Если prevMark уже на пределе

            string nextMark = GetNextMarkAfter(prevMark);
            if (nextMark == "Номеров нет") return "Номеров нет";

            return (string.Compare(nextMark, rangeStart) >= 0 && string.Compare(nextMark, rangeEnd) <= 0)
                ? nextMark
                : "Номеров нет";
        }

        public static int GetCombinationsCountInRange(string mark1, string mark2)
        {
            if (!CheckMark(mark1) || !CheckMark(mark2)) return 0;
            if (string.Compare(mark1, mark2) > 0) return 0; // Если первый номер больше второго

            int count = 1;
            string currentMark = mark1;

            while (true)
            {
                string nextMark = GetNextMarkAfter(currentMark);
                if (nextMark == "Номеров нет" || string.Compare(nextMark, mark2) > 0) break;

                count++;
                currentMark = nextMark;
            }

            return count;
        }
    }
}
