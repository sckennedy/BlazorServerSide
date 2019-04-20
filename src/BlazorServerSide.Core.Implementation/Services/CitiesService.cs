using System.Collections.Generic;
using System.Linq;
using BlazorServerSide.Core.Data;
using BlazorServerSide.Core.Interfaces;

namespace BlazorServerSide.Core.Implementation.Services
{
    public class CitiesService : ICitiesService
    {
        private readonly BlazorServerSideContext _context;
        public CitiesService(BlazorServerSideContext context)
        {
            _context = context;
        }
        public List<Cities> GetAllCities()
        {
            try
            {
                return _context.Cities.ToList();
            }
            catch
            {
                throw;
            }
        }
    }
}
