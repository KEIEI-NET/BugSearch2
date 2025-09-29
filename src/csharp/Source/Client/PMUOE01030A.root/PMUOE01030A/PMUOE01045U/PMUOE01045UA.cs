//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : ＵＯＥ送受信用ダイアログクラス
// プログラム概要   : ＵＯＥ送受信用ダイアログクラス制御を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10402071-00 作成担当 : 立花 裕輔
// 作 成 日  2008/05/26  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  10601191-00 作成担当 : 高峰
// 作 成 日  2010/05/07  修正内容 : PM1008 明治UOE-WEB対応に伴う仕様追加
//----------------------------------------------------------------------------//
// 管理番号  10902931-00 作成担当 : 譚洪
// 作 成 日  2013/08/15  修正内容 : 発注処理(自動)処理の追加
//----------------------------------------------------------------------------//
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// ＵＯＥ送受信用ダイアログクラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : ＵＯＥ送受信用ダイアログを表示します。</br>
	/// <br>Programmer : 96186 立花 裕輔</br>
	/// <br>Date       : 2008.06.19</br>
	/// <br></br>
	/// <br>UpdateNote : </br>
    /// <br>UpDate</br>
    /// <br>2010/05/07 高峰 PM1008 明治UOE-WEB対応に伴う仕様追加</br>
	/// </remarks>
	public class UoeSndRcvDialog : System.Windows.Forms.Form
    {
		private System.Windows.Forms.Timer Close_Timer;
        private System.Windows.Forms.Panel Container1_Panel;
        private PictureBox pictLogo1;
        private Infragistics.Win.Misc.UltraLabel ultraLabel_SndRcvStatus;
        private Infragistics.Win.Misc.UltraLabel ultraLabel_Connect;
        private Timer Open_Timer;
        private Infragistics.Win.Misc.UltraLabel ultraLabel_GUIDE01;
		private System.ComponentModel.IContainer components;

        // ===================================================================================== //
		// コンストラクタ
		// ===================================================================================== //
        # region Constructors
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.Run(new UoeSndRcvDialog());
        }
        /// <summary>
        /// ＵＯＥ送受信用ダイアログクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : ＵＯＥ送受信用ダイアログクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 96186 立花 裕輔</br>
		/// <br>Date       : 2005.06.19</br>
		/// </remarks>
		public UoeSndRcvDialog()
		{
			InitializeComponent();

            this._uoeSndRcvAcs = new UoeSndRcvAcs();

            this._uoeSndRcvAcs._msg_psfclr += new UoeSndRcvAcs.msg_psfclrEventHandler(this.msg_psfclr);
            this._uoeSndRcvAcs._msg_pssput += new UoeSndRcvAcs.msg_pssputEventHandler(this.msg_pssput);

            // ---- ADD 2013/08/15 譚洪 ---- >>>>>
            //OPT-CPM0110：フタバUOEオプション（個別）
            fuTaBaPs = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_FutabaUOECtl);
            if (fuTaBaPs == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_FuTaBa = (int)Option.ON;
            }
            else
            {
                this._opt_FuTaBa = (int)Option.OFF;
            }
            // ---- ADD 2013/08/15 譚洪 ---- <<<<<
		}
        /// <summary>
        /// インスタンス取得処理
        /// </summary>
        /// <returns></returns>
        public static UoeSndRcvDialog GetInstance()
        {
            if (_uoeSndRcvDialog == null)
            {
                _uoeSndRcvDialog = new UoeSndRcvDialog();
            }
            return _uoeSndRcvDialog;
        }
        # endregion

        # region 使用されているリソース後処理
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
        # endregion

        #region Windows フォーム デザイナで生成されたコード
        /// <summary>
		/// デザイナ サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディタで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UoeSndRcvDialog));
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance97 = new Infragistics.Win.Appearance();
            this.Close_Timer = new System.Windows.Forms.Timer(this.components);
            this.Container1_Panel = new System.Windows.Forms.Panel();
            this.ultraLabel_SndRcvStatus = new Infragistics.Win.Misc.UltraLabel();
            this.pictLogo1 = new System.Windows.Forms.PictureBox();
            this.ultraLabel_Connect = new Infragistics.Win.Misc.UltraLabel();
            this.Open_Timer = new System.Windows.Forms.Timer(this.components);
            this.ultraLabel_GUIDE01 = new Infragistics.Win.Misc.UltraLabel();
            this.Container1_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictLogo1)).BeginInit();
            this.SuspendLayout();
            // 
            // Close_Timer
            // 
            this.Close_Timer.Interval = 1;
            this.Close_Timer.Tick += new System.EventHandler(this.Close_Timer_Tick);
            // 
            // Container1_Panel
            // 
            this.Container1_Panel.BackColor = System.Drawing.Color.White;
            this.Container1_Panel.Controls.Add(this.ultraLabel_SndRcvStatus);
            this.Container1_Panel.Controls.Add(this.pictLogo1);
            this.Container1_Panel.Location = new System.Drawing.Point(4, 24);
            this.Container1_Panel.Name = "Container1_Panel";
            this.Container1_Panel.Size = new System.Drawing.Size(315, 61);
            this.Container1_Panel.TabIndex = 8;
            // 
            // ultraLabel_SndRcvStatus
            // 
            appearance2.ForeColorDisabled = System.Drawing.Color.Black;
            appearance2.TextVAlignAsString = "Middle";
            this.ultraLabel_SndRcvStatus.Appearance = appearance2;
            this.ultraLabel_SndRcvStatus.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel_SndRcvStatus.Location = new System.Drawing.Point(62, 9);
            this.ultraLabel_SndRcvStatus.Name = "ultraLabel_SndRcvStatus";
            this.ultraLabel_SndRcvStatus.Size = new System.Drawing.Size(246, 24);
            this.ultraLabel_SndRcvStatus.TabIndex = 1403;
            // 
            // pictLogo1
            // 
            this.pictLogo1.Image = ((System.Drawing.Image)(resources.GetObject("pictLogo1.Image")));
            this.pictLogo1.Location = new System.Drawing.Point(6, 6);
            this.pictLogo1.Name = "pictLogo1";
            this.pictLogo1.Size = new System.Drawing.Size(50, 50);
            this.pictLogo1.TabIndex = 12;
            this.pictLogo1.TabStop = false;
            // 
            // ultraLabel_Connect
            // 
            appearance1.ForeColorDisabled = System.Drawing.Color.Black;
            appearance1.TextVAlignAsString = "Middle";
            this.ultraLabel_Connect.Appearance = appearance1;
            this.ultraLabel_Connect.AutoSize = true;
            this.ultraLabel_Connect.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel_Connect.Location = new System.Drawing.Point(6, 3);
            this.ultraLabel_Connect.Name = "ultraLabel_Connect";
            this.ultraLabel_Connect.Size = new System.Drawing.Size(60, 17);
            this.ultraLabel_Connect.TabIndex = 1402;
            this.ultraLabel_Connect.Text = "接続先：";
            // 
            // Open_Timer
            // 
            this.Open_Timer.Interval = 1;
            this.Open_Timer.Tick += new System.EventHandler(this.Open_Timer_Tick);
            // 
            // ultraLabel_GUIDE01
            // 
            appearance97.ForeColorDisabled = System.Drawing.Color.Black;
            appearance97.TextVAlignAsString = "Middle";
            this.ultraLabel_GUIDE01.Appearance = appearance97;
            this.ultraLabel_GUIDE01.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel_GUIDE01.Location = new System.Drawing.Point(6, 87);
            this.ultraLabel_GUIDE01.Name = "ultraLabel_GUIDE01";
            this.ultraLabel_GUIDE01.Size = new System.Drawing.Size(313, 24);
            this.ultraLabel_GUIDE01.TabIndex = 1404;
            // 
            // UoeSndRcvDialog
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 15);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(254)))));
            this.ClientSize = new System.Drawing.Size(324, 113);
            this.ControlBox = false;
            this.Controls.Add(this.ultraLabel_GUIDE01);
            this.Controls.Add(this.ultraLabel_Connect);
            this.Controls.Add(this.Container1_Panel);
            this.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UoeSndRcvDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UOE送受信処理";
            this.Shown += new System.EventHandler(this.UoeSndRcvDialog_Shown);
            this.Container1_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictLogo1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        // ===================================================================================== //
        // 定数群
        // ===================================================================================== //
        #region Private Const Member
        private const int DEFAULT_CLIENT_WIDTH = 256;
        private const int    DEFAULT_CLIENT_HEIGHT = 135;  
		private const int    DEFAULT_TIME   = 2;

        // ---- ADD 2013/08/15 譚洪 --- >>>>>
        //メッセージセット関係
        private const string MSGSHOWSOLT = "MSGSHOWSOLT";
        private LocalDataStoreSlot msgShowSolt = null;

        #region ■列挙体
        /// <summary>
        /// オプション有効有無
        /// </summary>
        public enum Option : int
        {
            /// <summary>無効ユーザ</summary>
            OFF = 0,
            /// <summary>有効ユーザ</summary>
            ON = 1,
        }
        #endregion

        /// <summary>テキスト出力オプション情報</summary>
        private int _opt_FuTaBa;//OPT-CPM0110：フタバUOEオプション（個別）

        //専用USB用
        Broadleaf.Application.Remoting.ParamData.PurchaseStatus fuTaBaPs;
        // ---- ADD 2013/08/15 譚洪 --- <<<<<

        # region メッセージをＵＩに表示するフィールド名称
        private const int P_HED = 0;
        private const int P_MSG = 1;
        private const int P_GUIDE01 = 2;
        # endregion

        # endregion

        // ===================================================================================== //
		// プライベート変数
		// ===================================================================================== //
		# region Private Members
        //ダイアログインスタンス
        private static UoeSndRcvDialog _uoeSndRcvDialog = null;

        //ＵＯＥ送受信処理アクセスクラス
        private UoeSndRcvAcs _uoeSndRcvAcs = null;

		//ＵＯＥ送信ヘッダークラス
		private UoeSndHed _uoeSndHed = null;

		//ＵＯＥ受信ヘッダークラス
		private UoeRecHed _uoeRecHed = null;

        //仕入受信モード true:仕入受信処理 false:通常処理
        private bool _processStockSlipDtRecvDiv = false;

        //エラーステータス
        private int _status = 0;

        //エラーメッセージ
        private string _message = "";
        # endregion

        // ===================================================================================== //
        // プロパティ
        // ===================================================================================== //
        # region Properties
        # region 接続先Text
        /// <summary>
        /// 接続先Text
        /// </summary>
        public string ultraLabel_Connect_Text
        {
            get
            {
                return this.ultraLabel_Connect.Text;
            }
            set
            {
                this.ultraLabel_Connect.Text = value;
            }
        }
        # endregion

        # region 送受信状態Text
        /// <summary>
        /// 送受信状態Text
        /// </summary>
        public string ultraLabel_SndRcvStatus_Text
        {
            get
            {
                return this.ultraLabel_SndRcvStatus.Text;
            }
            set
            {
                this.ultraLabel_SndRcvStatus.Text = value;
            }
        }
        # endregion

        # region 送受信状態Text
        /// <summary>
        /// 送受信状態Text
        /// </summary>
        public string ultraLabel_GUIDE01_Text
        {
            get
            {
                return this.ultraLabel_GUIDE01.Text;
            }
            set
            {
                this.ultraLabel_GUIDE01.Text = value;
            }
        }
        # endregion

        # endregion

        /// <summary>
        /// ダイアログ表示処理
        /// </summary>
        /// <param name="uoeSndHed">ＵＯＥ送信オブジェクト</param>
        /// <param name="uoeRecHed">ＵＯＥ受信オブジェクト</param>
        /// <param name="processStockSlipDtRecvDiv">仕入受信モード true:仕入受信処理 false:通常処理</param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Update Note : 2010/05/07 高峰</br>
        /// <br>              PM1008 明治UOE-WEB対応に伴う仕様追加</br>
        /// </remarks>
        public int ShowDialog(UoeSndHed uoeSndHed, out UoeRecHed uoeRecHed, bool processStockSlipDtRecvDiv, out string message)
		{
            uoeRecHed = null;
            message = "";

            try
            {
                //画面の初期化
                ultraLabel_Connect_Text = "接続先：";
                ultraLabel_SndRcvStatus_Text = "";
                ultraLabel_GUIDE01_Text = "";

                // ---ADD 2010/05/07 ------------------>>>>>
                // 優良UOE Web用の表示
                if (UoeSndRcvAcs.IsOtherMakerUOEWeb(uoeSndHed.CommAssemblyId))
                {
                    ultraLabel_Connect_Text += GetWebServerName(uoeSndHed.CommAssemblyId, uoeSndHed);
                    ultraLabel_SndRcvStatus_Text = "通信中です。しばらくお待ち下さい。";
                }
                // ---ADD 2010/05/07 ------------------<<<<<

                //変数の初期化
                _processStockSlipDtRecvDiv = processStockSlipDtRecvDiv;
                _uoeSndHed = uoeSndHed;
                _uoeRecHed = null;
                _status = 0;
                _message = "";

                //this.ShowDialog(); // DEL 2013/08/15 譚洪

                // ---- ADD 2013/08/15 譚洪 --- >>>
                //フタバUSB専用:Option.ON
                if (this._opt_FuTaBa == (int)Option.ON)
                {
                    //メッセージを取得
                    msgShowSolt = System.Threading.Thread.GetNamedDataSlot(MSGSHOWSOLT);
                    //メッセージがない場合、既存の処理、他の場合は発注処理(自動)処理
                    if (System.Threading.Thread.GetData(msgShowSolt) == null
                        || (System.Threading.Thread.GetData(msgShowSolt) != null && (Int32)System.Threading.Thread.GetData(msgShowSolt) == 4)
                        || (System.Threading.Thread.GetData(msgShowSolt) != null && (Int32)System.Threading.Thread.GetData(msgShowSolt) == 2))
                    {
                        this.ShowDialog();
                    }
                    else
                    {
                        //発注処理(自動)処理
                        this.AutoSndRcv();
                    }
                    
                }
                else
                {
                    this.ShowDialog();
                }
                // ---- ADD 2013/08/15 譚洪 --- <<<

                uoeRecHed = _uoeRecHed;
                message = _message;
            }
            catch (Exception ex)
            {
                uoeRecHed = null;
                _status = -1;
                _message = ex.Message;
                message = ex.Message;
                CloseDialog();
            }
            return (_status);
		}

        /// <summary>
        /// 画面クローズ処理
        /// </summary>
        public void CloseDialog()
        {
            this.Close();
        }

        /// <summary>
        /// Timer.Tick イベント(Open_Timer_Tick)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void Open_Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                this.Open_Timer.Enabled = false;

                //ＵＯＥ送信編集アクセスクラス
                if (_uoeSndRcvAcs == null)
                {
                    _uoeSndRcvAcs = new UoeSndRcvAcs();
                }
                //ＵＯＥ送受信処理
                _uoeRecHed = new UoeRecHed();
                _status = _uoeSndRcvAcs.UoeSndRcv(
                                                _uoeSndHed,
                                            out _uoeRecHed,
                                            _processStockSlipDtRecvDiv,
                                            out _message);
                CloseTimerSetting(2);
            }
            catch (Exception ex)
            {
                _uoeRecHed = null;
                _status = -1;
                _message = ex.Message;
                CloseDialog();
            }
        }
        // ---- ADD 2013/08/15 譚洪 --- >>>>>
        /// <summary>
        /// 発注処理(自動)処理の追加
        /// </summary>
        private void AutoSndRcv()
        {
            try
            {
                //ＵＯＥ送信編集アクセスクラス
                if (_uoeSndRcvAcs == null)
                {
                    _uoeSndRcvAcs = new UoeSndRcvAcs();
                }

                //ＵＯＥ送受信処理
                _uoeRecHed = new UoeRecHed();
                _status = _uoeSndRcvAcs.UoeSndRcv(
                                                _uoeSndHed,
                                            out _uoeRecHed,
                                            _processStockSlipDtRecvDiv,
                                            out _message);
            }
            catch (Exception ex)
            {
                _uoeRecHed = null;
                _status = -1;
                _message = ex.Message;
            }
        }
        // ---- ADD 2013/08/15 譚洪 --- <<<<<

        /// <summary>
        /// Timer.Tick イベント(Close_Timer_Tick)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void Close_Timer_Tick(object sender, System.EventArgs e)
		{
            this.Close_Timer.Enabled = false;
            CloseDialog();
		}

        /// <summary>
        /// 開始タイマー制御処理
        /// </summary>
        /// <param name="displayTime">時間（秒単位）</param>
        private void OpenTimerSetting(int displayTime)
        {
            if (displayTime == 0)
            {
                this.Open_Timer.Interval = DEFAULT_TIME * 1000;
            }
            else
            {
                this.Open_Timer.Interval = displayTime * 1000;
            }
            this.Open_Timer.Enabled = true;
        }

        /// <summary>
        /// 終了タイマー制御処理
        /// </summary>
        /// <param name="displayTime">時間（秒単位）</param>
        private void CloseTimerSetting(int displayTime)
		{
			if (displayTime == 0)
			{
				this.Close_Timer.Interval = DEFAULT_TIME * 1000;
			}
			else
			{
				this.Close_Timer.Interval = displayTime * 1000;
			}
			this.Close_Timer.Enabled = true;
		}

        /// <summary>
        /// フォーム表示イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void UoeSndRcvDialog_Shown(object sender, EventArgs e)
        {
            this.OpenTimerSetting(1);
        }

        # region メッセージクリア
        /// <summary>
        /// メッセージクリア
        /// </summary>
        /// <param name="fld">クリアフィールド</param>
        void msg_psfclr(int fld)
        {
            switch (fld)
            {
                case P_HED:
                    this.ultraLabel_Connect_Text = "接続先：";
                    break;
                case P_MSG:
                    ultraLabel_SndRcvStatus_Text = "";
                    break;
                case P_GUIDE01:
                    ultraLabel_GUIDE01_Text = "";
                    break;
            }
        }
        # endregion

        # region メッセージ表示
        /// <summary>
        /// メッセージ表示
        /// </summary>
        /// <param name="fld">表示フィールド</param>
        /// <param name="text">表示テキスト</param>
        void msg_pssput(int fld, string text)
        {
            switch (fld)
            {
                case P_HED:
                    this.ultraLabel_Connect_Text = "接続先：" + text;
                    break;
                case P_MSG:
                    ultraLabel_SndRcvStatus_Text = text;
                    break;
                case P_GUIDE01:
                    ultraLabel_GUIDE01_Text = text;
                    break;
            }
        }
        # endregion

        // ---ADD 2010/05/07 ------------------>>>>>
        /// <summary>
        /// Webサーバの名称を取得します。
        /// </summary>
        /// <param name="commAssemblyId">通信アセンブリID</param>
        /// <param name="uoeSndHed">発注情報</param>
        /// <returns>
        /// <c>EnumUoeConst.ctCommAssemblyId_1004</c>の場合、明治産業を返します。
        /// (該当なしの場合、<c>string.Empty</c>を返します)
        /// </returns>
        public static string GetWebServerName(string commAssemblyId, UoeSndHed uoeSndHed)
        {

			

            switch (commAssemblyId)
            {
                case EnumUoeConst.ctCommAssemblyId_1004:
                    return "明治産業";
                case EnumUoeConst.ctCommAssemblyId_1003:
                    //発注先マスタの取得
                    UoeSndRcvJnlAcs _uoeSndRcvJnlAcs = new UoeSndRcvJnlAcs();

                    UOESupplier _supplier = _uoeSndRcvJnlAcs.SearchUOESupplier(uoeSndHed.UOESupplierCd);
                    if (_supplier != null)
                    {
                        return _supplier.UOESupplierName;
                    }
                    else
                    {
                        return string.Empty;
                    }
                default:
                    return string.Empty;
            }
        }
        // ---ADD 2010/05/07 ------------------<<<<<
	}
}
