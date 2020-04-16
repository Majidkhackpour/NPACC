using System;
using System.Linq;

namespace PacketParser.Services
{
    public static class Extentions
    {
        public static string GetDisplay<T>(this T EnumItem)
        {
            try
            {
                if (typeof(T).IsEnum)
                {
                    return ((PersianNameAttribute.PersianName)typeof(T).GetFields()
                        .Single(rec => rec.Name == Enum.GetName(typeof(T), EnumItem)).GetCustomAttributes(false)
                        .First(rec => rec is PersianNameAttribute.PersianName)).Text;
                }

                return EnumItem.ToString();
            }
            catch (Exception ex)
            {
                return EnumItem.ToString();
            }
        }
        public static bool ParseToBoolean(this string Input, bool def = false)
        {
            if (string.IsNullOrEmpty(Input))
                return def;
            if (Input.Trim() == "")
                return def;

            bool ret = def;
            if (!bool.TryParse(Input, out ret))
                return def;
            return ret;
        }
        public static float ParseTofloat(this string value, float def = 0)
        {
            value = value.Trim();
            if (string.IsNullOrEmpty(value))
                return def;
            float ret = def;
            float.TryParse(value, out ret);
            return ret;
        }
        public static DateTime ParseToDate(this string Input, DateTime? def = null)
        {
            if (string.IsNullOrEmpty(Input))
                return def ?? DateTime.Now;
            DateTime ret = def ?? DateTime.Now;

            if (DateTime.TryParse(Input, out ret))
                return ret;
            else
                return def ?? DateTime.Now;
        }
        public static decimal ParseToDecimal(this string value, decimal def = 0)
        {
            value = value.Trim();
            if (string.IsNullOrEmpty(value))
                return def;

            decimal ret;
            return decimal.TryParse(value, out ret) ? ret : def;
        }
        public static double ParseToDouble(this string value, double def = 0)
        {
            string xstr = value.Trim();
            if (string.IsNullOrEmpty(xstr))
                return def;
            //xstr  = xstr .TXTQT.Text.Replace("/", ".")
            return double.TryParse(value, out var ret) ? ret : def;
        }
        public static int ParseToInt(this string value, int def = 0)
        {
            string xstr = value.Trim();
            if (xstr == "")
                return def;
            return int.TryParse(value, out var ret) ? ret : def;
        }
        public static long ParseToLong(this string value, long def = 0)
        {
            string xstr = value.Trim();
            if (xstr == "")
                return def;
            return long.TryParse(value, out var ret) ? ret : def;
        }
        public static short ParseToShort(this string value, short def = 0)
        {
            string xstr = value.Trim();
            if (xstr == "")
                return def;

            return short.TryParse(value, out var ret) ? ret : def;
        }

        public static string ThreeSeparator(this decimal value)
        {
            return value.ToString("#,0");
        }
    }
}
