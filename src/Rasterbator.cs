// The Rasterbator Standalone Version 1.4.2
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
using System.Xml;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Collections;
using System.Collections.Specialized;
using System.Windows.Forms;
using System.ComponentModel;

namespace Rasterbator
{
	public class Rasterbator : Form
	{
		public static RasterLogic logic;

		public static Hashtable labels = new Hashtable ();

		public static System.Resources.ResourceManager resources = new System.Resources.ResourceManager ("Rasterbator.src.Rasterbator", Assembly.GetExecutingAssembly ());

		public static RasterJob currentJob = new RasterJob ();

		private HeaderPanel headerPanel = new HeaderPanel ();
		private AssistantControl tabControl1 = new AssistantControl ();

		private WelcomePanel panel1_Welcome = new WelcomePanel ();
		private SourceFilePanel panel2_SourceImage = new SourceFilePanel ();
		private PaperSizePanel panel3_PaperSize = new PaperSizePanel ();
		private OutputSizePanel panel4_OutputSize = new OutputSizePanel ();
		private OptionsPanel panel5_Options = new OptionsPanel ();
		private OutputFilePanel panel6_OutputFilename = new OutputFilePanel ();
		private RasterbatingPanel panel7_Rasterbating = new RasterbatingPanel ();
		private CompletedPanel panel8_Completed = new CompletedPanel ();

		private Size _standardPanelSize = new Size (702, 413);

		string[] LanguageFileNames = null;
		string ApplicationDirectory = "";
		string ResourceDirectory = "";

		[STAThread]
		public static void Main (string[] args)
		{
			// TODO console version
			if (args.Length > 0)
				Console.WriteLine ("Command line mode not yet supported.");
			
			Application.EnableVisualStyles ();
			Application.Run (new Rasterbator ());
		}

