using System;
using System.Collections.Generic;
using System.Net.Configuration;

namespace PLS_NO_POSTERINO.Classes
{
    class H
    {
        public static string ConvertTitleKindToString(TitleCheckKind pKind)
        {
            switch (pKind)
            {
                case TitleCheckKind.EndsWith:
                    return "Ends with";
                case TitleCheckKind.StartsWith:
                    return "Starts with";
                default:
                    return pKind.ToString();
            }
        }

        public static object[] ConvertAllTitleKindToString()
        {
            List<object> lvTitles = new List<object>();
            foreach (TitleCheckKind lvTck in Enum.GetValues(typeof (TitleCheckKind)))
            {
                lvTitles.Add(ConvertTitleKindToString(lvTck));
            }
            return lvTitles.ToArray();
        }

        public static TitleCheckKind ConvertKindStringToKind(string pKindString)
        {
            switch (pKindString)
            {
                case "Ends with":
                    return TitleCheckKind.EndsWith;
                case "Starts with":
                    return TitleCheckKind.StartsWith;
                default:
                    return (TitleCheckKind)Enum.Parse(typeof(TitleCheckKind),pKindString);
            }

        }

        public static bool TitlesToBlockContainsTitle(List<TitlesToBlock> pTitles, string pCurrentTitle)
        {
            if (pCurrentTitle == null)
                return false;
            foreach (TitlesToBlock lvT in pTitles)
            {
                if (lvT == null)
                    Console.WriteLine("WHAAAT");
                else
                {
                    switch (lvT.Kind)
                    {
                        case TitleCheckKind.Equals:
                            if (lvT.Name.Equals(pCurrentTitle, StringComparison.CurrentCultureIgnoreCase))
                                return true;
                            break;
                        case TitleCheckKind.Contains:
                            if (pCurrentTitle.ToLower().Contains(lvT.Name.ToLower()))
                                return true;
                            break;
                        case TitleCheckKind.StartsWith:
                            if (pCurrentTitle.ToLower().StartsWith(lvT.Name.ToLower()))
                                return true;
                            break;
                        case TitleCheckKind.EndsWith:
                            if (pCurrentTitle.ToLower().EndsWith(lvT.Name.ToLower()))
                                return true;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
            }
            return false;
        }
    }
}
