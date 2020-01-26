//-----------------------------------------------------------------------
// <copyright file="ITimerLogWrite.cs" company="CofcoIntl, Lda">
//     Copyright (c) CofcoIntl, Lda. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;

namespace DisposableTimerLog
{
    /// <summary>
    /// <see cref="ITimerLogWrite"/>
    /// </summary>
    public interface ITimerLogWrite : IDisposable
    {
        /// <summary>
        /// Converts to file.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        void ToFile(string filePath);

        /// <summary>
        /// Converts to console.
        /// </summary>
        void ToConsole();
    }
}