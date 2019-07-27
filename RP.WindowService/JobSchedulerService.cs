using RP.Utilities;
using Schedule;
using System;
using System.ServiceProcess;

namespace RP.WindowService
{
    public  class JobSchedulerService : ServiceBase
    {
     
        private readonly IJobManagement jobManagement;
        public JobSchedulerService()
        {
            this.jobManagement = new JobManagement();
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                System.Diagnostics.Debugger.Launch();
                ScheduleTimer Timer = new ScheduleTimer();
                Timer.Elapsed += Timer_Elapsed;
                Timer.AddEvent(new ScheduledTime("Daily", AppSettingHelper.DailyJobTime));
                Timer.Start();
            }
            catch (Exception e)
            {
            }
        }

        private void Timer_Elapsed(object sender, ScheduledEventArgs e)
        {
            this.jobManagement.StartAllJobs();
        }

        protected override void OnStop()
        {
            // TODO: Add code here to perform any tear-down necessary to stop your service.
        }
    }
}