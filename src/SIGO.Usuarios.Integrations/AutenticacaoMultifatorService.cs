using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using SIGO.Usuarios.Application.Services;
using System;
using System.Text;
using System.Threading.Tasks;

namespace SIGO.Usuarios.Integrations
{
    public class AutenticacaoMultifatorService : IAutenticacaoMultifatorService
    {
        public AutenticacaoMultifatorService(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        public Task EnviarConfirmacaoMultifator(string numeroCelular, string codigoVerificacao)
        {
            return Task.Run(() =>
            {
                var endpoint = Configuration["SIGORabbitMq:endpoint"];
                var user = Configuration["SIGORabbitMq:username"];
                var password = Configuration["SIGORabbitMq:password"];
                var factory = new ConnectionFactory { Uri = new Uri(endpoint), UserName = user, Password = password };
                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "sms",
                                         durable: true,
                                         exclusive: false,
                                         autoDelete: false,
                                         arguments: null);

                    var conteudoMensagem = new
                    {
                        numeroCelular,
                        mensagem = $"Seu código de verificação SIGO: {codigoVerificacao}"
                    };

                    var messageJson = Newtonsoft.Json.JsonConvert.SerializeObject(conteudoMensagem);
                    var body = Encoding.UTF8.GetBytes(messageJson);

                    channel.BasicPublish(exchange: "",
                                         routingKey: "sms",
                                         basicProperties: null,
                                         body: body);

                }
            });
        }
    }
}
