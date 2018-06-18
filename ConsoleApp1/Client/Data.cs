using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Models;
using Jil;

namespace ConsoleApp1.DAL
{
    public class Data : IData
    {
        // Client class to handle calls to DAL layer. //

        private readonly INetwork _utils;
        public Data(INetwork utils)
        {
            _utils = utils;
        }

        public async Task<string> CreateUpdateAsync(RequestJSON createrequest, string id = "") // id is an optional parameter
        {
            string result = string.Empty;
            RequestJSON requestJSON = new RequestJSON
            {
                expire = createrequest.expire,
                user = createrequest.user
            };


            string request = JSON.Serialize(requestJSON);
            string endpointURL = "guid";
            if (!string.IsNullOrWhiteSpace(id))
            {
                endpointURL = "guid/" + id;
            }
            Dictionary<string, string> res = await _utils.PostRequestAsync(endpointURL, request).ConfigureAwait(false);
            result = ProcessResponse(res);

            return result;
        }

        public async Task DeleteAsync(string id)
        {
            await _utils.DeleteRequestAsync("guid/" + id).ConfigureAwait(false);
        }

        public async Task<string> ReadAsync(string id)
        {
            Dictionary<string, string> res = await _utils.GetRequestAsync("guid/" + id).ConfigureAwait(false);
            string result = string.Empty;
            result = ProcessResponse(res);

            return result;
        }

        private string ProcessResponse(Dictionary<string, string> res)
        {
            string result;
            if (res["statuscode"] == "OK")
            {
                ResponseJSON successUserResponse = JSON.Deserialize<ResponseJSON>(res["response"]);
                if (!string.IsNullOrWhiteSpace(successUserResponse.result.guid))
                {
                    result = "Guid sucessfully created " + successUserResponse.result.guid + " and expires in " + successUserResponse.result.expire;
                }
                else
                {
                    result = "Guid not found";
                }
            }
            else if (res["statuscode"] == "InternalServerError")
            {
                result = "There seems to be a server error. Please try again later";
            }
            else if (res["statuscode"] == "BadRequest")
            {
                BadRequestResponse badRequestResponse = JSON.Deserialize<BadRequestResponse>(res["response"]);
                StringBuilder stringBuilder = new StringBuilder();
                foreach (var item in badRequestResponse.errors)
                {
                    stringBuilder.Append(item + Environment.NewLine);
                }

                result = stringBuilder.ToString();
            }
            else
            {
                result = "Route Not Found";
            }

            return result;
        }
    }
}
