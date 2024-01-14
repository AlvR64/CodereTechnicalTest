using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodereTest.Domain.Services
{
    public interface IHttpClientFactory
    {
        HttpClient CreateClient();
    }
}
