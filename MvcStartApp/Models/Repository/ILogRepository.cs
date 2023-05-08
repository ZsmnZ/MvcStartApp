﻿using MvcStartApp.Models.Db;

namespace MvcStartApp.Models.Repository
{
    public interface ILogRepository
    {
        Task AddLogs(Request req);
        Task<Request[]> GetLogs();
    }
}
