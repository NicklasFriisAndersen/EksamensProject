namespace SommerSummarum.Services;

public interface IClipboardService
{
    Task CopyToClipboard(string text);
}