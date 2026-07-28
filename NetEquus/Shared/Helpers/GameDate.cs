using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Helpers
{
    public static class GameDate
    {
        public static DateOnly Today()
        {
            return DateOnly.FromDateTime(DateTime.UtcNow);
        }
    }
}

