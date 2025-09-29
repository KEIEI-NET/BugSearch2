using System;

using DataDynamics.ActiveReports.Document;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 印刷プレビューパラメータクラス
	/// </summary>
	/// <remarks>
	/// <br>Note		: プレビュー表示用のパラメータクラスです。</br>
	/// <br>Programmer	: 22024 寺坂　誉志</br>
	/// <br>Date		: 2006.01.12</br>
	/// </remarks>
	public class SFMIT01290UB
	{
		#region Constructor
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public SFMIT01290UB()
		{
		}
		#endregion

		#region PrivateMember
		// 印刷ドキュメント（印刷用）
		private Document _printDocument;
		// 印刷ドキュメント（プレビュー用）
		private Document _previewDocument;
		// PDFパス
		private string _pdfPath;
		// 拡大率
		private int _expansionRate;
		#endregion

		#region Property
		/// <summary>
		/// 印刷ドキュメント（印刷用）
		/// </summary>
		public Document PrintDocument
		{
			get{ return this._printDocument; }
			set{ this._printDocument = value; }
		}

		/// <summary>
		/// 印刷ドキュメント（プレビュー用）
		/// </summary>
		public Document PreviewDocument
		{
			get{ return this._previewDocument; }
			set{ this._previewDocument = value; }
		}

		/// <summary>
		/// PDFパス
		/// </summary>
		public string PdfPath
		{
			get{ return this._pdfPath; }
			set{ this._pdfPath = value; }
		}

		/// <summary>
		/// 拡大率
		/// </summary>
		public int ExpansionRate
		{
			get{ return this._expansionRate; }
			set{ this._expansionRate = value; }
		}
		#endregion
	}
}
