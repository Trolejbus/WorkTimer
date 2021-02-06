using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WorkTimer.CustomControls.Base
{
    public partial class ScoppedForm : Form
    {
        protected ILifetimeScope Scope { get; private set; }

        public ScoppedForm()
        {
            InitializeComponent();
        }

        public void SetScope(ILifetimeScope scope)
        {
            Scope = scope;
            OnScopedSet(scope);
            SetChildScope(scope);
        }


        protected virtual void OnScopedSet(ILifetimeScope scope)
        {

        }

        private void SetChildScope(ILifetimeScope scope)
        {
            var scoppedControls = GetAll(this);
            foreach (var control in scoppedControls)
            {
                control.SetScope(scope);
            }
            
        }

        private IEnumerable<ScoppedUserControl> GetAll(Control control)
        {
            var controls = control.Controls.Cast<Control>();
            return controls.SelectMany(ctrl => GetAll(ctrl))
                .Concat(controls)
                .Where(c => c is ScoppedUserControl)
                .Cast<ScoppedUserControl>();
        }
    }
}
