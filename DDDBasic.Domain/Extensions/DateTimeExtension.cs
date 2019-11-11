using System;

namespace DDDBasic.Domain.Extensions
{
    public static class DateTimeExtension
    {
        public static bool Between(this DateTime input, DateTime date1, DateTime date2)
        {
            return (input > date1 && input < date2);
        }
    }
}
