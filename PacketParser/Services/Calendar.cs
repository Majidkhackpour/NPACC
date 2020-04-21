using System;
using System.Globalization;
using System.Linq;

namespace PacketParser.Services
{
    public class Calendar
    {
        public static DateTime ShamsiToMiladi(string DateParam)
        {
            try
            {
                var time = "";
                if (DateParam.Contains(" "))
                {
                    time = DateParam.Split(" ".ToCharArray())[1];
                    DateParam = DateParam.Split(" ".ToCharArray())[0];
                }

                short sec = 0;
                short min = 0;
                short hour = 0;

                if (time.Contains(":"))
                {
                    hour = short.Parse(time.Split(":".ToCharArray())[0]);
                    min = short.Parse(time.Split(":".ToCharArray())[1]);
                    sec = time.Split(":".ToCharArray()).Length == 3
                        ? short.Parse(time.Split(":".ToCharArray())[2])
                        : (short)0;
                }

                if (DateParam.Length < 7)
                    return DateTime.Now;
                DateParam = DateParam.Trim();
                var strTemp = DateParam.Split("/".ToCharArray());
                if (strTemp.Length != 3)
                    return DateTime.Now;

                var y = int.Parse(strTemp[0]);
                var m = short.Parse(strTemp[1]);
                var d = short.Parse(strTemp[2]);
                if (d <= 0 || d > 31)
                    return DateTime.Now;

                if (m <= 0 || m > 12)
                    return DateTime.Now;

                if (y.ToString().Length == 2)
                    y = 1300 + y;

                if (y <= 1200 || y >= 1500)
                    return DateTime.Now;

                var pc = new PersianCalendar();
                return CheckShamsiDate(DateParam) ? pc.ToDateTime(y, m, d, hour, min, sec, 0) : DateTime.Now;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return DateTime.Now;
            }
        }

        public static bool CheckShamsiDate(string DateParam)
        {
            try
            {
                DateParam = DateParam.Trim();
                var strTemp = DateParam.Split("/".ToCharArray());
                if (strTemp.Length != 3)
                    return false;
                var y = int.Parse(strTemp[0]);
                int m = short.Parse(strTemp[1]);
                int d = short.Parse(strTemp[2]);

                var pc = new PersianCalendar();
                if (m >= 1 && m <= 6 && d >= 1 && d <= 31)
                    return true;
                if (m >= 7 && m <= 11 && d >= 1 && d <= 30)
                    return true;
                if (m == 12 && d >= 1 && d <= 29)
                    return true;
                return m == 12 && d == 30 && pc.IsLeapYear(y);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return false;
            }
        }

        public static string MiladiToShamsi(DateTime? DateM)
        {
            try
            {
                return DateM == null ? "" : MiladiToShamsi(DateM.Value);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return null;
            }
        }

        public static string ToShamsiDateTime(DateTime dateM)
        {
            try
            {
                if (dateM.Year > 2500 || dateM.Year < 1500) return "";
                var ret = "";

                var persianCalendar = new PersianCalendar();
                if (persianCalendar.GetMonth(dateM) >= 10)
                    ret = persianCalendar.GetYear(dateM) + "/" + persianCalendar.GetMonth(dateM);
                else
                    ret = persianCalendar.GetYear(dateM) + "/0" + persianCalendar.GetMonth(dateM);

                if (persianCalendar.GetDayOfMonth(dateM) >= 10)
                    ret += "/" + persianCalendar.GetDayOfMonth(dateM);
                else
                    ret += "/" + "0" + persianCalendar.GetDayOfMonth(dateM);
                return $"{ret} {dateM:HH:mm:ss}";
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return null;
            }
        }
        public static string MiladiToShamsi(DateTime dateM)
        {
            try
            {
                if (dateM.Year > 2500 || dateM.Year < 1500) return "";
                var ret = "";

                var persianCalendar = new PersianCalendar();
                if (persianCalendar.GetMonth(dateM) >= 10)
                    ret = persianCalendar.GetYear(dateM) + "/" + persianCalendar.GetMonth(dateM);
                else
                    ret = persianCalendar.GetYear(dateM) + "/0" + persianCalendar.GetMonth(dateM);

                if (persianCalendar.GetDayOfMonth(dateM) >= 10)
                    ret += "/" + persianCalendar.GetDayOfMonth(dateM);
                else
                    ret += "/" + "0" + persianCalendar.GetDayOfMonth(dateM);
                return ret;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return null;
            }
        }

