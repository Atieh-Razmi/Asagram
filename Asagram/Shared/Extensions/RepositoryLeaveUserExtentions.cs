using Entities.Models;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Extensions
{
    public static class RepositoryLeaveUserExtentions
    {
        public static IQueryable<Leave> FilterUserLeaves(this IQueryable<Leave> query, UserLeaveParameters userLeaveParameters)
        {
            if(userLeaveParameters.LeaveType.HasValue) 
            {
                query = query.Where(c=>c.LeaveType == userLeaveParameters.LeaveType);
            }
            if (userLeaveParameters.LeaveTime.HasValue)
            {
                query = query.Where(c=>c.LeaveTime == userLeaveParameters.LeaveTime);
            }
            if (userLeaveParameters.LeaveStatus.HasValue)
            {
                query = query.Where(c=>c.LeaveStatus == userLeaveParameters.LeaveStatus);
            }
            return query;
        }
    }
}
