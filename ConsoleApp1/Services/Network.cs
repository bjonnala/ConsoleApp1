using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Network : INetwork
    {

        /* DAL Class which implements INetwork interface. This class handles all the data access by calling endpoints via HttpClient.  */
        /* In the future, if we need to swap out to any database we just need to modify this class without touching any dependents on this class. The dependency
         * is broken with interfaces. */



        private static HttpClient client = new HttpClient();
        private readonly string baseURL = string.Empty;
        private readonly string apiKey = string.Empty;

        public Network()
        {
            baseURL = "http://localhost:56747/v1/";
            client.DefaultRequestHeaders.Remove("apiKey");
            client.DefaultRequestHeaders.Add("apiKey", "??92-road-DRAW-settle-99??");
        }

        public async Task<Dictionary<string, string>> PostRequestAsync(string endpointurl,string body)
        {
            string result = string.Empty;
            Dictionary<string, string> res = new Dictionary<string, string>();

            HttpResponseMessage response = await client.PostAsync(baseURL + endpointurl, new StringContent(body, Encoding.UTF8, "application/json"));

            Debug.WriteLine("Endpoint: " + endpointurl);
            Debug.WriteLine("Headers : " + client.DefaultRequestHeaders);
            Debug.WriteLine("Request : " + body);
            if (response.IsSuccessStatusCode) //true if StatusCode was in the range 200-299; otherwise false.
            {
                result = await response.Content.ReadAsStringAsync();
                res.Add("statuscode", response.StatusCode.ToString());
                res.Add("response", result);
            }
            else
            {
                result = await response.Content.ReadAsStringAsync();
                res.Add("statuscode", response.StatusCode.ToString());
                res.Add("response", result);
            }

            return res;
        }

        public async Task<Dictionary<string, string>> DeleteRequestAsync(string endpointurl)
        {
            string result = string.Empty;
            Dictionary<string, string> res = new Dictionary<string, string>();

            HttpResponseMessage response = await client.DeleteAsync(baseURL + endpointurl);

            //Debug.WriteLine("Endpoint: " + endpointurl);
            //Debug.WriteLine("Headers : " + client.DefaultRequestHeaders);
            if (response.IsSuccessStatusCode) //true if StatusCode was in the range 200-299; otherwise false.
            {
                result = await response.Content.ReadAsStringAsync();
                res.Add("statuscode", response.StatusCode.ToString());
                res.Add("response", result);
            }
            else
            {
                result = await response.Content.ReadAsStringAsync();
                res.Add("statuscode", response.StatusCode.ToString());
                res.Add("response", result);
            }

            return res;
        }



        public async Task<Dictionary<string, string>> GetRequestAsync(string endpointurl)
        {
            string result = string.Empty;
            Dictionary<string, string> res = new Dictionary<string, string>();
            //client.DefaultRequestHeaders.Remove("accept");
            //client.DefaultRequestHeaders.Accept.Add(
            //    new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync(baseURL + endpointurl);
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsStringAsync();
                res.Add("statuscode", response.StatusCode.ToString());
                res.Add("response", result);
            }
            else
            {
                result = await response.Content.ReadAsStringAsync();
                res.Add("statuscode", response.StatusCode.ToString());
                res.Add("response", result);
            }
            return res;
        }
    }
}
