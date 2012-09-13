using System;
using System.IO;
using System.Windows.Forms;

namespace Rasterbator
{
	public class OutputFilePanel : AssistantPage
	{
		private Button BrowseButton2 = new Button();
		private TextBox textBox2 	= new TextBox();
		private SaveFileDialog SelectRasterbationTargetDialog = new SaveFileDialog();
		private Label SaveAsLabel = new Label();

		public OutputFilePanel ()
		{
			// 
			// textBox2
			// 
			this.textBox2.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right)));
			this.textBox2.Font = new System.Drawing.Font ("Tahoma", 16f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((System.Byte)(0)));
			this.textBox2.Location = new System.Drawing.Point (80, 88);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size (528, 27);
			this.textBox2.TabIndex = 9;
			this.textBox2.Text = "";
			// 
			// BrowseButton2
			// 
			this.BrowseButton2.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
			this.BrowseButton2.Font = new System.Drawing.Font ("Tahoma", 15f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((System.Byte)(0)));
			this.BrowseButton2.Location = new System.Drawing.Point (480, 128);
			this.BrowseButton2.Name = "BrowseButton2";
			this.BrowseButton2.Size = new System.Drawing.Size (128, 28);
			this.BrowseButton2.TabIndex = 10;
			this.BrowseButton2.Text = "Browse...";
			this.BrowseButton2.Click += new System.EventHandler (this.BrowseTargetFileButtonClicked);
			// 
			// SaveAsLabel
			// 
			this.SaveAsLabel.Font = new System.Drawing.Font ("Tahoma", 16f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, ((System.Byte)(0)));
			this.SaveAsLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.SaveAsLabel.Location = new System.Drawing.Point (80, 56);
			this.SaveAsLabel.Name = "SaveAsLabel";
			this.SaveAsLabel.Size = new System.Drawing.Size (512, 24);
			this.SaveAsLabel.TabIndex = 8;
			this.SaveAsLabel.Text = "Save rasterbation as (5/5)";
			// 
			// SelectRasterbationTargetDialog
			// 
			this.SelectRasterbationTargetDialog.Filter = "Pdf files (*.pdf)|*.pdf";
			
			this.Controls.Add (this.BrowseButton2);
			this.Controls.Add (this.textBox2);
			this.Controls.Add (this.SaveAsLabel);
		}
		
		void BrowseTargetFileButtonClicked (object sender, System.EventArgs e)
		{
			if (SelectRasterbationTargetDialog.ShowDialog () != DialogResult.OK)
				return;
			textBox2.Text = SelectRasterbationTargetDialog.FileName;
		}
		
		public override void beforeShowHandler ()
		{
			SelectRasterbationTargetDialog.Filter = Rasterbator.labels["SelectTargetFilter"].ToString ();
			
			string s = Rasterbator.currentJob.OriginalFilename;
			if (s.IndexOf (".") < 0)
				s += ".";
			s = s.Substring (0, s.LastIndexOf ("."));
			string fn = s;
			int c = 0;
			while (File.Exists (fn + ".pdf")) {
				c++;
				fn = s + "_" + c;
			}
			textBox2.Text = fn + ".pdf";
		}
		
		public override void afterLeaveHandler ()
		{
			Rasterbator.currentJob.TargetFilename = textBox2.Text;
		}
		
		public override string getContinueButtonText ()
		{
			return "Rasterbate";
		}
	}
}