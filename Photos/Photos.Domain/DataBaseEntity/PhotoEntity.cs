using Photos.Domain.DataBaseEntity.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Photos.Domain.DataBaseEntity
{
    public class PhotoEntity : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
