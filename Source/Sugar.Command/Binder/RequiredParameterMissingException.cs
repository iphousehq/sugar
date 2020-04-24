using System;

namespace Sugar.Command.Binder
{
    /// <summary>
    /// Exception to throw when a required <see cref="ParameterAttribute"/> is missing.
    /// </summary>
    public class RequiredParameterMissingException : ArgumentException
    {
        public RequiredParameterMissingException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}
