namespace StremioDotNet.Attributes;

[AttributeUsage(AttributeTargets.Property)]
public class ConfigPropertyNameAttribute : Attribute
{
    public string Name { get; }

    public ConfigPropertyNameAttribute(string name)
    {
        Name = name;
    }
}