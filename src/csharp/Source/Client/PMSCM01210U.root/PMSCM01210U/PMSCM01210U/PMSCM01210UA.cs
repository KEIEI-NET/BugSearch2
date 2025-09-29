//****************************************************************************//
// システム         : PM.NS                                                   //
// プログラム名称   : 売上データ抽出処理                                      //
// プログラム概要   : 売上データ抽出処理                                      //
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.                       //
//============================================================================//
// 履歴                                                                       //
//----------------------------------------------------------------------------//
// 管理番号              作成担当 :  高影                                     //
// 作 成 日  2011/07/29  修正内容 : 新規作成                                  //
//----------------------------------------------------------------------------//
// 管理番号              作成担当 :                                           //
// 修 正 日              修正内容 :                                           //
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
using System.IO;

namespace Broadleaf.Windows.Forms
{

    /// <summary>
    /// 売上データ抽出処理フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上データ抽出処理を行います。</br>
    /// <br>Programmer : 高影</br>
    /// <br>Date       : 2011/07/29</br>
    /// </remarks>
    public partial class PMSCM01210UA : Form
    {

        # region << Private Members >>

        // ツールバーツールキー設定
        private const string TOOLBAR_CLOSEBUTTON_KEY = "ButtonTool_Close";
        private const string TOOLBAR_UPDATEBUTTON_KEY = "ButtonTool_Update";

        private const string TOOLBAR_LOGINSECTIONLABLE_KEY = "LabelTool_LoginTitle";
        private const string TOOLBAR_LOGINNAMELABLE_KEY = "LabelTool_LoginName";

        private const int INIT_MODE = 0;
        private const int SEARCH_MODE = 1;

        private string CT_PGID = "PMSCM01210U";             // クラス名

        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;           // 終了ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _updateButton;          // 更新ボタン
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginTitleLabel;        // ログイン担当者Title
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginNameLabel;         // ログイン担当者名称

        private string _enterpriseCode;                     //企業コード
        private string _sectionCode;                        //拠点コード

        private SecInfoAcs _secInfoAcs;                     // 拠点情報アクセスクラス
        private SecInfoSetAcs _secInfoSetAcs = null;        // 拠点アクセスクラス

        private InpDisplay _inpDisplay;                     //画面データクラス
        private SndAndRcvProcAcs _sndAndRcvProcAcs;         //自動送受信バッチアクセスクラス

        private PM7RkSettingAcs _pM7RkSettingAcs;           //PM7連携全体設定アクセスクラス
        private PM7RkSetting _pM7RkSetting;                 //PM7連携全体設定マスタ

        private DateGetAcs _dateGet;

        private InpDisplay _para;

        private SalesSlipSearchAcs _salesSlipSearchAcs;

        private SFCMN00299CA _progressForm;

        # endregion

        #region << Constructor >>

        /// <summary>
        /// 売上データ抽出処理フォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note		: 売上データ抽出処理フォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer	: 高影</br>
        /// <br>Date		: 2011/07/29</br>
        /// </remarks>
        public PMSCM01210UA()
        {
            InitializeComponent();

            //企業コード取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            //拠点コード取得
            this._sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;

            this._secInfoSetAcs = new SecInfoSetAcs();
            this._secInfoAcs = new SecInfoAcs();

            //自動送受信バッチアクセスクラス
            this._sndAndRcvProcAcs = new SndAndRcvProcAcs();
            //画面データクラス
            this._inpDisplay = new InpDisplay();
            //PM7連携全体設定アクセスクラス
            this._pM7RkSettingAcs = new PM7RkSettingAcs();

            //PM7連携全体設定マスタ
            this._pM7RkSetting = new PM7RkSetting();
            this._pM7RkSetting.EnterpriseCode = this._enterpriseCode;
            this._pM7RkSetting.SectionCode = this._sectionCode;

            this._para = new InpDisplay();

            this._salesSlipSearchAcs = new SalesSlipSearchAcs();
        }

        #endregion

        #region << Private Methods >>

