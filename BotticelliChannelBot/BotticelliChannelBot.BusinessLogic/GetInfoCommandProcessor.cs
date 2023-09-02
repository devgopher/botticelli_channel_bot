using Botticelli.Framework.Commands.Processors;
using Botticelli.Framework.Commands.Validators;
using Botticelli.Shared.API.Client.Requests;
using Botticelli.Shared.ValueObjects;
using BotticelliChannelBot.BusinessLogic.Commands;
using Microsoft.Extensions.Logging;

namespace BotticelliChannelBot.BusinessLogic;

public class GetInfoCommandProcessor : CommandProcessor<GetInfoCommand>
{
    public GetInfoCommandProcessor(ILogger<StartCommandProcessor> logger,
                              ICommandValidator<GetInfoCommand> validator)
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
        message.Body = "What's it\n" +
            "\nThe main idea is to provide a simple bot creation and support platform.\n" +
            "\nBotticelli allows you to develop cross-platform bots with common business logic.\n" +
            "\nThe main features are:\n" +
            "\n-- cross-platform (Windows/Linux are supported)" +
            "\n-- supports different messengers" +
            "\n-- supports AI integration" +
            "\n-- supports message brokers integration (such as RabbitMq)" +
            "\n-- supports scheduling" +
            "\n-- supports bot managing" +
            "\n-- supports bot monitoring" +
            "\n\nRepository is here: https://github.com/devgopher/botticelli" +
            "\n\nSite is here: http://botticellibots.com";

        var sendRequest = new SendMessageRequest(message.Uid)
        {
            Message = message
        };

        await Bots?.FirstOrDefault()?.SendMessageAsync(sendRequest, token);
    }
}