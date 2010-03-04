﻿using PlanningPrep.Data;

namespace PlanningPrep.Domain
{
    public sealed class DomainInitializer
    {
        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public void Initialize()
        {
            // Initial the data access layer (DAL)
            DAOFactory.Initialize();
        }
    }
}
