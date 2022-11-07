namespace Application.Common
{
    public class JwtSettingsOptions
    {
        public const string JwtSettings = "JwtSettings";
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Secret { get; set; }
    }
}
