using Application.Interfaces;
using Entities.Enums;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public class LeaveService : ILeaveService
    {
        public Task<List<LeaveStep>> GenerateLeaveStep(Leave leave)
        {
            var steps = new List<LeaveStep>();

            int stepNumber = 1;

            var currentUnit = leave.User.Unit;

            while (currentUnit != null)
            {
                if (currentUnit.ManagerId != null)
                {
                    steps.Add(new LeaveStep
                    {
                        Leave = leave,
                        LeaveId = leave.Id,
                        LeaveStepNumber = stepNumber,
                        ApproverId = currentUnit.ManagerId,
                        LeaveStepStatus = LeaveStepStatus.Checking,
                        Date = DateTime.Now,
                    });
                    stepNumber++;
                }
                currentUnit = currentUnit.ParentUnit;
            }

            return Task.FromResult(steps); 
        }

        public Task<List<OverTimeStep>> GenerateOverTimeStep(OverTime overTime)
        {
            var steps = new List<OverTimeStep>();
            int stepNumber = 1;

            var currentUnit = overTime.User.Unit;
            while (currentUnit != null)
            {
                if (currentUnit.ManagerId != null && overTime.UserId != currentUnit.ManagerId)
                {
                    steps.Add(new OverTimeStep
                    {
                        OverTime = overTime,
                        OverTimeId = overTime.Id,
                        OverTimeStepNumber = stepNumber,
                        ApproverId = currentUnit.ManagerId,
                        OverTimeStepStatus = OverTimeStepStatus.Checking,
                        Date = DateTime.Now,
                    });
                    stepNumber++;
                }
                currentUnit = currentUnit.ParentUnit;
            }
            return Task.FromResult(steps);
        }
    }
}