        public static string ToShortDate(DateTime dateM)
        {
            try
            {
                var persianCalendar = new PersianCalendar();
                var cul = CultureInfo.CreateSpecificCulture("fa-IR");
                return dateM.ToString(cul.DateTimeFormat.ShortDatePattern);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return null;
            }
        }

        public static int GetYearOfDateSh(string dateSh)
        {
            try
            {
                var xx = "";
                if (string.IsNullOrEmpty(dateSh)) return 0;
                if (dateSh.Split('/').Length <= 2) return 0;
                xx = dateSh.Split('/')[0];
                return int.Parse(xx);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return 0;
            }
        }

        public static int GetMonthOfDateSh(string dateSh)
        {
            try
            {
                var xx = "";
                if (string.IsNullOrEmpty(dateSh)) return 0;
                if (dateSh.Split('/').Length <= 2) return 0;
                xx = dateSh.Split('/')[1];
                return int.Parse(xx);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return 0;
            }
        }

        public static string ToLongDateWithoutYear(DateTime dateM)
        {
            try
            {
                var persianCalendar = new PersianCalendar();
                var cul = CultureInfo.CreateSpecificCulture("fa-IR");
                return cul.DateTimeFormat.DayNames[(int)persianCalendar.GetDayOfWeek(dateM)] + " " +
                       persianCalendar.GetDayOfMonth(dateM) +
                       " " + monthNames[persianCalendar.GetMonth(dateM) - 1];
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return null;
            }
        }

        public static string ToLongTimeString(DateTime dateM)
        {
            try
            {
                var hour = string.Format("{0:D2}", dateM.Hour);
                var minute = string.Format("{0:D2}", dateM.Minute);
                var second = string.Format("{0:D2}", dateM.Second);
                if (dateM.Hour <= 12)
                    return hour + ":" + minute + ":" + second + " ق.ظ";
                else
                    return hour + ":" + minute + ":" + second + " ب.ظ";
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return null;
            }
        }

        public static string Minutes2TimeFormat(int min)
        {
            try
            {
                min = Math.Abs(min);
                var h = min / 60;
                var m = (min % 60);
                var ret = h.ToString();
                if (h < 10)
                    ret = "0" + h;
                ret += ":";
                if (m > 9)
                    ret = ret + m;
                else
                    ret = ret + "0" + m;
                return ret;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return "00:00";
            }
        }

        private static readonly string[] monthNames = { "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند" };
        /// <summary>
        /// اخرین روز ماه جاری شمسی را برمیگرداند
        /// </summary>
        /// <returns></returns>
        public static int EndDayOfMonth()
        {
            try
            {
                var tmp = Calendar.MiladiToShamsi(DateTime.Now);
                var arry = tmp.Split('/');
                var month = short.Parse(arry[1]);
                var year = int.Parse(arry[0]);
                return EndDayOfMonth(month, year);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return 0;
            }
        }
        /// <summary>
        /// تاریخ اخرین روز ماه شمسی جاری در تاریخ میلادی را بر می گرداند
        /// </summary>
        /// <returns></returns>
        public static DateTime EndDayOfPersianMonth()
        {
            try
            {
                var tmp = Calendar.MiladiToShamsi(DateTime.Now);
                var array = tmp.Split('/');
                array[2] = EndDayOfMonth().ToString();
                return ShamsiToMiladi($"{array[0] }/{array[1] }/{array[2] }");
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return DateTime.Now;
            }
        }

        /// <summary>
        /// شروع ماه شمسی را در تاریخ میلادی بر می گرداند
        /// </summary>
        /// <returns></returns>
        public static DateTime StartDayOfPersianMonth()
        {
            try
            {
                var tmp = Calendar.MiladiToShamsi(DateTime.Now);
                var array = tmp.Split('/');
                return ShamsiToMiladi($"{array[0] }/{array[1] }/1");
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return DateTime.Now;
            }
        }

