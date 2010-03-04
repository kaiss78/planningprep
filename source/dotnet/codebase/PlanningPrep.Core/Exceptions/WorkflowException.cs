﻿/* --------------------------------------------------------------------------------
 * Client Name: 
 * Project Name: 
 * Module: Pantheon.Core
 * Name: DataAccessException
 * Purpose: Custom exception class for WorkflowException
 *                   
 * Author: MH
 * Language: C# SDK version 2.0
 * --------------------------------------------------------------------------------
 * Change History:
 * version: 1.0    MH  12/08/09
 * Description: Initial Development
 * -------------------------------------------------------------------------------- */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanningPrep.Core.Exceptions
{
    /// <summary>
    /// 
    /// </summary>
    public class WorkflowException : PanthException
    {        
        /// <summary>
        /// Initializes a new instance of the <see cref="WorkflowException"/> class.
        /// </summary>
        public WorkflowException() {}

        /// <summary>
        /// Initializes a new instance of the <see cref="WorkflowException"/> class.
        /// </summary>
        /// <param name="className">Name of the class.</param>
        public WorkflowException(string errorMessage)
            : base(errorMessage)
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WorkflowException"/> class.
        /// </summary>
        /// <param name="className">Name of the class.</param>
        /// <param name="errorMessage">The error message.</param>
        public WorkflowException(string errorMessage, Exception innerException)
            : base(errorMessage, innerException)
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WorkflowException"/> class.
        /// </summary>
        /// <param name="className">Name of the class.</param>
        /// <param name="errorMessage">The error message.</param>
        /// <param name="innerException">The inner exception.</param>
        public WorkflowException(string errorMessage, Exception innerException,string exceptionSource)
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
