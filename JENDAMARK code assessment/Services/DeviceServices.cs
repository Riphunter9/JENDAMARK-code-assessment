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
    }
}
