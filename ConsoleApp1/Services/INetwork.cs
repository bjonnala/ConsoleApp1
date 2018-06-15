using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public interface INetwork
    {
        Task<Dictionary<string, string>> PostRequestAsync(string endpointurl, string body);
        Task<Dictionary<string, string>> GetRequestAsync(string endpointurl);
        Task<Dictionary<string, string>> DeleteRequestAsync(string endpointurl);
    }
}