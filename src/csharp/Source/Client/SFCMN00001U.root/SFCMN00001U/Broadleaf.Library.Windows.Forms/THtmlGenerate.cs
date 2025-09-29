using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Xsl;
namespace Broadleaf.Library.Windows.Forms
{
	[ToolboxBitmap(typeof(THtmlGenerate), "THtmlGenerate.bmp")]
	public class THtmlGenerate : Component
	{
		private Container components;
		private string errmsg = "";
		private string[,] wkarray = new string[0, 0];
		private Color _haikeicolor;
		private eColType gcoltype;
		private align _align;
		private int lBorderWidth = 1;
		private bool titletype = true;
		private Color tcolor;
		private Color tfontcolor;
		private int ltitlefontsize = 1;
		private bool guusuubackcolor;
		private Color gcolor;
		private Color gfontcolor;
		private int lgyofontsize = 1;
		private Color selectbkcolor;
		private int gcoltypeint;
		private bool _coltype = true;
		private Color _koteicolcolor;
		private Color _koteifontcolor;
		private Color _rowcolor;
		public int[] Coltypes = new int[0];
		private int _Brcount;
		[Category("WindowStyle"), DefaultValue(1), Description("テーブルに囲い線の太さを指定します")]
		public int BoderWidth
		{
			get
			{
				return this.lBorderWidth;
			}
			set
			{
				this.lBorderWidth = value;
			}
		}
		[Category("WindowStyle"), DefaultValue(true), Description("タイトル行を出力するかしないかの設定/取得を行います。")]
		public bool TitleRow
		{
			get
			{
				return this.titletype;
			}
			set
			{
				this.titletype = value;
			}
		}
		[Category("WindowStyle"), DefaultValue(eColType.clNone), Description("最初の列にチェックボックス、選択ボタンを設置するかどうかの設定、取得を行います。clNone:なし clCheckBox:チェックボックス clSelectBotton:選択")]
		public eColType FirstColtype
		{
			get
			{
				return this.gcoltype;
			}
			set
			{
				this.gcoltype = value;
				this.gcoltypeint = (int)this.gcoltype;
			}
		}
		[Category("WindowStyle"), DefaultValue(align.left), Description("テーブルの右、中央、左寄せの設定を行います。left:左寄せ center:中央寄せ right:右寄せ")]
		public align Align
		{
			get
			{
				return this._align;
			}
			set
			{
				this._align = value;
			}
		}
		[Category("WindowStyle"), Description("タイトル行のフォント色を設定します")]
		public Color TitleFontColor
		{
			get
			{
				return this.tfontcolor;
			}
			set
			{
				this.tfontcolor = value;
			}
		}
		[Category("WindowStyle"), DefaultValue(1), Description("タイトル行のフォントサイズを指定します。（1～7)")]
		public int TitleFontSize
		{
			get
			{
				return this.ltitlefontsize;
			}
			set
			{
				if (value < 1 || value > 7)
				{
					MessageBox.Show("１～７の範囲");
					return;
				}
				this.ltitlefontsize = value;
			}
		}
		[Category("WindowStyle"), DefaultValue(false), Description("偶数行の背景色を変更する。")]
		public bool GuusuuRow
		{
			get
			{
				return this.guusuubackcolor;
			}
			set
			{
				this.guusuubackcolor = value;
			}
		}
		[Category("WindowStyle"), Description("背景色を設定します")]
		public Color HaikeiColor
		{
			get
			{
				return this._haikeicolor;
			}
			set
			{
				this._haikeicolor = value;
			}
		}
		[Category("WindowStyle"), Description("行の背景色を設定します")]
		public Color RowFontColor
		{
			get
			{
				return this.gfontcolor;
			}
			set
			{
				this.gfontcolor = value;
			}
		}
		[Category("WindowStyle"), DefaultValue(1), Description("タイトル行のフォントサイズの設定を行います")]
		public int RowFontSize
		{
			get
			{
				return this.lgyofontsize;
			}
			set
			{
				if (value < 1 || value > 7)
				{
					MessageBox.Show("１～７の範囲");
					return;
				}
				this.lgyofontsize = value;
			}
		}
		[Category("WindowStyle"), Description("タイトル行の背景色を設定します")]
		public Color TitleColor
		{
			get
			{
				return this.tcolor;
			}
			set
			{
				this.tcolor = value;
			}
		}
		[Category("WindowStyle"), Description("偶数行の背景色を設定します")]
		public Color Guusuucolor
		{
			get
			{
				return this.gcolor;
			}
			set
			{
				this.gcolor = value;
			}
		}
		[Category("WindowStyle"), DefaultValue("Blue"), Description("選択行の背景色を設定します")]
		public Color SelectedBackColor
		{
			get
			{
				return this.selectbkcolor;
			}
			set
			{
				this.selectbkcolor = value;
			}
		}
		[Category("WindowStyle"), DefaultValue(0), Description("文字タイプ")]
		public int ColtypeString
		{
			get
			{
				return 0;
			}
		}
		[Category("WindowStyle"), DefaultValue(1), Description("数値タイプ")]
		public int ColtypeNumber
		{
			get
			{
				return 1;
			}
		}
		[Category("WindowStyle"), DefaultValue(2), Description("画像タイプ")]
		public int ColtypeImage
		{
			get
			{
				return 2;
			}
		}
		[Category("WindowStyle"), DefaultValue(false), Description("固定列有り無し")]
		public bool coltype
		{
			get
			{
				return this._coltype;
			}
			set
			{
				this._coltype = value;
			}
		}
		[Category("WindowStyle"), DefaultValue("Blue"), Description("固定列の背景色を設定します")]
		public Color koteicolcolor
		{
			get
			{
				return this._koteicolcolor;
			}
			set
			{
				this._koteicolcolor = value;
			}
		}
		[Category("WindowStyle"), DefaultValue("Blue"), Description("固定列のフォント色を設定します")]
		public Color koteifontcolor
		{
			get
			{
				return this._koteifontcolor;
			}
			set
			{
				this._koteifontcolor = value;
			}
		}
		[Category("WindowStyle"), DefaultValue(0), Description("ブランク(<BR>)の個数を指定します。（テーブル開始Ｙ軸設定）")]
		public int HightBR
		{
			get
			{
				return this._Brcount;
			}
			set
			{
				this._Brcount = value;
			}
		}
		[Category("WindowStyle"), Description("通常行の背景色を指定します")]
		public Color RowBackColor
		{
			get
			{
				return this._rowcolor;
			}
			set
			{
				this._rowcolor = value;
			}
		}
		public THtmlGenerate(IContainer container)
		{
			container.Add(this);
			this.InitializeComponent();
			this._align = align.left;
			this.gcoltype = eColType.clNone;
		}
		public THtmlGenerate()
		{
			this.InitializeComponent();
		}
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}
		private void InitializeComponent()
		{
			this.components = new Container();
		}
		public int ShowXmltohtmlGrid(string stylepath, string xmlpath, ref string htmlcode)
		{
			string text = Guid.NewGuid().ToString();
			try
			{
				XslCompiledTransform xslCompiledTransform = new XslCompiledTransform();
				if (!File.Exists(stylepath))
				{
					int result = 4;
					return result;
				}
				xslCompiledTransform.Load(stylepath);
				XmlDocument xmlDocument = new XmlDocument();
				if (!File.Exists(xmlpath))
				{
					int result = 5;
					return result;
				}
				xmlDocument.Load(xmlpath);
				new FileInfo(xmlpath);
				XmlTextWriter xmlTextWriter = new XmlTextWriter(text, null);
				xslCompiledTransform.Transform(xmlDocument.CreateNavigator(), null, xmlTextWriter);
				xmlTextWriter.Close();
				StreamReader streamReader = new StreamReader(text);
				htmlcode = streamReader.ReadToEnd();
				streamReader.Close();
				if (File.Exists(text))
				{
					File.Delete(text);
				}
				htmlcode = htmlcode.Replace("%dir%", Directory.GetCurrentDirectory() + "\\");
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message.ToString());
				this.errmsg = ex.Message.ToString();
				int result = 9;
				return result;
			}
			return 0;
		}
		public int ShowXmltohtmlGrid2(string stylepath, string xmlcode, ref string htmlcode)
		{
			string text = Guid.NewGuid().ToString();
			try
			{
				XslCompiledTransform xslCompiledTransform = new XslCompiledTransform();
				if (!File.Exists(stylepath))
				{
					int result = 4;
					return result;
				}
				xslCompiledTransform.Load(stylepath);
				XmlDocument xmlDocument = new XmlDocument();
				if (xmlcode.Length == 1)
				{
					int result = 5;
					return result;
				}
				xmlDocument.LoadXml(xmlcode);
				new FileInfo(stylepath);
				XmlTextWriter xmlTextWriter = new XmlTextWriter(text, null);
				xslCompiledTransform.Transform(xmlDocument.CreateNavigator(), null, xmlTextWriter);
				new XmlTextReader(text);
				xmlTextWriter.Close();
				StreamReader streamReader = new StreamReader(text);
				htmlcode = streamReader.ReadToEnd();
				streamReader.Close();
				if (File.Exists(text))
				{
					File.Delete(text);
				}
				htmlcode = htmlcode.Replace("%dir%", Directory.GetCurrentDirectory() + "\\");
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message.ToString());
				this.errmsg = ex.Message.ToString();
				int result = 9;
				return result;
			}
			return 0;
		}
		public int ShowArrayStringtoGridwithProperty(string[,] array, ref string htmlcode)
		{
			this.wkarray = new string[array.GetLength(0), array.GetLength(1)];
			this.wkarray = array;
			try
			{
				htmlcode = this.makehtmlcode(this.wkarray);
				htmlcode = htmlcode.Replace("%dir%", Directory.GetCurrentDirectory() + "\\");
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message.ToString());
				this.errmsg = ex.Message.ToString();
				return 9;
			}
			return 0;
		}
		public int ShowArrayStringtoGridwithStyleSheet(string stylepath, string[,] array, ref string htmlcode)
		{
			string text = Guid.NewGuid().ToString();
			try
			{
				XslCompiledTransform xslCompiledTransform = new XslCompiledTransform();
				if (!File.Exists(stylepath))
				{
					int result = 4;
					return result;
				}
				xslCompiledTransform.Load(stylepath);
				XmlDocument xmlDocument = new XmlDocument();
				string xml = this.makeXmlcode(array, stylepath);
				xmlDocument.LoadXml(xml);
				new FileInfo(stylepath);
				XmlTextWriter xmlTextWriter = new XmlTextWriter(text, null);
				xslCompiledTransform.Transform(xmlDocument.CreateNavigator(), null, xmlTextWriter);
				xmlTextWriter.Close();
				StreamReader streamReader = new StreamReader(text);
				htmlcode = streamReader.ReadToEnd();
				streamReader.Close();
				if (File.Exists(text))
				{
					File.Delete(text);
				}
				htmlcode = htmlcode.Replace("%dir%", Directory.GetCurrentDirectory() + "\\");
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message.ToString());
				this.errmsg = ex.Message.ToString();
				int result = 9;
				return result;
			}
			return 0;
		}
		public int MakeSryHtmlViewWithXML(string stylepath, ref string htmlcode)
		{
			string text = Guid.NewGuid().ToString();
			try
			{
				XslCompiledTransform xslCompiledTransform = new XslCompiledTransform();
				if (!File.Exists(stylepath))
				{
					int result = 4;
					return result;
				}
				xslCompiledTransform.Load(stylepath);
				XmlDocument xmlDocument = new XmlDocument();
				string xml = this.makesryXmlcode(stylepath);
				xmlDocument.LoadXml(xml);
				new FileInfo(stylepath);
				XmlTextWriter xmlTextWriter = new XmlTextWriter(text, null);
				xslCompiledTransform.Transform(xmlDocument.CreateNavigator(), null, xmlTextWriter);
				xmlTextWriter.Close();
				StreamReader streamReader = new StreamReader(text);
				htmlcode = streamReader.ReadToEnd();
				streamReader.Close();
				File.Delete(text);
				htmlcode = htmlcode.Replace("%dir%", Directory.GetCurrentDirectory() + "\\");
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message.ToString());
				this.errmsg = ex.Message.ToString();
				int result = 9;
				return result;
			}
			return 0;
		}
		public int MakeTokHtmlViewWithXSL(string stylepath, ref string htmlcode)
		{
			string text = Guid.NewGuid().ToString();
			try
			{
				XslCompiledTransform xslCompiledTransform = new XslCompiledTransform();
				if (!File.Exists(stylepath))
				{
					int result = 4;
					return result;
				}
				xslCompiledTransform.Load(stylepath);
				XmlDocument xmlDocument = new XmlDocument();
				string xml = this.maketokXmlcode(stylepath);
				xmlDocument.LoadXml(xml);
				new FileInfo(stylepath);
				XmlTextWriter xmlTextWriter = new XmlTextWriter(text, null);
				xslCompiledTransform.Transform(xmlDocument.CreateNavigator(), null, xmlTextWriter);
				xmlTextWriter.Close();
				StreamReader streamReader = new StreamReader(text);
				htmlcode = streamReader.ReadToEnd();
				streamReader.Close();
				File.Delete(text);
				htmlcode = htmlcode.Replace("%dir%", Directory.GetCurrentDirectory() + "\\");
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message.ToString());
				this.errmsg = ex.Message.ToString();
				int result = 9;
				return result;
			}
			return 0;
		}
		private string makesryXmlcode(string stylepath)
		{
			string str = "<?xml-stylesheet href=\"" + stylepath + "\" type=\"text/xsl\"?> <SryData> ";
			return str + "</SryData>";
		}
		private string maketokXmlcode(string stylepath)
		{
			string str = "<?xml-stylesheet href=\"" + stylepath + "\" type=\"text/xsl\"?> <TokData> ";
			return str + "</TokData>";
		}
		private string makehtmlcode(string[,] array)
		{
			return string.Concat(new string[]
			{
				"<html> <head> ",
				this.makescript(),
				"<META http-equiv=\"content-type\" content=\"text/html;charset=utf-8\" /> </head> <body bgcolor=rgb(",
				this._haikeicolor.R.ToString(),
				",",
				this._haikeicolor.G.ToString(),
				",",
				this._haikeicolor.B.ToString(),
				")> ",
				this.tablemake(array),
				"</body> </html> "
			});
		}
		private string makescript()
		{
			return "<SCRIPT LANGUAGE=\"JavaScript\" > function checkOn(e){ \tvar atostr = e; \tvar wkstr = \"\"; \tvar offset = 0; \tfor ( var lp = 1 ; offset != -1 ;lp++ ) \t{ \t\tvar offset = atostr.indexOf('@'); \t\tif(offset == -1) \t\t{ \t\t\tif ( atostr.length == 0 ) \t\t\t\t\tcontinue; \t\t\telse \t\t\t\twkstr = atostr.substring(0,atostr.length); \t\t} \t\t\telse \t\t\twkstr = atostr.substring(0,offset); \t\t\td =  document.getElementsByName(wkstr); \t\t\td[0].checked = true; \t\t\tatostr = atostr.substring(offset+1,atostr.length); \t\t} } function checkOff(e){ \tvar atostr = e; \tvar wkstr = \"\"; \tvar offset = 0; \tfor ( var lp = 1 ; offset != -1 ;lp++ ) \t{ \t\tvar offset = atostr.indexOf('@'); \t\tif(offset == -1) \t\t{ \t\t\tif ( atostr.length == 0 ) \t\t\t\t\tcontinue; \t\t\telse \t\t\t\twkstr = atostr.substring(0,atostr.length); \t\t} \t\t\telse \t\t\twkstr = atostr.substring(0,offset); \t\t\td =  document.getElementsByName(wkstr); \t\t\td[0].checked = false; \t\t\tatostr = atostr.substring(offset+1,atostr.length); \t\t} } function sendmsg(elem)\t{ \tdocument.frm.sel.value = elem.name; \tdocument.frm.submit(); } function changeRowColor(i,bkcolor)\t{ \ttable.rows[i].style.backgroundColor=bkcolor; } </SCRIPT> ";
		}
		private string tablemake(string[,] array)
		{
			string text = "";
			switch (this._align)
			{
			case align.center:
				text += "<DIV align=\"center\">";
				break;
			case align.right:
				text += "<DIV align=\"right\">";
				break;
			}
			for (int i = 0; i < this._Brcount; i++)
			{
				text += "<BR>";
			}
			text = text + "<table id=\"table\" border=\"" + this.lBorderWidth.ToString() + "\"> ";
			if (this.titletype)
			{
				if (this.gcoltypeint != 0)
				{
					string text2 = text;
					text = string.Concat(new string[]
					{
						text2,
						"<tr BGCOLOR=rgb(",
						this.tcolor.R.ToString(),
						",",
						this.tcolor.G.ToString(),
						",",
						this.tcolor.B.ToString(),
						")> <th></th> "
					});
				}
				else
				{
					string text3 = text;
					text = string.Concat(new string[]
					{
						text3,
						"<tr BGCOLOR=rgb(",
						this.tcolor.R.ToString(),
						",",
						this.tcolor.G.ToString(),
						",",
						this.tcolor.B.ToString(),
						")> "
					});
				}
				for (int j = 0; j < array.GetLength(1); j++)
				{
					string text4 = text;
					text = string.Concat(new string[]
					{
						text4,
						"<th><font color=rgb(",
						this.tfontcolor.R.ToString(),
						",",
						this.tfontcolor.G.ToString(),
						",",
						this.tfontcolor.B.ToString(),
						") font=\"",
						this.ltitlefontsize.ToString(),
						"\">",
						array[0, j],
						"</font></th> "
					});
				}
				text += "</tr> ";
			}
			text += "<form method=\"post\" name=\"frm\"> ";
			int k;
			if (this.titletype)
			{
				k = 1;
			}
			else
			{
				k = 0;
			}
			while (k < array.GetLength(0))
			{
				if (k % 2 == 0 && this.GuusuuRow)
				{
					string text5 = text;
					text = string.Concat(new string[]
					{
						text5,
						"<tr BGCOLOR=rgb(",
						this.gcolor.R.ToString(),
						",",
						this.gcolor.G.ToString(),
						",",
						this.gcolor.B.ToString(),
						")> "
					});
				}
				else
				{
					string text6 = text;
					text = string.Concat(new string[]
					{
						text6,
						"<tr BGCOLOR=rgb(",
						this._rowcolor.R.ToString(),
						",",
						this._rowcolor.G.ToString(),
						",",
						this._rowcolor.B.ToString(),
						")> "
					});
				}
				switch (this.gcoltypeint)
				{
				case 1:
					text = text + "<td><input type=\"checkbox\" name=\"" + k.ToString() + "\"></input></td> ";
					break;
				case 2:
					text = text + "<td><input type=\"button\" name=\"" + k.ToString() + "\" VALUE=\"選択\" onClick=\"sendmsg(this)\"></input></td> ";
					break;
				}
				for (int l = 0; l < array.GetLength(1); l++)
				{
					switch (this.Coltypes[l])
					{
					case 0:
						if (this._coltype && l == 0)
						{
							string text7 = text;
							text = string.Concat(new string[]
							{
								text7,
								"<td BGCOLOR=rgb(",
								this._koteicolcolor.R.ToString(),
								",",
								this._koteicolcolor.G.ToString(),
								",",
								this._koteicolcolor.B.ToString(),
								")> "
							});
							string text8 = text;
							text = string.Concat(new string[]
							{
								text8,
								"<font color=rgb(",
								this._koteifontcolor.R.ToString(),
								",",
								this._koteifontcolor.G.ToString(),
								",",
								this._koteifontcolor.B.ToString(),
								") font=\"",
								this.lgyofontsize.ToString(),
								"\">",
								array[k, l].ToString(),
								"</font>"
							});
						}
						else
						{
							text += "<td> ";
							string text9 = text;
							text = string.Concat(new string[]
							{
								text9,
								"<font color=rgb(",
								this.gfontcolor.R.ToString(),
								",",
								this.gfontcolor.G.ToString(),
								",",
								this.gfontcolor.B.ToString(),
								") font=\"",
								this.lgyofontsize.ToString(),
								"\">",
								array[k, l].ToString(),
								"</font>"
							});
						}
						break;
					case 1:
						if (this._coltype && l == 0)
						{
							string text10 = text;
							text = string.Concat(new string[]
							{
								text10,
								"<td  align=\"right\" BGCOLOR=rgb(",
								this._koteicolcolor.R.ToString(),
								",",
								this._koteicolcolor.G.ToString(),
								",",
								this._koteicolcolor.B.ToString(),
								")> "
							});
							string text11 = text;
							text = string.Concat(new string[]
							{
								text11,
								"<font color=rgb(",
								this._koteifontcolor.R.ToString(),
								",",
								this._koteifontcolor.G.ToString(),
								",",
								this._koteifontcolor.B.ToString(),
								") font=\"",
								this.lgyofontsize.ToString(),
								"\" >",
								this.inttokannma(array[k, l].ToString()),
								"</font>"
							});
						}
						else
						{
							text += "<td align=\"right\"> ";
							string text12 = text;
							text = string.Concat(new string[]
							{
								text12,
								"<font color=rgb(",
								this.gfontcolor.R.ToString(),
								",",
								this.gfontcolor.G.ToString(),
								",",
								this.gfontcolor.B.ToString(),
								") font=\"",
								this.lgyofontsize.ToString(),
								"\" >",
								this.inttokannma(array[k, l].ToString()),
								"</font>"
							});
						}
						break;
					case 2:
						if (this._coltype && l == 0)
						{
							string text2 = text;
							text = string.Concat(new string[]
							{
								text2,
								"<td BGCOLOR=rgb(",
								this._koteicolcolor.R.ToString(),
								",",
								this._koteicolcolor.G.ToString(),
								",",
								this._koteicolcolor.B.ToString(),
								")> "
							});
							text = text + "<IMG SRC=\"" + array[k, l].ToString() + "\"> ";
						}
						else
						{
							text += "<td> ";
							text = text + "<IMG SRC=\"" + array[k, l].ToString() + "\"> ";
						}
						break;
					}
					text += "</td> ";
				}
				text += "</tr> ";
				k++;
			}
			if (this.gcoltypeint == 2)
			{
				text += "<input type=\"hidden\" name=\"sel\" value=\"\"></input> ";
			}
			text += "</form> ";
			text += "</table> ";
			switch (this._align)
			{
			case align.center:
				text += "</DIV>";
				break;
			case align.right:
				text += "</DIV>";
				break;
			}
			return text;
		}
		private string inttokannma(string data)
		{
			string text = "";
			string result = "";
			try
			{
				int num = Convert.ToInt32(data);
				text = string.Format("{0:C}", num);
				result = text.Substring(1, text.Length - 1);
			}
			catch (Exception ex)
			{
				this.errmsg = ex.Message.ToString();
				return text;
			}
			return result;
		}
		private string makeXmlcode(string[,] array, string stylepath)
		{
			string text = "<?xml-stylesheet href=\"" + stylepath + "\" type=\"text/xsl\"?> <NewDataSet> ";
			for (int i = 0; i < array.GetLength(0); i++)
			{
				text += "<WRKTABLE> ";
				for (int j = 0; j < array.GetLength(1); j++)
				{
					string text2 = text;
					text = string.Concat(new string[]
					{
						text2,
						"<A",
						j.ToString(),
						">",
						array[i, j],
						"</A",
						j.ToString(),
						"> "
					});
				}
				text += "</WRKTABLE> ";
			}
			return text + "</NewDataSet>";
		}
	}
}
