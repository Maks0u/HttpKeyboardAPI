using System.Text.Json.Serialization;

namespace HttpKeyboardAPI
{
  public class KeyCombination
  {
    [JsonPropertyName("keys")]
    public List<string> Keys { get; set; } = new List<string>();
  }
}