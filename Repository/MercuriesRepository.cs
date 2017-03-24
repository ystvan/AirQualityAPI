using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirQualityAPI.Contexts;
using AirQualityAPI.Models;

namespace AirQualityAPI.Repository
{
    public class MercuriesRepository : IMercuriesRepository
    {
        //private static List<Mercury> _mercuriesList = new List<Mercury>();


        private MercuriesContext _context;

        public MercuriesRepository(MercuriesContext context)
        {
            _context = context;
        }

        public void Add(Mercury mercuryEntry)
        {
            //_mercuriesList.Add(mercuryEntry);
            _context.Mercury.Add(mercuryEntry);
            _context.SaveChanges();
        }

        public IEnumerable<Mercury> GetAll()
        {
            //return _mercuriesList;
            return _context.Mercury.ToList();
        }

        public Mercury Find(string id)
        {
            int matchingId = int.Parse(id);
            //return _mercuriesList.SingleOrDefault(m => m.Mercury_Id == matchingId);
            return _context.Mercury.SingleOrDefault(m => m.Mercury_Id == matchingId);
        }

        public void Remove(string id)
        {
            int matchingId = int.Parse(id);
            //var itemToRemove = _mercuriesList.FirstOrDefault(m => m.Mercury_Id == matchingId);
            //if (itemToRemove != null)
            //    _mercuriesList.Remove(itemToRemove);
            var itemToRemove = _context.Mercury.SingleOrDefault(m => m.Mercury_Id == matchingId);
            if (itemToRemove != null)
            {
                _context.Mercury.Remove(itemToRemove);
            }
            _context.SaveChanges();
        }

        public void Update(Mercury mercuryEntry)
        {
            //var itemToUpdate = _mercuriesList.FirstOrDefault(m => m.Mercury_Id == mercuryEntry.Mercury_Id);
            //if (itemToUpdate != null)
            //{
            //    itemToUpdate.Mercury_Id = mercuryEntry.Mercury_Id;
            //    itemToUpdate.DateTimeStart = mercuryEntry.DateTimeStart;
            //    itemToUpdate.Hg = mercuryEntry.Hg;
            //    itemToUpdate.Unit = mercuryEntry.Unit;
            //}

            var itemToUpdate = _context.Mercury.FirstOrDefault(m => m.Mercury_Id == mercuryEntry.Mercury_Id);
            if (itemToUpdate != null)
            {
                itemToUpdate.Mercury_Id = mercuryEntry.Mercury_Id;
                itemToUpdate.DateTimeStart = mercuryEntry.DateTimeStart;
                itemToUpdate.Hg = mercuryEntry.Hg;
                itemToUpdate.Unit = mercuryEntry.Unit;
            }
            _context.SaveChanges();
        }
    }
}
