using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Rasterbator
{
	public class SourceFilePanel : AssistantPage
	{
		private TextBox textBox1 = new TextBox();
		private OpenFileDialog SelectRasterbationSourceDialog = new OpenFileDialog();
		private Label SelectSourceImageLabel = new Label();
		private Button BrowseButton1 = new Button();
		
		public SourceFilePanel ()
		{	
			// 
			// SelectRasterbationSourceDialog
			// 
			this.SelectRasterbationSourceDialog.Filter = "Image files (*.jpg, *.png, *.gif, *.tif, *.bmp)|*.jpg;*.gif;*.png;*.tif;*.tiff;*." + "jpeg;*.bmp|All files (*.*)|*.*";
			this.SelectRasterbationSourceDialog.Title = "Select Rasterbation source...";
			this.SelectRasterbationSourceDialog.FileOk += new System.ComponentModel.CancelEventHandler (this.OpenFileDialog1FileOk);
			// 
			// SelectSourceImageLabel
			// 
			this.SelectSourceImageLabel.Font = new System.Drawing.Font ("Tahoma", 16f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, ((System.Byte)(0)));
			this.SelectSourceImageLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.SelectSourceImageLabel.Location = new System.Drawing.Point (80, 56);
			this.SelectSourceImageLabel.Name = "SelectSourceImageLabel";
			this.SelectSourceImageLabel.Size = new System.Drawing.Size (528, 24);
			this.SelectSourceImageLabel.TabIndex = 8;
			this.SelectSourceImageLabel.Text = "Select source image (1/5)";
			// 
			// textBox1
			// 
			this.textBox1.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right)));
			this.textBox1.Font = new System.Drawing.Font ("Tahoma", 16f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((System.Byte)(0)));
			this.textBox1.Location = new System.Drawing.Point (80, 88);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size (528, 27);
			this.textBox1.TabIndex = 9;
			this.textBox1.Text = "";
			this.textBox1.TextChanged += new System.EventHandler (this.TextBox1TextChanged);
			// 
			// BrowseButton1
			// 
			this.BrowseButton1.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
			this.BrowseButton1.Font = new System.Drawing.Font ("Tahoma", 15f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((System.Byte)(0)));
			this.BrowseButton1.Location = new System.Drawing.Point (480, 128);
			this.BrowseButton1.Name = "BrowseButton1";
			this.BrowseButton1.Size = new System.Drawing.Size (128, 28);
			this.BrowseButton1.TabIndex = 10;
			this.BrowseButton1.Text = "Browse...";
			this.BrowseButton1.Click += new System.EventHandler (this.BrowseSourceFileButtonClicked);
			
			this.Controls.Add (this.BrowseButton1);
			this.Controls.Add (this.textBox1);
			this.Controls.Add (this.SelectSourceImageLabel);
		}
		
		void TextBox1TextChanged (object sender, System.EventArgs e)
		{
			this.ParentControl.ContinueButtonEnabled = File.Exists (textBox1.Text);
		}
		
		void BrowseSourceFileButtonClicked (object sender, System.EventArgs e)
		{
			SelectRasterbationSourceDialog.ShowDialog ();
		}

		void OpenFileDialog1FileOk (object sender, System.ComponentModel.CancelEventArgs e)
		{
			textBox1.Text = SelectRasterbationSourceDialog.FileName;
		}
		
		public override Boolean isOkayToLeave ()
		{
			return (File.Exists (textBox1.Text));
		}
		
		public override void beforeShowHandler ()
		{
			this.ParentControl.ContinueButtonEnabled = false;
			
			SelectRasterbationSourceDialog.Title = Rasterbator.labels["SelectSource"].ToString ();
			SelectRasterbationSourceDialog.Filter = Rasterbator.labels["SelectSourceFilter"].ToString ();
		}
		
		public override void afterLeaveHandler ()
		{
			Rasterbator.currentJob.OriginalImage = Image.FromFile (textBox1.Text) as Bitmap;
			Rasterbator.currentJob.OriginalFilename = textBox1.Text;
		}
	}
}