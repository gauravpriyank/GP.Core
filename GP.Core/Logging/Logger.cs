using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Core.Logging
{
    public static class Logger
    {
        private static readonly ILogger _logger;

        static Logger()
        {
            _logger = ServiceLocator.Current.GetInstance<ILogger>();
        }

        #region LogError methods

        /// <summary>
        /// Logs an error with the given message.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="categories">The category names used to route the log entry.</param>
        /// <exception cref="ArgumentNullException">message is null</exception>
        public static void LogError(string message, params string[] categories)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            _logger.LogError(message, categories);
        }

        /// <summary>
        /// Logs an error with the given exception.
        /// </summary>
        /// <param name="exception">The exception to log.</param>
        /// <param name="categories">The category names used to route the log entry.</param>
        /// <exception cref="ArgumentNullException">exception is null</exception>
        public static void LogError(Exception exception, params string[] categories)
        {
            if (exception == null)
                throw new ArgumentNullException("exception");

            _logger.LogError(exception, categories);
        }

        /// <summary>
        /// Logs an error with the given message and exception.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="exception">The exception to log..</param>
        /// <param name="categories">The category names used to route the log entry.</param>
        /// <exception cref="ArgumentNullException">message or exception are null</exception>
        public static void LogError(string message, Exception exception, params string[] categories)
        {
            if (message == null)
                throw new ArgumentNullException("message");
            if (exception == null)
                throw new ArgumentNullException("exception");

            _logger.LogError(message, exception, categories);
        }

        /// <summary>
        /// Logs an error with the given exception.
        /// </summary>
        /// <param name="exception">The exception to log.</param>
        /// <param name="categories">The category names used to route the log entry.</param>
        /// <exception cref="ArgumentNullException">exception is null</exception>
        public static void LogError(Exception exception, Dictionary<string, object> properties, params string[] categories)
        {
            if (exception == null)
                throw new ArgumentNullException("exception");
            if (properties == null)
                throw new ArgumentNullException("properties");

            _logger.LogError(exception, properties, categories);
        }

        #endregion

        #region LogWarning methods

        /// <summary>
        /// Logs a warning with the given message.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="categories">The category names used to route the log entry.</param>
        /// <exception cref="ArgumentNullException">message is null</exception>
        public static void LogWarning(string message, params string[] categories)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            _logger.LogWarning(message, categories);
        }

        /// <summary>
        /// Logs a warning with the given exception.
        /// </summary>
        /// <param name="exception">The exception to log.</param>
        /// <param name="categories">The category names used to route the log entry.</param>
        /// <exception cref="ArgumentNullException">exception is null</exception>
        public static void LogWarning(Exception exception, params string[] categories)
        {
            if (exception == null)
                throw new ArgumentNullException("exception");

            _logger.LogWarning(exception, categories);
        }

        /// <summary>
        /// Logs a warning with the given message and exception.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="exception">The exception to log.</param>
        /// <param name="categories">The category names used to route the log entry.</param>
        /// <exception cref="ArgumentNullException">message or exception are null</exception>
        public static void LogWarning(string message, Exception exception, params string[] categories)
        {
            if (message == null)
                throw new ArgumentNullException("message");
            if (exception == null)
                throw new ArgumentNullException("exception");

            _logger.LogWarning(message, exception, categories);
        }

        #endregion

        #region LogInformation methods

        /// <summary>
        /// Logs an informational message with the given message.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="categories">The category names used to route the log entry.</param>
        /// <exception cref="ArgumentNullException">message is null</exception>
        public static void LogInformation(string message, params string[] categories)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            _logger.LogInformation(message, categories);
        }

        /// <summary>
        /// Logs an informational message with the given exception.
        /// </summary>
        /// <param name="exception">The exception to log.</param>
        /// <param name="categories">The category names used to route the log entry.</param>
        /// <exception cref="ArgumentNullException">exception is null</exception>
        public static void LogInformation(Exception exception, params string[] categories)
        {
            if (exception == null)
                throw new ArgumentNullException("exception");

            _logger.LogInformation(exception, categories);
        }

        /// <summary>
        /// Logs an informational message with the given message and exception.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="exception">The exception to log.</param>
        /// <param name="categories">The category names used to route the log entry.</param>
        /// <exception cref="ArgumentNullException">message or exception are null</exception>
        public static void LogInformation(string message, Exception exception, params string[] categories)
        {
            if (message == null)
                throw new ArgumentNullException("message");
            if (exception == null)
                throw new ArgumentNullException("exception");

            _logger.LogInformation(message, exception, categories);
        }

        #endregion

        #region LogDebug methods

        /// <summary>
        /// Logs a debug message with the given message.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="categories">The category names used to route the log entry.</param>
        /// <exception cref="ArgumentNullException">message is null</exception>
        public static void LogDebug(string message, params string[] categories)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            _logger.LogDebug(message, categories);
        }

        /// <summary>
        /// Logs a debug message with the given exception.
        /// </summary>
        /// <param name="exception">The exception to log.</param>
        /// <param name="categories">The category names used to route the log entry.</param>
        /// <exception cref="ArgumentNullException">exception is null</exception>
        public static void LogDebug(Exception exception, params string[] categories)
        {
            if (exception == null)
                throw new ArgumentNullException("exception");

            _logger.LogDebug(exception, categories);
        }

        /// <summary>
        /// Logs a debug message with the given message and exception.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="exception">The exception to log.</param>
        /// <param name="categories">The category names used to route the log entry.</param>
        /// <exception cref="ArgumentNullException">message or exception are null</exception>
        public static void LogDebug(string message, Exception exception, params string[] categories)
        {
            if (message == null)
                throw new ArgumentNullException("message");
            if (exception == null)
                throw new ArgumentNullException("exception");

            _logger.LogDebug(message, exception, categories);
        }

        #endregion
    }
    
}
