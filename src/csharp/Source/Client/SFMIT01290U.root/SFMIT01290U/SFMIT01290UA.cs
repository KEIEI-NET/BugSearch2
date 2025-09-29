using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using System.ComponentModel;
using Broadleaf.Application.Common;
using Broadleaf.Windows.Forms;
using System.IO;
using Broadleaf.Application.Resources;

using DataDynamics.ActiveReports.Toolbar;
using DataDynamics.ActiveReports.Document;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 伝票印刷プレビュークラス
	/// </summary>
	/// <remarks>
	/// <br>Note		: 伝票印刷共通のプレビューUIです。</br>
	/// <br>Programmer	: 22024 寺坂　誉志</br>
	/// <br>Date		: 2006.01.12</br> 
	/// <br></br>
    /// <br>Update Note : 2007.12.11 22018 鈴木 正臣</br>
    /// <br>            :   ①DC.NS対応 (ActiveReports 3.0 対応のみ)</br>
    /// <br></br>
    /// <br>Update Note : 2010/06/23 22018 鈴木 正臣</br>
    /// <br>            :   請求書印刷ページ指定対応</br>
    /// <br>Update Note : K2024/08/15 陳艶丹</br>
    /// <br>管理番号    : 12000031-00</br>
    /// <br>            : PMKOBETSU-4367 伝票が出ない（印刷APIフック追加対応）</br> 
    /// <br>Update Note	: 2024/11/26 田村顕成</br>
    /// <br>管理番号    : 12000031-00</br>
    /// <br>Update Note	: プレビューダイアログ表示タイムアウト対応</br>
    /// </remarks>
	public class SFMIT01290UA : System.Windows.Forms.Form
	{
		#region PrivateMember
		// 印刷用パラメータ
		SFMIT01290UB _prtParam;
		// ページ№退避用
		private string _bufText;
		// ズーム退避用
		private string _bufZoomText;
		#endregion

		#region Component
		private DataDynamics.ActiveReports.Viewer.Viewer viewer1;
		private DataDynamics.ActiveReports.Export.Pdf.PdfExport pdfExport1;
		/// <summary>
		/// 必要なデザイナ変数です。
		/// </summary>
		private System.ComponentModel.Container components = null;
        // --- ADD K2024/09/13 陳艶丹 PMKOBETSU-4367 伝票が出ない（印刷APIフック追加対応） ----->>>>>
        /// <summary>
        /// プレビュー印刷フラグ「0:プレビュー無し、1:プレビュー有り、2:プレビュー画面で「印刷」ボタン押す」
        /// </summary>
        public static int isPrtFlg = 0;
        // --- ADD K2024/09/13 陳艶丹 PMKOBETSU-4367 伝票が出ない（印刷APIフック追加対応） -----<<<<<
		#endregion
        // ADD 2024/11/26 田村顕成 プレビューダイアログ表示タイムアウト対応 ----->>>>>
        private Timer timer1;
        private const string xmlFileName = "SFMIT01290U_PreviewTimeoutSetting.xml";
        private PreviewTimeoutSet previewTimeoutInfo = null;
        private const int timeoutSec = 300000;
        // ADD 2024/11/26 田村顕成 プレビューダイアログ表示タイムアウト対応 -----<<<<<

		#region Constructor
		/// <summary>
		/// コンストラクタ
		/// </summary>
        /// <remarks>
        /// <br>Update Note : K2024/09/13 陳艶丹</br>
        /// <br>管理番号    : 12000031-00</br>
        /// <br>            : PMKOBETSU-4367 伝票が出ない（印刷APIフック追加対応）</br> 
        /// </remarks>
		public SFMIT01290UA()
		{
            isPrtFlg = 0; //ADD K2024/09/13 陳艶丹 PMKOBETSU-4367 伝票が出ない（印刷APIフック追加対応）
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
				// イベントに追加
				placeHolder2.Control.TextChanged	+= new System.EventHandler(this.ViewerZoom_TextChanged);
				placeHolder2.Control.KeyPress		+= new KeyPressEventHandler(this.ViewerZoom_KeyPress);
			}
		}
		#endregion

		#region Dispose
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

		#region Windows フォーム デザイナで生成されたコード 
		/// <summary>
		/// デザイナ サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディタで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SFMIT01290UA));
            this.viewer1 = new DataDynamics.ActiveReports.Viewer.Viewer();
            this.pdfExport1 = new DataDynamics.ActiveReports.Export.Pdf.PdfExport();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // viewer1
            // 
            this.viewer1.BackColor = System.Drawing.SystemColors.Control;
            this.viewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewer1.Document = new DataDynamics.ActiveReports.Document.Document( "ARNet Document" );
            this.viewer1.Location = new System.Drawing.Point( 0, 0 );
            this.viewer1.Name = "viewer1";
            this.viewer1.ReportViewer.CurrentPage = 0;
            this.viewer1.ReportViewer.MultiplePageCols = 3;
            this.viewer1.ReportViewer.MultiplePageRows = 2;
            this.viewer1.ReportViewer.ViewType = DataDynamics.ActiveReports.Viewer.ViewType.Normal;
            this.viewer1.Size = new System.Drawing.Size( 892, 648 );
            this.viewer1.TabIndex = 0;
            this.viewer1.TableOfContents.Text = "Contents";
            this.viewer1.TableOfContents.Width = 200;
            this.viewer1.TabTitleLength = 35;
            this.viewer1.Toolbar.Font = new System.Drawing.Font( "MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)) );
            this.viewer1.ToolClick += new DataDynamics.ActiveReports.Toolbar.ToolClickEventHandler( this.viewer1_ToolClick );
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
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.TimerTick);
            // 
            // SFMIT01290UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size( 5, 12 );
            this.ClientSize = new System.Drawing.Size( 892, 648 );
            this.Controls.Add( this.viewer1 );
            this.Icon = ((System.Drawing.Icon)(resources.GetObject( "$this.Icon" )));
            this.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.Name = "SFMIT01290UA";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "印刷プレビュー";
            this.ResumeLayout( false );

		}
		#endregion

		#region Main
		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		[STAThread]
		static void Main() 
		{
            System.Windows.Forms.Application.Run(new SFMIT01290UA());
		}
		#endregion

		#region PublicMethod
		/// <summary>
		/// 印刷開始処理（プレビュー有り）
		/// </summary>
		/// <param name="prtParam">印刷プレビューパラメータクラス</param>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note		: プレビュー有りで印刷を行います。</br>
		/// <br>			: 印刷ボタン押下時にはWindows標準の印刷ダイアログが表示されます。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2006.01.12</br>
		/// </remarks>
		public int PrintPreviewDefaultSetting(SFMIT01290UB prtParam)
		{
			this._prtParam	= prtParam;

			//拡大率の設定
			if (this._prtParam.ExpansionRate != 0.0)
			{
				this.viewer1.ReportViewer.Zoom = 1.0F;
			}

			// 画面をWindowsの作業領域分にする
			this.Width	= Screen.GetWorkingArea(this).Width;
			this.Height	= Screen.GetWorkingArea(this).Height;

			this.viewer1.Document = prtParam.PreviewDocument;
            // --- ADD m.suzuki 2010/06/23 ---------->>>>>
            // 印刷終了時の処理を登録
            this.viewer1.Document.Printer.EndPrint += new System.Drawing.Printing.PrintEventHandler( Printer_EndPrint );
            // --- ADD m.suzuki 2010/06/23 ----------<<<<<

			this.ShowDialog();

			return 0;
		}
        // --- ADD m.suzuki 2010/06/23 ---------->>>>>
        /// <summary>
        /// ドキュメント印刷終了時イベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Printer_EndPrint( object sender, System.Drawing.Printing.PrintEventArgs e )
        {
            // このフォームを終了する
            // （※ダイアログでキャンセルした場合は、この処理に入らない）
            this.Close();
        }
        // --- ADD m.suzuki 2010/06/23 ----------<<<<<

		/// <summary>
		/// 印刷開始処理（プレビュー有り）
		/// </summary>
		/// <param name="prtParam">印刷プレビューパラメータクラス</param>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note		: プレビュー有りで印刷を行います。</br>
		/// <br>			: 印刷ボタン押下時にダイアログは表示されません。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2006.01.12</br>
        /// <br>Update Note : K2024/09/13 陳艶丹</br>
        /// <br>管理番号    : 12000031-00</br>
        /// <br>            : PMKOBETSU-4367 伝票が出ない（印刷APIフック追加対応）</br> 
		/// </remarks>
		public int PrintPreview(SFMIT01290UB prtParam)
		{
            isPrtFlg = 1; //ADD K2024/09/13 陳艶丹 PMKOBETSU-4367 伝票が出ない（印刷APIフック追加対応）
			this._prtParam	= prtParam;

			//拡大率の設定
			if (this._prtParam.ExpansionRate != 0.0)
			{
				this.viewer1.ReportViewer.Zoom = 1.0F;
			}

			// 画面をWindowsの作業領域分にする
			this.Width = Screen.GetWorkingArea(this).Width;
			this.Height = Screen.GetWorkingArea(this).Height;

			// アクティブレポートViewerの設定
			// デフォルトの印刷ボタンを削除
			this.viewer1.Toolbar.Tools.RemoveAt(2);
			// 印刷ボタンの挿入
			// これとToolClickイベントの組み合わせにより、PrintDialogを出さずに印刷を可能にする
			DataDynamics.ActiveReports.Toolbar.Button printBtn = new DataDynamics.ActiveReports.Toolbar.Button();
			printBtn.Caption = "印刷";
			printBtn.ToolTip = "印刷を実行します";
			printBtn.ImageIndex = 1;
			printBtn.ButtonStyle = ButtonStyle.TextAndIcon;
			printBtn.Id = 5001;
			this.viewer1.Toolbar.Tools.Insert(2,printBtn);

			this.viewer1.Document = prtParam.PreviewDocument;
			
			this.ShowDialog();

			return 0;
		}

        // ADD 2024/11/26 田村顕成 プレビューダイアログ表示タイムアウト対応 ----->>>>>
        /// <summary>
        /// 印刷開始処理（プレビュー有り）
        /// </summary>
        /// <param name="prtParam">印刷プレビューパラメータクラス</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note		: プレビュー有りで印刷を行います。</br>
        /// <br>			: プレビュー画面を一定時間で終了し、印刷を開始する対応</br>
        /// <br>Programmer	: 32427 田村顕成</br>
        /// <br>Date		: 2024/11/26</br>
        /// </remarks>
        public int PrintPreview2(SFMIT01290UB prtParam)
        {
            this._prtParam = prtParam;
            GetXmlInfo();//プレビュー期限設定ファイルの読み込み（XMLがない場合はデフォルト5分）

            //拡大率の設定
            if (this._prtParam.ExpansionRate != 0.0)
            {
                this.viewer1.ReportViewer.Zoom = 1.0F;
            }

            // 画面をWindowsの作業領域分にする
            this.Width = Screen.GetWorkingArea(this).Width;
            this.Height = Screen.GetWorkingArea(this).Height;

            // アクティブレポートViewerの設定
            // デフォルトの印刷ボタンを削除
            this.viewer1.Toolbar.Tools.RemoveAt(2);
            // 印刷ボタンの挿入
            // これとToolClickイベントの組み合わせにより、PrintDialogを出さずに印刷を可能にする
            DataDynamics.ActiveReports.Toolbar.Button printBtn = new DataDynamics.ActiveReports.Toolbar.Button();
            printBtn.Caption = "印刷";
            printBtn.ToolTip = "印刷を実行します";
            printBtn.ImageIndex = 1;
            printBtn.ButtonStyle = ButtonStyle.TextAndIcon;
            printBtn.Id = 5001;
            this.viewer1.Toolbar.Tools.Insert(2, printBtn);

            timer1.Interval = previewTimeoutInfo.PreviewTimeoutSec;
            timer1.Enabled = true;
            try
            {
                this.viewer1.Document = prtParam.PreviewDocument;
                this.ShowDialog();
            }
            catch
            {
                //発生した例外をそのまま再スローする
                throw;
            }
            finally
            {
                timer1.Enabled = false;
            }

            return 0;
        }

        private void GetXmlInfo()
        {
            try
            {
                previewTimeoutInfo = new PreviewTimeoutSet();

                if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, xmlFileName)))
                {
                    // XMLからタイムアウト時間を取得する
                    previewTimeoutInfo = UserSettingController.DeserializeUserSetting<PreviewTimeoutSet>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, xmlFileName));
                }
                else
                {
                    // タイムアウト-デフォルト：300秒
                    previewTimeoutInfo.PreviewTimeoutSec = timeoutSec;
                }
            }
            catch
            {
                if (previewTimeoutInfo == null) previewTimeoutInfo = new PreviewTimeoutSet();
                // タイムアウト-デフォルト：300秒
                previewTimeoutInfo.PreviewTimeoutSec = timeoutSec;
            }
        }

        // ADD 2024/11/26 田村顕成 プレビューダイアログ表示タイムアウト対応 -----<<<<<

		/// <summary>
		/// 印刷開始処理（プレビュー有り）
		/// </summary>
		/// <param name="prtParam">印刷プレビューパラメータクラス</param>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note		: プレビューのみを行います。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2006.01.12</br>
		/// </remarks>
		public int PrintPreviewWithoutPrtBtn(SFMIT01290UB prtParam)
		{
			this._prtParam	= prtParam;

			//拡大率の設定
			if (this._prtParam.ExpansionRate != 0.0)
			{
				this.viewer1.ReportViewer.Zoom = (float)this._prtParam.ExpansionRate / 100F;
			}

			// 検索ボタンより左のボタンは非表示
			for (int ix = 0 ; ix != 8 ; ix++)
			{
				this.viewer1.Toolbar.Tools[ix].Visible = false;
			}
			this.viewer1.Toolbar.Wrappable = false;

			this.viewer1.Document = prtParam.PreviewDocument;
			
			return 0;
		}

		/// <summary>
		/// 印刷開始処理（PDF）
		/// </summary>
		/// <param name="prtParam">印刷プレビューパラメータクラス</param>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note		: PDFを出力します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2006.01.12</br>
		/// </remarks>
		public int OutputPDF(SFMIT01290UB prtParam)
		{
			this._prtParam	= prtParam;

			pdfExport1.Export(prtParam.PrintDocument, prtParam.PdfPath);
			
			return 0;
		}
		#endregion

		#region Event
		/// <summary>
		/// ツールバークリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: ユーザーがビューワのツールバーをクリックした時に発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2006.01.12</br>
        /// <br>Update Note : K2024/09/13 陳艶丹</br>
        /// <br>管理番号    : 12000031-00</br>
        /// <br>            : PMKOBETSU-4367 伝票が出ない（印刷APIフック追加対応）</br> 
		/// </remarks>
		private void viewer1_ToolClick(object sender, DataDynamics.ActiveReports.Toolbar.ToolClickEventArgs e)
		{
			if (e.Tool.Id == 5001)
			{
                timer1.Enabled = false;// ADD 2024/11/26 田村顕成 プレビューダイアログ表示タイムアウト対応
                isPrtFlg = 2;//ADD K2024/09/13 陳艶丹 PMKOBETSU-4367 伝票が出ない（印刷APIフック追加対応）
				this._prtParam.PrintDocument.Print(false, true, false);

				this.Close();
			}
		}

		/// <summary>
		/// テキストチェンジイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: ユーザーがテキストを変更した時に発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2006.01.12</br>
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
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2006.01.12</br>
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
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2006.01.12</br>
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

        // ADD 2024/11/26 田村顕成 プレビューダイアログ表示タイムアウト対応 ----->>>>>
        /// <summary>
        /// プレビュー時間監視タイマ
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note		: プレビュータイムアウト時にプレビュー画面を閉じて印刷を開始します</br>
        /// <br>Programmer	: 32427 田村顕成</br>
        /// <br>Date		: 2024/11/26</br>
        /// </remarks>

        private void TimerTick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            this._prtParam.PrintDocument.Print(false, true, false);
            this.Close();
        }
        // ADD 2024/11/26 田村顕成 プレビューダイアログ表示タイムアウト対応 -----<<<<<
		#endregion
    }

    // ADD 2024/11/26 田村顕成 プレビューダイアログ表示タイムアウト対応 ----->>>>>
    /// <summary>
    /// プレビュー時間監視タイマクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: プレビュータイムアウト時間</br>
    /// <br>Programmer	: 32427 田村顕成</br>
    /// <br>Date		: 2024/11/26</br>
    /// </remarks>

	[Serializable]
    public class PreviewTimeoutSet
    {
        // プレビュータイムアウト
        private int _previewTimeoutSec;

        /// <summary>
        /// リトライ設定クラス
        /// </summary>
        public PreviewTimeoutSet()
        {

        }

        /// <summary>タイムアウト時間</summary>
        public Int32 PreviewTimeoutSec
        {
            get { return this._previewTimeoutSec; }
            set { this._previewTimeoutSec = value; }
        }
    }
    // ADD 2024/11/26 田村顕成 プレビューダイアログ表示タイムアウト対応 -----<<<<<
}
