using System;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using PlanningPrep.Core.Exceptions;
using PlanningPrep.Core.Properties;

namespace PlanningPrep.Core.Logging
{
    /// <summary>
    /// Wrapper for OPLM system level logging
    /// </summary>
    public class PlanningPrepLogger
    {
        /// <summary>
        /// Handles logging for general exception
        /// </summary>
        public static void HandleException(Exception ex)
        {
            ExceptionPolicy.HandleException(ex, EnterpriseLibraryResources.ExceptionPolicy_Default);
        }

        /// <summary>
        /// Handles logging for workflow exception
        /// </summary>
        public static void HandleWorkflowException(Exception ex)
        {
            if (ex.GetType() != typeof(WorkflowException) || ex.GetType().BaseType != typeof(WorkflowException))
            {
                HandleException(ex);
            }
            ExceptionPolicy.HandleException(ex, EnterpriseLibraryResources.ExceptionPolicy_Workflow);
        }

        /// <summary>
        /// Writes information event log
        /// </summary>
        public static void LogInfo(string message)
        {
            Logger.Write(message, EnterpriseLibraryResources.LoggingCategory_Info, 1, 1, System.Diagnostics.TraceEventType.Information);
        }
        /// <summary>
        /// Writes security log
        /// </summary>
        public static void LogSecurityInfo(string message)
        {
            Logger.Write(message, EnterpriseLibraryResources.LoggingCategory_Security, 5, 2, System.Diagnostics.TraceEventType.Critical);
        }
    }
}
