using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Devices: DBClass<Guid>
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public bool IsActive { get; private set; }

        public Devices(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            IsActive = true;
        }
        public void Deactivate()
        {
            IsActive = false;
        }
    }

}
