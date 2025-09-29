#define ADD20060407
#define CHG20060417
#define CLR2
#define CHG20060509
using System;
using System.IO;
using System.Threading;
using System.Drawing;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Text;
using Broadleaf.Drawing.Printing;

using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Toolbar;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// ActiveReport共通プレビュー画面クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : ActiveRepotr印刷時の共通プレビュー画面クラスです。</br>
	/// <br>Programmer : 18012 Y.Sasaki</br>
	/// <br>Date       : 2005.11.17</br>
	/// <br>Update Note: 2006.04.07 Y.Sasaki</br>
	/// <br>           : １.品管対応 02204357-2-1-000058-01</br>
	/// <br>           :    矢印キー、Enterキーは無効化しない</br>
	/// <br>Update Note: 2006.04.17 Y.Sasaki</br>
	/// <br>           : １.ＰＤＦ出力タイミングの変更。</br>
	/// <br>           :    印刷時に作成する。</br>
	/// <br>Update Note: 2006.04.20 Y.Sasaki</br>
	/// <br>           : １.VS2005(.NET Framework version 2.0) 対応 </br>
	/// <br>           :    ApartmentStateの設定方法を、2.0で追加されたメソッド使用</br>
	/// <br>Update Note: 2006.04.21 Y.Sasaki</br>
	/// <br>           : １.Thread.Suspend, Thread.Resume を使わないように変更。</br>
	/// <br>Update Note: 2006.05.09 Y.Sasaki</br>
	/// <br>           : １.プレビュー用・印刷用と別々のスレッドで作成しているが、</br>
	/// <br>           :    バインドしているデータが同一データソースだった場合、</br>
	/// <br>           :    タイミングにより問題が発生する為、改良。</br>
	/// <br>Update Note: 2006.07.25 Y.Sasaki</br>
	/// <br>           : １.Visual印字位置調整からプレビューし印刷された場合、</br>
	/// <br>           :    トップレベルウィンドウが変わる現象を解除。</br>
	/// <br>Update Note: 2007.02.28 Y.Sasaki</br>
	/// <br>           : １.携帯.NS用に改良</br>
    /// <br>Update Note: 2012/05/17 yangmj</br>
    /// <br>           : 指定ページ印刷の追加</br>
	/// </remarks>
	public class SFCMN00293UA : System.Windows.Forms.Form
	{
		# region Private Members (Component)
		private DataDynamics.ActiveReports.Viewer.Viewer viewer1;
		private DataDynamics.ActiveReports.Export.Pdf.PdfExport pdfExport1;

		#endregion

		private System.ComponentModel.IContainer components = null;

		//================================================================================
		//  コンストラクター
		//================================================================================
		#region コンストラクター
		/// <summary>
		/// ActiveReport共通プレビュー画面クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 共通プレビュー画面クラスの初期化を行い新しいインスタンスを生成します。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.11.17</br>
		/// </remarks>
		public SFCMN00293UA()
		{
			InitializeComponent();
		
			// ビューワのページ№コントロールを取得
			PlaceHolder	placeHolder = this.viewer1.Toolbar.Tools.ToolById(17) as PlaceHolder;
			if (placeHolder != null)
			{
				// イベントに追加
				placeHolder.Control.TextChanged += new System.EventHandler(this.ViewerPageNumber_TextChanged);
			}
			
			// ビューワのズームコントロールを取得
			PlaceHolder	placeHolder2 = this.viewer1.Toolbar.Tools.ToolById(13) as PlaceHolder;
			if (placeHolder2 != null)
			{
//				// イベントに追加
//				placeHolder2.Control.TextChanged += new System.EventHandler(this.ViewerZoom_TextChanged);
//				placeHolder2.Control.KeyPress += new KeyPressEventHandler(this.ViewerZoom_KeyPress);
//#if ADD20060407				
//				placeHolder2.Control.KeyDown += new KeyEventHandler(this.ViewerZoom_KeyDown);
//#endif
			}
			
			// 共通関数部品インスタンス作成
			this._commonLib = new SFCMN00293UZ();
		
			// 設定ファイル読込
			if (this._commonLib.ReadSettingFile(CT_PrintCommonWindow))
			{
				string wkStr = (string)this._commonLib.ReadSection(CT_PrintPreviewWindow,CT_BackgroundPicture);
				
				// 背景画像コントロールの有無
				this._isBackGroundPicture = (TStrConv.StrToIntDef(wkStr,0) == 1);
			}
		
			// 印字位置調整部品インスタンス作成
			this._positionAdjViewLib  = new SFCMN00294CA();						// 印字位置調整部品(View用)
			this._positionAdjPrtLib   = new SFCMN00294CA();						// 印字位置調整部品(印刷用)
		}
		#endregion

		// ===============================================================================
		// 破棄
		// ===============================================================================
		# region Dispose
		/// <summary>
		/// 使用されているリソースに後処理を実行します。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		#endregion

		// ===============================================================================
		// Windowsフォームデザイナで生成されたコード
		// ===============================================================================
		#region Windows フォーム デザイナで生成されたコード 
		/// <summary>
		/// デザイナ サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディタで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SFCMN00293UA));
			this.viewer1 = new DataDynamics.ActiveReports.Viewer.Viewer();
			this.pdfExport1 = new DataDynamics.ActiveReports.Export.Pdf.PdfExport();
			this.SuspendLayout();
			// 
			// viewer1
			// 
			this.viewer1.BackColor = System.Drawing.SystemColors.Control;
			this.viewer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.viewer1.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.viewer1.Location = new System.Drawing.Point(0, 0);
			this.viewer1.Name = "viewer1";
			this.viewer1.ReportViewer.CurrentPage = 0;
			this.viewer1.ReportViewer.DisplayUnits = DataDynamics.ActiveReports.Viewer.DisplayUnits.Metric;
			this.viewer1.ReportViewer.MultiplePageCols = 3;
			this.viewer1.ReportViewer.MultiplePageRows = 2;
			this.viewer1.ReportViewer.ViewType = DataDynamics.ActiveReports.Viewer.ViewType.Normal;
			this.viewer1.Size = new System.Drawing.Size(1016, 734);
			this.viewer1.TabIndex = 0;
			this.viewer1.TableOfContents.Text = "Contents";
			this.viewer1.TableOfContents.Width = 200;
			this.viewer1.Toolbar.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.viewer1.ToolClick += new DataDynamics.ActiveReports.Toolbar.ToolClickEventHandler(this.viewer1_ToolClick);
			// 
			// pdfExport1
			// 
			this.pdfExport1.Security.Permissions = ((DataDynamics.ActiveReports.Export.Pdf.PdfPermissions)(((((((DataDynamics.ActiveReports.Export.Pdf.PdfPermissions.AllowPrint | DataDynamics.ActiveReports.Export.Pdf.PdfPermissions.AllowModifyContents)
									| DataDynamics.ActiveReports.Export.Pdf.PdfPermissions.AllowCopy)
									| DataDynamics.ActiveReports.Export.Pdf.PdfPermissions.AllowModifyAnnotations)
									| DataDynamics.ActiveReports.Export.Pdf.PdfPermissions.AllowFillIn)
									| DataDynamics.ActiveReports.Export.Pdf.PdfPermissions.AllowAccessibleReaders)
									| DataDynamics.ActiveReports.Export.Pdf.PdfPermissions.AllowAssembly)));
			// 
			// SFCMN00293UA
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
			this.ClientSize = new System.Drawing.Size(1016, 734);
			this.Controls.Add(this.viewer1);
			this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.Name = "SFCMN00293UA";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "印刷プレビュー";
			this.Closed += new System.EventHandler(this.SFCMN00293UA_Closed);
			this.Load += new System.EventHandler(this.SFCMN00293UA_Load);
			this.ResumeLayout(false);

            //--- ADD 2012/05/17 yangmj 指定ページ印刷の追加----->>>>>
            DataDynamics.ActiveReports.Toolbar.Separator separator =new DataDynamics.ActiveReports.Toolbar.Separator();
            separator.Id = 110;
            this.viewer1.Toolbar.Tools.Add(separator);

            DataDynamics.ActiveReports.Toolbar.Button printPageBtn = new DataDynamics.ActiveReports.Toolbar.Button();
            printPageBtn.Caption = "印刷ページ指定";
            printPageBtn.ToolTip = "印刷ページを指定します";
            printPageBtn.ButtonStyle = DataDynamics.ActiveReports.Toolbar.ButtonStyle.Text;
            printPageBtn.Id = 5030;
            this.viewer1.Toolbar.Tools.Add(printPageBtn);
            //--- ADD 2012/05/17 yangmj 指定ページ印刷の追加-----<<<<<
		}
		#endregion

		//================================================================================
		//  内部変数
		//================================================================================
		#region private member    
		// 印刷用レポートインスタンス格納用
		private DataDynamics.ActiveReports.ActiveReport3 _prtRpt  = null;
		// プレビュー用レポートインスタンス格納用
		private DataDynamics.ActiveReports.ActiveReport3 _viewRpt = null;
		
		private ArrayList _rptList = null;													// マージレポートインスタンス格納用		
		private SFCMN00293UC _commonInfo = null;										// 共通設定情報クラス
		private SFCMN00293UZ _commonLib  = null;										// 共通部品クラス
		private int _screenLoadMode;																// 画面起動モード
		private int _watermarkMode = 0;															// 背景画像表示モード
		private string _bufText;																		// ページ№退避用
		private string _bufZoomText;																// ズーム退避用
		private bool _isShowPrintDialog   = true;										// 印刷ダイアログ表示有無
		private bool _isBackGroundPicture = false;									// 背景画像コントロール有無
		
		SFCMN00294CA _positionAdjViewLib  = null;										// 印字位置調整部品(View用)
		SFCMN00294CA _positionAdjPrtLib   = null;										// 印字位置調整部品(印刷用)

		// >>>>> 2006.07.25 Y.Sasaki ADD START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
		private IWin32Window _owner = null;													// トップレベルウィンドウ	
		// <<<<< 2006.07.25 Y.Sasaki ADD END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //

		private bool _isShowing = false;														// 画面表示中フラグ
		#endregion

		//================================================================================
		//  内部定数
		//================================================================================
		#region private constant
		// ツールバーボタンＩＤ
		private const int CT_TOOLBUTTON_PRINT = 5000;								// 「印刷」ボタンID
		private const int CT_TOOLBUTTON_CLOSE = 5020;								// 「閉じる」ボタンID
        private const int CT_TOOLBUTTON_PAGE = 5030;								// 「印刷ページ指定」ボタンID //ADD 2012/05/17 yangmj 指定ページ印刷の追加
		
		//--- 設定ファイル系の定数定義 ---------------------------------------------------
		// 設定ファイル名
		private const string CT_PrintCommonWindow  = "PrintCommonWindow.XML";
		// プレビュー画面のセクション名
		private const string CT_PrintPreviewWindow = "PrintPreviewWindow";
		// 背景画像の設定有無KEY
		private const string CT_BackgroundPicture  = "BackgroundPicture";
		#endregion
		
		delegate void CreateReportDelegate();
		
		//================================================================================
		//  列挙型
		//================================================================================
		#region enum
		/// <summary>画面起動モード</summary>
		private enum ScreenLoadMode : int
		{
			/// <summary>レポート実行・ビュー</summary>
			RunAndViewMode = 0,
			/// <summary>ビュー</summary>
			ViewOnlyMode   = 1
		}
		
		/// <summary>
		/// 背景透かしプレビュー
		/// </summary>
		private enum emWaterMarkMode : int
		{
			/// <summary>通常プレビュー</summary>
			NormalPreview = 0,
			/// <summary>背景透かしプレビュー</summary>
			WaterMarkPreview = 1
		}
		#endregion
		
		//================================================================================
		//  外部提供プロパティ
		//================================================================================
		#region public property
		/// <summary>共通画面条件プロパティ</summary>
		public SFCMN00293UC CommonInfo
		{
			get{return this._commonInfo;}
			set{this._commonInfo = value;}
		}
		
		/// <summary>印刷ダイアログ表示プロパティ</summary>
		/// <value>[T:する,F:しない]</value>
		public bool IsShowPrintDialog
		{
			get{return _isShowPrintDialog;}
			set{_isShowPrintDialog = value;}
		}
		#endregion

		// ===============================================================================
		// メイン
		// ===============================================================================
		#region Main
		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		[STAThread]
		static void Main() 
		{
			System.Windows.Forms.Application.Run(new SFCMN00293UA());
		}
		#endregion

		// ===============================================================================
		// 外部提供関数
		// ===============================================================================
		#region public methods
		/// <summary>
		/// プレビュー表示処理
		/// </summary>
		/// <param name="rpt">対象ActiveReportクラス</param>
		/// <returns>ConstantManagement.MethodResult</returns>
		/// <remarks>
		/// <br>Note       : レポートを生成しながら、生成されたページから順次プレビューします。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.11.17</br>
		/// </remarks>
		public int Run(DataDynamics.ActiveReports.ActiveReport3 rpt)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
			
			this.DialogResult = DialogResult.Cancel;
			
			try
			{
				// 通常プレビューモード
				this._watermarkMode  = (int)emWaterMarkMode.NormalPreview;
			
				// 起動モード設定
				this._screenLoadMode = (int)ScreenLoadMode.RunAndViewMode; 
			
				// レポートインスタンス設定
				this._prtRpt   = rpt;
				this._viewRpt  = rpt;

				// プレビュー画面起動
				// >>>>> 2006.07.25 Y.Sasaki CHG START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
				//				DialogResult dr = this.ShowDialog();
				DialogResult dr = this.ShowDialog(this._owner);
				// <<<<< 2006.07.25 Y.Sasaki CHG END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //
				switch (dr)
				{
					case DialogResult.OK     :
					case DialogResult.None   :
						status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
						break;
					case DialogResult.Cancel :
						status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
						break;
					default:
						break;
				}
			}
			catch(Exception ex)
			{
			
				this._commonLib.TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, ex.Message,
					0, MessageBoxButtons.OK,MessageBoxDefaultButton.Button1);
			}
			
			return status;
		}
		
		/// <summary>
		/// プレビュー表示処理(背景透かしプレビュー)
		/// </summary>
		/// <param name="prtRpt">対象ActiveReportクラス(印刷用)</param>
		/// <param name="viewRpt">対象ActiveReportクラス(プレビュー用)</param>
		/// <returns>ConstantManagement.MethodResult</returns>
		/// <remarks>
		/// <br>Note       : レポートを生成しながら、生成されたページから順次プレビューします。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.11.17</br>
		/// </remarks>
		public int Run(DataDynamics.ActiveReports.ActiveReport3 prtRpt, DataDynamics.ActiveReports.ActiveReport3 viewRpt)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

			this.DialogResult = DialogResult.Cancel;
			try
			{
				// 背景透かしモード
				this._watermarkMode  = (int)emWaterMarkMode.WaterMarkPreview;

				// 起動モード設定
				this._screenLoadMode = (int)ScreenLoadMode.RunAndViewMode; 
			
				this._viewRpt = viewRpt;
				this._prtRpt  = prtRpt;

				// >>>>> 2006.07.25 Y.Sasaki CHG START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
				//				DialogResult dr = this.ShowDialog();
				DialogResult dr = this.ShowDialog(this._owner);
				// <<<<< 2006.07.25 Y.Sasaki CHG END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //
				switch (dr)
				{
					case DialogResult.OK     :
					case DialogResult.None   :
						status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
						break;
					case DialogResult.Cancel :
						status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
						break;
					default:
						break;
				}
			}
			catch(Exception ex)
			{
			
				this._commonLib.TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, ex.Message,
					0, MessageBoxButtons.OK,MessageBoxDefaultButton.Button1);
			}
			return status;
		}
		
		
		/// <summary>
		/// プレビュー表示処理(複数レポートマージ)
		/// </summary>
		/// <param name="rptList">対象ActiveReportリストクラス(印刷用)</param>
		/// <returns>ConstantManagement.MethodResult</returns>
		/// <remarks>
		/// <br>Note       : 複数レポートを生成しながらマージし、生成されたページから順次プレビューします。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.11.17</br>
		/// </remarks>
		public int Run(ArrayList rptList)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

			this.DialogResult = DialogResult.Cancel;
			try
			{
				// 背景透かしモード
				this._watermarkMode  = (int)emWaterMarkMode.NormalPreview;

				// 起動モード設定
				this._screenLoadMode = (int)ScreenLoadMode.RunAndViewMode; 
			
				// 基本レポートの取得
				this._viewRpt = (DataDynamics.ActiveReports.ActiveReport3)rptList[0];
				this._prtRpt  = (DataDynamics.ActiveReports.ActiveReport3)rptList[0];
				
				if (rptList.Count - 1 > 0)
				{
					this._rptList = new ArrayList();
					for (int i = 1; i <= rptList.Count - 1; i++)
					{
						if (rptList[i] is DataDynamics.ActiveReports.ActiveReport3)
						{
							this._rptList.Add(rptList[i]);
						}
					}
				} 
				else 
				{
					this._rptList = null;
				}


				// >>>>> 2006.07.25 Y.Sasaki CHG START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
				//				DialogResult dr = this.ShowDialog();
				DialogResult dr = this.ShowDialog(this._owner);
				// <<<<< 2006.07.25 Y.Sasaki CHG END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //
				switch (dr)
				{
					case DialogResult.OK     :
					case DialogResult.None   :
						status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
						break;
					case DialogResult.Cancel :
						status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
						break;
					default:
						break;
				}
			}
			catch(Exception ex)
			{
			
				this._commonLib.TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, ex.Message,
					0, MessageBoxButtons.OK,MessageBoxDefaultButton.Button1);
			}
			return status;
		}
		
		/// <summary>
		/// プレビュー表示処理(生成済みDocumentプレビュー)
		/// </summary>
		/// <param name="prtRpt">対象ActiveReportクラス</param>
		/// <returns>DialogResult</returns>
		/// <remarks>
		/// <br>Note       : プレビュー画面を表示します。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.11.17</br>
		/// </remarks>
		public int ShowPreview(DataDynamics.ActiveReports.ActiveReport3 prtRpt)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

			this.DialogResult = DialogResult.Cancel;

			// 起動モード設定
			this._screenLoadMode = (int)ScreenLoadMode.ViewOnlyMode; 
		
			this._prtRpt = prtRpt; 
			
			this.viewer1.Document = this._prtRpt.Document;
			this.viewer1.Show();

			// >>>>> 2006.07.25 Y.Sasaki CHG START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
			//				DialogResult dr = this.ShowDialog();
			DialogResult dr = this.ShowDialog(this._owner);
			// <<<<< 2006.07.25 Y.Sasaki CHG END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //
			switch (dr)
			{
				case DialogResult.OK     :
				case DialogResult.None   :
					status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
					break;
				case DialogResult.Cancel :
					status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
					break;
				default:
					break;
			}

			return status;
		}
		
		/// <summary>
		/// プレビュー表示処理
		/// </summary>
		/// <param name="owner">トップレベルウィンドウ</param>
		/// <param name="rpt">対象ActiveReportクラス</param>
		/// <returns>ConstantManagement.MethodResult</returns>
		/// <remarks>
		/// <br>Note       : レポートを生成しながら、生成されたページから順次プレビューします。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2006.07.25</br>
		/// </remarks>
		public int Run(IWin32Window owner, DataDynamics.ActiveReports.ActiveReport3 rpt)
		{
			this._owner = owner;
			return this.Run(rpt);
		}

		/// <summary>
		/// プレビュー表示処理
		/// </summary>
		/// <param name="rpt">対象ActiveReportクラス</param>
		/// <returns>ConstantManagement.MethodResult</returns>
		/// <remarks>
		/// <br>Note       : レポートを生成しながら、生成されたページから順次プレビューします。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.02.17</br>
		/// </remarks>
		public void Show(DataDynamics.ActiveReports.ActiveReport3 rpt)
		{
			try
			{
				this.viewer1.Document = null;
				
				// 通常プレビューモード
				this._watermarkMode = (int)emWaterMarkMode.NormalPreview;

				// 起動モード設定
				this._screenLoadMode = (int)ScreenLoadMode.RunAndViewMode;

				// レポートインスタンス設定
				this._prtRpt = rpt;
				this._viewRpt = rpt;

				// プレビュー画面起動
				if (!this._isShowing)
				{
					this._isShowing = true;
					this.Show();
				}
				else
				{
					// プレビュー用ドキュメント作成スレッド
					Thread prevThread =
						new Thread(new ThreadStart(ShowPreview));

					prevThread.IsBackground = true;
					prevThread.SetApartmentState(ApartmentState.STA);

					prevThread.Start();
				}
			}
			catch (Exception ex)
			{

				this._commonLib.TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, ex.Message,
					0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
			}
		}




		#endregion
		
		// ===============================================================================
		// 内部関数
		// ===============================================================================
		#region private methods
		/// <summary>
		/// 印刷用レポート作成処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : </br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.11.17</br>
		/// </remarks>
		private void CreatePrintReport()
		{
			try
			{
				// 印字位置調整
				this._commonLib.AdjustPrintPosition(ref this._positionAdjPrtLib, ref this._prtRpt, this._commonInfo, false);
				
				// プリンタ情報設定
				string message;
				if (this._commonLib.SetPrinterInfo(ref this._prtRpt, this._commonInfo, out message) != 0) 
				{
					this.DialogResult      = DialogResult.Abort;
					return;
				}

				this._prtRpt.Run();
		
#if !CHG20060417				
				// ------------------------------------------------------//
				// 分析帳票系用の対応                                    //
				// 両方(PDF・プリンタ)印刷モード時にプレビューの段階で   //
				// PDFを作成しておく必要がある。                         //
				// フレームにPDFを表示する為。                           //                    
				// ------------------------------------------------------//
				// 印刷モード = 両方印刷
				if (this._commonInfo.PrintMode == 3)
				{
					// PDF出力
					this.pdfExport1.Export(this._prtRpt.Document, this._commonInfo.PdfFullPath);
				}
#endif
			
			}
			catch (Exception ex)
			{
				throw new ActiveReportPrintException(ex.Message, -1);
			}
		}
		
		/// <summary>
		/// プレビュー表示処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : ドキュメントをプレビュー画面に割り当てレポート作成処理を開始します。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.11.17</br>
		/// </remarks>
		private void CreateReport()
		{
			try
			{
				string message;

				// 印字位置調整
				if (this._watermarkMode == (int)emWaterMarkMode.WaterMarkPreview)
				{
					// 背景画像有り
					this._commonLib.AdjustPrintPosition(ref this._positionAdjViewLib, ref this._viewRpt, this._commonInfo, this._isBackGroundPicture);
				} 
				else 
				{
					this._commonLib.AdjustPrintPosition(ref this._positionAdjViewLib, ref this._viewRpt, this._commonInfo, false);
				}
				
				// プリンタ情報設定
				if (this._commonLib.SetPrinterInfo(ref this._viewRpt, this._commonInfo, out message) != 0) 
				{
					this.DialogResult      = DialogResult.Abort;
					return;
				}

				this.viewer1.Document = this._viewRpt.Document;
				this.viewer1.Show();
				this._viewRpt.Run(true);

				// マージレポートはあるか？
				if (this._rptList != null)
				{
					for (int i = 0; i < this._rptList.Count; i++)
					{
						DataDynamics.ActiveReports.ActiveReport3 wkRpt 
							= (DataDynamics.ActiveReports.ActiveReport3)this._rptList[i];

						// 印字位置調整
						if (this._watermarkMode == (int)emWaterMarkMode.WaterMarkPreview)
						{
							// 背景画像有り
							this._commonLib.AdjustPrintPosition(ref this._positionAdjViewLib, ref wkRpt, this._commonInfo, this._isBackGroundPicture);
						} 
						else 
						{
							this._commonLib.AdjustPrintPosition(ref this._positionAdjViewLib, ref wkRpt, this._commonInfo, false);
						}
						
						// プリンタ情報設定
						if (this._commonLib.SetPrinterInfo(ref wkRpt, this._commonInfo, out message) != 0) 
						{
							this.DialogResult      = DialogResult.Abort;
							return;
						}
						
						wkRpt.Run(true);

						this._viewRpt.Document.Pages.AddRange(wkRpt.Document.Pages);
					}
				}
			
				// ------------------------------------------------------//
				// 分析帳票系用の対応                                    //
				// 両方(PDF・プリンタ)印刷モード時にプレビューの段階で   //
				// PDFを作成しておく必要がある。                         //
				// フレームにPDFを表示する為。                           //                    
				// ------------------------------------------------------//
				
#if !CHG20060417
				// 通常プレビューモードの場合
				if (this._watermarkMode == (int)emWaterMarkMode.NormalPreview)
				{
					// 印刷モード = 両方印刷
					if (this._commonInfo.PrintMode == 3)
					{
						// PDF出力
						this.pdfExport1.Export(this._viewRpt.Document, this._commonInfo.PdfFullPath);
					}
				}
#endif
#if CHG20060509
				if (this._screenLoadMode == (int)ScreenLoadMode.RunAndViewMode)
				{
					// 印刷用ドキュメント作成
					if (this._watermarkMode != (int)emWaterMarkMode.NormalPreview)
					{
						this.CreatePrintReport();
					}
				}
#endif
			}
			catch (Exception ex)
			{
				throw new ActiveReportPrintException(ex.Message + "\n\r" + ex.StackTrace + ex.Source, -1);
			}
		}
		
		/// <summary>
		/// プレビュー表示デリゲート呼出処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : コントロールの基になるウィンドウ ハンドルを所有するスレッド上で、
		///                : プレビュー表示処理デリゲートを実行します。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.11.17</br>
		/// </remarks>
		private void ShowPreview()
		{
			try
			{
				Invoke(new CreateReportDelegate(CreateReport));
			}
			catch (ActiveReportPrintException ex)
			{
				this._commonLib.TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP,
					ex.Message,
					ex.Status,
					MessageBoxButtons.OK,
					MessageBoxDefaultButton.Button1);
				
				this.DialogResult     = DialogResult.Abort;
			}
		}

		/// <summary>
		/// プレビュー画面初期設定
		/// </summary>
		/// <remarks>
		/// <br>Note       : プレビュー画面の初期設定を行います。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.11.17</br>
		/// </remarks>
		private void InitialScreen()
		{
			// 拡大率の設定
			if (this._commonInfo.ExpansionRate != 0)
			{
				float fx = (float)this._commonInfo.ExpansionRate / 100.0F;
				this.viewer1.ReportViewer.Zoom = fx;
			}
			
//			// 「閉じる」アイコン追加
//			this.viewer1.Toolbar.Images.Images.Add(
//				IconResourceManagement.ImageList16.Images[(int)Size16_Index.CLOSE]);

			// 「印刷」ボタンをカスタマイズ
			// デフォルト「印刷」ボタンを削除
			this.viewer1.Toolbar.Tools.RemoveAt(2);

			// カスタム「印刷」ボタンの作成
			DataDynamics.ActiveReports.Toolbar.Button printBtn =
				new DataDynamics.ActiveReports.Toolbar.Button();
			printBtn.Caption     = "印刷";
			printBtn.ToolTip     = "印刷を実行します";
			printBtn.ImageIndex  = 1;
			printBtn.ButtonStyle = DataDynamics.ActiveReports.Toolbar.ButtonStyle.TextAndIcon;
			printBtn.Id          = 5000;

			this.viewer1.Toolbar.Tools.Insert(2, printBtn); 
		
//			// セパレータ作成
//			DataDynamics.ActiveReports.Toolbar.Separator separator1 =
//				new DataDynamics.ActiveReports.Toolbar.Separator();
//			separator1.Id         = 5010;
//
//			this.viewer1.Toolbar.Tools.Add(separator1); 
//		
//
//			// 「閉じる」ボタン作成
//			DataDynamics.ActiveReports.Toolbar.Button closeBtn =
//				new DataDynamics.ActiveReports.Toolbar.Button();
//			closeBtn.Caption     = " 閉じる";
//			closeBtn.ToolTip     = "プレビューを終了します";
//			closeBtn.ImageIndex  = 12;
//			closeBtn.ButtonStyle = DataDynamics.ActiveReports.Toolbar.ButtonStyle.TextAndIcon;
//			closeBtn.Id          = 5020;
//
//			this.viewer1.Toolbar.Tools.Add(closeBtn); 
//		
//			// セパレータ作成
//			DataDynamics.ActiveReports.Toolbar.Separator separator2 =
//				new DataDynamics.ActiveReports.Toolbar.Separator();
//			separator2.Id         = 5030;
//
//			this.viewer1.Toolbar.Tools.Add(separator2); 
		
		}
		
		#endregion
		
		// ===============================================================================
		// コントロールイベント
		// ===============================================================================
		#region control event
		/// <summary>
		/// 画面ロードイベント
		/// </summary>
		/// <param name="sender">イベントオブジェクト</param>
		/// <param name="e">イベント引数</param>
		/// <remarks>
		/// <br>Note        : 画面がロードされた際、発生するイベントです。</br>
		/// <br>Programmer  : 18012 Y.Sasaki</br>
		/// <br>Date        : 2005.11.17</br>
		/// </remarks>
		private void SFCMN00293UA_Load(object sender, System.EventArgs e)
		{
			// 画面初期設定
			this.InitialScreen();
			
			// 印刷完了イベントをイベントハンドラに関連づけます
			this._prtRpt.Document.Printer.EndPrint
				+= new System.Drawing.Printing.PrintEventHandler(onEndPrint);

			if (this._screenLoadMode == (int)ScreenLoadMode.RunAndViewMode)
			{
#if !CHG20060509		// この部分を同期で走らせるように変更
				// 印刷用ドキュメント作成スレッド
				if (this._watermarkMode != (int)emWaterMarkMode.NormalPreview)
				{
					Thread printThread =
						new Thread(new ThreadStart(CreatePrintReport));
			
					printThread.IsBackground   = true;
#if CLR2
					printThread.SetApartmentState(ApartmentState.STA);
#else
					printThread.ApartmentState = ApartmentState.STA;
#endif
					

					printThread.Start();
				}
#endif
				// プレビュー用ドキュメント作成スレッド
				Thread prevThread =
					new Thread(new ThreadStart(ShowPreview));

				prevThread.IsBackground   = true;
#if CLR2
				prevThread.SetApartmentState(ApartmentState.STA);
#else
				prevThread.ApartmentState = ApartmentState.STA;
#endif

				prevThread.Start();
			}
		}

		/// <summary>
		/// ツールバークリックイベント
		/// </summary>
		/// <param name="sender">イベントオブジェクト</param>
		/// <param name="e">イベント引数</param>
		/// <remarks>
		/// <br>Note        : ツールバーをクリック際、発生するイベントです。</br>
		/// <br>Programmer  : 18012 Y.Sasaki</br>
		/// <br>Date        : 2005.11.17</br>
        /// <br>Update Note: 2012/05/17 yangmj</br>
        /// <br>           : 指定ページ印刷の追加</br>
		/// </remarks>
		private void viewer1_ToolClick(object sender, DataDynamics.ActiveReports.Toolbar.ToolClickEventArgs e)
		{
			// レポートインスタンス変更状態フラグ
			bool isRpxCange         = false;
			
			switch (e.Tool.Id)
			{
				case CT_TOOLBUTTON_PRINT:	// 印刷
				{
					Cursor nowCursor = this.Cursor;

					try
					{
						this.Cursor = Cursors.WaitCursor;
					
						if (this._commonInfo != null)
						{
							isRpxCange = ((this._commonInfo.HideControlList != null) && (this._commonInfo.HideControlList.Count > 0));
							
							// 非表示コントロール有無
							if (isRpxCange)
							{
								// コントロール変更
								this.ChangeARCtrlView(ref this._prtRpt, false, this._commonInfo.HideControlList);  

								// プレビュー画面を隠す
								this.Hide();

								// >>>>> 2006.07.25 Y.Sasaki ADD START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
								// 親画面をアクティブに
								if (this.Owner != null)
								{
									this.Owner.Activate();
								}
								// <<<<< 2006.07.25 Y.Sasaki ADD END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //

								// 印刷ドキュメント再作成
								this._prtRpt.Run();
							}
						}
						
#if CHG20060417
						// 印刷モード = 両方印刷
						if (this._commonInfo.PrintMode == 3)
						{
							// PDF出力
							this.pdfExport1.Export(this._prtRpt.Document, this._commonInfo.PdfFullPath);
						}
#endif

						// 印刷実行
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/22 DEL
                        //this._prtRpt.Document.Print(this._isShowPrintDialog,false,false);
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/22 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/22 ADD
                        if ( this._commonLib.PrintDocument( this._isShowPrintDialog, _prtRpt, _commonInfo.PrinterName ) )
                        {
                            // 拡大印刷処理をした場合はonEndPrintの処理が出来ないので直接終了する
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/22 ADD

						// 非表示コントロールに変更有り？
						if (isRpxCange)
						{
							// コントロール変更
							this.ChangeARCtrlView(ref this._prtRpt, true, this._commonInfo.HideControlList);  
						}
					}
					finally
					{
						this.Cursor = nowCursor; 
					}
					
					break;
				}
				case CT_TOOLBUTTON_CLOSE:		// 閉じる
				{
					this.Close();
					break;
				}
                //--- ADD 2012/05/17 yangmj 指定ページ印刷の追加----->>>>>
                case CT_TOOLBUTTON_PAGE:	// 印刷ページ指定
                {
                    SFCMN00293UE pageSet = new SFCMN00293UE();
                    DialogResult dialogRes = pageSet.Show(new Form(), this._viewRpt.Document.Pages.Count);
                    if (dialogRes == DialogResult.OK)
                    {
                        this._commonLib.setPageRange(pageSet.SelectPageList);

                        // 印刷実行
                        if (this._commonLib.PrintDocument(this._isShowPrintDialog, _prtRpt, _commonInfo.PrinterName))
                    {
                            // 拡大印刷処理をした場合はonEndPrintの処理が出来ないので直接終了する
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                    }
                    break;
			}
                //--- ADD 2012/05/17 yangmj 指定ページ印刷の追加-----<<<<<
		}
		}

		/// <summary>
		/// アクティブレポートARControl表示状態制御
		/// </summary>
		/// <param name="rpt">該当レポート</param>
		/// <param name="isVisibled">表示・非表示</param>
		/// <param name="ctrlList">変更するコントロールリスト</param>
		/// <remarks>
		/// <br>Note        : アクティブレポートARControl表示状態を制御します。</br>
		/// <br>Programmer	: 18012 Y.Sasaki</br>
		/// <br>Date		    : 2005.12.05</br>
		/// </remarks>
		private void ChangeARCtrlView(ref ActiveReport3 rpt, bool isVisibled, StringCollection ctrlList)
		{
			foreach (string name in ctrlList)
			{
				foreach (Section wkSection in rpt.Sections)
				{
					try
					{
						ARControl wkControl = wkSection.Controls[name];
						if (wkControl != null)
						{
							wkControl.Visible = isVisibled;
						}
					}
					catch (Exception)
					{
					}
				}
			}
		}
		
		/// <summary>
		/// テキストチェンジイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: ユーザーがテキストを変更した時に発生します。</br>
		/// <br>Programmer	: 18012 Y.Sasaki</br>
		/// <br>Date		: 2005.11.26</br>
		/// </remarks>
		private void ViewerPageNumber_TextChanged(object sender, System.EventArgs e)
		{
			Control control = (Control)sender;
			if (control.Text.Length > int.MaxValue.ToString().Length - 1)
			{
				control.Text = this._bufText;
			}
			else
			{
				this._bufText = control.Text;
			}
		}
		
		/// <summary>
		/// テキストチェンジイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: ユーザーがテキストを変更した時に発生します。</br>
		/// <br>Programmer	: 18012 Y.Sasaki</br>
		/// <br>Date		: 2006.1.13</br>
		/// </remarks>
		private void ViewerZoom_TextChanged(object sender, System.EventArgs e)
		{
			ComboBox comboBox = (ComboBox)sender;
			// パーセント指定の時のみ処理を行う
			if (comboBox.SelectedIndex < 8)
			{
				// float型以上の数値を入力させない
				if (comboBox.Text.Length > 6)
				{
					comboBox.Text = this._bufZoomText;
				}
				else
				{
					this._bufZoomText = comboBox.Text;
				}
			}
		}

		/// <summary>
		/// キープレスイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: ユーザーが文字キーを入力した時に発生します。</br>
		/// <br>Programmer	: 18012 Y.Sasaki</br>
		/// <br>Date		: 2006.1.13</br>
		/// </remarks>
		private void ViewerZoom_KeyPress(object sender, KeyPressEventArgs e)
		{
			// 数字キー、BackSpace以外の入力を受け付けない
			if ((e.KeyChar != (Char)Keys.Back) &&
				((e.KeyChar < '0') || (e.KeyChar > '9'))
				)
			{
				e.Handled = true;
			}
		}
		
#if ADD20060407	
		/// <summary>
		/// キーダウンイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: ユーザーがキーを押下した時に発生します。</br>
		/// <br>Programmer	: 18012 Y.Sasaki</br>
		/// <br>Date		: 2006.04.07</br>
		/// </remarks>
		private void ViewerZoom_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			e.Handled = true;
		}
#endif
		
		/// <summary>
		/// 印刷完了イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: 印刷が完了した時に発生します。</br>
		/// <br>Programmer	: 18012 Y.Sasaki</br>
		/// <br>Date		: 2005.12.02</br>
		/// </remarks>
		private void onEndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			this.Close();
		}		
		
		/// <summary>
		/// 画面終了イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: 画面終了時に発生します。</br>
		/// <br>Programmer	: 18012 Y.Sasaki</br>
		/// <br>Date		: 2005.12.02</br>
		/// </remarks>
		private void SFCMN00293UA_Closed(object sender, System.EventArgs e)
		{
			if (this._positionAdjViewLib != null)
			{
				this._positionAdjViewLib.Dispose();
			}

			if (this._positionAdjPrtLib != null)
			{
				this._positionAdjPrtLib.Dispose();
			}
		}
		#endregion


	}
}
