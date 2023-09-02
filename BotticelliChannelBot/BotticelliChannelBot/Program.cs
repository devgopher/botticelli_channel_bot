using BotDataSecureStorage.Settings;
using Botticelli.Framework.Commands.Validators;
using Botticelli.Framework.Extensions;
using Botticelli.Framework.Options;
using Botticelli.Framework.Telegram;
using Botticelli.Framework.Telegram.Extensions;
using Botticelli.Framework.Telegram.Options;
using BotticelliChannelBot.BusinessLogic;
using BotticelliChannelBot.BusinessLogic.Commands;
using BotticelliChannelBot.Telegram;
using NLog.Extensions.Logging;
using TelegramMessagingSample.Settings;

var builder = WebApplication.CreateBuilder(args);

var settings = builder.Configuration
                      .GetSection(nameof(SampleSettings))
                      .Get<SampleSettings>();

builder.Services
       .Configure<SampleSettings>(builder.Configuration.GetSection(nameof(SampleSettings)))
       .AddTelegramBot(builder.Configuration,
                       new BotOptionsBuilder<TelegramBotSettings>()
                               .Set(s => s.SecureStorageSettings = new SecureStorageSettings
                               {
                                   ConnectionString = settings.SecureStorageConnectionString
                               })
                               .Set(s => s.Name = settings.BotName))
       .AddLogging(cfg => cfg.AddNLog())
       .AddHostedService<BotticelliChannelBotHostedService>()
       .AddScoped<StartCommandProcessor>()
       .AddBotCommand<StartCommand, StartCommandProcessor, PassValidator<StartCommand>>()
       .AddBotCommand<GetInfoCommand, GetInfoCommandProcessor, PassValidator<GetInfoCommand>>()
       .AddBotCommand<QuickStartCommand, QuickStartCommandProcessor, PassValidator<QuickStartCommand>>()
       .AddBotCommand<SupportCommand, SupportCommandProcessor, PassValidator<SupportCommand>>();

var app = builder.Build();
app.Services.RegisterBotCommand<StartCommand, StartCommandProcessor, TelegramBot>()
    .RegisterBotCommand<QuickStartCommand, QuickStartCommandProcessor, TelegramBot>()
    .RegisterBotCommand<GetInfoCommand, GetInfoCommandProcessor, TelegramBot>()
    .RegisterBotCommand<SupportCommand, SupportCommandProcessor, TelegramBot>();

app.Run();