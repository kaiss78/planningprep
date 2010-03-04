using System;

namespace PlanningPrep.Core
{
        public class TimedTraceLog : IDisposable
    {
        private readonly string _message;

        private readonly long _startTicks;

        public TimedTraceLog(string objectName, string message)
        {
            _message = string.Format("{0}:{1}{2}", objectName, '\t', message);
            _startTicks = DateTime.Now.Ticks;
        }
        #region IDisposable Members

        void IDisposable.Dispose()
        {
            string msg = string.Format("{0}{1}{2}", _message, '\t', TimeSpan.FromTicks(DateTime.Now.Ticks - _startTicks).TotalSeconds);

#if DEBUG 
            System.Diagnostics.Debug.WriteLine(msg); 
#endif

        }

        #endregion
    }
}
