using WorkTimer.Domain.Models.Models;

namespace WorkTimer.UI.Models
{
    public class ListBoxItem<T>
    {
        public string Text { get; set; }

        public T Data { get; set; }
    }
}
