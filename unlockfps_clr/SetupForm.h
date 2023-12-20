#pragma once
#include "Settings.h"
#include "Managed.h"

namespace unlockfpsclr
{
	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;

	/// <summary>
	/// Summary for SetupForm
	/// </summary>
	public ref class SetupForm : public Form
	{
	public:
		SetupForm(Settings^ settings)
		{
			InitializeComponent();

			this->settings = settings;
			this->FormClosing += gcnew FormClosingEventHandler(this, &SetupForm::OnFormClosing);
			this->Load += gcnew EventHandler(this, &SetupForm::OnLoad);
		}

	protected:
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		~SetupForm()
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
		System::Windows::Forms::Label^ labelResult;

	private:
		System::Windows::Forms::Label^ labelSelectInstance;

	private:
		System::Windows::Forms::ComboBox^ comboBoxSelectInst;

	private:
		System::Windows::Forms::Button^ btnBrowse;

	private:
		System::Windows::Forms::Label^ labelHint;

	private:
		System::Windows::Forms::ToolTip^ ttPath;

	private:
		System::Windows::Forms::Button^ btnConfirm;

	private:
		System::ComponentModel::IContainer^ components;

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
			this->labelResult = (gcnew System::Windows::Forms::Label());
			this->labelSelectInstance = (gcnew System::Windows::Forms::Label());
			this->comboBoxSelectInst = (gcnew System::Windows::Forms::ComboBox());
			this->btnBrowse = (gcnew System::Windows::Forms::Button());
			this->labelHint = (gcnew System::Windows::Forms::Label());
			this->ttPath = (gcnew System::Windows::Forms::ToolTip(this->components));
			this->btnConfirm = (gcnew System::Windows::Forms::Button());
			this->SuspendLayout();
			//
			// labelResult
			//
			this->labelResult->Anchor = System::Windows::Forms::AnchorStyles::None;
			this->labelResult->BackColor = System::Drawing::Color::Transparent;
			this->labelResult->Font =
			(gcnew System::Drawing::Font(L"Arial", 11.25F, System::Drawing::FontStyle::Regular,
			                             System::Drawing::GraphicsUnit::Point, static_cast<System::Byte>(0)));
			this->labelResult->ForeColor = System::Drawing::Color::White;
			this->labelResult->Location = System::Drawing::Point(12, 11);
			this->labelResult->Name = L"labelResult";
			this->labelResult->Size = System::Drawing::Size(434, 18);
			this->labelResult->TabIndex = 0;
			this->labelResult->Text = L"Text";
			this->labelResult->TextAlign = System::Drawing::ContentAlignment::TopCenter;
			//
			// labelSelectInstance
			//
			this->labelSelectInstance->Anchor = System::Windows::Forms::AnchorStyles::None;
			this->labelSelectInstance->AutoSize = true;
			this->labelSelectInstance->BackColor = System::Drawing::Color::Transparent;
			this->labelSelectInstance->Font =
			(gcnew System::Drawing::Font(L"Microsoft Sans Serif", 9, System::Drawing::FontStyle::Regular,
			                             System::Drawing::GraphicsUnit::Point, static_cast<System::Byte>(0)));
			this->labelSelectInstance->ForeColor = System::Drawing::Color::White;
			this->labelSelectInstance->Location = System::Drawing::Point(10, 34);
			this->labelSelectInstance->Name = L"labelSelectInstance";
			this->labelSelectInstance->Size = System::Drawing::Size(41, 15);
			this->labelSelectInstance->TabIndex = 1;
			this->labelSelectInstance->Text = L"Select";
			//
			// comboBoxSelectInst
			//
			this->comboBoxSelectInst->Anchor = System::Windows::Forms::AnchorStyles::None;
			this->comboBoxSelectInst->BackColor =
				System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(32)),
				                                 static_cast<System::Int32>(static_cast<System::Byte>(34)),
				                                 static_cast<System::Int32>(static_cast<System::Byte>(37)));
			this->comboBoxSelectInst->DropDownStyle = System::Windows::Forms::ComboBoxStyle::DropDownList;
			this->comboBoxSelectInst->ForeColor = System::Drawing::Color::WhiteSmoke;
			this->comboBoxSelectInst->FormattingEnabled = true;
			this->comboBoxSelectInst->Location = System::Drawing::Point(12, 53);
			this->comboBoxSelectInst->Name = L"comboBoxSelectInst";
			this->comboBoxSelectInst->Size = System::Drawing::Size(434, 21);
			this->comboBoxSelectInst->TabIndex = 2;
			this->comboBoxSelectInst->Visible = false;
			//
			// btnBrowse
			//
			this->btnBrowse->Anchor = System::Windows::Forms::AnchorStyles::None;
			this->btnBrowse->Location = System::Drawing::Point(12, 52);
			this->btnBrowse->Name = L"btnBrowse";
			this->btnBrowse->Size = System::Drawing::Size(86, 23);
			this->btnBrowse->TabIndex = 3;
			this->btnBrowse->Text = L"Browse";
			this->btnBrowse->UseVisualStyleBackColor = true;
			this->btnBrowse->Visible = false;
			this->btnBrowse->Click += gcnew System::EventHandler(this, &SetupForm::btnBrowse_Click);
			//
			// labelHint
			//
			this->labelHint->Anchor = System::Windows::Forms::AnchorStyles::None;
			this->labelHint->AutoSize = true;
			this->labelHint->BackColor = System::Drawing::Color::Transparent;
			this->labelHint->Font =
			(gcnew System::Drawing::Font(L"Microsoft Sans Serif", 9, System::Drawing::FontStyle::Regular,
			                             System::Drawing::GraphicsUnit::Point, static_cast<System::Byte>(0)));
			this->labelHint->ForeColor = System::Drawing::Color::White;
			this->labelHint->Location = System::Drawing::Point(103, 56);
			this->labelHint->Name = L"labelHint";
			this->labelHint->Size = System::Drawing::Size(136, 15);
			this->labelHint->TabIndex = 4;
			this->labelHint->Text = L"or open your game now";
			this->labelHint->Visible = false;
			//
			// ttPath
			//
			this->ttPath->AutoPopDelay = 5000;
			this->ttPath->InitialDelay = 2;
			this->ttPath->ReshowDelay = 100;
			//
			// btnConfirm
			//
			this->btnConfirm->Anchor = System::Windows::Forms::AnchorStyles::None;
			this->btnConfirm->Location = System::Drawing::Point(342, 87);
			this->btnConfirm->Name = L"btnConfirm";
			this->btnConfirm->Size = System::Drawing::Size(104, 23);
			this->btnConfirm->TabIndex = 5;
			this->btnConfirm->Text = L"Confirm";
			this->btnConfirm->UseVisualStyleBackColor = true;
			this->btnConfirm->Click += gcnew System::EventHandler(this, &SetupForm::btnConfirm_Click);
			//
			// SetupForm
			//
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->BackColor =
				System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(54)),
				                                 static_cast<System::Int32>(static_cast<System::Byte>(57)),
				                                 static_cast<System::Int32>(static_cast<System::Byte>(63)));
			this->ClientSize = System::Drawing::Size(458, 122);
			this->Controls->Add(this->btnConfirm);
			this->Controls->Add(this->labelHint);
			this->Controls->Add(this->btnBrowse);
			this->Controls->Add(this->comboBoxSelectInst);
			this->Controls->Add(this->labelSelectInstance);
			this->Controls->Add(this->labelResult);
			this->FormBorderStyle = System::Windows::Forms::FormBorderStyle::FixedDialog;
			this->MaximizeBox = false;
			this->MinimizeBox = false;
			this->Name = L"SetupForm";
			this->StartPosition = System::Windows::Forms::FormStartPosition::CenterParent;
			this->Text = L"Setup";
			this->ResumeLayout(false);
			this->PerformLayout();
		}
#pragma endregion

	private:
		Void OnFormClosing(Object^ sender, FormClosingEventArgs^ e);

	private:
		Void btnBrowse_Click(Object^ sender, EventArgs^ e);

	private:
		Void OnProcessFound(String^ processPath);

	private:
		Void OnDoWork(Object^ sender, DoWorkEventArgs^ e);

	private:
		Void OnProgressChanged(Object^ sender, ProgressChangedEventArgs^ e);

	private:
		Void OnLoad(Object^ sender, EventArgs^ e);

	private:
		Void btnConfirm_Click(System::Object^ sender, EventArgs^ e);
	};
}
