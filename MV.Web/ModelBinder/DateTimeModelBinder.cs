using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MV.Web.ModelBinder
{
  public class DateTimeModelBinder : IModelBinder
  {
    public DateTimeModelBinder()
    {

    }

    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
      if (bindingContext == null)
      {
        throw new ArgumentNullException(nameof(bindingContext));
      }

      var modelName = bindingContext.ModelName;

      // Try to fetch the value of the argument by name
      var valueProviderResult = bindingContext.ValueProvider.GetValue(modelName);

      if (valueProviderResult == ValueProviderResult.None)
      {
        return Task.CompletedTask;
      }

      bindingContext.ModelState.SetModelValue(modelName, valueProviderResult);

      var value = valueProviderResult.FirstValue;

      // Check if the argument value is null or empty
      if (string.IsNullOrEmpty(value))
      {
        return Task.CompletedTask;
      }
      Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("de-DE");
      if (!DateTime.TryParse(value,Thread.CurrentThread.CurrentUICulture,DateTimeStyles.None,out var dateTime))
      {
        // Non-integer arguments result in model state errors
        bindingContext.ModelState.TryAddModelError(
            modelName, "The date fromat is wrong.");

        return Task.CompletedTask;
      }

      bindingContext.Result = ModelBindingResult.Success(dateTime);
      return Task.CompletedTask;
    }
  }
}
