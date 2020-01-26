namespace DisposableTimerLog
{
    using System.Threading;

    using Microsoft.Extensions.DependencyInjection;

    using Serilog;

    internal class Program
    {
        private static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel
                .Debug()
                .WriteTo
                .ColoredConsole()
                .CreateLogger();

            //setup our DI, AddTransient() because we need one different instance per using statement
            var serviceProvider = new ServiceCollection()
                                .AddTransient<ITimerLog, TimerLog>()
                                .BuildServiceProvider();

            var transientTimerLog = serviceProvider.GetService<ITimerLog>();

            using (transientTimerLog.Start().OnAction("asdgyagdyagsydgady"))
            {
                Thread.Sleep(150);
            }

            using (transientTimerLog.Start().OnAction("asfasf"))
            {
                Thread.Sleep(250);
            }
        }
    }
}