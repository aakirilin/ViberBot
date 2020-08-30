using System.Linq;

namespace ViberBot.Viber
{
    public class GameReplica
    {
        public int id { get; private set; }

        public string text { get; private set; }

        public GameRaplicaButton[] buttons { get; private set; }

        public GameReplica(int id, string text, params GameRaplicaButton[] buttons)
        {
            this.id = id;
            this.text = text;
            this.buttons = buttons;
        }

        public int? GetNextReplicaId(string buttonText)
        {
            var button = buttons.FirstOrDefault(b => b.text.ToLower().Equals(buttonText.ToLower()));
            if (button == null)
            {
                return null;
            }
            return button.nextReplicaId;
        }
    }
}
