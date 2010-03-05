using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Core.Exceptions
{
    public class CommunicationException : PanthException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommunicationException"/> class.
        /// </summary>
        public CommunicationException() {}

        /// <summary>
        /// Initializes a new instance of the <see cref="CommunicationException"/> class.
        /// </summary>
        /// <param name="errorMessage">The error message.</param>
        public CommunicationException(string errorMessage)
            : base(errorMessage)
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ManagerException"/> class.
        /// </summary>
        /// <param name="errorMessage">The error message.</param>
        /// <param name="innerException">The inner exception.</param>
        public CommunicationException(string errorMessage, Exception innerException)
            : base(errorMessage, innerException)
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CommunicationException"/> class.
        /// </summary>
        /// <param name="errorMessage">The error message.</param>
        /// <param name="innerException">The inner exception.</param>
        /// <param name="exceptionSource">The exception source.</param>
        public CommunicationException(string errorMessage, Exception innerException, string exceptionSource)
            : base(errorMessage, innerException, exceptionSource)
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
                if (ExceptionSource != "")
                {
                    return string.Format("{0}: {1}", ExceptionSource, base.Message);
                }
                return base.Message;
            }
        }
    }
}
