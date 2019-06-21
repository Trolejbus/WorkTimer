using System;
using System.Drawing;
using System.Windows.Forms;

namespace WorkTimer.CustomControls
{
    public class ImageButton : PictureBox
    {
        private bool hover;

        private Image _staticImage;
        public Image StaticImage
        {
            get
            {
                return _staticImage;
            }
            set
            {
                Image = value;
                _staticImage = value;
            }
        }

        private Image _hoverImage;
        public Image HoverImage
        {
            get
            {
                return _hoverImage;
            }
            set
            {
                _hoverImage = value;
            }
        }

        private Image _downImage;
        public Image DownImage
        {
            get
            {
                return _downImage;
            }
            set
            {
                _downImage = value;
            }
        }

        public ImageButton()
        {
            MouseDown += ImageButton_MouseDown;
            MouseEnter += ImageButton_MouseEnter;
            MouseLeave += ImageButton_MouseLeave;
            MouseUp += ImageButton_MouseUp;
        }

        private void ImageButton_MouseUp(object sender, MouseEventArgs e)
        {
            if (DownImage == null || HoverImage == null)
            {
                return;
            }

            Image = hover ? HoverImage : DownImage;
        }

        private void ImageButton_MouseLeave(object sender, EventArgs e)
        {
            hover = false;
            if (HoverImage == null)
            {
                return;
            }

            Image = StaticImage;
        }

        private void ImageButton_MouseEnter(object sender, EventArgs e)
        {
            hover = true;
            if (HoverImage == null)
            {
                return;
            }

            Image = HoverImage;
        }

        private void ImageButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (DownImage == null)
            {
                return;
            }

            Image = DownImage;
        }
    }
}