        /// <summary>
        /// 初期画面設定
        /// </summary>
        /// <remarks>
        /// <br>Note        : 画面初期化時に発生します。</br>      
        /// <br>Programmer  : 高影</br>
        /// <br>Date        : 2011/07/29</br>
        /// </remarks> 
        private void InitialScreenSetting()
        {
            SectionSt_DirGuide_uButton.ImageList = IconResourceManagement.ImageList16;
            SectionSt_DirGuide_uButton.Appearance.Image = (int)Size16_Index.STAR1;
            SectionEd_DirGuide_uButton.ImageList = IconResourceManagement.ImageList16;
            SectionEd_DirGuide_uButton.Appearance.Image = (int)Size16_Index.STAR1;

            CustomerSt_DirGuide_uButton.ImageList = IconResourceManagement.ImageList16;
            CustomerSt_DirGuide_uButton.Appearance.Image = (int)Size16_Index.STAR1;
            CustomerEd_DirGuide_uButton.ImageList = IconResourceManagement.ImageList16;
            CustomerEd_DirGuide_uButton.Appearance.Image = (int)Size16_Index.STAR1;

            TextSaveFolder_DirGuide_uButton.ImageList = IconResourceManagement.ImageList16;
            TextSaveFolder_DirGuide_uButton.Appearance.Image = (int)Size16_Index.STAR1;
            
            // ツールバー初期設定処理
            this.ToolBarInitilSetting();
        }

        /// <summary>
        /// ツールバー初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 画面初期化時、ツールバー初期設定処理を行います。</br>
        /// <br>Programmer  : 高影</br>
        /// <br>Date        : 2011/07/29</br>
        /// </remarks> 
        private void ToolBarInitilSetting()
        {
            this.tToolbarsManager_MainMenu.ImageListSmall = IconResourceManagement.ImageList16;

            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this._updateButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
            this._loginTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;
        }

