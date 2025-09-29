using System;
using System.Collections.Specialized;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 共通画面条件クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 共通画面に必要な条件を定義したクラスです。</br>
	/// <br>Programer  : 18012  Y.Sasaki</br>
	/// <br>Date       : 2005.11.24</br>
	/// <br>Update Note:</br>
	/// </remarks>
	[Serializable]
	public class SFCMN00293UC
	{
		/// <summary>印刷範囲</summary>
		/// <remarks>0:全てのページ,1:ページ指定</remarks>
		private int _printRange;

		/// <summary>印刷開始ページ</summary>
		/// <remarks>印刷を開始するページを指定</remarks>
		private int _printTopPage;
		
		/// <summary>印刷終了ページ</summary>
		/// <remarks>印刷を終了するページを指定</remarks>
		private int _printEndPage;
		
		/// <summary>上余白</summary>
		/// <remarks>上余白を指定</remarks>
		private int _marginsTop;

		/// <summary>下余白</summary>
		/// <remarks>下余白を指定</remarks>
		private int _marginsBottom;

		/// <summary>左余白</summary>
		/// <remarks>左余白を指定</remarks>
		private int _marginsLeft;
		
		/// <summary>右余白</summary>
		/// <remarks>右余白を指定</remarks>
		private int _marginsRight;
		
		/// <summary>拡大率</summary>
		/// <remarks>0～800%</remarks>
		private int _expansionRate;

		/// <summary>プリンター名称</summary>
		/// <remarks>プリンタの名称</remarks>
		private string _printerName = "";

		/// <summary>印刷モード</summary>
		/// <remarks>1:プリンタ,2:ＰＤＦ,3:両方</remarks>
		private int _printMode;

		/// <summary>印刷件数</summary>
		/// <remarks>印刷するデータの件数</remarks>
		private int _printMax;

		/// <summary>帳票フォームID</summary>
		/// <remarks>印刷する帳票フォームID</remarks>
		private string _outputFormID;
		
		/// <summary>印刷書類名</summary>
		/// <remarks>印刷する書類名称</remarks>
		private string _printName;
		
		/// <summary>ＰＤＦ出力パス</summary>
		/// <remarks>ＰＤＦの出力先(フルパス)</remarks>
		private string _pdfFullPath;
		
		/// <summary>印字位置調整</summary>
		/// <remarks>[0:しない,1:する]</remarks>
		private int _printPositionAdjust;
		
		/// <summary>印刷時コントロール非表示リスト</summary>
		/// <remarks>印刷時に非表示にするコントロールの名前リスト</remarks>
		private StringCollection _hideControlList = null;
		
		/// <summary>ステータス</summary>
		/// <remarks>印刷ステータス</remarks>
		private int _status;
		
		/// public propaty name  :  PrintRange
		/// <summary>印刷範囲プロパティ</summary>
		/// <value>0:全てのページ 1:指定ページ</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   印刷範囲プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public int PrintRange
		{
			get{return _printRange;}
			set{_printRange = value;}
		}

		/// public propaty name  :  PrintTopPage
		/// <summary>印刷開始ページプロパティ</summary>
		/// <value>印刷開始ページ</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   印刷開始ページプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public int PrintTopPage
		{
			get{return _printTopPage;}
			set{_printTopPage = value;}
		}

		/// public propaty name  :  PrintEndPage
		/// <summary>印刷終了ページプロパティ</summary>
		/// <value>印刷終了ページ</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   印刷終了ページプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public int PrintEndPage
		{
			get{return _printEndPage;}
			set{_printEndPage = value;}
		}

		/// public propaty name  :  MarginsTop
		/// <summary>上余白プロパティ</summary>
		/// <value>上余白</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   上余白プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public int MarginsTop
		{
			get{return _marginsTop;}
			set{_marginsTop = value;}
		}

		/// public propaty name  :  MarginsBottom
		/// <summary>下余白プロパティ</summary>
		/// <value>下余白</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   下余白プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public int MarginsBottom
		{
			get{return _marginsBottom;}
			set{_marginsBottom = value;}
		}

		/// public propaty name  :  MarginsLeft
		/// <summary>左余白プロパティ</summary>
		/// <value>左余白</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   左余白プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public int MarginsLeft
		{
			get{return _marginsLeft;}
			set{_marginsLeft = value;}
		}

		/// public propaty name  :  MarginsRight
		/// <summary>右余白プロパティ</summary>
		/// <value>右余白</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   右余白プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public int MarginsRight
		{
			get{return _marginsRight;}
			set{_marginsRight = value;}
		}
		
		
		/// public propaty name  :  ExpansionRate
		/// <summary>拡大率プロパティ</summary>
		/// <value>拡大率</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   拡大率プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public int ExpansionRate
		{
			get{return _expansionRate;}
			set{_expansionRate = value;}
		}
		
		/// public propaty name  :  PrinterName
		/// <summary>プリンタ名称プロパティ</summary>
		/// <value></value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   プリンタ名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string PrinterName
		{
			get{return _printerName;}
			set{_printerName = value;}
		}
		
		/// public propaty name  :  PrinterMode
		/// <summary>印刷モードプロパティ</summary>
		/// <value></value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   印刷モードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public int PrintMode
		{
			get{return _printMode;}
			set{_printMode = value;}
		}

		/// public propaty name  :  PrintMax
		/// <summary>印刷件数プロパティ</summary>
		/// <value></value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   印刷件数プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public int PrintMax
		{
			get{return _printMax;}
			set{_printMax = value;}
		}

		/// public propaty name  :  PrintName
		/// <summary>帳票フォームIDプロパティ</summary>
		/// <value></value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   帳票フォームIDプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string OutputFormID
		{
			get{return _outputFormID;}
			set{_outputFormID = value;}
		}
		
		/// public propaty name  :  PrintName
		/// <summary>印刷書類名称プロパティ</summary>
		/// <value></value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   印刷書類名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string PrintName
		{
			get{return _printName;}
			set{_printName = value;}
		}

		/// public propaty name  :  PdfFullPath
		/// <summary>ＰＤＦ出力先プロパティ</summary>
		/// <value></value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ＰＤＦ出力先プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string PdfFullPath
		{
			get{return _pdfFullPath;}
			set{_pdfFullPath = value;}
		}

		/// public propaty name  :  PrintPositionAdjust
		/// <summary>印字位置調整プロパティ</summary>
		/// <value>[0:しない,1:する]</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   印字位置調整プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public int PrintPositionAdjust
		{
			get{return _printPositionAdjust;}
			set{_printPositionAdjust = value;}
		}

		/// public propaty name  :  HideControlList
		/// <summary>印刷時コントロール非表示リストプロパティ</summary>
		/// <value>印刷時に非表示にするコントロールの名前リスト</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   印刷時コントロール非表示リストプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public StringCollection HideControlList
		{
			get{return _hideControlList;}
			set{_hideControlList = value;}
		}
		
		/// public propaty name  :  Status
		/// <summary>印刷ステータスプロパティ</summary>
		/// <value>印刷ステータス</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   印刷ステータス</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public int Status
		{
			get{return _status;}
			set{_status = value;}
		}

		/// <summary>
		/// 共通画面条件クラスコンストラクタ
		/// </summary>
		/// <returns>SFCMN00293UCクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :  SFCMN00293UCクラスの新しいインスタンスを生成します</br>
		/// <br>Programer       :   自動生成</br>
		/// </remarks>
		public SFCMN00293UC()
		{
		}
	}
}
