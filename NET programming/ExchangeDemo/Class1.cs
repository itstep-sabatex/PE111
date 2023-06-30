using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeDemo
{
    public class ObjectExchange 
    {
        public long Id { get; set; }
        public Guid Sender { get; set; }
        public Guid Destination { get; set; }
        [Required]
        [MaxLength(50)]
        public string ObjectId { get; set; } = default!;
        [MaxLength(50)]
        public string ObjectType { get; set; } = default!;
        /// <summary>
        /// внутрішня позначка часу створення обєкта
        /// </summary>
        public DateTime DateStamp { get; set; } = DateTime.UtcNow;
        public DateTime? SenderDateStamp { get; set; }
        public string ObjectAsText { get; set; } = default!;
        //string IEntityBase.KeyAsString() => Id.ToString();
    }
}
