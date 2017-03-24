using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirQualityAPI.Contexts;
using AirQualityAPI.Models;

namespace AirQualityAPI.Repository
{
    public class OzonesRepository : IOzonesRepository
    {
        //private static List<Ozone> _ozonesList = new List<Ozone>();

        private OzonesContext _context;

        public OzonesRepository(OzonesContext context)
        {
            _context = context;
        }

        public void Add(Ozone ozoneEntry)
        {
            //_ozonesList.Add(ozoneEntry);
            _context.Ozone.Add(ozoneEntry);
            _context.SaveChanges();
        }

        public IEnumerable<Ozone> GetAll()
        {
            //return _ozonesList;
            return _context.Ozone.ToList();
        }

        public Ozone Find(string id)
        {
            int matchingId = int.Parse(id);
            //return _ozonesList.SingleOrDefault(o => o.Ozone_Id == matchingId);
            return _context.Ozone.SingleOrDefault(o => o.Ozone_Id == matchingId);
        }

        public void Remove(string id)
        {
            int matchingId = int.Parse(id);
            //var itemToRemove = _ozonesList.FirstOrDefault(o => o.Ozone_Id == matchingId);
            //if (itemToRemove != null)
            //    _ozonesList.Remove(itemToRemove);
            var itemToRemove = _context.Ozone.FirstOrDefault(o => o.Ozone_Id == matchingId);
            if (itemToRemove != null)
                _context.Ozone.Remove(itemToRemove);
            _context.SaveChanges();
        }

        public void Update(Ozone ozoneEntry)
        {
            //var itemToUpdate = _ozonesList.FirstOrDefault(o => o.Ozone_Id == ozoneEntry.Ozone_Id);
            //if (itemToUpdate != null)
            //{
            //    itemToUpdate.Ozone_Id = ozoneEntry.Ozone_Id;
            //    itemToUpdate.DateTimeStart = ozoneEntry.DateTimeStart;
            //    itemToUpdate.Ozone1 = ozoneEntry.Ozone1;
            //    itemToUpdate.Unit = ozoneEntry.Unit;
            //}

            var itemToUpdate = _context.Ozone.FirstOrDefault(o => o.Ozone_Id == ozoneEntry.Ozone_Id);
            if (itemToUpdate != null)
            {
                itemToUpdate.Ozone_Id = ozoneEntry.Ozone_Id;
                itemToUpdate.DateTimeStart = ozoneEntry.DateTimeStart;
                itemToUpdate.Ozone1 = ozoneEntry.Ozone1;
                itemToUpdate.Unit = ozoneEntry.Unit;
            }
            _context.SaveChanges();
        }
    }
}
