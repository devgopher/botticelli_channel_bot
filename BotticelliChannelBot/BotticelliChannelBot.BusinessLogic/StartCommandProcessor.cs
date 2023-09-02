using Botticelli.Framework.Commands.Processors;
using Botticelli.Framework.Commands.Validators;
using Botticelli.Shared.API.Client.Requests;
using Botticelli.Shared.ValueObjects;
using BotticelliChannelBot.BusinessLogic.Commands;
using Microsoft.Extensions.Logging;

namespace BotticelliChannelBot.BusinessLogic;

public class StartCommandProcessor : CommandProcessor<StartCommand>
{
    public StartCommandProcessor(ILogger<StartCommandProcessor> logger,
                              ICommandValidator<StartCommand> validator)
            : base(logger, validator)
    {
    }

    protected override async Task InnerProcessContact(Message message, string argsString, CancellationToken token)
    {
    }

    protected override async Task InnerProcessPoll(Message message, string argsString, CancellationToken token)
    {
    }

    protected override async Task InnerProcessLocation(Message message, string argsString, CancellationToken token)
    {

    }


    protected override async Task InnerProcess(Message message, string args, CancellationToken token)
    {
        message.Body = "Hello! This is Botticelli! Here some commands to use this bot: " +
            "\n /GetInfo - displays a general info about the BotticelliBots project" +
            "\n /QuickStart - displays a quick start guide in order to build and deploy your first bot!";

        var sendRequest = new SendMessageRequest(message.Uid)
        {
            Message = message
        };

        await Bots?.FirstOrDefault()?.SendMessageAsync(sendRequest, token);
    }
}