        public static int EndDayOfMonth(short civilMonth, int civilyear)
        {
            try
            {
                if (CheckShamsiDate($"{civilyear}/{civilMonth}/31"))
                    return 31;
                else if (CheckShamsiDate($"{civilyear}/{civilMonth}/30"))
                    return 30;
                else
                    return 29;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return 30;
            }
        }

        public static int GetDayOfDateSh(string dateSh)
        {
            try
            {
                if (dateSh == "") return 0;
                var strTemp = dateSh.Split("/".ToCharArray());
                return strTemp.Length > 2 ? int.Parse(strTemp[2]) : 0;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return 0;
            }
        }

        public static string Today()
        {
            try
            {
                return MiladiToShamsi(DateTime.Now.Date);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return null;
            }
        }

        public static string GetPartday(string date, EnPartDate type)
        {
            try
            {
                var y = date.Substring(0, 4);
                var m = date.Substring(5, 2);
                var d = date.Substring(8, 2);
                switch (type)
                {
                    case EnPartDate.Year: return y;
                    case EnPartDate.Mounth: return m;
                    case EnPartDate.Day: return d;
                    default: return "";
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return null;
            }
        }

        public static int GetDaysInMonth(int y, int m)
        {
            try
            {
                if (y <= 0 || y >= 12) return 0;
                var ps = new PersianCalendar();
                return ps.GetDaysInMonth(y, m);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return 0;
            }
        }

        public static string AddToShamsiDate(int days, string dateSH, EnPartDate part)
        {
            try
            {
                if (dateSH.Length < 7) return MiladiToShamsi(DateTime.Now);
                if (dateSH.Split('/').Count() != 3) return MiladiToShamsi(DateTime.Now);
                dateSH = dateSH.Trim();
                var y = int.Parse(dateSH.Substring(0, 4));
                var m = int.Parse(dateSH.Substring(5, 2));
                var d = int.Parse(dateSH.Substring(8, 2));
                if (d <= 0 || d > 31) return MiladiToShamsi(DateTime.Now);
                if (m <= 0 || m > 12) return MiladiToShamsi(DateTime.Now);
                if (y.ToString().Length == 2) y = 1300 + y;
                if (y <= 1200 || y >= 1500) return MiladiToShamsi(DateTime.Now);
                var dateM = ShamsiToMiladi(dateSH);
                var addDays = 0;
                switch (part)
                {
                    case EnPartDate.Day:
                        addDays = days;
                        break;
                    case EnPartDate.Mounth:
                        if (days < 0) m = m - 1;
                        addDays = days * EndDayOfMonth((short)m, y);
                        break;
                    case EnPartDate.Year:
                        return (y + days) + "/" + m.ToString("00") + "/" + d.ToString("00");
                }

                dateM = dateM.AddDays(addDays);
                return MiladiToShamsi(dateM);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return null;
            }
        }

        public static string GetDayNameOfWeek(DateTime dateM)
        {
            try
            {
                switch (dateM.DayOfWeek)
                {
                    case DayOfWeek.Friday: return "جمعه";
                    case DayOfWeek.Monday: return "دوشنبه";
                    case DayOfWeek.Saturday: return "شنبه";
                    case DayOfWeek.Sunday: return "یکشنبه";
                    case DayOfWeek.Thursday: return "پنج شنبه";
                    case DayOfWeek.Tuesday: return "سه شنبه";
                    case DayOfWeek.Wednesday: return "چهار شنبه";
                    default: return null;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return null;
            }
        }

        public static string DateToFormatTime(DateTime dateM)
        {
            try
            {
                var h = dateM.Hour.ToString();
                var m = "";
                if (dateM.Second > 30) m = dateM.Minute + 1.ToString();
                else m = dateM.Minute.ToString();
                if (int.Parse(m) >= 60)
                {
                    m = "0";
                    h = (int.Parse(h) + 1).ToString();
                }

                if (h.Length > 1) h = "0" + h;
                if (m.Length > 1) m = "0" + m;
                return h + ":" + m;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return null;
            }
        }
    }
}
