using Photos.Domain.DataBaseEntity.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Photos.Domain.DataBaseEntity
{
    public class TestEntity : IEntity
    {
        public int Id { get; set; }
        public String Test { get; set; }
        public byte[] QR { get; set; }
    }
}
