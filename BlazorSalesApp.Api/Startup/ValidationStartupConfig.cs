using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using FluentValidation;
using MediatR;

namespace BlazorSalesApp.Api.Startup;

public static class ValidationStartupConfig
{
    public static void AddCustomValidation(this IServiceCollection services, Assembly executingAssembly)
    {
        services.AddValidatorsFromAssembly(executingAssembly);

        ValidatorOptions.Global.DefaultRuleLevelCascadeMode = CascadeMode.Stop;
        // ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("en");
        ValidatorOptions.Global.DisplayNameResolver = (_, member, _) =>
            member == null
                ? null
                : member.GetCustomAttribute<DisplayNameAttribute>()?.DisplayName == null
                    ? "This field"
                    : "Field " + member.GetCustomAttribute<DisplayNameAttribute>()?.DisplayName;

        services.AddTransient(typeof(IPipelineBehavior<,>),
            typeof(CustomValidationPipelineBehavior<,>));
        services.AddTransient<ExceptionHandlingMiddleware>();
    }
}