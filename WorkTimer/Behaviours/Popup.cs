using System;
using System.Windows.Forms;

namespace WorkTimer.Behaviours
{
    public class Popup
    {
        public void MakePopup(Form form, PopupPosition popupPosition)
        {
            form.Shown += Form_Shown(popupPosition);
        }

        private EventHandler Form_Shown(PopupPosition popupPosition)
        {
            return (object sender, EventArgs e) =>
            {
                switch(popupPosition)
                {
                    case PopupPosition.BottomRight:
                        ((Form)sender).Left = Screen.PrimaryScreen.WorkingArea.Location.X +
                            Screen.PrimaryScreen.WorkingArea.Width - ((Form)sender).Width + 3;
                        ((Form)sender).Top = Screen.PrimaryScreen.WorkingArea.Location.Y +
                            Screen.PrimaryScreen.WorkingArea.Height - ((Form)sender).Height;
                        break;
                    case PopupPosition.TopRight:
                        ((Form)sender).Left = Screen.PrimaryScreen.WorkingArea.Location.X +
                            Screen.PrimaryScreen.WorkingArea.Width - ((Form)sender).Width + 3;
                        ((Form)sender).Top = Screen.PrimaryScreen.WorkingArea.Location.Y + 3;
                        break;
                    case PopupPosition.TopLeft:
                        ((Form)sender).Left = Screen.PrimaryScreen.WorkingArea.Location.X + 3;
                        ((Form)sender).Top = Screen.PrimaryScreen.WorkingArea.Location.Y + 3;
                        break;
                    case PopupPosition.BottomLeft:
                        ((Form)sender).Left = Screen.PrimaryScreen.WorkingArea.Location.X + 3;
                        ((Form)sender).Top = Screen.PrimaryScreen.WorkingArea.Location.Y +
                            Screen.PrimaryScreen.WorkingArea.Height - ((Form)sender).Height;
                        break;
                    default:
                        throw new ArgumentException("Invalid Popup position.");
                }
               
            };
        }
    }

    public enum PopupPosition
    {
        TopRight,
        BottomRight,
        TopLeft,
        BottomLeft,
    }
}
