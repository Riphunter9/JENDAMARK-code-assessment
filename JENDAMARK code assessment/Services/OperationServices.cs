using JENDAMARK_code_assessment.Data;
using JENDAMARK_code_assessment.Pages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
namespace JENDAMARK_code_assessment.Services
{
    public class OperationServices
    {
        private readonly AppDbContext _context;
        public OperationServices(AppDbContext context)
        {
            _context = context;
        }

        //Getting Operations 
        public List<Data.Operations> GetOperations()
        {
            return _context.Operations.Include(x => x.Device).OrderBy(x => x.OrderInWhichToPerform).ToList();
        }
        public bool InsertOperation(Data.Operations model)
        {
            try
            {
                _context.Operations.Add(model);
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
