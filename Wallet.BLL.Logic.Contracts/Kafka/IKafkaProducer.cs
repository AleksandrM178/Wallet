using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallet.BLL.Logic.Contracts.Kafka
{
    public interface IKafkaProducer
    {
        Task ProduceAsync(string topic, object message);
    }
}
