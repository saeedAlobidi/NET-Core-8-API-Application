
using FluentValidation;
 
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

public static class OptionsBuilderExtensions
{


    /// <summary>
    /// Not every time you add option and file json in Configuration files 
    ///  1- register the files json in addConfigurationFiles
    ///  2- create class option such as (databaseOption) and there validation
    ///  3- add  Options in services
    /// </summary>
    
    /// <returns></returns>



    public static OptionsBuilder<TOptions> ValidateFluently<TOptions>(
    this OptionsBuilder<TOptions> optionsBuilder) where TOptions : class
    {


        optionsBuilder.Services.AddSingleton<IValidateOptions<TOptions>>(sp =>
        {
            var validator = sp.GetRequiredService<IValidator<TOptions>>();
            return new FluentValidationOptions<TOptions>(validator);
        });


        return optionsBuilder;
    }



    public static IConfigurationManager addConfigurationFiles(this IConfigurationManager config)
    {
        config.AddJsonFile("Configuration/json/database.json", optional: true, reloadOnChange: true);
        config.AddJsonFile("Configuration/json/jwt.json", optional: true, reloadOnChange: true);

        return config;
    }


    public static IServiceCollection addOptions(this IServiceCollection services, WebApplicationBuilder builder)
    {

        services.AddSingleton<IValidator<databaseOption>, DatabaseSettingsValidator>();
        services.AddSingleton<IValidator<jwtOption>, jwtValidator>();

        services.AddOptions<databaseOption>().Bind(builder.Configuration).ValidateFluently().ValidateOnStart();
        services.AddOptions<jwtOption>().Bind(builder.Configuration.GetSection(jwtOption.sectionName)).ValidateFluently().ValidateOnStart();


        return services;
    }

}