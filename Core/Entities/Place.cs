using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Place : BaseEntity
    {
        public Place(string Name)
        {
            this.Name = Name;
        }
    }
}