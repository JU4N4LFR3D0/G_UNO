﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_UNO
{
    public class SerialRequest
    {
        #region Const
        public const int TypeGCodeStream = 10;
        public const int TypeCancel = 11;
        public const int TypeUp = 12;
        public const int TypeDown = 13;
        public const int TypeLeft = 14;
        public const int TypeRight = 15;
        public const int TypeSetON = 16;
        public const int TypeSetOFF = 17;
        public const int TypeZero = 18;
        public const int TypeHome = 19;
        public const int TypeGetInfo = 20;
        #endregion

        public int Type { get; set; }
        public List<string> GCode { get; set; }

        public SerialRequest(int type)
        {
            Type = type;
            GCode = new List<string>();
        }

    }
    public static class Extensions
    {
        public static List<string> toLinesList(this string text)
        {
            return text.Split(new string[] { "\r\n", "\r", "\n" },StringSplitOptions.None).ToList();
        }
        public static string ArrToString(this string[] lines)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (string line in lines)
            {
                stringBuilder.AppendLine(line);
            }
            return stringBuilder.ToString();
        }
        public static bool InArray(this string[] items, string find)
        {
            try
            {
                if (items == null) return false;
                if (items.Length < 1) return false;
                foreach (string item in items)
                {
                    if (item == find)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
