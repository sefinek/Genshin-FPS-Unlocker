#pragma once
#include "Settings.h"
#include "SetupForm.h"
#include "SettingsForm.h"
#include <algorithm>

namespace unlockfpsclr
{
	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;

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
		System::Windows::Forms::Button^ btnStartGame;

	private:
		System::Windows::Forms::CheckBox^ ckbAutoStart;

	private:
		System::Windows::Forms::ToolTip^ ttAutoStart;

	private:
		System::Windows::Forms::TrackBar^ tbFPS;

	private:
		System::Windows::Forms::Label^ labelFPS;

	private:
		System::Windows::Forms::NumericUpDown^ inputFPS;

	private:
		System::Windows::Forms::MenuStrip^ menuStrip1;

	private:
		System::Windows::Forms::ToolStripMenuItem^ toolStripMenuItem;

	private:
		System::Windows::Forms::ToolStripMenuItem^ menuItemSettings;

	private:
		System::Windows::Forms::ToolTip^ ttGamePath;

	private:
		System::Windows::Forms::ToolStripMenuItem^ menuItemSetup;

	private:
		System::Windows::Forms::NotifyIcon^ notifyIcon;

	private:
		System::Windows::Forms::ContextMenuStrip^ contextMenuNotify;

	private:
		System::Windows::Forms::ToolStripMenuItem^ toolStripMenuExit;

	private:
		System::Windows::Forms::ToolStripMenuItem^ menuItemAbout;

	private:
		System::Windows::Forms::ToolStripMenuItem^ openToolStripMenuItem;

	private:
		System::Windows::Forms::ToolStripMenuItem^ genshinImpactModPackToolStripMenuItem;

	private:
		System::Windows::Forms::ToolStripMenuItem^ checkHzOfYourMonitorToolStripMenuItem;

	private:
		System::Windows::Forms::ToolStripMenuItem^ systemInformationToolStripMenuItem;

	private:
		System::Windows::Forms::ToolStripMenuItem^ dxDiaxToolStripMenuItem;

	private:
		System::Windows::Forms::ToolStripMenuItem^ linksToolStripMenuItem;

	private:
		System::Windows::Forms::ToolStripMenuItem^ officialWebsiteToolStripMenuItem;

	private:
		System::Windows::Forms::ToolStripMenuItem^ youTubeToolStripMenuItem;

	private:
		System::Windows::Forms::ToolStripMenuItem^ gitHubToolStripMenuItem;

	private:
		System::Windows::Forms::ToolStripMenuItem^ repositoriesToolStripMenuItem;

	private:
		System::Windows::Forms::ToolStripMenuItem^ genshinImpactReShade2023ToolStripMenuItem;

	private:
		System::Windows::Forms::ToolStripMenuItem^ genshinFPSUnlockToolStripMenuItem;

	private:
		System::Windows::Forms::ToolStripMenuItem^ myProfileToolStripMenuItem;

	private:
		System::Windows::Forms::ToolStripMenuItem^ configVersionToolStripMenuItem;

	private:
		System::Windows::Forms::ToolStripMenuItem^ viewConfigToolStripMenuItem;

	private:
		System::Windows::Forms::ToolStripMenuItem^ seeCurrentVersionToolStripMenuItem;

