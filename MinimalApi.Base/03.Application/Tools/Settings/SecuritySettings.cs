namespace MinimalApi.Base.Presentation.Filters
{
    public class SecuritySettings
    {
        public string ApiToken { get; set; } = String.Empty;
        public string URLSecurityApi { get; set; } = String.Empty;
        public string MyPropJWT_Usererty { get; set; } = String.Empty;
        public JwtSecurity Jwt { get; set; }

        public class JwtSecurity
        {
            public string SecretKey { get; set; } = String.Empty;
            public string Audience { get; set; } = String.Empty;
            public string Issuer { get; set; } = String.Empty;

        }
    }
 
}
