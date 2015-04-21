using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Logging;

namespace GP.Core.Logging.EntLib
{
    public class Logger : ILogger
    {
        private const int DefaultPriority = -1;
        private const int DefaultEventId = 0;
        private const string DefaultTitle = "";
        private static readonly LogWriter LogWriter;

        static Logger()
        {
            IConfigurationSource config = ConfigurationSourceFactory.Create();
            LogWriterFactory logWriterFactory = new LogWriterFactory(config);
            LogWriter = logWriterFactory.Create();
        }
        #region Properties: Private        

        #endregion

        #region LogError methods

        /// <summary>
        /// Logs an error with the given message.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="categories">The category names used to route the log entry.</param>
        /// <exception cref="ArgumentNullException">message is null</exception>
        public void LogError(string message, params string[] categories)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            LogWriter.Write(message, categories, DefaultPriority, DefaultEventId, TraceEventType.Error, DefaultTitle, null);
        }


        /// <summary>
        /// Logs an error with the given exception.
        /// </summary>
        /// <param name="exception">The exception to log.</param>
        /// <param name="categories">The category names used to route the log entry.</param>
        /// <exception cref="ArgumentNullException">exception is null</exception>
        public void LogError(Exception exception, params string[] categories)
        {
            if (exception == null)
                throw new ArgumentNullException("exception");

            LogWriter.Write(exception, categories, DefaultPriority, DefaultEventId, TraceEventType.Error, DefaultTitle, null);
        }

        /// <summary>
        /// Logs an error with the given message and exception.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="exception">The exception to log..</param>
        /// <param name="categories">The category names used to route the log entry.</param>
        /// <exception cref="ArgumentNullException">message or exception are null</exception>
        public void LogError(string message, Exception exception, params string[] categories)
        {
            if (message == null)
                throw new ArgumentNullException("message");
            if (exception == null)
                throw new ArgumentNullException("exception");

            LogWriter.Write("{0}\n\n{1}".FormatWith(message, exception), categories, DefaultPriority, DefaultEventId, TraceEventType.Error, DefaultTitle, null);
        }

        public void LogError(Exception exception, Dictionary<string, object> properties, params string[] categories)
        {
            if (exception == null)
                throw new ArgumentNullException("exception");
            if (properties == null)
                throw new ArgumentNullException("properties");

            LogWriter.Write(exception, categories, DefaultPriority, DefaultEventId, TraceEventType.Error, DefaultTitle, properties);
        }

        #endregion

        #region LogWarning methods

        /// <summary>
        /// Logs a warning with the given message.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="categories">The category names used to route the log entry.</param>
        /// <exception cref="ArgumentNullException">message is null</exception>
        public void LogWarning(string message, params string[] categories)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            LogWriter.Write(message, categories, DefaultPriority, DefaultEventId, TraceEventType.Warning, DefaultTitle, null);

        }


        /// <summary>
        /// Logs a warning with the given exception.
        /// </summary>
        /// <param name="exception">The exception to log.</param>
        /// <param name="categories">The category names used to route the log entry.</param>
        /// <exception cref="ArgumentNullException">exception is null</exception>
        public void LogWarning(Exception exception, params string[] categories)
        {
            if (exception == null)
                throw new ArgumentNullException("exception");

            LogWriter.Write(exception, categories, DefaultPriority, DefaultEventId, TraceEventType.Warning, DefaultTitle, null);
        }


        /// <summary>
        /// Logs a warning with the given message and exception.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="exception">The exception to log.</param>
        /// <param name="categories">The category names used to route the log entry.</param>
        /// <exception cref="ArgumentNullException">message or exception are null</exception>
        public void LogWarning(string message, Exception exception, params string[] categories)
        {
            if (message == null)
                throw new ArgumentNullException("message");
            if (exception == null)
                throw new ArgumentNullException("exception");

            LogWriter.Write("{0}\n\n{1}".FormatWith(message, exception), categories, DefaultPriority, DefaultEventId, TraceEventType.Warning, DefaultTitle, null);
        }

        #endregion

        #region LogInformation methods

        /// <summary>
        /// Logs an informational message with the given message.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="categories">The category names used to route the log entry.</param>
        /// <exception cref="ArgumentNullException">message is null</exception>
        public void LogInformation(string message, params string[] categories)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            LogWriter.Write(message, categories, DefaultPriority, DefaultEventId, TraceEventType.Information, DefaultTitle, null);

        }


        /// <summary>
        /// Logs an informational message with the given exception.
        /// </summary>
        /// <param name="exception">The exception to log.</param>
        /// <param name="categories">The category names used to route the log entry.</param>
        /// <exception cref="ArgumentNullException">exception is null</exception>
        public void LogInformation(Exception exception, params string[] categories)
        {
            if (exception == null)
                throw new ArgumentNullException("exception");

            LogWriter.Write(exception, categories, DefaultPriority, DefaultEventId, TraceEventType.Information, DefaultTitle, null);
        }


        /// <summary>
        /// Logs an informational message with the given message and exception.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="exception">The exception to log.</param>
        /// <param name="categories">The category names used to route the log entry.</param>
        /// <exception cref="ArgumentNullException">message or exception are null</exception>
        public void LogInformation(string message, Exception exception, params string[] categories)
        {
            if (message == null)
                throw new ArgumentNullException("message");
            if (exception == null)
                throw new ArgumentNullException("exception");

            LogWriter.Write("{0}\n\n{1}".FormatWith(message, exception), categories, DefaultPriority, DefaultEventId, TraceEventType.Information, DefaultTitle, null);
        }

        #endregion

        #region LogDebug methods

        /// <summary>
        /// Logs a debug message with the given message.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="categories">The category names used to route the log entry.</param>
        /// <exception cref="ArgumentNullException">message is null</exception>
        public void LogDebug(string message, params string[] categories)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            LogWriter.Write(message, categories, DefaultPriority, DefaultEventId, TraceEventType.Verbose, DefaultTitle, null);
        }

        /// <summary>
        /// Logs a debug message with the given exception.
        /// </summary>
        /// <param name="exception">The exception to log.</param>
        /// <param name="categories">The category names used to route the log entry.</param>
        /// <exception cref="ArgumentNullException">exception is null</exception>
        public void LogDebug(Exception exception, params string[] categories)
        {
            if (exception == null)
                throw new ArgumentNullException("exception");

            LogWriter.Write(exception, categories, DefaultPriority, DefaultEventId, TraceEventType.Verbose, DefaultTitle, null);
        }

        /// <summary>
        /// Logs a debug message with the given message and exception.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="exception">The exception to log.</param>
        /// <param name="categories">The category names used to route the log entry.</param>
        /// <exception cref="ArgumentNullException">message or exception are null</exception>
        public void LogDebug(string message, Exception exception, params string[] categories)
        {
            if (message == null)
                throw new ArgumentNullException("message");
            if (exception == null)
                throw new ArgumentNullException("exception");

            LogWriter.Write("{0}\n\n{1}".FormatWith(message, exception), categories, DefaultPriority, DefaultEventId, TraceEventType.Verbose, DefaultTitle, null);
        }

        #endregion
    }
}
