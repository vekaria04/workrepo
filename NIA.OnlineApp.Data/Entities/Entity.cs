using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIA.OnlineApp.Data.Entities
{
    public class Entity
    {
        public int Id { get; set; }
        public string Value { get; set; } = string.Empty; // varchar(5000)
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
