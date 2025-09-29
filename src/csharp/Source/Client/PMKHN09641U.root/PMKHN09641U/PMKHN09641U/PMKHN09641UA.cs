//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : キャンペーン対象商品設定マスタ一括削除
// プログラム概要   : キャンペーン対象商品設定マスタ一括削除
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李占川
// 作 成 日  2011/04/26  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日               修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.Windows.Forms;
using System.Collections.Generic;
using Broadleaf.Application.Controller;
using System.Collections;
using System.Net.NetworkInformation;

using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Infragistics.Win.UltraWinGrid;

namespace Broadleaf.Windows.Forms
{

    /// <summary>
    /// キャンペーン対象商品設定マスタ一括削除フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : キャンペーン対象商品設定マスタ一括削除を行います。</br>
    /// <br>Programmer : 李占川</br>
    /// <br>Date       : 2011/04/26</br>
    /// </remarks>
    public partial class PMKHN09641UA : Form
    {
        # region Private Constant
        // ツールバーツールキー設定
        private const string TOOLBAR_CLOSEBUTTON_KEY = "ButtonTool_Close";
        private const string TOOLBAR_UPDATEBUTTON_KEY = "ButtonTool_Update";
        private const string TOOLBAR_SEARCHBUTTON_KEY = "ButtonTool_Search";
        private const string TOOLBAR_CLEARBUTTON_KEY = "ButtonTool_Clear";
        private const string TOOLBAR_GUIDEBUTTON_KEY = "ButtonTool_Guide";
        private const string TOOLBAR_LOGINSECTIONLABLE_KEY = "LabelTool_LoginTitle";
        private const string TOOLBAR_LOGINNAMELABLE_KEY = "LabelTool_LoginName";

        private const string ctGUIDE_NAME_Section = "tEdit_SectionCodeAllowZero";
        private const string ctGUIDE_NAME_GoodsMakerCd = "tNedit_GoodsMakerCd";
        private const string ctGUIDE_NAME_HGoodsNo = "tEdit_HGoodsNo";
        private const string ctGUIDE_NAME_Grid = "ultraGrid_DeleteObject";

        private const int INIT_MODE = 0;
        private const int SEARCH_MODE = 1;

        // クラス名
        private string ct_PRINTNAME = "キャンペーン対象商品設定マスタ一括削除";
        # endregion

        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        # region Private Members
        private ImageList _imageList16 = null;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;					// 終了ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _searchButton;					// 検索ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _updateButton;					// 更新ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _guideButton;					// ガイドボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _clearButton;					// クリアボタン					
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginTitleLabel;				// ログイン担当者名称
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginNameLabel;

        private string _enterpriseCode;
        private CampaignGoodsStAcs _campaignGoodsStAcs = null;
        private SecInfoAcs _secInfoAcs;                     // 拠点情報アクセスクラス
        private SecInfoSetAcs _secInfoSetAcs = null;        // 拠点アクセスクラス
        private MakerAcs _makerAcs = null;					// メーカーアクセスクラス
        private Dictionary<string, SecInfoSet> _secInfoSetDic;
        private Dictionary<int, MakerUMnt> _makerUMntDic;
        private Control _prevControl = null;									// 現在のコントロール
        private string _guideKey;
        private int _retKeyFlag = -1;                       //判定フラグ

        private CampaignGoodsDataSet.CampaignGoodsDataTable _campaignGoodsDataTable;
        # endregion

        // ===================================================================================== //
        // Constructor
        // ===================================================================================== //
        #region　Constructor
        /// <summary>
        /// キャンペーン対象商品設定マスタ一括削除フォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note		: キャンペーン対象商品設定マスタ一括削除フォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer	: 李占川</br>
        /// <br>Date		: 2011/04/26</br>
        /// </remarks>
        public PMKHN09641UA()
        {
            InitializeComponent();

            // 変数初期化
            this._imageList16 = IconResourceManagement.ImageList16;

            this._loginTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolsManager_MainMenu.Tools[TOOLBAR_LOGINSECTIONLABLE_KEY];
            this._loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolsManager_MainMenu.Tools[TOOLBAR_LOGINNAMELABLE_KEY];
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools[TOOLBAR_CLOSEBUTTON_KEY];
            this._searchButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools[TOOLBAR_SEARCHBUTTON_KEY];
            this._updateButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools[TOOLBAR_UPDATEBUTTON_KEY];
            this._clearButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools[TOOLBAR_CLEARBUTTON_KEY];
            this._guideButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools[TOOLBAR_GUIDEBUTTON_KEY];

            //　企業コード取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._campaignGoodsStAcs = CampaignGoodsStAcs.GetInstance();
            this._secInfoSetAcs = new SecInfoSetAcs();
            this._makerAcs = new MakerAcs();
            this._secInfoAcs = new SecInfoAcs();

            this._campaignGoodsDataTable = this._campaignGoodsStAcs.CampaignGoodsDataTable;

            // マスタ読込
            ReadSecInfoSet();
            // メーカーマスタ読込処理
            LoadMakerUMnt();

            this._loginNameLabel.SharedProps.Caption = LoginInfoAcquisition.Employee.Name;
        }
        #endregion

        // ===================================================================================== //
        //  Private Methods
        // ===================================================================================== //
        #region　Private Methods
        /// <summary>
        /// 初期画面設定
        /// </summary>
        /// <remarks>
        /// <br>Note        : 画面初期化時に発生します。</br>      
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2011/04/26</br>
        /// </remarks> 
        private void InitialScreenSetting()
        {
            // ツールバー初期設定処理
            this.ToolBarInitilSetting();

            // ボタンアイコン設定
            this.SetGuidButtonIcon();

            // ツールボタンEnable設定処理
            this.SetControlEnabled(INIT_MODE);
        }

