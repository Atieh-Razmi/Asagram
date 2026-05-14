using Entities.Models;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Extensions
{
    public static class RepositoryWorkLogExtensions
    {
        public static IQueryable<WorkLog> FilterWorkLog(this IQueryable<WorkLog> query, WorkLogParameters workLogParameters)
        {
            if(workLogParameters.user.HasValue)
            {
                query = query.Where(e=>e.UserId == workLogParameters.user);
            }
            return query;

        }

        public static IQueryable<WorkLog> Search(this IQueryable<WorkLog> query, WorkLogParameters workLogParameters)
        {
            if (workLogParameters.FromDate.HasValue)
            {
                query.Where(e => e.Date >= workLogParameters.FromDate);
            }

            if(workLogParameters.ToDate.HasValue)
            {
                query.Where(e=>e.Date <= workLogParameters.ToDate);
            }
            return query;
        }
    }
}
