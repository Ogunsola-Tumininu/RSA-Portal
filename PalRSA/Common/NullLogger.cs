using System;
using System.ComponentModel;
using JetBrains.Annotations;


namespace Recapture.Common
{
    public class NullLogger : ILogger
    {
        /// <summary>
        /// Gets a value indicating whether logging is enabled for the <c>Trace</c> level.
        /// </summary>
        /// <returns>A value of <see langword="true" /> if logging is enabled for the <c>Trace</c> level, otherwise it returns <see langword="false" />.</returns>
        public bool IsTraceEnabled
        {
            get { return false; }
        }

        /// <summary>
        /// Gets a value indicating whether logging is enabled for the <c>Debug</c> level.
        /// </summary>
        /// <returns>A value of <see langword="true" /> if logging is enabled for the <c>Debug</c> level, otherwise it returns <see langword="false" />.</returns>
        public bool IsDebugEnabled
        {
            get { return false; }
        }

        /// <summary>
        /// Gets a value indicating whether logging is enabled for the <c>Info</c> level.
        /// </summary>
        /// <returns>A value of <see langword="true" /> if logging is enabled for the <c>Info</c> level, otherwise it returns <see langword="false" />.</returns>
        public bool IsInfoEnabled
        {
            get { return false; }
        }

        /// <summary>
        /// Gets a value indicating whether logging is enabled for the <c>Warn</c> level.
        /// </summary>
        /// <returns>A value of <see langword="true" /> if logging is enabled for the <c>Warn</c> level, otherwise it returns <see langword="false" />.</returns>
        public bool IsWarnEnabled
        {
            get { return false; }
        }

        /// <summary>
        /// Gets a value indicating whether logging is enabled for the <c>Error</c> level.
        /// </summary>
        /// <returns>A value of <see langword="true" /> if logging is enabled for the <c>Error</c> level, otherwise it returns <see langword="false" />.</returns>
        public bool IsErrorEnabled
        {
            get { return false; }
        }

        /// <summary>
        /// Gets a value indicating whether logging is enabled for the <c>Fatal</c> level.
        /// </summary>
        /// <returns>A value of <see langword="true" /> if logging is enabled for the <c>Fatal</c> level, otherwise it returns <see langword="false" />.</returns>
        public bool IsFatalEnabled
        {
            get { return false; }
        }


        /// <summary>
        /// Writes the diagnostic message at the <c>Trace</c> level.
        /// </summary>
        /// <param name="messageFunc">A function returning message to be written. Function is not evaluated if logging is not enabled.</param>
        public void Trace(Func<string> messageFunc)
        {
            // do nothing
        }


        public void Trace(string message, Exception exception, params object[] args)
        {
            // do nothing
        }

        [StringFormatMethod("message")]
        public void Trace(IFormatProvider formatProvider,
            [Localizable(false)] string message, params object[] args)
        {
            // do nothing
        }

        public void Trace(IFormatProvider formatProvider, string message, Exception exception, params object[] args)
        {
            // do nothing
        }

        /// <summary>
        /// Writes the diagnostic message at the <c>Trace</c> level.
        /// </summary>
        /// <param name="message">Log message.</param>
        public void Trace([Localizable(false)] string message)
        {
            // do nothing
        }

        /// <summary>
        /// Writes the diagnostic message at the <c>Trace</c> level using the specified parameters.
        /// </summary>
        /// <param name="message">A <see langword="string" /> containing format items.</param>
        /// <param name="args">Arguments to format.</param>
        [StringFormatMethod("message")]
        public void Trace([Localizable(false)] string message, params object[] args)
        {
            // do nothing
        }

        /// <summary>
        /// Writes the diagnostic message and exception at the <c>Trace</c> level.
        /// </summary>
        /// <param name="message">A <see langword="string" /> to be written.</param>
        /// <param name="exception">An exception to be logged.</param>
        public void Trace([Localizable(false)] string message, Exception exception)
        {
            // do nothing
        }


