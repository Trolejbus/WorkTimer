using System;
using System.Windows.Forms;

namespace WorkTimer.Behaviours
{
    public class Popup
    {
        public void MakePopup(Form form)
        {
            form.Shown += Form_Shown;
        }

        private void Form_Shown(object sender, EventArgs e)
        {
            ((Form)sender).Left = Screen.PrimaryScreen.WorkingArea.Location.X +
                Screen.PrimaryScreen.WorkingArea.Width - ((Form)sender).Width + 3;
            ((Form)sender).Top = Screen.PrimaryScreen.WorkingArea.Location.Y +
                Screen.PrimaryScreen.WorkingArea.Height - ((Form)sender).Height;
        }
    }
}
