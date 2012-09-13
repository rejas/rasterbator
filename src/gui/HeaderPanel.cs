using System;
using System.Windows.Forms;

namespace Rasterbator
{
	public class HeaderPanel : Panel
	{
		private Panel TitleBg = new Panel();
		private PictureBox pictureBox1 = new PictureBox();
		
		public HeaderPanel ()
		{
			this.pictureBox1.Image = ((System.Drawing.Image)(Rasterbator.resources.GetObject ("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point (0, 0);
			this.pictureBox1.Size = new System.Drawing.Size (1142, 128);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			
			this.TitleBg.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));
			this.TitleBg.BackColor = System.Drawing.Color.FromArgb (((System.Byte)(89)), ((System.Byte)(16)), ((System.Byte)(16)));
			this.TitleBg.Location = new System.Drawing.Point (0, 0);
			this.TitleBg.Size = new System.Drawing.Size (696, 128);
			this.TitleBg.TabIndex = 16;
			
			this.Controls.Add (this.pictureBox1);
			this.Controls.Add (this.TitleBg);
		}
	}
}