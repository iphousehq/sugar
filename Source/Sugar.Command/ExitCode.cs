namespace Sugar.Command
{
    /// <summary>
    /// Enumeration centralizing exit codes an console app can return.
    /// </summary>
    public enum ExitCode
    {
        NoCommand = -2,
        GeneralError = -1,
        Success = 0
    }
}