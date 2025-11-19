﻿using LocalizationResourceManager.Maui;
using MySteps.Resources;
using MySteps.Helpers;
using Microsoft.Extensions.Logging;
using MySteps.Repositories;
namespace MySteps
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                .UseLocalizationResourceManager(settings =>
                {
                    settings.AddResource(AppResources.ResourceManager);
                    settings.RestoreLatestCulture(true);
                });
                
                
            string dbPath = FileAccessHelper.GetLocalFilePath("my_steps.db3");
            builder.Services.AddSingleton<WalkRepository>(s => ActivatorUtilities.CreateInstance<WalkRepository>(s, dbPath));
            
            builder.Services.AddSingleton<MainPage>();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
