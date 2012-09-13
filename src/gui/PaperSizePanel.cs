using System;
using System.Drawing;
using System.Windows.Forms;

namespace Rasterbator
{
	public class PaperSizePanel : AssistantPage
	{
		private PictureBox PortraitSymbol = new PictureBox();
		private PictureBox LandscapeSymbol = new PictureBox();
		private ComboBox PaperAlignCombo = new ComboBox();
		private ComboBox PaperSizeCombo = new ComboBox();
		private Label PaperSizeLabel = new Label();
		private NumericUpDown numericUpDown1 = new NumericUpDown();
		private NumericUpDown numericUpDown2 = new NumericUpDown();
		private Label label7 = new Label();
		private Label label8 = new Label();
		private RadioButton StandardPaperRadio = new RadioButton();
		private RadioButton CustomPaperRadio = new RadioButton();
		private Label WidthLabel = new Label();
		private Label HeightLabel = new Label();
		
		public PaperSizePanel ()
		{
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit ();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit ();
			// 
			// PortraitSymbol
			// 
			this.PortraitSymbol.Image = ((Image)(Rasterbator.resources.GetObject ("PortraitSymbol.Image")));
			this.PortraitSymbol.Location = new Point (504, 128);
			this.PortraitSymbol.Name = "PortraitSymbol";
			this.PortraitSymbol.Size = new Size (42, 42);
			this.PortraitSymbol.TabIndex = 23;
			this.PortraitSymbol.TabStop = false;
			// 
			// LandscapeSymbol
			// 
			this.LandscapeSymbol.Image = ((Image)(Rasterbator.resources.GetObject ("LandscapeSymbol.Image")));
			this.LandscapeSymbol.Location = new Point (504, 128);
			this.LandscapeSymbol.Name = "LandscapeSymbol";
			this.LandscapeSymbol.Size = new Size (42, 42);
			this.LandscapeSymbol.TabIndex = 22;
			this.LandscapeSymbol.TabStop = false;
			// 
			// PaperSizeLabel
			// 
			this.PaperSizeLabel.Font = new System.Drawing.Font ("Tahoma", 16f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, ((System.Byte)(0)));
			this.PaperSizeLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.PaperSizeLabel.Location = new System.Drawing.Point (80, 56);
			this.PaperSizeLabel.Name = "PaperSizeLabel";
			this.PaperSizeLabel.Size = new System.Drawing.Size (536, 24);
			this.PaperSizeLabel.TabIndex = 8;
			this.PaperSizeLabel.Text = "Select paper size (2/5)";
			// 
			// PaperAlignCombo
			// 
			this.PaperAlignCombo.DropDownStyle = ComboBoxStyle.DropDownList;
			this.PaperAlignCombo.Font = new System.Drawing.Font ("Tahoma", 15f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((System.Byte)(0)));
			this.PaperAlignCombo.Items.AddRange (new object[] { "Portrait", "Landscape" });
			this.PaperAlignCombo.Location = new System.Drawing.Point (368, 136);
			this.PaperAlignCombo.Name = "PaperAlignCombo";
			this.PaperAlignCombo.Size = new System.Drawing.Size (120, 26);
			this.PaperAlignCombo.TabIndex = 20;
			this.PaperAlignCombo.SelectedIndexChanged += new System.EventHandler (this.ComboBox2SelectedIndexChanged);
			// 
			// PaperSizeCombo
			// 
			this.PaperSizeCombo.DropDownStyle = ComboBoxStyle.DropDownList;
			this.PaperSizeCombo.Font = new System.Drawing.Font ("Tahoma", 15f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((System.Byte)(0)));
			this.PaperSizeCombo.Items.AddRange (new object[] { "A4 (210x297 mm)", "A3 (297x420 mm)", "US Letter (216x279 mm)", "US Legal (216x356 mm)" });
			this.PaperSizeCombo.Location = new System.Drawing.Point (128, 136);
			this.PaperSizeCombo.Name = "PaperSizeCombo";
			this.PaperSizeCombo.Size = new System.Drawing.Size (224, 26);
			this.PaperSizeCombo.TabIndex = 19;
			// 
			// HeightLabel
			// 
			this.HeightLabel.Font = new System.Drawing.Font ("Tahoma", 16f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((System.Byte)(0)));
			this.HeightLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.HeightLabel.Location = new System.Drawing.Point (136, 264);
			this.HeightLabel.Name = "HeightLabel";
			this.HeightLabel.Size = new System.Drawing.Size (80, 24);
			this.HeightLabel.TabIndex = 15;
			this.HeightLabel.Text = "Height";
			// 
			// WidthLabel
			// 
			this.WidthLabel.Font = new System.Drawing.Font ("Tahoma", 16f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((System.Byte)(0)));
			this.WidthLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.WidthLabel.Location = new System.Drawing.Point (136, 232);
			this.WidthLabel.Name = "WidthLabel";
			this.WidthLabel.Size = new System.Drawing.Size (64, 24);
			this.WidthLabel.TabIndex = 13;
			this.WidthLabel.Text = "Width";
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.Enabled = false;
			this.numericUpDown1.Font = new System.Drawing.Font ("Tahoma", 16f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((System.Byte)(0)));
			this.numericUpDown1.Location = new System.Drawing.Point (216, 232);
			this.numericUpDown1.Maximum = new System.Decimal (new int[] { 10000, 0, 0, 0 });
			this.numericUpDown1.Minimum = new System.Decimal (new int[] { 50, 0, 0, 0 });
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size (80, 27);
			this.numericUpDown1.TabIndex = 14;
			this.numericUpDown1.Value = new System.Decimal (new int[] { 200, 0, 0, 0 });
			// 
			// numericUpDown2
			// 
			this.numericUpDown2.Enabled = false;
			this.numericUpDown2.Font = new System.Drawing.Font ("Tahoma", 16f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((System.Byte)(0)));
			this.numericUpDown2.Location = new System.Drawing.Point (216, 264);
			this.numericUpDown2.Maximum = new System.Decimal (new int[] { 10000, 0, 0, 0 });
			this.numericUpDown2.Minimum = new System.Decimal (new int[] { 50, 0, 0, 0 });
			this.numericUpDown2.Name = "numericUpDown2";
			this.numericUpDown2.Size = new System.Drawing.Size (80, 27);
			this.numericUpDown2.TabIndex = 16;
			this.numericUpDown2.Value = new System.Decimal (new int[] { 200, 0, 0, 0 });
			// 
			// CustomPaperRadio
			// 
			this.CustomPaperRadio.Font = new System.Drawing.Font ("Tahoma", 16f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((System.Byte)(0)));
			this.CustomPaperRadio.Location = new System.Drawing.Point (88, 200);
			this.CustomPaperRadio.Name = "CustomPaperRadio";
			this.CustomPaperRadio.Size = new System.Drawing.Size (488, 24);
			this.CustomPaperRadio.TabIndex = 12;
			this.CustomPaperRadio.Text = "Use custom paper size";
			this.CustomPaperRadio.CheckedChanged += new System.EventHandler (this.RadioButton2CheckedChanged);
			// 
			// StandardPaperRadio
			// 
			this.StandardPaperRadio.Checked = true;
			this.StandardPaperRadio.Font = new System.Drawing.Font ("Tahoma", 16f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((System.Byte)(0)));
			this.StandardPaperRadio.Location = new System.Drawing.Point (88, 112);
			this.StandardPaperRadio.Name = "StandardPaperRadio";
			this.StandardPaperRadio.Size = new System.Drawing.Size (480, 24);
			this.StandardPaperRadio.TabIndex = 11;
			this.StandardPaperRadio.TabStop = true;
			this.StandardPaperRadio.Text = "Use standard paper size";
			this.StandardPaperRadio.CheckedChanged += new System.EventHandler (this.RadioButton2CheckedChanged);
			// 
			// label7
			// 
			this.label7.Font = new System.Drawing.Font ("Tahoma", 16f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((System.Byte)(0)));
			this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label7.Location = new System.Drawing.Point (304, 264);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size (48, 24);
			this.label7.TabIndex = 18;
			this.label7.Text = "mm";
			// 
			// label8
			// 
			this.label8.Font = new System.Drawing.Font ("Tahoma", 16f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((System.Byte)(0)));
			this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label8.Location = new System.Drawing.Point (304, 232);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size (48, 24);
			this.label8.TabIndex = 17;
			this.label8.Text = "mm";
			
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit ();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit ();
			
			this.Controls.Add (this.PortraitSymbol);
			this.Controls.Add (this.LandscapeSymbol);
			this.Controls.Add (this.PaperAlignCombo);
			this.Controls.Add (this.PaperSizeCombo);
			this.Controls.Add (this.label7);
			this.Controls.Add (this.label8);
			this.Controls.Add (this.numericUpDown1);
			this.Controls.Add (this.numericUpDown2);
			this.Controls.Add (this.HeightLabel);
			this.Controls.Add (this.WidthLabel);
			this.Controls.Add (this.CustomPaperRadio);
			this.Controls.Add (this.StandardPaperRadio);
			this.Controls.Add (this.PaperSizeLabel);
		}
		
