using Autofac;
using System.Windows.Forms;

namespace WorkTimer
{
    public partial class WorkTimer : Form
    {
        public WorkTimer(ILifetimeScope scope)
        {
            InitializeComponent();
        }
    }
}
