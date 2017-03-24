using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirQualityAPI.Models;

namespace AirQualityAPI.Repository
{
    public interface IOzonesRepository
    {
        void Add(Ozone ozoneEntry);
        IEnumerable<Ozone> GetAll();
        Ozone Find(string id);
        void Remove(string id);
        void Update(Ozone ozoneEntry);
    }
}