        /// <summary>
        /// Writes the diagnostic message at the <c>Debug</c> level.
        /// </summary>
        /// <param name="messageFunc">A function returning message to be written. Function is not evaluated if logging is not enabled.</param>
        public void Debug(Func<string> messageFunc)
        {
            // do nothing
        }


        public void Debug(string message, Exception exception, params object[] args)
        {
            // do nothing
        }

        [StringFormatMethod("message")]
        public void Debug(IFormatProvider formatProvider,
            [Localizable(false)] string message, params object[] args)
        {
            // do nothing
        }

        public void Debug(IFormatProvider formatProvider, string message, Exception exception, params object[] args)
        {
            // do nothing
        }

        /// <summary>
        /// Writes the diagnostic message at the <c>Debug</c> level.
        /// </summary>
        /// <param name="message">Log message.</param>
        public void Debug([Localizable(false)] string message)
        {
            // do nothing
        }

        /// <summary>
        /// Writes the diagnostic message at the <c>Debug</c> level using the specified parameters.
        /// </summary>
        /// <param name="message">A <see langword="string" /> containing format items.</param>
        /// <param name="args">Arguments to format.</param>
        [StringFormatMethod("message")]
        public void Debug([Localizable(false)] string message, params object[] args)
        {
            // do nothing
        }

        /// <summary>
        /// Writes the diagnostic message and exception at the <c>Debug</c> level.
        /// </summary>
        /// <param name="message">A <see langword="string" /> to be written.</param>
        /// <param name="exception">An exception to be logged.</param>
        public void Debug([Localizable(false)] string message, Exception exception)
        {
            // do nothing
        }


        /// <summary>
        /// Writes the diagnostic message at the <c>Info</c> level.
        /// </summary>
        /// <param name="messageFunc">A function returning message to be written. Function is not evaluated if logging is not enabled.</param>
        public void Info(Func<string> messageFunc)
        {
            // do nothing
        }


        public void Info(string message, Exception exception, params object[] args)
        {
            // do nothing
        }

        [StringFormatMethod("message")]
        public void Info(IFormatProvider formatProvider,
            [Localizable(false)] string message, params object[] args)
        {
            // do nothing
        }

        public void Info(IFormatProvider formatProvider, string message, Exception exception, params object[] args)
        {
            // do nothing
        }

        /// <summary>
        /// Writes the diagnostic message at the <c>Info</c> level.
        /// </summary>
        /// <param name="message">Log message.</param>
        public void Info([Localizable(false)] string message)
        {
            // do nothing
        }

        /// <summary>
        /// Writes the diagnostic message at the <c>Info</c> level using the specified parameters.
        /// </summary>
        /// <param name="message">A <see langword="string" /> containing format items.</param>
        /// <param name="args">Arguments to format.</param>
        [StringFormatMethod("message")]
        public void Info([Localizable(false)] string message, params object[] args)
        {
            // do nothing
        }

        /// <summary>
        /// Writes the diagnostic message and exception at the <c>Info</c> level.
        /// </summary>
        /// <param name="message">A <see langword="string" /> to be written.</param>
        /// <param name="exception">An exception to be logged.</param>
        public void Info([Localizable(false)] string message, Exception exception)
        {
            // do nothing
        }

        /// <summary>
        /// Writes the diagnostic message at the <c>Warn</c> level.
        /// </summary>
        /// <param name="messageFunc">A function returning message to be written. Function is not evaluated if logging is not enabled.</param>
        public void Warn(Func<string> messageFunc)
        {
            // do nothing
        }


        public void Warn(string message, Exception exception, params object[] args)
        {
            // do nothing
        }

        [StringFormatMethod("message")]
        public void Warn(IFormatProvider formatProvider,
            [Localizable(false)] string message, params object[] args)
        {
            // do nothing
        }

        public void Warn(IFormatProvider formatProvider, string message, Exception exception, params object[] args)
        {
            // do nothing
        }

        /// <summary>
        /// Writes the diagnostic message at the <c>Warn</c> level.
        /// </summary>
        /// <param name="message">Log message.</param>
        public void Warn([Localizable(false)] string message)
        {
            // do nothing
        }

