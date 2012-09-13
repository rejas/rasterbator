// The Rasterbator Standalone Version 1.3
// Copyright (C) 2004-2010 Matias Ärje
// 
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Collections.Specialized;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

using Dr = System.Drawing;

namespace Rasterbator
{
	public class RasterLogic
	{
		private RasterJob currentJob;
		
		private int Resolution = 144;

		// amount of squares in one page
		private int SquaresX, SquaresY;

		// paper size in pixels
		private int PaperSizeX, PaperSizeY;

		// paper is divided into squares, circle centers will be placed at square centers
		private float SquareSize;

		// Area of the original image to utilize
		private int x1, x2, y1, y2;

		// source area in pixels
		private int AreaWidth, AreaHeight;

		// output image width in pixels
		private int ImageWidth, ImageHeight;

		private float MaxRadius;

		// paper size in dots (pdfwriter units)
		private float psx, psy;

		// output color
		private int R, G, B;
		
		private bool UseAverageColor = false;
		
		private Bitmap Source;
		private BitmapData SourceData;
		private bool OptimizeGetPixel = false;

		private int TotalPages = 0, PagesDone = 0;

		private Document D;
		private PdfWriter P;
		private PdfContentByte C;

		public string ErrorMessage = "";
		
		public RasterLogic (RasterJob c)
		{
			currentJob = c;
		}

		public void Go ()
		{
			try {
				CreateImage ();
			} catch (Exception E) {
				ErrorMessage = E.Message + " " + E.StackTrace;
			}
		}

		public void CreateImage ()
		{
			ImageWidth = (int)(Convert.ToInt32 (currentJob.OutputWidth) / 25.4 * Resolution);
			ImageHeight = (int)(Convert.ToInt32 (currentJob.OutputHeight) / 25.4 * Resolution);
			
			int PaperWidthInt = Convert.ToInt32 (currentJob.PaperWidthDecimal);
			int PaperHeightInt = Convert.ToInt32 (currentJob.PaperHeightDecimal);
			
			// paper size in pixels
			PaperSizeX = (int)(PaperWidthInt / 25.4 * Resolution);
			PaperSizeY = (int)(PaperHeightInt / 25.4 * Resolution);
			
			MaxRadius = (float)Convert.ToDecimal (currentJob.RasterSize) / 25.4f * Resolution / 2f;
			
			if (currentJob.RasterColor == "avg") {
				UseAverageColor = true;
			} else {
				R = int.Parse (currentJob.RasterColor.Substring (0, 2), System.Globalization.NumberStyles.HexNumber);
				G = int.Parse (currentJob.RasterColor.Substring (2, 2), System.Globalization.NumberStyles.HexNumber);
				B = int.Parse (currentJob.RasterColor.Substring (4, 2), System.Globalization.NumberStyles.HexNumber);
			}
			
			double XAspect = currentJob.OriginalImage.Width / currentJob.OriginalImage.Width;
			double YAspect = currentJob.OriginalImage.Height / currentJob.OriginalImage.Height;
			
			// Area of the original image to utilize
			x1 = (int)(0 * XAspect);
			x2 = (int)(currentJob.OriginalImage.Width * XAspect);
			y1 = (int)(0 * YAspect);
			y2 = (int)(currentJob.OriginalImage.Height * YAspect);
			
			AreaWidth = x2 - x1;
			AreaHeight = y2 - y1;
			
			Source = new Bitmap (currentJob.OriginalFilename);
			
			int PagesX = (int)Math.Ceiling ((double)(currentJob.OutputWidth / Convert.ToDouble(currentJob.PaperWidthDecimal)));
			int PagesY = (int)Math.Ceiling ((double)(currentJob.OutputHeight / Convert.ToDouble(currentJob.PaperHeightDecimal)));
			
			// paper is divided into squares, circle centers will be placed at square centers
			SquareSize = (float)(2f * ((float)MaxRadius - 1f) / Math.Sqrt (2f));
			
			// amount of squares in one page
			SquaresX = (int)(PaperSizeX / SquareSize);
			SquaresY = (int)(PaperSizeY / SquareSize);
			
			psx = 72f * (float)PaperWidthInt / 25.4f;
			psy = 72f * (float)PaperHeightInt / 25.4f;
			
			D = new Document (new iTextSharp.text.Rectangle (psx, psy), 0, 0, 0, 0);
			P = PdfWriter.GetInstance(D, new FileStream (currentJob.TargetFilename, FileMode.Create));
			P.ViewerPreferences = PdfWriter.FitWindow;
			D.AddTitle ("Rasterbation");
			D.AddCreator ("The Rasterbator at http://homokaasu.org/rasterbator/");
			D.Open ();
			
			C = P.DirectContent;
			
			TotalPages = PagesX * PagesY;
			
			// if the pixel format is easy to read directly from bitmap data, use the optimized method
			if (Source.PixelFormat == PixelFormat.Format32bppArgb || Source.PixelFormat == PixelFormat.Format24bppRgb)
				OptimizeGetPixel = true;
			
			if (OptimizeGetPixel)
				SourceData = Source.LockBits (new Dr.Rectangle (0, 0, Source.Width, Source.Height), ImageLockMode.ReadOnly, Source.PixelFormat);
			
			PagesDone = 0;
			for (int py = 0; py < PagesY; py++)
				for (int px = 0; px < PagesX; px++) {
					RasterbatePage (px, py);
					PagesDone++;
				}
			if (OptimizeGetPixel)
				Source.UnlockBits (SourceData);
			
			D.Close ();
			Source.Dispose ();
		}

