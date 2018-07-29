using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

using Windows.Web.Http;
using Windows.Storage.Streams;

using Newtonsoft.Json;
using Windows.Web.Http.Filters;
using Windows.Security.Cryptography.Certificates;

namespace Airport.Connector.Endpoints
{
    public interface IEndpoint<TModel, TInputModel>
    {
        Task<IList<TModel>> GetAll();
        Task<TModel> Get(int id);
        Task<TModel> Update(int id, TInputModel inputModel);
        Task<TModel> Create(TInputModel inputModel);
        Task Delete(int id);
    }

    public class Endpoint<TModel, TInputModel> : IEndpoint<TModel, TInputModel>
    {
        protected Uri baseUri { get;  }

        public Endpoint(Uri baseUri, string relativeUri)
        {
            this.baseUri = new Uri(baseUri, relativeUri);
        }

        public async Task<TModel> Create(TInputModel inputModel)
        {
            var httpClient = GetHttpClient();
            var json = JsonConvert.SerializeObject(inputModel);
            var content = new HttpStringContent(json, UnicodeEncoding.Utf8);
            var uri = new Uri(baseUri, "");

            var response = await httpClient.PostAsync(uri, content);

            return default(TModel);
        }

        public async Task Delete(int id)
        {
            var httpClient = GetHttpClient();
            var uri = new Uri(baseUri, $"{id}");

            await httpClient.DeleteAsync(uri);
        }

        public async Task<TModel> Get(int id)
        {
            return await Get<TModel>($"{id}");
        }

        public async Task<IList<TModel>> GetAll()
        {
            return await Get<IList<TModel>>("");
        }

        public async Task<TModel> Update(int id, TInputModel inputModel)
        {
            var httpClient = GetHttpClient();
            var json = JsonConvert.SerializeObject(inputModel);
            var content = new HttpStringContent(json, UnicodeEncoding.Utf8);
            var uri = new Uri(baseUri, $"{id}");

            var response = await httpClient.PutAsync(uri, content);

            return default(TModel);
        }

        protected async Task<T> Get<T>(string url)
        {
            var httpClient = GetHttpClient();
            var uri = new Uri(baseUri, url);
            var data =  await httpClient.GetStringAsync(uri);

            return JsonConvert.DeserializeObject<T>(data);
        }

        protected HttpClient GetHttpClient()
        {
            var aHBPF = new HttpBaseProtocolFilter();
            aHBPF.IgnorableServerCertificateErrors.Add(ChainValidationResult.Expired);
            aHBPF.IgnorableServerCertificateErrors.Add(ChainValidationResult.Untrusted);
            return new HttpClient(aHBPF);
        }

        
    }
}
