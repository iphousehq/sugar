using System;
using Amazon.Lambda.Core;

namespace Sugar.Amazon.Lambda
{
    /// <summary>
    /// Implementation of <see cref="ILambdaLogger"/> that only logs when an environment variable is set to true.
    /// </summary>
    public class FilteredLambdaLogger : ILambdaLogger
    {
        protected readonly bool IsLoggingEnabled;

        /// <summary>
        /// Default constructor (the environment variable name will default to "logToCloudwatch").
        /// </summary>
        public FilteredLambdaLogger() : this("logToCloudwatch")
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="environmentVariableName">If missing or cannot be parsed to a bool, logging will be enabled.</param>
        public FilteredLambdaLogger(string environmentVariableName)
        {
            // Defaults to logging if the environment variable is missing
            var value = Environment.GetEnvironmentVariable(environmentVariableName) ?? "True";

            IsLoggingEnabled = bool.Parse(value);
        }

        /// <summary>
        /// Logs a message to AWS CloudWatch Logs.
        /// 
        /// Logging will not be done:
        ///  If the role provided to the function does not have sufficient permissions.
        /// </summary>
        /// <param name="message"></param>
        public void Log(string message)
        {
            if (IsLoggingEnabled)
            {
                LambdaLogger.Log(message);
            }
        }

        /// <summary>
        /// Logs a message, followed by the current line terminator, to AWS CloudWatch Logs.
        /// 
        /// Logging will not be done:
        ///  If the role provided to the function does not have sufficient permissions.
        /// </summary>
        /// <param name="message"></param>
        public void LogLine(string message)
        {
            if (IsLoggingEnabled)
            {
                LambdaLogger.Log(message + Environment.NewLine);
            }
        }
    }
}