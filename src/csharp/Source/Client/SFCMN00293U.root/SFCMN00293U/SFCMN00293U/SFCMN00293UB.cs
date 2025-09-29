#define CLR2
#define CLR2_CHG20060420
using System;
using System.Collections;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Reflection;
using System.ComponentModel;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Drawing.Printing;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// ActiveReport共通レポート生成中画面クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : ActiveRepotr印刷時の共通レポート生成中画面クラスです。</br>
	/// <br>Programmer : 18012 Y.Sasaki</br>
	/// <br>Date       : 2005.11.17</br>
	/// <br>Update Note: 2006.04.20 Y.Sasaki CLR2</br>
	/// <br>           : １.VS2005(.NET Framework version 2.0) 対応 </br>
	/// <br>           :    ApartmentStateの設定方法を、2.0で追加されたメソッド使用</br>
	/// <br>Update Note: 2006.04.20 Y.Sasaki CLR2_CHG20060420</br>
	/// <br>           : １.スレッド処理部分をBackgroudWorkerコンポーネントを使用するように変更。 </br>
	/// <br>Update Note: 2006.09.14 Y.Sasaki</br>
	/// <br>           : １.品管対応 No.02204357-88-1-000149-01</br>
	/// <br>           :    複数マージ処理のパタンの際、マージ分のレポートに印刷情報設定がされてなかったので修正。</br>
	/// </remarks>
	public class SFCMN00293UB : System.Windows.Forms.Form
	{
		# region Private Members (Component)
		private Infragistics.Win.Misc.UltraLabel Process_Label;
		private Infragistics.Win.Misc.UltraLabel Printname_Label;
		private Infragistics.Win.Misc.UltraLabel Printer_Label;
		private Infragistics.Win.UltraWinProgressBar.UltraProgressBar Main_ProgressBar;
		private Infragistics.Win.Misc.UltraButton Cancel_Button;
		private DataDynamics.ActiveReports.Export.Pdf.PdfExport pdfExport1;
		private System.ComponentModel.BackgroundWorker bgWorkerPrint;
		/// <summary>
		/// 必要なデザイナ変数です。
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		//================================================================================
		//  コンストラクター
		//================================================================================
		#region コンストラクター
		/// <summary>
		/// ActiveReport共通レポート生成中画面クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : </br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.11.17</br>
		/// </remarks>
		public SFCMN00293UB()
		{
			InitializeComponent();
		
			// 共通関数部品インスタンス作成
			this._commonLib = new SFCMN00293UZ();

			// 印字位置調整部品インスタンス作成
			this._positionAdjPrtLib = new SFCMN00294CA();
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
			Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
			this.Process_Label = new Infragistics.Win.Misc.UltraLabel();
			this.Printname_Label = new Infragistics.Win.Misc.UltraLabel();
			this.Printer_Label = new Infragistics.Win.Misc.UltraLabel();
			this.Main_ProgressBar = new Infragistics.Win.UltraWinProgressBar.UltraProgressBar();
			this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
			this.pdfExport1 = new DataDynamics.ActiveReports.Export.Pdf.PdfExport();
			this.bgWorkerPrint = new System.ComponentModel.BackgroundWorker();
			this.SuspendLayout();
			// 
			// Process_Label
			// 
			appearance1.TextHAlign = Infragistics.Win.HAlign.Center;
			appearance1.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.Process_Label.Appearance = appearance1;
			this.Process_Label.Location = new System.Drawing.Point(0, 0);
			this.Process_Label.Name = "Process_Label";
			this.Process_Label.Size = new System.Drawing.Size(434, 14);
			this.Process_Label.TabIndex = 0;
			// 
			// Printname_Label
			// 
			appearance2.TextHAlign = Infragistics.Win.HAlign.Center;
			appearance2.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.Printname_Label.Appearance = appearance2;
			this.Printname_Label.Location = new System.Drawing.Point(0, 14);
			this.Printname_Label.Name = "Printname_Label";
			this.Printname_Label.Size = new System.Drawing.Size(434, 14);
			this.Printname_Label.TabIndex = 1;
			// 
			// Printer_Label
			// 
			appearance3.TextHAlign = Infragistics.Win.HAlign.Center;
			appearance3.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.Printer_Label.Appearance = appearance3;
			this.Printer_Label.Location = new System.Drawing.Point(0, 28);
			this.Printer_Label.Name = "Printer_Label";
			this.Printer_Label.Size = new System.Drawing.Size(434, 14);
			this.Printer_Label.TabIndex = 2;
			// 
			// Main_ProgressBar
			// 
			appearance4.ForeColor = System.Drawing.Color.Black;
			this.Main_ProgressBar.FillAppearance = appearance4;
			this.Main_ProgressBar.Location = new System.Drawing.Point(36, 51);
			this.Main_ProgressBar.Name = "Main_ProgressBar";
			this.Main_ProgressBar.Size = new System.Drawing.Size(360, 18);
			this.Main_ProgressBar.TabIndex = 3;
			this.Main_ProgressBar.Text = "[Formatted]";
			// 
			// Cancel_Button
			// 
			this.Cancel_Button.Location = new System.Drawing.Point(168, 83);
			this.Cancel_Button.Name = "Cancel_Button";
			this.Cancel_Button.Size = new System.Drawing.Size(92, 23);
			this.Cancel_Button.TabIndex = 4;
			this.Cancel_Button.Text = "キャンセル";
			this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
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
			// bgWorkerPrint
			// 
			this.bgWorkerPrint.WorkerSupportsCancellation = true;
			this.bgWorkerPrint.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorkerPrint_DoWork);
			this.bgWorkerPrint.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorkerPrint_RunWorkerCompleted);
			// 
			// SFCMN00293UB
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 12);
			this.ClientSize = new System.Drawing.Size(434, 108);
			this.ControlBox = false;
			this.Controls.Add(this.Cancel_Button);
			this.Controls.Add(this.Main_ProgressBar);
			this.Controls.Add(this.Printer_Label);
			this.Controls.Add(this.Printname_Label);
			this.Controls.Add(this.Process_Label);
			this.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SFCMN00293UB";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "印刷中";
			this.Load += new System.EventHandler(this.SFCMN00293UB_Load);
			this.ResumeLayout(false);

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
			System.Windows.Forms.Application.Run(new SFCMN00293UB());
		}
		#endregion
	
		//================================================================================
		//  内部定数
		//================================================================================
		#region private constant
		private const string CT_REPORTFORM_NAMESPASE = "Broadleaf.Drawing.Printing";
		#endregion

		//================================================================================
		//  内部変数
		//================================================================================
		#region private member    
