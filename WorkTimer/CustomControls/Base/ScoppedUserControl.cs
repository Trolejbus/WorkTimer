using Autofac;
using System.Windows.Forms;

namespace WorkTimer.CustomControls.Base
{
    public class ScoppedUserControl: UserControl
    {
        public void SetScope(ILifetimeScope scope)
        {
            OnScopedSet(scope);
        }

        protected virtual void OnScopedSet(ILifetimeScope scope)
        {

        }
    }
}
