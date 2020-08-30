namespace ViberBot.Viber
{
    public abstract class Command
    {
        public static string startChar = "#";

        public abstract string commandName { get; }

        public abstract string description { get; }

        public abstract string Execute(ViberCallbackEvent callbackEvent, object obj = null);
    }
}
