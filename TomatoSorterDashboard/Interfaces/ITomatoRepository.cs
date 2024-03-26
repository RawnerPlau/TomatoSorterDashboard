using TomatoSorterDashboard.Models;

namespace TomatoSorterDashboard.Interfaces
{
    public interface ITomatoRepository
    {
        public Task<Tomato> GetTomatoToday();

        public Task<List<Tomato>> GetAllTomatoes();
    }
}
