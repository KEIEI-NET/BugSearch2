//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : キャンペーン目標設定マスタ
// プログラム概要   : キャンペーン目標設定の登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 徐佳
// 作 成 日  2011/04/25  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  10700008-00 作成担当 : 譚洪
// 修 正 日  2011/07/05  修正内容 : Redmine#22743 目標値が全て0でも登録可能の対応
//----------------------------------------------------------------------------//
// 管理番号  10700008-00 作成担当 : 譚洪
// 修 正 日  2011/07/05  修正内容 : Redmine#22750 フォーカス制御障害の対応
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using System.Collections;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinToolbars;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// キャンペーン目標設定フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : キャンペーン目標設定フォームクラス</br>
    /// <br>Programmer : 徐佳</br>
    /// <br>Date       : 2011/04/25</br>
    /// <br>Update Note: 2011/07/05 譚洪 Redmine#22743 目標値が全て0でも登録可能の対応</br>
    /// <br>Update Note: 2011/07/05 譚洪 Redmine#22750 フォーカス制御障害の対応</br>
    /// </remarks>
    public partial class PMKHN09651UA : Form
    {
        #region ■ Constants

        private const string ASSEMBLY_ID = "PMKHN09651U";

        private const string COLUMN_MONTH = "Month";
        private const string COLUMN_SALESTARGET = "SalesTarget";
        private const string COLUMN_PROFITTARGET = "ProfitTarget";
        private const string COLUMN_COUNTTARGET = "CountTarget";

        private const string FORMAT_NUM = "#,###,###,###";
        private const string FORMAT_NUM1 = "##,###,###,###,###";

        private const string INSERT_MODE = "新規";
        private const string UPDATE_MODE = "更新";
        private const string DELETE_MODE = "削除";

        private const string ctGUIDE_NAME_CampaignGuide = "tNedit_CampaignCode";
        private const string ctGUIDE_NAME_Section = "tEdit_SectionCode";
        private const string ctGUIDE_NAME_CustomerCode = "tNedit_CustomerCode";
        private const string ctGUIDE_NAME_EmployeeCode = "tEdit_EmployeeCode";
        private const string ctGUIDE_NAME_SalesAreaCode = "tNedit_SalesAreaCode";
        private const string ctGUIDE_NAME_SalesGroupCode = "tNedit_BLGloupCode";
        private const string ctGUIDE_NAME_BLCode = "tNedit_BLGoodsCode";
        private const string ctGUIDE_NAME_SalesCode = "tNedit_SalesCode";
        private string _guideKey;

        private const string ct_Tool_CloseButton = "tool_Close";						// 終了
        private const string ct_Tool_NewButton = "tool_New";							// 新規
        private const string ct_Tool_SaveButton = "tool_Save";							// 保存
        private const string ct_Tool_LogicalDeleteButton = "tool_LogicalDelete";		// 論理削除
        private const string ct_Tool_DeleteButton = "tool_Delete";						// 削除
        private const string ct_Tool_RevivalButton = "tool_Revival";					// 復活
        private const string ct_Tool_UndoButton = "tool_Undo";					        // 元に戻す
        private const string ct_Tool_GuideButton = "tool_Guide";					    // ガイド
        private const string ct_Tool_RenewalButton = "tool_Renewal";					// 最新情報
        private const string ct_Tool_LoginEmployee = "tool_LoginEmployee";				// ログイン担当者タイトル
        private const string ct_Tool_LoginEmployeeName = "tool_LoginEmployeeName";		// ログイン担当者名称
        #endregion ■ Constants


        #region ■ Private Members

        private bool _isClose;
        private bool _isSave;
        private bool _isNew;
        private bool _isRevival;
        private bool _isLogicalDelete;
        private bool _isDelete;
        private bool _isUndo;
        private bool _isRenewal;
        private bool _isGuide;

        private string _enterpriseCode;                     // 企業コード

        private bool _cusotmerGuideSelected;                // 得意先ガイド選択フラグ

        private List<DateTime> _yearMonthList;              // 年月度リスト
        private List<DateTime> _startMonthDateList;         // 年月度開始日リスト
        private List<DateTime> _endMonthDateList;           // 年月度終了日リスト
        private int _year;                                  // 会計年度
        private int _thisYear;                              // 当年度

        private SecInfoAcs _secInfoAcs;                     // 拠点マスタ
        private SecInfoSetAcs _secInfoSetAcs;               // 拠点ガイドボタンがクリックされた時に発生します
        private CampaignStAcs _campaignStAcs;
        private CustomerInfoAcs _customerInfoAcs;
        private CustomerSearchAcs _customerSearchAcs;       // 得意先マスタ
        private EmployeeAcs _employeeAcs;                   // 従業員マスタ
        private UserGuideAcs _userGuideAcs;                 // ユーザーガイドマスタ
        private BLGroupUAcs _blGroupUAcs;                   // グループコードガイドマスタ
        private BLGoodsCdAcs _blGoodsCdAcs;                  // BLコードガイドマスタ
        private CampaignTargetAcs _campaignTargetAcs;       // キャンペーン目標設定マスタ
        private DateGetAcs _dateGetAcs;

        private Dictionary<int, CampaignSt> _campaignStDic;
        private Dictionary<string, SecInfoSet> _secInfoSetDic;
        private Dictionary<int, CustomerSearchRet> _customerSearchRetDic;
        private Dictionary<string, Employee> _employeeDic;
        private Dictionary<int, string> _blGroupUDic;
        private Dictionary<int, string> _blGoodsCdDic;
        private Dictionary<int, string> _salesAreaDic;
        private Dictionary<int, string> _salesCodeDic;

        private Dictionary<string, CampaignTarget> _campaignTargetDicClone;

        //private bool _searchFlg;  // DEL K2011/07/05 

        private int _prevTargetContrastCd;
        private int _prevCampaignCode;
        private string _prevSectionCode;
        private int _prevCustomerCode;
        private string _prevEmployeeCode;
        private int _prevSalesAreaCode;
        private int _prevSalesCode;
        private int _prevBLGroupCode;
        private int _prevBLGoodsCode;

        private int _prevSetArea;

        private int _customerFlag;

        // 画面イメージコントロール部品
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        #endregion ■ Private Members


        #region ■ Constructor

        /// <summary>
        /// キャンペーン目標設定フォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : キャンペーン目標設定フォームクラス</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        public PMKHN09651UA()
        {
            InitializeComponent();

            this._isClose = true;
            this._isSave = true;
            this._isNew = true;
            this._isRevival = false;
            this._isLogicalDelete = false;
            this._isDelete = false;
            this._isUndo = true;
            this._isGuide = true;
            this._isRenewal = true;
            // 企業コード取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // 各種アクセスクラスインスタンス生成
            this._secInfoAcs = new SecInfoAcs();
            this._secInfoSetAcs = new SecInfoSetAcs();
            this._campaignStAcs = new CampaignStAcs();
            this._customerInfoAcs = new CustomerInfoAcs();
            this._customerSearchAcs = new CustomerSearchAcs();
            this._employeeAcs = new EmployeeAcs();
            this._blGroupUAcs = new BLGroupUAcs();
            this._blGoodsCdAcs = new BLGoodsCdAcs();
            this._userGuideAcs = new UserGuideAcs();
            this._dateGetAcs = DateGetAcs.GetInstance();
            this._campaignTargetAcs = new CampaignTargetAcs();

            this._campaignTargetDicClone = new Dictionary<string, CampaignTarget>();


            // 各種マスタ取得
            bool bStatus = ReadMaster();
            if (!bStatus)
            {
                return;
            }

            // 会計年度情報取得
            GetFinancialYearTable(0);

            // ツールボタンEnable設定
            SetToolButtonVisible(this);
        }

        #endregion ■ Constructor

        /// <summary> 終了ボタンVisibleプロパティ </summary>
        public bool IsClose
        {
            get { return this._isClose; }
        }

        /// <summary> 保存ボタンVisibleプロパティ </summary>
        public bool IsSave
        {
            get { return this._isSave; }
        }

        /// <summary> 新規ボタンVisibleプロパティ </summary>
        public bool IsNew
        {
            get { return this._isNew; }
        }

        /// <summary> 復活ボタンVisibleプロパティ </summary>
        public bool IsRevival
        {
            get { return this._isRevival; }
        }

        /// <summary> 論理削除ボタンVisibleプロパティ </summary>
        public bool IsLogicalDelete
        {
            get { return this._isLogicalDelete; }
        }

        /// <summary> 完全削除ボタンVisibleプロパティ </summary>
        public bool IsDelete
        {
            get { return this._isDelete; }
        }

        /// <summary> 元に戻すボタンVisibleプロパティ </summary>
        public bool IsUndo
        {
            get { return this._isUndo; }
        }

        /// <summary> 最新情報ボタンVisibleプロパティ </summary>
        public bool IsRenewal
        {
            get { return this._isRenewal; }
        }

        /// <summary> ガイド報ボタンVisibleプロパティ </summary>
        public bool IsGuide
        {
            get { return this._isGuide; }
        }
        /// <summary>
        /// 終了前処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 終了前処理を行います。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        public int BeforeClose()
        {
            DialogResult result = DialogResult.No;

            // 画面状態変更チェック
            bool bStatus = CompareInputScreen();
            if (!bStatus)
            {
                result = ShowMessageBox(emErrorLevel.ERR_LEVEL_SAVECONFIRM,
                                       "",
                                       0,
                                       MessageBoxButtons.YesNoCancel,
                                       MessageBoxDefaultButton.Button2);
            }
            switch (result)
            {
                case DialogResult.Yes:
                    {
                        // 保存処理
                        int status = SaveProc();
                        if (status != 0)
                        {
                            return (status);
                        }

                        break;
                    }
                case DialogResult.No:
                    {
                        break;
                    }
                case DialogResult.Cancel:
                    {
                        return -1;
                    }
            }

            return 0;
        }

        /// <summary>
        /// 保存処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 保存処理を行います。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        public int Save()
        {
            return SaveProc();
        }

        /// <summary>
        /// 新規処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 新規処理を行います。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        public int New()
        {
            DialogResult result = DialogResult.No;

            // 画面状態変更チェック
            bool bStatus = CompareInputScreen();
            if (!bStatus)
            {
                result = ShowMessageBox(emErrorLevel.ERR_LEVEL_QUESTION,
                                           "編集中のデータが存在します。" + "\r\n" + "\r\n" + "登録してもよいですか？",
                                           0,
                                           MessageBoxButtons.YesNoCancel,
                                           MessageBoxDefaultButton.Button1);
            }

            switch (result)
            {
                case DialogResult.Yes:
                    {
                        // 保存処理
                        int status = SaveProc();
                        if (status != 0)
                        {
                            return (status);
                        }

                        break;
                    }
                case DialogResult.No:
                    {
                        break;
                    }
                case DialogResult.Cancel:
                    {
                        return 0;
                    }
            }

            // 画面初期化処理
            ClearScreen();

            SetControlEnabled(INSERT_MODE);

            this.tNedit_CampaignCode.Focus();

            // 条件コントロールEnabled制御
            ChangeTargetContrastControl(10);

            // フォーカス設定
            this.timer_SetFocus.Enabled = true;

            return 0;
        }

        /// <summary>
        /// 復活処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 復活処理を行います。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        public int Revival()
        {
            int statsu = RevivalProc();
            if (statsu == 0)
            {
                // フォーカス設定
                this.tNedit_SalesTargetSale.Focus();
            }

            return (statsu);
        }

        /// <summary>
        /// 論理削除処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 論理削除処理を行います。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/25</br>
        /// <br>Update Note: 2011/07/05 譚洪 Redmine#22750 フォーカス制御障害の対応</br>
        /// </remarks>
        public int LogicalDelete()
        {
            // 論理削除確認
            DialogResult result = ShowMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                                 "現在、表示中のデータを削除します。\r\nよろしいですか？",
                                                 0,
                                                 MessageBoxButtons.YesNo,
                                                 MessageBoxDefaultButton.Button2);
            if (result == DialogResult.No)
            {
                return 0;
            }


            if (this._prevCampaignCode != 0)
            {
                this.tNedit_CampaignCode.Text = this._prevCampaignCode.ToString();
            }
            if (!string.IsNullOrEmpty(this._prevSectionCode))
            {
                this.tEdit_SectionCode.Text = int.Parse(this._prevSectionCode).ToString("00");

            }
            if (this._prevCustomerCode != 0)
            {
                this.tNedit_CustomerCode.Text = this._prevCustomerCode.ToString("00000000");
            }
            if (!string.IsNullOrEmpty(this._prevEmployeeCode))
            {
                this.tEdit_EmployeeCode.Text = int.Parse(this._prevEmployeeCode).ToString("0000");
            }
            if (this._prevSalesAreaCode != 0)
            {
                this.tNedit_SalesAreaCode.Text = this._prevSalesAreaCode.ToString("0000");
            }
            if (this._prevBLGroupCode != 0)
            {
                this.tNedit_BLGloupCode.Text = this._prevBLGroupCode.ToString("00000");
            }
            if (this._prevBLGoodsCode != 0)
            {
                this.tNedit_BLGoodsCode.Text = this._prevBLGoodsCode.ToString("00000");
            }
            if (this._prevSalesCode != 0)
            {
                this.tNedit_SalesCode.Text = this._prevSalesCode.ToString("0000");
            }
            
            return LogicalDeleteProc();
        }

        /// <summary>
        /// 物理削除処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 物理削除処理を行います。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        public int Delete()
        {
            // 完全削除確認
            DialogResult result = ShowMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                                 "データを物理削除します。\r\nよろしいですか？",
                                                 0,
                                                 MessageBoxButtons.YesNo,
                                                 MessageBoxDefaultButton.Button2);
            if (result == DialogResult.No)
            {
                return 0;
            }

            return DeleteProc();
        }

        /// <summary>
        /// 元に戻す処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 元に戻す処理を行います。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        public int Undo()
        {
            return UndoProc();
        }

        /// <summary>
        /// ガイド処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : ガイド処理を行います。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        public int Guide()
        {
            ExecuteGuide();
            return 0;
        }

        /// <summary>
        /// 最新情報取得処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 最新情報を取得します。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        public int Renewal()
        {
            return RenewalProc();
        }

        /// <summary>
        /// フォーカス設定処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : フォーカス設定処理を行います。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        public void SetFocus()
        {
            this.tNedit_CampaignCode.Focus();
        }

        #region ■ Private Methods

        #region ツールバー初期設定処理
        /// <summary>
        /// ツールバー初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : ツールバーの初期設定を行う</br>
        /// <br>Programer  : 徐佳</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void InitialToolbarSetting()
        {
            // イメージリスト設定
            this.tToolsManager_MainMenu.ImageListSmall = IconResourceManagement.ImageList16;
           
            //----------------------------
            // ツールアイコン設定
            //----------------------------
            // 終了
            this.tToolsManager_MainMenu.Tools[ct_Tool_CloseButton].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            // 新規
            this.tToolsManager_MainMenu.Tools[ct_Tool_NewButton].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.NEW;
            // 保存
            this.tToolsManager_MainMenu.Tools[ct_Tool_SaveButton].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
            // 論理削除
            this.tToolsManager_MainMenu.Tools[ct_Tool_LogicalDeleteButton].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DELETE;
            // 削除
            this.tToolsManager_MainMenu.Tools[ct_Tool_DeleteButton].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DELETE;
            // 復活
            this.tToolsManager_MainMenu.Tools[ct_Tool_RevivalButton].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.UNDO;
            // 元に戻す
            this.tToolsManager_MainMenu.Tools[ct_Tool_UndoButton].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.UNDO;
            // ガイド計算
            this.tToolsManager_MainMenu.Tools[ct_Tool_GuideButton].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.GUIDE;
            // 最新情報
            this.tToolsManager_MainMenu.Tools[ct_Tool_RenewalButton].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.RENEWAL;
            // ログイン担当者
            this.tToolsManager_MainMenu.Tools[ct_Tool_LoginEmployee].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;

            // 担当者表示
            if (LoginInfoAcquisition.Employee != null)
            {
                LabelTool loginNameLabel = (LabelTool)this.tToolsManager_MainMenu.Tools[ct_Tool_LoginEmployeeName];
                if (loginNameLabel != null)
                {
                    loginNameLabel.SharedProps.Caption = LoginInfoAcquisition.Employee.Name;
                }
            }
        }
        #endregion

        #region ツールバー初期設定処理
        /// <summary>
        /// ツールボタンEnable設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : ツールボタンEnableを設定する</br>
        /// <br>Programer  : 徐佳</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void SetToolButtonVisible(Form form)
        {
            // 新規
            this.tToolsManager_MainMenu.Tools[ct_Tool_NewButton].SharedProps.Visible = this.IsNew;
            this.tToolsManager_MainMenu.Tools[ct_Tool_NewButton].SharedProps.Enabled = this.IsNew;
            // 保存
            this.tToolsManager_MainMenu.Tools[ct_Tool_SaveButton].SharedProps.Visible = this.IsSave;
            this.tToolsManager_MainMenu.Tools[ct_Tool_SaveButton].SharedProps.Enabled = this.IsSave;
            // 論理削除
            this.tToolsManager_MainMenu.Tools[ct_Tool_LogicalDeleteButton].SharedProps.Visible = this.IsLogicalDelete;
            this.tToolsManager_MainMenu.Tools[ct_Tool_LogicalDeleteButton].SharedProps.Enabled = this.IsLogicalDelete;
            // 削除
            this.tToolsManager_MainMenu.Tools[ct_Tool_DeleteButton].SharedProps.Visible = this.IsDelete;
            this.tToolsManager_MainMenu.Tools[ct_Tool_DeleteButton].SharedProps.Enabled = this.IsDelete;
            // 復活
            this.tToolsManager_MainMenu.Tools[ct_Tool_RevivalButton].SharedProps.Visible = this.IsRevival;
            this.tToolsManager_MainMenu.Tools[ct_Tool_RevivalButton].SharedProps.Enabled = this.IsRevival;
            // 元に戻す
            this.tToolsManager_MainMenu.Tools[ct_Tool_UndoButton].SharedProps.Visible = this.IsUndo;
            this.tToolsManager_MainMenu.Tools[ct_Tool_UndoButton].SharedProps.Enabled = this.IsUndo;
            // ガイド計算
            this.tToolsManager_MainMenu.Tools[ct_Tool_GuideButton].SharedProps.Visible = this.IsGuide;
            this.tToolsManager_MainMenu.Tools[ct_Tool_GuideButton].SharedProps.Enabled = this.IsGuide;
            // 最新情報
            this.tToolsManager_MainMenu.Tools[ct_Tool_RenewalButton].SharedProps.Visible = this.IsRenewal;
            this.tToolsManager_MainMenu.Tools[ct_Tool_RenewalButton].SharedProps.Enabled = this.IsRenewal;
        }
        #endregion


        #region マスタ読込
        /// <summary>
        /// 各種マスタ読込処理
        /// </summary>
        /// <returns>ステータス(True:正常 False:異常)</returns>
        /// <remarks>
        /// <br>Note       : 各種マスタを読み込み、バッファに保持します。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private bool ReadMaster()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            string errMsg = "";

            try
            {
                // キャンペーンコード
                status = GetCampaignStList();
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        break;
                    default:
                        errMsg = "キャンペーン設定マスタの読込に失敗しました。";
                        return (false);
                }

                // 拠点
                status = ReadSecInfoSet();
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        break;
                    default:
                        errMsg = "拠点マスタの読込に失敗しました。";
                        return (false);
                }

                // 得意先
                status = ReadCustomer();
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        break;
                    default:
                        errMsg = "得意先マスタの読込に失敗しました。";
                        return (false);
                }

                // 従業員
                status = ReadEmployee();
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        break;
                    default:
                        errMsg = "従業員マスタの読込に失敗しました。";
                        return (false);
                }

                // 地区
                status = ReadSalesArea();
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        break;
                    default:
                        errMsg = "地区情報の取得に失敗しました。";
                        return (false);
                }

                // グループコード
                status = ReadBLGroup();
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        break;
                    default:
                        errMsg = "グループコード情報の取得に失敗しました。";
                        return (false);
                }

                // BLコード
                status = ReadBLGoodsCd();
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        break;
                    default:
                        errMsg = "BLコード情報の取得に失敗しました。";
                        return (false);
                }

                // 販売区分
                status = ReadSalesCode();
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        break;
                    default:
                        errMsg = "販売区分情報の取得に失敗しました。";
                        return (false);
                }
            }
            finally
            {
                if (errMsg.Length > 0)
                {
                    TMsgDisp.Show(this,
                                  emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                  this.Name,
                                  errMsg,
                                  status,
                                  MessageBoxButtons.OK);
                }
            }

            return (true);
        }

        /// <summary>
        /// キャンペーン設定リスト取得
        /// </summary>
        /// <remarks>
        /// <br>Note       : キャンペーン設定マスタの取得を行います。</br>
        /// <br></br>
        /// </remarks>
        private int GetCampaignStList()
        {
            if (_campaignStAcs == null)
            {
                _campaignStAcs = new CampaignStAcs();
            }

            _campaignStDic = new Dictionary<int, CampaignSt>();
            ArrayList retList;

            try
            {
                // 全検索
                int status = _campaignStAcs.SearchAll(out retList, LoginInfoAcquisition.EnterpriseCode);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    foreach (CampaignSt campaignSt in retList)
                    {
                        if (!_campaignStDic.ContainsKey(campaignSt.CampaignCode))
                        {
                            _campaignStDic.Add(campaignSt.CampaignCode, campaignSt);
                        }
                    }
                }
            }
            catch
            {
                this._campaignStDic = new Dictionary<int, CampaignSt>();
                return -1;
            }

            return 0;
        }

        /// <summary>
        /// キャンペーン設定マスタ読込処理
        /// </summary>
        /// <param name="campaignCode">キャンペーンコード</param>
        /// <returns>キャンペーン設定データクラス</returns>
        /// <remarks>
        /// <br>Note       : キャンペーン設定マスタの取得を行います。</br>
        /// <br></br>
        /// </remarks>
        private CampaignSt ReadCampaignSt(int campaignCode)
        {
            if (_campaignStAcs == null)
            {
                _campaignStAcs = new CampaignStAcs();
            }

            CampaignSt campaignSt;
            int status = _campaignStAcs.Read(out campaignSt, LoginInfoAcquisition.EnterpriseCode, campaignCode);
            if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) &&
                (campaignSt.LogicalDeleteCode == 0))
            {
                ;
            }
            else
            {
                campaignSt = new CampaignSt();
            }

            return campaignSt;
        }

        /// <summary>
        /// 拠点マスタ読込処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 拠点マスタを読み込み、バッファに保持します。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private int ReadSecInfoSet()
        {
            this._secInfoSetDic = new Dictionary<string, SecInfoSet>();
            this._secInfoAcs.ResetSectionInfo();

            try
            {
                foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
                {
                    if (secInfoSet.LogicalDeleteCode == 0)
                    {
                        this._secInfoSetDic.Add(secInfoSet.SectionCode.Trim(), secInfoSet);
                    }
                }
            }
            catch
            {
                this._secInfoSetDic = new Dictionary<string, SecInfoSet>();
                return -1;
            }

            return 0;
        }

        /// <summary>
        /// 得意先マスタ読込処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 得意先マスタを読み込み、バッファに保持します。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private int ReadCustomer()
        {
            this._customerSearchRetDic = new Dictionary<int, CustomerSearchRet>();

            try
            {
                CustomerSearchPara para = new CustomerSearchPara();
                para.EnterpriseCode = this._enterpriseCode;

                CustomerSearchRet[] retArray;

                int status = this._customerSearchAcs.Serch(out retArray, para);
                if (status == 0)
                {
                    foreach (CustomerSearchRet customerSearchRet in retArray)
                    {
                        if (customerSearchRet.LogicalDeleteCode == 0)
                        {
                            this._customerSearchRetDic.Add(customerSearchRet.CustomerCode, customerSearchRet);
                        }
                    }
                }
            }
            catch
            {
                this._customerSearchRetDic = new Dictionary<int, CustomerSearchRet>();
                return -1;
            }

            return 0;
        }

        /// <summary>
        /// 従業員マスタ読込処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 従業員マスタを読み込み、バッファに保持します。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private int ReadEmployee()
        {
            this._employeeDic = new Dictionary<string, Employee>();

            try
            {
                ArrayList retList;
                ArrayList retList2;

                int status = this._employeeAcs.SearchAll(out retList, out retList2, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (Employee employee in retList)
                    {
                        if (employee.LogicalDeleteCode == 0)
                        {
                            this._employeeDic.Add(employee.EmployeeCode.Trim(), employee);
                        }
                    }
                }
            }
            catch
            {
                this._employeeDic = new Dictionary<string, Employee>();
                return -1;
            }

            return 0;
        }

        /// <summary>
        /// 地区マスタ読込処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 地区マスタを読み込み、バッファに保持します。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private int ReadSalesArea()
        {
            this._salesAreaDic = new Dictionary<int, string>();

            return ReadUserGdBd(21, ref this._salesAreaDic);
        }

        /// <summary>
        /// BLグループマスタ読込処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : BLグループマスタを読み込み、バッファに保持します。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private int ReadBLGroup()
        {
            this._blGroupUDic = new Dictionary<int, string>();

            try
            {
                string enterpriseCode = this._enterpriseCode;

                ArrayList retList;

                int status = this._blGroupUAcs.SearchAll(out retList, enterpriseCode);
                if (status == 0)
                {
                    foreach (BLGroupU bLGroupU in retList)
                    {
                        if (bLGroupU.LogicalDeleteCode == 0)
                        {
                            this._blGroupUDic.Add(bLGroupU.BLGroupCode, bLGroupU.BLGroupName);
                        }
                    }
                }
            }
            catch
            {
                this._blGroupUDic = new Dictionary<int, string>();
                return -1;
            }

            return 0;
        }

        /// <summary>
        /// 販売区分マスタ読込処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 販売区分マスタを読み込み、バッファに保持します。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private int ReadSalesCode()
        {
            this._salesCodeDic = new Dictionary<int, string>();

            return ReadUserGdBd(71, ref this._salesCodeDic);
        }

        /// <summary>
        /// BLコードガイドマスタ読込処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : BLコードガイドマスタを読み込み、バッファに保持します。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private int ReadBLGoodsCd()
        {
            this._blGoodsCdDic = new Dictionary<int, string>();

            try
            {
                string enterpriseCode = this._enterpriseCode;
                ArrayList retList;

                int status = this._blGoodsCdAcs.SearchAll(out retList, enterpriseCode);
                if (status == 0)
                {
                    foreach (BLGoodsCdUMnt blGoodsCdUMnt in retList)
                    {
                        if (blGoodsCdUMnt.LogicalDeleteCode == 0)
                        {
                            this._blGoodsCdDic.Add(blGoodsCdUMnt.BLGoodsCode, blGoodsCdUMnt.BLGoodsFullName);
                        }
                    }
                }

            }
            catch
            {
                this._blGoodsCdDic = new Dictionary<int, string>();
                return -1;
            }

            return 0;
        }

        /// <summary>
        /// ユーザーガイドマスタ読込処理
        /// </summary>
        /// <param name="userGuideDivCd">ガイド区分</param>
        /// <param name="targetDic">対象Dictionary</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : ユーザーガイドマスタを読み込み、バッファに保持します。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private int ReadUserGdBd(int userGuideDivCd, ref Dictionary<int, string> targetDic)
        {
            try
            {
                ArrayList retList;

                int status = this._userGuideAcs.SearchAllDivCodeBody(out retList, this._enterpriseCode,
                                                                     userGuideDivCd, UserGuideAcsData.UserBodyData);
                if (status == 0)
                {
                    foreach (UserGdBd userGdBd in retList)
                    {
                        if (userGdBd.LogicalDeleteCode == 0)
                        {
                            targetDic.Add(userGdBd.GuideCode, userGdBd.GuideName.Trim());
                        }
                    }
                }
            }
            catch
            {
                targetDic = new Dictionary<int, string>();
                return -1;
            }

            return 0;
        }
        #endregion マスタ読込

        #region 名称取得
        /// <summary>
        /// キャンペーン名称取得
        /// </summary>
        /// <param name="campaignCode">キャンペーンコード</param>
        /// <returns>キャンペーン名称</returns>
        /// <remarks>
        /// <br>Note       : キャンペーン名称の取得を行います。</br>
        /// <br></br>
        /// </remarks>
        public string GetCampaignName(int campaignCode)
        {
            string name = string.Empty;

            if (_campaignStDic == null)
            {
                // キャンペーン設定リスト取得
                GetCampaignStList();
            }

            CampaignSt campaignSt;
            if (_campaignStDic.ContainsKey(campaignCode))
            {
                // ディクショナリーに存在
                campaignSt = _campaignStDic[campaignCode];
                name = campaignSt.CampaignName;
            }
            else
            {
                // ディクショナリーに存在しないので、マスタから読込
                campaignSt = ReadCampaignSt(campaignCode);
                name = campaignSt.CampaignName;
            }

            return name;
        }

        /// <summary>
        /// 拠点名取得処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>拠点名</returns>
        /// <remarks>
        /// <br>Note       : 拠点名を取得します。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private string GetSectionName(string sectionCode)
        {
            string sectionName = "";

            if (this._secInfoSetDic.ContainsKey(sectionCode.Trim()))
            {
                sectionName = this._secInfoSetDic[sectionCode.Trim()].SectionGuideNm.Trim();
            }

            return sectionName;
        }

        /// <summary>
        /// 得意先名取得処理
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        /// <returns>得意先名</returns>
        /// <remarks>
        /// <br>Note       : 得意先名を取得します。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private string GetCustomerName(int customerCode)
        {
            string customerName = "";

            if (this._customerSearchRetDic.ContainsKey(customerCode))
            {
                if (customerCode != 0)
                {
                    customerName = this._customerSearchRetDic[customerCode].Snm.Trim();
                }
            }

            return customerName;
        }

        /// <summary>
        /// 従業員名取得処理
        /// </summary>
        /// <param name="employeeCode">従業員コード</param>
        /// <returns>従業員名</returns>
        /// <remarks>
        /// <br>Note       : 従業員名を取得します。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private string GetEmployeeName(string employeeCode)
        {
            string employeeName = "";

            if (this._employeeDic.ContainsKey(employeeCode.Trim()))
            {
                employeeName = this._employeeDic[employeeCode].Name.Trim();
            }

            return employeeName;
        }

        /// <summary>
        /// 地区名取得処理
        /// </summary>
        /// <param name="salesAreaCode">地区コード</param>
        /// <returns>地区名</returns>
        /// <remarks>
        /// <br>Note       : 地区名を取得します。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private string GetSalesAreaName(int salesAreaCode)
        {
            string salesAreaName = "";

            if (this._salesAreaDic.ContainsKey(salesAreaCode))
            {
                if (salesAreaCode != 0)
                {
                    salesAreaName = this._salesAreaDic[salesAreaCode].Trim();
                }
            }

            return salesAreaName;
        }

        /// <summary>
        /// BLグループ取得処理
        /// </summary>
        /// <param name="blGroupCode">BLグループコード</param>
        /// <returns>BLグループ名称</returns>
        /// <remarks>
        /// <br>Note       : BLグループ名称を取得します。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private string GetBLGroupName(int blGroupCode)
        {
            string blGroupName = "";

            if (this._blGroupUDic.ContainsKey(blGroupCode))
            {
                if (blGroupCode != 0)
                {
                    blGroupName = this._blGroupUDic[blGroupCode].Trim();
                }
            }

            return blGroupName;
        }

        /// <summary>
        /// 販売区分名取得処理
        /// </summary>
        /// <param name="salesCode">販売区分コード</param>
        /// <returns>販売区分名</returns>
        /// <remarks>
        /// <br>Note       : 販売区分名を取得します。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private string GetSalesCodeName(int salesCode)
        {
            string salesCodeName = "";

            if (this._salesCodeDic.ContainsKey(salesCode))
            {
                if (salesCode != 0)
                {
                    salesCodeName = this._salesCodeDic[salesCode].Trim();
                }
            }

            return salesCodeName;
        }

        /// <summary>
        /// BL名称取得処理
        /// </summary>
        /// <param name="blGoodsCode">BLコード</param>
        /// <returns>BL名称</returns>
        /// <remarks>
        /// <br>Note       : BL名称を取得します。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private string GetBLGoodsName(int blGoodsCode)
        {
            string blGoodsName = "";

            if (this._blGoodsCdDic.ContainsKey(blGoodsCode))
            {
                if (blGoodsCode != 0)
                {
                    blGoodsName = this._blGoodsCdDic[blGoodsCode].Trim();
                }
            }

            return blGoodsName;
        }
        #endregion 名称取得


        #region マスタ存在チェック
        /// <summary>
        /// 得意先存在チェック処理
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        /// <returns>true：OK、false：NG</returns>
        /// <remarks>
        /// <br>Note       : 得意先が存在するかチェックします。</br>
        /// <br></br>
        /// </remarks>
        private bool CheckCustomer(int customerCode)
        {
            bool check = false;

            try
            {
                if (this._customerSearchRetDic.ContainsKey(customerCode))
                {
                    check = true;
                }
            }
            catch
            {
                check = false;
            }

            return check;
        }
        #endregion マスタ存在チェック

        #region 会計年度テーブル取得
        /// <summary>
        /// 会計年度テーブル取得処理
        /// </summary>
        /// <param name="addYearFromThis">当年からの差分</param>
        /// <remarks>
        /// <br>Note       : 会計年度テーブルを取得し、会計年度情報をバッファに保持します。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void GetFinancialYearTable(int addYearFromThis)
        {
            try
            {
                this._dateGetAcs.GetFinancialYearTable(addYearFromThis,
                                                       out this._startMonthDateList,
                                                       out this._endMonthDateList,
                                                       out this._yearMonthList,
                                                       out this._year);
                if (addYearFromThis == 0)
                {
                    this._thisYear = this._year;
                }
            }
            catch
            {
                this._startMonthDateList = new List<DateTime>();
                this._endMonthDateList = new List<DateTime>();
                this._yearMonthList = new List<DateTime>();
                this._year = 0;
            }
        }
        #endregion 会計年度テーブル取得


        #region 画面初期化

        private void InitialSetting()
        {

            // 画面イメージ統一
            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);

            // ツールバー初期設定処理
            InitialToolbarSetting();
        }



        /// <summary>
        /// 画面情報初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面情報を初期化します。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void ClearScreen()
        {
            this.tNedit_CampaignCode.Clear();
            this.tEdit_CampaignName.Clear();
            this.tNedit_YearFrm.Clear();
            this.tNedit_MonthFrm.Clear();
            this.tNedit_DayFrm.Clear();
            this.tNedit_YearTo.Clear();
            this.tNedit_MonthTo.Clear();
            this.tNedit_DayTo.Clear();
            this.tComboEditor_TargetContrastCd.Value = 10;
            this.tEdit_SectionCode.Clear();
            this.tEdit_SectionName.Clear();
            this.tNedit_CustomerCode.Clear();
            this.tEdit_CustomerName.Clear();
            this.tEdit_EmployeeCode.Clear();
            this.tEdit_EmployeeName.Clear();
            this.tNedit_SalesAreaCode.Clear();
            this.tEdit_SalesAreaName.Clear();
            this.tNedit_BLGloupCode.Clear();
            this.tEdit_GroupName.Clear();
            this.tNedit_SalesCode.Clear();
            this.tEdit_SalesCodeName.Clear();
            this.tNedit_BLGoodsCode.Clear();
            this.tEdit_BLName.Clear();

            ClearGrid();

            this.Mode_Label.Text = INSERT_MODE;

            //this._searchFlg = false; // DEL K2011/07/05 

            this._prevTargetContrastCd = 10;
            this._prevCampaignCode = 0;
            this._prevSectionCode = "";
            this._prevCustomerCode = 0;
            this._prevEmployeeCode = "";
            this._prevSalesAreaCode = 0;
            this._prevSalesCode = 0;
            this._prevBLGroupCode = 0;
            this._prevBLGoodsCode = 0;
            this._prevSetArea = 10;
            this._customerFlag = 0;
        }

        /// <summary>
        /// 画面情報初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面情報を初期化します。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/25</br>
        /// <br>Update Note: 2011/07/05 譚洪 Redmine#22750 フォーカス制御障害の対応</br>
        /// </remarks>
        private void ComboChgClearScreen()
        {
            this.tEdit_SectionCode.Clear();
            this.tEdit_SectionName.Clear();
            this.tNedit_CustomerCode.Clear();
            this.tEdit_CustomerName.Clear();
            this.tEdit_EmployeeCode.Clear();
            this.tEdit_EmployeeName.Clear();
            this.tNedit_SalesAreaCode.Clear();
            this.tEdit_SalesAreaName.Clear();
            this.tNedit_BLGloupCode.Clear();
            this.tEdit_GroupName.Clear();
            this.tNedit_SalesCode.Clear();
            this.tEdit_SalesCodeName.Clear();
            this.tNedit_BLGoodsCode.Clear();
            this.tEdit_BLName.Clear();

            ClearGrid();

            this.Mode_Label.Text = INSERT_MODE;
            SetControlEnabled(INSERT_MODE);  // ADD K2011/07/05 

            //this._searchFlg = false; // DEL K2011/07/05

            this._prevTargetContrastCd = (Int32)this.tComboEditor_TargetContrastCd.Value;
            this._prevSectionCode = "";
            this._prevCustomerCode = 0;
            this._prevEmployeeCode = "";
            this._prevSalesAreaCode = 0;
            this._prevSalesCode = 0;
            this._prevBLGroupCode = 0;
            this._prevBLGoodsCode = 0;
            this._prevSetArea = 10;
        }

        /// <summary>
        /// グリッド初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : グリッド情報を初期化します。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void ClearGrid()
        {
            this.tNedit_SalesTargetSale.Clear();
            this.tNedit_SalesTargetProfit.Clear();
            this.tNedit_SalesTargetCount.Clear();
            this.tNedit_SalesTargetSale1.Clear();
            this.tNedit_SalesTargetProfit1.Clear();
            this.tNedit_SalesTargetCount1.Clear();

            for (int index = 0; index < 13; index++)
            {
                if (index != 12)
                {
                    this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_MONTH].Value = this._yearMonthList[index].Month.ToString("00");
                }
                else
                {
                    this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_MONTH].Value = "計";
                }
                this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_SALESTARGET].Value = "";
                this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_PROFITTARGET].Value = "";
                this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_COUNTTARGET].Value = "";
            }

            this._campaignTargetDicClone.Clear();
        }
        #endregion 画面初期化

        #region 画面設定
        /// <summary>
        /// コントロールサイズ設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : コントロールサイズを設定します。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void SetControlSize()
        {
            this.tNedit_YearFrm.Size = new Size(43, 24);
            this.tEdit_SectionCode.Size = new Size(74, 24);
            this.tEdit_SectionName.Size = new Size(315, 24);
            this.tNedit_CustomerCode.Size = new Size(74, 24);
            this.tEdit_CustomerName.Size = new Size(315, 24);
            this.tEdit_EmployeeCode.Size = new Size(74, 24);
            this.tEdit_EmployeeName.Size = new Size(315, 24);
            this.tNedit_SalesAreaCode.Size = new Size(74, 24);
            this.tEdit_SalesAreaName.Size = new Size(315, 24);
            this.tNedit_BLGloupCode.Size = new Size(74, 24);
            this.tEdit_GroupName.Size = new Size(315, 24);
            this.tNedit_SalesCode.Size = new Size(74, 24);
            this.tEdit_SalesCodeName.Size = new Size(315, 24);
            this.tNedit_BLGoodsCode.Size = new Size(74, 24);
            this.tEdit_BLName.Size = new Size(315, 24);

            this.tNedit_SalesTargetSale.Size = new Size(139, 24);
            this.tNedit_SalesTargetProfit.Size = new Size(139, 24);
            this.tNedit_SalesTargetCount.Size = new Size(115, 24);

            this.tNedit_SalesTargetSale1.Size = new Size(139, 24);
            this.tNedit_SalesTargetProfit1.Size = new Size(139, 24);
            this.tNedit_SalesTargetCount1.Size = new Size(115, 24);

        }

        /// <summary>
        /// 画面初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面情報の初期設定を行います。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void SetScreenInitialSetting()
        {
            // コントロールサイズ設定
            SetControlSize();

            // -----------------------------
            // ボタンアイコン設定
            // -----------------------------
            ImageList imageList16 = IconResourceManagement.ImageList16;
            this.CampaignGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.SectionGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.CustomerGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.EmployeeGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.SalesAreaGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.GroupGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.SalesCodeGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.BLGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];

            // -----------------------------
            // グリッド設定
            // -----------------------------
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add(COLUMN_MONTH, typeof(string));
            dataTable.Columns.Add(COLUMN_SALESTARGET, typeof(string));
            dataTable.Columns.Add(COLUMN_PROFITTARGET, typeof(string));
            dataTable.Columns.Add(COLUMN_COUNTTARGET, typeof(string));

            for (int index = 0; index < 13; index++)
            {
                DataRow dataRow;
                dataRow = dataTable.NewRow();

                if (index != 12)
                {
                    dataRow[COLUMN_MONTH] = "";
                }
                else
                {
                    dataRow[COLUMN_MONTH] = "計";
                }
                dataRow[COLUMN_SALESTARGET] = "";
                dataRow[COLUMN_PROFITTARGET] = "";
                dataRow[COLUMN_COUNTTARGET] = "";
                dataTable.Rows.Add(dataRow);
            }

            this.SalesTarget_uGrid.DataSource = dataTable;

            // キャプション
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_MONTH].Header.Caption = "月";
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_SALESTARGET].Header.Caption = "売上目標";
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_PROFITTARGET].Header.Caption = "粗利目標";
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_COUNTTARGET].Header.Caption = "数量目標";

            // 列幅
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_MONTH].Width = 54;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_SALESTARGET].Width = 137;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_PROFITTARGET].Width = 137;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_COUNTTARGET].Width = 114;

            // TextHAlign(ヘッダー)
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_MONTH].Header.Appearance.TextHAlign = HAlign.Center;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_SALESTARGET].Header.Appearance.TextHAlign = HAlign.Center;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_PROFITTARGET].Header.Appearance.TextHAlign = HAlign.Center;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_COUNTTARGET].Header.Appearance.TextHAlign = HAlign.Center;

            // TextHAlign(セル)
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_MONTH].CellAppearance.TextHAlign = HAlign.Center;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_SALESTARGET].CellAppearance.TextHAlign = HAlign.Right;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_PROFITTARGET].CellAppearance.TextHAlign = HAlign.Right;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_COUNTTARGET].CellAppearance.TextHAlign = HAlign.Right;

            // TextVAlign(ヘッダー)
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_MONTH].Header.Appearance.TextVAlign = VAlign.Middle;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_SALESTARGET].Header.Appearance.TextVAlign = VAlign.Middle;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_PROFITTARGET].Header.Appearance.TextVAlign = VAlign.Middle;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_COUNTTARGET].Header.Appearance.TextVAlign = VAlign.Middle;

            // TextVAlign(セル)
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_MONTH].CellAppearance.TextVAlign = VAlign.Middle;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_SALESTARGET].CellAppearance.TextVAlign = VAlign.Middle;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_PROFITTARGET].CellAppearance.TextVAlign = VAlign.Middle;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_COUNTTARGET].CellAppearance.TextVAlign = VAlign.Middle;

            // ForeColor(ヘッダー)
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_MONTH].Header.Appearance.ForeColor = Color.White;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_SALESTARGET].Header.Appearance.ForeColor = Color.White;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_PROFITTARGET].Header.Appearance.ForeColor = Color.White;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_COUNTTARGET].Header.Appearance.ForeColor = Color.White;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_MONTH].Header.Appearance.ForeColorDisabled = Color.White;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_SALESTARGET].Header.Appearance.ForeColorDisabled = Color.White;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_PROFITTARGET].Header.Appearance.ForeColorDisabled = Color.White;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_COUNTTARGET].Header.Appearance.ForeColorDisabled = Color.White;

            // ForeColor(セル)
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_SALESTARGET].CellAppearance.ForeColor = Color.Black;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_PROFITTARGET].CellAppearance.ForeColor = Color.Black;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_COUNTTARGET].CellAppearance.ForeColor = Color.Black;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_SALESTARGET].CellAppearance.ForeColorDisabled = Color.Black;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_PROFITTARGET].CellAppearance.ForeColorDisabled = Color.Black;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_COUNTTARGET].CellAppearance.ForeColorDisabled = Color.Black;

            // 列設定(月)
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_MONTH].CellAppearance.BackColor = Color.FromArgb(89, 135, 214);
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_MONTH].CellAppearance.BackColorDisabled = Color.FromArgb(89, 135, 214);
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_MONTH].CellAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_MONTH].CellAppearance.BackColorDisabled2 = Color.FromArgb(7, 59, 150);
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_MONTH].CellAppearance.BackGradientStyle = GradientStyle.Vertical;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_MONTH].CellAppearance.ForeColor = Color.White;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_MONTH].CellAppearance.ForeColorDisabled = Color.White;

            // 行設定(計)
            this.SalesTarget_uGrid.Rows[12].Cells[COLUMN_SALESTARGET].Appearance.BackColor = Color.Gainsboro;
            this.SalesTarget_uGrid.Rows[12].Cells[COLUMN_SALESTARGET].Appearance.BackColorDisabled = Color.Gainsboro;
            this.SalesTarget_uGrid.Rows[12].Cells[COLUMN_PROFITTARGET].Appearance.BackColor = Color.Gainsboro;
            this.SalesTarget_uGrid.Rows[12].Cells[COLUMN_PROFITTARGET].Appearance.BackColorDisabled = Color.Gainsboro;
            this.SalesTarget_uGrid.Rows[12].Cells[COLUMN_COUNTTARGET].Appearance.BackColor = Color.Gainsboro;
            this.SalesTarget_uGrid.Rows[12].Cells[COLUMN_COUNTTARGET].Appearance.BackColorDisabled = Color.Gainsboro;

            // Activation
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_MONTH].CellActivation = Activation.Disabled;
            this.SalesTarget_uGrid.Rows[12].Activation = Activation.Disabled;
        }
        #endregion 画面設定

        #region コントロールEnabled制御
        /// <summary>
        /// 設定区分条件コントロールEnabled制御処理
        /// </summary>
        /// <param name="targetContrastCd">設定区分コード</param>
        /// <remarks>
        /// <br>Note       : 設定区分の値によってコントロールの制御を行います。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/25</br>
        /// <br>Update Note: 2011/07/05 譚洪 Redmine#22750 フォーカス制御障害の対応</br>
        /// </remarks>
        private void ChangeTargetContrastControl(int targetContrastCd)
        {
            switch (targetContrastCd)
            {
                case 10:    // 拠点
                    {
                        this.tEdit_SectionCode.Enabled = true;
                        this.SectionGuide_Button.Enabled = true;

                        this.tNedit_CustomerCode.Enabled = false;
                        this.CustomerGuide_Button.Enabled = false;
                        this.tEdit_EmployeeCode.Enabled = false;
                        this.EmployeeGuide_Button.Enabled = false;
                        this.tNedit_SalesAreaCode.Enabled = false;
                        this.SalesAreaGuide_Button.Enabled = false;
                        this.tNedit_BLGloupCode.Enabled = false;
                        this.GroupGuide_Button.Enabled = false;
                        this.tNedit_SalesCode.Enabled = false;
                        this.SalesCodeGuide_Button.Enabled = false;
                        this.tNedit_BLGoodsCode.Enabled = false;
                        this.BLGuide_Button.Enabled = false;

                        this.tNedit_CustomerCode.Clear();
                        this.tEdit_CustomerName.Clear();
                        this.tEdit_EmployeeCode.Clear();
                        this.tEdit_EmployeeName.Clear();
                        this.tNedit_SalesAreaCode.Clear();
                        this.tEdit_SalesAreaName.Clear();
                        this.tNedit_BLGloupCode.Clear();
                        this.tEdit_GroupName.Clear();
                        this.tNedit_SalesCode.Clear();
                        this.tEdit_SalesCodeName.Clear();
                        this.tNedit_BLGoodsCode.Clear();
                        this.tEdit_BLName.Clear();

                        break;
                    }
                case 30:    // 拠点＋得意先
                    {
                        this.tEdit_SectionCode.Enabled = true;
                        this.SectionGuide_Button.Enabled = true;
                        this.tNedit_CustomerCode.Enabled = true;
                        this.CustomerGuide_Button.Enabled = true;

                        this.tEdit_EmployeeCode.Enabled = false;
                        this.EmployeeGuide_Button.Enabled = false;
                        this.tNedit_SalesAreaCode.Enabled = false;
                        this.SalesAreaGuide_Button.Enabled = false;
                        this.tNedit_BLGloupCode.Enabled = false;
                        this.GroupGuide_Button.Enabled = false;
                        this.tNedit_SalesCode.Enabled = false;
                        this.SalesCodeGuide_Button.Enabled = false;
                        this.tNedit_BLGoodsCode.Enabled = false;
                        this.BLGuide_Button.Enabled = false;

                        this.tEdit_EmployeeCode.Clear();
                        this.tEdit_EmployeeName.Clear();
                        this.tNedit_SalesAreaCode.Clear();
                        this.tEdit_SalesAreaName.Clear();
                        this.tNedit_BLGloupCode.Clear();
                        this.tEdit_GroupName.Clear();
                        this.tNedit_SalesCode.Clear();
                        this.tEdit_SalesCodeName.Clear();
                        this.tNedit_BLGoodsCode.Clear();
                        this.tEdit_BLName.Clear();

                        break;
                    }
                case 221:   // 拠点＋担当者
                case 222:   // 拠点＋受注者
                case 223:   // 拠点＋発行者
                    {
                        if (targetContrastCd == 221)
                        {
                            this.uLabel_Employee.Text = "担当者";
                        }
                        else if (targetContrastCd == 222)
                        {
                            this.uLabel_Employee.Text = "受注者";
                        }
                        else
                        {
                            this.uLabel_Employee.Text = "発行者";
                        }
                        this.tEdit_SectionCode.Enabled = true;
                        this.SectionGuide_Button.Enabled = true;
                        this.tEdit_EmployeeCode.Enabled = true;
                        this.EmployeeGuide_Button.Enabled = true;

                        this.tNedit_CustomerCode.Enabled = false;
                        this.CustomerGuide_Button.Enabled = false;
                        this.tNedit_SalesAreaCode.Enabled = false;
                        this.SalesAreaGuide_Button.Enabled = false;
                        this.tNedit_BLGloupCode.Enabled = false;
                        this.GroupGuide_Button.Enabled = false;
                        this.tNedit_SalesCode.Enabled = false;
                        this.SalesCodeGuide_Button.Enabled = false;
                        this.tNedit_BLGoodsCode.Enabled = false;
                        this.BLGuide_Button.Enabled = false;

                        this.tNedit_CustomerCode.Clear();
                        this.tEdit_CustomerName.Clear();
                        //this.tEdit_EmployeeCode.Clear();  // DEL K2011/07/05 
                        //this.tEdit_EmployeeName.Clear();  // DEL K2011/07/05 
                        this.tNedit_SalesAreaCode.Clear();
                        this.tEdit_SalesAreaName.Clear();
                        this.tNedit_BLGloupCode.Clear();
                        this.tEdit_GroupName.Clear();
                        this.tNedit_SalesCode.Clear();
                        this.tEdit_SalesCodeName.Clear();
                        this.tNedit_BLGoodsCode.Clear();
                        this.tEdit_BLName.Clear();

                        break;
                    }
                case 32:    // 拠点＋地区
                    {
                        this.tEdit_SectionCode.Enabled = true;
                        this.SectionGuide_Button.Enabled = true;
                        this.tNedit_SalesAreaCode.Enabled = true;
                        this.SalesAreaGuide_Button.Enabled = true;

                        this.tNedit_CustomerCode.Enabled = false;
                        this.CustomerGuide_Button.Enabled = false;
                        this.tEdit_EmployeeCode.Enabled = false;
                        this.EmployeeGuide_Button.Enabled = false;
                        this.tNedit_BLGloupCode.Enabled = false;
                        this.GroupGuide_Button.Enabled = false;
                        this.tNedit_SalesCode.Enabled = false;
                        this.SalesCodeGuide_Button.Enabled = false;
                        this.tNedit_BLGoodsCode.Enabled = false;
                        this.BLGuide_Button.Enabled = false;

                        this.tNedit_CustomerCode.Clear();
                        this.tEdit_CustomerName.Clear();
                        this.tEdit_EmployeeCode.Clear();
                        this.tEdit_EmployeeName.Clear();
                        this.tNedit_BLGloupCode.Clear();
                        this.tEdit_GroupName.Clear();
                        this.tNedit_SalesCode.Clear();
                        this.tEdit_SalesCodeName.Clear();
                        this.tNedit_BLGoodsCode.Clear();
                        this.tEdit_BLName.Clear();

                        break;
                    }
                case 50:    // 拠点＋BLコード
                    {
                        this.tEdit_SectionCode.Enabled = true;
                        this.SectionGuide_Button.Enabled = true;
                        this.tNedit_BLGloupCode.Enabled = true;
                        this.GroupGuide_Button.Enabled = true;

                        this.tNedit_CustomerCode.Enabled = false;
                        this.CustomerGuide_Button.Enabled = false;
                        this.tEdit_EmployeeCode.Enabled = false;
                        this.EmployeeGuide_Button.Enabled = false;
                        this.tNedit_SalesAreaCode.Enabled = false;
                        this.SalesAreaGuide_Button.Enabled = false;
                        this.tNedit_SalesCode.Enabled = false;
                        this.SalesCodeGuide_Button.Enabled = false;
                        this.tNedit_BLGoodsCode.Enabled = false;
                        this.BLGuide_Button.Enabled = false;

                        this.tNedit_CustomerCode.Clear();
                        this.tEdit_CustomerName.Clear();
                        this.tEdit_EmployeeCode.Clear();
                        this.tEdit_EmployeeName.Clear();
                        this.tNedit_SalesAreaCode.Clear();
                        this.tEdit_SalesAreaName.Clear();
                        this.tNedit_SalesCode.Clear();
                        this.tEdit_SalesCodeName.Clear();
                        this.tNedit_BLGoodsCode.Clear();
                        this.tEdit_BLName.Clear();

                        break;
                    }
                case 44:    // 拠点＋販売区分
                    {
                        this.tEdit_SectionCode.Enabled = true;
                        this.SectionGuide_Button.Enabled = true;
                        this.tNedit_SalesCode.Enabled = true;
                        this.SalesCodeGuide_Button.Enabled = true;

                        this.tNedit_CustomerCode.Enabled = false;
                        this.CustomerGuide_Button.Enabled = false;
                        this.tEdit_EmployeeCode.Enabled = false;
                        this.EmployeeGuide_Button.Enabled = false;
                        this.tNedit_SalesAreaCode.Enabled = false;
                        this.SalesAreaGuide_Button.Enabled = false;
                        this.tNedit_BLGloupCode.Enabled = false;
                        this.GroupGuide_Button.Enabled = false;
                        this.tNedit_BLGoodsCode.Enabled = false;
                        this.BLGuide_Button.Enabled = false;

                        this.tNedit_CustomerCode.Clear();
                        this.tEdit_CustomerName.Clear();
                        this.tEdit_EmployeeCode.Clear();
                        this.tEdit_EmployeeName.Clear();
                        this.tNedit_SalesAreaCode.Clear();
                        this.tEdit_SalesAreaName.Clear();
                        this.tNedit_BLGloupCode.Clear();
                        this.tEdit_GroupName.Clear();
                        this.tNedit_BLGoodsCode.Clear();
                        this.tEdit_BLName.Clear();

                        break;
                    }
                case 60:    // 拠点＋BLグループコード
                    {
                        this.tEdit_SectionCode.Enabled = true;
                        this.SectionGuide_Button.Enabled = true;
                        this.tNedit_BLGoodsCode.Enabled = true;
                        this.BLGuide_Button.Enabled = true;

                        this.tNedit_CustomerCode.Enabled = false;
                        this.CustomerGuide_Button.Enabled = false;
                        this.tEdit_EmployeeCode.Enabled = false;
                        this.EmployeeGuide_Button.Enabled = false;
                        this.tNedit_SalesAreaCode.Enabled = false;
                        this.SalesAreaGuide_Button.Enabled = false;
                        this.tNedit_BLGloupCode.Enabled = false;
                        this.GroupGuide_Button.Enabled = false;
                        this.tNedit_SalesCode.Enabled = false;
                        this.SalesCodeGuide_Button.Enabled = false;

                        this.tNedit_CustomerCode.Clear();
                        this.tEdit_CustomerName.Clear();
                        this.tEdit_EmployeeCode.Clear();
                        this.tEdit_EmployeeName.Clear();
                        this.tNedit_SalesAreaCode.Clear();
                        this.tEdit_SalesAreaName.Clear();
                        this.tNedit_BLGloupCode.Clear();
                        this.tEdit_GroupName.Clear();
                        this.tNedit_SalesCode.Clear();
                        this.tEdit_SalesCodeName.Clear();

                        break;
                    }
            }
        }

        /// <summary>
        /// コントロールEnabled制御処理
        /// </summary>
        /// <param name="editMode">編集モード</param>
        /// <remarks>
        /// <br>Note       : コントロールのEnabled制御を行います。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/25</br>
        /// <br>Update Note: 2011/07/05 譚洪 Redmine#22750 フォーカス制御障害の対応</br>
        /// </remarks>
        private void SetControlEnabled(string editMode)
        {
            switch (editMode)
            {
                case INSERT_MODE:
                    {
                        this.tComboEditor_TargetContrastCd.Enabled = true;

                        this.tNedit_SalesTargetSale.Enabled = true;
                        this.tNedit_SalesTargetProfit.Enabled = true;
                        this.tNedit_SalesTargetCount.Enabled = true;
                        this.tNedit_SalesTargetSale1.Enabled = true;
                        this.tNedit_SalesTargetProfit1.Enabled = true;
                        this.tNedit_SalesTargetCount1.Enabled = true;
                        this.tNedit_CampaignCode.Enabled = true;
                        this.CampaignGuide_Button.Enabled = true;

                        this.SalesTarget_uGrid.Enabled = true;

                        this._isClose = true;
                        this._isSave = true;
                        this._isNew = true;
                        this._isRevival = false;
                        this._isLogicalDelete = false;
                        this._isDelete = false;
                        this._isUndo = true;
                        this._isRenewal = true;
                        this._isGuide = true;

                        break;
                    }
                case UPDATE_MODE:
                    {

                        // テーブルキー項目は入力不可
                        // ----- DEL K2011/07/05 ------- >>>>>>>>>
                        //this.tComboEditor_TargetContrastCd.Enabled = false;
                        //this.tEdit_SectionCode.Enabled = false;
                        //this.SectionGuide_Button.Enabled = false;
                        //this.tNedit_CustomerCode.Enabled = false;
                        //this.CustomerGuide_Button.Enabled = false;
                        //this.tEdit_EmployeeCode.Enabled = false;
                        //this.EmployeeGuide_Button.Enabled = false;
                        //this.tNedit_SalesAreaCode.Enabled = false;
                        //this.SalesAreaGuide_Button.Enabled = false;
                        //this.tNedit_BLGloupCode.Enabled = false;
                        //this.GroupGuide_Button.Enabled = false;
                        //this.tNedit_SalesCode.Enabled = false;
                        //this.SalesCodeGuide_Button.Enabled = false;
                        //this.tNedit_CampaignCode.Enabled = false;
                        //this.CampaignGuide_Button.Enabled = false;

                        //this.tNedit_BLGoodsCode.Enabled = false;
                        //this.BLGuide_Button.Enabled = false;
                        // ----- DEL K2011/07/05 ------- <<<<<<<<<

                        // ----- ADD K2011/07/05 ------- >>>>>>>>>
                        this.tComboEditor_TargetContrastCd.Enabled = true;
                        this.tNedit_CampaignCode.Enabled = true;
                        this.CampaignGuide_Button.Enabled = true;
                        ChangeTargetContrastControl((int)this.tComboEditor_TargetContrastCd.Value);
                        // ----- ADD K2011/07/05 ------- <<<<<<<<<


                        this.tNedit_SalesTargetSale.Enabled = true;
                        this.tNedit_SalesTargetProfit.Enabled = true;
                        this.tNedit_SalesTargetCount.Enabled = true;
                        this.tNedit_SalesTargetSale1.Enabled = true;
                        this.tNedit_SalesTargetProfit1.Enabled = true;
                        this.tNedit_SalesTargetCount1.Enabled = true;

                        this.SalesTarget_uGrid.Enabled = true;

                        this._isClose = true;
                        this._isSave = true;
                        this._isNew = true;
                        this._isRevival = false;
                        this._isLogicalDelete = true;
                        this._isDelete = false;
                        this._isUndo = true;
                        this._isRenewal = true;
                        //this._isGuide = false;  // DEL K2011/07/05 
                        this._isGuide = true;   // ADD K2011/07/05 

                        break;
                    }
                case DELETE_MODE:
                    {
                        // テーブルキー項目は入力不可
                        this.tComboEditor_TargetContrastCd.Enabled = false;
                        this.tEdit_SectionCode.Enabled = false;
                        this.SectionGuide_Button.Enabled = false;
                        this.tNedit_CustomerCode.Enabled = false;
                        this.CustomerGuide_Button.Enabled = false;
                        this.tEdit_EmployeeCode.Enabled = false;
                        this.EmployeeGuide_Button.Enabled = false;
                        this.tNedit_SalesAreaCode.Enabled = false;
                        this.SalesAreaGuide_Button.Enabled = false;
                        this.tNedit_BLGloupCode.Enabled = false;
                        this.GroupGuide_Button.Enabled = false;
                        this.tNedit_SalesCode.Enabled = false;
                        this.SalesCodeGuide_Button.Enabled = false;
                        this.tNedit_CampaignCode.Enabled = false;
                        this.CampaignGuide_Button.Enabled = false;
                        this.tNedit_BLGoodsCode.Enabled = false;
                        this.BLGuide_Button.Enabled = false;



                        this.tNedit_SalesTargetSale.Enabled = false;
                        this.tNedit_SalesTargetProfit.Enabled = false;
                        this.tNedit_SalesTargetCount.Enabled = false;
                        this.tNedit_SalesTargetSale1.Enabled = false;
                        this.tNedit_SalesTargetProfit1.Enabled = false;
                        this.tNedit_SalesTargetCount1.Enabled = false;

                        this.SalesTarget_uGrid.Enabled = false;

                        this._isClose = true;
                        this._isSave = false;
                        this._isNew = true;
                        this._isDelete = true;
                        this._isRevival = true;
                        this._isLogicalDelete = false;
                        this._isUndo = false;
                        this._isRenewal = false;
                        this._isGuide = false;

                        break;
                    }
            }

            SetToolButtonVisible(this);
        }
        #endregion コントロールEnabled制御


        #region キーコントロールDisable制御
        /// <summary>
        /// キーコントロールDisable制御処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : キーコントロールのDisable制御を行います。</br>
        /// <br></br>
        /// </remarks>
        private void SetKeyControlDisable()
        {
            // テーブルキー項目は入力不可
            this.tNedit_CampaignCode.Enabled = false;
            this.CampaignGuide_Button.Enabled = false;
            this.tComboEditor_TargetContrastCd.Enabled = false;
            this.tEdit_SectionCode.Enabled = false;
            this.SectionGuide_Button.Enabled = false;


            this.tNedit_CustomerCode.Enabled = false;
            this.CustomerGuide_Button.Enabled = false;
            this.tEdit_EmployeeCode.Enabled = false;
            this.EmployeeGuide_Button.Enabled = false;
            this.tNedit_SalesAreaCode.Enabled = false;
            this.SalesAreaGuide_Button.Enabled = false;
            this.tNedit_BLGloupCode.Enabled = false;
            this.GroupGuide_Button.Enabled = false;
            this.tNedit_BLGoodsCode.Enabled = false;
            this.BLGuide_Button.Enabled = false;
            this.tNedit_SalesCode.Enabled = false;
            this.SalesCodeGuide_Button.Enabled = false;

        }
        #endregion キーコントロールDisable制御


        #region Focus設定
        /// <summary>
        /// Nextコントロール取得処理
        /// </summary>
        /// <param name="prevControl">現在コントロール</param>
        /// <param name="nextControl">Nextコントロール</param>
        /// <remarks>
        /// <br>Note       : Nextコントロールを取得します。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void GetNextControl(Control prevControl, out Control nextControl)
        {
            nextControl = null;

            if (prevControl == null)
            {
                return;
            }

            // 設定区分
            int targetContrastCd = (int)this.tComboEditor_TargetContrastCd.Value;

            switch (prevControl.Name)
            {
                case "tNedit_CampaignCode":
                case "CampaignGuide_Button":
                    {
                        nextControl = this.tComboEditor_TargetContrastCd;
                        break;
                    }
                case "tEdit_SectionCode":
                case "SectionGuide_Button":
                    {
                        switch (targetContrastCd)
                        {
                            case 10:    // 拠点
                                {
                                    nextControl = this.tNedit_SalesTargetSale;
                                    break;
                                }
                            case 30:    // 拠点＋得意先
                                {
                                    nextControl = this.tNedit_CustomerCode;
                                    break;
                                }
                            case 221:   // 拠点＋担当者
                            case 222:   // 拠点＋受注者
                            case 223:   // 拠点＋発行者
                                {
                                    nextControl = this.tEdit_EmployeeCode;
                                    break;
                                }
                            case 32:    // 拠点＋地区
                                {
                                    nextControl = this.tNedit_SalesAreaCode;
                                    break;
                                }
                            case 50:    // 拠点＋グループコード
                                {
                                    nextControl = this.tNedit_BLGloupCode;
                                    break;
                                }
                            case 60:    // 拠点＋BLコード
                                {
                                    nextControl = this.tNedit_BLGoodsCode;
                                    break;
                                }
                            case 44:    // 拠点＋販売区分
                                {
                                    nextControl = tNedit_SalesCode;
                                    break;
                                }
                        }
                        break;
                    }
                case "tNedit_CustomerCode":
                case "CustomerGuide_Button":
                case "tEdit_EmployeeCode":
                case "EmployeeGuide_Button":
                case "tNedit_SalesAreaCode":
                case "SalesAreaGuide_Button":
                case "tNedit_BLGloupCode":
                case "GroupGuide_Button":
                case "tNedit_BLGoodsCode":
                case "BLGuide_Button":
                case "tNedit_SalesCode":
                case "SalesCodeGuide_Button":

                    {
                        nextControl = this.tNedit_SalesTargetSale;
                        break;
                    }
            }
        }

        /// <summary>
        /// NextCell設定処理
        /// </summary>
        /// <param name="e">イベントハンドら</param>
        /// <param name="shiftFlg">ShiftKey押下フラグ(True:押下 Flase:押下せず)</param>
        /// <remarks>
        /// <br>Note       : NextCellを設定します。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void SetNextCell(ref ChangeFocusEventArgs e, bool shiftFlg)
        {
            int rowIndex;
            int columnIndex;

            if (this.SalesTarget_uGrid.ActiveCell == null)
            {
                if (this.SalesTarget_uGrid.ActiveRow == null)
                {
                    rowIndex = 0;
                    columnIndex = 1;
                }
                else
                {
                    rowIndex = this.SalesTarget_uGrid.ActiveRow.Index;
                    columnIndex = 1;
                }
            }
            else
            {
                rowIndex = this.SalesTarget_uGrid.ActiveCell.Row.Index;
                columnIndex = this.SalesTarget_uGrid.ActiveCell.Column.Index;
            }

            e.NextCtrl = null;

            if (shiftFlg == false)
            {
                if (rowIndex < 11)
                {
                    this.SalesTarget_uGrid.Rows[rowIndex + 1].Cells[columnIndex].Activate();
                    this.SalesTarget_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                }
                else
                {
                    if (columnIndex < 3)
                    {
                        this.SalesTarget_uGrid.Rows[0].Cells[columnIndex + 1].Activate();
                        this.SalesTarget_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                    }
                    else
                    {
                        if (this.Mode_Label.Text == INSERT_MODE)
                        {
                            this.tNedit_CampaignCode.Focus();
                        }
                        else
                        {
                            this.tNedit_SalesTargetSale.Focus();
                        }
                    }
                }
            }
            else
            {
                if (rowIndex > 0)
                {
                    this.SalesTarget_uGrid.Rows[rowIndex - 1].Cells[columnIndex].Activate();
                    this.SalesTarget_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                }
                else
                {
                    if (columnIndex > 1)
                    {
                        this.SalesTarget_uGrid.Rows[11].Cells[columnIndex - 1].Activate();
                        this.SalesTarget_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                    }
                    else
                    {
                        this.tNedit_SalesTargetCount1.Focus();
                    }
                }
            }
        }
        #endregion Focus設定

        #region 保存処理
        /// <summary>
        /// 保存処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : キャンペーン目標設定を保存します。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private int SaveProc()
        {
            this.SalesTarget_uGrid.ActiveCell = null;

            // 入力チェック
            bool bStatus = CheckScreenInput(true);
            if (!bStatus)
            {
                return -1;
            }

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            status = SaveCampaignTarget();

            return (status);
        }

        /// <summary>
        /// 保存処理(キャンペーン目標)
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : キャンペーン目標設定を保存します。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private int SaveCampaignTarget()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // 画面情報取得
            List<CampaignTarget> campaignTargetList = new List<CampaignTarget>();
            ScreenToCampaignTargetList(ref campaignTargetList);

            // 削除リスト取得
            List<CampaignTarget> deleteList = new List<CampaignTarget>();
            if (this._campaignTargetDicClone.ContainsKey("1"))
            {
                deleteList.Add(this._campaignTargetDicClone["1"]);
            }

            // 削除処理
            if (deleteList.Count > 0)
            {
                status = this._campaignTargetAcs.Delete(deleteList);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                        {
                            // 排他処理
                            ExclusiveTransaction(status);
                            return (status);
                        }
                    default:
                        {
                            ShowMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                           "SaveProc",
                           "保存処理に失敗しました。",
                           status,
                           MessageBoxButtons.OK);
                            return (status);
                        }
                }
            }

            

            // 保存処理
            status = this._campaignTargetAcs.Write(ref campaignTargetList);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        SaveCompletionDialog dialog = new SaveCompletionDialog();
                        dialog.ShowDialog(2);

                        this.Mode_Label.Text = INSERT_MODE;

                        if (this.Mode_Label.Text == INSERT_MODE)
                        {
                            // コントロールEnabled制御
                            SetControlEnabled(INSERT_MODE);
                            ComboChgClearScreen();
                            // 設定区分条件コントロールEnabled制御
                            ChangeTargetContrastControl((int)this.tComboEditor_TargetContrastCd.Value);
                            this.tEdit_SectionCode.Focus();
                        }

                        // バッファ更新
                        this._campaignTargetDicClone.Clear();
                        foreach (CampaignTarget campaignTarget in campaignTargetList)
                        {
                            for (int index = 1; index < 13; index++)
                            {
                                this._campaignTargetDicClone.Add(index.ToString(), campaignTarget);
                            }

                        }

                        return (status);
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    {
                        // 排他処理
                        ExclusiveTransaction(status);
                        return (status);
                    }
                default:
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_STOP,
                                       "SaveProc",
                                       "保存処理に失敗しました。",
                                       status,
                                       MessageBoxButtons.OK);

                        return (status);
                    }
            }
        }
        #endregion 保存処理

        #region 元に戻す処理
        /// <summary>
        /// 元に戻す処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 画面状態を元に戻します。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private int UndoProc()
        {
            if (this.Mode_Label.Text == INSERT_MODE)
            {
                // 画面初期化
                ClearScreen();

                // コントロールEnabled制御
                SetControlEnabled(INSERT_MODE);

                // 設定区分条件コントロールEnabled制御
                ChangeTargetContrastControl((int)this.tComboEditor_TargetContrastCd.Value);

                // フォーカスセット
                this.tNedit_CampaignCode.Focus();
            }
            else if (this.Mode_Label.Text == UPDATE_MODE)
            {
                CampaignTargetToScreen(this._campaignTargetDicClone);
            }
            // ボタンツール有効無効設定処理
            this.SettingGuideButtonToolEnabled(this.ActiveControl);
            return 0;
        }
        #endregion 元に戻す処理

        #region 論理削除処理
        /// <summary>
        /// 論理削除処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : キャンペーン目標設定を論理削除します。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private int LogicalDeleteProc()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            status = LogicalDeleteCampaignTarget();

            return (status);
        }

        /// <summary>
        /// 論理削除処理(キャンペーン目標)
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : キャンペーン目標設定を論理削除します。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private int LogicalDeleteCampaignTarget()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            List<CampaignTarget> campaignTargetList = new List<CampaignTarget>();
            if (this._campaignTargetDicClone.ContainsKey("1"))
            {
                campaignTargetList.Add(this._campaignTargetDicClone["1"]);
            }
            

            // 論理削除
            status = this._campaignTargetAcs.LogicalDelete(ref campaignTargetList);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // 編集モード変更
                        this.Mode_Label.Text = DELETE_MODE;

                        // コントロールEnabled制御
                        SetControlEnabled(DELETE_MODE);

                        // バッファ更新
                        this._campaignTargetDicClone.Clear();
                        foreach (CampaignTarget campaignTarget in campaignTargetList)
                        {
                            for (int index = 1; index < 13; index++)
                            {
                                this._campaignTargetDicClone.Add(index.ToString(), campaignTarget);
                            }
                        }

                        // 画面展開
                        CampaignTargetToScreen(this._campaignTargetDicClone);

                        return (status);
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        // 排他処理
                        ExclusiveTransaction(status);
                        return (status);
                    }
                default:
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_STOP,
                                       "LogicalDeleteProc",
                                       "削除処理に失敗しました。",
                                       status,
                                       MessageBoxButtons.OK);

                        return (status);
                    }
            }
        }
        #endregion 論理削除処理

        #region 物理削除処理
        /// <summary>
        /// 物理削除処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : キャンペーン目標設定を物理削除します。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private int DeleteProc()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            List<CampaignTarget> campaignTargetList = new List<CampaignTarget>();
            if (this._campaignTargetDicClone.ContainsKey("1"))
            {
                campaignTargetList.Add(this._campaignTargetDicClone["1"]);
            }

            // 物理削除
            status = this._campaignTargetAcs.Delete(campaignTargetList);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // 編集モード変更
                        this.Mode_Label.Text = INSERT_MODE;

                        // コントロールEnabled制御
                        SetControlEnabled(INSERT_MODE);

                        // 設定区分条件コントロールEnabled制御
                        ChangeTargetContrastControl((int)this.tComboEditor_TargetContrastCd.Value);

                        // 画面クリア
                        ClearScreen();

                        // フォーカスセット
                        this.tNedit_CampaignCode.Focus();

                        // バッファ更新
                        this._campaignTargetDicClone.Clear();

                        // 設定区分条件コントロールEnabled制御
                        ChangeTargetContrastControl((int)this.tComboEditor_TargetContrastCd.Value);
                        return (status);
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        // 排他処理
                        ExclusiveTransaction(status);
                        return (status);
                    }
                default:
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_STOP,
                                       "DeleteProc",
                                       "完全削除処理に失敗しました。",
                                       status,
                                       MessageBoxButtons.OK);

                        return (status);
                    }
            }
        }
        #endregion 物理削除処理

        #region 復活処理
        /// <summary>
        /// 復活処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : キャンペーン目標設定を復活します。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private int RevivalProc()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            status = RevivalCampaignTarget();

            return (status);
        }

        /// <summary>
        /// 復活処理(キャンペーン目標)
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : キャンペーン目標設定を復活します。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private int RevivalCampaignTarget()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            List<CampaignTarget> campaignTargetList = new List<CampaignTarget>();
            if (this._campaignTargetDicClone.ContainsKey("1"))
            {
                campaignTargetList.Add(this._campaignTargetDicClone["1"]);
            }

            // 復活
            status = this._campaignTargetAcs.Revival(ref campaignTargetList);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // 編集モード変更
                        this.Mode_Label.Text = UPDATE_MODE;

                        // コントロールEnabled制御
                        SetControlEnabled(UPDATE_MODE);

                        // バッファ更新
                        this._campaignTargetDicClone.Clear();
                        foreach (CampaignTarget campaignTarget in campaignTargetList)
                        {
                            for (int index = 1; index < 13; index++)
                            {
                                this._campaignTargetDicClone.Add(index.ToString(), campaignTarget);
                            }
                        }

                        return (status);
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        // 排他処理
                        ExclusiveTransaction(status);
                        return (status);
                    }
                default:
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_STOP,
                                       "RevivalProc",
                                       "復活処理に失敗しました。",
                                       status,
                                       MessageBoxButtons.OK);

                        return (status);
                    }
            }
        }

        #endregion 復活処理



        #region 最新情報取得処理
        /// <summary>
        /// 最新情報取得処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 最新情報を取得します。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private int RenewalProc()
        {
            // 各種マスタ取得
            bool bStatus = ReadMaster();
            if (!bStatus)
            {
                return (-1);
            }

            ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                   "最新情報を取得しました。",
                                   0,
                                   MessageBoxButtons.OK,
                                   MessageBoxDefaultButton.Button1);

            return (0);
        }
        #endregion 最新情報取得処理

        #region チェック処理
        /// <summary>
        /// 入力チェック処理
        /// </summary>
        /// <param name="beforeSaveFlg">保存前フラグ(True:保存前 False:検索時)</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 画面情報の入力チェックを行います。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private bool CheckScreenInput(bool beforeSaveFlg)
        {
            bool bStatus;

            // 入力チェック(条件)
            bStatus = CheckCondition(beforeSaveFlg);
            if (!bStatus)
            {
                return (false);
            }

            // ----- DEL 2011/07/05 ---- >>>>
            //if (beforeSaveFlg == true)
            //{
            //    // 入力チェック(目標)
            //    bStatus = CheckSalesTarget();
            //    if (!bStatus)
            //    {
            //        return (false);
            //    }
            //}
            // ----- DEL 2011/07/05 ---- <<<<

            return (true);
        }

        /// <summary>
        /// 入力チェック処理(条件)
        /// </summary>
        /// <param name="beforeSaveFlg">保存前フラグ(True:保存前 False:検索時)</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 画面情報の入力チェックを行います。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private bool CheckCondition(bool beforeSaveFlg)
        {
            // 一括ゼロ詰め
            this.uiSetControl1.SettingAllControlsZeroPaddedText();

            string errMsg = "";
            Control control = null;

            try
            {
                if (this.tNedit_CampaignCode.GetInt() == 0)
                {
                    errMsg = "キャンペーンコードを入力して下さい。";
                    control = this.tNedit_CampaignCode;
                    return (false);
                }
                int campaignCode = this.tNedit_CampaignCode.GetInt();
                if (this.Mode_Label.Text == INSERT_MODE && GetCampaignName(campaignCode) == "")
                {
                    errMsg = "キャンペーンコードが存在しません。";
                    control = this.tEdit_SectionCode;
                    return (false);
                }

                // 設定区分
                int targetContrastCd = (int)this.tComboEditor_TargetContrastCd.Value;
                switch (targetContrastCd)
                {
                    default:
                        {
                            if (this.tEdit_SectionCode.DataText.Trim() == "")
                            {
                                errMsg = "拠点を入力してください。";
                                control = this.tEdit_SectionCode;
                                return (false);
                            }

                            string sectionCode = this.tEdit_SectionCode.DataText.Trim();
                            if (this.Mode_Label.Text == INSERT_MODE && GetSectionName(sectionCode) == "")
                            {
                                errMsg = "マスタに登録されていません。";
                                control = this.tEdit_SectionCode;
                                return (false);
                            }

                            if (targetContrastCd == 30)
                            {
                                if (this.tNedit_CustomerCode.GetInt() == 0)
                                {
                                    errMsg = "得意先を入力してください。";
                                    control = this.tNedit_CustomerCode;
                                    return (false);
                                }

                                int customerCode = this.tNedit_CustomerCode.GetInt();
                                if (this.Mode_Label.Text == INSERT_MODE && !CheckCustomer(customerCode))
                                {
                                    errMsg = "マスタに登録されていません。";
                                    control = this.tNedit_CustomerCode;
                                    return (false);
                                }
                            }
                            else if ((targetContrastCd == 221) || (targetContrastCd == 222) || (targetContrastCd == 223))
                            {
                                if (this.tEdit_EmployeeCode.DataText.Trim() == "")
                                {
                                    if (targetContrastCd == 221)
                                    {
                                        errMsg = "担当者を入力してください。";
                                    }
                                    else if (targetContrastCd == 222)
                                    {
                                        errMsg = "受注者を入力してください。";
                                    }
                                    else
                                    {
                                        errMsg = "発行者を入力してください。";
                                    }
                                    control = this.tEdit_EmployeeCode;
                                    return (false);
                                }

                                string employeeCode = this.tEdit_EmployeeCode.DataText.Trim();
                                if (this.Mode_Label.Text == INSERT_MODE && GetEmployeeName(employeeCode) == "")
                                {
                                    errMsg = "マスタに登録されていません。";
                                    control = this.tEdit_EmployeeCode;
                                    return (false);
                                }
                            }
                            else if (targetContrastCd == 32)
                            {
                                if (this.tNedit_SalesAreaCode.GetInt() == 0)
                                {
                                    errMsg = "地区を入力してください。";
                                    control = this.tNedit_SalesAreaCode;
                                    return (false);
                                }

                                int salesAreaCode = this.tNedit_SalesAreaCode.GetInt();
                                if (this.Mode_Label.Text == INSERT_MODE && GetSalesAreaName(salesAreaCode) == "")
                                {
                                    errMsg = "マスタに登録されていません。";
                                    control = this.tNedit_SalesAreaCode;
                                    return (false);
                                }
                            }
                            else if (targetContrastCd == 50)
                            {
                                if (this.tNedit_BLGloupCode.GetInt() == 0)
                                {
                                    errMsg = "グループコードを入力してください。";
                                    control = this.tNedit_BLGloupCode;
                                    return (false);
                                }

                                int groupCode = this.tNedit_BLGloupCode.GetInt();
                                if (this.Mode_Label.Text == INSERT_MODE && GetBLGroupName(groupCode) == "")
                                {
                                    errMsg = "マスタに登録されていません。";
                                    control = this.tNedit_BLGloupCode;
                                    return (false);
                                }
                            }
                            else if (targetContrastCd == 44)
                            {
                                if (this.tNedit_SalesCode.GetInt() == 0)
                                {
                                    errMsg = "販売区分を入力してください。";
                                    control = this.tNedit_SalesCode;
                                    return (false);
                                }

                                int salesCode = this.tNedit_SalesCode.GetInt();
                                if (this.Mode_Label.Text == INSERT_MODE && GetSalesCodeName(salesCode) == "")
                                {
                                    errMsg = "マスタに登録されていません。";
                                    control = this.tNedit_SalesCode;
                                    return (false);
                                }
                            }
                            else if (targetContrastCd == 60)
                            {
                                if (this.tNedit_BLGoodsCode.GetInt() == 0)
                                {
                                    errMsg = "BLコードを入力してください。";
                                    control = this.tNedit_SalesCode;
                                    return (false);
                                }

                                int blCode = this.tNedit_BLGoodsCode.GetInt();
                                if (this.Mode_Label.Text == INSERT_MODE && GetBLGoodsName(blCode) == "")
                                {
                                    errMsg = "マスタに登録されていません。";
                                    control = this.tNedit_BLGoodsCode;
                                    return (false);
                                }
                            }

                            break;
                        }
                }
            }
            finally
            {
                if ((errMsg.Length > 0) && (beforeSaveFlg == true))
                {
                    control.Focus();

                    this.SettingGuideButtonToolEnabled(control);

                    ShowMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                   errMsg,
                                   0,
                                   MessageBoxButtons.OK,
                                   MessageBoxDefaultButton.Button1);
                }
            }

            return (true);
        }

        /// <summary>
        /// 入力チェック処理(目標)
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 画面情報の入力チェックを行います。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private bool CheckSalesTarget()
        {
            string errMsg = "";

            try
            {
                bool inputFlg = false;
                for (int index = 0; index < 12; index++)
                {
                    // セル値変換
                    if ((ChangeCellValue(this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_SALESTARGET].Value) == 0) &&
                        (ChangeCellValue(this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_PROFITTARGET].Value) == 0) &&
                        (ChangeCellValue(this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_COUNTTARGET].Value) == 0))
                    {
                        continue;
                    }

                    inputFlg = true;
                }

                if (inputFlg == false)
                {
                    errMsg = "目標を入力してください。";
                    this.SalesTarget_uGrid.Focus();
                    this.SalesTarget_uGrid.Rows[0].Cells[COLUMN_SALESTARGET].Activate();
                    this.SalesTarget_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                    return (false);
                }
            }
            finally
            {
                if (errMsg.Length > 0)
                {
                    ShowMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                   errMsg,
                                   0,
                                   MessageBoxButtons.OK,
                                   MessageBoxDefaultButton.Button1);
                }
            }

            return (true);
        }

        /// <summary>
        /// 画面情報変更チェック処理
        /// </summary>
        /// <returns>ステータス(True:変更なし　False:変更あり)</returns>
        /// <remarks>
        /// <br>Note       : 画面情報が変更されているかどうかチェックします。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private bool CompareInputScreen()
        {
            if (this.Mode_Label.Text == INSERT_MODE)
            {
                if (this.tNedit_CampaignCode.GetInt() != 0)
                {
                    return (false);
                }
                if ((int)this.tComboEditor_TargetContrastCd.Value != 10)
                {
                    return (false);
                }
                if (this.tEdit_SectionCode.DataText.Trim() != "")
                {
                    return (false);
                }
                if (this.tNedit_CustomerCode.GetInt() != 0)
                {
                    return (false);
                }
                if (this.tEdit_EmployeeCode.DataText.Trim() != "")
                {
                    return (false);
                }
                if (this.tNedit_SalesAreaCode.GetInt() != 0)
                {
                    return (false);
                }
                if (this.tNedit_BLGloupCode.GetInt() != 0)
                {
                    return (false);
                }
                if (this.tNedit_SalesCode.GetInt() != 0)
                {
                    return (false);
                }
                if (this.tNedit_BLGoodsCode.GetInt() != 0)
                {
                    return (false);
                }
            }

            return CompareInputGrid();
        }

        /// <summary>
        /// グリッド情報変更チェック処理
        /// </summary>
        /// <returns>ステータス(True:変更なし　False:変更あり)</returns>
        /// <remarks>
        /// <br>Note       : グリッドが変更されているかどうかチェックします。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private bool CompareInputGrid()
        {
            List<CampaignTarget> campaignTargetList = new List<CampaignTarget>();
            List<CampaignTarget> campaignTargetListCam = new List<CampaignTarget>();
            ScreenToCampaignTargetList(ref campaignTargetList);
            if (this._campaignTargetDicClone.Count != 0)
            {
                campaignTargetListCam.Add(this._campaignTargetDicClone["1"]);

                if (!((campaignTargetList[0].MonthlySalesTarget == campaignTargetListCam[0].MonthlySalesTarget)
                && (campaignTargetList[0].TermSalesTarget == campaignTargetListCam[0].TermSalesTarget)
                && (campaignTargetList[0].MonthlySalesTargetProfit == campaignTargetListCam[0].MonthlySalesTargetProfit)
                && (campaignTargetList[0].TermSalesTargetProfit == campaignTargetListCam[0].TermSalesTargetProfit)
                && (campaignTargetList[0].MonthlySalesTargetCount == campaignTargetListCam[0].MonthlySalesTargetCount)
                && (campaignTargetList[0].TermSalesTargetCount == campaignTargetListCam[0].TermSalesTargetCount)
                && (campaignTargetList[0].SalesTargetProfit1 == campaignTargetListCam[0].SalesTargetProfit1)
                && (campaignTargetList[0].SalesTargetProfit2 == campaignTargetListCam[0].SalesTargetProfit2)
                && (campaignTargetList[0].SalesTargetProfit3 == campaignTargetListCam[0].SalesTargetProfit3)
                && (campaignTargetList[0].SalesTargetProfit4 == campaignTargetListCam[0].SalesTargetProfit4)
                && (campaignTargetList[0].SalesTargetProfit5 == campaignTargetListCam[0].SalesTargetProfit5)
                && (campaignTargetList[0].SalesTargetProfit6 == campaignTargetListCam[0].SalesTargetProfit6)
                && (campaignTargetList[0].SalesTargetProfit7 == campaignTargetListCam[0].SalesTargetProfit7)
                && (campaignTargetList[0].SalesTargetProfit8 == campaignTargetListCam[0].SalesTargetProfit8)
                && (campaignTargetList[0].SalesTargetProfit9 == campaignTargetListCam[0].SalesTargetProfit9)
                && (campaignTargetList[0].SalesTargetProfit10 == campaignTargetListCam[0].SalesTargetProfit10)
                && (campaignTargetList[0].SalesTargetProfit11 == campaignTargetListCam[0].SalesTargetProfit11)
                && (campaignTargetList[0].SalesTargetProfit12 == campaignTargetListCam[0].SalesTargetProfit12)
                && (campaignTargetList[0].SalesTargetMoney1 == campaignTargetListCam[0].SalesTargetMoney1)
                && (campaignTargetList[0].SalesTargetMoney2 == campaignTargetListCam[0].SalesTargetMoney2)
                && (campaignTargetList[0].SalesTargetMoney3 == campaignTargetListCam[0].SalesTargetMoney3)
                && (campaignTargetList[0].SalesTargetMoney4 == campaignTargetListCam[0].SalesTargetMoney4)
                && (campaignTargetList[0].SalesTargetMoney5 == campaignTargetListCam[0].SalesTargetMoney5)
                && (campaignTargetList[0].SalesTargetMoney6 == campaignTargetListCam[0].SalesTargetMoney6)
                && (campaignTargetList[0].SalesTargetMoney7 == campaignTargetListCam[0].SalesTargetMoney7)
                && (campaignTargetList[0].SalesTargetMoney8 == campaignTargetListCam[0].SalesTargetMoney8)
                && (campaignTargetList[0].SalesTargetMoney9 == campaignTargetListCam[0].SalesTargetMoney9)
                && (campaignTargetList[0].SalesTargetMoney10 == campaignTargetListCam[0].SalesTargetMoney10)
                && (campaignTargetList[0].SalesTargetMoney11 == campaignTargetListCam[0].SalesTargetMoney11)
                && (campaignTargetList[0].SalesTargetMoney12 == campaignTargetListCam[0].SalesTargetMoney12)
                && (campaignTargetList[0].SalesTargetCount1 == campaignTargetListCam[0].SalesTargetCount1)
                && (campaignTargetList[0].SalesTargetCount2 == campaignTargetListCam[0].SalesTargetCount2)
                && (campaignTargetList[0].SalesTargetCount3 == campaignTargetListCam[0].SalesTargetCount3)
                && (campaignTargetList[0].SalesTargetCount4 == campaignTargetListCam[0].SalesTargetCount4)
                && (campaignTargetList[0].SalesTargetCount5 == campaignTargetListCam[0].SalesTargetCount5)
                && (campaignTargetList[0].SalesTargetCount6 == campaignTargetListCam[0].SalesTargetCount6)
                && (campaignTargetList[0].SalesTargetCount7 == campaignTargetListCam[0].SalesTargetCount7)
                && (campaignTargetList[0].SalesTargetCount8 == campaignTargetListCam[0].SalesTargetCount8)
                && (campaignTargetList[0].SalesTargetCount9 == campaignTargetListCam[0].SalesTargetCount9)
                && (campaignTargetList[0].SalesTargetCount10 == campaignTargetListCam[0].SalesTargetCount10)
                && (campaignTargetList[0].SalesTargetCount11 == campaignTargetListCam[0].SalesTargetCount11)
                && (campaignTargetList[0].SalesTargetCount12 == campaignTargetListCam[0].SalesTargetCount12)
                ))
                {
                    return (false);
                }
            }
            else
            {
                if (campaignTargetList.Count == 0)
                {
                    return (true);
                }
                if (!((campaignTargetList[0].MonthlySalesTarget == 0)
                && (campaignTargetList[0].TermSalesTarget == 0)
                && (campaignTargetList[0].MonthlySalesTargetProfit == 0)
                && (campaignTargetList[0].TermSalesTargetProfit == 0)
                && (campaignTargetList[0].MonthlySalesTargetCount == 0)
                && (campaignTargetList[0].TermSalesTargetCount == 0)
                && (campaignTargetList[0].SalesTargetProfit1 == 0)
                && (campaignTargetList[0].SalesTargetProfit2 == 0)
                && (campaignTargetList[0].SalesTargetProfit3 == 0)
                && (campaignTargetList[0].SalesTargetProfit4 == 0)
                && (campaignTargetList[0].SalesTargetProfit5 == 0)
                && (campaignTargetList[0].SalesTargetProfit6 == 0)
                && (campaignTargetList[0].SalesTargetProfit7 == 0)
                && (campaignTargetList[0].SalesTargetProfit8 == 0)
                && (campaignTargetList[0].SalesTargetProfit9 == 0)
                && (campaignTargetList[0].SalesTargetProfit10 == 0)
                && (campaignTargetList[0].SalesTargetProfit11 == 0)
                && (campaignTargetList[0].SalesTargetProfit12 == 0)
                && (campaignTargetList[0].SalesTargetMoney1 == 0)
                && (campaignTargetList[0].SalesTargetMoney2 == 0)
                && (campaignTargetList[0].SalesTargetMoney3 == 0)
                && (campaignTargetList[0].SalesTargetMoney4 == 0)
                && (campaignTargetList[0].SalesTargetMoney5 == 0)
                && (campaignTargetList[0].SalesTargetMoney6 == 0)
                && (campaignTargetList[0].SalesTargetMoney7 == 0)
                && (campaignTargetList[0].SalesTargetMoney8 == 0)
                && (campaignTargetList[0].SalesTargetMoney9 == 0)
                && (campaignTargetList[0].SalesTargetMoney10 == 0)
                && (campaignTargetList[0].SalesTargetMoney11 == 0)
                && (campaignTargetList[0].SalesTargetMoney12 == 0)
                && (campaignTargetList[0].SalesTargetCount1 == 0)
                && (campaignTargetList[0].SalesTargetCount2 == 0)
                && (campaignTargetList[0].SalesTargetCount3 == 0)
                && (campaignTargetList[0].SalesTargetCount4 == 0)
                && (campaignTargetList[0].SalesTargetCount5 == 0)
                && (campaignTargetList[0].SalesTargetCount6 == 0)
                && (campaignTargetList[0].SalesTargetCount7 == 0)
                && (campaignTargetList[0].SalesTargetCount8 == 0)
                && (campaignTargetList[0].SalesTargetCount9 == 0)
                && (campaignTargetList[0].SalesTargetCount10 == 0)
                && (campaignTargetList[0].SalesTargetCount11 == 0)
                && (campaignTargetList[0].SalesTargetCount12 == 0)
                ))
                {
                    return (false);
                }
            
            }

            return (true);
        }

        /// <summary>
        /// 情報保存チェック処理
        /// </summary>
        /// <returns>ステータス(True:保存可能　False:保存不可)</returns>
        /// <remarks>
        /// <br>Note       : 情報保存されるかどうかチェックします。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/25</br>
        /// <br>Update Note: 2011/07/05 譚洪 Redmine#22750 フォーカス制御障害の対応</br>
        /// </remarks>
        private bool CheckSaveConfirm()
        {
            // 設定区分
            int targetContrastCd = (int)this.tComboEditor_TargetContrastCd.Value;


            if (this.tNedit_CampaignCode.GetInt() == 0)
            {
                return (false);
            }

            int campaignCode = this.tNedit_CampaignCode.GetInt();
            if (GetCampaignName(campaignCode) == "")
            {
                return (false);
            }


            if (this.tEdit_SectionCode.DataText.Trim() == "")
            {
                return (false);
            }

            string sectionCode = this.tEdit_SectionCode.DataText.Trim().PadLeft(2, '0');
            if (GetSectionName(sectionCode) == "")
            {
                return (false);
            }

            if (targetContrastCd == 30)
            {
                if (this.tNedit_CustomerCode.GetInt() == 0)
                {
                    return (false);
                }

                int customerCode = this.tNedit_CustomerCode.GetInt();
                if (!CheckCustomer(customerCode))
                {
                    return (false);
                }
            }
            else if ((targetContrastCd == 221) || (targetContrastCd == 222) || (targetContrastCd == 223))
            {
                if (this.tEdit_EmployeeCode.DataText.Trim() == "")
                {
                    return (false);
                }

                string employeeCode = this.tEdit_EmployeeCode.DataText.Trim().PadLeft(4, '0');
                if (GetEmployeeName(employeeCode) == "")
                {
                    return (false);
                }
            }
            else if (targetContrastCd == 32)
            {
                if (this.tNedit_SalesAreaCode.GetInt() == 0)
                {
                    return (false);
                }

                int salesAreaCode = this.tNedit_SalesAreaCode.GetInt();
                if (GetSalesAreaName(salesAreaCode) == "")
                {
                    return (false);
                }
            }
            else if (targetContrastCd == 50)
            {
                if (this.tNedit_BLGloupCode.GetInt() == 0)
                {
                    return (false);
                }

                int groupCode = this.tNedit_BLGloupCode.GetInt();
                if (GetBLGroupName(groupCode) == "")
                {
                    return (false);
                }
            }
            else if (targetContrastCd == 44)
            {
                if (this.tNedit_SalesCode.GetInt() == 0)
                {
                    return (false);
                }

                int salesCode = this.tNedit_SalesCode.GetInt();
                if (GetSalesCodeName(salesCode) == "")
                {
                    return (false);
                }
            }
            else if (targetContrastCd == 60)
            {
                if (this.tNedit_BLGoodsCode.GetInt() == 0)
                {
                    return (false);
                }

                int blCode = this.tNedit_BLGoodsCode.GetInt();
                if (GetBLGoodsName(blCode) == "")
                {
                    return (false);
                }
            }

            // 新規でキー項目が全て入力OKの場合、キーコントロールのDisable制御
            //SetKeyControlDisable();  // DEL K2011/07/05

            return (true);
        }
        #endregion チェック処理

        #region 検索処理
        /// <summary>
        /// 検索処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : キャンペーン目標設定マスタを検索します。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private int SearchProc()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            bool bStatus;

            // 検索条件チェック
            bStatus = CheckScreenInput(false);
            if (!bStatus)
            {
                return (-1);
            }

            status = SearchCampaignTarget();

            return (status);
        }

        /// <summary>
        /// 検索処理(キャンペーン目標)
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : キャンペーン目標設定マスタを検索します。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/25</br>
        /// <br>Update Note: 2011/07/05 譚洪 Redmine#22750 フォーカス制御障害の対応</br>
        /// </remarks>
        private int SearchCampaignTarget()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            // 検索条件設定
            CampaignTarget searchPara = new CampaignTarget();
            SetSearchCampaignTargetPara(ref searchPara);

            List<CampaignTarget> campaignTargetList = new List<CampaignTarget>();

            // 検索
            status = this._campaignTargetAcs.Search(ref campaignTargetList, searchPara, ConstantManagement.LogicalMode.GetDataAll);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // 編集モード設定
                        if (campaignTargetList[0].LogicalDeleteCode == 0)
                        {
                            this.Mode_Label.Text = UPDATE_MODE;

                            // コントロールEnabled制御
                            SetControlEnabled(UPDATE_MODE);
                        }
                        else
                        {
                            this.Mode_Label.Text = DELETE_MODE;

                            // コントロールEnabled制御
                            SetControlEnabled(DELETE_MODE);
                        }

                        // バッファ更新
                        this._campaignTargetDicClone.Clear();

                        foreach (CampaignTarget campaignTarget in campaignTargetList)
                        {
                            for (int index = 1; index < 13; index++)
                            {
                                this._campaignTargetDicClone.Add(index.ToString(), campaignTarget);
                            }
                        }

                        // 画面展開
                        CampaignTargetToScreen(_campaignTargetDicClone);

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ERROR:
                    {
                        this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "画面検索処理に失敗しました。", -1);
                        break;
                    }
                default:
                    {
                        this.Mode_Label.Text = INSERT_MODE;
                        // ----- ADD K2011/07/05 ------- >>>>>>>>>
                        ClearGrid();    
                        // コントロールEnabled制御
                        SetControlEnabled(INSERT_MODE);
                        // ----- ADD K2011/07/05 ------- <<<<<<<<<
                        break;
                    }
            }

            //this._searchFlg = true; // DEL K2011/07/05

            return (status);
        }
        #endregion 検索処理

        #region グリッド関連
        /// <summary>
        /// 合計目標取得処理
        /// </summary>
        /// <param name="columnIndex">列インデックス(2:売上目標 3:粗利目標 4:数量目標)</param>
        /// <returns>合計目標</returns>
        /// <remarks>
        /// <br>Note       : 合計目標を取得します。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private double GetTotalTarget(int columnIndex)
        {
            double totalTarget = 0;

            if (columnIndex < 1)
            {
                return totalTarget;
            }

            for (int index = 0; index < 12; index++)
            {
                if ((this.SalesTarget_uGrid.Rows[index].Cells[columnIndex].Value == DBNull.Value) ||
                    ((string)this.SalesTarget_uGrid.Rows[index].Cells[columnIndex].Value == ""))
                {
                    continue;
                }

                totalTarget += double.Parse((string)this.SalesTarget_uGrid.Rows[index].Cells[columnIndex].Value);
            }

            return totalTarget;
        }

        /// <summary>
        /// セル値変換処理(セル値→Double型)
        /// </summary>
        /// <param name="cellValue">セル値</param>
        /// <returns>セル値</returns>
        /// <remarks>
        /// <br>Note       : セル値をDouble型に変換します。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private double ChangeCellValue(object cellValue)
        {
            double target = 0;

            if ((cellValue != DBNull.Value) && (cellValue != null) && ((string)cellValue != ""))
            {
                target = double.Parse((string)cellValue);
            }

            return target;
        }

        /// <summary>
        /// 変換処理(セル値→string型)
        /// </summary>
        /// <param name="tNedit">tNedit</param>
        /// <param name="columNum">columNum</param>
        /// <returns>セル値</returns>
        /// <remarks>
        /// <br>Note       : 値をDouble型に変換します。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void ChangeValue(TNedit tNedit,int columNum)
        {
            double targetValue = 0;
            string retText;
            string targetText = tNedit.DataText;

            // カンマのみ削除
            RemoveCommaPeriod(targetText, out retText, false);
            try
            {
                targetValue = double.Parse(retText);
                if (targetText.Length > columNum)
                {
                    tNedit.Value = "";
                }
                else
                {
                    // ユーザー定価の場合
                    tNedit.Value = targetValue.ToString(FORMAT_NUM);
                }
                
            }
            catch
            {
                tNedit.Value = "";
            }
        }
        #endregion グリッド関連

        #region 検索条件設定
        /// <summary>
        /// 検索条件設定処理(キャンペーン目標)
        /// </summary>
        /// <param name="searchPara">キャンペーン目標検索条件</param>
        /// <remarks>
        /// <br>Note       : 検索条件を設定します。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void SetSearchCampaignTargetPara(ref CampaignTarget searchPara)
        {
            // 企業コード
            searchPara.EnterpriseCode = this._enterpriseCode;
            // 拠点コード
            searchPara.SectionCode = this.tEdit_SectionCode.DataText.Trim().PadLeft(2, '0');
            // キャンペーンコード
            searchPara.CampaignCode = this.tNedit_CampaignCode.GetInt();

            // 設定区分
            int targetContrastCd = (int)this.tComboEditor_TargetContrastCd.Value;
            switch (targetContrastCd)
            {
                case 10:    // 拠点
                    {
                        searchPara.TargetContrastCd = 10;
                        break;
                    }
                case 30:    // 拠点＋得意先
                    {
                        searchPara.TargetContrastCd = 30;
                        searchPara.CustomerCode = this.tNedit_CustomerCode.GetInt();
                        break;
                    }
                case 221:   // 拠点＋担当者
                case 222:   // 拠点＋受注者
                case 223:   // 拠点＋発行者
                    {
                        searchPara.TargetContrastCd = 22;
                        searchPara.EmployeeCode = this.tEdit_EmployeeCode.DataText.Trim();
                        if (targetContrastCd == 221)
                        {
                            searchPara.EmployeeDivCd = 10;
                        }
                        if (targetContrastCd == 222)
                        {
                            searchPara.EmployeeDivCd = 20;
                        }
                        if (targetContrastCd == 223)
                        {
                            searchPara.EmployeeDivCd = 30;
                        }
                        break;
                    }
                case 32:    // 拠点＋地区
                    {
                        searchPara.TargetContrastCd = 32;
                        searchPara.SalesAreaCode = this.tNedit_SalesAreaCode.GetInt();
                        break;
                    }
                case 50:    // 拠点＋グループコード
                    {
                        searchPara.TargetContrastCd = 50;
                        searchPara.BLGroupCode = this.tNedit_BLGloupCode.GetInt();
                        break;
                    }
                case 44:    // 拠点＋販売区分
                    {
                        searchPara.TargetContrastCd = 44;
                        searchPara.SalesCode = this.tNedit_SalesCode.GetInt();
                        break;
                    }
                case 60:    // 拠点＋BLコード
                    {
                        searchPara.TargetContrastCd = 60;
                        searchPara.BLGoodsCode = this.tNedit_BLGoodsCode.GetInt();
                        break;
                    }
            }

        }
        #endregion 検索条件設定

        #region 画面情報取得
        /// <summary>
        /// 画面情報取得処理(キャンペーン目標設定マスタ)
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面情報を取得します。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/25</br>
        /// <br>Update Note: 2011/07/05 Redmine#22743 目標値が全て0でも登録可能の対応</br>
        /// </remarks>
        private void ScreenToCampaignTargetList(ref List<CampaignTarget> campaignTargetList)
        {

            CampaignTarget campaignTarget = new CampaignTarget();
            //Boolean boo = false;  // DEL 2011/07/05
            // 売上月間目標金額
            campaignTarget.MonthlySalesTarget = (long)ChangeCellValue(this.tNedit_SalesTargetSale.Value);
            // DEL 2011/07/05 --- >>>
            //if (!((long)ChangeCellValue(this.tNedit_SalesTargetSale.Value) == 0))
            //{
            //    boo = true;
            //}
            // DEL 2011/07/05 --- <<<
            // 売上期間目標金額
            campaignTarget.TermSalesTarget = (long)ChangeCellValue(this.tNedit_SalesTargetSale1.Value);
            // DEL 2011/07/05 --- >>>
            //if (!((long)ChangeCellValue(this.tNedit_SalesTargetSale1.Value) == 0))
            //{
            //    boo = true;
            //}
            // DEL 2011/07/05 --- <<<
            // 売上月間目標粗利額
            campaignTarget.MonthlySalesTargetProfit = (long)ChangeCellValue(this.tNedit_SalesTargetProfit.Value);
            // DEL 2011/07/05 --- >>>
            //if (!((long)ChangeCellValue(this.tNedit_SalesTargetProfit.Value) == 0))
            //{
            //    boo = true;
            //}
            // DEL 2011/07/05 --- <<<
            // 売上期間目標粗利額
            campaignTarget.TermSalesTargetProfit = (long)ChangeCellValue(this.tNedit_SalesTargetProfit1.Value);
            // DEL 2011/07/05 --- >>>
            //if (!((long)ChangeCellValue(this.tNedit_SalesTargetProfit1.Value) == 0))
            //{
            //    boo = true;
            //}
            // DEL 2011/07/05 --- <<<
            // 売上月間目標数量
            campaignTarget.MonthlySalesTargetCount = ChangeCellValue(this.tNedit_SalesTargetCount.Value);
            // DEL 2011/07/05 --- >>>
            //if (!(ChangeCellValue(this.tNedit_SalesTargetCount.Value) == 0))
            //{
            //    boo = true;
            //}
            // DEL 2011/07/05 --- <<<
            // 売上期間目標数量
            campaignTarget.TermSalesTargetCount = ChangeCellValue(this.tNedit_SalesTargetCount1.Value);
            // DEL 2011/07/05 --- >>>
            //if (!(ChangeCellValue(this.tNedit_SalesTargetCount1.Value) == 0))
            //{
            //    boo = true;
            //}
            // DEL 2011/07/05 --- <<<

            // 企業コード
            campaignTarget.EnterpriseCode = this._enterpriseCode;
            // 拠点コード
            campaignTarget.SectionCode = this.tEdit_SectionCode.DataText.Trim();
            // キャンペーンコード
            campaignTarget.CampaignCode = this.tNedit_CampaignCode.GetInt();

            int targetContrastCd = (int)this.tComboEditor_TargetContrastCd.Value;
            switch (targetContrastCd)
            {
                case 10:
                    {
                        // 目標対比区分
                        campaignTarget.TargetContrastCd = 10;
                        break;
                    }
                case 221:
                    {
                        // 目標対比区分
                        campaignTarget.TargetContrastCd = 22;
                        // 従業員区分
                        campaignTarget.EmployeeDivCd = 10;
                        // 従業員コード
                        campaignTarget.EmployeeCode = this.tEdit_EmployeeCode.DataText.Trim();
                        break;
                    }
                case 222:
                    {
                        // 目標対比区分
                        campaignTarget.TargetContrastCd = 22;
                        // 従業員区分
                        campaignTarget.EmployeeDivCd = 20;
                        // 従業員コード
                        campaignTarget.EmployeeCode = this.tEdit_EmployeeCode.DataText.Trim();
                        break;
                    }
                case 223:
                    {
                        // 目標対比区分
                        campaignTarget.TargetContrastCd = 22;
                        // 従業員区分
                        campaignTarget.EmployeeDivCd = 30;
                        // 従業員コード
                        campaignTarget.EmployeeCode = this.tEdit_EmployeeCode.DataText.Trim();
                        break;
                    }
                case 30:
                    {
                        // 目標対比区分
                        campaignTarget.TargetContrastCd = 30;
                        campaignTarget.CustomerCode = this.tNedit_CustomerCode.GetInt();
                        break;
                    }
                case 32:
                    {
                        // 目標対比区分
                        campaignTarget.TargetContrastCd = 32;
                        campaignTarget.SalesAreaCode = this.tNedit_SalesAreaCode.GetInt();
                        break;
                    }
                case 44:
                    {
                        // 目標対比区分
                        campaignTarget.TargetContrastCd = 44;
                        campaignTarget.SalesCode = this.tNedit_SalesCode.GetInt();
                        break;
                    }
                case 50:
                    {
                        // 目標対比区分
                        campaignTarget.TargetContrastCd = 50;
                        campaignTarget.BLGroupCode = this.tNedit_BLGloupCode.GetInt();
                        break;
                    }
                case 60:
                    {
                        // 目標対比区分
                        campaignTarget.TargetContrastCd = 60;
                        campaignTarget.BLGoodsCode = this.tNedit_BLGoodsCode.GetInt();
                        break;
                    }
            }
            
            for (int index = 0; index < 12; index++)
            {
                string salesTargetMoney = "SalesTargetMoney";
                string salesTargetProfit = "SalesTargetProfit";
                string salesTargetCount = "SalesTargetCount";
                salesTargetMoney = salesTargetMoney + (this._yearMonthList[0].AddMonths(index).Month).ToString();
                salesTargetProfit = salesTargetProfit + (this._yearMonthList[0].AddMonths(index).Month).ToString();
                salesTargetCount = salesTargetCount + (this._yearMonthList[0].AddMonths(index).Month).ToString();
                // セル値変換
                if ((ChangeCellValue(this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_SALESTARGET].Value) == 0) &&
                    (ChangeCellValue(this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_PROFITTARGET].Value) == 0) &&
                    (ChangeCellValue(this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_COUNTTARGET].Value) == 0))
                {
                    continue;
                }
                //boo = true; // DEL 2011/07/05
                Type type = campaignTarget.GetType();
                type.GetProperty(salesTargetMoney).SetValue(campaignTarget, (long)ChangeCellValue(this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_SALESTARGET].Value), null);
                // 売上目標粗利額
                type.GetProperty(salesTargetProfit).SetValue(campaignTarget, (long)ChangeCellValue(this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_PROFITTARGET].Value), null);
                // 売上目標数量
                type.GetProperty(salesTargetCount).SetValue(campaignTarget, (long)ChangeCellValue(this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_COUNTTARGET].Value), null);
            }
            // UPD 2011/07/05 --- >>>
            //if (boo)
            //{
                campaignTargetList.Add(campaignTarget);
            //}
            // UPD 2011/07/05--- <<<
        }
        #endregion 画面情報取得

        #region 画面展開
        /// <summary>
        /// 画面展開処理(キャンペーン目標)
        /// </summary>
        /// <param name="campaignTargetDic">キャンペーン目標リスト</param>
        /// <remarks>
        /// <br>Note       : キャンペーン目標リストを画面展開します。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void CampaignTargetToScreen(Dictionary<string, CampaignTarget> campaignTargetDic)
        {
            //------------------------------
            // 目標情報初期化
            //------------------------------
            this.tNedit_SalesTargetSale.Clear();
            this.tNedit_SalesTargetProfit.Clear();
            this.tNedit_SalesTargetCount.Clear();
            this.tNedit_SalesTargetSale1.Clear();
            this.tNedit_SalesTargetProfit1.Clear();
            this.tNedit_SalesTargetCount1.Clear();

            CampaignTarget campaignTarget = campaignTargetDic["1"];
            // 売上月間目標金額
            if (campaignTarget.MonthlySalesTarget != 0)
            {
                this.tNedit_SalesTargetSale.Value = campaignTarget.MonthlySalesTarget.ToString(FORMAT_NUM);
            }

            // 売上期間目標金額
            if (campaignTarget.TermSalesTarget != 0)
            {
                this.tNedit_SalesTargetSale1.Value = campaignTarget.TermSalesTarget.ToString(FORMAT_NUM);
            }

            // 売上月間目標粗利額
            if (campaignTarget.MonthlySalesTargetProfit != 0)
            {
                this.tNedit_SalesTargetProfit.Value = campaignTarget.MonthlySalesTargetProfit.ToString(FORMAT_NUM);
            }

            // 売上期間目標粗利額
            if (campaignTarget.TermSalesTargetProfit != 0)
            {
                this.tNedit_SalesTargetProfit1.Value = campaignTarget.TermSalesTargetProfit.ToString(FORMAT_NUM);
            }

            // 売上月間目標数量
            if (campaignTarget.MonthlySalesTargetCount != 0)
            {
                this.tNedit_SalesTargetCount.Value = campaignTarget.MonthlySalesTargetCount.ToString(FORMAT_NUM);
            }
            
            // 売上期間目標数量
            if (campaignTarget.TermSalesTargetCount != 0)
            {
                this.tNedit_SalesTargetCount1.Value = campaignTarget.TermSalesTargetCount.ToString(FORMAT_NUM);
            }

            for (int index = 0; index < 13; index++)
            {
                this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_SALESTARGET].Value = "";
                this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_PROFITTARGET].Value = "";
                this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_COUNTTARGET].Value = "";
            }

            //------------------------------
            // 目標情報設定
            //------------------------------
            double totalMoney = 0;
            double totalProfit = 0;
            double totalCount = 0;
            for (int index = 0; index < 12; index++)
            {
                int index1 = index + 1;
                if (!campaignTargetDic.ContainsKey(index1.ToString()))
                {
                    continue;
                }
                campaignTarget = (CampaignTarget)campaignTargetDic[index1.ToString()];
                switch(this._yearMonthList[0].AddMonths(index).Month)
                {
                    case 1:
                        {
                            totalMoney += campaignTarget.SalesTargetMoney1;
                            totalProfit += campaignTarget.SalesTargetProfit1;
                            totalCount += campaignTarget.SalesTargetCount1;
                            SetCellValue(campaignTarget.SalesTargetMoney1, campaignTarget.SalesTargetProfit1, campaignTarget.SalesTargetCount1,index);
                            break;
                        }
                    case 2:
                        {
                            totalMoney += campaignTarget.SalesTargetMoney2;
                            totalProfit += campaignTarget.SalesTargetProfit2;
                            totalCount += campaignTarget.SalesTargetCount2;
                            SetCellValue(campaignTarget.SalesTargetMoney2, campaignTarget.SalesTargetProfit2, campaignTarget.SalesTargetCount2,index);
                            break;
                        }
                    case 3:
                        {
                            totalMoney += campaignTarget.SalesTargetMoney3;
                            totalProfit += campaignTarget.SalesTargetProfit3;
                            totalCount += campaignTarget.SalesTargetCount3;
                            SetCellValue(campaignTarget.SalesTargetMoney3, campaignTarget.SalesTargetProfit3, campaignTarget.SalesTargetCount3, index);
                            break;
                        }
                    case 4:
                        {
                            totalMoney += campaignTarget.SalesTargetMoney4;
                            totalProfit += campaignTarget.SalesTargetProfit4;
                            totalCount += campaignTarget.SalesTargetCount4;
                            SetCellValue(campaignTarget.SalesTargetMoney4, campaignTarget.SalesTargetProfit4, campaignTarget.SalesTargetCount4, index);
                            break;
                        }
                    case 5:
                        {
                            totalMoney += campaignTarget.SalesTargetMoney5;
                            totalProfit += campaignTarget.SalesTargetProfit5;
                            totalCount += campaignTarget.SalesTargetCount5;
                            SetCellValue(campaignTarget.SalesTargetMoney5, campaignTarget.SalesTargetProfit5, campaignTarget.SalesTargetCount5, index);
                            break;
                        }
                    case 6:
                        {
                            totalMoney += campaignTarget.SalesTargetMoney6;
                            totalProfit += campaignTarget.SalesTargetProfit6;
                            totalCount += campaignTarget.SalesTargetCount6;
                            SetCellValue(campaignTarget.SalesTargetMoney6, campaignTarget.SalesTargetProfit6, campaignTarget.SalesTargetCount6, index);
                            break;
                        }
                    case 7:
                        {
                            totalMoney += campaignTarget.SalesTargetMoney7;
                            totalProfit += campaignTarget.SalesTargetProfit7;
                            totalCount += campaignTarget.SalesTargetCount7;
                            SetCellValue(campaignTarget.SalesTargetMoney7, campaignTarget.SalesTargetProfit7, campaignTarget.SalesTargetCount7, index);
                            break;
                        }
                    case 8:
                        {
                            totalMoney += campaignTarget.SalesTargetMoney8;
                            totalProfit += campaignTarget.SalesTargetProfit8;
                            totalCount += campaignTarget.SalesTargetCount8;
                            SetCellValue(campaignTarget.SalesTargetMoney8, campaignTarget.SalesTargetProfit8, campaignTarget.SalesTargetCount8, index);
                            break;
                        }
                    case 9:
                        {
                            totalMoney += campaignTarget.SalesTargetMoney9;
                            totalProfit += campaignTarget.SalesTargetProfit9;
                            totalCount += campaignTarget.SalesTargetCount9;
                            SetCellValue(campaignTarget.SalesTargetMoney9, campaignTarget.SalesTargetProfit9, campaignTarget.SalesTargetCount9, index);
                            break;
                        }
                    case 10:
                        {
                            totalMoney += campaignTarget.SalesTargetMoney10;
                            totalProfit += campaignTarget.SalesTargetProfit10;
                            totalCount += campaignTarget.SalesTargetCount10;
                            SetCellValue(campaignTarget.SalesTargetMoney10, campaignTarget.SalesTargetProfit10, campaignTarget.SalesTargetCount10, index);
                            break;
                        }
                    case 11:
                        {
                            totalMoney += campaignTarget.SalesTargetMoney11;
                            totalProfit += campaignTarget.SalesTargetProfit11;
                            totalCount += campaignTarget.SalesTargetCount11;
                            SetCellValue(campaignTarget.SalesTargetMoney11, campaignTarget.SalesTargetProfit11, campaignTarget.SalesTargetCount11, index);
                            break;
                        }
                    case 12:
                        {
                            totalMoney += campaignTarget.SalesTargetMoney12;
                            totalProfit += campaignTarget.SalesTargetProfit12;
                            totalCount += campaignTarget.SalesTargetCount12;
                            SetCellValue(campaignTarget.SalesTargetMoney12, campaignTarget.SalesTargetProfit12, campaignTarget.SalesTargetCount12, index);
                            break;
                        }
                }

            }

            //------------------------------
            // 合計行設定
            //------------------------------
            if (totalMoney != 0)
            {
                this.SalesTarget_uGrid.Rows[12].Cells[COLUMN_SALESTARGET].Value = totalMoney.ToString(FORMAT_NUM);
            }
            if (totalProfit != 0)
            {
                this.SalesTarget_uGrid.Rows[12].Cells[COLUMN_PROFITTARGET].Value = totalProfit.ToString(FORMAT_NUM);
            }
            if (totalCount != 0)
            {
                this.SalesTarget_uGrid.Rows[12].Cells[COLUMN_COUNTTARGET].Value = totalCount.ToString(FORMAT_NUM);
            }
        }
        /// <summary>
        /// 画面展開処理(キャンペーン目標)1
        /// </summary>
        /// <param name="salesTargetMoney">売上目標金額</param>
        /// <param name="salesTargetProfit">売上目標粗利額</param>
        /// <param name="salesTargetCount">売上目標数量</param>
        /// <param name="index"></param>
        /// <remarks>
        /// <br>Note       : キャンペーン目標)リストを画面展開します。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
       private void SetCellValue(double salesTargetMoney, double salesTargetProfit, double salesTargetCount, int index)
        {

            if (salesTargetMoney != 0)
            {
                this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_SALESTARGET].Value = salesTargetMoney.ToString(FORMAT_NUM);
            }
            if (salesTargetProfit != 0)
            {
                this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_PROFITTARGET].Value = salesTargetProfit.ToString(FORMAT_NUM);
            }
            if (salesTargetCount != 0)
            {
                this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_COUNTTARGET].Value = salesTargetCount.ToString(FORMAT_NUM);
            }
        }
         #endregion 画面展開

        #region 排他処
        /// <summary>
        /// 排他処理
        /// </summary>
        /// <param name="status">ステータス</param>
        /// <remarks>
        /// <br>Note       : 排他制御を行います。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void ExclusiveTransaction(int status)
        {
            string errMsg = "";

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        // 他端末更新
                        errMsg = "既に他端末より更新されています。";
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // 他端末削除
                        errMsg = "既に他端末より削除されています。";
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    {
                        // 既に使用されています
                        string campaignCode = this.tNedit_CampaignCode.DataText.Trim();
                        errMsg = "この" + campaignCode + "を既に使用されています。";
                        break;
                    }
            }

            ShowMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                           errMsg,
                           status,
                           MessageBoxButtons.OK,
                           MessageBoxDefaultButton.Button1);
        }
        #endregion 排他処


        /// <summary>
        /// 「ガイド」処理
        /// </summary>
        public void ExecuteGuide()
        {
            switch (this._guideKey)
            {

                // 目標設定
                case ctGUIDE_NAME_CampaignGuide:
                    {
                        this.CampaignGuide_Button_Click(this.CampaignGuide_Button, new EventArgs());
                        break;
                    }
                // 拠点 
                case ctGUIDE_NAME_Section:
                    {
                        this.SectionGuide_Button_Click(this.SectionGuide_Button, new EventArgs());
                        break;
                    }
                // 得意先
                case ctGUIDE_NAME_CustomerCode:
                    {
                        this.CustomerGuide_Button_Click(this.CustomerGuide_Button, new EventArgs());
                        break;
                    }
                // 担当者
                case ctGUIDE_NAME_EmployeeCode:
                    {
                        this.EmployeeGuide_Button_Click(this.EmployeeGuide_Button, new EventArgs());
                        break;
                    }
                // 地区
                case ctGUIDE_NAME_SalesAreaCode:
                    {
                        this.SalesAreaGuide_Button_Click(this.SalesAreaGuide_Button, new EventArgs());
                        break;
                    }
                // グループコード
                case ctGUIDE_NAME_SalesGroupCode:
                    {
                        this.GroupGuide_Button_Click(this.GroupGuide_Button, new EventArgs());
                        break;
                    }
                // BLコード
                case ctGUIDE_NAME_BLCode:
                    {
                        this.BLGuide_Button_Click(this.BLGuide_Button, new EventArgs());
                        break;
                    }
                // 販売区分
                case ctGUIDE_NAME_SalesCode:
                    {
                        this.SalesCodeGuide_Button_Click(this.SalesCodeGuide_Button, new EventArgs());
                        break;
                    }
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

            if (targetControl.Name == ctGUIDE_NAME_CampaignGuide
                || targetControl.Name == ctGUIDE_NAME_Section
                || targetControl.Name == ctGUIDE_NAME_CustomerCode
                || targetControl.Name == ctGUIDE_NAME_EmployeeCode
                || targetControl.Name == ctGUIDE_NAME_SalesAreaCode
                || targetControl.Name == ctGUIDE_NAME_SalesGroupCode
                || targetControl.Name == ctGUIDE_NAME_BLCode
                || targetControl.Name == ctGUIDE_NAME_SalesCode)
            {
                this._guideKey = targetControl.Name;
                this.tToolsManager_MainMenu.Tools[ct_Tool_GuideButton].SharedProps.Enabled = true;
            }
            else
            {
                this._guideKey = string.Empty;
                this.tToolsManager_MainMenu.Tools[ct_Tool_GuideButton].SharedProps.Enabled = false;
            }
        }


         #region メッセージボックス表

        /// <summary>
        /// メッセージボックス表示処理
        /// </summary>
        /// <param name="errLevel">エラーレベル</param>
        /// <param name="message">表示するメッセージ</param>
        /// <param name="status">ステータス値</param>
        /// <param name="msgButton">表示するボタン</param>
        /// <param name="defaultButton">初期表示ボタン</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : メッセージボックスを表示します。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private DialogResult ShowMessageBox(emErrorLevel errLevel, string message, int status, MessageBoxButtons msgButton, MessageBoxDefaultButton defaultButton)
        {
            DialogResult dialogResult;
            dialogResult = TMsgDisp.Show(this,                              // 親ウィンドウフォーム
                                         errLevel,                          // エラーレベル
                                         ASSEMBLY_ID,                       // アセンブリID
                                         message,                           // 表示するメッセージ
                                         status,                            // ステータス値
                                         msgButton,                         // 表示するボタン
                                         defaultButton);                    // 初期表示ボタン
            return dialogResult;
        }

        /// <summary>
        /// メッセージボックス表示処理
        /// </summary>
        /// <param name="errLevel">エラーレベル</param>
        /// <param name="methodName">処理名称</param>
        /// <param name="message">表示するメッセージ</param>
        /// <param name="status">ステータス値</param>
        /// <param name="msgButton">表示するボタン</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : メッセージボックスを表示します。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private DialogResult ShowMessageBox(emErrorLevel errLevel, string methodName, string message, int status, MessageBoxButtons msgButton)
        {
            DialogResult dialogResult;
            dialogResult = TMsgDisp.Show(this, 						        // 親ウィンドウフォーム
                                         errLevel,			                // エラーレベル
                                         this.Name,						    // プログラム名称
                                         ASSEMBLY_ID, 		  　　			// アセンブリID
                                         methodName,						// 処理名称
                                         "",					            // オペレーション
                                         message,	                        // 表示するメッセージ
                                         status,							// ステータス値
                                         this._campaignTargetAcs,			// エラーが発生したオブジェクト
                                         msgButton,         			  	// 表示するボタン
                                         MessageBoxDefaultButton.Button1);	// 初期表示ボタン

            return dialogResult;
        }

         #endregion メッセージボックス表示

        #region 文字列編集処

        /// <summary>
        /// カンマ・ピリオド削除処理
        /// </summary>
        /// <param name="targetText">カンマ・ピリオド削除前テキスト</param>
        /// <param name="retText">カンマ・ピリオド削除済みテキスト</param>
        /// <param name="periodDelFlg">ピリオド削除フラグ(True:カンマ・ピリオド削除  False:カンマ削除)</param>
        /// <remarks>
        /// <br>Note		: 対象のテキストからカンマ・ピリオドを削除します。</br>
        /// <br>Programmer	: 徐佳</br>
        /// <br>Date		: 2011/04/25</br>
        /// </remarks>
        private void RemoveCommaPeriod(string targetText, out string retText, bool periodDelFlg)
        {
            retText = "";

            // セル値編集用にカンマ・ピリオド削除
            for (int i = targetText.Length - 1; i >= 0; i--)
            {
                // カンマ・ピリオド削除
                if (periodDelFlg == true)
                {
                    if ((targetText[i].ToString() == ",") || (targetText[i].ToString() == "."))
                    {
                        targetText = targetText.Remove(i, 1);
                    }
                }
                // カンマのみ削除
                else
                {
                    if (targetText[i].ToString() == ",")
                    {
                        targetText = targetText.Remove(i, 1);
                    }
                }
            }

            retText = targetText;
        }

        /// <summary>
        /// 小数点取得処理
        /// </summary>
        /// <param name="targetText">チェック対象テキスト</param>
        /// <param name="retText">小数部分テキスト</param>
        /// <remarks>
        /// <br>Note		: 対象のテキストから小数部分のみを返します。</br>
        /// <br>Programmer	: 徐佳</br>
        /// <br>Date		: 2011/04/25</br>
        /// </remarks>
        private void GetDecimal(string targetText, out string retText)
        {
            retText = "";

            for (int i = targetText.IndexOf(".") + 1; i < targetText.Length; i++)
            {
                retText += targetText[i].ToString();
            }
        }

        #endregion 文字列編集処理

        #endregion ■ Private Methods


        #region ■ Control Event

        /// <summary>
        /// Load イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : Form_Load時に発生します。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void PMKHN09651UA_Load(object sender, EventArgs e)
        {
            // 画面初期設定
            SetScreenInitialSetting();

            // 画面初期化処理
            ClearScreen();

            // 初期設定処理
            InitialSetting();

            // フォーカス設定
            this.timer_SetFocus.Enabled = true;
        }

         #region ガイドボタン押
        /// <summary>
        /// Button_Click イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : キャンペーンコードガイドボタンがクリックされた時に発生します。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/25</br>
        /// <br>Update Note: 2011/07/05 譚洪 Redmine#22750 フォーカス制御障害の対応</br>
        /// </remarks>
        private void CampaignGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                CampaignSt campaignSt;

                // ガイド起動
                int status = _campaignStAcs.ExecuteGuid(this._enterpriseCode, out campaignSt);
                if (status == 0)
                {
                    // 結果セット
                    this.tNedit_CampaignCode.SetInt(campaignSt.CampaignCode);
                    this.tEdit_CampaignName.Text = campaignSt.CampaignName;
                    this.tNedit_YearFrm.SetInt(campaignSt.ApplyStaDate.Year);
                    this.tNedit_MonthFrm.SetInt(campaignSt.ApplyStaDate.Month);
                    this.tNedit_DayFrm.SetInt(campaignSt.ApplyStaDate.Day);
                    this.tNedit_YearTo.SetInt(campaignSt.ApplyEndDate.Year);
                    this.tNedit_MonthTo.SetInt(campaignSt.ApplyEndDate.Month);
                    this.tNedit_DayTo.SetInt(campaignSt.ApplyEndDate.Day);
                    //this._prevCampaignCode = campaignSt.CampaignCode;
                    Control nextControl;
                    if (CheckSaveConfirm() == false)
                    {
                        this._prevCampaignCode = campaignSt.CampaignCode;
                        GetNextControl(this.CampaignGuide_Button, out nextControl);
                        nextControl.Focus();
                        this.SettingGuideButtonToolEnabled(this.ActiveControl);
                        return;
                    }
                    else
                    {
                        //if (this._searchFlg)
                        //{
                        //    DialogResult result = ShowMessageBox(emErrorLevel.ERR_LEVEL_SAVECONFIRM,
                        //                                        "",
                        //                                        0,
                        //                                        MessageBoxButtons.YesNoCancel,
                        //                                        MessageBoxDefaultButton.Button2);
                        //    switch (result)
                        //    {
                        //        case DialogResult.Yes:
                        //            {
                        //                // 保存処理
                        //                status = SaveProc();
                        //                if (status != 0)
                        //                {
                        //                    this._prevCampaignCode = campaignSt.CampaignCode;
                        //                    return;
                        //                }

                        //                break;
                        //            }
                        //        case DialogResult.No:
                        //            {
                        //                break;
                        //            }
                        //        case DialogResult.Cancel:
                        //            {
                        //                this.tNedit_CampaignCode.Value = this._prevCampaignCode;
                        //                this.tEdit_CampaignName.DataText = GetCampaignName(this._prevCampaignCode);
                        //                return;
                        //            }
                        //    }
                        //}

                        if (campaignSt.CampaignCode != this._prevCampaignCode)
                        {
                            // 検索
                            status = SearchProc();
                            if (status != 0)
                            {
                                ClearGrid();
                                this._prevCampaignCode = campaignSt.CampaignCode;
                            }
                            else
                            {
                                this._prevCampaignCode = campaignSt.CampaignCode;
                            }
                        }


                    }
                    // フォーカス設定
                    GetNextControl(this.CampaignGuide_Button, out nextControl);
                    nextControl.Focus();
                    this.SettingGuideButtonToolEnabled(this.ActiveControl);
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Button_Click イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 拠点ガイドボタンがクリックされた時に発生します。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/25</br>
        /// <br>Update Note: 2011/07/05 譚洪 Redmine#22750 フォーカス制御障害の対応</br>
        /// </remarks>
        private void SectionGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                SecInfoSet secInfoSet;

                int status = this._secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out secInfoSet);
                if (status == 0)
                {
                    // 拠点コード設定
                    this.tEdit_SectionCode.DataText = secInfoSet.SectionCode.Trim();
                    // 拠点名設定
                    this.tEdit_SectionName.DataText = secInfoSet.SectionGuideNm.Trim();

                    if ((int)this.tComboEditor_TargetContrastCd.Value == 10)
                    {
                        // 検索
                        status = SearchProc();
                        //this._searchFlg = false;  // DEL K2011/07/05
                        if (this.tNedit_CampaignCode.Text.ToString() != "")
                        {
                            GetCampaignStList();

                            // キャンペーンコード取得
                            int campaignCode = this.tNedit_CampaignCode.GetInt();
                            if (string.IsNullOrEmpty(GetCampaignName(campaignCode)))
                            {
                                // 該当なし
                                this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "キャンペーンコードが存在しません。", -1);
                                this.tNedit_CampaignCode.Focus();
                                this.tNedit_CampaignCode.Text = "";
                                this.tEdit_CampaignName.Clear();
                                this.tNedit_YearFrm.Clear();
                                this.tNedit_MonthFrm.Clear();
                                this.tNedit_DayFrm.Clear();
                                this.tNedit_YearTo.Clear();
                                this.tNedit_MonthTo.Clear();
                                this.tNedit_DayTo.Clear();
                                this._prevCampaignCode = 0;
                                this.SettingGuideButtonToolEnabled(this.ActiveControl);
                                return;
                            }
                            int campainCapare = Convert.ToInt32(this.tNedit_CampaignCode.Text.ToString());
                          
                            if (this._campaignStDic[campainCapare].LogicalDeleteCode == 1 && status != 0)
                            {
                                this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "マスタに登録されていません。", -1);
                                this.tNedit_CampaignCode.Focus();
                                this.tNedit_CampaignCode.Text = "";
                                this.tEdit_CampaignName.Clear();
                                this.tNedit_YearFrm.Clear();
                                this.tNedit_MonthFrm.Clear();
                                this.tNedit_DayFrm.Clear();
                                this.tNedit_YearTo.Clear();
                                this.tNedit_MonthTo.Clear();
                                this.tNedit_DayTo.Clear();
                                this._prevCampaignCode = 0;
                                this.SettingGuideButtonToolEnabled(this.ActiveControl);
                                return;
                            }
                        }
                    }

                    Control nextControl;
                    if (CheckSaveConfirm() == false)
                    {
                        this._prevSectionCode = secInfoSet.SectionCode.Trim();
                        // フォーカス設定
                       
                        GetNextControl(this.SectionGuide_Button, out nextControl);
                        nextControl.Focus();
                        this.SettingGuideButtonToolEnabled(this.ActiveControl);
                        return;
                    }
                    else
                    {
                        // ----- DEL K2011/07/05 ------- >>>>>>>>>
                        //if (this._searchFlg)
                        //{
                        //    DialogResult result = ShowMessageBox(emErrorLevel.ERR_LEVEL_SAVECONFIRM,
                        //                                        "",
                        //                                        0,
                        //                                        MessageBoxButtons.YesNoCancel,
                        //                                        MessageBoxDefaultButton.Button2);
                        //    switch (result)
                        //    {
                        //        case DialogResult.Yes:
                        //            {
                        //                // 保存処理
                        //                status = SaveProc();
                        //                if (status != 0)
                        //                {
                        //                    this._prevSectionCode = secInfoSet.SectionCode.Trim();
                        //                    return;
                        //                }

                        //                break;
                        //            }
                        //        case DialogResult.No:
                        //            {
                        //                break;
                        //            }
                        //        case DialogResult.Cancel:
                        //            {
                        //                this.tEdit_SectionCode.DataText = this._prevSectionCode;
                        //                this.tEdit_SectionName.DataText = GetSectionName(this._prevSectionCode);
                        //                return;
                        //            }
                        //    }
                        //}
                        // ----- DEL K2011/07/05 ------- <<<<<<<<<

                        // 検索
                        status = SearchProc();
                        if (status != 0)
                        {
                            ClearGrid();
                            this._prevSectionCode = secInfoSet.SectionCode.Trim();
                        }
                        else
                        {
                            this._prevSectionCode = secInfoSet.SectionCode.Trim();
                        }
                    }

                    // フォーカス設定
                    GetNextControl(this.SectionGuide_Button, out nextControl);
                    nextControl.Focus();
                    // ボタンツール有効無効設定処理
                    this.SettingGuideButtonToolEnabled(this.ActiveControl);
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }


        /// <summary>
        /// Button_Click イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 得意先ガイドボタンがクリックされた時に発生します。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void CustomerGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this._customerFlag = 0;

                this.Cursor = Cursors.WaitCursor;

                this._cusotmerGuideSelected = false;

                int status;

                // 得意先ガイド
                PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);

                customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
                customerSearchForm.ShowDialog(this);

                if ((int)this.tComboEditor_TargetContrastCd.Value == 30)
                {
                    // 検索
                    status = SearchProc();
                    //this._searchFlg = false;  // DEL K2011/07/05
                    if (this.tNedit_CampaignCode.Text.ToString() != "")
                    {
                        GetCampaignStList();

                        if (this._customerFlag == 1)
                        {
                            // 該当なし
                            this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "キャンペーンコードが存在しません。", -1);
                            this.tNedit_CampaignCode.Focus();
                            this.tNedit_CampaignCode.Text = "";
                            this.tEdit_CampaignName.Clear();
                            this.tNedit_YearFrm.Clear();
                            this.tNedit_MonthFrm.Clear();
                            this.tNedit_DayFrm.Clear();
                            this.tNedit_YearTo.Clear();
                            this.tNedit_MonthTo.Clear();
                            this.tNedit_DayTo.Clear();
                            this._prevCampaignCode = 0;
                            this.SettingGuideButtonToolEnabled(this.ActiveControl);
                            return;
                        }

                        int campainCapare = Convert.ToInt32(this.tNedit_CampaignCode.Text.ToString());
                       
                        if (this._campaignStDic[campainCapare].LogicalDeleteCode == 1 && status != 0)
                        {
                            this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "マスタに登録されていません。", -1);
                            this.tNedit_CampaignCode.Focus();
                            this.tNedit_CampaignCode.Text = "";
                            this.tEdit_CampaignName.Clear();
                            this.tNedit_YearFrm.Clear();
                            this.tNedit_MonthFrm.Clear();
                            this.tNedit_DayFrm.Clear();
                            this.tNedit_YearTo.Clear();
                            this.tNedit_MonthTo.Clear();
                            this.tNedit_DayTo.Clear();
                            this._prevCampaignCode = 0;
                            this.SettingGuideButtonToolEnabled(this.ActiveControl);
                            return;
                        }
                    }
                }

                if (this._cusotmerGuideSelected == true)
                {
                    // フォーカス設定
                    Control nextControl;
                    GetNextControl(this.CustomerGuide_Button, out nextControl);
                    nextControl.Focus();
                    // ボタンツール有効無効設定処理
                    this.SettingGuideButtonToolEnabled(this.ActiveControl);
                }

                // 検索
                status = SearchProc();
                if (status != 0)
                {
                    ClearGrid();
                    if (this.tNedit_CustomerCode.Text.ToString() != "")
                    {
                        this._prevCustomerCode = Convert.ToInt32(this.tNedit_CustomerCode.Text.ToString());
                    }
                    else
                    {
                        this._prevCustomerCode = 0;
                    }
                }
                else
                {
                    if (this.tNedit_CustomerCode.Text.ToString() != "")
                    {
                        this._prevCustomerCode = Convert.ToInt32(this.tNedit_CustomerCode.Text.ToString());
                    }
                    else
                    {
                        this._prevCustomerCode = 0;
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// 得意先選択時発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="customerSearchRet">得意先検索戻り値クラス</param>
        /// <remarks>
        /// <br>Note       : 得意先選択時に発生します。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/25</br>
        /// <br>Update Note: 2011/07/05 譚洪 Redmine#22750 フォーカス制御障害の対応</br>
        /// </remarks>
        private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null)
            {
                this._cusotmerGuideSelected = false;
                return;
            }

            int status;

            // 得意先コード設定
            this.tNedit_CustomerCode.SetInt(customerSearchRet.CustomerCode);
            // 得意先名設定
            this.tEdit_CustomerName.DataText = customerSearchRet.Snm.Trim();


            if ((int)this.tComboEditor_TargetContrastCd.Value == 30)
            {
                // 検索
                status = SearchProc();
                //this._searchFlg = false;  // DEL K2011/07/05
                if (this.tNedit_CampaignCode.Text.ToString() != "")
                {
                    GetCampaignStList();

                    // キャンペーンコード取得
                    int campaignCode = this.tNedit_CampaignCode.GetInt();
                    if (string.IsNullOrEmpty(GetCampaignName(campaignCode)))
                    {
                        this._customerFlag = 1;
                        return;
                    }

                    int campainCapare = Convert.ToInt32(this.tNedit_CampaignCode.Text.ToString());
                 
                    if (this._campaignStDic[campainCapare].LogicalDeleteCode == 1 && status != 0)
                    {
                        return;
                    }
                }
            }


            if (CheckSaveConfirm() == false)
            {
                this._prevCustomerCode = customerSearchRet.CustomerCode;
                return;
            }
            else
            {
                //if (this._searchFlg)
                //{
                //    DialogResult result = ShowMessageBox(emErrorLevel.ERR_LEVEL_SAVECONFIRM,
                //                                        "",
                //                                        0,
                //                                        MessageBoxButtons.YesNoCancel,
                //                                        MessageBoxDefaultButton.Button2);
                //    switch (result)
                //    {
                //        case DialogResult.Yes:
                //            {
                //                // 保存処理
                //                status = SaveProc();
                //                if (status != 0)
                //                {
                //                    this._prevCustomerCode = customerSearchRet.CustomerCode;
                //                    return;
                //                }

                //                break;
                //            }
                //        case DialogResult.No:
                //            {
                //                break;
                //            }
                //        case DialogResult.Cancel:
                //            {
                //                this.tNedit_CustomerCode.SetInt(this._prevCustomerCode);
                //                this.tEdit_CustomerName.DataText = GetCustomerName(this._prevCustomerCode);
                //                return;
                //            }
                //    }
                //}

                // 検索
                status = SearchProc();
                if (status != 0)
                {
                    ClearGrid();
                    this._prevCustomerCode = customerSearchRet.CustomerCode;
                }
                else
                {
                    this._prevCustomerCode = customerSearchRet.CustomerCode;
                }
            }

            this._cusotmerGuideSelected = true;
        }

        /// <summary>
        /// Button_Click イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 従業員ガイドボタンがクリックされた時に発生します。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/25</br>
        /// <br>Update Note: 2011/07/05 譚洪 Redmine#22750 フォーカス制御障害の対応</br>
        /// </remarks>
        private void EmployeeGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                Employee employee;

                int status = this._employeeAcs.ExecuteGuid(this._enterpriseCode, false, out employee);
                if (status == 0)
                {
                    // 従業員コード設定
                    this.tEdit_EmployeeCode.DataText = employee.EmployeeCode.Trim();
                    // 従業員名設定
                    this.tEdit_EmployeeName.DataText = employee.Name.Trim();
                    if ((int)this.tComboEditor_TargetContrastCd.Value == 221
                        || (int)this.tComboEditor_TargetContrastCd.Value == 222
                        || (int)this.tComboEditor_TargetContrastCd.Value == 223)
                    {
                        // 検索
                        status = SearchProc();
                        //this._searchFlg = false;  // DEL K2011/07/05
                        if (this.tNedit_CampaignCode.Text.ToString() != "")
                        {
                            GetCampaignStList();

                            // キャンペーンコード取得
                            int campaignCode = this.tNedit_CampaignCode.GetInt();
                            if (string.IsNullOrEmpty(GetCampaignName(campaignCode)))
                            {
                                // 該当なし
                                this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "キャンペーンコードが存在しません。", -1);
                                this.tNedit_CampaignCode.Focus();
                                this.tNedit_CampaignCode.Text = "";
                                this.tEdit_CampaignName.Clear();
                                this.tNedit_YearFrm.Clear();
                                this.tNedit_MonthFrm.Clear();
                                this.tNedit_DayFrm.Clear();
                                this.tNedit_YearTo.Clear();
                                this.tNedit_MonthTo.Clear();
                                this.tNedit_DayTo.Clear();
                                this._prevCampaignCode = 0;
                                this.SettingGuideButtonToolEnabled(this.ActiveControl);
                                return;
                            }

                            int campainCapare = Convert.ToInt32(this.tNedit_CampaignCode.Text.ToString());
                         
                            if (this._campaignStDic[campainCapare].LogicalDeleteCode == 1 && status != 0)
                            {
                                this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "マスタに登録されていません。", -1);
                                this.tNedit_CampaignCode.Focus();
                                this.tNedit_CampaignCode.Text = "";
                                this.tEdit_CampaignName.Clear();
                                this.tNedit_YearFrm.Clear();
                                this.tNedit_MonthFrm.Clear();
                                this.tNedit_DayFrm.Clear();
                                this.tNedit_YearTo.Clear();
                                this.tNedit_MonthTo.Clear();
                                this.tNedit_DayTo.Clear();
                                this._prevCampaignCode = 0;
                                this.SettingGuideButtonToolEnabled(this.ActiveControl);
                                return;
                            }
                        }
                    }

                    if (CheckSaveConfirm() == false)
                    {
                        this._prevEmployeeCode = employee.EmployeeCode.Trim();
                        return;
                    }
                    else
                    {
                        // ----- DEL K2011/07/05 ------- >>>>>>>>>
                        //if (this._searchFlg)
                        //{
                        //    DialogResult result = ShowMessageBox(emErrorLevel.ERR_LEVEL_SAVECONFIRM,
                        //                                        "",
                        //                                        0,
                        //                                        MessageBoxButtons.YesNoCancel,
                        //                                        MessageBoxDefaultButton.Button2);
                        //    switch (result)
                        //    {
                        //        case DialogResult.Yes:
                        //            {
                        //                // 保存処理
                        //                status = SaveProc();
                        //                if (status != 0)
                        //                {
                        //                    this._prevEmployeeCode = employee.EmployeeCode.Trim();
                        //                    return;
                        //                }

                        //                break;
                        //            }
                        //        case DialogResult.No:
                        //            {
                        //                break;
                        //            }
                        //        case DialogResult.Cancel:
                        //            {
                        //                this.tEdit_EmployeeCode.DataText = this._prevEmployeeCode;
                        //                this.tEdit_EmployeeName.DataText = GetEmployeeName(this._prevEmployeeCode);
                        //                return;
                        //            }
                        //    }
                        //}
                        // ----- DEL K2011/07/05 ------- <<<<<<<<<

                        // 検索
                        status = SearchProc();
                        if (status != 0)
                        {
                            ClearGrid();
                            this._prevEmployeeCode = employee.EmployeeCode.Trim();
                        }
                        else
                        {
                            this._prevEmployeeCode = employee.EmployeeCode.Trim();
                        }
                    }

                    // フォーカス設定
                    Control nextControl;
                    GetNextControl(this.EmployeeGuide_Button, out nextControl);
                    nextControl.Focus();
                    // ボタンツール有効無効設定処理
                    this.SettingGuideButtonToolEnabled(this.ActiveControl);
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Button_Click イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 地区ガイドボタンがクリックされた時に発生します。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/25</br>
        /// <br>Update Note: 2011/07/05 譚洪 Redmine#22750 フォーカス制御障害の対応</br>
        /// </remarks>
        private void SalesAreaGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                UserGdHd userGdHd;
                UserGdBd userGdBd;

                int status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 21);

                if (status == 0)
                {
                    // 地区コード設定
                    this.tNedit_SalesAreaCode.SetInt(userGdBd.GuideCode);
                    // 地区名設定
                    this.tEdit_SalesAreaName.DataText = userGdBd.GuideName.Trim();

                    if ((int)this.tComboEditor_TargetContrastCd.Value == 32)
                    {
                        // 検索
                        status = SearchProc();
                        //this._searchFlg = false;  // DEL K2011/07/05
                        if (this.tNedit_CampaignCode.Text.ToString() != "")
                        {
                            GetCampaignStList();
                            // キャンペーンコード取得
                            int campaignCode = this.tNedit_CampaignCode.GetInt();
                            if (string.IsNullOrEmpty(GetCampaignName(campaignCode)))
                            {
                                // 該当なし
                                this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "キャンペーンコードが存在しません。", -1);
                                this.tNedit_CampaignCode.Focus();
                                this.tNedit_CampaignCode.Text = "";
                                this.tEdit_CampaignName.Clear();
                                this.tNedit_YearFrm.Clear();
                                this.tNedit_MonthFrm.Clear();
                                this.tNedit_DayFrm.Clear();
                                this.tNedit_YearTo.Clear();
                                this.tNedit_MonthTo.Clear();
                                this.tNedit_DayTo.Clear();
                                this._prevCampaignCode = 0;
                                this.SettingGuideButtonToolEnabled(this.ActiveControl);
                                return;
                            }

                            int campainCapare = Convert.ToInt32(this.tNedit_CampaignCode.Text.ToString());
                      
                            if (this._campaignStDic[campainCapare].LogicalDeleteCode == 1 && status != 0)
                            {
                                this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "マスタに登録されていません。", -1);
                                this.tNedit_CampaignCode.Focus();
                                this.tNedit_CampaignCode.Text = "";
                                this.tEdit_CampaignName.Clear();
                                this.tNedit_YearFrm.Clear();
                                this.tNedit_MonthFrm.Clear();
                                this.tNedit_DayFrm.Clear();
                                this.tNedit_YearTo.Clear();
                                this.tNedit_MonthTo.Clear();
                                this.tNedit_DayTo.Clear();
                                this._prevCampaignCode = 0;
                                this.SettingGuideButtonToolEnabled(this.ActiveControl);
                                return;
                            }
                        }
                    }

                    if (CheckSaveConfirm() == false)
                    {
                        this._prevSalesAreaCode = userGdBd.GuideCode;
                        return;
                    }
                    else
                    {
                        // ----- DEL K2011/07/05 ------- >>>>>>>>>
                        //if (this._searchFlg)
                        //{
                        //    DialogResult result = ShowMessageBox(emErrorLevel.ERR_LEVEL_SAVECONFIRM,
                        //                                        "",
                        //                                        0,
                        //                                        MessageBoxButtons.YesNoCancel,
                        //                                        MessageBoxDefaultButton.Button2);
                        //    switch (result)
                        //    {
                        //        case DialogResult.Yes:
                        //            {
                        //                // 保存処理
                        //                status = SaveProc();
                        //                if (status != 0)
                        //                {
                        //                    this._prevSalesAreaCode = userGdBd.GuideCode;
                        //                    return;
                        //                }

                        //                break;
                        //            }
                        //        case DialogResult.No:
                        //            {
                        //                break;
                        //            }
                        //        case DialogResult.Cancel:
                        //            {
                        //                this.tNedit_SalesAreaCode.SetInt(this._prevSalesAreaCode);
                        //                this.tEdit_SalesAreaName.DataText = GetSalesAreaName(this._prevSalesAreaCode);
                        //                return;
                        //            }
                        //    }
                        //}
                        // ----- DEL K2011/07/05 ------- <<<<<<<<<

                        // 検索
                        status = SearchProc();
                        if (status != 0)
                        {
                            ClearGrid();
                            this._prevSalesAreaCode = userGdBd.GuideCode;
                        }
                        else
                        {
                            this._prevSalesAreaCode = userGdBd.GuideCode;
                        }
                    }

                    // フォーカス設定
                    Control nextControl;
                    GetNextControl(this.SalesAreaGuide_Button, out nextControl);
                    nextControl.Focus();
                    // ボタンツール有効無効設定処理
                    this.SettingGuideButtonToolEnabled(this.ActiveControl);
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Button_Click イベント(BLGuide_Button)
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note		: ＢＬコードガイドボタンがクリックされた時に発生します。</br>
        /// <br>Programmer  : 徐佳</br>
        /// <br>Date        : 2011/04/25</br>
        /// <br>Update Note: 2011/07/05 譚洪 Redmine#22750 フォーカス制御障害の対応</br>
        /// </remarks>
        private void BLGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                BLGoodsCdUMnt blGoodsCdUMnt = null;

                int status = this._blGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out blGoodsCdUMnt);
                if (status == 0)
                {
                    // BLコード設定
                    this.tNedit_BLGoodsCode.Value = blGoodsCdUMnt.BLGoodsCode;
                    // BL名設定
                    this.tEdit_BLName.DataText = blGoodsCdUMnt.BLGoodsFullName.Trim();

                    if ((int)this.tComboEditor_TargetContrastCd.Value == 60)
                    {
                        // 検索
                        status = SearchProc();
                        //this._searchFlg = false;  // DEL K2011/07/05
                        if (this.tNedit_CampaignCode.Text.ToString() != "")
                        {
                            GetCampaignStList();

                            // キャンペーンコード取得
                            int campaignCode = this.tNedit_CampaignCode.GetInt();
                            if (string.IsNullOrEmpty(GetCampaignName(campaignCode)))
                            {
                                // 該当なし
                                this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "キャンペーンコードが存在しません。", -1);
                                this.tNedit_CampaignCode.Focus();
                                this.tNedit_CampaignCode.Text = "";
                                this.tEdit_CampaignName.Clear();
                                this.tNedit_YearFrm.Clear();
                                this.tNedit_MonthFrm.Clear();
                                this.tNedit_DayFrm.Clear();
                                this.tNedit_YearTo.Clear();
                                this.tNedit_MonthTo.Clear();
                                this.tNedit_DayTo.Clear();
                                this._prevCampaignCode = 0;
                                this.SettingGuideButtonToolEnabled(this.ActiveControl);
                                return;
                            }

                            int campainCapare = Convert.ToInt32(this.tNedit_CampaignCode.Text.ToString());
                          
                            if (this._campaignStDic[campainCapare].LogicalDeleteCode == 1 && status != 0)
                            {
                                this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "マスタに登録されていません。", -1);
                                this.tNedit_CampaignCode.Focus();
                                this.tNedit_CampaignCode.Text = "";
                                this.tEdit_CampaignName.Clear();
                                this.tNedit_YearFrm.Clear();
                                this.tNedit_MonthFrm.Clear();
                                this.tNedit_DayFrm.Clear();
                                this.tNedit_YearTo.Clear();
                                this.tNedit_MonthTo.Clear();
                                this.tNedit_DayTo.Clear();
                                this._prevCampaignCode = 0;
                                this.SettingGuideButtonToolEnabled(this.ActiveControl);
                                return;
                            }
                        }
                    }

                    if (CheckSaveConfirm() == false)
                    {
                        this._prevBLGoodsCode = blGoodsCdUMnt.BLGoodsCode;
                        return;
                    }
                    else
                    {
                        // ----- DEL K2011/07/05 ------- >>>>>>>>>
                        //if (this._searchFlg)
                        //{
                        //    DialogResult result = ShowMessageBox(emErrorLevel.ERR_LEVEL_SAVECONFIRM,
                        //                                        "",
                        //                                        0,
                        //                                        MessageBoxButtons.YesNoCancel,
                        //                                        MessageBoxDefaultButton.Button2);
                        //    switch (result)
                        //    {
                        //        case DialogResult.Yes:
                        //            {
                        //                // 保存処理
                        //                status = SaveProc();
                        //                if (status != 0)
                        //                {
                        //                    this.tNedit_BLGoodsCode.Value= blGoodsCdUMnt.BLGoodsCode;
                        //                    return;
                        //                }

                        //                break;
                        //            }
                        //        case DialogResult.No:
                        //            {
                        //                break;
                        //            }
                        //        case DialogResult.Cancel:
                        //            {
                        //                this.tNedit_BLGoodsCode.Value = this._prevBLGoodsCode;
                        //                this.tEdit_BLName.DataText = GetBLGoodsName(this._prevBLGoodsCode);
                        //                return;
                        //            }
                        //    }
                        //}
                        // ----- DEL K2011/07/05 ------- <<<<<<<<<

                        // 検索
                        status = SearchProc();
                        if (status != 0)
                        {
                            ClearGrid();
                            this._prevBLGoodsCode = blGoodsCdUMnt.BLGoodsCode;
                        }
                        else
                        {
                            this._prevBLGoodsCode = blGoodsCdUMnt.BLGoodsCode;
                        }
                    }
                    // フォーカス設定
                    Control nextControl;
                    GetNextControl(this.BLGuide_Button, out nextControl);
                    nextControl.Focus();
                    // ボタンツール有効無効設定処理
                    this.SettingGuideButtonToolEnabled(this.ActiveControl);
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Button_Click イベント(GroupGuide_Button)
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note		: グループコードガイドボタンがクリックされた時に発生します。</br>
        /// <br>Programmer  : 徐佳</br>
        /// <br>Date        : 2011/04/25</br>
        /// <br>Update Note: 2011/07/05 譚洪 Redmine#22750 フォーカス制御障害の対応</br>
        /// </remarks>
        private void GroupGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                BLGroupU blGroupU = new BLGroupU();

                int status = this._blGroupUAcs.ExecuteGuid(this._enterpriseCode, out blGroupU);
                if (status == 0)
                {
                    // BLグループコード設定
                    this.tNedit_BLGloupCode.Value = blGroupU.BLGroupCode;
                    // BLグループ名設定
                    this.tEdit_GroupName.DataText = GetBLGroupName(blGroupU.BLGroupCode);
                    if ((int)this.tComboEditor_TargetContrastCd.Value == 50)
                    {
                        // 検索
                        status = SearchProc();
                        //this._searchFlg = false;  // DEL K2011/07/05
                        if (this.tNedit_CampaignCode.Text.ToString() != "")
                        {
                            GetCampaignStList();
                            // キャンペーンコード取得
                            int campaignCode = this.tNedit_CampaignCode.GetInt();
                            if (string.IsNullOrEmpty(GetCampaignName(campaignCode)))
                            {
                                // 該当なし
                                this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "キャンペーンコードが存在しません。", -1);
                                this.tNedit_CampaignCode.Focus();
                                this.tNedit_CampaignCode.Text = "";
                                this.tEdit_CampaignName.Clear();
                                this.tNedit_YearFrm.Clear();
                                this.tNedit_MonthFrm.Clear();
                                this.tNedit_DayFrm.Clear();
                                this.tNedit_YearTo.Clear();
                                this.tNedit_MonthTo.Clear();
                                this.tNedit_DayTo.Clear();
                                this._prevCampaignCode = 0;
                                this.SettingGuideButtonToolEnabled(this.ActiveControl);
                                return;
                            }

                            int campainCapare = Convert.ToInt32(this.tNedit_CampaignCode.Text.ToString());
                            if (this._campaignStDic[campainCapare].LogicalDeleteCode == 1 && status != 0)
                            {
                                this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "マスタに登録されていません。", -1);
                                this.tNedit_CampaignCode.Focus();
                                this.tNedit_CampaignCode.Text = "";
                                this.tEdit_CampaignName.Clear();
                                this.tNedit_YearFrm.Clear();
                                this.tNedit_MonthFrm.Clear();
                                this.tNedit_DayFrm.Clear();
                                this.tNedit_YearTo.Clear();
                                this.tNedit_MonthTo.Clear();
                                this.tNedit_DayTo.Clear();
                                this._prevCampaignCode = 0;
                                this.SettingGuideButtonToolEnabled(this.ActiveControl);
                                return;
                            }
                        }
                    }

                    if (CheckSaveConfirm() == false)
                    {
                        this._prevBLGroupCode = blGroupU.BLGroupCode;
                        return;
                    }
                    else
                    {
                        // ----- DEL K2011/07/05 ------- >>>>>>>>>
                        //if (this._searchFlg)
                        //{
                        //    DialogResult result = ShowMessageBox(emErrorLevel.ERR_LEVEL_SAVECONFIRM,
                        //                                        "",
                        //                                        0,
                        //                                        MessageBoxButtons.YesNoCancel,
                        //                                        MessageBoxDefaultButton.Button2);
                        //    switch (result)
                        //    {
                        //        case DialogResult.Yes:
                        //            {
                        //                // 保存処理
                        //                status = SaveProc();
                        //                if (status != 0)
                        //                {
                        //                    this.tNedit_BLGloupCode.Value = blGroupU.BLGroupCode;
                        //                    return;
                        //                }

                        //                break;
                        //            }
                        //        case DialogResult.No:
                        //            {
                        //                break;
                        //            }
                        //        case DialogResult.Cancel:
                        //            {
                        //                this.tNedit_BLGloupCode.Value = this._prevBLGroupCode;
                        //                this.tEdit_GroupName.DataText = GetBLGroupName(this._prevBLGroupCode);
                        //                return;
                        //            }
                        //    }
                        //}
                        // ----- DEL K2011/07/05 ------- <<<<<<<<<

                        // 検索
                        status = SearchProc();
                        if (status != 0)
                        {
                            ClearGrid();
                            this._prevBLGoodsCode = blGroupU.BLGroupCode;
                        }
                        else
                        {
                            this._prevBLGoodsCode = blGroupU.BLGroupCode;
                        }
                    }
                    // フォーカス設定
                    Control nextControl;
                    GetNextControl(this.GroupGuide_Button, out nextControl);
                    nextControl.Focus();
                    // ボタンツール有効無効設定処理
                    this.SettingGuideButtonToolEnabled(this.ActiveControl);
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Button_Click イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 販売区分ガイドボタンがクリックされた時に発生します。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/25</br>
        /// <br>Update Note: 2011/07/05 譚洪 Redmine#22750 フォーカス制御障害の対応</br>
        /// </remarks>
        private void SalesCodeGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                UserGdHd userGdHd;
                UserGdBd userGdBd;

                int status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 71);
                if (status == 0)
                {
                    // 販売区分コード設定
                    this.tNedit_SalesCode.SetInt(userGdBd.GuideCode);
                    // 販売区分名設定
                    this.tEdit_SalesCodeName.DataText = userGdBd.GuideName.Trim();

                    if ((int)this.tComboEditor_TargetContrastCd.Value == 44)
                    {
                        // 検索
                        status = SearchProc();
                        //this._searchFlg = false;  // DEL K2011/07/05
                        if (this.tNedit_CampaignCode.Text.ToString() != "")
                        {
                            GetCampaignStList();

                            // キャンペーンコード取得
                            int campaignCode = this.tNedit_CampaignCode.GetInt();
                            if (string.IsNullOrEmpty(GetCampaignName(campaignCode)))
                            {
                                // 該当なし
                                this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "キャンペーンコードが存在しません。", -1);
                                this.tNedit_CampaignCode.Focus();
                                this.tNedit_CampaignCode.Text = "";
                                this.tEdit_CampaignName.Clear();
                                this.tNedit_YearFrm.Clear();
                                this.tNedit_MonthFrm.Clear();
                                this.tNedit_DayFrm.Clear();
                                this.tNedit_YearTo.Clear();
                                this.tNedit_MonthTo.Clear();
                                this.tNedit_DayTo.Clear();
                                this._prevCampaignCode = 0;
                                this.SettingGuideButtonToolEnabled(this.ActiveControl);
                                return;
                            }

                            int campainCapare = Convert.ToInt32(this.tNedit_CampaignCode.Text.ToString());
                          
                            if (this._campaignStDic[campainCapare].LogicalDeleteCode == 1 && status != 0)
                            {
                                this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "マスタに登録されていません。", -1);
                                this.tNedit_CampaignCode.Focus();
                                this.tNedit_CampaignCode.Text = "";
                                this.tEdit_CampaignName.Clear();
                                this.tNedit_YearFrm.Clear();
                                this.tNedit_MonthFrm.Clear();
                                this.tNedit_DayFrm.Clear();
                                this.tNedit_YearTo.Clear();
                                this.tNedit_MonthTo.Clear();
                                this.tNedit_DayTo.Clear();
                                this._prevCampaignCode = 0;
                                this.SettingGuideButtonToolEnabled(this.ActiveControl);
                                return;
                            }
                        }
                    }

                    if (CheckSaveConfirm() == false)
                    {
                        this._prevSalesCode = userGdBd.GuideCode;
                        return;
                    }
                    else
                    {
                        // ----- DEL K2011/07/05 ------- >>>>>>>>>
                        //if (this._searchFlg)
                        //{
                        //    DialogResult result = ShowMessageBox(emErrorLevel.ERR_LEVEL_SAVECONFIRM,
                        //                                        "",
                        //                                        0,
                        //                                        MessageBoxButtons.YesNoCancel,
                        //                                        MessageBoxDefaultButton.Button2);
                        //    switch (result)
                        //    {
                        //        case DialogResult.Yes:
                        //            {
                        //                // 保存処理
                        //                status = SaveProc();
                        //                if (status != 0)
                        //                {
                        //                    this._prevSalesCode = userGdBd.GuideCode;
                        //                    return;
                        //                }

                        //                break;
                        //            }
                        //        case DialogResult.No:
                        //            {
                        //                break;
                        //            }
                        //        case DialogResult.Cancel:
                        //            {
                        //                this.tNedit_SalesCode.SetInt(this._prevSalesCode);
                        //                this.tEdit_SalesCodeName.DataText = GetSalesCodeName(this._prevSalesCode);
                        //                return;
                        //            }
                        //    }
                        //}
                        // ----- DEL K2011/07/05 ------- <<<<<<<<<

                        // 検索
                        status = SearchProc();
                        if (status != 0)
                        {
                            ClearGrid();
                            this._prevSalesCode = userGdBd.GuideCode;
                        }
                        else
                        {
                            this._prevSalesCode = userGdBd.GuideCode;
                        }
                    }

                    // フォーカス設定
                    Control nextControl;
                    GetNextControl(this.SalesCodeGuide_Button, out nextControl);
                    nextControl.Focus();
                    // ボタンツール有効無効設定処理
                    this.SettingGuideButtonToolEnabled(this.ActiveControl);
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
         #endregion ガイドボタン押下

        #region グリッド関

        /// <summary>
        /// AfterEnterEditMode イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : セルが編集モードになった時に発生します。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void SalesTarget_uGrid_AfterEnterEditMode(object sender, EventArgs e)
        {
            // ボタンツール有効無効設定処理
            this.SettingGuideButtonToolEnabled(this.ActiveControl);
            if (this.SalesTarget_uGrid.ActiveCell == null)
            {
                return;
            }

            if ((this.SalesTarget_uGrid.ActiveCell.Value == DBNull.Value) || 
                ((string)this.SalesTarget_uGrid.ActiveCell.Value == ""))
            {
                return;
            }

            string retText;
            string targetText = (string)this.SalesTarget_uGrid.ActiveCell.Value;

            // カンマのみ削除
            RemoveCommaPeriod(targetText, out retText, false);

            this.SalesTarget_uGrid.ActiveCell.Value = retText;
            this.SalesTarget_uGrid.ActiveCell.SelStart = 0;
            this.SalesTarget_uGrid.ActiveCell.SelLength = retText.Length;
        }

        /// <summary>
        /// AfterExitEditMode イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : セルの編集モードが終了した時に発生します。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void SalesTarget_uGrid_AfterExitEditMode(object sender, EventArgs e)
        {
            if (this.SalesTarget_uGrid.ActiveCell == null)
            {
                return;
            }

            int columnIndex = this.SalesTarget_uGrid.ActiveCell.Column.Index;

            if ((this.SalesTarget_uGrid.ActiveCell.Value != DBNull.Value) &&
                ((string)this.SalesTarget_uGrid.ActiveCell.Value != ""))
            {
                string retText;
                string targetText = (string)this.SalesTarget_uGrid.ActiveCell.Value;

                // カンマのみ削除
                RemoveCommaPeriod(targetText, out retText, false);
                double targetValue;
                try
                {
                   targetValue = double.Parse(retText);
                   if (targetText.Length > 13)
                   {
                       this.SalesTarget_uGrid.ActiveCell.Value = "";
                   }
                   else
                   {
                       // ユーザー定価の場合
                       this.SalesTarget_uGrid.ActiveCell.Value = targetValue.ToString(FORMAT_NUM);
                   }
                   
                }
                catch
                {
                    this.SalesTarget_uGrid.ActiveCell.Value = "";
                }  
            }

            // 合計目標取得
            double totalTarget = GetTotalTarget(columnIndex);

            if (totalTarget == 0)
            {
                this.SalesTarget_uGrid.Rows[12].Cells[columnIndex].Value = "";
            }
            else
            {
                this.SalesTarget_uGrid.Rows[12].Cells[columnIndex].Value = totalTarget.ToString(FORMAT_NUM1);
            }
        }

        /// <summary>
        /// KeyDown イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : グリッドがアクティブ状態でキーが押された時に発生します。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void SalesTarget_uGrid_KeyDown(object sender, KeyEventArgs e)
        {
            int rowIndex;
            int columnIndex;

            if (this.SalesTarget_uGrid.ActiveCell == null)
            {
                if (this.SalesTarget_uGrid.ActiveRow == null)
                {
                    rowIndex = 0;
                    columnIndex = 1;
                }
                else
                {
                    rowIndex = this.SalesTarget_uGrid.ActiveRow.Index;
                    columnIndex = 1;
                }
            }
            else
            {
                rowIndex = this.SalesTarget_uGrid.ActiveCell.Row.Index;
                columnIndex = this.SalesTarget_uGrid.ActiveCell.Column.Index;
            }

            switch (e.KeyCode)
            {
                case Keys.Up:
                    {
                        e.Handled = true;

                        if (rowIndex == 0)
                        {
                            if (columnIndex == 1)
                            {
                                this.tNedit_SalesTargetSale1.Focus();
                            }
                            else if (columnIndex == 2)
                            {
                                this.tNedit_SalesTargetProfit1.Focus();
                            }
                            else
                            {
                                this.tNedit_SalesTargetCount1.Focus();
                            }
                        }
                        else
                        {
                            this.SalesTarget_uGrid.Rows[rowIndex - 1].Cells[columnIndex].Activate();
                            this.SalesTarget_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        break;
                    }
                case Keys.Down:
                    {
                        e.Handled = true;

                        if (rowIndex < 11)
                        {
                            this.SalesTarget_uGrid.Rows[rowIndex + 1].Cells[columnIndex].Activate();
                            this.SalesTarget_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        break;
                    }
                case Keys.Left:
                    {
                        if (this.SalesTarget_uGrid.ActiveCell.IsInEditMode)
                        {
                            if (this.SalesTarget_uGrid.ActiveCell.SelStart == 0)
                            {
                                e.Handled = true;

                                if (columnIndex <= 1)
                                {
                                    int targetContrastCd = (int)this.tComboEditor_TargetContrastCd.Value;
                                    if (targetContrastCd == 45)
                                    {
                                        this.BLGuide_Button.Focus();
                                    }
                                    else
                                    {
                                        this.SectionGuide_Button.Focus();
                                    }
                                }
                                else
                                {
                                    this.SalesTarget_uGrid.Rows[rowIndex].Cells[columnIndex - 1].Activate();
                                    this.SalesTarget_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                }
                            }
                        }
                        break;
                    }
                case Keys.Right:
                    {
                        if (this.SalesTarget_uGrid.ActiveCell.IsInEditMode)
                        {
                            if (this.SalesTarget_uGrid.ActiveCell.SelStart >= this.SalesTarget_uGrid.ActiveCell.Text.Length)
                            {
                                e.Handled = true;

                                if (columnIndex != 3)
                                {
                                    this.SalesTarget_uGrid.Rows[rowIndex].Cells[columnIndex + 1].Activate();
                                    this.SalesTarget_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                }
                            }
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// KeyPress イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : グリッドがアクティブ状態でキーが押された時に発生します。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void SalesTarget_uGrid_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 制御キーが押された？
            if (Char.IsControl(e.KeyChar))
            {
                return;
            }
            
            if (this.SalesTarget_uGrid.ActiveCell == null)
            {
                return;
            }

            int rowIndex = this.SalesTarget_uGrid.ActiveCell.Row.Index;
            int columnIndex = this.SalesTarget_uGrid.ActiveCell.Column.Index;

            if (columnIndex < 1)
            {
                return;
            }

            // 「Backspace」キーを押された時
            if ((byte)e.KeyChar == (byte)'\b')
            {
                return;
            }

            // 対象セルのテキスト取得
            string retText;
            string targetText = this.SalesTarget_uGrid.ActiveCell.Text;
            this.SalesTarget_uGrid.PerformAction(UltraGridAction.EnterEditMode);

            // 各行の入力可能桁数を設定します
            switch (columnIndex)
            {

                // 売上目標、粗利目標 数量目標
                // 11
                case 1:
                case 2:
                    // セルのテキストが選択されている場合
                    if (this.SalesTarget_uGrid.ActiveCell.SelText == targetText)
                    {
                        // 数値のみ入力可
                        if ((byte)e.KeyChar < (byte)'0' || (byte)'9' < (byte)e.KeyChar)
                        {
                            e.KeyChar = '\0';
                        }
                    }
                    else
                    {
                        // カンマ、ピリオド削除
                        RemoveCommaPeriod(targetText, out retText, true);

                        // 文字数が9文字だったら入力不可
                        if (retText.Length == 10)
                        {
                            e.KeyChar = '\0';
                        }
                        else
                        {
                            // 数値以外の時
                            if ((byte)e.KeyChar < (byte)'0' || (byte)'9' < (byte)e.KeyChar)
                            {
                                // 入力値の1文字目は「,」不可
                                if (targetText == "")
                                {
                                    e.KeyChar = '\0';
                                }
                                else
                                {
                                    // 「,」は入力可
                                    if ((byte)e.KeyChar != ',')
                                    {
                                        e.KeyChar = '\0';
                                    }

                                    if (targetText[targetText.Length - 1].ToString() == ",")
                                    {
                                        e.KeyChar = '\0';
                                    }
                                }
                            }
                        }
                    }
                    break;
                case 3:
                    // セルのテキストが選択されている場合
                    if (this.SalesTarget_uGrid.ActiveCell.SelText == targetText)
                    {
                        // 数値のみ入力可
                        if ((byte)e.KeyChar < (byte)'0' || (byte)'9' < (byte)e.KeyChar)
                        {
                            e.KeyChar = '\0';
                        }
                    }
                    else
                    {
                        // カンマ、ピリオド削除
                        RemoveCommaPeriod(targetText, out retText, true);

                        // 文字数が9文字だったら入力不可
                        if (retText.Length == 8)
                        {
                            e.KeyChar = '\0';
                        }
                        else
                        {
                            // 数値以外の時
                            if ((byte)e.KeyChar < (byte)'0' || (byte)'9' < (byte)e.KeyChar)
                            {
                                // 入力値の1文字目は「,」不可
                                if (targetText == "")
                                {
                                    e.KeyChar = '\0';
                                }
                                else
                                {
                                    // 「,」は入力可
                                    if ((byte)e.KeyChar != ',')
                                    {
                                        e.KeyChar = '\0';
                                    }

                                    if (targetText[targetText.Length - 1].ToString() == ",")
                                    {
                                        e.KeyChar = '\0';
                                    }
                                }
                            }
                        }
                    }
                    break;
            }
        }

        /// <summary>
        /// Leave イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : グリッドからフォーカスが離れた時に発生します。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void SalesTarget_uGrid_Leave(object sender, EventArgs e)
        {
            this.SalesTarget_uGrid.ActiveCell = null;
            this.SalesTarget_uGrid.ActiveRow = null;
        }
        #endregion グリッド関連

        /// <summary>
        /// SelectionChangeCommitted イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 設定区分の値が変更された時に発生します。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void tComboEditor_TargetContrastCd_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (this.tComboEditor_TargetContrastCd.Value == null)
            {
                return;
            }

            ComboChgClearScreen();
            // 設定区分条件コントロールEnabled制御
            ChangeTargetContrastControl((int)this.tComboEditor_TargetContrastCd.Value);

            this._prevSetArea = (int)this.tComboEditor_TargetContrastCd.Value;
        }

        private void AfterChangeTargetContrastCd()
        {
            int status;

            // ----- DEL K2011/07/05 ------- >>>>>>>>>
            //if (this._searchFlg)
            //{
            //    DialogResult result = ShowMessageBox(emErrorLevel.ERR_LEVEL_SAVECONFIRM,
            //                                        "",
            //                                        0,
            //                                        MessageBoxButtons.YesNoCancel,
            //                                        MessageBoxDefaultButton.Button2);
            //    switch (result)
            //    {
            //        case DialogResult.Yes:
            //            {
            //                // 保存処理
            //                status = SaveProc();
            //                if (status != 0)
            //                {
            //                    this._prevTargetContrastCd = (int)this.tComboEditor_TargetContrastCd.Value;
            //                    return;
            //                }

            //                break;
            //            }
            //        case DialogResult.No:
            //            {
            //                break;
            //            }
            //        case DialogResult.Cancel:
            //            {
            //                this.tComboEditor_TargetContrastCd.SelectionChangeCommitted -= tComboEditor_TargetContrastCd_SelectionChangeCommitted;
            //                this.tComboEditor_TargetContrastCd.Value = this._prevTargetContrastCd;
            //                this.tComboEditor_TargetContrastCd.SelectionChangeCommitted += tComboEditor_TargetContrastCd_SelectionChangeCommitted;
            //                return;
            //            }
            //    }
            //}
            // ----- DEL K2011/07/05 ------- <<<<<<<<<

            //検索
           status = SearchProc();
            if (status != 0)
            {
                int prevTargetContrastCd = (int)this.tComboEditor_TargetContrastCd.Value;
                ClearScreen();
                this._prevTargetContrastCd = prevTargetContrastCd;
                this.tComboEditor_TargetContrastCd.SelectionChangeCommitted -= tComboEditor_TargetContrastCd_SelectionChangeCommitted;
                this.tComboEditor_TargetContrastCd.Value = prevTargetContrastCd;
                this.tComboEditor_TargetContrastCd.SelectionChangeCommitted += tComboEditor_TargetContrastCd_SelectionChangeCommitted;
            }
            else
            {
                this._prevTargetContrastCd = (int)this.tComboEditor_TargetContrastCd.Value;
            }

            this.Top_Panel.Focus();
            this.tComboEditor_TargetContrastCd.Focus();

            // 設定区分条件コントロールEnabled制御
            ChangeTargetContrastControl((int)this.tComboEditor_TargetContrastCd.Value);
        }
        /// <summary>
        /// ChangeFocus イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : コントロールのフォーカスが変更された時に発生します。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/25</br>
        /// <br>Update Note: 2011/07/05 譚洪 Redmine#22750 フォーカス制御障害の対応</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            int status;
            GetCampaignStList();

            switch (e.PrevCtrl.Name)
            {
                // キャンペーンコード
                case "tNedit_CampaignCode":
                    {
                      
                        if (this.tNedit_CampaignCode.GetInt() == 0)
                        {
                            this.tEdit_CampaignName.Clear();
                            this.tNedit_YearFrm.Clear();
                            this.tNedit_MonthFrm.Clear();
                            this.tNedit_DayFrm.Clear();
                            this.tNedit_YearTo.Clear();
                            this.tNedit_MonthTo.Clear();
                            this.tNedit_DayTo.Clear();
                            this.tNedit_CampaignCode.Clear();
                            this._prevCampaignCode = 0;
                            break;
                        }
                        // キャンペーンコード取得
                        int campaignCode = this.tNedit_CampaignCode.GetInt();

                        if (campaignCode != this._prevCampaignCode)
                        {
                            if (!string.IsNullOrEmpty(GetCampaignName(campaignCode)))
                            {
                                // キャンペーン名取得
                                this.tEdit_CampaignName.DataText = GetCampaignName(campaignCode);
                                this._prevCampaignCode = campaignCode;

                                CampaignSt campaignSt = ReadCampaignSt(campaignCode);
                                this.tNedit_YearFrm.SetInt(campaignSt.ApplyStaDate.Year);
                                this.tNedit_MonthFrm.SetInt(campaignSt.ApplyStaDate.Month);
                                this.tNedit_DayFrm.SetInt(campaignSt.ApplyStaDate.Day);
                                this.tNedit_YearTo.SetInt(campaignSt.ApplyEndDate.Year);
                                this.tNedit_MonthTo.SetInt(campaignSt.ApplyEndDate.Month);
                                this.tNedit_DayTo.SetInt(campaignSt.ApplyEndDate.Day);
                                if (((int)this.tComboEditor_TargetContrastCd.Value == 10 && this.tEdit_SectionCode.Text !="")
                                    ||((int)this.tComboEditor_TargetContrastCd.Value == 30 && this.tEdit_SectionCode.Text !="" &&  this.tNedit_CustomerCode.Text !="")
                                    ||((int)this.tComboEditor_TargetContrastCd.Value == 221 && this.tEdit_SectionCode.Text !="" &&  this.tEdit_EmployeeName.Text !="")
                                    ||((int)this.tComboEditor_TargetContrastCd.Value == 222 && this.tEdit_SectionCode.Text !="" &&  this.tEdit_EmployeeName.Text !="")
                                    ||((int)this.tComboEditor_TargetContrastCd.Value == 223 && this.tEdit_SectionCode.Text !="" &&  this.tEdit_EmployeeName.Text !="")
                                    ||((int)this.tComboEditor_TargetContrastCd.Value == 32 && this.tEdit_SectionCode.Text !="" &&  this.tNedit_SalesAreaCode.Text !="")
                                    ||((int)this.tComboEditor_TargetContrastCd.Value == 50 && this.tEdit_SectionCode.Text !="" &&  this.tNedit_BLGloupCode.Text !="")
                                    ||((int)this.tComboEditor_TargetContrastCd.Value == 60 && this.tEdit_SectionCode.Text !="" &&  this.tNedit_BLGoodsCode.Text !="")
                                    ||((int)this.tComboEditor_TargetContrastCd.Value == 44 && this.tEdit_SectionCode.Text !="" &&  this.tNedit_SalesCode.Text !=""))
                                {
                                    // 検索
                                    status = SearchProc();
                                    //this._searchFlg = false; // DEL K2011/07/05
                                    if (this.tNedit_CampaignCode.Text.ToString() != "")
                                    {
                                        GetCampaignStList();

                                        // キャンペーンコード取得
                                        campaignCode = this.tNedit_CampaignCode.GetInt();
                                        if (string.IsNullOrEmpty(GetCampaignName(campaignCode)))
                                        {
                                            // 該当なし
                                            this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "キャンペーンコードが存在しません。", -1);
                                            e.NextCtrl = this.tNedit_CampaignCode;
                                            this.tNedit_CampaignCode.Text = "";
                                            this.tEdit_CampaignName.Clear();
                                            this.tNedit_YearFrm.Clear();
                                            this.tNedit_MonthFrm.Clear();
                                            this.tNedit_DayFrm.Clear();
                                            this.tNedit_YearTo.Clear();
                                            this.tNedit_MonthTo.Clear();
                                            this.tNedit_DayTo.Clear();
                                            this._prevCampaignCode = 0;
                                            this.SettingGuideButtonToolEnabled(this.ActiveControl);
                                            return;
                                        }

                                        int campainCapare = Convert.ToInt32(this.tNedit_CampaignCode.Text.ToString());
                                      
                                        if (this._campaignStDic[campainCapare].LogicalDeleteCode == 1 && status != 0)
                                        {
                                            this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "マスタに登録されていません。", -1);
                                            e.NextCtrl = this.tNedit_CampaignCode;
                                            this.tNedit_CampaignCode.Text = "";
                                            this.tEdit_CampaignName.Clear();
                                            this.tNedit_YearFrm.Clear();
                                            this.tNedit_MonthFrm.Clear();
                                            this.tNedit_DayFrm.Clear();
                                            this.tNedit_YearTo.Clear();
                                            this.tNedit_MonthTo.Clear();
                                            this.tNedit_DayTo.Clear();
                                            this._prevCampaignCode = 0;
                                            this.SettingGuideButtonToolEnabled(this.ActiveControl);
                                            return;
                                        }
                                    }
                                }
                           
                            }
                            else
                            {
                                // 該当なし
                                this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "キャンペーンコードが存在しません。", -1);
                                e.NextCtrl = e.PrevCtrl;
                                this.tNedit_CampaignCode.SetInt(this._prevCampaignCode);
                                this.tEdit_CampaignName.DataText = GetCampaignName(this._prevCampaignCode);
                                return;
                            }

                            if (CheckSaveConfirm() == false)
                            {
                                this._prevCampaignCode = campaignCode;
                            }
                            else
                            {
                                // ----- DEL K2011/07/05 ------- >>>>>>>>>
                                //if (this._searchFlg)
                                //{
                                //    DialogResult result = ShowMessageBox(emErrorLevel.ERR_LEVEL_SAVECONFIRM,
                                //                                        "",
                                //                                        0,
                                //                                        MessageBoxButtons.YesNoCancel,
                                //                                        MessageBoxDefaultButton.Button2);
                                //    switch (result)
                                //    {
                                //        case DialogResult.Yes:
                                //            {
                                //                // 保存処理
                                //                status = SaveProc();
                                //                if (status != 0)
                                //                {
                                //                    this._prevCampaignCode = campaignCode;
                                //                    break;
                                //                }

                                //                break;
                                //            }
                                //        case DialogResult.No:
                                //            {
                                //                break;
                                //            }
                                //        case DialogResult.Cancel:
                                //            {
                                //                this.tNedit_CampaignCode.Value = this._prevCampaignCode;
                                //                this.tEdit_CampaignName.DataText = GetCampaignName(this._prevCampaignCode);
                                //                break;
                                //            }
                                //    }
                                //}
                                // ----- DEL K2011/07/05 ------- <<<<<<<<<


                                // 検索
                                status = SearchProc();
                                if (status != 0)
                                {
                                    ClearGrid();
                                    this._prevCampaignCode = campaignCode;
                                }
                                else
                                {
                                    this._prevCampaignCode = campaignCode;
                                }
                            }
                        }

                        // フォーカス設定
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                Control nextControl;
                                GetNextControl(this.tNedit_CampaignCode, out nextControl);
                                e.NextCtrl = nextControl;
                                break;
                            }
                        }
                        //else
                        //{
                        //    if (e.Key == Keys.Tab)
                        //    {
                        //        if (this.tNedit_CampaignCode.DataText.Trim() != "")
                        //        {
                        //            e.NextCtrl = this.tComboEditor_TargetContrastCd;
                        //            break;
                        //        }
                        //    }
                        //}

                        break;
                    }
                case "tComboEditor_TargetContrastCd":
                    {
                        if (this._prevSetArea != (int)this.tComboEditor_TargetContrastCd.Value)
                        {
                            if (this.tComboEditor_TargetContrastCd.Value == null)
                            {
                                return;
                            }

                            ComboChgClearScreen();
                            // 設定区分条件コントロールEnabled制御
                            ChangeTargetContrastControl((int)this.tComboEditor_TargetContrastCd.Value);

                            this._prevSetArea = (int)this.tComboEditor_TargetContrastCd.Value;
                        }
                        break;
                    }
                // 拠点
                case "tEdit_SectionCode":
                    {
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Down)
                            {
                                if ((int)this.tComboEditor_TargetContrastCd.Value == 10)
                                {
                                    e.NextCtrl = null;
                                    break;
                                }
                            }
                        }

                        if (this.tEdit_SectionCode.DataText.Trim() == "")
                        {
                            this.tEdit_SectionName.Clear();
                            ClearGrid();    // ADD K2011/07/05
                            this._prevSectionCode = "";
                            break;
                        }

                        // 拠点コード取得
                        string sectionCode = this.tEdit_SectionCode.DataText.Trim().PadLeft(2, '0');

                        if (sectionCode != this._prevSectionCode)
                        {
                            
                            if (!string.IsNullOrEmpty(GetSectionName(sectionCode)))
                            {
                                // 拠点名取得
                                this.tEdit_SectionName.DataText = GetSectionName(sectionCode);
                                this._prevSectionCode = sectionCode;
                                if ((int)this.tComboEditor_TargetContrastCd.Value == 10)
                                {
                                    // 検索
                                    status = SearchProc();
                                    //this._searchFlg = false // DEL K2011/07/05
                                    if (this.tNedit_CampaignCode.Text.ToString() != "")
                                    {
                                        GetCampaignStList();

                                        // キャンペーンコード取得
                                        int campaignCode = this.tNedit_CampaignCode.GetInt();
                                        if (string.IsNullOrEmpty(GetCampaignName(campaignCode)))
                                        {
                                            // 該当なし
                                            this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "キャンペーンコードが存在しません。", -1);
                                            e.NextCtrl = this.tNedit_CampaignCode;
                                            this.tNedit_CampaignCode.Text = "";
                                            this.tEdit_CampaignName.Clear();
                                            this.tNedit_YearFrm.Clear();
                                            this.tNedit_MonthFrm.Clear();
                                            this.tNedit_DayFrm.Clear();
                                            this.tNedit_YearTo.Clear();
                                            this.tNedit_MonthTo.Clear();
                                            this.tNedit_DayTo.Clear();
                                            this._prevCampaignCode = 0;
                                            this.SettingGuideButtonToolEnabled(this.ActiveControl);
                                            return;
                                        }

                                        int campainCapare = Convert.ToInt32(this.tNedit_CampaignCode.Text.ToString());

                                        if (this._campaignStDic[campainCapare].LogicalDeleteCode == 1 && status != 0)
                                        {
                                            this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "マスタに登録されていません。", -1);
                                            e.NextCtrl = this.tNedit_CampaignCode;
                                            this.tNedit_CampaignCode.Text = "";
                                            this.tEdit_CampaignName.Clear();
                                            this.tNedit_YearFrm.Clear();
                                            this.tNedit_MonthFrm.Clear();
                                            this.tNedit_DayFrm.Clear();
                                            this.tNedit_YearTo.Clear();
                                            this.tNedit_MonthTo.Clear();
                                            this.tNedit_DayTo.Clear();
                                            this._prevCampaignCode = 0;
                                            this.SettingGuideButtonToolEnabled(this.ActiveControl);
                                            return;
                                        }
                                    }
                                }
                                // ----- ADD K2011/07/05 ------- >>>>>>>>>
                                else
                                {
                                    if (CheckSaveConfirm() == false)
                                    {
                                        this._prevSectionCode = sectionCode;
                                    }
                                    else
                                    {
                                        // 検索
                                        status = SearchProc();
                                        if (status != 0)
                                        {
                                            ClearGrid();
                                            this._prevSectionCode = sectionCode;
                                        }
                                        else
                                        {
                                            this._prevSectionCode = sectionCode;
                                        }
                                    }
                                }
                                // ----- ADD K2011/07/05 ------- <<<<<<<<<
                            }
                            else
                            {
                                // 該当なし
                                this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "マスタに登録されていません。", -1);
                                e.NextCtrl = e.PrevCtrl;
                                this.tEdit_SectionCode.DataText = this._prevSectionCode;
                                this.tEdit_SectionName.DataText = GetSectionName(this._prevSectionCode);
                                return;
                            }

                            // ----- DEL K2011/07/05 ------- >>>>>>>>> 
                            //if (CheckSaveConfirm() == false)
                            //{
                            //    this._prevSectionCode = sectionCode;
                            //}
                            //else
                            //{
                            //    if (this._searchFlg)
                            //    {
                            //        DialogResult result = ShowMessageBox(emErrorLevel.ERR_LEVEL_SAVECONFIRM,
                            //                                            "",
                            //                                            0,
                            //                                            MessageBoxButtons.YesNoCancel,
                            //                                            MessageBoxDefaultButton.Button2);
                            //        switch (result)
                            //        {
                            //            case DialogResult.Yes:
                            //                {
                            //                    // 保存処理
                            //                    status = SaveProc();
                            //                    if (status != 0)
                            //                    {
                            //                        this._prevSectionCode = sectionCode;
                            //                        break;
                            //                    }

                            //                    break;
                            //                }
                            //            case DialogResult.No:
                            //                {
                            //                    break;
                            //                }
                            //            case DialogResult.Cancel:
                            //                {
                            //                    this.tEdit_SectionCode.DataText = this._prevSectionCode;
                            //                    this.tEdit_SectionName.DataText = GetSectionName(this._prevSectionCode);
                            //                    break;
                            //                }
                            //        }
                            //    }


                            //    // 検索
                            //    status = SearchProc();
                            //    if (status != 0)
                            //    {
                            //        ClearGrid();
                            //        this._prevSectionCode = sectionCode;
                            //    }
                            //    else
                            //    {
                            //        this._prevSectionCode = sectionCode;
                            //    }
                            //}
                            // ----- DEL K2011/07/05 ------- >>>>>>>>>
                        }

                        // フォーカス設定
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                if (this.tEdit_SectionName.DataText.Trim() != "")
                                {
                                    Control nextControl;
                                    GetNextControl(this.tEdit_SectionCode, out nextControl);
                                    e.NextCtrl = nextControl;
                                    break;
                                }
                            }
                        }
                        break;
                    }
                case "tNedit_CustomerCode":
                    {
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Down)
                            {
                                if ((int)this.tComboEditor_TargetContrastCd.Value == 30)
                                {
                                    e.NextCtrl = null;
                                    break;
                                }
                            }
                        }

                        if (this.tNedit_CustomerCode.GetInt() == 0)
                        {
                            this.tEdit_CustomerName.Clear();
                            this.tNedit_CustomerCode.Clear();
                            ClearGrid();    // ADD K2011/07/05
                            this._prevCustomerCode = 0;
                            break;
                        }

                        // 得意先コード取得
                        int customerCode = this.tNedit_CustomerCode.GetInt();

                        if (customerCode != this._prevCustomerCode)
                        {
                            if (!string.IsNullOrEmpty(GetCustomerName(customerCode)))
                            {
                                // 得意先名取得
                                this.tEdit_CustomerName.DataText = GetCustomerName(customerCode);
                                this._prevCustomerCode = customerCode;

                                if ((int)this.tComboEditor_TargetContrastCd.Value == 30)
                                {
                                    // 検索
                                    status = SearchProc();
                                    //this._searchFlg = false;  // DEL K2011/07/05
                                    if (this.tNedit_CampaignCode.Text.ToString() != "")
                                    {
                                        GetCampaignStList();

                                        // キャンペーンコード取得
                                        int campaignCode = this.tNedit_CampaignCode.GetInt();
                                        if (string.IsNullOrEmpty(GetCampaignName(campaignCode)))
                                        {
                                            // 該当なし
                                            this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "キャンペーンコードが存在しません。", -1);
                                            e.NextCtrl = this.tNedit_CampaignCode;
                                            this.tNedit_CampaignCode.Text = "";
                                            this.tEdit_CampaignName.Clear();
                                            this.tNedit_YearFrm.Clear();
                                            this.tNedit_MonthFrm.Clear();
                                            this.tNedit_DayFrm.Clear();
                                            this.tNedit_YearTo.Clear();
                                            this.tNedit_MonthTo.Clear();
                                            this.tNedit_DayTo.Clear();
                                            this._prevCampaignCode = 0;
                                            this.SettingGuideButtonToolEnabled(this.ActiveControl);
                                            return;
                                        }

                                        int campainCapare = Convert.ToInt32(this.tNedit_CampaignCode.Text.ToString());
                                     
                                        if (this._campaignStDic[campainCapare].LogicalDeleteCode == 1 && status != 0)
                                        {
                                            this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "マスタに登録されていません。", -1);
                                            e.NextCtrl = this.tNedit_CampaignCode;
                                            this.tNedit_CampaignCode.Text = "";
                                            this.tEdit_CampaignName.Clear();
                                            this.tNedit_YearFrm.Clear();
                                            this.tNedit_MonthFrm.Clear();
                                            this.tNedit_DayFrm.Clear();
                                            this.tNedit_YearTo.Clear();
                                            this.tNedit_MonthTo.Clear();
                                            this.tNedit_DayTo.Clear();
                                            this._prevCampaignCode = 0;
                                            this.SettingGuideButtonToolEnabled(this.ActiveControl);
                                            return;
                                        }
                                    }
                                }
                                // ----- ADD K2011/07/05 ------- >>>>>>>>>
                                else
                                {
                                    if (CheckSaveConfirm() == false)
                                    {
                                        this._prevCustomerCode = customerCode;
                                    }
                                    else
                                    {
                                        // 検索
                                        status = SearchProc();
                                        if (status != 0)
                                        {
                                            ClearGrid();
                                            this._prevCustomerCode = customerCode;
                                        }
                                        else
                                        {
                                            this._prevCustomerCode = customerCode;
                                        }
                                    }
                                }
                                // ----- ADD K2011/07/05 ------- <<<<<<<<<


                            }
                            else
                            {
                                // 該当なし
                                this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "マスタに登録されていません。", -1);
                                e.NextCtrl = e.PrevCtrl;
                                this.tNedit_CustomerCode.SetInt(this._prevCustomerCode);
                                this.tEdit_CustomerName.DataText = GetCustomerName(this._prevCustomerCode);
                                return;
                            }

                            // ----- DEL K2011/07/05 ------- >>>>>>>>>
                            //if (CheckSaveConfirm() == false)
                            //{
                            //    this._prevCustomerCode = customerCode;
                            //}
                            //else
                            //{
                            //    if (this._searchFlg)
                            //    {
                            //        DialogResult result = ShowMessageBox(emErrorLevel.ERR_LEVEL_SAVECONFIRM,
                            //                                            "",
                            //                                            0,
                            //                                            MessageBoxButtons.YesNoCancel,
                            //                                            MessageBoxDefaultButton.Button2);
                            //        switch (result)
                            //        {
                            //            case DialogResult.Yes:
                            //                {
                            //                    // 保存処理
                            //                    status = SaveProc();
                            //                    if (status != 0)
                            //                    {
                            //                        this._prevCustomerCode = customerCode;
                            //                        return;
                            //                    }

                            //                    break;
                            //                }
                            //            case DialogResult.No:
                            //                {
                            //                    break;
                            //                }
                            //            case DialogResult.Cancel:
                            //                {
                            //                    this.tNedit_CustomerCode.SetInt(this._prevCustomerCode);
                            //                    this.tEdit_CustomerName.DataText = GetCustomerName(this._prevCustomerCode);
                            //                    return;
                            //                }
                            //        }
                            //    }

                            //    // 検索
                            //    status = SearchProc();
                            //    if (status != 0)
                            //    {
                            //        ClearGrid();
                            //        this._prevCustomerCode = customerCode;
                            //    }
                            //    else
                            //    {
                            //        this._prevCustomerCode = customerCode;
                            //    }
                            //}
                            // ----- DEL K2011/07/05 ------- <<<<<<<<<
                        }

                        // フォーカス設定
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                if (this.tEdit_CustomerName.DataText.Trim() != "")
                                {
                                    Control nextControl;
                                    GetNextControl(this.tNedit_CustomerCode, out nextControl);
                                    e.NextCtrl = nextControl;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab)
                            {
                                if (this.tEdit_SectionName.DataText.Trim() != "")
                                {
                                    e.NextCtrl = this.tEdit_SectionCode;
                                    break;
                                }
                            }
                        }
                        break;
                    }
                case "tEdit_EmployeeCode":
                    {
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Down)
                            {
                                if ((int)this.tComboEditor_TargetContrastCd.Value == 221
                                    || (int)this.tComboEditor_TargetContrastCd.Value == 222
                                    || (int)this.tComboEditor_TargetContrastCd.Value == 223)
                                {
                                    e.NextCtrl = null;
                                    break;
                                }
                            }
                        }

                        if (this.tEdit_EmployeeCode.DataText.Trim() == "")
                        {
                            this.tEdit_EmployeeName.Clear();
                            ClearGrid();    // ADD K2011/07/05
                            this._prevEmployeeCode = "";
                            break;
                        }

                        // 従業員コード取得
                        string employeeCode = this.tEdit_EmployeeCode.DataText.Trim().PadLeft(4, '0');

                        if (employeeCode != this._prevEmployeeCode)
                        {
                            if (!string.IsNullOrEmpty(GetEmployeeName(employeeCode)))
                            {
                                // 従業員名取得
                                this.tEdit_EmployeeName.DataText = GetEmployeeName(employeeCode);
                                this._prevEmployeeCode = employeeCode;


                                if ((int)this.tComboEditor_TargetContrastCd.Value == 221
                                    || (int)this.tComboEditor_TargetContrastCd.Value == 222
                                    || (int)this.tComboEditor_TargetContrastCd.Value == 223)
                                {
                                    // キャンペーンコード取得
                                    int campaignCode = this.tNedit_CampaignCode.GetInt();
                                    if (string.IsNullOrEmpty(GetCampaignName(campaignCode)))
                                    {
                                        // 該当なし
                                        this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "キャンペーンコードが存在しません。", -1);
                                        e.NextCtrl = this.tNedit_CampaignCode;
                                        this.tNedit_CampaignCode.Text = "";
                                        this.tEdit_CampaignName.Clear();
                                        this.tNedit_YearFrm.Clear();
                                        this.tNedit_MonthFrm.Clear();
                                        this.tNedit_DayFrm.Clear();
                                        this.tNedit_YearTo.Clear();
                                        this.tNedit_MonthTo.Clear();
                                        this.tNedit_DayTo.Clear();
                                        this._prevCampaignCode = 0;
                                        return;
                                    }

                                    // 検索
                                    status = SearchProc();
                                    //this._searchFlg = false; // DEL K2011/07/05
                                    if (this.tNedit_CampaignCode.Text.ToString() != "")
                                    {
                                        GetCampaignStList();

                                        // キャンペーンコード取得
                                        campaignCode = this.tNedit_CampaignCode.GetInt();
                                        if (string.IsNullOrEmpty(GetCampaignName(campaignCode)))
                                        {
                                            // 該当なし
                                            this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "キャンペーンコードが存在しません。", -1);
                                            e.NextCtrl = this.tNedit_CampaignCode;
                                            this.tNedit_CampaignCode.Text = "";
                                            this.tEdit_CampaignName.Clear();
                                            this.tNedit_YearFrm.Clear();
                                            this.tNedit_MonthFrm.Clear();
                                            this.tNedit_DayFrm.Clear();
                                            this.tNedit_YearTo.Clear();
                                            this.tNedit_MonthTo.Clear();
                                            this.tNedit_DayTo.Clear();
                                            this._prevCampaignCode = 0;
                                            this.SettingGuideButtonToolEnabled(this.ActiveControl);
                                            return;
                                        }
                                        int campainCapare = Convert.ToInt32(this.tNedit_CampaignCode.Text.ToString());
                                       
                                        if (this._campaignStDic[campainCapare].LogicalDeleteCode == 1 && status != 0)
                                        {
                                            this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "マスタに登録されていません。", -1);
                                            e.NextCtrl = this.tNedit_CampaignCode;
                                            this.tNedit_CampaignCode.Text = "";
                                            this.tEdit_CampaignName.Clear();
                                            this.tNedit_YearFrm.Clear();
                                            this.tNedit_MonthFrm.Clear();
                                            this.tNedit_DayFrm.Clear();
                                            this.tNedit_YearTo.Clear();
                                            this.tNedit_MonthTo.Clear();
                                            this.tNedit_DayTo.Clear();
                                            this._prevCampaignCode = 0;
                                            this.SettingGuideButtonToolEnabled(this.ActiveControl);
                                            return;
                                        }
                                    }
                                }
                                // ----- ADD K2011/07/05 ------- >>>>>>>>>
                                else
                                {
                                    if (CheckSaveConfirm() == false)
                                    {
                                        this._prevEmployeeCode = employeeCode;
                                    }
                                    else
                                    {
                                        // 検索
                                        status = SearchProc();
                                        if (status != 0)
                                        {
                                            ClearGrid();
                                            this._prevEmployeeCode = employeeCode;
                                        }
                                        else
                                        {
                                            this._prevEmployeeCode = employeeCode;
                                        }
                                    }
                                }
                                // ----- ADD K2011/07/05 ------- <<<<<<<<<


                            }
                            else
                            {
                                // 該当なし
                                this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "マスタに登録されていません。", -1);
                                e.NextCtrl = e.PrevCtrl;
                                this.tEdit_EmployeeCode.DataText = this._prevEmployeeCode;
                                this.tEdit_EmployeeName.DataText = GetEmployeeName(this._prevEmployeeCode);
                                return;
                            }

                            // ----- DEL K2011/07/05 ------- >>>>>>>>>
                            //if (CheckSaveConfirm() == false)
                            //{
                            //    this._prevEmployeeCode = employeeCode;
                            //}
                            //else
                            //{
                            //    if (this._searchFlg)
                            //    {
                            //        DialogResult result = ShowMessageBox(emErrorLevel.ERR_LEVEL_SAVECONFIRM,
                            //                                            "",
                            //                                            0,
                            //                                            MessageBoxButtons.YesNoCancel,
                            //                                            MessageBoxDefaultButton.Button2);
                            //        switch (result)
                            //        {
                            //            case DialogResult.Yes:
                            //                {
                            //                    // 保存処理
                            //                    status = SaveProc();
                            //                    if (status != 0)
                            //                    {
                            //                        this._prevEmployeeCode = employeeCode;
                            //                        return;
                            //                    }

                            //                    break;
                            //                }
                            //            case DialogResult.No:
                            //                {
                            //                    break;
                            //                }
                            //            case DialogResult.Cancel:
                            //                {
                            //                    this.tEdit_EmployeeCode.DataText = this._prevEmployeeCode;
                            //                    this.tEdit_EmployeeName.DataText = GetEmployeeName(this._prevEmployeeCode);
                            //                    return;
                            //                }
                            //        }
                            //    }

                            //    // 検索
                            //    status = SearchProc();
                            //    if (status != 0)
                            //    {
                            //        ClearGrid();
                            //        this._prevEmployeeCode = employeeCode;
                            //    }
                            //    else
                            //    {
                            //        this._prevEmployeeCode = employeeCode;
                            //    }
                            //}
                            // ----- DEL K2011/07/05 ------- <<<<<<<<<
                        }

                        // フォーカス設定
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                if (this.tEdit_EmployeeName.DataText.Trim() != "")
                                {
                                    Control nextControl;
                                    GetNextControl(this.tEdit_EmployeeCode, out nextControl);
                                    e.NextCtrl = nextControl;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab)
                            {
                                if (this.tEdit_SectionName.DataText.Trim() != "")
                                {
                                    e.NextCtrl = this.tEdit_SectionCode;
                                    break;
                                }
                            }
                        }
                        break;
                    }
                case "tNedit_SalesAreaCode":
                    {
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Down)
                            {
                                if ((int)this.tComboEditor_TargetContrastCd.Value == 32)
                                {
                                    e.NextCtrl = null;
                                    break;
                                }
                            }
                        }

                        if (this.tNedit_SalesAreaCode.GetInt() == 0)
                        {
                            this.tEdit_SalesAreaName.Clear();
                            this.tNedit_SalesAreaCode.Clear();
                            ClearGrid();    // ADD K2011/07/05
                            this._prevSalesAreaCode = 0;
                            break;
                        }

                        // 地区コード取得
                        int salesAreaCode = this.tNedit_SalesAreaCode.GetInt();

                        if (salesAreaCode != this._prevSalesAreaCode)
                        {
                            if (!string.IsNullOrEmpty(GetSalesAreaName(salesAreaCode)))
                            {
                                // 地区名取得
                                this.tEdit_SalesAreaName.DataText = GetSalesAreaName(salesAreaCode);
                                this._prevSalesAreaCode = salesAreaCode;

                                if ((int)this.tComboEditor_TargetContrastCd.Value == 32)
                                {
                                    // 検索
                                    status = SearchProc();
                                    //this._searchFlg = false;  // DEL K2011/07/05
                                    if (this.tNedit_CampaignCode.Text.ToString() != "")
                                    {
                                        GetCampaignStList();

                                        // キャンペーンコード取得
                                        int campaignCode = this.tNedit_CampaignCode.GetInt();
                                        if (string.IsNullOrEmpty(GetCampaignName(campaignCode)))
                                        {
                                            // 該当なし
                                            this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "キャンペーンコードが存在しません。", -1);
                                            e.NextCtrl = this.tNedit_CampaignCode;
                                            this.tNedit_CampaignCode.Text = "";
                                            this.tEdit_CampaignName.Clear();
                                            this.tNedit_YearFrm.Clear();
                                            this.tNedit_MonthFrm.Clear();
                                            this.tNedit_DayFrm.Clear();
                                            this.tNedit_YearTo.Clear();
                                            this.tNedit_MonthTo.Clear();
                                            this.tNedit_DayTo.Clear();
                                            this._prevCampaignCode = 0;
                                            this.SettingGuideButtonToolEnabled(this.ActiveControl);
                                            return;
                                        }

                                        int campainCapare = Convert.ToInt32(this.tNedit_CampaignCode.Text.ToString());
                                   
                                        if (this._campaignStDic[campainCapare].LogicalDeleteCode == 1 && status != 0)
                                        {
                                            this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "マスタに登録されていません。", -1);
                                            e.NextCtrl = this.tNedit_CampaignCode;
                                            this.tNedit_CampaignCode.Text = "";
                                            this.tEdit_CampaignName.Clear();
                                            this.tNedit_YearFrm.Clear();
                                            this.tNedit_MonthFrm.Clear();
                                            this.tNedit_DayFrm.Clear();
                                            this.tNedit_YearTo.Clear();
                                            this.tNedit_MonthTo.Clear();
                                            this.tNedit_DayTo.Clear();
                                            this._prevCampaignCode = 0;
                                            this.SettingGuideButtonToolEnabled(this.ActiveControl);
                                            return;
                                        }
                                    }
                                }
                                // ----- ADD K2011/07/05 ------- >>>>>>>>>
                                else
                                {
                                    if (CheckSaveConfirm() == false)
                                    {
                                        this._prevSalesAreaCode = salesAreaCode;
                                    }
                                    else
                                    {
                                        // 検索
                                        status = SearchProc();
                                        if (status != 0)
                                        {
                                            ClearGrid();
                                            this._prevSalesAreaCode = salesAreaCode;
                                        }
                                        else
                                        {
                                            this._prevSalesAreaCode = salesAreaCode;
                                        }
                                    }
                                }
                                // ----- ADD K2011/07/05 ------- <<<<<<<<<
                            }
                            else
                            {
                                // 該当なし
                                this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "マスタに登録されていません。", -1);
                                e.NextCtrl = e.PrevCtrl;
                                this.tNedit_SalesAreaCode.SetInt(this._prevSalesAreaCode);
                                this.tEdit_SalesAreaName.DataText = GetSalesAreaName(this._prevSalesAreaCode);
                                return;
                            }

                            // ----- DEL K2011/07/05 ------- >>>>>>>>>
                            //if (CheckSaveConfirm() == false)
                            //{
                            //    this._prevSalesAreaCode = salesAreaCode;
                            //}
                            //else
                            //{
                            //    if (this._searchFlg)
                            //    {
                            //        DialogResult result = ShowMessageBox(emErrorLevel.ERR_LEVEL_SAVECONFIRM,
                            //                                            "",
                            //                                            0,
                            //                                            MessageBoxButtons.YesNoCancel,
                            //                                            MessageBoxDefaultButton.Button2);
                            //        switch (result)
                            //        {
                            //            case DialogResult.Yes:
                            //                {
                            //                    // 保存処理
                            //                    status = SaveProc();
                            //                    if (status != 0)
                            //                    {
                            //                        this._prevSalesAreaCode = salesAreaCode;
                            //                        return;
                            //                    }

                            //                    break;
                            //                }
                            //            case DialogResult.No:
                            //                {
                            //                    break;
                            //                }
                            //            case DialogResult.Cancel:
                            //                {
                            //                    this.tNedit_SalesAreaCode.SetInt(this._prevSalesAreaCode);
                            //                    this.tEdit_SalesAreaName.DataText = GetSalesAreaName(this._prevSalesAreaCode);
                            //                    return;
                            //                }
                            //        }
                            //    }

                            //    // 検索
                            //    status = SearchProc();
                            //    if (status != 0)
                            //    {
                            //        ClearGrid();
                            //        this._prevSalesAreaCode = salesAreaCode;
                            //    }
                            //    else
                            //    {
                            //        this._prevSalesAreaCode = salesAreaCode;
                            //    }
                            //}
                            // ----- DEL K2011/07/05 ------- <<<<<<<<<
                        }

                        // フォーカス設定
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                if (this.tEdit_SalesAreaName.DataText.Trim() != "")
                                {
                                    Control nextControl;
                                    GetNextControl(this.tNedit_SalesAreaCode, out nextControl);
                                    e.NextCtrl = nextControl;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab)
                            {
                                if (this.tEdit_SectionName.DataText.Trim() != "")
                                {
                                    e.NextCtrl = this.tEdit_SectionCode;
                                    break;
                                }
                            }
                        }
                        break;
                    }
                case "tNedit_BLGloupCode":
                    {
                        if (this.tNedit_BLGloupCode.GetInt() == 0)
                        {
                            this.tEdit_GroupName.Clear();
                            this.tNedit_BLGloupCode.Clear();
                            ClearGrid();    // ADD K2011/07/05
                            this._prevBLGroupCode = 0;
                            break;
                        }

                        // ｸﾞﾙｰﾌﾟｺｰﾄﾞ取得
                        int bLGloupCode = this.tNedit_BLGloupCode.GetInt();

                        if (bLGloupCode != this._prevBLGroupCode)
                        {
                            if (!string.IsNullOrEmpty(GetBLGroupName(bLGloupCode)))
                            {
                                // ｸﾞﾙｰﾌﾟｺｰﾄﾞ名取得
                                this.tEdit_GroupName.DataText = GetBLGroupName(bLGloupCode);
                                this._prevBLGroupCode = bLGloupCode;

                                if ((int)this.tComboEditor_TargetContrastCd.Value == 50)
                                {
                                    // 検索
                                    status = SearchProc();
                                    //this._searchFlg = false; // DEL K2011/07/05
                                    if (this.tNedit_CampaignCode.Text.ToString() != "")
                                    {
                                        GetCampaignStList();

                                        // キャンペーンコード取得
                                        int campaignCode = this.tNedit_CampaignCode.GetInt();
                                        if (string.IsNullOrEmpty(GetCampaignName(campaignCode)))
                                        {
                                            // 該当なし
                                            this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "キャンペーンコードが存在しません。", -1);
                                            e.NextCtrl = this.tNedit_CampaignCode;
                                            this.tNedit_CampaignCode.Text = "";
                                            this.tEdit_CampaignName.Clear();
                                            this.tNedit_YearFrm.Clear();
                                            this.tNedit_MonthFrm.Clear();
                                            this.tNedit_DayFrm.Clear();
                                            this.tNedit_YearTo.Clear();
                                            this.tNedit_MonthTo.Clear();
                                            this.tNedit_DayTo.Clear();
                                            this._prevCampaignCode = 0;
                                            this.SettingGuideButtonToolEnabled(this.ActiveControl);
                                            return;
                                        }

                                        int campainCapare = Convert.ToInt32(this.tNedit_CampaignCode.Text.ToString());
                                        
                                        if (this._campaignStDic[campainCapare].LogicalDeleteCode == 1 && status != 0)
                                        {
                                            this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "マスタに登録されていません。", -1);
                                            e.NextCtrl = this.tNedit_CampaignCode;
                                            this.tNedit_CampaignCode.Text = "";
                                            this.tEdit_CampaignName.Clear();
                                            this.tNedit_YearFrm.Clear();
                                            this.tNedit_MonthFrm.Clear();
                                            this.tNedit_DayFrm.Clear();
                                            this.tNedit_YearTo.Clear();
                                            this.tNedit_MonthTo.Clear();
                                            this.tNedit_DayTo.Clear();
                                            this._prevCampaignCode = 0;
                                            this.SettingGuideButtonToolEnabled(this.ActiveControl);
                                            return;
                                        }
                                    }
                                }
                                // ----- ADD K2011/07/05 ------- >>>>>>>>>
                                else
                                {
                                    if (CheckSaveConfirm() == false)
                                    {
                                        this._prevBLGroupCode = bLGloupCode;
                                    }
                                    else
                                    {
                                        // 検索
                                        status = SearchProc();
                                        if (status != 0)
                                        {
                                            ClearGrid();
                                            this._prevBLGroupCode = bLGloupCode;
                                        }
                                        else
                                        {
                                            this._prevBLGroupCode = bLGloupCode;
                                        }
                                    }
                                }
                                // ----- ADD K2011/07/05 ------- <<<<<<<<<
                            }
                            else
                            {
                                // 該当なし
                                this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "マスタに登録されていません。", -1);
                                e.NextCtrl = e.PrevCtrl;
                                this.tNedit_BLGloupCode.SetInt(this._prevBLGroupCode);
                                this.tEdit_GroupName.DataText = GetBLGroupName(this._prevBLGroupCode);
                                return;
                            }

                            // ----- DEL K2011/07/05 ------- >>>>>>>>>
                            //if (CheckSaveConfirm() == false)
                            //{
                            //    this._prevBLGroupCode = bLGloupCode;
                            //}
                            //else
                            //{
                            //    if (this._searchFlg)
                            //    {
                            //        DialogResult result = ShowMessageBox(emErrorLevel.ERR_LEVEL_SAVECONFIRM,
                            //                                            "",
                            //                                            0,
                            //                                            MessageBoxButtons.YesNoCancel,
                            //                                            MessageBoxDefaultButton.Button2);
                            //        switch (result)
                            //        {
                            //            case DialogResult.Yes:
                            //                {
                            //                    // 保存処理
                            //                    status = SaveProc();
                            //                    if (status != 0)
                            //                    {
                            //                        this._prevBLGroupCode = bLGloupCode;
                            //                        return;
                            //                    }

                            //                    break;
                            //                }
                            //            case DialogResult.No:
                            //                {
                            //                    break;
                            //                }
                            //            case DialogResult.Cancel:
                            //                {
                            //                    this.tNedit_BLGloupCode.SetInt(this._prevBLGroupCode);
                            //                    this.tEdit_GroupName.DataText = GetBLGroupName(this._prevBLGroupCode);
                            //                    return;
                            //                }
                            //        }
                            //    }

                            //    // 検索
                            //    status = SearchProc();
                            //    if (status != 0)
                            //    {
                            //        ClearGrid();
                            //        this._prevBLGroupCode = bLGloupCode;
                            //    }
                            //    else
                            //    {
                            //        this._prevBLGroupCode = bLGloupCode;
                            //    }
                            //}

                            // ----- DEL K2011/07/05 ------- <<<<<<<<<
                        }

                        // フォーカス設定
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                if (this.tEdit_GroupName.DataText.Trim() != "")
                                {
                                    Control nextControl;
                                    GetNextControl(this.tNedit_BLGloupCode, out nextControl);
                                    e.NextCtrl = nextControl;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab)
                            {
                                if (this.tEdit_SectionName.DataText.Trim() != "")
                                {
                                    e.NextCtrl = this.tEdit_SectionCode;
                                    break;
                                }
                            }
                        }
                        break;
                    }
                // BLｺｰﾄﾞ
                case "tNedit_BLGoodsCode":
                    {
                        if (this.tNedit_BLGoodsCode.GetInt() == 0)
                        {
                            this.tEdit_BLName.Clear();
                            this.tNedit_BLGoodsCode.Clear();
                            ClearGrid();    // ADD K2011/07/05
                            this._prevBLGoodsCode = 0;
                            break;
                        }

                        // BLｺｰﾄﾞ取得
                        int bLGoodsCode = this.tNedit_BLGoodsCode.GetInt();

                        if (bLGoodsCode != this._prevBLGoodsCode)
                        {
                            if (!string.IsNullOrEmpty(GetBLGoodsName(bLGoodsCode)))
                            {
                                // BLｺｰﾄﾞ名取得
                                this.tEdit_BLName.DataText = GetBLGoodsName(bLGoodsCode);
                                this._prevBLGoodsCode = bLGoodsCode;

                                if ((int)this.tComboEditor_TargetContrastCd.Value == 60)
                                {
                                    // 検索
                                    status = SearchProc();
                                    //this._searchFlg = false; // DEL K2011/07/05
                                    if (this.tNedit_CampaignCode.Text.ToString() != "")
                                    {
                                        GetCampaignStList();

                                        // キャンペーンコード取得
                                        int campaignCode = this.tNedit_CampaignCode.GetInt();
                                        if (string.IsNullOrEmpty(GetCampaignName(campaignCode)))
                                        {
                                            // 該当なし
                                            this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "キャンペーンコードが存在しません。", -1);
                                            e.NextCtrl = this.tNedit_CampaignCode;
                                            this.tNedit_CampaignCode.Text = "";
                                            this.tEdit_CampaignName.Clear();
                                            this.tNedit_YearFrm.Clear();
                                            this.tNedit_MonthFrm.Clear();
                                            this.tNedit_DayFrm.Clear();
                                            this.tNedit_YearTo.Clear();
                                            this.tNedit_MonthTo.Clear();
                                            this.tNedit_DayTo.Clear();
                                            this._prevCampaignCode = 0;
                                            this.SettingGuideButtonToolEnabled(this.ActiveControl);
                                            return;
                                        }

                                        int campainCapare = Convert.ToInt32(this.tNedit_CampaignCode.Text.ToString());
                                       
                                        if (this._campaignStDic[campainCapare].LogicalDeleteCode == 1 && status != 0)
                                        {
                                            this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "マスタに登録されていません。", -1);
                                            e.NextCtrl = this.tNedit_CampaignCode;
                                            this.tNedit_CampaignCode.Text = "";
                                            this.tEdit_CampaignName.Clear();
                                            this.tNedit_YearFrm.Clear();
                                            this.tNedit_MonthFrm.Clear();
                                            this.tNedit_DayFrm.Clear();
                                            this.tNedit_YearTo.Clear();
                                            this.tNedit_MonthTo.Clear();
                                            this.tNedit_DayTo.Clear();
                                            this._prevCampaignCode = 0;
                                            this.SettingGuideButtonToolEnabled(this.ActiveControl);
                                            return;
                                        }
                                    }
                                }
                                // ----- ADD K2011/07/05 ------- >>>>>>>>>
                                else
                                {
                                    if (CheckSaveConfirm() == false)
                                    {
                                        this._prevBLGoodsCode = bLGoodsCode;
                                    }
                                    else
                                    {
                                        // 検索
                                        status = SearchProc();
                                        if (status != 0)
                                        {
                                            ClearGrid();
                                            this._prevBLGoodsCode = bLGoodsCode;
                                        }
                                        else
                                        {
                                            this._prevBLGoodsCode = bLGoodsCode;
                                        }
                                    }
                                }
                                // ----- ADD K2011/07/05 ------- <<<<<<<<<
                            }
                            else
                            {
                                // 該当なし
                                this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "マスタに登録されていません。", -1);
                                e.NextCtrl = e.PrevCtrl;
                                this.tNedit_BLGoodsCode.SetInt(this._prevBLGoodsCode);
                                this.tEdit_BLName.DataText = GetBLGoodsName(this._prevBLGoodsCode);
                                return;
                            }

                            // ----- DEL K2011/07/05 ------- >>>>>>>>>
                            //if (CheckSaveConfirm() == false)
                            //{
                            //    this._prevBLGoodsCode = bLGoodsCode;
                            //}
                            //else
                            //{
                            //    if (this._searchFlg)
                            //    {
                            //        DialogResult result = ShowMessageBox(emErrorLevel.ERR_LEVEL_SAVECONFIRM,
                            //                                            "",
                            //                                            0,
                            //                                            MessageBoxButtons.YesNoCancel,
                            //                                            MessageBoxDefaultButton.Button2);
                            //        switch (result)
                            //        {
                            //            case DialogResult.Yes:
                            //                {
                            //                    // 保存処理
                            //                    status = SaveProc();
                            //                    if (status != 0)
                            //                    {
                            //                        this._prevBLGoodsCode = bLGoodsCode;
                            //                        return;
                            //                    }

                            //                    break;
                            //                }
                            //            case DialogResult.No:
                            //                {
                            //                    break;
                            //                }
                            //            case DialogResult.Cancel:
                            //                {
                            //                    this.tNedit_BLGoodsCode.SetInt(this._prevBLGroupCode);
                            //                    this.tEdit_BLName.DataText = GetBLGoodsName(this._prevBLGoodsCode);
                            //                    return;
                            //                }
                            //        }
                            //    }

                            //    // 検索
                            //    status = SearchProc();
                            //    if (status != 0)
                            //    {
                            //        ClearGrid();
                            //        this._prevBLGoodsCode = bLGoodsCode;
                            //    }
                            //    else
                            //    {
                            //        this._prevBLGoodsCode = bLGoodsCode;
                            //    }
                            //}
                            // ----- DEL K2011/07/05 ------- <<<<<<<<<
                        }

                        // フォーカス設定
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                if (this.tEdit_BLName.DataText.Trim() != "")
                                {
                                    Control nextControl;
                                    GetNextControl(this.tNedit_BLGoodsCode, out nextControl);
                                    e.NextCtrl = nextControl;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab)
                            {
                                if (this.tEdit_SectionName.DataText.Trim() != "")
                                {
                                    e.NextCtrl = this.tEdit_SectionCode;
                                    break;
                                }
                            }
                        }
                        break;
                    }
                case "SectionGuide_Button":
                    {
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Down)
                            {
                                if ((int)this.tComboEditor_TargetContrastCd.Value == 10)
                                {
                                    e.NextCtrl = null;
                                }
                            }
                            else if (e.Key == Keys.Right)
                            {
                                if ((int)this.tComboEditor_TargetContrastCd.Value == 10 && this.tEdit_SectionCode.Text != "")
                                {
                                    // 検索
                                    status = SearchProc();
                                    //this._searchFlg = false;  // DEL K2011/07/05
                                    if (this.tNedit_CampaignCode.Text.ToString() != "")
                                    {
                                        GetCampaignStList();

                                        // キャンペーンコード取得
                                        int campaignCode = this.tNedit_CampaignCode.GetInt();
                                        if (string.IsNullOrEmpty(GetCampaignName(campaignCode)))
                                        {
                                            // 該当なし
                                            this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "キャンペーンコードが存在しません。", -1);
                                            e.NextCtrl = this.tNedit_CampaignCode;
                                            this.tNedit_CampaignCode.Text = "";
                                            this.tEdit_CampaignName.Clear();
                                            this.tNedit_YearFrm.Clear();
                                            this.tNedit_MonthFrm.Clear();
                                            this.tNedit_DayFrm.Clear();
                                            this.tNedit_YearTo.Clear();
                                            this.tNedit_MonthTo.Clear();
                                            this.tNedit_DayTo.Clear();
                                            this._prevCampaignCode = 0;
                                            this.SettingGuideButtonToolEnabled(this.ActiveControl);
                                            return;
                                        }

                                        int campainCapare = Convert.ToInt32(this.tNedit_CampaignCode.Text.ToString());
                                        
                                        if (this._campaignStDic[campainCapare].LogicalDeleteCode == 1 && status != 0)
                                        {
                                            this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "マスタに登録されていません。", -1);
                                            e.NextCtrl = this.tNedit_CampaignCode;
                                            this.tNedit_CampaignCode.Text = "";
                                            this.tEdit_CampaignName.Clear();
                                            this.tNedit_YearFrm.Clear();
                                            this.tNedit_MonthFrm.Clear();
                                            this.tNedit_DayFrm.Clear();
                                            this.tNedit_YearTo.Clear();
                                            this.tNedit_MonthTo.Clear();
                                            this.tNedit_DayTo.Clear();
                                            this._prevCampaignCode = 0;
                                            this.SettingGuideButtonToolEnabled(this.ActiveControl);
                                            return;
                                        }
                                    }
                                }
                                else
                                {
                                    e.NextCtrl = this.tNedit_SalesTargetSale;
                                }

                                return;
                            }
                        }
                        break;
                    }
                case "CustomerGuide_Button":
                case "EmployeeGuide_Button":
                case "SalesAreaGuide_Button":
                case "GroupGuide_Button":
                case "BLGuide_Button":
                case "SalesCodeGuide_Button":
                    {
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Right)
                            {
                                if (((int)this.tComboEditor_TargetContrastCd.Value == 30 && this.tEdit_SectionCode.Text != "" && this.tNedit_CustomerCode.Text != "")
                                    || ((int)this.tComboEditor_TargetContrastCd.Value == 221 && this.tEdit_SectionCode.Text != "" && this.tEdit_EmployeeName.Text != "")
                                    || ((int)this.tComboEditor_TargetContrastCd.Value == 222 && this.tEdit_SectionCode.Text != "" && this.tEdit_EmployeeName.Text != "")
                                    || ((int)this.tComboEditor_TargetContrastCd.Value == 223 && this.tEdit_SectionCode.Text != "" && this.tEdit_EmployeeName.Text != "")
                                    || ((int)this.tComboEditor_TargetContrastCd.Value == 32 && this.tEdit_SectionCode.Text != "" && this.tNedit_SalesAreaCode.Text != "")
                                    || ((int)this.tComboEditor_TargetContrastCd.Value == 50 && this.tEdit_SectionCode.Text != "" && this.tNedit_BLGloupCode.Text != "")
                                    || ((int)this.tComboEditor_TargetContrastCd.Value == 60 && this.tEdit_SectionCode.Text != "" && this.tNedit_BLGoodsCode.Text != "")
                                    || ((int)this.tComboEditor_TargetContrastCd.Value == 44 && this.tEdit_SectionCode.Text != "" && this.tNedit_SalesCode.Text != ""))
                                {
                                    // 検索
                                    status = SearchProc();
                                    //this._searchFlg = false;  // DEL K2011/07/05
                                    if (this.tNedit_CampaignCode.Text.ToString() != "")
                                    {
                                        GetCampaignStList();

                                        // キャンペーンコード取得
                                        int campaignCode = this.tNedit_CampaignCode.GetInt();
                                        if (string.IsNullOrEmpty(GetCampaignName(campaignCode)))
                                        {
                                            // 該当なし
                                            this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "キャンペーンコードが存在しません。", -1);
                                            e.NextCtrl = this.tNedit_CampaignCode;
                                            this.tNedit_CampaignCode.Text = "";
                                            this.tEdit_CampaignName.Clear();
                                            this.tNedit_YearFrm.Clear();
                                            this.tNedit_MonthFrm.Clear();
                                            this.tNedit_DayFrm.Clear();
                                            this.tNedit_YearTo.Clear();
                                            this.tNedit_MonthTo.Clear();
                                            this.tNedit_DayTo.Clear();
                                            this._prevCampaignCode = 0;
                                            this.SettingGuideButtonToolEnabled(this.ActiveControl);
                                            return;
                                        }

                                        int campainCapare = Convert.ToInt32(this.tNedit_CampaignCode.Text.ToString());
                                     
                                        if (this._campaignStDic[campainCapare].LogicalDeleteCode == 1 && status != 0)
                                        {
                                            this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "マスタに登録されていません。", -1);
                                            e.NextCtrl = this.tNedit_CampaignCode;
                                            this.tNedit_CampaignCode.Text = "";
                                            this.tEdit_CampaignName.Clear();
                                            this.tNedit_YearFrm.Clear();
                                            this.tNedit_MonthFrm.Clear();
                                            this.tNedit_DayFrm.Clear();
                                            this.tNedit_YearTo.Clear();
                                            this.tNedit_MonthTo.Clear();
                                            this.tNedit_DayTo.Clear();
                                            this._prevCampaignCode = 0;
                                            this.SettingGuideButtonToolEnabled(this.ActiveControl);
                                            return;
                                        }
                                    }
                                }
                                else
                                {
                                    e.NextCtrl = this.tNedit_SalesTargetSale;
                                }
                            }
                        }
                        break;
                    }
                case "tNedit_SalesCode":
                    {
                        if (tNedit_SalesCode.GetInt() == 0)
                        {
                            this.tEdit_SalesCodeName.Clear();
                            this.tNedit_SalesCode.Clear();
                            ClearGrid();    // ADD K2011/07/05
                            this._prevSalesCode = 0;
                            return;
                        }

                        // 販売区分コード取得
                        int salesCode = this.tNedit_SalesCode.GetInt();

                        if (salesCode != this._prevSalesCode)
                        {
                            if (!string.IsNullOrEmpty(GetSalesCodeName(salesCode)))
                            {
                                // 販売区分名取得
                                this.tEdit_SalesCodeName.DataText = GetSalesCodeName(salesCode);
                                this._prevSalesCode = salesCode;


                                if ((int)this.tComboEditor_TargetContrastCd.Value == 44)
                                {
                                    // 検索
                                    status = SearchProc();
                                    //this._searchFlg = false; // DEL K2011/07/05
                                    if (this.tNedit_CampaignCode.Text.ToString() != "")
                                    {
                                        GetCampaignStList();

                                        // キャンペーンコード取得
                                        int campaignCode = this.tNedit_CampaignCode.GetInt();
                                        if (string.IsNullOrEmpty(GetCampaignName(campaignCode)))
                                        {
                                            // 該当なし
                                            this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "キャンペーンコードが存在しません。", -1);
                                            e.NextCtrl = this.tNedit_CampaignCode;
                                            this.tNedit_CampaignCode.Text = "";
                                            this.tEdit_CampaignName.Clear();
                                            this.tNedit_YearFrm.Clear();
                                            this.tNedit_MonthFrm.Clear();
                                            this.tNedit_DayFrm.Clear();
                                            this.tNedit_YearTo.Clear();
                                            this.tNedit_MonthTo.Clear();
                                            this.tNedit_DayTo.Clear();
                                            this._prevCampaignCode = 0;
                                            this.SettingGuideButtonToolEnabled(this.ActiveControl);
                                            return;
                                        }

                                        int campainCapare = Convert.ToInt32(this.tNedit_CampaignCode.Text.ToString());
                                   
                                        if (this._campaignStDic[campainCapare].LogicalDeleteCode == 1 && status != 0)
                                        {
                                            this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "マスタに登録されていません。", -1);
                                            e.NextCtrl = this.tNedit_CampaignCode;
                                            this.tNedit_CampaignCode.Text = "";
                                            this.tEdit_CampaignName.Clear();
                                            this.tNedit_YearFrm.Clear();
                                            this.tNedit_MonthFrm.Clear();
                                            this.tNedit_DayFrm.Clear();
                                            this.tNedit_YearTo.Clear();
                                            this.tNedit_MonthTo.Clear();
                                            this.tNedit_DayTo.Clear();
                                            this._prevCampaignCode = 0;
                                            this.SettingGuideButtonToolEnabled(this.ActiveControl);
                                            return;
                                        }
                                    }
                                }
                                // ----- ADD K2011/07/05 ------- >>>>>>>>>
                                else
                                {
                                    if (CheckSaveConfirm() == false)
                                    {
                                        this._prevSalesCode = salesCode;
                                    }
                                    else
                                    {
                                        // 検索
                                        status = SearchProc();
                                        if (status != 0)
                                        {
                                            ClearGrid();
                                            this._prevSalesCode = salesCode;
                                        }
                                        else
                                        {
                                            this._prevSalesCode = salesCode;
                                        }
                                    }
                                }
                                // ----- ADD K2011/07/05 ------- <<<<<<<<<
                            }
                            else
                            {
                                // 該当なし
                                this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "マスタに登録されていません。", -1);
                                e.NextCtrl = e.PrevCtrl;
                                this.tNedit_SalesCode.SetInt(this._prevSalesCode);
                                this.tEdit_SalesCodeName.DataText = GetSalesCodeName(this._prevSalesCode);
                                return;
                            }

                            // ----- DEL K2011/07/05 ------- >>>>>>>>>
                            //if (CheckSaveConfirm() == false)
                            //{
                            //    this._prevSalesCode = salesCode;
                            //}
                            //else
                            //{
                            //    if (this._searchFlg)
                            //    {
                            //        DialogResult result = ShowMessageBox(emErrorLevel.ERR_LEVEL_SAVECONFIRM,
                            //                                            "",
                            //                                            0,
                            //                                            MessageBoxButtons.YesNoCancel,
                            //                                            MessageBoxDefaultButton.Button2);
                            //        switch (result)
                            //        {
                            //            case DialogResult.Yes:
                            //                {
                            //                    // 保存処理
                            //                    status = SaveProc();
                            //                    if (status != 0)
                            //                    {
                            //                        this._prevSalesCode = salesCode;
                            //                        return;
                            //                    }

                            //                    break;
                            //                }
                            //            case DialogResult.No:
                            //                {
                            //                    break;
                            //                }
                            //            case DialogResult.Cancel:
                            //                {
                            //                    this.tNedit_SalesCode.SetInt(this._prevSalesCode);
                            //                    this.tEdit_SalesCodeName.DataText = GetSalesCodeName(this._prevSalesCode);
                            //                    return;
                            //                }
                            //        }
                            //    }

                            //    // 検索
                            //    status = SearchProc();
                            //    if (status != 0)
                            //    {
                            //        ClearGrid();
                            //        this._prevSalesCode = salesCode;
                            //    }
                            //    else
                            //    {
                            //        this._prevSalesCode = salesCode;
                            //    }
                            //}
                            // ----- DEL K2011/07/05 ------- <<<<<<<<<
                        }

                        // フォーカス設定
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                if (this.tEdit_SalesCodeName.DataText.Trim() != "")
                                {
                                    Control nextControl;
                                    GetNextControl(this.tNedit_SalesCode, out nextControl);
                                    e.NextCtrl = nextControl;
                                    return;
                                }
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab)
                            {
                                if (this.tEdit_SectionName.DataText.Trim() != "")
                                {
                                    e.NextCtrl = this.tEdit_SectionCode;
                                    return;
                                }
                            }
                        }
                        break;
                    }
                case "tNedit_SalesTargetSale":
                    {
                        ChangeValue(this.tNedit_SalesTargetSale,10);
                        // フォーカス設定
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Down)
                            {
                                e.NextCtrl = null;
                                this.tNedit_SalesTargetSale1.Focus();
                                return;
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab)
                            {
                                if (this.Mode_Label.Text == INSERT_MODE
                                    || this.Mode_Label.Text == UPDATE_MODE)  // ADD K2011/07/05 
                                {
                                    // ----- DEL K2011/07/05 ------- >>>>>>>>>
                                    // 設定区分
                                    //int targetContrastCd = (int)this.tComboEditor_TargetContrastCd.Value;

                                    //switch (targetContrastCd)
                                    //{
                                    //    case 10:    // 拠点
                                    //        {
                                    //            if (this.tEdit_SectionName.DataText.Trim() != "")
                                    //            {
                                    //                e.NextCtrl = this.tEdit_SectionCode;
                                    //                return;
                                    //            }
                                    //            break;
                                    //        }
                                    //    case 30:    // 拠点＋得意先
                                    //        {
                                    //            if (this.tEdit_CustomerName.DataText.Trim() != "")
                                    //            {
                                    //                e.NextCtrl = this.tNedit_CustomerCode;
                                    //                return;
                                    //            }
                                    //            break;
                                    //        }
                                    //    case 221:   // 拠点＋担当者
                                    //    case 222:   // 拠点＋受注者
                                    //    case 223:   // 拠点＋発行者
                                    //        {
                                    //            if (this.tEdit_EmployeeName.DataText.Trim() != "")
                                    //            {
                                    //                e.NextCtrl = this.tEdit_EmployeeCode;
                                    //                return;
                                    //            }
                                    //            break;
                                    //        }
                                    //    case 32:    // 拠点＋地区
                                    //        {
                                    //            if (this.tEdit_SalesAreaName.DataText.Trim() != "")
                                    //            {
                                    //                e.NextCtrl = this.tNedit_SalesAreaCode;
                                    //                return;
                                    //            }
                                    //            break;
                                    //        }
                                    //    case 50:    // 拠点＋グループコード
                                    //        {
                                    //            if (this.tEdit_GroupName.DataText.Trim() != "")
                                    //            {
                                    //                e.NextCtrl = this.tNedit_BLGloupCode;
                                    //                return;
                                    //            }
                                    //            break;
                                    //        }
                                    //    case 44:    // 拠点＋販売区分
                                    //        {
                                    //            if (this.tEdit_GroupName.DataText.Trim() != "")
                                    //            {
                                    //                e.NextCtrl = this.tNedit_SalesCode;
                                    //                return;
                                    //            }
                                    //            break;
                                    //        }
                                    //    case 60:    // 拠点＋BLコード
                                    //        {
                                    //            if (this.tEdit_BLName.DataText.Trim() != "")
                                    //            {
                                    //                e.NextCtrl = this.tNedit_BLGoodsCode;
                                    //                return;
                                    //            }
                                    //            break;
                                    //        }
                                    //}
                                    // ----- DEL K2011/07/05 ------- <<<<<<<<<
                                }
                                else
                                {
                                    e.NextCtrl = this.SalesTarget_uGrid;
                                }
                            }
                        }
                        break;
                    }
                case "tNedit_SalesTargetProfit":
                    {
                        ChangeValue(this.tNedit_SalesTargetProfit,10);
                        break;
                    }
                case "tNedit_SalesTargetCount":
                    {
                        ChangeValue(this.tNedit_SalesTargetCount,8);
                        break;
                    }
                case "tNedit_SalesTargetSale1":
                    {
                        ChangeValue(this.tNedit_SalesTargetSale1,10);
                        if (e.Key == Keys.Down)
                        {
                            e.NextCtrl = null;
                            this.SalesTarget_uGrid.Focus();
                            this.SalesTarget_uGrid.Rows[0].Cells[COLUMN_SALESTARGET].Activate();
                            this.SalesTarget_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            return;
                        }
                        break;
                    }
                case "tNedit_SalesTargetProfit1":
                    {
                        ChangeValue(this.tNedit_SalesTargetProfit1,10);
                        if (e.Key == Keys.Down)
                        {
                            e.NextCtrl = null;
                            this.SalesTarget_uGrid.Focus();
                            this.SalesTarget_uGrid.Rows[0].Cells[COLUMN_PROFITTARGET].Activate();
                            this.SalesTarget_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            return;
                        }
                        break;
                    }
                case "tNedit_SalesTargetCount1":
                    {
                        ChangeValue(this.tNedit_SalesTargetCount1,8);
                        if (e.Key == Keys.Down)
                        {
                            e.NextCtrl = null;
                            this.SalesTarget_uGrid.Focus();
                            this.SalesTarget_uGrid.Rows[0].Cells[COLUMN_COUNTTARGET].Activate();
                            this.SalesTarget_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            return;
                        }

                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                e.NextCtrl = null;
                                this.SalesTarget_uGrid.Focus();
                                this.SalesTarget_uGrid.Rows[0].Cells[COLUMN_SALESTARGET].Activate();
                                this.SalesTarget_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                return;
                            }
                        }

                        break;
                    }
                case "SalesTarget_uGrid":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                SetNextCell(ref e, false);
                                return;
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab)
                            {
                                SetNextCell(ref e, true);
                                return;
                            }
                        }
                        break;
                    }
            }

            if (e.NextCtrl == null)
            {
                return;
            }
    
            if (e.NextCtrl == this.SalesTarget_uGrid)
            {
                if (e.ShiftKey == false)
                {
                    if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter) || e.Key == Keys.Down || e.Key == Keys.Right)
                    {
                        e.NextCtrl = null;
                        this.SalesTarget_uGrid.Focus();
                        this.SalesTarget_uGrid.Rows[0].Cells[COLUMN_SALESTARGET].Activate();
                        this.SalesTarget_uGrid.PerformAction(UltraGridAction.EnterEditMode);

                    }
                }
                else
                {
                    this.SalesTarget_uGrid.Rows[11].Cells[COLUMN_COUNTTARGET].Activate();
                }

                this.SalesTarget_uGrid.PerformAction(UltraGridAction.EnterEditMode);
            }

            // ガイドボタンツール有効無効設定処理
            if ((e.NextCtrl != null) && (e.NextCtrl.TabStop))
            {
                this.SettingGuideButtonToolEnabled(e.NextCtrl);
            }
        }

        /// <summary>
        /// フォーカス設定
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">クラス</param>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void timer_SetFocus_Tick(object sender, EventArgs e)
        {
            // フォーカス設定
            this.tNedit_CampaignCode.Focus();
            this._guideKey = this.tNedit_CampaignCode.Name;

            this.timer_SetFocus.Enabled = false;
        }
        #endregion ■ Control Events

        /// <summary>
        /// エラーメッセージ表示処理
        /// </summary>
        /// <param name="iLevel">エラーレベル</param>
        /// <param name="message">表示メッセージ</param>
        /// <param name="status">ステータス</param>
        /// <remarks>
        /// <br>Note        : エラーメッセージ表示処理</br>
        /// <br>Programmer  : 徐佳</br>
        /// <br>Date        : 2011/04/25</br>
        /// </remarks>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
        {
            TMsgDisp.Show(
                iLevel, 							// エラーレベル
                "PMKHN09651UA",						// アセンブリＩＤまたはクラスＩＤ
                "キャンペーン目標設定マスタ",		// プログラム名称
                "", 								// 処理名称
                "",									// オペレーション
                message,							// 表示するメッセージ
                status, 							// ステータス値
                null, 								// エラーが発生したオブジェクト
                MessageBoxButtons.OK, 				// 表示するボタン
                MessageBoxDefaultButton.Button1);	// 初期表示ボタン
        }

        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note	   : フォームが読み込まれた時に発生します。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void tToolsManager_MainMenu_ToolClick(object sender, ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                // 終了
                case ct_Tool_CloseButton:
                    {
                        int status = this.BeforeClose();
                        // 終了前チェックが正常場合は処理終了
                        if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                        {
                            this.Close();
                        }
                        break;
                    }
                // 新規
                case ct_Tool_NewButton:
                    {
                        this.New();
                        break;
                    }
                // 保存 
                case ct_Tool_SaveButton:
                    {
                        this.Save();
                        break;
                    }
                // 復活
                case ct_Tool_RevivalButton:
                    {
                        this.Revival();
                        break;
                    }
                // 論理削除
                case ct_Tool_LogicalDeleteButton:
                    {
                        this.LogicalDelete();
                        break;
                    }
                // 削除
                case ct_Tool_DeleteButton:
                    {
                        this.Delete();
                        break;
                    }
                // 元に戻す
                case ct_Tool_UndoButton:
                    {
                        this.Undo();
                        break;
                    }
                // ガイド
                case ct_Tool_GuideButton:
                    {
                        this.Guide();
                        break;
                    }
                // 最新情報
                case ct_Tool_RenewalButton:
                    {
                        this.Renewal();
                        break;
                    }
            }
        }
    }
}
