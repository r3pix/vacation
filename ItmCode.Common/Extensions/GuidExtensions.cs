using System;
using System.Collections.Generic;
using System.Text;

namespace ItmCode.Common.Extensions
{
    public static class GuidExtensions
    {
        public static Guid Create(int prefix, int sufix)
        {
            return Guid.Parse($"00000000-{prefix.ToString("0000")}-0000-0000-{sufix.ToString("000000000000")}");
        }
    }
}