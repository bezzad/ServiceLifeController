using System;
using System.Data;
using System.Windows.Forms;

namespace ServiceLifeController.Views
{
    public class BaseForm : System.Windows.Forms.Form, IDisposable
    {
        protected DataTable SourceTable;
        protected readonly object SyncObj = new object();

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            Application.Idle += OnLoaded;
        }

        protected virtual void OnLoaded(object sender, EventArgs e)
        {
            Application.Idle -= OnLoaded;
            if (Program.IsAdmin())
            {
                this.Text += "  (Run as Admin)";
            }
        }


        ~BaseForm()
        {
            Dispose();
        }

        // Public implementation of Dispose pattern callable by consumers.
        public new void Dispose()
        {
            if (IsDisposed)
                return;

            // Dispose of unmanaged resources.
            Dispose(true);
            // Suppress finalization.
            GC.SuppressFinalize(this);
            GC.Collect();

            base.Dispose();
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Dispose stuff here
                if (SourceTable != null)
                {
                    SourceTable.Dispose();
                }
            }

            base.Dispose(disposing);
        }
    }
}
