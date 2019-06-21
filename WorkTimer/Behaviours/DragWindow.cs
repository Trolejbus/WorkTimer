using System.Drawing;
using System.Windows.Forms;

namespace WorkTimer.Behaviours
{
    internal class DragWindow
    {
        private Control _controller;

        public bool DragVertical { get; set; }
        public bool DragHorizontal { get; set; }

        public bool FitToParentDimensions { get; set; }
        public Point FitToParentDimensionsDelayMin { get; set; }
        public Point FitToParentDimensionsDelayMax { get; set; }

        Point dragOffset;

        public DragWindow()
        {
            DragVertical = true;
            DragHorizontal = true;
            FitToParentDimensions = false;
        }

        public Control DraggableControl { get; set; }

        public Control Controller
        {
            get
            {
                return _controller;
            }
            set
            {
                if (_controller != null)
                {
                    _controller.MouseDown -= _controller_MouseDown;
                    _controller.MouseMove -= _controller_MouseMove;
                }

                _controller = value;

                _controller.MouseDown += _controller_MouseDown;
                _controller.MouseMove += _controller_MouseMove;
            }
        }

        private void _controller_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point newLocation = ((Control)sender).PointToScreen(e.Location);

                if (DragVertical)
                {
                    newLocation.Y -= dragOffset.Y;
                }
                else
                {
                    newLocation.Y = DraggableControl.Top;
                }

                if (DragHorizontal)
                {
                    newLocation.X -= dragOffset.X;
                }
                else
                {
                    newLocation.X = DraggableControl.Left;
                }

                if (FitToParentDimensions)
                {
                    int maxX = Screen.PrimaryScreen.Bounds.Width - DraggableControl.Width + FitToParentDimensionsDelayMax.X;
                    int maxY = Screen.PrimaryScreen.Bounds.Height - DraggableControl.Height + FitToParentDimensionsDelayMax.Y;
                    int minX = -FitToParentDimensionsDelayMin.X;
                    int minY = -FitToParentDimensionsDelayMin.Y;

                    if (DragHorizontal)
                    {
                        if (newLocation.X < -FitToParentDimensionsDelayMin.X)
                        {
                            newLocation.X = -FitToParentDimensionsDelayMin.X;
                        }
                        else if (newLocation.X > maxX)
                        {
                            newLocation.X = maxX;
                        }
                    }

                    if (DragVertical)
                    {
                        if (newLocation.Y < minY)
                        {
                            newLocation.Y = minY;
                        }
                        else if (newLocation.Y > maxY)
                        {
                            newLocation.Y = maxY;
                        }
                    }
                }

                DraggableControl.Location = newLocation;
            }
        }

        protected void _controller_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dragOffset = ((Control)sender).PointToScreen(e.Location);

                var formLocation = DraggableControl.Location;
                dragOffset.X -= formLocation.X;
                dragOffset.Y -= formLocation.Y;
            }
        }
    }
}
