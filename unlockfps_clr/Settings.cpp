#include "Settings.h"

using namespace System;
using namespace IO;
using namespace Text;
using namespace Json;
using namespace Windows::Forms;

Settings::Settings()
{
}

Settings^ Settings::initialize_defaults()
{
	AutoClose = true;
	AutoDisableVSync = true;
	AutoStart = false;
	ConfigDate = "18.04.2023";
	ConfigVersion = "1.1.1";
	DllList = gcnew List<String^>();
	CustomResX = 1920;
	CustomResY = 1080;
	FPSTarget = 60;
	Fullscreen = false;
	Fullscreen = true;
	GamePath = "";
	IsExclusiveFullscreen = false;
	PopupWindow = false;
	Priority = 3;
	UseCustomRes = false;
	UsePowerSave = false;
	return this;
}

void Settings::save()
{
	auto options = gcnew JsonSerializerOptions();
	options->WriteIndented = true;

	auto serialized = JsonSerializer::Serialize(this, options);
	File::WriteAllText(ConfigPath, serialized, Encoding::UTF8);
}

Settings^ Settings::load()
{
	// Create a config if there isn't one
	if (!File::Exists(ConfigPath))
		return (gcnew Settings())->initialize_defaults();

	auto serialized = File::ReadAllText(ConfigPath, Encoding::UTF8);
	auto instance = JsonSerializer::Deserialize<Settings^>(serialized, nullptr);

	// Extra sanitization
	if (!instance->DllList)
		instance->DllList = gcnew List<String^>();

	// Remove invalid items
	for each (auto path in instance->DllList->ToArray())
	{
		if (!File::Exists(path)) instance->DllList->Remove(path);
	}

	return instance;
}
