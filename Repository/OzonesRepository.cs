using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirQualityAPI.Models;

namespace AirQualityAPI.Repository
{
    public class OzonesRepository : IOzonesRepository
    {
        private static List<Ozone> _ozonesList = new List<Ozone>();
        public void Add(Ozone ozoneEntry)
        {
            _ozonesList.Add(ozoneEntry);
        }

        public IEnumerable<Ozone> GetAll()
        {
            return _ozonesList;
        }

        public Ozone Find(string id)
        {
            int matchingId = int.Parse(id);
            return _ozonesList.SingleOrDefault(o => o.Ozone_Id == matchingId);
        }

        public void Remove(string id)
        {
            int matchingId = int.Parse(id);
            var itemToRemove = _ozonesList.FirstOrDefault(o => o.Ozone_Id == matchingId);
            if (itemToRemove != null)
                _ozonesList.Remove(itemToRemove);
        }

        public void Update(Ozone ozoneEntry)
        {
            var itemToUpdate = _ozonesList.FirstOrDefault(o => o.Ozone_Id == ozoneEntry.Ozone_Id);
            if (itemToUpdate != null)
            {
                itemToUpdate.Ozone_Id = ozoneEntry.Ozone_Id;
                itemToUpdate.DateTimeStart = ozoneEntry.DateTimeStart;
                itemToUpdate.Ozone1 = ozoneEntry.Ozone1;
                itemToUpdate.Unit = ozoneEntry.Unit;
            }
        }
    }
}
