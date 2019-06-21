using System.ComponentModel.DataAnnotations;

namespace WorkTimer.SQLite.Entities.Base
{
    internal class Entity<TId>
    {
        [Key]
        public TId Id { get; set; }
    }
}
