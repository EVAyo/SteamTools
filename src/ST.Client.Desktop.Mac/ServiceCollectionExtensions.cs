using System;
using System.Application.Services;
using System.Application.Services.Implementation;
using System.Application.UI;
using System.Net.Http;
using System.Windows;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection
{
    public static partial class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDesktopPlatformService(this IServiceCollection services, bool hasSteam, bool hasGUI, bool hasNotifyIcon)
        {
            if (OperatingSystem2.IsMacOS)
            {
                services.AddSingleton<IHttpPlatformHelper, PlatformHttpPlatformHelper>();
                services.AddSingleton(AppDelegate.Instance!);
                services.AddSingleton<MacDesktopPlatformServiceImpl>();
                services.AddSingleton<IPlatformService>(s => s.GetRequiredService<MacDesktopPlatformServiceImpl>());
                services.AddSingleton<IDesktopPlatformService>(s => s.GetRequiredService<MacDesktopPlatformServiceImpl>());
                services.AddSingleton<IEmailPlatformService>(s => s.GetRequiredService<MacDesktopPlatformServiceImpl>());
                //services.AddSingleton<ISystemJumpListService, SystemJumpListServiceImpl>();
                if (hasNotifyIcon) services.AddNotifyIcon();
            }
            else
            {
                throw new PlatformNotSupportedException();
            }
            return services;
        }
    }
}