using Autofac;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WorkTimer.Domain.Models.Enums;
using WorkTimer.Domain.Models.Models;
using WorkTimer.Interfaces.Controllers;
using WorkTimer.Interfaces.Services;
using WorkTimer.UI.Models;

namespace WorkTimer
{
    public partial class WorkTimerForm : Form
    {
        private readonly IWorkController _workController;
        private readonly ITimeService _timeService;
        private IEnumerable<WorkLogModel> logs;

        public WorkTimerForm(ILifetimeScope scope)
        {
            InitializeComponent();
            _workController = scope.Resolve<IWorkController>();
            _timeService = scope.Resolve<ITimeService>();
            RefreshLogs();
        }

        private void refreshButton_Click(object sender, System.EventArgs e)
        {
            RefreshLogs();
        }

        private void RefreshLogs()
        {
            logs = _workController.GetCurrentLogs();
            workLogListBox.Items.Clear();

            foreach (var log in logs)
            {
                var text = GetText(log);
                var span = (log.EndDate ?? _timeService.GetCurrentDate()) - log.StartDate;

                workLogListBox.Items.Add(new ListBoxItem<WorkLogModel>()
                {
                    Text = $"{text} {span:hh\\:mm\\:ss} from: {log.StartDate:hh\\:mm\\:ss} to: {log.EndDate:hh\\:mm\\:ss}",
                    Data = log,
                });
            }
        }

        private string GetText(WorkLogModel log)
        {
            switch(log.Type)
            {
                case WorkType.Unassigned:
                    return "Unassigned";
                case WorkType.Work:
                    return "Work";
                case WorkType.Break:
                    return "Break";
                default:
                    throw new Exception("No types");
            }
        }
    }
}
