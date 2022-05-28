using System;
using System.Collections.Generic;

namespace Common
{
    public class Helpers
    {
        public static bool IsSet(object value)
        {
            return !(value == null);
        }
        public static bool IsSet(string value)
        {
            return !(value == null);
        }
        public static int ToInt32(string value)
        {
            int number = 0;
            bool parsed = Int32.TryParse(value, out number);
            return number;
        }
        public static bool HasItems<T>(List<T> list)
        {
            return IsSet(list) && list.Count != 0;
        }
        public static T GetItemAt<T>(List<T> list, int index, T defaultValue = default)
        {
            return HasItems(list) && index < list.Count ? list[index] : defaultValue;
        }
        public static int GetItemCount<T>(List<T> list)
        {
            return HasItems(list) ? list.Count : 0;
        }
    }
}
