using System;

namespace PlanningPrep.Models.Enums
{
    [Flags]
    public enum PlanningPrepDbType : byte
    {
        DbTypeInteger = 1,
        DbTypeLong = 2,
        DbTypeString = 3,
        DbTypeDateTime = 4,
        DbTypeBit = 5
    }
}