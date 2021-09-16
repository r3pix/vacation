using System.Collections.Generic;
using System.Net;

namespace ItmCode.Common.Contract
{
    public class Response
    {
        private List<string> _errors;

        public Response() : this(HttpStatusCode.OK)
        { }

        public Response(HttpStatusCode code)
        {
            _errors = new List<string>();
            Code = (int)code;
            IsError = Code >= 400;
        }

        public int Code { get; }
        public IEnumerable<string> Errors => _errors;
        public bool IsError { get; }

        public void AddError(string error) => _errors.Add(error);

        public void AddError(IEnumerable<string> errors) => _errors.AddRange(errors);
    }

    //public class Response<T> : Response
    //{
    //    public Response(T result) : base()
    //    {
    //        Result = result;
    //    }

    //    public Response(HttpStatusCode code, T result) : base(code)
    //    {
    //        Result = result;
    //    }

    //    public T Result { get; }
    //}
}