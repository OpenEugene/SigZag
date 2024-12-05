using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Oqtane.Modules;
using Oqtane.Services;
using Oqtane.Shared;
using System.Net;

namespace OE.Module.SigZag.Services
{
    public class SigZagService : ResponseServiceBase, IService
    {
        public SigZagService(IHttpClientFactory http, SiteState siteState) : base(http, siteState) { }

        private string Apiurl => CreateApiUrl("SigZag");

        public async Task<(List<Models.SigZag>,HttpStatusCode)> GetSigZagsAsync()
        {
            var url = $"{Apiurl}";
            (var data, var response) = await GetJsonWithResponseAsync<List<Models.SigZag>>(url);
            return (data, response.StatusCode);      
        }

        public async Task<(Models.SigZag,HttpStatusCode)> GetSigZagAsync(int SigZagId)
        {
            var url = $"{Apiurl}/{SigZagId}";
            (var data, var response) = await GetJsonWithResponseAsync<Models.SigZag>(url);
            return (data, response.StatusCode);        
        }

        public async Task<(Models.SigZag,HttpStatusCode)> AddSigZagAsync(Models.SigZag SigZag)
        {
            var url = $"{Apiurl}";
            (var data, var response) = await PostJsonWithResponseAsync<Models.SigZag>(url,SigZag);
            return (data, response.StatusCode);        
        }

        public async Task<(Models.SigZag,HttpStatusCode)> UpdateSigZagAsync(Models.SigZag SigZag)
        {
            var url = $"{Apiurl}/{SigZag.SigZagId}";
            (var data, var response) = await PutJsonWithResponseAsync<Models.SigZag>(url,SigZag);
            return (data, response.StatusCode);        
        }

        public async Task<HttpStatusCode> DeleteSigZagAsync(int SigZagId)
        {
            var url = $"{Apiurl}/{SigZagId}";
            var response  = await DeleteWithResponseAsync(url);
            return response.StatusCode;
        }
    }
}
