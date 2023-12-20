﻿using Contracts;
using MassTransit;
using System.Diagnostics.Contracts;

namespace AuctionService.Consumers;

public class AuctionCreatedFaultConsumer : IConsumer<Fault<AuctionCreated>>
{
    public async Task Consume(ConsumeContext<Fault<AuctionCreated>> context)
    {
        var exception = context.Message.Exceptions.First();
        if (exception.ExceptionType == "System.ArgumentException")
        {
            context.Message.Message.Model = "Foobar";
            await context.Publish(context.Message.Message);
        }
    }
}
