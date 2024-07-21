using Serilog;
using Solid.Menu_Executions;
using Microsoft.Extensions.DependencyInjection;
using Solid.AMTSimulation.Interface;
using Solid.AMTSimulation;
using Solid.AmtActions;
using Solid.Requests;
using Solid.AmtActions.interfaces;
using Serilog.Core;

namespace Solid
{
    internal class MenuExecutor : IMenu
    {
        //private IDictionary<int, int> _dict;
        //public MenuExecutor(IDictionary<int, int> dict)
        //{
        //    _dict = dict;
        //}
        public Guid newGuid { get; set; }
        public ILogger _log { get; set; }
        public IComscript _comscript { get; set; }
        public MenuExecutor(ILogger log, IComscript comscript)
        {
            newGuid = Guid.NewGuid();
            _log = log;
            _comscript = comscript;
        }

        public void DisplayMenu()
        {
            _log.Information("");
            _log.Information("========================");
            _log.Information($"-------- Menu ---------- {newGuid}");
            _log.Information("========================");
            _log.Information("1 - Create new Job request");
            _log.Information("2 - Monitor Job");
            _log.Information("3 - Get message");
            _log.Information("4 - All");
            _log.Information("5 - Find All active jobs");
            _log.Information("9 - Exit");
            _log.Information("");
        }

        public int GetUserInput()
        {
            _log.Information("Enter option:");
            return int.Parse(Console.ReadLine());
        }

        private void ExecuteDependencyInjection<TRequest, TAction>()
            where TRequest : class, IRequest
            where TAction : class, IAction
        {
            var serviceProvider = new ServiceCollection()
                                          .AddScoped<ILogger, Logger>(x => (Logger)_log)
                                          .AddScoped<IComscript, Comscript>(x=> (Comscript)_comscript)
                                          .AddScoped<IRequest, TRequest>()
                                          .AddScoped<IAction, TAction>()
                                          .BuildServiceProvider();

            var service = serviceProvider.GetRequiredService<IAction>();
            service.PerformAction();
        }
        public bool Execute()
        {
            DisplayMenu();
            var InputOption = GetUserInput();

            _log.Information($"Input Option = {InputOption}");

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
                    return false;
            }
            return true;
        }
    }
}