#if !CLR2_CHG20060420		
		private Thread printThread                                 = null;
#endif
		private SFCMN00293UZ _commonLib                            = null;
		private SFCMN00293UC _commonInfo                           = null;
		private System.Type _type                                  = null;
		private PropertyInfo _isDiscontinuePi                      = null;
		
		private DataDynamics.ActiveReports.ActiveReport3 _rpt       = null;

		private DataDynamics.ActiveReports.ActiveReport3 _cancelRpt = null;				// 中断対象レポートインスタンス
		private ArrayList _rptList                                 = null;				// マージレポートインスタンス格納用		
		private ArrayList _discontinuePiList                       = null;				// マージレポートPropertyInfo格納用
		private int _margeCount                                    = 0;						// マージ用印刷件数保存バッファ
		private bool _showProgressDialog                           = true;				// 画面表示状態
		private bool _isDiscontinue                                = false;				// 中断フラグ
		private SFCMN00294CA _positionAdjPrtLib                    = null;				// 印字位置調整部品(印刷用)
		
		// 中断画面設定非同期デリゲート
		private delegate void initialSettingHandler(string printnm, string printernm, int printMax);
		private delegate void maxSettingHandler(int max);
		private delegate void processSettingHandler(int cnt);
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
		#endregion
		
		//================================================================================
		//  外部提供プロパティ
		//================================================================================
		#region public methods
		/// <summary>
		/// 印刷中ダイアログ表示印刷処理
		/// </summary>
		/// <param name="rpt">対象ActiveReportクラス</param>
		/// <returns>ConstantManagement.MethodResult</returns>
		/// <remarks>
		/// <br>Note       : 印刷中ダイアログを表示し、印刷処理を行います。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.11.18</br>
		/// </remarks>
		public int Run(DataDynamics.ActiveReports.ActiveReport3 rpt)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
			
			// 画面表示
			this._showProgressDialog = true;
			
			// 中断ボタン非表示
			this.Cancel_Button.Visible = false;
			
			// 内部変数初期化
			this._type            = null;
			this._isDiscontinuePi = null;
			
			this._type = rpt.GetType();
			
			// 中断フラグを取得します
			if (this._type != null)
			{
				// 動的に中断フラグプロパティを取得する
				this._isDiscontinuePi = this._type.GetProperty("IsDiscontinue");
				
				// 中断フラグプロパティが宣言されていれば、中断ボタン使用可能
				if (this._isDiscontinuePi != null)
				{
					this.Cancel_Button.Visible = true;
					this._isDiscontinuePi.SetValue(rpt, false, null);
				}
			}
			
			this._rpt = rpt;
			
			DialogResult dr = this.ShowDialog();
			switch(dr)
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
		/// 印刷中ダイアログ表示印刷処理
		/// </summary>
		/// <param name="rpt">対象ActiveReportクラス</param>
		/// <param name="showProgressDialog">ダイアログ画面表示有無</param>
		/// <returns>ConstantManagement.MethodResult</returns>
		/// <remarks>
		/// <br>Note       : 印刷中ダイアログを表示・非表示を切替えて、印刷処理を行います。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.11.25</br>
		/// </remarks>
		public int Run(DataDynamics.ActiveReports.ActiveReport3 rpt, bool showProgressDialog)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
			
			// 画面表示状態
			this._showProgressDialog = showProgressDialog;
			
			// 中断ボタン非表示
			this.Cancel_Button.Visible = false;
			
			// 内部変数初期化
			this._type            = null;
			this._isDiscontinuePi = null;
			
			this._type = rpt.GetType();
			
			// 中断フラグを取得します
			if (this._type != null)
			{
				// 動的に中断フラグプロパティを取得する
				this._isDiscontinuePi = this._type.GetProperty("IsDiscontinue");
				
				// 中断フラグプロパティが宣言されていれば、中断ボタン使用可能
				if (this._isDiscontinuePi != null)
				{
					this.Cancel_Button.Visible = true;
					this._isDiscontinuePi.SetValue(rpt, false, null);
				}
			}
			
			this._rpt = rpt;
			
			// 画面表示有り
			if (this._showProgressDialog)
			{
				DialogResult dr = this.ShowDialog();
				switch(dr)
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
				// 画面表示無し
			else 
			{
				// 印刷処理実行
				this.PrintProc();

				status = this._commonInfo.Status;
			}

			return status;
		}

		/// <summary>
		/// 印刷ドキュメント作成処理
		/// </summary>
		/// <param name="rpt">対象ActiveReportクラス</param>
		/// <param name="showProgressDialog">ダイアログ画面表示有無</param>
		/// <returns>ConstantManagement.MethodResult</returns>
		/// <remarks>
		/// <br>Note       : 印刷中ダイアログを表示・非表示を切替えて、印刷ドキュメント作成処理を行います。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.03.01</br>
		/// </remarks>
		public int MakeDocument(DataDynamics.ActiveReports.ActiveReport3 rpt, bool showProgressDialog)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

			// 画面表示状態
			this._showProgressDialog = showProgressDialog;

			// 中断ボタン非表示
			this.Cancel_Button.Visible = false;

			// 内部変数初期化
			this._type = null;
			this._isDiscontinuePi = null;

			this._type = rpt.GetType();

			// 中断フラグを取得します
			if (this._type != null)
			{
				// 動的に中断フラグプロパティを取得する
				this._isDiscontinuePi = this._type.GetProperty("IsDiscontinue");

				// 中断フラグプロパティが宣言されていれば、中断ボタン使用可能
				if (this._isDiscontinuePi != null)
				{
					this.Cancel_Button.Visible = true;
					this._isDiscontinuePi.SetValue(rpt, false, null);
				}
			}

			this._rpt = rpt;

			// 画面表示有り
			if (this._showProgressDialog)
			{
				DialogResult dr = this.ShowDialog();
				switch (dr)
				{
					case DialogResult.OK:
					case DialogResult.None:
						status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
						break;
					case DialogResult.Cancel:
						status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
						break;
					default:
						break;
				}
			}
			// 画面表示無し
			else
			{
				// 印刷処理実行
				this.PrintProc();

				status = this._commonInfo.Status;
			}

			return status;
		}
		
		/// <summary>
		/// 印刷中ダイアログ表示印刷処理(複数レポートマージ)
		/// </summary>
		/// <param name="rptList">対象レポートインスタンスリスト</param>
		/// <param name="showProgressDialog">ダイアログ画面表示有無</param>
		/// <returns>ConstantManagement.MethodResult</returns>
		/// <remarks>
		/// <br>Note       : 印刷中ダイアログを表示・非表示を切替えて、マージしながら印刷処理を行います。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.11.25</br>
		/// </remarks>
		public int Run(ArrayList rptList, bool showProgressDialog)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
			
			// 画面表示
			this._showProgressDialog = showProgressDialog;
			
			// 中断ボタン非表示
			this.Cancel_Button.Visible = false;
			
			// 内部変数初期化
			this._type            = null;
			this._isDiscontinuePi = null;
			
			// 基準レポート取得
			this._rpt = (DataDynamics.ActiveReports.ActiveReport3)rptList[0];
			
			// 中断フラグ取得
			this._isDiscontinuePi = this.GetCustomProperty(this._rpt, "IsDiscontinue");
			
			// 中断フラグプロパティが宣言されていれば、中断ボタン使用可能
			if (this._isDiscontinuePi != null)
			{
				this.Cancel_Button.Visible = true;
				this._isDiscontinuePi.SetValue(this._rpt, false, null);
			}
			
			// マージレポート取得
			if (rptList.Count - 1 > 0)
			{
				this._rptList = new ArrayList();
				this._discontinuePiList = new ArrayList();
				
				for (int i = 1; i <= rptList.Count - 1; i++)
				{
					if (rptList[i] is DataDynamics.ActiveReports.ActiveReport3)
					{
						DataDynamics.ActiveReports.ActiveReport3 wkRpt = 
							(DataDynamics.ActiveReports.ActiveReport3)rptList[i];
						
						// レポートインスタンス追加
						this._rptList.Add(wkRpt);

						// 動的に中断フラグプロパティを取得する
						PropertyInfo pi = this.GetCustomProperty(wkRpt, "IsDiscontinue");
						this._discontinuePiList.Add(pi);
					}
				}
			} 
			else 
			{
				this._rptList = null;
			}
			// 画面表示有り
			if (this._showProgressDialog)
			{

				DialogResult dr = this.ShowDialog();
				switch(dr)
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
			else 
			{
				// 印刷処理実行
				this.PrintProc();

				status = this._commonInfo.Status;
			}

			return status;
		}
		
		/// <summary>
		/// プログレスバー進捗状況設定処理
		/// </summary>
		/// <param name="sender">イベントソース</param>
		/// <param name="printCount">印刷作成件数</param>
		/// <remarks>
		/// <br>Note       : プログレスバーの進捗状況を設定します。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.11.18</br>
		/// </remarks>
		public void ProgressBarUpEvent(object sender, int printCount)
		{
			// 画面表示有りモードのみ
			if (this._showProgressDialog)
			{
				this.ProcessSetting(printCount);
			}
		}
		#endregion

		//================================================================================
		//  内部処理
		//================================================================================
		#region private method        
		/// <summary>
		/// 印刷メイン処理
		/// </summary>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note       : 印刷のメイン処理を行います。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.11.15</br>
		/// </remarks>
		private void BackGroudPrintProc(BackgroundWorker worker, DoWorkEventArgs e)
		{
			this._commonInfo.Status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
			this._isDiscontinue = false;

			string message;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/26 ADD
            // 2:ＰＤＦ出力ならば
            if ( this._commonInfo.PrintMode == 2 )
            {
                // ドットプリンタを選択する
                _commonLib.SelectDotPrinter( ref _commonInfo );
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/26 ADD

			// 印字位置調整
			this._commonLib.AdjustPrintPosition(ref this._positionAdjPrtLib, ref this._rpt, this._commonInfo, false);

			// 印刷情報設定
			if (this._commonLib.SetPrinterInfo(ref this._rpt, this._commonInfo, out message) != 0)
			{
				this.DialogResult = DialogResult.Abort;
				return;
			}

			// マージ用カウント初期化
			this._margeCount = 0;

			// 印刷開始
			this._cancelRpt = this._rpt;
			this._rpt.Run();

			// 中断確認
			if (this._isDiscontinue) return;

			// マージレポートはあるか？
			if (this._rptList != null)
			{
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/26 ADD
                // 2:ＰＤＦ出力ならば
                if ( this._commonInfo.PrintMode == 2 )
                {
                    // ドットプリンタを選択する
                    _commonLib.SelectDotPrinter( ref _commonInfo );
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/26 ADD

				for (int i = 0; i < this._rptList.Count; i++)
				{
					// キャンセルされた
					if (worker.CancellationPending)
					{
						e.Cancel = true;
					}

					DataDynamics.ActiveReports.ActiveReport3 wkRpt
						= (DataDynamics.ActiveReports.ActiveReport3)this._rptList[i];

					// プログレスバー現在値取得
					this._margeCount += this.Main_ProgressBar.Value;

					this._cancelRpt = wkRpt;

					// 印字位置調整
					this._commonLib.AdjustPrintPosition(ref this._positionAdjPrtLib, ref wkRpt, this._commonInfo, false);

					// >>>>> 2006.09.14 Y.Sasaki ADD START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
					// 印刷情報設定
					if (this._commonLib.SetPrinterInfo(ref wkRpt, this._commonInfo, out message) != 0)
					{
						this.DialogResult = DialogResult.Abort;
						return;
					}
					// <<<<< 2006.09.14 Y.Sasaki ADD END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //
					
					wkRpt.Run();

					this._rpt.Document.Pages.AddRange(wkRpt.Document.Pages);
				}
			}

			if (this._rpt.Document != null && this._rpt.Document.Pages.Count != 0)
			{
				switch (this._commonInfo.PrintMode)
				{
					case 1:		// プリンタ出力
						{
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/22 DEL
                            //this._rpt.Document.Print(false, false, false);
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/22 DEL
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/22 ADD
                            this._commonLib.PrintDocument( false, _rpt, _commonInfo.PrinterName );
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/22 ADD
                            break;
						}
					case 2:   // PDF出力
						{
							this.pdfExport1.Export(this._rpt.Document, this._commonInfo.PdfFullPath);
							break;
						}
					case 3:		// 両方
						{
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/22 DEL
                            //this._rpt.Document.Print(false, false, false);
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/22 DEL
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/22 ADD
                            this._commonLib.PrintDocument( false, _rpt, _commonInfo.PrinterName );
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/22 ADD
                            this.pdfExport1.Export( this._rpt.Document, this._commonInfo.PdfFullPath );
							break;
						}
					default:
						break;
				}

				// 戻りSTATUS設定
				this._commonInfo.Status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			}
		}

		/// <summary>
		/// 印刷メイン処理
		/// </summary>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note       : 印刷のメイン処理を行います。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.11.15</br>
		/// </remarks>
		private void PrintProc()
		{
			this._commonInfo.Status = (int)ConstantManagement.MethodResult.ctFNC_ERROR; 
			
			this.Cancel_Button.Enabled = true;
			this._isDiscontinue        = false;
			
			try
			{
				// 画面設定
				this.ScreenSetting(this._commonInfo.PrintName, this._commonInfo.PrinterName, this._commonInfo.PrintMax);
				string message;

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/26 ADD
                // 2:ＰＤＦ出力ならば
                if ( this._commonInfo.PrintMode == 2 )
                {
                    // ドットプリンタを選択する
                    _commonLib.SelectDotPrinter( ref _commonInfo );
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/26 ADD

				// 印字位置調整
				this._commonLib.AdjustPrintPosition(ref this._positionAdjPrtLib, ref this._rpt, this._commonInfo, false);
				
				// 印刷情報設定
				if (this._commonLib.SetPrinterInfo(ref this._rpt, this._commonInfo, out message) != 0) 
				{
					this.DialogResult      = DialogResult.Abort;
					return;
				}

				// マージ用カウント初期化
				this._margeCount = 0;
				
				// 印刷開始
				this._cancelRpt = this._rpt;
				this._rpt.Run();

				// 中断確認
				if (this._isDiscontinue) return;

				// マージレポートはあるか？
				if (this._rptList != null)
				{
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/26 ADD
                    // 2:ＰＤＦ出力ならば
                    if ( this._commonInfo.PrintMode == 2 )
                    {
                        // ドットプリンタを選択する
                        _commonLib.SelectDotPrinter( ref _commonInfo );
                    }
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/26 ADD

					for (int i = 0; i < this._rptList.Count; i++)
					{
						DataDynamics.ActiveReports.ActiveReport3 wkRpt 
							= (DataDynamics.ActiveReports.ActiveReport3)this._rptList[i];

						this._isDiscontinuePi = (PropertyInfo)this._discontinuePiList[i];
						
						// プログレスバー現在値取得
						this._margeCount += this.Main_ProgressBar.Value;
						
						this._cancelRpt = wkRpt;
						
						// 印字位置調整
						this._commonLib.AdjustPrintPosition(ref this._positionAdjPrtLib, ref wkRpt, this._commonInfo, false);

						// >>>>> 2006.09.14 Y.Sasaki ADD START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
						// 印刷情報設定
						if (this._commonLib.SetPrinterInfo(ref wkRpt, this._commonInfo, out message) != 0)
						{
							this.DialogResult = DialogResult.Abort;
							return;
						}
						// <<<<< 2006.09.14 Y.Sasaki ADD END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //
						
						wkRpt.Run();

						// 中断確認
						if (this._isDiscontinue) return;

						this._rpt.Document.Pages.AddRange(wkRpt.Document.Pages);
					}
				}
				
				// 中断ボタン無効
				this.Cancel_Button.Enabled = false;
				
				if (this._rpt.Document != null && this._rpt.Document.Pages.Count != 0)
				{
					switch (this._commonInfo.PrintMode)
					{
						case 1:		// プリンタ出力
						{
							this._rpt.Document.Print(false,false,false);
							break;
						}
						case 2:   // PDF出力
						{
							this.pdfExport1.Export(this._rpt.Document, this._commonInfo.PdfFullPath);
							break;
						}
						case 3:		// 両方
						{
							this._rpt.Document.Print(false,false,false);
							this.pdfExport1.Export(this._rpt.Document, this._commonInfo.PdfFullPath);
							break;
						}
						default:
							break;
					}
			
					// 戻りSTATUS設定
					this._commonInfo.Status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL; 
					this.DialogResult      = DialogResult.OK;
				} 
					// 印刷がキャンセルされた？
				else 
				{
					this.DialogResult = DialogResult.Cancel;
				}
			}
			
			catch (ActiveReportPrintException ex)
			{
			
				this._commonLib.TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP,
					ex.Message,
					ex.Status,
					MessageBoxButtons.OK,
					MessageBoxDefaultButton.Button1);
  		}
			
			catch (Exception ex)
			{
				this.DialogResult      = DialogResult.Abort;

				string message = "印刷処理処理にて例外が発生しました。"
					+ "\n\r" + ex.Message;
				
				this._commonLib.TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP,
					message,
					-1,
					MessageBoxButtons.OK,
					MessageBoxDefaultButton.Button1);
			}
			finally
			{
				// 印字位置調整部品破棄
				if (this._positionAdjPrtLib != null)
				{
					this._positionAdjPrtLib.Dispose();
				}
				
				// 画面表示有りの時のみ
				if (this._showProgressDialog)
				{
					this.Close();
				}
			}
		}

		/// <summary>
		/// 印刷メイン処理
		/// </summary>
		/// <param name="IsPrint">印刷有無[T:印刷する,F:ドキュメント作成のみ]</param>
		/// <remarks>
		/// <br>Note       : 印刷のメイン処理を行います。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.03.01</br>
		/// </remarks>
		private void PrintProc(bool IsPrint)
		{
			this._commonInfo.Status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

			this.Cancel_Button.Enabled = true;
			this._isDiscontinue = false;

			try
			{
				// 画面設定
				this.ScreenSetting(this._commonInfo.PrintName, this._commonInfo.PrinterName, this._commonInfo.PrintMax);
				string message;

				// 印字位置調整
				this._commonLib.AdjustPrintPosition(ref this._positionAdjPrtLib, ref this._rpt, this._commonInfo, false);

				// 印刷情報設定
				if (this._commonLib.SetPrinterInfo(ref this._rpt, this._commonInfo, out message) != 0)
				{
					this.DialogResult = DialogResult.Abort;
					return;
				}

				// マージ用カウント初期化
				this._margeCount = 0;

				// 印刷開始
				this._cancelRpt = this._rpt;
				this._rpt.Run();

				// 中断確認
				if (this._isDiscontinue) return;

				// マージレポートはあるか？
				if (this._rptList != null)
				{
					for (int i = 0; i < this._rptList.Count; i++)
					{
						DataDynamics.ActiveReports.ActiveReport3 wkRpt
							= (DataDynamics.ActiveReports.ActiveReport3)this._rptList[i];

						this._isDiscontinuePi = (PropertyInfo)this._discontinuePiList[i];

						// プログレスバー現在値取得
						this._margeCount += this.Main_ProgressBar.Value;

						this._cancelRpt = wkRpt;

						// 印字位置調整
						this._commonLib.AdjustPrintPosition(ref this._positionAdjPrtLib, ref wkRpt, this._commonInfo, false);

						// >>>>> 2006.09.14 Y.Sasaki ADD START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
						// 印刷情報設定
						if (this._commonLib.SetPrinterInfo(ref wkRpt, this._commonInfo, out message) != 0)
						{
							this.DialogResult = DialogResult.Abort;
							return;
						}
						// <<<<< 2006.09.14 Y.Sasaki ADD END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //

						wkRpt.Run();

						// 中断確認
						if (this._isDiscontinue) return;

						this._rpt.Document.Pages.AddRange(wkRpt.Document.Pages);
					}
				}

				// 中断ボタン無効
				this.Cancel_Button.Enabled = false;

				if (this._rpt.Document != null && this._rpt.Document.Pages.Count != 0)
				{
					switch (this._commonInfo.PrintMode)
					{
						case 1:		// プリンタ出力
							{
                                if ( IsPrint )
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/22 DEL
                                    //this._rpt.Document.Print(false, false, false);
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/22 DEL
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/22 ADD
                                    this._commonLib.PrintDocument( false, _rpt, _commonInfo.PrinterName );
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/22 ADD
								break;
							}
						case 2:   // PDF出力
							{
								if (IsPrint)
									this.pdfExport1.Export(this._rpt.Document, this._commonInfo.PdfFullPath);
								break;
							}
						case 3:		// 両方
							{
								if (IsPrint)
								{
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/22 DEL
                                    //this._rpt.Document.Print(false, false, false);
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/22 DEL
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/22 ADD
                                    this._commonLib.PrintDocument( false, _rpt, _commonInfo.PrinterName );
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/22 ADD
                                    this.pdfExport1.Export( this._rpt.Document, this._commonInfo.PdfFullPath );
								}
								break;
							}
						default:
							break;
					}

					// 戻りSTATUS設定
					this._commonInfo.Status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
					this.DialogResult = DialogResult.OK;
				}
				// 印刷がキャンセルされた？
				else
				{
					this.DialogResult = DialogResult.Cancel;
				}
			}

			catch (ActiveReportPrintException ex)
			{

				this._commonLib.TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP,
					ex.Message,
					ex.Status,
					MessageBoxButtons.OK,
					MessageBoxDefaultButton.Button1);
			}

			catch (Exception ex)
			{
				this.DialogResult = DialogResult.Abort;

				string message = "印刷処理処理にて例外が発生しました。"
					+ "\n\r" + ex.Message;

				this._commonLib.TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP,
					message,
					-1,
					MessageBoxButtons.OK,
					MessageBoxDefaultButton.Button1);
			}
			finally
			{
				// 印字位置調整部品破棄
				if (this._positionAdjPrtLib != null)
				{
					this._positionAdjPrtLib.Dispose();
				}

				// 画面表示有りの時のみ
				if (this._showProgressDialog)
				{
					this.Close();
				}
			}
		}

		
		/// <summary>
		/// プロパティ動的取得
		/// </summary>
		/// <param name="targetObj"></param>
		/// <param name="targetName"></param>
		/// <remarks>
		/// <br>Note       : </br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.11.25</br>
		/// </remarks>
		private PropertyInfo GetCustomProperty(object targetObj, string targetName)
		{
			PropertyInfo pi = null;
			System.Type type = targetObj.GetType();

			if (type != null)
			{
				// 動的に中断フラグプロパティを取得する
				pi = type.GetProperty(targetName);
			} 
			return pi;
		}
		
		
		/// <summary>
		/// 初期画面設定処理
		/// </summary>
		/// <param name="printnm">印刷帳票名</param>
		/// <param name="printernm">プリンター名</param>
		/// <param name="printMax">印刷件数</param>
		/// <remarks>
		/// <br>Note       : 呼出元スレッドを判定し、画面初期設定を行います。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.11.18</br>
		/// </remarks>
		private void ScreenSetting(string printnm, string printernm, int printMax)
		{
			// 呼出元のスレッドを判定
			if (this.InvokeRequired == false)
			{
				this.InitialSetting(printnm,printernm,printMax);
			} 
			// 別スレッドの場合
			else 
			{
				initialSettingHandler _initsetting = new initialSettingHandler(InitialSetting);
                        
				Object[] parmList1 = {printnm,printernm,printMax};
                        
				this.BeginInvoke(_initsetting, parmList1);
			}
		}
		
		
		/// <summary>
		/// 画面初期設定
		/// </summary>
		/// <param name="printnm">出力名</param>
		/// <param name="printernm">出力プリンター名</param>
		/// <param name="max">印刷件数</param>
		/// <remarks>
		/// <br>Note       : 画面の初期設定を行います。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.11.18</br>
		/// </remarks>
		private void InitialSetting(string printnm, string printernm, int max)
		{
			string message     = "印刷中です。";
			string printerName = printernm; 
			
			switch (this._commonInfo.PrintMode)
			{
				case 1:		// プリンタ
					break;
				case 2:		// ＰＤＦ
					printerName = "PDF";
					message     = "出力中です。";
					break;
				case 3:
					break;
				default:
					break;
			}
			
			this.Printname_Label.Text = String.Format("「{0}」を", printnm);
			this.Printer_Label.Text   = printerName + "で"+ message;

			if (max != 0)
			{
				this.Main_ProgressBar.Visible = true;
				this.Main_ProgressBar.Maximum = max; 
				this.Main_ProgressBar.Minimum = 0; 
			} 
			else 
			{
				this.Main_ProgressBar.Visible = false;
			}
		}

		/// <summary>
		/// 出力件数設定処理
		/// </summary>
		/// <param name="cnt">出力件数</param>
		/// <remarks>
		/// <br>Note       : 画面の出力済み件数を更新します。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.11.18</br>
		/// </remarks>
		private void ProcessSetting (int cnt)
		{
			string message = "印刷中です。";
			switch (this._commonInfo.PrintMode)
			{
				case 1:		// プリンタ
					break;
				case 2:		// ＰＤＦ
					message = "出力中です。";
					break;
				case 3:
					break;
				default:
					break;
			}

			if (this._commonInfo.PrintMax != 0)
			{
				this.Main_ProgressBar.Value = this._margeCount + cnt;
				this.Main_ProgressBar.Refresh();
				this.Process_Label.Text = String.Format("現在、{0}／{1}件 を{2}", this._margeCount + cnt, this._commonInfo.PrintMax, message);
				this.Process_Label.Refresh();
			} 
			else 
			{
				this.Process_Label.Text = String.Format("現在、{0}件　を{1}",this._margeCount + cnt, message);
				this.Process_Label.Refresh();
			}
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
		/// <br>Date        : 2005.11.15</br>
		/// </remarks>
		private void SFCMN00293UB_Load(object sender, System.EventArgs e)
		{
#if CLR2_CHG20060420
			this.Cancel_Button.Enabled = true;
			
			// 画面設定
			this.ScreenSetting(this._commonInfo.PrintName, this._commonInfo.PrinterName, this._commonInfo.PrintMax);
			
			this.bgWorkerPrint.RunWorkerAsync();
#else
			// 印刷用スレッドの作成
			this.printThread = new Thread(new ThreadStart(this.PrintProc));
			
			printThread.IsBackground   = true;
#if CLR2
			printThread.SetApartmentState(ApartmentState.STA);
#else
			printThread.ApartmentState = ApartmentState.STA;
#endif
			
			this.printThread.Start();
#endif
		}

		private void bgWorkerPrint_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
		{
			this.BackGroudPrintProc(this.bgWorkerPrint, e);
		}

		/// <summary>
		/// RunWorkerCompletedイベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/// <remarks>
		/// <br>Note        : ワーカーが完了した時に発生します。</br>
		/// <br>Programmer  : 18012 Y.Sasaki</br>
		/// <br>Date        : 2006.04.20</br>
		/// </remarks>
		private void bgWorkerPrint_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
		{
			if (e.Error != null)
			{
				this.DialogResult = DialogResult.Abort;
				this._commonLib.TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP,
					e.Error.Message,
					-1,
					MessageBoxButtons.OK,
					MessageBoxDefaultButton.Button1);
			} else if (e.Cancelled) {
				this.DialogResult = DialogResult.Cancel;
			} else {
				this.DialogResult = DialogResult.OK;
			}

			// 印字位置調整部品破棄
			if (this._positionAdjPrtLib != null)
			{
				this._positionAdjPrtLib.Dispose();
			}

			// 画面表示有りの時のみ
			if (this._showProgressDialog)
			{
				this.Close();
			}
		}
		
		
		/// <summary>
		/// キャンセルボタンクリックイベント
		/// </summary>
		/// <param name="sender">イベントオブジェクト</param>
		/// <param name="e">イベント引数</param>
		/// <remarks>
		/// <br>Note        : キャンセルボタンがクリックされた際、発生するイベントです。</br>
		/// <br>Programmer  : 18012 Y.Sasaki</br>
		/// <br>Date        : 2005.11.15</br>
		/// </remarks>
		private void Cancel_Button_Click(object sender, System.EventArgs e)
		{
#if CLR2_CHG20060420
			// 中断フラグを立てる
			this._isDiscontinuePi.SetValue(this._cancelRpt, true, null);
			this._isDiscontinue = true;
#else
			// 印刷スレッド中断
			this.printThread.Suspend();
            
			DialogResult dr = 
				this._commonLib.TMessageBox(emErrorLevel.ERR_LEVEL_INFO, "印刷中です。"+ "\n" + "処理を中断してもよろしいですか？",
				0, MessageBoxButtons.YesNo,MessageBoxDefaultButton.Button2);

			switch (dr)
			{
				case DialogResult.Yes:

					// 中断フラグを立てる
					this._isDiscontinuePi.SetValue(this._cancelRpt, true, null);
					this._isDiscontinue = true;
					
					this.printThread.Resume();
					this.printThread.Join();
					
					this.DialogResult = DialogResult.Cancel;
					break;
				case DialogResult.No:
					this.printThread.Resume();
					break;
			}
#endif
		}
		#endregion
	}
}
