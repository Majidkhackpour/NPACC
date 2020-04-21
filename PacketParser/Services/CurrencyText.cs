using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace PacketParser.Services
{
    public static class CurrencyText
    {
        public static string fixNumberAndPutSharp(this string input)
        {
            try
            {
                if (string.IsNullOrEmpty(input)) return input;
                input = input.FixString().RemoveNoNumbers("");
                while (input.StartsWith("0"))
                    input = input.Substring(1, input.Length - 1);
                if (input.Length == 8)
                    input = "51" + input;
                return input.Length == 10 ? $"#T{input}" : "";
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return "";
            }
        }

        public static string fixForUrl(this string input)
        {
            try
            {
                //https://www.urldecoder.org/
                if (string.IsNullOrEmpty(input)) return "";
                input = input.Replace("!", "%21");
                input = input.Replace("#", "%23");
                input = input.Replace("$", "%24");
                input = input.Replace("'", "%27");
                input = input.Replace("(", "%28");
                input = input.Replace(")", "%29");
                input = input.Replace("*", "%2A");
                input = input.Replace("+", "%2B");
                input = input.Replace(",", "%2c");
                input = input.Replace("/", "%2F");
                input = input.Replace(":", "%3A");
                input = input.Replace(";", "%3B");
                input = input.Replace("=", "%3D");
                input = input.Replace("?", "%3F");
                input = input.Replace("@", "%40");
                input = input.Replace("[", "%5B");
                input = input.Replace("]", "%5D");
                input = input.Replace("\r\n", "\n");
                input = input.Replace("\r", "\n");
                input = input.Replace("\n", "%0D%0A");
                input = input.Replace(" ", "%20");
                input = input.Replace("\"", "%22");
                input = input.Replace("-", "%2D");
                input = input.Replace(".", "%2E");
                input = input.Replace("<", "%3C");
                input = input.Replace(">", "%3E");
                input = input.Replace("\\", "%5C");
                input = input.Replace("^", "%5E");
                input = input.Replace("_", "%5F");
                input = input.Replace("`", "%60");
                input = input.Replace("{", "%7B");
                input = input.Replace("|", "%7C");
                input = input.Replace("}", "%7D");
                input = input.Replace("~", " %7E");
                return input;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return "";
            }
        }

        public static string RemoveNoNumbers(this string Input, string Replcment)
        {
            try
            {
                var ret = "";
                Input = FixString(Input);
                if (string.IsNullOrEmpty(Input)) return "";
                Input = Input.Replace("\r", Replcment);
                Input = Input.Replace("\n", Replcment);
                Input = Input.Replace("\t", Replcment);

                foreach (var item in Input.ToCharArray())
                    if ("0123456789".Contains(item.ToString()))
                        ret += item.ToString();
                    else
                        ret += Replcment;
                return ret;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return null;
            }
        }

        public static List<string> SplitString(this string input, string SpliterList = " /\\\r\n\t)(-_=+%$#@*|><,`~'\":.?؟،")
        {
            if (string.IsNullOrEmpty(input))
                return new List<string>();
            input = input.ToLower().FixString();
            return input.Split(SpliterList.ToCharArray())?.ToList();
        }

        public static string FixString(this string input)
        {
            try
            {
                if (string.IsNullOrEmpty(input)) return "";
                while (input.Contains("  "))
                    input = input.Replace("  ", " ");
                input = input.Replace("*", "×");
                input = input.Replace("'", "");
                input = input.Replace("ھ", "ه");
                input = input.Replace("ك", "ک");
                input = input.Replace("ي", "ی");
                input = input.Replace("۰", "0").Replace("0", "0").Replace("٠", "0");
                input = input.Replace("۱", "1").Replace("١", "1");
                input = input.Replace("۲", "2").Replace("٢", "2");
                input = input.Replace("٣", "3").Replace("۳", "3");
                input = input.Replace("۴", "4").Replace("٤", "4");
                input = input.Replace("٥", "5").Replace("۵", "5");
                input = input.Replace("۶", "6").Replace("٦", "6");
                input = input.Replace("٧", "7").Replace("۷", "7");
                input = input.Replace("۸", "8").Replace("٨", "8");
                input = input.Replace("۹", "9").Replace("٩", "9");
                return input.Trim();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return null;
            }
        }

        private static string _DecimalPoint = "";
        public static string DecimalPoint
        {
            get
            {
                try
                {
                    if (!string.IsNullOrEmpty(_DecimalPoint)) return _DecimalPoint;

                    decimal x = 0;
                    if (!decimal.TryParse("0.1", out x))
                        _DecimalPoint = ((double)0.1).ToString().Substring(1, 1);
                    else
                        _DecimalPoint = x.ToString() == "0.1" ? "." : ((double)0.1).ToString().Substring(1, 1);

                    return _DecimalPoint;
                }
                catch
                {
                    return CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
                }
            }
        }

        private static string _decimalSeprator = "";
        public static string decimalSeprator
        {
            get
            {
                try
                {
                    if (!string.IsNullOrEmpty(_decimalSeprator)) return _decimalSeprator;

                    decimal x = 1000;
                    var temp = x.ToString("N0");
                    _decimalSeprator = temp.Substring(1, 1);
                    return _DecimalPoint;
                }
                catch
                {
                    return CultureInfo.CurrentCulture.NumberFormat.NumberGroupSeparator;
                }
            }
        }

        public static string RemoveNoNumbers_Dot(string Input, string Replcment)
        {
            try
            {
                Input = FixString(Input).Trim();
                if (string.IsNullOrEmpty(Input)) return Input;

                Input = Input.Replace("\r\n", Replcment);

                var arr = Input.ToCharArray();

                foreach (var item in arr)
                {
                    if ("0123456789.".Contains(item.ToString()))
                    {
                        //Character is a number
                        //nothing
                    }
                    else if (item.ToString() != "" && item.ToString() != Replcment)
                        Input = Input.Replace(item.ToString(), Replcment);
                }

                if (Replcment == "") return Input;
                while (Input.Contains(Replcment + Replcment))
                    Input = Input.Replace(Replcment + Replcment, Replcment);

                return Input;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return null;
            }
        }
    }
}
