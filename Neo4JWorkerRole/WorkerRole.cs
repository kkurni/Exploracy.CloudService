using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Diagnostics;
using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.WindowsAzure.StorageClient;
using Neo4j.Server.AzureWorkerHost;

namespace Neo4JWorkerRole
{
    public class WorkerRole : RoleEntryPoint
    {
        private NeoServer _Server;
        public override void Run()
        {
            // This is a sample worker implementation. Replace with your logic.
            Trace.WriteLine("Neo4JWorkerRole entry point called", "Information");

            while (true)
            {
                Thread.Sleep(10000);
                Trace.WriteLine("Working", "Information");
            }
        }

        public override bool OnStart()
        {
            // Set the maximum number of concurrent connections 
            ServicePointManager.DefaultConnectionLimit = 12;

            // For information on handling configuration changes
            // see the MSDN topic at http://go.microsoft.com/fwlink/?LinkId=166357.

            _Server = new NeoServer(CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("Neo4jConnectionString")));
            //_Server = new NeoServer(CloudStorageAccount.DevelopmentStorageAccount);
            _Server.DownloadAndInstall();
            _Server.Start();

            return base.OnStart();
        }

        public override void OnStop()
        {
            _Server.Stop();
            base.OnStop();
        }
    }
}
