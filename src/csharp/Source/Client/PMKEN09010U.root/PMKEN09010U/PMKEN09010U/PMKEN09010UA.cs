using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.Collections;
using System.IO;
using Microsoft.VisualBasic;

using Broadleaf.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Remoting.ParamData;

using Infragistics.Win.UltraWinTabControl;
using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win;
using Infragistics.Win.UltraWinToolTip;


namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 優良設定マスタメインフレーム
	/// </summary>
    /// <remarks>
    /// <br>UpdateNote : 2008/07/01 30415 柴田 倫幸 流用/機能追加の為、修正</br>
    /// <br>UpdateNote : 2009.04.06 20056 對馬 大輔 №13066 拠点ｺｰﾄﾞ追加対応</br>
    /// <br>UpdateNote : 2010/01/13 30517 夏野 駿希 Mantis：14889　拠点コード初期値を“00”全社へ変更</br>
    /// <br>                                        Mantis：14715　拠点変更時に不整合チェック処理が実行されるように変更</br>
    /// </remarks>
	public partial class PMKEN09010UA :Form
	{
		# region ■Constructor
		public PMKEN09010UA()
		{
			InitializeComponent();

            this._controlScreenSkin = new ControlScreenSkin(); // 2009.04.06
		}
		# endregion

		# region ■Private Members

        /// <summary>優良設定コントローラ</summary>
        //public PrimeSettingController _PrimeSettingController;  // DEL 2008/07/01
        public PrimeSettingAcs _PrimeSettingController;           // ADD 2008/07/01

		/// <summary>企業コード</summary>
		private string _enterpriseCode;
		/// <summary>起動システムコード</summary>
		private int _systemCode;
		/// <summary>テキスト出力用子画面制御クラス</summary>
		private FormControlInfo _formControlInfo;
		// HACK:タブを追加する場合はここに追加
		/// <summary>タブ名称配列</summary>
        private string[] TAB_KEYS = new string[] { TAB_MAIN, TAB_ORDER ,TAB_DETAIL, TAB_VIEW };
		/// <summary>テキスト出力用フォームコントロールクラスHashtable</summary>
		private Hashtable _formControlInfoTable;

        // ADD 2008/10/30 不具合対応[6961] 仕様変更 ---------->>>>>
        /// <summary>優良設定用備考の管理画面</summary>
        private IPrimeSettingNoteChanger _noteChangerView;
        /// <summary>
        /// 優良設定用備考の管理画面のアクセサ
        /// </summary>
        /// <value>優良設定用備考の管理画面</value>
        private IPrimeSettingNoteChanger NoteChangerView
        {
            get { return _noteChangerView; }
            set { _noteChangerView = value; }
        }

        /// <summary>優良設定用備考の変化に影響を受ける画面のリスト</summary>
        private readonly IList<IPrimeSettingNoteChangedEventHandler> _noteChangedEventHandlerList = new List<IPrimeSettingNoteChangedEventHandler>();
        /// <summary>
        /// 優良設定用備考の変化に影響を受ける画面のリストを取得します。
        /// </summary>
        /// <value>優良設定用備考の変化に影響を受ける画面のリスト</value>
        public IList<IPrimeSettingNoteChangedEventHandler> NoteChangedEventHandlerList
        {
            get { return _noteChangedEventHandlerList; }
        }
        // ADD 2008/10/30 不具合対応[6961] 仕様変更 ----------<<<<<

        private ControlScreenSkin _controlScreenSkin; // 2009.04.06
        private bool _leaveEventCancel = false; // 2009.04.06

        private bool _bCode = false;// 2010/01/13 Add

		# endregion 

		# region ■Const
        
		//--------------------------------------------------------------------------
		//	メイン画面用
		//--------------------------------------------------------------------------
		# region 中分類・メーカー・品目設定
        private const string TAB_MAIN = "TAB_MAIND";
        // --- DEL 2008/07/01 -------------------------------->>>>>
        //private const string TAB_MAIN_ID = "NSKEN90101U";
        //private const string TAB_MAIN_NS = "Broadleaf.Windows.Forms.NSKEN90101UA";
        // --- DEL 2008/07/01 --------------------------------<<<<< 
        // --- ADD 2008/07/01 -------------------------------->>>>>
        private const string TAB_MAIN_ID = "PMKEN09011U";
        private const string TAB_MAIN_NS = "Broadleaf.Windows.Forms.PMKEN09011UA";
        // --- ADD 2008/07/01 --------------------------------<<<<< 
        private const string TAB_MAIN_NAME = "基本設定";

        private const string MESSAGE_NONOWNSECTION = "自拠点情報が取得できませんでした。拠点設定を行ってから起動してください。"; // 2009.04.06
        private const string SECCODE_ALL = "00"; // 2009.04.06
        private const string SECNAME_ALL = "全社"; // 2009.04.06
		# endregion

        //--------------------------------------------------------------------------
        //	詳細画面用 
        //--------------------------------------------------------------------------
        # region 表示順位
        private const string TAB_ORDER = "TAB_ORDER";
        // --- DEL 2008/07/01 -------------------------------->>>>>
        //private const string TAB_SORT_ID = "NSKEN90107U";
        //private const string TAB_SORT_NS = "Broadleaf.Windows.Forms.NSKEN90107UA";
        //private const string TAB_SORT_NAME = "表示順位設定";
        // --- DEL 2008/07/01 --------------------------------<<<<< 
        // --- ADD 2008/07/01 -------------------------------->>>>>
        private const string TAB_SORT_ID = "PMKEN09014U";
        private const string TAB_SORT_NS = "Broadleaf.Windows.Forms.PMKEN09014UA";
        private const string TAB_SORT_NAME = "表示順・仕入先設定";
        // --- ADD 2008/07/01 --------------------------------<<<<< 

        # endregion
        //--------------------------------------------------------------------------
		//	詳細画面用 
		//--------------------------------------------------------------------------
	    # region 詳細画面
		private const string TAB_DETAIL = "TAB_DETAIL";
        // --- DEL 2008/07/01 -------------------------------->>>>>
        //private const string TAB_DETAIL_ID = "NSKEN90102U";
        //private const string TAB_DETAIL_NS = "Broadleaf.Windows.Forms.NSKEN90102UA";
        // --- DEL 2008/07/01 --------------------------------<<<<< 
        // --- ADD 2008/07/01 -------------------------------->>>>>
        private const string TAB_DETAIL_ID = "PMKEN09012U";
        private const string TAB_DETAIL_NS = "Broadleaf.Windows.Forms.PMKEN09012UA";
        // --- ADD 2008/07/01 --------------------------------<<<<< 
		private const string TAB_DETAIL_NAME = "詳細設定";

        # endregion

        //--------------------------------------------------------------------------
        //	一覧画面用 
        //--------------------------------------------------------------------------
        # region 設定内容一覧
        private const string TAB_VIEW = "TAB_VIEW";
        // --- DEL 2008/07/01 -------------------------------->>>>>
        //private const string TAB_VIEW_ID = "NSKEN90103U";
        //private const string TAB_VIEW_NS = "Broadleaf.Windows.Forms.NSKEN90103UA";
        // --- DEL 2008/07/01 --------------------------------<<<<< 
        // --- ADD 2008/07/01 -------------------------------->>>>>
        private const string TAB_VIEW_ID = "PMKEN09013U";
        private const string TAB_VIEW_NS = "Broadleaf.Windows.Forms.PMKEN09013UA";
        // --- ADD 2008/07/01 --------------------------------<<<<< 
        private const string TAB_VIEW_NAME = "設定内容一覧";
        # endregion

        //--------------------------------------------------------------------------
		//	標準ToolBar
		//--------------------------------------------------------------------------
		# region ▼Const-標準ToolBar
		/// <summary>標準グループ</summary>
		private const string GROUP_NORMAL = "Button_UltraToolbar";
		/// <summary>終了 ボタン Key</summary>
		private const string BUTTON_CLOSE = "Close";
		/// <summary>ファイル出力 ボタン Key</summary>
		private const string BUTTON_OUTPUT = "Output";
		/// <summary>クリア ボタン Key</summary>
		private const string BUTTON_CLEAR = "Clear";
		/// <summary>保存ボタン Key</summary>
		private const string BUTTON_SAVE = "Save";
        /// <summary>進むボタン Key</summary>
        //private const string BUTTON_NEXT = "Next";  // DEL 2008/07/01
        /// <summary>戻るボタン Key</summary>
        //private const string BUTTON_BACK = "Back";  // DEL 2008/07/01
        /// <summary>印刷ボタン Key</summary>
        private const string BUTTON_PRINT = "Print";
        /// <summary>シークレット</summary>
        private const string SECRET = "Secret";
        # endregion

		//--------------------------------------------------------------------------
		//	抽出条件ToolBar
		//--------------------------------------------------------------------------
		# region ▼Const-抽出条件ToolBar
		/// <summary>抽出条件グループ</summary>
		private const string GROUP_EXTRACTCONDITION	= "ExtractCondition_Toolbar";
		/// <summary>システム コンボボックス Key</summary>
		private const string COMBOBOXTOOL_SYSTEM = "DataInputSystem_tComboEditor";
		/// <summary>出力対象拠点 ラベル Key</summary>
		private const string LABEL_OUTPUTSEC = "OutPutSecTitle_Label";
		/// <summary>出力対象拠点 コンボボックス Key</summary>
		private const string COMBOBOXTOOL_OUTPUTSEC = "OutPutSec_ComboEditor";
		# endregion

		//--------------------------------------------------------------------------
		//	その他
		//--------------------------------------------------------------------------
		# region ▼Const-その他
		/// <summary>拠点-[全社]コード</summary>
		private const string SEC_ALLSEC_CD = "000000";
		/// <summary>拠点-[全社]名称</summary>
		private const string SEC_ALLSEC_NM = "全社";
		/// <summary>タブなし</summary>
		private const string NO_TAB = "";

        // --- ADD 2008/07/01 -------------------------------->>>>>
        private const string PROGRAM_NAME = "優良設定マスタ";
        private const string PROGRAM_ID = "PMKEN09010U";
        // --- ADD 2008/07/01 --------------------------------<<<<< 
		# endregion
   
        # endregion

        # region ■Events

        /// <remarks>タブ変更で発生するイベント</remarks>
       public event MainTabChangeEventHandler TabIndexChange;

       /// <remarks>ツールボタンで子に処理させたい場合に発生させるイベント</remarks>
       public event FrameNotifyEventHandler _frameNotifyEvent;

       # region Loadイベント
        /// <summary>
		/// PMKEN09010UA Loadイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
        private void PMKEN09010UA_Load(object sender, EventArgs e)
        {
			try
			{
                // 2009.04.06 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                this._controlScreenSkin.LoadSkin();
                // スキン変更除外設定
                List<string> excCtrlNm = new List<string>();
                excCtrlNm.Add(this.Standard_UGroupBox.Name);
                this._controlScreenSkin.SetExceptionCtrl(excCtrlNm);
                this._controlScreenSkin.SettingScreenSkin(this);
                // 2009.04.06 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

				if (LoginInfoAcquisition.EnterpriseCode != null)
					_enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

				if ((Program._param != null) && (Program._param.Length > (int)ConstantManagement_SF_AP.ExeParameterIndex.ctPRM_CUSTOM1))
				{
					// 起動システムコードを取得
					_systemCode = Convert.ToInt32(Program._param[(int)ConstantManagement_SF_AP.ExeParameterIndex.ctPRM_CUSTOM1]);
				}

				// ultraTabControlにImageListを設定
				this.Main_TabControl.ImageList = Broadleaf.Library.Resources.IconResourceManagement.ImageList16;
				// ツールバーを設定する
				this.SettingToolbar();

                // --- ADD 2009/03/10 障害ID:12270対応------------------------------------------------------>>>>>
                // タブスタイル設定
                Main_TabControl.UseOsThemes = DefaultableBoolean.False;
                Main_TabControl.Appearance.BackColor = Color.WhiteSmoke;
                Main_TabControl.Appearance.BackColor2 = Color.FromArgb(198, 219, 255);
                Main_TabControl.Appearance.BackGradientStyle = GradientStyle.Vertical;
                Main_TabControl.ActiveTabAppearance.BackColor = Color.White;
                Main_TabControl.ActiveTabAppearance.BackColor2 = Color.Pink;
                Main_TabControl.ActiveTabAppearance.BackGradientStyle = GradientStyle.Vertical;
                Main_TabControl.Style = UltraTabControlStyle.VisualStudio2005;
                Main_TabControl.ViewStyle = ViewStyle.Office2003;
                // --- ADD 2009/03/10 障害ID:12270対応------------------------------------------------------<<<<<

                // 2009.04.06 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                this.uButton_SectionGuide.ImageList = IconResourceManagement.ImageList16;
                this.uButton_SectionGuide.Appearance.Image = (int)Size16_Index.STAR1;
                SecInfoSet secInfoSet = this.GetSecInfo(LoginInfoAcquisition.Employee.BelongSectionCode.Trim());
                // 2010/01/13 >>>
                //this.tEdit_SectionCode.Text = secInfoSet.SectionCode.Trim();
                //this.uLabel_SectionNm.Text = secInfoSet.SectionGuideNm.Trim(); ;
                this.tEdit_SectionCode.Text = SECCODE_ALL;
                this.uLabel_SectionNm.Text = SECNAME_ALL;
                // 2010/01/13 <<<
                this.tEdit_SectionCode.Focus();
                // 2009.04.06 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

				// 現在のカーソルを保持
				Cursor localCursor = this.Cursor;
				// カーソルを砂時計に
				this.Cursor = Cursors.WaitCursor;

                //_PrimeSettingController = new PrimeSettingController();  // DEL 2008/07/01
                _PrimeSettingController = new PrimeSettingAcs();           // ADD 2008/07/01
                _PrimeSettingController.EnterPriseCode = LoginInfoAcquisition.EnterpriseCode;
                // 2010/01/13 >>>
                //_PrimeSettingController.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.TrimEnd();  // ADD 2008/07/04
                _PrimeSettingController.SectionCode = SECCODE_ALL;
                // 2010/01/13 <<<

                // 該当データ取得
                int status = _PrimeSettingController.DataSearch();

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            foreach (string wkString in this.TAB_KEYS)
                            {
                                // フォーム制御テーブルを生成する
                                this.FormControlInfoCreate(wkString);
                                // MDI子画面生成
                                this.CreateMdiChildForm(wkString, _formControlInfo.AssemblyID, _formControlInfo.ClassID, _formControlInfo.Key, _formControlInfo.Name, _formControlInfo.Icon, _formControlInfo);
                            }
                            // ADD 2008/10/30 不具合対応[6961] 仕様変更 ---------->>>>>
                            // 優良設定用備考の表示用処理
                            if (NoteChangerView != null)
                            {
                                foreach (IPrimeSettingNoteChangedEventHandler handler in NoteChangedEventHandlerList)
                                {
                                    NoteChangerView.NoteChanged += handler.PrimeSettingNoteChanged;
                                }
                            }
                            // ADD 2008/10/30 不具合対応[6961] 仕様変更 ----------<<<<<
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                        {
                            break;
                        }
                    default:
                        {
                            // サーチ
                            TMsgDisp.Show(
                                this, 								// 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                                PROGRAM_ID, 						// アセンブリＩＤまたはクラスＩＤ
                                PROGRAM_NAME, 			            // プログラム名称
                                "PMKEN09010UA_Load", 			    // 処理名称
                                TMsgDisp.OPE_GET, 					// オペレーション
                                "読み込みに失敗しました。", 		// 表示するメッセージ
                                status, 							// ステータス値
                                this._PrimeSettingController, 	    // エラーが発生したオブジェクト
                                MessageBoxButtons.OK, 				// 表示するボタン
                                MessageBoxDefaultButton.Button1);	// 初期表示ボタン

                            break;
                        }
                }

				// カーソルを戻す
				this.Cursor = localCursor;

				// 先頭Tabを選択
				this.Main_TabControl.SelectedTab = this.Main_TabControl.Tabs[0];
			}
			finally
			{
				// 起動用フローティングウィンドウ(Close)
				//Program._floatingWindow.Close();  // DEL 2008/07/01
			}
		}
		# endregion

		# region FormClosingイベント
        private void PMKEN09010UA_FormClosing(object sender, FormClosingEventArgs e)
        {

			// MDI子画面が展開されていない→exit
			if (this.Main_TabControl.Tabs.Count <= 0)
				return;

			// 編集画面の内容をStatic領域にストアする
//			StoreMdiChild();
		}
		# endregion

		# region ツールバークリックイベント
		/// <summary>
		/// ツールバークリックイベント
		/// </summary>
		private void Main_ToolbarsManager_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
		{
            int status = 0;  // ADD 2008/07/01

            switch (e.Tool.Key)
            {
                // 終了ボタン
                case BUTTON_CLOSE:
                    {
                        // メイン画面のクローズ
                        this.Close();
                        break;
                    }

                // テキスト出力ボタン
                case BUTTON_OUTPUT:
                    {
                        // テキスト出力処理
                        this.Main_TabControl.SelectedTab = this.Main_TabControl.Tabs[0];
                        break;
                    }

                // クリアボタン
                case BUTTON_CLEAR:
                    {
                        // クリア処理
                        //this.ExConditionClear();
                        break;
                    }

                // TODO:保存ボタン
                case BUTTON_SAVE:
                    {
                        if (TMsgDisp.Show(emErrorLevel.ERR_LEVEL_QUESTION,PROGRAM_ID, "更新しますか？", 0, MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            this.ultraStatusBar1.Panels["Text"].Text = string.Empty;    // ADD 2008/11/25 不具合対応[6962] 仕様変更 仕入先コードは全体で必須入力

                            // ADD 2008/10/29 不具合対応[6962] 仕様変更 ---------->>>>>
                            // 仕入先コードの入力チェック
                            string errorMessage = string.Empty;
                            IPrimeSettingCheckable checker = this.Main_TabControl.ActiveTab.Tag as IPrimeSettingCheckable;
                            if (checker != null)
                            {
                                if (!checker.CanSave(out errorMessage))
                                {
                                    this.ultraStatusBar1.Panels["Text"].Text = errorMessage;
                                    TMsgDisp.Show(
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        PROGRAM_ID,
                                        errorMessage,
                                        status,
                                        MessageBoxButtons.OK
                                    );
                                    break;
                                }
                            }
                            // ADD 2008/10/29 不具合対応[6962] 仕様変更 ----------<<<<<

                            // DEL 2008/11/25 不具合対応[6962] ↓仕様変更 仕入先コードは全体で必須入力
                            //status = _PrimeSettingController.updatePrimeSettingList();
                            // ADD 2008/11/25 不具合対応[6962] 仕様変更 仕入先コードは全体で必須入力 ---------->>>>>
                            status = _PrimeSettingController.updatePrimeSettingList(out errorMessage);
                            if (status.Equals(PrimeSettingAcs.UPDATE_CHECK_ERROR) && !string.IsNullOrEmpty(errorMessage))
                            {
                                this.ultraStatusBar1.Panels["Text"].Text = errorMessage;
                                TMsgDisp.Show(
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    PROGRAM_ID,
                                    errorMessage,
                                    status,
                                    MessageBoxButtons.OK
                                );
                                break;
                            }
                            // ADD 2008/11/25 不具合対応[6962] 仕様変更 仕入先コードは全体で必須入力 ----------<<<<<
                            // ----- ADD 2012/09/25 xupz for redmine#32367----->>>>>
                            if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE)
                            {
                                TMsgDisp.Show(
                                this,								// 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
                                "PMKEN09010U",						// アセンブリＩＤまたはクラスＩＤ
                                this.Text,							// プログラム名称
                                "ExclusiveTransaction",				// 処理名称
                                TMsgDisp.OPE_UPDATE,							// オペレーション
                                "既に他端末より更新されています",						// 表示するメッセージ 
                                status,								// ステータス値
                                "",							// エラーが発生したオブジェクト
                                MessageBoxButtons.OK,				// 表示するボタン
                                MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                                break;
                            }
                            else if (status == (int)ConstantManagement.DB_Status.ctDB_DUPLICATE)
                            {
                                TMsgDisp.Show(
                                this,								// 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
                                "PMKEN09010U",						// アセンブリＩＤまたはクラスＩＤ
                                "既に他端末より更新されています",                        // 表示するメッセージ
                                status,								// ステータス値
                                MessageBoxButtons.OK);				// 表示するボタン
                                break;
                            }
                            // ----- ADD 2012/09/25 xupz for redmine#32367-----<<<<<
                            //if ((status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) && // DEL 2012/09/25 xupz for redmine#32367
                            else if ((status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) && // ADD 2012/09/25 xupz for redmine#32367
                                (status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) &&
                                (status != (int)ConstantManagement.DB_Status.ctDB_EOF))
                            {
                                // 登録失敗
                                TMsgDisp.Show(
                                    this, 								// 親ウィンドウフォーム
                                    emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                                    PROGRAM_ID, 						// アセンブリＩＤまたはクラスＩＤ
                                    PROGRAM_NAME, 		     	        // プログラム名称
                                    "Main_ToolbarsManager_ToolClick", 	// 処理名称
                                    TMsgDisp.OPE_UPDATE, 				// オペレーション
                                    "更新に失敗しました。", 			// 表示メッセージ
                                    status, 							// ステータス値
                                    this._PrimeSettingController,	    // エラーが発生したオブジェクト
                                    MessageBoxButtons.OK, 				// 表示するボタン
                                    MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                            }
                            else
                            {
                                SaveCompletionDialog dialog = new SaveCompletionDialog();
                                dialog.ShowDialog(2);  // アニメーション2秒
                            }
                        }
                        break;
                    }
            }
		}
		# endregion

		# region SelectedTabChangedイベント
		/// <summary>
		/// タブ SelectedTabChangedイベント
		/// </summary>
		private void Main_TabControl_SelectedTabChanged(object sender, SelectedTabChangedEventArgs e)
		{
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // 画面非表示イベント
                if (TabIndexChange != null)
                {
                    int TabIndex = ((SelectedTabChangedEventArgs)e).Tab.Index;
                    TabIndexChange(this, TabIndex);
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
		}
		# endregion

        # region 子画面通知イベント
        /// <summary>
        /// タブ SelectedTabChangedイベント
        /// </summary>
        private void FrameNotifyEvent( string key)
        {
            // 画面非表示イベント
            if (_frameNotifyEvent != null)
            {
                _frameNotifyEvent(this, this.Main_TabControl.SelectedTab.Index, key);
            }

        }
        # endregion


		# endregion

		# region ■Private Methods
        # region ▼タブ構築関連
        
		/// <summary>
		/// フォームコントロールクラスクリエイト処理
		/// </summary>
		/// <param name="nexViewFormname">次に表示するフォーム</param>
		private void FormControlInfoCreate(string nexViewFormname)
		{
			_formControlInfo = null;

            switch (nexViewFormname)
            {
                // タブアイコン
                case (TAB_MAIN):
                    {
                        _formControlInfo = new FormControlInfo(nexViewFormname, TAB_MAIN_ID, TAB_MAIN_NS,
                            TAB_MAIN_NAME, IconResourceManagement.ImageList16.Images[(int)Size16_Index.MAIN], TAB_SORT_ID, NO_TAB);
                        break;
                    }
                case (TAB_ORDER):
                    {
                        _formControlInfo = new FormControlInfo(nexViewFormname, TAB_SORT_ID, TAB_SORT_NS,
                            TAB_SORT_NAME, IconResourceManagement.ImageList16.Images[(int)Size16_Index.SUBMENU], TAB_DETAIL_ID, TAB_MAIN_ID);
                        break;
                    }
                case (TAB_DETAIL):
                    {
                        _formControlInfo = new FormControlInfo(nexViewFormname, TAB_DETAIL_ID, TAB_DETAIL_NS,
                            TAB_DETAIL_NAME, IconResourceManagement.ImageList16.Images[(int)Size16_Index.DETAILS], TAB_VIEW_ID, TAB_SORT_ID);
                        break;
                    }
                case (TAB_VIEW):
                    {
                        _formControlInfo = new FormControlInfo(nexViewFormname, TAB_VIEW_ID, TAB_VIEW_NS,
                            TAB_VIEW_NAME, IconResourceManagement.ImageList16.Images[(int)Size16_Index.ALLSELECT], NO_TAB, TAB_DETAIL_ID);
                        break;
                    }
            }

			// フォームコントロールクラスHashtabelにAdd
			if (this._formControlInfoTable == null)
			{
				this._formControlInfoTable = new Hashtable();
			}
			this._formControlInfoTable[nexViewFormname] = _formControlInfo;
		}
        

		/// <summary>
		/// MDI子画面を生成する
		/// </summary>
		/// <param name="key">フォームクラス識別Key</param>
		/// <param name="frmAssemblyName">フォームアセンブリ名</param>
		/// <param name="frmClassName">フォームクラス名称</param>
		/// <param name="frmName">フォーム名</param>
		/// <param name="title">タブ名称</param>
		/// <param name="icon">アイコン・イメージ</param>
		/// <param name="info">フォーム制御情報</param>
		/// <returns>none</returns>								
		private Form CreateMdiChildForm(string key, string frmAssemblyName, string frmClassName, string frmName, string title, Image icon, FormControlInfo info)
		{
			Form form = null;

			// フォームのインスタンス化
			form = (System.Windows.Forms.Form)this.LoadAssemblyFrom(frmAssemblyName, frmClassName, typeof(System.Windows.Forms.Form));
			// テキスト出力用フォームコントロールクラスにインターフェースオブジェクトをセット
			//((FormControlInfo)this._formControlInfoTable[key]).TextOutInterface = (ITextOutForm)form;

			if (form != null)
			{
				// フォームプロパティ変更
				form.Name = frmName;

				// タブページコントロールをインスタンス
				UltraTabPageControl uTabPageControl = new UltraTabPageControl();

				// タブの外観を設定し、タブコントロールにタブを追加する
				UltraTab uTab = new UltraTab();
				uTab.TabPage = uTabPageControl;
				uTab.Text = title;				// 名称
				uTab.Key = frmName;				// Key
				uTab.Tag = form;				// フォームのインスタンス
				uTab.Appearance.Image = icon;	// アイコン
				uTab.Appearance.BackColor = Color.White;
				uTab.Appearance.BackColor2 = Color.Lavender;
				uTab.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
				uTab.ActiveAppearance.BackColor = Color.White;
				uTab.ActiveAppearance.BackColor2 = Color.LightPink;
				uTab.ActiveAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;

				this.Main_TabControl.Controls.Add(uTabPageControl);
				this.Main_TabControl.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] { uTab });
				this.Main_TabControl.SelectedTab = uTab;

				form.TopLevel = false;
				form.FormBorderStyle = FormBorderStyle.None;
                /*
				// IEntryTbsMDIChildインターフェイスを実装している場合は以下の処理を実行する。
                if ((form is IEntryTbsMDIChild))
                {
                    // 引数のオブジェクトには、起動するシステムコードを入れる
                    ((IEntryTbsMDIChild)form).Show(_systemCode);
                }
                else
                 */
                if ((form is IPrimeSettingController))
                {
                    ((IPrimeSettingController)form).objPrimeSettingController = (object)_PrimeSettingController;
                    TabIndexChange += ((IPrimeSettingController)form).MainTabIndexChange;
                    _frameNotifyEvent += ((IPrimeSettingController)form).FrameNotifyEvent;
                    form.Show();
                }
                else
                {
                    form.Show();
                }
               
				uTabPageControl.Controls.Add(form);
				form.Dock = System.Windows.Forms.DockStyle.Fill;

                // ADD 2008/10/30 不具合対応[6961] 仕様変更 ---------->>>>>
                // 優良設定用備考の値を管理する画面を保持
                IPrimeSettingNoteChanger noteChangerForm = form as IPrimeSettingNoteChanger;
                if (noteChangerForm != null)
                {
                    NoteChangerView = noteChangerForm;
                }

                // 優良設定用備考の変化に影響を受ける画面を保持
                IPrimeSettingNoteChangedEventHandler noteChangedForm = form as IPrimeSettingNoteChangedEventHandler;
                if (noteChangedForm != null)
                {
                    NoteChangedEventHandlerList.Add(noteChangedForm);
                }
                // ADD 2008/10/30 不具合対応[6961] 仕様変更 ----------<<<<<
			}
			info.Form = form;

			return form;
		}
		# endregion

		# region ▼ツールバー関連
		/// <summary>
		/// ツールバーの設定
		/// </summary>
		/// <remarks>テキスト出力フレームのツールバーの設定を行います。</remarks>
		private void SettingToolbar()
		{
			// イメージリストを設定する
			Main_ToolbarsManager.ImageListSmall = Broadleaf.Library.Resources.IconResourceManagement.ImageList16;

			//--------------------------------------------------------------
			// メイン ツールバー
			//--------------------------------------------------------------
			// ログイン担当者へのアイコン設定
			Infragistics.Win.UltraWinToolbars.LabelTool loginEmployeeLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)Main_ToolbarsManager.Tools["LOGINTITLE"];
			if (loginEmployeeLabel != null)
				loginEmployeeLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;

			// ログイン名
			Infragistics.Win.UltraWinToolbars.LabelTool LoginName = (Infragistics.Win.UltraWinToolbars.LabelTool)Main_ToolbarsManager.Tools["LoginName_LabelTool"];
			if (LoginName != null && LoginInfoAcquisition.Employee != null)
			{
				Employee employee = new Employee();
				employee = LoginInfoAcquisition.Employee;
				LoginName.SharedProps.Caption = employee.Name;
			}

            // --- ADD 2008/07/01 -------------------------------->>>>>
            // 拠点名称取得
            SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
            SecInfoSet secInfoSet = new SecInfoSet();

            // 拠点名称取得
            int status = secInfoSetAcs.Read(out secInfoSet, this._enterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode);

            if (status == 0)
            {
                // 拠点名称設定
                Infragistics.Win.UltraWinToolbars.LabelTool SectionName = (Infragistics.Win.UltraWinToolbars.LabelTool)Main_ToolbarsManager.Tools["SectionName_LabelTool"];
                SectionName.SharedProps.Caption = secInfoSet.SectionGuideNm;
            }
            // --- ADD 2008/07/01 --------------------------------<<<<< 

			//--------------------------------------------------------------
			// 標準 ツールバー
			//--------------------------------------------------------------
			// 終了のアイコン設定
			Infragistics.Win.UltraWinToolbars.ButtonTool closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[BUTTON_CLOSE];
			if (closeButton != null)
				closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;

            // --- DEL 2008/07/01 -------------------------------->>>>>
            //// 進むのアイコン設定
            //Infragistics.Win.UltraWinToolbars.ButtonTool nextButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[BUTTON_NEXT];
            //if (nextButton != null)
            //    nextButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.NEXT;

            //// 戻るのアイコン設定
            //Infragistics.Win.UltraWinToolbars.ButtonTool backButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[BUTTON_BACK];
            //if (backButton != null)
            //    backButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BEFORE;
            // --- DEL 2008/07/01 --------------------------------<<<<< 

            // 印刷のアイコン設定
            Infragistics.Win.UltraWinToolbars.ButtonTool printButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[BUTTON_PRINT];
            if (printButton != null)
            {
                printButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.PRINT;
                // ADD 2008/10/28 不具合対応[6966] [印刷]ボタンは不要 ---------->>>>>
                printButton.SharedProps.Enabled = false;
                printButton.SharedProps.Visible = false;
                // ADD 2008/10/28 不具合対応[6966] [印刷]ボタンは不要 ----------<<<<<
            }
            
            // 保存のアイコン設定
            Infragistics.Win.UltraWinToolbars.ButtonTool saveButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[BUTTON_SAVE];
            if (saveButton != null)
                saveButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;

			// 出力のアイコン設定
			Infragistics.Win.UltraWinToolbars.ButtonTool outputButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[BUTTON_OUTPUT];
            if (outputButton != null)
            {
                outputButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CSVOUTPUT;
                // ADD 2008/10/28 不具合対応[6966] [ファイル出力]ボタンは不要 ---------->>>>>
                outputButton.SharedProps.Enabled = false;
                outputButton.SharedProps.Visible = false;
                // ADD 2008/10/28 不具合対応[6966] [ファイル出力]ボタンは不要 ----------<<<<<
            }

            // --- DEL 2008/07/01 -------------------------------->>>>>
			// クリアのアイコン設定
            //Infragistics.Win.UltraWinToolbars.ButtonTool clearButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[BUTTON_CLEAR];
            //if (clearButton != null)
            //    clearButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.UNDO;
            // --- DEL 2008/07/01 --------------------------------<<<<< 

			// １段目に配置
			//Main_ToolbarsManager.Toolbars["ExtractCondition_Toolbar"].DockedRow = 1;   
		}

		# endregion
        /*
		/// <summary>
		/// 子画面の保存処理
		/// </summary>
		/// <returns>ステータス</returns>
		/// <remarks>子画面に対して、Staticに保存させる処理を実行させます。</remarks>
		private int StoreMdiChild()
		{
			int st = -1;

			if (_formControlInfo != null)
			{
				if (_formControlInfo.Form is IEntryTbsMDIChildEdit)
				{
					// スタティック保存処理
					st = ((IEntryTbsMDIChildEdit)_formControlInfo.Form).SaveStaticMemoryData(this);
				}
			}

			return st;
		}
        */
		/// <summary>
		/// 指定されたアセンブリ及びクラス名より、クラスをインスタンス化する
		/// </summary>
		/// <param name="asmname">アセンブリ名称</param>
		/// <param name="classname">クラス名称</param>
		/// <param name="type">実装するクラス型</param>
		/// <returns>インスタンス化されたクラス</returns>
		/// <remarks>アセンブリをロードします。</remarks>
		private object LoadAssemblyFrom(string asmname, string classname, Type type)
		{
			object obj = null;
			try
			{
				System.Reflection.Assembly asm = System.Reflection.Assembly.Load(asmname);
				Type objType = asm.GetType(classname);
				if (objType != null)
				{
					if ((objType == type) || (objType.IsSubclassOf(type) == true) || (objType.GetInterface(type.Name).Name == type.Name))
					{
						obj = Activator.CreateInstance(objType);
					}
				}
			}
			catch (System.IO.FileNotFoundException er)
			{
				// 対象アセンブリなし（警告）
				TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, Program.PGID, er.StackTrace, 0, MessageBoxButtons.OK);
			}
			catch (System.Exception er)
			{
				// 対象アセンブリなし（警告)
				string _msg = "Message=" + er.Message + "\r\n" + "Trace  =" + er.StackTrace + "\r\n" + "Source =" + er.Source;
				TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, Program.PGID, _msg, 0, MessageBoxButtons.OK);
			}

			return obj;
		}


		# endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMKEN09010UA_KeyDown(object sender, KeyEventArgs e)
        {
            // DEL 2008/10/28 不具合対応[6971]↓
            /*
            if (e.KeyCode == Keys.Escape)
            {
                if (MessageBox.Show("終了しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Close();
            }
            else*/ 
            if ((e.Control) && (e.KeyCode == Keys.S))
            {
                // --- CHG 2009/02/19 障害ID:11684対応------------------------------------------------------>>>>>
                //if (_PrimeSettingController.SecretMode == false) return;
                //if ("051231" == Interaction.InputBox("パスワード入力", "シークレットモード移行", "",0,0))
                //{
                //    _PrimeSettingController.SecretMode = false;
                //    FrameNotifyEvent(SECRET);
                //}

                InputPassword inputPass = new InputPassword();
                DialogResult result = inputPass.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    if ("051231" == inputPass.Password)
                    {
                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,
                                        PROGRAM_ID,
                                        "シークレットメーカーを表示します。",
                                        0,
                                        MessageBoxButtons.OK);

                        _PrimeSettingController.SecretMode = false;
                        FrameNotifyEvent(SECRET);
                    }
                    else
                    {
                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,
                                        PROGRAM_ID,
                                        "パスワードが間違っています。",
                                        0,
                                        MessageBoxButtons.OK);
                    }
                }
                // --- CHG 2009/02/19 障害ID:11684対応------------------------------------------------------<<<<<
            }
        }

        // TODO:削除画面
        private void PMKEN09010UA_Shown(object sender, EventArgs e)
        {
            int status;

            if (_PrimeSettingController.UserPrimeSettingTable.Rows.Count > 0)
            {
                Form frm = new PMKEN09010UD(_PrimeSettingController.UserPrimeSettingTable.DefaultView);

                if (frm.ShowDialog() == DialogResult.Cancel) return;

                // ユーザー登録分にあって提供にないデータを削除する
                status = _PrimeSettingController.updateUserDeleteList();

                if ((int)ConstantManagement.DB_Status.ctDB_NORMAL != status)
                {
                    TMsgDisp.Show(
                    this, 								// 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                    PROGRAM_ID, 						// アセンブリＩＤまたはクラスＩＤ
                    PROGRAM_NAME, 				        // プログラム名称
                    "PMKEN09010UA_Shown", 				// 処理名称
                    TMsgDisp.OPE_DELETE, 				// オペレーション
                    "削除に失敗しました。", 			// 表示するメッセージ
                    status, 							// ステータス値
                    this._PrimeSettingController,	    // エラーが発生したオブジェクト
                    MessageBoxButtons.OK, 				// 表示するボタン
                    MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                }
            }
        }

        // 2009.04.06 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// ChangeFocus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            this._leaveEventCancel = false;

            // PrevCtrl設定
            Control prevCtrl = new Control();
            if (e.PrevCtrl is Control) prevCtrl = (Control)e.PrevCtrl;

            switch (prevCtrl.Name)
            {
                #region 拠点コード
                //---------------------------------------------------------------
                // 拠点コード
                //---------------------------------------------------------------
                case "tEdit_SectionCode":
                    {
                        this._leaveEventCancel = true;
                        string code = this.tEdit_SectionCode.Text.Trim();
                        code = this.uiSetControl1.GetZeroPaddedText(tEdit_SectionCode.Name, code);

                        if (string.IsNullOrEmpty(code))
                        {
                            this.tEdit_SectionCode.Text = SECCODE_ALL;
                            this.uLabel_SectionNm.Text = SECNAME_ALL;
                            this.ReSettingPrmInfo();
                            // 2010/01/13 Add >>>
                            if (_bCode == true)
                            {
                                this.PMKEN09010UA_Shown(sender, e);
                                _bCode = false;
                            }
                            // 2010/01/13 Add <<<
                        }
                        else
                        {
                            SecInfoSet secInfoSet = this.GetSecInfo(code);

                            if (secInfoSet == null)
                            {
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    "拠点が存在しません。",
                                    -1,
                                    MessageBoxButtons.OK);
                                this.tEdit_SectionCode.Text = SECCODE_ALL;
                                this.uLabel_SectionNm.Text = SECNAME_ALL;
                                e.NextCtrl = e.PrevCtrl;
                            }
                            else
                            {
                                this.tEdit_SectionCode.Text = secInfoSet.SectionCode.Trim();
                                this.uLabel_SectionNm.Text = secInfoSet.SectionGuideNm;
                                this.ReSettingPrmInfo();
                                // 2010/01/13 Add >>>
                                if (_bCode==true)
                                {
                                    this.PMKEN09010UA_Shown(sender, e);
                                    _bCode = false;
                                }
                                // 2010/01/13 Add <<<
                            }
                        }
                        break;
                    }
                #endregion
            }
        }

        /// <summary>
        /// 拠点ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uButton_SectionGuide_Click(object sender, EventArgs e)
        {
            SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
            SecInfoSet secInfoSet;

            int status = secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out secInfoSet);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.tEdit_SectionCode.Text = secInfoSet.SectionCode.Trim();
                this.uLabel_SectionNm.Text = secInfoSet.SectionGuideNm;
                this.ReSettingPrmInfo();
            }
        }

        /// <summary>
        /// 拠点情報取得処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns></returns>
        public SecInfoSet GetSecInfo(string sectionCode)
        {
            SecInfoAcs secInfoAcs = new SecInfoAcs();
            SecInfoSet retSecInfoSet = null;

            // 拠点制御アクセスクラスインスタンス化処理
            this.CreateSecInfoAcs(secInfoAcs);

            if (secInfoAcs.SecInfoSetList != null)
            {
                foreach (SecInfoSet secInfoSet in secInfoAcs.SecInfoSetList)
                {
                    if (secInfoSet.SectionCode.Trim() == sectionCode.Trim())
                    {
                        retSecInfoSet = secInfoSet;
                        break;
                    }
                }

            }
            return retSecInfoSet;
        }

        /// <summary>
        /// 拠点制御アクセスクラスインスタンス化処理
        /// </summary>
        /// <param name="secInfoSetAcs"></param>
        public void CreateSecInfoAcs(SecInfoAcs secInfoAcs)
        {
            if (secInfoAcs == null)
            {
                secInfoAcs = new SecInfoAcs();
            }

            // ログイン担当拠点情報の取得
            if (secInfoAcs.SecInfoSet == null)
            {
                throw new ApplicationException(MESSAGE_NONOWNSECTION);
            }
        }

        /// <summary>
        /// tEdit_SectionCode_Leaveイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tEdit_SectionCode_Leave(object sender, EventArgs e)
        {
            if (this._leaveEventCancel)
            {
                this._leaveEventCancel = false;
                return;
            }

            string code = this.tEdit_SectionCode.Text.Trim();
            code = this.uiSetControl1.GetZeroPaddedText(tEdit_SectionCode.Name, code);

            if (string.IsNullOrEmpty(code))
            {
                this.tEdit_SectionCode.Text = SECCODE_ALL;
                this.uLabel_SectionNm.Text = SECNAME_ALL;
                this.ReSettingPrmInfo();
            }
            else
            {
                SecInfoSet secInfoSet = this.GetSecInfo(code);

                if (secInfoSet == null)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "拠点が存在しません。",
                        -1,
                        MessageBoxButtons.OK);
                    this.tEdit_SectionCode.Text = SECCODE_ALL;
                    this.uLabel_SectionNm.Text = SECNAME_ALL;
                    this.tEdit_SectionCode.Focus();
                }
                else
                {
                    this.tEdit_SectionCode.Text = secInfoSet.SectionCode.Trim();
                    this.uLabel_SectionNm.Text = secInfoSet.SectionGuideNm;
                    this.ReSettingPrmInfo();
                }
            }
        }

        /// <summary>
        /// 優良情報再設定処理
        /// </summary>
        private void ReSettingPrmInfo()
        {
            // 優良設定再設定
            if (this._PrimeSettingController.SectionCode != this.tEdit_SectionCode.Text.Trim())
            {
                SFCMN00299CA processingDialog = new SFCMN00299CA();
                try
                {
                    processingDialog.Title = "優良設定取得";
                    processingDialog.Message = "現在、優良設定取得中です。";
                    processingDialog.DispCancelButton = false;
                    processingDialog.Show((Form)this.Parent);

                    this._PrimeSettingController.SectionCode = this.tEdit_SectionCode.Text.Trim();

                    _bCode = true;// 2010/01/13 Add

                    // 該当データ取得
                    int status = _PrimeSettingController.DataSearchOnlyPrmInfo();

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        this.Main_TabControl.Tabs.Clear();

                        foreach (string wkString in this.TAB_KEYS)
                        {
                            // フォーム制御テーブルを生成する
                            this.FormControlInfoCreate(wkString);
                            // MDI子画面生成
                            this.CreateMdiChildForm(wkString, _formControlInfo.AssemblyID, _formControlInfo.ClassID, _formControlInfo.Key, _formControlInfo.Name, _formControlInfo.Icon, _formControlInfo);
                        }
                        // 優良設定用備考の表示用処理
                        if (NoteChangerView != null)
                        {
                            foreach (IPrimeSettingNoteChangedEventHandler handler in NoteChangedEventHandlerList)
                            {
                                NoteChangerView.NoteChanged += handler.PrimeSettingNoteChanged;
                            }
                        }
                    }
                }
                finally
                {
                    processingDialog.Dispose();
                }
            }
            // 先頭Tabを選択
            this.Main_TabControl.SelectedTab = this.Main_TabControl.Tabs[0];
        }
        // 2009.04.06 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
    }
}