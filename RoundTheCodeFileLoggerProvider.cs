// RoundTheCodeFileLoggerProvider.cs
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

[ProviderAlias("RoundTheCodeFile")]
public class RoundTheCodeFileLoggerProvider : ILoggerProvider
{
    public readonly RoundTheCodeFileLoggerOptions Options;
 
    public RoundTheCodeFileLoggerProvider(IOptions<RoundTheCodeFileLoggerOptions> _options)
    {
        Options = _options.Value;
 
        var filepath = "C:\\Temp";
        if (!Directory.Exists(filepath))
        {
            Directory.CreateDirectory(filepath);
        }
    }
 
    public ILogger CreateLogger(string categoryName)
    {
        return new RoundTheCodeFileLogger(this);
    }
 
    public void Dispose()
    {
    }
}