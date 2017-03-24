using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirQualityAPI.Models;

namespace AirQualityAPI.Repository
{
    public class MercuriesRepository : IMercuriesRepository
    {
        private static List<Mercury> _mercuriesList = new List<Mercury>();

        public void Add(Mercury mercuryEntry)
        {
            _mercuriesList.Add(mercuryEntry);
        }

        public IEnumerable<Mercury> GetAll()
        {
            return _mercuriesList;
        }

        public Mercury Find(string id)
        {
            int matchingId = int.Parse(id);
            return _mercuriesList.SingleOrDefault(m => m.Mercury_Id == matchingId);
        }

        public void Remove(string id)
        {
            int matchingId = int.Parse(id);
            var itemToRemove = _mercuriesList.FirstOrDefault(m => m.Mercury_Id == matchingId);
            if (itemToRemove != null)
                _mercuriesList.Remove(itemToRemove);
        }

        public void Update(Mercury mercuryEntry)
        {
            var itemToUpdate = _mercuriesList.FirstOrDefault(m => m.Mercury_Id == mercuryEntry.Mercury_Id);
            if (itemToUpdate != null)
            {
                itemToUpdate.Mercury_Id = mercuryEntry.Mercury_Id;
                itemToUpdate.DateTimeStart = mercuryEntry.DateTimeStart;
                itemToUpdate.Hg = mercuryEntry.Hg;
                itemToUpdate.Unit = mercuryEntry.Unit;
            }
        }
    }
}
