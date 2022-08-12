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
            var DeviceList =  _context.Devices.OrderBy(x => x.Name).ToList();
            return DeviceList;
        }
        //Inserting device
        public bool InsertDevices(Device model)
        {
            try
            {
                var Device = _context.Devices.Where(x=>x.DeviceID == model.DeviceID).FirstOrDefault();
                if (Device!=null)
                {
                    Device.Name = model.Name;
                    Device.DeviceID = model.DeviceID;
                    Device.DeviceType = model.DeviceType;
                    _context.Devices.Update(model);
                }
                else
                {
                    _context.Devices.Add(model);
                }
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
            return _context.Operations.Include(x => x.Device).OrderBy(x => x.OrderInWhichToPerform).ToList();
        }
        //Inserting Operations
        public bool InsertOperation(Data.Operations model)
        {
            try
            {
                var Operations = _context.Operations.FirstOrDefault(x => x.OperationID == model.OperationID);
                if (Operations.OperationID != 0)
                {
                    Operations.Name = model.Name;
                    Operations.DeviceID = model.DeviceID;
                    Operations.ImageData = model.ImageData;
                    Operations.OrderInWhichToPerform = model.OrderInWhichToPerform;
                    _context.Operations.Update(model);
                }
                else
                {
                    _context.Operations.Add(model);
                }
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        //updating 
        public Data.Operations UpdateOperation(int operationID)
        {
            Operations operations = new Data.Operations();
            return _context.Operations.FirstOrDefault(x => x.OperationID == operationID);
        }
        //Deleting
    }
}
