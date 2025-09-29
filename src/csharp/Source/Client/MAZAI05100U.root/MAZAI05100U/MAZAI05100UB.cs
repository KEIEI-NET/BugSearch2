using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 棚卸表PDF表示画面
	/// </summary>
	/// <remarks>
	/// <br>Note		: </br>
	/// <br>Programmer	: 23010 中村　仁</br>
	/// <br>Date		: 2007.04.02</br>
	/// <br></br>
	/// </remarks>
	public partial class MAZAI05100UB : Form
	{
		#region コンストラクタ
		// ===================================================================================== //
		// コンストラクタ
		// ===================================================================================== //
		
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public MAZAI05100UB()
		{
			InitializeComponent();
		}
		#endregion
			
		/// <summary>
		/// PDF表示開始
		/// </summary>
		/// <param name="pdfTempPath">PDFファイルパス</param>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note		: </br>
		/// <br>Programmer	: 23010 中村　仁</br>
		/// <br>Date		: 2007.04.03</br>
		/// <br>Update Note	: </br>
		/// </remarks>
		public int ShowPDFPreview(string pdfTempPath)
		{
			int st = -1;

			try
			{
				if (String.IsNullOrEmpty( pdfTempPath ) == false) 
				{
					if (pdfTempPath.Equals("about:blank"))
					{
						this.webBrowser1.Navigate(new Uri( "about:blank" ));		// 現在表示内容をクリア
					}
					else
					{
						this.webBrowser1.Navigate(new Uri( "about:blank" ));		// 現在表示内容をクリア
						this.webBrowser1.Navigate(new Uri( pdfTempPath ));			// ブラウザで表示を行います。
						st = 0;
					}
					st = 0;
				}
			}
			catch (UriFormatException)
			{
			}
			catch (Exception ex)
			{
				TMsgDisp.Show( emErrorLevel.ERR_LEVEL_STOPDISP, this.Name,
					"プレビュー表示に失敗しました。\r\n" + ex.Message, 
					-1, MessageBoxButtons.OK );
			}
			
			return st;
		}
		
	}
}