using System.Linq;

namespace ViberBot.Viber
{
    public class HelpCommand : Command
    {
        public override string commandName => "help";

        public override string description => "Получить список команд.";

        public override string Execute(ViberCallbackEvent callbackEvent, object obj = null)
        {
            var commands = Bot.instanse.allCommands.Select(c => $"{Command.startChar}{c.commandName} - {c.description}");
            var receiver = callbackEvent.senderId;
            var response = Utils.SendTextMessage(receiver, "Список доступных команд:");
            foreach (var command in commands)
            {
                response += Utils.SendTextMessage(receiver, command);
            }
            return response;
        }
    }
}