	private:
		System::ComponentModel::IContainer^ components;

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
			this->btnStartGame = (gcnew System::Windows::Forms::Button());
			this->ckbAutoStart = (gcnew System::Windows::Forms::CheckBox());
			this->ttAutoStart = (gcnew System::Windows::Forms::ToolTip(this->components));
			this->tbFPS = (gcnew System::Windows::Forms::TrackBar());
			this->labelFPS = (gcnew System::Windows::Forms::Label());
			this->inputFPS = (gcnew System::Windows::Forms::NumericUpDown());
			this->menuStrip1 = (gcnew System::Windows::Forms::MenuStrip());
			this->toolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->menuItemSettings = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->menuItemSetup = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->menuItemAbout = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->openToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->genshinImpactModPackToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->checkHzOfYourMonitorToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->systemInformationToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->dxDiaxToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->configVersionToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->viewConfigToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->seeCurrentVersionToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->linksToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->officialWebsiteToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->youTubeToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->gitHubToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->repositoriesToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->genshinImpactReShade2023ToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->genshinFPSUnlockToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->myProfileToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->ttGamePath = (gcnew System::Windows::Forms::ToolTip(this->components));
			this->notifyIcon = (gcnew System::Windows::Forms::NotifyIcon(this->components));
			this->contextMenuNotify = (gcnew System::Windows::Forms::ContextMenuStrip(this->components));
			this->toolStripMenuExit = (gcnew System::Windows::Forms::ToolStripMenuItem());
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->tbFPS))->BeginInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->inputFPS))->BeginInit();
			this->menuStrip1->SuspendLayout();
			this->contextMenuNotify->SuspendLayout();
			this->SuspendLayout();
			// 
			// btnStartGame
			// 
			this->btnStartGame->Anchor = System::Windows::Forms::AnchorStyles::None;
			this->btnStartGame->BackColor = System::Drawing::Color::Transparent;
			this->btnStartGame->Location = System::Drawing::Point(225, 89);
			this->btnStartGame->Name = L"btnStartGame";
			this->btnStartGame->Size = System::Drawing::Size(75, 23);
			this->btnStartGame->TabIndex = 0;
			this->btnStartGame->TabStop = false;
			this->btnStartGame->Text = L"Start game";
			this->btnStartGame->UseVisualStyleBackColor = false;
			this->btnStartGame->Click += gcnew System::EventHandler(this, &MainForm::btnStartGame_Click);
			// 
			// ckbAutoStart
			// 
			this->ckbAutoStart->Anchor = System::Windows::Forms::AnchorStyles::None;
			this->ckbAutoStart->AutoSize = true;
			this->ckbAutoStart->BackColor = System::Drawing::Color::Transparent;
			this->ckbAutoStart->ForeColor = System::Drawing::Color::White;
			this->ckbAutoStart->Location = System::Drawing::Point(12, 93);
			this->ckbAutoStart->Name = L"ckbAutoStart";
			this->ckbAutoStart->Size = System::Drawing::Size(141, 17);
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
			this->tbFPS->Anchor = System::Windows::Forms::AnchorStyles::None;
			this->tbFPS->AutoSize = false;
			this->tbFPS->Cursor = System::Windows::Forms::Cursors::Hand;
			this->tbFPS->Location = System::Drawing::Point(12, 66);
			this->tbFPS->Maximum = 365;
			this->tbFPS->Minimum = 12;
			this->tbFPS->Name = L"tbFPS";
			this->tbFPS->Size = System::Drawing::Size(288, 21);
			this->tbFPS->TabIndex = 2;
			this->tbFPS->TabStop = false;
			this->tbFPS->TickStyle = System::Windows::Forms::TickStyle::None;
			this->tbFPS->Value = 60;
			// 
			// labelFPS
			// 
			this->labelFPS->Anchor = System::Windows::Forms::AnchorStyles::None;
			this->labelFPS->AutoSize = true;
			this->labelFPS->BackColor = System::Drawing::Color::Transparent;
			this->labelFPS->ForeColor = System::Drawing::Color::White;
			this->labelFPS->Location = System::Drawing::Point(17, 42);
			this->labelFPS->Name = L"labelFPS";
			this->labelFPS->Size = System::Drawing::Size(47, 13);
			this->labelFPS->TabIndex = 3;
			this->labelFPS->Text = L"FPS limit";
			// 
			// inputFPS
			// 
			this->inputFPS->Anchor = System::Windows::Forms::AnchorStyles::None;
			this->inputFPS->BackColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(47)), static_cast<System::Int32>(static_cast<System::Byte>(49)),
			                                                             static_cast<System::Int32>(static_cast<System::Byte>(54)));
			this->inputFPS->ForeColor = System::Drawing::Color::White;
			this->inputFPS->Location = System::Drawing::Point(81, 39);
			this->inputFPS->Maximum = System::Decimal(gcnew cli::array<System::Int32>(4){365, 0, 0, 0});
			this->inputFPS->Minimum = System::Decimal(gcnew cli::array<System::Int32>(4){12, 0, 0, 0});
			this->inputFPS->Name = L"inputFPS";
			this->inputFPS->Size = System::Drawing::Size(212, 20);
			this->inputFPS->TabIndex = 4;
			this->inputFPS->TabStop = false;
			this->inputFPS->Value = System::Decimal(gcnew cli::array<System::Int32>(4){60, 0, 0, 0});
			// 
			// menuStrip1
			// 
			this->menuStrip1->BackColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(32)), static_cast<System::Int32>(static_cast<System::Byte>(34)),
			                                                               static_cast<System::Int32>(static_cast<System::Byte>(37)));
			this->menuStrip1->Items->AddRange(gcnew cli::array<System::Windows::Forms::ToolStripItem^>(4){
				this->toolStripMenuItem,
				this->openToolStripMenuItem, this->configVersionToolStripMenuItem, this->linksToolStripMenuItem
			});
			this->menuStrip1->Location = System::Drawing::Point(0, 0);
			this->menuStrip1->Name = L"menuStrip1";
			this->menuStrip1->Size = System::Drawing::Size(312, 24);
			this->menuStrip1->TabIndex = 5;
			this->menuStrip1->Text = L"menuStrip1";
			// 
			// toolStripMenuItem
			// 
			this->toolStripMenuItem->DropDownItems->AddRange(gcnew cli::array<System::Windows::Forms::ToolStripItem^>(3){
				this->menuItemSettings,
				this->menuItemSetup, this->menuItemAbout
			});
			this->toolStripMenuItem->ForeColor = System::Drawing::Color::DimGray;
			this->toolStripMenuItem->Name = L"toolStripMenuItem";
			this->toolStripMenuItem->Size = System::Drawing::Size(61, 20);
			this->toolStripMenuItem->Text = L"Options";
			// 
			// menuItemSettings
			// 
			this->menuItemSettings->Name = L"menuItemSettings";
			this->menuItemSettings->Size = System::Drawing::Size(116, 22);
			this->menuItemSettings->Text = L"Settings";
			this->menuItemSettings->Click += gcnew System::EventHandler(this, &MainForm::settingsMenuItem_Click);
			// 
			// menuItemSetup
			// 
			this->menuItemSetup->Name = L"menuItemSetup";
			this->menuItemSetup->Size = System::Drawing::Size(116, 22);
			this->menuItemSetup->Text = L"Setup";
			this->menuItemSetup->Click += gcnew System::EventHandler(this, &MainForm::setupMenuItem_Click);
			// 
			// menuItemAbout
			// 
			this->menuItemAbout->Name = L"menuItemAbout";
			this->menuItemAbout->Size = System::Drawing::Size(116, 22);
			this->menuItemAbout->Text = L"About";
			this->menuItemAbout->Click += gcnew System::EventHandler(this, &MainForm::menuItemAbout_Click);
			// 
			// openToolStripMenuItem
			// 
			this->openToolStripMenuItem->DropDownItems->AddRange(gcnew cli::array<System::Windows::Forms::ToolStripItem^>(2){
				this->genshinImpactModPackToolStripMenuItem,
				this->checkHzOfYourMonitorToolStripMenuItem
			});
			this->openToolStripMenuItem->ForeColor = System::Drawing::Color::DimGray;
			this->openToolStripMenuItem->Name = L"openToolStripMenuItem";
			this->openToolStripMenuItem->Size = System::Drawing::Size(48, 20);
			this->openToolStripMenuItem->Text = L"Open";
			// 
			// genshinImpactModPackToolStripMenuItem
			// 
			this->genshinImpactModPackToolStripMenuItem->Name = L"genshinImpactModPackToolStripMenuItem";
			this->genshinImpactModPackToolStripMenuItem->Size = System::Drawing::Size(211, 22);
			this->genshinImpactModPackToolStripMenuItem->Text = L"Stella Mod Launcher";
			this->genshinImpactModPackToolStripMenuItem->Click += gcnew System::EventHandler(this, &MainForm::mainApp_Click);
			// 
			// checkHzOfYourMonitorToolStripMenuItem
			// 
			this->checkHzOfYourMonitorToolStripMenuItem->DropDownItems->AddRange(gcnew cli::array<System::Windows::Forms::ToolStripItem^>(2){
				this->systemInformationToolStripMenuItem,
				this->dxDiaxToolStripMenuItem
			});
			this->checkHzOfYourMonitorToolStripMenuItem->Name = L"checkHzOfYourMonitorToolStripMenuItem";
			this->checkHzOfYourMonitorToolStripMenuItem->Size = System::Drawing::Size(211, 22);
			this->checkHzOfYourMonitorToolStripMenuItem->Text = L"Check Hz of your monitor";
			// 
			// systemInformationToolStripMenuItem
			// 
			this->systemInformationToolStripMenuItem->Name = L"systemInformationToolStripMenuItem";
			this->systemInformationToolStripMenuItem->Size = System::Drawing::Size(178, 22);
			this->systemInformationToolStripMenuItem->Text = L"System Information";
			this->systemInformationToolStripMenuItem->Click += gcnew System::EventHandler(this, &MainForm::si_Click);
			// 
			// dxDiaxToolStripMenuItem
			// 
			this->dxDiaxToolStripMenuItem->Name = L"dxDiaxToolStripMenuItem";
			this->dxDiaxToolStripMenuItem->Size = System::Drawing::Size(178, 22);
			this->dxDiaxToolStripMenuItem->Text = L"DxDiax";
			this->dxDiaxToolStripMenuItem->Click += gcnew System::EventHandler(this, &MainForm::dxdiag_Click);
			// 
			// configVersionToolStripMenuItem
			// 
			this->configVersionToolStripMenuItem->DropDownItems->AddRange(gcnew cli::array<System::Windows::Forms::ToolStripItem^>(2){
				this->viewConfigToolStripMenuItem,
				this->seeCurrentVersionToolStripMenuItem
			});
			this->configVersionToolStripMenuItem->ForeColor = System::Drawing::Color::DimGray;
			this->configVersionToolStripMenuItem->Name = L"configVersionToolStripMenuItem";
			this->configVersionToolStripMenuItem->Size = System::Drawing::Size(55, 20);
			this->configVersionToolStripMenuItem->Text = L"Config";
			// 
			// viewConfigToolStripMenuItem
			// 
			this->viewConfigToolStripMenuItem->Name = L"viewConfigToolStripMenuItem";
			this->viewConfigToolStripMenuItem->Size = System::Drawing::Size(180, 22);
			this->viewConfigToolStripMenuItem->Text = L"View config";
			this->viewConfigToolStripMenuItem->Click += gcnew System::EventHandler(this, &MainForm::viewCfg_Click);
			// 
			// seeCurrentVersionToolStripMenuItem
			// 
			this->seeCurrentVersionToolStripMenuItem->Name = L"seeCurrentVersionToolStripMenuItem";
			this->seeCurrentVersionToolStripMenuItem->Size = System::Drawing::Size(180, 22);
			this->seeCurrentVersionToolStripMenuItem->Text = L"See current version";
			this->seeCurrentVersionToolStripMenuItem->Click += gcnew System::EventHandler(this, &MainForm::seeCurrentVersion_Click);
			// 
			// linksToolStripMenuItem
			// 
			this->linksToolStripMenuItem->DropDownItems->AddRange(gcnew cli::array<System::Windows::Forms::ToolStripItem^>(3){
				this->officialWebsiteToolStripMenuItem,
				this->youTubeToolStripMenuItem, this->gitHubToolStripMenuItem
			});
			this->linksToolStripMenuItem->ForeColor = System::Drawing::Color::DimGray;
			this->linksToolStripMenuItem->Name = L"linksToolStripMenuItem";
			this->linksToolStripMenuItem->Size = System::Drawing::Size(46, 20);
			this->linksToolStripMenuItem->Text = L"Links";
			// 
			// officialWebsiteToolStripMenuItem
			// 
			this->officialWebsiteToolStripMenuItem->Name = L"officialWebsiteToolStripMenuItem";
			this->officialWebsiteToolStripMenuItem->Size = System::Drawing::Size(155, 22);
			this->officialWebsiteToolStripMenuItem->Text = L"Official website";
			this->officialWebsiteToolStripMenuItem->Click += gcnew System::EventHandler(this, &MainForm::officialWebsite_Click);
			// 
			// youTubeToolStripMenuItem
			// 
			this->youTubeToolStripMenuItem->Name = L"youTubeToolStripMenuItem";
			this->youTubeToolStripMenuItem->Size = System::Drawing::Size(155, 22);
			this->youTubeToolStripMenuItem->Text = L"YouTube";
			this->youTubeToolStripMenuItem->Click += gcnew System::EventHandler(this, &MainForm::youtube_Click);
			// 
			// gitHubToolStripMenuItem
			// 
			this->gitHubToolStripMenuItem->DropDownItems->AddRange(gcnew cli::array<System::Windows::Forms::ToolStripItem^>(2){
				this->repositoriesToolStripMenuItem,
				this->myProfileToolStripMenuItem
			});
			this->gitHubToolStripMenuItem->Name = L"gitHubToolStripMenuItem";
			this->gitHubToolStripMenuItem->Size = System::Drawing::Size(155, 22);
			this->gitHubToolStripMenuItem->Text = L"GitHub";
			// 
			// repositoriesToolStripMenuItem
			// 
			this->repositoriesToolStripMenuItem->DropDownItems->AddRange(gcnew cli::array<System::Windows::Forms::ToolStripItem^>(2){
				this->genshinImpactReShade2023ToolStripMenuItem,
				this->genshinFPSUnlockToolStripMenuItem
			});
			this->repositoriesToolStripMenuItem->Name = L"repositoriesToolStripMenuItem";
			this->repositoriesToolStripMenuItem->Size = System::Drawing::Size(138, 22);
			this->repositoriesToolStripMenuItem->Text = L"Repositories";
			// 
			// genshinImpactReShade2023ToolStripMenuItem
			// 
			this->genshinImpactReShade2023ToolStripMenuItem->Name = L"genshinImpactReShade2023ToolStripMenuItem";
			this->genshinImpactReShade2023ToolStripMenuItem->Size = System::Drawing::Size(205, 22);
			this->genshinImpactReShade2023ToolStripMenuItem->Text = L"Genshin Impact ReShade";
			this->genshinImpactReShade2023ToolStripMenuItem->Click += gcnew System::EventHandler(this, &MainForm::githubMainRepo_Click);
			// 
			// genshinFPSUnlockToolStripMenuItem
			// 
			this->genshinFPSUnlockToolStripMenuItem->Name = L"genshinFPSUnlockToolStripMenuItem";
			this->genshinFPSUnlockToolStripMenuItem->Size = System::Drawing::Size(205, 22);
			this->genshinFPSUnlockToolStripMenuItem->Text = L"Genshin FPS Unlock";
			this->genshinFPSUnlockToolStripMenuItem->Click += gcnew System::EventHandler(this, &MainForm::githubFpsUnlock_Click);
			// 
			// myProfileToolStripMenuItem
			// 
			this->myProfileToolStripMenuItem->Name = L"myProfileToolStripMenuItem";
			this->myProfileToolStripMenuItem->Size = System::Drawing::Size(138, 22);
			this->myProfileToolStripMenuItem->Text = L"My profile";
			this->myProfileToolStripMenuItem->Click += gcnew System::EventHandler(this, &MainForm::githubMyProfile_Click);
			// 
			// ttGamePath
			// 
			this->ttGamePath->AutoPopDelay = 5000;
			this->ttGamePath->InitialDelay = 2;
			this->ttGamePath->ReshowDelay = 100;
			// 
			// notifyIcon
			// 
			this->notifyIcon->BalloonTipIcon = System::Windows::Forms::ToolTipIcon::Info;
			this->notifyIcon->BalloonTipText = L"Minimized to tray";
			this->notifyIcon->BalloonTipTitle = L"FPS Unlocker";
			this->notifyIcon->ContextMenuStrip = this->contextMenuNotify;
			this->notifyIcon->Text = L"Hello";
			this->notifyIcon->Visible = true;
			// 
			// contextMenuNotify
			// 
			this->contextMenuNotify->Items->AddRange(gcnew cli::array<System::Windows::Forms::ToolStripItem^>(1){this->toolStripMenuExit});
			this->contextMenuNotify->Name = L"contextMenuNotify";
			this->contextMenuNotify->ShowItemToolTips = false;
			this->contextMenuNotify->Size = System::Drawing::Size(94, 26);
			// 
			// toolStripMenuExit
			// 
			this->toolStripMenuExit->Name = L"toolStripMenuExit";
			this->toolStripMenuExit->Size = System::Drawing::Size(93, 22);
			this->toolStripMenuExit->Text = L"Exit";
			this->toolStripMenuExit->Click += gcnew System::EventHandler(this, &MainForm::toolStripMenuExit_Click);
			// 
			// MainForm
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->BackColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(54)), static_cast<System::Int32>(static_cast<System::Byte>(57)),
			                                                   static_cast<System::Int32>(static_cast<System::Byte>(63)));
			this->ClientSize = System::Drawing::Size(312, 122);
			this->Controls->Add(this->inputFPS);
			this->Controls->Add(this->labelFPS);
			this->Controls->Add(this->tbFPS);
			this->Controls->Add(this->ckbAutoStart);
			this->Controls->Add(this->btnStartGame);
			this->Controls->Add(this->menuStrip1);
			this->FormBorderStyle = System::Windows::Forms::FormBorderStyle::FixedSingle;
			this->MainMenuStrip = this->menuStrip1;
			this->MaximizeBox = false;
			this->Name = L"MainForm";
			this->SizeGripStyle = System::Windows::Forms::SizeGripStyle::Hide;
			this->StartPosition = System::Windows::Forms::FormStartPosition::CenterScreen;
			this->Text = L"Genshin FPS Unlocker";
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->tbFPS))->EndInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->inputFPS))->EndInit();
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
