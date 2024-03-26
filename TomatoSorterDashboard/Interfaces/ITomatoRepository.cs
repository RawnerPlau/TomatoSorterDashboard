using TomatoSorterDashboard.Models;

namespace TomatoSorterDashboard.Interfaces
{
    public interface ITomatoRepository
    {
        public Task<Tomato> GetOneTomatoDoc();
    }
}
