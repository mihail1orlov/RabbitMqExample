using AutoBogus;
using Google.Protobuf;
using RabbitMq.ProtoData.Models;

namespace RabbitMq.MessageGenerator
{
    internal class MessageGenerator : IMessageGenerator
    {
        public byte[] Generate()
        {
            var myObject = AutoFaker.Generate<ObjectResult>();
            var bytes = myObject.ToByteArray();
            return bytes;
        }
    }
}