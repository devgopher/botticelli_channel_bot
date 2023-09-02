using Botticelli.Framework.Telegram;
using Botticelli.Interfaces;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using TelegramMessagingSample.Settings;

namespace BotticelliChannelBot.Telegram;

/// <summary>
///     This hosted service intended for sending messages according to a schedule
/// </summary>
public class BotticelliChannelBotHostedService : IHostedService
{
    private readonly IOptionsMonitor<SampleSettings> _settings;
    private readonly IBot<TelegramBot> _telegramBot;

    public BotticelliChannelBotHostedService(IBot<TelegramBot> telegramBot, IOptionsMonitor<SampleSettings> settings)
    {
        _telegramBot = telegramBot;
        _settings = settings;
    }

    public Task StartAsync(CancellationToken token)
    {
        Console.WriteLine("Start sending messages...");

        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("Stop sending messages...");

        return Task.CompletedTask;
    }
}