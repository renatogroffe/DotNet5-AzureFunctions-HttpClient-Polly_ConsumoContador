using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using FunctionAppConsumoContador.HttpClients;

namespace FunctionAppConsumoContador
{
    public class TimerTriggerConsumoContador
    {
        public readonly APIContagemClient _apiContagemClient;

        public TimerTriggerConsumoContador(APIContagemClient apiContagemClient)
        {
            _apiContagemClient = apiContagemClient;
        }

        [Function("TimerTriggerConsumoContador")]
        public void Run([TimerTrigger("*/5 * * * * *")] FunctionContext context)
        {
            var logger = context.GetLogger("TimerTriggerConsumoContador");
            
            var resultado = _apiContagemClient.ObterDadosContagemAsync().Result;
            logger.LogInformation($" ## Valor do contador = {resultado.ValorAtual}");
            logger.LogInformation($" ## Saudação = {resultado.Saudacao}");
            logger.LogInformation($" ## Aviso = {resultado.Aviso}");
            logger.LogInformation($" ## Local = {resultado.Local}");
            logger.LogInformation($" ## Kernel = {resultado.Kernel}");
            logger.LogInformation($" ## Target Framework = {resultado.TargetFramework}");
        }
    }
}