		public double Progress {
			get {
				if (TotalPages == 0)
					return 0;
				return (double)PagesDone / (double)TotalPages;
			}
		}

		// optimized but unsafe and very fast get pixel for common pixel formats
		unsafe private Dr.Color GetSourcePixel (int x, int y)
		{
			byte* bp = (byte*)SourceData.Scan0;
			switch (SourceData.PixelFormat) {
			case PixelFormat.Format32bppArgb:
				bp += (x * 4) + (y * SourceData.Stride);
				return Dr.Color.FromArgb (*(bp + 3), *(bp + 2), *(bp + 1), *bp);
			case PixelFormat.Format24bppRgb:
				bp += (x * 3) + (y * SourceData.Stride);
				return Dr.Color.FromArgb (*(bp + 2), *(bp + 1), *bp);
			}
			return Dr.Color.Empty;
		}

		private void RasterbatePage (int px, int py)
		{
			if (!UseAverageColor)
				C.SetRGBColorFill (R, G, B);
			
			// loops every square of the page
			
			float MaxX = float.MinValue;
			float MaxY = float.MinValue;
			
			int pxs = PaperSizeX * px;
			int pys = PaperSizeY * py;
			float awr = (float)AreaWidth / (float)ImageWidth;
			// area width ratio
			float ahr = (float)AreaHeight / (float)ImageHeight;
			// area height ratio
			// from -1 to +1 since large circles in adjoining pages may partially be visible in this page also.
			for (int sy = -1; sy < SquaresY + 1; sy++) {
				
				// this square top pixel in aggregate coordinates of all papers
				int ThisSquareY = (int)(pys + sy * SquareSize);
				
				// square mapped to source image:
				int sy1 = (int)(y1 + ThisSquareY * ahr);
				if (sy1 >= y2)
					break;
				// out of boundary - skip remainder column
				int sy2 = (int)(y1 + (ThisSquareY + SquareSize) * ahr);
				
				for (int sx = -1; sx < SquaresX + 1; sx++) {
					
					// this square left pixel in aggregate coordinates of all papers
					int ThisSquareX = (int)(pxs + sx * SquareSize);
					
					// square mapped to source image:
					int sx1 = (int)(x1 + ThisSquareX * awr);
					if (sx1 >= x2)
						break;
					// out of boundary - skip remainder row
					int sx2 = (int)(x1 + (ThisSquareX + SquareSize) * awr);
					
					// calculates average brightness
					float Brightness = 0;
					float c = 0;
					float coc = 0;
					float r = 0, g = 0, b = 0;
					for (int @by = sy1; @by <= sy2; @by++)
						for (int bx = sx1; bx <= sx2; bx++) {
							c++;
							if (bx >= Source.Width || @by >= Source.Height || bx > x2 || @by > y2 || bx < 0 || @by < 0) {
								Brightness += 1;
								continue;
							}
							
							Dr.Color P = OptimizeGetPixel ? GetSourcePixel (bx, @by) : Source.GetPixel (bx, @by);
							Brightness += P.GetBrightness ();
							if (!UseAverageColor)
								continue;
							
							coc++;
							r += P.R;
							g += P.G;
							b += P.B;
						}
					
					float Radius = (1 - Brightness / c) * MaxRadius;
					
					float ex = (sx + 0.5f) * SquareSize / 2f;
					float ey = (sy + 0.5f) * SquareSize / 2f;
					
					if (UseAverageColor)
						C.SetRGBColorFill ((int)(r / coc), (int)(g / coc), (int)(b / coc));
					
					if(Radius/2 > 0) //speed improvement from rasterbator-ng
					{
						if (currentJob.UseRectangles)
							C.Rectangle(ex + ((MaxRadius - Radius)/2) ,(psy-ey) + ((MaxRadius - Radius)/2),Radius,Radius); 
						else 
							C.Circle(ex, psy-ey, Radius/2);
					}
					
					ex += SquareSize / 4;
					ey += SquareSize / 4;
					
					if (ex > MaxX)
						MaxX = ex;
					if (ey > MaxY)
						MaxY = ey;
					
					C.Fill ();
				}
			}
			
			float rx = SquaresX * SquareSize / 2;
			float ry = SquaresY * SquareSize / 2;
			
			if (MaxX < rx)
				rx = MaxX;
			if (MaxY < ry)
				ry = MaxY;
			
			// remove bleed
			C.SetRGBColorFill (255, 255, 255);
			C.Rectangle (-SquareSize, 0, psx + SquareSize, -SquareSize);
			// top
			C.Fill ();
			C.Rectangle (-SquareSize, -SquareSize, 0, SquareSize);
			// left
			C.Fill ();
			C.Rectangle (rx, -SquareSize, SquareSize, psy + SquareSize);
			// right
			C.Fill ();
			C.Rectangle (-SquareSize, psy - ry, psx + SquareSize, -SquareSize);
			// bottom
			C.Fill ();
			
			if (currentJob.CroppingRectangle) {
				C.SetLineWidth(0.5f);
				C.MoveTo (0, psy);
				
				C.SetRGBColorStroke (0xbb, 0xbb, 0xbb);
				
				C.LineTo (rx, psy);
				C.LineTo (rx, psy - ry);
				C.LineTo (0, psy - ry);
				C.LineTo (0, psy);
				
				C.Stroke ();
			}
			
			D.NewPage ();
		}
	}
}