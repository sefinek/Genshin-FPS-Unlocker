using NLog;
using NLog.Config;

namespace unlockfps_nc;

public static class LogManagerHelper
{
	private static Logger? _logger;

	public static void Initialize(string cfgPath, string appName, string? appVersion)
	{
		_logger = LogManager.GetCurrentClassLogger()
			.WithProperty("AppName", appName)
			.WithProperty("AppVersion", appVersion);

		LogManager.Configuration = new XmlLoggingConfiguration(cfgPath);
	}

	public static Logger GetLogger()
	{
		return _logger ?? throw new InvalidOperationException("Logger has not been initialized. Call LogManagerHelper.Initialize(appName, appVersion) first.");
	}
}
