#pragma once

namespace unlockfpsclr
{
	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;

	/// <summary>
	/// Summary for AboutForm
	/// </summary>
	public ref class AboutForm : public Form
	{
	public:
		AboutForm(void)
		{
			InitializeComponent();
			//
			//TODO: Add the constructor code here
			//
		}

	protected:
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		~AboutForm()
		{
			if (components)
			{
				delete components;
			}
		}

	private:
		System::Windows::Forms::Label^ labelTitle;

	private:
		System::Windows::Forms::LinkLabel^ linkLabelSource;

	private:
		System::Windows::Forms::LinkLabel^ linkLabelIssues;

	private:
		System::Windows::Forms::PictureBox^ pictureBox1;

	private:
		System::Windows::Forms::Label^ label1;

	protected:

	private:
		/// <summary>
		/// Required designer variable.
		/// </summary>
		System::ComponentModel::Container^ components;

#pragma region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		void InitializeComponent(void)
		{
			System::ComponentModel::ComponentResourceManager^ resources =
				(gcnew System::ComponentModel::ComponentResourceManager(AboutForm::typeid));
			this->labelTitle = (gcnew System::Windows::Forms::Label());
			this->linkLabelSource = (gcnew System::Windows::Forms::LinkLabel());
			this->linkLabelIssues = (gcnew System::Windows::Forms::LinkLabel());
			this->pictureBox1 = (gcnew System::Windows::Forms::PictureBox());
			this->label1 = (gcnew System::Windows::Forms::Label());
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->pictureBox1))->BeginInit();
			this->SuspendLayout();
			//
			// labelTitle
			//
			this->labelTitle->Anchor = System::Windows::Forms::AnchorStyles::None;
			this->labelTitle->BackColor = System::Drawing::Color::Transparent;
			this->labelTitle->Font = (gcnew System::Drawing::Font(L"Arial", 12, System::Drawing::FontStyle::Bold));
			this->labelTitle->ForeColor = System::Drawing::Color::White;
			this->labelTitle->Location = System::Drawing::Point(12, 12);
			this->labelTitle->Name = L"labelTitle";
			this->labelTitle->Padding = System::Windows::Forms::Padding(0, 5, 0, 0);
			this->labelTitle->Size = System::Drawing::Size(300, 44);
			this->labelTitle->TabIndex = 0;
			this->labelTitle->Text = L"Genshin FPS Unlocker\r\nv2.1.0";
			this->labelTitle->TextAlign = System::Drawing::ContentAlignment::TopCenter;
			//
			// linkLabelSource
			//
			this->linkLabelSource->Anchor = System::Windows::Forms::AnchorStyles::None;
			this->linkLabelSource->BackColor = System::Drawing::Color::Transparent;
			this->linkLabelSource->ForeColor = System::Drawing::Color::White;
			this->linkLabelSource->LinkArea = System::Windows::Forms::LinkArea(25, 11);
			this->linkLabelSource->LinkBehavior = System::Windows::Forms::LinkBehavior::NeverUnderline;
			this->linkLabelSource->Location = System::Drawing::Point(12, 66);
			this->linkLabelSource->Name = L"linkLabelSource";
			this->linkLabelSource->Size = System::Drawing::Size(300, 29);
			this->linkLabelSource->TabIndex = 2;
			this->linkLabelSource->TabStop = true;
			this->linkLabelSource->Text = L"This program is free and open source.\r\nModified by Sefinek.";
			this->linkLabelSource->TextAlign = System::Drawing::ContentAlignment::MiddleCenter;
			this->linkLabelSource->UseCompatibleTextRendering = true;
			this->linkLabelSource->LinkClicked += gcnew System::Windows::Forms::LinkLabelLinkClickedEventHandler(
				this, &AboutForm::linkLabelSource_LinkClicked);
			//
			// linkLabelIssues
			//
			this->linkLabelIssues->Anchor = System::Windows::Forms::AnchorStyles::None;
			this->linkLabelIssues->BackColor = System::Drawing::Color::Transparent;
			this->linkLabelIssues->ForeColor = System::Drawing::Color::White;
			this->linkLabelIssues->LinkArea = System::Windows::Forms::LinkArea(86, 46);
			this->linkLabelIssues->LinkBehavior = System::Windows::Forms::LinkBehavior::NeverUnderline;
			this->linkLabelIssues->Location = System::Drawing::Point(12, 106);
			this->linkLabelIssues->Name = L"linkLabelIssues";
			this->linkLabelIssues->Size = System::Drawing::Size(300, 47);
			this->linkLabelIssues->TabIndex = 3;
			this->linkLabelIssues->TabStop = true;
			this->linkLabelIssues->Text =
				L"If you encounter any problems or have a suggestion,\r\nfeel free to submit an issue"
				L" at\r\ngithub.com/sefinek24/genshin-fps-unlock/issues.";
			this->linkLabelIssues->TextAlign = System::Drawing::ContentAlignment::MiddleCenter;
			this->linkLabelIssues->UseCompatibleTextRendering = true;
			this->linkLabelIssues->LinkClicked += gcnew System::Windows::Forms::LinkLabelLinkClickedEventHandler(
				this, &AboutForm::linkLabelIssues_LinkClicked);
			//
			// pictureBox1
			//
			this->pictureBox1->Anchor = System::Windows::Forms::AnchorStyles::None;
			this->pictureBox1->Cursor = System::Windows::Forms::Cursors::Hand;
			this->pictureBox1->Image =
				(cli::safe_cast<System::Drawing::Image^>(resources->GetObject(L"pictureBox1.Image")));
			this->pictureBox1->Location = System::Drawing::Point(290, 12);
			this->pictureBox1->Name = L"pictureBox1";
			this->pictureBox1->Size = System::Drawing::Size(22, 22);
			this->pictureBox1->SizeMode = System::Windows::Forms::PictureBoxSizeMode::StretchImage;
			this->pictureBox1->TabIndex = 6;
			this->pictureBox1->TabStop = false;
			this->pictureBox1->Click += gcnew System::EventHandler(this, &AboutForm::Exit_Button);
			//
			// label1
			//
			this->label1->Anchor = System::Windows::Forms::AnchorStyles::None;
			this->label1->BackColor = System::Drawing::Color::Transparent;
			this->label1->ForeColor = System::Drawing::Color::White;
			this->label1->Location = System::Drawing::Point(13, 162);
			this->label1->Name = L"label1";
			this->label1->Size = System::Drawing::Size(299, 20);
			this->label1->TabIndex = 7;
			this->label1->Text = L"Thank you for using this software.";
			this->label1->TextAlign = System::Drawing::ContentAlignment::MiddleCenter;
			//
			// AboutForm
			//
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->BackColor =
				System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(20)),
				                                 static_cast<System::Int32>(static_cast<System::Byte>(22)),
				                                 static_cast<System::Int32>(static_cast<System::Byte>(25)));
			this->ClientSize = System::Drawing::Size(324, 192);
			this->Controls->Add(this->label1);
			this->Controls->Add(this->pictureBox1);
			this->Controls->Add(this->linkLabelIssues);
			this->Controls->Add(this->linkLabelSource);
			this->Controls->Add(this->labelTitle);
			this->FormBorderStyle = System::Windows::Forms::FormBorderStyle::None;
			this->Name = L"AboutForm";
			this->StartPosition = System::Windows::Forms::FormStartPosition::CenterParent;
			this->Text = L"About";
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->pictureBox1))->EndInit();
			this->ResumeLayout(false);
		}
#pragma endregion

	private:
		Void linkLabelSource_LinkClicked(Object^ sender, LinkLabelLinkClickedEventArgs^ e);

	private:
		Void linkLabelIssues_LinkClicked(Object^ sender, LinkLabelLinkClickedEventArgs^ e);

	private:
		Void Exit_Button(Object^ sender, EventArgs^ e);
	};
}
