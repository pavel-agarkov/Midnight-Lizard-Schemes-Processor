using System.Collections.Generic;

namespace MidnightLizard.Schemes.Infrastructure.Configuration
{
    public class KafkaConfig
    {
        public Dictionary<string, object> KAFKA_CONSUMER_CONFIG { get; set; }

        public string SCHEMES_EVENTS_TOPIC { get; set; }
        public string SCHEMES_REQUESTS_TOPIC { get; set; }
    }
}