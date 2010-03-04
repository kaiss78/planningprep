using System;
using System.Collections.Generic;
using System.Linq;
using PlanningPrep.Core.Extensions;

namespace PlanningPrep.Models.Strategy
{
    /// <summary>
    /// Used as an attribute for describing properties of a strategy object that should 
    /// be pushed out to the user interface
    /// </summary>
    [AttributeUsage(  AttributeTargets.Property, AllowMultiple=false )]
    public class StrategyObjectFieldAttribute : Attribute 
    {
        #region Constructors

        public StrategyObjectFieldAttribute()
        {
            EntityReference = null;
            IsRequired = true;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Label to use, if any 
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Field display type
        /// </summary>
        public string DisplayType { get; set; }

        /// <summary>
        /// The data type
        /// </summary>
        public string DataType { get; set; }

        /// <summary>
        /// Default value
        /// </summary>
        public string DefaultValue { get; set; }

        /// <summary>
        /// Whether or not the field is required
        /// </summary>
        public bool IsRequired { get; set; }

        /// <summary>
        /// If there's an entity reference
        /// </summary>
        public string EntityReference { get; set; }

        /// <summary>
        /// Means to ignore this field
        /// </summary>
        public bool Ignore { get; set; }

        /// <summary>
        /// The acceptable values
        /// </summary>
        /// <remarks>
        /// This is a string of the format AcceptableValues="Text1;Value1|Text2;Value2" etc.
        /// Not that items are separated by the "|" character which name/value pairs are separated using the ";" character
        /// </remarks>
        public string AcceptableValues { get; set; }

        #endregion

        /// <summary>
        /// Returns a list of entries derived from the <see cref="AcceptableValues"/>
        /// </summary>
        /// <returns></returns>
        public IDictionary<string, object> GetPickListEntries()
        {
            if (AcceptableValues.IsNullOrEmpty())
            {
                return new Dictionary<string, object>();
            }

            string rowSeparator = ";";

            Dictionary<string, object> entries = new Dictionary<string, object>();
            string[] tmpAr = AcceptableValues.Split(new[] {'|'});
            foreach (string s in tmpAr.Where(s => !s.IsNullOrEmpty()))
            {
                string text, value;
                if (s.Contains(rowSeparator))
                {
                    text = s.SubStrBefore(rowSeparator);
                    value = s.SubStrAfter(rowSeparator);
                }
                else
                {
                    text = value = s;
                }

                entries.Add(text, value);
            }
            return entries;
        }
    }
}


