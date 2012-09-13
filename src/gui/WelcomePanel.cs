using System;
using System.Windows.Forms;

namespace Rasterbator
{
	public class WelcomePanel : AssistantPage
	{
		public ListBox LanguageListBox = new ListBox();
		
		private Label WelcomeTitle = new Label();
		private Label WelcomeInfo = new Label();
		private Label TranslatorInfo = new Label();
		private LinkLabel TranslatorUrl = new LinkLabel();
		private LinkLabel linkLabel1 = new LinkLabel();
		private Label SelectLanguageLabel = new Label();
		private Label label25 = new Label();

		public WelcomePanel ()
		{
			// 
			// WelcomeTitle
			// 
			this.WelcomeTitle.Font = new System.Drawing.Font ("Tahoma", 16f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, ((System.Byte)(0)));
			this.WelcomeTitle.ForeColor = System.Drawing.SystemColors.ControlText;
			this.WelcomeTitle.Location = new System.Drawing.Point (80, 56);
			this.WelcomeTitle.Name = "WelcomeTitle";
			this.WelcomeTitle.Size = new System.Drawing.Size (344, 48);
			this.WelcomeTitle.TabIndex = 4;
			this.WelcomeTitle.Text = "Welcome to The Rasterbator!";
			// 
			// WelcomeInfo
			// 
			this.WelcomeInfo.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));
			this.WelcomeInfo.Font = new System.Drawing.Font ("Tahoma", 16f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((System.Byte)(0)));
			this.WelcomeInfo.ForeColor = System.Drawing.SystemColors.ControlText;
			this.WelcomeInfo.Location = new System.Drawing.Point (80, 112);
			this.WelcomeInfo.Name = "WelcomeInfo";
			this.WelcomeInfo.Size = new System.Drawing.Size (344, 184);
			this.WelcomeInfo.TabIndex = 5;
			this.WelcomeInfo.Text = "The Rasterbator creates huge, rasterized, multi-page images from any picture. The" + " rasterized images can be printed and assembled into extremely cool looking post" + "ers.";
			// 
			// TranslatorInfo
			// 
			this.TranslatorInfo.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));
			this.TranslatorInfo.Font = new System.Drawing.Font ("Tahoma", 11f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((System.Byte)(0)));
			this.TranslatorInfo.ForeColor = System.Drawing.SystemColors.ControlText;
			this.TranslatorInfo.Location = new System.Drawing.Point (448, 314);
			this.TranslatorInfo.Name = "TranslatorInfo";
			this.TranslatorInfo.Size = new System.Drawing.Size (216, 24);
			this.TranslatorInfo.TabIndex = 11;
			this.TranslatorInfo.Text = "Translated by ";
			// 
			// TranslatorUrl
			// 
			this.TranslatorUrl.ActiveLinkColor = System.Drawing.Color.FromArgb (((System.Byte)(158)), ((System.Byte)(11)), ((System.Byte)(14)));
			this.TranslatorUrl.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));
			this.TranslatorUrl.Font = new System.Drawing.Font ("Tahoma", 11f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((System.Byte)(0)));
			this.TranslatorUrl.LinkBehavior = LinkBehavior.HoverUnderline;
			this.TranslatorUrl.LinkColor = System.Drawing.Color.FromArgb (((System.Byte)(78)), ((System.Byte)(7)), ((System.Byte)(7)));
			this.TranslatorUrl.Location = new System.Drawing.Point (448, 338);
			this.TranslatorUrl.Name = "TranslatorUrl";
			this.TranslatorUrl.Size = new System.Drawing.Size (200, 32);
			this.TranslatorUrl.TabIndex = 12;
			this.TranslatorUrl.TabStop = true;
			this.TranslatorUrl.Text = "http://translatorurl";
			this.TranslatorUrl.LinkClicked += new LinkLabelLinkClickedEventHandler (this.TranslatorUrlLinkClicked);
			// 
			// linkLabel1
			// 
			this.linkLabel1.ActiveLinkColor = System.Drawing.Color.FromArgb (((System.Byte)(158)), ((System.Byte)(11)), ((System.Byte)(14)));
			this.linkLabel1.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Left)));
			this.linkLabel1.Font = new System.Drawing.Font ("Tahoma", 16f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((System.Byte)(0)));
			this.linkLabel1.LinkBehavior = LinkBehavior.HoverUnderline;
			this.linkLabel1.LinkColor = System.Drawing.Color.FromArgb (((System.Byte)(78)), ((System.Byte)(7)), ((System.Byte)(7)));
			this.linkLabel1.Location = new System.Drawing.Point (80, 344);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size (264, 23);
			this.linkLabel1.TabIndex = 7;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "http://arje.net/rasterbator";
			this.linkLabel1.LinkClicked += new LinkLabelLinkClickedEventHandler (this.LinkLabel1LinkClicked);
			// 
			// SelectLanguageLabel
			// 
			this.SelectLanguageLabel.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
			this.SelectLanguageLabel.Font = new System.Drawing.Font ("Tahoma", 16f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((System.Byte)(0)));
			this.SelectLanguageLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.SelectLanguageLabel.Location = new System.Drawing.Point (448, 32);
			this.SelectLanguageLabel.Name = "SelectLanguageLabel";
			this.SelectLanguageLabel.Size = new System.Drawing.Size (208, 40);
			this.SelectLanguageLabel.TabIndex = 9;
			this.SelectLanguageLabel.Text = "Please select language:";
			this.SelectLanguageLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// label25
			// 
			this.label25.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Left)));
			this.label25.Font = new System.Drawing.Font ("Tahoma", 11f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((System.Byte)(0)));
			this.label25.ForeColor = System.Drawing.Color.FromArgb (((System.Byte)(136)), ((System.Byte)(136)), ((System.Byte)(136)));
			this.label25.Location = new System.Drawing.Point (80, 376);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size (544, 24);
			this.label25.TabIndex = 8;
      		this.label25.Text = "The Rasterbator Standalone 1.4 - Michael Veeck 2010 - rasterbator@veeck.de - Licensed under GPL";
			// 
			// LanguageListBox
			// 
			this.LanguageListBox.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Right)));
			this.LanguageListBox.Font = new System.Drawing.Font ("Tahoma", 16f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((System.Byte)(0)));
			this.LanguageListBox.ItemHeight = 19;
			this.LanguageListBox.Location = new System.Drawing.Point (448, 77);
			this.LanguageListBox.Name = "LanguageListBox";
			this.LanguageListBox.Size = new System.Drawing.Size (168, 260);
			this.LanguageListBox.TabIndex = 10;
			
			this.Controls.Add (this.WelcomeTitle);
			this.Controls.Add (this.WelcomeInfo);
			this.Controls.Add (this.TranslatorInfo);
			this.Controls.Add (this.TranslatorUrl);
			this.Controls.Add (this.linkLabel1);
			this.Controls.Add (this.label25);
			this.Controls.Add (this.SelectLanguageLabel);
			this.Controls.Add (this.LanguageListBox);
		}
		
		void TranslatorUrlLinkClicked (object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (TranslatorUrl.Text == "")
				return;
			System.Diagnostics.Process.Start (TranslatorUrl.Text);
		}
		
		void LinkLabel1LinkClicked (object sender, LinkLabelLinkClickedEventArgs e)
		{
		  	 System.Diagnostics.Process.Start("http://arje.net/rasterbator");
		}
	}
}