using MvcStartApp.Models.Db;

namespace MvcStartApp.Models.Repository
{
    public interface IRequestRepository
    {
        Task AddLogs(Request req);
        Task<Request[]> GetLogs();
    }
}
