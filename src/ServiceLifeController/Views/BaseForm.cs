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

            var version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(3);
            var admin = Program.IsAdmin() ? "(Run as Admin)" : "";

            Text = $"{Text} ver{version}  {admin}";

            Application.Idle += OnLoaded;
        }

        protected virtual void OnLoaded(object sender, EventArgs e)
        {
            Application.Idle -= OnLoaded;
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

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // BaseForm
            // 
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Name = "BaseForm";
            this.ResumeLayout(false);

        }
    }
}
