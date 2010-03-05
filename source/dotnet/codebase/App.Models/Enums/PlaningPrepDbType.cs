using System;

namespace App.Models.Enums
{
    [Flags]
    public enum PantheonDbType : byte
    {
        DbTypeInteger = 1,
        DbTypeLong = 2,
        DbTypeString = 3,
        DbTypeDateTime = 4,
        DbTypeBit = 5
    }
}