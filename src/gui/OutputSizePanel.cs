using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Rasterbator
{
	public class OutputSizePanel : AssistantPage
	{
		private Bitmap DisplayImage = null;
		private ComboBox MeasureDimensionCombo = new ComboBox();
		private PictureBox pictureBox2 = new PictureBox();
		private Label label11 = new Label();
		private NumericUpDown numericUpDown4 = new NumericUpDown();
		private Label OutputSizeLabel = new Label();
		private Label SheetsLabel = new Label();
		
		public OutputSizePanel ()
		{
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).BeginInit ();
			
			// 
			// pictureBox2
			// 
			this.pictureBox2.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));
			this.pictureBox2.Location = new System.Drawing.Point (32, 48);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size (300, 300);
			this.pictureBox2.TabIndex = 21;
			this.pictureBox2.TabStop = false;
			// 
			// label11
			// 
			this.label11.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
			this.label11.Font = new System.Drawing.Font ("Tahoma", 16f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((System.Byte)(0)));
			this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label11.Location = new System.Drawing.Point (360, 176);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size (304, 112);
			this.label11.TabIndex = 15;
			// 
			// SheetsLabel
			// 
			this.SheetsLabel.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
			this.SheetsLabel.Font = new System.Drawing.Font ("Tahoma", 16f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((System.Byte)(0)));
			this.SheetsLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.SheetsLabel.Location = new System.Drawing.Point (448, 106);
			this.SheetsLabel.Name = "SheetsLabel";
			this.SheetsLabel.Size = new System.Drawing.Size (64, 24);
			this.SheetsLabel.TabIndex = 13;
			this.SheetsLabel.Text = "sheets";
			// 
			// OutputSizeLabel
			// 
			this.OutputSizeLabel.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
			this.OutputSizeLabel.Font = new System.Drawing.Font ("Tahoma", 16f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, ((System.Byte)(0)));
			this.OutputSizeLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.OutputSizeLabel.Location = new System.Drawing.Point (352, 40);
			this.OutputSizeLabel.Name = "OutputSizeLabel";
			this.OutputSizeLabel.Size = new System.Drawing.Size (312, 48);
			this.OutputSizeLabel.TabIndex = 8;
			this.OutputSizeLabel.Text = "Define output size (3/5)";
			// 
			// numericUpDown4
			// 
			this.numericUpDown4.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
			this.numericUpDown4.DecimalPlaces = 1;
			this.numericUpDown4.Font = new System.Drawing.Font ("Tahoma", 16f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((System.Byte)(0)));
			this.numericUpDown4.Location = new System.Drawing.Point (360, 104);
			this.numericUpDown4.Maximum = new System.Decimal (new int[] { 1000, 0, 0, 0 });
			this.numericUpDown4.Minimum = new System.Decimal (new int[] { 1, 0, 0, 0 });
			this.numericUpDown4.Name = "numericUpDown4";
			this.numericUpDown4.Size = new System.Drawing.Size (80, 27);
			this.numericUpDown4.TabIndex = 14;
			this.numericUpDown4.Value = new System.Decimal (new int[] { 5, 0, 0, 0 });
			this.numericUpDown4.ValueChanged += new System.EventHandler (this.NumericUpDown4ValueChanged);
			// 
			// MeasureDimensionCombo
			// 
			this.MeasureDimensionCombo.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
			this.MeasureDimensionCombo.DropDownStyle = ComboBoxStyle.DropDownList;
			this.MeasureDimensionCombo.Font = new System.Drawing.Font ("Tahoma", 15f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((System.Byte)(0)));
			this.MeasureDimensionCombo.Items.AddRange (new object[] { "wide", "high" });
			this.MeasureDimensionCombo.Location = new System.Drawing.Point (520, 104);
			this.MeasureDimensionCombo.Name = "MeasureDimensionCombo";
			this.MeasureDimensionCombo.Size = new System.Drawing.Size (88, 26);
			this.MeasureDimensionCombo.TabIndex = 22;
			this.MeasureDimensionCombo.SelectedIndexChanged += new System.EventHandler (this.NumericUpDown4ValueChanged);
			
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).EndInit ();
			
			this.Controls.Add (this.MeasureDimensionCombo);
			this.Controls.Add (this.pictureBox2);
			this.Controls.Add (this.label11);
			this.Controls.Add (this.numericUpDown4);
			this.Controls.Add (this.SheetsLabel);
			this.Controls.Add (this.OutputSizeLabel);
		}
		
		public override void beforeShowHandler ()
		{
			if (MeasureDimensionCombo.SelectedIndex < 0)
				MeasureDimensionCombo.SelectedIndex = 0;
			
			int d;
			if (pictureBox2.Width < pictureBox2.Height)
				d = pictureBox2.Width;
			else
				d = pictureBox2.Height;
			
			double w, h;
			if (Rasterbator.currentJob.OriginalImage.Width > Rasterbator.currentJob.OriginalImage.Height) {
				w = d;
				h = d * (double)Rasterbator.currentJob.OriginalImage.Height / (double)Rasterbator.currentJob.OriginalImage.Width;
			} else {
				h = d;
				w = d * (double)Rasterbator.currentJob.OriginalImage.Width / (double)Rasterbator.currentJob.OriginalImage.Height;
			}
			DisplayImage = new Bitmap (Rasterbator.currentJob.OriginalImage, new Size ((int)w, (int)h));
			
			DisplayPaging ();
		}
		
		void NumericUpDown4ValueChanged (object sender, System.EventArgs e)
		{
			DisplayPaging ();
		}
		
		void DisplayPaging ()
		{
			if (DisplayImage == null)
				return;
			
			int d;
			if (pictureBox2.Width <pictureBox2.Height)
				d = pictureBox2.Width;
			else
				d = pictureBox2.Height;
			
			decimal w = DisplayImage.Width;
			decimal h = DisplayImage.Height;
			Bitmap B = new Bitmap (DisplayImage);
			Graphics G = Graphics.FromImage (B);
			
			decimal Pages = numericUpDown4.Value;
			
			bool AdjustWidth = true;
			if (MeasureDimensionCombo.SelectedIndex == 1)
				AdjustWidth = false;
			
			decimal DisplayPageWidth = 1, DisplayPageHeight = 1, PagesX = 1, PagesY = 1;
			
			if (AdjustWidth) {
				DisplayPageWidth = w / Pages;
				DisplayPageHeight = Rasterbator.currentJob.PaperHeightDecimal / Rasterbator.currentJob.PaperWidthDecimal * DisplayPageWidth;
				PagesX = Pages;
				PagesY = Rasterbator.currentJob.PaperWidthDecimal / Rasterbator.currentJob.PaperHeightDecimal * PagesX * h / w;
			} else {
				DisplayPageHeight = h / Pages;
				DisplayPageWidth = Rasterbator.currentJob.PaperWidthDecimal / Rasterbator.currentJob.PaperHeightDecimal * DisplayPageHeight;
				PagesY = Pages;
				PagesX = Rasterbator.currentJob.PaperHeightDecimal / Rasterbator.currentJob.PaperWidthDecimal * PagesY * w / h;
			}
			
			Pen DarkPen = new Pen (Color.FromArgb (0x88, 0, 0, 0));
			Pen LightPen = new Pen (Color.FromArgb (0x88, 255, 255, 255));
			
			decimal p = DisplayPageWidth;
			while (p < w) {
				int x = (int)Math.Round (p);
				G.DrawLine (LightPen, x, 0, x, (int)h);
				G.DrawLine (DarkPen, x + 1, 0, x + 1, (int)h);
				p += DisplayPageWidth;
			}
			
			p = DisplayPageHeight;
			while (p < h) {
				int y = (int)Math.Round (p);
				G.DrawLine (LightPen, 0, y, (int)w, y);
				G.DrawLine (DarkPen, 0, y + 1, (int)w, y + 1);
				p += DisplayPageHeight;
			}
			
			G.Save ();
			G.Dispose ();
			
			Bitmap B2 = new Bitmap (d, d);
			
			G = Graphics.FromImage (B2);
			G.FillRectangle (new SolidBrush (Color.White), 0, 0, d, d);
			
			TextureBrush TB = new TextureBrush (B, WrapMode.Clamp);
			TB.TranslateTransform ((int)Math.Round ((d - (decimal)w) / 2), (int)Math.Round (((decimal)d - h) / 2));
			
			G.FillRectangle (TB, (int)Math.Round (((decimal)d - w) / 2), (int)Math.Round (((decimal)d - h) / 2), (int)w, (int)h);
			G.Save ();
			
			pictureBox2.Image = B2 as Image;
			
			int px = (int)Math.Ceiling ((double)PagesX);
			int py = (int)Math.Ceiling ((double)PagesY);
			
			string Stats = "";
			
			decimal OutputWidth = Rasterbator.currentJob.PaperWidthDecimal * PagesX;
			decimal OutputHeight = Rasterbator.currentJob.PaperHeightDecimal * PagesY;
			
			if (OutputWidth > 1000 || OutputHeight > 1000)
				Stats = Rasterbator.labels["OutputImageSize"] + "\n" + (OutputWidth / 1000).ToString ("f2") + " x " + (OutputHeight / 1000).ToString ("f2") + " m\n\n";
			else
				Stats = Rasterbator.labels["OutputImageSize"] + "\n" + (OutputWidth / 10).ToString ("f1") + " x " + (OutputHeight / 10).ToString ("f1") + " cm\n\n";
			
			Stats += Rasterbator.labels["PaperConsumption"] + "\n" + px + " x " + py + " = " + (px * py) + " " + Rasterbator.labels["sheet" + (px * py == 1 ? "" : "s")];
			
			Rasterbator.currentJob.OutputWidth = (int)OutputWidth;
			Rasterbator.currentJob.OutputHeight = (int)OutputHeight;
			
			label11.Text = Stats;
		}
	}
}