        /// <summary>
        /// Writes the diagnostic message at the <c>Warn</c> level using the specified parameters.
        /// </summary>
        /// <param name="message">A <see langword="string" /> containing format items.</param>
        /// <param name="args">Arguments to format.</param>
        [StringFormatMethod("message")]
        public void Warn([Localizable(false)] string message, params object[] args)
        {
            // do nothing
        }

        /// <summary>
        /// Writes the diagnostic message and exception at the <c>Warn</c> level.
        /// </summary>
        /// <param name="message">A <see langword="string" /> to be written.</param>
        /// <param name="exception">An exception to be logged.</param>
        public void Warn([Localizable(false)] string message, Exception exception)
        {
            // do nothing
        }


        /// <summary>
        /// Writes the diagnostic message at the <c>Error</c> level.
        /// </summary>
        /// <param name="messageFunc">A function returning message to be written. Function is not evaluated if logging is not enabled.</param>
        public void Error(Func<string> messageFunc)
        {
            // do nothing
        }


        public void Error(string message, Exception exception, params object[] args)
        {
            // do nothing
        }

        [StringFormatMethod("message")]
        public void Error(IFormatProvider formatProvider,
            [Localizable(false)] string message, params object[] args)
        {
            // do nothing
        }

        public void Error(IFormatProvider formatProvider, string message, Exception exception, params object[] args)
        {
            // do nothing
        }

        /// <summary>
        /// Writes the diagnostic message at the <c>Error</c> level.
        /// </summary>
        /// <param name="message">Log message.</param>
        public void Error([Localizable(false)] string message)
        {
            // do nothing
        }

        /// <summary>
        /// Writes the diagnostic message at the <c>Error</c> level using the specified parameters.
        /// </summary>
        /// <param name="message">A <see langword="string" /> containing format items.</param>
        /// <param name="args">Arguments to format.</param>
        [StringFormatMethod("message")]
        public void Error([Localizable(false)] string message, params object[] args)
        {
            // do nothing
        }

        /// <summary>
        /// Writes the diagnostic message and exception at the <c>Error</c> level.
        /// </summary>
        /// <param name="message">A <see langword="string" /> to be written.</param>
        /// <param name="exception">An exception to be logged.</param>
        public void Error([Localizable(false)] string message, Exception exception)
        {
            // do nothing
        }

        /// <summary>
        /// Writes the diagnostic message at the <c>Fatal</c> level.
        /// </summary>
        /// <param name="messageFunc">A function returning message to be written. Function is not evaluated if logging is not enabled.</param>
        public void Fatal(Func<string> messageFunc)
        {
            // do nothing
        }


        public void Fatal(string message, Exception exception, params object[] args)
        {
            // do nothing
        }

        [StringFormatMethod("message")]
        public void Fatal(IFormatProvider formatProvider,
            [Localizable(false)] string message, params object[] args)
        {
            // do nothing
        }

        public void Fatal(IFormatProvider formatProvider, string message, Exception exception, params object[] args)
        {
            // do nothing
        }

        /// <summary>
        /// Writes the diagnostic message at the <c>Fatal</c> level.
        /// </summary>
        /// <param name="message">Log message.</param>
        public void Fatal([Localizable(false)] string message)
        {
            // do nothing
        }

        /// <summary>
        /// Writes the diagnostic message at the <c>Fatal</c> level using the specified parameters.
        /// </summary>
        /// <param name="message">A <see langword="string" /> containing format items.</param>
        /// <param name="args">Arguments to format.</param>
        [StringFormatMethod("message")]
        public void Fatal([Localizable(false)] string message, params object[] args)
        {
            // do nothing
        }

        /// <summary>
        /// Writes the diagnostic message and exception at the <c>Fatal</c> level.
        /// </summary>
        /// <param name="message">A <see langword="string" /> to be written.</param>
        /// <param name="exception">An exception to be logged.</param>
        public void Fatal([Localizable(false)] string message, Exception exception)
        {
            // do nothing
        }

    }
}