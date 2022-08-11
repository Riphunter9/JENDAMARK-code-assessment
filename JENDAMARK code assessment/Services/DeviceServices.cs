using JENDAMARK_code_assessment.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JENDAMARK_code_assessment.Services
{
    public class DeviceServices
    {
        private readonly AppDbContext _context;
        public DeviceServices(AppDbContext context)
        {
            _context = context;
        }
        public List<Device> GetDevices()
        {
            return _context.Devices.OrderBy(x => x.Name).ToList();
        }
        public bool InsertDevices(Device model)
        {
            try
            {
                _context.Devices.Add(model);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
    }
}
