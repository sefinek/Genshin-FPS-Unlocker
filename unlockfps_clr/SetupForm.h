#pragma once
#include "Settings.h"
#include "Managed.h"

namespace unlockfpsclr
{
	using namespace System;
	using namespace System::ComponentModel;
	using namespace Collections;
	using namespace Windows::Forms;
	using namespace Data;
	using namespace Drawing;

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
		Label^ labelResult;

	private:
		Label^ labelSelectInstance;

	private:
		ComboBox^ comboBoxSelectInst;

	private:
		Button^ btnBrowse;

	private:
		Label^ labelHint;

	private:
		ToolTip^ ttPath;

	private:
		Button^ btnConfirm;

	private:
		IContainer^ components;

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
			this->labelResult = (gcnew Label());
			this->labelSelectInstance = (gcnew Label());
			this->comboBoxSelectInst = (gcnew ComboBox());
			this->btnBrowse = (gcnew Button());
			this->labelHint = (gcnew Label());
			this->ttPath = (gcnew ToolTip(this->components));
			this->btnConfirm = (gcnew Button());
			this->SuspendLayout();
			// 
			// labelResult
			// 
			this->labelResult->Anchor = AnchorStyles::Top;
			this->labelResult->BackColor = Color::Transparent;
			this->labelResult->Font = (gcnew Drawing::Font(L"Arial", 9.75F, FontStyle::Regular, GraphicsUnit::Point,
			                                               static_cast<Byte>(0)));
			this->labelResult->ForeColor = Color::White;
			this->labelResult->Location = Point(9, 9);
			this->labelResult->Name = L"labelResult";
			this->labelResult->Size = Drawing::Size(437, 18);
			this->labelResult->TabIndex = 0;
			this->labelResult->Text = L"labelResult";
			this->labelResult->TextAlign = ContentAlignment::TopCenter;
			// 
			// labelSelectInstance
			// 
			this->labelSelectInstance->AutoSize = true;
			this->labelSelectInstance->BackColor = Color::Transparent;
			this->labelSelectInstance->ForeColor = Color::White;
			this->labelSelectInstance->Location = Point(9, 36);
			this->labelSelectInstance->Name = L"labelSelectInstance";
			this->labelSelectInstance->Size = Drawing::Size(37, 13);
			this->labelSelectInstance->TabIndex = 1;
			this->labelSelectInstance->Text = L"Select";
			// 
			// comboBoxSelectInst
			// 
			this->comboBoxSelectInst->BackColor = Color::Black;
			this->comboBoxSelectInst->DropDownStyle = ComboBoxStyle::DropDownList;
			this->comboBoxSelectInst->FormattingEnabled = true;
			this->comboBoxSelectInst->Location = Point(12, 52);
			this->comboBoxSelectInst->Name = L"comboBoxSelectInst";
			this->comboBoxSelectInst->Size = Drawing::Size(434, 21);
			this->comboBoxSelectInst->TabIndex = 2;
			this->comboBoxSelectInst->Visible = false;
			// 
			// btnBrowse
			// 
			this->btnBrowse->Location = Point(12, 51);
			this->btnBrowse->Name = L"btnBrowse";
			this->btnBrowse->Size = Drawing::Size(75, 23);
			this->btnBrowse->TabIndex = 3;
			this->btnBrowse->Text = L"Browse";
			this->btnBrowse->UseVisualStyleBackColor = true;
			this->btnBrowse->Visible = false;
			this->btnBrowse->Click += gcnew EventHandler(this, &SetupForm::btnBrowse_Click);
			// 
			// labelHint
			// 
			this->labelHint->AutoSize = true;
			this->labelHint->BackColor = Color::Transparent;
			this->labelHint->ForeColor = Color::White;
			this->labelHint->Location = Point(91, 56);
			this->labelHint->Name = L"labelHint";
			this->labelHint->Size = Drawing::Size(118, 13);
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
			this->btnConfirm->Location = Point(363, 82);
			this->btnConfirm->Name = L"btnConfirm";
			this->btnConfirm->Size = Drawing::Size(83, 23);
			this->btnConfirm->TabIndex = 5;
			this->btnConfirm->Text = L"Confirm";
			this->btnConfirm->UseVisualStyleBackColor = true;
			this->btnConfirm->Click += gcnew EventHandler(this, &SetupForm::btnConfirm_Click);
			// 
			// SetupForm
			// 
			this->AutoScaleDimensions = SizeF(6, 13);
			this->AutoScaleMode = Windows::Forms::AutoScaleMode::Font;
			this->BackColor = Color::FromArgb(static_cast<Byte>(54), static_cast<Byte>(57),
			                                  static_cast<Byte>(63));
			this->ClientSize = Drawing::Size(458, 117);
			this->Controls->Add(this->btnConfirm);
			this->Controls->Add(this->labelHint);
			this->Controls->Add(this->btnBrowse);
			this->Controls->Add(this->comboBoxSelectInst);
			this->Controls->Add(this->labelSelectInstance);
			this->Controls->Add(this->labelResult);
			this->FormBorderStyle = Windows::Forms::FormBorderStyle::FixedDialog;
			this->MaximizeBox = false;
			this->MinimizeBox = false;
			this->Name = L"SetupForm";
			this->StartPosition = FormStartPosition::CenterParent;
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
		Void btnConfirm_Click(Object^ sender, EventArgs^ e);
	};
}
