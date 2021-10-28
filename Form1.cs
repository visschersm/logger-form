using Microsoft.Extensions.Logging;

namespace logger_form_demo;

public partial class Form1 : Form
{
    private readonly ILogger<Form> logger;

    public Form1(ILogger<Form> logger)
    {
        InitializeComponent();

        this.logger = logger;
        logger.LogTrace("Log Trace");
        logger.LogDebug("Log Debug");
        logger.LogInformation("Log Information");
        logger.LogWarning("Log Warning");
        logger.LogError("Log Error");
        logger.LogCritical("Log Critical");
    }
}
