
using Blazored.Toast.Services;
using JENDAMARK_code_assessment.Data;
using JENDAMARK_code_assessment.Pages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public List<KeyValuePair<int, string>> GetDeviceTypes()
        {
            var DeviceTypes = Enum.GetValues(typeof(DeviceType))
                         .Cast<int>()
                         .Select(x => new KeyValuePair<int, string>(key: x, value: Enum.GetName(typeof(DeviceType), x)))
                         .ToList();
            return DeviceTypes;
        }
        //listing devices for select list
        public List<Device> GetDevices()
        {
            var DeviceList = _context.Devices.OrderBy(x => x.Name).ToList();
            return DeviceList;
        }

        //Inserting device
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
        //Getting Operations 
        public List<Data.Operations> GetOperations()
        {
            var data = _context.Operations.Include(x => x.Device).OrderBy(x => x.OrderInWhichToPerform).ToList();
            return data;
        }
        //Inserting Operations
        public bool InsertOperation(Data.Operations model)
        {
            
            try
            {

                var Operations = _context.Operations.FirstOrDefault(x => x.OperationID == model.OperationID);
                _context.Operations.Add(model);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        //Deleting
        public bool DeleteOperation(Data.Operations model)
        {
            var Operations = _context.Operations.FirstOrDefault(x => x.OperationID == model.OperationID);
            if (Operations.OperationID == model.OperationID)
            {
                _context.Operations.Remove(model);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
