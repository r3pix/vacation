using System;
using System.Collections.Generic;
using System.Text;

namespace ItmCode.Common.Contract
{
    public class PaginationResult<TResult>
    {
        public IEnumerable<TResult> Result { get; }

        public int Total { get; set; }

        public PaginationResult(IEnumerable<TResult> result, int total)
        {
            Result = result;
            Total = total;
        }
    }
}