using System;
using System.Windows.Forms;

namespace ServiceLifeController.Views
{
    public partial class BaseForm : Form
    {
        public BaseForm()
        {
            InitializeComponent();
            Application.Idle += LoadCompleted;
        }

        protected virtual void LoadCompleted(object sender, EventArgs e)
        {
            Application.Idle -= LoadCompleted;
        }
    }
}
