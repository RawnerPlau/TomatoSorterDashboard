using TomatoSorterDashboard.Models;

namespace TomatoSorterDashboard.Interfaces
{
    public interface ITomato
    {
        public Task<List<Tomato>> GetAllTomatoes();
    }
}
