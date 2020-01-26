namespace DisposableTimerLog
{
    using System;

    /// <summary>
    ///
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public interface ITimerLog : IDisposable
    {
        /// <summary>
        /// Starts this instance.
        /// </summary>
        /// <returns></returns>
        public ITimerLogAction Start();
    }
}