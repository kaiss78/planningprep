using System;

namespace App.Models.Enums
{
    [Flags]
    public enum AppDbType : byte
    {
        DbTypeInteger = 1,
        DbTypeLong = 2,
        DbTypeString = 3,
        DbTypeDateTime = 4,
        DbTypeBit = 5
    }
}