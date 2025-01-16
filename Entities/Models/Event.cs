using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Event
    {
        [Column("EventID")]
        public Guid Id { get; set; }

        public string Name { get; set; }
        public DateTime Date { get; set; }

        public ICollection<EventFirework> EventFireworks { get; set; }
    }
}
