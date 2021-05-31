using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FunctionAppConsumoContador.Models;

namespace FunctionAppConsumoContador.HttpClients
{
    public class APIContagemClient
    {
        private HttpClient _httpClient;

        public APIContagemClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResultadoContador> ObterDadosContagem()
        {
            return await _httpClient.GetFromJsonAsync<ResultadoContador>(
                Environment.GetEnvironmentVariable("EndpointContador"));
        }
    }
}