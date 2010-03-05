namespace App.Models.Enums
{
    /// <summary>
    /// Enum for user activity types in the system
    /// </summary>
    public enum ActivityType
    {
        PageAccess,
        LoginSuccess,
        LoginFails,
        SaveFails,
        UpdateFails,
        DeleteFails,
        SaveSuccessful,
        UpdateSuccessful,
        DeleteSuccessful,
        Other
    }
}
