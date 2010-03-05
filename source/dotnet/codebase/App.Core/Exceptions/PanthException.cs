#region History

/* --------------------------------------------------------------------------------
 * Client Name: 
 * Project Name: 
 * Module: App.Core
 * Name: PanthException
 * Purpose: Message reader class from XML file
 *                   
 * Author: MH
 * Language: C# SDK version 2.0
 * --------------------------------------------------------------------------------
 * Change History:
 * version: 1.0    MH  12/08/09
 * Description: Initial Development
 * -------------------------------------------------------------------------------- */

#endregion
using System;

namespace App.Core.Exceptions
{
    public class PanthException : ApplicationException
    {
        /// <summary>
        /// Gets or sets the name of the service.
        /// </summary>
        /// <value>The name of the service.</value>
        public string ExceptionSource { get; private set; }

        public PanthException() {}

        public PanthException( string errorMessage )
            : base( errorMessage )
        {
        }

        public PanthException(string errorMessage, Exception exception)
            : base(errorMessage, exception)
        {
        }

        public PanthException(string errorMessage, Exception exception, string exceptionSource)
            : base(errorMessage, exception)
        {
            ExceptionSource = exceptionSource;
        }

        public override string Message
        {
            get
            {
                return String.Format("A error occurred while trying to process your request ({0}).", base.Message);
            }
        }
    }
}
