﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3053
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PlanningPrep.Core.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class EnterpriseLibraryResources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal EnterpriseLibraryResources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("PlanningPrep.Core.Properties.EnterpriseLibraryResources", typeof(EnterpriseLibraryResources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to defaultexceptionpolicy.
        /// </summary>
        public static string ExceptionPolicy_Default {
            get {
                return ResourceManager.GetString("ExceptionPolicy_Default", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to workflowexceptionpolicy.
        /// </summary>
        public static string ExceptionPolicy_Workflow {
            get {
                return ResourceManager.GetString("ExceptionPolicy_Workflow", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to logcategoryinformation.
        /// </summary>
        public static string LoggingCategory_Info {
            get {
                return ResourceManager.GetString("LoggingCategory_Info", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to logcategorysecurity.
        /// </summary>
        public static string LoggingCategory_Security {
            get {
                return ResourceManager.GetString("LoggingCategory_Security", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to logcategoryworkflow.
        /// </summary>
        public static string LoggingCategory_Workflow {
            get {
                return ResourceManager.GetString("LoggingCategory_Workflow", resourceCulture);
            }
        }
    }
}