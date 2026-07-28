using System;
using System.Collections.Generic;
using System.Text;

namespace Application.CycleApp.DailyChecks
{
    public interface IFoalingCheckService
    {
        Task ProcessDueFoalingsAsync(Guid UserId);
    }
}
