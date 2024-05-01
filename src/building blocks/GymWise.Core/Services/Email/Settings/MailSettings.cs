namespace GymWise.Core.Services.Email.Settings;

/// <param name="SmtpPort"> Gets or sets the SMTP port. </param>
public record MailSettings(int SmtpPort)
{
    public const string SettingsKey = "Mail";

    /// <summary>
    /// Gets or sets the email sender display name.
    /// </summary>
    public string SenderDisplayName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the email sender.
    /// </summary>
    public string SenderEmail { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the SMTP password.
    /// </summary>
    public string SmtpPassword { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the SMTP server.
    /// </summary>
    public string SmtpServer { get; set; } = string.Empty;
}