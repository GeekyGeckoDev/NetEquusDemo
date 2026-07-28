using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.GameTime
{
    public class GameTimeService : IGameTimeService
    {
        public GameWindow GetCurrentWindow()
        {
            var hour = DateTime.UtcNow.Hour;

            if (hour >= 6 && hour < 12)
                return GameWindow.Morning;

            if (hour >= 12 && hour < 17)
                return GameWindow.Midday;

            if (hour >= 17 && hour < 22)
                return GameWindow.Evening;

            return GameWindow.Night;
        }
    }
}
