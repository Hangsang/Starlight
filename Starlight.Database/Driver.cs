using MongoDB.Driver;
using Serilog;
using Starlight.Common.Interfaces;
using System.Diagnostics;

namespace Starlight.Database
{
    public static class Driver
    {
        private static ILogger Logger { get; set; }

        public static void Start(string connection, ILogger logger)
        {
            Mongo.Client = new MongoClient(connection);
            Mongo.Database = Mongo.Client.GetDatabase("starrail");

            Logger = logger;

            InitializeRepositories();
        }

        private static void InitializeRepositories()
        {
            Logger.Information("========================== MONGODB ============================");

            var sw = new Stopwatch();
            sw.Start();

            var type = typeof(IRepository);
            var repos = AppDomain.CurrentDomain.GetAssemblies()
                                 .SelectMany(s => s.GetTypes())
                                 .Where(p => type.IsAssignableFrom(p));

            var successfullyStarted = 0;

            foreach (var t in repos)
            {
                if (t.IsInterface)
                    continue;

                var sw2 = new Stopwatch();

                sw2.Start();

                if (Activator.CreateInstance(t) is not IRepository instance)
                    continue;

                instance.Start();

                Logger.Information("Loaded {0} in {1}ms", t.Name, sw2.ElapsedMilliseconds);
                sw2.Stop();
                successfullyStarted++;
            }

            Logger.Information("Initialized {0} MongoDB Collections in {1}ms", successfullyStarted, sw.ElapsedMilliseconds);
            sw.Stop();
            Logger.Information("===============================================================");
        }
    }
}