namespace API.Core.Config
{
    public class DbOptions
    {
        public string Server { get; set; } = string.Empty;

        public string Schema { get; set; } = string.Empty;

        public string User { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;
    }
}