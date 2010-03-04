using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PlanningPrep.Core.Exceptions
{
    public static class ExceptionHelper
    {
        /// <summary>
        /// Handles the process of repository level exception.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <returns></returns>
        public static TException HandleException<TException>(Exception exception)
            where TException : PanthException
        {
            Exception innerException = exception.InnerException ?? exception;
            ConstructorInfo exceptionType = typeof(TException).GetConstructor(new[] { typeof(string), typeof(Exception) });

            return (TException)exceptionType.Invoke(new object[] { innerException.Message, innerException });
        }

        /// <summary>
        /// Handles the process of repository level exception.
        /// </summary>
        /// <typeparam name="TException">The type of the exception.</typeparam>
        /// <param name="exception">The exception.</param>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public static TException HandleException<TException>(Exception exception, string source)
            where TException : PanthException
        {
            Exception innerException = exception.InnerException ?? exception;
            ConstructorInfo exceptionType = typeof(TException).GetConstructor(new[] { typeof(string), typeof(string), typeof(Exception) });

            return (TException)exceptionType.Invoke(new object[] { source, innerException.Message, innerException });
        }
    }
}
