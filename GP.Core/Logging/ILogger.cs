using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Core.Logging
{
    public interface ILogger
    {
        #region LogError methods

        /// <summary>
        /// Logs an error with the given message.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="categories">The category names used to route the log entry.</param>
        /// <exception cref="ArgumentNullException">message is null</exception>
        void LogError(string message, params string[] categories);

        /// <summary>
        /// Logs an error with the given exception.
        /// </summary>
        /// <param name="exception">The exception to log.</param>
        /// <param name="categories">The category names used to route the log entry.</param>
        /// <exception cref="ArgumentNullException">exception is null</exception>
        void LogError(Exception exception, params string[] categories);

        /// <summary>
        /// Logs an error with the given message and exception.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="exception">The exception to log..</param>
        /// <param name="categories">The category names used to route the log entry.</param>
        /// <exception cref="ArgumentNullException">message or exception are null</exception>
        void LogError(string message, Exception exception, params string[] categories);

        /// <summary>
        /// Logs an error with the given exception.
        /// </summary>
        /// <param name="exception">The exception to log.</param>
        /// <param name="categories">The category names used to route the log entry.</param>
        /// <exception cref="ArgumentNullException">exception is null</exception>
        void LogError(Exception exception, Dictionary<string, object> properties, params string[] categories);

        #endregion

        #region LogWarning methods

        /// <summary>
        /// Logs a warning with the given message.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="categories">The category names used to route the log entry.</param>
        /// <exception cref="ArgumentNullException">message is null</exception>
        void LogWarning(string message, params string[] categories);

        /// <summary>
        /// Logs a warning with the given exception.
        /// </summary>
        /// <param name="exception">The exception to log.</param>
        /// <param name="categories">The category names used to route the log entry.</param>
        /// <exception cref="ArgumentNullException">exception is null</exception>
        void LogWarning(Exception exception, params string[] categories);

        /// <summary>
        /// Logs a warning with the given message and exception.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="exception">The exception to log.</param>
        /// <param name="categories">The category names used to route the log entry.</param>
        /// <exception cref="ArgumentNullException">message or exception are null</exception>
        void LogWarning(string message, Exception exception, params string[] categories);

        #endregion

        #region LogInformation methods

        /// <summary>
        /// Logs an informational message with the given message.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="categories">The category names used to route the log entry.</param>
        /// <exception cref="ArgumentNullException">message is null</exception>
        void LogInformation(string message, params string[] categories);

        /// <summary>
        /// Logs an informational message with the given exception.
        /// </summary>
        /// <param name="exception">The exception to log.</param>
        /// <param name="categories">The category names used to route the log entry.</param>
        /// <exception cref="ArgumentNullException">exception is null</exception>
        void LogInformation(Exception exception, params string[] categories);

        /// <summary>
        /// Logs an informational message with the given message and exception.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="exception">The exception to log.</param>
        /// <param name="categories">The category names used to route the log entry.</param>
        /// <exception cref="ArgumentNullException">message or exception are null</exception>
        void LogInformation(string message, Exception exception, params string[] categories);

        #endregion

        #region LogDebug methods

        /// <summary>
        /// Logs a debug message with the given message.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="categories">The category names used to route the log entry.</param>
        /// <exception cref="ArgumentNullException">message is null</exception>
        void LogDebug(string message, params string[] categories);

        /// <summary>
        /// Logs a debug message with the given exception.
        /// </summary>
        /// <param name="exception">The exception to log.</param>
        /// <param name="categories">The category names used to route the log entry.</param>
        /// <exception cref="ArgumentNullException">exception is null</exception>
        void LogDebug(Exception exception, params string[] categories);

        /// <summary>
        /// Logs a debug message with the given message and exception.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="exception">The exception to log.</param>
        /// <param name="categories">The category names used to route the log entry.</param>
        /// <exception cref="ArgumentNullException">message or exception are null</exception>
        void LogDebug(string message, Exception exception, params string[] categories);

        #endregion
    }
}
