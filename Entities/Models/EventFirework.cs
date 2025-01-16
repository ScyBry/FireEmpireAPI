using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class EventFirework
    {
        [ForeignKey(nameof(Event))]
        public Guid EventId { get; set; }
        public Event Event { get; set; }

        [ForeignKey(nameof(Firework))]
        public Guid FireworkId { get; set; }
        public Firework Firework { get; set; }

        public int QuantityUsed { get; set; } // Количество использованных фейерверков на событии
    }
}
