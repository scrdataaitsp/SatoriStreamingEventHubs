using System;
using System.Configuration;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SatoriStreamingData
{
    public class EventHubsTraceListener : TraceListener
    {
        private readonly EventHubClient _client;

        public EventHubsTraceListener()
        {
            MessagingFactory factory = MessagingFactory.Create(ServiceBusEnvironment.CreateServiceUri("sb", ConfigurationSettings.AppSettings["ServiceBus.Namespace"], ""), new MessagingFactorySettings()
            {
                TokenProvider = TokenProvider.CreateSharedAccessSignatureTokenProvider(ConfigurationSettings.AppSettings["ServiceBus.KeyName"], ConfigurationSettings.AppSettings["ServiceBus.Key"]),
                TransportType = TransportType.Amqp
            });
            _client = factory.CreateEventHubClient("vehicletelemetry");


        }

        public override void Write(string message)
        {
            //var eventData = new EventData(Encoding.Default.GetBytes(JsonConvert.SerializeObject(new LogMessageEvent()
            //{
            //    InstanceId = _instanceId,
            //    MachineName = Environment.MachineName,
            //    SiteName = _siteName,
            //    Value = message
            //})));


            var eventData = new EventData(Encoding.Default.GetBytes(message));

            //eventData.PartitionKey = //provide partitionkey here;
            _client.Send(eventData);
        }

        public override void WriteLine(string message)
        {
            Write(message);
        }
    }
}