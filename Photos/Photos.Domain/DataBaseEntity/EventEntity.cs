using Photos.Domain.DataBaseEntity.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Photos.Domain.DataBaseEntity
{
    public class EventEntity : IEntity
    {
        public int Id { get; set; }
        public string NameEvent { get; set; }
        public DateTime DateEvent { get; set; }
        public string DescriptionEvent { get; set; }

    }
}
