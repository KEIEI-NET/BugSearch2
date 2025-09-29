using System;
using System.IO;
using System.Threading;
using System.Drawing;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using Broadleaf.Application.Common;
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
	/// <br>Programmer : 22011 柏原　頼人</br>
	/// <br>Date       : </br>
	/// <br>Update Note: </br>
    /// </remarks>
	public class SFANL08203UB : System.Windows.Forms.Form
	{
		# region Private Members (Component)
		private DataDynamics.ActiveReports.Viewer.Viewer viewer1;
		#endregion

		private System.ComponentModel.IContainer components = null;

		//================================================================================
		//  コンストラクター
		//================================================================================
		#region コンストラクター
		/// <summary>
		/// ActiveReport共通プレビュー画面クラスコンストラクタ
		/// </summary>
		public SFANL08203UB()
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
            }
			
			// 共通関数部品インスタンス作成
			this._commonLib = new SFANL08203UC();
		
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SFANL08203UB));
            this.viewer1 = new DataDynamics.ActiveReports.Viewer.Viewer();
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
            // SFANL08203UB
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.ClientSize = new System.Drawing.Size(1016, 734);
            this.Controls.Add(this.viewer1);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.Name = "SFANL08203UB";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "印刷プレビュー";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SFANL08203UB_KeyPress);
            this.TextChanged += new System.EventHandler(this.SFANL08203UB_TextChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SFANL08203UB_KeyDown);
            this.Load += new System.EventHandler(this.SFANL08203UB_Load);
            this.ResumeLayout(false);

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
        // PDF出力クラス
        private DataDynamics.ActiveReports.Export.Pdf.PdfExport pdfExport1 = new DataDynamics.ActiveReports.Export.Pdf.PdfExport();
		
		private SFANL08203UD _commonInfo = null;										// 共通設定情報クラス
		private SFANL08203UC _commonLib  = null;										// 共通部品クラス
		private string _bufText;														// ページ№退避用
		private string _bufZoomText;													// ズーム退避用
		private bool _isShowPrintDialog   = true;										// 印刷ダイアログ表示有無
        private IWin32Window _owner = null;											// トップレベルウィンドウ	
		#endregion

		//================================================================================
		//  内部定数
		//================================================================================
		#region private constant
		// ツールバーボタンＩＤ
		private const int CT_TOOLBUTTON_PRINT = 5000;								// 「印刷」ボタンID
		private const int CT_TOOLBUTTON_CLOSE = 5020;								// 「閉じる」ボタンID
		#endregion
		
		delegate void CreateReportDelegate();
		
		//================================================================================
		//  外部提供プロパティ
		//================================================================================
		#region public property
		/// <summary>共通画面条件プロパティ</summary>
		public SFANL08203UD CommonInfo
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
			System.Windows.Forms.Application.Run(new SFANL08203UB());
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
		public int Run(DataDynamics.ActiveReports.ActiveReport3 rpt)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
			this.DialogResult = DialogResult.Cancel;
			try
			{
				// レポートインスタンス設定
				this._prtRpt   = rpt;
				this._viewRpt  = rpt;

				// プレビュー画面起動
				DialogResult dr = this.ShowDialog(this._owner);
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
		public int ShowPreview(DataDynamics.ActiveReports.ActiveReport3 prtRpt)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
			this.DialogResult = DialogResult.Cancel;

			this._prtRpt = prtRpt;
			this.viewer1.Document = this._prtRpt.Document;
            this.viewer1.Show();

			DialogResult dret = this.ShowDialog(this._owner);
			switch (dret)
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
		public int Run(IWin32Window owner, DataDynamics.ActiveReports.ActiveReport3 rpt)
		{
			this._owner = owner;
			return this.Run(rpt);
		}
		#endregion
		
		// ===============================================================================
		// 内部関数
		// ===============================================================================
		#region private methods	
		/// <summary>
		/// プレビュー表示処理
		/// </summary>
		private void CreateReport()
		{
			try
			{
				string message;
                ActiveReport3 prtRpt;

                // プリンタ情報設定
				if (this._commonLib.SetPrinterInfo(ref this._viewRpt, this._commonInfo, out message) != 0) 
				{
					this.DialogResult      = DialogResult.Abort;
					return;
				}

                try
                {
                    //ﾀﾞﾐｰﾃﾞｰﾀﾌﾟﾚﾋﾞｭｰ以外
                    if (_commonInfo.PrintMode != 4)
                    {
                        if (_commonInfo.PrintPprBgImageData != null)
                        {
                            //背景画像を合成
                            SFANL08235CE.SetValidPaperKind(this._viewRpt);
                            prtRpt = SFANL08235CE.OverlayImage(this._viewRpt, (Bitmap)_commonInfo.PrintPprBgImageData, _commonInfo.PrtPprBgImageRowPos, _commonInfo.PrtPprBgImageColPos);
                            SFANL08235CE.SetValidPaperKind(this._viewRpt);
                            this.viewer1.Document = prtRpt.Document;
                        }
                        else
                        {
                            this._viewRpt.Run();
                            this.viewer1.Document = this._viewRpt.Document;
                        }
                    }
                    else
                    {
                        this.viewer1.Document = this._viewRpt.Document;
                    }
                    this.viewer1.Show();
                }
                catch (Exception ex)
                {
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "SFANL08203UB", "レポートの作成に失敗しました\r\n" +
                                                                                  "詳細："+ex.Message, 0, MessageBoxButtons.OK);
                    this.viewer1.Document.Dispose();
                    this.viewer1.Dispose();
                    GC.Collect();
                    this.Close();
                    return;
                }
			}
            catch (Exception ex)
			{
				throw new ActiveReportPrintException(ex.Message + "\n\r" + ex.StackTrace + ex.Source, -1);
			}
		}
		
		/// <summary>
		/// プレビュー表示デリゲート呼出処理
		/// </summary>
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
		private void InitialScreen()
		{
			// 拡大率の設定
			if (this._commonInfo.ExpansionRate != 0)
			{
				float fx = (float)this._commonInfo.ExpansionRate / 100.0F;
				this.viewer1.ReportViewer.Zoom = fx;
			}
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

            //フォームのサイズ、位置を調整
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.Top = 0;
            this.Left = 0;
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
		private void SFANL08203UB_Load(object sender, System.EventArgs e)
		{
			// 画面初期設定
			this.InitialScreen();
			
			// 印刷完了イベントをイベントハンドラに関連づけます
			this._prtRpt.Document.Printer.EndPrint
				+= new System.Drawing.Printing.PrintEventHandler(onEndPrint);

			// プレビュー用ドキュメント作成スレッド
            Thread prevThread =
                new Thread(new ThreadStart(ShowPreview));

            prevThread.IsBackground = true;
            prevThread.SetApartmentState(ApartmentState.STA);
            prevThread.Start();			
		}

		/// <summary>
		/// ツールバークリックイベント
		/// </summary>
		/// <param name="sender">イベントオブジェクト</param>
		/// <param name="e">イベント引数</param>
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

								// 親画面をアクティブに
								if (this.Owner != null)
								{
									this.Owner.Activate();
								}

								// 印刷ドキュメント再作成
                                try{
								    this._prtRpt.Run();
                                }
                                catch (Exception ex)
                                {
                                    string msg = ex.Message;
                                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, "SFANL08203UB", "印刷に失敗しました。\r\n詳細：" + ex.Message, 0, MessageBoxButtons.OK);
                                    this._prtRpt.Document.Dispose();
                                    this._prtRpt.Dispose();
                                    GC.Collect();
                                    this.Close();
                                    return;
                                }
							}
						}
						 //印刷モード = 両方印刷
                        if (this._commonInfo.PrintMode == 0)
                        {
                            // PDF出力
                            this.pdfExport1.Export(this._prtRpt.Document, this._commonInfo.PdfFullPath);
                        }

						// 印刷実行
						this._prtRpt.Document.Print(this._isShowPrintDialog,false,false);

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
			}
		}

		/// <summary>
		/// アクティブレポートARControl表示状態制御
		/// </summary>
		/// <param name="rpt">該当レポート</param>
		/// <param name="isVisibled">表示・非表示</param>
		/// <param name="ctrlList">変更するコントロールリスト</param>
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
		/// 印刷完了イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		private void onEndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			this.Close();
		}
        
        /// <summary>
        /// テキストチェンジイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        private void SFANL08203UB_TextChanged(object sender, EventArgs e)
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
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SFANL08203UB_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 数字キー、BackSpace以外の入力を受け付けない
            if ((e.KeyChar != (Char)Keys.Back) &&
                ((e.KeyChar < '0') || (e.KeyChar > '9'))
                )
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// キーダウンイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SFANL08203UB_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        #endregion


        


	}
}
