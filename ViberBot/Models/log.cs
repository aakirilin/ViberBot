namespace ViberBot.Models
{
    public class Log
    {
        public int id { get; set; }
        public string text { get; set; }
        public string steackTrace { get; set; }

        public Log(string text, string steackTrace)
        {
            this.text = text;
            this.steackTrace = steackTrace;
        }
    }
}
