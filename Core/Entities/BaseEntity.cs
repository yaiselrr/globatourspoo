using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class BaseEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool State { get; set; }
        public string UserCreatorId { get; set; }
        public string UserModifierId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public BaseEntity()
        {
            this.State = true;
            this.UserCreatorId = "Yaisel";
            this.UserModifierId = "Yaisel";
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = DateTime.Now;
        }


    }
}