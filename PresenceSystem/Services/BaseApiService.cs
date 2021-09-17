using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Vacation.Services
{
    public class BaseApiService
    {
        protected readonly HttpClient _httpClient;
        protected readonly IMapper _mapper;

        public BaseApiService(HttpClient httpClient, IMapper mapper)
        {
            this._httpClient = httpClient;
            this._mapper = mapper;
        }
    }
}