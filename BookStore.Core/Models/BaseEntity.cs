using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Core.Models
{
    public abstract class BaseEntity
    {
        public String ID { get; set; }
        public DateTimeOffset CreationTime { get; set; }
        public BaseEntity()
        {
            this.ID = Guid.NewGuid().ToString();
            this.CreationTime = DateTime.Now;
        }
    }
}
