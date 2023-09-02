using Botticelli.Framework.Commands.Processors;
using Botticelli.Framework.Commands.Validators;
using Botticelli.Shared.API.Client.Requests;
using Botticelli.Shared.ValueObjects;
using BotticelliChannelBot.BusinessLogic.Commands;
using Microsoft.Extensions.Logging;

namespace BotticelliChannelBot.BusinessLogic;

public class SupportCommandProcessor : CommandProcessor<SupportCommand>
{
    public SupportCommandProcessor(ILogger<SupportCommandProcessor> logger,
                              ICommandValidator<SupportCommand> validator)
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
        message.Body = "botticellibots@gmail.com";

        var sendRequest = new SendMessageRequest(message.Uid)
        {
            Message = message
        };

        await Bots?.FirstOrDefault()?.SendMessageAsync(sendRequest, token);
    }
}
