using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFrame.Common.Definitions
{
    public static class StringExtend
    {
        /// <summary>
        /// 替换所有的字符串
        /// </summary>
        /// <param name="str"></param>
        /// <param name="oldValues"></param>
        /// <param name="newValue"></param>
        /// <returns></returns>
        public static string ReplaceAll(this string str, string[] oldValues, string newValue)
        {
            foreach (var oldValue in oldValues)
            {
                str = str.Replace(oldValue, newValue);
            }
            return str;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static int ToInt(this object obj)
        {
            if (obj != null)
            {
                if (obj.Equals(DBNull.Value))
                {
                    return 0;
                }
                if (int.TryParse(obj.ToString(), out var num))
                {
                    return num;
                }
            }
            return 0;
        }
    }
}
