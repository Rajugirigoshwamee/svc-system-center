namespace svc.system.center.domain.Config;

public class AuthConfig
{
    public required string Key { get; set; }

    public required string Issuer { get; set; }

    public required string Audiance { get; set; }

    public required int AccessExpireMinutes { get; set; }
}
