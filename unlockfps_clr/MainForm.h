#pragma once
#include "Settings.h"
#include "SetupForm.h"
#include "SettingsForm.h"
#include <algorithm>

namespace unlockfpsclr
{
	using namespace System;
	using namespace System::ComponentModel;
	using namespace Collections;
	using namespace Windows::Forms;
	using namespace Data;
	using namespace Drawing;

	/// <summary>
	/// Summary for MainForm
	/// </summary>
	public ref class MainForm : public Form
	{
	public:
		MainForm(void)
		{
			InitializeComponent();

			settings = Settings::Load();
			settingsForm = gcnew SettingsForm(settings);

			this->Load += gcnew EventHandler(this, &MainForm::OnLoad);
			this->FormClosing += gcnew FormClosingEventHandler(this, &MainForm::OnFormClosing);
			this->Resize += gcnew EventHandler(this, &MainForm::OnResize);
			this->notifyIcon->DoubleClick += gcnew EventHandler(this, &MainForm::OnDoubleClick);
		}

	protected:
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		~MainForm()
		{
			if (components)
			{
				delete components;
			}
		}

	private:
		Settings^ settings;

	private:
		BackgroundWorker^ backgroundWorker;

	private:
		SettingsForm^ settingsForm;

	private:
		Button^ btnStartGame;

	private:
		CheckBox^ ckbAutoStart;

	private:
		ToolTip^ ttAutoStart;

	private:
		TrackBar^ tbFPS;

	private:
		Label^ labelFPS;

	private:
		NumericUpDown^ inputFPS;

	private:
		MenuStrip^ menuStrip1;

	private:
		ToolStripMenuItem^ toolStripMenuItem;

	private:
		ToolStripMenuItem^ menuItemSettings;

	private:
		ToolTip^ ttGamePath;

	private:
		ToolStripMenuItem^ menuItemSetup;

	private:
		NotifyIcon^ notifyIcon;

	private:
		Windows::Forms::ContextMenuStrip^ contextMenuNotify;

	private:
		ToolStripMenuItem^ toolStripMenuExit;

	private:
		ToolStripMenuItem^ menuItemAbout;

	private:
		ToolStripMenuItem^ openToolStripMenuItem;

	private:
		ToolStripMenuItem^ genshinImpactModPackToolStripMenuItem;

	private:
		ToolStripMenuItem^ checkHzOfYourMonitorToolStripMenuItem;

	private:
		ToolStripMenuItem^ systemInformationToolStripMenuItem;

	private:
		ToolStripMenuItem^ dxDiaxToolStripMenuItem;

	private:
		ToolStripMenuItem^ linksToolStripMenuItem;

	private:
		ToolStripMenuItem^ officialWebsiteToolStripMenuItem;

	private:
		ToolStripMenuItem^ youTubeToolStripMenuItem;

	private:
		ToolStripMenuItem^ gitHubToolStripMenuItem;

	private:
		ToolStripMenuItem^ repositoriesToolStripMenuItem;

	private:
		ToolStripMenuItem^ genshinImpactReShade2023ToolStripMenuItem;

	private:
		ToolStripMenuItem^ genshinFPSUnlockToolStripMenuItem;

	private:
		ToolStripMenuItem^ myProfileToolStripMenuItem;

	private:
		ToolStripMenuItem^ configVersionToolStripMenuItem;

	private:
		ToolStripMenuItem^ viewConfigToolStripMenuItem;

	private:
		ToolStripMenuItem^ seeCurrentVersionToolStripMenuItem;

	private:
		IContainer^ components;

	protected:

	protected:

	private:
		/// <summary>
		/// Required designer variable.
		/// </summary>


#pragma region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		void InitializeComponent(void)
		{
			this->components = (gcnew System::ComponentModel::Container());
			this->btnStartGame = (gcnew Button());
			this->ckbAutoStart = (gcnew CheckBox());
			this->ttAutoStart = (gcnew ToolTip(this->components));
			this->tbFPS = (gcnew TrackBar());
			this->labelFPS = (gcnew Label());
			this->inputFPS = (gcnew NumericUpDown());
			this->menuStrip1 = (gcnew MenuStrip());
			this->toolStripMenuItem = (gcnew ToolStripMenuItem());
			this->menuItemSettings = (gcnew ToolStripMenuItem());
			this->menuItemSetup = (gcnew ToolStripMenuItem());
			this->menuItemAbout = (gcnew ToolStripMenuItem());
			this->openToolStripMenuItem = (gcnew ToolStripMenuItem());
			this->genshinImpactModPackToolStripMenuItem = (gcnew ToolStripMenuItem());
			this->checkHzOfYourMonitorToolStripMenuItem = (gcnew ToolStripMenuItem());
			this->systemInformationToolStripMenuItem = (gcnew ToolStripMenuItem());
			this->dxDiaxToolStripMenuItem = (gcnew ToolStripMenuItem());
			this->configVersionToolStripMenuItem = (gcnew ToolStripMenuItem());
			this->viewConfigToolStripMenuItem = (gcnew ToolStripMenuItem());
			this->seeCurrentVersionToolStripMenuItem = (gcnew ToolStripMenuItem());
			this->linksToolStripMenuItem = (gcnew ToolStripMenuItem());
			this->officialWebsiteToolStripMenuItem = (gcnew ToolStripMenuItem());
			this->youTubeToolStripMenuItem = (gcnew ToolStripMenuItem());
			this->gitHubToolStripMenuItem = (gcnew ToolStripMenuItem());
			this->repositoriesToolStripMenuItem = (gcnew ToolStripMenuItem());
			this->genshinImpactReShade2023ToolStripMenuItem = (gcnew ToolStripMenuItem());
			this->genshinFPSUnlockToolStripMenuItem = (gcnew ToolStripMenuItem());
			this->myProfileToolStripMenuItem = (gcnew ToolStripMenuItem());
			this->ttGamePath = (gcnew ToolTip(this->components));
			this->notifyIcon = (gcnew NotifyIcon(this->components));
			this->contextMenuNotify = (gcnew Windows::Forms::ContextMenuStrip(this->components));
			this->toolStripMenuExit = (gcnew ToolStripMenuItem());
			(cli::safe_cast<ISupportInitialize^>(this->tbFPS))->BeginInit();
			(cli::safe_cast<ISupportInitialize^>(this->inputFPS))->BeginInit();
			this->menuStrip1->SuspendLayout();
			this->contextMenuNotify->SuspendLayout();
			this->SuspendLayout();
			// 
			// btnStartGame
			// 
			this->btnStartGame->BackColor = Color::Transparent;
			this->btnStartGame->Location = Point(209, 87);
			this->btnStartGame->Name = L"btnStartGame";
			this->btnStartGame->Size = Drawing::Size(75, 23);
			this->btnStartGame->TabIndex = 0;
			this->btnStartGame->TabStop = false;
			this->btnStartGame->Text = L"Start game";
			this->btnStartGame->UseVisualStyleBackColor = false;
			this->btnStartGame->Click += gcnew EventHandler(this, &MainForm::btnStartGame_Click);
			// 
			// ckbAutoStart
			// 
			this->ckbAutoStart->AutoSize = true;
			this->ckbAutoStart->BackColor = Color::Transparent;
			this->ckbAutoStart->ForeColor = Color::White;
			this->ckbAutoStart->Location = Point(12, 90);
			this->ckbAutoStart->Name = L"ckbAutoStart";
			this->ckbAutoStart->Size = Drawing::Size(141, 17);
			this->ckbAutoStart->TabIndex = 1;
			this->ckbAutoStart->TabStop = false;
			this->ckbAutoStart->Text = L"Start game automatically";
			this->ttAutoStart->SetToolTip(this->ckbAutoStart, L"This will take effect on subsequent launch");
			this->ckbAutoStart->UseVisualStyleBackColor = false;
			// 
			// ttAutoStart
			// 
			this->ttAutoStart->AutoPopDelay = 5000;
			this->ttAutoStart->InitialDelay = 1;
			this->ttAutoStart->ReshowDelay = 100;
			// 
			// tbFPS
			// 
			this->tbFPS->AutoSize = false;
			this->tbFPS->Cursor = Cursors::Hand;
			this->tbFPS->Location = Point(6, 64);
			this->tbFPS->Maximum = 365;
			this->tbFPS->Minimum = 12;
			this->tbFPS->Name = L"tbFPS";
			this->tbFPS->Size = Drawing::Size(283, 21);
			this->tbFPS->TabIndex = 2;
			this->tbFPS->TabStop = false;
			this->tbFPS->TickStyle = TickStyle::None;
			this->tbFPS->Value = 60;
			// 
			// labelFPS
			// 
			this->labelFPS->AutoSize = true;
			this->labelFPS->BackColor = Color::Transparent;
			this->labelFPS->ForeColor = Color::White;
			this->labelFPS->Location = Point(12, 40);
			this->labelFPS->Name = L"labelFPS";
			this->labelFPS->Size = Drawing::Size(47, 13);
			this->labelFPS->TabIndex = 3;
			this->labelFPS->Text = L"FPS limit";
			// 
			// inputFPS
			// 
			this->inputFPS->BackColor = Color::FromArgb(static_cast<Byte>(47), static_cast<Byte>(49),
			                                            static_cast<Byte>(54));
			this->inputFPS->ForeColor = Color::White;
			this->inputFPS->Location = Point(77, 37);
			this->inputFPS->Maximum = Decimal(gcnew array<Int32>(4){365, 0, 0, 0});
			this->inputFPS->Minimum = Decimal(gcnew array<Int32>(4){12, 0, 0, 0});
			this->inputFPS->Name = L"inputFPS";
			this->inputFPS->Size = Drawing::Size(207, 20);
			this->inputFPS->TabIndex = 4;
			this->inputFPS->TabStop = false;
			this->inputFPS->Value = Decimal(gcnew array<Int32>(4){60, 0, 0, 0});
			// 
			// menuStrip1
			// 
			this->menuStrip1->BackColor = Color::FromArgb(static_cast<Byte>(32), static_cast<Byte>(34),
			                                              static_cast<Byte>(37));
			this->menuStrip1->Items->AddRange(gcnew array<ToolStripItem^>(4){
				this->toolStripMenuItem,
				this->openToolStripMenuItem, this->configVersionToolStripMenuItem, this->linksToolStripMenuItem
			});
			this->menuStrip1->Location = Point(0, 0);
			this->menuStrip1->Name = L"menuStrip1";
			this->menuStrip1->Size = Drawing::Size(296, 24);
			this->menuStrip1->TabIndex = 5;
			this->menuStrip1->Text = L"menuStrip1";
			// 
			// toolStripMenuItem
			// 
			this->toolStripMenuItem->DropDownItems->AddRange(gcnew array<ToolStripItem^>(3){
				this->menuItemSettings,
				this->menuItemSetup, this->menuItemAbout
			});
			this->toolStripMenuItem->ForeColor = Color::White;
			this->toolStripMenuItem->Name = L"toolStripMenuItem";
			this->toolStripMenuItem->Size = Drawing::Size(61, 20);
			this->toolStripMenuItem->Text = L"Options";
			// 
			// menuItemSettings
			// 
			this->menuItemSettings->Name = L"menuItemSettings";
			this->menuItemSettings->Size = Drawing::Size(116, 22);
			this->menuItemSettings->Text = L"Settings";
			this->menuItemSettings->Click += gcnew EventHandler(this, &MainForm::settingsMenuItem_Click);
			// 
			// menuItemSetup
			// 
			this->menuItemSetup->Name = L"menuItemSetup";
			this->menuItemSetup->Size = Drawing::Size(116, 22);
			this->menuItemSetup->Text = L"Setup";
			this->menuItemSetup->Click += gcnew EventHandler(this, &MainForm::setupMenuItem_Click);
			// 
			// menuItemAbout
			// 
			this->menuItemAbout->Name = L"menuItemAbout";
			this->menuItemAbout->Size = Drawing::Size(116, 22);
			this->menuItemAbout->Text = L"About";
			this->menuItemAbout->Click += gcnew EventHandler(this, &MainForm::menuItemAbout_Click);
			// 
			// openToolStripMenuItem
			// 
			this->openToolStripMenuItem->DropDownItems->AddRange(gcnew array<ToolStripItem^>(2){
				this->genshinImpactModPackToolStripMenuItem,
				this->checkHzOfYourMonitorToolStripMenuItem
			});
			this->openToolStripMenuItem->ForeColor = Color::White;
			this->openToolStripMenuItem->Name = L"openToolStripMenuItem";
			this->openToolStripMenuItem->Size = Drawing::Size(48, 20);
			this->openToolStripMenuItem->Text = L"Open";
			// 
			// genshinImpactModPackToolStripMenuItem
			// 
			this->genshinImpactModPackToolStripMenuItem->Name = L"genshinImpactModPackToolStripMenuItem";
			this->genshinImpactModPackToolStripMenuItem->Size = Drawing::Size(211, 22);
			this->genshinImpactModPackToolStripMenuItem->Text = L"Genshin Stella Mod";
			this->genshinImpactModPackToolStripMenuItem->Click += gcnew EventHandler(this, &MainForm::mainApp_Click);
			// 
			// checkHzOfYourMonitorToolStripMenuItem
			// 
			this->checkHzOfYourMonitorToolStripMenuItem->DropDownItems->AddRange(gcnew array<ToolStripItem^>(2){
				this->systemInformationToolStripMenuItem,
				this->dxDiaxToolStripMenuItem
			});
			this->checkHzOfYourMonitorToolStripMenuItem->Name = L"checkHzOfYourMonitorToolStripMenuItem";
			this->checkHzOfYourMonitorToolStripMenuItem->Size = Drawing::Size(211, 22);
			this->checkHzOfYourMonitorToolStripMenuItem->Text = L"Check Hz of your monitor";
			// 
			// systemInformationToolStripMenuItem
			// 
			this->systemInformationToolStripMenuItem->Name = L"systemInformationToolStripMenuItem";
			this->systemInformationToolStripMenuItem->Size = Drawing::Size(178, 22);
			this->systemInformationToolStripMenuItem->Text = L"System Information";
			this->systemInformationToolStripMenuItem->Click += gcnew EventHandler(this, &MainForm::si_Click);
			// 
			// dxDiaxToolStripMenuItem
			// 
			this->dxDiaxToolStripMenuItem->Name = L"dxDiaxToolStripMenuItem";
			this->dxDiaxToolStripMenuItem->Size = Drawing::Size(178, 22);
			this->dxDiaxToolStripMenuItem->Text = L"DxDiax";
			this->dxDiaxToolStripMenuItem->Click += gcnew EventHandler(this, &MainForm::dxdiag_Click);
			// 
			// configVersionToolStripMenuItem
			// 
			this->configVersionToolStripMenuItem->DropDownItems->AddRange(gcnew array<ToolStripItem^>(2){
				this->viewConfigToolStripMenuItem,
				this->seeCurrentVersionToolStripMenuItem
			});
			this->configVersionToolStripMenuItem->ForeColor = Color::White;
			this->configVersionToolStripMenuItem->Name = L"configVersionToolStripMenuItem";
			this->configVersionToolStripMenuItem->Size = Drawing::Size(55, 20);
			this->configVersionToolStripMenuItem->Text = L"Config";
			// 
			// viewConfigToolStripMenuItem
			// 
			this->viewConfigToolStripMenuItem->Name = L"viewConfigToolStripMenuItem";
			this->viewConfigToolStripMenuItem->Size = Drawing::Size(174, 22);
			this->viewConfigToolStripMenuItem->Text = L"View config";
			this->viewConfigToolStripMenuItem->Click += gcnew EventHandler(this, &MainForm::viewCfg_Click);
			// 
			// seeCurrentVersionToolStripMenuItem
			// 
			this->seeCurrentVersionToolStripMenuItem->Name = L"seeCurrentVersionToolStripMenuItem";
			this->seeCurrentVersionToolStripMenuItem->Size = Drawing::Size(174, 22);
			this->seeCurrentVersionToolStripMenuItem->Text = L"See current version";
			this->seeCurrentVersionToolStripMenuItem->Click += gcnew EventHandler(
				this, &MainForm::seeCurrentVersion_Click);
			// 
			// linksToolStripMenuItem
			// 
			this->linksToolStripMenuItem->DropDownItems->AddRange(gcnew array<ToolStripItem^>(3){
				this->officialWebsiteToolStripMenuItem,
				this->youTubeToolStripMenuItem, this->gitHubToolStripMenuItem
			});
			this->linksToolStripMenuItem->ForeColor = Color::White;
			this->linksToolStripMenuItem->Name = L"linksToolStripMenuItem";
			this->linksToolStripMenuItem->Size = Drawing::Size(46, 20);
			this->linksToolStripMenuItem->Text = L"Links";
			// 
			// officialWebsiteToolStripMenuItem
			// 
			this->officialWebsiteToolStripMenuItem->Name = L"officialWebsiteToolStripMenuItem";
			this->officialWebsiteToolStripMenuItem->Size = Drawing::Size(155, 22);
			this->officialWebsiteToolStripMenuItem->Text = L"Official website";
			this->officialWebsiteToolStripMenuItem->Click += gcnew EventHandler(this, &MainForm::officialWebsite_Click);
			// 
			// youTubeToolStripMenuItem
			// 
			this->youTubeToolStripMenuItem->Name = L"youTubeToolStripMenuItem";
			this->youTubeToolStripMenuItem->Size = Drawing::Size(155, 22);
			this->youTubeToolStripMenuItem->Text = L"YouTube";
			this->youTubeToolStripMenuItem->Click += gcnew EventHandler(this, &MainForm::youtube_Click);
			// 
			// gitHubToolStripMenuItem
			// 
			this->gitHubToolStripMenuItem->DropDownItems->AddRange(gcnew array<ToolStripItem^>(2){
				this->repositoriesToolStripMenuItem,
				this->myProfileToolStripMenuItem
			});
			this->gitHubToolStripMenuItem->Name = L"gitHubToolStripMenuItem";
			this->gitHubToolStripMenuItem->Size = Drawing::Size(155, 22);
			this->gitHubToolStripMenuItem->Text = L"GitHub";
			// 
			// repositoriesToolStripMenuItem
			// 
			this->repositoriesToolStripMenuItem->DropDownItems->AddRange(gcnew array<ToolStripItem^>(2){
				this->genshinImpactReShade2023ToolStripMenuItem,
				this->genshinFPSUnlockToolStripMenuItem
			});
			this->repositoriesToolStripMenuItem->Name = L"repositoriesToolStripMenuItem";
			this->repositoriesToolStripMenuItem->Size = Drawing::Size(138, 22);
			this->repositoriesToolStripMenuItem->Text = L"Repositories";
			// 
			// genshinImpactReShade2023ToolStripMenuItem
			// 
			this->genshinImpactReShade2023ToolStripMenuItem->Name = L"genshinImpactReShade2023ToolStripMenuItem";
			this->genshinImpactReShade2023ToolStripMenuItem->Size = Drawing::Size(205, 22);
			this->genshinImpactReShade2023ToolStripMenuItem->Text = L"Genshin Impact ReShade";
			this->genshinImpactReShade2023ToolStripMenuItem->Click += gcnew EventHandler(
				this, &MainForm::githubMainRepo_Click);
			// 
			// genshinFPSUnlockToolStripMenuItem
			// 
			this->genshinFPSUnlockToolStripMenuItem->Name = L"genshinFPSUnlockToolStripMenuItem";
			this->genshinFPSUnlockToolStripMenuItem->Size = Drawing::Size(205, 22);
			this->genshinFPSUnlockToolStripMenuItem->Text = L"Genshin FPS Unlock";
			this->genshinFPSUnlockToolStripMenuItem->Click += gcnew
				EventHandler(this, &MainForm::githubFpsUnlock_Click);
			// 
			// myProfileToolStripMenuItem
			// 
			this->myProfileToolStripMenuItem->Name = L"myProfileToolStripMenuItem";
			this->myProfileToolStripMenuItem->Size = Drawing::Size(138, 22);
			this->myProfileToolStripMenuItem->Text = L"My profile";
			this->myProfileToolStripMenuItem->Click += gcnew EventHandler(this, &MainForm::githubMyProfile_Click);
			// 
			// ttGamePath
			// 
			this->ttGamePath->AutoPopDelay = 5000;
			this->ttGamePath->InitialDelay = 2;
			this->ttGamePath->ReshowDelay = 100;
			// 
			// notifyIcon
			// 
			this->notifyIcon->BalloonTipIcon = ToolTipIcon::Info;
			this->notifyIcon->BalloonTipText = L"Minimized to tray";
			this->notifyIcon->BalloonTipTitle = L"FPS Unlocker";
			this->notifyIcon->ContextMenuStrip = this->contextMenuNotify;
			this->notifyIcon->Text = L"Hello";
			this->notifyIcon->Visible = true;
			// 
			// contextMenuNotify
			// 
			this->contextMenuNotify->Items->AddRange(gcnew array<ToolStripItem^>(1){this->toolStripMenuExit});
			this->contextMenuNotify->Name = L"contextMenuNotify";
			this->contextMenuNotify->ShowItemToolTips = false;
			this->contextMenuNotify->Size = Drawing::Size(94, 26);
			// 
			// toolStripMenuExit
			// 
			this->toolStripMenuExit->Name = L"toolStripMenuExit";
			this->toolStripMenuExit->Size = Drawing::Size(93, 22);
			this->toolStripMenuExit->Text = L"Exit";
			this->toolStripMenuExit->Click += gcnew EventHandler(this, &MainForm::toolStripMenuExit_Click);
			// 
			// MainForm
			// 
			this->AutoScaleDimensions = SizeF(6, 13);
			this->AutoScaleMode = Windows::Forms::AutoScaleMode::Font;
			this->BackColor = Color::FromArgb(static_cast<Byte>(54), static_cast<Byte>(57),
			                                  static_cast<Byte>(63));
			this->ClientSize = Drawing::Size(296, 122);
			this->Controls->Add(this->inputFPS);
			this->Controls->Add(this->labelFPS);
			this->Controls->Add(this->tbFPS);
			this->Controls->Add(this->ckbAutoStart);
			this->Controls->Add(this->btnStartGame);
			this->Controls->Add(this->menuStrip1);
			this->FormBorderStyle = Windows::Forms::FormBorderStyle::FixedSingle;
			this->MainMenuStrip = this->menuStrip1;
			this->MaximizeBox = false;
			this->Name = L"MainForm";
			this->SizeGripStyle = Windows::Forms::SizeGripStyle::Hide;
			this->StartPosition = FormStartPosition::CenterScreen;
			this->Text = L"Genshin FPS Unlocker";
			(cli::safe_cast<ISupportInitialize^>(this->tbFPS))->EndInit();
			(cli::safe_cast<ISupportInitialize^>(this->inputFPS))->EndInit();
			this->menuStrip1->ResumeLayout(false);
			this->menuStrip1->PerformLayout();
			this->contextMenuNotify->ResumeLayout(false);
			this->ResumeLayout(false);
			this->PerformLayout();
		}
#pragma endregion

	private:
		Void btnStartGame_Click(Object^ sender, EventArgs^ e);

	private:
		Void settingsMenuItem_Click(Object^ sender, EventArgs^ e);

	private:
		Void OnLoad(Object^ sender, EventArgs^ e);

	private:
		Void setupMenuItem_Click(Object^ sender, EventArgs^ e);

	private:
		Void OnDoWork(Object^ sender, DoWorkEventArgs^ e);

	private:
		Void OnProgressChanged(Object^ sender, ProgressChangedEventArgs^ e);

	private:
		Void OnResize(Object^ sender, EventArgs^ e);

	private:
		Void OnDoubleClick(Object^ sender, EventArgs^ e);

	private:
		Void toolStripMenuExit_Click(Object^ sender, EventArgs^ e);

	private:
		Void OnFormClosing(Object^ sender, FormClosingEventArgs^ e);

	private:
		Void menuItemAbout_Click(Object^ sender, EventArgs^ e);

	private:
		Void mainApp_Click(Object^ sender, EventArgs^ e);

	private:
		Void si_Click(Object^ sender, EventArgs^ e);

	private:
		Void dxdiag_Click(Object^ sender, EventArgs^ e);

	private:
		Void githubMainRepo_Click(Object^ sender, EventArgs^ e);

	private:
		Void githubFpsUnlock_Click(Object^ sender, EventArgs^ e);

	private:
		Void githubMyProfile_Click(Object^ sender, EventArgs^ e);

	private:
		Void officialWebsite_Click(Object^ sender, EventArgs^ e);

	private:
		Void youtube_Click(Object^ sender, EventArgs^ e);
		// private: Void ToolStipMenu_MouseEnter(Object^ sender, EventArgs^ e);
	private:
		Void viewCfg_Click(Object^ sender, EventArgs^ e);

	private:
		Void seeCurrentVersion_Click(Object^ sender, EventArgs^ e);
	};
}