		void ComboBox2SelectedIndexChanged (object sender, System.EventArgs e)
		{
			PortraitSymbol.Visible = PaperAlignCombo.SelectedIndex == 0;
			LandscapeSymbol.Visible = PaperAlignCombo.SelectedIndex == 1;
		}

		void RadioButton2CheckedChanged (object sender, System.EventArgs e)
		{
			PaperSizeCombo.Enabled = StandardPaperRadio.Checked;
			PaperAlignCombo.Enabled = StandardPaperRadio.Checked;
			numericUpDown1.Enabled = CustomPaperRadio.Checked;
			numericUpDown2.Enabled = CustomPaperRadio.Checked;
		}
		
		public override void beforeShowHandler ()
		{
			if (PaperSizeCombo.SelectedIndex < 0)
				PaperSizeCombo.SelectedIndex = 0;
			if (PaperAlignCombo.SelectedIndex < 0)
				PaperAlignCombo.SelectedIndex = 0;
		}
		
		public override void afterLeaveHandler ()
		{
			if (StandardPaperRadio.Checked) {
				decimal s1 = 0, s2 = 0;
				switch (PaperSizeCombo.SelectedIndex) {
				case 0:
					s1 = 210m;
					s2 = 297m;
					break;
				case 1:
					s1 = 297m;
					s2 = 420m;
					break;
				case 2:
					s1 = 216m;
					s2 = 279m;
					break;
				case 3:
					s1 = 216m;
					s2 = 356m;
					break;
				}
				
				if (PaperAlignCombo.SelectedIndex == 0) {
					Rasterbator.currentJob.PaperWidthDecimal = s1;
					Rasterbator.currentJob.PaperHeightDecimal = s2;
				} else {
					Rasterbator.currentJob.PaperWidthDecimal = s2;
					Rasterbator.currentJob.PaperHeightDecimal = s1;
				}
				
			} else {
				Rasterbator.currentJob.PaperWidthDecimal = numericUpDown1.Value;
				Rasterbator.currentJob.PaperHeightDecimal = numericUpDown2.Value;
			}
		}
	}
}