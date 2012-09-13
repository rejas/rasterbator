using System;
using System.Windows.Forms;
using System.Drawing;

namespace Rasterbator
{
	public class OptionsPanel : AssistantPage
	{
		private Panel CustomColorDisplay = new Panel();
		private CheckBox CutoutCheckbox = new CheckBox();
		private ColorDialog colorDialog1 = new ColorDialog();
		private NumericUpDown numericUpDown5 = new NumericUpDown();
		private Label DotSizeInfoLabel = new Label();
		private Label CutoutInfoLabel = new Label();
		private Label label10 = new Label();
		private Label DotSizeLabel = new Label();
		private Label SetOptionsLabel = new Label();
		
		private Panel ColorModePanel = new Panel();
		private Label ColorModeLabel = new Label();
		private RadioButton BlackRadio = new RadioButton();
		private RadioButton CustomColorRadio = new RadioButton();
		private RadioButton MultiColorRadio = new RadioButton();
		private Button SelectButton = new Button();
		
		private Panel DotModePanel = new Panel();
		private Label DotModeLabel = new Label();
		private RadioButton CircleRadio = new RadioButton();
		private RadioButton RectangleRadio = new RadioButton();
		
		public OptionsPanel ()
		{			
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).BeginInit ();
			// 
			// DotSizeInfoLabel
			// 
			this.DotSizeInfoLabel.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right)));
			this.DotSizeInfoLabel.Location = new Point (104, 186);
			this.DotSizeInfoLabel.Name = "DotSizeInfoLabel";
			this.DotSizeInfoLabel.Size = new Size (528, 35);
			this.DotSizeInfoLabel.TabIndex = 21;
			this.DotSizeInfoLabel.Text = "Dot size defines the maximum size of the dots of the rasterbation. Typical range " + "is 5-25 mm, but other sizes can be used too, if you want to play around.";
			// 
			// CutoutInfoLabel
			// 
			this.CutoutInfoLabel.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right)));
			this.CutoutInfoLabel.Location = new Point (104, 78);
			this.CutoutInfoLabel.Name = "CutoutInfoLabel";
			this.CutoutInfoLabel.Size = new Size (520, 40);
			this.CutoutInfoLabel.TabIndex = 20;
			this.CutoutInfoLabel.Text = "This option will draw a dim rectangle around the rasterbation graphic of each pag" + "e. The border will make it considerably easier to cut away the empty margins. If" + " you plan not to cut out the margins, you should uncheck this.";
			
			
			this.DotModePanel.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right)));
			this.DotModePanel.Location = new Point (88, 125);
			this.DotModePanel.Size = new Size(600, 24);
			// 
			// DotModeLabel
			// 
			this.DotModeLabel.Font = new Font ("Tahoma", 16f, FontStyle.Regular, GraphicsUnit.World, ((System.Byte)(0)));
			this.DotModeLabel.ForeColor = SystemColors.ControlText;
			this.DotModeLabel.Location = new Point (0, 0);
			this.DotModeLabel.Name = "DotModeLabel";
			this.DotModeLabel.Size = new Size (100, 24);
			this.DotModeLabel.TabIndex = 16;
			this.DotModeLabel.Text = "Dot mode";
			// 
			// CircleRadio
			// 
			this.CircleRadio.Font = new Font ("Tahoma", 16f, FontStyle.Regular, GraphicsUnit.World, ((System.Byte)(0)));
			this.CircleRadio.Location = new Point (150, 0);
			this.CircleRadio.Name = "CircleRadio";
			this.CircleRadio.Size = new Size (150, 24);
			this.CircleRadio.TabIndex = 24;
			this.CircleRadio.Text = "Circle";
			this.CircleRadio.Checked = true;
			// 
			// RectangleRadio
			// 
			this.RectangleRadio.Font = new Font ("Tahoma", 16f, FontStyle.Regular, GraphicsUnit.World, ((System.Byte)(0)));
			this.RectangleRadio.Location = new Point (300, 0);
			this.RectangleRadio.Name = "RectangleRadio";
			this.RectangleRadio.Size = new Size (150, 24);
			this.RectangleRadio.TabIndex = 24;
			this.RectangleRadio.Text = "Rectangle";
			// 
			// label10
			// 
			this.label10.Font = new Font ("Tahoma", 16f, FontStyle.Regular, GraphicsUnit.World, ((System.Byte)(0)));
			this.label10.ForeColor = SystemColors.ControlText;
			this.label10.Location = new Point (256, 154);
			this.label10.Name = "label10";
			this.label10.Size = new Size (40, 24);
			this.label10.TabIndex = 17;
			this.label10.Text = "mm";
			// 
			// numericUpDown5
			// 
			this.numericUpDown5.Font = new Font ("Tahoma", 16f, FontStyle.Regular, GraphicsUnit.World, ((System.Byte)(0)));
			this.numericUpDown5.Location = new Point (176, 154);
			this.numericUpDown5.Maximum = new System.Decimal (new int[] { 500, 0, 0, 0 });
			this.numericUpDown5.Minimum = new System.Decimal (new int[] { 1, 0, 0, 0 });
			this.numericUpDown5.Name = "numericUpDown5";
			this.numericUpDown5.Size = new Size (72, 27);
			this.numericUpDown5.TabIndex = 14;
			this.numericUpDown5.Value = new System.Decimal (new int[] { 10, 0, 0, 0 });
			// 
			// CutoutCheckbox
			// 
			this.CutoutCheckbox.Checked = true;
			this.CutoutCheckbox.CheckState = CheckState.Checked;
			this.CutoutCheckbox.Font = new Font ("Tahoma", 15f, FontStyle.Regular, GraphicsUnit.World, ((System.Byte)(0)));
			this.CutoutCheckbox.Location = new Point (88, 54);
			this.CutoutCheckbox.Name = "CutoutCheckbox";
			this.CutoutCheckbox.Size = new Size (488, 24);
			this.CutoutCheckbox.TabIndex = 19;
			this.CutoutCheckbox.Text = "Draw cutout line around rasterbated area";
			// 
			// SetOptionsLabel
			// 
			this.SetOptionsLabel.Font = new Font ("Tahoma", 16f, FontStyle.Bold, GraphicsUnit.World, ((System.Byte)(0)));
			this.SetOptionsLabel.ForeColor = SystemColors.ControlText;
			this.SetOptionsLabel.Location = new Point (88, 24);
			this.SetOptionsLabel.Name = "SetOptionsLabel";
			this.SetOptionsLabel.Size = new Size (552, 24);
			this.SetOptionsLabel.TabIndex = 8;
			this.SetOptionsLabel.Text = "Set rasterbation options (4/5)";
			
			// 
			// DotSizeLabel
			// 
			this.DotSizeLabel.Font = new Font ("Tahoma", 16f, FontStyle.Regular, GraphicsUnit.World, ((System.Byte)(0)));
			this.DotSizeLabel.ForeColor = SystemColors.ControlText;
			this.DotSizeLabel.Location = new Point (88, 154);
			this.DotSizeLabel.Name = "DotSizeLabel";
			this.DotSizeLabel.Size = new Size (368, 24);
			this.DotSizeLabel.TabIndex = 13;
			this.DotSizeLabel.Text = "Dot size";
			
			this.ColorModePanel.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right)));
			this.ColorModePanel.Location = new Point (88, 219);
			this.ColorModePanel.Size = new Size(600, 240);
			
			// 
			// ColorModeLabel
			// 
			this.ColorModeLabel.Font = new Font ("Tahoma", 16f, FontStyle.Regular, GraphicsUnit.World, ((System.Byte)(0)));
			this.ColorModeLabel.ForeColor = SystemColors.ControlText;
			this.ColorModeLabel.Location = new Point (0, 0);
			this.ColorModeLabel.Name = "ColorModeLabel";
			this.ColorModeLabel.Size = new Size (150, 24);
			this.ColorModeLabel.TabIndex = 15;
			this.ColorModeLabel.Text = "Color mode";
			// 
			// BlackRadio
			// 
			this.BlackRadio.Checked = true;
			this.BlackRadio.Font = new Font ("Tahoma", 16f, FontStyle.Regular, GraphicsUnit.World, ((System.Byte)(0)));
			this.BlackRadio.Location = new Point (150, 0);
			this.BlackRadio.Name = "BlackRadio";
			this.BlackRadio.Size = new Size (150, 24);
			this.BlackRadio.TabIndex = 22;
			this.BlackRadio.TabStop = true;
			this.BlackRadio.Text = "Black";
			// 
			// MultiColorRadio
			// 
			this.MultiColorRadio.Font = new Font ("Tahoma", 16f, FontStyle.Regular, GraphicsUnit.World, ((System.Byte)(0)));
			this.MultiColorRadio.Location = new Point (150, 24);
			this.MultiColorRadio.Name = "MultiColorRadio";
			this.MultiColorRadio.Size = new Size (150, 24);
			this.MultiColorRadio.TabIndex = 24;
			this.MultiColorRadio.Text = "Multi-color";
			// 
			// CustomColorRadio
			// 
			this.CustomColorRadio.Font = new Font ("Tahoma", 16f, FontStyle.Regular, GraphicsUnit.World, ((System.Byte)(0)));
			this.CustomColorRadio.Location = new Point (150, 48);
			this.CustomColorRadio.Name = "CustomColorRadio";
			this.CustomColorRadio.Size = new Size (150, 24);
			this.CustomColorRadio.TabIndex = 23;
			this.CustomColorRadio.Text = "Custom color:";
			// 
			// CustomColorDisplay
			// 
			this.CustomColorDisplay.BackColor = Color.FromArgb (((System.Byte)(158)), ((System.Byte)(11)), ((System.Byte)(14)));
			this.CustomColorDisplay.Location = new Point (300, 48);
			this.CustomColorDisplay.Name = "CustomColorDisplay";
			this.CustomColorDisplay.Size = new Size (24, 24);
			this.CustomColorDisplay.TabIndex = 25;
			// 
			// SelectButton
			// 
			this.SelectButton.Font = new Font ("Tahoma", 15f, FontStyle.Regular, GraphicsUnit.World, ((System.Byte)(0)));
			this.SelectButton.Location = new Point (350, 48);
			this.SelectButton.Name = "SelectButton";
			this.SelectButton.Size = new Size (150, 24);
			this.SelectButton.TabIndex = 26;
			this.SelectButton.Text = "Select...";
			this.SelectButton.Click += new System.EventHandler (this.SelectColorButtonClicked);
			// 
			// colorDialog1
			// 
			this.colorDialog1.Color = Color.FromArgb (((System.Byte)(158)), ((System.Byte)(11)), ((System.Byte)(14)));
			
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).EndInit ();
			
			this.ColorModePanel.Controls.Add (this.ColorModeLabel);
			this.ColorModePanel.Controls.Add (this.MultiColorRadio);
			this.ColorModePanel.Controls.Add (this.BlackRadio);
			this.ColorModePanel.Controls.Add (this.CustomColorRadio);
			this.ColorModePanel.Controls.Add (this.SelectButton);
			this.ColorModePanel.Controls.Add (this.CustomColorDisplay);
			
			this.DotModePanel.Controls.Add (this.DotModeLabel);
			this.DotModePanel.Controls.Add (this.RectangleRadio);
			this.DotModePanel.Controls.Add (this.CircleRadio);
			
			this.Controls.Add (this.DotSizeInfoLabel);
			this.Controls.Add (this.CutoutInfoLabel);
			this.Controls.Add (this.CutoutCheckbox);
			this.Controls.Add (this.label10);
			this.Controls.Add (this.numericUpDown5);
			this.Controls.Add (this.DotSizeLabel);
			this.Controls.Add (this.SetOptionsLabel);
			this.Controls.Add (this.ColorModePanel);
			this.Controls.Add (this.DotModePanel);
		}
		
		public override Boolean isOkayToLeave ()
		{
			if (numericUpDown5.Value < 3m) {
				if (MessageBox.Show (Rasterbator.labels["SmallDotSizeWarning"].ToString (), Rasterbator.labels["ConfirmOptions"].ToString (), MessageBoxButtons.YesNo) == DialogResult.No)
					return false;
			}
			return true;
		}
		
		public override void afterLeaveHandler ()
		{
			Rasterbator.currentJob.RasterSize = numericUpDown5.Value;
			Rasterbator.currentJob.CroppingRectangle = CutoutCheckbox.Checked;
			Rasterbator.currentJob.UseRectangles = RectangleRadio.Checked;
			
			if (MultiColorRadio.Checked)
				Rasterbator.currentJob.RasterColor = "avg";
			else if (BlackRadio.Checked)
				Rasterbator.currentJob.RasterColor = "000000";
			else if (CustomColorRadio.Checked) {
				Color C = colorDialog1.Color;
				Rasterbator.currentJob.RasterColor = C.R.ToString ("x2") + C.G.ToString ("x2") + C.B.ToString ("x2");
			}
		}
		
		void SelectColorButtonClicked (object sender, System.EventArgs e)
		{
			if (colorDialog1.ShowDialog () != DialogResult.OK)
				return;
			CustomColorRadio.Checked = true;
			CustomColorDisplay.BackColor = colorDialog1.Color;
		}
	}
}