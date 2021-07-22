using System;
using JetBrains.Annotations;
using NLog;

namespace Recapture.Common
{
    public class NLogLogger : ILogger
    {
        private readonly Logger _internalLogger;

        // needed for NLog to display correct {callsite}
        private readonly static Type DeclaringType = typeof(NLogLogger);

        public NLogLogger([NotNull] Logger internalLogger)
        {
            if (internalLogger == null) throw new ArgumentNullException("internalLogger");

            _internalLogger = internalLogger;
        }

        #region Is___Enabled
        /// <summary>
        /// Gets a value indicating whether this instance is trace enabled.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is trace enabled; otherwise, <c>false</c>.
        /// </value>
        public bool IsTraceEnabled
        {
            get { return _internalLogger.IsTraceEnabled; }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is debug enabled.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is debug enabled; otherwise, <c>false</c>.
        /// </value>
        public bool IsDebugEnabled
        {
            get { return _internalLogger.IsDebugEnabled; }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is info enabled.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is info enabled; otherwise, <c>false</c>.
        /// </value>
        public bool IsInfoEnabled
        {
            get { return _internalLogger.IsInfoEnabled; }
        }


        /// <summary>
        /// Gets a value indicating whether this instance is warn enabled.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is warn enabled; otherwise, <c>false</c>.
        /// </value>
        public bool IsWarnEnabled
        {
            get { return _internalLogger.IsWarnEnabled; }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is error enabled.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is error enabled; otherwise, <c>false</c>.
        /// </value>
        public bool IsErrorEnabled
        {
            get { return _internalLogger.IsErrorEnabled; }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is fatal enabled.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is fatal enabled; otherwise, <c>false</c>.
        /// </value>
        public bool IsFatalEnabled
        {
            get { return _internalLogger.IsFatalEnabled; }
        }
        #endregion

        #region Trace

        /// <summary>
        /// Log a message object with the <see cref="LogLevel.Trace"/> level.
        /// </summary>
        /// <param name="message">The message object to log.</param>
        public void Trace(string message)
        {
            if (!IsFatalEnabled)
                return;

            var level = GetLevel(LogLevel.Trace);
            var logEvent = new LogEventInfo(level, _internalLogger.Name, message);

            _internalLogger.Log(DeclaringType, logEvent);

        }

        /// <summary>
        /// Log a message object with the <see cref="LogLevel.Trace"/> level including
        /// the stack Trace of the <see cref="Exception"/> passed
        /// as a parameter.
        /// </summary>
        /// <param name="message">The message object to log.</param>
        /// <param name="exception">The exception to log, including its stack Trace.</param>
        public void Trace(string message, Exception exception)
        {
            if (!IsFatalEnabled)
                return;

            var level = GetLevel(LogLevel.Trace);
            var logEvent = new LogEventInfo(level, _internalLogger.Name, null, message, null, exception);

            _internalLogger.Log(DeclaringType, logEvent);
        }


        /// <summary>
        /// Log a message with the <see cref="LogLevel.Trace"/> level.
        /// </summary>
        /// <param name="message">The format of the message object to log.<see cref="string.Format(string,object[])"/> </param>
        /// <param name="args">the list of format arguments</param>
        public void Trace(string message, params object[] args)
        {
            if (!IsFatalEnabled)
                return;

            var level = GetLevel(LogLevel.Trace);
            var logEvent = new LogEventInfo(level, _internalLogger.Name, null, message, args);

            _internalLogger.Log(DeclaringType, logEvent);
        }

        /// <summary>
        /// Log a message with the <see cref="LogLevel.Trace"/> level.
        /// </summary>
        /// <param name="message">The format of the message object to log.<see cref="string.Format(string,object[])"/> </param>
        /// <param name="exception">The exception to log.</param>
        /// <param name="args">the list of format arguments</param>
        public void Trace(string message, Exception exception, params object[] args)
        {
            if (!IsFatalEnabled)
                return;

            var level = GetLevel(LogLevel.Trace);
            var logEvent = new LogEventInfo(level, _internalLogger.Name, null, message, args, exception);

            _internalLogger.Log(DeclaringType, logEvent);
        }
        /// <summary>
        /// Log a message with the <see cref="LogLevel.Trace"/> level.
        /// </summary>
        /// <param name="formatProvider">An <see cref="IFormatProvider"/> that supplies culture-specific formatting Fatalrmation.</param>
        /// <param name="message">The format of the message object to log.<see cref="string.Format(string,object[])"/> </param>
        /// <param name="args"></param>
        public void Trace(IFormatProvider formatProvider, string message, params object[] args)
        {
            if (!IsFatalEnabled)
                return;

            var level = GetLevel(LogLevel.Trace);
            var logEvent = new LogEventInfo(level, _internalLogger.Name, formatProvider, message, args);

            _internalLogger.Log(DeclaringType, logEvent);
        }

        /// <summary>
        /// Log a message with the <see cref="LogLevel.Trace"/> level.
        /// </summary>
        /// <param name="formatProvider">An <see cref="IFormatProvider"/> that supplies culture-specific formatting Fatalrmation.</param>
        /// <param name="message">The format of the message object to log.<see cref="string.Format(string,object[])"/> </param>
        /// <param name="exception">The exception to log.</param>
        /// <param name="args"></param>
        public void Trace(IFormatProvider formatProvider, string message, Exception exception, params object[] args)
        {
            if (!IsFatalEnabled)
                return;

            var level = GetLevel(LogLevel.Trace);
            var logEvent = new LogEventInfo(level, _internalLogger.Name, formatProvider, message, args, exception);

            _internalLogger.Log(DeclaringType, logEvent);
        }

        #endregion

        #region Debug

        /// <summary>
        /// Log a message object with the <see cref="LogLevel.Debug"/> level.
        /// </summary>
        /// <param name="message">The message object to log.</param>
        public void Debug(string message)
        {
            if (!IsFatalEnabled)
                return;

            var level = GetLevel(LogLevel.Debug);
            var logEvent = new LogEventInfo(level, _internalLogger.Name, message);

            _internalLogger.Log(DeclaringType, logEvent);

        }

        /// <summary>
        /// Log a message object with the <see cref="LogLevel.Debug"/> level including
        /// the stack Debug of the <see cref="Exception"/> passed
        /// as a parameter.
        /// </summary>
        /// <param name="message">The message object to log.</param>
        /// <param name="exception">The exception to log, including its stack Debug.</param>
        public void Debug(string message, Exception exception)
        {
            if (!IsFatalEnabled)
                return;

            var level = GetLevel(LogLevel.Debug);
            var logEvent = new LogEventInfo(level, _internalLogger.Name, null, message, null, exception);

            _internalLogger.Log(DeclaringType, logEvent);
        }


        /// <summary>
        /// Log a message with the <see cref="LogLevel.Debug"/> level.
        /// </summary>
        /// <param name="message">The format of the message object to log.<see cref="string.Format(string,object[])"/> </param>
        /// <param name="args">the list of format arguments</param>
        public void Debug(string message, params object[] args)
        {
            if (!IsFatalEnabled)
                return;

            var level = GetLevel(LogLevel.Debug);
            var logEvent = new LogEventInfo(level, _internalLogger.Name, null, message, args);

            _internalLogger.Log(DeclaringType, logEvent);
        }

        /// <summary>
        /// Log a message with the <see cref="LogLevel.Debug"/> level.
        /// </summary>
        /// <param name="message">The format of the message object to log.<see cref="string.Format(string,object[])"/> </param>
        /// <param name="exception">The exception to log.</param>
        /// <param name="args">the list of format arguments</param>
        public void Debug(string message, Exception exception, params object[] args)
        {
            if (!IsFatalEnabled)
                return;

            var level = GetLevel(LogLevel.Debug);
            var logEvent = new LogEventInfo(level, _internalLogger.Name, null, message, args, exception);

            _internalLogger.Log(DeclaringType, logEvent);
        }
        /// <summary>
        /// Log a message with the <see cref="LogLevel.Debug"/> level.
        /// </summary>
        /// <param name="formatProvider">An <see cref="IFormatProvider"/> that supplies culture-specific formatting Fatalrmation.</param>
        /// <param name="message">The format of the message object to log.<see cref="string.Format(string,object[])"/> </param>
        /// <param name="args"></param>
        public void Debug(IFormatProvider formatProvider, string message, params object[] args)
        {
            if (!IsFatalEnabled)
                return;

            var level = GetLevel(LogLevel.Debug);
            var logEvent = new LogEventInfo(level, _internalLogger.Name, formatProvider, message, args);

            _internalLogger.Log(DeclaringType, logEvent);
        }

        /// <summary>
        /// Log a message with the <see cref="LogLevel.Debug"/> level.
        /// </summary>
        /// <param name="formatProvider">An <see cref="IFormatProvider"/> that supplies culture-specific formatting Fatalrmation.</param>
        /// <param name="message">The format of the message object to log.<see cref="string.Format(string,object[])"/> </param>
        /// <param name="exception">The exception to log.</param>
        /// <param name="args"></param>
        public void Debug(IFormatProvider formatProvider, string message, Exception exception, params object[] args)
        {
            if (!IsFatalEnabled)
                return;

            var level = GetLevel(LogLevel.Debug);
            var logEvent = new LogEventInfo(level, _internalLogger.Name, formatProvider, message, args, exception);

            _internalLogger.Log(DeclaringType, logEvent);
        }
        #endregion

        #region Info

        /// <summary>
        /// Log a message object with the <see cref="LogLevel.Info"/> level.
        /// </summary>
        /// <param name="message">The message object to log.</param>
        public void Info(string message)
        {
            if (!IsFatalEnabled)
                return;

            var level = GetLevel(LogLevel.Info);
            var logEvent = new LogEventInfo(level, _internalLogger.Name, message);

            _internalLogger.Log(DeclaringType, logEvent);

        }

        /// <summary>
        /// Log a message object with the <see cref="LogLevel.Info"/> level including
        /// the stack Info of the <see cref="Exception"/> passed
        /// as a parameter.
        /// </summary>
        /// <param name="message">The message object to log.</param>
        /// <param name="exception">The exception to log, including its stack Info.</param>
        public void Info(string message, Exception exception)
        {
            if (!IsFatalEnabled)
                return;

            var level = GetLevel(LogLevel.Info);
            var logEvent = new LogEventInfo(level, _internalLogger.Name, null, message, null, exception);

            _internalLogger.Log(DeclaringType, logEvent);
        }


        /// <summary>
        /// Log a message with the <see cref="LogLevel.Info"/> level.
        /// </summary>
        /// <param name="message">The format of the message object to log.<see cref="string.Format(string,object[])"/> </param>
        /// <param name="args">the list of format arguments</param>
        public void Info(string message, params object[] args)
        {
            if (!IsFatalEnabled)
                return;

            var level = GetLevel(LogLevel.Info);
            var logEvent = new LogEventInfo(level, _internalLogger.Name, null, message, args);

            _internalLogger.Log(DeclaringType, logEvent);
        }

        /// <summary>
        /// Log a message with the <see cref="LogLevel.Info"/> level.
        /// </summary>
        /// <param name="message">The format of the message object to log.<see cref="string.Format(string,object[])"/> </param>
        /// <param name="exception">The exception to log.</param>
        /// <param name="args">the list of format arguments</param>
        public void Info(string message, Exception exception, params object[] args)
        {
            if (!IsFatalEnabled)
                return;

            var level = GetLevel(LogLevel.Info);
            var logEvent = new LogEventInfo(level, _internalLogger.Name, null, message, args, exception);

            _internalLogger.Log(DeclaringType, logEvent);
        }
        /// <summary>
        /// Log a message with the <see cref="LogLevel.Info"/> level.
        /// </summary>
        /// <param name="formatProvider">An <see cref="IFormatProvider"/> that supplies culture-specific formatting Fatalrmation.</param>
        /// <param name="message">The format of the message object to log.<see cref="string.Format(string,object[])"/> </param>
        /// <param name="args"></param>
        public void Info(IFormatProvider formatProvider, string message, params object[] args)
        {
            if (!IsFatalEnabled)
                return;

            var level = GetLevel(LogLevel.Info);
            var logEvent = new LogEventInfo(level, _internalLogger.Name, formatProvider, message, args);

            _internalLogger.Log(DeclaringType, logEvent);
        }

        /// <summary>
        /// Log a message with the <see cref="LogLevel.Info"/> level.
        /// </summary>
        /// <param name="formatProvider">An <see cref="IFormatProvider"/> that supplies culture-specific formatting Fatalrmation.</param>
        /// <param name="message">The format of the message object to log.<see cref="string.Format(string,object[])"/> </param>
        /// <param name="exception">The exception to log.</param>
        /// <param name="args"></param>
        public void Info(IFormatProvider formatProvider, string message, Exception exception, params object[] args)
        {
            if (!IsFatalEnabled)
                return;

            var level = GetLevel(LogLevel.Info);
            var logEvent = new LogEventInfo(level, _internalLogger.Name, formatProvider, message, args, exception);

            _internalLogger.Log(DeclaringType, logEvent);
        }




        #endregion

        #region Warn

        /// <summary>
        /// Log a message object with the <see cref="LogLevel.Warn"/> level.
        /// </summary>
        /// <param name="message">The message object to log.</param>
        public void Warn(string message)
        {
            if (!IsFatalEnabled)
                return;

            var level = GetLevel(LogLevel.Warn);
            var logEvent = new LogEventInfo(level, _internalLogger.Name, message);

            _internalLogger.Log(DeclaringType, logEvent);

        }

        /// <summary>
        /// Log a message object with the <see cref="LogLevel.Warn"/> level including
        /// the stack Warn of the <see cref="Exception"/> passed
        /// as a parameter.
        /// </summary>
        /// <param name="message">The message object to log.</param>
        /// <param name="exception">The exception to log, including its stack Warn.</param>
        public void Warn(string message, Exception exception)
        {
            if (!IsFatalEnabled)
                return;

            var level = GetLevel(LogLevel.Warn);
            var logEvent = new LogEventInfo(level, _internalLogger.Name, null, message, null, exception);

            _internalLogger.Log(DeclaringType, logEvent);
        }


        /// <summary>
        /// Log a message with the <see cref="LogLevel.Warn"/> level.
        /// </summary>
        /// <param name="message">The format of the message object to log.<see cref="string.Format(string,object[])"/> </param>
        /// <param name="args">the list of format arguments</param>
        public void Warn(string message, params object[] args)
        {
            if (!IsFatalEnabled)
                return;

            var level = GetLevel(LogLevel.Warn);
            var logEvent = new LogEventInfo(level, _internalLogger.Name, null, message, args);

            _internalLogger.Log(DeclaringType, logEvent);
        }

        /// <summary>
        /// Log a message with the <see cref="LogLevel.Warn"/> level.
        /// </summary>
        /// <param name="message">The format of the message object to log.<see cref="string.Format(string,object[])"/> </param>
        /// <param name="exception">The exception to log.</param>
        /// <param name="args">the list of format arguments</param>
        public void Warn(string message, Exception exception, params object[] args)
        {
            if (!IsFatalEnabled)
                return;

            var level = GetLevel(LogLevel.Warn);
            var logEvent = new LogEventInfo(level, _internalLogger.Name, null, message, args, exception);

            _internalLogger.Log(DeclaringType, logEvent);
        }
        /// <summary>
        /// Log a message with the <see cref="LogLevel.Warn"/> level.
        /// </summary>
        /// <param name="formatProvider">An <see cref="IFormatProvider"/> that supplies culture-specific formatting Fatalrmation.</param>
        /// <param name="message">The format of the message object to log.<see cref="string.Format(string,object[])"/> </param>
        /// <param name="args"></param>
        public void Warn(IFormatProvider formatProvider, string message, params object[] args)
        {
            if (!IsFatalEnabled)
                return;

            var level = GetLevel(LogLevel.Warn);
            var logEvent = new LogEventInfo(level, _internalLogger.Name, formatProvider, message, args);

            _internalLogger.Log(DeclaringType, logEvent);
        }

        /// <summary>
        /// Log a message with the <see cref="LogLevel.Warn"/> level.
        /// </summary>
        /// <param name="formatProvider">An <see cref="IFormatProvider"/> that supplies culture-specific formatting Fatalrmation.</param>
        /// <param name="message">The format of the message object to log.<see cref="string.Format(string,object[])"/> </param>
        /// <param name="exception">The exception to log.</param>
        /// <param name="args"></param>
        public void Warn(IFormatProvider formatProvider, string message, Exception exception, params object[] args)
        {
            if (!IsFatalEnabled)
                return;

            var level = GetLevel(LogLevel.Warn);
            var logEvent = new LogEventInfo(level, _internalLogger.Name, formatProvider, message, args, exception);

            _internalLogger.Log(DeclaringType, logEvent);
        }




        #endregion

        #region Error

        /// <summary>
        /// Log a message object with the <see cref="LogLevel.Error"/> level.
        /// </summary>
        /// <param name="message">The message object to log.</param>
        public void Error(string message)
        {
            if (!IsFatalEnabled)
                return;

            var level = GetLevel(LogLevel.Error);
            var logEvent = new LogEventInfo(level, _internalLogger.Name, message);

            _internalLogger.Log(DeclaringType, logEvent);

        }

        /// <summary>
        /// Log a message object with the <see cref="LogLevel.Error"/> level including
        /// the stack Error of the <see cref="Exception"/> passed
        /// as a parameter.
        /// </summary>
        /// <param name="message">The message object to log.</param>
        /// <param name="exception">The exception to log, including its stack Error.</param>
        public void Error(string message, Exception exception)
        {
            if (!IsFatalEnabled)
                return;

            var level = GetLevel(LogLevel.Error);
            var logEvent = new LogEventInfo(level, _internalLogger.Name, null, message, null, exception);

            _internalLogger.Log(DeclaringType, logEvent);
        }


        /// <summary>
        /// Log a message with the <see cref="LogLevel.Error"/> level.
        /// </summary>
        /// <param name="message">The format of the message object to log.<see cref="string.Format(string,object[])"/> </param>
        /// <param name="args">the list of format arguments</param>
        public void Error(string message, params object[] args)
        {
            if (!IsFatalEnabled)
                return;

            var level = GetLevel(LogLevel.Error);
            var logEvent = new LogEventInfo(level, _internalLogger.Name, null, message, args);

            _internalLogger.Log(DeclaringType, logEvent);
        }

        /// <summary>
        /// Log a message with the <see cref="LogLevel.Error"/> level.
        /// </summary>
        /// <param name="message">The format of the message object to log.<see cref="string.Format(string,object[])"/> </param>
        /// <param name="exception">The exception to log.</param>
        /// <param name="args">the list of format arguments</param>
        public void Error(string message, Exception exception, params object[] args)
        {
            if (!IsFatalEnabled)
                return;

            var level = GetLevel(LogLevel.Error);
            var logEvent = new LogEventInfo(level, _internalLogger.Name, null, message, args, exception);

            _internalLogger.Log(DeclaringType, logEvent);
        }
        /// <summary>
        /// Log a message with the <see cref="LogLevel.Error"/> level.
        /// </summary>
        /// <param name="formatProvider">An <see cref="IFormatProvider"/> that supplies culture-specific formatting Fatalrmation.</param>
        /// <param name="message">The format of the message object to log.<see cref="string.Format(string,object[])"/> </param>
        /// <param name="args"></param>
        public void Error(IFormatProvider formatProvider, string message, params object[] args)
        {
            if (!IsFatalEnabled)
                return;

            var level = GetLevel(LogLevel.Error);
            var logEvent = new LogEventInfo(level, _internalLogger.Name, formatProvider, message, args);

            _internalLogger.Log(DeclaringType, logEvent);
        }

        /// <summary>
        /// Log a message with the <see cref="LogLevel.Error"/> level.
        /// </summary>
        /// <param name="formatProvider">An <see cref="IFormatProvider"/> that supplies culture-specific formatting Fatalrmation.</param>
        /// <param name="message">The format of the message object to log.<see cref="string.Format(string,object[])"/> </param>
        /// <param name="exception">The exception to log.</param>
        /// <param name="args"></param>
        public void Error(IFormatProvider formatProvider, string message, Exception exception, params object[] args)
        {
            if (!IsFatalEnabled)
                return;

            var level = GetLevel(LogLevel.Error);
            var logEvent = new LogEventInfo(level, _internalLogger.Name, formatProvider, message, args, exception);

            _internalLogger.Log(DeclaringType, logEvent);
        }

        #endregion

        #region Fatal

        /// <summary>
        /// Log a message object with the <see cref="LogLevel.Fatal"/> level.
        /// </summary>
        /// <param name="message">The message object to log.</param>
        public void Fatal(string message)
        {
            if (!IsFatalEnabled)
                return;

            var level = GetLevel(LogLevel.Fatal);
            var logEvent = new LogEventInfo(level, _internalLogger.Name, message);

            _internalLogger.Log(DeclaringType, logEvent);

        }

        /// <summary>
        /// Log a message object with the <see cref="LogLevel.Fatal"/> level including
        /// the stack Fatal of the <see cref="Exception"/> passed
        /// as a parameter.
        /// </summary>
        /// <param name="message">The message object to log.</param>
        /// <param name="exception">The exception to log, including its stack Fatal.</param>
        public void Fatal(string message, Exception exception)
        {
            if (!IsFatalEnabled)
                return;

            var level = GetLevel(LogLevel.Fatal);
            var logEvent = new LogEventInfo(level, _internalLogger.Name, null, message, null, exception);

            _internalLogger.Log(DeclaringType, logEvent);
        }


        /// <summary>
        /// Log a message with the <see cref="LogLevel.Fatal"/> level.
        /// </summary>
        /// <param name="message">The format of the message object to log.<see cref="string.Format(string,object[])"/> </param>
        /// <param name="args">the list of format arguments</param>
        public void Fatal(string message, params object[] args)
        {
            if (!IsFatalEnabled)
                return;

            var level = GetLevel(LogLevel.Fatal);
            var logEvent = new LogEventInfo(level, _internalLogger.Name, null, message, args);

            _internalLogger.Log(DeclaringType, logEvent);
        }

        /// <summary>
        /// Log a message with the <see cref="LogLevel.Fatal"/> level.
        /// </summary>
        /// <param name="message">The format of the message object to log.<see cref="string.Format(string,object[])"/> </param>
        /// <param name="exception">The exception to log.</param>
        /// <param name="args">the list of format arguments</param>
        public void Fatal(string message, Exception exception, params object[] args)
        {
            if (!IsFatalEnabled)
                return;

            var level = GetLevel(LogLevel.Fatal);
            var logEvent = new LogEventInfo(level, _internalLogger.Name, null, message, args, exception);

            _internalLogger.Log(DeclaringType, logEvent);
        }
        /// <summary>
        /// Log a message with the <see cref="LogLevel.Fatal"/> level.
        /// </summary>
        /// <param name="formatProvider">An <see cref="IFormatProvider"/> that supplies culture-specific formatting Fatalrmation.</param>
        /// <param name="message">The format of the message object to log.<see cref="string.Format(string,object[])"/> </param>
        /// <param name="args"></param>
        public void Fatal(IFormatProvider formatProvider, string message, params object[] args)
        {
            if (!IsFatalEnabled)
                return;

            var level = GetLevel(LogLevel.Fatal);
            var logEvent = new LogEventInfo(level, _internalLogger.Name, formatProvider, message, args);

            _internalLogger.Log(DeclaringType, logEvent);
        }

        /// <summary>
        /// Log a message with the <see cref="LogLevel.Fatal"/> level.
        /// </summary>
        /// <param name="formatProvider">An <see cref="IFormatProvider"/> that supplies culture-specific formatting Fatalrmation.</param>
        /// <param name="message">The format of the message object to log.<see cref="string.Format(string,object[])"/> </param>
        /// <param name="exception">The exception to log.</param>
        /// <param name="args"></param>
        public void Fatal(IFormatProvider formatProvider, string message, Exception exception, params object[] args)
        {
            if (!IsFatalEnabled)
                return;

            var level = GetLevel(LogLevel.Fatal);
            var logEvent = new LogEventInfo(level, _internalLogger.Name, formatProvider, message, args, exception);

            _internalLogger.Log(DeclaringType, logEvent);
        }




        #endregion

        private static NLog.LogLevel GetLevel(LogLevel logLevel)
        {
            switch (logLevel)
            {
                case LogLevel.All:
                    return NLog.LogLevel.Trace;
                case LogLevel.Trace:
                    return NLog.LogLevel.Trace;
                case LogLevel.Debug:
                    return NLog.LogLevel.Debug;
                case LogLevel.Info:
                    return NLog.LogLevel.Info;
                case LogLevel.Warn:
                    return NLog.LogLevel.Warn;
                case LogLevel.Error:
                    return NLog.LogLevel.Error;
                case LogLevel.Fatal:
                    return NLog.LogLevel.Fatal;
                case LogLevel.Off:
                    return NLog.LogLevel.Off;
                default:
                    throw new ArgumentOutOfRangeException("logLevel", logLevel, "Unknown log level");
            }
        }
    }
}