//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 日産発注処理
// プログラム概要   : 日産発注処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright 2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10601190-00 作成担当 : 呉元嘯
// 作 成 日  2010/03/08  修正内容 : 新規作成
//                                  日産Web-UOEとの連携用データとして、UOE発注データから日産Web-UOE用システム連携ファイルの作成を行う
//----------------------------------------------------------------------------//
// 管理番号  10601190-00 作成担当 : 呉元嘯
// 修 正 日  2010/03/18  修正内容 : Redmine4005、4030-4031対応
//----------------------------------------------------------------------------//
// 管理番号  10601190-00 作成担当 : 呉元嘯
// 修 正 日  2010/03/19  修正内容 : Redmine#4031、4032対応
//----------------------------------------------------------------------------//
// 管理番号  10601190-00 作成担当 : 呉元嘯
// 修 正 日  2010/03/19  修正内容 : Redmine#4065対応
//----------------------------------------------------------------------------//
// 管理番号  10607734-00 作成担当 : 譚洪
// 修 正 日  2010/12/31  修正内容 : UOE自動化改良
//----------------------------------------------------------------------------//
// 管理番号  10607734-01 作成担当 : 曹文傑
// 修 正 日  2011/02/25  修正内容 : 日産UOE自動化、Ｂ対応分の組み込み
//----------------------------------------------------------------------------//
// 管理番号  10607734-01 作成担当 : 曹文傑
// 修 正 日  2011/03/15  修正内容 : Redmine #19908の対応
//----------------------------------------------------------------------------//
// 管理番号  10607734-01 作成担当 : 曹文傑
// 修 正 日  2011/03/17  修正内容 : Redmine #19971の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 凌小青
// 作 成 日  2011/12/02  修正内容 : Redmine#8304の対応
//----------------------------------------------------------------------------//
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using System.Collections;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Library.Globarization;

using System.Runtime.InteropServices;


namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 日産発注処理UIクラス
    /// </summary>
    /// <remarks>
    /// <br>Note        : 日産発注処理UIフォームクラス</br>
    /// <br>Programmer  : 呉元嘯</br>
    /// <br>Date        : 2010/03/08</br>
    /// <br>UpdateNote  : 2010/03/18 呉元嘯 Redmine4005、4030-4031対応</br>
    /// <br>UpdateNote  : 2010/03/19 呉元嘯 Redmine#4031、4032対応</br>
    /// <br>UpdateNote  : 2010/12/31 譚洪 UOE自動化改良</br>
    /// <br>UpdateNote  : 2011/02/25 曹文傑 日産UOE自動化、Ｂ対応分の組み込み</br>
 /// <br>UpdateNote  : 2011/03/17 曹文傑 </br>
    /// <br>              Redmine #19971の対応</br>
    /// </remarks>
    public partial class PMUOE01521UA : Form
    {
        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region Constructors
        /// <summary>
        ///  日産発注処理フォームクラス デフォルトコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note        : 日産発注処理フォームクラス デフォルトコンストラクタ</br>
        /// <br>Programmer  : 呉元嘯</br>
        /// <br>Date        : 2010/03/08</br>
        /// <br>UpdateNote  : 2010/03/19 呉元嘯 Redmine4031、4032対応</br>
        /// </remarks>
        public PMUOE01521UA()
        {
            InitializeComponent();

            // 変数初期化
            this._detailInput = new PMUOE01521UB();
            this._imageList16 = IconResourceManagement.ImageList16;
            this._loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolbarsManager_MainMenu.Tools["LoginName_LabelTool"];
            this._loginEmployeeLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolbarsManager_MainMenu.Tools["LoginCaption_LabelTool"];
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Close"];
            this._saveButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Save"];
            this._retryButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Undo"];
            this._searchButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Search"];

            this._controlScreenSkin = new ControlScreenSkin();
            this._loginNameLabel.SharedProps.Caption = LoginInfoAcquisition.Employee.Name;

            this._uoeSupplierAcs = new UOESupplierAcs();

            // -----------DEL 2010/03/19------------>>>>>
            //_inpDisplay = new NissanInpDisplay();
            //this._detailInputAcs = NissanOrderProcAcs.GetInstance();
            // -----------DEL 2010/03/19------------<<<<<
        }

        # endregion

        // ===================================================================================== //
        // 定数
        // ===================================================================================== //
        # region Const Members
        //業務区分
        private const Int32 ctTerminalDiv_Order = 1;	//発注
        private const Int32 ctTerminalDiv_Cancel = 2;//取消処理

        //端末番号区分
        private const Int32 ctTerminalNoDiv_Own = 0;	//自端末
        private const Int32 ctTerminalNoDiv_Other = 1;	//他端末
        private const Int32 ctTerminalNoDiv_All = 2;	//全端末

        //システム区分
        private const Int32 ctSysDiv_Input = 0;	//手入力
        private const Int32 ctSysDiv_Slip = 1;	//伝発発注
        private const Int32 ctSysDiv_Srch = 2;	//検索発注
        private const Int32 ctSysDiv_Stock = 3;	//在庫一括

        //入力メッセージ
        private const string MESSAGE_SupplierCd = "発注先を選択して下さい。";
        private const string MESSAGE_TerminalDiv = "業務区分を選択して下さい。";
        private const string MESSAGE_TerminalNoDiv = "端末区分を選択して下さい。";
        private const string MESSAGE_TerminalNo = "端末番号を入力して下さい。";
        private const string MESSAGE_SysDiv = "システム区分を選択して下さい。";
        private const string MESSAGE_St_OnlineNo = "呼出番号(開始)を入力して下さい。";
        private const string MESSAGE_Ed_OnlineNo = "呼出番号(終了)を入力して下さい。";
        private const string MESSAGE_InputDateSt = "入力日(開始)を入力して下さい。";
        private const string MESSAGE_InputDateEd = "入力日(終了)を入力して下さい。";
        private const string MESSAGE_CustomerCode = "得意先を入力して下さい。";

        private const string MESSAGE_NoPass = "回答保存フォルダが未入力です。UOE発注先マスタの設定をご確認ください。";
        private const string MESSAGE_PassError = "回答保存フォルダが存在しません。UOE発注先マスタの設定をご確認ください。";
        private const string MESSAGE_ExclusiveError = "別端末で発注処理中です。";
        //日産
        private const string key = "0203";
        //日産
        private const string fileName = "F2WUOE.TXT";
        // アセンブリID
        private const string ASSEMBLY_ID = "PMUOE01521U";

        // --------ADD 2010/12/31--------->>>>>
        // 日産（自動）
        private const string auto_key = "0204";  
        private const string preFileName = "F2WUOE_";
        private const string preSubFileName = "F2WUOESUB_";
        private const string endSubFileName = ".TXT";
        private const string endFileName = ".TXT";
        private const string timeFormat = "yyyyMMddHHmmss";
        // --------ADD 2010/12/31---------<<<<<

        // ---ADD 2011/02/25-------------------->>>>>
        private const string key205 = "0205";
        private const string key206 = "0206";  
        // ---ADD 2011/02/25--------------------<<<<<
        # endregion

        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        # region Private Members
        private PMUOE01521UB _detailInput;
        private ImageList _imageList16 = null;                                                // イメージリスト
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;                    // 終了ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _saveButton;                     // 確定ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _retryButton;                    // クリアボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _searchButton;                   // 検索ボタン
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginNameLabel;                  // ログイン担当者名称
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginEmployeeLabel;                  // ログイン担当者名称
        private ControlScreenSkin _controlScreenSkin;

        private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        private string _loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;

        //ＵＯＥ発注先アクセスクラス
        private UOESupplierAcs _uoeSupplierAcs;         // ADD 2010/12/31                              
        //ＵＯＥ発注先
        private List<UOESupplier> _uoeSupplier01521;
        private UOEConnectInfo _uOEConnectInfo;// UOE接続先情報マスタ 
        //得意先マスタ
        private Dictionary<int, CustomerSearchRet> _customerSearchRet;
        //画面入力クラス
        private NissanInpDisplay _inpDisplay;
        //端末番号
        int _cashRegisterNo;
        //日産発注処理アクセスクラス
        private NissanOrderProcAcs _detailInputAcs;

        private bool buttonDisFlg = true;

        // 前回発注先
        private Int32 _bfSupplier = 0;

        // --------ADD 2010/12/31--------->>>>>
        /// <summary>
        /// 画面閉じるフラグ
        /// </summary>
        public bool closeCheck = true;
        private string nissanFlod = string.Empty;
        private UOESupplier _uoeSupplier = null;
        // --------ADD 2010/12/31---------<<<<<
        # endregion

        // ===================================================================================== //
        // プライベートメソッド
        // ===================================================================================== //
        # region Private Methods

        # region ■ 初期設定関連 ■
        # region ■ ボタン初期設定処理 ■
        /// <summary>
        /// ボタン初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : ボタン初期設定処理を行います。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/03/08</br>
        /// </remarks>
        private void ButtonInitialSetting()
        {
            //tToolbarsManager_MainMenu
            this.tToolbarsManager_MainMenu.ImageListSmall = this._imageList16;
            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this._saveButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
            this._retryButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;
            this._searchButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SEARCH;
            this._loginEmployeeLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;

            //ImageList
            this.uButton_CustomerGuide.ImageList = this._imageList16;

            //Appearance.Image
            this.uButton_CustomerGuide.Appearance.Image = (int)Size16_Index.STAR1;
        }
        # endregion ■ ボタン初期設定処理 ■

        #region 初期データ取得処理
        /// <summary>
        /// 初期データ取得処理
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 初期データ取得処理を行います。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/03/08</br>
        /// </remarks>
        public void ReadInitData()
        {
            //-----------------------------------------------------------
            // ＵＯＥ発注先キャッシュ処理
            //-----------------------------------------------------------
            this.CacheUOESupplier_01521();

            //-----------------------------------------------------------
            // 得意先マスタキャッシュ処理
            //-----------------------------------------------------------
            this.CacheCustomerSearch();

            //-----------------------------------------------------------
            // 従業員マスタキャッシュ処理
            //-----------------------------------------------------------
            this.CacheEmployee();

            //-----------------------------------------------------------
            // 端末管理設定(自端末番号を取得)
            //-----------------------------------------------------------
            int cashRegisterNo = 0;
            PosTerminalMgAcs posTerminalMgAcs = new PosTerminalMgAcs();
            int status = posTerminalMgAcs.GetCashRegisterNo(out cashRegisterNo, this._enterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this._cashRegisterNo = cashRegisterNo;
            }
        }

        /// <summary>
        /// ＵＯＥ発注先情報キャッシュ制御処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : ＵＯＥ発注先情報キャッシュ制御処理を行います。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/03/08</br>
        /// <br>UpdateNote : 2011/02/25 曹文傑 </br>
        /// <br>             日産UOE自動化、Ｂ対応分の組み込み</br>
        /// </remarks>
        public void CacheUOESupplier_01521()
        {
            _uoeSupplier01521 = new List<UOESupplier>();
            List<UOESupplier> resultList = new List<UOESupplier>();
            try
            {
                ArrayList retList;
                int status = this._uoeSupplierAcs.SearchAll(out retList, this._enterpriseCode, this._loginSectionCode.Trim());
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    foreach (UOESupplier uoeSupplier in retList)
                    {
                        if (uoeSupplier.LogicalDeleteCode == 0)
                        {
                            resultList.Add(uoeSupplier);
                        }
                    }
                }

                resultList = resultList.FindAll(delegate(UOESupplier target)
                {
                    // ---UPD 2011/02/25--------------->>>>>
                    //if (key.Equals(target.CommAssemblyId)
                    //    || auto_key.Equals(target.CommAssemblyId))  // ADD 2010/12/31

                    if (key.Equals(target.CommAssemblyId)
                        || auto_key.Equals(target.CommAssemblyId)
                        || key205.Equals(target.CommAssemblyId)
                        || key206.Equals(target.CommAssemblyId))
                    // ---UPD 2011/02/25---------------<<<<<
                    {
                        return (true);
                    }
                    else
                    {
                        return (false);
                    }
                });

                if (resultList != null && resultList.Count > 0)
                {
                    _uoeSupplier01521 = resultList;
                }
            }
            catch (Exception)
            {
                _uoeSupplier01521 = new List<UOESupplier>();
            }
        }

        /// <summary>
        /// 得意先マスタキャッシュ処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 得意先マスタキャッシュ処理を行います。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/03/08</br>
        /// </remarks>
        public void CacheCustomerSearch()
        {
            _customerSearchRet = new Dictionary<int, CustomerSearchRet>();
            CustomerSearchRet[] customerSearchRetArray = null;

            // 条件設定
            CustomerSearchPara customerSearchPara = new CustomerSearchPara();
            customerSearchPara.EnterpriseCode = this._enterpriseCode;

            try
            {
                // 得意先マスタデータ取得(PMKHN09012A)
                CustomerSearchAcs customerSearchAcs = new CustomerSearchAcs();
                int status = customerSearchAcs.Serch(out customerSearchRetArray, customerSearchPara);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    foreach (CustomerSearchRet customerSearchRet in customerSearchRetArray)
                    {
                        if (customerSearchRet.LogicalDeleteCode == 0 &&
                            _customerSearchRet.ContainsKey(customerSearchRet.CustomerCode) != true)
                        {
                            this._customerSearchRet.Add(customerSearchRet.CustomerCode, customerSearchRet);
                        }
                    }

                }
            }
            catch (Exception)
            {
                _customerSearchRet = new Dictionary<int, CustomerSearchRet>();
            }
        }

        /// <summary>
        /// 従業員マスタキャッシュ処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 従業員マスタキャッシュ処理を行います。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/03/08</br>
        /// <br>UpdateNote : 2010/03/19 呉元嘯 Redmine4032対応</br>
        /// </remarks>
        public void CacheEmployee()
        {
            //this._detailInputAcs.CacheEmployee();// DEL 2010/03/19
            this.DetailInputAcs.CacheEmployee();// ADD 2010/03/19
        }

        // --------- ADD 2010/12/31 -------------------->>>>
        /// <summary>
        /// UOE接続先情報マスタキャッシュ制御処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : UOE接続先情報マスタキャッシュ制御処理を行います。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/12/31</br>
        /// </remarks>
        public void CacheUOEConnectInfo(string commAssemblyId)
        {
            try
            {
                //指定された企業コード・通信アセンブリID・レジ番号のUOE接続先情報LISTを全て戻します
                UOEConnectInfoAcs uOEConnectInfoAcs = new UOEConnectInfoAcs();
                UOEConnectInfo uOEConnectInfo = null;
                _uOEConnectInfo = null;
                int status = uOEConnectInfoAcs.Read(out uOEConnectInfo, this._enterpriseCode, commAssemblyId, _cashRegisterNo);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    _uOEConnectInfo = uOEConnectInfo;
                }
            }
            catch (Exception)
            {
                _uOEConnectInfo = null;
            }
        }
        // --------- ADD 2010/12/31 --------------------<<<<

        # endregion 初期データ取得処理

        # region ■ 初期化処理 ■
        /// <summary>
        /// 画面初期化処理
        /// </summary>
        /// <param name="isConfirm">true:確認ダイアログを表示する false:表示しない</param>
        /// <param name="detail">true:全クリア false:明細部クリア</param>
        /// <returns>true:初期化実行 false:初期化未実行</returns>
        /// <remarks>
        /// <br>Note       :  画面初期化処理を行います。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/03/08</br>
        /// <br>UpdateNote : 2010/03/19 呉元嘯 Redmine4032対応</br>
        /// </remarks>
        private bool Clear(bool isConfirm, bool detail)
        {
            //if ((isConfirm) && this._detailInputAcs.IsDataChanged && this._detailInputAcs.StockRowExists())// DEL 2010/03/19
            if ((isConfirm) && this.DetailInputAcs.IsDataChanged && this.DetailInputAcs.StockRowExists())// ADD 2010/03/19
            {
                DialogResult dialogResult = TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    "現在、編集中のデータが存在します。" + "\r\n" + "\r\n" +
                    "実行しても宜しいですか？",
                    0,
                    MessageBoxButtons.YesNo,
                    MessageBoxDefaultButton.Button1);

                if (dialogResult != DialogResult.Yes)
                {
                    return false;
                }
            }

            // データ変更フラグプロパティをfalseにする
            //this._detailInputAcs.IsDataChanged = false;// DEL 2010/03/19
            this.DetailInputAcs.IsDataChanged = false;// ADD 2010/03/19

            // 画面処理
            if (detail)
            {
                ComboEditorItemInitialSetting();
                EventArgs e = new EventArgs();
                tComEd_SupplierCd_ValueChanged(null, e);

            }

            // テーブルクリア処理
            this._detailInput.Clear();

            //ヘッダー部画面入入力部のクリア
            this._detailInput.ClearHedaerItem();   // ADD 2010/12/31

            //コントロール関連有効無効設定処理
            SettingControlEnabled();

            return true;
        }


        # endregion ■ 初期化処理 ■

        # endregion ■ 初期設定関連 ■

        # region ■ コンボエディタアイテム初期設定処理 ■
        /// <summary>
        /// コンボエディタアイテム初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : コンボエディタアイテム初期設定処理を行います。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/03/08</br>
        /// <br>UpdateNote : 2010/03/18 呉元嘯 Redmine#4031対応</br>
        /// <br>UpdateNote : 2010/03/19 呉元嘯 Redmine#4031対応</br>
        /// </remarks>
        private void ComboEditorItemInitialSetting()
        {
            // -----------DEL 2010/03/19------------>>>>>
            //if (NissanInpDisplay == null)
            //{
            //    //_inpDisplay = new NissanInpDisplay();// DEL 2010/03/18
            //    NissanInpDisplay = new NissanInpDisplay();// ADD 2010/03/18
            //}
            // -----------DEL 2010/03/19------------<<<<<

            //発注先コード：発注先名称の初期設定処理
            this.tComEd_SupplierCd.Items.Clear();

            for (int i = 0; i < _uoeSupplier01521.Count; i++)
            {
                UOESupplier uoeSupplier = (UOESupplier)_uoeSupplier01521[i];

                object dataValue = (object)uoeSupplier.UOESupplierCd;
                string displayText = uoeSupplier.UOESupplierCd.ToString("000000") + ":" + uoeSupplier.UOESupplierName;
                tComEd_SupplierCd.Items.Add(dataValue, displayText);
            }

            ClearOrderInpDisplay(NissanInpDisplay);
            SetDisplay(NissanInpDisplay);
        }
        # endregion ■ コンボエディタアイテム初期設定処理 ■

        # region ■ 画面データ→画面格納処理 ■
        /// <summary>
        /// 画面データクラス→画面格納処理
        /// </summary>
        /// <param name="inpDisplay">在庫一括データオブジェクト</param>
        /// <remarks>
        /// <br>Note       : 画面データクラス→画面格納処理を行います。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/03/08</br>
        /// <br>UpdateNote : 2010/03/19 呉元嘯 Redmine4031対応</br>
        /// </remarks>
        private void SetDisplay(NissanInpDisplay inpDisplay)
        {
            // ----------DEL 2010/03/19------------>>>>>
            //if (inpDisplay == null)
            //{
            //    inpDisplay = new NissanInpDisplay();
            //    ClearOrderInpDisplay(inpDisplay);
            //}
            // ----------DEL 2010/03/19------------<<<<<
            //入力項目
            this.tComboEditor_TerminalDiv.Value = inpDisplay.BusinessCode;		//業務区分
            this.tComboEditor_TerminalNoDiv.Value = inpDisplay.CashRegisterNoDiv;	//端末区分


            //端末番号
            switch (inpDisplay.CashRegisterNoDiv)
            {
                //自端末
                case ctTerminalNoDiv_Own:
                    {
                        inpDisplay.CashRegisterNo = _cashRegisterNo;
                        tNedit_TerminalNo.Enabled = false;
                        break;
                    }

                //他端末
                case ctTerminalNoDiv_Other:
                    {
                        tNedit_TerminalNo.Enabled = true;
                        break;
                    }

                //全端末
                case ctTerminalNoDiv_All:
                    {
                        inpDisplay.CashRegisterNo = 0;
                        tNedit_TerminalNo.Enabled = false;
                        break;
                    }
            }

            this.tNedit_TerminalNo.SetInt(inpDisplay.CashRegisterNo);

            //システム区分
            this.tComboEditor_SysDiv.Value = inpDisplay.SystemDivCd;

            this.tNedit_St_OnlineNo.SetInt(inpDisplay.UOESalesOrderNoSt); //オンライン番号(開始）
            this.tNedit_Ed_OnlineNo.SetInt(inpDisplay.UOESalesOrderNoEd); //オンライン番号(終了）
            this.tDateEdit_InputDateSt.SetDateTime(inpDisplay.SalesDateSt); //入力日（開始）
            this.tDateEdit_InputDateEd.SetDateTime(inpDisplay.SalesDateEd); //入力日（終了）
            this.tNedit_CustomerCode.SetInt(inpDisplay.CustomerCode); //得意先ｺｰﾄﾞ
            this.tComEd_SupplierCd.Value = inpDisplay.UOESupplierCd; //発注先ｺｰﾄﾞ

            //出力項目
            this.uLabel_CustomerName.Text = inpDisplay.CustomerName; //得意先名称

        }

        # endregion ■ 画面データ→画面格納処理 ■

        # region ■ 画面データクラスの初期化 ■
        /// <summary>
        /// 画面データクラスの初期化
        /// </summary>
        /// <param name="inpDisplay"></param>
        /// <remarks>
        /// <br>Note       : 画面データクラスの初期化処理を行います。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/03/08</br>
        /// </remarks>
        private void ClearOrderInpDisplay(NissanInpDisplay inpDisplay)
        {
            //環境項目
            inpDisplay.EnterpriseCode = this._enterpriseCode;   //企業コード

            //入力項目
            inpDisplay.BusinessCode = ctTerminalDiv_Order;   //業務区分
            inpDisplay.CashRegisterNoDiv = ctTerminalNoDiv_Own;   //端末番号
            inpDisplay.CashRegisterNo = _cashRegisterNo;         //端末番号
            inpDisplay.SystemDivCd = ctSysDiv_Slip;            //システム区分

            inpDisplay.UOESalesOrderNoSt = 0;               //オンライン番号(開始）
            inpDisplay.UOESalesOrderNoEd = 0;               //オンライン番号(終了）
            inpDisplay.SalesDateSt = DateTime.Now;   //入力日（開始）
            inpDisplay.SalesDateEd = DateTime.Now;   //入力日（終了）
            inpDisplay.CustomerCode = 0;            //得意先ｺｰﾄﾞ

            //発注先ｺｰﾄﾞ
            if (_uoeSupplier01521.Count > 0)
            {
                inpDisplay.UOESupplierCd = _uoeSupplier01521[0].UOESupplierCd;

                PMUOE01521UB._supplierCd = _uoeSupplier01521[0].UOESupplierCd;
                PMUOE01521UB._sectionCode = _loginSectionCode;
            }
            //出力項目
            inpDisplay.CustomerName = "";            //得意先名称
        }
        # endregion ■ 画面データクラスの初期化 ■

        # region ■ 画面→画面データクラス格納処理 ■
        /// <summary>
        /// 画面→画面データクラス格納処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面→画面データクラス格納処理を行います。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/03/08</br>
        /// </remarks>
        private NissanInpDisplay GetDisplay()
        {
            NissanInpDisplay inpDisplay = new NissanInpDisplay();

            //環境項目
            inpDisplay.EnterpriseCode = this._enterpriseCode;   //企業コード

            //入力項目
            inpDisplay.BusinessCode = (Int32)this.tComboEditor_TerminalDiv.Value; //業務区分
            inpDisplay.CashRegisterNoDiv = (Int32)this.tComboEditor_TerminalNoDiv.Value;//端末区分

            //端末番号
            inpDisplay.CashRegisterNo = (Int32)this.tNedit_TerminalNo.GetInt();

            inpDisplay.SystemDivCd = (Int32)this.tComboEditor_SysDiv.Value;          //システム区分

            inpDisplay.UOESalesOrderNoSt = this.tNedit_St_OnlineNo.GetInt(); //オンライン番号(開始）
            inpDisplay.UOESalesOrderNoEd = this.tNedit_Ed_OnlineNo.GetInt();     //オンライン番号(終了）
            inpDisplay.SalesDateSt = this.tDateEdit_InputDateSt.GetDateTime(); //入力日（開始）
            inpDisplay.SalesDateEd = this.tDateEdit_InputDateEd.GetDateTime(); //入力日（終了）
            inpDisplay.CustomerCode = this.tNedit_CustomerCode.GetInt();       //得意先ｺｰﾄﾞ
            if (this.tComEd_SupplierCd.Value != null)
            {
                inpDisplay.UOESupplierCd = (int)this.tComEd_SupplierCd.Value;        //発注先ｺｰﾄﾞ
            }

            //出力項目
            inpDisplay.CustomerName = this.uLabel_CustomerName.Text;           //得意先名称

            return inpDisplay;
        }

        /// <summary>画面データクラスのプロパティ</summary>
        //public NissanInpDisplay NissanInpDisplay// DEL 2010/03/18
        private NissanInpDisplay NissanInpDisplay// ADD 2010/03/18
        {
            // -----------UPD 2010/03/19------------>>>>>
            //get
            //{
            //    return this._inpDisplay;
            //}
            get
            {
                if (_inpDisplay == null)
                {
                    _inpDisplay = new NissanInpDisplay();
                }
                return _inpDisplay;
            }
            // -----------UPD 2010/03/19------------<<<<<
            set
            {
                this._inpDisplay = value;
            }
        }

        // -----------ADD 2010/03/19------------>>>>>
        /// <summary>日産発注処理アクセスクラスのプロパティ</summary>
        private NissanOrderProcAcs  DetailInputAcs
        {
            get
            {
                if (_detailInputAcs == null)
                {
                    _detailInputAcs = NissanOrderProcAcs.GetInstance();
                }
                return _detailInputAcs;
            }
        }
        // -----------ADD 2010/03/19------------<<<<<

        # endregion ■ 画面→画面データクラス格納処理 ■

        # region ■ StatusBarメッセージ表示処理 ■
        /// <summary>
        /// StatusBarメッセージ表示処理
        /// </summary>
        /// <param name="nextControl">次のコントロール</param>
        /// <remarks>
        /// <br>Note       : StatusBarメッセージ表示処理を行います。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/03/08</br>
        /// </remarks>
        private void StatusBarMessageSettingProc(Control nextControl)
        {
            string message = "";

            if (nextControl.Name == tComEd_SupplierCd.Name)
            {
                message = MESSAGE_SupplierCd;
            }
            else if (nextControl.Name == tComboEditor_TerminalDiv.Name)
            {
                message = MESSAGE_TerminalDiv;
            }
            else if (nextControl.Name == tComboEditor_TerminalNoDiv.Name)
            {
                message = MESSAGE_TerminalNoDiv;
            }
            else if (nextControl.Name == tNedit_TerminalNo.Name)
            {
                message = MESSAGE_TerminalNo;
            }
            else if (nextControl.Name == tComboEditor_SysDiv.Name)
            {
                message = MESSAGE_SysDiv;
            }
            else if (nextControl.Name == tNedit_St_OnlineNo.Name)
            {
                message = MESSAGE_St_OnlineNo;
            }
            else if (nextControl.Name == tNedit_Ed_OnlineNo.Name)
            {
                message = MESSAGE_Ed_OnlineNo;
            }
            else if (nextControl.Name == tDateEdit_InputDateSt.Name)
            {
                message = MESSAGE_InputDateSt;
            }
            else if (nextControl.Name == tDateEdit_InputDateEd.Name)
            {
                message = MESSAGE_InputDateEd;
            }
            else if (nextControl.Name == tNedit_CustomerCode.Name)
            {
                message = MESSAGE_CustomerCode;
            }
            else
            {
                message = "";
            }
            StockDetailInput_StatusBarMessageSetting(this, message);
        }
        # endregion ■  StatusBarメッセージ表示処理 ■

        # region ■ ステータスバーメッセージ表示イベント ■
        /// <summary>
        /// ステータスバーメッセージ表示イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="message">メッセージ</param>
        /// <remarks>
        /// <br>Note       : ステータスバーメッセージ表示イベント処理を行います。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/03/08</br>
        /// </remarks>
        private void StockDetailInput_StatusBarMessageSetting(object sender, string message)
        {
            this.uStatusBar_Main.Panels[0].Text = message;
        }
        # endregion ■ ステータスバーメッセージ表示イベント ■

        # region ■ 終了処理 ■
        /// <summary>
        /// 終了処理
        /// </summary>
        /// <param name="isConfirm">true:確認ダイアログを表示する false:表示しない</param>
        /// <remarks>
        /// <br>Note       : 終了処理を行います。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/03/08</br>
        /// <br>UpdateNote : 2010/03/18 呉元嘯 Redmine4005対応</br>
        /// <br>UpdateNote : 2010/03/19 呉元嘯 Redmine4032対応</br>
        /// <br>UpdateNote : 2010/03/19 呉元嘯 Redmine4065対応</br>
        /// </remarks>
        private void Close(bool isConfirm)
        {
            //if ((isConfirm) && this._detailInputAcs.IsDataChanged && this._detailInputAcs.StockRowExists())// DEL 2010/03/19
            if ((isConfirm) && this.DetailInputAcs.IsDataChanged && this.DetailInputAcs.StockRowExists())// ADD 2010/03/19
            {
                DialogResult dialogResult = TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    "現在、編集中のデータが存在します。" + "\r\n" + "\r\n" +
                    "実行しても宜しいですか？",
                    0,
                    MessageBoxButtons.YesNo,
                    MessageBoxDefaultButton.Button1);

                if (dialogResult == DialogResult.Yes)
                {
                    DialogResult dr = TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_QUESTION,
                    this.Name,
                    "発注処理を終了前に日産部品発注システムにて送信してください。" + "\r\n" + "\r\n" +
                    "発注処理を終了しますか？" + "\r\n" +
                    "【注意!!】" + "\r\n" +
                    //"未送信の場合、作成した連携ファイルが削除されてしまう可能性があります。" + "\r\n" + "\r\n",// DEL 2010/03/19
                    "未送信の場合、作成した連携ファイルが削除されてしまう可能性があります。" + "\r\n",// ADD 2010/03/19
                    0,
                    MessageBoxButtons.YesNo,
                    //MessageBoxDefaultButton.Button1);// DEL 2010/03/19
                    MessageBoxDefaultButton.Button2);// ADD 2010/03/19
                    if (dr == DialogResult.Yes)
                    {
                        //this._detailInputAcs.CloseFileStream(_detailInputAcs.UoeFileStream);// DEL 2010/03/18
                        // -----------UPD 2010/03/19------------>>>>>
                        //this._detailInputAcs.CloseFileStream();// ADD 2010/03/18
                        this.DetailInputAcs.CloseFileStream();
                        // -----------UPD 2010/03/19------------<<<<<
                        this.Close();
                    }
                }

            }
            else
            {
                DialogResult dr = TMsgDisp.Show(
                this,
                emErrorLevel.ERR_LEVEL_QUESTION,
                this.Name,
                "発注処理を終了前に日産部品発注システムにて送信してください。" + "\r\n" +　"\r\n" + 
                "発注処理を終了しますか？" + "\r\n" +
                "【注意!!】" + "\r\n" +
                //"未送信の場合、作成した連携ファイルが削除されてしまう可能性があります。" + "\r\n" + "\r\n",// DEL 2010/03/19
                "未送信の場合、作成した連携ファイルが削除されてしまう可能性があります。" + "\r\n",// ADD 2010/03/19
                0,
                MessageBoxButtons.YesNo,
                //MessageBoxDefaultButton.Button1);// DEL 2010/03/19
                MessageBoxDefaultButton.Button2);// ADD 2010/03/19
                if (dr == DialogResult.Yes)
                {
                    //this._detailInputAcs.CloseFileStream(_detailInputAcs.UoeFileStream);// DEL 2010/03/18
                    // -----------UPD 2010/03/19------------>>>>>
                    //this._detailInputAcs.CloseFileStream();// ADD 2010/03/18
                    this.DetailInputAcs.CloseFileStream();
                    // -----------UPD 2010/03/19------------<<<<<
                    this.Close();
                }
            }
        }
        # endregion ■ 終了処理 ■

        #region チェック処理
        /// <summary>
        /// 検索条件チェック処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note        : 検索条件をチェックします。</br>
        /// <br>Programmer  : 呉元嘯</br>
        /// <br>Date        : 2010/03/08</br>
        /// </remarks>
        private bool CheckSearchCondition()
        {
            string errMsg = "";

            NissanInpDisplay = this.GetDisplay();

            try
            {
                //発注先
                if (NissanInpDisplay.UOESupplierCd == 0)
                {
                    errMsg = "発注先が選択されていません。";
                    this.tComEd_SupplierCd.Focus();
                    return (false);
                }

                //端末番号
                if ((NissanInpDisplay.CashRegisterNoDiv == ctTerminalNoDiv_Other)
                    && (NissanInpDisplay.CashRegisterNo == 0))
                {
                    errMsg = "端末番号が未入力です。";
                    this.tNedit_TerminalNo.SetInt(0);
                    this.tNedit_TerminalNo.Focus();
                    return (false);
                }

                //入力開始日付
                if (tDateEdit_InputDateSt.GetLongDate() == 0)
                {
                    errMsg = "入力開始日付が未入力です。";
                    this.tDateEdit_InputDateSt.Focus();
                    return (false);
                }

                if (!InputDateEditCheack(tDateEdit_InputDateSt))
                {
                    errMsg = "入力開始日付の指定に誤りがあります。";
                    this.tDateEdit_InputDateSt.Focus();
                    return (false);
                }

                //入力終了日付
                if (tDateEdit_InputDateEd.GetLongDate() == 0)
                {
                    errMsg = "入力終了日付が未入力です。";
                    this.tDateEdit_InputDateEd.Focus();
                    return (false);
                }

                if (!InputDateEditCheack(tDateEdit_InputDateEd))
                {
                    errMsg = "入力終了日付の指定に誤りがあります。";
                    this.tDateEdit_InputDateEd.Focus();
                    return (false);
                }

                //入力日範囲
                if ((NissanInpDisplay.SalesDateSt != DateTime.MinValue)
                && (NissanInpDisplay.SalesDateEd != DateTime.MinValue)
                && (NissanInpDisplay.SalesDateSt > NissanInpDisplay.SalesDateEd))
                {
                    errMsg = "入力日付の範囲が不正です。";
                    this.tDateEdit_InputDateSt.Focus();
                    return (false);
                }

                //呼出番号
                if ((NissanInpDisplay.UOESalesOrderNoSt != 0)
                    && (NissanInpDisplay.UOESalesOrderNoEd != 0)
                    && (NissanInpDisplay.UOESalesOrderNoSt > NissanInpDisplay.UOESalesOrderNoEd))
                {
                    errMsg = "呼出番号の範囲が不正です。";
                    this.tNedit_St_OnlineNo.Focus();
                    return (false);
                }
            }
            finally
            {
                if (errMsg.Length > 0)
                {
                    ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                   errMsg,
                                   0,
                                   MessageBoxButtons.OK,
                                   MessageBoxDefaultButton.Button1);
                }
            }

            return (true);
        }

        /// <summary>
        /// 年月日入力チェック処理
        /// </summary>
        /// <param name="control">年月日control</param>
        /// <returns>True:OK, False:NG</returns>
        /// <remarks>
        /// <br>Note       : 年月日入力チェック処理を行います。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/03/08</br>
        /// </remarks>
        private bool InputDateEditCheack(TDateEdit control)
        {
            // 日付を数値型で取得
            int date = control.GetLongDate();
            int yy = date / 10000;
            int mm = date / 100 % 100;
            int dd = date % 100;
            // 日付未入力チェック
            if (date == 0) return false;
            // システムサポートチェック
            if (yy < 1900) { return false; }
            // 年・月・日別入力チェック
            switch (control.DateFormat)
            {
                // 年・月・日表示時
                case emDateFormat.dfG2Y2M2D:
                case emDateFormat.df4Y2M2D:
                case emDateFormat.df2Y2M2D:
                    if (yy == 0 || mm == 0 || dd == 0) return false;
                    break;

                // 年・月    表示時
                case emDateFormat.dfG2Y2M:
                case emDateFormat.df4Y2M:
                case emDateFormat.df2Y2M:
                    if (yy == 0 || mm == 0) return false;
                    break;

                // 年        表示時
                case emDateFormat.dfG2Y:
                case emDateFormat.df4Y:
                case emDateFormat.df2Y:
                    if (yy == 0) return false;
                    break;

                // 月・日　　表示時
                case emDateFormat.df2M2D:
                    if (mm == 0 || dd == 0) return false;
                    break;

                // 月        表示時
                case emDateFormat.df2M:
                    if (mm == 0) return false;
                    break;

                // 日        表示時
                case emDateFormat.df2D:
                    if (dd == 0) return false;
                    break;
            }

            DateTime dt = TDateTime.LongDateToDateTime("YYYYMMDD", date);

            // 単純日付妥当性チェック

            if (TDateTime.IsAvailableDate(dt) == false) return false;

            return true;
        }

        /// <summary>
        /// 発注先ファイルチェック処理
        /// </summary>
        /// <param name="folder">発注先フォルダ</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : 発注先ファイルチェックを行います。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/03/08</br>
        /// <br>UpdateNote : 2010/03/19 呉元嘯 Redmine#4032対応</br>
        /// <br>UpdateNote : 2011/02/25 曹文傑 日産UOE自動化、Ｂ対応分の組み込み</br>
        /// </remarks>
        private bool UOESupplierFileCheck(string folder)
        {
            bool status = true;
            string mess = string.Empty;

            // 回答保存フォルダが未入力場合
            if (string.IsNullOrEmpty(folder))
            {
                mess = MESSAGE_NoPass;
                status = false;
            }
            // 回答保存フォルダ存在しない場合
            else if (!Directory.Exists(folder))
            {
                mess = MESSAGE_PassError;
                status = false;
            }
            // ファイルがオープン中の場合
            //else if (!this._detailInputAcs.GetCanWriteFlg(folder + "\\" + fileName))// DEL 2010/03/19
            // --------UPD 2010/12/31--------->>>>>
            //else if (!this.DetailInputAcs.GetCanWriteFlg(folder + "\\" + fileName))// ADD 2010/03/19
            //{
            //    mess = MESSAGE_ExclusiveError;
            //    status = false;
            //}
            // --------UPD 2011/02/25--------->>>>>
            //else if (key.Equals(this._uoeSupplier.CommAssemblyId))
            else if (key.Equals(this._uoeSupplier.CommAssemblyId)
             || (key205.Equals(this._uoeSupplier.CommAssemblyId) && this._uoeSupplier.InqOrdDivCd == 0))
            // --------UPD 2011/02/25---------<<<<<
            {
                if (!this.DetailInputAcs.GetCanWriteFlg(folder + "\\" + fileName))
                {
                    mess = MESSAGE_ExclusiveError;
                    status = false;
                }
            }
            // --------UPD 2010/12/31---------<<<<<

            if (!string.IsNullOrEmpty(mess))
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    mess.ToString(),
                    0,
                    MessageBoxButtons.OK);
            }
            return status;
        }

        // --------ADD 2010/12/31--------->>>>>
        /// <summary>
        /// 発注先ファイルチェック処理
        /// </summary>
        /// <param name="path">発注先フォルダ</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : 発注先ファイルチェックを行います。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/12/31</br>
        /// </remarks>
        private bool UOESupplierSubFileCheck(string path)
        {
            bool status = true;
            string mess = string.Empty;

            if (!this.DetailInputAcs.GetCanWriteFlg(path))
            {
                mess = MESSAGE_ExclusiveError;
                status = false;
            }

            if (!string.IsNullOrEmpty(mess))
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    mess.ToString(),
                    0,
                    MessageBoxButtons.OK);
            }
            return status;
        }
        // --------ADD 2010/12/31---------<<<<<
        # endregion

        #region メッセージボックス表示
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
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009/04/07</br>
        /// </remarks>
        private DialogResult ShowMessageBox(emErrorLevel errLevel, string message, int status, MessageBoxButtons msgButton, MessageBoxDefaultButton defaultButton)
        {
            DialogResult dialogResult;
            dialogResult = TMsgDisp.Show(this,                              // 親ウィンドウフォーム
                                         errLevel,                          // エラーレベル
                                         ASSEMBLY_ID,                        // アセンブリID
                                         message,                           // 表示するメッセージ
                                         status,                            // ステータス値
                                         msgButton,                         // 表示するボタン
                                         defaultButton);                    // 初期表示ボタン
            return dialogResult;
        }
        #endregion メッセージボックス表示

        # region ■ ＵＯＥ発注データ 検索処理 ■
        /// <summary>
        /// ＵＯＥ発注データ 検索処理
        /// </summary>
        /// <param name="inpDisplay">検索条件クラス</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : ＵＯＥ発注データ 検索処理を行います。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/03/08</br>
        /// <br>UpdateNote : 2010/03/19 呉元嘯 Redmine#4032対応</br>
        /// <br>UpdateNote : 2011/02/25 曹文傑 </br>
        /// <br>             日産UOE自動化、Ｂ対応分の組み込み</br>
        /// </remarks>
        public int SearchDB(NissanInpDisplay inpDisplay)
        {
            //検索実行処理
            string message = "";
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            // 抽出中画面部品のインスタンスを作成
            SFCMN00299CA msgForm = new SFCMN00299CA();
            msgForm.Title = "検索処理中";
            msgForm.Message = "検索処理中です。";

            try
            {
                msgForm.Show();
                //status = _detailInputAcs.SearchDB(NissanInpDisplay, out message);// DEL 2010/03/19
                status = this.DetailInputAcs.SearchDB(NissanInpDisplay, out message);// ADD 2010/03/19
            }
            finally
            {
                msgForm.Close();
            }

            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                if (status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "該当データが存在しません。",
                        -1,
                        MessageBoxButtons.OK);

                    this.SetControlFocus(this.tComEd_SupplierCd);

                    return status;
                }
                else
                {
                    TMsgDisp.Show(
                       this,
                       emErrorLevel.ERR_LEVEL_STOPDISP,
                       this.Name,
                       message,
                       -1,
                       MessageBoxButtons.OK);
                    this.SetControlFocus(this.tComEd_SupplierCd);

                    return status;
                }

            }

            // ガイドボタンツール有効無効設定処理
            this.SettingGuideButtonToolEnabled();

            //コントロール関連有効無効設定処理
            this.SettingControlEnabled();

            // ---ADD 2011/02/25---------------->>>>
            #region お届け先コードとリマーク２有効無効設定処理
            // 指定されたUOE発注先のプログラムの取得
            if (this._uoeSupplier01521 != null && this._uoeSupplier01521.Count > 0)
            {
                foreach (UOESupplier uoeSupplier in _uoeSupplier01521)
                {
                    if (uoeSupplier.UOESupplierCd == (int)this.tComEd_SupplierCd.Value)
                    {
                        if (key205.Equals(uoeSupplier.CommAssemblyId))
                        {
                            this._detailInput.SetRemark2Enabled(false);
                            this._detailInput.SetShippingCdEnabled(true);
                        }
                        else if (key206.Equals(uoeSupplier.CommAssemblyId))
                        {
                            this._detailInput.SetRemark2Enabled(true);
                            this._detailInput.SetShippingCdEnabled(true);
                        }
                        else
                        {
                            this._detailInput.SetRemark2Enabled(false);
                            this._detailInput.SetShippingCdEnabled(false);
                        }
                        break;
                    }
                }
            }
            #endregion
            // ---ADD 2011/02/25----------------<<<<

            return status;
        }

        # endregion ■ ＵＯＥ発注データ 検索処理 ■

        # region ■ 保存処理 ■
        /// <summary>
        /// 保存処理
        /// </summary>
        /// <returns>true:保存完了 false:未保存</returns>
        /// <remarks>
        /// <br>Note       : 保存処理を行います。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/03/08</br>
        /// <br>UpdateNote : 2010/03/19 呉元嘯 Redmine#4032対応</br>
        /// <br>UpdateNote : 2011/02/25 曹文傑 </br>
        /// <br>             日産UOE自動化、Ｂ対応分の組み込み</br>
        /// <br>UpdateNote : 2011/03/15 曹文傑 </br>
        /// <br>             Redmine #19908の対応</br>
        /// <br>UpdateNote : 2011/03/17 曹文傑 </br>
        /// <br>             Redmine #19971の対応</br>
        /// </remarks>
        private bool UpdateDB()
        {
            bool isSave = false;
            string retMessage = "";
            int status = 0;

            try
            {
                // ---ADD 2011/02/25----------->>>>>
                if (key205.Equals(this._uoeSupplier.CommAssemblyId)
                    || key206.Equals(this._uoeSupplier.CommAssemblyId)
                    || auto_key.Equals(this._uoeSupplier.CommAssemblyId))
                {
                    // ヘッダー部入力値の保存処理
                    this._detailInput.ResetHeaderInfo();
                }
                // ---ADD 2011/02/25-----------<<<<<
                //保存件数のチェック
                //if (this._detailInputAcs.IsDataChanged == false) return (isSave);// DEL 2010/03/19
                if (this.DetailInputAcs.IsDataChanged == false) return (isSave);// ADD 2010/03/19
                this.Cursor = Cursors.WaitCursor;
                // ---ADD 2011/02/25----------------->>>>>
                this._detailInput.CodeToNameUpdate(NissanInpDisplay.SystemDivCd);

                List<string> itemNameList = new List<string>();
                List<string> itemList = new List<string>();

                // ---UPD 2011/03/17------------->>>>
                if (key205.Equals(this._uoeSupplier.CommAssemblyId)
                    || key206.Equals(this._uoeSupplier.CommAssemblyId)
                    || auto_key.Equals(this._uoeSupplier.CommAssemblyId))
                {
                if (this.DetailInputAcs.SaveDataCheck(NissanInpDisplay.BusinessCode, NissanInpDisplay.SystemDivCd, out itemNameList, out itemList) != true)
                {
                    StringBuilder message = new StringBuilder();
                    message.Append("未入力の項目が存在するため、登録できません。" + "\r\n" + "\r\n");

                    foreach (string s in itemNameList)
                    {
                        message.Append(s + "\r\n");
                    }

                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        message.ToString(),
                        0,
                        MessageBoxButtons.OK);

                    string itemName = "";
                    if (itemList.Count > 0)
                    {
                        itemName = itemList[0].ToString();
                    }
                    return isSave;
                }
                }
                // ---UPD 2011/03/17-------------<<<<
                // ---ADD 2011/02/25-----------------<<<<<
                StringBuilder messageBuilder = new StringBuilder();
                //if (this._detailInputAcs.GetDeleteCount() <= 0)// DEL 2010/03/19
                if (this.DetailInputAcs.GetDeleteCount() <= 0)// ADD 2010/03/19
                {
                    messageBuilder.Append("明細が選択されていません。" + "\r\n");

                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        messageBuilder.ToString(),
                        0,
                        MessageBoxButtons.OK);
                    return isSave;
                }
                // ---ADD 2011/02/25-------------->>>>>
                else if (key206.Equals(this._uoeSupplier.CommAssemblyId) && this.DetailInputAcs.GetDeleteCount() > 114)
                {
                    messageBuilder.Append("明細合計が114を超えない様に選択してください。" + "\r\n");

                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        messageBuilder.ToString(),
                        0,
                        MessageBoxButtons.OK);
                    return isSave;
                }
                // ---ADD 2011/02/25--------------<<<<<
                //else if (this._detailInputAcs.GetDeleteCount() > 152)// DEL 2010/03/19
                else if (this.DetailInputAcs.GetDeleteCount() > 152)// ADD 2010/03/19
                {
                    messageBuilder.Append("明細合計が152を超えない様に選択してください。" + "\r\n");

                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        messageBuilder.ToString(),
                        0,
                        MessageBoxButtons.OK);
                    return isSave;
                }

                // ---ADD 2011/02/25-------------->>>>>
                // ＵＯＥ発注データ発注セット数の算出用
                this.DetailInputAcs.SetCommAssemblyId(this._uoeSupplier.CommAssemblyId);
                // ---ADD 2011/02/25--------------<<<<<
                //if (this._detailInputAcs.GetBlocCount() > 19)// DEL 2010/03/19
                if (this.DetailInputAcs.GetBlocCount() > 19)// ADD 2010/03/19
                {
                    messageBuilder.Append("発注可能数が不正です。" + "\r\n");

                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        messageBuilder.ToString(),
                        0,
                        MessageBoxButtons.OK);
                    return isSave;

                }

                // ----ADD 2010/12/31 ---------------->>>>
                if (this._detailInput.BoCodeCheck(NissanInpDisplay.BusinessCode, NissanInpDisplay.SystemDivCd) != true)
                {
                    StringBuilder message = new StringBuilder();
                    message.Append("明細部に未入力の項目が存在するため、確定できません。" + "\r\n" + "\r\n");
                    message.Append("BO区分" + "\r\n");

                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        message.ToString(),
                        0,
                        MessageBoxButtons.OK);

                    return isSave;
                }
                // ----ADD 2010/12/31 ----------------<<<<

                // 実行メッセージ表示
                DialogResult dialogResult = TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_QUESTION,
                    this.Name,
                    "発注処理を実行してもよろしいですか？",
                    0,
                    MessageBoxButtons.YesNo,
                    MessageBoxDefaultButton.Button1);

                if (dialogResult != DialogResult.Yes)
                {
                    return isSave;
                }

                // --------ADD 2010/12/31-------->>>>>
                // ---UPD 2011/02/25----------->>>>>
                //if (auto_key.Equals(this._uoeSupplier.CommAssemblyId))
                if (auto_key.Equals(this._uoeSupplier.CommAssemblyId)
                    || (key205.Equals(this._uoeSupplier.CommAssemblyId) && _uoeSupplier.InqOrdDivCd == 1)
                    || key206.Equals(this._uoeSupplier.CommAssemblyId))
                // ---UPD 2011/02/25-----------<<<<<
                {
                    this.uButton_CustomerGuide.Focus();
                    ScreenEnableSet(false);
                    this.closeCheck = false;
                }
                // --------ADD 2010/12/31--------<<<<<

                // UOE発注先マスタの収得
                UOESupplier uOESupplier = GetUOESupplier(NissanInpDisplay);

                // インポート中画面部品のインスタンスを作成
                Broadleaf.Windows.Forms.SFCMN00299CA form = new Broadleaf.Windows.Forms.SFCMN00299CA();
                // 表示文字を設定
                form.Title = "更新処理中";
                form.Message = "更新処理中です。";
                // ダイアログ表示
                form.Show();

                List<UOEOrderDtlWork> uOEOrderDtlWorkList = new List<UOEOrderDtlWork>();
                List<StockDetailWork> stockDetailWorkList = new List<StockDetailWork>();

                List<UOEOrderDtlWork> uOEOrderDtlWorkDelList = new List<UOEOrderDtlWork>();
                List<StockDetailWork> stockDetailWorkDelList = new List<StockDetailWork>();

                // ---ADD 2011/03/15--------------->>>>>
                // 0206の場合、UOE発注先マスタをアクセスに設定する。（WriteDB用）
                if (_uoeSupplier != null && key206.Equals(_uoeSupplier.CommAssemblyId))
                {
                    this.DetailInputAcs.SetUOESupplier(_uoeSupplier);
                }
                // ---ADD 2011/03/15---------------<<<<<
                // 書込処理
                // -----------UPD 2010/03/19------------>>>>>
                //status = this._detailInputAcs.WriteDB(this._cashRegisterNo, NissanInpDisplay.SystemDivCd, out retMessage,
                         //out uOEOrderDtlWorkList, out stockDetailWorkList, out uOEOrderDtlWorkDelList, out stockDetailWorkDelList);
                status = this.DetailInputAcs.WriteDB(this._cashRegisterNo, NissanInpDisplay.SystemDivCd, out retMessage,
                out uOEOrderDtlWorkList, out stockDetailWorkList, out uOEOrderDtlWorkDelList, out stockDetailWorkDelList);
                // -----------UPD 2010/03/19------------<<<<<

                // ダイアログを閉じる
                form.Close();

                //保存処理の実行
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    isSave = true;

                    // 明細グリッド設定処理
                    this._detailInput.SettingGrid();

                    // --------DEL 2010/12/31-------->>>>>
                    //SaveCompletionDialog dialog = new SaveCompletionDialog();
                    //dialog.ShowDialog(2);
                    // --------DEL 2010/12/31--------<<<<<

                    if (uOEOrderDtlWorkList != null && uOEOrderDtlWorkList.Count > 0
                        && stockDetailWorkList != null && stockDetailWorkList.Count > 0)
                    {
                        // --------UPD 2010/12/31-------->>>>>
                        //this.WriteTextProc(NissanInpDisplay.SystemDivCd,
                        //     uOEOrderDtlWorkList, stockDetailWorkList, uOEOrderDtlWorkDelList, stockDetailWorkDelList);

                        if (_uoeSupplier != null)
                        {
                            int subStatus = 0;
                            // 手動：0
                            if (key.Equals(_uoeSupplier.CommAssemblyId))
                            {
                                subStatus = this.WriteTextProc(NissanInpDisplay.SystemDivCd,
                                     uOEOrderDtlWorkList, stockDetailWorkList, uOEOrderDtlWorkDelList, stockDetailWorkDelList);
                                //--------ADD BY凌小青 on 2011/12/02 for Redmine#8304  ---------->>>>>>>>
                                DateTime dt = DateTime.Now;
                                if (File.Exists(uOESupplier.AnswerSaveFolder + "\\" + fileName))
                                {
                                    string BakFileName = preFileName + dt.ToString(timeFormat) + endFileName;
                                    File.Copy(uOESupplier.AnswerSaveFolder + "\\" + fileName, uOESupplier.AnswerSaveFolder + "\\" + BakFileName);
                                }
                                //--------ADD BY凌小青 on 2011/12/02 for Redmine#8304  ----------<<<<<<<<
                                // ダイアログを閉じる
                                form.Close();
                                if (subStatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    SaveCompletionDialog dialog = new SaveCompletionDialog();
                                    dialog.ShowDialog(2);
                                }
                            }
                            // 自動：1
                            else if (auto_key.Equals(_uoeSupplier.CommAssemblyId))
                            {
                                DateTime dt = DateTime.Now;
                                // HATTU_YYYYMMDDHHMMSS_端末番号.TXT
                                string autoFileName = preFileName + dt.ToString(timeFormat) + "_" + _cashRegisterNo.ToString("000") + endFileName;                               

                                if (!UOESupplierSubFileCheck(nissanFlod + "\\" + autoFileName))
                                {
                                    return false;
                                }

                                subStatus = this.WriteAutoTextProc(NissanInpDisplay.SystemDivCd,
                                     uOEOrderDtlWorkList, stockDetailWorkList, uOEOrderDtlWorkDelList, stockDetailWorkDelList);
                                //--------ADD BY凌小青 on 2011/12/02 for Redmine#8304  ---------->>>>>>>>
                                if (File.Exists(uOESupplier.AnswerSaveFolder + "\\" + autoFileName))
                                {
                                    string autoBakFileName = preFileName + dt.ToString(timeFormat) + "BAK" + endFileName;
                                    File.Copy(uOESupplier.AnswerSaveFolder + "\\" + autoFileName, uOESupplier.AnswerSaveFolder + "\\" + autoBakFileName);
                                }
                                //--------ADD BY凌小青 on 2011/12/02 for Redmine#8304  ----------<<<<<<<<
                                // ダイアログを閉じる
                                form.Close();
                                if (subStatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    SaveCompletionDialog dialog = new SaveCompletionDialog();
                                    dialog.ShowDialog(2);
                                    // 自動更新処理
                                    subStatus = this.AutoUpdate(NissanInpDisplay.SystemDivCd, nissanFlod, autoFileName,
                                         uOEOrderDtlWorkList, stockDetailWorkList, uOEOrderDtlWorkDelList, stockDetailWorkDelList, _cashRegisterNo, _uoeSupplier, out retMessage);
                                }
                            }
                            // ---ADD 2011/02/25----------------->>>>>
                            else if (key205.Equals(_uoeSupplier.CommAssemblyId))
                            {
                                // 手動：0
                                if (_uoeSupplier.InqOrdDivCd == 0)
                                {
                                    subStatus = this.WriteTextProc2(NissanInpDisplay.SystemDivCd,
                                         uOEOrderDtlWorkList, stockDetailWorkList, uOEOrderDtlWorkDelList, stockDetailWorkDelList);
                                    //--------ADD BY凌小青 on 2011/12/02 for Redmine#8304  ---------->>>>>>>>
                                    DateTime dt = DateTime.Now;
                                    if (File.Exists(uOESupplier.AnswerSaveFolder + "\\" + fileName))
                                    {
                                        string BakFileName = preFileName + dt.ToString(timeFormat) + endFileName;
                                        File.Copy(uOESupplier.AnswerSaveFolder + "\\" + fileName, uOESupplier.AnswerSaveFolder + "\\" + BakFileName);
                                    }
                                    //--------ADD BY凌小青 on 2011/12/02 for Redmine#8304  ----------<<<<<<<<
                                    // ダイアログを閉じる
                                    form.Close();
                                    if (subStatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                    {
                                        SaveCompletionDialog dialog = new SaveCompletionDialog();
                                        dialog.ShowDialog(2);
                                    }                                    
                                }
                                // 自動：1
                                else
                                {
                                    DateTime dt = DateTime.Now;
                                    // HATTU_YYYYMMDDHHMMSS_端末番号.TXT
                                    string autoFileName = preFileName + dt.ToString(timeFormat) + "_" + _cashRegisterNo.ToString("000") + endFileName;                                    

                                    if (!UOESupplierSubFileCheck(nissanFlod + "\\" + autoFileName))
                                    {
                                        return false;
                                    }

                                    subStatus = this.WriteTextProc2(NissanInpDisplay.SystemDivCd,
                                         uOEOrderDtlWorkList, stockDetailWorkList, uOEOrderDtlWorkDelList, stockDetailWorkDelList);
                                    //--------ADD BY凌小青 on 2011/12/02 for Redmine#8304  ---------->>>>>>>>
                                    if (File.Exists(uOESupplier.AnswerSaveFolder + "\\" + autoFileName))
                                    {
                                        string autoBakFileName = preFileName + dt.ToString(timeFormat) + "BAK" + endFileName;
                                        File.Copy(uOESupplier.AnswerSaveFolder + "\\" + autoFileName, uOESupplier.AnswerSaveFolder + "\\" + autoBakFileName);
                                    }
                                    //--------ADD BY凌小青 on 2011/12/02 for Redmine#8304  ----------<<<<<<<<
                                    // ダイアログを閉じる
                                    form.Close();
                                    if (subStatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                    {
                                        SaveCompletionDialog dialog = new SaveCompletionDialog();
                                        dialog.ShowDialog(2);
                                        // 自動更新処理
                                        subStatus = this.AutoUpdate(NissanInpDisplay.SystemDivCd, nissanFlod, autoFileName,
                                             uOEOrderDtlWorkList, stockDetailWorkList, uOEOrderDtlWorkDelList, stockDetailWorkDelList, _cashRegisterNo, _uoeSupplier, out retMessage);
                                    }
                                }
                            }
                            else if (key206.Equals(_uoeSupplier.CommAssemblyId))
                            {
                                DateTime dt = DateTime.Now;
                                // HATTU_YYYYMMDDHHMMSS_端末番号.TXT
                                string autoFileName = preFileName + dt.ToString(timeFormat) + "_" + _cashRegisterNo.ToString("000") + endFileName;

                                if (!UOESupplierSubFileCheck(nissanFlod + "\\" + autoFileName))
                                {
                                    return false;
                                }

                                #region 明細部分を使用して連携番号のセットを行う
                                List<UOEOrderDtlWork> newUOEOrderDtlWL = new List<UOEOrderDtlWork>();
                                int count = 0;
                                int onlineNo = -1;

                                for (int i = 0; i < uOEOrderDtlWorkList.Count; i++)
                                {
                                    if (i == 0)
                                    {
                                        count++;
                                        onlineNo = uOEOrderDtlWorkList[i].OnlineNo;

                                        newUOEOrderDtlWL.Add(uOEOrderDtlWorkList[i]);

                                        if (uOEOrderDtlWorkList.Count == 1)
                                        {
                                            newUOEOrderDtlWL.Add(this.GetUOEOrderDtlWork(uOEOrderDtlWorkList[i]));
                                        }
                                    }
                                    else
                                    {
                                        // 発注番号が変更された
                                        if (onlineNo != uOEOrderDtlWorkList[i].OnlineNo)
                                        {
                                            if (count != 0)
                                            {
                                                newUOEOrderDtlWL.Add(this.GetUOEOrderDtlWork(uOEOrderDtlWorkList[i - 1]));
                                                newUOEOrderDtlWL.Add(uOEOrderDtlWorkList[i]);
                                            }
                                            else
                                            {
                                                newUOEOrderDtlWL.Add(uOEOrderDtlWorkList[i]);
                                            }

                                            if (i == uOEOrderDtlWorkList.Count - 1)
                                            {
                                                newUOEOrderDtlWL.Add(this.GetUOEOrderDtlWork(uOEOrderDtlWorkList[i]));
                                            }
                                            count = 1;
                                            onlineNo = uOEOrderDtlWorkList[i].OnlineNo;
                                        }
                                        // 発注番号が変更なし
                                        else
                                        {
                                            count++;

                                            if (count == 3)
                                            {
                                                count = 0;
                                                newUOEOrderDtlWL.Add(uOEOrderDtlWorkList[i]);
                                                newUOEOrderDtlWL.Add(this.GetUOEOrderDtlWork(uOEOrderDtlWorkList[i]));
                                            }
                                            else
                                            {
                                                newUOEOrderDtlWL.Add(uOEOrderDtlWorkList[i]);

                                                if (i == uOEOrderDtlWorkList.Count - 1)
                                                {
                                                    newUOEOrderDtlWL.Add(this.GetUOEOrderDtlWork(uOEOrderDtlWorkList[i]));
                                                }
                                            }
                                        }
                                    }
                                }
                                #endregion

                                subStatus = this.WriteTextProc2(NissanInpDisplay.SystemDivCd,
                                     newUOEOrderDtlWL, stockDetailWorkList, uOEOrderDtlWorkDelList, stockDetailWorkDelList);
                                //--------ADD BY凌小青 on 2011/12/02 for Redmine#8304  ---------->>>>>>>>
                                if (File.Exists(uOESupplier.AnswerSaveFolder + "\\" + autoFileName))
                                {
                                    string autoBakFileName = preFileName + dt.ToString(timeFormat) + "BAK" + endFileName;
                                    File.Copy(uOESupplier.AnswerSaveFolder + "\\" + autoFileName, uOESupplier.AnswerSaveFolder + "\\" + autoBakFileName);
                                }
                                //--------ADD BY凌小青 on 2011/12/02 for Redmine#8304  ----------<<<<<<<<
                                // ダイアログを閉じる
                                form.Close();
                                if (subStatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    SaveCompletionDialog dialog = new SaveCompletionDialog();
                                    dialog.ShowDialog(2);
                                    // 自動更新処理
                                    subStatus = this.AutoUpdate(NissanInpDisplay.SystemDivCd, nissanFlod, autoFileName,
                                         uOEOrderDtlWorkList, stockDetailWorkList, uOEOrderDtlWorkDelList, stockDetailWorkDelList, _cashRegisterNo, _uoeSupplier, out retMessage);
                                }
                            }
                            // ---ADD 2011/02/25-----------------<<<<<
                        }

                        // --------UPD 2010/12/31--------<<<<<
                    }
                }
            }
            catch (Exception ex)
            {
                isSave = false;
                retMessage = ex.Message;
            }
            finally
            {
                this.Cursor = Cursors.Default;

                if (status != 0)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_STOPDISP,
                        this.Name,
                        "(" + status.ToString() + ")" +
                        "更新に失敗しました。" + "\r\n" + "\r\n" + retMessage,
                        status,
                        MessageBoxButtons.OK);
                }
            }

            // --------ADD 2010/12/31--------->>>>>
            // ---UPD 2011/02/25----------->>>>>
            //if (auto_key.Equals(this._uoeSupplier.CommAssemblyId))
            if (auto_key.Equals(this._uoeSupplier.CommAssemblyId)
                || (key205.Equals(this._uoeSupplier.CommAssemblyId) && _uoeSupplier.InqOrdDivCd == 1)
                || key206.Equals(this._uoeSupplier.CommAssemblyId))
            // ---UPD 2011/02/25-----------<<<<<
            {
                ScreenEnableSet(true);
                this.closeCheck = true;
            }
            // --------ADD 2010/12/31---------<<<<<

            return isSave;
        }

        // --------ADD 2010/12/31--------->>>>>
        /// <summary>
        /// 画面Enable設定処理
        /// </summary>
        /// <param name="enable">enable</param>
        /// <returns>BOOL</returns>
        /// <remarks>
        /// <br>Note       : 画面Enable設定を行います。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/08/26</br>
        /// </remarks>
        private void ScreenEnableSet(bool enable)
        {
            this.tToolbarsManager_MainMenu.Enabled = enable;
            this.panel_Header.Enabled = enable;
            this.panel_Detail.Enabled = enable;
        }
        // --------ADD 2010/12/31---------<<<<<

        /// <summary>
        /// ファイルがオープン中チェック
        /// </summary>
        /// <param name="systemDiv">システム区分</param>
        /// <param name="uOEOrderDtlWorkList">UOE発注データ</param>
        /// <param name="stockDetailWorkList">仕入明細データ</param>
        /// <param name="uOEOrderDtlWorkDelList">UOE発注削除データ</param>
        /// <param name="stockDetailWorkDelList">仕入明細削除データ</param>
        /// <returns>BOOL</returns>
        /// <remarks>
        /// <br>Note       : UOE発注先マスタ収得を行います。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/03/08</br>
        /// </remarks>
        private int WriteTextProc(int systemDiv,
               List<UOEOrderDtlWork> uOEOrderDtlWorkList, List<StockDetailWork> stockDetailWorkList,
               List<UOEOrderDtlWork> uOEOrderDtlWorkDelList, List<StockDetailWork> stockDetailWorkDelList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            string retMessage = string.Empty;

            // -----------UPD 2010/03/19------------>>>>>
            //status = this._detailInputAcs.WriteText(systemDiv, out retMessage,
            //                            uOEOrderDtlWorkList);
            status = this.DetailInputAcs.WriteText(systemDiv, out retMessage,
                                        uOEOrderDtlWorkList);
            // -----------UPD 2010/03/19------------<<<<<
            return status;
        }

        /// <summary>
        /// ファイルがオープン中チェック
        /// </summary>
        /// <param name="systemDiv">システム区分</param>
        /// <param name="uOEOrderDtlWorkList">UOE発注データ</param>
        /// <param name="stockDetailWorkList">仕入明細データ</param>
        /// <param name="uOEOrderDtlWorkDelList">UOE発注削除データ</param>
        /// <param name="stockDetailWorkDelList">仕入明細削除データ</param>
        /// <returns>BOOL</returns>
        /// <remarks>
        /// <br>Note       : UOE発注先マスタ収得を行います。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/03/08</br>
        /// </remarks>
        private int WriteAutoTextProc(int systemDiv,
               List<UOEOrderDtlWork> uOEOrderDtlWorkList, List<StockDetailWork> stockDetailWorkList,
               List<UOEOrderDtlWork> uOEOrderDtlWorkDelList, List<StockDetailWork> stockDetailWorkDelList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            string retMessage = string.Empty;

            status = this.DetailInputAcs.WriteAutoText(systemDiv, out retMessage,
                                        uOEOrderDtlWorkList);

            return status;
        }

        // --------ADD 2010/12/31--------->>>>>
        /// <summary>
        /// ファイルがオープン中チェック
        /// </summary>
        /// <param name="systemDiv">システム区分</param>
        /// <param name="uOEOrderDtlWorkList">UOE発注データ</param>
        /// <param name="stockDetailWorkList">仕入明細データ</param>
        /// <param name="uOEOrderDtlWorkDelList">UOE発注削除データ</param>
        /// <param name="stockDetailWorkDelList">仕入明細削除データ</param>
        /// <returns>BOOL</returns>
        /// <remarks>
        /// <br>Note       : UOE発注先マスタ収得を行います。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/12/31</br>
        /// </remarks>
        private int WriteSubTextProc(int systemDiv,
               List<UOEOrderDtlWork> uOEOrderDtlWorkList, List<StockDetailWork> stockDetailWorkList,
               List<UOEOrderDtlWork> uOEOrderDtlWorkDelList, List<StockDetailWork> stockDetailWorkDelList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            string retMessage = string.Empty;

            status = this.DetailInputAcs.WriteSubText(systemDiv, out retMessage,
                                        uOEOrderDtlWorkList);

            return status;
        }

        /// <summary>
        /// 自動更新処理
        /// </summary>
        /// <param name="systemDiv">システム区分</param>
        /// <param name="nissanFlod">フォルダ</param>
        /// <param name="uOEOrderDtlWorkList">UOE発注データ</param>
        /// <param name="stockDetailWorkList">仕入明細データ</param>
        /// <param name="uOEOrderDtlWorkDelList">UOE発注削除データ</param>
        /// <param name="stockDetailWorkDelList">仕入明細削除データ</param>
        /// <param name="cashRegisterNo">自端末番号</param>
        /// <param name="uoeSupplier">UOEマスタデータ</param>
        /// <param name="errMess">errMess</param>
        /// <returns>BOOL</returns>
        /// <remarks>
        /// <br>Note       : 自動更新処理を行います。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/07/26</br>
        /// </remarks>
        private int AutoUpdate(int systemDiv, string nissanFlod, string fileName,
               List<UOEOrderDtlWork> uOEOrderDtlWorkList, List<StockDetailWork> stockDetailWorkList,
               List<UOEOrderDtlWork> uOEOrderDtlWorkDelList, List<StockDetailWork> stockDetailWorkDelList, int cashRegisterNo, UOESupplier uoeSupplier, out string errMess)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            errMess = string.Empty;
            string autoFileName = string.Empty; // サブファイル名

            #region 発注送信データサブファイル生成
            // HATTUSUB_YYYYMMDDHHMMSS_端末番号.TXT
            DateTime dt = DateTime.Now;
            autoFileName = preSubFileName + dt.ToString(timeFormat) + "_" + cashRegisterNo.ToString("000") + endSubFileName;

            if (!UOESupplierSubFileCheck(nissanFlod + "\\" + autoFileName))
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                return status;
            }

            int subStatus = this.WriteSubTextProc(NissanInpDisplay.SystemDivCd,
                                     uOEOrderDtlWorkList, stockDetailWorkList, uOEOrderDtlWorkDelList, stockDetailWorkDelList);


            #endregion

            // 自動更新処理
            status = this._detailInputAcs.AutoUpdateProc(nissanFlod + "\\" + fileName, uoeSupplier.AnswerSaveFolder + "\\" + autoFileName, uoeSupplier, _uOEConnectInfo, out errMess);
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                DialogResult dialogResult = TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                    this.Name,
                                    errMess,
                                    0,
                                    MessageBoxButtons.OK,
                                    MessageBoxDefaultButton.Button1);
            }

            return status;
        }
        // --------ADD 2010/12/31---------<<<<<

        // ---ADD 2011/02/25---------------->>>>>
        /// <summary>
        /// ファイルがオープン中チェック(プログラムIDが「0205」と「0206」の場合)
        /// </summary>
        /// <param name="systemDiv">システム区分</param>
        /// <param name="uOEOrderDtlWorkList">UOE発注データ</param>
        /// <param name="stockDetailWorkList">仕入明細データ</param>
        /// <param name="uOEOrderDtlWorkDelList">UOE発注削除データ</param>
        /// <param name="stockDetailWorkDelList">仕入明細削除データ</param>
        /// <returns>BOOL</returns>
        /// <remarks>
        /// <br>Note       : UOE発注先マスタ収得を行います。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2010/02/25</br>
        /// </remarks>
        private int WriteTextProc2(int systemDiv,
               List<UOEOrderDtlWork> uOEOrderDtlWorkList, List<StockDetailWork> stockDetailWorkList,
               List<UOEOrderDtlWork> uOEOrderDtlWorkDelList, List<StockDetailWork> stockDetailWorkDelList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            string retMessage = string.Empty;

            status = this.DetailInputAcs.WriteText2(systemDiv, out retMessage,
                                        uOEOrderDtlWorkList);
            return status;
        }

        /// <summary>
        /// 明細部分を使用して連携番号のセットを行う(プログラムIDが「0206」の場合)
        /// </summary>
        /// <param name="uOEOrderDtlWork">UOE発注データワーク</param>
        /// <returns>UOE発注データワーク</returns>
        /// <remarks>
        /// <br>Note       : 明細部分を使用して連携番号のセットを行います。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/02/25</br>
        /// </remarks>
        private UOEOrderDtlWork GetUOEOrderDtlWork(UOEOrderDtlWork uOEOrderDtlWork)
        {
            UOEOrderDtlWork work = new UOEOrderDtlWork();
            work.BoCode = " ";
            work.AcceptAnOrderCnt = 1;
            work.GoodsNoNoneHyphen = uOEOrderDtlWork.UoeRemark2;
            work.OnlineNo = uOEOrderDtlWork.OnlineNo;
            return work;
        }
        // ---ADD 2011/02/25----------------<<<<<
        # endregion ■ 保存処理 ■

        # region ■ 削除処理 ■
        /// <summary>
        /// 削除処理
        /// </summary>
        /// <returns>true:削除完了 false:削除失敗</returns>
        /// <remarks>
        /// <br>Note       : 削除処理を行います。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/03/08</br>
        /// <br>UpdateNote : 2010/03/19 呉元嘯 Redmine#4032対応</br>
        /// </remarks>
        bool DeleteDB()
        {
            bool retBool = false;
            int status = 0;
            string message = "";

            try
            {
                //削除件数のチェック
                // -----------UPD 2010/03/19------------>>>>>
                //if (this._detailInputAcs.IsDataChanged == false) return (retBool);
                //if (this._detailInputAcs.GetDeleteCount() <= 0)
                if (this.DetailInputAcs.IsDataChanged == false) return (retBool);
                if (this.DetailInputAcs.GetDeleteCount() <= 0)
                // -----------UPD 2010/03/19------------<<<<<
                {
                    StringBuilder messageBuilder = new StringBuilder();
                    messageBuilder.Append("削除対象のデータを選択してください。" + "\r\n");

                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        messageBuilder.ToString(),
                        0,
                        MessageBoxButtons.OK);
                    return retBool;
                }

                //削除メッセージ表示
                DialogResult dialogResult = TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_QUESTION,
                    this.Name,
                    "選択行を削除してもよろしいですか？",
                    0,
                    MessageBoxButtons.YesNo,
                    MessageBoxDefaultButton.Button1);

                if (dialogResult != DialogResult.Yes)
                {
                    return retBool;
                }

                // インポート中画面部品のインスタンスを作成
                Broadleaf.Windows.Forms.SFCMN00299CA form = new Broadleaf.Windows.Forms.SFCMN00299CA();
                // 表示文字を設定
                form.Title = "削除処理中";
                form.Message = "削除処理中です。";
                // ダイアログ表示
                form.Show();

                //status = this._detailInputAcs.DeleteDB(out message);// DEL 2010/03/19
                status = this.DetailInputAcs.DeleteDB(out message);// ADD 2010/03/19

                // ダイアログを閉じる
                form.Close();

                //削除処理の実行
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //if (this._detailInputAcs.GetNoSelectCount() > 0)// DEL 2010/03/19
                    if (this.DetailInputAcs.GetNoSelectCount() > 0)// ADD 2010/03/19
                    {
                        //再検索
                        this._detailInput.Clear1();

                        SearchDB(NissanInpDisplay);

                        this._detailInput.SettingGrid(NissanInpDisplay.BusinessCode);

                        // テーブルクリア処理
                        this._detailInput.ClearUltr();

                        retBool = false;
                    }
                    else
                    {
                        retBool = true;
                    }

                    // 明細グリッド設定処理
                    this._detailInput.SettingGrid();

                    SaveCompletionDialog dialog = new SaveCompletionDialog();
                    dialog.ShowDialog(2);
                }
            }
            catch (Exception ex)
            {
                retBool = false;
                message = ex.Message;
                status = -1;
            }
            finally
            {
                if (status != 0)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_STOPDISP,
                        this.Name,
                        "(" + status.ToString() + ")" +
                        "削除に失敗しました。" + "\r\n" + "\r\n" + message,
                        status,
                        MessageBoxButtons.OK);
                }

            }
            return (retBool);
        }

        # endregion

        # region ■ UOE発注先マスタの収得 ■
        /// <summary>
        /// UOE発注先マスタ収得
        /// </summary>
        /// <param name="inpDisplay">画面の情報</param>
        /// <returns>UOE発注先マスタ</returns>
        /// <remarks>
        /// <br>Note       :  UOE発注先マスタ収得を行います。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/03/08</br>
        /// </remarks>
        private UOESupplier GetUOESupplier(NissanInpDisplay inpDisplay)
        {
            UOESupplier uOESupplier = new UOESupplier();
            List<UOESupplier> resultList;

            resultList = _uoeSupplier01521.FindAll(delegate(UOESupplier target)
            {
                if (inpDisplay.UOESupplierCd.Equals(target.UOESupplierCd))
                {
                    return (true);
                }
                else
                {
                    return (false);
                }
            });

            if (resultList != null && resultList.Count > 0)
            {
                uOESupplier = (UOESupplier)resultList[0];
            }

            return uOESupplier;
        }

        # endregion ■ UOE発注先マスタの収得 ■

        # endregion

        // ===================================================================================== //
        // 各コントロールイベント処理
        // ===================================================================================== //
        # region Control Event Methods
        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : フォームロードイベント処理を行います。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/03/08</br>
        /// </remarks>
        private void PMUOE01521UA_Load(object sender, EventArgs e)
        {
            // Skin設定
            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);
            this._controlScreenSkin.SettingScreenSkin(this._detailInput);

            this.panel_Detail.Controls.Add(this._detailInput);
            this._detailInput.Dock = DockStyle.Fill;

            // ボタン初期設定処理
            this.ButtonInitialSetting();

            // 初期データ取得処理
            this.ReadInitData();

            // コンボエディタアイテム初期設定処理
            this.ComboEditorItemInitialSetting();
            this._bfSupplier = PMUOE01521UB._supplierCd;

            // クリア処理
            this.Clear(false, false);

            // --------ADD 2010/12/31--------->>>>>
            // 指定されたUOE発注先の回答保存フォルダの取得
            if (this._uoeSupplier01521 != null && this._uoeSupplier01521.Count > 0)
            {
                foreach (UOESupplier uoeSupplier in _uoeSupplier01521)
                {
                    if (uoeSupplier.UOESupplierCd == (int)this.tComEd_SupplierCd.Value)
                    {
                        nissanFlod = uoeSupplier.AnswerSaveFolder;
                        _uoeSupplier = uoeSupplier;

                        // 手動の場合、
                        if (key.Equals(uoeSupplier.CommAssemblyId))
                        {
                            PMUOE01521UB._inqOrdDivCdFlg = 0;
                            //-----------------------------------------------------------
                            // UOE接続先情報マスタ
                            //-----------------------------------------------------------
                            this.CacheUOEConnectInfo(uoeSupplier.CommAssemblyId); 
                            break;
                        }
                        // 自動の場合、
                        // ---UPD 2011/02/25------------>>>>>
                        //else if (auto_key.Equals(uoeSupplier.CommAssemblyId))
                        else if (auto_key.Equals(uoeSupplier.CommAssemblyId)
                              || key205.Equals(uoeSupplier.CommAssemblyId)
                              || key206.Equals(uoeSupplier.CommAssemblyId))
                        // ---UPD 2011/02/25------------<<<<<
                        {
                            PMUOE01521UB._inqOrdDivCdFlg = 1;
                            //-----------------------------------------------------------
                            // UOE接続先情報マスタ
                            //-----------------------------------------------------------
                            this.CacheUOEConnectInfo(uoeSupplier.CommAssemblyId); 
                            break;
                        }
                        else
                        {
                            // なし。
                        }
                    }
                }
            }

            // --------ADD 2010/12/31---------<<<<<

            this.timer_InitialSet.Enabled = true;

        }

        /// <summary>
        /// フォーカスコントロールイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : フォーカスコントロールイベント処理を行います。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/03/08</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            bool canChangeFocus;
            int code;
            if (e.PrevCtrl == null || e.NextCtrl == null) return;
            if (NissanInpDisplay == null) return;

            switch (e.PrevCtrl.Name)
            {
                // グリッド =============================================== //
                case "uGrid_Details":
                    {
                        #region [ uGrid_Details ]
                        switch (e.Key)
                        {
                            case Keys.Return:
                                {
                                    if (this._detailInput.uGrid_Details.ActiveCell != null)
                                    {
                                        if (this._detailInput.ReturnKeyDown())
                                        {
                                            e.NextCtrl = null;
                                        }
                                        else
                                        {
                                            this._detailInput.uGrid_Details.ActiveCell.Selected = false;
                                            this._detailInput.uGrid_Details.ActiveCell = null;
                                        }
                                    }
                                    break;
                                }
                        }
                        #endregion
                        break;
                    }

                // UOE発注先コード ============================================ //
                case "tComEd_SupplierCd":
                    {
                        #region [ tComEd_SupplierCd ]
                        if (tComEd_SupplierCd.Value != null)
                        {
                            NissanInpDisplay.UOESupplierCd = (Int32)tComEd_SupplierCd.Value;
                        }

                        code = this.tNedit_CustomerCode.GetInt();

                        if (e.ShiftKey)
                        {
                            if (code == 0)
                            {
                                // フォーカス設定
                                if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                                {
                                    e.NextCtrl = this.uButton_CustomerGuide;
                                }
                            }
                            else
                            {
                                string customerNameFouce = "";
                                if (GetMakerName(code, out customerNameFouce) == true)
                                {
                                    if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                                    {
                                        e.NextCtrl = this.tNedit_CustomerCode;
                                    }
                                }
                            }
                        }

                        #endregion
                        break;
                    }

                // 業務区分 ============================================ //
                case "tComboEditor_TerminalDiv":
                    {
                        #region [ tComboEditor_TerminalDiv ]
                        NissanInpDisplay.BusinessCode = (Int32)tComboEditor_TerminalDiv.Value;
                        #endregion
                        break;
                    }

                // 端末区分 ============================================ //
                case "tComboEditor_TerminalNoDiv":
                    #region [ tComboEditor_TerminalNoDiv ]
                    NissanInpDisplay.CashRegisterNoDiv = (Int32)tComboEditor_TerminalNoDiv.Value;
                    #endregion
                    break;

                // 端末番号 ============================================ //
                case "tNedit_TerminalNo":
                    #region [ tNedit_TerminalNo ]
                    NissanInpDisplay.CashRegisterNo = this.tNedit_TerminalNo.GetInt();
                    #endregion
                    break;

                // システム区分 ============================================ //
                case "tComboEditor_SysDiv":
                    #region [ tComboEditor_SysDiv ]
                    NissanInpDisplay.SystemDivCd = (Int32)tComboEditor_SysDiv.Value;
                    #endregion
                    break;

                // オンライン番号(開始） ============================================ //
                case "tNedit_St_OnlineNo":
                    #region [ St_OnlineNo ]
                    NissanInpDisplay.UOESalesOrderNoSt = tNedit_St_OnlineNo.GetInt();
                    #endregion
                    break;

                // オンライン番号(終了） ============================================ //
                case "tNedit_Ed_OnlineNo":
                    #region [ Ed_OnlineNo ]
                    NissanInpDisplay.UOESalesOrderNoEd = tNedit_Ed_OnlineNo.GetInt();
                    #endregion
                    break;

                // 入力日（開始） ============================================ //
                case "tDateEdit_InputDateSt":
                    #region [ tDateEdit_InputDateSt ]
                    NissanInpDisplay.SalesDateSt = tDateEdit_InputDateSt.GetDateTime();
                    #endregion
                    break;

                // 入力日（終了） ============================================ //
                case "tDateEdit_InputDateEd":
                    #region [ tDateEdit_InputDateEd ]
                    NissanInpDisplay.SalesDateEd = tDateEdit_InputDateEd.GetDateTime();
                    #endregion
                    break;

                // 得意先ｺｰﾄﾞ ============================================ //
                case "tNedit_CustomerCode":
                    #region [ tNedit_CustomerCode ]
                    canChangeFocus = true;
                    code = this.tNedit_CustomerCode.GetInt();

                    if (NissanInpDisplay.CustomerCode != code)
                    {
                        if (code == 0)
                        {
                            NissanInpDisplay.CustomerCode = 0;
                            NissanInpDisplay.CustomerName = "";
                        }
                        else
                        {
                            string customerName = "";
                            if (GetMakerName(code, out customerName) == true)
                            {
                                NissanInpDisplay.CustomerCode = code;
                                NissanInpDisplay.CustomerName = customerName;

                            }
                            else
                            {
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    "得意先が存在しません。",
                                    -1,
                                    MessageBoxButtons.OK);
                                canChangeFocus = false;
                            }
                        }

                        // NextCtrl制御
                        if (canChangeFocus)
                        {
                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        {
                                            if (this.tNedit_CustomerCode.GetInt() == 0)
                                            {
                                                e.NextCtrl = this.uButton_CustomerGuide;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.tComEd_SupplierCd;
                                            }
                                            break;
                                        }
                                }
                            }
                        }
                        else
                        {
                            e.NextCtrl = e.PrevCtrl;
                        }
                    }
                    else
                    {
                        if (!e.ShiftKey)
                        {
                            if (code == 0)
                            {
                                // フォーカス設定
                                if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                                {
                                    e.NextCtrl = this.uButton_CustomerGuide;
                                }
                            }
                            else
                            {
                                string customerNameFouce = "";
                                if (GetMakerName(code, out customerNameFouce) == true)
                                {
                                    if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                                    {
                                        e.NextCtrl = this.tComEd_SupplierCd;
                                    }
                                }
                            }
                        }
                    }

                    #endregion
                    break;

                // 得意先ボタン
                case "uButton_CustomerGuide":
                    {
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                            {
                                e.NextCtrl = this.tComEd_SupplierCd;
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                            {
                                e.NextCtrl = this.tNedit_CustomerCode;
                            }
                        }
                        break;
                    }
            }

            // メモリ上の内容と比較する
            NissanInpDisplay InpDisplayNow = this.GetDisplay();
            ArrayList arRetList = NissanInpDisplay.Compare(InpDisplayNow);

            if (arRetList.Count > 0)
            {
                // 画面情報クラス→画面格納処理
                this.SetDisplay(NissanInpDisplay);
            }

            // ガイドボタンツール有効無効設定処理
            if ((e.NextCtrl != null) && (e.NextCtrl.TabStop))
            {
                SettingGuideButtonToolEnabled();
                this.StatusBarMessageSettingProc(e.NextCtrl);
            }
        }

        /// <summary>
        /// 得意先ｺｰﾄﾞ名取得処理
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="customerName">得意先名称</param>
        /// <returns>True：データあり、False：データなし</returns>
        /// <remarks>
        /// <br>Note       : 得意先ｺｰﾄﾞ名取得処理を行います。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/03/08</br>
        /// </remarks>
        private bool GetMakerName(int customerCode, out string customerName)
        {
            customerName = string.Empty;

            if (!this._customerSearchRet.ContainsKey(customerCode))
            {
                return false;
            }

            customerName = this._customerSearchRet[customerCode].Name.Trim() + this._customerSearchRet[customerCode].Name2.Trim();

            return true;
        }

        # region ■ 得意先ガイドボタンクリックイベント ■
        /// <summary>
        /// 得意先ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : 得意先ガイドボタンクリックイベント処理を行います。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/03/08</br>
        /// </remarks>
        private void uButton_CustomerGuide_Click(object sender, EventArgs e)
        {
            // 得意先ガイド用ライブラリ名変更
            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);	// 得意先検索アクセスクラス
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
            DialogResult ret = customerSearchForm.ShowDialog(this);
        }

        /// <summary>
        /// 得意先選択時発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="customerSearchRet">得意先車両検索戻り値クラス</param>
        /// <remarks>
        /// <br>Note       : 得意先選択時発生イベント処理を行います。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/03/08</br>
        /// </remarks>
        private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null)
            {
                return;
            }

            this.NissanInpDisplay.CustomerCode = customerSearchRet.CustomerCode;                    // 得意先コード
            this.NissanInpDisplay.CustomerName = customerSearchRet.Name + customerSearchRet.Name2;   // 得意先名称

            this.tNedit_CustomerCode.SetInt(this.NissanInpDisplay.CustomerCode);
            this.uLabel_CustomerName.Text = this.NissanInpDisplay.CustomerName;

            // 結果
            ((PMKHN04005UA)sender).DialogResult = DialogResult.OK;
        }

        # endregion ■ 得意先ガイドボタンクリックイベント ■

        /// <summary>
        /// 初期フォーカス設定タイマー起動イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 初期フォーカス設定タイマー起動イベント処理を行います。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/03/08</br>
        /// </remarks>
        private void timer_InitialSet_Tick(object sender, EventArgs e)
        {
            this.timer_InitialSet.Enabled = false;

            //-----------------------------------------------------------
            // 日産Web-UOE用連携ファイルのオープン処理
            //-----------------------------------------------------------
            if (_uoeSupplier01521 != null && _uoeSupplier01521.Count > 0)
            {
                // --- UPD 2010/12/31 ---------------->>>>>>>>>>>>>>
                foreach (UOESupplier uoeSupplier in _uoeSupplier01521)
                {
                    if (uoeSupplier.UOESupplierCd == (int)this.tComEd_SupplierCd.Value)
                    {
                        //if (!UOESupplierFileCheck(_uoeSupplier01521[0].AnswerSaveFolder))
                        if (!UOESupplierFileCheck(uoeSupplier.AnswerSaveFolder))
                        {
                            // [検索]ボタンおよび[確定]ボタンを押下不可とします
                            buttonDisFlg = false;
                        }
                        else
                        {
                            buttonDisFlg = true;
                        }
                        break;
                    }
                }
                // --- UPD 2010/12/31 ----------------<<<<<<<<<<<<<
            }

            SetControlFocus(this.tComEd_SupplierCd);

        }

        /// <summary>
        /// ファイル（ストリーム）をクローズ
        /// </summary>
        /// <remarks>
        /// <br>Note       :  ファイル（ストリーム）をクローズする。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/03/08</br>
        /// <br>UpdateNote : 2010/03/18 呉元嘯 Redmine4005対応</br>
        /// <br>UpdateNote : 2010/03/19 呉元嘯 Redmine4032対応</br>
        /// </remarks>
        public void CloseFileStreamU()
        {
            //this._detailInputAcs.CloseFileStream(_detailInputAcs.UoeFileStream);// DEL 2010/03/18
            // -----------UPD 2010/03/19------------>>>>>
            //this._detailInputAcs.CloseFileStream();// ADD 2010/03/18
            this.DetailInputAcs.CloseFileStream();
            // -----------UPD 2010/03/19------------<<<<<
        }

        # region ■ 指定フォーカス設定処理 ■
        /// <summary>
        /// 指定フォーカス設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 指定フォーカス設定処理を行います。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/03/08</br>
        /// </remarks>
        private void SetControlFocus(Control control)
        {
            if (control == null) return;
            if (control.Enabled != true) return;
            if (control.Visible != true) return;
            control.Focus();

            // ガイドボタンツール有効無効設定処理
            this.SettingGuideButtonToolEnabled();
            this.StatusBarMessageSettingProc(control);
        }
        # endregion

        # region ■ ガイドボタンツール有効無効設定処理 ■
        /// <summary>
        /// ガイドボタンツール有効無効設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : ガイドボタンツール有効無効設定処理を行います。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/03/08</br>
        /// <br>UpdateNote : 2010/03/19 呉元嘯 Redmine#032対応</br>
        /// </remarks>
        private void SettingGuideButtonToolEnabled()
        {
            //if (this._detailInputAcs.IsDataChanged == true)// DEL 2010/03/19
            if (this.DetailInputAcs.IsDataChanged == true)// ADD 2010/03/19
            {
                // 検索ボタン
                _searchButton.SharedProps.Enabled = false;
                // 確定ボタン
                this._saveButton.SharedProps.Enabled = true;
            }
            else
            {
                // 検索ボタン
                _searchButton.SharedProps.Enabled = true;
                // 確定ボタン
                this._saveButton.SharedProps.Enabled = false;
            }
            if (this.buttonDisFlg == false)
            {
                // 検索ボタン
                _searchButton.SharedProps.Enabled = false;
                // 確定ボタン
                this._saveButton.SharedProps.Enabled = false;
            }
        }

        # endregion ■ ガイドボタンツール有効無効設定処理 ■

        # region ■ コントロール関連 ■
        /// <summary>
        /// コントロール関連有効無効設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : コントロール関連有効無効設定処理を行います。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/03/08</br>
        /// <br>UpdateNote : 2010/03/19 呉元嘯 Redmine#4032対応</br>
        /// </remarks>
        private void SettingControlEnabled()
        {
            //if (this._detailInputAcs.IsDataChanged == true)// DEL 2010/03/19
            if (this.DetailInputAcs.IsDataChanged == true)// ADD 2010/03/19
            {

                this.tComEd_SupplierCd.Enabled = false;
                this.tComboEditor_TerminalNoDiv.Enabled = false;
                this.tNedit_TerminalNo.Enabled = false;
                this.tComboEditor_TerminalDiv.Enabled = false;
                this.tComboEditor_SysDiv.Enabled = false;
                this.tNedit_St_OnlineNo.Enabled = false;
                this.tNedit_Ed_OnlineNo.Enabled = false;
                this.tDateEdit_InputDateSt.Enabled = false;
                this.tDateEdit_InputDateEd.Enabled = false;
                this.tNedit_CustomerCode.Enabled = false;
                this.uButton_CustomerGuide.Enabled = false;
            }
            else
            {
                this.tComEd_SupplierCd.Enabled = true;
                this.tComboEditor_TerminalNoDiv.Enabled = true;

                //他端末
                if ((Int32)(this.tComboEditor_TerminalNoDiv.Value) == ctTerminalNoDiv_Other)
                {
                    this.tNedit_TerminalNo.Enabled = true;
                }
                //自端末・全端末
                else
                {
                    this.tNedit_TerminalNo.Enabled = false;
                }
                this.tComboEditor_TerminalDiv.Enabled = true;
                this.tComboEditor_SysDiv.Enabled = true;
                this.tNedit_St_OnlineNo.Enabled = true;
                this.tNedit_Ed_OnlineNo.Enabled = true;
                this.tDateEdit_InputDateSt.Enabled = true;
                this.tDateEdit_InputDateEd.Enabled = true;
                this.tNedit_CustomerCode.Enabled = true;
                this.uButton_CustomerGuide.Enabled = true;
            }
        }

        # endregion ■ コントロール関連 ■

        # region ■ 端末区分値変更イベント ■
        /// <summary>
        /// 端末区分値変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : 端末区分値変更イベント処理を行います。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/03/08</br>
        /// </remarks>
        private void tComboEditor_TerminalNoDiv_ValueChanged(object sender, EventArgs e)
        {
            Int32 code = (Int32)this.tComboEditor_TerminalNoDiv.Value;
            if (code == NissanInpDisplay.CashRegisterNoDiv) return;
            NissanInpDisplay.CashRegisterNoDiv = code;

            //端末番号
            switch (NissanInpDisplay.CashRegisterNoDiv)
            {
                //自端末
                case ctTerminalNoDiv_Own:
                    {
                        NissanInpDisplay.CashRegisterNo = _cashRegisterNo;
                        tNedit_TerminalNo.Enabled = false;
                        break;
                    }

                //他端末
                case ctTerminalNoDiv_Other:
                    {
                        NissanInpDisplay.CashRegisterNo = _cashRegisterNo;
                        tNedit_TerminalNo.Enabled = true;
                        break;
                    }
                //全端末
                case ctTerminalNoDiv_All:
                    {
                        NissanInpDisplay.CashRegisterNo = 0;
                        tNedit_TerminalNo.Enabled = false;
                        break;
                    }
            }
            this.tNedit_TerminalNo.SetInt(NissanInpDisplay.CashRegisterNo);
        }
        # endregion ■ 端末区分値変更イベント ■

        #region ■ UOE発注先値変更イベント ■
        /// <summary>
        /// UOE発注先値変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : UOE発注先値変更イベント処理を行います。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/03/08</br>
        /// <br>UpdateNote : 2010/03/18 呉元嘯 Redmine4005対応</br>
        /// <br>UpdateNote : 2010/03/19 呉元嘯 Redmine#4032対応</br>
        /// <br>UpdateNote : 2011/02/25 曹文傑 </br>
        /// <br>             日産UOE自動化、Ｂ対応分の組み込み</br>
        /// </remarks>
        private void tComEd_SupplierCd_ValueChanged(object sender, EventArgs e)
        {
            if (this._bfSupplier == 0) return;

            if (this.tComEd_SupplierCd.Value != null &&
                (int)this.tComEd_SupplierCd.Value != this._bfSupplier)
            {
                // 前回発注先のファイル（ストリーム）をクローズする
                //this._detailInputAcs.CloseFileStream(this._detailInputAcs.UoeFileStream);// DEL 2010/03/18
                // -----------UPD 2010/03/19------------>>>>>
                //this._detailInputAcs.CloseFileStream();// ADD 2010/03/18
                this.DetailInputAcs.CloseFileStream();
                // -----------UPD 2010/03/19------------<<<<<
                PMUOE01521UB._supplierCd = (int)this.tComEd_SupplierCd.Value;
                this._bfSupplier = (int)this.tComEd_SupplierCd.Value;

                // 日産Web-UOE用連携ファイルのオープン処理
                if (_uoeSupplier01521 != null && _uoeSupplier01521.Count > 0)
                {
                    List<UOESupplier> resultList;
                    resultList = _uoeSupplier01521.FindAll(delegate(UOESupplier target)
                    {
                        if (PMUOE01521UB._supplierCd.Equals(target.UOESupplierCd))
                        {
                            return (true);
                        }
                        else
                        {
                            return (false);
                        }
                    });

                    if (resultList != null && resultList.Count > 0)
                    {
                        _uoeSupplier = resultList[0];

                        nissanFlod = resultList[0].AnswerSaveFolder;

                        if (!UOESupplierFileCheck(resultList[0].AnswerSaveFolder))
                        {
                            // [検索]ボタンおよび[確定]ボタンを押下不可とします
                            this._searchButton.SharedProps.Enabled = false;
                            this._saveButton.SharedProps.Enabled = false;
                            this.buttonDisFlg = false;
                        }
                        else
                        {
                            this.buttonDisFlg = true;

                            this._detailInput.CacheUOEGuideName_01521();

                            // 手動の場合、
                            if (key.Equals(resultList[0].CommAssemblyId))
                            {
                                PMUOE01521UB._inqOrdDivCdFlg = 0;
                            }
                            // ---UPD 2011/02/25------------>>>>>
                            //else if (auto_key.Equals(resultList[0].CommAssemblyId))
                            else if (auto_key.Equals(resultList[0].CommAssemblyId)
                                || key205.Equals(resultList[0].CommAssemblyId)
                                || key206.Equals(resultList[0].CommAssemblyId))
                            // ---UPD 2011/02/25------------<<<<<
                            {
                                PMUOE01521UB._inqOrdDivCdFlg = 1;
                            }
                            else
                            {
                                // なし。
                            }
                            
                            //-----------------------------------------------------------
                            // UOE接続先情報マスタ
                            //-----------------------------------------------------------
                            this.CacheUOEConnectInfo(resultList[0].CommAssemblyId); 
                        }
                        this.SettingGuideButtonToolEnabled();
                    }

                }
            }
        }
        #endregion

        # region ■ ツールバーイベント ■
        /// <summary>
        /// ツールバーボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : ツールバーボタンクリックイベント処理を行います。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/03/08</br>
        /// </remarks>
        private void tToolbarsManager_MainMenu_ToolClick(object sender, ToolClickEventArgs e)
        {
            //画面→抽出条件クラス
            NissanInpDisplay = this.GetDisplay();

            switch (e.Tool.Key)
            {
                //終了処理
                case "ButtonTool_Close":
                    {
                        // 終了処理
                        this.Close(true);
                        break;
                    }
                //検索処理
                case "ButtonTool_Search":
                    {
                        //検索処理
                        if (this.CheckSearchCondition() == true)
                        {
                            // システム区分が在庫一括時のみ入力可能とします。
                            if (this.tComboEditor_SysDiv.SelectedIndex == 3)
                            {
                                PMUOE01521UB._countFlg = true;
                            }
                            else
                            {
                                PMUOE01521UB._countFlg = false;
                            }

                            int status = SearchDB(NissanInpDisplay);

                            // ADD 2010/12/31 ------------------------------>>>>>
                            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                            {
                                PMUOE01521UB._dataListFlg = true;
                            }
                            else
                            {
                                PMUOE01521UB._dataListFlg = false;
                            }
                            // ADD 2010/12/31 ------------------------------<<<<<

                            // 明細グリッドセル設定処理
                            this._detailInput.SettingGrid(NissanInpDisplay.BusinessCode);
                            this._detailInput.uGrid_Details.Focus();
                        }
                        break;
                    }
                //確定処理
                case "ButtonTool_Save":
                    {
                        bool isStatus = false;

                        // セル編集後に直接ボタンクリックを行なうとセルの編集が発生しないため
                        if (this._detailInput.uGrid_Details.ActiveCell != null)
                        {
                            this._detailInput.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                        }

                        //取消処理
                        if (NissanInpDisplay.BusinessCode == ctTerminalDiv_Cancel)
                        {
                            isStatus = this.DeleteDB();
                        }
                        //更新処理
                        else
                        {
                            isStatus = this.UpdateDB();
                        }

                        //画面初期化処理
                        if (isStatus)
                        {
                            this.Clear(false, true);
                            this.SetControlFocus(this.tComEd_SupplierCd);
                        }

                        break;
                    }
                //新規処理
                case "ButtonTool_Undo":
                    {
                        bool isSave = this.Clear(true, true);

                        if (isSave)
                        {
                            PMUOE01521UB._countFlg = false;
                            this.SetControlFocus(this.tComEd_SupplierCd);
                        }
                        break;
                    }
            }
        }
        # endregion ■ ツールバーイベント ■
        # endregion
    }
}