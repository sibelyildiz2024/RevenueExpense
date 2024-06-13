using MauiAppBlazor3.Models;
using MauiAppBlazor3.Services;
using Microsoft.Extensions.Logging;

namespace MauiAppBlazor3
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
				});

			builder.Services.AddMauiBlazorWebView();
            builder.Services.AddBlazorBootstrap();

            var dbPath = Path.Combine(
				Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
				@"Ledger.db");

			builder.Services.AddSingleton<IInComeDebtItemService, InComeDebtItemService>(
				s => ActivatorUtilities.CreateInstance<InComeDebtItemService>(s, dbPath));

			//builder.Services.AddSingleton<IGenericService<IncomeModel>, IncomeService>(
			//	s => ActivatorUtilities.CreateInstance<IncomeService>(s, dbPath));
			builder.Services.AddSingleton<IIncomeService, IncomeService>(
				s => ActivatorUtilities.CreateInstance<IncomeService>(s, dbPath));
			builder.Services.AddSingleton<IDebtService, DebtService>(
				s => ActivatorUtilities.CreateInstance<DebtService>(s, dbPath));

#if DEBUG
			builder.Services.AddBlazorWebViewDeveloperTools();
			builder.Logging.AddDebug();
#endif

			return builder.Build();
		}
	}
}
