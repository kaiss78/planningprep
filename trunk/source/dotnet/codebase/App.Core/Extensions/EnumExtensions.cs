using System;
using System.ComponentModel;

namespace App.Core.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum enumItem)
        {
            DescriptionAttribute[] attributes = (DescriptionAttribute[])enumItem.GetType().GetField(enumItem.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : string.Empty;
        }
    }
}
