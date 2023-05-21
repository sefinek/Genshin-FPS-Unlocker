#pragma once

namespace unlockfpsclr
{
	using namespace System;
	using namespace ComponentModel;
	using namespace Collections;
	using namespace Windows::Forms;
	using namespace Data;
	using namespace Drawing;

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
		Label^ labelTitle;

	private:
		LinkLabel^ linkLabelSource;

	private:
		LinkLabel^ linkLabelIssues;

	private:
		PictureBox^ pictureBox1;

	private:
		Label^ label1;

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
			auto resources = (gcnew ComponentResourceManager(AboutForm::typeid));
			this->labelTitle = (gcnew Label());
			this->linkLabelSource = (gcnew LinkLabel());
			this->linkLabelIssues = (gcnew LinkLabel());
			this->pictureBox1 = (gcnew PictureBox());
			this->label1 = (gcnew Label());
			(cli::safe_cast<ISupportInitialize^>(this->pictureBox1))->BeginInit();
			this->SuspendLayout();
			// 
			// labelTitle
			// 
			this->labelTitle->BackColor = Color::Transparent;
			this->labelTitle->Font = (gcnew Drawing::Font(L"Arial", 12, FontStyle::Bold));
			this->labelTitle->ForeColor = Color::White;
			this->labelTitle->Location = Point(12, 12);
			this->labelTitle->Name = L"labelTitle";
			this->labelTitle->Padding = Windows::Forms::Padding(0, 5, 0, 0);
			this->labelTitle->Size = Drawing::Size(300, 44);
			this->labelTitle->TabIndex = 0;
			this->labelTitle->Text = L"Genshin FPS Unlocker\r\nv2.0.9";
			this->labelTitle->TextAlign = ContentAlignment::TopCenter;
			// 
			// linkLabelSource
			// 
			this->linkLabelSource->BackColor = Color::Transparent;
			this->linkLabelSource->ForeColor = Color::White;
			this->linkLabelSource->LinkArea = LinkArea(25, 11);
			this->linkLabelSource->LinkBehavior = LinkBehavior::NeverUnderline;
			this->linkLabelSource->Location = Point(12, 66);
			this->linkLabelSource->Name = L"linkLabelSource";
			this->linkLabelSource->Size = Drawing::Size(300, 29);
			this->linkLabelSource->TabIndex = 2;
			this->linkLabelSource->TabStop = true;
			this->linkLabelSource->Text = L"This program is free and open source.\r\nModified by Sefinek.";
			this->linkLabelSource->TextAlign = ContentAlignment::MiddleCenter;
			this->linkLabelSource->UseCompatibleTextRendering = true;
			this->linkLabelSource->LinkClicked += gcnew LinkLabelLinkClickedEventHandler(
				this, &AboutForm::linkLabelSource_LinkClicked);
			// 
			// linkLabelIssues
			// 
			this->linkLabelIssues->BackColor = Color::Transparent;
			this->linkLabelIssues->ForeColor = Color::White;
			this->linkLabelIssues->LinkArea = LinkArea(86, 46);
			this->linkLabelIssues->LinkBehavior = LinkBehavior::NeverUnderline;
			this->linkLabelIssues->Location = Point(12, 106);
			this->linkLabelIssues->Name = L"linkLabelIssues";
			this->linkLabelIssues->Size = Drawing::Size(300, 47);
			this->linkLabelIssues->TabIndex = 3;
			this->linkLabelIssues->TabStop = true;
			this->linkLabelIssues->Text =
				L"If you encounter any problems or have a suggestion,\r\nfeel free to submit an issue"
				L" at\r\ngithub.com/sefinek24/genshin-fps-unlock/issues.";
			this->linkLabelIssues->TextAlign = ContentAlignment::MiddleCenter;
			this->linkLabelIssues->UseCompatibleTextRendering = true;
			this->linkLabelIssues->LinkClicked += gcnew LinkLabelLinkClickedEventHandler(
				this, &AboutForm::linkLabelIssues_LinkClicked);
			// 
			// pictureBox1
			// 
			this->pictureBox1->Cursor = Cursors::Hand;
			this->pictureBox1->Image = (cli::safe_cast<Image^>(resources->GetObject(L"pictureBox1.Image")));
			this->pictureBox1->Location = Point(290, 12);
			this->pictureBox1->Name = L"pictureBox1";
			this->pictureBox1->Size = Drawing::Size(22, 22);
			this->pictureBox1->SizeMode = PictureBoxSizeMode::StretchImage;
			this->pictureBox1->TabIndex = 6;
			this->pictureBox1->TabStop = false;
			this->pictureBox1->Click += gcnew EventHandler(this, &AboutForm::Exit_Button);
			// 
			// label1
			// 
			this->label1->BackColor = Color::Transparent;
			this->label1->ForeColor = Color::White;
			this->label1->Location = Point(13, 162);
			this->label1->Name = L"label1";
			this->label1->Size = Drawing::Size(299, 20);
			this->label1->TabIndex = 7;
			this->label1->Text = L"Thank you for using this software.";
			this->label1->TextAlign = ContentAlignment::MiddleCenter;
			// 
			// AboutForm
			// 
			this->AutoScaleDimensions = SizeF(6, 13);
			this->AutoScaleMode = Windows::Forms::AutoScaleMode::Font;
			this->BackColor = Color::FromArgb(static_cast<Byte>(20), static_cast<Byte>(22),
			                                  static_cast<Byte>(25));
			this->ClientSize = Drawing::Size(324, 192);
			this->Controls->Add(this->label1);
			this->Controls->Add(this->pictureBox1);
			this->Controls->Add(this->linkLabelIssues);
			this->Controls->Add(this->linkLabelSource);
			this->Controls->Add(this->labelTitle);
			this->FormBorderStyle = Windows::Forms::FormBorderStyle::None;
			this->Name = L"AboutForm";
			this->StartPosition = FormStartPosition::CenterParent;
			this->Text = L"About";
			(cli::safe_cast<ISupportInitialize^>(this->pictureBox1))->EndInit();
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
