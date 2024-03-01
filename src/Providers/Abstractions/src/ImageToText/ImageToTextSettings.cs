// ReSharper disable once CheckNamespace
namespace LangChain.Providers;

/// <summary>
/// Base class for chat request settings.
/// </summary>
public class ImageToTextSettings
{
    public static ImageToTextSettings Default { get; } = new()
    {
        StopSequences = Array.Empty<string>(),
        User = string.Empty,
        UseStreaming = false,
    };
    
    /// <summary>
    /// Unique user identifier.
    /// </summary>
    public string? User { get; init; }
    
    /// <summary>
    /// Defines the stop sequences for the model.
    /// </summary>
    public IReadOnlyList<string>? StopSequences { get; init; }

    /// <summary>
    /// Sampling temperature
    /// </summary>
    public bool? UseStreaming { get; init; }

    /// <summary>
    /// Calculate the settings to use for the request.
    /// </summary>
    /// <param name="requestSettings"></param>
    /// <param name="modelSettings"></param>
    /// <param name="providerSettings"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public static ImageToTextSettings Calculate(
        ImageToTextSettings? requestSettings,
        ImageToTextSettings? modelSettings,
        ImageToTextSettings? providerSettings)
    {
        return new ImageToTextSettings
        {
            StopSequences = 
                requestSettings?.StopSequences ??
                modelSettings?.StopSequences ??
                providerSettings?.StopSequences ??
                Default.StopSequences ??
                throw new InvalidOperationException("Default StopSequences is not set."),
            User = 
                requestSettings?.User ??
                modelSettings?.User ??
                providerSettings?.User ??
                Default.User ??
                throw new InvalidOperationException("Default User is not set."),
            UseStreaming = 
                requestSettings?.UseStreaming ??
                modelSettings?.UseStreaming ??
                providerSettings?.UseStreaming ??
                Default.UseStreaming ??
                throw new InvalidOperationException("Default UseStreaming is not set."),
        };
    }
}