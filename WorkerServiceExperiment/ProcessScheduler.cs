using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Coravel.Invocable;

namespace WorkerServiceExperiment
{
    public class ProcessScheduler : IInvocable
    {
        private readonly ILogger<ProcessScheduler> logger;
        public ProcessScheduler(ILogger<ProcessScheduler> logger)
        {
            this.logger = logger;
        }

        public Task Invoke()
        {
            var jobId = Guid.NewGuid();
            logger.LogInformation($"Starting job Id: {jobId}");
            return Task.CompletedTask;
            // return Task.FromResult(true);
        }
}
}