        /// <summary>
        /// ツールバークリック更新処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : ツールバークリック時更新処理を行う。</br>
        /// <br>Programmer : 高影</br>
        /// <br>Date       : 2011/07/29</br>
        /// </remarks>
        private bool UpdateProc()
        {
            bool result = false;

            Control control = null;
            string errorMessage = "";
            if (this.ScreenDataCheck(ref control, ref errorMessage) == false)
            {
                // 入力チェック
                TMsgDisp.Show(
                    this,                                  // 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_INFO,    // エラーレベル
                    CT_PGID,                               // アセンブリＩＤまたはクラスＩＤ
                    errorMessage,                               // 表示するメッセージ
                    0,                                     // ステータス値
                    MessageBoxButtons.OK);                // 表示するボタン

                // コントロールを選択
                control.Focus();
                if (control is TEdit)
                {
                    ((TEdit)control).SelectAll();
                }
                if (control is TNedit)
                {
                    ((TNedit)control).SelectAll();
                }
                return result;
            }
            if (this.TextSaveFolderCheck() == false)
            {
                return result;
            }

            try
            {
                _progressForm = new SFCMN00299CA();
                _progressForm.Title = "売上データ抽出処理";
                _progressForm.Message = "只今、売上データ抽出処理中です．．．";

                Int32 outSalesTotal = 0;
                string errMsg = "";
                SndAndRcvProcAcs pMSCM01201A = new SndAndRcvProcAcs();
                this.GetDisplay();
                Int32 SalesDateSt = Int32.Parse(this._inpDisplay.SalesDateSt.ToString("yyyyMMdd"));
                Int32 SalesDateEd = Int32.Parse(this._inpDisplay.SalesDateEd.ToString("yyyyMMdd"));
                Int32 InpDateSt = Int32.Parse(this._inpDisplay.InpDateSt.ToString("yyyyMMdd"));
                Int32 InpDateEd = Int32.Parse(this._inpDisplay.InpDateEd.ToString("yyyyMMdd"));
                if (InpDateSt == Int32.Parse(DateTime.MinValue.ToString("yyyyMMdd")))
                {
                    InpDateSt = 0;
                }
                if (InpDateEd == Int32.Parse(DateTime.MinValue.ToString("yyyyMMdd")))
                {
                    InpDateEd = 0;
                }

                Int32 SectionCodeSt = 0;
                if (this._inpDisplay.SectionCodeSt != "")
                {
                    SectionCodeSt = Int32.Parse(this._inpDisplay.SectionCodeSt);
                }
                else
                {
                    SectionCodeSt = 0;
                }
                Int32 SectionCodeEd = 0;
                if (this._inpDisplay.SectionCodeEd != "")
                {
                    SectionCodeEd = Int32.Parse(this._inpDisplay.SectionCodeEd);
                }
                else
                {
                    SectionCodeEd = 0;
                }

                _progressForm.Show(this);

                int status = pMSCM01201A.SearchAndTextout(0,
                SalesDateSt,
                SalesDateEd,
                InpDateSt,
                InpDateEd,
                SectionCodeSt,
                SectionCodeEd,
                this._inpDisplay.CustomerCodeSt,
                this._inpDisplay.CustomerCodeEd,
                this._inpDisplay.SlipNoSt,
                this._inpDisplay.SlipNoEd,
                this._inpDisplay.TextSaveFolder,
                ref outSalesTotal,
                ref errMsg);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    OutpCount_ultraLabel.Text = outSalesTotal.ToString("#,##0");
                    result = true;
                }
                else if (status == (int)ConstantManagement.DB_Status.ctDB_ERROR)
                {
                    if (_progressForm != null)
                    {
                        _progressForm.Close();
                        _progressForm = null;
                    }
                    TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    errMsg,
                    -1,
                    MessageBoxButtons.OK);
                    OutpCount_ultraLabel.Text = "0";
                }
                else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    if (_progressForm != null)
                    {
                        _progressForm.Close();
                        _progressForm = null;
                    }
                    TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "対象データがありません。",
                    -1,
                    MessageBoxButtons.OK);
                    OutpCount_ultraLabel.Text = "0";
                }
                else
                {
                    OutpCount_ultraLabel.Text = "0";
                }

            }
            finally
            {
                if (_progressForm != null)
                {
                    _progressForm.Close();
                    _progressForm = null;
                }
            }

            Refresh();
            return result;
        }

        #endregion

        #region << 画面データクラス格納処理 >>

        /// <summary>
        /// 画面→画面データクラス格納処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面→画面データクラス格納処理を行います。</br>
        /// <returns></returns>
        /// <br>Programmer : 高影</br>
        /// <br>Date       : 2011/07/29</br>
        /// </remarks>
        public InpDisplay GetDisplay()
        {
            this._inpDisplay = new InpDisplay();

            _inpDisplay.SalesDateSt = this.SalesDateSt_tDateEdit.GetDateTime();
            _inpDisplay.SalesDateEd = this.SalesDateEd_tDateEdit.GetDateTime();

            _inpDisplay.InpDateSt = this.InpDateSt_tDateEdit.GetDateTime();
            _inpDisplay.InpDateEd = this.InpDateEd_tDateEdit.GetDateTime();

            _inpDisplay.CustomerCodeSt = this.tNedit_CustomerCode_St.GetInt();
            _inpDisplay.CustomerNameSt = this.CustomerNameSt_tEdit.Text;

            _inpDisplay.CustomerCodeEd = this.tNedit_CustomerCode_Ed.GetInt();
            _inpDisplay.CustomerNameEd = this.CustomerNameEd_tEdit.Text;

            _inpDisplay.SectionCodeSt = this.tEdit_SectionCode_St.Text;
            _inpDisplay.SectionNameSt = this.SectionNameSt_tEdit.Text;

            _inpDisplay.SectionCodeEd = this.tEdit_SectionCode_Ed.Text;
            _inpDisplay.SectionNameEd = this.SectionNameEd_tEdit.Text;

            _inpDisplay.SlipNoSt = this.tNedit_SupplierSlipNo_St.GetInt();
            _inpDisplay.SlipNoEd = this.tNedit_SupplierSlipNo_Ed.GetInt();

            _inpDisplay.TextSaveFolder = this.TextSaveFolder_tEdit.Text;

            _inpDisplay.OutpCount = 0;

            return _inpDisplay;
        }

        #endregion

        # region << Control Events >>

        /// <summary>
        /// Form.Load イベント(PMSCM01210U)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note        : ユーザーがフォームを読み込むときに発生します。</br>
        /// <br>Programmer	: 高影</br>
        /// <br>Date        : 2011/07/29</br>
        /// </remarks>
        private void PMSCM01210U_Load(object sender, EventArgs e)
        {

            this._loginTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolbarsManager_MainMenu.Tools[TOOLBAR_LOGINSECTIONLABLE_KEY];
            this._loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolbarsManager_MainMenu.Tools[TOOLBAR_LOGINNAMELABLE_KEY];
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools[TOOLBAR_CLOSEBUTTON_KEY];
            this._updateButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools[TOOLBAR_UPDATEBUTTON_KEY];

            this._loginNameLabel.SharedProps.Caption = LoginInfoAcquisition.Employee.Name;

            this.SalesDateSt_tDateEdit.SetDateTime(DateTime.Now);
            this.SalesDateEd_tDateEdit.SetDateTime(DateTime.Now);

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            try
            {
                status = this._pM7RkSettingAcs.Read(ref this._pM7RkSetting);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this.TextSaveFolder_tEdit.Text = this._pM7RkSetting.TextSaveFolder;
                }
                else
                {
                    this.TextSaveFolder_tEdit.Text = "";
                }
            }
            catch (Exception)
            {
                this.TextSaveFolder_tEdit.Text = "";
            }

            // 画面初期化
            this.InitialScreenSetting();
        }

        /// <summary>
        /// ツールバークリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : ツールバークリック時に発生します。</br>
        /// <br>Programmer : 高影</br>
        /// <br>Date       : 2011/07/29</br>
        /// </remarks>
        private void tToolbarsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                // 終了処理
                case TOOLBAR_CLOSEBUTTON_KEY:
                    {
                        Close();
                        break;
                    }
                // 更新処理
                case TOOLBAR_UPDATEBUTTON_KEY:
                    {
                        bool result = this.UpdateProc();
                        if (!result)
                        {
                            return;
                        }
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
        /// <br>Programmer : 高影</br>
        /// <br>Date       : 2011/07/29</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            InpDisplay para = this._para.Clone();

            switch (e.PrevCtrl.Name)
            {
                // 拠点コードFrom
                case "tEdit_SectionCode_St":
                    {
                        //------------------------------------
                        // 拠点ゼロコード取得
                        //------------------------------------
                        UiSet uiset;
                        uiSetControl1.ReadUISet(out uiset, tEdit_SectionCode_St.Name);
                        string sectionCodeZero = new string('0', uiset.Column);

                        //------------------------------------
                        // 拠点コード取得
                        //------------------------------------
                        string sectionCode = this.tEdit_SectionCode_St.Text.TrimEnd();

                        if (this.tEdit_SectionCode_St.GetInt() == 0)
                        {
                            sectionCode = "";
                            this.tEdit_SectionCode_St.Text = "";
                            this.SectionNameSt_tEdit.Text = "";
                            this._para.SectionCodeSt = "";
                            this._para.SectionNameSt = "";
                        }

                        if (sectionCode.Length == 1)
                        {
                            sectionCode = "0" + sectionCode;
                        }

                        if (sectionCode != para.SectionCodeSt)
                        {

                            //------------------------------------
                            // 検索
                            //------------------------------------
                            if (sectionCode != string.Empty && sectionCode != sectionCodeZero)
                            {
                                if (_secInfoSetAcs == null)
                                {
                                    _secInfoSetAcs = new SecInfoSetAcs();
                                }
                                SecInfoSet sectionInfo;
                                int status = this._secInfoSetAcs.Read(out sectionInfo, this._enterpriseCode, sectionCode);
                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    // パラメータに保存
                                    this._para.SectionCodeSt = sectionInfo.SectionCode.TrimEnd();
                                    this._para.SectionNameSt = sectionInfo.SectionGuideNm.TrimEnd();

                                    if (sectionInfo.LogicalDeleteCode == 1)
                                    {
                                        this.SectionNameSt_tEdit.Text = "";
                                        this._para.SectionNameSt = "";
                                    }
                                    else
                                    {
                                        this.SectionNameSt_tEdit.Text = this._para.SectionNameSt;
                                    }
                                    e.NextCtrl = tEdit_SectionCode_Ed;
                                }
                                else if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) ||
                                    (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "該当する拠点が存在しません。",
                                        status,
                                        MessageBoxButtons.OK);

                                    this.tEdit_SectionCode_St.Text = this._para.SectionCodeSt;
                                    this.SectionNameSt_tEdit.Text = this._para.SectionNameSt;
                                    e.NextCtrl = e.PrevCtrl;
                                }
                                else
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_STOPDISP,
                                        this.Name,
                                        "拠点名の取得に失敗しました。",
                                        status,
                                        MessageBoxButtons.OK);

                                    this.tEdit_SectionCode_St.Text = this._para.SectionCodeSt;
                                }
                            }
                        }

                    }
                    break;

                // 拠点コードTo
                case "tEdit_SectionCode_Ed":
                    {
                        //------------------------------------
                        // 拠点ゼロコード取得
                        //------------------------------------
                        UiSet uiset;
                        uiSetControl1.ReadUISet(out uiset, tEdit_SectionCode_Ed.Name);
                        string sectionCodeZero = new string('0', uiset.Column);

                        //------------------------------------
                        // 拠点コード取得
                        //------------------------------------
                        string sectionCode = this.tEdit_SectionCode_Ed.Text.TrimEnd();

                        if (this.tEdit_SectionCode_Ed.GetInt() == 0)
                        {
                            sectionCode = "";
                            this.tEdit_SectionCode_Ed.Text = "";
                            this.SectionNameEd_tEdit.Text = "";
                            this._para.SectionCodeEd = "";
                            this._para.SectionNameEd = "";
                        }

                        if (sectionCode.Length == 1)
                        {
                            sectionCode = "0" + sectionCode;
                        }

                        if (sectionCode != para.SectionCodeEd)
                        {

                            //------------------------------------
                            // 検索
                            //------------------------------------
                            if (sectionCode != string.Empty && sectionCode != sectionCodeZero)
                            {
                                if (_secInfoSetAcs == null)
                                {
                                    _secInfoSetAcs = new SecInfoSetAcs();
                                }
                                SecInfoSet sectionInfo;
                                int status = this._secInfoSetAcs.Read(out sectionInfo, this._enterpriseCode, sectionCode);
                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    // パラメータに保存
                                    this._para.SectionCodeEd = sectionInfo.SectionCode.TrimEnd();
                                    this._para.SectionNameEd = sectionInfo.SectionGuideNm.TrimEnd();

                                    if (sectionInfo.LogicalDeleteCode == 1)
                                    {
                                        this.SectionNameEd_tEdit.Text = "";
                                        this._para.SectionNameEd = "";
                                    }
                                    else
                                    {
                                        this.SectionNameEd_tEdit.Text = this._para.SectionNameEd;
                                    }
                                    e.NextCtrl = tNedit_CustomerCode_St;
                                }
                                else if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) ||
                                    (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "該当する拠点が存在しません。",
                                        status,
                                        MessageBoxButtons.OK);

                                    this.tEdit_SectionCode_Ed.Text = this._para.SectionCodeEd;
                                    this.SectionNameEd_tEdit.Text = this._para.SectionNameEd;
                                    e.NextCtrl = e.PrevCtrl;
                                }
                                else
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_STOPDISP,
                                        this.Name,
                                        "拠点名の取得に失敗しました。",
                                        status,
                                        MessageBoxButtons.OK);

                                    this.tEdit_SectionCode_Ed.Text = this._para.SectionCodeEd;
                                }
                            }
                        }

                    }
                    break;

                //得意先コードFrom
                case "tNedit_CustomerCode_St":
                    {
                        int code = this.tNedit_CustomerCode_St.GetInt();

                        if (para.CustomerCodeSt != code)
                        {
                            if (code == 0)
                            {
                                this._para.CustomerCodeSt = 0;
                                this._para.CustomerNameSt = "";
                                this.tNedit_CustomerCode_St.Text = "";
                                this.CustomerNameSt_tEdit.Text = "";
                            }
                            else
                            {
                                CustomerInfo data;
                                int status = this._salesSlipSearchAcs.GetCustomer(this._enterpriseCode, code, out data);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    this._para.CustomerCodeSt = data.CustomerCode;
                                    this._para.CustomerNameSt = data.Name + " " + data.Name2;

                                    this.CustomerNameSt_tEdit.Text = this._para.CustomerNameSt;
                                    e.NextCtrl = tNedit_CustomerCode_Ed;
                                }
                                else if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) ||
                                    (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "該当する得意先が存在しません。",
                                        status,
                                        MessageBoxButtons.OK);

                                    if (this._para.CustomerCodeSt == 0)
                                    {
                                        this.tNedit_CustomerCode_St.Text = "";
                                    }
                                    else
                                    {
                                        this.tNedit_CustomerCode_St.Text = this._para.CustomerCodeSt.ToString();
                                    }
                                    this.CustomerNameSt_tEdit.Text = this._para.CustomerNameSt;
                                    e.NextCtrl = e.PrevCtrl;
                                }
                                else
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_STOPDISP,
                                        this.Name,
                                        "得意先名称の取得に失敗しました。",
                                        status,
                                        MessageBoxButtons.OK);
                                    this.tNedit_CustomerCode_St.Text = this._para.CustomerCodeSt.ToString();
                                }
                            }
                        }
                        break;
                    }

                // 得意先コードTo
                case "tNedit_CustomerCode_Ed":
                    {
                        int code = this.tNedit_CustomerCode_Ed.GetInt();

                        if (para.CustomerCodeEd != code)
                        {
                            if (code == 0)
                            {
                                this._para.CustomerCodeEd = 0;
                                this._para.CustomerNameEd = "";

                                this.tNedit_CustomerCode_Ed.Text = "";
                                this.CustomerNameEd_tEdit.Text = "";
                            }
                            else
                            {
                                CustomerInfo data;
                                int status = this._salesSlipSearchAcs.GetCustomer(this._enterpriseCode, code, out data);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    this._para.CustomerCodeEd = data.CustomerCode;
                                    this._para.CustomerNameEd = data.Name + " " + data.Name2;

                                    this.CustomerNameEd_tEdit.Text = this._para.CustomerNameEd;
                                    e.NextCtrl = tNedit_SupplierSlipNo_St;
                                }
                                else if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) ||
                                    (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "該当する得意先が存在しません。",
                                        status,
                                        MessageBoxButtons.OK);

                                    if (this._para.CustomerCodeEd == 0)
                                    {
                                        this.tNedit_CustomerCode_Ed.Text = "";
                                    }
                                    else
                                    {
                                        this.tNedit_CustomerCode_Ed.Text = this._para.CustomerCodeEd.ToString();
                                    }
                                    this.CustomerNameEd_tEdit.Text = this._para.CustomerNameEd;
                                    e.NextCtrl = e.PrevCtrl;
                                }
                                else
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_STOPDISP,
                                        this.Name,
                                        "得意先名称の取得に失敗しました。",
                                        status,
                                        MessageBoxButtons.OK);
                                    this.tNedit_CustomerCode_Ed.Text = this._para.CustomerCodeEd.ToString();
                                }
                            }
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// GroupExpanding イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note		: UltraExplorerBarGroup が展開される前に発生します。</br>
        /// <br>Programmer  : 高影</br>
        /// <br>Date        : 2011/07/29</br>
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
        /// <br>Programmer  : 高影</br>
        /// <br>Date        : 2011/07/29</br>
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

        /// <summary>
        /// Control.Click イベント(SectionSt_DirGuide_uButton)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 拠点Fromガイドボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 高影</br>
        /// <br>Date       : 2011/07/29</br>
        /// </remarks>
        private void SectionSt_DirGuide_uButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status;
                SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
                SecInfoSet secInfoSet = new SecInfoSet();

                status = secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out secInfoSet);
                if (status == 0)
                {
                    // 設定値を保存
                    this.tEdit_SectionCode_St.Text = secInfoSet.SectionCode.Trim();
                    this.SectionNameSt_tEdit.Text = secInfoSet.SectionGuideNm.Trim();
                    this.tEdit_SectionCode_Ed.Focus();
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;

            }
        }

        /// <summary>
        /// Control.Click イベント(SectionEd_DirGuide_uButton)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 拠点Toガイドボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 高影</br>
        /// <br>Date       : 2011/07/29</br>
        /// </remarks>
        private void SectionEd_DirGuide_uButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status;
                SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
                SecInfoSet secInfoSet = new SecInfoSet();

                status = secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out secInfoSet);
                if (status == 0)
                {
                    // 設定値を保存
                    this.tEdit_SectionCode_Ed.Text = secInfoSet.SectionCode.Trim();
                    this.SectionNameEd_tEdit.Text = secInfoSet.SectionGuideNm.Trim();
                    this.tNedit_CustomerCode_St.Focus();
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;

            }
        }

        /// <summary>
        /// Control.Click イベント(CustomerSt_DirGuide_uButton)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 得意先Toガイドボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 高影</br>
        /// <br>Date       : 2011/07/29</br>
        /// </remarks>
        private void CustomerSt_DirGuide_uButton_Click(object sender, EventArgs e)
        {
            // 得意先ガイド用ライブラリ名変更
            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);	// 得意先検索アクセスクラス
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect1);
            DialogResult ret = customerSearchForm.ShowDialog(this);
            this.tNedit_CustomerCode_Ed.Focus();
        }

        /// <summary>
        /// Control.Click イベント(CustomerEd_DirGuide_uButton)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 得意先Toガイドボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 高影</br>
        /// <br>Date       : 2011/07/29</br>
        /// </remarks>
        private void CustomerEd_DirGuide_uButton_Click(object sender, EventArgs e)
        {
            // 得意先ガイド用ライブラリ名変更
            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);	// 得意先検索アクセスクラス
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect2);
            DialogResult ret = customerSearchForm.ShowDialog(this);
            this.tNedit_SupplierSlipNo_St.Focus();
        }

        /// <summary>
        /// 得意先選択時発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="customerSearchRet">得意先検索戻り値クラス</param>
        /// <remarks>
        /// <br>Note       : 得意先選択時発生イベント処理を行います。</br>
        /// <br>Programmer : 高影</br>
        /// <br>Date       : 2011/07/29</br>
        /// </remarks>
        private void CustomerSearchForm_CustomerSelect1(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null)
            {
                return;
            }

            this._inpDisplay.CustomerCodeSt = customerSearchRet.CustomerCode;                    // 得意先コード
            this._inpDisplay.CustomerNameSt = customerSearchRet.Name + customerSearchRet.Name2;   // 得意先名称

            this.tNedit_CustomerCode_St.SetInt(this._inpDisplay.CustomerCodeSt);
            this.CustomerNameSt_tEdit.Text = this._inpDisplay.CustomerNameSt;

            // 結果
            ((PMKHN04005UA)sender).DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// 得意先選択時発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="customerSearchRet">得意先検索戻り値クラス</param>
        /// <remarks>
        /// <br>Note       : 得意先選択時発生イベント処理を行います。</br>
        /// <br>Programmer : 高影</br>
        /// <br>Date       : 2011/07/29</br>
        /// </remarks>
        private void CustomerSearchForm_CustomerSelect2(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null)
            {
                return;
            }

            this._inpDisplay.CustomerCodeEd = customerSearchRet.CustomerCode;                    // 得意先コード
            this._inpDisplay.CustomerNameEd = customerSearchRet.Name + customerSearchRet.Name2;   // 得意先名称

            this.tNedit_CustomerCode_Ed.SetInt(this._inpDisplay.CustomerCodeEd);
            this.CustomerNameEd_tEdit.Text = this._inpDisplay.CustomerNameEd;

            // 結果
            ((PMKHN04005UA)sender).DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Control.Click イベント(TextSaveFolder_DirGuide_uButton)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : テキスト格納フォルダボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 高影</br>
        /// <br>Date       : 2011.07.29</br>
        /// </remarks>
        private void TextSaveFolder_DirGuide_uButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();

            dlg.RootFolder = Environment.SpecialFolder.Desktop;
            dlg.Description = "コンバートデータのフォルダを指定して下さい。";
            DialogResult ret = dlg.ShowDialog();
            if (ret == DialogResult.OK)
            {
                TextSaveFolder_tEdit.Text = dlg.SelectedPath;
            }
        }

        #endregion

        #region << 入力項目チェック >>

        /// <summary>
        /// 日付チェック処理呼び出し
        /// </summary>
        /// <param name="cdrResult"></param>
        /// <param name="tde_St_OrderDataCreateDate"></param>
        /// <param name="tde_Ed_OrderDataCreateDate"></param>
        /// <param name="mode"></param>
        /// <param name="ym"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 日付チェック処理呼び出しを行う。 </br>
        /// <br>Programmer : 高影</br>
        /// <br>Date       : 2011/07/29</br>
        /// </remarks>
        private bool CallCheckDateRange(out DateGetAcs.CheckDateRangeResult cdrResult, ref TDateEdit tde_St_OrderDataCreateDate, ref TDateEdit tde_Ed_OrderDataCreateDate, bool mode, int ym)
        {
            _dateGet = DateGetAcs.GetInstance();
            cdrResult = _dateGet.CheckDateRange(DateGetAcs.YmdType.YearMonth, ym, ref tde_St_OrderDataCreateDate, ref tde_Ed_OrderDataCreateDate, mode);
            return (cdrResult == DateGetAcs.CheckDateRangeResult.OK);
        }

        /// <summary>
        /// 入力項目チェック処理
        /// </summary>
        /// <param name="control"></param>
        /// <param name="errorMessage"></param>
        /// <returns>result</returns>
        /// <remarks>
        /// <br>Note       : 入力項目チェック処理を行う。 </br>
        /// <br>Programmer : 高影</br>
        /// <br>Date       : 2011/07/29</br>
        /// </remarks>
        private bool ScreenDataCheck(ref Control control, ref string errorMessage)
        {
            bool result = false;

            string kbnNm = SalesDate_ultraLabel.Text;

            DateGetAcs.CheckDateRangeResult cdrResult;

            //売上日（開始～終了）
            if (CallCheckDateRange(out cdrResult, ref SalesDateSt_tDateEdit, ref SalesDateEd_tDateEdit, true, 0) == false)
            {
                switch (cdrResult)
                {
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                        {
                            errorMessage = string.Format("開始" + kbnNm + "{0}", "の入力が不正です。");
                            control = this.SalesDateSt_tDateEdit;
                            return result;
                        }
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                        {
                            errorMessage = string.Format("終了" + kbnNm + "{0}", "の入力が不正です。");
                            control = this.SalesDateEd_tDateEdit;
                            return result;
                        }
                    case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                        {
                            errorMessage = string.Format(kbnNm + "{0}", "の範囲指定に誤りがあります。");
                            control = this.SalesDateSt_tDateEdit;
                            return result;
                        }
                }
            }

            kbnNm = this.InpDate_ultraLabel.Text;

            //入カ日（開始～終了）
            if (CallCheckDateRange(out cdrResult, ref InpDateSt_tDateEdit, ref InpDateEd_tDateEdit, true, 0) == false)
            {
                switch (cdrResult)
                {
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                        {
                            errorMessage = string.Format("開始" + kbnNm + "{0}", "の入力が不正です。");
                            control = this.InpDateSt_tDateEdit;
                            return result;
                        }
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                        {
                            errorMessage = string.Format("終了" + kbnNm + "{0}", "の入力が不正です。");
                            control = this.InpDateEd_tDateEdit;
                            return result;
                        }
                    case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                        {
                            errorMessage = string.Format(kbnNm + "{0}", "の範囲指定に誤りがあります。");
                            control = this.InpDateSt_tDateEdit;
                            return result;
                        }
                }
            }

            //必須入力チェック
            //売上日Ｆｒｏｍ
            if (this.SalesDateSt_tDateEdit.GetDateTime() == DateTime.MinValue)
            {
                control = this.SalesDateSt_tDateEdit;
                errorMessage = "開始売上日を入力してください。";
                return result;
            }
            //売上日Ｔｏ
            if (this.SalesDateEd_tDateEdit.GetDateTime() == DateTime.MinValue)
            {
                control = this.SalesDateEd_tDateEdit;
                errorMessage = "終了売上日を入力してください。";
                return result;
            }
            //テキスト格納フォルダ
            if (this.TextSaveFolder_tEdit.Text.Trim() == "")
            {
                this.TextSaveFolder_tEdit.Clear();
                control = this.TextSaveFolder_tEdit;
                errorMessage = "テキスト格納フォルダを入力してください。";
                return result;
            }

            //入力値指定範囲チェック
            //売上日
            if (this.SalesDateEd_tDateEdit.GetLongDate() != 0)
            {
                if (this.SalesDateSt_tDateEdit.GetLongDate() > this.SalesDateEd_tDateEdit.GetLongDate())
                {
                    control = this.SalesDateSt_tDateEdit;
                    errorMessage = "売上日の範囲指定に誤りがあります。";
                    return result;
                }
            }
            //入力日
            if (this.InpDateEd_tDateEdit.GetLongDate() != 0)
            {
                if (this.InpDateSt_tDateEdit.GetLongDate() > this.InpDateEd_tDateEdit.GetLongDate())
                {
                    control = this.InpDateSt_tDateEdit;
                    errorMessage = "入力日の範囲指定に誤りがあります。";
                    return result;
                }
            }
            //拠点
            if (this.tEdit_SectionCode_Ed.GetInt() != 0)
            {
                if (this.tEdit_SectionCode_St.GetInt() > this.tEdit_SectionCode_Ed.GetInt())
                {
                    control = this.tEdit_SectionCode_St;
                    errorMessage = "拠点の範囲指定に誤りがあります。";
                    return result;
                }
            }
            //得意先
            if (this.tNedit_CustomerCode_Ed.GetInt() != 0)
            {
                if (this.tNedit_CustomerCode_St.GetInt() > this.tNedit_CustomerCode_Ed.GetInt())
                {
                    control = this.tNedit_CustomerCode_St;
                    errorMessage = "得意先の範囲指定に誤りがあります。";
                    return result;
                }
            }
            //伝票番号
            if (this.tNedit_SupplierSlipNo_Ed.GetInt() != 0)
            {
                if (this.tNedit_SupplierSlipNo_St.GetInt() > this.tNedit_SupplierSlipNo_Ed.GetInt())
                {
                    control = this.tNedit_SupplierSlipNo_St;
                    errorMessage = "伝票番号の範囲指定に誤りがあります。";
                    return result;
                }
            }

            result = true;

            return result;
        }

        /// <summary>
        /// テキスト格納フォルダ存在性チェック
        /// </summary>
        /// <returns>result</returns>
        /// <remarks>
        /// <br>Note       : テキスト格納フォルダ存在性チェック処理を行う。 </br>
        /// <br>Programmer : 高影</br>
        /// <br>Date       : 2011/07/29</br>
        /// </remarks>
        private bool TextSaveFolderCheck()
        {
            bool result = true;
            //テキスト格納フォルダ存在性チェック
            if (!Directory.Exists(this.TextSaveFolder_tEdit.Text))
            {
                result = false;
                this.TextSaveFolder_tEdit.Clear();
                this.TextSaveFolder_tEdit.Focus();
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, Text,
                                "指定したフォルダが存在しません。", 0, MessageBoxButtons.OK);
                return result;
            }

            return result;
        }

        #endregion

    }
}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              