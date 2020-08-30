namespace ViberBot.Viber
{
    public class HelloCommand : Command
    {
        public override string commandName => "hello";

        public override string description => "Поздароваться.";

        public override string Execute(ViberCallbackEvent callbackEvent, object obj = null)
        {
            var receiver = callbackEvent.senderId;
            return Utils.SendTextMessage(receiver, $"Привет! Я чат бот для Viber. К сожалению я всего лишь машина и могу отвечать только на заданные команды. Список команд можно вывести отправив мне сообщение с текстом {Command.startChar}{new HelpCommand().commandName}.");
        }
    }
}
