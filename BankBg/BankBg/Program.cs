﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;
using Quartz.Impl;
namespace BankBg
{
    class Program
    {
        static void Main(string[] args)
        {
<<<<<<< HEAD
            Console.WriteLine("ok");
=======
>>>>>>> 605129af0c813d30655fc48ab56ddbcb512b5d08
            var f = new StdSchedulerFactory();
            var s = f.GetScheduler();
            s.Start();
            var j = JobBuilder.Create<ManageDB>().Build();
            var t = TriggerBuilder.Create().WithSimpleSchedule(x => x.WithIntervalInHours(1).RepeatForever()).Build();
            s.ScheduleJob(j, t);
<<<<<<< HEAD
            
=======
>>>>>>> 605129af0c813d30655fc48ab56ddbcb512b5d08
        }
    }
}
