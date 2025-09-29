//**********************************************************************//
// System           :   ＳＦ．ＮＥＴ                                    //
// Sub System       :                                                   //
// Program name     :   印刷ダイアログ			                        //
//                  :												    //
// Name Space       :   Broadleaf.Windows.Forms							//
// Programer        :   柏原　頼人　　　　                              //
// Date             :   2007.03.19                                      //
//----------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co,. Ltd                 //
//**********************************************************************//
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Printing;
using System.Reflection;
using System.Collections.Generic;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;
using DataDynamics.ActiveReports;
using Broadleaf.Drawing.Printing;

namespace Broadleaf.Windows.Forms
{
	#region enum
	/// <summary>
	/// ダイアログ結果列挙
	/// </summary>
	public enum DialogResultCode
	{
		/// <summary>エラー</summary>
		Error,
		/// <summary>戻る</summary>
		Return,
		/// <summary>自由帳票の一覧表</summary>
		FreeList,
		/// <summary>自由帳票のはがき</summary>
		FreePostCard,
	}
	#endregion
		
	/// <summary>
	/// SFANL08203U(帳票選択画面）
	/// programer : 柏原頼人
    /// <br>Update Note : 2007.09.10 30015 橋本　裕毅</br>
    /// <br>            :	自由帳票DM対応</br>
    /// <br>Update Note : 2008.03.18 30015 橋本　裕毅</br>
    /// <br>            :	自由帳票第一次改良案件　印刷ダイアログ起動速度Up対応</br>
	/// </summary>
	public class SFANL08203U : System.Windows.Forms.Form
	{
		
		#region コンポーネント定義

        private Infragistics.Win.Misc.UltraButton CanButton;
		private System.Windows.Forms.GroupBox groupBox1;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
		private System.Windows.Forms.CheckBox PreviewcheckBox;
		private System.Windows.Forms.GroupBox groupBox3;
		private Infragistics.Win.Misc.UltraLabel ultraLabel11;
		private System.ComponentModel.IContainer components;
		private Infragistics.Win.Misc.UltraLabel comentlbl;
		private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
		private Broadleaf.Library.Windows.Forms.TComboEditor printerCombo1;
		private Broadleaf.Library.Windows.Forms.TComboEditor PrintType_tComboEditor;
		private Infragistics.Win.Misc.UltraLabel DMNo_ultraLabel;
        private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
        private Infragistics.Win.Misc.UltraButton OKButton;

		#endregion
		
		#region コンストラクタ
		/// <summary>
		/// 印刷ダイアログの初期化及びインスタンス生成を行います。
		/// </summary>
		public SFANL08203U()
		{
			//
			// Windows フォーム デザイナ サポートに必要です。
			//
			InitializeComponent();
			_prtManageAcs = new PrtManageAcs();
			_prtPaperStAcs = new PrtPaperStAcs();

		}
		#endregion

		// 2008.03.18 Hiroki.Hashimoto Add Sta >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
		#region Const
		public const string ctMsg_FreeDMList = "自由帳票DM一覧表";
		public const string ctMsg_FreeDMPostCard = "自由帳票DMはがき";
		public const string ctRoot_FrePrtPSet = "\\FREEPOS\\PRTPOS\\FrePrtPSet_";
		#endregion
		// 2008.03.18 Hiroki.Hashimoto Add End <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

		#region メンバ変数
		private Hashtable PrinterInfoList = new Hashtable();
		private Hashtable _SelectPrinterInfo = new Hashtable();
		private int _EnablePreview = 1;		                    // 0:プレビューしない　1:プレビューする
		private SFANL08205C _PrintInfo;
        private int _DialogMode = 0;
        private List<LastPrtPrinter> _lastPrinters;                        // 最終印刷プリンタ
        private LastPrtPrinterAcs _lastPrintersAcs = new LastPrtPrinterAcs(); // 

///// 2007.09.10 Hiroki.Hashimoto Add Sta
		private DialogResultCode _dialogResultCode;           // ダイアログリザルトコード
		private int _SelectFlag; // 選択フラグ（10:帳票,20:DM）
		private List<FrePrtPSet> _frePrtPSetList; // 印字位置設定リスト
		//private List<FrePrtPSet> _frePrtPSetListPrint; // 印字位置設定リスト(一覧表) // 2008.03.18 Hiroki.Hashimoto Del
		//private List<FrePrtPSet> _frePrtPSetPostCard; // 印字位置設定リスト(はがき) // 2008.03.18 Hiroki.Hashimoto Del
		private FrePrtPSet _frePrtPSet = null;
///// 2007.09.10 Hiroki.Hashimoto Add End

        private PrtManageAcs _prtManageAcs;
        private PrtPaperStAcs _prtPaperStAcs;
        private PrtPaperSt _prtPaperSt;            //帳票用紙設定
        private ArrayList prial;                   //プリンタ情報
        private ArrayList alPrintMngNo = null;     //プリンタ情報のコレクション
        private string _printerNm = "";
        private object[] _prtItemSetLs = new object[1];  //印字項目設置のリスト
        #endregion
		
		#region private readonly
		private readonly Size _defaultModeSize = new Size(552,320);			// 標準モード時
		private readonly Size _pdfModeSize     = new Size(552,200);			// ＰＤＦ出力モード
		#endregion

		#region private constant
		private const string CT_DEFAULT_TITLE      = "印刷設定";
		private const string CT_PDFMODE_TITLE      = "出力設定";
		private const int CT_BUTTONINTERVAL_BOTTOM = 72;
		#endregion
		