		public Rasterbator ()
		{
			this.panel1_Welcome.SuspendLayout ();
			this.panel2_SourceImage.SuspendLayout ();
			this.panel3_PaperSize.SuspendLayout ();
			this.panel4_OutputSize.SuspendLayout ();
			this.panel5_Options.SuspendLayout ();
			this.panel6_OutputFilename.SuspendLayout ();
			this.panel7_Rasterbating.SuspendLayout ();
			this.panel8_Completed.SuspendLayout ();
			this.SuspendLayout ();
			// 
			// Panel1_Welcome
			// 
			this.panel1_Welcome.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));
			this.panel1_Welcome.Size = _standardPanelSize;
			this.panel1_Welcome.LanguageListBox.SelectedIndexChanged += new System.EventHandler (this.LanguageListBoxSelectedIndexChanged);
			// 
			// Panel2_SourceImage
			// 
			this.panel2_SourceImage.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));
			this.panel2_SourceImage.Size = _standardPanelSize;
			// 
			// Panel3_PaperSize
			// 
			this.panel3_PaperSize.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));
			this.panel3_PaperSize.Size = _standardPanelSize;
			// 
			// Panel4_OutputSize
			// 
			this.panel4_OutputSize.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));
			this.panel4_OutputSize.Size = _standardPanelSize;
			// 
			// Panel5_Options
			// 
			this.panel5_Options.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));
			this.panel5_Options.Size = _standardPanelSize;
			// 
			// Panel6_OutputFilename
			// 
			this.panel6_OutputFilename.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));
			this.panel6_OutputFilename.Size = _standardPanelSize;
			// 
			// Panel7_Rasterbating
			// 
			this.panel7_Rasterbating.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));
			this.panel7_Rasterbating.Size = _standardPanelSize;
			// 
			// Panel8_Completed
			// 
			this.panel8_Completed.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));
			this.panel8_Completed.Size = _standardPanelSize;
			
			// 
			// MainForm
			// 
			//this.AutoScaleBaseSize = new Size (5, 13);// see http://www.mono-project.com/FAQ:_Winforms#My_forms_are_sized_improperly
			//this.ClientSize = new Size (692, 523);
			//this.Resize += new System.EventHandler (this.MainFormResize);
			
			headerPanel.Size = new Size (696, 128);
			tabControl1.Location = new Point (-6, 107);
			tabControl1.Size = _standardPanelSize;
			tabControl1.AddPage (panel1_Welcome);
			tabControl1.AddPage (panel2_SourceImage);
			tabControl1.AddPage (panel3_PaperSize);
			tabControl1.AddPage (panel4_OutputSize);
			tabControl1.AddPage (panel5_Options);
			tabControl1.AddPage (panel6_OutputFilename);
			tabControl1.AddPage (panel7_Rasterbating);
			tabControl1.AddPage (panel8_Completed);
			
			this.Controls.Add (headerPanel);
			this.Controls.Add (tabControl1);
			
			this.Icon = ((Icon)(resources.GetObject ("$this.Icon")));
			this.Size = new Size (700, 550);
			this.Text = "The Rasterbator";
			this.Load += new System.EventHandler (this.MainFormLoad);
			this.FormBorderStyle = FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			
			this.panel8_Completed.ResumeLayout (false);
			this.panel7_Rasterbating.ResumeLayout (false);
			this.panel6_OutputFilename.ResumeLayout (false);
			this.panel5_Options.ResumeLayout (false);
			this.panel4_OutputSize.ResumeLayout (false);
			this.panel3_PaperSize.ResumeLayout (false);
			this.panel2_SourceImage.ResumeLayout (false);
			this.panel1_Welcome.ResumeLayout (false);
			this.ResumeLayout (false);

			this.CenterToScreen();
		}

		bool CheckFile (string dir, string filename)
		{
			if (File.Exists (dir + filename))
				return true;
			MessageBox.Show ("Cannot find file " + filename + " - make sure it is in the installation directory (" + dir + "). Cannot continue, sorry.");
			return false;
		}

		Control FindControl (Control Source, string s)
		{
			foreach (Control C in Source.Controls) {
				if (C.Name == s)
					return C;
				Control c = FindControl (C, s);
				if (c != null)
					return c;
			}
			return null;
		}

		void LanguageListBoxSelectedIndexChanged (object sender, System.EventArgs e)
		{
			try {
				XmlTextReader Rdr = new XmlTextReader (LanguageFileNames[panel1_Welcome.LanguageListBox.SelectedIndex]);
				labels.Clear ();
				while (Rdr.Read ()) {
					if (Rdr.NodeType != XmlNodeType.Element)
						continue;
					if (Rdr.Name != "item")
						continue;
					
					string n = Rdr.GetAttribute ("name");
					string s = Rdr.ReadElementString ();
					
					Control C = FindControl (this, n);
					
					labels[n] = s;
					
					if (C is Label)
						(C as Label).Text = s;
					if (C is Button)
						(C as Button).Text = s;
					if (C is CheckBox)
						(C as CheckBox).Text = s;
					if (C is RadioButton)
						(C as RadioButton).Text = s;
					if (C is ComboBox) {
						string[] p = s.Split ('|');
						for (int i = 0; i < p.Length; i++)
							(C as ComboBox).Items[i] = p[i];
					}
					if (C is LinkLabel) {
						// prevent running of processes
						if (!s.ToLower ().StartsWith ("http://"))
							s = "";
						try {
							new Uri (s);
							// check
							(C as LinkLabel).Text = s;
							(C as LinkLabel).Visible = true;
						} catch {
							(C as LinkLabel).Visible = false;
							(C as LinkLabel).Text = "";
						}
					}
				}
				Rdr.Close ();
			} catch (Exception E) {
				MessageBox.Show ("Error in language data file " + LanguageFileNames[panel1_Welcome.LanguageListBox.SelectedIndex] + " - " + E.Message);
			}
		}

		void MainFormLoad (object sender, System.EventArgs e)
		{
			ApplicationDirectory = Assembly.GetExecutingAssembly ().Location;
			ApplicationDirectory = ApplicationDirectory.Substring (0, ApplicationDirectory.LastIndexOf (Path.DirectorySeparatorChar) + 1);
			ResourceDirectory = ApplicationDirectory + "../Resources" + Path.DirectorySeparatorChar;
			
			if (!CheckFile (ApplicationDirectory, "itextsharp.dll")) {
				Close ();
				return;
			}
			
			if (!CheckFile (ApplicationDirectory, "ICSharpCode.SharpZipLib.dll")) {
				Close ();
				return;
			}
			
			if (!Directory.Exists (ResourceDirectory + "languages")) {
				MessageBox.Show ("The language data directory (" + ResourceDirectory + "languages) seems to be missing. Please extract the language directory from the archive file.");
				Close ();
			}
			
			panel1_Welcome.LanguageListBox.Items.Clear ();
			LanguageFileNames = Directory.GetFiles (ResourceDirectory + "languages");
			foreach (string s in LanguageFileNames) {
				XmlTextReader Rdr = null;
				try {
					Rdr = new XmlTextReader (s);
					while (Rdr.Read ()) {
						if (Rdr.NodeType != XmlNodeType.Element)
							continue;
						if (Rdr.Name == "language") {
							string lt = Rdr.GetAttribute ("nativename");
							if (Rdr.GetAttribute ("englishname") != null)
								lt = Rdr.GetAttribute ("englishname") + " (" + lt + ")";
							panel1_Welcome.LanguageListBox.Items.Add (lt);
							string ISOLanguageName = Rdr.GetAttribute ("TwoLetterISOLanguageName");
							if ((lt.ToLower () == "english") & (panel1_Welcome.LanguageListBox.SelectedIndex == -1)) {
								panel1_Welcome.LanguageListBox.SelectedIndex = panel1_Welcome.LanguageListBox.Items.Count - 1;
							}
							if (ISOLanguageName == System.Globalization.CultureInfo.CurrentCulture.TwoLetterISOLanguageName) {
								panel1_Welcome.LanguageListBox.SelectedIndex = panel1_Welcome.LanguageListBox.Items.Count - 1;
							}
						}
					}
					Rdr.Close ();
				} catch (Exception E) {
					MessageBox.Show ("Error in language data file " + s + " - " + E.Message);
					Rdr.Close ();
				}
			}
			
			if (panel1_Welcome.LanguageListBox.Items.Count == 0) {
				MessageBox.Show ("Could not find any language files. Please extract the language directory from the archive file.");
				Close ();
			}
		}
	}
}
