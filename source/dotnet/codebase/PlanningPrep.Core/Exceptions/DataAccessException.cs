/* --------------------------------------------------------------------------------
 * Client Name: 
 * Project Name: 
 * Module: Pantheon.Core
 * Name: DataAccessException
 * Purpose: Custom exception class for Data Access Exception
 *                   
 * Author: MH
 * Language: C# SDK version 2.0
 * --------------------------------------------------------------------------------
 * Change History:
 * version: 1.0    MH  12/08/09
 * Description: Initial Development
 * -------------------------------------------------------------------------------- */
using System;

namespace PlanningPrep.Core.Exceptions
{
    public class DataAccessException : PanthException
    {        
        /// <summary>
        /// Initializes a new instance of the <see cref="DataAccessException"/> class.
        /// </summary>
        public DataAccessException() {}

        /// <summary>
        /// Initializes a new instance of the <see cref="DataAccessException"/> class.
        /// </summary>
        public DataAccessException(string message)
            : base(message)
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataAccessException"/> class.
        /// </summary>
        public DataAccessException(string errorMessage, Exception exception)
            : base(errorMessage, exception)
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataAccessException"/> class.
        /// </summary>
        public DataAccessException(string errorMessage, Exception exception, string exceptionSource)
            : base(errorMessage, exception, exceptionSource)
        {            
        }

        /// <summary>
        /// Gets the message.
        /// </summary>
        /// <value>The message.</value>
        public override string Message
        {
            get
            {
                return ExceptionSource != "" ? string.Format("{0}: {1}", ExceptionSource, base.Message) : base.Message;
            }
        }
    }
}
