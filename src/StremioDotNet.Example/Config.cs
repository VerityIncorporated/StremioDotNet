using StremioDotNet.Attributes;

namespace StremioDotNet.Example;

[Config]
public class Config
{
    [ConfigPropertyName("something")]
    public int Something { get; set; }
    
    [ConfigPropertyName("somethingelse")]
    public string? SomethingElse { get; set; }
}