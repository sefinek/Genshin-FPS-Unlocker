#pragma once
#include "Settings.h"
#include <algorithm>

namespace unlockfpsclr
{
	using namespace System;
	using namespace ComponentModel;
	using namespace Collections;
	using namespace Windows::Forms;
	using namespace Data;
	using namespace Drawing;
	using namespace Generic;

	/// <summary>
	/// Summary for SettingsForm
	/// </summary>
	public ref class SettingsForm : public Form
	{
	public:
		SettingsForm(Settings^ settings)
		{
			InitializeComponent();

			this->ckbVSync->DataBindings->Add("Checked", settings, "AutoDisableVSync", false,
			                                  DataSourceUpdateMode::OnPropertyChanged);
			this->ckbPopupWnd->DataBindings->Add("Checked", settings, "PopupWindow", false,
			                                     DataSourceUpdateMode::OnPropertyChanged);
			this->ckbFullscreen->DataBindings->Add("Checked", settings, "Fullscreen", false,
			                                       DataSourceUpdateMode::OnPropertyChanged);
			this->ckbCustomRes->DataBindings->Add("Checked", settings, "UseCustomRes", false,
			                                      DataSourceUpdateMode::OnPropertyChanged);
			this->ckbStartMinimized->DataBindings->Add("Checked", settings, "StartMinimized", false,
			                                           DataSourceUpdateMode::OnPropertyChanged);
			this->ckbAutoClose->DataBindings->Add("Checked", settings, "AutoClose", false,
			                                      DataSourceUpdateMode::OnPropertyChanged);
			this->ckbPowerSave->DataBindings->Add("Checked", settings, "UsePowerSave", false,
			                                      DataSourceUpdateMode::OnPropertyChanged);

			//this->customResX->DataBindings->Add("Value", settings, "CustomResX");
			//this->customResY->DataBindings->Add("Value", settings, "CustomResY");
			//this->monitorNum->DataBindings->Add("Value", settings, "MonitorNum");
			//this->comboWindowMode->DataBindings->Add("SelectedIndex", settings, "IsExclusiveFullscreen");
			//this->comboPriority->DataBindings->Add("SelectedIndex", settings, "Priority");

			/*auto bindingSource = gcnew BindingSource();
			bindingSource->DataSource = settings->DllList;
			bindingSource->AllowNew = true;
			this->lbDllList->DataSource = bindingSource;*/
			this->lbDllList->Format += gcnew ListControlConvertEventHandler(this, &SettingsForm::OnFormat);

			this->settings = settings;
			this->Load += gcnew EventHandler(this, &SettingsForm::OnLoad);
			this->FormClosing += gcnew FormClosingEventHandler(this, &SettingsForm::UpdateSettings);
		}

	protected:
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		~SettingsForm()
		{
			if (components)
			{
				delete components;
			}
		}

	private:
		Settings^ settings;

	private:
		Label^ labelAutoSave;

	private:
		TabControl^ tabControl;

	private:
		TabPage^ tabPageGeneral;

	private:
		CheckBox^ ckbVSync;

	private:
		TabPage^ tabPageLaunchOptions;

	private:
		NumericUpDown^ customResX;

	private:
		Label^ labelCustomRes;

	private:
		CheckBox^ ckbCustomRes;

	private:
		CheckBox^ ckbFullscreen;

	private:
		CheckBox^ ckbPopupWnd;

	private:
		NumericUpDown^ customResY;

	private:
		Label^ labelDummy;

	private:
		ComboBox^ comboWindowMode;

	private:
		Label^ labelWindowMode;

	private:
		ToolTip^ toolTip;

	private:
		CheckBox^ ckbStartMinimized;

	private:
		CheckBox^ ckbAutoClose;

	private:
		NumericUpDown^ monitorNum;

	private:
		Label^ labelMonitorNum;

	private:
		TabPage^ tabPageDLLs;

	private:
		Button^ btnDllRemove;

	private:
		Button^ btnDllAdd;

	private:
		ListBox^ lbDllList;

	private:
		Label^ labelDLLMessage;

	private:
		ComboBox^ comboPriority;

	private:
		Label^ labelPriority;

	private:
		CheckBox^ ckbPowerSave;

	private:
		IContainer^ components;

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
			this->labelAutoSave = (gcnew Label());
			this->tabControl = (gcnew TabControl());
			this->tabPageGeneral = (gcnew TabPage());
			this->comboPriority = (gcnew ComboBox());
			this->labelPriority = (gcnew Label());
			this->ckbPowerSave = (gcnew CheckBox());
			this->ckbAutoClose = (gcnew CheckBox());
			this->ckbStartMinimized = (gcnew CheckBox());
			this->ckbVSync = (gcnew CheckBox());
			this->tabPageLaunchOptions = (gcnew TabPage());
			this->monitorNum = (gcnew NumericUpDown());
			this->labelMonitorNum = (gcnew Label());
			this->comboWindowMode = (gcnew ComboBox());
			this->labelWindowMode = (gcnew Label());
			this->labelDummy = (gcnew Label());
			this->customResY = (gcnew NumericUpDown());
			this->customResX = (gcnew NumericUpDown());
			this->labelCustomRes = (gcnew Label());
			this->ckbCustomRes = (gcnew CheckBox());
			this->ckbFullscreen = (gcnew CheckBox());
			this->ckbPopupWnd = (gcnew CheckBox());
			this->tabPageDLLs = (gcnew TabPage());
			this->btnDllRemove = (gcnew Button());
			this->btnDllAdd = (gcnew Button());
			this->lbDllList = (gcnew ListBox());
			this->labelDLLMessage = (gcnew Label());
			this->toolTip = (gcnew ToolTip(this->components));
			this->tabControl->SuspendLayout();
			this->tabPageGeneral->SuspendLayout();
			this->tabPageLaunchOptions->SuspendLayout();
			(cli::safe_cast<ISupportInitialize^>(this->monitorNum))->BeginInit();
			(cli::safe_cast<ISupportInitialize^>(this->customResY))->BeginInit();
			(cli::safe_cast<ISupportInitialize^>(this->customResX))->BeginInit();
			this->tabPageDLLs->SuspendLayout();
			this->SuspendLayout();
			// 
			// labelAutoSave
			// 
			this->labelAutoSave->Anchor = AnchorStyles::None;
			this->labelAutoSave->BackColor = Color::Transparent;
			this->labelAutoSave->Font = (gcnew Drawing::Font(L"Arial", 8.25F, FontStyle::Bold));
			this->labelAutoSave->ForeColor = Color::SkyBlue;
			this->labelAutoSave->Location = Point(16, 243);
			this->labelAutoSave->Name = L"labelAutoSave";
			this->labelAutoSave->Size = Drawing::Size(249, 14);
			this->labelAutoSave->TabIndex = 0;
			this->labelAutoSave->Text = L"All settings will be automatically saved.";
			this->labelAutoSave->TextAlign = ContentAlignment::BottomCenter;
			// 
			// tabControl
			// 
			this->tabControl->Anchor = AnchorStyles::None;
			this->tabControl->Controls->Add(this->tabPageGeneral);
			this->tabControl->Controls->Add(this->tabPageLaunchOptions);
			this->tabControl->Controls->Add(this->tabPageDLLs);
			this->tabControl->Location = Point(12, 12);
			this->tabControl->Name = L"tabControl";
			this->tabControl->SelectedIndex = 0;
			this->tabControl->Size = Drawing::Size(257, 223);
			this->tabControl->TabIndex = 1;
			// 
			// tabPageGeneral
			// 
			this->tabPageGeneral->BackColor = Color::FromArgb(static_cast<Byte>(47), static_cast<
				                                                  Byte>(49),
			                                                  static_cast<Byte>(54));
			this->tabPageGeneral->Controls->Add(this->comboPriority);
			this->tabPageGeneral->Controls->Add(this->labelPriority);
			this->tabPageGeneral->Controls->Add(this->ckbPowerSave);
			this->tabPageGeneral->Controls->Add(this->ckbAutoClose);
			this->tabPageGeneral->Controls->Add(this->ckbStartMinimized);
			this->tabPageGeneral->Controls->Add(this->ckbVSync);
			this->tabPageGeneral->Location = Point(4, 22);
			this->tabPageGeneral->Name = L"tabPageGeneral";
			this->tabPageGeneral->Padding = Windows::Forms::Padding(3);
			this->tabPageGeneral->Size = Drawing::Size(249, 197);
			this->tabPageGeneral->TabIndex = 0;
			this->tabPageGeneral->Text = L"General";
			// 
			// comboPriority
			// 
			this->comboPriority->Anchor = AnchorStyles::None;
			this->comboPriority->DropDownStyle = ComboBoxStyle::DropDownList;
			this->comboPriority->FormattingEnabled = true;
			this->comboPriority->Items->AddRange(gcnew array<Object^>(6){
				L"Realtime", L"High", L"Above normal", L"Normal (default)",
				L"Below normal", L"Low"
			});
			this->comboPriority->Location = Point(123, 101);
			this->comboPriority->Name = L"comboPriority";
			this->comboPriority->Size = Drawing::Size(120, 21);
			this->comboPriority->TabIndex = 5;
			this->comboPriority->TabStop = false;
			// 
			// labelPriority
			// 
			this->labelPriority->Anchor = AnchorStyles::None;
			this->labelPriority->AutoSize = true;
			this->labelPriority->BackColor = Color::Transparent;
			this->labelPriority->ForeColor = Color::White;
			this->labelPriority->Location = Point(5, 104);
			this->labelPriority->Name = L"labelPriority";
			this->labelPriority->Size = Drawing::Size(108, 13);
			this->labelPriority->TabIndex = 4;
			this->labelPriority->Text = L"Game process priority";
			// 
			// ckbPowerSave
			// 
			this->ckbPowerSave->Anchor = AnchorStyles::None;
			this->ckbPowerSave->AutoSize = true;
			this->ckbPowerSave->BackColor = Color::Transparent;
			this->ckbPowerSave->ForeColor = Color::White;
			this->ckbPowerSave->Location = Point(7, 79);
			this->ckbPowerSave->Name = L"ckbPowerSave";
			this->ckbPowerSave->Size = Drawing::Size(90, 17);
			this->ckbPowerSave->TabIndex = 3;
			this->ckbPowerSave->TabStop = false;
			this->ckbPowerSave->Text = L"Power saving";
			this->toolTip->SetToolTip(this->ckbPowerSave,
			                          L"Sets fps to 10 and low process priority upon losing focus (e.g. tabbing out of ga"
			                          L"me)");
			this->ckbPowerSave->UseVisualStyleBackColor = false;
			// 
			// ckbAutoClose
			// 
			this->ckbAutoClose->Anchor = AnchorStyles::None;
			this->ckbAutoClose->AutoSize = true;
			this->ckbAutoClose->BackColor = Color::Transparent;
			this->ckbAutoClose->ForeColor = Color::White;
			this->ckbAutoClose->Location = Point(7, 55);
			this->ckbAutoClose->Name = L"ckbAutoClose";
			this->ckbAutoClose->Size = Drawing::Size(76, 17);
			this->ckbAutoClose->TabIndex = 2;
			this->ckbAutoClose->TabStop = false;
			this->ckbAutoClose->Text = L"Auto close";
			this->toolTip->SetToolTip(this->ckbAutoClose, L"Automatically close unlocker after game exits");
			this->ckbAutoClose->UseVisualStyleBackColor = false;
			// 
			// ckbStartMinimized
			// 
			this->ckbStartMinimized->Anchor = AnchorStyles::None;
			this->ckbStartMinimized->AutoSize = true;
			this->ckbStartMinimized->BackColor = Color::Transparent;
			this->ckbStartMinimized->ForeColor = Color::White;
			this->ckbStartMinimized->Location = Point(7, 31);
			this->ckbStartMinimized->Name = L"ckbStartMinimized";
			this->ckbStartMinimized->Size = Drawing::Size(140, 17);
			this->ckbStartMinimized->TabIndex = 1;
			this->ckbStartMinimized->TabStop = false;
			this->ckbStartMinimized->Text = L"Start minimized unlocker";
			this->ckbStartMinimized->UseVisualStyleBackColor = false;
			// 
			// ckbVSync
			// 
			this->ckbVSync->Anchor = AnchorStyles::None;
			this->ckbVSync->AutoSize = true;
			this->ckbVSync->BackColor = Color::Transparent;
			this->ckbVSync->ForeColor = Color::White;
			this->ckbVSync->Location = Point(7, 7);
			this->ckbVSync->Name = L"ckbVSync";
			this->ckbVSync->Size = Drawing::Size(118, 17);
			this->ckbVSync->TabIndex = 0;
			this->ckbVSync->TabStop = false;
			this->ckbVSync->Text = L"Auto disable VSync";
			this->ckbVSync->UseVisualStyleBackColor = false;
			// 
			// tabPageLaunchOptions
			// 
			this->tabPageLaunchOptions->BackColor = Color::FromArgb(static_cast<Byte>(47),
			                                                        static_cast<Byte>(49), static_cast<
				                                                        Byte>(54));
			this->tabPageLaunchOptions->Controls->Add(this->monitorNum);
			this->tabPageLaunchOptions->Controls->Add(this->labelMonitorNum);
			this->tabPageLaunchOptions->Controls->Add(this->comboWindowMode);
			this->tabPageLaunchOptions->Controls->Add(this->labelWindowMode);
			this->tabPageLaunchOptions->Controls->Add(this->labelDummy);
			this->tabPageLaunchOptions->Controls->Add(this->customResY);
			this->tabPageLaunchOptions->Controls->Add(this->customResX);
			this->tabPageLaunchOptions->Controls->Add(this->labelCustomRes);
			this->tabPageLaunchOptions->Controls->Add(this->ckbCustomRes);
			this->tabPageLaunchOptions->Controls->Add(this->ckbFullscreen);
			this->tabPageLaunchOptions->Controls->Add(this->ckbPopupWnd);
			this->tabPageLaunchOptions->Location = Point(4, 22);
			this->tabPageLaunchOptions->Name = L"tabPageLaunchOptions";
			this->tabPageLaunchOptions->Padding = Windows::Forms::Padding(3);
			this->tabPageLaunchOptions->Size = Drawing::Size(249, 197);
			this->tabPageLaunchOptions->TabIndex = 1;
			this->tabPageLaunchOptions->Text = L"Launch Options";
			// 
			// monitorNum
			// 
			this->monitorNum->Anchor = AnchorStyles::None;
			this->monitorNum->Location = Point(111, 132);
			this->monitorNum->Minimum = Decimal(gcnew array<Int32>(4){1, 0, 0, 0});
			this->monitorNum->Name = L"monitorNum";
			this->monitorNum->Size = Drawing::Size(126, 20);
			this->monitorNum->TabIndex = 10;
			this->monitorNum->TabStop = false;
			this->monitorNum->Value = Decimal(gcnew array<Int32>(4){1, 0, 0, 0});
			// 
			// labelMonitorNum
			// 
			this->labelMonitorNum->Anchor = AnchorStyles::None;
			this->labelMonitorNum->AutoSize = true;
			this->labelMonitorNum->BackColor = Color::Transparent;
			this->labelMonitorNum->ForeColor = Color::White;
			this->labelMonitorNum->Location = Point(7, 134);
			this->labelMonitorNum->Name = L"labelMonitorNum";
			this->labelMonitorNum->Size = Drawing::Size(42, 13);
			this->labelMonitorNum->TabIndex = 9;
			this->labelMonitorNum->Text = L"Monitor";
			// 
			// comboWindowMode
			// 
			this->comboWindowMode->Anchor = AnchorStyles::None;
			this->comboWindowMode->DropDownStyle = ComboBoxStyle::DropDownList;
			this->comboWindowMode->FormattingEnabled = true;
			this->comboWindowMode->Items->AddRange(gcnew array<Object^>(2){L"Borderless", L"Exclusive"});
			this->comboWindowMode->Location = Point(111, 104);
			this->comboWindowMode->Name = L"comboWindowMode";
			this->comboWindowMode->Size = Drawing::Size(126, 21);
			this->comboWindowMode->TabIndex = 8;
			this->comboWindowMode->TabStop = false;
			this->toolTip->SetToolTip(this->comboWindowMode,
			                          L"Fullscreen Window Mode\r\nThis will only apply if the game is running fullscreen");
			// 
			// labelWindowMode
			// 
			this->labelWindowMode->Anchor = AnchorStyles::None;
			this->labelWindowMode->AutoSize = true;
			this->labelWindowMode->BackColor = Color::Transparent;
			this->labelWindowMode->ForeColor = Color::White;
			this->labelWindowMode->Location = Point(7, 107);
			this->labelWindowMode->Name = L"labelWindowMode";
			this->labelWindowMode->Size = Drawing::Size(75, 13);
			this->labelWindowMode->TabIndex = 7;
			this->labelWindowMode->Text = L"Window mode";
			// 
			// labelDummy
			// 
			this->labelDummy->Anchor = AnchorStyles::None;
			this->labelDummy->AutoSize = true;
			this->labelDummy->BackColor = Color::Transparent;
			this->labelDummy->ForeColor = Color::White;
			this->labelDummy->Location = Point(169, 79);
			this->labelDummy->Name = L"labelDummy";
			this->labelDummy->Size = Drawing::Size(12, 13);
			this->labelDummy->TabIndex = 6;
			this->labelDummy->Text = L"x";
			// 
			// customResY
			// 
			this->customResY->Anchor = AnchorStyles::None;
			this->customResY->Location = Point(182, 77);
			this->customResY->Maximum = Decimal(gcnew array<Int32>(4){4320, 0, 0, 0});
			this->customResY->Minimum = Decimal(gcnew array<Int32>(4){200, 0, 0, 0});
			this->customResY->Name = L"customResY";
			this->customResY->Size = Drawing::Size(55, 20);
			this->customResY->TabIndex = 5;
			this->customResY->Value = Decimal(gcnew array<Int32>(4){1080, 0, 0, 0});
			// 
			// customResX
			// 
			this->customResX->Anchor = AnchorStyles::None;
			this->customResX->Location = Point(111, 77);
			this->customResX->Maximum = Decimal(gcnew array<Int32>(4){7680, 0, 0, 0});
			this->customResX->Minimum = Decimal(gcnew array<Int32>(4){200, 0, 0, 0});
			this->customResX->Name = L"customResX";
			this->customResX->Size = Drawing::Size(55, 20);
			this->customResX->TabIndex = 4;
			this->customResX->TabStop = false;
			this->customResX->Value = Decimal(gcnew array<Int32>(4){1920, 0, 0, 0});
			// 
			// labelCustomRes
			// 
			this->labelCustomRes->Anchor = AnchorStyles::None;
			this->labelCustomRes->AutoSize = true;
			this->labelCustomRes->BackColor = Color::Transparent;
			this->labelCustomRes->ForeColor = Color::White;
			this->labelCustomRes->Location = Point(7, 79);
			this->labelCustomRes->Name = L"labelCustomRes";
			this->labelCustomRes->Size = Drawing::Size(90, 13);
			this->labelCustomRes->TabIndex = 3;
			this->labelCustomRes->Text = L"Custom resolution";
			// 
			// ckbCustomRes
			// 
			this->ckbCustomRes->Anchor = AnchorStyles::None;
			this->ckbCustomRes->AutoSize = true;
			this->ckbCustomRes->BackColor = Color::Transparent;
			this->ckbCustomRes->ForeColor = Color::White;
			this->ckbCustomRes->Location = Point(7, 55);
			this->ckbCustomRes->Name = L"ckbCustomRes";
			this->ckbCustomRes->Size = Drawing::Size(109, 17);
			this->ckbCustomRes->TabIndex = 2;
			this->ckbCustomRes->TabStop = false;
			this->ckbCustomRes->Text = L"Custom resolution";
			this->ckbCustomRes->UseVisualStyleBackColor = false;
			// 
			// ckbFullscreen
			// 
			this->ckbFullscreen->Anchor = AnchorStyles::None;
			this->ckbFullscreen->AutoSize = true;
			this->ckbFullscreen->BackColor = Color::Transparent;
			this->ckbFullscreen->ForeColor = Color::White;
			this->ckbFullscreen->Location = Point(7, 31);
			this->ckbFullscreen->Name = L"ckbFullscreen";
			this->ckbFullscreen->Size = Drawing::Size(74, 17);
			this->ckbFullscreen->TabIndex = 1;
			this->ckbFullscreen->TabStop = false;
			this->ckbFullscreen->Text = L"Fullscreen";
			this->ckbFullscreen->UseVisualStyleBackColor = false;
			// 
			// ckbPopupWnd
			// 
			this->ckbPopupWnd->Anchor = AnchorStyles::None;
			this->ckbPopupWnd->AutoSize = true;
			this->ckbPopupWnd->BackColor = Color::Transparent;
			this->ckbPopupWnd->ForeColor = Color::White;
			this->ckbPopupWnd->Location = Point(7, 7);
			this->ckbPopupWnd->Name = L"ckbPopupWnd";
			this->ckbPopupWnd->Size = Drawing::Size(96, 17);
			this->ckbPopupWnd->TabIndex = 0;
			this->ckbPopupWnd->TabStop = false;
			this->ckbPopupWnd->Text = L"Popup window";
			this->toolTip->SetToolTip(this->ckbPopupWnd, L"Launch the game in borderless windowed mode");
			this->ckbPopupWnd->UseVisualStyleBackColor = false;
			// 
			// tabPageDLLs
			// 
			this->tabPageDLLs->BackColor = Color::FromArgb(static_cast<Byte>(47), static_cast<Byte>(49),
			                                               static_cast<Byte>(54));
			this->tabPageDLLs->Controls->Add(this->btnDllRemove);
			this->tabPageDLLs->Controls->Add(this->btnDllAdd);
			this->tabPageDLLs->Controls->Add(this->lbDllList);
			this->tabPageDLLs->Controls->Add(this->labelDLLMessage);
			this->tabPageDLLs->Location = Point(4, 22);
			this->tabPageDLLs->Name = L"tabPageDLLs";
			this->tabPageDLLs->Padding = Windows::Forms::Padding(3);
			this->tabPageDLLs->Size = Drawing::Size(249, 197);
			this->tabPageDLLs->TabIndex = 2;
			this->tabPageDLLs->Text = L"DLLs";
			// 
			// btnDllRemove
			// 
			this->btnDllRemove->Anchor = AnchorStyles::None;
			this->btnDllRemove->Location = Point(136, 115);
			this->btnDllRemove->Name = L"btnDllRemove";
			this->btnDllRemove->Size = Drawing::Size(107, 23);
			this->btnDllRemove->TabIndex = 3;
			this->btnDllRemove->TabStop = false;
			this->btnDllRemove->Text = L"Remove";
			this->btnDllRemove->UseVisualStyleBackColor = true;
			this->btnDllRemove->Click += gcnew EventHandler(this, &SettingsForm::btnDllRemove_Click);
			// 
			// btnDllAdd
			// 
			this->btnDllAdd->Anchor = AnchorStyles::None;
			this->btnDllAdd->Location = Point(136, 81);
			this->btnDllAdd->Name = L"btnDllAdd";
			this->btnDllAdd->Size = Drawing::Size(107, 23);
			this->btnDllAdd->TabIndex = 2;
			this->btnDllAdd->TabStop = false;
			this->btnDllAdd->Text = L"Add";
			this->btnDllAdd->UseVisualStyleBackColor = true;
			this->btnDllAdd->Click += gcnew EventHandler(this, &SettingsForm::btnDllAdd_Click);
			// 
			// lbDllList
			// 
			this->lbDllList->Anchor = AnchorStyles::None;
			this->lbDllList->BackColor = Color::FromArgb(static_cast<Byte>(32), static_cast<Byte>(34),
			                                             static_cast<Byte>(37));
			this->lbDllList->ForeColor = Color::White;
			this->lbDllList->FormattingEnabled = true;
			this->lbDllList->Location = Point(6, 31);
			this->lbDllList->Name = L"lbDllList";
			this->lbDllList->Size = Drawing::Size(120, 160);
			this->lbDllList->TabIndex = 1;
			this->lbDllList->TabStop = false;
			// 
			// labelDLLMessage
			// 
			this->labelDLLMessage->Anchor = AnchorStyles::None;
			this->labelDLLMessage->BackColor = Color::Transparent;
			this->labelDLLMessage->ForeColor = Color::White;
			this->labelDLLMessage->Location = Point(0, 8);
			this->labelDLLMessage->Name = L"labelDLLMessage";
			this->labelDLLMessage->Size = Drawing::Size(249, 13);
			this->labelDLLMessage->TabIndex = 0;
			this->labelDLLMessage->Text = L"DLLs will be injected in the order of this list.";
			this->labelDLLMessage->TextAlign = ContentAlignment::TopCenter;
			// 
			// toolTip
			// 
			this->toolTip->AutoPopDelay = 5000;
			this->toolTip->InitialDelay = 1;
			this->toolTip->ReshowDelay = 100;
			// 
			// SettingsForm
			// 
			this->AutoScaleDimensions = SizeF(6, 13);
			this->AutoScaleMode = Windows::Forms::AutoScaleMode::Font;
			this->BackColor = Color::FromArgb(static_cast<Byte>(32), static_cast<Byte>(34),
			                                  static_cast<Byte>(37));
			this->ClientSize = Drawing::Size(281, 264);
			this->Controls->Add(this->tabControl);
			this->Controls->Add(this->labelAutoSave);
			this->FormBorderStyle = Windows::Forms::FormBorderStyle::FixedDialog;
			this->MaximizeBox = false;
			this->MinimizeBox = false;
			this->Name = L"SettingsForm";
			this->ShowIcon = false;
			this->StartPosition = FormStartPosition::CenterParent;
			this->Text = L"Settings";
			this->tabControl->ResumeLayout(false);
			this->tabPageGeneral->ResumeLayout(false);
			this->tabPageGeneral->PerformLayout();
			this->tabPageLaunchOptions->ResumeLayout(false);
			this->tabPageLaunchOptions->PerformLayout();
			(cli::safe_cast<ISupportInitialize^>(this->monitorNum))->EndInit();
			(cli::safe_cast<ISupportInitialize^>(this->customResY))->EndInit();
			(cli::safe_cast<ISupportInitialize^>(this->customResX))->EndInit();
			this->tabPageDLLs->ResumeLayout(false);
			this->ResumeLayout(false);
		}
#pragma endregion

	private:
		Void UpdateSettings(Object^ sender, FormClosingEventArgs^ e);

	private:
		Void btnDllRemove_Click(Object^ sender, EventArgs^ e);

	private:
		Void OnLoad(Object^ sender, EventArgs^ e);

	private:
		Void btnDllAdd_Click(Object^ sender, EventArgs^ e);

	private:
		Void OnFormat(Object^ sender, ListControlConvertEventArgs^ e);
	};
}
