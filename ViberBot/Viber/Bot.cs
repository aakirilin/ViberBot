using System.Collections.Generic;
using System.Linq;

namespace ViberBot.Viber
{
    public class Bot
    {
        private static Bot _instanse = new Bot();

        public static Bot instanse
        {
            get
            {
                return _instanse;
            }
        }

        private Command[] commands;

        public IReadOnlyCollection<Command> allCommands => commands;

        private Bot()
        {
            commands = new Command[]
            {
                new HelloCommand(),
                new HelpCommand(),
                new GameCommand()
            };
        }

        public Command GetCommand(string typeCallback)
        {
            return commands.FirstOrDefault(c =>
                typeCallback.ToLower()
                    .StartsWith($"{Command.startChar}{c.commandName.ToLower()}"));
        }
    }
}
