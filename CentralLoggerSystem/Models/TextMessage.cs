namespace CentralLoggerSystem.Models
{
    public class TextMessage
    {
        public TextMessage() { }
        public TextMessage(string Message, string Level, DateTime Timestamp)
        {
            this.Message = Message;
            this.Level = Level;
            this.Timestamp = Timestamp;
        }

        public string Level { get; set; }
        public string Message { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
