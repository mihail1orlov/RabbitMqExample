FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /

COPY . /

WORKDIR /RabbitMq.Host

RUN dotnet clean
RUN dotnet restore

RUN dotnet publish -c release -o /app --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:6.0

ENV RABBITMQ_CONNECTION_STRING: "amqp://user:user1234@192.168.1.203:5672",
ENV RABBITMQ_EXCHANGE: "MyExchange",
ENV RABBITMQ_EXCHANGE_TYPE: "Topic",
ENV RABBITMQ_ROUTING_KEY: "MyRoutingKey",
ENV RABBITMQ_DURABLE: "true"

WORKDIR /app
COPY --from=build /app ./

ENTRYPOINT ["dotnet", "RabbitMq.Host.dll"]