        /// <summary>
        /// ツールバー初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 画面初期化時、ツールバー初期設定処理を行います。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2011/04/26</br>
        /// </remarks> 
        private void ToolBarInitilSetting()
        {
            this._imageList16 = IconResourceManagement.ImageList16;
            this.tToolsManager_MainMenu.ImageListSmall = this._imageList16;

            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this._searchButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SEARCH;
            this._updateButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
            this._guideButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.GUIDE;
            this._clearButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;
            this._loginTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;
        }

        /// <summary>
        /// ガイドボタンのアイコン設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : ガイドボタンのアイコンを設定します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2011/04/26</br>
        /// </remarks>
        private void SetGuidButtonIcon()
        {
            this.SectionGuide_Button.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];
            this.MakerGuide_Button.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];
        }

        /// <summary>
        /// コントロールEnabled制御処理
        /// </summary>
        /// <param name="editMode">編集モード</param>
        /// <remarks>
        /// <br>Note       : コントロールのEnabled制御を行います。</br>
        /// <br>Programer  : 李占川</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void SetControlEnabled(int editMode)
        {
            if (editMode == INIT_MODE)
            {
                this._updateButton.SharedProps.Enabled = false;
            }
            else
            {
                this._updateButton.SharedProps.Enabled = true;
            }

            this.SettingGuideButtonToolEnabled(this.ActiveControl);
        }

        /// <summary>
        /// 画面表示
        /// </summary>
        /// <param name="campaignGoodsData">画面データ</param>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void SetDisplay(CampaignGoodsData campaignGoodsData)
        {
            if (campaignGoodsData == null) return;

            // start
            this.tEdit_SectionCodeAllowZero.BeginUpdate();
            this.tNedit_GoodsMakerCd.BeginUpdate();
            this.tEdit_HGoodsNo.BeginUpdate();


            // 画面情報を表示する
            this.tEdit_SectionCodeAllowZero.Text = campaignGoodsData.SectionCode;
            this.tEdit_SectionName.Text = campaignGoodsData.SectionName;
            this.tNedit_GoodsMakerCd.SetInt(campaignGoodsData.GoodsMakerCd);
            if (campaignGoodsData.GoodsMakerNm.Length > 10)
            {
                this.tEdit_MakerNm.Text = campaignGoodsData.GoodsMakerNm.Substring(0, 10);
            }
            else
            {
                this.tEdit_MakerNm.Text = campaignGoodsData.GoodsMakerNm;
            }
            this.tEdit_HGoodsNo.Text = campaignGoodsData.HeaderGoodsNo;

            this.GoodsStCount_uLabel.Text = campaignGoodsData.GoodsStCount.ToString("N0") + " " + "件";
            this.NameStCount_uLabel.Text = campaignGoodsData.NameStCount.ToString("N0") + " " + "件";
            this.CustomStCount_uLabel.Text = campaignGoodsData.CustomStCount.ToString("N0") + " " + "件";
            this.TargetStCount_uLabel.Text = campaignGoodsData.TargetStCount.ToString("N0") + " " + "件";

            // 画面ENABLE
            this.tEdit_SectionCodeAllowZero.Enabled = true;
            this.SectionGuide_Button.Enabled = true;

            // end
            this.tEdit_SectionCodeAllowZero.EndUpdate();
            this.tNedit_GoodsMakerCd.EndUpdate();
            this.tEdit_HGoodsNo.EndUpdate();
        }

        /// <summary>
        /// 画面初期化
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面初期化を行い</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void Clear()
        {
            // 画面初期化データ
            this._campaignGoodsStAcs.CreateCampaignGoodsInitialData();
            // 画面初期化表示
            this.SetDisplay(this._campaignGoodsStAcs.CampaignGoodsData);
            // 削除対象データ画面初期化表示
            this._campaignGoodsDataTable.Clear();
            // コントロールEnabled制御処理
            this.SetControlEnabled(INIT_MODE);

            this.timer_SetFocus.Enabled = true;
        }

        /// <summary>
        /// 「ガイド」処理
        /// </summary>
        private void ExecuteGuide()
        {
            switch (this._guideKey)
            {
                // 拠点
                case ctGUIDE_NAME_Section:
                    {
                        this.SectionGuide_Button_Click(this.SectionGuide_Button, new EventArgs());
                        break;
                    }
                // メーカー
                case ctGUIDE_NAME_GoodsMakerCd:
                    {
                        this.MakerGuide_Button_Click(this.MakerGuide_Button, new EventArgs());
                        break;
                    }

            }
        }

        /// <summary>
        /// 画面検索
        /// </summary>
        /// <remarks>
        /// <br>Note       : 検索処理を行い</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void Search()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            // オフライン状態チェック
            if (!CheckOnline())
            {
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_STOP,
                    this.Text,
                    this.Text + "画面検索処理に失敗しました。",
                    (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                return;
            }

            if (this._prevControl != null)
            {
                ChangeFocusEventArgs e = new ChangeFocusEventArgs(false, false, false, Keys.Return, this._prevControl, this._prevControl);
                this.tRetKeyControl1_ChangeFocus(this, e);
                if (this._retKeyFlag != 1)
                {
                    return; 
                }
            }
            // チェック
            bool isSave = this.BeforeSearchCheck();

            if (!isSave)
            {
                return;
            }

            // 検索
            string errMessge;
            status = this._campaignGoodsStAcs.SearchData(out errMessge);

            switch (status)
            {
                case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                    this.SetControlEnabled(SEARCH_MODE);
                    break;

                case (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN:
                    // 0件エラー
                    MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "該当するデータがありません。", 0);
                    this.SetControlEnabled(INIT_MODE);
                    break;

                default:
                    MsgDispProc(emErrorLevel.ERR_LEVEL_STOP, "検索に失敗しました。", -1);
                    this.SetControlEnabled(INIT_MODE);
                    break;
            }

            this.GoodsStCount_uLabel.Text = "0 件";
            this.NameStCount_uLabel.Text = "0 件";
            this.CustomStCount_uLabel.Text = "0 件";
            this.TargetStCount_uLabel.Text = "0 件";
        }

        /// <summary>
        /// 一括削除処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 一括削除処理を行う</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void DeleteAll()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            if (this._prevControl != null)
            {
                ChangeFocusEventArgs e = new ChangeFocusEventArgs(false, false, false, Keys.Return, this._prevControl, this._prevControl);
                this.tRetKeyControl1_ChangeFocus(this, e);
            }

            // 確認メッセージを表示する。
            DialogResult result = TMsgDisp.Show(
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,             // エラーレベル
                        "PMKHN09641UA",						            // アセンブリＩＤまたはクラスＩＤ
                        ct_PRINTNAME,				                    // プログラム名称
                        "", 								            // 処理名称
                        "",									            // オペレーション
                        "一括削除処理を開始してもよろしいですか？",		// 表示するメッセージ
                        -1, 							                // ステータス値
                        null, 								            // エラーが発生したオブジェクト
                        MessageBoxButtons.YesNo, 				        // 表示するボタン
                        MessageBoxDefaultButton.Button1);	            // 初期表示ボタン
            // 入力画面へ戻る。
            if (result == DialogResult.No)
            {
                return;
            }

            // 抽出中画面部品のインスタンスを作成
            SFCMN00299CA msgForm = new SFCMN00299CA();
            msgForm.Title = "更新中";
            msgForm.Message = "更新中です。";
            try
            {
                msgForm.Show();

                string msg = string.Empty;
                // 更新処理
                status = this._campaignGoodsStAcs.DeleteData(ref msg);

                switch (status)
                {
                    case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                        this.SetDisplay(this._campaignGoodsStAcs.CampaignGoodsData);
                        // フォーカスは拠点に戻る
                        this.tEdit_SectionCodeAllowZero.Focus();
                        this.SetControlEnabled(INIT_MODE);

                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                        TMsgDisp.Show(this,                         // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,     // エラーレベル
                        "PMKHN09641U",							// アセンブリID
                        "キャンペーン対象商品設定マスタが\n既に他端末により更新されている為、処理を中断しました。\n再試行するか、しばらく待ってから再度処理を実行して下さい。",	    // 表示するメッセージ
                        status,									// ステータス値
                        MessageBoxButtons.OK);					// 表示するボタン

                        // フォーカスは拠点に戻る
                        this.tEdit_SectionCodeAllowZero.Focus();
                        this.SetControlEnabled(INIT_MODE);

                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                       TMsgDisp.Show(this,                         // 親ウィンドウフォーム
                       emErrorLevel.ERR_LEVEL_EXCLAMATION,     // エラーレベル
                       "PMKHN09641U",							// アセンブリID
                       "キャンペーン対象商品設定マスタが\n既に他端末により削除されている為、処理を中断しました。\n再試行するか、しばらく待ってから再度処理を実行して下さい。",	    // 表示するメッセージ
                       status,									// ステータス値
                       MessageBoxButtons.OK);					// 表示するボタン
                        // フォーカスは拠点に戻る
                        this.tEdit_SectionCodeAllowZero.Focus();
                        this.SetControlEnabled(INIT_MODE);

                        break;

                    default:
                        MsgDispProc(emErrorLevel.ERR_LEVEL_STOP, "更新に失敗しました。", 0);
                        this.SetControlEnabled(INIT_MODE);
                        break;
                }
            }
            finally
            {
                msgForm.Close();
            }
        }

        /// <summary>
        /// 画面検索前チェック
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private bool BeforeSearchCheck()
        {
            CampaignGoodsData campaignGoodsData = this._campaignGoodsStAcs.CampaignGoodsData;

            // 拠点入力チェック
            if (string.IsNullOrEmpty(campaignGoodsData.SectionCode))
            {
                // 該当なし
                TMsgDisp.Show(this, 												// 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_EXCLAMATION, 				// エラーレベル
                                this.Name,											// アセンブリID
                                "拠点が設定されていません。",                       // 表示するメッセージ
                                -1,													// ステータス値
                                MessageBoxButtons.OK);

                // フォーカス設定
                this.tEdit_SectionCodeAllowZero.Focus();
                return false;
            }

            // メーカー入力チェック
            if (campaignGoodsData.GoodsMakerCd == 0)
            {
                // 該当なし
                TMsgDisp.Show(this, 												// 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_EXCLAMATION, 				// エラーレベル
                                this.Name,											// アセンブリID
                                "メーカーコードを入力して下さい。",                 // 表示するメッセージ
                                -1,													// ステータス値
                                MessageBoxButtons.OK);

                // フォーカス設定
                this.tNedit_GoodsMakerCd.Focus();
                this.SettingGuideButtonToolEnabled(this.ActiveControl);
                return false;
            }

            return true;
        }

        /// <summary>
        /// 拠点略称取得処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>拠点名</returns>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private string GetSectionName(string sectionCode)
        {
            sectionCode = sectionCode.Trim().PadLeft(2, '0');

            if (sectionCode == "00")
            {
                return "全社";
            }

            if (this._secInfoSetDic.ContainsKey(sectionCode))
            {
                return this._secInfoSetDic[sectionCode].SectionGuideNm.Trim();
            }

            return "";
        }

        /// <summary>
        /// ﾒｰｶｰ名取得処理
        /// </summary>
        /// <param name="goodsMakerCd">ﾒｰｶｰコード</param>
        /// <returns>ﾒｰｶｰ名</returns>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private string GetGoodsMakerNm(int goodsMakerCd)
        {
            if (this._makerUMntDic.ContainsKey(goodsMakerCd))
            {
                return this._makerUMntDic[goodsMakerCd].MakerName.Trim();
            }

            return "";
        }

        /// <summary>
        /// 拠点情報マスタ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void ReadSecInfoSet()
        {
            this._secInfoSetDic = new Dictionary<string, SecInfoSet>();

            foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
            {
                if (secInfoSet.LogicalDeleteCode == 0)
                {
                    this._secInfoSetDic.Add(secInfoSet.SectionCode.Trim(), secInfoSet);
                }
            }
        }

        /// <summary>
        /// メーカーマスタ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void LoadMakerUMnt()
        {
            this._makerUMntDic = new Dictionary<int, MakerUMnt>();

            try
            {
                ArrayList retList;

                int status = this._makerAcs.SearchAll(out retList, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (MakerUMnt makerUMnt in retList)
                    {
                        if (makerUMnt.LogicalDeleteCode == 0)
                        {
                            this._makerUMntDic.Add(makerUMnt.GoodsMakerCd, makerUMnt);
                        }
                    }
                }
            }
            catch
            {
                this._makerUMntDic = new Dictionary<int, MakerUMnt>();
            }
        }

        /// <summary>
        /// ボタンツール有効無効設定処理
        /// </summary>
        /// <param name="nextControl">次のコントロール</param>
        /// <remarks>
        /// <br>Note		: ボタンツール有効無効設定処理</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2011/04/26</br>
        /// </remarks>
        private void SettingGuideButtonToolEnabled(Control nextControl)
        {
            if (nextControl == null) return;

            Control targetControl = nextControl;
            if (nextControl.Parent != null)
            {
                if ((nextControl.Parent is Broadleaf.Library.Windows.Forms.TNedit) ||
                    (nextControl.Parent is Broadleaf.Library.Windows.Forms.TEdit))
                {
                    targetControl = nextControl.Parent;
                }
            }

            if (targetControl.Name == ctGUIDE_NAME_Section
                || targetControl.Name == ctGUIDE_NAME_GoodsMakerCd)
            {
                this._guideButton.SharedProps.Enabled = true;
                this._guideKey = targetControl.Name;
            }
            else
            {
                this._guideButton.SharedProps.Enabled = false;
            }
        }

        /// <summary>
        /// グリッド列初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 画面初期化の時、グリッド列初期設定を行います。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2011/04/26</br>
        /// </remarks>
        private void SetGridInitialLayout()
        {
            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.ultraGrid_DeleteObject.DisplayLayout.Bands[0];
            if (editBand == null) return;

            CampaignGoodsDataSet.CampaignGoodsDataTable table = this._campaignGoodsDataTable;
            ColumnsCollection columns = editBand.Columns;

            editBand.ColHeadersVisible = true;

            // 名称
            columns[table.CampaignCodeColumn.ColumnName].Header.Caption = "ｺｰﾄﾞ";
            columns[table.CampaignNameColumn.ColumnName].Header.Caption = "名称";
            columns[table.SectionCodeColumn.ColumnName].Header.Caption = "拠点";
            columns[table.SectionNameColumn.ColumnName].Header.Caption = "拠点名";
            columns[table.CampaignSettingKindNmColumn.ColumnName].Header.Caption = "設定種別";
            columns[table.GoodsMakerCdColumn.ColumnName].Header.Caption = "ﾒｰｶｰ";
            columns[table.GoodsMakerNmColumn.ColumnName].Header.Caption = "ﾒｰｶｰ名";
            columns[table.GoodsNoColumn.ColumnName].Header.Caption = "品番";
            columns[table.GoodsNameColumn.ColumnName].Header.Caption = "品名";
            columns[table.CustomerCodeColumn.ColumnName].Header.Caption = "得意先";
            columns[table.CustomerNameColumn.ColumnName].Header.Caption = "得意先名";
            columns[table.DiscountRateColumn.ColumnName].Header.Caption = "値引率";
            columns[table.PriceFlColumn.ColumnName].Header.Caption = "売価額";
            columns[table.RateValColumn.ColumnName].Header.Caption = "売価率";
            columns[table.PriceStartDateColumn.ColumnName].Header.Caption = "価格開始日";
            columns[table.PriceEndDateColumn.ColumnName].Header.Caption = "価格終了日";

            // 表示幅設定
            columns[table.CampaignCodeColumn.ColumnName].Width = 90;
            columns[table.CampaignNameColumn.ColumnName].Width = 120;
            columns[table.SectionCodeColumn.ColumnName].Width = 90;
            columns[table.SectionNameColumn.ColumnName].Width = 170;
            columns[table.CampaignSettingKindNmColumn.ColumnName].Width = 120;
            columns[table.GoodsMakerCdColumn.ColumnName].Width = 90;
            columns[table.GoodsMakerNmColumn.ColumnName].Width = 170;
            columns[table.GoodsNoColumn.ColumnName].Width = 170;
            columns[table.GoodsNameColumn.ColumnName].Width = 300;
            columns[table.CustomerCodeColumn.ColumnName].Width = 90;
            columns[table.CustomerNameColumn.ColumnName].Width = 170;
            columns[table.DiscountRateColumn.ColumnName].Width = 90;
            columns[table.PriceFlColumn.ColumnName].Width = 150;
            columns[table.RateValColumn.ColumnName].Width = 90;
            columns[table.PriceStartDateColumn.ColumnName].Width = 100;
            columns[table.PriceEndDateColumn.ColumnName].Width = 100;

            // 入力許可設定
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in columns)
            {
                // 全ての列をいったん非入力にする。
                col.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            }

            // 詰め
            columns[table.CampaignCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            columns[table.CampaignNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            columns[table.SectionCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            columns[table.SectionNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            columns[table.CampaignSettingKindNmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            columns[table.GoodsMakerCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            columns[table.GoodsMakerNmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            columns[table.GoodsNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            columns[table.GoodsNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            columns[table.CustomerCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            columns[table.CustomerNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            columns[table.DiscountRateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            columns[table.PriceFlColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            columns[table.RateValColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            columns[table.PriceStartDateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            columns[table.PriceEndDateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;

            string FORMAT1 = "##0.00;-##0.00;''";
            string FORMAT2 = "#,###,###,##0.00;-#,###,###,##0.00;''";
            string FORMAT3 = "0000;''";

            // Format
            columns[table.GoodsMakerCdColumn.ColumnName].Format = FORMAT3;
            columns[table.DiscountRateColumn.ColumnName].Format = FORMAT1;
            columns[table.RateValColumn.ColumnName].Format = FORMAT1;
            columns[table.PriceFlColumn.ColumnName].Format = FORMAT2;
        }

        /// <summary>
        /// グリッド列表示非表示設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 画面初期化の時、グリッド列初期設定を行います。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2011/04/26</br>
        /// </remarks>
        private void SetGridColVisible()
        {
            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.ultraGrid_DeleteObject.DisplayLayout.Bands[0];
            if (editBand == null) return;

            CampaignGoodsDataSet.CampaignGoodsDataTable table = this._campaignGoodsDataTable;
            ColumnsCollection columns = editBand.Columns;

            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in columns)
            {
                // 全ての列をいったん非表示にする。
                col.Hidden = true;
            }

            // ｺｰﾄﾞ
            columns[table.CampaignCodeColumn.ColumnName].Hidden = false;
            // 名称
            columns[table.CampaignNameColumn.ColumnName].Hidden = false;
            // 拠点
            columns[table.SectionCodeColumn.ColumnName].Hidden = false;
            // 拠点名
            columns[table.SectionNameColumn.ColumnName].Hidden = false;
            // 設定種別
            columns[table.CampaignSettingKindNmColumn.ColumnName].Hidden = false;
            // ﾒｰｶｰ
            columns[table.GoodsMakerCdColumn.ColumnName].Hidden = false;
            // ﾒｰｶｰ名
            columns[table.GoodsMakerNmColumn.ColumnName].Hidden = false;
            // 品番
            columns[table.GoodsNoColumn.ColumnName].Hidden = false;
            // 品名
            columns[table.GoodsNameColumn.ColumnName].Hidden = false;
            // 得意先
            columns[table.CustomerCodeColumn.ColumnName].Hidden = false;
            // 得意先名
            columns[table.CustomerNameColumn.ColumnName].Hidden = false;
            // 売価率
            columns[table.DiscountRateColumn.ColumnName].Hidden = false;
            // 売価率
            columns[table.PriceFlColumn.ColumnName].Hidden = false;
            // 売価額
            columns[table.RateValColumn.ColumnName].Hidden = false;
            // 価格開始日
            columns[table.PriceStartDateColumn.ColumnName].Hidden = false;
            // 価格終了日
            columns[table.PriceEndDateColumn.ColumnName].Hidden = false;
        }

        /// <summary>
        /// エラーメッセージ表示処理
        /// </summary>
        /// <param name="iLevel">エラーレベル</param>
        /// <param name="message">表示メッセージ</param>
        /// <param name="status">ステータス</param>
        /// <remarks>
        /// <br>Note        : エラーメッセージ表示処理</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2011/04/26</br>
        /// </remarks>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
        {
            TMsgDisp.Show(
                iLevel, 							// エラーレベル
                "PMKHN09641UA",						// アセンブリＩＤまたはクラスＩＤ
                ct_PRINTNAME,				        // プログラム名称
                "", 								// 処理名称
                "",									// オペレーション
                message,							// 表示するメッセージ
                status, 							// ステータス値
                null, 								// エラーが発生したオブジェクト
                MessageBoxButtons.OK, 				// 表示するボタン
                MessageBoxDefaultButton.Button1);	// 初期表示ボタン
        }
        #endregion

        // ===================================================================================== //
        // 各コントロールイベント処理
        // ===================================================================================== //
        # region Control Event Methods
        /// <summary>
        ///	Form.Load イベント(PMKHN09641U)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: ユーザーがフォームを読み込むときに発生します。</br>
        /// <br>Programmer	: 李占川</br>
        /// <br>Date		: 2011/04/26</br>
        /// </remarks>
        private void PMKHN09641U_Load(object sender, EventArgs e)
        {
            // 画面初期化
            InitialScreenSetting();

            this.ultraGrid_DeleteObject.DataSource = this._campaignGoodsDataTable;

            // 画面初期化
            this.Clear();
        }

        /// <summary>
        /// ツールバークリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : ツールバークリック時に発生します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void tToolsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                // 終了
                case TOOLBAR_CLOSEBUTTON_KEY:
                    {
                        // 終了処理
                        Close();
                        break;
                    }
                // 検索
                case TOOLBAR_SEARCHBUTTON_KEY:
                    {
                        this.Search();
                        break;
                    }
                // 一括削除処理
                case TOOLBAR_UPDATEBUTTON_KEY:
                    {
                        this.DeleteAll();
                        break;
                    }
                // クリア
                case TOOLBAR_CLEARBUTTON_KEY:
                    {
                        // クリア処理
                        this.Clear();
                        break;
                    }
                // ガイド
                case TOOLBAR_GUIDEBUTTON_KEY:
                    {
                        this.ExecuteGuide();
                        break;
                    }
            }
        }

        /// <summary>
        /// ChangeFocus イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            this._retKeyFlag = 0;

            if (e.PrevCtrl == null || e.NextCtrl.Name == "ultraExplorerBar1")
            {
                return;
            }

            this._prevControl = e.NextCtrl;

            CampaignGoodsData campaignGoodsDataCurrent = this._campaignGoodsStAcs.CampaignGoodsData;
            if (campaignGoodsDataCurrent == null) return;

            CampaignGoodsData campaignGoodsData = campaignGoodsDataCurrent.Clone();

            switch (e.PrevCtrl.Name)
            {
　　　　　　　　// Grid
                case "ultraGrid_DeleteObject":
                    {
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Return || e.Key == Keys.Tab)
                            {
                                if (this.ultraGrid_DeleteObject.ActiveCell != null)
                                {
                                    this.ultraGrid_DeleteObject.ActiveCell.Activate();
                                    e.NextCtrl = null;
                                }
                                if (this.ultraGrid_DeleteObject.ActiveRow != null)
                                {
                                    e.NextCtrl = null;
                                }
                               
                            }
                        }
                        break;
                    
                    }
                // 拠点コード
                case ctGUIDE_NAME_Section:
                    {
                        string code = this.tEdit_SectionCodeAllowZero.Text.Trim().PadLeft(2, '0');

                        if (string.IsNullOrEmpty(code) || "00".Equals(code))
                        {
                            code = "00";
                            campaignGoodsData.SectionCode = code;
                            campaignGoodsData.SectionName = GetSectionName(code);
                        }

                        // 入力変更なし
                        if (code.Equals(campaignGoodsData.SectionCode))
                        {
                            if (e.ShiftKey == false)
                            {
                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                {
                                    // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす
                                    if (string.IsNullOrEmpty(code))
                                    {
                                        e.NextCtrl = this.SectionGuide_Button;
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.tNedit_GoodsMakerCd;
                                    }
                                }
                                else
                                {
                                    if (e.Key == Keys.Up)
                                    {
                                        e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                                    }
                                
                                }

                            }
                            else
                            {
                                if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Up)
                                {
                                    e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                                }
                            
                            }
                            
                           
                            break;
                        }
                        else
                        {
                            // 入力無し
                            if (string.IsNullOrEmpty(this.tEdit_SectionCodeAllowZero.Text.Trim()))
                            {
                                // 設定値保存、名称のクリア
                                campaignGoodsData.SectionCode = string.Empty;
                                campaignGoodsData.SectionName = string.Empty;

                                // フォーカス設定
                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                {
                                    e.NextCtrl = this.SectionGuide_Button;
                                }

                                break;
                            }

                            if (!string.IsNullOrEmpty(GetSectionName(code)))
                            {
                                // 結果を画面に設定
                                campaignGoodsData.SectionCode = code;
                                campaignGoodsData.SectionName = GetSectionName(code);
                            }
                            else
                            {
                                // 該当なし
                                this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "拠点が存在しません。", -1);
                                // 画面表示
                                this.SetDisplay(campaignGoodsData);
                                e.NextCtrl = e.PrevCtrl;
                                return;
                            }
                            if (e.ShiftKey == false)
                            {
                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                {
                                    e.NextCtrl = this.tNedit_GoodsMakerCd;
                                }
                            }
                            else
                            {
                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                {
                                    // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす
                                    e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                                }
                            }
                            
                        }

                        break;
                    }
                // 拠点ボタン
                case "SectionGuide_Button":
                    {
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Return || e.Key == Keys.Tab)
                            {
                                // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす
                                e.NextCtrl = this.tNedit_GoodsMakerCd;
                            }
                            else if (e.Key == Keys.Up)
                            {
                                e.NextCtrl = this.SectionGuide_Button;
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Return || e.Key == Keys.Tab)
                            {
                                e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                            }
                        }
                        break;
                    }

                // メーカーボタン
                case "MakerGuide_Button":
                    {
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Return || e.Key == Keys.Tab)
                            {
                                // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす
                                e.NextCtrl = this.tEdit_HGoodsNo;
                            }
                            else if (e.Key == Keys.Down)
                            {
                                if (this.ultraGrid_DeleteObject.Rows.Count > 0)
                                {
                                    this.ultraGrid_DeleteObject.Focus();
                                    this.ultraGrid_DeleteObject.ActiveRow = this.ultraGrid_DeleteObject.Rows[0];
                                    this.ultraGrid_DeleteObject.ActiveRow.Selected = true;
                                    e.NextCtrl = this.ultraGrid_DeleteObject;
                                }
                                else
                                {
                                    e.NextCtrl = this.MakerGuide_Button;
                                }
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Return || e.Key == Keys.Tab)
                            {
                                e.NextCtrl = this.tNedit_GoodsMakerCd;
                            }
                        }
                        break;
                    }
                // メーカー
                case ctGUIDE_NAME_GoodsMakerCd:
                    {
                        int code = this.tNedit_GoodsMakerCd.GetInt();
                    
                        // 入力変更なし
                        if (code == campaignGoodsData.GoodsMakerCd)
                        {
                            
                            if (e.ShiftKey == false)
                            {
                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                {
                                    // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす
                                    if (code == 0)
                                    {
                                        e.NextCtrl = this.MakerGuide_Button;
                                    }
                                    else
                                    {
                                        e.NextCtrl = tEdit_HGoodsNo;
                                    }
                                }
                                else
                                {
                                    if (e.Key == Keys.Right && code == 0)
                                    {
                                        e.NextCtrl = this.MakerGuide_Button;
                                    }
                                    else if (e.Key == Keys.Up)
                                    {
                                        e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                                    }
                                }
                            }
                            else
                            {
                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                {
                                    e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                                }
                            }

                            break;
                        }
                        else
                        {
                            // 入力無し
                            if (code == 0)
                            {

                                // 設定値保存、名称のクリア
                                campaignGoodsData.GoodsMakerCd = 0;
                                campaignGoodsData.GoodsMakerNm = string.Empty;
                                if (e.ShiftKey == false)
                                {
                                    // フォーカス設定
                                    if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right)
                                    {
                                        e.NextCtrl = this.MakerGuide_Button;
                                    }
                                }
                                else
                                {
                                    // フォーカス設定
                                    if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                    {
                                        e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                                    }
                                }


                                break;
                            }

                            if (!string.IsNullOrEmpty(GetGoodsMakerNm(code)))
                            {
                                // 結果を画面に設定
                                campaignGoodsData.GoodsMakerCd = code;
                                campaignGoodsData.GoodsMakerNm = GetGoodsMakerNm(code);
                            }
                            else
                            {
                                // 該当なし
                                this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "メーカーが存在しません。", -1);
                                // 画面表示
                                this.SetDisplay(campaignGoodsData);
                                e.NextCtrl = e.PrevCtrl;
                                return;
                            }
                            if (e.ShiftKey == false)
                            {
                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                {
                                    // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす
                                    e.NextCtrl = this.tEdit_HGoodsNo;
                                }
                            }
                            else
                            {
                                // フォーカス設定
                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                {
                                    e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                                }
                            }
                        }
                        break;
                    }
                // 頭品番
                case ctGUIDE_NAME_HGoodsNo:
                    {
                        campaignGoodsData.HeaderGoodsNo = this.tEdit_HGoodsNo.DataText.Trim();

                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Return || e.Key == Keys.Tab)
                            {
                                // 入力あり＆Tab遷移＆次がガイドボタンの場合
                                if (this.ultraGrid_DeleteObject.Rows.Count > 0)
                                {
                                    this.ultraGrid_DeleteObject.Focus();
                                    this.ultraGrid_DeleteObject.ActiveRow = this.ultraGrid_DeleteObject.Rows[0];
                                    this.ultraGrid_DeleteObject.ActiveRow.Selected = true;
                                }
                                else
                                {
                                    e.NextCtrl = this.tEdit_HGoodsNo;
                                }

                            }
                            if (e.Key == Keys.Down)
                            {
                                if (this.ultraGrid_DeleteObject.Rows.Count > 0)
                                {
                                    this.ultraGrid_DeleteObject.Focus();
                                    this.ultraGrid_DeleteObject.ActiveRow = this.ultraGrid_DeleteObject.Rows[0];
                                    this.ultraGrid_DeleteObject.ActiveRow.Selected = true;
                                }
                                else
                                {
                                    e.NextCtrl = this.tEdit_HGoodsNo;
                                }
                            }
                            if (e.Key == Keys.Right)
                            {
                                e.NextCtrl = this.tEdit_HGoodsNo;
                            }
                        }
                        else
                        {
                            if (this.tNedit_GoodsMakerCd.Text == "")
                            {
                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                {
                                    e.NextCtrl = this.MakerGuide_Button;
                                }
                                
                            }
                            else
                            {
                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                {
                                    e.NextCtrl = this.tNedit_GoodsMakerCd;
                                }
                            }
                            
                        }
                        break;
                    }
            }

            this._prevControl = e.NextCtrl;

            // メモリ上の内容と比較する
            ArrayList arRetList = campaignGoodsData.Compare(campaignGoodsDataCurrent);

            if (arRetList.Count > 0)
            {
                this._campaignGoodsStAcs.CacheCampaignGoodsData(campaignGoodsData);

                // 画面表示
                this.SetDisplay(campaignGoodsData);
            }


            // ガイドボタンツール有効無効設定処理
            if ((e.NextCtrl != null) && (e.NextCtrl.TabStop))
            {
                this.SettingGuideButtonToolEnabled(e.NextCtrl);
            }

            this._retKeyFlag = 1;
        }

        /// <summary>
        /// Control.Click イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void SectionGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // キャッシュ処理
                CampaignGoodsData campaignGoodsData = this._campaignGoodsStAcs.CampaignGoodsData;

                int status;
                SecInfoSet secInfoSet = new SecInfoSet();

                // 拠点ガイド表示
                status = this._secInfoSetAcs.ExecuteGuid(this._enterpriseCode, true, out secInfoSet);
                if (status == 0)
                {
                    if (secInfoSet.SectionCode.Trim() != campaignGoodsData.SectionCode)
                    {
                        // 拠点コード
                        campaignGoodsData.SectionCode = secInfoSet.SectionCode.Trim();

                        // 拠点名称
                        campaignGoodsData.SectionName = secInfoSet.SectionGuideNm.Trim();

                        // 画面再表示
                        this.SetDisplay(campaignGoodsData);

                        // キャッシュ処理
                        this._campaignGoodsStAcs.CacheCampaignGoodsData(campaignGoodsData);
                    }

                    // フォーカス設定
                    this.tNedit_GoodsMakerCd.Focus();
                    this.SettingGuideButtonToolEnabled(this.ActiveControl);
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Button_Click イベント(MakerGuide_Button)
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note		: メーカーガイドボタンがクリックされた時に発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2011/04/26</br>
        /// </remarks>
        private void MakerGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // キャッシュ処理
                CampaignGoodsData campaignGoodsData = this._campaignGoodsStAcs.CampaignGoodsData;

                int status;
                MakerUMnt makerUMnt = new MakerUMnt();

                // メーカーガイド表示
                status = this._makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt);
                if (status == 0)
                {
                    if (makerUMnt.GoodsMakerCd != campaignGoodsData.GoodsMakerCd)
                    {
                        campaignGoodsData.GoodsMakerCd = makerUMnt.GoodsMakerCd;
                        campaignGoodsData.GoodsMakerNm = makerUMnt.MakerName;

                        // メーカーコード
                        this.tNedit_GoodsMakerCd.SetInt(makerUMnt.GoodsMakerCd);
                        if (makerUMnt.MakerName.Length > 10)
                        {
                            this.tEdit_MakerNm.Text = makerUMnt.MakerName.Substring(0, 10);
                        }
                        else
                        {
                            this.tEdit_MakerNm.Text = makerUMnt.MakerName;
                        }
                        this.tEdit_HGoodsNo.Focus();
                        this.SettingGuideButtonToolEnabled(this.ActiveControl);
                    }
                }

            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// フォーカス設定
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">クラス</param>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void timer_SetFocus_Tick(object sender, EventArgs e)
        {
            // フォーカス設定
            this.tEdit_SectionCodeAllowZero.Focus();
            this._guideKey = this.tEdit_SectionCodeAllowZero.Name;
            this.SettingGuideButtonToolEnabled(this.ActiveControl);

            this.timer_SetFocus.Enabled = false;
        }

        /// <summary>
        /// グリッド初期レイアウト設定イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note		: 画面初期化時、グリッド初期レイアウト設定を行います。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2011/04/26</br>
        /// </remarks>
        private void ultraGrid_DeleteObject_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            // グリッド列初期設定処理
            this.SetGridInitialLayout();

            // グリッド列表示非表示設定処理
            this.SetGridColVisible();
        }

        /// <summary>
        /// KeyDown イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : グリッドがアクティブ状態でキーが押された時に発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2011/04/26</br>
        /// </remarks>
        private void ultraGrid_DeleteObject_KeyDown(object sender, KeyEventArgs e)
        {
            int rowIndex;
            int columnIndex;


            if (this.ultraGrid_DeleteObject.ActiveCell == null)
            {
                if (this.ultraGrid_DeleteObject.ActiveRow == null)
                {
                    rowIndex = 0;
                    columnIndex = 0;
                }
                else
                {
                    rowIndex = this.ultraGrid_DeleteObject.ActiveRow.Index;
                    columnIndex = 0;
                }
            }
            else
            {
                rowIndex = this.ultraGrid_DeleteObject.ActiveCell.Row.Index;
                columnIndex = this.ultraGrid_DeleteObject.ActiveCell.Column.Index;
            }

            switch (e.KeyCode)
            {
                case Keys.Up:
                    {
                        e.Handled = true;

                        if (rowIndex == 0)
                        {
                            if (this.ultraGrid_DeleteObject.ActiveRow != null)
                            {
                                this.ultraGrid_DeleteObject.ActiveRow.Selected = false;
                                this.ultraGrid_DeleteObject.ActiveRow = null;
                            }
                            this.tEdit_HGoodsNo.Focus();
                        }
                        else
                        {
                            if (this.ultraGrid_DeleteObject.ActiveCell == null)
                            {
                                this.ultraGrid_DeleteObject.Rows[rowIndex - 1].Activate();
                                this.ultraGrid_DeleteObject.Rows[rowIndex - 1].Selected = true;
                            }
                            else
                            {
                                this.ultraGrid_DeleteObject.Rows[rowIndex - 1].Cells[columnIndex].Activate();
                            }
                        }
                        break;
                    }
                case Keys.Down:
                    {
                        e.Handled = true;

                        if (rowIndex < this.ultraGrid_DeleteObject.Rows.Count - 1)
                        {
                            if (this.ultraGrid_DeleteObject.ActiveCell == null)
                            {
                                this.ultraGrid_DeleteObject.Rows[rowIndex + 1].Activate();
                                this.ultraGrid_DeleteObject.Rows[rowIndex + 1].Selected = true;
                            }
                            else
                            {
                                this.ultraGrid_DeleteObject.Rows[rowIndex + 1].Cells[columnIndex].Activate();
                            }
                        }
                        break;
                    }
                case Keys.Left:
                    {
                        e.Handled = true;

                        if (rowIndex != 0)
                        {
                            if (columnIndex != 0)
                            {
                                this.ultraGrid_DeleteObject.Rows[rowIndex].Cells[columnIndex - 1].Activate();
                            }
                        }
                        else
                        {
                            if (columnIndex != 0)
                            {
                                this.ultraGrid_DeleteObject.Rows[rowIndex].Cells[columnIndex - 1].Activate();
                            }
                        }

                        break;
                    }
                case Keys.Right:
                    {
                        e.Handled = true;
                        if (rowIndex != this.ultraGrid_DeleteObject.Rows.Count - 1)
                        {
                            if ((this.ultraGrid_DeleteObject.Rows.Count - 1) < 0)
                            {
                                return;
                            }

                            if (columnIndex != this.ultraGrid_DeleteObject.Rows[rowIndex].Cells["PriceEndDate"].Column.Index)
                            {
                                this.ultraGrid_DeleteObject.Rows[rowIndex].Cells[columnIndex + 1].Activate();
                            }
                        }
                        else
                        {
                            if (columnIndex != this.ultraGrid_DeleteObject.Rows[rowIndex].Cells["PriceEndDate"].Column.Index)
                            {
                                this.ultraGrid_DeleteObject.Rows[rowIndex].Cells[columnIndex + 1].Activate();
                            }
                        
                        }

                        break;
                    }
            }
        }

        /// <summary>
        /// AfterCellActivate イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : プロパティの値が変更された後に発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2011/04/26</br>
        /// </remarks>
        private void ultraGrid_DeleteObject_AfterCellActivate(object sender, EventArgs e)
        {
            this.ultraGrid_DeleteObject.ActiveCell.Row.Selected = true;
        }

        /// <summary>
        /// GroupExpanding イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note		: UltraExplorerBarGroup が展開される前に発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2011/04/26</br>
        /// </remarks>
        private void ultraExplorerBar1_GroupExpanding(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == "SearchGroup") ||
                (e.Group.Key == "DeleteObjectGroup") ||
                (e.Group.Key == "ResultSettingGroup"))
            {
                // グループの展開をキャンセル
                e.Cancel = true;
            }
        }

        /// <summary>
        /// GroupCollapsing イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note		: UltraExplorerBarGroup が縮小される前に発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2011/04/26</br>
        /// </remarks>
        private void ultraExplorerBar1_GroupCollapsing(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == "SearchGroup") ||
                (e.Group.Key == "DeleteObjectGroup") ||
                (e.Group.Key == "ResultSettingGroup"))
            {
                // グループの縮小をキャンセル
                e.Cancel = true;
            }
        }
        #endregion

        #region オフライン状態チェック処理
        /// <summary>				
        /// ログオン時オンライン状態チェック処理				
        /// </summary>				
        /// <returns>チェック処理結果</returns>				
        public static bool CheckOnline()
        {
            if (Broadleaf.Application.Common.LoginInfoAcquisition.OnlineFlag == false)
            {
                return false;
            }
            else
            {
                // ローカルエリア接続状態によるオンライン判定				
                if (CheckRemoteOn() == false)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>				
        /// リモート接続可能判定				
        /// </summary>				
        /// <returns>判定結果</returns>				
        private static bool CheckRemoteOn()
        {
            bool isLocalAreaConnected = NetworkInterface.GetIsNetworkAvailable();

            if (isLocalAreaConnected == false)
            {
                // インターネット接続不能状態				
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

    }
}