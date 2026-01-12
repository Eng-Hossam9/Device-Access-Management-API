using Domain.Entities;
using Infrastructure.Persistence_Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Devices
{
    public class DeviceRepository : IRepositoryEntityBase<Guid, Domain.Entities.Devices>
    {
        private readonly AppDbContext _context;

        public DeviceRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Domain.Entities.Devices device)
        {
            _context.Devices.Add(device);
        }



        public Task DeleteAsync(Guid id)
        {
            var data =  _context.Devices.FirstOrDefaultAsync(d => d.Id == id);
            if (data != null) 
            {
                _context.Remove(data);
            }
            return Task.CompletedTask;
        }

        public async Task<Domain.Entities.Devices?> GetByIdAsync(Guid id)
        {
            return await _context.Devices.FirstOrDefaultAsync(d => d.Id == id);
        }

        public Task UpdateAsync(Domain.Entities.Devices device)
        {
            var data = _context.Devices.FirstOrDefaultAsync(d => d.Id == device.Id);
            if(data!=null)
            _context.Devices.Update(device);
            return Task.CompletedTask;



        }


    }
}