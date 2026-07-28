using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.GameTime
{
    public interface IGameTimeService
    {
        GameWindow GetCurrentWindow();
    }
}
