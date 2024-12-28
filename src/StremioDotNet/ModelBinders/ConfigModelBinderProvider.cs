using System.Reflection;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using StremioDotNet.Attributes;

namespace StremioDotNet.ModelBinders;

internal class ConfigModelBinderProvider : IModelBinderProvider
{
    public IModelBinder GetBinder(ModelBinderProviderContext context)
    {
        return context.Metadata.ModelType.GetCustomAttribute(typeof(ConfigAttribute)) != null ? new BinderTypeModelBinder(typeof(ConfigModelBinder)) : null!;
    }
}