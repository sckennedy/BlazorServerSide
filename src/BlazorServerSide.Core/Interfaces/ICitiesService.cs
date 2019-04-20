
using System.Collections.Generic;

namespace BlazorServerSide.Core.Interfaces
{
    public interface ICitiesService
    {
        List<Cities> GetAllCities();
    }
}
