using System.Collections.Generic;
using TheWorld.Models;

namespace TheWorld.Services
{
    public interface IWorldRepository
    {
        IList<Trip> GetAllTrips();
        List<Trip> GetAllTripsWithStops();
        void SaveChanges();
        void AddTrip(Trip T);
    }
}