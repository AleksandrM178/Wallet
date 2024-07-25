using EmailService.Contracts;
using System.Text.Json;
using Wallet.BLL.Logic.Contracts.Notififcation;
using Wallet.Common.Entities.HttpClientts;

namespace Wallet.BLL.Logic.Notification
{
    public class NotificationLogic : INotificationLogic
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public NotificationLogic(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task SendAsync(EmailServiceMessage message)
        {
            var client = _httpClientFactory.CreateClient(HttpClientNames.EMAIL_SERVICE);

            var content = new HttpRequestMessage();
            content.Method = HttpMethod.Post;
            content.Content = new StringContent(JsonSerializer.Serialize(message), null, "application/json");

            await client.SendAsync(content);
        }
    }
}
