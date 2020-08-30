namespace ViberBot.Viber
{
    public class GameRaplicaButton
    {
        public string text { get; private set; }

        public int nextReplicaId { get; private set; }

        public GameRaplicaButton(string text, int nextReplicaId)
        {
            this.text = text;
            this.nextReplicaId = nextReplicaId;
        }
    }
}
