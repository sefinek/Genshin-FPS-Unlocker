#pragma once
#include "Settings.h"

using namespace System;
using namespace IO;
using namespace Windows::Forms;
using namespace Collections::Generic;
using namespace Microsoft::Win32;
using namespace Runtime::InteropServices;

namespace Managed
{
	// Start game with launch options
	bool StartGame(Settings^ settings);

	// Attempt to find game path through registry
	List<String^>^ TryResolveGamePath();

	// Get game path while the game is running
	String^ TryGetGamePath();

	void InjectDLLs(List<String^>^ paths);
};