		#region プロパティ
        /// <summary>
		/// ダイアログ表示モード0:プリンタ、帳票選択可　1:プリンタ設定のみ（一括印刷用）
		/// </summary>
		public int DialogMode
		{
			get{return this._DialogMode;}
			set{this._DialogMode = value;}
		}
		
        /// <summary>
		/// 印刷条件プロパティ
		/// </summary>
		public SFANL08205C PrintInfo
		{
			get{return this._PrintInfo;}
			set
            {
                this._PrintInfo = value;
                if((_PrintInfo!= null) && (_printerNm != ""))
                  this._PrintInfo.prinm = _printerNm;
            }
		}

		/// <summary>
		/// プリンタ情報
		/// </summary>
		public Hashtable SelectPrinterInfo
		{
			get{return _SelectPrinterInfo;}
			set{_SelectPrinterInfo = value;}
		}
		
        /// <summary>
		/// プレビューの有無(0:プレビューする　1:プレビューしない)
		/// </summary>
		public int EnablePreview
		{
			get{return _EnablePreview;}
			set{_EnablePreview = value;}
		}

		/// <summary>
		/// 選択フラグ(10:帳票,20:DM)
		/// </summary>
		public int SelectFlag
		{
			get { return _SelectFlag; }
			set { _SelectFlag = value; }
		}

		/// <summary>
		/// 印字位置設定リスト
		/// </summary>
		public List<FrePrtPSet> frePrtPSetList
		{
			get { return _frePrtPSetList; }
			set { _frePrtPSetList = value; }
		}

		#endregion
		
