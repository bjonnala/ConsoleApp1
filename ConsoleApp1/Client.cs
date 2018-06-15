using ConsoleApp1.DAL;
using ConsoleApp1.Models;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Client
    {
        private readonly IData _data;
        public Client(IData data)
        {
            _data = data;
        }

        public async Task<string> GetAsync(string id)
        {
            return await _data.ReadAsync(id).ConfigureAwait(false);
        }

        //public async Task<string> PostAsync(string id,RequestJSON requestJSON)
        //{
        //    return await _data.CreateUpdateAsync(id,requestJSON).ConfigureAwait(false);
        //}

        //public async Task<string> UpdateAsync(string id, RequestJSON requestJSON)
        //{
        //    return await _data.CreateUpdateAsync(id,requestJSON).ConfigureAwait(false);
        //}

        public async Task DeleteAsync(string id)
        {
            await _data.DeleteAsync(id).ConfigureAwait(false);
        }


    }
}