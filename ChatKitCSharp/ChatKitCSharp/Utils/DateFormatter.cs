using System;
using System.Collections.Generic;
using System.Collections;
using System.Globalization;
//using System.text.SimpleDateFormat;

namespace ChatKitCSharp.Utils
{
    public sealed class DateFormatter
    {
        private DateFormatter()
        {
        }

        public static string Format(DateTime date, Template template)
        {
            switch (template)
            {
                case Template.STRING_DAY_MONTH:
                    return Format(date, "d MMMM");
                case Template.STRING_DAY_MONTH_YEAR:
                    return Format(date, "d MMMM yyyy");
                case Template.TIME:
                    return Format(date, "HH:mm");
                default:
                    return Format(date, "");
            }
        }

        public static string Format(DateTime date, string format)
        {
            if (date == null) return "";
            date.GetDateTimeFormats().SetValue(format, 0);
            return date.GetDateTimeFormats()[0];
        }

        public static bool IsSameDay(DateTime date1, DateTime date2)
        {
            if (date1 == null || date2 == null)
            {
                throw new Exception("Dates must not be null");
            }

            return (date1.Year == date2.Year &&
                date1.Month == date2.Month &&
                date1.Day == date1.Day);
        }

        public static bool IsSameYear(DateTime date1, DateTime date2)
        {
            if (date1 == null || date2 == null)
            {
                throw new Exception("Dates must not be null");
            }

            return (date1.Year == date2.Year);
        }

        public static bool IsToday(DateTime date)
        {
            return (date.Date.Day == DateTime.Now.Day);
        }

        public static bool IsYesterday(DateTime date)
        {
            var yesterday = DateTime.Now.AddDays(-1);
            return yesterday.Date == date;
        }

        public static bool IsCurrentYear(DateTime date)
        {
            return (date.Year == DateTime.Now.Year);
        }

        public interface Formatter
        {
            string Format(DateTime date);
        }

        public enum Template
        {
            STRING_DAY_MONTH_YEAR = 1,
            STRING_DAY_MONTH = 2,
            TIME = 3
        }
    }
}