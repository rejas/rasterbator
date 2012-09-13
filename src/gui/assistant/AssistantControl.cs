using System;
using System.Drawing;
using System.Windows.Forms;

namespace Rasterbator
{
	public class AssistantControl : Panel
	{
		private TabControl tabControl = new TabControl();
		private Button ContinueButton = new Button();
		private Button BackButton = new Button();
		
		public AssistantControl() {
			
			this.BackButton.Font 		= new Font ("Tahoma", 15f, FontStyle.Regular, GraphicsUnit.World, ((System.Byte)(0)));
			this.BackButton.Location 	= new Point (80, 357);
			this.BackButton.Size 		= new Size (96, 32);
			this.BackButton.Text 		= "< Back";
			this.BackButton.Click 		+= new EventHandler (this.BackButtonClicked);
			this.BackButton.Visible 		= false;
			
			this.ContinueButton.Font 	= new Font ("Tahoma", 15f, FontStyle.Regular, GraphicsUnit.World, ((System.Byte)(0)));
			this.ContinueButton.Location = new Point (472, 357);
			this.ContinueButton.Size 	= new Size (136, 32);
			this.ContinueButton.Text		= "Continue >";
			this.ContinueButton.Click 	+= new EventHandler (this.NextButtonClicked);
			
			tabControl.Size 		= new Size (702, 343);
			
			this.Controls.Add(BackButton);
			this.Controls.Add(ContinueButton);
			this.Controls.Add(tabControl);
		}
		
		public Boolean ContinueButtonEnabled {
			get { return (ContinueButton.Enabled); }
			set { ContinueButton.Enabled = value; }
		}
		
		public String ContinueButtonText {
			get { return (ContinueButton.Text); }
			set { ContinueButton.Text = value; }
		}
		
		public int SelectedIndex {
			get { return (tabControl.SelectedIndex); }
			set { tabControl.SelectedIndex = value; }
		}
		
		public void AddPage(AssistantPage a) {
			tabControl.Controls.Add(a);
		}
		
		void BackButtonClicked (object sender, System.EventArgs e)
		{
			tabControl.SelectedIndex--;
			
			updateButtons();
		}
		
		void NextButtonClicked (object sender, System.EventArgs e)
		{
			if (!(tabControl.SelectedTab as AssistantPage).isOkayToLeave())
				return;
			
			(tabControl.SelectedTab as AssistantPage).afterLeaveHandler();
			
			if (tabControl.SelectedIndex<tabControl.Controls.Count-1)
			{
				tabControl.SelectedIndex++;
				
				(tabControl.SelectedTab as AssistantPage).beforeShowHandler();
				
				updateButtons();
			} else {
				(this.Parent as Form).Close();
			}
		}
		
		void updateButtons()
		{
			if (tabControl.SelectedIndex==tabControl.Controls.Count-1)
				this.ContinueButton.Text = "Close";
			else 
				this.ContinueButton.Text = (tabControl.SelectedTab as AssistantPage).getContinueButtonText();
			
			this.ContinueButton.Enabled = (tabControl.SelectedTab as AssistantPage).isOkayToLeave();
			this.BackButton.Visible = (tabControl.SelectedIndex>0);
		}
	}
}