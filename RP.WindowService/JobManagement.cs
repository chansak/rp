using System;

namespace RP.WindowService
{
    public interface IJobManagement
    {
        void StartAllJobs();
    }
    public  class JobManagement :IJobManagement
    {
        public JobManagement()
        {
        }

        public void StartAllJobs()
        {
            var currentDate = DateTime.Now;
            IJob dailyJob = new DailyJob();
            dailyJob.Start();
        }
    }
}