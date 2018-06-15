using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.DAL
{
    public interface IData
    {
        Task<string> CreateUpdateAsync(RequestJSON createrequest, string id = ""); // id is an optional parameter
        Task<string> ReadAsync(string id);
        Task DeleteAsync(string id);
    }
}
