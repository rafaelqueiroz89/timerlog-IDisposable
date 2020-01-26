//-----------------------------------------------------------------------
// <copyright file="ITimerLogAction.cs" company="CofcoIntl, Lda">
//     Copyright (c) CofcoIntl, Lda. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace DisposableTimerLog
{
    using System;

    /// <summary>
    /// <see cref="ITimerLogAction"/>
    /// </summary>
    public interface ITimerLogAction : IDisposable
    {
        /// <summary>
        /// Called when [action].
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns></returns>
        ITimerLogWrite OnAction(string action);
    }
}