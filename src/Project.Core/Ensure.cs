using System;

namespace Project.Core
{
    public static class Ensure
    {
        /// <summary>
        /// Tests that the given rule passes (returns true). If not, then an
        /// application exception is thrown with the given message.
        /// </summary>
        public static void ApplicationRule(bool predicate, string message)
        {
            if (!predicate)
            {
                throw new ApplicationException(message);
            }
        }

        /// <summary>
        /// Test that the given argument object is not null. If it is, then
        /// an <see cref="ArgumentNullException"/> is thrown.
        /// </summary>
        public static void ArgumentNotNull(object arg, string argName)
        {
            if (arg == null)
            {
                throw new ArgumentNullException(argName, string.Format("Argument '{0}' is not allowed to be null", argName));
            }
        }

        /// <summary>
        /// Test that the given string argument is not null or empty. If it
        /// is, then an <see cref="ArgumentException"/> is thrown.
        /// </summary>
        public static void ArgumentNotNullOrEmpty(string arg, string argName)
        {
            if (arg.IsNullOrEmpty())
            {
                throw new ArgumentException(string.Format("Argument '{0}' is not allowed to be null or empty", argName), argName);
            }
        }
    }
}
