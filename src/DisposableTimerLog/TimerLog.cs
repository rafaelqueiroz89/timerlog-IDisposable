namespace DisposableTimerLog
{
    using System;
    using System.Diagnostics;

    using Serilog;

    /// <summary>
    ///
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public class TimerLog : ITimerLog, ITimerLogAction, ITimerLogWrite
    {
        private Stopwatch stopwatch;
        private string action;

        /// <summary>
        /// Starts this instance.
        /// </summary>
        /// <returns></returns>
        public ITimerLogAction Start()
        {
            this.stopwatch = Stopwatch.StartNew();
            this.stopwatch.Start();
            return this;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
            Log.Debug("-----------+++ ------------------- +++-----------");

            this.stopwatch.Stop();
            Log.Debug($"Process {this.action} end in {this.stopwatch.ElapsedMilliseconds} ms");

            Log.Debug("-----------+++ ------------------- +++-----------");
        }

        /// <summary>
        /// Froms the action.
        /// </summary>
        /// <param name="action">The action.</param>
        public ITimerLogWrite OnAction(string action)
        {
            this.action = action;
            return this;
        }

        /// <summary>
        /// Converts to console.
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void ToConsole()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Converts to file.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <exception cref="NotImplementedException"></exception>
        public void ToFile(string filePath)
        {
            throw new NotImplementedException();
        }
    }
}