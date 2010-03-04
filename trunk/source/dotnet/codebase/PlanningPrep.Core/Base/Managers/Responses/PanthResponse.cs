﻿using System.Collections.Generic;
using PlanningPrep.Core.RuleEngine;

namespace PlanningPrep.Core.Base.Managers.Responses
{
    public abstract class PanthResponse
    {
        public bool Result { get; set; }
        public string Exception { get; set; }
        public long ExceptionCode { get; set; }
        public IList<ValidationError> Errors { get; set; }
    }
}