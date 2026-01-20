using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Devices: DBClass<Guid>
    {
        public string Name { get;  set; }
        public bool IsActive { get;  set; }

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
        public Devices(string name,Guid deviceid)
        {
            Id = deviceid;
            Name = name;
            IsActive = true;
        }
    }

}
