using System;
using System.Collections.Generic;
using Models;
using SharedControllerHelper;

namespace ServiceLifeController.Views
{
    public partial class ServiceLogViewerForm : BaseForm
    {
        public ServiceLogViewerForm()
        {
            InitializeComponent();

            dtpTo.Value = DateTime.Now;
            dtpFrom.Value = dtpTo.Value.AddMonths(-1);
        }

        private void btnClearLogs_Click(object sender, EventArgs e)
        {
            WindowsEventLog.DeleteCurrentSource();
        }

        private void btnFetchLogs_Click(object sender, EventArgs e)
        {
            IEnumerable<Log> logs = null;

            if (dtpFrom.Checked)
            {
                logs = WindowsEventLog.GetEntryCollection(dtpFrom.Value, dtpTo.Checked ? dtpTo.Value : DateTime.Now, chkErrors.Checked, chkWarnings.Checked,
                    chkInformations.Checked, chkAuditSuccess.Checked, chkAuditFailure.Checked);
            }
            else if (dtpTo.Checked)
            {
                logs = WindowsEventLog.GetEntryCollection(dtpTo.Value.AddDays(-30), dtpTo.Value, chkErrors.Checked, chkWarnings.Checked,
                    chkInformations.Checked, chkAuditSuccess.Checked, chkAuditFailure.Checked);
            }
            else
            {
                logs = WindowsEventLog.GetEntryCollection(chkErrors.Checked, chkWarnings.Checked,
                    chkInformations.Checked, chkAuditSuccess.Checked, chkAuditFailure.Checked);
            }

            if (logs != null)
            {
                dgvLogs.DataSource = logs.ToDataTable();
            }
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFrom.Value >= dtpTo.Value)
            {
                dtpTo.Value = dtpFrom.Value.AddDays(1);
            }
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFrom.Value >= dtpTo.Value)
            {
                dtpFrom.Value = dtpTo.Value.AddDays(-1);
            }
        }
    }
}
