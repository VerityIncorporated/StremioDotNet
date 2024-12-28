using System.Reflection;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace StremioDotNet.ModelBinders;

internal class ConfigModelBinder : IModelBinder
{
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        ArgumentNullException.ThrowIfNull(bindingContext);

        if (!bindingContext.ActionContext.RouteData.Values.TryGetValue("config", out var rawConfigObj) || rawConfigObj is not string rawConfig)
        {
            bindingContext.Result = ModelBindingResult.Success(null);
            return Task.CompletedTask;
        }
        
        var targetType = bindingContext.ModelType;
        var result = Activator.CreateInstance(targetType);
        
        var properties = targetType.GetProperties(BindingFlags.Public | BindingFlags.Instance);

        foreach (var property in properties)
        {
            var attribute = property.GetCustomAttribute<Attributes.ConfigPropertyNameAttribute>();
            
            var configKey = attribute?.Name ?? property.Name;

            var configEntries = rawConfig.Split('|', StringSplitOptions.RemoveEmptyEntries)
                .Select(entry => entry.Split('=', 2))
                .ToDictionary(parts => parts[0], parts => parts.Length > 1 ? parts[1] : string.Empty);

            if (!configEntries.TryGetValue(configKey, out var value)) continue;
            
            try
            {
                var convertedValue = Convert.ChangeType(value, property.PropertyType);
                property.SetValue(result, convertedValue);
            }
            catch
            {
                // ignored
            }
        }

        bindingContext.Result = ModelBindingResult.Success(result);
        return Task.CompletedTask;
    }
}