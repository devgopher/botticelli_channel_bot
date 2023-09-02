using Botticelli.Framework.Commands;

namespace BotticelliChannelBot.BusinessLogic.Commands
{
    public class GetInfoCommand : ICommand
    {
        public Guid Id { get; set; }
    }
}
