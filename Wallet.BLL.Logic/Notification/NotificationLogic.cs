using Confluent.Kafka;
using EmailService.Contracts;
using Microsoft.Extensions.Logging;
using Wallet.BLL.Logic.Contracts.Kafka;
using Wallet.BLL.Logic.Contracts.Notififcation;

namespace Wallet.BLL.Logic.Notification
{
    public class NotificationLogic : INotificationLogic
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IKafkaProducer _kafkaProducer;
        private readonly ILogger<NotificationLogic> _logger;

        public NotificationLogic(
            IHttpClientFactory httpClientFactory,
            IKafkaProducer kafkaProducer,
            ILogger<NotificationLogic> logger)
        {
            _httpClientFactory = httpClientFactory;
            _kafkaProducer = kafkaProducer;
            _logger = logger;
        }

        public async Task SendAsync(EmailServiceMessage message)
        {
            try
            {
                await _kafkaProducer.ProduceAsync("email.service.topic", message);
                _logger.LogInformation("message was sended sucsessful");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }




/*        public async Task SendAsync(EmailServiceMessage message)
        {
            HttpResponseMessage response = null;
            try
            {
                var client = _httpClientFactory.CreateClient(HttpClientNames.EMAIL_SERVICE);

                var content = new HttpRequestMessage();
                content.Method = HttpMethod.Post;
                content.Content = new StringContent(JsonSerializer.Serialize(message), null, "application/json");

                response = await client.SendAsync(content);

                while (!response.IsSuccessStatusCode)
                {
                    response = await client.SendAsync(content);
                }
            }
            catch (Exception ex)
            {

            }
        }*/
    }
}
