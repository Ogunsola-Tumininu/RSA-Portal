using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using NLog;

namespace Recapture.Common
{
    public static class LogProvider
    {
        // minimum support for unit testing
        public static bool UseNullLogger { get; set; }

        // based on https://github.com/PureKrome/SimpleLogging/blob/master/Code/SimpleLogging.NLog/NLogExtensions.cs
        /// <summary>
        /// Gets the logger named after the currently-being-initialized class.
        /// </summary>
        /// <returns>The logger.</returns>
        /// <remarks>This is a slow-running method. 
        /// Make sure you're not doing this in a loop.</remarks>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static ILogger GetLogger()
        {
            var framesToSkip = 1;
            string loggerName = null;
            var thisNamespace = typeof(LogProvider).Namespace ?? "";
            do
            {
                var frame = new StackFrame(framesToSkip, false);
                var method = frame.GetMethod();
                if (method == null)
                    break;

                framesToSkip++;

                var callerType = method.DeclaringType;
                if (callerType == null
                    || callerType.Namespace == null
                    || string.IsNullOrWhiteSpace(callerType.Namespace)
                    || callerType.Namespace.StartsWith("System.")
                    || callerType.Module.Name.Equals("mscorlib.dll", StringComparison.OrdinalIgnoreCase)
                    || callerType.Namespace.StartsWith(thisNamespace)
                    )
                    continue;

                loggerName = callerType.FullName;
                break;

            } while (true);

            return GetLogger(loggerName);

        }

        /// <summary>
        /// Gets the specified named logger.
        /// </summary>
        /// <param name="name">Name of the logger.</param>
        /// <returns>The logger reference. Multiple calls to <c>GetLogger</c> with the same argument aren't guaranteed to return the same logger reference.</returns>
        public static ILogger GetLogger(string name)
        {
            if (UseNullLogger)
                return new NullLogger();

            // should be configurable. or just inject ILogger using IoC and get rid of LogProvider altogether
            return new NLogLogger(LogManager.GetLogger(name));
        }
    }
}