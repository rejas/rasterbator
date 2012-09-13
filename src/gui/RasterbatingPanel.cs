using System;
using System.Windows.Forms;
using System.Threading;
using System.Drawing;
using System.ComponentModel;

namespace Rasterbator
{
	public class RasterbatingPanel : AssistantPage
	{
		private CheckBox 	LowPriorityRasterbation 			= new CheckBox();
		private ProgressBar progressBar1 					= new ProgressBar();
		private Label 		EstimatedTimeRemainingLabel 		= new Label();
		private Label 		RasterbateBackgroundInfoLabel 	= new Label();
		private Label 		PleaseWaitLabel 					= new Label();
		
		private double LastProgress = -1;
		private Thread Worker = null;
		private DateTime StartTime;
		private System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer (new Container ());
		
		public RasterbatingPanel ()
		{
			// 
			// progressBar1
			// 
			this.progressBar1.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right)));
			this.progressBar1.Location = new Point (80, 160);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new Size (528, 16);
			this.progressBar1.TabIndex = 8;
			// 
			// LowPriorityRasterbation
			// 
			this.LowPriorityRasterbation.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Left)));
			this.LowPriorityRasterbation.Font = new Font ("Tahoma", 15f, FontStyle.Regular, GraphicsUnit.World, ((System.Byte)(0)));
			this.LowPriorityRasterbation.Location = new Point (80, 320);
			this.LowPriorityRasterbation.Name = "LowPriorityRasterbation";
			this.LowPriorityRasterbation.Size = new Size (488, 24);
			this.LowPriorityRasterbation.TabIndex = 22;
			this.LowPriorityRasterbation.Text = "Rasterbate on low priority";
			this.LowPriorityRasterbation.CheckedChanged += new System.EventHandler (this.LowPriorityRasterbationCheckedChanged);
			// 
			// RasterbateBackgroundInfoLabel
			// 
			this.RasterbateBackgroundInfoLabel.Anchor = ((AnchorStyles)(((AnchorStyles.Bottom | AnchorStyles.Left) | AnchorStyles.Right)));
			this.RasterbateBackgroundInfoLabel.Location = new Point (96, 344);
			this.RasterbateBackgroundInfoLabel.Name = "RasterbateBackgroundInfoLabel";
			this.RasterbateBackgroundInfoLabel.Size = new Size (520, 40);
			this.RasterbateBackgroundInfoLabel.TabIndex = 23;
			this.RasterbateBackgroundInfoLabel.Text = "Check this if you want to use other programs while rasterbating. The rasterbation" + " will take more time, but other programs become more responsive.";
			// 
			// PleaseWaitLabel
			// 
			this.PleaseWaitLabel.Font = new Font ("Tahoma", 16f, FontStyle.Bold, GraphicsUnit.World, ((System.Byte)(0)));
			this.PleaseWaitLabel.ForeColor = SystemColors.ControlText;
			this.PleaseWaitLabel.Location = new Point (80, 136);
			this.PleaseWaitLabel.Name = "PleaseWaitLabel";
			this.PleaseWaitLabel.Size = new Size (520, 24);
			this.PleaseWaitLabel.TabIndex = 4;
			this.PleaseWaitLabel.Text = "Rasterbating, please wait...";
			// 
			// EstimatedTimeRemainingLabel
			// 
			this.EstimatedTimeRemainingLabel.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
			this.EstimatedTimeRemainingLabel.Location = new Point (144, 176);
			this.EstimatedTimeRemainingLabel.Name = "EstimatedTimeRemainingLabel";
			this.EstimatedTimeRemainingLabel.Size = new Size (464, 16);
			this.EstimatedTimeRemainingLabel.TabIndex = 21;
			this.EstimatedTimeRemainingLabel.Text = "Estimated time remaining:";
			this.EstimatedTimeRemainingLabel.TextAlign = ContentAlignment.TopRight;
			// 
			// timer1
			// 
			this.timer1.Tick += new System.EventHandler (this.Timer1Tick);
			
			this.Controls.Add (this.RasterbateBackgroundInfoLabel);
			this.Controls.Add (this.LowPriorityRasterbation);
			this.Controls.Add (this.EstimatedTimeRemainingLabel);
			this.Controls.Add (this.PleaseWaitLabel);
			this.Controls.Add (this.progressBar1);
		}
		
		public override void beforeShowHandler ()
		{
			this.ParentControl.ContinueButtonEnabled = false;
			
			Rasterbator.logic = new RasterLogic(Rasterbator.currentJob);
			// 
			// Worker
			// 
			this.Worker = new Thread (new ThreadStart (Rasterbator.logic.Go));
			this.Worker.Priority = ThreadPriority.Lowest;
			this.Worker.Start ();
			
			EstimatedTimeRemainingLabel.Text = "";
			StartTime = DateTime.Now;
			LastProgress = -1;
			
			progressBar1.ForeColor = Color.FromArgb (0xff, 0x4e, 0x7, 0x7);
			timer1.Enabled = true;
		}

		void LowPriorityRasterbationCheckedChanged (object sender, System.EventArgs e)
		{
			Worker.Priority = LowPriorityRasterbation.Checked ? ThreadPriority.BelowNormal : ThreadPriority.Normal;
		}
		
		void Timer1Tick (object sender, System.EventArgs e)
		{
			double p = Rasterbator.logic.Progress;
			progressBar1.Value = (int)(p * 100.0);
			
			if (StartTime.AddSeconds (2) < DateTime.Now && p != LastProgress) {
				
				double SecondsElapsed = DateTime.Now.Subtract (StartTime).TotalSeconds;
				int SecondsRemaining = (int)(SecondsElapsed / p * (1.0 - p));
				
				if (SecondsRemaining > 0) {
					string s = Rasterbator.labels["EstimatedTimeRemainingLabel"].ToString ();
					if (SecondsRemaining > 0) {
						int m = SecondsRemaining / 60;
						if (m > 0)
							s += " " + m + " " + Rasterbator.labels["minute" + (m == 1 ? "" : "s")];
						SecondsRemaining %= 60;
					}
					s += " " + SecondsRemaining + " " + Rasterbator.labels["second" + (SecondsRemaining == 1 ? "" : "s")];
					
					EstimatedTimeRemainingLabel.Text = s;
				} else {
					EstimatedTimeRemainingLabel.Text = "";
				}
				
				LastProgress = p;
			}
			
			if (Worker.ThreadState == ThreadState.Running)
				return;
			
			//TODO Rasterbator.currentJob.OriginalImage.Dispose ();
			
			timer1.Enabled = false;
			if (Rasterbator.logic.ErrorMessage != "")
				MessageBox.Show ("An error occurred while rasterbating. Please read the help files for possible solutions." + "\n\nThe error message is:\n" + Rasterbator.logic.ErrorMessage);
			
			this.ParentControl.ContinueButtonEnabled = true;
		}
		
		public override Boolean isOkayToLeave ()
		{
			return (!timer1.Enabled);
		}
	}
}