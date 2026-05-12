using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface ILeaveService
    {
        Task<List<LeaveStep>> GenerateLeaveStep(Leave leave);
    }
}
