namespace unlockfps_nc.Model;

public class Config
{
	public string GamePath { get; set; } = "";

	public bool AutoStart { get; set; }
	public bool AutoClose { get; set; } = true;
	public bool PopupWindow { get; set; }
	public bool Fullscreen { get; set; } = true;
	public bool UseCustomRes { get; set; }
	public bool IsExclusiveFullscreen { get; set; }
	public bool StartMinimized { get; set; }
	public bool UsePowerSave { get; set; }
	public bool SuspendLoad { get; set; }
	public bool UseMobileUI { get; set; }

	public int FPSTarget { get; set; } = 144;
	public int CustomResX { get; set; } = 1920;
	public int CustomResY { get; set; } = 1080;
	public int MonitorNum { get; set; } = 1;
	public int Priority { get; set; } = 3;
	public string AdditionalCommandLine { get; set; } = "";
}
