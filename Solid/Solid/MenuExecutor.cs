using Serilog;

namespace Solid
{
    internal static class MenuExecutor
    {
        public static void Execute()
        {
            while (true)
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

                Log.Information("Enter option:");

                var InputOption = int.Parse(Console.ReadLine());
                Log.Information($"Input Option = {InputOption.ToString()}");

                switch (InputOption)
                {
                    case 1:
                        {
                            var rand = new Random();
                            Request req = new Request()
                            {
                                Action = Actions.AllowedActions.NewJobRequest,
                                JobName = "Task-" + rand.Next(1, 100),
                                JobParameter = "TaskParam-" + rand.Next(1, 100),
                            };

                            Helper helper = new Helper();
                            helper.PerformAction(req);

                            break;
                        }
                    case 2:
                        {
                            Log.Information("Enter request ID:");
                            Request req = new Request()
                            {
                                Action = Actions.AllowedActions.MonitorJob,
                                RequestId = int.Parse(Console.ReadLine())
                            };

                            Helper helper = new Helper();
                            helper.PerformAction(req);
                            break;
                        }

                    case 3:
                        {
                            Log.Information("Enter request ID:");
                            Request req = new Request()
                            {
                                Action = Actions.AllowedActions.GetMessage,
                                RequestId = int.Parse(Console.ReadLine())
                            };

                            Helper helper = new Helper();
                            helper.PerformAction(req);
                            break;
                        }

                    case 4:
                        {
                            var rand = new Random();
                            Request req = new Request()
                            {
                                Action = Actions.AllowedActions.All,
                                JobName = "Task-" + rand.Next(1, 100),
                                JobParameter = "TaskParam-" + rand.Next(1, 100),
                            };

                            Helper helper = new Helper();
                            helper.PerformAction(req);
                            break;
                        }

                    case 5:
                        {
                            Request req = new Request()
                            {
                                Action = Actions.AllowedActions.GetAllActiveJobs
                            };

                            Helper helper = new Helper();
                            helper.PerformAction(req);
                            break;
                        }
                    case 9:
                        {
                            return;
                        }
                }
            }
        }
    }
}