#include "AboutForm.h"

using namespace System::Diagnostics;

namespace unlockfpsclr
{
	Void AboutForm::Exit_Button(Object^ sender, EventArgs^ e)
	{
		Close();
	}

	Void AboutForm::linkLabelSource_LinkClicked(Object^ sender, LinkLabelLinkClickedEventArgs^ e)
	{
		Process::Start("https://github.com/sefinek24/genshin-fps-unlock");
	}

	Void AboutForm::linkLabelIssues_LinkClicked(Object^ sender, LinkLabelLinkClickedEventArgs^ e)
	{
		Process::Start("https://github.com/sefinek24/genshin-fps-unlock/issues");
	}
}
