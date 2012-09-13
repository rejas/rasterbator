using System;
using System.Drawing;

namespace Rasterbator
{
	public class RasterJob
	{
		public String OriginalFilename;
		public String TargetFilename;
		
		// paper size in mm
		public decimal PaperWidthDecimal = 210m;
		public decimal PaperHeightDecimal = 297m;
		
		public int OutputWidth, OutputHeight;
		
		public Bitmap OriginalImage = null;
		
		public decimal RasterSize;
		public String RasterColor;
		
		public bool UseRectangles = false;
		public bool CroppingRectangle = false;
		
		public RasterJob ()
		{
		}
	}
}
