using System;
using System.IO;
using System.Windows.Forms;

namespace Rasterbator
{
	public class CompletedPanel : AssistantPage
	{
		private CheckBox 	OpenFileCheckbox 	= new CheckBox();		
		private Label 		GalleryPlugLabel 	= new Label();
		private Label 		CompletedLabel		= new Label();
		private Label 		PrintInfoLabel 		= new Label();
		private LinkLabel 	linkLabel2 			= new LinkLabel();
		
		public CompletedPanel ()
		{
			// 
			// CompletedLabel
			// 
			this.CompletedLabel.Font = new System.Drawing.Font ("Tahoma", 16f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, ((System.Byte)(0)));
			this.CompletedLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.CompletedLabel.Location = new System.Drawing.Point (80, 26);
			this.CompletedLabel.Name = "CompletedLabel";
			this.CompletedLabel.Size = new System.Drawing.Size (368, 24);
			this.CompletedLabel.TabIndex = 4;
			this.CompletedLabel.Text = "Rasterbation completed!";
			// 
			// PrintInfoLabel
			// 
			this.PrintInfoLabel.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right)));
			this.PrintInfoLabel.Font = new System.Drawing.Font ("Tahoma", 16f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((System.Byte)(0)));
			this.PrintInfoLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.PrintInfoLabel.Location = new System.Drawing.Point (80, 58);
			this.PrintInfoLabel.Name = "PrintInfoLabel";
			this.PrintInfoLabel.Size = new System.Drawing.Size (544, 90);
			this.PrintInfoLabel.TabIndex = 5;
			this.PrintInfoLabel.Text = "When printing the image in Adobe Reader, choose Page scaling: Fit to paper at the options window that comes up. If you chose horizontal paper alignment, also make sure Auto-Rotate and Center is selected. Most printers cannot print to the margins of the paper - these settings ensure that all the images will be completely printed.";
			// 
			// GalleryPlugLabel
			// 
			this.GalleryPlugLabel.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right)));
			this.GalleryPlugLabel.Font = new System.Drawing.Font ("Tahoma", 16f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((System.Byte)(0)));
			this.GalleryPlugLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.GalleryPlugLabel.Location = new System.Drawing.Point (80, 168);
			this.GalleryPlugLabel.Name = "GalleryPlugLabel";
			this.GalleryPlugLabel.Size = new System.Drawing.Size (544, 38);
			this.GalleryPlugLabel.TabIndex = 21;
			this.GalleryPlugLabel.Text = "Please take a photograph of your picture and submit it to the Rasterbation Gallery!";
			// 
			// linkLabel2
			// 
			this.linkLabel2.ActiveLinkColor = System.Drawing.Color.FromArgb (((System.Byte)(158)), ((System.Byte)(11)), ((System.Byte)(14)));
			this.linkLabel2.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Left)));
			this.linkLabel2.Font = new System.Drawing.Font ("Tahoma", 16f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((System.Byte)(0)));
			this.linkLabel2.LinkBehavior = LinkBehavior.HoverUnderline;
			this.linkLabel2.LinkColor = System.Drawing.Color.FromArgb (((System.Byte)(78)), ((System.Byte)(7)), ((System.Byte)(7)));
			this.linkLabel2.Location = new System.Drawing.Point (80, 304);
			this.linkLabel2.Name = "linkLabel2";
			this.linkLabel2.Size = new System.Drawing.Size (344, 23);
			this.linkLabel2.TabIndex = 7;
			this.linkLabel2.TabStop = true;
			this.linkLabel2.Text = "http://homokaasu.org/rasterbator/gallery.gas";
			this.linkLabel2.LinkClicked += new LinkLabelLinkClickedEventHandler (this.LinkLabel2LinkClicked);
			// 
			// OpenFileCheckbox
			// 
			this.OpenFileCheckbox.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));
			this.OpenFileCheckbox.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
			this.OpenFileCheckbox.Checked = true;
			this.OpenFileCheckbox.CheckState = CheckState.Checked;
			this.OpenFileCheckbox.Font = new System.Drawing.Font ("Tahoma", 15f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((System.Byte)(0)));
			this.OpenFileCheckbox.Location = new System.Drawing.Point (280, 364);
			this.OpenFileCheckbox.Name = "OpenFileCheckbox";
			this.OpenFileCheckbox.Size = new System.Drawing.Size (248, 24);
			this.OpenFileCheckbox.TabIndex = 20;
			this.OpenFileCheckbox.Text = "Open rasticulate file";
			this.OpenFileCheckbox.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			
			this.Controls.Add (this.GalleryPlugLabel);
			this.Controls.Add (this.OpenFileCheckbox);
			this.Controls.Add (this.linkLabel2);
			this.Controls.Add (this.CompletedLabel);
			this.Controls.Add (this.PrintInfoLabel);
		}
		
		void LinkLabel2LinkClicked (object sender, LinkLabelLinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start("http://homokaasu.org/rasterbator/gallery.gas");
		}
		
		public override void afterLeaveHandler ()
		{
			if (this.OpenFileCheckbox.Checked)
				if (File.Exists (Rasterbator.currentJob.TargetFilename))
					System.Diagnostics.Process.Start (Rasterbator.currentJob.TargetFilename);
		}
	}
}