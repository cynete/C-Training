using Serilog;
using Solid.Menu_Executions;
using Microsoft.Extensions.DependencyInjection;
using Solid.AMTSimulation.Interface;
using Solid.AMTSimulation;
using Solid.AmtActions;
using Solid.Requests;
using Solid.AmtActions.interfaces;

namespace Solid
{
    internal class MenuExecutor : IMenu
    {
        public void DisplayMenu()
        {
            Log.Information("");
            Log.Information("========================");
            Log.Information("-------- Menu ----------");
            Log.Information("========================");
            Log.Information("1 - Create new Job request");
            Log.Information("2 - Monitor Job");
            Log.Information("3 - Get message");
            Log.Information("4 - All");
            Log.Information("5 - Find All active jobs");
            Log.Information("9 - Exit");
            Log.Information("");
        }

        public int GetUserInput()
        {
            Log.Information("Enter option:");
            return int.Parse(Console.ReadLine());
        }

        private void ExecuteDependencyInjection<TRequest, TAction>()
            where TRequest : class, IRequest
            where TAction : class, IAction
        {
            var serviceProvider = new ServiceCollection()
                                          .AddScoped<IComscript, Comscript>()
                                          .AddScoped<IRequest, TRequest>()
                                          .AddScoped<IAction, TAction>()
                                          .BuildServiceProvider();

            var service = serviceProvider.GetRequiredService<IAction>();
            service.PerformAction();
        }
        public void Execute()
        {
            while (true)
            {
                DisplayMenu();
                var InputOption = GetUserInput();

                Log.Information($"Input Option = {InputOption}");

                switch (InputOption)
                {
                    case 1:
                        ExecuteDependencyInjection<NewJobRequest, ActionNewJob>();
                        break;
                    case 2:
                        ExecuteDependencyInjection<MonitorJobRequest, ActionMonitorJob>();
                        break;
                    case 3:
                        ExecuteDependencyInjection<GetMessageRequest, ActionGetMessage>();
                        break;
                    case 4:
                        ExecuteDependencyInjection<AllRequest, ActionAll>();
                        break;
                    case 5:
                        ExecuteDependencyInjection<AllActiveJobsRequest, ActionAllActiveJobs>();
                        break;
                    case 9:
                        break;
                }
            }
        }
    }
}
