//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : マツダ発注処理
// プログラム概要   : マツダ発注処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright 2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10702591-00 作成担当 : 李占川
// 作 成 日  2011/05/18  修正内容 : 新規作成
//                                  マツダWebUOEとの連携用データとして、UOE発注データからマツダ用システム連携アドレスの作成を行う
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 凌小青
// 作 成 日  2011/12/02  修正内容 : Redmine#8304の対応
//----------------------------------------------------------------------------//
using System;
using System.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using System.Collections.Generic;
using Broadleaf.Library.Windows.Forms;
using Infragistics.Win.UltraWinToolbars;
using Broadleaf.Library.Resources;
using System.Collections;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using System.IO;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// マツダ発注処理UIクラス
    /// </summary>
    /// <remarks>
    /// <br>Note        : マツダ発注処理UIフォームクラス</br>
    /// <br>Programmer  : 李占川</br>
    /// <br>Date        : 2011/05/18</br>
    /// </remarks>
    public partial class PMUOE01541UA : Form
    {
        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region Constructors
        /// <summary>
        ///  マツダ発注処理フォームクラス デフォルトコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note        : マツダ発注処理フォームクラス デフォルトコンストラクタ</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2011/05/18</br>
        /// </remarks>
        public PMUOE01541UA()
        {
            InitializeComponent();

            // 変数初期化
            this._detailInput = new PMUOE01541UB();
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
        //マツダ
        private const string key = "0403";
        // アセンブリID
        private const string ASSEMBLY_ID = "PMUOE01541U";
        // 最大明細数
        private const int MAX_DETAILCOUNT = 30;
        // 最大ブロック数
        private const int MAX_BLOCCOUNT = 30;
        // 最大UOE発注行番号
        private const int MAX_UOEORDERDTLNO = 5;
        //マツダ(自動)
        private const string autoKey = "0403";
        # endregion

        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        # region Private Members
        private PMUOE01541UB _detailInput;
        private ImageList _imageList16 = null;                                                // イメージリスト
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;                    // 終了ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _saveButton;                     // 確定ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _retryButton;                    // クリアボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _searchButton;                   // 検索ボタン
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginNameLabel;                  // ログイン担当者名称
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginEmployeeLabel;              // ログイン担当者名称
        private ControlScreenSkin _controlScreenSkin;

        private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        private string _loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;

        private UOESupplierAcs _uoeSupplierAcs;                                     //ＵＯＥ発注先アクセスクラス
        //ＵＯＥ発注先
        private List<UOESupplier> _uoeSupplier01521;
        private UOEConnectInfo _uOEConnectInfo;// UOE接続先情報マスタ
        //得意先マスタ
        private Dictionary<int, CustomerSearchRet> _customerSearchRet;
        //画面入力クラス
        private MazdaInpDisplay _inpDisplay;
        //端末番号
        int _cashRegisterNo;
        //マツダ発注処理アクセスクラス
        private MazdaOrderProcAcs _detailInputAcs;

        private bool buttonDisFlg = true;

        // 前回発注先
        private Int32 _bfSupplier = 0;

        // 画面閉じるフラグ
        private string mitsubishiFlod = string.Empty;
        private UOESupplier _uoeSupplier = null;
        private int inqOrdDivCd = 0;
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
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/05/18</br>
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
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/05/18</br>r>
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
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/05/18</br>
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
                    if (key.Equals(target.CommAssemblyId) || autoKey.Equals(target.CommAssemblyId))
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
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/05/18</br>
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
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        public void CacheEmployee()
        {
            this.DetailInputAcs.CacheEmployee();
        }

        /// <summary>
        /// UOE接続先情報マスタキャッシュ制御処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : UOE接続先情報マスタキャッシュ制御処理を行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        public void CacheUOEConnectInfo()
        {
            try
            {
                //指定された企業コード・通信アセンブリID・レジ番号のUOE接続先情報LISTを全て戻します
                UOEConnectInfoAcs uOEConnectInfoAcs = new UOEConnectInfoAcs();
                UOEConnectInfo uOEConnectInfo = null;
                _uOEConnectInfo = null;
                int status = uOEConnectInfoAcs.Read(out uOEConnectInfo, this._enterpriseCode, _uoeSupplier.CommAssemblyId, _cashRegisterNo);
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
        # endregion 初期データ取得処理

        # region ■ 初期化処理 ■
        /// <summary>
        /// 画面初期化処理
        /// </summary>
        /// <param name="isConfirm">true:確認ダイアログを表示する false:表示しない</param>
        /// <param name="detail">true:全クリア false:明細部クリア</param>
        /// <returns>true:初期化実行 false:初期化未実行</returns>
        /// <remarks>
        /// <br>Note       : 画面初期化処理を行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        private bool Clear(bool isConfirm, bool detail)
        {
            if ((isConfirm) && this.DetailInputAcs.IsDataChanged && this.DetailInputAcs.StockRowExists())
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
            this.DetailInputAcs.IsDataChanged = false;

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
            this._detailInput.ClearHedaerItem();

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
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        private void ComboEditorItemInitialSetting()
        {
            //発注先コード：発注先名称の初期設定処理
            this.tComEd_SupplierCd.Items.Clear();

            for (int i = 0; i < _uoeSupplier01521.Count; i++)
            {
                UOESupplier uoeSupplier = (UOESupplier)_uoeSupplier01521[i];

                object dataValue = (object)uoeSupplier.UOESupplierCd;
                string displayText = uoeSupplier.UOESupplierCd.ToString("000000") + ":" + uoeSupplier.UOESupplierName;
                tComEd_SupplierCd.Items.Add(dataValue, displayText);
            }

            ClearOrderInpDisplay(MazdaInpDisplay);
            SetDisplay(MazdaInpDisplay);
        }
        # endregion ■ コンボエディタアイテム初期設定処理 ■

        # region ■ 画面データ→画面格納処理 ■
        /// <summary>
        /// 画面データクラス→画面格納処理
        /// </summary>
        /// <param name="inpDisplay">在庫一括データオブジェクト</param>
        /// <remarks>
        /// <br>Note       : 画面データクラス→画面格納処理を行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        private void SetDisplay(MazdaInpDisplay inpDisplay)
        {
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
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        private void ClearOrderInpDisplay(MazdaInpDisplay inpDisplay)
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

                PMUOE01541UB._supplierCd = _uoeSupplier01521[0].UOESupplierCd;
                PMUOE01541UB._sectionCode = _loginSectionCode;
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
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        private MazdaInpDisplay GetDisplay()
        {
            MazdaInpDisplay inpDisplay = new MazdaInpDisplay();

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
        private MazdaInpDisplay MazdaInpDisplay
        {
            get
            {
                if (_inpDisplay == null)
                {
                    _inpDisplay = new MazdaInpDisplay();
                }
                return _inpDisplay;
            }
            set
            {
                this._inpDisplay = value;
            }
        }

        /// <summary>マツダ発注処理アクセスクラスのプロパティ</summary>
        private MazdaOrderProcAcs DetailInputAcs
        {
            get
            {
                if (_detailInputAcs == null)
                {
                    _detailInputAcs = MazdaOrderProcAcs.GetInstance();
                }
                return _detailInputAcs;
            }
        }

        # endregion ■ 画面→画面データクラス格納処理 ■

        # region ■ StatusBarメッセージ表示処理 ■
        /// <summary>
        /// StatusBarメッセージ表示処理
        /// </summary>
        /// <param name="nextControl">次のコントロール</param>
        /// <remarks>
        /// <br>Note       : StatusBarメッセージ表示処理を行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/05/18</br>
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
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/05/18</br>
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
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        private void Close(bool isConfirm)
        {
            if ((isConfirm) && this.DetailInputAcs.IsDataChanged && this.DetailInputAcs.StockRowExists())
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
                    this.Close();
                }

            }
            else
            {
                this.Close();
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
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2011/05/18</br>
        /// </remarks>
        private bool CheckSearchCondition()
        {
            string errMsg = "";

            MazdaInpDisplay = this.GetDisplay();

            try
            {
                //発注先
                if (MazdaInpDisplay.UOESupplierCd == 0)
                {
                    errMsg = "発注先が選択されていません。";
                    this.tComEd_SupplierCd.Focus();
                    return (false);
                }

                //端末番号
                if ((MazdaInpDisplay.CashRegisterNoDiv == ctTerminalNoDiv_Other)
                    && (MazdaInpDisplay.CashRegisterNo == 0))
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
                if ((MazdaInpDisplay.SalesDateSt != DateTime.MinValue)
                && (MazdaInpDisplay.SalesDateEd != DateTime.MinValue)
                && (MazdaInpDisplay.SalesDateSt > MazdaInpDisplay.SalesDateEd))
                {
                    errMsg = "入力日付の範囲が不正です。";
                    this.tDateEdit_InputDateSt.Focus();
                    return (false);
                }

                //呼出番号
                if ((MazdaInpDisplay.UOESalesOrderNoSt != 0)
                    && (MazdaInpDisplay.UOESalesOrderNoEd != 0)
                    && (MazdaInpDisplay.UOESalesOrderNoSt > MazdaInpDisplay.UOESalesOrderNoEd))
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
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/05/18</br>
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
        /// <param name="initFlg">初期処理フラグ</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : 発注先ファイルチェックを行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        private bool UOESupplierFileCheck(string folder, bool initFlg)
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
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/05/18</br>
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
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        public int SearchDB(MazdaInpDisplay inpDisplay)
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
                status = this.DetailInputAcs.SearchDB(MazdaInpDisplay, out message);
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
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        private bool UpdateDB()
        {
            bool isSave = false;
            string retMessage = "";
            int status = 0;

            try
            {
                //保存件数のチェック
                if (this.DetailInputAcs.IsDataChanged == false) return (isSave);
                this.Cursor = Cursors.WaitCursor;
                StringBuilder messageBuilder = new StringBuilder();
                if (this.DetailInputAcs.GetDeleteCount() <= 0)
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
                else if (this.DetailInputAcs.GetDeleteCount() > MAX_DETAILCOUNT)
                {
                    messageBuilder.Append("明細合計が" + MAX_DETAILCOUNT + "を超えない様に選択してください。" + "\r\n");

                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        messageBuilder.ToString(),
                        0,
                        MessageBoxButtons.OK);
                    return isSave;
                }

                if (this._detailInput.BoCodeCheck(MazdaInpDisplay.BusinessCode, MazdaInpDisplay.SystemDivCd) != true)
                {
                    StringBuilder message = new StringBuilder();
                    message.Append("未入力の項目が存在するため、確定できません。" + "\r\n" + "\r\n");
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

                if (inqOrdDivCd == 1)
                {
                    this.uLabel_CustomerName.Focus();  // 自動処理時、「tEdit_UoeRemark1_Leave」を行う。
                    ScreenEnableSet(false);
                }

                // UOE発注先マスタの収得
                UOESupplier uOESupplier = GetUOESupplier(MazdaInpDisplay);
                if (!UOESupplierFileCheck(uOESupplier.AnswerSaveFolder, false))
                {
                    return isSave;
                }

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

                if (_uoeSupplier != null && key.Equals(_uoeSupplier.CommAssemblyId))
                {
                    this.DetailInputAcs.SetUOESupplier(_uoeSupplier);
                }

                // 書込処理
                //----------DEL BY 凌小青 on 2011/12/02 for Redmine#8304 ---------->>>>>>>>>>
                //status = this.DetailInputAcs.WriteDB(this._cashRegisterNo, MazdaInpDisplay.SystemDivCd, out retMessage,
                //out uOEOrderDtlWorkList, out stockDetailWorkList, out uOEOrderDtlWorkDelList, out stockDetailWorkDelList);
                //----------DEL BY 凌小青 on 2011/12/02 for Redmine#8304 ----------<<<<<<<<<<
                //----------ADD BY 凌小青 on 2011/12/02 for Redmine#8304 ---------->>>>>>>>>>
                status = this.DetailInputAcs.WriteDB(this._cashRegisterNo, MazdaInpDisplay.SystemDivCd, out retMessage,
                out uOEOrderDtlWorkList, out stockDetailWorkList, out uOEOrderDtlWorkDelList, out stockDetailWorkDelList, ref uOESupplier);
                //----------ADD BY 凌小青 on 2011/12/02 for Redmine#8304 ----------<<<<<<<<<<
                // ダイアログを閉じる
                form.Close();

                //保存処理の実行
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    isSave = true;                    

                    // 明細グリッド設定処理
                    this._detailInput.SettingGrid();
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

            if (inqOrdDivCd == 1)
            {
                ScreenEnableSet(true);
            }

            return isSave;
        }

        /// <summary>
        /// 画面Enable設定処理
        /// </summary>
        /// <param name="enable">enable</param>
        /// <returns>BOOL</returns>
        /// <remarks>
        /// <br>Note       : 画面Enable設定を行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        private void ScreenEnableSet(bool enable)
        {
            this.tToolbarsManager_MainMenu.Enabled = enable;
            this.panel_Header.Enabled = enable;
            this.panel_Detail.Enabled = enable;
        }
        # endregion ■ 保存処理 ■

        # region ■ 削除処理 ■
        /// <summary>
        /// 削除処理
        /// </summary>
        /// <returns>true:削除完了 false:削除失敗</returns>
        /// <remarks>
        /// <br>Note       : 削除処理を行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        bool DeleteDB()
        {
            bool retBool = false;
            int status = 0;
            string message = "";

            try
            {
                //削除件数のチェック
                if (this.DetailInputAcs.IsDataChanged == false) return (retBool);
                if (this.DetailInputAcs.GetDeleteCount() <= 0)
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

                status = this.DetailInputAcs.DeleteDB(out message);

                // ダイアログを閉じる
                form.Close();

                //削除処理の実行
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (this.DetailInputAcs.GetNoSelectCount() > 0)
                    {
                        //再検索
                        this._detailInput.Clear1();
                        SearchDB(MazdaInpDisplay);
                        this._detailInput.SettingGrid(MazdaInpDisplay.BusinessCode);

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
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        private UOESupplier GetUOESupplier(MazdaInpDisplay inpDisplay)
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
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/05/18</br>
        /// <br>UpdateNote : 2011/05/18 李占川 UOE自動化改良</br>
        /// </remarks>
        private void PMUOE01541UA_Load(object sender, EventArgs e)
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
            this._bfSupplier = PMUOE01541UB._supplierCd;

            // クリア処理
            this.Clear(false, false);

            // 指定されたUOE発注先の回答保存フォルダの取得
            if (this._uoeSupplier01521 != null && this._uoeSupplier01521.Count > 0)
            {
                foreach (UOESupplier uoeSupplier in _uoeSupplier01521)
                {
                    if (uoeSupplier.UOESupplierCd == (int)this.tComEd_SupplierCd.Value)
                    {
                        mitsubishiFlod = uoeSupplier.AnswerSaveFolder;
                        _uoeSupplier = uoeSupplier;

                        if (key.Equals(uoeSupplier.CommAssemblyId))
                        {
                            inqOrdDivCd = 0;
                            PMUOE01541UB._inqOrdDivCdFlg = inqOrdDivCd;
                        }
                        else if (autoKey.Equals(uoeSupplier.CommAssemblyId))
                        {
                            inqOrdDivCd = 1;
                            PMUOE01541UB._inqOrdDivCdFlg = inqOrdDivCd;
                        }
                        else
                        {
                            //なし。
                        }
                    }
                }
            }

            // UOE接続先情報マスタの取得
            if (_uoeSupplier != null)
            {
                this.CacheUOEConnectInfo();
            }
            else
            {
                //なし。
            }

            this.timer_InitialSet.Enabled = true;

        }

        /// <summary>
        /// フォーカスコントロールイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : フォーカスコントロールイベント処理を行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            bool canChangeFocus;
            int code;
            if (e.PrevCtrl == null || e.NextCtrl == null) return;
            if (MazdaInpDisplay == null) return;

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
                                            this._detailInput.uGrid_Details.ActiveCell.Selected = false; // ADD 2011/05/18
                                            this._detailInput.uGrid_Details.ActiveCell = null; // ADD 2011/05/18
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
                            MazdaInpDisplay.UOESupplierCd = (Int32)tComEd_SupplierCd.Value;
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
                        MazdaInpDisplay.BusinessCode = (Int32)tComboEditor_TerminalDiv.Value;
                        #endregion
                        break;
                    }

                // 端末区分 ============================================ //
                case "tComboEditor_TerminalNoDiv":
                    #region [ tComboEditor_TerminalNoDiv ]
                    MazdaInpDisplay.CashRegisterNoDiv = (Int32)tComboEditor_TerminalNoDiv.Value;
                    #endregion
                    break;

                // 端末番号 ============================================ //
                case "tNedit_TerminalNo":
                    #region [ tNedit_TerminalNo ]
                    MazdaInpDisplay.CashRegisterNo = this.tNedit_TerminalNo.GetInt();
                    #endregion
                    break;

                // システム区分 ============================================ //
                case "tComboEditor_SysDiv":
                    #region [ tComboEditor_SysDiv ]
                    MazdaInpDisplay.SystemDivCd = (Int32)tComboEditor_SysDiv.Value;
                    #endregion
                    break;

                // オンライン番号(開始） ============================================ //
                case "tNedit_St_OnlineNo":
                    #region [ St_OnlineNo ]
                    MazdaInpDisplay.UOESalesOrderNoSt = tNedit_St_OnlineNo.GetInt();
                    #endregion
                    break;

                // オンライン番号(終了） ============================================ //
                case "tNedit_Ed_OnlineNo":
                    #region [ Ed_OnlineNo ]
                    MazdaInpDisplay.UOESalesOrderNoEd = tNedit_Ed_OnlineNo.GetInt();
                    #endregion
                    break;

                // 入力日（開始） ============================================ //
                case "tDateEdit_InputDateSt":
                    #region [ tDateEdit_InputDateSt ]
                    MazdaInpDisplay.SalesDateSt = tDateEdit_InputDateSt.GetDateTime();
                    #endregion
                    break;

                // 入力日（終了） ============================================ //
                case "tDateEdit_InputDateEd":
                    #region [ tDateEdit_InputDateEd ]
                    MazdaInpDisplay.SalesDateEd = tDateEdit_InputDateEd.GetDateTime();
                    #endregion
                    break;

                // 得意先ｺｰﾄﾞ ============================================ //
                case "tNedit_CustomerCode":
                    #region [ tNedit_CustomerCode ]
                    canChangeFocus = true;
                    code = this.tNedit_CustomerCode.GetInt();

                    if (MazdaInpDisplay.CustomerCode != code)
                    {
                        if (code == 0)
                        {
                            MazdaInpDisplay.CustomerCode = 0;
                            MazdaInpDisplay.CustomerName = "";
                        }
                        else
                        {
                            string customerName = "";
                            if (GetMakerName(code, out customerName) == true)
                            {
                                MazdaInpDisplay.CustomerCode = code;
                                MazdaInpDisplay.CustomerName = customerName;

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
            MazdaInpDisplay InpDisplayNow = this.GetDisplay();
            ArrayList arRetList = MazdaInpDisplay.Compare(InpDisplayNow);

            if (arRetList.Count > 0)
            {
                // 画面情報クラス→画面格納処理
                this.SetDisplay(MazdaInpDisplay);
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
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/05/18</br>
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
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/05/18</br>
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
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null)
            {
                return;
            }

            this.MazdaInpDisplay.CustomerCode = customerSearchRet.CustomerCode;                    // 得意先コード
            this.MazdaInpDisplay.CustomerName = customerSearchRet.Name + customerSearchRet.Name2;   // 得意先名称

            this.tNedit_CustomerCode.SetInt(this.MazdaInpDisplay.CustomerCode);
            this.uLabel_CustomerName.Text = this.MazdaInpDisplay.CustomerName;

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
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        private void timer_InitialSet_Tick(object sender, EventArgs e)
        {
            this.timer_InitialSet.Enabled = false;

            //-----------------------------------------------------------
            // マツダWeb-UOE用連携ファイルのオープン処理
            //-----------------------------------------------------------
            if (_uoeSupplier01521 != null && _uoeSupplier01521.Count > 0)
            {
                foreach (UOESupplier uOESupplier in _uoeSupplier01521)
                {
                    if (uOESupplier.UOESupplierCd == (int)this.tComEd_SupplierCd.Value)
                    {
                        if (!UOESupplierFileCheck(uOESupplier.AnswerSaveFolder, true))
                        {
                            // [検索]ボタンおよび[確定]ボタンを押下不可とします
                            buttonDisFlg = false;
                        }
                        else
                        {
                            buttonDisFlg = true;
                        }
                    }
                }
            }

            SetControlFocus(this.tComEd_SupplierCd);

        }

        # region ■ 指定フォーカス設定処理 ■
        /// <summary>
        /// 指定フォーカス設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 指定フォーカス設定処理を行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/05/18</br>
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
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        private void SettingGuideButtonToolEnabled()
        {
            if (this.DetailInputAcs.IsDataChanged == true)
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
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        private void SettingControlEnabled()
        {
            if (this.DetailInputAcs.IsDataChanged == true)
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
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        private void tComboEditor_TerminalNoDiv_ValueChanged(object sender, EventArgs e)
        {
            Int32 code = (Int32)this.tComboEditor_TerminalNoDiv.Value;
            if (code == MazdaInpDisplay.CashRegisterNoDiv) return;
            MazdaInpDisplay.CashRegisterNoDiv = code;

            //端末番号
            switch (MazdaInpDisplay.CashRegisterNoDiv)
            {
                //自端末
                case ctTerminalNoDiv_Own:
                    {
                        MazdaInpDisplay.CashRegisterNo = _cashRegisterNo;
                        tNedit_TerminalNo.Enabled = false;
                        break;
                    }

                //他端末
                case ctTerminalNoDiv_Other:
                    {
                        MazdaInpDisplay.CashRegisterNo = _cashRegisterNo;
                        tNedit_TerminalNo.Enabled = true;
                        break;
                    }
                //全端末
                case ctTerminalNoDiv_All:
                    {
                        MazdaInpDisplay.CashRegisterNo = 0;
                        tNedit_TerminalNo.Enabled = false;
                        break;
                    }
            }
            this.tNedit_TerminalNo.SetInt(MazdaInpDisplay.CashRegisterNo);
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
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        private void tComEd_SupplierCd_ValueChanged(object sender, EventArgs e)
        {
            if (this._bfSupplier == 0) return;

            if (this.tComEd_SupplierCd.Value != null &&
                (int)this.tComEd_SupplierCd.Value != this._bfSupplier)
            {
                PMUOE01541UB._supplierCd = (int)this.tComEd_SupplierCd.Value;
                this._bfSupplier = (int)this.tComEd_SupplierCd.Value;

                // マツダWeb-UOE用連携ファイルのオープン処理
                if (_uoeSupplier01521 != null && _uoeSupplier01521.Count > 0)
                {
                    List<UOESupplier> resultList;
                    resultList = _uoeSupplier01521.FindAll(delegate(UOESupplier target)
                    {
                        if (PMUOE01541UB._supplierCd.Equals(target.UOESupplierCd))
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
                        mitsubishiFlod = resultList[0].AnswerSaveFolder;
                        _uoeSupplier = resultList[0];

                        this._detailInput.CacheUOEGuideName_01531();

                        if (key.Equals(resultList[0].CommAssemblyId))
                        {
                            inqOrdDivCd = 0;
                            PMUOE01541UB._inqOrdDivCdFlg = inqOrdDivCd;
                        }
                        else if (autoKey.Equals(resultList[0].CommAssemblyId))
                        {
                            inqOrdDivCd = 1;
                            PMUOE01541UB._inqOrdDivCdFlg = inqOrdDivCd;
                        }
                        else
                        {
                            //なし。
                        }

                        // UOE接続先情報マスタの取得
                        if (_uoeSupplier != null)
                        {
                            this.CacheUOEConnectInfo();
                        }
                        else
                        {
                            //なし。
                        }

                        if (!UOESupplierFileCheck(resultList[0].AnswerSaveFolder, true))
                        {
                            // [検索]ボタンおよび[確定]ボタンを押下不可とします
                            this._searchButton.SharedProps.Enabled = false;
                            this._saveButton.SharedProps.Enabled = false;
                            this.buttonDisFlg = false;
                        }
                        else
                        {
                            this.buttonDisFlg = true;
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
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        private void tToolbarsManager_MainMenu_ToolClick(object sender, ToolClickEventArgs e)
        {
            //画面→抽出条件クラス
            MazdaInpDisplay = this.GetDisplay();

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
                                PMUOE01541UB._countFlg = true;
                            }
                            else
                            {
                                PMUOE01541UB._countFlg = false;
                            }

                            int status = SearchDB(MazdaInpDisplay);
                            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                            {
                                PMUOE01541UB._searchNoDateFlg = true;
                            }
                            // 明細グリッドセル設定処理
                            this._detailInput.SettingGrid(MazdaInpDisplay.BusinessCode);
                            PMUOE01541UB._searchNoDateFlg = false;
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
                        if (MazdaInpDisplay.BusinessCode == ctTerminalDiv_Cancel)
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
                            PMUOE01541UB._countFlg = false;
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