		#region 後処理
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
			Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SFANL08203U));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.printerCombo1 = new Broadleaf.Library.Windows.Forms.TComboEditor();
			this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
			this.CanButton = new Infragistics.Win.Misc.UltraButton();
			this.PreviewcheckBox = new System.Windows.Forms.CheckBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.comentlbl = new Infragistics.Win.Misc.UltraLabel();
			this.PrintType_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
			this.ultraLabel11 = new Infragistics.Win.Misc.UltraLabel();
			this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
			this.OKButton = new Infragistics.Win.Misc.UltraButton();
			this.DMNo_ultraLabel = new Infragistics.Win.Misc.UltraLabel();
			this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.printerCombo1)).BeginInit();
			this.groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.PrintType_tComboEditor)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.printerCombo1);
			this.groupBox1.Controls.Add(this.ultraLabel1);
			this.groupBox1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.groupBox1.Location = new System.Drawing.Point(24, 112);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(504, 64);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "プリンタ";
			// 
			// printerCombo1
			// 
			appearance1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.printerCombo1.ActiveAppearance = appearance1;
			this.printerCombo1.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
			this.printerCombo1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			appearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.printerCombo1.ItemAppearance = appearance2;
			this.printerCombo1.Location = new System.Drawing.Point(104, 22);
			this.printerCombo1.Name = "printerCombo1";
			this.printerCombo1.Size = new System.Drawing.Size(352, 24);
			this.printerCombo1.TabIndex = 0;
			this.printerCombo1.ValueChanged += new System.EventHandler(this.printerCombo_SelectedIndexChanged);
			// 
			// ultraLabel1
			// 
			this.ultraLabel1.Location = new System.Drawing.Point(16, 24);
			this.ultraLabel1.Name = "ultraLabel1";
			this.ultraLabel1.Size = new System.Drawing.Size(88, 23);
			this.ultraLabel1.TabIndex = 3;
			this.ultraLabel1.Text = "プリンタ名";
			// 
			// CanButton
			// 
			this.CanButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CanButton.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			appearance3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.CanButton.HotTrackAppearance = appearance3;
			this.CanButton.Location = new System.Drawing.Point(368, 232);
			this.CanButton.Name = "CanButton";
			this.CanButton.Size = new System.Drawing.Size(140, 27);
			this.CanButton.TabIndex = 4;
			this.CanButton.Text = "キャンセル(&C)";
			this.CanButton.Click += new System.EventHandler(this.CanButton_Click);
			// 
			// PreviewcheckBox
			// 
			this.PreviewcheckBox.Checked = true;
			this.PreviewcheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.PreviewcheckBox.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.PreviewcheckBox.Location = new System.Drawing.Point(344, 192);
			this.PreviewcheckBox.Name = "PreviewcheckBox";
			this.PreviewcheckBox.Size = new System.Drawing.Size(168, 24);
			this.PreviewcheckBox.TabIndex = 2;
			this.PreviewcheckBox.Text = "プレビュー印刷(&V)";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.comentlbl);
			this.groupBox3.Controls.Add(this.PrintType_tComboEditor);
			this.groupBox3.Controls.Add(this.ultraLabel11);
			this.groupBox3.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.groupBox3.Location = new System.Drawing.Point(24, 8);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(504, 88);
			this.groupBox3.TabIndex = 0;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "帳票";
			// 
			// comentlbl
			// 
			this.comentlbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
			this.comentlbl.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.comentlbl.Location = new System.Drawing.Point(106, 52);
			this.comentlbl.Name = "comentlbl";
			this.comentlbl.Size = new System.Drawing.Size(392, 24);
			this.comentlbl.TabIndex = 0;
			// 
			// PrintType_tComboEditor
			// 
			appearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.PrintType_tComboEditor.ActiveAppearance = appearance4;
			appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.PrintType_tComboEditor.ItemAppearance = appearance5;
			this.PrintType_tComboEditor.Location = new System.Drawing.Point(104, 22);
			this.PrintType_tComboEditor.Name = "PrintType_tComboEditor";
			this.PrintType_tComboEditor.Size = new System.Drawing.Size(352, 24);
			this.PrintType_tComboEditor.TabIndex = 0;
			this.PrintType_tComboEditor.ValueChanged += new System.EventHandler(this.PrintType_tComboEditor_ValueChanged);
			// 
			// ultraLabel11
			// 
			this.ultraLabel11.Location = new System.Drawing.Point(16, 24);
			this.ultraLabel11.Name = "ultraLabel11";
			this.ultraLabel11.Size = new System.Drawing.Size(88, 23);
			this.ultraLabel11.TabIndex = 3;
			this.ultraLabel11.Text = "帳票名称";
			// 
			// tArrowKeyControl1
			// 
			this.tArrowKeyControl1.OwnerForm = this;
			// 
			// OKButton
			// 
			this.OKButton.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.OKButton.HotTrackAppearance = appearance7;
			this.OKButton.Location = new System.Drawing.Point(224, 232);
			this.OKButton.Name = "OKButton";
			this.OKButton.Size = new System.Drawing.Size(140, 27);
			this.OKButton.TabIndex = 3;
			this.OKButton.Text = "印刷(&P)";
			this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
			// 
			// DMNo_ultraLabel
			// 
			appearance6.ForeColor = System.Drawing.Color.Red;
			this.DMNo_ultraLabel.Appearance = appearance6;
			this.DMNo_ultraLabel.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.DMNo_ultraLabel.Location = new System.Drawing.Point(24, 185);
			this.DMNo_ultraLabel.Name = "DMNo_ultraLabel";
			this.DMNo_ultraLabel.Size = new System.Drawing.Size(307, 36);
			this.DMNo_ultraLabel.TabIndex = 9;
			this.DMNo_ultraLabel.Text = "DMパターンを設定していない場合は、\r\n正常に印字されない場合があります。";
			// 
			// tRetKeyControl1
			// 
			this.tRetKeyControl1.OwnerForm = this;
			this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
			// 
			// SFANL08203U
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 15);
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
			this.ClientSize = new System.Drawing.Size(544, 268);
			this.Controls.Add(this.DMNo_ultraLabel);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.CanButton);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.OKButton);
			this.Controls.Add(this.PreviewcheckBox);
			this.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SFANL08203U";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "印刷設定";
			this.Load += new System.EventHandler(this.SFANL08203U_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.printerCombo1)).EndInit();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.PrintType_tComboEditor)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion
		
		#region エントリポイント
		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		[STAThread]
		static void Main() 
		{			
			System.Windows.Forms.Application.Run(new SFANL08203U());
		}
		#endregion

        #region ダイアログロードイベント
        /// <summary>
        /// ダイアログロードイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SFANL08203U_Load(object sender, System.EventArgs e)
		{
            //ボタンのアイコンを設定
			ImageList imglist = IconResourceManagement.ImageList16;
			OKButton.ImageList			= imglist;
			OKButton.Appearance.Image	= Size16_Index.PRINT;
			CanButton.ImageList			= imglist;
			CanButton.Appearance.Image	= Size16_Index.BEFORE;
            //コンポーネント初期化
            printerCombo1.Items.Clear();
			comentlbl.Text = "";

			// 2008.03.18 Hiroki.Hashimoto Del Sta >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

			// どの帳票に対してのダイアログか判断して出す。
			// this.GetPaperInfo(this.SelectFlag); // 2007.09.10 Hiroki.Hashimoto Add 

			// 2008.03.18 Hiroki.Hashimoto Del End <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
			// 2008.03.18 Hiroki.Hashimoto Add Sta >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
			if (this.SelectFlag == 10)
			{
				this.GetPaperInfo();
			// 2008.03.18 Hiroki.Hashimoto Add End >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
				// 最終印刷プリンタ取得
				_lastPrintersAcs.Search(out _lastPrinters);

				//GetPaperInfo(); // 2007.09.10 Hiroki.Hashimoto Del
				GetPrinterInfo();
				// 画面表示設定
				this.ScreenViewSetting();
			// 2008.03.18 Hiroki.Hashimoto Add Sta >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
			}
			else
			{
				// 帳票情報を取得
				int st = GetPaperInfoForDM();
				if (st == 0)
				{
					// 最終印刷プリンタ取得
					_lastPrintersAcs.Search(out _lastPrinters);

					//GetPaperInfo(); // 2007.09.10 Hiroki.Hashimoto Del
					GetPrinterInfo();
					// 画面表示設定
					this.ScreenViewSetting();
				}
				else
				{
					_dialogResultCode = DialogResultCode.Return;
					this.Close();
				}
			}
			// 2008.03.18 Hiroki.Hashimoto Add End >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        }
        #endregion

        #region 画面表示設定
        /// <summary>
		/// 画面表示設定
		/// </summary>
		/// <remarks>
		/// <br>Note       : 出力モードより画面表示設定を行います。</br>
		/// <br>Programmer : 22011 柏原　頼人</br>
		/// <br>Date       : 2006.03.29</br>
		/// </remarks>
		private void ScreenViewSetting()
		{
            bool isVisibled = true;

            if (DialogMode == 1)
            {
                //一括印刷
                groupBox1.Location = new Point(24, 8);
                isVisibled = false;
                // 画面サイズ
                this.Height = groupBox1.Top + groupBox1.Height + OKButton.Height + (PreviewcheckBox.Height) + CT_BUTTONINTERVAL_BOTTOM;
            }
            else
            {
                //通常印刷
                groupBox1.Location = new Point(24, 112);
                isVisibled = true;
                // 画面サイズ
                this.Height = groupBox1.Top + groupBox1.Height + OKButton.Height + (PreviewcheckBox.Height * 2) + CT_BUTTONINTERVAL_BOTTOM;
            }

			// 画面表示・非表示制御
			this.PreviewcheckBox.Visible = isVisibled;					// プレビュー有無
			this.groupBox3.Visible       = isVisibled;					// 帳票名称
			
			// コントロール位置制御
			this.OKButton.Top            = this.Height - CT_BUTTONINTERVAL_BOTTOM;
			this.CanButton.Top           = this.Height - CT_BUTTONINTERVAL_BOTTOM;
        }
        #endregion

        #region 一括印刷用抽出印刷
        /// <summary>
		/// 一括印刷用抽出印刷関数
		/// </summary>
		/// <returns></returns>
		public int BatchPrint()
		{
			int status = 0;
			this._PrintInfo.printmode = 3;
            this._PrintInfo.prevkbn = 0;

            status = ExtraProc();
            // 抽出処理
            if (status == 0)
            {
                // 印刷処理
                status = PrtProc();
            }
            return status;
        }
        #endregion

        #region ダミーデータプレビュー
        /// <summary>
        /// ダミーデータプレビュー
        /// </summary>
        /// <param name="prtItemSetLs"></param>
        /// <param name="frePrtPset"></param>
        /// <param name="createRowCnt"></param>
        /// <param name="bgImage"></param>
        /// <returns></returns>
        public int DummyDataPreview(List<PrtItemSetWork> prtItemSetLs, FrePrtPSet frePrtPset, Int32 createRowCnt, Bitmap bgImage)
        {
            SFANL08235CB dummyRptGenerater = new SFANL08235CB();
            ActiveReport3 dummyRpt;
            ActiveReport3 prtRpt;
            int status = 0;

            // ダミーデータ作成
            status = dummyRptGenerater.CreateDummyDataReport(prtItemSetLs, frePrtPset, createRowCnt, bgImage, out dummyRpt);
            if (status == 0)
            {
                //用紙種類設定
                SFANL08235CE.SetValidPaperKind(dummyRpt);
                // 背景画像挿入
                prtRpt = SFANL08235CE.OverlayImage(dummyRpt, bgImage, frePrtPset.PrtPprBgImageRowPos, frePrtPset.PrtPprBgImageColPos);
                //用紙種類設定
                SFANL08235CE.SetValidPaperKind(prtRpt);
                
                // -- 印刷処理 ------------------------------- 
                // 印刷共通情報プロパティ設定
                Broadleaf.Windows.Forms.SFANL08203UD commonInfo = new SFANL08203UD();
                commonInfo.PrintMax = 0;                              // 印刷件数
                commonInfo.PrintMode = 4;                               // ﾀﾞﾐｰﾃﾞｰﾀﾌﾟﾚﾋﾞｭ

                Broadleaf.Windows.Forms.SFANL08203UB viewForm = new Broadleaf.Windows.Forms.SFANL08203UB();
                // 共通条件設定
                viewForm.CommonInfo = commonInfo;
                // プレビュー実行
                status = viewForm.Run(prtRpt);
            }
            // 戻り値設定
            this._PrintInfo.status = status;

            return status;
        }
        #endregion

        #region プリンタ選択ダイアログ表示
        /// <summary>
        /// プリンタ選択ダイアログ表示
        /// </summary>
        /// <param name="owner">オーナーウィンドウ</param>
        public DialogResult PinrterSelectDlgShow(IWin32Window owner,string groupNm)
        {
            this.DialogMode = 1;            //プリンタ選択のみ
			//this.PrintInfo.printmode = 1; // 実印刷
			this.SelectFlag = 10; // 帳票
			this.DMNo_ultraLabel.Visible = false;
			// UI表示切替処理
            this.Text = "印刷設定 - " + groupNm + "一括印刷";
			this.ChangeEnable(SelectFlag); // 2007.09.10 Hiroki.Hashimoto ADD 
            this.ShowDialog(owner);
            return this.DialogResult;
        }
        #endregion

        #region 印刷用ダイアログ表示
        /// <summary>
        /// プリンタ選択ダイアログ表示
        /// </summary>
        /// <param name="owner">オーナーウィンドウ</param>
        public DialogResult PinrtDlgShow(IWin32Window owner)
        {
            this.DialogMode = 0;
			this.PrintInfo.printmode = 1; // 実印刷
            this.SelectFlag = 10; // 帳票
			this.DMNo_ultraLabel.Visible = false;
            // UI表示切替処理
            this.Text = "印刷設定";
            this.ChangeEnable(SelectFlag); // 2007.09.10 Hiroki.Hashimoto ADD 

            this.ShowDialog(owner);
            return this.DialogResult;
        }
        #endregion

        #region 帳票情報取得
		#region 2008.03.18 Hiroki.Hashimoto Del
		///// <summary>
		///// 帳票情報を取得
		///// </summary>
		//private void GetPaperInfo(int flag)
		//{
		//    //-- コンボボックスに追加 -------------------------------------
		//    _prtPaperSt = new PrtPaperSt();         //帳票用紙設定
		//    alPrintMngNo = new ArrayList();         //プリンタ情報のAL
			
		//    if (_PrintInfo != null)
		//    {
		//        if (_PrintInfo.outConfimationMsg != null)
		//            comentlbl.Text = _PrintInfo.outConfimationMsg;
		//        else
		//            comentlbl.Text = "";

		//        // DMの場合
		//        if (this.SelectFlag == 20)
		//        {
		//            // 帳票名称取得処理
		//            this.SearchPrintType();
		//            this.PrintType_tComboEditor.SelectedIndex = 0;
		//            FrePrtPSet frePrtPSet = (FrePrtPSet)this.PrintType_tComboEditor.SelectedItem.DataValue;
		//            comentlbl.Text = frePrtPSet.OutConfimationMsg;

		//            if (frePrtPSet.FreePrtPprSpPrpseCd == 1)
		//            {
		//                DMNo_ultraLabel.Visible = true;
		//            }
		//            else
		//            {
		//                DMNo_ultraLabel.Visible = false;
		//            }
		//        }
		//        else
		//        {
		//            if (_PrintInfo.prpnm != null)
		//            {
		//                PrintType_tComboEditor.Text = _PrintInfo.prpnm;
		//            }
		//            else
		//                PrintType_tComboEditor.Text = string.Empty;
		//        }
		//    }
		//}		
		#endregion

		#region 2008.03.18 Hiroki.Hashimoto Add
		/// <summary>
		/// 帳票情報を取得
		/// </summary>
		private void GetPaperInfo()
		{
		    //-- コンボボックスに追加 -------------------------------------
		    _prtPaperSt = new PrtPaperSt();         //帳票用紙設定
		    alPrintMngNo = new ArrayList();         //プリンタ情報のAL
		    if (_PrintInfo != null)
		    {
		        if (_PrintInfo.outConfimationMsg != null)
		            comentlbl.Text = _PrintInfo.outConfimationMsg;
		        else
		            comentlbl.Text = "";

		        if (_PrintInfo.prpnm != null)
		        {
		            //PrintTypeEdit.Text = _PrintInfo.prpnm; // 2007.09.10 Hiroki.Hashimoto Del
		            PrintType_tComboEditor.Text = _PrintInfo.prpnm; // 2007.09.10 Hiroki.Hashimoto Add
		        }
		        else
		            //PrintTypeEdit.Text = ""; // 2007.09.10 Hiroki.Hashimoto Del
		            PrintType_tComboEditor.Text = string.Empty; // 2007.09.10 Hiroki.Hashimoto Add
		    }
		}

		/// <summary>
		/// 帳票情報を取得(自由帳票DM用)
		/// </summary>
		private int GetPaperInfoForDM()
		{
		    //-- コンボボックスに追加 -------------------------------------
		    _prtPaperSt = new PrtPaperSt();         //帳票用紙設定
		    alPrintMngNo = new ArrayList();         //プリンタ情報のAL
			int st = 4;
		    if (_PrintInfo != null)
		    {
				// 帳票名称取得処理
				st = this.SearchPrintType();
				if (st == 0)
				{
					this.PrintType_tComboEditor.SelectedIndex = 0;
					_frePrtPSet = (FrePrtPSet)this.PrintType_tComboEditor.SelectedItem.DataValue;
					comentlbl.Text = _frePrtPSet.OutConfimationMsg;

		            if (_frePrtPSet.FreePrtPprSpPrpseCd == 1)
		            {
		                DMNo_ultraLabel.Visible = true;
		            }
		            else
		            {
		                DMNo_ultraLabel.Visible = false;
		            }
					//FrePrtPSet frePrtPSet = (FrePrtPSet)this.PrintType_tComboEditor.SelectedItem.DataValue;

					//comentlbl.Text = frePrtPSet.OutConfimationMsg;

					//if (frePrtPSet.FreePrtPprSpPrpseCd == 1)
					//{
					//    DMNo_ultraLabel.Visible = true;
					//}
					//else
					//{
					//    DMNo_ultraLabel.Visible = false;
					//}
				}
				else
				{
					PrintInfo.status = st;
					PrintInfo.message = this.CreateMessage(PrintInfo.printPaperUseDivcd);
				}
		    }
			return st;
		}
		#endregion

		/// <summary>
		/// プリンター情報を取得
		/// </summary>
		private void GetPrinterInfo()
		{
			prial = new ArrayList();
			int aricnt = 0;
			if ( _prtManageAcs.Search(out prial ,LoginInfoAcquisition.EnterpriseCode) == 0 )
			{
				foreach( PrtManage mf in prial )
				{
					if ( mf != null )
					{
						if ( mf.LogicalDeleteCode == 0 )
						{
							this.printerCombo1.Items.Add(mf.PrinterMngNo,mf.PrinterName);
                            alPrintMngNo.Add(mf.PrinterMngNo);
                            aricnt++;
						}
					}
				}
			}
            
			if ( aricnt == 0 )
			{
				this.printerCombo1.Text = "デフォルトプリンタ";
				// 2008.3.18 Hiroki.Hashimoto Add Sta >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
				if(_PrintInfo != null)
				// 2008.3.18 Hiroki.Hashimoto Add End <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
					this._PrintInfo.prinm    = "";
			}

            if (printerCombo1.Items.Count > 0)
            {
                LastPrtPrinter lastPrter;
                printerCombo1.SelectedIndex = 0;

                // 最終印刷プリンタのデータがあれば初期値として設定する
                if (_lastPrinters == null) return;
                if (_PrintInfo != null)
                    lastPrter = _lastPrintersAcs.FindLastPrtPrinter(_lastPrinters, DialogMode, SelectFlag, _PrintInfo.printPaperUseDivcd);
                else
                    lastPrter = _lastPrintersAcs.FindLastPrtPrinter(_lastPrinters, DialogMode, SelectFlag, 0);
               
                if (lastPrter != null)
                {
                    for (int idx = 0; idx < printerCombo1.Items.Count; idx++)
                    {
                        if ((Int32)(printerCombo1.Items[idx].DataValue) == lastPrter.PrinterMngNo)
                        {
                            printerCombo1.SelectedIndex = idx;
                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
		/// プリンター情報の詳細を表示
		/// </summary>
		/// <param name="PrinterName"></param>
		private void SetPrinterInfo(string PrinterName)
		{
			// プリンタ名称をキーにプリンタ情報を取得
			Hashtable SelectPrinterInfo = (Hashtable)PrinterInfoList[PrinterName];
			_SelectPrinterInfo = SelectPrinterInfo;
			this._PrintInfo.prinm = printerCombo1.Text.Trim();
        }
        #endregion

        #region プリンタ変更イベント
        /// <summary>
		/// コンボが変更されたときの処理
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void PrinterCombo_SelectionChanged(object sender, System.EventArgs e)
		{
			// 変更されたプリンタの情報を表示
			SetPrinterInfo(printerCombo1.Text.Trim());
        }
        #endregion
       
        #region 抽出ロジック
        /// <summary>
        /// 抽出ロジック
        /// </summary>
        public int ExtraProc()
        {
            int status;
            status = 0;
            // printinfoに格納
            string AssemblyID = "";
            string ClassID = "";
            object ob = null;
            
            ///抽出処理
            if (this._PrintInfo.extrapgid != null)
            {
                if (this._PrintInfo.extrapgid.ToString().Trim() != "")
                {
                    //抽出ＤＬＬをリフレクション
                    AssemblyID = this._PrintInfo.extrapgid.ToString();
                    AssemblyID += ".DLL";
                    ClassID = this._PrintInfo.extraclassid.ToString();

                    // アセンブリのロード
                    try
                    {
                        Assembly assm = Assembly.LoadFrom(AssemblyID);

                        // アセンブリ内のクラスを取得します。
                        // ネームスペースを含めた完全なクラス名で指定する必要があります。
                        System.Type type = assm.GetType(ClassID);

                        if (type != null)
                        {
                            // クラスを動的に作成します。
                            object instance = Activator.CreateInstance(type, new object[] { this._PrintInfo });
                            //実データ印刷
                            MethodInfo method = type.GetMethod("ExtrPrintData", new Type[0]);
                            ob = method.Invoke(instance, null);
                            status = (int)ob;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "エラー");
                    }
                }
            }
            return status;
        }
        #endregion

        #region 印刷ロジック
        /// <summary>
		/// 印刷ロジック
		/// </summary>
		public int PrtProc()
		{
			int status = 0;
		
			object ob = null;
			string AssemblyID = "";
			string ClassID    = "";
			///印刷処理
			if ( this._PrintInfo.printpgid != null )
			{
				if ( this._PrintInfo.printpgid.ToString().Trim() != "" )
				{
					//印刷ＤＬＬをリフレクション
					AssemblyID = this._PrintInfo.printpgid.ToString();
					AssemblyID += ".DLL";
					ClassID = this._PrintInfo.printclassid.ToString();
					// アセンブリのロード
					try
					{
						Assembly assm = Assembly.LoadFrom(AssemblyID);
						// アセンブリ内のクラスを取得します。
						// ネームスペースを含めた完全なクラス名で指定する必要があります。
						System.Type type = assm.GetType(ClassID);
						if( type != null)
						{
							// クラスを動的に作成します。
							object instance = Activator.CreateInstance(type,new object[]{this._PrintInfo});
							MethodInfo method = type.GetMethod("StartPrint",new Type[0]);
							ob = method.Invoke(instance,null);

							status = (int)ob;
						}						
					}
					catch(Exception)
					{
					}
				}
			}
			return status;
        }
        #endregion

		#region OKボタン押下処理
        /// <summary>
        /// ＯＫボタン押下時処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OKButton_Click(object sender, System.EventArgs e)
        {
            int status = 0; ;

            // 一括印刷の場合は抽出印刷は行わないで終了
			if (this._DialogMode != 1)
			{
                // プレビュー印刷チェックボックスの値を格納
                if (PreviewcheckBox.Checked)
                {
                    _EnablePreview = 1;
                    this._PrintInfo.prevkbn = 1;
                }
                else
                {
                    _EnablePreview = 0;
                    this._PrintInfo.prevkbn = 0;
                }

				// 2007.10.02 Hiroki.Hashimoto Add //
				if (this.SelectFlag == 20)
				{
					// 2008.03.18 Hiroki Hashimoto Add Sta >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
					// ファイル名を元に1件Readを行う
					try
					{
						List<FrePprECnd> frePprECndList = null;
						List<FrePprSrtO> frePprSrtOList = null;

						status = this.frePrtPosLocalAcs.ReadLocalFrePrtPSet(ref _frePrtPSet, out frePprECndList, out frePprSrtOList);
					// 2008.03.18 Hiroki Hashimoto Add End <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

						// DMの場合はPrintInfoを作成
						_PrintInfo.InportFrePrtPSet(_frePrtPSet, _PrintInfo.enterpriseCode, _PrintInfo.kidopgid, _PrintInfo.jyoken, _PrintInfo.jyokenDtl, false);

						// 帳票チャート共通部品クラス
						SFCMN00331C cmnCommon = new SFCMN00331C();
						// PDFパス取得
						string pdfPath = "";
						string pdfName = "";

						//PDF出力ファイルパス
						status = cmnCommon.GetPdfSavePathName(_PrintInfo.prpnm, ref pdfPath, ref pdfName);
						_PrintInfo.pdftemppath = pdfPath + pdfName;	//一覧表のときはprintinfoに、PDFの出力先フォルダ情報をセット

					// 2008.03.18 Hiroki Hashimoto Add Sta >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
					}
					catch(Exception)
					{
						_dialogResultCode = DialogResultCode.Error;
						return;
					}
					// 2008.03.18 Hiroki Hashimoto Add End <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
				}
				status = ExtraProc();   // 抽出処理
                if (status == 0)
                {
                    // 印刷処理 
                    status = PrtProc();
                }
			}
			#region 2007.09.12 Hiroki.Hashimoto Add
			if (this.SelectFlag == 10)
			{
                if (status == 0)
                {
                    if(((_PrintInfo!=null) && (_PrintInfo.prevkbn == 0))||(PrintInfo == null)) 
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                else
                    this.DialogResult = System.Windows.Forms.DialogResult.Abort;
			}
			else
			{
				switch (status)
				{
					case 0:
						// DM一覧表で印刷か？それともDMはがきで印刷か？
						if(PrintInfo.printPaperUseDivcd == 3)
							_dialogResultCode = DialogResultCode.FreeList;
						else
							_dialogResultCode = DialogResultCode.FreePostCard;
						break;
					case -1:
						_dialogResultCode = DialogResultCode.Error;
						break;
					default:
						_dialogResultCode = DialogResultCode.Return;
						break;
				}
			}
			#endregion


            #region 最終印刷プリンタ保存
            if (printerCombo1.SelectedItem != null)
            {
                LastPrtPrinter lastprtr;
                if (_PrintInfo != null)
                    lastprtr = _lastPrintersAcs.FindLastPrtPrinter(_lastPrinters, DialogMode, SelectFlag, _PrintInfo.printPaperUseDivcd);
                else
                    lastprtr = _lastPrintersAcs.FindLastPrtPrinter(_lastPrinters, DialogMode, SelectFlag, 0);

                if (lastprtr != null) _lastPrinters.Remove(lastprtr);

                lastprtr = new LastPrtPrinter();
                lastprtr.PrinterMngNo = (Int32)printerCombo1.SelectedItem.DataValue;
                lastprtr.PrinterName = printerCombo1.Text;
                lastprtr.DialogMode = DialogMode;
                lastprtr.SelectFlag = SelectFlag;
                if (_PrintInfo != null)
                    lastprtr.PrintPaperUseDivcd = _PrintInfo.printPaperUseDivcd;
                else
                    lastprtr.PrintPaperUseDivcd = 0;

                if (_lastPrinters == null) _lastPrinters = new List<LastPrtPrinter>();
                _lastPrinters.Add(lastprtr);
                _lastPrintersAcs.Write(_lastPrinters);
            }
            #endregion


            #region 2007.09.12 Hiroki.Hashimoto Del
            //if (status == 0)
			//    this.DialogResult = System.Windows.Forms.DialogResult.OK;
			//else
			//    this.DialogResult = System.Windows.Forms.DialogResult.Abort;
			#endregion
			this.Hide();
			if (this.SelectFlag == 10)
			{
				this.PrintInfo = null;
			}
        }
         #endregion

        #region キャンセルボタン押下
        /// <summary>
		/// キャンセルボタン押下時処理
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CanButton_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
        #endregion

        #region プリンタ変更
        /// <summary>
		/// プリンタ変更
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void printerCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			int selcnt;
			
			selcnt = printerCombo1.SelectedIndex;
			selcnt++;
			
			int cnt = 1;
			if ( selcnt != 0 )
			{
				foreach( PrtManage mf in prial )
				{
					if ( ( mf != null ) && ( cnt == selcnt ))
					{						
						this.printerCombo1.Text = mf.PrinterName;
                        // 一括印刷の時は一端変数に格納
                        if (DialogMode != 1)
                            this._PrintInfo.prinm = mf.PrinterName;
                        else
                            _printerNm = mf.PrinterName;
					}
					cnt++;
				}
			}
        }
        #endregion

///// 2007.09.10 Hiroki.Hashimoto ADD STA
		#region DM用印刷ダイアログ処理
        /// <summary>
		/// DM用印刷ダイアログ表示処理
		/// </summary>
		/// <returns>列挙体</returns>
		/// <remarks>
		/// <br>Note		: フォームが呼び出された時に発生します。</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2007.08.24</br>
		/// </remarks>
        public DialogResultCode ShowDialogFrePrt()
        {
			try
			{
                _dialogResultCode = DialogResultCode.Return;
				this.SelectFlag = 20; // DM

				this.ChangeEnable(SelectFlag);
				this.ShowDialog();
			}
			catch ( Exception )
			{
				_dialogResultCode = DialogResultCode.Error;
			}

			return _dialogResultCode;

        }
		#endregion

		#region UI表示切替処理
        /// <summary>
		/// UI表示切替処理
		/// </summary>
		/// <param name="targetUI">10:帳票,20:DM</param>
		/// <remarks>
		/// <br>Note		: 帳票名称の表示を切り替えます。</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2007.08.24</br>
		/// </remarks>
		private void ChangeEnable(int targetUI)
		{
			if (targetUI == 10)
			{
				this.PrintType_tComboEditor.Appearance.BackColorDisabled = Color.White;
				this.PrintType_tComboEditor.Appearance.ForeColorDisabled = Color.Black;
				this.PrintType_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDown; // 2007.10.17 Hiroki.Hashimoto Add
				this.PrintType_tComboEditor.Enabled = false;
			}
			else
			{
				this.PrintType_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList; // 2007.10.17 Hiroki.Hashimoto Add
				this.PrintType_tComboEditor.Enabled = true;
			}
		}
		#endregion

        /// <summary>
		/// PrintType_tComboEditor_ValueChangedイベント
		/// </summary>
		/// <remarks>
		/// <br>Note		: 帳票が選ばれたタイミングで印字位置データを取得します。</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2007.08.24</br>
		/// </remarks>
		private void PrintType_tComboEditor_ValueChanged(object sender, EventArgs e)
		{
			if (this.PrintType_tComboEditor.SelectedIndex >= 0)
			{
				_frePrtPSet = (FrePrtPSet)this.PrintType_tComboEditor.SelectedItem.DataValue;
				// 出力確認メッセージ
				comentlbl.Text = _frePrtPSet.OutConfimationMsg;

				// DM案内文だったら、注釈を出す
				if (_frePrtPSet.FreePrtPprSpPrpseCd == 1)
				{
					DMNo_ultraLabel.Visible = true;
				}
				else
				{
					DMNo_ultraLabel.Visible = false;
				}
			}
		}

///// 2007.09.10 Hiroki.Hashimoto ADD END

		// 2008.03.18 Hiroki Hashimoto Add Sta >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
		FrePrtPosLocalAcs frePrtPosLocalAcs = null;
        /// <summary>
		/// 帳票名称取得処理
		/// </summary>
        /// <param name="frePrtGuideSearchRet"></param>
		/// <remarks>
		/// <br>Note		: 帳票名称を取得します。</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2007.08.24</br>
		/// </remarks>
		private int SearchPrintType()
		{
			this.PrintType_tComboEditor.Items.Clear();

			if(frePrtPosLocalAcs == null)
				frePrtPosLocalAcs = new FrePrtPosLocalAcs();

			// サーバーから取得したリストを渡して、ローカルとマージした結果を返してもらう
			List<FrePrtPSet> retList = this.frePrtPosLocalAcs.FindAllLocalDataExists(_frePrtPSetList);

			if ((retList == null) || (retList.Count == 0))
			{
				return 4;
			}
			else
			{
			    foreach (FrePrtPSet wkFrePrtPSet in retList)
			    {
			        this.PrintType_tComboEditor.Items.Add(wkFrePrtPSet, wkFrePrtPSet.DisplayName);
			    }
				return 0;
			}
		}

 		/// <summary>
		/// エラーメッセージ作成処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : エラーメッセージを返します。</br>
		/// <br>Programmer : 30015 橋本　裕毅</br>
		/// <br>Date       : 2009.02.05</br>
		/// </remarks>
		private string CreateMessage(int printPaperUseDivcd)
		{
			string msg = string.Empty;
			if (printPaperUseDivcd == 3)
			{
				msg = "この端末に" + ctMsg_FreeDMList + "の印字位置情報がありません\n印字位置情報のダウンロードが必要です";
			}
			else if (printPaperUseDivcd == 4)
			{
				msg = "この端末に" + ctMsg_FreeDMPostCard + "の印字位置情報がありません\n印字位置情報のダウンロードが必要です";
			}
			return msg;
		}
		// 2008.03.18 Hiroki Hashimoto Add End <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

		#region 2008.03.17 Hiroki.Hashimoto Del
		//private void SearchPrintType()
		//{
		//    this.PrintType_tComboEditor.Items.Clear();

		//    if (PrintInfo.printPaperUseDivcd == 3)
		//    {
		//        _frePrtPSetListPrint = new List<FrePrtPSet>();	// 一覧表印字位置List
		//        _frePrtPSetListPrint = _frePrtPSetList.FindAll(
		//            delegate(FrePrtPSet wkFrePrtPSet)
		//            {
		//                if(wkFrePrtPSet.PrintPaperUseDivcd == 3)
		//                    return true;
		//                else
		//                    return false;
		//            }
		//        );

		//        foreach (FrePrtPSet wkFrePrtPSet in _frePrtPSetListPrint)
		//        {
		//            this.PrintType_tComboEditor.Items.Add(wkFrePrtPSet, wkFrePrtPSet.DisplayName);
		//        }
		//    }
		//    else if (PrintInfo.printPaperUseDivcd == 4)
		//    {
		//        _frePrtPSetPostCard = new List<FrePrtPSet>();	// はがき印字位置List
		//        _frePrtPSetPostCard = _frePrtPSetList.FindAll(
		//            delegate(FrePrtPSet wkFrePrtPSet)
		//            {
		//                if(wkFrePrtPSet.PrintPaperUseDivcd == 4)
		//                    return true;
		//                else
		//                    return false;
		//            }
		//        );

		//        foreach (FrePrtPSet wkFrePrtPSet in _frePrtPSetPostCard)
		//        {
		//            this.PrintType_tComboEditor.Items.Add(wkFrePrtPSet, wkFrePrtPSet.DisplayName);
		//        }
		//    }
		//}
		#endregion

	}
}
