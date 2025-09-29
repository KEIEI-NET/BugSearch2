//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : キャンペーン対象商品設定マスタ一括登録
// プログラム概要   : キャンペーン対象商品設定マスタ一括登録
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 鄧潘ハン
// 作 成 日  2011/05/20  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  10700008-00 作成担当 : 譚洪
// 修 正 日  2011/07/13  修正内容 : Redmine#22877 BLコード（開始）（終了）をやめて、単独指定に変更の修正
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Library.Windows.Forms;
using System.Net.NetworkInformation;
using System.Collections;
using Broadleaf.Application.Remoting.ParamData;
using System.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// キャンペーン対象商品設定マスタ一括登録フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : キャンペーン対象商品設定マスタ一括登録を行います。</br>
    /// <br>Programmer : 鄧潘ハン</br>
    /// <br>Date       : 2011/05/20</br>
    /// <br>UpdateNote : 2011/07/13 譚洪 Redmine#22877 BLコード（開始）（終了）をやめて、単独指定に変更の修正</br>
    /// </remarks>
    public partial class PMKHN09631UA : Form
    {
        # region Private Constant
        
        // ツールバーツールキー設定
        private const string TOOLBAR_CLOSEBUTTON_KEY = "ButtonTool_Close";
        private const string TOOLBAR_UPDATEBUTTON_KEY = "ButtonTool_Update";
        private const string TOOLBAR_GUIDEBUTTON_KEY = "ButtonTool_Guid";
        private const string TOOLBAR_CLEARBUTTON_KEY = "ButtonTool_Clear";
        private const string TOOLBAR_LOGINSECTIONLABLE_KEY = "LabelTool_LoginTitle";
        private const string TOOLBAR_LOGINNAMELABLE_KEY = "LabelTool_LoginName";

        // ガイド名称
        private const string ctGUIDE_NAME_Section = "tEdit_SectionCodeAllowZero";
        private const string ctGUIDE_NAME_CampaignCode = "CampaignCode_tNedit";
        private const string ctGUIDE_NAME_GoodsMakerCd = "tNedit_GoodsMakerCd";
        private const string ctGUIDE_NAME_BLGoodsCdSt = "tNedit_BLGoodsCode_St";
        //private const string ctGUIDE_NAME_BLGoodsCdEd = "tNedit_BLGoodsCode_Ed";  // DEL 2011/07/13 

        // クラス名
        private string ct_PRINTNAME = "キャンペーン対象商品設定マスタ一括登録";

        # endregion

        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        # region Private Members

        private ImageList _imageList16 = null;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;					// 終了ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _updateButton;					// 更新ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _guideButton;					// ガイドボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _clearButton;					// クリアボタン					
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginTitleLabel;				// ログイン担当者名称
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginNameLabel;

        private MakerAcs _makerAcs;                        // メーカーアクセスクラス
        private string _enterpriseCode;                    // 企業コード
        private DateGetAcs _dateGetAcs;                    // 日付取得部品
        private int START_FLAG = 0;
        //private int END_FLAG = 1;   // DEL 2011/07/13 
        private BLGoodsCdAcs _blGoodsCdAcs = null;		   // BLアクセスクラス
        private CampaignStAcs _campaignStAcs;              // キャンペーン設定アクセスクラス
        private SecInfoSetAcs _secInfoSetAcs;              // 拠点情報設定アクセスクラス
        private CampaignGoodsData _campaignGoodsData;
        /// <summary>キャンペーンアクセスクラス</summary>
        public  CampaignGoodsStAcs _campaignGoodsStAcs=null;
        private string _guideKey;
        private SecInfoAcs _secInfoAcs;
        private Control _prevControl = null;
        private SFCMN00299CA msgForm = null;
        private PMKHN09631UB _PMKHN09631UB = null;
        /// <summary>キャンペーンリンクリスト</summary>
        public  ArrayList _campaignLinklist = null;
        private string _pregoodsMakerCd = "";
        private string _pregoodsMakerName = "";
        private string _prebLGoodsCode = "";  // ADD 2011/07/13 
        private string _prebLGoodsName = "";  // ADD 2011/07/13 
        private string _presectionCode = "00";
        private string _presectionName = "全社";
        private int _retKeyFlag = -1;                       //判定フラグ

        private string _precampaignCode = "";
        private int _retgraflag = 0;

        # endregion

        // ===================================================================================== //
        // Constructor
        // ===================================================================================== //
        #region　Constructor

        /// <summary>
        /// キャンペーン対象商品設定マスタ一括登録フォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note		: キャンペーン対象商品設定マスタ一括登録フォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer	: 鄧潘ハン</br>
        /// <br>Date		: 2011/05/20</br>
        /// </remarks>
        public PMKHN09631UA()
        {
            InitializeComponent();
            // 変数初期化
            this._imageList16 = IconResourceManagement.ImageList16;

            this._loginTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolsManager_MainMenu.Tools[TOOLBAR_LOGINSECTIONLABLE_KEY];
            this._loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolsManager_MainMenu.Tools[TOOLBAR_LOGINNAMELABLE_KEY];
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools[TOOLBAR_CLOSEBUTTON_KEY];
            this._updateButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools[TOOLBAR_UPDATEBUTTON_KEY];
            this._clearButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools[TOOLBAR_CLEARBUTTON_KEY];
            this._guideButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools[TOOLBAR_GUIDEBUTTON_KEY];

            this._makerAcs = new MakerAcs();
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._blGoodsCdAcs = new BLGoodsCdAcs();
            this._campaignStAcs = new CampaignStAcs();
            this._secInfoSetAcs = new SecInfoSetAcs();
            this._campaignGoodsData = new CampaignGoodsData();
            this._campaignGoodsStAcs = CampaignGoodsStAcs.GetInstance();
            this._dateGetAcs = DateGetAcs.GetInstance();
            this._loginNameLabel.SharedProps.Caption = LoginInfoAcquisition.Employee.Name;
            this._secInfoAcs = new SecInfoAcs();
         
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
        /// <br>Programmer  : 鄧潘ハン</br>
        /// <br>Date        : 2011/05/20</br>
        /// </remarks> 
        private void InitialScreenSetting()
        {
            this.ToolBarInitilSetting();       // ツールバー初期設定処理
            this.SetGuidButtonIcon();          // ボタンアイコン設定
            this.InitialScreenData();          //初期画面データ設定
        }

        /// <summary>
        /// 画面初期化
        /// </summary>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2011/05/20</br>
        /// <br>UpdateNote : 2011/07/13 譚洪 Redmine#22877 BLコード（開始）（終了）をやめて、単独指定に変更の修正</br>
        /// </remarks>
        private void Clear()
        {
            this.InitialScreenData();
            this.CampaignCode_tNedit.Text = string.Empty;
            this.tNedit_GoodsMakerCd.Text = string.Empty;
            this.tEdit_GoodsMakerName.Text = string.Empty;
            this.tEdit_gNoNHyphen.Text = string.Empty;
            this.tEdit_gNoNHyphen.Text = string.Empty;
            //this.tNedit_BLGoodsCode_Ed.Text = string.Empty;  // DEL 2011/07/13 
            this.tEdit_BLGoodsName.Text = string.Empty; // ADD 2011/07/13
            this.tNedit_BLGoodsCode_St.Text = string.Empty;
            this._campaignGoodsStAcs._precampaignLinkList = null;
            this.GoodsRCount_uLabel.Text="0 件";
            this.CampaignMngAdd_uLabel.Text = "0 件";
            //this.Initial_Timer.Enabled = true;      // DEL 2011/07/13 
            this.tNedit_GoodsMakerCd.Focus(); 
            //this.ActiveControl = this.tNedit_GoodsMakerCd;  // DEL 2011/07/13 
            this.SettingGuideButtonToolEnabled(this.ActiveControl);
            _pregoodsMakerCd = "";
            _pregoodsMakerName = "";
            _prebLGoodsCode = "";  // ADD 2011/07/13 
            _prebLGoodsName = "";  // ADD 2011/07/13 
            _presectionCode = "00";
            _presectionName = "全社";
            _precampaignCode = "";
        }

        /// <summary>
        /// 画面初期化
        /// </summary>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2011/05/20</br>
        /// </remarks>
        private void InitialScreenData()
        {
            this.CampaignName_tEdit.Text = string.Empty;
            this.tEdit_SectionCodeAllowZero.Text = "00";
            this.SectionName_tEdit.Text = "全社";
            this.CampaignObjDiv_tComboEditor.SelectedIndex = 0;
            this.ApplyStaDate_TDateEdit.SetDateTime(DateTime.Now);
            this.ApplyEndDate_TDateEdit.SetDateTime(DateTime.Now);
            this.CampaignObjDiv_Button.Enabled = false;
            this._campaignLinklist = new ArrayList();
            this._campaignGoodsStAcs._precampaignLinkList = null;
        }

        /// <summary>
        /// ツールバー初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 画面初期化時、ツールバー初期設定処理を行います。</br>
        /// <br>Programmer  : 鄧潘ハン</br>
        /// <br>Date        : 2011/05/20</br>
        /// </remarks> 
        private void ToolBarInitilSetting()
        {
            this._imageList16 = IconResourceManagement.ImageList16;
            this.tToolsManager_MainMenu.ImageListSmall = this._imageList16;
            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
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
        /// <br>Programmer  : 鄧潘ハン</br>
        /// <br>Date        : 2011/05/20</br>
        /// <br>UpdateNote  : 2011/07/13 譚洪 Redmine#22877 BLコード（開始）（終了）をやめて、単独指定に変更の修正</br>
        /// </remarks>
        private void SetGuidButtonIcon()
        {
            this.uButton_GoodsMakerCd.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];
            this.BLGoodsCdFrm_Button.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];
            //this.BLGoodsCdTo_Button.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];  // DEL 2011/07/13 
            this.uButton_CampaignCode.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];
            this.SectionGuide_Button.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];
        }

        /// <summary>
        /// ＢＬコードガイドデータ取得処理
        /// </summary>
        /// <param name="flag">0:開始 1:終了</param>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2011/05/20</br>
        /// <br>UpdateNote : 2011/07/13 譚洪 Redmine#22877 BLコード（開始）（終了）をやめて、単独指定に変更の修正</br>
        /// </remarks>
        private void ClickBLGoodsCodeGuide(int flag)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                int status;
                BLGoodsCdUMnt blGoodsCdUMnt = null;

                // BLコードガイド表示
                status = this._blGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out blGoodsCdUMnt);
                if (status == 0)
                {
                    // BLコードフラグ
                    // ----- UPD 2011/07/13 ------- >>>>>>>>>
                    //if (flag == this.START_FLAG)
                    //{
                        this.tNedit_BLGoodsCode_St.Text=blGoodsCdUMnt.BLGoodsCode.ToString("00000");
                        this.tEdit_BLGoodsName.Text = blGoodsCdUMnt.BLGoodsHalfName;
                        // フォーカス設定
                        //this.tNedit_BLGoodsCode_Ed.Focus();
                        this.CampaignCode_tNedit.Focus();
                    //}
                    //else
                    //{
                    //    this.tNedit_BLGoodsCode_Ed.Text=blGoodsCdUMnt.BLGoodsCode.ToString("00000");
                    //    // フォーカス設定
                    //    this.CampaignCode_tNedit.Focus(); 
                    //}
                    
                    this.SettingGuideButtonToolEnabled(this.ActiveControl);

                    this._prebLGoodsCode = blGoodsCdUMnt.BLGoodsCode.ToString();
                    this._prebLGoodsName = blGoodsCdUMnt.BLGoodsHalfName;
                    // ----- UPD 2011/07/13 ------- <<<<<<<<<
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// ボタンツール有効無効設定処理
        /// </summary>
        /// <param name="nextControl">次のコントロール</param>
        /// <remarks>
        /// <br>Note		: ボタンツール有効無効設定処理</br>
        /// <br>Programmer  : 鄧潘ハン</br>
        /// <br>Date        : 2011/05/20</br>
        /// <br>UpdateNote  : 2011/07/13 譚洪 Redmine#22877 BLコード（開始）（終了）をやめて、単独指定に変更の修正</br>
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
                || targetControl.Name == ctGUIDE_NAME_CampaignCode
                || targetControl.Name == ctGUIDE_NAME_GoodsMakerCd
                || targetControl.Name == ctGUIDE_NAME_BLGoodsCdSt)
                //|| targetControl.Name == ctGUIDE_NAME_BLGoodsCdEd)  // DEL 2011/07/13 
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
        /// 「ガイド」処理
        /// </summary>
        /// <remarks>
        /// <br>Note		:「ガイド」処理</br>
        /// <br>Programmer  : 鄧潘ハン</br>
        /// <br>Date        : 2011/05/20</br>
        /// <br>UpdateNote  : 2011/07/13 譚洪 Redmine#22877 BLコード（開始）（終了）をやめて、単独指定に変更の修正</br>
        /// </remarks>
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

                case ctGUIDE_NAME_CampaignCode:
                    {
                        this.uButton_CampaignCode_Click(this.uButton_CampaignCode, new EventArgs());
                        break;
                    }

                case ctGUIDE_NAME_GoodsMakerCd:
                    {
                        this.uButton_GoodsMakerCd_Click(this.uButton_GoodsMakerCd, new EventArgs());
                        break;
                    }

                case ctGUIDE_NAME_BLGoodsCdSt:
                    {
                        this.BLGoodsCdFrm_Button_Click(this.BLGoodsCdFrm_Button, new EventArgs());
                        break;
                    }

                // ----- DEL 2011/07/13 ------- >>>>>>>>>
                //case ctGUIDE_NAME_BLGoodsCdEd:
                //    {
                //        this.BLGoodsCdTo_Button_Click(this.BLGoodsCdTo_Button, new EventArgs());
                //        break;
                //    }
                // ----- DEL 2011/07/13 ------- <<<<<<<<<
            }
        }

        /// <summary>
        /// 画面更新前チェック
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2011/05/20</br>
        /// <br>UpdateNote : 2011/07/13 譚洪 Redmine#22877 BLコード（開始）（終了）をやめて、単独指定に変更の修正</br>
        /// </remarks>
        private bool BeforeSearchCheck(int maxRow)
        {
            int yearDif = 0;
            DateGetAcs.CheckDateResult cdResult;

            // メーカーコード
            if (this._campaignGoodsData.GoodsMakerCd == 0)
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

            // ----- DEL 2011/07/13 ------- >>>>>>>>>
            // ＢＬコード比較
            //if (this._campaignGoodsData.BLGroupCodeSt > this._campaignGoodsData.BLGroupCodeEd && this._campaignGoodsData.BLGroupCodeEd != 0)
            //{
            //    // 該当に誤りがあります
            //    TMsgDisp.Show(this, 												// 親ウィンドウフォーム
            //                    emErrorLevel.ERR_LEVEL_EXCLAMATION, 				// エラーレベル
            //                    this.Name,											// アセンブリID
            //                    "ＢＬコードの範囲に誤りがあります。",                 // 表示するメッセージ
            //                    -1,													// ステータス値
            //                    MessageBoxButtons.OK);

            //    // フォーカス設定
            //    this.tNedit_BLGoodsCode_St.Focus();
            //    this.SettingGuideButtonToolEnabled(this.ActiveControl);
            //    return false;
            //}
            // ----- DEL 2011/07/13 ------- <<<<<<<<<

            // ----- ADD 2011/07/13 ------- >>>>>>>>>
            // 頭品番が未入力、で且つＢＬコードが未入力でエラー
            if (string.IsNullOrEmpty(this._campaignGoodsData.GoodsNoNoneHyphen) && this._campaignGoodsData.BLGoodsCode == 0)
            {
                // 該当に誤りがあります
                TMsgDisp.Show(this, 												// 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_EXCLAMATION, 				// エラーレベル
                                this.Name,											// アセンブリID
                                "品番か、ＢＬコードを入力して下さい。",                 // 表示するメッセージ
                                -1,													// ステータス値
                                MessageBoxButtons.OK);

                // フォーカス設定
                this.tEdit_gNoNHyphen.Focus();
                return false;
            }
            // ----- ADD 2011/07/13 ------- <<<<<<<<<

            // キャンペーンコード
            if (this._campaignGoodsData.CampaignCode == 0)
            {
                // 該当なし
                TMsgDisp.Show(this, 												// 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_EXCLAMATION, 				// エラーレベル
                                this.Name,											// アセンブリID
                                "キャンペーンコードを入力して下さい。",                 // 表示するメッセージ
                                -1,													// ステータス値
                                MessageBoxButtons.OK);

                // フォーカス設定
                this.CampaignCode_tNedit.Focus();
                this.SettingGuideButtonToolEnabled(this.ActiveControl);
                return false;
            }

            // 対象得意先が設定
            if (maxRow == 0 && CampaignObjDiv_Button.Enabled == true)
            {
                // 該当なし
                TMsgDisp.Show(this, 												// 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_EXCLAMATION, 				// エラーレベル
                                this.Name,											// アセンブリID
                                "対象得意先が設定されていません。",                 // 表示するメッセージ
                                -1,													// ステータス値
                                MessageBoxButtons.OK);

                // フォーカス設定
                this.CampaignObjDiv_Button.Focus();
                this.SettingGuideButtonToolEnabled(this.ActiveControl);
                return false;
            }

            // 対象得意先が設定
            if (this.CampaignObjDiv_tComboEditor.SelectedIndex != 0
                && this.CampaignObjDiv_tComboEditor.SelectedIndex != 1)
            {
                // 該当なし
                TMsgDisp.Show(this, 												// 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_EXCLAMATION, 				// エラーレベル
                                this.Name,											// アセンブリID
                                "対象得意先区分を入力して下さい。",                 // 表示するメッセージ
                                -1,													// ステータス値
                                MessageBoxButtons.OK);

                // フォーカス設定
                this.CampaignObjDiv_tComboEditor.Focus();
                this.SettingGuideButtonToolEnabled(this.ActiveControl);
                return false;
            }

            // キャンペーン名称
            if (string.IsNullOrEmpty(this._campaignGoodsData.CampaignName))
            {
                // 該当なし
                TMsgDisp.Show(this, 												// 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_EXCLAMATION, 				// エラーレベル
                                this.Name,											// アセンブリID
                                "キャンペーン名称を入力して下さい。",                 // 表示するメッセージ
                                -1,													// ステータス値
                                MessageBoxButtons.OK);

                // フォーカス設定
                this.CampaignName_tEdit.Focus();
                this.SettingGuideButtonToolEnabled(this.ActiveControl);
                return false;
            }

            // 適用開始日
            if (CallCheckDate(out cdResult, ref this.ApplyStaDate_TDateEdit) == false)
            {
                // 処理日
                switch (cdResult)
                {
                    case DateGetAcs.CheckDateResult.ErrorOfInvalid:
                        {
                            // 不正値を入力時エラ
                            TMsgDisp.Show(this, 												// 親ウィンドウフォーム
                                            emErrorLevel.ERR_LEVEL_EXCLAMATION, 				// エラーレベル
                                            this.Name,											// アセンブリID
                                            "適用日の入力が不正です。",                         // 表示するメッセージ
                                            -1,													// ステータス値
                                            MessageBoxButtons.OK);

                            // フォーカス設定
                            this.ApplyStaDate_TDateEdit.Focus();
                            this.SettingGuideButtonToolEnabled(this.ActiveControl);
                        }
                        break;
                    case DateGetAcs.CheckDateResult.ErrorOfNoInput:
                        {
                            // 未入力の場合エラ
                            TMsgDisp.Show(this, 												// 親ウィンドウフォーム
                                            emErrorLevel.ERR_LEVEL_EXCLAMATION, 				// エラーレベル
                                            this.Name,											// アセンブリID
                                            "適用日の入力が不正です。",                         // 表示するメッセージ
                                            -1,													// ステータス値
                                            MessageBoxButtons.OK);

                            // フォーカス設定
                            this.ApplyStaDate_TDateEdit.Focus();
                            this.SettingGuideButtonToolEnabled(this.ActiveControl);
                        }
                        break;
                }
                return false;
            }

            // 適用終了日
            if (CallCheckDate(out cdResult, ref this.ApplyEndDate_TDateEdit) == false)
            {
                // 処理日
                switch (cdResult)
                {
                    case DateGetAcs.CheckDateResult.ErrorOfInvalid:
                        {
                            // 不正値を入力時エラ
                            TMsgDisp.Show(this, 												// 親ウィンドウフォーム
                                            emErrorLevel.ERR_LEVEL_EXCLAMATION, 				// エラーレベル
                                            this.Name,											// アセンブリID
                                            "適用日の入力が不正です。",                         // 表示するメッセージ
                                            -1,													// ステータス値
                                            MessageBoxButtons.OK);

                            // フォーカス設定
                            this.ApplyEndDate_TDateEdit.Focus();
                            this.SettingGuideButtonToolEnabled(this.ActiveControl);
                        }
                        break;
                    case DateGetAcs.CheckDateResult.ErrorOfNoInput:
                        {
                            // 未入力の場合エラ
                            TMsgDisp.Show(this, 												// 親ウィンドウフォーム
                                            emErrorLevel.ERR_LEVEL_EXCLAMATION, 				// エラーレベル
                                            this.Name,											// アセンブリID
                                            "適用日の入力が不正です。",                         // 表示するメッセージ
                                            -1,													// ステータス値
                                            MessageBoxButtons.OK);

                            // フォーカス設定
                            this.ApplyEndDate_TDateEdit.Focus();
                            this.SettingGuideButtonToolEnabled(this.ActiveControl);
                        }
                        break;
                }
                return false;
            }

            // 適用日の入力
            if (this.ApplyStaDate_TDateEdit.GetLongDate() > this.ApplyEndDate_TDateEdit.GetLongDate())
            {
                // 開始＞終了
                TMsgDisp.Show(this, 												// 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_EXCLAMATION, 				// エラーレベル
                                this.Name,											// アセンブリID
                                "適用日の入力が不正です。",                         // 表示するメッセージ
                                -1,													// ステータス値
                                MessageBoxButtons.OK);

                // フォーカス設定
                this.ApplyStaDate_TDateEdit.Focus();
                this.SettingGuideButtonToolEnabled(this.ActiveControl);
                return false;
            }
            yearDif = this.ApplyEndDate_TDateEdit.GetLongDate() - this.ApplyStaDate_TDateEdit.GetLongDate();

            // 適用日の範囲
            if (yearDif >= 10000)
            {
                // 開始＞終了
                TMsgDisp.Show(this, 												// 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_EXCLAMATION, 				// エラーレベル
                                this.Name,											// アセンブリID
                                "適用日の範囲は１年以内で入力して下さい。",                         // 表示するメッセージ
                                -1,													// ステータス値
                                MessageBoxButtons.OK);

                // フォーカス設定
                this.ApplyStaDate_TDateEdit.Focus();
                this.SettingGuideButtonToolEnabled(this.ActiveControl);
                return false;
            }

            return true;
        }


        /// <summary>
        /// 日付チェック処理呼び出し
        /// </summary>
        /// <param name="cdResult"></param>
        /// <param name="targetDateEdit"></param>
        /// <returns></returns>
        private bool CallCheckDate(out DateGetAcs.CheckDateResult cdResult, ref TDateEdit targetDateEdit)
        {
            cdResult = this._dateGetAcs.CheckDate(ref targetDateEdit, false);
            return (cdResult == DateGetAcs.CheckDateResult.OK);
        }

        /// <summary>
        /// 拠点名称取得処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>拠点名称 ※該当するものがない場合、<c>null</c>を返します。</returns>
        /// <remarks>
        /// <br>Note       : 拠点名称を取得します。</br>
        /// <br></br>
        /// </remarks>
        private string GetSectionName(string sectionCode)
        {
            string sectionName = "";

            // 全社共通チェック
            if (sectionCode.Trim().PadLeft(2, '0') == "00")
            {
                sectionName = "全社";
                this.tEdit_SectionCodeAllowZero.Text = "00";
                return sectionName;
            }

            try
            {
                foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
                {
                    if (secInfoSet.SectionCode.Trim() == sectionCode.Trim().PadLeft(2, '0'))
                    {
                        sectionName = secInfoSet.SectionGuideNm.Trim();
                        return sectionName;
                    }
                }
                sectionName = null;
            }
            catch
            {
                sectionName = null;
            }

            return sectionName;
        }

        /// <summary>
        /// メーカー名称取得処理
        /// </summary>
        /// <param name="goodsMakerCd">メーカーコード</param>
        /// <returns>メーカー名称 ※該当するものがない場合、<c>null</c>を返します。</returns>
        /// <remarks>
        /// <br>Note       : メーカー名称を取得します。</br>
        /// <br></br>
        /// </remarks>
        private string GetCoodsMaker(string goodsMakerCd)
        {
            string CoodsMakerName = string.Empty;
            MakerUMnt makerUMnt;
            try
            {
                int status = this._makerAcs.Read(out makerUMnt, this._enterpriseCode, Convert.ToInt32(goodsMakerCd));
                if (status == 0 && makerUMnt.LogicalDeleteCode == 0)
                {
                    // 結果セット
                    CoodsMakerName = makerUMnt.MakerName;
                }
                else
                {
                    // 結果セット
                    CoodsMakerName = null;
                }
            }
            catch
            {
                CoodsMakerName = null;
            }

            return CoodsMakerName;
        }

        /// <summary>
        /// BLコード名称取得処理
        /// </summary>
        /// <param name="blGoodsCd">BLコード</param>
        /// <returns>BLコード名称 ※該当するものがない場合、<c>null</c>を返します。</returns>
        /// <remarks>
        /// <br>Note       : BLコード名称を取得します。</br>
        /// <br></br>
        /// </remarks>
        private string GetBLGoodsName(string blGoodsCd)
        {
            string BLGoodsName = string.Empty;
            BLGoodsCdUMnt blGoodsCdUMnt = null;

            int status = this._blGoodsCdAcs.Read(out blGoodsCdUMnt, this._enterpriseCode, Convert.ToInt32(blGoodsCd));
            if (status == 0)
            {
                // 結果セット
                BLGoodsName = blGoodsCdUMnt.BLGoodsName;
            }
            else
            {
                // 結果セット
                BLGoodsName = null;
            }
            return BLGoodsName;
        }

        /// <summary>
        /// エラーメッセージ表示処理
        /// </summary>
        /// <param name="iLevel">エラーレベル</param>
        /// <param name="message">表示メッセージ</param>
        /// <param name="status">ステータス</param>
        /// <remarks>
        /// <br>Note        : エラーメッセージ表示処理</br>
        /// <br>Programmer  : 鄧潘ハン</br>
        /// <br>Date        : 2011/05/20</br>
        /// </remarks>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
        {
            TMsgDisp.Show(
                iLevel, 							// エラーレベル
                "PMKHN09631UA",						// アセンブリＩＤまたはクラスＩＤ
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
        ///	Form.Load イベント(PMKHN09631U)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: ユーザーがフォームを読み込むときに発生します。</br>
        /// <br>Programmer	: 鄧潘ハン</br>
        /// <br>Date		: 2011/05/20</br>
        /// <br>UpdateNote  : 2011/07/13 譚洪 Redmine#22877 BLコード（開始）（終了）をやめて、単独指定に変更の修正</br>
        /// </remarks>
        private void PMKHN09631UA_Load(object sender, EventArgs e)
        {
            // 画面初期化
            InitialScreenSetting();

            this.Initial_Timer.Enabled = true; // ADD 2011/07/13 
        }

        /// <summary>
        /// ツールバークリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : ツールバークリック時に発生します。</br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2011/05/20</br>
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
                // 更新
                case TOOLBAR_UPDATEBUTTON_KEY:
                    {
                        this.DataUpdate();
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
        /// Control.Click イベント(uButton_GoodsMakerCd)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : メーカーガイドをクッリク時に発生します。</br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2011/05/20</br>
        /// </remarks>
        private void uButton_GoodsMakerCd_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                MakerUMnt makerUMnt;
                
                int status = this._makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt);
                if (status == 0)
                {
                    // 結果セット
                    this.tNedit_GoodsMakerCd.Text=makerUMnt.GoodsMakerCd.ToString("0000");
                    this.tEdit_GoodsMakerName.Text = makerUMnt.MakerName;

                    // フォーカス設定
                    this.tEdit_gNoNHyphen.Focus();

                    SettingGuideButtonToolEnabled(this.ActiveControl);
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        ///Control.Click イベント(BLGoodsCdFrm_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : BLコードガイドをクッリク時に発生します。</br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2011/05/20</br>
        /// </remarks>
        private void BLGoodsCdFrm_Button_Click(object sender, EventArgs e)
        {
            // ＢＬコードガイドデータ取得処理
            this.ClickBLGoodsCodeGuide(START_FLAG);
        }

        // ----- DEL 2011/07/13 ------- >>>>>>>>>
        /// <summary>
        /// Control.Click イベント(BLGoodsCdTo_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : BLコード終了ガイドをクッリク時に発生します。</br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2011/05/20</br>
        /// </remarks>
        //private void BLGoodsCdTo_Button_Click(object sender, EventArgs e)
        //{
        //    // ＢＬコードガイドデータ取得処理
        //    this.ClickBLGoodsCodeGuide(END_FLAG);
        //}
        // ----- DEL 2011/07/13 ------- <<<<<<<<<

        /// <summary>
        /// Control.Click イベント(uButton_CampaignCode)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : キャンペーンコードガイドをクッリク時に発生します。</br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2011/05/20</br>
        /// </remarks>
        private void uButton_CampaignCode_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                CampaignSt campaignSt;

                // ガイド起動
                int status = _campaignStAcs.ExecuteGuid(this._enterpriseCode,  out campaignSt);

                if (status == 0)
                {
                    if (this._precampaignCode != Convert.ToInt32(campaignSt.CampaignCode).ToString().Trim())
                    {
                        this._precampaignCode = this.CampaignCode_tNedit.GetInt().ToString().Trim();
                        // 結果セット
                        this.CampaignCode_tNedit.Text = campaignSt.CampaignCode.ToString("000000");
                        this.CampaignName_tEdit.Text = campaignSt.CampaignName;

                        campaignSt.EnterpriseCode = this._enterpriseCode;
                        campaignSt.CampaignCode = this.CampaignCode_tNedit.GetInt();
                        status = this._campaignGoodsStAcs.SearchCampaignSt(ref campaignSt);

                        if (status == 0)
                        {
                            this.CampaignName_tEdit.Text = campaignSt.CampaignName;
                            this.CampaignObjDiv_tComboEditor.SelectedIndex = campaignSt.CampaignObjDiv;
                            this.ApplyStaDate_TDateEdit.SetDateTime(campaignSt.ApplyStaDate);
                            this.ApplyEndDate_TDateEdit.SetDateTime(campaignSt.ApplyEndDate);
                            this.tEdit_SectionCodeAllowZero.Text = campaignSt.SectionCode.ToString().Trim();
                            this.SectionName_tEdit.Text = GetSectionName(campaignSt.SectionCode);

                            status = this._campaignGoodsStAcs.SearchCustomer(this.CampaignCode_tNedit.GetInt());

                            if (status == 0)
                            {
                                this._campaignLinklist = new ArrayList();

                                this._campaignLinklist = this._campaignGoodsStAcs._precampaignLinkList;
                            }
                            else
                            {
                                this._campaignLinklist = new ArrayList();

                                this._campaignGoodsStAcs._precampaignLinkList = null;
                            }
                        }

                    }

                    // フォーカス設定
                    this.CampaignName_tEdit.Focus(); 
                    SettingGuideButtonToolEnabled(this.ActiveControl);
                }

                this._precampaignCode = this.CampaignCode_tNedit.GetInt().ToString().Trim();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Control.Click イベント(SectionGuide_Butto)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 拠点ガイドボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2011/05/20</br>
        /// </remarks>
        private void SectionGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status;
                SecInfoSet secInfoSet = new SecInfoSet();

                status = _secInfoSetAcs.ExecuteGuid(this._enterpriseCode, true, out secInfoSet);
                if (status == 0)
                {
                    this.tEdit_SectionCodeAllowZero.DataText = secInfoSet.SectionCode.Trim();
                    this.SectionName_tEdit.DataText = secInfoSet.SectionGuideNm.Trim();
                    // フォーカス設定
                    this.CampaignObjDiv_tComboEditor.Focus();

                    SettingGuideButtonToolEnabled(this.ActiveControl);
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Control.Click イベント(CampaignObjDiv_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : CampaignObjDiv_Buttonをクッリク時に発生します。</br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2011/05/20</br>
        /// </remarks>
        private void CampaignObjDiv_Button_Click(object sender, EventArgs e)
        {
            //得意先設定画面を開ける
            this._PMKHN09631UB = new PMKHN09631UB();

            this._PMKHN09631UB.ShowDialog();
        }

        /// <summary>
        /// SelectionChanged イベント(CampaignObjDiv_tComboEditor)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : SelectionChangedときに発生します。</br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2011/05/20</br>
        /// </remarks>
        private void CampaignObjDiv_tComboEditor_SelectionChanged(object sender, EventArgs e)
        {
            if (this.CampaignObjDiv_tComboEditor.SelectedIndex == 1)
            {
                this.CampaignObjDiv_Button.Enabled = true;
            }
            else
            {
                this.CampaignObjDiv_Button.Enabled = false;
            }

        }

        private void msgForm_CancelButtonClick(object sender, EventArgs e)
        {
            this._campaignGoodsStAcs.ExtractCancelFlag = true;
            // 抽出キャンセル
            if (this.msgForm != null)
            {
                this.msgForm.Message = "中断します。";
            }
        }

        /// <summary>
        /// 画面更新
        /// </summary>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2011/05/20</br>
        /// <br>UpdateNote : 2011/07/13 譚洪 Redmine#22877 BLコード（開始）（終了）をやめて、単独指定に変更の修正</br>
        /// </remarks>
        private void DataUpdate()
        {
            int readCount = 0;
            int addCount = 0;
            int maxRow = 0;
            this._retgraflag = 1;

            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            this._campaignGoodsStAcs.ExtractCancelFlag = false;

            // 確認メッセージを表示する。
            DialogResult result = TMsgDisp.Show(
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,             // エラーレベル
                        "PMKHN09631UA",						            // アセンブリＩＤまたはクラスＩＤ
                        ct_PRINTNAME,				                    // プログラム名称
                        "", 								            // 処理名称
                        "",									            // オペレーション
                        "一括登録処理を開始してもよろしいですか？",		// 表示するメッセージ
                        -1, 							                // ステータス値
                        null, 								            // エラーが発生したオブジェクト
                        MessageBoxButtons.YesNo, 				        // 表示するボタン
                        MessageBoxDefaultButton.Button1);	            // 初期表示ボタン
            // 入力画面へ戻る。
            if (result == DialogResult.No)
            {
                return;
            }

            // オフライン状態チェック
            if (!CheckOnline())
            {
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_STOP,
                    this.Text,
                    this.Text + "画面更新処理に失敗しました。",
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

            //this._campaignGoodsData.BLGroupCodeSt = this.tNedit_BLGoodsCode_St.GetInt();  // DEL 2011/07/13
            this._campaignGoodsData.BLGoodsCode = this.tNedit_BLGoodsCode_St.GetInt();      // ADD 2011/07/13
            //this._campaignGoodsData.BLGroupCodeEd = this.tNedit_BLGoodsCode_Ed.GetInt();  // DEL 2011/07/13 
            this._campaignGoodsData.GoodsMakerCd = this.tNedit_GoodsMakerCd.GetInt();
            this._campaignGoodsData.GoodsNoNoneHyphen = this.tEdit_gNoNHyphen.Text.ToString().Trim();
            this._campaignGoodsData.EnterpriseCode = this._enterpriseCode.ToString().Trim();
            this._campaignGoodsData.CampaignCode = this.CampaignCode_tNedit.GetInt();
            this._campaignGoodsData.SectionCode = this.tEdit_SectionCodeAllowZero.Text.ToString().Trim();
            this._campaignGoodsData.CampaignName = this.CampaignName_tEdit.Text.ToString().Trim();
            this._campaignGoodsData.CampaignObjDiv = Convert.ToInt32(this.CampaignObjDiv_tComboEditor.Value);
            this._campaignGoodsData.ApplyStaDate = this.ApplyStaDate_TDateEdit.GetLongDate();
            this._campaignGoodsData.ApplyEndDate = this.ApplyEndDate_TDateEdit.GetLongDate();


            if (this._campaignGoodsStAcs._precampaignLinkList == null)
            {
                maxRow = 0;
            }
            else
            {
                maxRow=this._campaignGoodsStAcs._precampaignLinkList.Count;
            }

            // チェック
            bool isUpdate = this.BeforeSearchCheck(maxRow);

            if (!isUpdate)
            {
                return;
            }

            // 抽出中画面部品のインスタンスを作成
            msgForm = new SFCMN00299CA();
            msgForm.Title = "抽出処理";
            msgForm.Message = "現在、データ抽出中です。(ESCで中断します)￥nしばらくお待ちください";
            msgForm.DispCancelButton = true;
            msgForm.CancelButtonClick += new EventHandler(msgForm_CancelButtonClick);
          
            try
            {
                msgForm.Show();
                // 検索
                if (this._campaignGoodsStAcs.ExtractCancelFlag == false)
                {
                    status = this._campaignGoodsStAcs.SearchData(_campaignGoodsData,this._campaignLinklist, ref readCount, ref addCount);
                }
                switch (status)
                {
                    case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                        if (this._campaignGoodsStAcs.ExtractCancelFlag == false)
                        {
                            this.GoodsRCount_uLabel.Text = readCount.ToString("N0") + " " + "件";
                            this.CampaignMngAdd_uLabel.Text = addCount.ToString("N0") + " " + "件";
                        }

                        break;

                    case (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN:
                        if (this._campaignGoodsStAcs.ExtractCancelFlag == false)
                        {
                            // 0件エラー
                            MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "該当するデータが存在しません。", 0);
                        }

                        break;

                    default:
                        MsgDispProc(emErrorLevel.ERR_LEVEL_STOP, "更新に失敗しました。", -1);
                        this.GoodsRCount_uLabel.Text = "0 " + "件";
                        this.CampaignMngAdd_uLabel.Text = "0 " + "件";
                        break;
                }
            }
            finally
            {
                msgForm.Close();
            }

            this._campaignLinklist = new ArrayList();

            this._campaignLinklist = this._campaignGoodsStAcs._precampaignLinkList;

            this.SettingGuideButtonToolEnabled(this.ActiveControl);
        }

        /// <summary>
        /// フォーカス設定
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">クラス</param>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2011/05/20</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, EventArgs e)
        {
            // フォーカス設定
            this.tNedit_GoodsMakerCd.Focus();
            this._guideKey = this.tNedit_GoodsMakerCd.Name;

            this.SettingGuideButtonToolEnabled(this.ActiveControl);

            this.Initial_Timer.Enabled = false;
        }

        /// <summary>
        /// ChangeFocus イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2011/05/20</br>
        /// <br>UpdateNote : 2011/07/13 譚洪 Redmine#22877 BLコード（開始）（終了）をやめて、単独指定に変更の修正</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            this._retKeyFlag = 0;

            if (e.PrevCtrl == null || e.NextCtrl.Name == "ultraExplorerBar1")
            {
                return;
            }

           
            this._prevControl = e.NextCtrl;

            switch (e.PrevCtrl.Name)
            {
                // メーカーコードガイドボタン
                case "uButton_GoodsMakerCd":
                    {
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Right)
                            {
                                e.NextCtrl = this.uButton_GoodsMakerCd;
                            }
                            else if (e.Key == Keys.Up)
                            {
                                e.NextCtrl = this.uButton_GoodsMakerCd;
                            }
                            else if (e.Key == Keys.Down)
                            {
                                e.NextCtrl = this.tEdit_gNoNHyphen;
                            }
                            
                        }
                      
                        break;
                    }


                // ----- DEL 2011/07/13 ------- >>>>>>>>>
                // Goodsコード終了ガイドボタン
                //case "BLGoodsCdTo_Button":
                //    {
                //        if (e.ShiftKey == false)
                //        {
                //            if (e.Key == Keys.Right)
                //            {
                //                e.NextCtrl = this.BLGoodsCdTo_Button;
                //            }
                //            else if (e.Key == Keys.Down)
                //            {
                //                e.NextCtrl = this.uButton_CampaignCode;
                //            }
                //            else if (e.Key == Keys.Up)
                //            {
                //                e.NextCtrl = this.tEdit_gNoNHyphen;
                //            }
                //        }

                //        break;
                //    }
                // ----- DEL 2011/07/13 ------- <<<<<<<<<

                // ----- ADD 2011/07/13 ------- >>>>>>>>>
                // Goodsコード開始ガイドボタン
                case "BLGoodsCdFrm_Button":
                    {
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Right)
                            {
                                e.NextCtrl = this.BLGoodsCdFrm_Button;
                            }
                            else if (e.Key == Keys.Down)
                            {
                                e.NextCtrl = this.uButton_CampaignCode;
                            }
                            else if (e.Key == Keys.Up)
                            {
                                e.NextCtrl = this.tEdit_gNoNHyphen;
                            }
                        }

                        break;
                    }
                // ----- ADD 2011/07/13 ------- <<<<<<<<<


                // キャンペーンコードガイドボタン
                case "uButton_CampaignCode":
                    {
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Right)
                            {
                                e.NextCtrl = this.uButton_CampaignCode;
                            }
                            else if(e.Key == Keys.Up)
                            {
                                // ----- UPD 2011/07/13 ------- <<<<<<<<<
                                //e.NextCtrl = this.tNedit_BLGoodsCode_Ed;
                                e.NextCtrl = this.tNedit_BLGoodsCode_St;
                                // ----- UPD 2011/07/13 ------- >>>>>>>>>
                            }


                        }

                        break;
                    }

                // 拠点コードガイドボタン
                case "SectionGuide_Button":
                    {
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Right)
                            {
                                e.NextCtrl = this.SectionGuide_Button;
                            }
                            if (e.Key == Keys.Down && this.CampaignObjDiv_Button.Enabled == false)
                            {
                                e.NextCtrl = this.CampaignObjDiv_tComboEditor;
                            }

                        }

                        break;
                    }

                // キャンペーン名称
                case "CampaignName_tEdit":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Down) && e.NextCtrl.Name != "_PMKHN09631UA_Toolbars_Dock_Area_Top")
                            {
                                if (this._retgraflag != 1)
                                {
                                    this._retgraflag = 0;
                                    e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                                }
                            }
                            else if (e.Key == Keys.Up)
                            {
                                e.NextCtrl = this.CampaignCode_tNedit;
                            }
                            
                        }
                        else
                        {
                            // 入力無し
                            if (string.IsNullOrEmpty(this.CampaignCode_tNedit.Text.Trim()))
                            {
                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                {
                                    e.NextCtrl = this.uButton_CampaignCode;
                                }
                           
                            }
                            else
                            {
                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                {
                                    e.NextCtrl = this.CampaignCode_tNedit;
                                }

                            }
                        }
                     
                        break;
                    }
                // 拠点コード
                case ctGUIDE_NAME_Section:
                    {

                        // 拠点コード取得
                        string sectionCode = this.tEdit_SectionCodeAllowZero.DataText;
                        // 拠点名称取得
                        string sectionName = GetSectionName(sectionCode);

                        int code = 0;
                        try
                        {
                            code = Convert.ToInt32(sectionCode);

                        }
                        catch
                        {
                            code = 0;
                        }

                        if (code == 0)
                        {
                            this.tEdit_SectionCodeAllowZero.Text = "00";
                            this.SectionName_tEdit.Text = "全社";
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(sectionName))
                            {
                                this.SectionName_tEdit.Text = sectionName;
                            }
                            else if (sectionName == null)
                            {
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                    this.Name,
                                    "拠点が存在しません。",
                                    -1,
                                    MessageBoxButtons.OK
                                );
                                this.tEdit_SectionCodeAllowZero.Text = this._presectionCode;
                                this.SectionName_tEdit.Text = this._presectionName;
                                e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                                e.NextCtrl.Select();
                                return;
                            }
                        
                        }

                        this._presectionName = this.SectionName_tEdit.Text;
                        this._presectionCode = this.tEdit_SectionCodeAllowZero.Text.ToString().Trim();
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.SectionName_tEdit.DataText.Trim() != "")
                                {
                                    // フォーカス設定
                                    e.NextCtrl = this.CampaignObjDiv_tComboEditor;
                                }
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.SectionName_tEdit.DataText.Trim() != "")
                                {
                                    // フォーカス設定
                                    e.NextCtrl = this.CampaignName_tEdit;
                                }
                            }
                        }
                        break;
                    }
                // メーカーコード
                case ctGUIDE_NAME_GoodsMakerCd:
                    {
                        // メーカーコード取得
                        string goodsMakerCd = this.tNedit_GoodsMakerCd.DataText;

                        int code = this.tNedit_GoodsMakerCd.GetInt();

                        if (code == 0)
                        {
                            this.tNedit_GoodsMakerCd.Text = string.Empty;
                            this.tEdit_GoodsMakerName.Text = string.Empty;
                        }
                        else
                        {
                            // メーカー名称取得
                            string goodsMakerName = GetCoodsMaker(goodsMakerCd);
                            if (!string.IsNullOrEmpty(goodsMakerName))
                            {
                                this.tNedit_GoodsMakerCd.Text = goodsMakerCd;
                                this.tEdit_GoodsMakerName.Text = goodsMakerName;
                            }
                            else
                            {
                                if (goodsMakerName == null)
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                        this.Name,
                                        "メーカーが存在しません。",
                                        -1,
                                        MessageBoxButtons.OK
                                    );
                                    this.tNedit_GoodsMakerCd.Text = this._pregoodsMakerCd;
                                    this.tEdit_GoodsMakerName.Text = this._pregoodsMakerName;
                                    e.NextCtrl = this.tNedit_GoodsMakerCd;
                                    e.NextCtrl.Select();
                                    return;
                                }

                            } 
                        }
                      
                        this._pregoodsMakerCd = this.tNedit_GoodsMakerCd.Text.ToString().Trim();
                        this._pregoodsMakerName = this.tEdit_GoodsMakerName.Text.ToString().Trim();

                        if (e.ShiftKey == false)
                        {

                            // 入力無し
                            if (string.IsNullOrEmpty(this.tNedit_GoodsMakerCd.Text.Trim()))
                            {
                                if (e.Key == Keys.Return || e.Key == Keys.Tab )
                                {
                                    e.NextCtrl = this.uButton_GoodsMakerCd;
                                }
                                else if (e.Key == Keys.Up)
                                {
                                    e.NextCtrl = this.tNedit_GoodsMakerCd;
                                }
                            }
                            else
                            {
                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                {
                                    if (this._retgraflag != 1)
                                    {
                                        this._retgraflag = 0;
                                        e.NextCtrl = this.tEdit_gNoNHyphen;
                                    }
                                }
                                else if (e.Key == Keys.Up)
                                {
                                    e.NextCtrl = this.tNedit_GoodsMakerCd;
                                }

                            }
                        }
                        else
                        {
                            e.NextCtrl = this.ApplyEndDate_TDateEdit;
                        }

                        if (this.tNedit_GoodsMakerCd.Text != "")
                        {
                            this.tNedit_GoodsMakerCd.Text = this.tNedit_GoodsMakerCd.GetInt().ToString("0000");
                        }

                        break;
                    }

                // BLコード開始
                case ctGUIDE_NAME_BLGoodsCdSt:
                    {
                        // BLコード取得
                        // ----- UPD 2011/07/13 ------- >>>>>>>>>
                        //string blGoodsCd = this.tNedit_BLGoodsCode_St.Text;
                        int blGoodsCd = this.tNedit_BLGoodsCode_St.GetInt();

                        //if (blGoodsCd == "")
                        if (blGoodsCd == 0)
                        {
                            this.tNedit_BLGoodsCode_St.Clear();
                            this.tEdit_BLGoodsName.Clear(); 
                        }
                        else
                        {
                            BLGoodsCdUMnt blGoodsCdUMnt = null;
                            // BLコード表示
                            int status = this._blGoodsCdAcs.Read(out blGoodsCdUMnt, this._enterpriseCode, blGoodsCd);

                            if (status == 0)
                            {
                                this.tEdit_BLGoodsName.Text = blGoodsCdUMnt.BLGoodsHalfName;
                            }
                            else
                            {
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                    this.Name,
                                    "BLコードが存在しません。",
                                    -1,
                                    MessageBoxButtons.OK
                                );
                                this.tNedit_BLGoodsCode_St.Text = this._prebLGoodsCode;
                                this.tEdit_BLGoodsName.Text = this._prebLGoodsName;
                                e.NextCtrl = this.tNedit_BLGoodsCode_St;
                                e.NextCtrl.Select();
                                break;
                            }
                        }

                        this._prebLGoodsCode = this.tNedit_BLGoodsCode_St.Text.Trim();
                        this._prebLGoodsName = this.tEdit_BLGoodsName.Text.Trim();
                        // ----- UPD 2011/07/13 ------- <<<<<<<<<

                        if (e.ShiftKey == false)
                        {
                            // 入力無し
                            if (string.IsNullOrEmpty(this.tNedit_BLGoodsCode_St.Text.Trim()))
                            {
                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                {
                                    e.NextCtrl = this.BLGoodsCdFrm_Button;
                                }
                            }
                            else
                            {
                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                {
                                    // ----- UPD 2011/07/13 ------- <<<<<<<<<
                                    //e.NextCtrl = this.tNedit_BLGoodsCode_Ed;
                                    e.NextCtrl = this.CampaignCode_tNedit;
                                    // ----- UPD 2011/07/13 ------- >>>>>>>>>
                                }
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Return || e.Key == Keys.Tab)
                            {
                                e.NextCtrl = this.tEdit_gNoNHyphen;
                            }
                        }

                        if (this.tNedit_BLGoodsCode_St.Text != "")
                        {
                            this.tNedit_BLGoodsCode_St.Text = this.tNedit_BLGoodsCode_St.GetInt().ToString("000000");
                        }
                        break;
                    }

                // ----- DEL 2011/07/13 ------- >>>>>>>>>
                // BLコード終了
                //case ctGUIDE_NAME_BLGoodsCdEd:
                //    {
                //        // BLコード取得
                //        string blGoodsCd = this.tNedit_BLGoodsCode_Ed.Text;
                //        if (blGoodsCd == "")
                //        {
                //            this.tNedit_BLGoodsCode_Ed.Clear();
                //        }

                //        if (e.ShiftKey == false)
                //        {
                //            // 入力無し
                //            if (string.IsNullOrEmpty(this.tNedit_BLGoodsCode_Ed.Text.Trim()))
                //            {
                //                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                //                {
                //                    e.NextCtrl = this.BLGoodsCdTo_Button;
                //                }
                //            }
                //            else
                //            {
                //                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                //                {
                //                    e.NextCtrl = this.CampaignCode_tNedit;
                //                }
                //            }
                //        }
                //        else
                //        {
                //            // 入力無し
                //            if (string.IsNullOrEmpty(this.tNedit_BLGoodsCode_St.Text.Trim()))
                //            {
                //                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                //                {
                //                    e.NextCtrl = this.BLGoodsCdFrm_Button;
                //                }
                //            }
                //            else
                //            {
                //                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                //                {
                //                    e.NextCtrl = this.tNedit_BLGoodsCode_St;
                //                }
                //            }
                //        }

                //        if (e.ShiftKey == false)
                //        {
                //            if (e.Key == Keys.Down)
                //            {
                //                e.NextCtrl = this.uButton_CampaignCode;
                //            }
                //        }

                //        if (this.tNedit_BLGoodsCode_Ed.Text != "")
                //        {
                //            this.tNedit_BLGoodsCode_Ed.Text = this.tNedit_BLGoodsCode_Ed.GetInt().ToString("000000");
                //        }
                //        break;
                //    }
                // ----- DEL 2011/07/13 ------- <<<<<<<<<

                //　キャンペーンコード
                case ctGUIDE_NAME_CampaignCode:
                    {
                        if (this.CampaignCode_tNedit.Text.ToString() != string.Empty)
                        {
                            int status = 0;
                            CampaignSt campaignSt = new CampaignSt();
                            campaignSt.EnterpriseCode = this._enterpriseCode;
                            campaignSt.CampaignCode = this.CampaignCode_tNedit.GetInt();
                            status = this._campaignGoodsStAcs.SearchCampaignSt(ref campaignSt);
                            if (status == 0)
                            {

                                if (this._precampaignCode != this.CampaignCode_tNedit.GetInt().ToString().Trim())
                                {
                                    this.CampaignName_tEdit.Text = campaignSt.CampaignName;
                                    this.CampaignObjDiv_tComboEditor.SelectedIndex = campaignSt.CampaignObjDiv;
                                    this.ApplyStaDate_TDateEdit.SetDateTime(campaignSt.ApplyStaDate);
                                    this.ApplyEndDate_TDateEdit.SetDateTime(campaignSt.ApplyEndDate);
                                    this.tEdit_SectionCodeAllowZero.Text = campaignSt.SectionCode.ToString().Trim();
                                    // 拠点名称取得
                                    this.SectionName_tEdit.Text = GetSectionName(campaignSt.SectionCode);
                                }
                                
                            }
                            else
                            {
                                if (this._precampaignCode != this.CampaignCode_tNedit.GetInt().ToString().Trim())
                                {
                                    InitialScreenData();
                                }
                            }

                            if (this._precampaignCode != this.CampaignCode_tNedit.GetInt().ToString().Trim())
                            {
                                status = this._campaignGoodsStAcs.SearchCustomer(this.CampaignCode_tNedit.GetInt());

                                if (status == 0)
                                {
                                    this._campaignLinklist = new ArrayList();

                                    this._campaignLinklist = this._campaignGoodsStAcs._precampaignLinkList;
                                }
                                else
                                {
                                    this._campaignLinklist = new ArrayList();
                                    this._campaignGoodsStAcs._precampaignLinkList = null;
                                }
                            }
                        }
                        else
                        {
                            InitialScreenData();
                        }

                        this._precampaignCode = this.CampaignCode_tNedit.GetInt().ToString().Trim();

                        if (e.ShiftKey == false)
                        {
                            // 入力無し
                            if (string.IsNullOrEmpty(this.CampaignCode_tNedit.Text.Trim()))
                            {
                                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                {
                                    if (this._retgraflag != 1)
                                    {
                                        this._retgraflag = 0;
                                        // フォーカス設定
                                        e.NextCtrl = this.uButton_CampaignCode;
                                    }
                                   
                                }
                            }
                            else
                            {
                                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                {
                                    if (this._retgraflag != 1)
                                    {
                                        this._retgraflag = 0;
                                        // フォーカス設定
                                        e.NextCtrl = this.CampaignName_tEdit;
                                    } 
                                }
                            }
                        }
                        else
                        {
                            // 入力無し
                            // ----- UPD 2011/07/13 ------- >>>>>>>>>
                            //if (string.IsNullOrEmpty(this.tNedit_BLGoodsCode_Ed.Text.Trim()))
                            if (string.IsNullOrEmpty(this.tNedit_BLGoodsCode_St.Text.Trim()))
                            {
                                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                {
                                    // フォーカス設定
                                    //e.NextCtrl = this.BLGoodsCdTo_Button;
                                    e.NextCtrl = this.BLGoodsCdFrm_Button;
                                }
                            }
                            else
                            {
                                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                {
                                    // フォーカス設定
                                    //e.NextCtrl = this.tNedit_BLGoodsCode_Ed;
                                    e.NextCtrl = this.tNedit_BLGoodsCode_St;
                                }
                            }
                            // ----- UPD 2011/07/13 ------- <<<<<<<<<
                        }
                        if (this.CampaignCode_tNedit.Text != "")
                        {
                            this.CampaignCode_tNedit.Text = this.CampaignCode_tNedit.GetInt().ToString("000000");
                            if (this.CampaignCode_tNedit.GetInt() == 0)
                            {
                                this.CampaignCode_tNedit.Text = "";
                            }
                        }
                        break;
                    }
                
                //対象得意先設定 
                case "CampaignObjDiv_tComboEditor":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // フォーカス設定
                                e.NextCtrl = this.ApplyStaDate_TDateEdit;
                            }
                            else if (e.Key == Keys.Right && this.CampaignObjDiv_Button.Enabled == false)
                            {
                                e.NextCtrl = this.CampaignObjDiv_tComboEditor;
                            }

                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // フォーカス設定
                                e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                            }

                        }

                        break;
                    }

                // 適用日開始
                case "ApplyStaDate_TDateEdit":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // フォーカス設定
                                e.NextCtrl = this.ApplyEndDate_TDateEdit;
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // フォーカス設定
                                e.NextCtrl = this.CampaignObjDiv_tComboEditor;
                            }

                        }
                        break;
                    }
                // 適用日終了  
                case "ApplyEndDate_TDateEdit":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // フォーカス設定
                                e.NextCtrl = this.tNedit_GoodsMakerCd;
                            }
                            else if (e.Key == Keys.Up && this.CampaignObjDiv_Button.Enabled == false)
                            {
                                e.NextCtrl = this.CampaignObjDiv_tComboEditor;
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // フォーカス設定
                                e.NextCtrl = this.ApplyStaDate_TDateEdit;
                            }

                        }
                        break;
                    }
                //　頭品番
                case "tEdit_gNoNHyphen":
                    {
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Down)
                            {
                                e.NextCtrl = this.tNedit_BLGoodsCode_St;
                            }
                            else if (e.Key == Keys.Right)
                            {
                                e.NextCtrl = this.tEdit_gNoNHyphen;
                            }
                        }
                        else
                        {
                            // 入力無し
                            if (string.IsNullOrEmpty(this.tNedit_GoodsMakerCd.Text.Trim()))
                            {
                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                {
                                    e.NextCtrl = this.uButton_GoodsMakerCd;
                                }
                            }
                            else
                            {
                                e.NextCtrl = this.tNedit_GoodsMakerCd;
                            }
                        }

                        break;
                    }
                    
            }

            this._prevControl = e.NextCtrl;

            // ガイドボタンツール有効無効設定処理
            if ((e.NextCtrl != null) && (e.NextCtrl.TabStop) && this._retgraflag == 0)
            {
                this.SettingGuideButtonToolEnabled(e.NextCtrl);
            }

            this._retgraflag = 0;
            this._retKeyFlag = 1;
        }

        /// <summary>
        /// GroupCollapsing イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note		: UltraExplorerBarGroup が縮小される前に発生します。</br>
        /// <br>Programmer  : 鄧潘ハン</br>
        /// <br>Date        : 2011/05/20</br>
        /// </remarks>
        private void ultraExplorerBar1_GroupCollapsing(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == "SearchGroup") ||
                (e.Group.Key == "SetContestGroup") ||
                (e.Group.Key == "ResultSettingGroup"))
            {
                // グループの縮小をキャンセル
                e.Cancel = true;
            }
        }

        /// <summary>
        /// GroupExpanding イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note		: UltraExplorerBarGroup が展開される前に発生します。</br>
        /// <br>Programmer  : 鄧潘ハン</br>
        /// <br>Date        : 2011/05/20</br>
        /// </remarks>
        private void ultraExplorerBar1_GroupExpanding(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == "SearchGroup") ||
                (e.Group.Key == "SetContestGroup") ||
                (e.Group.Key == "ResultSettingGroup"))
            {
                // グループの展開をキャンセル
                e.Cancel = true;
            }
        }

        # endregion

        #region ◎ オフライン状態チェック処理
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