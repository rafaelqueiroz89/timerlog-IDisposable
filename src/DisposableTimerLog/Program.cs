namespace DisposableTimerLog
{
    using System.Threading;

    using Microsoft.Extensions.DependencyInjection;

    using Serilog;

    internal static class Program
    {
        private static void Main()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo
                .ColoredConsole()
                .CreateLogger();

            //setup our DI, AddTransient() because we need one different instance per using statement
            var serviceProvider = new ServiceCollection()
                                .AddTransient<ITimerLog, TimerLog>()
                                .BuildServiceProvider();

            var transientTimerLog = serviceProvider.GetService<ITimerLog>();
            transientTimerLog.Start().OnAction("First call");//Forces a first call to ensure that JIT has done its job
            transientTimerLog.Dispose();

            using (transientTimerLog.Start().OnAction("Teste1"))
            {
                Thread.Sleep(250);
            }

            using (transientTimerLog.Start().OnAction("Teste2"))
            {
                Thread.Sleep(150);
            }
        }
    }
}