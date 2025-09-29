//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : マスタ送受信処理
// プログラム概要   : データセンターに対して追加・更新処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 作 成 日  2009/04/01  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 修 正 日  2009/06/16  修正内容 : PVCS票#172マスタ送受信処理の抽出件数について
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 修 正 日  2009/06/17  修正内容 : PVCS票#161 抽出対象データが存在しない場合のログについて 
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 修 正 日  2009/07/06  修正内容 : マスタ送受信処理のＡＰＰロックについて
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 馮文雄
// 修 正 日  2011/07/25  修正内容 : SCM対応-拠点管理（10704767-00）
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 馮文雄
// 修 正 日  2011/08/19  修正内容 : #23817 データ送信画面のFormatExceptionについて
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 孫東響
// 修 正 日  2011/08/23  修正内容 : #23890 受信データがない場合について
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 孫東響
// 修 正 日  2011/08/27  修正内容 : #23922 受信処理で対象外の項目も受信されてしまいます。
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 孫東響
// 修 正 日  2011/08/29  修正内容 : #23934 条件送信の開始日付時間・終了日付時間の初期値について
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 孫東響
// 修 正 日  2011/08/30  修正内容 : #24191 送信処理中 選択したマスタにだけチェックがついた状態に修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 梁森東
// 修 正 日  2011/09/05  修正内容 : Redmine #23936送受信関連の拠点ガイドについての対応
//----------------------------------------------------------------------------//
// 管理番号              修正担当 : 孫東響
// 修 正 日  2011/09/05  修正内容 : #24047 送信失敗時の対処について
//----------------------------------------------------------------------------//
// 管理番号              修正担当 : 孫東響
// 修 正 日  2011/09/14  修正内容 : #24542 拠点選択について
//----------------------------------------------------------------------------//
// 管理番号              修正担当 : FSI菅原 庸平
// 修 正 日  2012/07/26  修正内容 : 抽出条件区分に従業員、ユーザーガイド(販売区分)、結合を追加
//----------------------------------------------------------------------------//
// 管理番号  11770021-00 作成担当 : 陳艶丹
// 作 成 日  2021/04/12  修正内容 : 得意先メモ情報の追加
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Controller;
using Infragistics.Win.UltraWinGrid;
using System.IO;
using Broadleaf.Application.Resources;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// マスタ送受信処理
    /// </summary>
    /// <remarks>
    /// Note       : マスタ送受信処理です。<br />
    /// Programmer : 譚洪<br />
    /// Date       : 2009.04.02<br />
    /// <br>Update Note: 2021/04/12 陳艶丹</br>
    /// <br>管理番号   : 11770021-00</br>
    /// <br>           : PMKOBETSU-4136 得意先メモ情報の追加</br>
    /// </remarks>
    public partial class PMKYO01201UA : Form
    {

        #region ■ Const Memebers ■
        private const string PROGRAM_ID = "PMKYO01201UA";
        private const string ALL_SECTIONCODE = "00"; //ADD 2011/07/25
        private const string ERROR_BATU = "×";
        private static readonly string ctTableName_DataReceiveResult = "DataReceiveResult";
        private const string PROGRAM_NAME = "マスタ送受信処理";
        private const string MST_SECINFOSET = "拠点設定マスタ";
        private const string MST_SUBSECTION = "部門設定マスタ";
        private const string MST_WAREHOUSE = "倉庫設定マスタ";
        private const string MST_EMPLOYEE = "従業員設定マスタ";
        private const string MST_USERGDAREADIVU = "ユーザーガイドマスタ(販売エリア区分）";
        private const string MST_USERGDBUSDIVU = "ユーザーガイドマスタ（業務区分）";
        private const string MST_USERGDCATEU = "ユーザーガイドマスタ（業種）";
        private const string MST_USERGDBUSU = "ユーザーガイドマスタ（職種）";
        private const string MST_USERGDGOODSDIVU = "ユーザーガイドマスタ（商品区分）";
        private const string MST_USERGDCUSGROUPU = "ユーザーガイドマスタ（得意先掛率グループ）";
        private const string MST_USERGDBANKU = "ユーザーガイドマスタ（銀行）";
        private const string MST_USERGDPRIDIVU = "ユーザーガイドマスタ（価格区分）";
        private const string MST_USERGDDELIDIVU = "ユーザーガイドマスタ（納品区分）";
        private const string MST_USERGDGOODSBIGU = "ユーザーガイドマスタ（商品大分類）";
        private const string MST_USERGDBUYDIVU = "ユーザーガイドマスタ（販売区分）";
        private const string MST_USERGDSTOCKDIVOU = "ユーザーガイドマスタ（在庫管理区分１）";
        private const string MST_USERGDSTOCKDIVTU = "ユーザーガイドマスタ（在庫管理区分２）";
        private const string MST_USERGDRETURNREAU = "ユーザーガイドマスタ（返品理由）";
        private const string MST_RATEPROTYMNG = "掛率優先管理マスタ";
        private const string MST_RATE = "掛率マスタ";
        private const string MST_SALESTARGET = "売上目標設定マスタ";
        private const string MST_CUSTOME = "得意先マスタ";
        private const string MST_SUPPLIER = "仕入先マスタ";
        private const string MST_JOINPARTSU = "結合マスタ";
        private const string MST_GOODSSET = "セットマスタ";
        private const string MST_TBOSEARCHU = "ＴＢＯマスタ";
        private const string MST_MODELNAMEU = "車種マスタ";
        private const string MST_BLGOODSCDU = "ＢＬコードマスタ";
        private const string MST_MAKERU = "メーカーマスタ";
        private const string MST_GOODSMGROUPU = "商品中分類マスタ";
        private const string MST_BLGROUPU = "グループコードマスタ";
        private const string MST_BLCODEGUIDE = "BLコードガイドマスタ";
        private const string MST_GOODSU = "商品マスタ";
        private const string MST_STOCK = "在庫マスタ";
        private const string MST_PARTSSUBSTU = "代替マスタ";
        private const string MST_PARTSPOSCODEU = "部位マスタ";

        //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
        private const string FILEID_CUSTOMER = "CustomerRF";
        private const string FILEID_GOODS = "GoodsURF";
        private const string FILEID_STOCK = "StockRF";
        private const string FILEID_SUPPLIER = "SupplierRF";
        private const string FILEID_RATE = "RateRF";
        // --- ADD 2012/07/26 ---------------------------->>>>>
        private const string FILEID_EMPLOYEE = "EmployeeDtlRF";
        private const string FILEID_JOINPARTSU = "JoinPartsURF";
        private const string FILEID_USERGDU = "UserGdBdURF";
        // --- ADD 2012/07/26 ----------------------------<<<<<
        //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
        private const string UI_XML_NAME = "PMKYO01201U_SectionSetting.xml";//ADD 2011/09/14 sundx #24542 拠点選択について
        #endregion ■ Const Memebers ■

        # region ■ private field ■

        private ImageList _imageList16 = null;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _updateButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _clearButton;
        //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
        private Infragistics.Win.UltraWinToolbars.ButtonTool _extractDetailButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _settingButton;
        private Infragistics.Win.UltraWinToolbars.PopupMenuTool _detailButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _custDetailButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _suppDetailButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _goodsDetailButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _stockDetailButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _rateDetailButton;
        // --- ADD 2012/07/26 --------------------------------------------------------->>>>>
        private Infragistics.Win.UltraWinToolbars.ButtonTool _employeeDetailButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _joinPartsUrateDetailButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _userGdBuyDivUrateDetailButton;
        // --- ADD 2012/07/26 ---------------------------------------------------------<<<<<
        //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
        private Infragistics.Win.UltraWinToolbars.LabelTool _LoginTitleLabel;
        private ControlScreenSkin _controlScreenSkin;
        // 送信情報データテーブル
        private UpdateResultDataSet.UpdateResultDataTable _updateResultDataTable;
        // 送信条件データテーブル
        private ExtractionConditionDataSet.ExtractionConditionDataTable _extractionConditionDataTable;
        // 受信情報データテーブル
        private ReceiveInfoDataSet.ReceiveInfoDataTable _receiveInfoDataTable;
        // 受信条件データテーブル
        private ReceiveConditionDataSet.ReceiveConditionDataTable _receiveConditionDataTable;
        private MstUpdCountAcs _mstUpdCountAcs;
        private static readonly Color DISABLE_COLOR = Color.Gainsboro;
        private static readonly Color DISABLE_FONT_COLOR = Color.Black;
        private string _loginName = LoginInfoAcquisition.Employee.Name;
        private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        private string _loginEmplooyCode = LoginInfoAcquisition.Employee.EmployeeCode;
        private DateTime _startTime = new DateTime();
        private ArrayList _secMngSetArrList = new ArrayList();
        private string _baseCode = string.Empty;
        private ArrayList masterNameList = new ArrayList();
        private ArrayList masterDivList = new ArrayList();
        private ArrayList masterDtlDivList = new ArrayList();
        private ArrayList baseCodeNameList = new ArrayList();
        // デフォルト行の外観設定
        Infragistics.Win.Appearance _defRowAppearance = new Infragistics.Win.Appearance();
        // 選択時の行外観設定
        private readonly Color _selBackColor = Color.FromArgb(251, 230, 148);
        private readonly Color _selBackColor2 = Color.FromArgb(238, 149, 21);
        private int _connectPointDiv = 0;
        private ReceiveInfoDataSet _receiveDataSet;
        private DataTable _receiveInfoTable;
        private Control _prevControl = null;
        private DateTime _preDataTime = DateTime.MinValue;
        //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
        private string _loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
        private string _preSectionCode;
        private ArrayList sendDestSecList = new ArrayList();
        private ArrayList selectMstNameList = new ArrayList();
        private ArrayList selectMstDivList = new ArrayList();
        private ArrayList selectMstDtlDivList = new ArrayList();
        private ArrayList selectbaseCodeNameList = new ArrayList();
        private ArrayList _sndRcvHisList = new ArrayList();
        private ArrayList _sndRcvEtrList = new ArrayList();
        private ContextMenu _contextMenu;
        private APSupplierProcParamWork _supplierProcParam; //仕入先マスタ抽出条件
        private APCustomerProcParamWork _customerProcParam; //得意先マスタ抽出条件
        private APGoodsProcParamWork _goodsProcParam; //商品マスタ抽出条件
        private APStockProcParamWork _stockProcParam; //在庫マスタ抽出条件
        private APRateProcParamWork _rateProcParam; //掛率マスタ抽出条件
        // --- ADD 2012/07/26 ------------------------->>>>>
        private APEmployeeProcParamWork _employeeProcParam; // 従業員設定マスタ抽出条件
        private APJoinPartsUProcParamWork _joinPartsUProcParam; // 結合マスタ抽出条件
        private APUserGdBuyDivUProcParamWork _userGdBuyDivUProcParam; // ユーザーガイドマスタ（販売区分）抽出条件
        // --- ADD 2012/07/26 -------------------------<<<<<
        private Dictionary<string, SndRcvEtrWork> sndRcvEtrDic = new Dictionary<string, SndRcvEtrWork>();
        //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
        private DataSet _uiDataSet;//ADD 2011/09/14 sundx #24542 拠点選択について
        private string _initSecCode = "00";//ADD 2011/09/14 sundx #24542 拠点選択について

        # endregion ■ private field ■

        #region  ■ ボタン初期設定処理 ■
        /// <summary>
        /// ボタン初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : ボタン初期設定処理です。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.26</br>
        /// </remarks>
        private void ButtonInitialSetting()
        {
            this.tToolsManager_MainMenu.ImageListSmall = this._imageList16;
            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this._updateButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
            this._clearButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;
            //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
            this._extractDetailButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DETAILS;
            this._settingButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DETAILS2;
            this._detailButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DETAILS;
            //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
            this._LoginTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;

        }
        # endregion ■ ボタン初期設定処理 ■

        # region ■ コンストラクタ ■
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public PMKYO01201UA()
        {
            InitializeComponent();
            // 変数初期化
            this._imageList16 = IconResourceManagement.ImageList16;
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Close"];
            this._updateButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Update"];
            this._clearButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Clear"];
            //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
            this._extractDetailButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_ExtractDetail"];
            this._settingButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Setting"];
            this._detailButton = (Infragistics.Win.UltraWinToolbars.PopupMenuTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Detail"];
            this._custDetailButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Customer"];
            this._suppDetailButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Supplier"];
            this._goodsDetailButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Goods"];
            this._stockDetailButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Stock"];
            this._rateDetailButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Rate"];
            // --- ADD 2012/07/26 ------------------------------------------------------------------------------------------------------------------------>>>>>
            this._employeeDetailButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Employee"];
            this._joinPartsUrateDetailButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_JoinPartsU"];
            this._userGdBuyDivUrateDetailButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_UserGdBuyDivU"];
            // --- ADD 2012/07/26 ------------------------------------------------------------------------------------------------------------------------<<<<<
            this._preSectionCode = string.Empty;
            _supplierProcParam = new APSupplierProcParamWork();
            _customerProcParam = new APCustomerProcParamWork();
            _goodsProcParam = new APGoodsProcParamWork();
            _stockProcParam = new APStockProcParamWork();
            _rateProcParam = new APRateProcParamWork();
            // --- ADD 2012/07/26 ------------------------->>>>>
            _employeeProcParam = new APEmployeeProcParamWork();
            _joinPartsUProcParam = new APJoinPartsUProcParamWork();
            _userGdBuyDivUProcParam = new APUserGdBuyDivUProcParamWork();
            // --- ADD 2012/07/26 -------------------------<<<<<
            this.SectionGuide_Button.Appearance.Image = _imageList16.Images[(int)Size16_Index.STAR1];
            //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
            this._LoginTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolsManager_MainMenu.Tools["LabelTool_LoginTitle"];
            this._controlScreenSkin = new ControlScreenSkin();
            this._mstUpdCountAcs = MstUpdCountAcs.GetInstance();
            this._updateResultDataTable = this._mstUpdCountAcs.UpdateResultDataTable;
            this._extractionConditionDataTable = this._mstUpdCountAcs.ExtractionConditionDataTable;
            this._receiveInfoDataTable = this._mstUpdCountAcs.ReceiveInfoDataTable;
            this._receiveConditionDataTable = this._mstUpdCountAcs.ReceiveConditionDataTable;
        }
        # endregion ■ コンストラクタ ■

        # region ■ フォームロード ■
        /// <summary>
        /// 画面の処理化処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>   
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>		
        /// <br>Note		: 画面の処理化を行う。</br>
        /// <br>Programmer	: 譚洪</br>	
        /// <br>Date		: 2009.04.26</br>
        /// </remarks>
        private void PMKYO01201UA_Load(object sender, EventArgs e)
        {
            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);

            this.ButtonInitialSetting();

            if (_receiveDataSet == null)
            {
                // 更新テーブル設定
                _receiveDataSet = new ReceiveInfoDataSet();
                _receiveDataSet.Tables.Add(new DataTable(ctTableName_DataReceiveResult));
                this._receiveInfoTable = _receiveDataSet.Tables[ctTableName_DataReceiveResult];
            }


            // 送受信区分
            this.tce_SendAndReceKubun.SelectedIndex = 0;
            //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
            //抽出条件区分
            this.tce_ExtractCondDiv.SelectedIndex = 0;
            //ADD 2011/09/14 sundx #24542 拠点選択について--------------------------------->>>>>
            InitSecCode();
            _initSecCode = this.tEdit_SectionCode.DataText.PadLeft(2, '0');
            //ADD 2011/09/14 sundx #24542 拠点選択について---------------------------------<<<<<
            //送信先拠点
            if (this.Condition_Grid.Rows.Count > 0)
            {
				this.Condition_Grid.ActiveCell = this.Condition_Grid.Rows[0].Cells[this._extractionConditionDataTable.SendDestCondColumn.ColumnName];
                this.ultraTabControl1.SelectedTab = this.ultraTabControl1.Tabs["updateTab"];
            }

            _contextMenu = this.BCondition_Grid.ContextMenu;
            //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<

            // ログイン担当者の設定
            Infragistics.Win.UltraWinToolbars.LabelTool loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolsManager_MainMenu.Tools["LabelTool_LoginName"];
            loginNameLabel.SharedProps.Caption = _loginName;

			//-----DEL 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
			//if (0 != this.Condition_Grid.Rows.Count)
			//{
			//    this.Condition_Grid.ActiveCell = this.Condition_Grid.Rows[0].Cells[this._extractionConditionDataTable.BeginningDateColumn.ColumnName];
			//}
			//-----DEL 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
            this.timer_InitialSetFocus.Enabled = true;
        }
        # endregion ■ フォームロード ■

        # region ■ 画面設定ファイル処理 ADD sundx #24542 拠点選択について ■
        /// <summary>
        /// 前次選択の拠点コードを取得
        /// </summary>
        /// <returns>拠点コード</returns>
        public string GetSection()
        {
            string secCode = string.Empty;
            try
            {
                string fileName = Path.Combine(ConstantManagement_ClientDirectory.UISettings, UI_XML_NAME);

                if (UserSettingController.ExistUserSetting(fileName))
                {
                    if (_uiDataSet == null)
                    {
                        _uiDataSet = new DataSet();
                    }

                    _uiDataSet.ReadXml(Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, fileName));
                    secCode = _uiDataSet.Tables[0].Rows[0][0].ToString();
                }
            }
            catch { }
            return secCode;
        }
        /// <summary>
        /// 選択した拠点コードをXMLファイルに保存
        /// </summary>
        /// <param name="secCode">拠点コード</param>
        /// <returns>ステータス</returns>
        public int SetSecCode(string secCode)
        {
            int status = 0;
            try
            {
                if (!string.IsNullOrEmpty(secCode))
                {
                    string fileName = Path.Combine(ConstantManagement_ClientDirectory.UISettings, UI_XML_NAME);
                    fileName = Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, fileName);
                    if (_uiDataSet == null)
                    {
                        _uiDataSet = new DataSet();                        
                    }
                    if (_uiDataSet.Tables.Count == 0)
                    {
                        DataTable dt = new DataTable("Section");
                        DataColumn col = new DataColumn("SecCode", typeof(string));
                        dt.Columns.Add(col);
                        _uiDataSet.Tables.Add(dt);
                    }
                    _uiDataSet.Tables[0].Clear();
                    DataRow row = _uiDataSet.Tables[0].NewRow();
                    row[0] = secCode;
                    _uiDataSet.Tables[0].Rows.Add(row);
                    _uiDataSet.WriteXml(fileName);
                }
            }
            catch
            {
                status = 1000;
            }
            return status;
        }
        /// <summary>
        /// 拠点初期化
        /// </summary>
        private void InitSecCode()
        {
            try
            {
                string secCode = GetSection();
                if (string.IsNullOrEmpty(secCode) || "".Equals(secCode.Trim()))
                {
                    return;
                }
                if (string.Empty.Equals(GetSectionName(secCode.Trim())))
                {
                    this.tEdit_SectionCode.DataText = this._preSectionCode;
                }
                else
                {
                    this.tEdit_SectionCode.DataText = secCode.Trim();
                    this.tEdit_SectionName.DataText = GetSectionName(secCode.Trim());
                    this._preSectionCode = secCode.Trim();
                    ResetGridCol();
                }                
            }
            finally
            { }
        }
        # endregion ■ 画面設定ファイル処理 ■

        # region ■ 画面初期化後イベント ■
        /// <summary>
        /// 画面初期化後イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note		: 画面初期化後イベント処理発生します。</br>
        /// <br>Programmer	: 譚洪</br>
        /// <br>Date		: 2009.04.30</br>
        /// </remarks>
        private void timer_InitialSetFocus_Tick(object sender, EventArgs e)
        {
            this.timer_InitialSetFocus.Enabled = false;

            this.tce_SendAndReceKubun.Select();
            this.tce_SendAndReceKubun.Focus();
            // 接続先チェック処理
            string errMsg = null;
            if (!_mstUpdCountAcs.CheckConnect(_enterpriseCode, out _connectPointDiv, out errMsg))
            {
                this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, errMsg, 0);
                return;
            }
        }
        #endregion

        # region ■ マスタ送信メッソド関連 ■

        # region ■ 送信グリッド列初期設定処理 ■
        /// <summary>
        /// 送信情報グリッド列初期設定処理
        /// </summary>
        /// <remarks>		
        /// <br>Note		: 送信情報グリッド初期設定処理を行う。</br>
        /// <br>Programmer	: 譚洪</br>	
        /// <br>Date		: 2009.04.02</br>
        /// </remarks>
        private void InitialAccSettingGridCol()
        {
            this.Acc_Grid.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;

            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.Acc_Grid.DisplayLayout.Bands[0];
            if (editBand == null) return;

            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in editBand.Columns)
            {
                //「No列」以外の全てのセルのDiabledColorを設定する。
                if (col.Key != this._updateResultDataTable.RowNoColumn.ColumnName)
                {
                    col.CellAppearance.BackColorDisabled = DISABLE_COLOR;
                    col.CellAppearance.ForeColorDisabled = DISABLE_FONT_COLOR;
                }
            }

            this.Acc_Grid.DisplayLayout.Override.HeaderAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.Acc_Grid.DisplayLayout.Appearance.FontData.SizeInPoints = 11F;

            // Filter設定
            this.Acc_Grid.DisplayLayout.Bands[0].Columns[this._updateResultDataTable.RowNoColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            this.Acc_Grid.DisplayLayout.Bands[0].Columns[this._updateResultDataTable.ExtractionDataColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            this.Acc_Grid.DisplayLayout.Bands[0].Columns[this._updateResultDataTable.ExtractionCountColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

            // 表示幅設定
            //this.Acc_Grid.DisplayLayout.Bands[0].Columns[this._updateResultDataTable.RowNoColumn.ColumnName].Width = 15; //DEL 2011/07/25
            //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
            this.Acc_Grid.DisplayLayout.Bands[0].Columns[this._updateResultDataTable.RowNoColumn.ColumnName].Width = 30;
            this.Acc_Grid.DisplayLayout.Bands[0].Columns[this._updateResultDataTable.SendDestColumn.ColumnName].Width = 40;
            this.Acc_Grid.DisplayLayout.Bands[0].Columns[this._updateResultDataTable.ExtractionDataColumn.ColumnName].Width = 350;
            //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
            //this.Acc_Grid.DisplayLayout.Bands[0].Columns[this._updateResultDataTable.ExtractionDataColumn.ColumnName].Width = 300; //DEL 2011/07/25
            this.Acc_Grid.DisplayLayout.Bands[0].Columns[this._updateResultDataTable.ExtractionCountColumn.ColumnName].Width = 100;


            // 固定列設定
            this.Acc_Grid.DisplayLayout.Bands[0].Columns[this._updateResultDataTable.SendDestColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;//ADD 2011/07/25
            this.Acc_Grid.DisplayLayout.Bands[0].Columns[this._updateResultDataTable.RowNoColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            this.Acc_Grid.DisplayLayout.Bands[0].Columns[this._updateResultDataTable.ExtractionDataColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            this.Acc_Grid.DisplayLayout.Bands[0].Columns[this._updateResultDataTable.ExtractionCountColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;

            this.Acc_Grid.DisplayLayout.Bands[0].Columns[this._updateResultDataTable.RowNoColumn.ColumnName].Header.Fixed = false;
            this.Acc_Grid.DisplayLayout.Bands[0].Columns[this._updateResultDataTable.ExtractionDataColumn.ColumnName].Header.Fixed = false;
            this.Acc_Grid.DisplayLayout.Bands[0].Columns[this._updateResultDataTable.ExtractionCountColumn.ColumnName].Header.Fixed = false;

            // CellAppearance設定
            this.Acc_Grid.DisplayLayout.Bands[0].Columns[this._updateResultDataTable.RowNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.Acc_Grid.DisplayLayout.Bands[0].Columns[this._updateResultDataTable.ExtractionDataColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.Acc_Grid.DisplayLayout.Bands[0].Columns[this._updateResultDataTable.ExtractionCountColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

            // 入力許可設定
            this.Acc_Grid.DisplayLayout.Bands[0].Columns[this._updateResultDataTable.RowNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            this.Acc_Grid.DisplayLayout.Bands[0].Columns[this._updateResultDataTable.SendDestColumn.ColumnName].CellClickAction = CellClickAction.CellSelect; //ADD 2011/07/25
            this.Acc_Grid.DisplayLayout.Bands[0].Columns[this._updateResultDataTable.SendDestColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit; //ADD 2011/07/25
            this.Acc_Grid.DisplayLayout.Bands[0].Columns[this._updateResultDataTable.ExtractionDataColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.Acc_Grid.DisplayLayout.Bands[0].Columns[this._updateResultDataTable.ExtractionCountColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            // Style設定
            this.Acc_Grid.DisplayLayout.Bands[0].Columns[this._updateResultDataTable.RowNoColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            this.Acc_Grid.DisplayLayout.Bands[0].Columns[this._updateResultDataTable.SendDestColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox; //ADD 2011/07/25
            this.Acc_Grid.DisplayLayout.Bands[0].Columns[this._updateResultDataTable.ExtractionDataColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            this.Acc_Grid.DisplayLayout.Bands[0].Columns[this._updateResultDataTable.ExtractionCountColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;

            //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
            //Hidden列設定
            this.Acc_Grid.DisplayLayout.Bands[0].Columns[this._updateResultDataTable.ExtractionCountColumn.ColumnName].Hidden = true;
            //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
        }

        /// <summary>
        /// 送信条件グリッド列初期設定処理
        /// </summary>
        /// <remarks>		
        /// <br>Note		: グリッド初期設定処理を行う。</br>
        /// <br>Programmer	: 譚洪</br>	
        /// <br>Date		: 2009.04.02</br>
        /// </remarks>
        private void InitialConSettingGridCol()
        {

            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.Condition_Grid.DisplayLayout.Bands[0];
            if (editBand == null) return;

            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in editBand.Columns)
            {
                //「No列」以外の全てのセルのDiabledColorを設定する。
                if (col.Key != this._extractionConditionDataTable.BaseCodeColumn.ColumnName)
                {
                    col.CellAppearance.BackColorDisabled = DISABLE_COLOR;
                    col.CellAppearance.ForeColorDisabled = DISABLE_FONT_COLOR;
                }
            }

            // Filter設定
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BaseCodeColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BaseNameColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BeginningDateColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BeginningTimeColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.EndDateColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.EndTimeColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

            // 表示幅設定
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BaseCodeColumn.ColumnName].Width = 50;
            //-----DEL 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
            //this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BaseNameColumn.ColumnName].Width = 130;
            //this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BeginningDateColumn.ColumnName].Width = 60;
            //this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BeginningTimeColumn.ColumnName].Width = 50;
            //this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.EndDateColumn.ColumnName].Width = 60;
            //this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.EndTimeColumn.ColumnName].Width = 50;
            //-----DEL 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
            //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.SendDestCondColumn.ColumnName].Width = 30;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BaseNameColumn.ColumnName].Width = 200;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BeginningDateColumn.ColumnName].Width = 120;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BeginningTimeColumn.ColumnName].Width = 100;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.EndDateColumn.ColumnName].Width = 120;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.EndTimeColumn.ColumnName].Width = 100;
            //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<


            // 固定列設定
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BaseCodeColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BaseNameColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BeginningDateColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BeginningTimeColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.EndDateColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.EndTimeColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;

            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BaseCodeColumn.ColumnName].Header.Fixed = false;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BaseNameColumn.ColumnName].Header.Fixed = false;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BeginningDateColumn.ColumnName].Header.Fixed = false;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BeginningTimeColumn.ColumnName].Header.Fixed = false;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.EndDateColumn.ColumnName].Header.Fixed = false;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.EndTimeColumn.ColumnName].Header.Fixed = false;

            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.SendDestCondColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;//ADD 2011/07/25
			this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BaseNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;//ADD 2011/07/25
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BeginningDateColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BeginningTimeColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.EndDateColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.EndTimeColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;

            // CellAppearance設定
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BaseCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BaseNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BeginningDateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BeginningTimeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.EndDateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.EndTimeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;

            // 入力許可設定
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BaseCodeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.SendDestCondColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;//ADD 2011/07/25
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BaseNameColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BeginningDateColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BeginningTimeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.EndDateColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.EndTimeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;

            // Style設定
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BaseCodeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.SendDestCondColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;//ADD 2011/07/25
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BaseNameColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BeginningDateColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Date;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BeginningTimeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.EndDateColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Date;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.EndTimeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;

            //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
            //Hidden列設定
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BaseCodeColumn.ColumnName].Hidden = true;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.InitBeginningDateColumn.ColumnName].Hidden = true;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.InitBeginningTimeColumn.ColumnName].Hidden = true;
            //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
        }

        # endregion ■ 送信グリッド列初期設定処理 ■

        /// <summary>
        /// 送信シンク実行日付設定処理
        /// </summary>
        /// <remarks>		
        /// <br>Note		: 送信シンク実行日付設定処理設定処理を行う。</br>
        /// <br>Programmer	: 譚洪</br>	
        /// <br>Date		: 2009.04.02</br>
        /// </remarks>
        private void SearchSyncExecDate()
        {
            if (!_mstUpdCountAcs.CheckOnline())
            {
                TMsgDisp.Show(
                emErrorLevel.ERR_LEVEL_STOP,
                this.Text,
                this.Text + "画面初期化処理に失敗しました。",
                (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                return;
            }

            //int status = _mstUpdCountAcs.LoadSyncExecDate(_enterpriseCode, out _startTime, out baseCodeNameList);//DEL 2011/07/25
            int status = _mstUpdCountAcs.LoadSyncExecDate(_enterpriseCode, out _startTime, out baseCodeNameList, 1);//ADD 2011/07/25
        }

        /// <summary>
        /// 送信マスタ名称設定設定
        /// </summary>
        /// <remarks>		
        /// <br>Note		: 送信マスタ名称設定処理を行う。</br>
        /// <br>Programmer	: 譚洪</br>	
        /// <br>Date		: 2009.04.02</br>
        /// </remarks>
        private void SearchMasterName()
        {
            if (!_mstUpdCountAcs.CheckOnline())
            {
                TMsgDisp.Show(
                emErrorLevel.ERR_LEVEL_STOP,
                this.Text,
                this.Text + "画面初期化処理に失敗しました。",
                (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                return;
            }
            // 送信マスタ名称を取得する。
            int status = _mstUpdCountAcs.LoadMstName(_enterpriseCode, out masterNameList);
        }

        /// <summary>
        /// 送信マスタ区分設定設定
        /// </summary>
        /// <remarks>		
        /// <br>Note		: 送信マスタ区分設定処理を行う。</br>
        /// <br>Programmer	: 譚洪</br>	
        /// <br>Date		: 2009.04.02</br>
        /// </remarks>
        private void SearchMasterDoDiv()
        {
            int status = _mstUpdCountAcs.LoadMstDoDiv(_enterpriseCode, out masterDivList);
        }

        /// <summary>
        /// 送信情報グリッド設定処理
        /// </summary>
        /// <remarks>		
        /// <br>Note		: 送信情報グリッド設定処理を行う。</br>
        /// <br>Programmer	: 譚洪</br>	
        /// <br>Date		: 2009.04.02</br>
        /// </remarks>
        private void InitialAccDataGridCol()
        {
            UpdateResultDataSet.UpdateResultRow row = null;
            int rowNo = 0;
            foreach (SecMngSndRcvWork work in masterNameList)
            {
                //-----DEL 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
                //rowNo = rowNo + 1;
                //row = _updateResultDataTable.NewUpdateResultRow();
                //row.RowNo = rowNo;
                //row.ExtractionData = work.MasterName;
                //row.ExtractionCount = string.Empty;
                //_updateResultDataTable.Rows.Add(row);
                //-----DEL 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
                //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
                //送信先拠点リストを作成する
                if (ALL_SECTIONCODE.Equals(this.tEdit_SectionCode.DataText.Trim()))
                {
                    this.sendDestSecList = baseCodeNameList;
                }
                else if (string.Empty.Equals(this.tEdit_SectionCode.DataText.Trim()))
                {
                    this.sendDestSecList = new ArrayList();
                }
                else
                {
                    this.sendDestSecList = new ArrayList();
                    for (int k = 0; k < baseCodeNameList.Count; k++)
                    {
                        if (((BaseCodeNameWork)baseCodeNameList[k]).SectionCode.Trim().Equals(this.tEdit_SectionCode.DataText.Trim()))
                        {
                            this.sendDestSecList.Add((BaseCodeNameWork)baseCodeNameList[k]);
                            break;
                        }
                    }
                }
                //拠点管理設定マスタに登録した送信先拠点を送信情報グリッドに追加
                int colCnt = _updateResultDataTable.Columns.Count;
                for (int j = colCnt - 1; j > this.Acc_Grid.DisplayLayout.Bands[0].Columns[_updateResultDataTable.ExtractionCountColumn.ColumnName].Index; j--)
                {
                    _updateResultDataTable.Columns.RemoveAt(j);
                }
                for (int i = 0; i < this.sendDestSecList.Count; i++)
                {
                    BaseCodeNameWork baseCodeNameWork = (BaseCodeNameWork)this.sendDestSecList[i];
                    if (!_updateResultDataTable.Columns.Contains(baseCodeNameWork.SectionCode.Trim()))
                    {
                        _updateResultDataTable.Columns.Add(baseCodeNameWork.SectionCode.Trim());
                        this.Acc_Grid.DisplayLayout.Bands[0].Columns[baseCodeNameWork.SectionCode.Trim()].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        _updateResultDataTable.Columns[baseCodeNameWork.SectionCode.Trim()].Caption = baseCodeNameWork.SectionGuideNm;
                    }
                }
                //差分の場合、
                if (tce_ExtractCondDiv.SelectedIndex == 0)
                {
                    rowNo = rowNo + 1;
                    row = _updateResultDataTable.NewUpdateResultRow();
                    row.RowNo = rowNo;
                    row.ExtractionData = work.MasterName;
                    row.ExtractionCount = string.Empty;
                    for (int i = 0; i < this.sendDestSecList.Count; i++)
                    {
                        BaseCodeNameWork baseCodeNameWork = (BaseCodeNameWork)this.sendDestSecList[i];
                        row[baseCodeNameWork.SectionCode.Trim()] = string.Empty;
                    }
                    _updateResultDataTable.Rows.Add(row);

                    this._extractDetailButton.SharedProps.Enabled = false;
                }
                //条件の場合、
                else
                {
                    // --- DEL 2012/07/26 ------------------>>>>>
                    //if (MST_STOCK.Equals(work.MasterName) || MST_GOODSU.Equals(work.MasterName) || MST_CUSTOME.Equals(work.MasterName)
                    //    || MST_SUPPLIER.Equals(work.MasterName) || MST_RATE.Equals(work.MasterName))
                    // --- DEL 2012/07/26 ------------------<<<<<
                    // --- ADD 2012/07/26 ------------------>>>>>
                    if (MST_STOCK.Equals(work.MasterName)
                     || MST_GOODSU.Equals(work.MasterName)
                     || MST_CUSTOME.Equals(work.MasterName)
                     || MST_SUPPLIER.Equals(work.MasterName)
                     || MST_RATE.Equals(work.MasterName)
                     || MST_EMPLOYEE.Equals(work.MasterName)
                     || MST_JOINPARTSU.Equals(work.MasterName)
                     || MST_USERGDBUYDIVU.Equals(work.MasterName))
                    // --- ADD 2012/07/26 ------------------<<<<<
                    {
                        rowNo = rowNo + 1;
                        row = _updateResultDataTable.NewUpdateResultRow();
                        row.RowNo = rowNo;
                        row.ExtractionData = work.MasterName;
                        //ADD 2011/08/30 #24191 送信処理中選択したマスタにだけチェックがついた状態に修正---->>>>>
                        if (selectMstNameList.Count > 0)
                        {
                            row.SendDest = false;
                            foreach (SecMngSndRcvWork selectWork in selectMstNameList)
                            {
                                if (work.MasterName.Equals(selectWork.MasterName))
                                {
                                    row.SendDest = true;
                                    break;
                                }
                            }
                        }
                        //ADD 2011/08/30 #24191 送信処理中選択したマスタにだけチェックがついた状態に修正----<<<<<
                        row.ExtractionCount = string.Empty;
                        for (int i = 0; i < this.sendDestSecList.Count; i++)
                        {
                            BaseCodeNameWork baseCodeNameWork = (BaseCodeNameWork)this.sendDestSecList[i];
                            row[baseCodeNameWork.SectionCode.Trim()] = string.Empty;
                        }
                        _updateResultDataTable.Rows.Add(row);

                        this._extractDetailButton.SharedProps.Enabled = true;
                    }
                }
                //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
            }
        }

        /// <summary>
        /// 送信情報グリッドエラー設定処理
        /// </summary>
        /// <remarks>		
        /// <br>Note		: 送信情報グリッドエラー設定処理を行う。</br>
        /// <br>Programmer	: 譚洪</br>	
        /// <br>Date		: 2009.04.02</br>
        /// </remarks>
        private void SearchResultErrGridCol()
        {
            UpdateResultDataSet.UpdateResultRow row = null;
            int rowNo = 0;
            foreach (SecMngSndRcvWork work in masterNameList)
            {
                rowNo = rowNo + 1;
                row = _updateResultDataTable.NewUpdateResultRow();
                row.RowNo = rowNo;
                row.ExtractionData = work.MasterName;
                row.ExtractionCount = ERROR_BATU;
                _updateResultDataTable.Rows.Add(row);
            }
        }

        /// <summary>
        /// 検索件数フォーマット設定
        /// </summary>
        /// <remarks>		
        /// <br>Note		: 検索件数フォーマット設定処理を行う。</br>
        /// <br>Programmer	: 譚洪</br>	
        /// <br>Date		: 2009.04.02</br>
        /// </remarks>
        private String IntConvert(Int32 searchCount)
        {
            String searchCountStr = Convert.ToString(searchCount);
            Int32 searchCountLen = searchCountStr.Length;
            if (searchCountLen <= 3)
            {
                searchCountStr = searchCountStr + " 件";
            }
            else if (3 < searchCountLen && searchCountLen <= 6)
            {
                searchCountStr = searchCountStr.Substring(0, searchCountLen - 3) + "," + searchCountStr.Substring(searchCountLen - 3) + " 件";
            }
            else if (6 < searchCountLen && searchCountLen <= 9)
            {
                searchCountStr = searchCountStr.Substring(0, searchCountLen - 6) + ","
                    + searchCountStr.Substring(searchCountLen - 6, 3) + ","
                    + searchCountStr.Substring(searchCountLen - 3) + " 件";
            }
            return searchCountStr;
        }
        #region DEL 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）
        ///// <summary>
        ///// 送信情報グリッド計数設定処理
        ///// </summary>
        ///// <remarks>		
        ///// <br>Note		: 送信情報グリッド計数設定処理を行う。</br>
        ///// <br>Programmer	: 譚洪</br>	
        ///// <br>Date		: 2009.04.02</br>
        ///// </remarks>
        //private void SearchResultDataGridCol(MstSearchCountWorkWork searchCountWork)
        //{
        //    UpdateResultDataSet.UpdateResultRow row = null;
        //    int rowNo = 0;
        //    foreach (SecMngSndRcvWork work in masterNameList)
        //    {
        //        rowNo = rowNo + 1;
        //        row = _updateResultDataTable.NewUpdateResultRow();
        //        row.RowNo = rowNo;
        //        row.ExtractionData = work.MasterName;
        //        // 拠点設定マスタ
        //        if (MST_SECINFOSET.Equals(work.MasterName))
        //        {
        //            row.ExtractionCount = this.IntConvert(searchCountWork.SecInfoSetCount);
        //        }
        //        // 部門設定マスタ
        //        else if (MST_SUBSECTION.Equals(work.MasterName))
        //        {
        //            row.ExtractionCount = this.IntConvert(searchCountWork.SubSectionCount);
        //        }
        //        // 倉庫設定マスタ
        //        else if (MST_WAREHOUSE.Equals(work.MasterName))
        //        {
        //            row.ExtractionCount = this.IntConvert(searchCountWork.WarehouseCount);
        //        }
        //        // 従業員設定マスタ
        //        else if (MST_EMPLOYEE.Equals(work.MasterName))
        //        {
        //            row.ExtractionCount = this.IntConvert(searchCountWork.EmployeeCount + searchCountWork.EmployeeDtlCount);
        //        }
        //        // ユーザーガイドマスタ(販売エリア区分）
        //        else if (MST_USERGDAREADIVU.Equals(work.MasterName))
        //        {
        //            row.ExtractionCount = this.IntConvert(searchCountWork.UserGdAreaDivUCount);
        //        }
        //        // ユーザーガイドマスタ（業務区分）
        //        else if (MST_USERGDBUSDIVU.Equals(work.MasterName))
        //        {
        //            row.ExtractionCount = this.IntConvert(searchCountWork.UserGdBusDivUCount);
        //        }
        //        // ユーザーガイドマスタ（業種）
        //        else if (MST_USERGDCATEU.Equals(work.MasterName))
        //        {
        //            row.ExtractionCount = this.IntConvert(searchCountWork.UserGdCateUCount);
        //        }
        //        // ユーザーガイドマスタ（職種）
        //        else if (MST_USERGDBUSU.Equals(work.MasterName))
        //        {
        //            row.ExtractionCount = this.IntConvert(searchCountWork.UserGdBusUCount);
        //        }
        //        // ユーザーガイドマスタ（商品区分）
        //        else if (MST_USERGDGOODSDIVU.Equals(work.MasterName))
        //        {
        //            row.ExtractionCount = this.IntConvert(searchCountWork.UserGdGoodsDivUCount);
        //        }
        //        // ユーザーガイドマスタ（得意先掛率グループ）
        //        else if (MST_USERGDCUSGROUPU.Equals(work.MasterName))
        //        {
        //            row.ExtractionCount = this.IntConvert(searchCountWork.UserGdCusGrouPUCount);
        //        }
        //        // ユーザーガイドマスタ（銀行）
        //        else if (MST_USERGDBANKU.Equals(work.MasterName))
        //        {
        //            row.ExtractionCount = this.IntConvert(searchCountWork.UserGdBankUCount);
        //        }
        //        // ユーザーガイドマスタ（価格区分）
        //        else if (MST_USERGDPRIDIVU.Equals(work.MasterName))
        //        {
        //            row.ExtractionCount = this.IntConvert(searchCountWork.UserGdPriDivUCount);
        //        }
        //        // ユーザーガイドマスタ（納品区分）
        //        else if (MST_USERGDDELIDIVU.Equals(work.MasterName))
        //        {
        //            row.ExtractionCount = this.IntConvert(searchCountWork.UserGdDeliDivUCount);
        //        }
        //        // ユーザーガイドマスタ（商品大分類）
        //        else if (MST_USERGDGOODSBIGU.Equals(work.MasterName))
        //        {
        //            row.ExtractionCount = this.IntConvert(searchCountWork.UserGdGoodsBigUCount);
        //        }
        //        // ユーザーガイドマスタ（販売区分）
        //        else if (MST_USERGDBUYDIVU.Equals(work.MasterName))
        //        {
        //            row.ExtractionCount = this.IntConvert(searchCountWork.UserGdBuyDivUCount);
        //        }
        //        // ユーザーガイドマスタ（在庫管理区分１）
        //        else if (MST_USERGDSTOCKDIVOU.Equals(work.MasterName))
        //        {
        //            row.ExtractionCount = this.IntConvert(searchCountWork.UserGdStockDivOUCount);
        //        }
        //        // ユーザーガイドマスタ（在庫管理区分２）
        //        else if (MST_USERGDSTOCKDIVTU.Equals(work.MasterName))
        //        {
        //            row.ExtractionCount = this.IntConvert(searchCountWork.UserGdStockDivTUCount);
        //        }
        //        // ユーザーガイドマスタ（返品理由）
        //        else if (MST_USERGDRETURNREAU.Equals(work.MasterName))
        //        {
        //            row.ExtractionCount = this.IntConvert(searchCountWork.UserGdReturnReaUCount);
        //        }
        //        // 掛率優先管理マスタ
        //        else if (MST_RATEPROTYMNG.Equals(work.MasterName))
        //        {
        //            row.ExtractionCount = this.IntConvert(searchCountWork.RateProtyMngCount);
        //        }
        //        // 掛率マスタ
        //        else if (MST_RATE.Equals(work.MasterName))
        //        {
        //            row.ExtractionCount = this.IntConvert(searchCountWork.RateCount);
        //        }
        //        // 売上目標設定マスタ
        //        else if (MST_SALESTARGET.Equals(work.MasterName))
        //        {
        //            row.ExtractionCount = this.IntConvert(searchCountWork.EmpSalesTargetCount + searchCountWork.CustSalesTargetCount + searchCountWork.GcdSalesTargetCount);
        //        }
        //        // 得意先マスタ
        //        else if (MST_CUSTOME.Equals(work.MasterName))
        //        {
        //            row.ExtractionCount = this.IntConvert(searchCountWork.CustomerCount + searchCountWork.CustomerChangeCount + searchCountWork.CustRateGroupCount
        //                + searchCountWork.CustSlipMngCount + searchCountWork.CustSlipNoSetCount);
        //        }
        //        // 仕入先マスタ
        //        else if (MST_SUPPLIER.Equals(work.MasterName))
        //        {
        //            row.ExtractionCount = this.IntConvert(searchCountWork.SupplierCount);
        //        }
        //        // 結合マスタ
        //        else if (MST_JOINPARTSU.Equals(work.MasterName))
        //        {
        //            row.ExtractionCount = this.IntConvert(searchCountWork.JoinPartsUCount);
        //        }
        //        // セットマスタ
        //        else if (MST_GOODSSET.Equals(work.MasterName))
        //        {
        //            row.ExtractionCount = this.IntConvert(searchCountWork.GoodsSetCount);
        //        }
        //        // ＴＢＯマスタ
        //        else if (MST_TBOSEARCHU.Equals(work.MasterName))
        //        {
        //            row.ExtractionCount = this.IntConvert(searchCountWork.TBOSearchUCount);
        //        }
        //        // 車種マスタ
        //        else if (MST_MODELNAMEU.Equals(work.MasterName))
        //        {
        //            row.ExtractionCount = this.IntConvert(searchCountWork.ModelNameUCount);
        //        }
        //        // ＢＬコードマスタ
        //        else if (MST_BLGOODSCDU.Equals(work.MasterName))
        //        {
        //            row.ExtractionCount = this.IntConvert(searchCountWork.BLGoodsCdUCount);
        //        }
        //        // メーカーマスタ
        //        else if (MST_MAKERU.Equals(work.MasterName))
        //        {
        //            row.ExtractionCount = this.IntConvert(searchCountWork.MakerUCount);
        //        }
        //        // 商品中分類マスタ
        //        else if (MST_GOODSMGROUPU.Equals(work.MasterName))
        //        {
        //            row.ExtractionCount = this.IntConvert(searchCountWork.GoodsMGroupUCount);
        //        }
        //        // グループコードマスタ
        //        else if (MST_BLGROUPU.Equals(work.MasterName))
        //        {
        //            row.ExtractionCount = this.IntConvert(searchCountWork.BLGroupUCount);
        //        }
        //        // BLコードガイドマスタ
        //        else if (MST_BLCODEGUIDE.Equals(work.MasterName))
        //        {
        //            row.ExtractionCount = this.IntConvert(searchCountWork.BLCodeGuideCount);
        //        }
        //        // 商品マスタ
        //        else if (MST_GOODSU.Equals(work.MasterName))
        //        {
        //            row.ExtractionCount = this.IntConvert(searchCountWork.GoodsMngCount + searchCountWork.GoodsPriceCount + searchCountWork.GoodsUCount
        //                + searchCountWork.IsolIslandPrcCount);
        //        }
        //        // 在庫マスタ
        //        else if (MST_STOCK.Equals(work.MasterName))
        //        {
        //            row.ExtractionCount = this.IntConvert(searchCountWork.StockCount);
        //        }
        //        // 代替マスタ
        //        else if (MST_PARTSSUBSTU.Equals(work.MasterName))
        //        {
        //            row.ExtractionCount = this.IntConvert(searchCountWork.PartsSubstUCount);
        //        }
        //        // 部位マスタ
        //        else if (MST_PARTSPOSCODEU.Equals(work.MasterName))
        //        {
        //            row.ExtractionCount = this.IntConvert(searchCountWork.PartsPosCodeUCount);
        //        }
        //        _updateResultDataTable.Rows.Add(row);
        //    }
        //}
        #endregion DEL 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）
        //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
        /// <summary>
        /// 送信情報グリッド計数設定処理
        /// </summary>
        /// <remarks>		
        /// <br>Note		: 送信情報グリッド計数設定処理を行う。</br>
        /// <br>Programmer	: 馮文雄</br>	
        /// <br>Date		: 2011/07/25</br>
        /// <br>Update Note: 2021/04/12 陳艶丹</br>
        /// <br>管理番号   : 11770021-00</br>
        /// <br>           : PMKOBETSU-4136 得意先メモ情報の追加</br>
        /// </remarks>
        private void SearchResultDataGridCol(Dictionary<string, MstSearchCountWorkWork> searchCntDic, ArrayList errSectionCodeList)
        {
            UpdateResultDataSet.UpdateResultRow row = null;
            int rowNo = 0;
            foreach (SecMngSndRcvWork work in masterNameList)
            {
                if ((this.tce_ExtractCondDiv.SelectedIndex == 0) ||
                    (this.tce_ExtractCondDiv.SelectedIndex == 1 &&
                    // --- DEL 2012/07/26 ------------------>>>>>
                    //(MST_STOCK.Equals(work.MasterName) || MST_GOODSU.Equals(work.MasterName) || MST_CUSTOME.Equals(work.MasterName)
                    //    || MST_SUPPLIER.Equals(work.MasterName) || MST_RATE.Equals(work.MasterName))))
                    // --- DEL 2012/07/26 ------------------<<<<<
                    // --- ADD 2012/07/26 ------------------>>>>>
                     (MST_STOCK.Equals(work.MasterName)
                     || MST_GOODSU.Equals(work.MasterName)
                     || MST_CUSTOME.Equals(work.MasterName)
                     || MST_SUPPLIER.Equals(work.MasterName)
                     || MST_RATE.Equals(work.MasterName)
                     || MST_EMPLOYEE.Equals(work.MasterName)
                     || MST_JOINPARTSU.Equals(work.MasterName)
                     || MST_USERGDBUYDIVU.Equals(work.MasterName))))
                    // --- ADD 2012/07/26 ------------------<<<<<
                {
                    rowNo = rowNo + 1;
                    row = _updateResultDataTable.NewUpdateResultRow();
                    row.RowNo = rowNo;
                    row.ExtractionData = work.MasterName;
                    row.SendDest = false;
                    foreach (SecMngSndRcvWork selectWork in selectMstNameList)
                    {
                        if (work.MasterName.Equals(selectWork.MasterName))
                        {
                            row.SendDest = true;
                            foreach (string sectionCode in searchCntDic.Keys)
                            {
                                MstSearchCountWorkWork searchCountWork = searchCntDic[sectionCode];
                                // 拠点設定マスタ
                                if (MST_SECINFOSET.Equals(work.MasterName))
                                {
                                    row[sectionCode] = this.IntConvert(searchCountWork.SecInfoSetCount);
                                }
                                // 部門設定マスタ
                                else if (MST_SUBSECTION.Equals(work.MasterName))
                                {
                                    row[sectionCode] = this.IntConvert(searchCountWork.SubSectionCount);
                                }
                                // 倉庫設定マスタ
                                else if (MST_WAREHOUSE.Equals(work.MasterName))
                                {
                                    row[sectionCode] = this.IntConvert(searchCountWork.WarehouseCount);
                                }
                                // 従業員設定マスタ
                                else if (MST_EMPLOYEE.Equals(work.MasterName))
                                {
                                    // --- DEL 2012/07/26 ---------------------------->>>>>
                                    //row[sectionCode] = this.IntConvert(searchCountWork.EmployeeCount + searchCountWork.EmployeeDtlCount);
                                    // --- DEL 2012/07/26 ----------------------------<<<<<
                                    // --- ADD 2012/07/26 ---------------------------->>>>>
                                    // 差分の場合
                                    if (tce_ExtractCondDiv.SelectedIndex == 0)
                                    {
                                        row[sectionCode] = this.IntConvert(searchCountWork.EmployeeCount + searchCountWork.EmployeeDtlCount);
                                    }
                                    else
                                    {
                                        row[sectionCode] = this.IntConvert(searchCountWork.EmployeeCount);
                                    }
                                    // --- ADD 2012/07/26 ----------------------------<<<<<
                                }
                                // ユーザーガイドマスタ(販売エリア区分）
                                else if (MST_USERGDAREADIVU.Equals(work.MasterName))
                                {
                                    row[sectionCode] = this.IntConvert(searchCountWork.UserGdAreaDivUCount);
                                }
                                // ユーザーガイドマスタ（業務区分）
                                else if (MST_USERGDBUSDIVU.Equals(work.MasterName))
                                {
                                    row[sectionCode] = this.IntConvert(searchCountWork.UserGdBusDivUCount);
                                }
                                // ユーザーガイドマスタ（業種）
                                else if (MST_USERGDCATEU.Equals(work.MasterName))
                                {
                                    row[sectionCode] = this.IntConvert(searchCountWork.UserGdCateUCount);
                                }
                                // ユーザーガイドマスタ（職種）
                                else if (MST_USERGDBUSU.Equals(work.MasterName))
                                {
                                    row[sectionCode] = this.IntConvert(searchCountWork.UserGdBusUCount);
                                }
                                // ユーザーガイドマスタ（商品区分）
                                else if (MST_USERGDGOODSDIVU.Equals(work.MasterName))
                                {
                                    row[sectionCode] = this.IntConvert(searchCountWork.UserGdGoodsDivUCount);
                                }
                                // ユーザーガイドマスタ（得意先掛率グループ）
                                else if (MST_USERGDCUSGROUPU.Equals(work.MasterName))
                                {
                                    row[sectionCode] = this.IntConvert(searchCountWork.UserGdCusGrouPUCount);
                                }
                                // ユーザーガイドマスタ（銀行）
                                else if (MST_USERGDBANKU.Equals(work.MasterName))
                                {
                                    row[sectionCode] = this.IntConvert(searchCountWork.UserGdBankUCount);
                                }
                                // ユーザーガイドマスタ（価格区分）
                                else if (MST_USERGDPRIDIVU.Equals(work.MasterName))
                                {
                                    row[sectionCode] = this.IntConvert(searchCountWork.UserGdPriDivUCount);
                                }
                                // ユーザーガイドマスタ（納品区分）
                                else if (MST_USERGDDELIDIVU.Equals(work.MasterName))
                                {
                                    row[sectionCode] = this.IntConvert(searchCountWork.UserGdDeliDivUCount);
                                }
                                // ユーザーガイドマスタ（商品大分類）
                                else if (MST_USERGDGOODSBIGU.Equals(work.MasterName))
                                {
                                    row[sectionCode] = this.IntConvert(searchCountWork.UserGdGoodsBigUCount);
                                }
                                // ユーザーガイドマスタ（販売区分）
                                else if (MST_USERGDBUYDIVU.Equals(work.MasterName))
                                {
                                    row[sectionCode] = this.IntConvert(searchCountWork.UserGdBuyDivUCount);
                                }
                                // ユーザーガイドマスタ（在庫管理区分１）
                                else if (MST_USERGDSTOCKDIVOU.Equals(work.MasterName))
                                {
                                    row[sectionCode] = this.IntConvert(searchCountWork.UserGdStockDivOUCount);
                                }
                                // ユーザーガイドマスタ（在庫管理区分２）
                                else if (MST_USERGDSTOCKDIVTU.Equals(work.MasterName))
                                {
                                    row[sectionCode] = this.IntConvert(searchCountWork.UserGdStockDivTUCount);
                                }
                                // ユーザーガイドマスタ（返品理由）
                                else if (MST_USERGDRETURNREAU.Equals(work.MasterName))
                                {
                                    row[sectionCode] = this.IntConvert(searchCountWork.UserGdReturnReaUCount);
                                }
                                // 掛率優先管理マスタ
                                else if (MST_RATEPROTYMNG.Equals(work.MasterName))
                                {
                                    row[sectionCode] = this.IntConvert(searchCountWork.RateProtyMngCount);
                                }
                                // 掛率マスタ
                                else if (MST_RATE.Equals(work.MasterName))
                                {
                                    row[sectionCode] = this.IntConvert(searchCountWork.RateCount);
                                }
                                // 売上目標設定マスタ
                                else if (MST_SALESTARGET.Equals(work.MasterName))
                                {
                                    row[sectionCode] = this.IntConvert(searchCountWork.EmpSalesTargetCount + searchCountWork.CustSalesTargetCount + searchCountWork.GcdSalesTargetCount);
                                }
                                // 得意先マスタ
                                else if (MST_CUSTOME.Equals(work.MasterName))
                                {
                                    // ------ UPD 2021/04/12 陳艶丹 FOR PMKOBETSU-4136-------->>>>>
                                    //row[sectionCode] = this.IntConvert(searchCountWork.CustomerCount + searchCountWork.CustomerChangeCount + searchCountWork.CustRateGroupCount
                                    //    + searchCountWork.CustSlipMngCount + searchCountWork.CustSlipNoSetCount);
                                    row[sectionCode] = this.IntConvert(searchCountWork.CustomerCount + searchCountWork.CustomerChangeCount + searchCountWork.CustRateGroupCount
                                        + searchCountWork.CustSlipMngCount + searchCountWork.CustSlipNoSetCount + searchCountWork.CustomerMemoCount);
                                    // ------ UPD 2021/04/12 陳艶丹 FOR PMKOBETSU-4136--------<<<<<
                                }
                                // 仕入先マスタ
                                else if (MST_SUPPLIER.Equals(work.MasterName))
                                {
                                    row[sectionCode] = this.IntConvert(searchCountWork.SupplierCount);
                                }
                                // 結合マスタ
                                else if (MST_JOINPARTSU.Equals(work.MasterName))
                                {
                                    row[sectionCode] = this.IntConvert(searchCountWork.JoinPartsUCount);
                                }
                                // セットマスタ
                                else if (MST_GOODSSET.Equals(work.MasterName))
                                {
                                    row[sectionCode] = this.IntConvert(searchCountWork.GoodsSetCount);
                                }
                                // ＴＢＯマスタ
                                else if (MST_TBOSEARCHU.Equals(work.MasterName))
                                {
                                    row[sectionCode] = this.IntConvert(searchCountWork.TBOSearchUCount);
                                }
                                // 車種マスタ
                                else if (MST_MODELNAMEU.Equals(work.MasterName))
                                {
                                    row[sectionCode] = this.IntConvert(searchCountWork.ModelNameUCount);
                                }
                                // ＢＬコードマスタ
                                else if (MST_BLGOODSCDU.Equals(work.MasterName))
                                {
                                    row[sectionCode] = this.IntConvert(searchCountWork.BLGoodsCdUCount);
                                }
                                // メーカーマスタ
                                else if (MST_MAKERU.Equals(work.MasterName))
                                {
                                    row[sectionCode] = this.IntConvert(searchCountWork.MakerUCount);
                                }
                                // 商品中分類マスタ
                                else if (MST_GOODSMGROUPU.Equals(work.MasterName))
                                {
                                    row[sectionCode] = this.IntConvert(searchCountWork.GoodsMGroupUCount);
                                }
                                // グループコードマスタ
                                else if (MST_BLGROUPU.Equals(work.MasterName))
                                {
                                    row[sectionCode] = this.IntConvert(searchCountWork.BLGroupUCount);
                                }
                                // BLコードガイドマスタ
                                else if (MST_BLCODEGUIDE.Equals(work.MasterName))
                                {
                                    row[sectionCode] = this.IntConvert(searchCountWork.BLCodeGuideCount);
                                }
                                // 商品マスタ
                                else if (MST_GOODSU.Equals(work.MasterName))
                                {
                                    row[sectionCode] = this.IntConvert(searchCountWork.GoodsMngCount + searchCountWork.GoodsPriceCount + searchCountWork.GoodsUCount
                                        + searchCountWork.IsolIslandPrcCount);
                                }
                                // 在庫マスタ
                                else if (MST_STOCK.Equals(work.MasterName))
                                {
                                    row[sectionCode] = this.IntConvert(searchCountWork.StockCount);
                                }
                                // 代替マスタ
                                else if (MST_PARTSSUBSTU.Equals(work.MasterName))
                                {
                                    row[sectionCode] = this.IntConvert(searchCountWork.PartsSubstUCount);
                                }
                                // 部位マスタ
                                else if (MST_PARTSPOSCODEU.Equals(work.MasterName))
                                {
                                    row[sectionCode] = this.IntConvert(searchCountWork.PartsPosCodeUCount);
                                }
                            }
                            foreach (string errSectionCode in errSectionCodeList)
                            {
                                row[errSectionCode] = ERROR_BATU;
                            }
                            break;
                        }
                    }
                    _updateResultDataTable.Rows.Add(row);
                }
            }
        }

        /// <summary>
        /// 更新した後で送信条件タブを再設定する
        /// </summary>
        /// <remarks>		
        /// <br>Note		: 送信条件の時間設定処理を行う。</br>
        /// <br>Programmer	: 馮文雄</br>	
        /// <br>Date		: 2011/07/25</br>
        /// </remarks>
        private void SearchCondtionGridCol()
        {
            this.SearchSyncExecDate();
            if (!ALL_SECTIONCODE.Equals(tEdit_SectionCode.DataText))
            {
                //「00:全社」ではない場合、入力した送信先拠点だけを保留
                ArrayList indexList = new ArrayList();
                for (int i = 0; i < this._extractionConditionDataTable.Rows.Count; i++)
                {
                    ExtractionConditionDataSet.ExtractionConditionRow row = (ExtractionConditionDataSet.ExtractionConditionRow)_extractionConditionDataTable.Rows[i];
                    if (!row.BaseCode.Trim().Equals(tEdit_SectionCode.DataText.Trim()))
                    {
                        indexList.Add(i);
                    }
                }
                for (int j = indexList.Count - 1; j >= 0; j--)
                {
                    _extractionConditionDataTable.Rows.RemoveAt((int)indexList[j]);
                }
            }
            for (int i = 0; i < this._extractionConditionDataTable.Rows.Count; i++)
            {
                ExtractionConditionDataSet.ExtractionConditionRow row = (ExtractionConditionDataSet.ExtractionConditionRow)_extractionConditionDataTable.Rows[i];
                row.SendDestCond = false;
                for (int j = 0; j < selectbaseCodeNameList.Count; j++)
                {
                    BaseCodeNameWork selectbaseCodeNamework = (BaseCodeNameWork)selectbaseCodeNameList[j];
                    if (row.BaseCode.Trim().Equals(selectbaseCodeNamework.SectionCode.Trim()))
                    {
                        row.SendDestCond = true;
                        break;
                    }
                }
                if (this.tce_ExtractCondDiv.SelectedIndex == 1)
                {
                    if (row.SendDestCond == false)
                    {
                        row.BeginningDate = DateTime.MinValue;
                        row.BeginningTime = string.Empty;
                        row.EndDate = DateTime.MinValue;
                        row.EndTime = string.Empty;
                        row.InitBeginningDate = DateTime.MinValue;
                        row.InitBeginningTime = string.Empty;
                        //ADD 2011/08/29 #23934 条件送信の開始日付時間・終了日付時間の初期値について--------------------------------------->>>>>
                        Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.BeginningDateColumn.ColumnName].SetValue(DBNull.Value, true);
                        Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.EndDateColumn.ColumnName].SetValue(DBNull.Value, true);
                        Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.EndDateColumn.ColumnName].Selected = false;
                        //ADD 2011/08/29 #23934 条件送信の開始日付時間・終了日付時間の初期値について---------------------------------------<<<<<
                    }
                }
            }
            
        }
        //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<

        /// <summary>
        /// 送信情報グリッド設定処理
        /// </summary>
        /// <remarks>		
        /// <br>Note		: 送信情報グリッド設定処理を行う。</br>
        /// <br>Programmer	: 譚洪</br>	
        /// <br>Date		: 2009.04.02</br>
        /// </remarks>
        private void UpdateResultAccDataGridCol()
        {
            UpdateResultDataSet.UpdateResultRow row = null;
            int rowNo = 0;
            foreach (SecMngSndRcvWork work in masterNameList)
            {
                rowNo = rowNo + 1;
                row = _updateResultDataTable.NewUpdateResultRow();
                row.RowNo = rowNo;
                row.ExtractionData = work.MasterName;
                row.ExtractionCount = string.Empty;
                _updateResultDataTable.Rows.Add(row);
            }
        }

        /// <summary>
        /// マスタ送信処理
        /// </summary>
        /// <remarks>		
        /// <br>Note		: データ送信処理を行う。</br>
        /// <br>Programmer	: 譚洪</br>	
        /// <br>Date		: 2009.04.02</br>
        /// </remarks>
        private void UpdateProcess()
        {
            Broadleaf.Windows.Forms.SFCMN00299CA form = new Broadleaf.Windows.Forms.SFCMN00299CA();
            // 表示文字を設定
            form.Title = "送信処理中";
            form.Message = "送信処理中です";

            #region DEL 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）
            //string beginningDate = this.Condition_Grid.Rows[0].Cells[this._extractionConditionDataTable.BeginningDateColumn.ColumnName].Value.ToString();
            //string beginningTime = this.Condition_Grid.Rows[0].Cells[this._extractionConditionDataTable.BeginningTimeColumn.ColumnName].Value.ToString();

            //string endingDate = this.Condition_Grid.Rows[0].Cells[this._extractionConditionDataTable.EndDateColumn.ColumnName].Value.ToString();
            //string endingTime = this.Condition_Grid.Rows[0].Cells[this._extractionConditionDataTable.EndTimeColumn.ColumnName].Value.ToString();

            //string baseCode = this.Condition_Grid.Rows[0].Cells[this._extractionConditionDataTable.BaseCodeColumn.ColumnName].Value.ToString();
            //// 開始日付
            //DateTime beginDateTime = new DateTime(int.Parse(beginningDate.Substring(0, 4)), int.Parse(beginningDate.Substring(5, 2)),
            //    int.Parse(beginningDate.Substring(8, 2)), int.Parse(beginningTime.Substring(0, 2)), int.Parse(beginningTime.Substring(3, 2)),
            //    int.Parse(beginningTime.Substring(6, 2)));
            //// 終了日付
            //DateTime endDateTime = new DateTime(int.Parse(endingDate.Substring(0, 4)), int.Parse(endingDate.Substring(5, 2)),
            //    int.Parse(endingDate.Substring(8, 2)), int.Parse(endingTime.Substring(0, 2)), int.Parse(endingTime.Substring(3, 2)),
            //    int.Parse(endingTime.Substring(6, 2)));

            //if (beginDateTime.Year == _startTime.Year && beginDateTime.Month == _startTime.Month && beginDateTime.Day == _startTime.Day
            //    && beginDateTime.Hour == _startTime.Hour && beginDateTime.Minute == _startTime.Minute && beginDateTime.Second == _startTime.Second)
            //{
            //    beginDateTime = _startTime;
            //}

            //long beginDtLong = beginDateTime.Ticks;
            //long endDtLong = endDateTime.Ticks;
            //bool isEmpty = false;
            //baseCode = baseCode.Trim();
            //MstSearchCountWorkWork searchCountWork = new MstSearchCountWorkWork();
            //// データ送信処理
            //int status = _mstUpdCountAcs.SendProc(_connectPointDiv, masterDivList, masterNameList, beginDtLong, endDtLong, _startTime, _enterpriseCode, _loginEmplooyCode, baseCode, out searchCountWork, out isEmpty);
            #endregion DEL 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）
            this.Cursor = Cursors.WaitCursor;
            // ダイアログ表示
            form.Show();
            //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
            Dictionary<string, MstSearchCountWorkWork> searchCntDic = new Dictionary<string, MstSearchCountWorkWork>();
            int status = 0;
            bool isEmpty = true;
            string pmEnterpriseCode = string.Empty;
            string beginningDate;
            string beginningTime;
            string endingDate;
            string endingTime;
            string initBeginningDate;
            string initBeginningTime;
            string baseCode;

            //-----ADD 2011.08.19 #23817----->>>>>
            DateTime dtBeginDate = DateTime.MinValue;
            DateTime dtEndDate = DateTime.MinValue;
            DateTime dtInitBeginDate = DateTime.MinValue;
            //-----ADD 2011.08.19 #23817-----<<<<<
            DateTime beginDateTime = DateTime.MinValue;
            DateTime endDateTime = DateTime.MinValue;
            DateTime initBeginDateTime = DateTime.MinValue;
            ArrayList errSectionCodeList = new ArrayList();
            ArrayList stockMaxList = new ArrayList();
            ArrayList goodsMaxList = new ArrayList();
            int errorStatus = -1;//ADD 2011/09/05 #24047
            string errMsg = "";//ADD 2011/09/05 #24047
            for (int i = 0; i < this.Condition_Grid.Rows.Count; i++)
            {
                //-----ADD 2011.08.19 #23817----->>>>>
                if (this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.BeginningDateColumn.ColumnName].Value != null
                    && !String.IsNullOrEmpty(this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.BeginningDateColumn.ColumnName].Value.ToString()))
                {
                    dtBeginDate = (DateTime)this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.BeginningDateColumn.ColumnName].Value;
                }
                if(this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.EndDateColumn.ColumnName].Value != null 
                    && !String.IsNullOrEmpty(this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.EndDateColumn.ColumnName].Value.ToString()))
                {
                    dtEndDate = (DateTime)this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.EndDateColumn.ColumnName].Value;
                }
                //-----ADD 2011.08.19 #23817-----<<<<<
                beginningDate = this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.BeginningDateColumn.ColumnName].Value.ToString();
                beginningTime = this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.BeginningTimeColumn.ColumnName].Value.ToString();

                endingDate = this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.EndDateColumn.ColumnName].Value.ToString();
                endingTime = this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.EndTimeColumn.ColumnName].Value.ToString();

                //-----ADD 2011.08.19 #23817----->>>>>
                dtInitBeginDate = (DateTime)this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.InitBeginningDateColumn.ColumnName].Value;
                //-----ADD 2011.08.19 #23817-----<<<<<
                initBeginningDate = this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.InitBeginningDateColumn.ColumnName].Value.ToString();
                initBeginningTime = this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.InitBeginningTimeColumn.ColumnName].Value.ToString();

                baseCode = this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.BaseCodeColumn.ColumnName].Value.ToString();
                // 開始日付
                if (!string.IsNullOrEmpty(beginningDate) && !string.IsNullOrEmpty(beginningTime))
                {
                    //-----DEL 2011.08.19 #23817----->>>>>
                    //beginDateTime = new DateTime(int.Parse(beginningDate.Substring(0, 4)), int.Parse(beginningDate.Substring(5, 2)),
                    //    int.Parse(beginningDate.Substring(8, 2)), int.Parse(beginningTime.Substring(0, 2)), int.Parse(beginningTime.Substring(3, 2)),
                    //    int.Parse(beginningTime.Substring(6, 2)));
                    //-----DEL 2011.08.19 #23817-----<<<<<
                    //-----ADD 2011.08.19 #23817----->>>>>
                    beginDateTime = new DateTime(dtBeginDate.Year, dtBeginDate.Month, dtBeginDate.Day,
                        int.Parse(beginningTime.Substring(0, 2)), int.Parse(beginningTime.Substring(3, 2)),
                        int.Parse(beginningTime.Substring(6, 2)));
                    //-----ADD 2011.08.19 #23817-----<<<<<
                }
                else
                {
                    beginDateTime = DateTime.MinValue;
                }
                // 終了日付
                if (!string.IsNullOrEmpty(endingDate) && !string.IsNullOrEmpty(endingTime))
                {
                    //-----DEL 2011.08.19 #23817----->>>>>
                    //endDateTime = new DateTime(int.Parse(endingDate.Substring(0, 4)), int.Parse(endingDate.Substring(5, 2)),
                    //    int.Parse(endingDate.Substring(8, 2)), int.Parse(endingTime.Substring(0, 2)), int.Parse(endingTime.Substring(3, 2)),
                    //    int.Parse(endingTime.Substring(6, 2)));
                    //-----DEL 2011.08.19 #23817-----<<<<<
                    //-----ADD 2011.08.19 #23817----->>>>>
                    endDateTime = new DateTime(dtEndDate.Year, dtEndDate.Month, dtEndDate.Day,
                        int.Parse(endingTime.Substring(0, 2)), int.Parse(endingTime.Substring(3, 2)),
                        int.Parse(endingTime.Substring(6, 2)));
                    //-----ADD 2011.08.19 #23817-----<<<<<
                }
                else
                {
                    endDateTime = DateTime.MinValue;
                }

                // 初期開始日付
                if (!string.IsNullOrEmpty(initBeginningDate) && !string.IsNullOrEmpty(initBeginningTime))
                {
                    //-----DEL 2011.08.19 #23817----->>>>>
                    //initBeginDateTime = new DateTime(int.Parse(initBeginningDate.Substring(0, 4)), int.Parse(initBeginningDate.Substring(5, 2)),
                    //    int.Parse(initBeginningDate.Substring(8, 2)), int.Parse(initBeginningTime.Substring(0, 2)), int.Parse(initBeginningTime.Substring(3, 2)),
                    //    int.Parse(initBeginningTime.Substring(6, 2)));
                    //-----DEL 2011.08.19 #23817-----<<<<<
                    //-----ADD 2011.08.19 #23817----->>>>>
                    initBeginDateTime = new DateTime(dtInitBeginDate.Year, dtInitBeginDate.Month, dtInitBeginDate.Day,
                        int.Parse(initBeginningTime.Substring(0, 2)), int.Parse(initBeginningTime.Substring(3, 2)),
                        int.Parse(initBeginningTime.Substring(6, 2)));
                    //-----ADD 2011.08.19 #23817-----<<<<<

                }

                if (beginDateTime.Year == initBeginDateTime.Year && beginDateTime.Month == initBeginDateTime.Month && beginDateTime.Day == initBeginDateTime.Day
                    && beginDateTime.Hour == initBeginDateTime.Hour && beginDateTime.Minute == initBeginDateTime.Minute && beginDateTime.Second == initBeginDateTime.Second)
                {
                    //beginDateTime = initBeginDateTime;//DEL 2011/08/27 #23922 受信処理で対象外の項目も受信されてしまいます。
                    beginDateTime = dtInitBeginDate;//ADD 2011/08/27 #23922 受信処理で対象外の項目も受信されてしまいます。
                }

                long beginDtLong = beginDateTime.Ticks;
                long endDtLong = endDateTime.Ticks;
                bool b_Empty = true;
                baseCode = baseCode.Trim();
                MstSearchCountWorkWork searchCountWork = new MstSearchCountWorkWork();
                if (((bool)this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.SendDestCondColumn.ColumnName].Value) == false)
                {
                    //チェックされない送信先拠点へ送信しない
                    continue;
                }
                DateTime _initBegTime = ((ExtractionConditionDataSet.ExtractionConditionRow)this._extractionConditionDataTable.Rows[i]).InitBeginningDate;
                //マスタ抽出条件パラメータリストを作成
                ArrayList paramList = new ArrayList();
                foreach (SecMngSndRcvWork work in selectMstNameList)
                {
                    if (MST_RATE.Equals(work.MasterName))
                    {
                        _rateProcParam.UpdateDateTimeBegin = beginDtLong;
                        _rateProcParam.UpdateDateTimeEnd = endDtLong;
                        paramList.Add(_rateProcParam);
                    }
                    else if (MST_STOCK.Equals(work.MasterName))
                    {
                        _stockProcParam.UpdateDateTimeBegin = beginDtLong;
                        _stockProcParam.UpdateDateTimeEnd = endDtLong;
                        paramList.Add(_stockProcParam);
                    }
                    else if (MST_CUSTOME.Equals(work.MasterName))
                    {
                        _customerProcParam.UpdateDateTimeBegin = beginDtLong;
                        _customerProcParam.UpdateDateTimeEnd = endDtLong;
                        paramList.Add(_customerProcParam);
                    }
                    else if (MST_SUPPLIER.Equals(work.MasterName))
                    {
                        _supplierProcParam.UpdateDateTimeBegin = beginDtLong;
                        _supplierProcParam.UpdateDateTimeEnd = endDtLong;
                        paramList.Add(_supplierProcParam);
                    }
                    else if (MST_GOODSU.Equals(work.MasterName))
                    {
                        _goodsProcParam.UpdateDateTimeBegin = beginDtLong;
                        _goodsProcParam.UpdateDateTimeEnd = endDtLong;
                        paramList.Add(_goodsProcParam);
                    }
                    // --- ADD 2012/07/26 ------------------>>>>>
                    else if (MST_EMPLOYEE.Equals(work.MasterName))
                    {
                        _employeeProcParam.UpdateDateTimeBegin = beginDtLong;
                        _employeeProcParam.UpdateDateTimeEnd = endDtLong;
                        paramList.Add(_employeeProcParam);
                    }
                    else if (MST_USERGDBUYDIVU.Equals(work.MasterName))
                    {
                        _userGdBuyDivUProcParam.UpdateDateTimeBegin = beginDtLong;
                        _userGdBuyDivUProcParam.UpdateDateTimeEnd = endDtLong;
                        paramList.Add(_userGdBuyDivUProcParam);
                    }
                    else if (MST_JOINPARTSU.Equals(work.MasterName))
                    {
                        _joinPartsUProcParam.UpdateDateTimeBegin = beginDtLong;
                        _joinPartsUProcParam.UpdateDateTimeEnd = endDtLong;
                        paramList.Add(_joinPartsUProcParam);
                    }
                    // --- ADD 2012/07/26 ------------------<<<<<
                }
                _mstUpdCountAcs.SeachPmCode(_enterpriseCode, baseCode, out pmEnterpriseCode);
                // データ送信処理
                status = _mstUpdCountAcs.SendProc(this.tce_ExtractCondDiv.SelectedIndex, _connectPointDiv, paramList, pmEnterpriseCode, masterDivList, masterNameList, beginDtLong, endDtLong, _initBegTime, _enterpriseCode, _loginSectionCode, _loginEmplooyCode, baseCode, out searchCountWork, out b_Empty);
                if (!b_Empty)
                {
                    isEmpty = false;
                }
                // 検索0件の場合、
                if (b_Empty)
                {
                    searchCntDic.Add(baseCode, searchCountWork);
                }
                // 検索エラーの場合、 
                else if (-1 == searchCountWork.ErrorKubun || -2 == searchCountWork.ErrorKubun)
                {
                    errSectionCodeList.Add(baseCode);
                    //ADD 2011/09/05 #24047 --------------->>>>>
                    errorStatus = status;
                    errMsg = "検索処理に失敗しました。";
                    //ADD 2011/09/05 #24047 ---------------<<<<<
                }
                else if (-3 == searchCountWork.ErrorKubun)
                {
                    goodsMaxList.Add(baseCode);
                    continue;
                }
                else if (-4 == searchCountWork.ErrorKubun)
                {
                    stockMaxList.Add(baseCode);
                    continue;
                }
                //ADD 2011/09/05 #24047 --------------->>>>>
                else if (-5 == searchCountWork.ErrorKubun)
                {
                    errSectionCodeList.Add(baseCode);
                    errorStatus = status;
                    errMsg = "更新処理に失敗しました。";
                }
                //ADD 2011/09/05 #24047 ---------------<<<<<
                else
                {
                    searchCntDic.Add(baseCode, searchCountWork);
                }
            }
            //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
            
            // ダイアログを閉じる
            form.Close();
            this.Cursor = Cursors.Default;
            //更新後画面再設定
            if (isEmpty && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 送信情報テーブルクリア処理
                this._updateResultDataTable.Clear();
                this.SearchResultDataGridCol(searchCntDic, errSectionCodeList);
                this.ultraTabControl1.SelectedTab = this.ultraTabControl1.Tabs["updateTab"];

                //送信条件テーブルクリア
                //DEL 2011/08/29 #23934 条件送信の開始日付時間・終了日付時間の初期値について--->>>>>
                //this._extractionConditionDataTable.Clear();
                //this.SearchCondtionGridCol();
                //DEL 2011/08/29 #23934 条件送信の開始日付時間・終了日付時間の初期値について---<<<<<
                //ADD 2011/08/29 #23934 条件送信の開始日付時間・終了日付時間の初期値について--->>>>>
                if (this.tce_ExtractCondDiv.SelectedIndex != 1)
                {
                    this._extractionConditionDataTable.Clear();
                    this.SearchCondtionGridCol();
                }
                //ADD 2011/08/29 #23934 条件送信の開始日付時間・終了日付時間の初期値について---<<<<<
                
                // メッセージを表示
                this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "抽出対象のデータが存在しません。", 0);
            }
            else
            {
                string errSecCode = "";
                for (int i = 0; i < stockMaxList.Count; i++)
                {
                    errSecCode = errSecCode + "拠点[" + stockMaxList[i] + "]：在庫マスタの抽出件数は20000件を超えるため、条件を再設定してください。\r\n";
                }
                for (int i = 0; i < goodsMaxList.Count; i++)
                {
                    errSecCode = errSecCode + "拠点[" + goodsMaxList[i] + "]：商品マスタの抽出件数は20000件を超えるため、条件を再設定してください。\r\n";
                }
                //ADD 2011/09/05 #24047--------------------------------------->>>>>
                if (!string.IsNullOrEmpty(errMsg))
                {
                    this.MsgDispProc(emErrorLevel.ERR_LEVEL_STOP, errMsg, errorStatus);
                }                
                //ADD 2011/09/05 #24047---------------------------------------<<<<<
                if (errSecCode != "")
                {
                    this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, errSecCode, 0);
                }
                // 送信情報テーブルクリア処理
                this._updateResultDataTable.Clear();
                this.SearchResultDataGridCol(searchCntDic, errSectionCodeList);

                //送信条件テーブルクリア                
                //DEL 2011/08/29 #23934 条件送信の開始日付時間・終了日付時間の初期値について--->>>>>
                //this._extractionConditionDataTable.Clear();
                //this.SearchCondtionGridCol();
                //DEL 2011/08/29 #23934 条件送信の開始日付時間・終了日付時間の初期値について---<<<<<
                //ADD 2011/08/29 #23934 条件送信の開始日付時間・終了日付時間の初期値について--->>>>>
                if (this.tce_ExtractCondDiv.SelectedIndex != 1)
                {
                    this._extractionConditionDataTable.Clear();
                    this.SearchCondtionGridCol();
                }
                //ADD 2011/08/29 #23934 条件送信の開始日付時間・終了日付時間の初期値について---<<<<<
                this.ultraTabControl1.SelectedTab = this.ultraTabControl1.Tabs["updateTab"];
            }
            #region DEL 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）
            //// 検索0件の場合、
            //if (isEmpty)
            //{

            //    // 送信情報テーブルクリア処理
            //    this._updateResultDataTable.Clear();

            //    this.SearchResultDataGridCol(searchCntDic);

            //    this.ultraTabControl1.SelectedTab = this.ultraTabControl1.Tabs["updateTab"];

            //    // メッセージを表示
            //    this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "抽出対象のデータが存在しません。", 0);

            //}
            //// 検索エラーの場合、 
            //else if (-1 == searchCountWork.ErrorKubun)
            //{
            //    // 送信情報テーブルクリア処理
            //    this._updateResultDataTable.Clear();

            //    this.SearchResultErrGridCol();

            //    this.ultraTabControl1.SelectedTab = this.ultraTabControl1.Tabs["updateTab"];
            //}
            //else if (-2 == searchCountWork.ErrorKubun)
            //{
            //    // 送信情報テーブルクリア処理
            //    this._updateResultDataTable.Clear();

            //    this.SearchResultErrGridCol();

            //    this.ultraTabControl1.SelectedTab = this.ultraTabControl1.Tabs["updateTab"];

            //    // メッセージを表示
            //    this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "処理が込み合っているためタイムアウトしました。\n再試行するか、しばらく待ってから再度処理を行ってください。", 0);
            //}
            //else
            //{
            //    // 送信情報テーブルクリア処理
            //    this._updateResultDataTable.Clear();

            //    this.SearchResultDataGridCol(searchCntDic);

            //    this.ultraTabControl1.SelectedTab = this.ultraTabControl1.Tabs["updateTab"];
            //}
            #endregion DEL 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）
        }


        /// <summary>
        /// 送信更新チェック処理
        /// </summary>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <returns>True:OK, False:NG</returns>
        /// <remarks>
        /// <br>Note		: 画面の更新チェックを行う。</br>
        /// <br>Programmer	: 譚洪</br>
        /// <br>Date		: 2009.04.03</br>
        /// </remarks>
        private bool ScreenInputCheck(ref string errMessage)
        {
            bool status = true;

            const string ct_NoInput = "が未入力です。";
            const string ct_RangeError = "抽出日付の範囲が不正です。";
            const string ct_BeginTimeError = "の変更時は同一月内のみ設定が可能です。";

            DateTime begDateTime = new DateTime();
            DateTime endDateTime = new DateTime();

            #region DEL 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）
            //// 日付の範囲チェック用(開始日 > 終了日 → NG)
            //foreach (ExtractionConditionDataSet.ExtractionConditionRow row in this._mstUpdCountAcs.ExtractionConditionDataTable)
            //{
            //    if (row.IsNull(this._extractionConditionDataTable.BeginningTimeColumn.ColumnName)
            //        || row.IsNull(this._extractionConditionDataTable.BeginningDateColumn.ColumnName)
            //        || row.IsNull(this._extractionConditionDataTable.EndDateColumn.ColumnName)
            //        || row.IsNull(this._extractionConditionDataTable.EndTimeColumn.ColumnName))
            //    {
            //        break;
            //    }
            //    String beginningTimeStr = row.BeginningTime;
            //    String endDateTimeStr = row.EndTime;

            //    if (string.IsNullOrEmpty(beginningTimeStr) || string.IsNullOrEmpty(endDateTimeStr))
            //    {
            //        break;
            //    }
            //    int beginningTimeHours = int.Parse(beginningTimeStr.Substring(0, 2));
            //    int beginningTimeMinutes = int.Parse(beginningTimeStr.Substring(3, 2));
            //    int beginningTimeSeconds = int.Parse(beginningTimeStr.Substring(6, 2));

            //    int endDateHours = int.Parse(endDateTimeStr.Substring(0, 2));
            //    int endDateMinutes = int.Parse(endDateTimeStr.Substring(3, 2));
            //    int endDateSeconds = int.Parse(endDateTimeStr.Substring(6, 2));
            //    // 開始日
            //    begDateTime = new DateTime(row.BeginningDate.Year, row.BeginningDate.Month, row.BeginningDate.Day,
            //        beginningTimeHours, beginningTimeMinutes, beginningTimeSeconds);
            //    // 終了日
            //    endDateTime = new DateTime(row.EndDate.Year, row.EndDate.Month, row.EndDate.Day,
            //        endDateHours, endDateMinutes, endDateSeconds);
            //}

            //String beginningDate = this.Condition_Grid.Rows[0].Cells[this._extractionConditionDataTable.BeginningDateColumn.ColumnName].Value.ToString().Trim();
            //String beginningTime = this.Condition_Grid.Rows[0].Cells[this._extractionConditionDataTable.BeginningTimeColumn.ColumnName].Value.ToString().Trim();
            //String endDate = this.Condition_Grid.Rows[0].Cells[this._extractionConditionDataTable.EndDateColumn.ColumnName].Value.ToString().Trim();
            //String endTime = this.Condition_Grid.Rows[0].Cells[this._extractionConditionDataTable.EndTimeColumn.ColumnName].Value.ToString().Trim();

            //// 開始日付
            //if (beginningDate == string.Empty)
            //{
            //    errMessage = string.Format("抽出開始日付{0}", ct_NoInput);
            //    this.Condition_Grid.ActiveCell = this.Condition_Grid.Rows[0].Cells[this._extractionConditionDataTable.BeginningDateColumn.ColumnName];

            //    status = false;

            //    return status;
            //}
            //// 開始時間
            //if (this.Condition_Grid.Rows[0].Cells[this._extractionConditionDataTable.BeginningTimeColumn.ColumnName].Value.ToString().Trim() == string.Empty)
            //{
            //    errMessage = string.Format("抽出開始時間{0}", ct_NoInput);
            //    this.Condition_Grid.ActiveCell = this.Condition_Grid.Rows[0].Cells[this._extractionConditionDataTable.BeginningTimeColumn.ColumnName];
            //    status = false;

            //    return status;
            //}
            //// 終了日付
            //if (this.Condition_Grid.Rows[0].Cells[this._extractionConditionDataTable.EndDateColumn.ColumnName].Value.ToString().Trim() == string.Empty)
            //{
            //    errMessage = string.Format("抽出終了日付{0}", ct_NoInput);
            //    this.Condition_Grid.ActiveCell = this.Condition_Grid.Rows[0].Cells[this._extractionConditionDataTable.EndDateColumn.ColumnName];
            //    status = false;

            //    return status;
            //}
            //// 終了時間
            //if (this.Condition_Grid.Rows[0].Cells[this._extractionConditionDataTable.EndTimeColumn.ColumnName].Value.ToString().Trim() == string.Empty)
            //{
            //    errMessage = string.Format("抽出終了時間{0}", ct_NoInput);
            //    this.Condition_Grid.ActiveCell = this.Condition_Grid.Rows[0].Cells[this._extractionConditionDataTable.EndTimeColumn.ColumnName];
            //    status = false;

            //    return status;
            //}

            //// 日付の範囲をチェック(開始日 > 終了日 → NG)
            //if (begDateTime > endDateTime)
            //{
            //    errMessage = ct_RangeError;
            //    this.Condition_Grid.ActiveCell = this.Condition_Grid.Rows[0].Cells[this._extractionConditionDataTable.BeginningDateColumn.ColumnName];
            //    status = false;
            //    return status;
            //}

            //// 更新画面の開始日付チェック
            //if (!this.UpdateOverData())
            //{
            //    errMessage = "送信対象拠点が設定されていません。";
            //    this.Condition_Grid.ActiveCell = this.Condition_Grid.Rows[0].Cells[this._extractionConditionDataTable.BeginningDateColumn.ColumnName];
            //    status = false;
            //    return status;
            //}

            //if (_startTime.Year == begDateTime.Year && _startTime.Month == begDateTime.Month && _startTime.Day == begDateTime.Day
            //     && _startTime.Hour == begDateTime.Hour && _startTime.Minute == begDateTime.Minute && _startTime.Second == begDateTime.Second)
            //{
            //    status = true;
            //}
            //else
            //{
            //    // シック時間チェック
            //    if (begDateTime < _startTime)
            //    {
            //        if (begDateTime.Year != endDateTime.Year || begDateTime.Month != endDateTime.Month)
            //        {
            //            errMessage = string.Format("開始日付{0}", ct_BeginTimeError);
            //            this.Condition_Grid.ActiveCell = this.Condition_Grid.Rows[0].Cells[this._extractionConditionDataTable.BeginningDateColumn.ColumnName];
            //            status = false;
            //            return status;
            //        }
            //    }
            //}
            #endregion DEL 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）
            //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
            if (string.IsNullOrEmpty(tEdit_SectionCode.DataText))
            {
                errMessage = string.Format("送信先{0}", ct_NoInput);
                tEdit_SectionCode.Focus();
                status = false;

                return status;
            }
            DateTime initbegDateTime = new DateTime();
            selectbaseCodeNameList = new ArrayList();
            ArrayList newSndDestCodeList = new ArrayList();
            _mstUpdCountAcs.ReloadSecMngSetInfo(_enterpriseCode, out newSndDestCodeList);
            for (int i = 0; i < this.Condition_Grid.Rows.Count; i++)
            {
                //チェックオンされた送信条件レコードはチェックを行う。
                if (((bool)this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.SendDestCondColumn.ColumnName].Value) == true)
                {
                    selectbaseCodeNameList.Add(this.sendDestSecList[i]);
                    //選択している送信先コードが削除されたかどうかチェック
                    if (!newSndDestCodeList.Contains(((BaseCodeNameWork)this.sendDestSecList[i]).SectionCode))
                    {
                        errMessage = string.Format("削除された送信先が存在します。");
                        status = false;
                        return status;
                    }
                    //----- ADD 2011.08.19 #23817----->>>>>
                    DateTime dtBeginDate = DateTime.MinValue;
                    if (this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.BeginningDateColumn.ColumnName].Value != null
                    && !String.IsNullOrEmpty(this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.BeginningDateColumn.ColumnName].Value.ToString()))
                    {
                        dtBeginDate = (DateTime)this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.BeginningDateColumn.ColumnName].Value;

                    }
                    DateTime dtEndDate = DateTime.MinValue;
                    if(this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.EndDateColumn.ColumnName].Value != null 
                    && !String.IsNullOrEmpty(this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.EndDateColumn.ColumnName].Value.ToString()))
                    {
                        dtEndDate = (DateTime)this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.EndDateColumn.ColumnName].Value;
                    }
                    DateTime dtInitBeginDate = DateTime.MinValue;
                    if (this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.InitBeginningDateColumn.ColumnName].Value != null
                        && !String.IsNullOrEmpty(this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.InitBeginningDateColumn.ColumnName].Value.ToString()))
                    {
                        dtInitBeginDate = (DateTime)this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.InitBeginningDateColumn.ColumnName].Value;

                    }
                    //----- ADD 2011.08.19 #23817-----<<<<<
                    String initbeginningDate = this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.InitBeginningDateColumn.ColumnName].Value.ToString().Trim();
                    String initbeginningTime = this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.InitBeginningTimeColumn.ColumnName].Value.ToString().Trim();
                    String beginningDate = this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.BeginningDateColumn.ColumnName].Value.ToString().Trim();
                    String beginningTime = this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.BeginningTimeColumn.ColumnName].Value.ToString().Trim();
                    String endDate = this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.EndDateColumn.ColumnName].Value.ToString().Trim();
                    String endTime = this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.EndTimeColumn.ColumnName].Value.ToString().Trim();

                    //抽出条件区分が｢差分｣の場合、開始日付、開始時間、終了日付、終了時間の入力チェックを行う
                    if (this.tce_ExtractCondDiv.SelectedIndex == 0)
                    {
                        // 開始日付
                        if (beginningDate == string.Empty)
                        {
                            errMessage = string.Format("抽出開始日付{0}", ct_NoInput);
                            this.Condition_Grid.ActiveCell = this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.BeginningDateColumn.ColumnName];
                            this.ultraTabControl1.SelectedTab = this.ultraTabControl1.Tabs["searchTab"];
                            status = false;

                            return status;
                        }
                        // 開始時間
                        if (this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.BeginningTimeColumn.ColumnName].Value.ToString().Trim() == string.Empty)
                        {
                            errMessage = string.Format("抽出開始時間{0}", ct_NoInput);
                            this.Condition_Grid.ActiveCell = this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.BeginningTimeColumn.ColumnName];
                            this.ultraTabControl1.SelectedTab = this.ultraTabControl1.Tabs["searchTab"];
                            status = false;

                            return status;
                        }
                        // 終了日付
                        if (this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.EndDateColumn.ColumnName].Value.ToString().Trim() == string.Empty)
                        {
                            errMessage = string.Format("抽出終了日付{0}", ct_NoInput);
                            this.Condition_Grid.ActiveCell = this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.EndDateColumn.ColumnName];
                            this.ultraTabControl1.SelectedTab = this.ultraTabControl1.Tabs["searchTab"];
                            status = false;

                            return status;
                        }
                        // 終了時間
                        if (this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.EndTimeColumn.ColumnName].Value.ToString().Trim() == string.Empty)
                        {
                            errMessage = string.Format("抽出終了時間{0}", ct_NoInput);
                            this.Condition_Grid.ActiveCell = this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.EndTimeColumn.ColumnName];
                            this.ultraTabControl1.SelectedTab = this.ultraTabControl1.Tabs["searchTab"];
                            status = false;

                            return status;
                        }

                        //----- DEL 2011.08.19 #23817----->>>>>
                        //int initbeginningDateYear = int.Parse(initbeginningDate.Substring(0, 4));
                        //int initbeginningDateMonth = int.Parse(initbeginningDate.Substring(5, 2));
                        //int initbeginningDateDay = int.Parse(initbeginningDate.Substring(8, 2));
                        //----- DEL 2011.08.19 #23817-----<<<<<
                        //----- ADD 2011.08.19 #23817----->>>>>
                        int initbeginningDateYear = dtInitBeginDate.Year;
                        int initbeginningDateMonth = dtInitBeginDate.Month;
                        int initbeginningDateDay = dtInitBeginDate.Day;
                        //----- ADD 2011.08.19 #23817-----<<<<<
                        int initbeginningTimeHours = int.Parse(initbeginningTime.Substring(0, 2));
                        int initbeginningTimeMinutes = int.Parse(initbeginningTime.Substring(3, 2));
                        int initbeginningTimeSeconds = int.Parse(initbeginningTime.Substring(6, 2));

                        //----- DEL 2011.08.19 #23817----->>>>>
                        //int beginningDateYear = int.Parse(beginningDate.Substring(0, 4));
                        //int beginningDateMonth = int.Parse(beginningDate.Substring(5, 2));
                        //int beginningDateDay = int.Parse(beginningDate.Substring(8, 2));
                        //----- DEL 2011.08.19 #23817-----<<<<<
                        //----- ADD 2011.08.19 #23817----->>>>>
                        int beginningDateYear = dtBeginDate.Year;
                        int beginningDateMonth = dtBeginDate.Month;
                        int beginningDateDay = dtBeginDate.Day;
                        //----- ADD 2011.08.19 #23817-----<<<<<
                        int beginningTimeHours = int.Parse(beginningTime.Substring(0, 2));
                        int beginningTimeMinutes = int.Parse(beginningTime.Substring(3, 2));
                        int beginningTimeSeconds = int.Parse(beginningTime.Substring(6, 2));

                        //----- DEL 2011.08.19 #23817----->>>>>
                        //int endDateYear = int.Parse(endDate.Substring(0, 4));
                        //int endDateMonth = int.Parse(endDate.Substring(5, 2));
                        //int endDateDay = int.Parse(endDate.Substring(8, 2));
                        //----- DEL 2011.08.19 #23817-----<<<<<
                        //----- ADD 2011.08.19 #23817----->>>>>
                        int endDateYear = dtEndDate.Year;
                        int endDateMonth = dtEndDate.Month;
                        int endDateDay = dtEndDate.Day;
                        //----- ADD 2011.08.19 #23817-----<<<<<
                        int endDateHours = int.Parse(endTime.Substring(0, 2));
                        int endDateMinutes = int.Parse(endTime.Substring(3, 2));
                        int endDateSeconds = int.Parse(endTime.Substring(6, 2));

                        //初期開始日
                        initbegDateTime = new DateTime(initbeginningDateYear, initbeginningDateMonth, initbeginningDateDay,
                           initbeginningTimeHours, initbeginningTimeMinutes, initbeginningTimeSeconds);
                        // 開始日
                        begDateTime = new DateTime(beginningDateYear, beginningDateMonth, beginningDateDay,
                           beginningTimeHours, beginningTimeMinutes, beginningTimeSeconds);
                        // 終了日
                        endDateTime = new DateTime(endDateYear, endDateMonth, endDateDay,
                            endDateHours, endDateMinutes, endDateSeconds);

                        // 日付の範囲をチェック(開始日 > 終了日 → NG)
                        if (begDateTime > endDateTime)
                        {
                            errMessage = ct_RangeError;
                            this.Condition_Grid.ActiveCell = this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.BeginningDateColumn.ColumnName];
                            this.ultraTabControl1.SelectedTab = this.ultraTabControl1.Tabs["searchTab"];
                            status = false;
                            return status;
                        }
                        
                        // 更新画面の開始日付チェック
                        //if (!this.UpdateOverData())
                        //{
                        //    errMessage = "送信対象拠点が設定されていません。";
                        //    this.Condition_Grid.ActiveCell = this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.BeginningDateColumn.ColumnName];
                        //    status = false;
                        //    return status;
                        //}

                        if (initbegDateTime.Year == begDateTime.Year && initbegDateTime.Month == begDateTime.Month && initbegDateTime.Day == begDateTime.Day
                                && initbegDateTime.Hour == begDateTime.Hour && initbegDateTime.Minute == begDateTime.Minute && initbegDateTime.Second == begDateTime.Second)
                        {
                            status = true;
                        }
                        else
                        {
                            // シック時間チェック
                            if (begDateTime < initbegDateTime)
                            {
                                if (begDateTime.Year != endDateTime.Year || begDateTime.Month != endDateTime.Month)
                                {
                                    errMessage = string.Format("抽出開始日付{0}", ct_BeginTimeError);
                                    this.Condition_Grid.ActiveCell = this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.BeginningDateColumn.ColumnName];
                                    this.ultraTabControl1.SelectedTab = this.ultraTabControl1.Tabs["searchTab"];
                                    status = false;
                                    return status;
                                }
                            }
                        }
                    }
                    //抽出条件区分が｢条件｣の場合
                    else
                    {
                        ExtractionConditionDataSet.ExtractionConditionRow row = (ExtractionConditionDataSet.ExtractionConditionRow)this._mstUpdCountAcs.ExtractionConditionDataTable[i];

                        if ((!string.IsNullOrEmpty(beginningDate) && row.BeginningDate != DateTime.MinValue) 
                            || (!string.IsNullOrEmpty(beginningTime)))
                        {
                            //開始日付が入力されない場合
                            if (string.IsNullOrEmpty(beginningDate))
                            {
                                errMessage = string.Format("抽出開始日付{0}", ct_NoInput);
                                this.Condition_Grid.ActiveCell = this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.BeginningDateColumn.ColumnName];
                                this.ultraTabControl1.SelectedTab = this.ultraTabControl1.Tabs["searchTab"];
                                status = false;
                                return status;
                            }
                            //開始時間が入力されない場合
                            if (string.IsNullOrEmpty(beginningTime))
                            {
                                errMessage = string.Format("抽出開始時間{0}", ct_NoInput);
                                this.Condition_Grid.ActiveCell = this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.BeginningTimeColumn.ColumnName];
                                this.ultraTabControl1.SelectedTab = this.ultraTabControl1.Tabs["searchTab"];
                                status = false;

                                return status;
                            }
                        }

                        if ((!string.IsNullOrEmpty(endDate) && row.EndDate != DateTime.MinValue)
                            || !string.IsNullOrEmpty(endTime))
                        {
                            //終了日付が入力されない場合
                            if (string.IsNullOrEmpty(endDate))
                            {
                                errMessage = string.Format("抽出終了日付{0}", ct_NoInput);
                                this.Condition_Grid.ActiveCell = this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.EndDateColumn.ColumnName];
                                this.ultraTabControl1.SelectedTab = this.ultraTabControl1.Tabs["searchTab"];
                                status = false;
                                return status;
                            }
                            //終了時間が入力されない場合
                            if (string.IsNullOrEmpty(endTime))
                            {
                                errMessage = string.Format("抽出終了時間{0}", ct_NoInput);
                                this.Condition_Grid.ActiveCell = this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.EndTimeColumn.ColumnName];
                                this.ultraTabControl1.SelectedTab = this.ultraTabControl1.Tabs["searchTab"];
                                status = false;

                                return status;
                            }
                        }

                        //開始日付と終了日付が入力された場合、範囲チェックを行う
                        if ((!string.IsNullOrEmpty(beginningDate) && row.BeginningDate != DateTime.MinValue)
                            && (!string.IsNullOrEmpty(endDate) && row.EndDate != DateTime.MinValue))
                        {
                            //----- DEL 2011.08.19 #23817----->>>>>
                            //int beginningDateYear = int.Parse(beginningDate.Substring(0, 4));
                            //int beginningDateMonth = int.Parse(beginningDate.Substring(5, 2));
                            //int beginningDateDay = int.Parse(beginningDate.Substring(8, 2));
                            //----- DEL 2011.08.19 #23817-----<<<<<
                            //----- ADD 2011.08.19 #23817----->>>>>
                            int beginningDateYear = dtBeginDate.Year;
                            int beginningDateMonth = dtBeginDate.Month;
                            int beginningDateDay = dtBeginDate.Day;
                            //----- ADD 2011.08.19 #23817-----<<<<<
                            int beginningTimeHours = int.Parse(beginningTime.Substring(0, 2));
                            int beginningTimeMinutes = int.Parse(beginningTime.Substring(3, 2));
                            int beginningTimeSeconds = int.Parse(beginningTime.Substring(6, 2));

                            //----- DEL 2011.08.19 #23817----->>>>>
                            //int endDateYear = int.Parse(endDate.Substring(0, 4));
                            //int endDateMonth = int.Parse(endDate.Substring(5, 2));
                            //int endDateDay = int.Parse(endDate.Substring(8, 2));
                            //----- DEL 2011.08.19 #23817-----<<<<<
                            //----- ADD 2011.08.19 #23817----->>>>>
                            int endDateYear = dtEndDate.Year;
                            int endDateMonth = dtEndDate.Month;
                            int endDateDay = dtEndDate.Day;
                            //----- ADD 2011.08.19 #23817-----<<<<<
                            int endDateHours = int.Parse(endTime.Substring(0, 2));
                            int endDateMinutes = int.Parse(endTime.Substring(3, 2));
                            int endDateSeconds = int.Parse(endTime.Substring(6, 2));

                            // 開始日
                            begDateTime = new DateTime(beginningDateYear, beginningDateMonth, beginningDateDay,
                               beginningTimeHours, beginningTimeMinutes, beginningTimeSeconds);
                            // 終了日
                            endDateTime = new DateTime(endDateYear, endDateMonth, endDateDay,
                                endDateHours, endDateMinutes, endDateSeconds);

                            // 日付の範囲をチェック(開始日 > 終了日 → NG)
                            if (begDateTime > endDateTime)
                            {
                                errMessage = ct_RangeError;
                                this.Condition_Grid.ActiveCell = this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.BeginningDateColumn.ColumnName];
                                status = false;
                                return status;
                            }

                            this._customerProcParam.UpdateDateTimeBegin = begDateTime.Ticks;
                            this._customerProcParam.UpdateDateTimeEnd = endDateTime.Ticks;
                            this._goodsProcParam.UpdateDateTimeBegin = begDateTime.Ticks;
                            this._goodsProcParam.UpdateDateTimeEnd = endDateTime.Ticks;
                            this._stockProcParam.UpdateDateTimeBegin = begDateTime.Ticks;
                            this._stockProcParam.UpdateDateTimeEnd = endDateTime.Ticks;
                            this._supplierProcParam.UpdateDateTimeBegin = begDateTime.Ticks;
                            this._supplierProcParam.UpdateDateTimeEnd = endDateTime.Ticks;
                            this._rateProcParam.UpdateDateTimeBegin = begDateTime.Ticks;
                            this._rateProcParam.UpdateDateTimeEnd = endDateTime.Ticks;
                            // --- ADD 2012/07/26 ------------------------->>>>>
                            this._employeeProcParam.UpdateDateTimeBegin = begDateTime.Ticks;
                            this._employeeProcParam.UpdateDateTimeEnd = endDateTime.Ticks;
                            this._userGdBuyDivUProcParam.UpdateDateTimeBegin = begDateTime.Ticks;
                            this._userGdBuyDivUProcParam.UpdateDateTimeEnd = endDateTime.Ticks;
                            this._joinPartsUProcParam.UpdateDateTimeBegin = begDateTime.Ticks;
                            this._joinPartsUProcParam.UpdateDateTimeEnd = endDateTime.Ticks;
                            // --- ADD 2012/07/26 -------------------------<<<<<
                        }
                        else
                        {
                            this._customerProcParam.UpdateDateTimeBegin = 0;
                            this._customerProcParam.UpdateDateTimeEnd = 0;
                            this._goodsProcParam.UpdateDateTimeBegin = 0;
                            this._goodsProcParam.UpdateDateTimeEnd = 0;
                            this._stockProcParam.UpdateDateTimeBegin = 0;
                            this._stockProcParam.UpdateDateTimeEnd = 0;
                            this._supplierProcParam.UpdateDateTimeBegin = 0;
                            this._supplierProcParam.UpdateDateTimeEnd = 0;
                            this._rateProcParam.UpdateDateTimeBegin = 0;
                            this._rateProcParam.UpdateDateTimeEnd = 0;
                            // --- ADD 2012/07/26 ------------------------->>>>>
                            this._employeeProcParam.UpdateDateTimeBegin = 0;
                            this._employeeProcParam.UpdateDateTimeEnd = 0;
                            this._userGdBuyDivUProcParam.UpdateDateTimeBegin = 0;
                            this._userGdBuyDivUProcParam.UpdateDateTimeEnd = 0;
                            this._joinPartsUProcParam.UpdateDateTimeBegin = 0;
                            this._joinPartsUProcParam.UpdateDateTimeEnd = 0;
                            // --- ADD 2012/07/26 -------------------------<<<<<
                        }
                    }
                }
            }
            //送信先が1つでもチェックオンされない場合
            if (selectbaseCodeNameList.Count == 0)
            {
                errMessage = "送信先拠点が選択されていません。";
                this.ultraTabControl1.SelectedTab = this.ultraTabControl1.Tabs["searchTab"];
                status = false;
                return status;
            }
            //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<

            return status;
        }

        /// <summary>
        /// 送信更新時間の設定
        /// </summary>
        /// <remarks>		
        /// <br>Note		: 送信更新時間処理を行う。</br>
        /// <br>Programmer	: 譚洪</br>	
        /// <br>Date		: 2009.04.02</br>
        /// </remarks>
        private bool UpdateOverData()
        {
            bool isUpdate = true;
            DateTime startTimeBak = new DateTime();
            isUpdate = _mstUpdCountAcs.SendUpdateProc(_enterpriseCode, baseCodeNameList, out startTimeBak);
            if (isUpdate)
            {
                _startTime = startTimeBak;
            }
            else
            {
                isUpdate = false;
            }
            return isUpdate;
        }

        #endregion ■ マスタ送信メッソド関連 ■

        # region ■ マスタ受信メッソド関連 ■


        /// <summary>
        /// マスタ送信処理の入力チェック処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: マスタ送信処理の入力チェック処理を行う。</br>
        /// <br>Programmer	: 譚洪</br>
        /// <br>Date		: 2009.04.03</br>
        /// </remarks>
        private bool UpdateBeforeCheck()
        {
            bool status = true;

            string errMessage = "";

            // 画面データチェック処理
            if (!this.ScreenInputCheck(ref errMessage))
            {

                this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, errMessage, 0);

                status = false;
                return status;
            }

            if (0 == this.Acc_Grid.Rows.Count)
            {
                this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "送受信対象マスタが設定されていません。", 0);

                status = false;
                return status;
            }

            //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
            //条件送信の場合、送信対象を選択チェック
            selectMstNameList = new ArrayList();
            for (int i = 0; i < this.Acc_Grid.Rows.Count; i++)
            {
                if ((bool)this.Acc_Grid.Rows[i].Cells[this._updateResultDataTable.SendDestColumn.ColumnName].Value)
                {
                    foreach(SecMngSndRcvWork work in masterNameList)
                    {
                        if (work.MasterName.Equals(this.Acc_Grid.Rows[i].Cells[this._updateResultDataTable.ExtractionDataColumn.ColumnName].Value.ToString()))
                        {
                            selectMstNameList.Add(work);
                        }
                    }
                }
            }
            //抽出条件区分が｢条件｣の場合、送信対象が1つでもチェックオンされない場合
            if (this.tce_ExtractCondDiv.SelectedIndex == 1 && selectMstNameList.Count == 0)
            {
                this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "送信対象が選択されていません。", 0);

                status = false;
                return status;
            }
            //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<

            // 送信対象マスタチェック処理
            //if (!_mstUpdCountAcs.CheckMasterDiv(_enterpriseCode, masterNameList))
            //{
            //    this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "送信対象マスタが既に他端末より更新されています。", 0);

            //    status = false;
            //    return status;
            //}

            // 接続先チェック処理 
            if (!_mstUpdCountAcs.CheckConnect(_enterpriseCode, out _connectPointDiv, out errMessage))
            {
                this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, errMessage, 0);

                status = false;
                return status;
            }

            return status;
        }

        /// <summary>
        /// マスタ受信処理の入力チェック処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: マスタ受信処理の入力チェック処理を行う。</br>
        /// <br>Programmer	: 譚洪</br>
        /// <br>Date		: 2009.04.03</br>
        /// </remarks>
        private bool ReceUpdateBeforeCheck()
        {
            bool status = true;

            //-----DEL 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
            //string errMessage = "";

            //if (!this.ReceScreenInputCheck(ref errMessage))
            //{

            //    this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, errMessage, 0);

            //    status = false;
            //    return status;
            //}
            //-----DEL 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<

            if (0 == this.Bcc_Grid.Rows.Count)
            {
                this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "送受信対象マスタが設定されていません。", 0);

                status = false;
                return status;
            }

            // 送信対象マスタチェック処理
            //if (!_mstUpdCountAcs.CheckMasterDiv(_enterpriseCode, masterNameList))
            //{
            //    this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "送信対象マスタが既に他端末より更新されています。", 0);

            //    status = false;
            //    return status;
            //}

            // 接続先チェック処理 
            string errMsg = string.Empty;
            if (!_mstUpdCountAcs.CheckConnect(_enterpriseCode, out _connectPointDiv, out errMsg))
            {
                this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, errMsg, 0);

                status = false;
                return status;
            }

            return status;
        }

        /// <summary>
        /// 受信情報グリッド計数設定処理
        /// </summary>
        /// <remarks>		
        /// <br>Note		: 受信情報グリッド計数設定処理を行う。</br>
        /// <br>Programmer	: 譚洪</br>	
        /// <br>Date		: 2009.04.02</br>
        /// </remarks>
        private void ReceSearchResultDataGridCol(Hashtable countTable)
        {

            DataRow row = null;

            int rowNo = 0;
            foreach (SecMngSndRcvWork work in masterNameList)
            {
                rowNo = rowNo + 1;
                row = _receiveInfoTable.NewRow();
                row[_receiveInfoDataTable.RowNoColumn.ColumnName] = rowNo;
                row[_receiveInfoDataTable.MasterNameColumn.ColumnName] = work.MasterName;
                row[_receiveInfoDataTable.DisplayOrderColumn.ColumnName] = work.DisplayOrder; //ADD 2011/07/25
                //for (int i = 0; i < baseCodeNameList.Count; i++)//DEL 2011/07/25
                for (int i = 0; i < _sndRcvHisList.Count; i++)//ADD 2011/07/25
                {
                    //-----DEL 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
                    //BaseCodeNameWork baseCodeNameWork = (BaseCodeNameWork)this.baseCodeNameList[i];
                    //MstSearchCountWorkWork searchCountWork = (MstSearchCountWorkWork)countTable[baseCodeNameWork.SectionCode];
                    //-----DEL 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
                    //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
                    SndRcvHisWork sndRcvHisWork = (SndRcvHisWork)this._sndRcvHisList[i];
                    string key = sndRcvHisWork.EnterpriseCode + sndRcvHisWork.SectionCode.Trim() + sndRcvHisWork.SndRcvHisConsNo.ToString();
                    MstSearchCountWorkWork searchCountWork = (MstSearchCountWorkWork)countTable[key];
                    //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
                    // 更新エラーと検索エラーの場合、
                    if (searchCountWork.ErrorKubun == -1 || searchCountWork.ErrorKubun == -2)
                    {
                        // 拠点設定マスタ
                        if (MST_SECINFOSET.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = ERROR_BATU;//DEL 2011/07/25
                            row[key] = ERROR_BATU;//ADD 2011/07/25
                        }
                        // 部門設定マスタ
                        else if (MST_SUBSECTION.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = ERROR_BATU;//DEL 2011/07/25
                            row[key] = ERROR_BATU;//ADD 2011/07/25
                        }
                        // 倉庫設定マスタ
                        else if (MST_WAREHOUSE.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = ERROR_BATU;//DEL 2011/07/25
                            row[key] = ERROR_BATU;//ADD 2011/07/25
                        }
                        // 従業員設定マスタ
                        else if (MST_EMPLOYEE.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = ERROR_BATU;//DEL 2011/07/25
                            row[key] = ERROR_BATU;//ADD 2011/07/25
                        }
                        // ユーザーガイドマスタ(販売エリア区分）
                        else if (MST_USERGDAREADIVU.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = ERROR_BATU;//DEL 2011/07/25
                            row[key] = ERROR_BATU;//ADD 2011/07/25
                        }
                        // ユーザーガイドマスタ（業務区分）
                        else if (MST_USERGDBUSDIVU.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = ERROR_BATU;//DEL 2011/07/25
                            row[key] = ERROR_BATU;//ADD 2011/07/25
                        }
                        // ユーザーガイドマスタ（業種）
                        else if (MST_USERGDCATEU.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = ERROR_BATU;//DEL 2011/07/25
                            row[key] = ERROR_BATU;//ADD 2011/07/25
                        }
                        // ユーザーガイドマスタ（職種）
                        else if (MST_USERGDBUSU.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = ERROR_BATU;//DEL 2011/07/25
                            row[key] = ERROR_BATU;//ADD 2011/07/25
                        }
                        // ユーザーガイドマスタ（商品区分）
                        else if (MST_USERGDGOODSDIVU.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = ERROR_BATU;//DEL 2011/07/25
                            row[key] = ERROR_BATU;//ADD 2011/07/25
                        }
                        // ユーザーガイドマスタ（得意先掛率グループ）
                        else if (MST_USERGDCUSGROUPU.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = ERROR_BATU;//DEL 2011/07/25
                            row[key] = ERROR_BATU;//ADD 2011/07/25
                        }
                        // ユーザーガイドマスタ（銀行）
                        else if (MST_USERGDBANKU.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = ERROR_BATU;//DEL 2011/07/25
                            row[key] = ERROR_BATU;//ADD 2011/07/25
                        }
                        // ユーザーガイドマスタ（価格区分）
                        else if (MST_USERGDPRIDIVU.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = ERROR_BATU;//DEL 2011/07/25
                            row[key] = ERROR_BATU;//ADD 2011/07/25
                        }
                        // ユーザーガイドマスタ（納品区分）
                        else if (MST_USERGDDELIDIVU.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = ERROR_BATU;//DEL 2011/07/25
                            row[key] = ERROR_BATU;//ADD 2011/07/25
                        }
                        // ユーザーガイドマスタ（商品大分類）
                        else if (MST_USERGDGOODSBIGU.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = ERROR_BATU;//DEL 2011/07/25
                            row[key] = ERROR_BATU;//ADD 2011/07/25
                        }
                        // ユーザーガイドマスタ（販売区分）
                        else if (MST_USERGDBUYDIVU.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = ERROR_BATU;//DEL 2011/07/25
                            row[key] = ERROR_BATU;//ADD 2011/07/25
                        }
                        // ユーザーガイドマスタ（在庫管理区分１）
                        else if (MST_USERGDSTOCKDIVOU.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = ERROR_BATU;//DEL 2011/07/25
                            row[key] = ERROR_BATU;//ADD 2011/07/25
                        }
                        // ユーザーガイドマスタ（在庫管理区分２）
                        else if (MST_USERGDSTOCKDIVTU.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = ERROR_BATU;//DEL 2011/07/25
                            row[key] = ERROR_BATU;//ADD 2011/07/25
                        }
                        // ユーザーガイドマスタ（返品理由）
                        else if (MST_USERGDRETURNREAU.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = ERROR_BATU;//DEL 2011/07/25
                            row[key] = ERROR_BATU;//ADD 2011/07/25
                        }
                        // 掛率優先管理マスタ
                        else if (MST_RATEPROTYMNG.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = ERROR_BATU;//DEL 2011/07/25
                            row[key] = ERROR_BATU;//ADD 2011/07/25
                        }
                        // 掛率マスタ
                        else if (MST_RATE.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = ERROR_BATU;//DEL 2011/07/25
                            row[key] = ERROR_BATU;//ADD 2011/07/25
                        }
                        // 売上目標設定マスタ
                        else if (MST_SALESTARGET.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = ERROR_BATU;//DEL 2011/07/25
                            row[key] = ERROR_BATU;//ADD 2011/07/25
                        }
                        // 得意先マスタ
                        else if (MST_CUSTOME.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = ERROR_BATU;//DEL 2011/07/25
                            row[key] = ERROR_BATU;//ADD 2011/07/25
                        }
                        // 仕入先マスタ
                        else if (MST_SUPPLIER.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = ERROR_BATU;//DEL 2011/07/25
                            row[key] = ERROR_BATU;//ADD 2011/07/25
                        }
                        // 結合マスタ
                        else if (MST_JOINPARTSU.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = ERROR_BATU;//DEL 2011/07/25
                            row[key] = ERROR_BATU;//ADD 2011/07/25
                        }
                        // セットマスタ
                        else if (MST_GOODSSET.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = ERROR_BATU;//DEL 2011/07/25
                            row[key] = ERROR_BATU;//ADD 2011/07/25
                        }
                        // ＴＢＯマスタ
                        else if (MST_TBOSEARCHU.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = ERROR_BATU;//DEL 2011/07/25
                            row[key] = ERROR_BATU;//ADD 2011/07/25
                        }
                        // 車種マスタ
                        else if (MST_MODELNAMEU.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = ERROR_BATU;//DEL 2011/07/25
                            row[key] = ERROR_BATU;//ADD 2011/07/25
                        }
                        // ＢＬコードマスタ
                        else if (MST_BLGOODSCDU.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = ERROR_BATU;//DEL 2011/07/25
                            row[key] = ERROR_BATU;//ADD 2011/07/25
                        }
                        // メーカーマスタ
                        else if (MST_MAKERU.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = ERROR_BATU;//DEL 2011/07/25
                            row[key] = ERROR_BATU;//ADD 2011/07/25
                        }
                        // 商品中分類マスタ
                        else if (MST_GOODSMGROUPU.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = ERROR_BATU;//DEL 2011/07/25
                            row[key] = ERROR_BATU;//ADD 2011/07/25
                        }
                        // グループコードマスタ
                        else if (MST_BLGROUPU.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = ERROR_BATU;//DEL 2011/07/25
                            row[key] = ERROR_BATU;//ADD 2011/07/25
                        }
                        // BLコードガイドマスタ
                        else if (MST_BLCODEGUIDE.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = ERROR_BATU;//DEL 2011/07/25
                            row[key] = ERROR_BATU;//ADD 2011/07/25
                        }
                        // 商品マスタ
                        else if (MST_GOODSU.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = ERROR_BATU;//DEL 2011/07/25
                            row[key] = ERROR_BATU;//ADD 2011/07/25
                        }
                        // 在庫マスタ
                        else if (MST_STOCK.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = ERROR_BATU;//DEL 2011/07/25
                            row[key] = ERROR_BATU;//ADD 2011/07/25
                        }
                        // 代替マスタ
                        else if (MST_PARTSSUBSTU.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = ERROR_BATU;//DEL 2011/07/25
                            row[key] = ERROR_BATU;//ADD 2011/07/25
                        }
                        // 部位マスタ
                        else if (MST_PARTSPOSCODEU.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = ERROR_BATU;//DEL 2011/07/25
                            row[key] = ERROR_BATU;//ADD 2011/07/25
                        }

                        if (searchCountWork.ErrorKubun == -2)
                        {
                            // メッセージを表示
                            this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "処理が込み合っているためタイムアウトしました。\n再試行するか、しばらく待ってから再度処理を行ってください。", 0);
                        }
                    }
                    else
                    {
                        // 拠点設定マスタ
                        if (MST_SECINFOSET.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = this.IntConvert(searchCountWork.SecInfoSetCount);//DEL 2011/07/25
                            row[key] = this.IntConvert(searchCountWork.SecInfoSetCount);//ADD 2011/07/25
                        }
                        // 部門設定マスタ
                        else if (MST_SUBSECTION.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = this.IntConvert(searchCountWork.SubSectionCount);//DEL 2011/07/25
                            row[key] = this.IntConvert(searchCountWork.SubSectionCount);//ADD 2011/07/25
                        }
                        // 倉庫設定マスタ
                        else if (MST_WAREHOUSE.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = this.IntConvert(searchCountWork.WarehouseCount);//DEL 2011/07/25
                            row[key] = this.IntConvert(searchCountWork.WarehouseCount);//ADD 2011/07/25
                        }
                        // 従業員設定マスタ
                        else if (MST_EMPLOYEE.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = this.IntConvert(searchCountWork.EmployeeCount + searchCountWork.EmployeeDtlCount);//DEL 2011/07/25
                            // --- DEL 2012/07/26 ---------------------------->>>>>
                            //row[key] = this.IntConvert(searchCountWork.EmployeeCount + searchCountWork.EmployeeDtlCount);//ADD 2011/07/25
                            // --- DEL 2012/07/26 ----------------------------<<<<<
                            // --- ADD 2012/07/26 ---------------------------->>>>>
                            // 差分の場合
                            if (sndRcvHisWork.SndLogExtraCondDiv == 0)
                            {
                                row[key] = this.IntConvert(searchCountWork.EmployeeCount + searchCountWork.EmployeeDtlCount);
                            }
                            else
                            {
                                row[key] = this.IntConvert(searchCountWork.EmployeeCount);
                            }
                            // --- ADD 2012/07/26 ----------------------------<<<<<
                        }
                        // ユーザーガイドマスタ(販売エリア区分）
                        else if (MST_USERGDAREADIVU.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = this.IntConvert(searchCountWork.UserGdAreaDivUCount);//DEL 2011/07/25
                            row[key] = this.IntConvert(searchCountWork.UserGdAreaDivUCount);//ADD 2011/07/25
                        }
                        // ユーザーガイドマスタ（業務区分）
                        else if (MST_USERGDBUSDIVU.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = this.IntConvert(searchCountWork.UserGdBusDivUCount);//DEL 2011/07/25
                            row[key] = this.IntConvert(searchCountWork.UserGdBusDivUCount);//ADD 2011/07/25
                        }
                        // ユーザーガイドマスタ（業種）
                        else if (MST_USERGDCATEU.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = this.IntConvert(searchCountWork.UserGdCateUCount);//DEL 2011/07/25
                            row[key] = this.IntConvert(searchCountWork.UserGdCateUCount);//ADD 2011/07/25
                        }
                        // ユーザーガイドマスタ（職種）
                        else if (MST_USERGDBUSU.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = this.IntConvert(searchCountWork.UserGdBusUCount);//DEL 2011/07/25
                            row[key] = this.IntConvert(searchCountWork.UserGdBusUCount);//ADD 2011/07/25
                        }
                        // ユーザーガイドマスタ（商品区分）
                        else if (MST_USERGDGOODSDIVU.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = this.IntConvert(searchCountWork.UserGdGoodsDivUCount);//DEL 2011/07/25
                            row[key] = this.IntConvert(searchCountWork.UserGdGoodsDivUCount);//ADD 2011/07/25
                        }
                        // ユーザーガイドマスタ（得意先掛率グループ）
                        else if (MST_USERGDCUSGROUPU.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = this.IntConvert(searchCountWork.UserGdCusGrouPUCount);//DEL 2011/07/25
                            row[key] = this.IntConvert(searchCountWork.UserGdCusGrouPUCount);//ADD 2011/07/25
                        }
                        // ユーザーガイドマスタ（銀行）
                        else if (MST_USERGDBANKU.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = this.IntConvert(searchCountWork.UserGdBankUCount);//DEL 2011/07/25
                            row[key] = this.IntConvert(searchCountWork.UserGdBankUCount);//ADD 2011/07/25
                        }
                        // ユーザーガイドマスタ（価格区分）
                        else if (MST_USERGDPRIDIVU.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = this.IntConvert(searchCountWork.UserGdPriDivUCount);//DEL 2011/07/25
                            row[key] = this.IntConvert(searchCountWork.UserGdPriDivUCount);//ADD 2011/07/25
                        }
                        // ユーザーガイドマスタ（納品区分）
                        else if (MST_USERGDDELIDIVU.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = this.IntConvert(searchCountWork.UserGdDeliDivUCount);//DEL 2011/07/25
                            row[key] = this.IntConvert(searchCountWork.UserGdDeliDivUCount);//ADD 2011/07/25
                        }
                        // ユーザーガイドマスタ（商品大分類）
                        else if (MST_USERGDGOODSBIGU.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = this.IntConvert(searchCountWork.UserGdGoodsBigUCount);//DEL 2011/07/25
                            row[key] = this.IntConvert(searchCountWork.UserGdGoodsBigUCount);//ADD 2011/07/25
                        }
                        // ユーザーガイドマスタ（販売区分）
                        else if (MST_USERGDBUYDIVU.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = this.IntConvert(searchCountWork.UserGdBuyDivUCount);//DEL 2011/07/25
                            row[key] = this.IntConvert(searchCountWork.UserGdBuyDivUCount);//ADD 2011/07/25
                        }
                        // MOD 2009/06/16 ---->>>
                        // ユーザーガイドマスタ（在庫管理区分１）
                        else if (MST_USERGDSTOCKDIVOU.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = this.IntConvert(searchCountWork.UserGdStockDivOUCount);//DEL 2011/07/25
                            row[key] = this.IntConvert(searchCountWork.UserGdStockDivOUCount);//ADD 2011/07/25
                        }
                        // ユーザーガイドマスタ（在庫管理区分２）
                        else if (MST_USERGDSTOCKDIVTU.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = this.IntConvert(searchCountWork.UserGdStockDivTUCount);//DEL 2011/07/25
                            row[key] = this.IntConvert(searchCountWork.UserGdStockDivTUCount);//ADD 2011/07/25
                        }
                        // ユーザーガイドマスタ（返品理由）
                        else if (MST_USERGDRETURNREAU.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = this.IntConvert(searchCountWork.UserGdReturnReaUCount);//DEL 2011/07/25
                            row[key] = this.IntConvert(searchCountWork.UserGdReturnReaUCount);//ADD 2011/07/25
                        }
                        // MOD 2009/06/16 ----<<<
                        // 掛率優先管理マスタ
                        else if (MST_RATEPROTYMNG.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = this.IntConvert(searchCountWork.RateProtyMngCount);//DEL 2011/07/25
                            row[key] = this.IntConvert(searchCountWork.RateProtyMngCount);//ADD 2011/07/25
                        }
                        // 掛率マスタ
                        else if (MST_RATE.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = this.IntConvert(searchCountWork.RateCount);//DEL 2011/07/25
                            row[key] = this.IntConvert(searchCountWork.RateCount);//ADD 2011/07/25
                        }
                        // 売上目標設定マスタ
                        else if (MST_SALESTARGET.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = this.IntConvert(searchCountWork.EmpSalesTargetCount + searchCountWork.CustSalesTargetCount + searchCountWork.GcdSalesTargetCount);//DEL 2011/07/25
                            row[key] = this.IntConvert(searchCountWork.EmpSalesTargetCount + searchCountWork.CustSalesTargetCount + searchCountWork.GcdSalesTargetCount);//ADD 2011/07/25
                        }
                        // 得意先マスタ
                        else if (MST_CUSTOME.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = this.IntConvert(searchCountWork.CustomerCount + searchCountWork.CustomerChangeCount + searchCountWork.CustRateGroupCount
                            //    + searchCountWork.CustSlipMngCount + searchCountWork.CustSlipNoSetCount);//DEL 2011/07/25
                            // ------ UPD 2021/04/12 陳艶丹 FOR PMKOBETSU-4136-------->>>>>
                            //row[key] = this.IntConvert(searchCountWork.CustomerCount + searchCountWork.CustomerChangeCount + searchCountWork.CustRateGroupCount
                            //    + searchCountWork.CustSlipMngCount + searchCountWork.CustSlipNoSetCount);//ADD 2011/07/25
                            row[key] = this.IntConvert(searchCountWork.CustomerCount + searchCountWork.CustomerChangeCount + searchCountWork.CustRateGroupCount
                                + searchCountWork.CustSlipMngCount + searchCountWork.CustSlipNoSetCount + searchCountWork.CustomerMemoCount);
                            // ------ UPD 2021/04/12 陳艶丹 FOR PMKOBETSU-4136--------<<<<<
                        }
                        // 仕入先マスタ
                        else if (MST_SUPPLIER.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = this.IntConvert(searchCountWork.SupplierCount);//DEL 2011/07/25
                            row[key] = this.IntConvert(searchCountWork.SupplierCount);//ADD 2011/07/25
                        }
                        // 結合マスタ
                        else if (MST_JOINPARTSU.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = this.IntConvert(searchCountWork.JoinPartsUCount);//DEL 2011/07/25
                            row[key] = this.IntConvert(searchCountWork.JoinPartsUCount);//ADD 2011/07/25
                        }
                        // セットマスタ
                        else if (MST_GOODSSET.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = this.IntConvert(searchCountWork.GoodsSetCount);//DEL 2011/07/25
                            row[key] = this.IntConvert(searchCountWork.GoodsSetCount);//ADD 2011/07/25
                        }
                        // ＴＢＯマスタ
                        else if (MST_TBOSEARCHU.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = this.IntConvert(searchCountWork.TBOSearchUCount);//DEL 2011/07/25
                            row[key] = this.IntConvert(searchCountWork.TBOSearchUCount);//ADD 2011/07/25
                        }
                        // 車種マスタ
                        else if (MST_MODELNAMEU.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = this.IntConvert(searchCountWork.ModelNameUCount);//DEL 2011/07/25
                            row[key] = this.IntConvert(searchCountWork.ModelNameUCount);//ADD 2011/07/25
                        }
                        // ＢＬコードマスタ
                        else if (MST_BLGOODSCDU.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = this.IntConvert(searchCountWork.BLGoodsCdUCount);//DEL 2011/07/25
                            row[key] = this.IntConvert(searchCountWork.BLGoodsCdUCount);//ADD 2011/07/25
                        }
                        // メーカーマスタ
                        else if (MST_MAKERU.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = this.IntConvert(searchCountWork.MakerUCount);//DEL 2011/07/25
                            row[key] = this.IntConvert(searchCountWork.MakerUCount);//ADD 2011/07/25
                        }
                        // 商品中分類マスタ
                        else if (MST_GOODSMGROUPU.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = this.IntConvert(searchCountWork.GoodsMGroupUCount);//DEL 2011/07/25
                            row[key] = this.IntConvert(searchCountWork.GoodsMGroupUCount);//ADD 2011/07/25
                        }
                        // グループコードマスタ
                        else if (MST_BLGROUPU.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = this.IntConvert(searchCountWork.BLGroupUCount);//DEL 2011/07/25
                            row[key] = this.IntConvert(searchCountWork.BLGroupUCount);//ADD 2011/07/25
                        }
                        // BLコードガイドマスタ
                        else if (MST_BLCODEGUIDE.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = this.IntConvert(searchCountWork.BLCodeGuideCount);//DEL 2011/07/25
                            row[key] = this.IntConvert(searchCountWork.BLCodeGuideCount);//ADD 2011/07/25
                        }
                        // 商品マスタ
                        else if (MST_GOODSU.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = this.IntConvert(searchCountWork.GoodsMngCount + searchCountWork.GoodsPriceCount + searchCountWork.GoodsUCount
                            //    + searchCountWork.IsolIslandPrcCount);//DEL 2011/07/25
                            row[key] = this.IntConvert(searchCountWork.GoodsMngCount + searchCountWork.GoodsPriceCount + searchCountWork.GoodsUCount
                                + searchCountWork.IsolIslandPrcCount);//ADD 2011/07/25
                        }
                        // 在庫マスタ
                        else if (MST_STOCK.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = this.IntConvert(searchCountWork.StockCount);//DEL 2011/07/25
                            row[key] = this.IntConvert(searchCountWork.StockCount);//ADD 2011/07/25
                        }
                        // 代替マスタ
                        else if (MST_PARTSSUBSTU.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = this.IntConvert(searchCountWork.PartsSubstUCount);//DEL 2011/07/25
                            row[key] = this.IntConvert(searchCountWork.PartsSubstUCount);//ADD 2011/07/25
                        }
                        // 部位マスタ
                        else if (MST_PARTSPOSCODEU.Equals(work.MasterName))
                        {
                            //row[baseCodeNameWork.SectionCode] = this.IntConvert(searchCountWork.PartsPosCodeUCount);//DEL 2011/07/25
                            row[key] = this.IntConvert(searchCountWork.PartsPosCodeUCount);//ADD 2011/07/25
                        }
                    }
                }
                _receiveInfoTable.Rows.Add(row);
            }
        }

        /// <summary>
        /// 受信更新チェック処理
        /// </summary>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <returns>True:OK, False:NG</returns>
        /// <remarks>
        /// <br>Note		: 画面の受信更新チェックを行う。</br>
        /// <br>Programmer	: 譚洪</br>
        /// <br>Date		: 2009.04.03</br>
        /// </remarks>
        private bool ReceScreenInputCheck(ref string errMessage)
        {
            bool status = true;

            const string ct_NoInput = "が未入力です。";
            const string ct_RangeError = "抽出日付の範囲が不正です。";
            const string ct_BeginTimeError = "の変更時は同一月内のみ設定が可能です。";

            DateTime begDateTime = new DateTime();
            DateTime endDateTime = new DateTime();

            String beginningDate = string.Empty;
            String beginningTime = string.Empty;
            String endDate = string.Empty;
            String endTime = string.Empty;

            Int32 rowConut = 0;
            // 日付の範囲チェック用(開始日 > 終了日 → NG)
            foreach (ReceiveConditionDataSet.ReceiveConditionRow row in this._mstUpdCountAcs.ReceiveConditionDataTable)
            {
                // 開始日付
                if (row.IsNull(this._receiveConditionDataTable.BeginningDateColumn.ColumnName))
                {
                    beginningDate = string.Empty;
                }
                else
                {
                    beginningDate = this.BCondition_Grid.Rows[rowConut].Cells[this._receiveConditionDataTable.BeginningDateColumn.ColumnName].Value.ToString().Trim();
                }
                // 開始時間
                if (row.IsNull(this._receiveConditionDataTable.BeginningTimeColumn.ColumnName))
                {
                    beginningTime = string.Empty;
                }
                else
                {
                    beginningTime = this.BCondition_Grid.Rows[rowConut].Cells[this._receiveConditionDataTable.BeginningTimeColumn.ColumnName].Value.ToString().Trim();
                }
                // 終了日付
                if (row.IsNull(this._receiveConditionDataTable.EndDateColumn.ColumnName))
                {
                    endDate = string.Empty;
                }
                else
                {
                    endDate = this.BCondition_Grid.Rows[rowConut].Cells[this._receiveConditionDataTable.EndDateColumn.ColumnName].Value.ToString().Trim();
                }
                // 終了時間
                if (row.IsNull(this._receiveConditionDataTable.EndTimeColumn.ColumnName))
                {
                    endTime = string.Empty;
                }
                else
                {
                    endTime = this.BCondition_Grid.Rows[rowConut].Cells[this._receiveConditionDataTable.EndTimeColumn.ColumnName].Value.ToString().Trim();
                }

                // 開始日付
                if (beginningDate == string.Empty)
                {
                    errMessage = string.Format("抽出開始日付{0}", ct_NoInput);
                    this.BCondition_Grid.ActiveCell = this.BCondition_Grid.Rows[rowConut].Cells[this._receiveConditionDataTable.BeginningDateColumn.ColumnName];

                    status = false;

                    return status;
                }
                // 開始時間
                if (beginningTime == string.Empty)
                {
                    errMessage = string.Format("抽出開始時間{0}", ct_NoInput);
                    this.BCondition_Grid.ActiveCell = this.BCondition_Grid.Rows[rowConut].Cells[this._receiveConditionDataTable.BeginningTimeColumn.ColumnName];
                    status = false;

                    return status;
                }
                // 終了日付
                if (endDate == string.Empty)
                {
                    errMessage = string.Format("抽出終了日付{0}", ct_NoInput);
                    this.BCondition_Grid.ActiveCell = this.BCondition_Grid.Rows[rowConut].Cells[this._receiveConditionDataTable.EndDateColumn.ColumnName];
                    status = false;

                    return status;
                }
                // 終了時間
                if (endTime == string.Empty)
                {
                    errMessage = string.Format("抽出終了時間{0}", ct_NoInput);
                    this.BCondition_Grid.ActiveCell = this.BCondition_Grid.Rows[rowConut].Cells[this._receiveConditionDataTable.EndTimeColumn.ColumnName];
                    status = false;

                    return status;
                }

                String beginningTimeStr = row.BeginningTime;
                String endDateTimeStr = row.EndTime;

                int beginningTimeHours = int.Parse(beginningTimeStr.Substring(0, 2));
                int beginningTimeMinutes = int.Parse(beginningTimeStr.Substring(3, 2));
                int beginningTimeSeconds = int.Parse(beginningTimeStr.Substring(6, 2));

                int endDateHours = int.Parse(endDateTimeStr.Substring(0, 2));
                int endDateMinutes = int.Parse(endDateTimeStr.Substring(3, 2));
                int endDateSeconds = int.Parse(endDateTimeStr.Substring(6, 2));

                // 開始日
                begDateTime = new DateTime(row.BeginningDate.Year, row.BeginningDate.Month, row.BeginningDate.Day,
                    beginningTimeHours, beginningTimeMinutes, beginningTimeSeconds);
                // 終了日
                endDateTime = new DateTime(row.EndDate.Year, row.EndDate.Month, row.EndDate.Day,
                    endDateHours, endDateMinutes, endDateSeconds);

                // 日付の範囲をチェック(開始日 > 終了日 → NG)
                if (begDateTime > endDateTime)
                {
                    errMessage = ct_RangeError;
                    this.BCondition_Grid.ActiveCell = this.BCondition_Grid.Rows[rowConut].Cells[this._receiveConditionDataTable.BeginningDateColumn.ColumnName];
                    status = false;
                    return status;
                }
                bool isTimeOut = false;
                // 更新画面の開始日付チェック
                if (!this.ReceUpdateOverData(out isTimeOut))
                {
                    //errMessage = "受信対象拠点が設定されていません。";//DEL 2011/08/23 #23890 受信データがない場合について
                    errMessage = "抽出対象のデータが存在しません。";//ADD 2011/08/23 #23890 受信データがない場合について
                    this.BCondition_Grid.ActiveCell = this.BCondition_Grid.Rows[rowConut].Cells[this._receiveConditionDataTable.BeginningDateColumn.ColumnName];
                    status = false;
                    return status;
                }
                // ADD 2009/07/06 --->>>
                if (isTimeOut)
                {
                    errMessage = "処理が込み合っているためタイムアウトしました。\n再試行するか、しばらく待ってから再度処理を行ってください。";
                    status = false;
                    return status;
                }
                // ADD 2009/07/06 ---<<<
                string baseCodeTemp = this.BCondition_Grid.Rows[rowConut].Cells[this._receiveConditionDataTable.BaseCodeColumn.ColumnName].Value.ToString();

                foreach (APMSTSecMngSetWork work in _secMngSetArrList)
                {
                    if (baseCodeTemp.Equals(work.SectionCode))
                    {
                        if (work.SyncExecDate.Year == begDateTime.Year && work.SyncExecDate.Month == begDateTime.Month && work.SyncExecDate.Day == begDateTime.Day
                             && work.SyncExecDate.Hour == begDateTime.Hour && work.SyncExecDate.Minute == begDateTime.Minute && work.SyncExecDate.Second == begDateTime.Second)
                        {
                            status = true;
                        }
                        else
                        {
                            // シック時間チェック
                            if (begDateTime < work.SyncExecDate)
                            {
                                if (begDateTime.Year != endDateTime.Year || begDateTime.Month != endDateTime.Month)
                                {
                                    errMessage = string.Format("開始日付{0}", ct_BeginTimeError);
                                    this.BCondition_Grid.ActiveCell = this.BCondition_Grid.Rows[0].Cells[this._receiveConditionDataTable.BeginningDateColumn.ColumnName];
                                    status = false;
                                    return status;
                                }
                            }
                        }
                    }
                }


                rowConut++;
            }

            return status;
        }

        /// <summary>
        /// 受信情報グリッド設定処理
        /// </summary>
        /// <remarks>		
        /// <br>Note		: 受信情報グリッド設定処理を行う。</br>
        /// <br>Programmer	: 譚洪</br>	
        /// <br>Date		: 2009.04.02</br>
        /// </remarks>
        private void InitialBccSettingGridCol()
        {
            this.Bcc_Grid.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;

            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.Bcc_Grid.DisplayLayout.Bands[0];
            if (editBand == null) return;

            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in editBand.Columns)
            {
                //「No列」以外の全てのセルのDiabledColorを設定する。
                if (col.Key != this._receiveInfoDataTable.RowNoColumn.ColumnName)
                {
                    col.CellAppearance.BackColorDisabled = DISABLE_COLOR;
                    col.CellAppearance.ForeColorDisabled = DISABLE_FONT_COLOR;
                }
            }
            this.Bcc_Grid.DisplayLayout.Override.HeaderAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.Bcc_Grid.DisplayLayout.Appearance.FontData.SizeInPoints = 11F;

            // Filter設定
            this.Bcc_Grid.DisplayLayout.Bands[0].Columns[this._receiveInfoDataTable.RowNoColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            this.Bcc_Grid.DisplayLayout.Bands[0].Columns[this._receiveInfoDataTable.MasterNameColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

            // 表示幅設定
            this.Bcc_Grid.DisplayLayout.AutoFitStyle = AutoFitStyle.None;
            this.Bcc_Grid.DisplayLayout.Bands[0].Columns[this._receiveInfoDataTable.RowNoColumn.ColumnName].Width = 30;
            //this.Bcc_Grid.DisplayLayout.Bands[0].Columns[this._receiveInfoDataTable.MasterNameColumn.ColumnName].Width = 600;//DEL 2011/07/25
            this.Bcc_Grid.DisplayLayout.Bands[0].Columns[this._receiveInfoDataTable.MasterNameColumn.ColumnName].Width = 350;//ADD 2011/07/25

            this.Bcc_Grid.DisplayLayout.Bands[0].Columns[this._receiveInfoDataTable.DisplayOrderColumn.ColumnName].Hidden = true; //ADD 2011/07/25
            // 固定列設定
            this.Bcc_Grid.DisplayLayout.Bands[0].Columns[this._receiveInfoDataTable.RowNoColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            this.Bcc_Grid.DisplayLayout.Bands[0].Columns[this._receiveInfoDataTable.MasterNameColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;

            this.Bcc_Grid.DisplayLayout.Bands[0].Columns[this._receiveInfoDataTable.RowNoColumn.ColumnName].Header.Fixed = false;
            this.Bcc_Grid.DisplayLayout.Bands[0].Columns[this._receiveInfoDataTable.MasterNameColumn.ColumnName].Header.Fixed = false;

            // CellAppearance設定
            this.Bcc_Grid.DisplayLayout.Bands[0].Columns[this._receiveInfoDataTable.RowNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.Bcc_Grid.DisplayLayout.Bands[0].Columns[this._receiveInfoDataTable.MasterNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;

            // 入力許可設定
            this.Bcc_Grid.DisplayLayout.Bands[0].Columns[this._receiveInfoDataTable.RowNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            this.Bcc_Grid.DisplayLayout.Bands[0].Columns[this._receiveInfoDataTable.MasterNameColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            // Style設定
            this.Bcc_Grid.DisplayLayout.Bands[0].Columns[this._receiveInfoDataTable.RowNoColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            this.Bcc_Grid.DisplayLayout.Bands[0].Columns[this._receiveInfoDataTable.MasterNameColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;

            //-----DEL 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
            //foreach (BaseCodeNameWork baseCodeNameWork in baseCodeNameList)
            //{
            //    // Filter設定
            //    editBand.Columns[baseCodeNameWork.SectionCode].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            //    // 表示幅設定
            //    editBand.Columns[baseCodeNameWork.SectionCode].Width = 100;
            //    // 固定列設定
            //    editBand.Columns[baseCodeNameWork.SectionCode].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            //    editBand.Columns[baseCodeNameWork.SectionCode].Header.Fixed = false;
            //    // CellAppearance設定
            //    editBand.Columns[baseCodeNameWork.SectionCode].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //    // 入力許可設定
            //    editBand.Columns[baseCodeNameWork.SectionCode].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            //    // Style設定
            //    editBand.Columns[baseCodeNameWork.SectionCode].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;

            //}
            //-----DEL 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
            //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
            foreach (SndRcvHisWork sndRcvHisWork in _sndRcvHisList)
            {
                string key = sndRcvHisWork.EnterpriseCode + sndRcvHisWork.SectionCode.Trim() + sndRcvHisWork.SndRcvHisConsNo.ToString();
                // Filter設定
                editBand.Columns[key].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                // 表示幅設定
                editBand.Columns[key].Width = 100;
                // 固定列設定
                editBand.Columns[key].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                editBand.Columns[key].Header.Fixed = false;
                // CellAppearance設定
                editBand.Columns[key].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                // 入力許可設定
                editBand.Columns[key].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                // Style設定
                editBand.Columns[key].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            }
            //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
        }

        /// <summary>
        /// 受信条件グリッド設定処理
        /// </summary>
        /// <remarks>		
        /// <br>Note		: 受信条件グリッド設定処理を行う。</br>
        /// <br>Programmer	: 譚洪</br>	
        /// <br>Date		: 2009.04.02</br>
        /// </remarks>
        private void InitialBConSettingGridCol()
        {

            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.BCondition_Grid.DisplayLayout.Bands[0];
            if (editBand == null) return;

            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in editBand.Columns)
            {
                //「No列」以外の全てのセルのDiabledColorを設定する。
                if (col.Key != this._receiveConditionDataTable.BaseCodeColumn.ColumnName)
                {
                    col.CellAppearance.BackColorDisabled = DISABLE_COLOR;
                    col.CellAppearance.ForeColorDisabled = DISABLE_FONT_COLOR;
                }
            }

            // Filter設定
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.BaseCodeColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.BaseNameColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.ExtraCondDivColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.ExtraCondDivNmColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.SndRcvHisConsNoColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.BeginningDateColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.BeginningTimeColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.EndDateColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.EndTimeColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

            // 表示幅設定
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.BaseCodeColumn.ColumnName].Width = 50;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.BaseNameColumn.ColumnName].Width = 130;
            //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
            //this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.BeginningDateColumn.ColumnName].Width = 60;
            //this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.BeginningTimeColumn.ColumnName].Width = 50;
            //this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.EndDateColumn.ColumnName].Width = 60;
            //this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.EndTimeColumn.ColumnName].Width = 50;
            //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
            //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.BeginningDateColumn.ColumnName].Width = 120;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.BeginningTimeColumn.ColumnName].Width = 100;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.EndDateColumn.ColumnName].Width = 120;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.EndTimeColumn.ColumnName].Width = 100;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.ExtraCondDivColumn.ColumnName].Width = 10;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.ExtraCondDivNmColumn.ColumnName].Width = 100;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.SndRcvHisConsNoColumn.ColumnName].Width = 100;
            //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<

            // 固定列設定
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.BaseCodeColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.BaseNameColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.ExtraCondDivColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.ExtraCondDivNmColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.SndRcvHisConsNoColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.BeginningDateColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.BeginningTimeColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.EndDateColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.EndTimeColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;

            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.BaseCodeColumn.ColumnName].Header.Fixed = false;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.BaseNameColumn.ColumnName].Header.Fixed = false;
            //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.ExtraCondDivColumn.ColumnName].Header.Fixed = false;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.ExtraCondDivNmColumn.ColumnName].Header.Fixed = false;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.SndRcvHisConsNoColumn.ColumnName].Header.Fixed = false;
            //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.BeginningDateColumn.ColumnName].Header.Fixed = false;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.BeginningTimeColumn.ColumnName].Header.Fixed = false;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.EndDateColumn.ColumnName].Header.Fixed = false;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.EndTimeColumn.ColumnName].Header.Fixed = false;

            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.BeginningDateColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.BeginningTimeColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.EndDateColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.EndTimeColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
			//-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
			this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.BaseCodeColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
			this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.BaseNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
			this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.ExtraCondDivNmColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
			//-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
            // CellAppearance設定
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.BaseCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.BaseNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.ExtraCondDivColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.ExtraCondDivNmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.SndRcvHisConsNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.BeginningDateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.BeginningTimeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.EndDateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.EndTimeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;

            // 入力許可設定
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.BaseCodeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.BaseNameColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.ExtraCondDivColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.ExtraCondDivNmColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.SndRcvHisConsNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.BeginningDateColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.BeginningTimeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.EndDateColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.EndTimeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
            //-----DEL 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
            //this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.BeginningDateColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            //this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.BeginningTimeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            //this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.EndDateColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            //this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.EndTimeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            //-----DEL 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<

            // Style設定
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.BaseCodeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.BaseNameColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.ExtraCondDivColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.ExtraCondDivNmColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.SndRcvHisConsNoColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.BeginningDateColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Date;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.BeginningTimeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.EndDateColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Date;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.EndTimeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;

            //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
            // Hidden列設定
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.EnterpriseCodeColumn.ColumnName].Hidden = true;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.BaseCodeColumn.ColumnName].Hidden = true;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.ExtraCondDivColumn.ColumnName].Hidden = true;
            this.BCondition_Grid.DisplayLayout.Bands[0].Columns[this._receiveConditionDataTable.SndRcvHisConsNoColumn.ColumnName].Hidden = true;
            //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
        }

        /// <summary>
        /// 受信拠点設定処理
        /// </summary>
        /// <remarks>		
        /// <br>Note		: 受信拠点設定処理を行う。</br>
        /// <br>Programmer	: 譚洪</br>	
        /// <br>Date		: 2009.04.02</br>
        /// </remarks>
        private void InitReceInfoSet()
        {
            this._receiveInfoDataTable.BeginLoadData();
            try
            {
                Int32 columnsLen = _receiveInfoTable.Columns.Count;

                for (int i = 0; i < columnsLen; i++)
                {
                    this._receiveInfoTable.Columns.Remove(this._receiveInfoTable.Columns[i].ColumnName);
                    i--;
                    columnsLen--;
                }
                // 更新グリッドを設定する
                // 番号
                this._receiveInfoTable.Columns.Add(_receiveInfoDataTable.RowNoColumn.ColumnName, typeof(int));
                this._receiveInfoTable.Columns[_receiveInfoDataTable.RowNoColumn.ColumnName].DefaultValue = 0;
                this._receiveInfoTable.Columns[_receiveInfoDataTable.RowNoColumn.ColumnName].Caption = "No.";
                // 更新データ
                this._receiveInfoTable.Columns.Add(_receiveInfoDataTable.MasterNameColumn.ColumnName, typeof(string));
                this._receiveInfoTable.Columns[_receiveInfoDataTable.MasterNameColumn.ColumnName].DefaultValue = string.Empty;
                this._receiveInfoTable.Columns[_receiveInfoDataTable.MasterNameColumn.ColumnName].Caption = "マスタ名称";
                //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
                this._receiveInfoTable.Columns.Add(_receiveInfoDataTable.DisplayOrderColumn.ColumnName, typeof(int));
                this._receiveInfoTable.Columns[_receiveInfoDataTable.DisplayOrderColumn.ColumnName].DefaultValue = 0;
                this._receiveInfoTable.Columns[_receiveInfoDataTable.DisplayOrderColumn.ColumnName].Caption = "DisplayOrder";
                //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
                // 更新結果
                //-----DEL 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
                //for ( int j = 0; j < baseCodeNameList.Count; j++ )
                //{
                //    BaseCodeNameWork baseCodeNameWork = (BaseCodeNameWork)this.baseCodeNameList[j];
                //    this._receiveInfoTable.Columns.Add(baseCodeNameWork.SectionCode, typeof(string));
                //    this._receiveInfoTable.Columns[baseCodeNameWork.SectionCode].DefaultValue = string.Empty;
                //    this._receiveInfoTable.Columns[baseCodeNameWork.SectionCode].Caption = baseCodeNameWork.SectionGuideNm;
                //}
                //-----DEL 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
                //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
                for (int j = 0; j < _sndRcvHisList.Count; j++)
                {
                    SndRcvHisWork sndRcvHisWork = (SndRcvHisWork)this._sndRcvHisList[j];
                    string key = sndRcvHisWork.EnterpriseCode + sndRcvHisWork.SectionCode.Trim() + sndRcvHisWork.SndRcvHisConsNo.ToString();
                    this._receiveInfoTable.Columns.Add(key, typeof(string));
                    this._receiveInfoTable.Columns[key].DefaultValue = string.Empty;
                    SecInfoAcs secInfoAcs = new SecInfoAcs();
                    try
                    {
                        this._receiveInfoTable.Columns[key].Caption = string.Empty;
                        foreach (SecInfoSet secInfoSet in secInfoAcs.SecInfoSetList)
                        {
                            if (secInfoSet.SectionCode.Trim() == sndRcvHisWork.SectionCode.Trim().PadLeft(2, '0'))
                            {
                                this._receiveInfoTable.Columns[key].Caption = secInfoSet.SectionGuideNm.Trim();
                                break;
                            }
                        }
                    }
                    catch
                    {
                        this._receiveInfoTable.Columns[key].Caption = string.Empty;
                    }
                }
                //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
            }
            finally
            {
                this._receiveInfoTable.EndLoadData();
            }
        }

        /// <summary>
        /// 受信マスタ名称設定設定
        /// </summary>
        /// <remarks>		
        /// <br>Note		: 受信マスタ名称設定処理を行う。</br>
        /// <br>Programmer	: 譚洪</br>	
        /// <br>Date		: 2009.04.02</br>
        /// </remarks>
        private void SearchReceMasterName()
        {
            if (!_mstUpdCountAcs.CheckOnline())
            {
                TMsgDisp.Show(
                emErrorLevel.ERR_LEVEL_STOP,
                this.Text,
                this.Text + "画面初期化処理に失敗しました。",
                (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                return;
            }

            int status = _mstUpdCountAcs.LoadReceMstName(_enterpriseCode, out masterNameList);
        }

        /// <summary>
        /// 受信シンク実行日付設定処理
        /// </summary>
        /// <remarks>		
        /// <br>Note		: 受信シンク実行日付設定処理設定処理を行う。</br>
        /// <br>Programmer	: 譚洪</br>	
        /// <br>Date		: 2009.04.02</br>
        /// </remarks>
        private void SearchReceSyncExecDate()
        {
            if (!_mstUpdCountAcs.CheckOnline())
            {
                TMsgDisp.Show(
                emErrorLevel.ERR_LEVEL_STOP,
                this.Text,
                this.Text + "画面初期化処理に失敗しました。",
                (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                return;
            }

            //int status = _mstUpdCountAcs.LoadReceSyncExecDate(_enterpriseCode, out _secMngSetArrList, out baseCodeNameList);//DEL 2011/07/25
            //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
            int status = _mstUpdCountAcs.LoadReceSyncExecDate(_enterpriseCode, out _secMngSetArrList, out baseCodeNameList, out _sndRcvHisList, out _sndRcvEtrList);
            //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<

            if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
            {
                TMsgDisp.Show(
                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                PROGRAM_ID,
                "",
                "",
                "",
                "処理が込み合っているためタイムアウトしました。\n再試行するか、しばらく待ってから再度処理を行ってください。",
                0,
                null,
                MessageBoxButtons.OK,
                MessageBoxDefaultButton.Button1);
            }
        }

        /// <summary>
        /// 受信更新時間の設定
        /// </summary>
        /// <remarks>		
        /// <br>Note		: 受信更新時間処理を行う。</br>
        /// <br>Programmer	: 譚洪</br>	
        /// <br>Date		: 2009.04.02</br>
        /// </remarks>
        private bool ReceUpdateOverData(out bool isTimeOut)
        {
            bool isUpdate = true;
            ArrayList secMngSetArrList = new ArrayList();
            isUpdate = _mstUpdCountAcs.ReceUpdateProc(_enterpriseCode, baseCodeNameList, out secMngSetArrList, out isTimeOut);
            if (isUpdate)
            {
                _secMngSetArrList = secMngSetArrList;
            }
            else
            {
                isUpdate = false;
            }
            return isUpdate;
        }


        /// <summary>
        /// 受信マスタ区分設定設定
        /// </summary>
        /// <remarks>		
        /// <br>Note		: 送信マスタ区分設定処理を行う。</br>
        /// <br>Programmer	: 譚洪</br>	
        /// <br>Date		: 2009.04.02</br>
        /// </remarks>
        private void SearchReceMasterDoDiv()
        {
            int status = _mstUpdCountAcs.LoadReceMstDoDiv(_enterpriseCode, out masterDivList);
        }

        /// <summary>
        /// 受信マスタ明細区分設定処理
        /// </summary>
        /// <remarks>		
        /// <br>Note		: 送信マスタ明細区分設定処理を行う。</br>
        /// <br>Programmer	: 譚洪</br>	
        /// <br>Date		: 2009.04.02</br>
        /// </remarks>
        private void SearchReceMasterDtlDoDiv()
        {
            int status = _mstUpdCountAcs.LoadReceMstDtlDoDiv(_enterpriseCode, out masterDtlDivList);
        }

        /// <summary>
        /// マスタ受信処理
        /// </summary>
        /// <remarks>		
        /// <br>Note		: マスタ送信処理を行う。</br>
        /// <br>Programmer	: 譚洪</br>	
        /// <br>Date		: 2009.04.02</br>
        /// </remarks>
        private void ReceUpdateProcess()
        {
            Int32 rowCount = 0;
            string pmCode = string.Empty;
            bool isEmpty = false;
            bool isTotalEmpty = true;
            MstSearchCountWorkWork searchCountWork = null;
            Hashtable countTable = new Hashtable();

            Broadleaf.Windows.Forms.SFCMN00299CA form = new Broadleaf.Windows.Forms.SFCMN00299CA();
            // 表示文字を設定
            form.Title = "受信処理中";
            form.Message = "受信処理中です";


            this.Cursor = Cursors.WaitCursor;
            //-----DEL 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
            // ダイアログ表示
            form.Show();
            //-----DEL 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
            foreach (ReceiveConditionDataSet.ReceiveConditionRow row in this._mstUpdCountAcs.ReceiveConditionDataTable)
            {
                //-----DEL 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
                //string beginningDate = this.BCondition_Grid.Rows[rowCount].Cells[this._receiveConditionDataTable.BeginningDateColumn.ColumnName].Value.ToString();
                //string beginningTime = this.BCondition_Grid.Rows[rowCount].Cells[this._receiveConditionDataTable.BeginningTimeColumn.ColumnName].Value.ToString();

                //string endingDate = this.BCondition_Grid.Rows[rowCount].Cells[this._receiveConditionDataTable.EndDateColumn.ColumnName].Value.ToString();
                //string endingTime = this.BCondition_Grid.Rows[rowCount].Cells[this._receiveConditionDataTable.EndTimeColumn.ColumnName].Value.ToString();

                //string baseCode = this.BCondition_Grid.Rows[rowCount].Cells[this._receiveConditionDataTable.BaseNameColumn.ColumnName].Value.ToString();
                //// 開始日付
                //DateTime beginDateTime = new DateTime(int.Parse(beginningDate.Substring(0, 4)), int.Parse(beginningDate.Substring(5, 2)),
                //    int.Parse(beginningDate.Substring(8, 2)), int.Parse(beginningTime.Substring(0, 2)), int.Parse(beginningTime.Substring(3, 2)),
                //    int.Parse(beginningTime.Substring(6, 2)));
                //// 終了日付
                //DateTime endDateTime = new DateTime(int.Parse(endingDate.Substring(0, 4)), int.Parse(endingDate.Substring(5, 2)),
                //    int.Parse(endingDate.Substring(8, 2)), int.Parse(endingTime.Substring(0, 2)), int.Parse(endingTime.Substring(3, 2)),
                //    int.Parse(endingTime.Substring(6, 2)));
                //-----DEL 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
                string baseCodeTemp = this.BCondition_Grid.Rows[rowCount].Cells[this._receiveConditionDataTable.BaseCodeColumn.ColumnName].Value.ToString();

                //-----DEL 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
                //foreach (APMSTSecMngSetWork work in _secMngSetArrList)
                //{
                //    if (baseCodeTemp.Equals(work.SectionCode))
                //    {
                //        if (beginDateTime.Year == work.SyncExecDate.Year && beginDateTime.Month == work.SyncExecDate.Month && beginDateTime.Day == work.SyncExecDate.Day
                //            && beginDateTime.Hour == work.SyncExecDate.Hour && beginDateTime.Minute == work.SyncExecDate.Minute && beginDateTime.Second == work.SyncExecDate.Second)
                //        {
                //            beginDateTime = work.SyncExecDate;
                //        }
                //        break;
                //    }
                //}
                //-----DEL 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
                //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
                ArrayList paramList = new ArrayList();
                //送信元企業コード
                string sendDestEnterpriseCode = this.BCondition_Grid.Rows[rowCount].Cells[this._receiveConditionDataTable.EnterpriseCodeColumn.ColumnName].Value.ToString();
                //送信元拠点コード
                string sendDestSecCode = baseCodeTemp;
                //送受信履歴ログ送信番号
                int sndRcvHisConsNo = (int)this.BCondition_Grid.Rows[rowCount].Cells[this._receiveConditionDataTable.SndRcvHisConsNoColumn.ColumnName].Value;
                GetSelectSndRcvEtr(sendDestEnterpriseCode, sendDestSecCode, sndRcvHisConsNo);
                if (sndRcvEtrDic.ContainsKey(FILEID_CUSTOMER))
                {
                    paramList.Add(sndRcvEtrDic[FILEID_CUSTOMER]);
                }
                if (sndRcvEtrDic.ContainsKey(FILEID_GOODS))
                {
                    paramList.Add(sndRcvEtrDic[FILEID_GOODS]);
                }
                if (sndRcvEtrDic.ContainsKey(FILEID_STOCK))
                {
                    paramList.Add(sndRcvEtrDic[FILEID_STOCK]);
                }
                if (sndRcvEtrDic.ContainsKey(FILEID_SUPPLIER))
                {
                    paramList.Add(sndRcvEtrDic[FILEID_SUPPLIER]);
                }
                if (sndRcvEtrDic.ContainsKey(FILEID_RATE))
                {
                    paramList.Add(sndRcvEtrDic[FILEID_RATE]);
                }
                // --- ADD 2012/07/26 ---------------------------->>>>>
                if (sndRcvEtrDic.ContainsKey(FILEID_EMPLOYEE))
                {
                    paramList.Add(sndRcvEtrDic[FILEID_EMPLOYEE]);
                }
                if (sndRcvEtrDic.ContainsKey(FILEID_JOINPARTSU))
                {
                    paramList.Add(sndRcvEtrDic[FILEID_JOINPARTSU]);
                }
                if (sndRcvEtrDic.ContainsKey(FILEID_USERGDU))
                {
                    paramList.Add(sndRcvEtrDic[FILEID_USERGDU]);
                }
                // --- ADD 2012/07/26 ----------------------------<<<<<
                // 開始日付
                DateTime beginDateTime = DateTime.MinValue;
                // 終了日付
                DateTime endDateTime = DateTime.MinValue;
                SndRcvHisWork sndRcvHisWork = new SndRcvHisWork();
                foreach (SndRcvHisWork work in _sndRcvHisList)
                {
                    if (sendDestSecCode.Equals(work.SectionCode) && sendDestEnterpriseCode.Equals(work.EnterpriseCode)
                        && sndRcvHisConsNo == work.SndRcvHisConsNo)
                    {
                        beginDateTime = work.SndObjStartDate;
                        endDateTime = work.SndObjEndDate;
                        sndRcvHisWork = work;
                        break;
                    }
                }
                //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<


                //int status = _mstUpdCountAcs.SeachPmCode(_enterpriseCode, baseCodeTemp, out pmCode);//DEL 2011/07/25
                long beginDtLong = beginDateTime.Ticks;
                long endDtLong = endDateTime.Ticks;
                searchCountWork = new MstSearchCountWorkWork();
                //-----DEL 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
                //// ダイアログ表示
                //form.Show();
                //-----DEL 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
                //status = _mstUpdCountAcs.ReceProc(_enterpriseCode, _connectPointDiv, masterDivList, masterDtlDivList, masterNameList, beginDtLong, endDtLong, _secMngSetArrList, pmCode, _loginEmplooyCode, baseCodeTemp, out searchCountWork, out isEmpty);//DEL 2011/07/25
                //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
                int status = _mstUpdCountAcs.ReceProc(_enterpriseCode, _connectPointDiv, masterDivList, masterDtlDivList, masterNameList, beginDtLong, endDtLong, _secMngSetArrList, paramList, sndRcvHisWork, sendDestEnterpriseCode, _loginEmplooyCode, baseCodeTemp, out searchCountWork, out isEmpty);//ADD 2011/07/25
                //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
                //-----DEL 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
                //// ダイアログを閉じる
                //form.Close();
                //-----DEL 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
                if (!isEmpty)
                {
                    isTotalEmpty = false;
                }
                //countTable.Add(baseCodeTemp, searchCountWork);//DEL 2011/07/25
                countTable.Add(sendDestEnterpriseCode + sendDestSecCode.Trim() + sndRcvHisConsNo.ToString(), searchCountWork);//ADD 2011/07/25
                rowCount++;
            }
            //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
            // ダイアログを閉じる
            form.Close();
            //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
            this.Cursor = Cursors.Default;

            // 検索0件の場合、
            if (isTotalEmpty)
            {
                OperationHistoryLog operationHistoryLog = new OperationHistoryLog();
                // MOD 2009/06/17 --->>>
                //operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, string.Empty, "抽出対象のデータが存在しません。");
                operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, "抽出対象のデータが存在しません。", string.Empty);
                // MOD 2009/06/17 ---<<<
                // 送信情報テーブルクリア処理
                this._receiveInfoTable.Clear();

                this.ReceSearchResultDataGridCol(countTable);

                this.ultraTabControl2.SelectedTab = this.ultraTabControl2.Tabs["updateTab"];

                // メッセージを表示
                //this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "抽出対象のデータが存在しません。", 0);//DEL 2011/08/23 #23890 受信データがない場合について

            }
            else
            {
                // 送信情報テーブルクリア処理
                this._receiveInfoTable.Clear();

                this.ReceSearchResultDataGridCol(countTable);

                this.ultraTabControl2.SelectedTab = this.ultraTabControl2.Tabs["updateTab"];
            }
        }

        #endregion ■ マスタ受信メッソド関連 ■

        #region ■ 送受信共通処理 ■
        /// <summary>
        /// ツールバーボタンクリックイベント処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>		
        /// <br>Note		: なし。</br>
        /// <br>Programmer	: 譚洪</br>	
        /// <br>Date		: 2009.04.02</br>
        /// </remarks>
        private void tToolsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "ButtonTool_Close":
                    {
                        // 終了処理
                        this.Close();
                        break;
                    }
                case "ButtonTool_Update":
                    {
                        // 更新処理
                        bool inputCheck = false;
                        if (tce_SendAndReceKubun.SelectedIndex == 0)
                        {
                            if (0 == this.Condition_Grid.Rows.Count)
                            {
                                // メッセージを表示
                                this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "送信対象拠点が設定されていません。", 0);
                                return;
                            }

                            // セル編集後に直接ボタンクリックを行なうとセルの編集が発生しないため
                            if (this.Condition_Grid.ActiveCell != null)
                            {
                                this.Condition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                            }

                            inputCheck = this.UpdateBeforeCheck();

                            if (inputCheck)
                            {
                                this.DataGetAgain();
                                this.UpdateProcess();
                            }
                        }
                        else
                        {
                            if (0 == this.BCondition_Grid.Rows.Count)
                            {
                                // メッセージを表示
                                //this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "受信対象拠点が設定されていません。", 0);//DEL 2011/08/23 #23890 受信データがない場合について
                                //this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "抽出対象のデータが存在しません。", 0);//ADD 2011/08/23 #23890 受信データがない場合について
                                this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "受信対象のデータが存在しません。", 0);//ADD 2011/08/23 #23890 受信データがない場合について
                                return;
                            }

                            // セル編集後に直接ボタンクリックを行なうとセルの編集が発生しないため
                            if (this.BCondition_Grid.ActiveCell != null)
                            {
                                this.BCondition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                            }

                            inputCheck = this.ReceUpdateBeforeCheck();

                            if (inputCheck)
                            {
                                this.DataGetAgain();
                                this.ReceUpdateProcess();
                            }
                        }
                        break;
                    }
                case "ButtonTool_Clear":
                    {
                        // 元に戻す処理
                        this.Retry();

                        break;
                    }
                //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
                case "ButtonTool_ExtractDetail":
                    {
                        //送信抽出条件詳細処理
                        ExtractDetailShow();
                        break;
                    }
                case "ButtonTool_Setting":
                    {
                        //設定ボタン処理
                        SendDestSet();
                        break;
                    }
                case "ButtonTool_Customer":
                    {
                        //得意先マスタ抽出条件
                        PMKYO01301UA _PMKYO01301UA = new PMKYO01301UA();
                        _PMKYO01301UA.Mode = 2; //2:参照モード
                        if (sndRcvEtrDic.ContainsKey(FILEID_CUSTOMER))
                        {
                            SndRcvEtrWork sndRcvEtrWork = (SndRcvEtrWork)this.sndRcvEtrDic[FILEID_CUSTOMER];
                            this._customerProcParam.CustomerCodeBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond1);
                            this._customerProcParam.CustomerCodeEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond1);
                            this._customerProcParam.KanaBeginRF = sndRcvEtrWork.StartCond2;
                            this._customerProcParam.KanaEndRF = sndRcvEtrWork.EndCond2;
                            this._customerProcParam.MngSectionCodeBeginRF = sndRcvEtrWork.StartCond3;
                            this._customerProcParam.MngSectionCodeEndRF = sndRcvEtrWork.EndCond3;
                            this._customerProcParam.CustomerAgentCdBeginRF = sndRcvEtrWork.StartCond4;
                            this._customerProcParam.CustomerAgentCdEndRF = sndRcvEtrWork.EndCond4;
                            this._customerProcParam.SalesAreaCodeBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond5);
                            this._customerProcParam.SalesAreaCodeEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond5);
                            this._customerProcParam.BusinessTypeCodeBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond6);
                            this._customerProcParam.BusinessTypeCodeEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond6);
                        }
                        _PMKYO01301UA._customerProcParam = this._customerProcParam;
                        _PMKYO01301UA.ShowDialog();
                        break;
                    }
                case "ButtonTool_Supplier":
                    {
                        //仕入先マスタ抽出条件
                        PMKYO01501UA _PMKYO01501UA = new PMKYO01501UA();
                        _PMKYO01501UA.Mode = 2; //2:参照モード
                        if (sndRcvEtrDic.ContainsKey(FILEID_SUPPLIER))
                        {
                            SndRcvEtrWork sndRcvEtrWork = (SndRcvEtrWork)this.sndRcvEtrDic[FILEID_SUPPLIER];
                            this._supplierProcParam.SupplierCdBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond1);
                            this._supplierProcParam.SupplierCdEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond1);
                        }
                        _PMKYO01501UA._supplierProcParam = this._supplierProcParam;
                        _PMKYO01501UA.ShowDialog();
                        break;
                    }
                case "ButtonTool_Goods":
                    {
                        //商品マスタ抽出条件
                        PMKYO01401UA _PMKYO01401UA = new PMKYO01401UA();
                        _PMKYO01401UA.Mode = 2; //2:参照モード
                        if (sndRcvEtrDic.ContainsKey(FILEID_GOODS))
                        {
                            SndRcvEtrWork sndRcvEtrWork = (SndRcvEtrWork)this.sndRcvEtrDic[FILEID_GOODS];
                            this._goodsProcParam.SupplierCdBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond1);
                            this._goodsProcParam.SupplierCdEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond1);
                            this._goodsProcParam.GoodsMakerCdBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond2);
                            this._goodsProcParam.GoodsMakerCdEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond2);
                            this._goodsProcParam.BLGoodsCodeBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond3);
                            this._goodsProcParam.BLGoodsCodeEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond3);
                            this._goodsProcParam.GoodsNoBeginRF = sndRcvEtrWork.StartCond4;
                            this._goodsProcParam.GoodsNoEndRF = sndRcvEtrWork.EndCond4;
                        }
                        _PMKYO01401UA._goodsProcParam = this._goodsProcParam;
                        _PMKYO01401UA.ShowDialog();
                        break;
                    }
                case "ButtonTool_Stock":
                    {
                        //在庫マスタ抽出条件
                        PMKYO01701UA _PMKYO01701UA = new PMKYO01701UA();
                        _PMKYO01701UA.Mode = 2; //2:参照モード
                        if (sndRcvEtrDic.ContainsKey(FILEID_STOCK))
                        {
                            SndRcvEtrWork sndRcvEtrWork = (SndRcvEtrWork)this.sndRcvEtrDic[FILEID_STOCK];
                            this._stockProcParam.WarehouseCodeBeginRF = sndRcvEtrWork.StartCond1;
                            this._stockProcParam.WarehouseCodeEndRF = sndRcvEtrWork.EndCond1;
                            this._stockProcParam.WarehouseShelfNoBeginRF = sndRcvEtrWork.StartCond2;
                            this._stockProcParam.WarehouseShelfNoEndRF = sndRcvEtrWork.EndCond2;
                            this._stockProcParam.SupplierCdBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond3);
                            this._stockProcParam.SupplierCdEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond3);
                            this._stockProcParam.GoodsMakerCdBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond4);
                            this._stockProcParam.GoodsMakerCdEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond4);
                            this._stockProcParam.BLGloupCodeBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond5);
                            this._stockProcParam.BLGloupCodeEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond5);
                            this._stockProcParam.GoodsNoBeginRF = sndRcvEtrWork.StartCond6;
                            this._stockProcParam.GoodsNoEndRF = sndRcvEtrWork.EndCond6;
                        }
                        _PMKYO01701UA._stockProcParam = this._stockProcParam;
                        _PMKYO01701UA.ShowDialog();
                        break;
                    }
                case "ButtonTool_Rate":
                    {
                        //掛率マスタ抽出条件
                        PMKYO01601UA _PMKYO01601UA = new PMKYO01601UA();
                        _PMKYO01601UA.Mode = 2; //2:参照モード
                        if (sndRcvEtrDic.ContainsKey(FILEID_RATE))
                        {
                            SndRcvEtrWork sndRcvEtrWork = (SndRcvEtrWork)this.sndRcvEtrDic[FILEID_RATE];
                            this._rateProcParam.UnitPriceKindRF = sndRcvEtrWork.StartCond1;
                            this._rateProcParam.SetFunRF = sndRcvEtrWork.EndCond1;
                            // --- DEL 2012/07/26 ------------------------->>>>>
                            //this._rateProcParam.RateSettingDivideRF = sndRcvEtrWork.StartCond2;
                            // --- DEL 2012/07/26 -------------------------<<<<<
                            // --- ADD 2012/07/26 ------------------------->>>>>
                            this._rateProcParam.SectionCodeBeginRF = sndRcvEtrWork.StartCond2;
                            this._rateProcParam.SectionCodeEndRF = sndRcvEtrWork.EndCond2;
                            // --- ADD 2012/07/26 -------------------------<<<<<
                            this._rateProcParam.CustRateGrpCodeBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond3);
                            this._rateProcParam.CustRateGrpCodeEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond3);
                            this._rateProcParam.CustomerCodeBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond4);
                            this._rateProcParam.CustomerCodeEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond4);
                            this._rateProcParam.SupplierCdBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond5);
                            this._rateProcParam.SupplierCdEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond5);
                            this._rateProcParam.GoodsMakerCdBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond6);
                            this._rateProcParam.GoodsMakerCdEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond6);
                            this._rateProcParam.GoodsRateRankBeginRF = sndRcvEtrWork.StartCond7;
                            this._rateProcParam.GoodsRateRankEndRF = sndRcvEtrWork.EndCond7;
                            this._rateProcParam.GoodsRateGrpCodeBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond8);
                            this._rateProcParam.GoodsRateGrpCodeEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond8);
                            this._rateProcParam.BLGoodsCodeBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond9);
                            this._rateProcParam.BLGoodsCodeEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond9);
                            this._rateProcParam.GoodsNoBeginRF = sndRcvEtrWork.StartCond10;
                            this._rateProcParam.GoodsNoEndRF = sndRcvEtrWork.EndCond10;
                        }
                        _PMKYO01601UA._rateProcParam = this._rateProcParam;
                        _PMKYO01601UA.ShowDialog();
                        break;
                    }
                // --- ADD 2012/07/26 ------------------------------------->>>>>
                case "ButtonTool_Employee":
                    {
                        // 従業員設定マスタ抽出条件
                        PMKYO01511UA _PMKYO01511UA = new PMKYO01511UA();
                        _PMKYO01511UA.Mode = 2; //2:参照モード
                        if (sndRcvEtrDic.ContainsKey(FILEID_EMPLOYEE))
                        {
                            SndRcvEtrWork sndRcvEtrWork = (SndRcvEtrWork)this.sndRcvEtrDic[FILEID_EMPLOYEE];
                            this._employeeProcParam.BelongSectionCdBeginRF = sndRcvEtrWork.StartCond1;
                            this._employeeProcParam.BelongSectionCdEndRF = sndRcvEtrWork.EndCond1;
                            this._employeeProcParam.EmployeeCdBeginRF = sndRcvEtrWork.StartCond2;
                            this._employeeProcParam.EmployeeCdEndRF = sndRcvEtrWork.EndCond2;
                        }
                        _PMKYO01511UA._employeeProcParam = this._employeeProcParam;
                        _PMKYO01511UA.ShowDialog();
                        break;
                    }
                case "ButtonTool_JoinPartsU":
                    {
                        // 結合マスタ抽出条件
                        PMKYO01521UA _PMKYO01521UA = new PMKYO01521UA();
                        _PMKYO01521UA.Mode = 2; //2:参照モード
                        if (sndRcvEtrDic.ContainsKey(FILEID_JOINPARTSU))
                        {
                            SndRcvEtrWork sndRcvEtrWork = (SndRcvEtrWork)this.sndRcvEtrDic[FILEID_JOINPARTSU];
                            this._joinPartsUProcParam.JoinSourPartsNoWithHBeginRF = sndRcvEtrWork.StartCond1;
                            this._joinPartsUProcParam.JoinSourPartsNoWithHEndRF = sndRcvEtrWork.EndCond1;
                            this._joinPartsUProcParam.JoinSourceMakerCodeBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond2);
                            this._joinPartsUProcParam.JoinSourceMakerCodeEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond2);
                            this._joinPartsUProcParam.JoinDispOrderBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond3);
                            this._joinPartsUProcParam.JoinDispOrderEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond3);
                            this._joinPartsUProcParam.JoinDestMakerCodeBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond4);
                            this._joinPartsUProcParam.JoinDestMakerCodeEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond4);
                        }
                        _PMKYO01521UA._joinPartsUProcParam = this._joinPartsUProcParam;
                        _PMKYO01521UA.ShowDialog();
                        break;
                    }
                case "ButtonTool_UserGdBuyDivU":
                    {
                        // ユーザーガイドマスタ（販売区分）抽出条件
                        PMKYO01531UA _PMKYO01531UA = new PMKYO01531UA();
                        _PMKYO01531UA.Mode = 2; //2:参照モード
                        if (sndRcvEtrDic.ContainsKey(FILEID_USERGDU))
                        {
                            SndRcvEtrWork sndRcvEtrWork = (SndRcvEtrWork)this.sndRcvEtrDic[FILEID_USERGDU];
                            this._userGdBuyDivUProcParam.GuideCodeBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond1);
                            this._userGdBuyDivUProcParam.GuideCodeEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond1);
                        }
                        _PMKYO01531UA._userGdBuyDivUProcParam = this._userGdBuyDivUProcParam;
                        _PMKYO01531UA.ShowDialog();
                        break;
                    }
                // --- ADD 2012/07/26 -------------------------------------<<<<<
                //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
            }
        }

        /// <summary>
        /// 元に戻す処理
        /// </summary>
        /// <remarks>		
        /// <br>Note		: 元に戻す処理です。</br>
        /// <br>Programmer	: 譚洪</br>	
        /// <br>Date		: 2009.04.02</br>
        /// </remarks>
        private void Retry()
        {
            //this.SendClear(); //DEL 2011/07/25
            //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
            this.SendClear(0);
            this.tce_ExtractCondDiv.SelectedIndex = 0;
            //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
            //ADD 2011/09/14 sundx #24542 拠点選択について----->>>>>
            SetSecCode(_initSecCode);
            InitSecCode();
            //ADD 2011/09/14 sundx #24542 拠点選択について-----<<<<<

        }

        /// <summary>
        /// 更新の場合、送受信画面情報もう一度取得処理
        /// </summary>
        /// <remarks>		
        /// <br>Note		: 更新の場合、送受信画面情報もう一度取得処理です。</br>
        /// <br>Programmer	: 譚洪</br>	
        /// <br>Date		: 2009.04.02</br>
        /// </remarks>
        private void DataGetAgain()
        {
            // 送信の場合、
            if (tce_SendAndReceKubun.SelectedIndex == 0)
            {
                this._updateResultDataTable.Clear();
                // 送信情報データ設定
                this.Acc_Grid.DataSource = this._updateResultDataTable;
                // 送信情報グリッド初期設定
                this.InitialAccSettingGridCol();
                // マスタ名称を取得する。
                this.SearchMasterName();
                // マスタ名称を取得区分。
                this.SearchMasterDoDiv();
                // 送受信対象設定マスタより、マスタ名称初期設定
                this.InitialAccDataGridCol();
            }
            // 受信の場合、
            else
            {
                this._receiveInfoTable.Clear();
                // マスタ名称を取得する。
                this.SearchReceMasterName();
                // マスタ名称を取得区分。
                this.SearchReceMasterDoDiv();
                // データ更新区分を取得する。
                this.SearchReceMasterDtlDoDiv();
                // 拠点設定処理
                this.InitReceInfoSet();
                // 受信情報データ設定
                this.Bcc_Grid.DataSource = this._receiveInfoTable;
                // 受信情報グリッド初期設定
                this.InitialBccSettingGridCol();
            }
        }

        /// <summary>
        /// ドロプダン変更処理
        /// </summary>
        /// <param name="mode">0:初期化 1:送受信区分変更 2:抽出条件区分変更</param>
        /// <remarks>		
        /// <br>Note		: ドロプダン変更処理です。</br>
        /// <br>Programmer	: 譚洪</br>	
        /// <br>Date		: 2009.04.02</br>
        /// </remarks>
        //private void SendClear() //DEL 2011/07/25
        private void SendClear(int mode) //ADD 2011/07/25
        {
            // 送信の場合、
            if (tce_SendAndReceKubun.SelectedIndex == 0)
            {
                this._extractionConditionDataTable.Clear();
                this._updateResultDataTable.Clear();
                this._receiveConditionDataTable.Clear();
                this._receiveInfoTable.Clear();

                //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
                // 送信先設定
                this.SearchSyncExecDate();
                if (mode == 0 || mode == 1)
                {
                    //0:初期化、または1:送受信区分変更の場合、送信先拠点を再設定
                    if (baseCodeNameList.Count == 0)
                    {
                        this.tEdit_SectionCode.DataText = string.Empty;
                        this.tEdit_SectionName.DataText = string.Empty;
                    }
                    else if (baseCodeNameList.Count == 1)
                    {
                        this.tEdit_SectionCode.DataText = ((BaseCodeNameWork)baseCodeNameList[0]).SectionCode.Trim();
                        this.tEdit_SectionName.DataText = ((BaseCodeNameWork)baseCodeNameList[0]).SectionGuideNm;
                    }
                    else
                    {
                        this.tEdit_SectionCode.DataText = ALL_SECTIONCODE;
                        this.tEdit_SectionName.DataText = "全社";
                    }
                    this.sendDestSecList = baseCodeNameList;
                    this._preSectionCode = this.tEdit_SectionCode.DataText;
                }
                //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<

                // 送信情報true
                this.ultraTabControl1.Visible = true;
                // 受信情報false
                this.ultraTabControl2.Visible = false;
                // 送信情報データ設定
                this.Acc_Grid.DataSource = this._updateResultDataTable;
                // 送信条件データ設定
                this.Condition_Grid.DataSource = this._extractionConditionDataTable;
                // 送信情報グリッド初期設定
                this.InitialAccSettingGridCol();
                // マスタ名称を取得する。
                this.SearchMasterName();
                // マスタ名称を取得区分。
                this.SearchMasterDoDiv();
                // シンク実行日付を取得する。
                //this.SearchSyncExecDate();//DEL 2011/07/25
                // 送受信対象設定マスタより、マスタ名称初期設定
                this.InitialAccDataGridCol();
                // 送信条件グリッド初期設定
                this.InitialConSettingGridCol();
                //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
                // 送信条件グリッド再設定
                this.ResetConSettingGridCol();
                //画面コントロール表示制御を設定
                this._extractDetailButton.SharedProps.Visible = true;
                this._settingButton.SharedProps.Visible = false;
                this._detailButton.SharedProps.Visible = false;
                this.uLabel_SectionCode.Visible = true;
                this.tEdit_SectionCode.Visible = true;
                this.tEdit_SectionName.Visible = true;
                this.SectionGuide_Button.Visible = true;
                this.uLabel_ExtractCondDiv.Visible = true;
                this.tce_ExtractCondDiv.Visible = true;
                //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<

                if (this.Condition_Grid.Rows.Count > 0)
                {
					//this.Condition_Grid.ActiveCell = this.Condition_Grid.Rows[0].Cells[this._extractionConditionDataTable.BeginningDateColumn.ColumnName];//DEL 2011/07/25
					this.Condition_Grid.ActiveCell = this.Condition_Grid.Rows[0].Cells[this._extractionConditionDataTable.SendDestCondColumn.ColumnName];//ADD 2011/07/25
                    this.ultraTabControl1.SelectedTab = this.ultraTabControl1.Tabs["updateTab"];
                }
            }
            // 受信の場合、
            else
            {
                this._extractionConditionDataTable.Clear();
                this._updateResultDataTable.Clear();
                this._receiveConditionDataTable.Clear();
                this._receiveInfoTable.Clear();

                // 送信情報false
                this.ultraTabControl1.Visible = false;
                // 受信情報true
                this.ultraTabControl2.Visible = true;
                // マスタ名称を取得する。
                this.SearchReceMasterName();
                // マスタ名称を取得区分。
                this.SearchReceMasterDoDiv();
                // データ更新区分を取得する。
                this.SearchReceMasterDtlDoDiv();
                // シンク実行日付を取得する。
                this.SearchReceSyncExecDate();
                // 拠点設定処理
                this.InitReceInfoSet();
                // 受信情報データ設定
                this.Bcc_Grid.DataSource = this._receiveInfoTable;
                // 受信条件データ設定
                this.BCondition_Grid.DataSource = this._receiveConditionDataTable;
                // 受信情報グリッド初期設定
                this.InitialBccSettingGridCol();
                // 受信条件グリッド初期設定
                this.InitialBConSettingGridCol();
                // 送受信対象設定マスタより、マスタ名称初期設定
                this.UpdateResultBccDataGridCol();
                //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
                //画面コントロール表示制御を設定
                this._extractDetailButton.SharedProps.Visible = false;
                this._settingButton.SharedProps.Visible = true;
                this._detailButton.SharedProps.Visible = true;
                this.uLabel_SectionCode.Visible = false;
                this.tEdit_SectionCode.Visible = false;
                this.tEdit_SectionName.Visible = false;
                this.SectionGuide_Button.Visible = false;
                this.uLabel_ExtractCondDiv.Visible = false;
                this.tce_ExtractCondDiv.Visible = false;
                //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
                //ADD 2011/08/29 #23934 条件送信の開始日付時間・終了日付時間の初期値について--------------------------------------->>>>>
                //開始日付、開始時間、終了日付、終了時間に空白を設定する
                for (int i = 0; i < this._receiveConditionDataTable.Rows.Count; i++)
                {
                    ReceiveConditionDataSet.ReceiveConditionRow row = (ReceiveConditionDataSet.ReceiveConditionRow)_receiveConditionDataTable.Rows[i];
                    if (row.BeginningDate.Equals(DateTime.MinValue))
                    {
                        BCondition_Grid.Rows[i].Cells[this._receiveConditionDataTable.BeginningDateColumn.ColumnName].SetValue(DBNull.Value, true);
                    }
                    if (row.EndDate.Equals(DateTime.MinValue))
                    {
                        BCondition_Grid.Rows[i].Cells[this._receiveConditionDataTable.EndDateColumn.ColumnName].SetValue(DBNull.Value, true);
                    }             
                }
                if (BCondition_Grid.ActiveCell != null)
                {
                    BCondition_Grid.ActiveCell.Selected = false;
                    BCondition_Grid.ActiveCell.Activated = false;
                }
                //ADD 2011/08/29 #23934 条件送信の開始日付時間・終了日付時間の初期値について---------------------------------------<<<<<
                if (this.BCondition_Grid.Rows.Count > 0)
                {
                    //this.BCondition_Grid.ActiveCell = this.BCondition_Grid.Rows[0].Cells[this._receiveConditionDataTable.BeginningDateColumn.ColumnName];//DEL 2011/07/25
                    this.BCondition_Grid.Rows[0].Activate();//ADD 2011/07/25
                    this.ultraTabControl2.SelectedTab = this.ultraTabControl2.Tabs["updateTab"];
                }
            }
            //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
            //入力したマスタ抽出条件もクリア
            this._customerProcParam = new APCustomerProcParamWork();
            this._supplierProcParam = new APSupplierProcParamWork();
            this._stockProcParam = new APStockProcParamWork();
            this._goodsProcParam = new APGoodsProcParamWork();
            this._rateProcParam = new APRateProcParamWork();
            // --- ADD 2012/07/26 ------------------------->>>>>
            this._employeeProcParam = new APEmployeeProcParamWork();
            this._joinPartsUProcParam = new APJoinPartsUProcParamWork();
            this._userGdBuyDivUProcParam = new APUserGdBuyDivUProcParamWork();
            // --- ADD 2012/07/26 -------------------------<<<<<
            this.sndRcvEtrDic.Clear();
            //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
        }

        /// <summary>
        /// 受信情報グリッド設定処理
        /// </summary>
        /// <remarks>		
        /// <br>Note		: 受信情報グリッド設定処理を行う。</br>
        /// <br>Programmer	: 譚洪</br>	
        /// <br>Date		: 2009.04.02</br>
        /// </remarks>
        private void UpdateResultBccDataGridCol()
        {
            DataRow row = null;

            int rowNo = 0;
            foreach (SecMngSndRcvWork work in masterNameList)
            {
                rowNo = rowNo + 1;
                row = _receiveInfoTable.NewRow();
                row[_receiveInfoDataTable.RowNoColumn.ColumnName] = rowNo;
                row[_receiveInfoDataTable.MasterNameColumn.ColumnName] = work.MasterName;
                //-----DEL 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
                //for (int i = 0; i < baseCodeNameList.Count; i++ ) 
                //{
                //    BaseCodeNameWork baseCodeNameWork = (BaseCodeNameWork)this.baseCodeNameList[i];
                //    row[baseCodeNameWork.SectionCode] = string.Empty;
                //}
                //-----DEL 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
                //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
                row[_receiveInfoDataTable.DisplayOrderColumn.ColumnName] = work.DisplayOrder;
                for (int i = 0; i < _sndRcvHisList.Count; i++)
                {
                    SndRcvHisWork sndRcvHisWork = (SndRcvHisWork)this._sndRcvHisList[i];
                    row[sndRcvHisWork.EnterpriseCode + sndRcvHisWork.SectionCode.Trim() + sndRcvHisWork.SndRcvHisConsNo.ToString()] = string.Empty;
                }
                //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
                _receiveInfoTable.Rows.Add(row);
            }
        }

        /// <summary>
        /// エラーメッセージ処理
        /// </summary>
        /// <param name="iLevel">エラーレベル</param>
        /// <param name="message">エラーメッセージ</param>
        /// <param name="status">STATUS</param>
        /// <returns>true:チェック完了 false:チェック未完了</returns>
        /// <remarks>
        /// <br>Note		: エラーメッセージを行う。</br>
        /// <br>Programmer	: 譚洪</br>
        /// <br>Date		: 2009.04.01</br>
        /// </remarks>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
        {
            TMsgDisp.Show(
                iLevel,
                PROGRAM_ID,
                "",
                "",
                "",
                message,
                status,
                null,
                MessageBoxButtons.OK,
                MessageBoxDefaultButton.Button1);
        }

        #endregion region ■ 送受信共通処理 ■

        #region ■ グリッド ■

        /// <summary>
        /// 送信条件グリッドキープレスイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void Condition_Grid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.Condition_Grid.ActiveCell == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.Condition_Grid.ActiveCell;

            // ActiveCellが数量の場合
            if (cell.Column.Key == this._extractionConditionDataTable.BeginningTimeColumn.ColumnName
                || cell.Column.Key == this._extractionConditionDataTable.EndTimeColumn.ColumnName)
            {
                // 編集モード中？
                if (cell.IsInEditMode)
                {
                    if (!this.KeyPressNumCheck(e.KeyChar, cell.Text, cell.SelStart, cell.SelLength))
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// 数値入力チェック処理
        /// </summary>
        /// <param name="key">入力されたキー値</param>
        /// <param name="prevVal">入力値</param>
        /// <param name="selstart">入力値</param>
        /// <param name="sellength">入力値</param>
        /// <returns>true=入力可,false=入力不可</returns>
        private bool KeyPressNumCheck(char key, string prevVal, int selstart, int sellength)
        {
            // 制御キーが押された？
            if (Char.IsControl(key))
            {
                return true;
            }
            // 数値以外は、ＮＧ
            if (!Char.IsDigit(key))
            {
                return false;
            }

            // キーが押されたと仮定した場合の文字列を生成する。
            string _strResult = "";
            if (sellength > 0)
            {
                _strResult = prevVal.Substring(0, selstart) + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));
            }
            else
            {
                _strResult = prevVal;
            }

            // キーが押された結果の文字列を生成する。
            _strResult = prevVal.Substring(0, selstart)
                + key
                + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));

            // 桁数チェック！
            if (_strResult.Length > 6)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 送信条件グリッドキードンイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void Condition_Grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.Condition_Grid.ActiveCell != null)
            {
                Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.Condition_Grid.ActiveCell;

                    // 編集中であった場合
                    if (cell.IsInEditMode)
                    {
                        // セルのスタイルにて判定
                        switch (this.Condition_Grid.ActiveCell.StyleResolved)
                        {
                            // テキストボックス・テキストボックス(ボタン付)
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.Edit:
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton:
                                {
                                    switch (e.KeyData)
                                    {
                                        // ←キー
                                        case Keys.Left:
                                            if (this.Condition_Grid.ActiveCell.SelStart == 0)
                                            {
                                                this.Condition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab);
                                                e.Handled = true;
												// add by 馮文雄 2011/07/25 ----------------------------->>>>>>
												while (!(this.Condition_Grid.ActiveCell.IsInEditMode ||
													"SendDestCond".Equals(this.Condition_Grid.ActiveCell.Column.ToString())))
												{
													this.Condition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab);
													e.Handled = true;
												}
												// add by 馮文雄 2011/07/25 -----------------------------<<<<<<
                                            }
                                            break;
                                        // →キー
                                        case Keys.Right:
                                            if (this.Condition_Grid.ActiveCell.SelStart >= this.Condition_Grid.ActiveCell.Text.Length)
                                            {
                                                this.Condition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
                                                e.Handled = true;
												// add by 馮文雄 2011/07/25 ----------------------------->>>>>>
												while (!this.Condition_Grid.ActiveCell.IsInEditMode)
												{
													this.Condition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
													e.Handled = true;
												}
												// add by 馮文雄 2011/07/25 -----------------------------<<<<<<
                                            }
                                            break;
										// add by 馮文雄 2011/07/25 ----------------------------->>>>>>
										// ↓キー
										case Keys.Down:
											{
												this.Condition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell);
												if (this.Condition_Grid.ActiveCell.CanEnterEditMode)
												{
													this.Condition_Grid.PerformAction(UltraGridAction.EnterEditMode);
												}
												e.Handled = true;
											}
											break;
										// ↑キー
										case Keys.Up:
											{
												this.Condition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell);
												if (this.Condition_Grid.ActiveCell.CanEnterEditMode)
												{
													this.Condition_Grid.PerformAction(UltraGridAction.EnterEditMode);
												}
												e.Handled = true;
											}
											break;
										// add by 馮文雄 2011/07/25 -----------------------------<<<<<<
                                    }
                                }
                                break;
                            // 上記以外のスタイル
                            default:
                                {
                                    switch (e.KeyData)
                                    {
                                        // ←キー
                                        case Keys.Left:
                                            {
                                                this.Condition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab);
                                                e.Handled = true;
												// add by 馮文雄 2011/07/25 ----------------------------->>>>>>
												while (!(this.Condition_Grid.ActiveCell.IsInEditMode ||
													"SendDestCond".Equals(this.Condition_Grid.ActiveCell.Column.ToString())))
												{
													this.Condition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab);
													e.Handled = true;
												}
												// add by 馮文雄 2011/07/25 -----------------------------<<<<<<
                                            }
                                            break;
                                        // →キー
                                        case Keys.Right:
                                            {
                                                this.Condition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
                                                e.Handled = true;
												// add by 馮文雄 2011/07/25 ----------------------------->>>>>>
												while (!this.Condition_Grid.ActiveCell.IsInEditMode)
												{
													this.Condition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
													e.Handled = true;
												}
												// add by 馮文雄 2011/07/25 -----------------------------<<<<<<
                                            }
                                            break;
										// add by 馮文雄 2011/07/25 ----------------------------->>>>>>
										// ↓キー
										case Keys.Down:
											{
												this.Condition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell);
												if (this.Condition_Grid.ActiveCell.CanEnterEditMode)
												{
													this.Condition_Grid.PerformAction(UltraGridAction.EnterEditMode);
												}
												e.Handled = true;
											}
											break;
										// ↑キー
										case Keys.Up:
											{
												this.Condition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell);
												if (this.Condition_Grid.ActiveCell.CanEnterEditMode)
												{
													this.Condition_Grid.PerformAction(UltraGridAction.EnterEditMode);
												}
												e.Handled = true;
											}
											break;
										// add by 馮文雄 2011/07/25 -----------------------------<<<<<<
                                    }
                                    break;
                                }
                        }
                    } // add by 馮文雄 2011/07/25 ----------------------------->>>>>>
                    else
                    {
                        switch (e.KeyCode)
                        {
                            case Keys.Left:
                                {
                                    this.Condition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab);
                                    e.Handled = true;
                                    while (!(this.Condition_Grid.ActiveCell.IsInEditMode || 
                                        "SendDestCond".Equals(this.Condition_Grid.ActiveCell.Column.ToString())))
                                    {
                                        this.Condition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab);
                                        e.Handled = true;
                                    }
                                    e.Handled = true;
                                    break;
                                }
                            case Keys.Right:
                                {
                                    this.Condition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
                                    e.Handled = true;
                                    while (!(this.Condition_Grid.ActiveCell.IsInEditMode ||
                                        "BeginningDate".Equals(this.Condition_Grid.ActiveCell.Column.ToString())))
                                    {
                                        this.Condition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
                                        e.Handled = true;
                                    }
                                    e.Handled = true;
                                    break;
                                }
                            // ↓キー
                            case Keys.Down:
                                {
                                    this.Condition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell);
                                    if (this.Condition_Grid.ActiveCell.CanEnterEditMode)
                                    {
                                        this.Condition_Grid.PerformAction(UltraGridAction.EnterEditMode);
                                    }
                                    e.Handled = true;
                                }
                                break;
                            // ↑キー
                            case Keys.Up:
                                {
                                    this.Condition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell);
                                    if (this.Condition_Grid.ActiveCell.CanEnterEditMode)
                                    {
                                        this.Condition_Grid.PerformAction(UltraGridAction.EnterEditMode);
                                    }
                                    e.Handled = true;
                                }
                                break;
                        }
                    }
                    // add by 馮文雄 2011/07/25 -----------------------------<<<<<<

                    switch (e.KeyCode)
                    {
                        case Keys.Home:
                            {
                                if ((this.Condition_Grid.ActiveCell != null) && (this.Condition_Grid.ActiveCell.IsInEditMode))
                                {
                                    // 編集モードの場合はなにもしない
                                }
                                else
                                {
                                    this.Condition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstCellInRow);
                                }
                                break;
                            }
                        case Keys.End:
                            {
                                // 編集モードの場合はなにもしない
                                if ((this.Condition_Grid.ActiveCell != null) && (this.Condition_Grid.ActiveCell.IsInEditMode))
                                {
                                    //
                                }
                                else
                                {
                                    this.Condition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.LastCellInRow);
                                }
                                break;
                            }
                        case Keys.Enter:
                            {
								//bool isMove = MoveNextAllowEditCell(false);// del 2011/07/25

                                break;
                            }
                    }
                }
        }

        /// <summary>
        /// 送信条件グリッドEnterキーイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void Condition_Grid_BeforeEnterEditMode(object sender, CancelEventArgs e)
        {
            if (this.Condition_Grid.ActiveCell == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.Condition_Grid.ActiveCell;
            int rowIndex = cell.Row.Index;
            String value = cell.Value.ToString().Trim();

            // ActiveCellが開始時間の場合
            if (cell.Column.Key == this._extractionConditionDataTable.BeginningTimeColumn.ColumnName)
            {
                // 開始時間変換
                if (value.Length == 8)
                {
                    this._extractionConditionDataTable[rowIndex].BeginningTime = value.Substring(0, 2) + value.Substring(3, 2) + value.Substring(6, 2);
                    cell.Value = value.Substring(0, 2) + value.Substring(3, 2) + value.Substring(6, 2);
                }
            }
            // ActiveCellが終了時間の場合
            else if (cell.Column.Key == this._extractionConditionDataTable.EndTimeColumn.ColumnName)
            {
                // 終了時間変換
                if (value.Length == 8)
                {
                    this._extractionConditionDataTable[rowIndex].EndTime = value.Substring(0, 2) + value.Substring(3, 2) + value.Substring(6, 2);
                    cell.Value = value.Substring(0, 2) + value.Substring(3, 2) + value.Substring(6, 2);
                }
            }
            else if (cell.Column.Key == this._extractionConditionDataTable.BeginningDateColumn.ColumnName
                     || cell.Column.Key == this._extractionConditionDataTable.EndDateColumn.ColumnName)
            {
                if (cell.Value is DBNull)
                {
                    this._preDataTime = DateTime.MinValue;
                }
                else
                {
                    this._preDataTime = Convert.ToDateTime(cell.Value);
                }
            }
        }

        /// <summary>
        /// 送信条件グリッドセルアップデート後イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void Condition_Grid_AfterExitEditMode(object sender, EventArgs e)
        {
            if (this.Condition_Grid.ActiveCell == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.Condition_Grid.ActiveCell;
            int rowIndex = cell.Row.Index;


            // ActiveCellが開始時間の場合
            if (cell.Column.Key == this._extractionConditionDataTable.BeginningTimeColumn.ColumnName)
            {
                string value = cell.Value.ToString().Trim();
                // 開始時間変換
                if (value.Length == 6)
                {
                    this._extractionConditionDataTable[rowIndex].BeginningTime = value.Substring(0, 2) + ":" +
                       value.Substring(2, 2) + ":" + value.Substring(4, 2);
                }
            }
            // ActiveCellが終了時間の場合
            else if (cell.Column.Key == this._extractionConditionDataTable.EndTimeColumn.ColumnName)
            {
                string value = cell.Value.ToString().Trim();
                // 終了時間変換
                if (value.Length == 6)
                {
                    this._extractionConditionDataTable[rowIndex].EndTime = value.Substring(0, 2) + ":" +
                       value.Substring(2, 2) + ":" + value.Substring(4, 2);
                }
            }
        }

        /// <summary>
        /// 送信条件グリッドセルアップデート後イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void Condition_Grid_AfterCellUpdate(object sender, CellEventArgs e)
        {
            if (e.Cell == null) return;
            int rowIndex = e.Cell.Row.Index;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = e.Cell;

            string errMsg = string.Empty;
            if (cell.Column.Key == this._extractionConditionDataTable.BeginningTimeColumn.ColumnName)
            {
                errMsg = "開始時間は時間6桁で入力して下さい。";
            }
            else if (cell.Column.Key == this._extractionConditionDataTable.EndTimeColumn.ColumnName)
            {
                errMsg = "終了時間は時間6桁で入力して下さい。";
            }


            // ActiveCellが開始時間の場合
            if (cell.Column.Key == this._extractionConditionDataTable.BeginningTimeColumn.ColumnName
                || cell.Column.Key == this._extractionConditionDataTable.EndTimeColumn.ColumnName)
            {
                string startTime = cell.Value.ToString().Trim();
                // チェック処理
                if (!string.IsNullOrEmpty(startTime))
                {
                    bool inputFlg = true;
                    for (int i = 0; i < startTime.Length; i++)
                    {
                        if (!char.IsNumber(startTime, i))
                        {
                            inputFlg = false;
                            break;
                        }
                    }

                    if (!inputFlg)
                    {
                        TMsgDisp.Show(
                           this,
                           emErrorLevel.ERR_LEVEL_INFO,
                           this.Name,
                           errMsg,
                           -1,
                           MessageBoxButtons.OK);
                        cell.Value = string.Empty;
                    }
                    else
                    {
                        // 桁チェック
                        if (startTime.Length != 6)
                        {
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                errMsg,
                                -1,
                                MessageBoxButtons.OK);
                            cell.Value = string.Empty;
                        }
                        else
                        {
                            // 時間有効性チェック
                            int hour = Convert.ToInt32(startTime.Substring(0, 2));
                            int minute = Convert.ToInt32(startTime.Substring(2, 2));
                            int second = Convert.ToInt32(startTime.Substring(4, 2));
                            if (hour >= 24 || minute >= 60 || second >= 60)
                            {
                                TMsgDisp.Show(
                                   this,
                                   emErrorLevel.ERR_LEVEL_INFO,
                                   this.Name,
                                   errMsg,
                                   -1,
                                   MessageBoxButtons.OK);
                                cell.Value = string.Empty;
                            }
                            else
                            {
                                if (cell.Column.Key == this._extractionConditionDataTable.BeginningTimeColumn.ColumnName)
                                {
                                    this._extractionConditionDataTable[rowIndex].BeginningTime = startTime.Substring(0, 2) + ":"
                                        + startTime.Substring(2, 2) + ":" + startTime.Substring(4, 2);
                                }
                                else if (cell.Column.Key == this._extractionConditionDataTable.EndTimeColumn.ColumnName)
                                {
                                    this._extractionConditionDataTable[rowIndex].EndTime = startTime.Substring(0, 2) + ":"
                                        + startTime.Substring(2, 2) + ":" + startTime.Substring(4, 2);
                                }

                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 送受信区分選択イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void tce_SendAndReceKubun_ValueChanged(object sender, EventArgs e)
        {
            //this.SendClear(); //DEL 2011/07/25
            //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
            this.SendClear(1);
            if (this.tce_SendAndReceKubun.SelectedIndex == 0)
            {                
                InitSecCode();//ADD 2011/09/14 sundx #24542 拠点選択について
                this.tce_ExtractCondDiv.SelectedIndex = 0;
            }
            //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
        }

        //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
        /// <summary>
        /// 抽出条件区分選択イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void tce_ExtractCondDiv_ValueChanged(object sender, EventArgs e)
        {
            this.SendClear(2);
            if (this.tce_ExtractCondDiv.SelectedIndex == 1)
            {
                this.Acc_Grid.DisplayLayout.Bands[0].Columns[this._updateResultDataTable.SendDestColumn.ColumnName].Hidden = false;
            }
            else
            {
                this.Acc_Grid.DisplayLayout.Bands[0].Columns[this._updateResultDataTable.SendDestColumn.ColumnName].Hidden = true;
            }
        }
        //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<

        /// <summary>
        /// 受信条件グリッドキープレスイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void BCondition_Grid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.BCondition_Grid.ActiveCell == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.BCondition_Grid.ActiveCell;

            // ActiveCellが数量の場合
            if (cell.Column.Key == this._receiveConditionDataTable.BeginningTimeColumn.ColumnName
                || cell.Column.Key == this._receiveConditionDataTable.EndTimeColumn.ColumnName)
            {
                // 編集モード中？
                if (cell.IsInEditMode)
                {
                    if (!this.KeyPressNumCheck(e.KeyChar, cell.Text, cell.SelStart, cell.SelLength))
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// 受信条件グリッドキードンイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void BCondition_Grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.BCondition_Grid.ActiveCell != null)
            {
                Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.BCondition_Grid.ActiveCell;

                    // 編集中であった場合
                    if (cell.IsInEditMode)
                    {
                        // セルのスタイルにて判定
                        switch (this.BCondition_Grid.ActiveCell.StyleResolved)
                        {
                            // テキストボックス・テキストボックス(ボタン付)
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.Edit:
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton:
                                {
                                    switch (e.KeyData)
                                    {
                                        // ←キー
                                        case Keys.Left:
                                            if (this.BCondition_Grid.ActiveCell.SelStart == 0)
                                            {
                                                this.BCondition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab);
                                                e.Handled = true;
                                            }
                                            break;
                                        // →キー
                                        case Keys.Right:
                                            if (this.BCondition_Grid.ActiveCell.SelStart >= this.BCondition_Grid.ActiveCell.Text.Length)
                                            {
                                                this.BCondition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
                                                e.Handled = true;
                                            }
                                            break;
                                    }
                                }
                                break;
                            // 上記以外のスタイル
                            default:
                                {
                                    switch (e.KeyData)
                                    {
                                        // ←キー
                                        case Keys.Left:
                                            {
                                                this.BCondition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab);
                                                e.Handled = true;
                                            }
                                            break;
                                        // →キー
                                        case Keys.Right:
                                            {
                                                this.BCondition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
                                                e.Handled = true;
                                            }
                                            break;
                                    }
                                    break;
                                }
                        }
                    }

                    switch (e.KeyCode)
                    {
                        case Keys.Home:
                            {
                                if ((this.BCondition_Grid.ActiveCell != null) && (this.BCondition_Grid.ActiveCell.IsInEditMode))
                                {
                                    // 編集モードの場合はなにもしない
                                }
                                else
                                {
                                    this.BCondition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstCellInRow);
                                }
                                break;
                            }
                        case Keys.End:
                            {
                                // 編集モードの場合はなにもしない
                                if ((this.BCondition_Grid.ActiveCell != null) && (this.BCondition_Grid.ActiveCell.IsInEditMode))
                                {
                                    //
                                }
                                else
                                {
                                    this.BCondition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.LastCellInRow);
                                }
                                break;
                            }
                        case Keys.Enter:
                            {
                                bool isMove = BMoveNextAllowEditCell(false);
                                break;
                            }
                    }
                }
        }

        /// <summary>
        /// 受信条件グリッドEnterキーイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void BCondition_Grid_BeforeEnterEditMode(object sender, CancelEventArgs e)
        {
            if (this.BCondition_Grid.ActiveCell == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.BCondition_Grid.ActiveCell;
            int rowIndex = cell.Row.Index;
            String value = cell.Value.ToString().Trim();

            // ActiveCellが開始時間の場合
            if (cell.Column.Key == this._receiveConditionDataTable.BeginningTimeColumn.ColumnName)
            {
                // 開始時間変換
                if (value.Length == 8)
                {
                    this._receiveConditionDataTable[rowIndex].BeginningTime = value.Substring(0, 2) + value.Substring(3, 2) + value.Substring(6, 2);
                    cell.Value = value.Substring(0, 2) + value.Substring(3, 2) + value.Substring(6, 2);
                }
            }
            // ActiveCellが終了時間の場合
            else if (cell.Column.Key == this._receiveConditionDataTable.EndTimeColumn.ColumnName)
            {
                // 終了時間変換
                if (value.Length == 8)
                {
                    this._receiveConditionDataTable[rowIndex].EndTime = value.Substring(0, 2) + value.Substring(3, 2) + value.Substring(6, 2);
                    cell.Value = value.Substring(0, 2) + value.Substring(3, 2) + value.Substring(6, 2);
                }
            }
            else if (cell.Column.Key == this._receiveConditionDataTable.BeginningDateColumn.ColumnName
                     || cell.Column.Key == this._receiveConditionDataTable.EndDateColumn.ColumnName)
            {
                if (cell.Value is DBNull)
                {
                    this._preDataTime = DateTime.MinValue;
                }
                else
                {
                    this._preDataTime = Convert.ToDateTime(cell.Value);
                }
            }
        }

        /// <summary>
        /// タブの処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <returns/>
        /// <remarks>
        /// <br>Note       : なし。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.05.20</br>
        /// </remarks>
        private void ultraTabControl2_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
        {
            //-----DEL 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
            //if (this.ultraTabControl1.SelectedTab == this.ultraTabControl1.Tabs["searchTab"])
            //{
            //    this.Bcc_Grid.Visible = false;
            //    this.BCondition_Grid.Visible = true;
            //}
            //else
            //{
            //    this.Bcc_Grid.Visible = true;
            //    this.BCondition_Grid.Visible = false;
            //}
            //-----DEL 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
            //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
            if (this.ultraTabControl2.SelectedTab == this.ultraTabControl2.Tabs["searchTab"])
            {
                this._settingButton.SharedProps.Enabled = false;
                if (this.BCondition_Grid.Rows.Count > 0 && this.BCondition_Grid.ActiveRow != null &&
                    (int)this.BCondition_Grid.ActiveRow.Cells[this._receiveConditionDataTable.ExtraCondDivColumn.ColumnName].Value == 1)
                {
                    this._detailButton.SharedProps.Enabled = true;
                    this._custDetailButton.SharedProps.Visible = true;
                    this._suppDetailButton.SharedProps.Visible = true;
                    this._goodsDetailButton.SharedProps.Visible = true;
                    this._stockDetailButton.SharedProps.Visible = true;
                    this._rateDetailButton.SharedProps.Visible = true;
                    // --- ADD 2012/07/26 ------------------------------------>>>>>
                    this._employeeDetailButton.SharedProps.Visible = true;
                    this._joinPartsUrateDetailButton.SharedProps.Visible = true;
                    this._userGdBuyDivUrateDetailButton.SharedProps.Visible = true;
                    // --- ADD 2012/07/26 ------------------------------------<<<<<
                    this._custDetailButton.SharedProps.Enabled = false;
                    this._suppDetailButton.SharedProps.Enabled = false;
                    this._goodsDetailButton.SharedProps.Enabled = false;
                    this._stockDetailButton.SharedProps.Enabled = false;
                    this._rateDetailButton.SharedProps.Enabled = false;
                    // --- ADD 2012/07/26 ------------------------------------->>>>>
                    this._employeeDetailButton.SharedProps.Enabled = false;
                    this._joinPartsUrateDetailButton.SharedProps.Enabled = false;
                    this._userGdBuyDivUrateDetailButton.SharedProps.Enabled = false;
                    // --- ADD 2012/07/26 -------------------------------------<<<<<

                    GetSelectSndRcvEtr(this.BCondition_Grid.ActiveRow.Cells[_receiveConditionDataTable.EnterpriseCodeColumn.ColumnName].Value.ToString(),
                        this.BCondition_Grid.ActiveRow.Cells[_receiveConditionDataTable.BaseCodeColumn.ColumnName].Value.ToString(),
                        (int)this.BCondition_Grid.ActiveRow.Cells[_receiveConditionDataTable.SndRcvHisConsNoColumn.ColumnName].Value);
                    if (sndRcvEtrDic != null)
                    {
                        if (sndRcvEtrDic.ContainsKey(FILEID_CUSTOMER))
                        {
                            this._custDetailButton.SharedProps.Enabled = true;
                        }
                        if (sndRcvEtrDic.ContainsKey(FILEID_GOODS))
                        {
                            this._goodsDetailButton.SharedProps.Enabled = true;
                        }
                        if (sndRcvEtrDic.ContainsKey(FILEID_STOCK))
                        {
                            this._stockDetailButton.SharedProps.Enabled = true;
                        }
                        if (sndRcvEtrDic.ContainsKey(FILEID_SUPPLIER))
                        {
                            this._suppDetailButton.SharedProps.Enabled = true;
                        }
                        if (sndRcvEtrDic.ContainsKey(FILEID_RATE))
                        {
                            this._rateDetailButton.SharedProps.Enabled = true;
                        }
                        // --- ADD 2012/07/26 ---------------------------->>>>>
                        if (sndRcvEtrDic.ContainsKey(FILEID_EMPLOYEE))
                        {
                            this._employeeDetailButton.SharedProps.Enabled = true;
                        }
                        if (sndRcvEtrDic.ContainsKey(FILEID_JOINPARTSU))
                        {
                            this._joinPartsUrateDetailButton.SharedProps.Enabled = true;
                        }
                        if (sndRcvEtrDic.ContainsKey(FILEID_USERGDU))
                        {
                            this._userGdBuyDivUrateDetailButton.SharedProps.Enabled = true;
                        }
                        // --- ADD 2012/07/26 ----------------------------<<<<<
                    }
                    this.BCondition_Grid.ContextMenu = _contextMenu;
                }
                else
                {
                    this.BCondition_Grid.ContextMenu = null;
                    this._detailButton.SharedProps.Enabled = false;
                }
            }
            else
            {
                if (this.Bcc_Grid.ActiveRow != null &&
                    (MST_GOODSU.Equals(this.Bcc_Grid.ActiveRow.Cells[this._receiveInfoDataTable.MasterNameColumn.ColumnName].Value) ||
                    (MST_STOCK.Equals(this.Bcc_Grid.ActiveRow.Cells[this._receiveInfoDataTable.MasterNameColumn.ColumnName].Value))))
                {
                    this._settingButton.SharedProps.Enabled = true;
                }
                else
                {
                    this._settingButton.SharedProps.Enabled = false;
                }

                this._detailButton.SharedProps.Enabled = false;
            }
            //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
        }

        /// <summary>
        /// タブの処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <returns/>
        /// <remarks>
        /// <br>Note       : なし。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.05.20</br>
        /// </remarks>
        private void ultraTabControl1_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
        {
            if (this.ultraTabControl1.SelectedTab == this.ultraTabControl1.Tabs["searchTab"])
            {
                this.Acc_Grid.Visible = false;
                this.Condition_Grid.Visible = true;
                //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
                this._extractDetailButton.SharedProps.Enabled = false;
                this._settingButton.SharedProps.Visible = false;
                this._detailButton.SharedProps.Visible = false;
                //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
            }
            else
            {
                this.Acc_Grid.Visible = true;
                this.Condition_Grid.Visible = false;
                //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
                if (this.tce_ExtractCondDiv.SelectedIndex == 1)
                {
                    this._extractDetailButton.SharedProps.Enabled = true;
                }
                this._settingButton.SharedProps.Visible = false;
                this._detailButton.SharedProps.Visible = false;
                //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
            }
        }

        /// <summary>
        /// 受信条件グリッドセルアップデート後イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void BCondition_Grid_AfterExitEditMode(object sender, EventArgs e)
        {
            if (this.BCondition_Grid.ActiveCell == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.BCondition_Grid.ActiveCell;
            int rowIndex = cell.Row.Index;


            // ActiveCellが開始時間の場合
            if (cell.Column.Key == this._receiveConditionDataTable.BeginningTimeColumn.ColumnName)
            {
                string value = cell.Value.ToString().Trim();
                // 開始時間変換
                if (value.Length == 6)
                {
                    this._receiveConditionDataTable[rowIndex].BeginningTime = value.Substring(0, 2) + ":" +
                       value.Substring(2, 2) + ":" + value.Substring(4, 2);
                }
            }
            // ActiveCellが終了時間の場合
            else if (cell.Column.Key == this._receiveConditionDataTable.EndTimeColumn.ColumnName)
            {
                string value = cell.Value.ToString().Trim();
                // 終了時間変換
                if (value.Length == 6)
                {
                    this._receiveConditionDataTable[rowIndex].EndTime = value.Substring(0, 2) + ":" +
                       value.Substring(2, 2) + ":" + value.Substring(4, 2);
                }
            }
        }

        /// <summary>
        /// 受信条件グリッドセルアップデート後イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void BCondition_Grid_AfterCellUpdate(object sender, CellEventArgs e)
        {
            if (e.Cell == null) return;
            int rowIndex = e.Cell.Row.Index;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = e.Cell;

            string errMsg = string.Empty;
            if (cell.Column.Key == this._receiveConditionDataTable.BeginningTimeColumn.ColumnName)
            {
                errMsg = "開始時間は時間6桁で入力して下さい。";
            }
            else if (cell.Column.Key == this._receiveConditionDataTable.EndTimeColumn.ColumnName)
            {
                errMsg = "終了時間は時間6桁で入力して下さい。";
            }

            // ActiveCellが開始時間の場合
            if (cell.Column.Key == this._receiveConditionDataTable.BeginningTimeColumn.ColumnName
                || cell.Column.Key == this._receiveConditionDataTable.EndTimeColumn.ColumnName)
            {
                string startTime = cell.Value.ToString().Trim();
                // チェック処理
                if (!string.IsNullOrEmpty(startTime))
                {
                    bool inputFlg = true;
                    for (int i = 0; i < startTime.Length; i++)
                    {
                        if (!char.IsNumber(startTime, i))
                        {
                            inputFlg = false;
                            break;
                        }
                    }

                    if (!inputFlg)
                    {
                        TMsgDisp.Show(
                           this,
                           emErrorLevel.ERR_LEVEL_INFO,
                           this.Name,
                           errMsg,
                           -1,
                           MessageBoxButtons.OK);
                        cell.Value = string.Empty;
                    }
                    else
                    {
                        // 桁チェック
                        if (startTime.Length != 6)
                        {
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                errMsg,
                                -1,
                                MessageBoxButtons.OK);
                            cell.Value = string.Empty;
                        }
                        else
                        {
                            // 時間有効性チェック
                            int hour = Convert.ToInt32(startTime.Substring(0, 2));
                            int minute = Convert.ToInt32(startTime.Substring(2, 2));
                            int second = Convert.ToInt32(startTime.Substring(4, 2));
                            if (hour >= 24 || minute >= 60 || second >= 60)
                            {
                                TMsgDisp.Show(
                                   this,
                                   emErrorLevel.ERR_LEVEL_INFO,
                                   this.Name,
                                   errMsg,
                                   -1,
                                   MessageBoxButtons.OK);
                                cell.Value = string.Empty;
                            }
                            else
                            {
                                if (cell.Column.Key == this._receiveConditionDataTable.BeginningTimeColumn.ColumnName)
                                {
                                    this._receiveConditionDataTable[rowIndex].BeginningTime = startTime.Substring(0, 2) + ":"
                                        + startTime.Substring(2, 2) + ":" + startTime.Substring(4, 2);
                                }
                                else if (cell.Column.Key == this._receiveConditionDataTable.EndTimeColumn.ColumnName)
                                {
                                    this._receiveConditionDataTable[rowIndex].EndTime = startTime.Substring(0, 2) + ":"
                                        + startTime.Substring(2, 2) + ":" + startTime.Substring(4, 2);
                                }

                            }
                        }
                    }
                }
            }
        }


        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note		: フォームロードイベント処理発生します。</br>
        /// <br>Programmer	: 劉学智</br>
        /// <br>Date		: 2009.05.20</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;
            this._prevControl = e.NextCtrl;

            switch (e.PrevCtrl.Name)
            {
                //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
                case "tEdit_SectionCode":
                    {
                        bool flag = true;
                        try
                        {
                            // 拠点コード取得
                            string sectionCode = this.tEdit_SectionCode.DataText;

                            if (sectionCode.Trim().Equals(""))
                            {
                                //クリア処理と同じ
                                SendClear(0);
                                //flag = false;//DEL 2011/07/25
                                if (string.IsNullOrEmpty(this.tEdit_SectionCode.DataText.Trim())) flag = false;//ADD 2011/07/25
                                return;
                            }

                            if (sectionCode.Trim().Equals(this._preSectionCode))
                            {
                                flag = true;
                                return;
                            }

                            // 拠点名称取得
                            string sectionName = GetSectionName(sectionCode);

                            if (sectionName.Trim() != string.Empty)
                            {
                                this.tEdit_SectionName.DataText = sectionName;
                                this.tEdit_SectionCode.Text = sectionCode.Trim().PadLeft(2, '0');
                                this._preSectionCode = sectionCode.Trim().PadLeft(2, '0');
                                flag = true;
                                SetSecCode(this.tEdit_SectionCode.Text);//ADD 2011/09/14 sundx #24542 拠点選択について
                                //ADD 2011/08/30 #24191 送信処理中選択したマスタにだけチェックがついた状態に修正---->>>>>
                                //条件送信の場合、送信対象を選択チェック
                                if (selectMstNameList == null)
                                {
                                    selectMstNameList = new ArrayList();
                                }
                                else
                                {
                                    selectMstNameList.Clear();
                                }
                                for (int i = 0; i < this.Acc_Grid.Rows.Count; i++)
                                {
                                    if ((bool)this.Acc_Grid.Rows[i].Cells[this._updateResultDataTable.SendDestColumn.ColumnName].Value)
                                    {
                                        foreach (SecMngSndRcvWork work in masterNameList)
                                        {
                                            if (work.MasterName.Equals(this.Acc_Grid.Rows[i].Cells[this._updateResultDataTable.ExtractionDataColumn.ColumnName].Value.ToString()))
                                            {
                                                selectMstNameList.Add(work);
                                            }
                                        }
                                    }
                                }
                                //ADD 2011/08/30 #24191 送信処理中選択したマスタにだけチェックがついた状態に修正----<<<<<

                                ResetGridCol();
                                //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
                                //入力したマスタ抽出条件もクリア
                                this._customerProcParam = new APCustomerProcParamWork();
                                this._supplierProcParam = new APSupplierProcParamWork();
                                this._stockProcParam = new APStockProcParamWork();
                                this._goodsProcParam = new APGoodsProcParamWork();
                                this._rateProcParam = new APRateProcParamWork();
                                // --- ADD 2012/07/26 ------------------------->>>>>
                                this._employeeProcParam = new APEmployeeProcParamWork();
                                this._joinPartsUProcParam = new APJoinPartsUProcParamWork();
                                this._userGdBuyDivUProcParam = new APUserGdBuyDivUProcParamWork();
                                // --- ADD 2012/07/26 -------------------------<<<<<
                                this.sndRcvEtrDic.Clear();
                                //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
                            }
                            else
                            {
                                TMsgDisp.Show(this,                     // 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,     // エラーレベル
                                this.Name,							    // アセンブリID
                                "送信先拠点コードが存在しません。",	// 表示するメッセージ
                                0,									    // ステータス値
                                MessageBoxButtons.OK);					// 表示するボタン

                                this.tEdit_SectionCode.DataText = this._preSectionCode;
                                flag = false;
                            }
                        }
                        finally
                        {
                            if (e.ShiftKey == false)
                            {
                                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                {
                                    if (flag)
                                    {
                                        // フォーカス設定
                                        e.NextCtrl = this.tce_ExtractCondDiv;
                                    }
                                    else
                                    {
                                        // フォーカス設定
                                        e.NextCtrl = this.SectionGuide_Button;
                                    }
                                }
                            }
                        }
                        break;
                    }
                //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
                case "ultraTabControl1":
                    {
                        switch (e.Key)
                        {
                            case Keys.Return:
                                {
                                    if (this.ultraTabControl1.SelectedTab == this.ultraTabControl1.Tabs["searchTab"])
                                    {
                                        if (this.Condition_Grid.ActiveCell != null)
                                        {
											//if (MoveNextAllowEditCell(false))// del 2011/07/25
											if (MoveNextAllowEditCell(false, e.ShiftKey))// ADD 2011/07/25
											{
												e.NextCtrl = null;
											}
											else if (this.Condition_Grid.Rows[this._extractionConditionDataTable.Rows.Count - 1].Cells[5].Activated)
											{
												//e.NextCtrl = this.tce_SendAndReceKubun;
												this.Condition_Grid.Rows[0].Cells[0].Activate();
												this.Condition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
											}
											else
											{
												e.NextCtrl = e.PrevCtrl;
											}
                                        }
                                    }
                                    break;
                                }
                            case Keys.Tab:
                                {
                                    if (this.ultraTabControl1.SelectedTab == this.ultraTabControl1.Tabs["searchTab"])
                                    {
										//if (MoveNextAllowEditCell(false))// del 2011/07/25
										if (MoveNextAllowEditCell(false, e.ShiftKey))// ADD 2011/07/25
                                        {
                                            e.NextCtrl = null;
                                        }
                                        else if (this.Condition_Grid.Rows[this._extractionConditionDataTable.Rows.Count - 1].Cells[5].Activated)
                                        {
                                            e.NextCtrl = null;
                                            this.Condition_Grid.Rows[0].Cells[0].Activate();
                                            this.Condition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                        }
                                        else
                                        {
                                            e.NextCtrl = e.PrevCtrl;
                                        }
                                    }
                                    break;
                                }
                        }
                        break;
                    }

                case "ultraTabControl2":
                    {
                        switch (e.Key)
                        {
                            case Keys.Return:
                                {
                                    if (this.ultraTabControl2.SelectedTab == this.ultraTabControl2.Tabs["searchTab"])
                                    {
                                        if (this.BCondition_Grid.ActiveCell != null)
                                        {
                                            if (BMoveNextAllowEditCell(false))
                                            {
                                                e.NextCtrl = null;
                                            }
                                            else if (this.BCondition_Grid.Rows[this._receiveConditionDataTable.Rows.Count - 1].Cells[5].Activated)
                                            {
                                                //e.NextCtrl = this.tce_SendAndReceKubun;
                                                this.BCondition_Grid.Rows[0].Cells[2].Activate();
                                                this.BCondition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                            }
                                            else
                                            {
                                                e.NextCtrl = e.PrevCtrl;
                                            }
                                        }
                                    }
                                    break;
                                }
                            case Keys.Tab:
                                {
                                    if (this.ultraTabControl2.SelectedTab == this.ultraTabControl2.Tabs["searchTab"])
                                    {
                                        if (BMoveNextAllowEditCell(false))
                                        {
                                            e.NextCtrl = null;
                                        }
                                        else if (this.BCondition_Grid.Rows[this._receiveConditionDataTable.Rows.Count - 1].Cells[5].Activated)
                                        {
                                            e.NextCtrl = null;
                                            this.BCondition_Grid.Rows[0].Cells[2].Activate();
                                            this.BCondition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                        }
                                        else
                                        {
                                            e.NextCtrl = e.PrevCtrl;
                                        }
                                    }
                                    break;
                                }
                        }
                        break;
                    }

                case "Condition_Grid":
                    {
                        switch (e.Key)
                        {
                            case Keys.Return:
                                {
                                    if (this.Condition_Grid.ActiveCell != null)
                                    {
										//if (MoveNextAllowEditCell(false))// del 2011/07/25
										if (MoveNextAllowEditCell(false, e.ShiftKey))// ADD 2011/07/25
                                        {
                                            e.NextCtrl = null;
                                        }
                                        else if (this.Condition_Grid.Rows[this._extractionConditionDataTable.Rows.Count - 1].Cells[5].Activated)
                                        {
                                            e.NextCtrl = this.tce_SendAndReceKubun;
                                            //this.Condition_Grid.Rows[0].Cells[2].Activate();
                                            //this.Condition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                        }
                                        else
                                        {
                                            e.NextCtrl = e.PrevCtrl;
                                        }
                                    }

                                    break;
                                }
                            case Keys.Tab:
                                {
									//if (MoveNextAllowEditCell(false))// del 2011/07/25
									if (MoveNextAllowEditCell(false, e.ShiftKey))// ADD 2011/07/25
                                    {
                                        e.NextCtrl = null;
                                    }
                                    else if (this.Condition_Grid.Rows[this._extractionConditionDataTable.Rows.Count - 1].Cells[5].Activated)
                                    {
                                        e.NextCtrl = this.tce_SendAndReceKubun;
                                        //this.Condition_Grid.Rows[0].Cells[2].Activate();
                                        //this.Condition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                    }
                                    else
                                    {
                                        e.NextCtrl = e.PrevCtrl;
                                    }

                                    break;
                                }
                        }
                        break;
                    }

                case "BCondition_Grid":
                    {
                        switch (e.Key)
                        {
                            case Keys.Return:
                                {
                                    if (this.BCondition_Grid.ActiveCell != null)
                                    {
                                        if (BMoveNextAllowEditCell(false))
                                        {
                                            e.NextCtrl = null;
                                        }
                                        else if (this.BCondition_Grid.Rows[this._receiveConditionDataTable.Rows.Count - 1].Cells[5].Activated)
                                        {
                                            e.NextCtrl = this.tce_SendAndReceKubun;
                                            //this.Condition_Grid.Rows[0].Cells[2].Activate();
                                            //this.Condition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                        }
                                        else
                                        {
                                            e.NextCtrl = e.PrevCtrl;
                                        }
                                    }

                                    break;
                                }
                            case Keys.Tab:
                                {
                                    if (BMoveNextAllowEditCell(false))
                                    {
                                        e.NextCtrl = null;
                                    }
                                    else if (this.BCondition_Grid.Rows[this._receiveConditionDataTable.Rows.Count - 1].Cells[5].Activated)
                                    {
                                        e.NextCtrl = this.tce_SendAndReceKubun;
                                        //this.BCondition_Grid.Rows[0].Cells[2].Activate();
                                        //this.BCondition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                    }
                                    else
                                    {
                                        e.NextCtrl = e.PrevCtrl;
                                    }

                                    break;
                                }
                        }
                        break;
                    }
            }
        }

        //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
        /// <summary>
        /// 拠点名称取得処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>拠点名称</returns>
        /// <remarks>
        /// <br>Note        : 拠点名称を取得します。</br>
        /// <br>Programmer  : 馮文雄</br>
        /// <br>Date        : 2011/07/25</br>
        /// </remarks>
        private string GetSectionName(string sectionCode)
        {
            string sectionName = string.Empty;

            if (sectionCode.Trim().PadLeft(2, '0') == ALL_SECTIONCODE)
            {
                sectionName = "全社";
                return sectionName;
            }

            for (int i = 0; i < baseCodeNameList.Count; i++)
            {
                if (sectionCode.PadLeft(2, '0').Equals(((BaseCodeNameWork)baseCodeNameList[i]).SectionCode.Trim()))
                {
                    sectionName = ((BaseCodeNameWork)baseCodeNameList[i]).SectionGuideNm;
                    return sectionName;
                }
            }

            return sectionName;
        }

        /// <summary>
        /// Control.Click イベント(SectionGuide_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 拠点ガイドボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer  : 馮文雄</br>
        /// <br>Date        : 2011/07/25</br>
        /// </remarks>
        private void SectionGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status;
                SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
                SecInfoSet secInfoSet = new SecInfoSet();

                //status = secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out secInfoSet);//DEL by Liangsd 2011/09/05
                status = secInfoSetAcs.ExecuteGuid(this._enterpriseCode, true, out secInfoSet);    //ADD by Liangsd 2011/09/05
                if (status == 0)
                {
                    if (string.Empty.Equals(GetSectionName(secInfoSet.SectionCode.Trim())))
                    {
                        TMsgDisp.Show(this,                             // 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,     // エラーレベル
                                this.Name,							    // アセンブリID
                                "送信先拠点コードが存在しません。",	    // 表示するメッセージ
                                0,									    // ステータス値
                                MessageBoxButtons.OK);					// 表示するボタン

                        this.tEdit_SectionCode.DataText = this._preSectionCode;
                    }
                    else
                    {
                        this.tEdit_SectionCode.DataText = secInfoSet.SectionCode.Trim();
                        this.tEdit_SectionName.DataText = secInfoSet.SectionGuideNm.Trim();
                        this._preSectionCode = secInfoSet.SectionCode.Trim();
                        ResetGridCol();
                        SetSecCode(this.tEdit_SectionCode.Text);//ADD 2011/09/14 sundx #24542
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// グリッド情報を再設定
        /// </summary>
        /// <remarks>
        /// <br>Note　　　  :グリッド情報を再設定。</br>
        /// <br>Programmer  : 馮文雄</br>
        /// <br>Date        : 2011/07/25</br>
        /// </remarks>
        private void ResetGridCol()
        {
            this._extractionConditionDataTable.Clear();
            this._updateResultDataTable.Clear();
            this._receiveConditionDataTable.Clear();
            this._receiveInfoTable.Clear();

            // 送信情報データ設定
            this.Acc_Grid.DataSource = this._updateResultDataTable;
            // 送信条件データ設定
            this.Condition_Grid.DataSource = this._extractionConditionDataTable;
            // 送信情報グリッド初期設定
            this.InitialAccSettingGridCol();
            // マスタ名称を取得する。
            this.SearchMasterName();
            // マスタ名称を取得区分。
            this.SearchMasterDoDiv();
            // シンク実行日付を取得する。
            this.SearchSyncExecDate();
            // 送受信対象設定マスタより、マスタ名称初期設定
            this.InitialAccDataGridCol();
            // 送信条件グリッド初期設定
            this.InitialConSettingGridCol();
            // 送信条件グリッド再設定
            this.ResetConSettingGridCol();
        }

        /// <summary>
        /// 送信条件グリッド再設定
        /// </summary>
        /// <remarks>
        /// <br>Note　　　  :送信条件グリッド再設定。</br>
        /// <br>Programmer  : 馮文雄</br>
        /// <br>Date        : 2011/07/25</br>
        /// </remarks>
        private void ResetConSettingGridCol()
        {
            if (!ALL_SECTIONCODE.Equals(tEdit_SectionCode.DataText))
            {
                //「00:全社」ではない場合、入力した送信先拠点だけを保留
                ArrayList indexList = new ArrayList();
                for (int i = 0; i < this._extractionConditionDataTable.Rows.Count; i++)
                {
                    ExtractionConditionDataSet.ExtractionConditionRow row = (ExtractionConditionDataSet.ExtractionConditionRow)_extractionConditionDataTable.Rows[i];
                    if (!row.BaseCode.Trim().Equals(tEdit_SectionCode.DataText.Trim()))
                    {
                        indexList.Add(i);
                    }
                }
                for (int j = indexList.Count - 1; j >= 0; j--)
                {
                    _extractionConditionDataTable.Rows.RemoveAt((int)indexList[j]);
                }
            }
            if (this.tce_ExtractCondDiv.SelectedIndex == 1)
            {
                //開始日付、開始時間、終了日付、終了時間に空白を設定する
                for (int i = 0; i < this._extractionConditionDataTable.Rows.Count; i++)
                {
                    ExtractionConditionDataSet.ExtractionConditionRow row = (ExtractionConditionDataSet.ExtractionConditionRow)_extractionConditionDataTable.Rows[i];
                    row.BeginningDate = DateTime.MinValue;
                    row.BeginningTime = string.Empty;
                    row.EndDate = DateTime.MinValue;
                    row.EndTime = string.Empty;
                    row.InitBeginningDate = DateTime.MinValue;
                    row.InitBeginningTime = string.Empty;
                    //ADD 2011/08/29 #23934 条件送信の開始日付時間・終了日付時間の初期値について--------------------------------------->>>>>
                    Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.BeginningDateColumn.ColumnName].SetValue(DBNull.Value, true);
                    Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.EndDateColumn.ColumnName].SetValue(DBNull.Value, true);                    
                    //ADD 2011/08/29 #23934 条件送信の開始日付時間・終了日付時間の初期値について---------------------------------------<<<<<                    
                }
                //ADD 2011/08/29 #23934 条件送信の開始日付時間・終了日付時間の初期値について--------------------------------------->>>>>
                if (Condition_Grid.Rows.Count > 0)
                {
                    Condition_Grid.Rows[Condition_Grid.Rows.Count - 1].Cells[this._extractionConditionDataTable.EndDateColumn.ColumnName].Activated = false;
                    Condition_Grid.Rows[Condition_Grid.Rows.Count - 1].Cells[this._extractionConditionDataTable.EndDateColumn.ColumnName].Selected = false;
                }
                //ADD 2011/08/29 #23934 条件送信の開始日付時間・終了日付時間の初期値について---------------------------------------<<<<<
            }
        }

        /// <summary>
        /// 送信情報ダブルクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  :送信条件グリッド再設定。</br>
        /// <br>Programmer  : 馮文雄</br>
        /// <br>Date        : 2011/07/25</br>
        /// </remarks>
        private void Acc_Grid_DoubleClickCell(object sender, DoubleClickCellEventArgs e)
        {
            if (this.tce_ExtractCondDiv.SelectedIndex != 1) return;
            if (e.Cell == null) return;
            if (e.Cell.Column.Index == this.Acc_Grid.DisplayLayout.Bands[0].Columns[this._updateResultDataTable.SendDestColumn.ColumnName].Index)
            {
                return;
            }
            ExtractDetailShow();
        }

        /// <summary>
        /// 抽出条件詳細画面をポップアップする
        /// </summary>
        /// <remarks>
        /// <br>Note　　　  :対応マスタの抽出条件画面をポップアップする。</br>
        /// <br>Programmer  : 馮文雄</br>
        /// <br>Date        : 2011/07/25</br>
        /// </remarks>
        private void ExtractDetailShow()
        {
            UltraGridRow row = Acc_Grid.ActiveRow;
            if (row == null) return;
            string colMasterNm = row.Cells[this._updateResultDataTable.ExtractionDataColumn.ColumnName].Value.ToString();
            if (MST_RATE.Equals(colMasterNm))
            {
                //掛率マスタ抽出条件詳細
                PMKYO01601UA _PMKYO01601UA = new PMKYO01601UA();
                _PMKYO01601UA.Mode = 1; //1:新規モード
                _PMKYO01601UA._rateProcParam = this._rateProcParam;
                _PMKYO01601UA.ShowDialog();
                this._rateProcParam = _PMKYO01601UA._rateProcParam;
            }
            else if (MST_SUPPLIER.Equals(colMasterNm))
            {
                //仕入先マスタ抽出条件詳細
                PMKYO01501UA _PMKYO01501UA = new PMKYO01501UA();
                _PMKYO01501UA.Mode = 1; //1:新規モード
                _PMKYO01501UA._supplierProcParam = this._supplierProcParam;
                _PMKYO01501UA.ShowDialog();
                this._supplierProcParam = _PMKYO01501UA._supplierProcParam;
            }
            else if (MST_STOCK.Equals(colMasterNm))
            {
                //在庫マスタ抽出条件詳細
                PMKYO01701UA _PMKYO01701UA = new PMKYO01701UA();
                _PMKYO01701UA.Mode = 1; //1:新規モード
                _PMKYO01701UA._stockProcParam = this._stockProcParam;
                _PMKYO01701UA.ShowDialog();
                this._stockProcParam = _PMKYO01701UA._stockProcParam;
            }
            else if (MST_CUSTOME.Equals(colMasterNm))
            {
                //得意先マスタ抽出条件詳細
                PMKYO01301UA _PMKYO01301UA = new PMKYO01301UA();
                _PMKYO01301UA.Mode = 1; //1:新規モード
                _PMKYO01301UA._customerProcParam = this._customerProcParam;
                _PMKYO01301UA.ShowDialog();
                this._customerProcParam = _PMKYO01301UA._customerProcParam;
            }
            else if (MST_GOODSU.Equals(colMasterNm))
            {
                //商品マスタ抽出条件詳細
                PMKYO01401UA _PMKYO01401UA = new PMKYO01401UA();
                _PMKYO01401UA.Mode = 1; //1:新規モード
                _PMKYO01401UA._goodsProcParam = this._goodsProcParam;
                _PMKYO01401UA.ShowDialog();
                this._goodsProcParam = _PMKYO01401UA._goodsProcParam;
            }
            // --- ADD 2012/07/26 ------------------------------------->>>>>
            else if (MST_EMPLOYEE.Equals(colMasterNm))
            {
                // 従業員設定マスタ抽出条件詳細
                PMKYO01511UA _PMKYO01511UA = new PMKYO01511UA();
                _PMKYO01511UA.Mode = 1; //1:新規モード
                _PMKYO01511UA._employeeProcParam = this._employeeProcParam;
                _PMKYO01511UA.ShowDialog();
                this._employeeProcParam = _PMKYO01511UA._employeeProcParam;
            }
            else if (MST_JOINPARTSU.Equals(colMasterNm))
            {
                // 結合マスタ抽出条件抽出条件詳細
                PMKYO01521UA _PMKYO01521UA = new PMKYO01521UA();
                _PMKYO01521UA.Mode = 1; //1:新規モード
                _PMKYO01521UA._joinPartsUProcParam = this._joinPartsUProcParam;
                _PMKYO01521UA.ShowDialog();
                this._joinPartsUProcParam = _PMKYO01521UA._joinPartsUProcParam;
            }
            else if (MST_USERGDBUYDIVU.Equals(colMasterNm))
            {
                // ユーザーガイドマスタ（販売区分）抽出条件抽出条件詳細
                PMKYO01531UA _PMKYO01531UA = new PMKYO01531UA();
                _PMKYO01531UA.Mode = 1; //1:新規モード
                _PMKYO01531UA._userGdBuyDivUProcParam = this._userGdBuyDivUProcParam;
                _PMKYO01531UA.ShowDialog();
                this._userGdBuyDivUProcParam = _PMKYO01531UA._userGdBuyDivUProcParam;
            }
            // --- ADD 2012/07/26 -------------------------------------<<<<<
        }

        /// <summary>
        /// 行選択処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  :送信条件グリッド再設定。</br>
        /// <br>Programmer  : 馮文雄</br>
        /// <br>Date        : 2011/07/25</br>
        /// </remarks>
        private void Bcc_Grid_AfterRowActivate(object sender, EventArgs e)
        {
            if (this.ultraTabControl2.SelectedTab == this.ultraTabControl2.Tabs["searchTab"])
            {
                this._settingButton.SharedProps.Enabled = false;

                if (this.BCondition_Grid.ActiveRow != null &&
                    (int)this.BCondition_Grid.ActiveRow.Cells[this._receiveConditionDataTable.ExtraCondDivColumn.ColumnName].Value == 1)
                {
                    this._detailButton.SharedProps.Enabled = true;
                }
                else
                {
                    this._detailButton.SharedProps.Enabled = false;
                }
            }
            else
            {
                if (this.Bcc_Grid.ActiveRow != null &&
                    (MST_GOODSU.Equals(this.Bcc_Grid.ActiveRow.Cells[this._receiveInfoDataTable.MasterNameColumn.ColumnName].Value) ||
                    (MST_STOCK.Equals(this.Bcc_Grid.ActiveRow.Cells[this._receiveInfoDataTable.MasterNameColumn.ColumnName].Value))))
                {
                    this._settingButton.SharedProps.Enabled = true;
                }
                else
                {
                    this._settingButton.SharedProps.Enabled = false;
                }

                this._detailButton.SharedProps.Enabled = false;
            }
        }

        /// <summary>
        /// 受信情報グリッドダブルクリック処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  :送信条件グリッド再設定。</br>
        /// <br>Programmer  : 馮文雄</br>
        /// <br>Date        : 2011/07/25</br>
        /// </remarks>
        private void Bcc_Grid_DoubleClickCell(object sender, DoubleClickCellEventArgs e)
        {
            if (e.Cell == null) return;
            //送信対象設定
            SendDestSet();
        }

        /// <summary>
        /// 送信対象設定画面をポップアップする
        /// </summary>
        /// <remarks>
        /// <br>Note　　　  :送信対象設定画面をポップアップする。</br>
        /// <br>Programmer  : 馮文雄</br>
        /// <br>Date        : 2011/07/25</br>
        /// </remarks>
        private void SendDestSet()
        {
            UltraGridRow row = Bcc_Grid.ActiveRow;
            if (row == null) return;
            if ((!MST_STOCK.Equals(row.Cells[_receiveInfoDataTable.MasterNameColumn.ColumnName].Value))
                && (!MST_GOODSU.Equals(row.Cells[_receiveInfoDataTable.MasterNameColumn.ColumnName].Value))) return;
            //在庫マスタ、または商品マスタの場合送信対象を設定可能
            PMKYO09200UA _PMKYO09200UA = new PMKYO09200UA();
            _PMKYO09200UA._callForm = true;
            _PMKYO09200UA._callPara = Convert.ToInt32(row.Cells[_receiveInfoDataTable.DisplayOrderColumn.ColumnName].Value);
            _PMKYO09200UA.ShowDialog();
        }

        /// <summary>
        /// 行選択処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  :受信条件グリッド行選択。</br>
        /// <br>Programmer  : 馮文雄</br>
        /// <br>Date        : 2011/07/25</br>
        /// </remarks>
        private void BCondition_Grid_AfterRowActivate(object sender, EventArgs e)
        {
            if (this.ultraTabControl2.SelectedTab == this.ultraTabControl2.Tabs["searchTab"])
            {
                this._settingButton.SharedProps.Enabled = false;

                if (this.BCondition_Grid.ActiveRow != null &&
                    (int)this.BCondition_Grid.ActiveRow.Cells[_receiveConditionDataTable.ExtraCondDivColumn.ColumnName].Value == 1)
                {
                    this._detailButton.SharedProps.Enabled = true;
                    this._custDetailButton.SharedProps.Visible = true;
                    this._suppDetailButton.SharedProps.Visible = true;
                    this._goodsDetailButton.SharedProps.Visible = true;
                    this._stockDetailButton.SharedProps.Visible = true;
                    this._rateDetailButton.SharedProps.Visible = true;
                    // --- ADD 2012/07/26 ---------->>>>>
                    this._employeeDetailButton.SharedProps.Visible = true;
                    this._joinPartsUrateDetailButton.SharedProps.Visible = true;
                    this._userGdBuyDivUrateDetailButton.SharedProps.Visible = true;
                    // --- ADD 2012/07/26 ----------<<<<<
                    this._custDetailButton.SharedProps.Enabled = false;
                    this._suppDetailButton.SharedProps.Enabled = false;
                    this._goodsDetailButton.SharedProps.Enabled = false;
                    this._stockDetailButton.SharedProps.Enabled = false;
                    this._rateDetailButton.SharedProps.Enabled = false;
                    // --- ADD 2012/07/26 ---------->>>>>
                    this._employeeDetailButton.SharedProps.Enabled = false;
                    this._joinPartsUrateDetailButton.SharedProps.Enabled = false;
                    this._userGdBuyDivUrateDetailButton.SharedProps.Enabled = false;
                    // --- ADD 2012/07/26 ----------<<<<<

                    GetSelectSndRcvEtr(this.BCondition_Grid.ActiveRow.Cells[_receiveConditionDataTable.EnterpriseCodeColumn.ColumnName].Value.ToString(),
                        this.BCondition_Grid.ActiveRow.Cells[_receiveConditionDataTable.BaseCodeColumn.ColumnName].Value.ToString(),
                        (int)this.BCondition_Grid.ActiveRow.Cells[_receiveConditionDataTable.SndRcvHisConsNoColumn.ColumnName].Value);
                    if (sndRcvEtrDic != null)
                    {
                        if (sndRcvEtrDic.ContainsKey(FILEID_CUSTOMER))
                        {
                            this._custDetailButton.SharedProps.Enabled = true;
                        }
                        if (sndRcvEtrDic.ContainsKey(FILEID_GOODS))
                        {
                            this._goodsDetailButton.SharedProps.Enabled = true;
                        }
                        if (sndRcvEtrDic.ContainsKey(FILEID_STOCK))
                        {
                            this._stockDetailButton.SharedProps.Enabled = true;
                        }
                        if (sndRcvEtrDic.ContainsKey(FILEID_SUPPLIER))
                        {
                            this._suppDetailButton.SharedProps.Enabled = true;
                        }
                        if (sndRcvEtrDic.ContainsKey(FILEID_RATE))
                        {
                            this._rateDetailButton.SharedProps.Enabled = true;
                        }
                        // --- ADD 2012/07/26 ---------------------------->>>>>
                        if (sndRcvEtrDic.ContainsKey(FILEID_EMPLOYEE))
                        {
                            this._employeeDetailButton.SharedProps.Enabled = true;
                        }
                        if (sndRcvEtrDic.ContainsKey(FILEID_JOINPARTSU))
                        {
                            this._joinPartsUrateDetailButton.SharedProps.Enabled = true;
                        }
                        if (sndRcvEtrDic.ContainsKey(FILEID_USERGDU))
                        {
                            this._userGdBuyDivUrateDetailButton.SharedProps.Enabled = true;
                        }
                        // --- ADD 2012/07/26 ----------------------------<<<<<
                    }
                    this.BCondition_Grid.ContextMenu = _contextMenu;
                }
                else
                {
                    this._detailButton.SharedProps.Enabled = false;
                    this.BCondition_Grid.ContextMenu = null;
                }
            }
        }

        /// <summary>
        /// 履歴ログデータに対する抽出条件履歴ログデータを取得
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="sndRcvHisConsNo">送受信履歴ログ送信番号</param>
        /// <returns>抽出条件履歴ログデータリスト</returns>
        private void GetSelectSndRcvEtr(string enterpriseCode, string sectionCode, Int32 sndRcvHisConsNo)
        {
            sndRcvEtrDic.Clear();
            if (_sndRcvEtrList != null && _sndRcvEtrList.Count > 0)
            {
                foreach (SndRcvEtrWork work in _sndRcvEtrList)
                {
                    if (work.EnterpriseCode.Equals(enterpriseCode) && work.SectionCode.Trim().Equals(sectionCode.Trim())
                        && work.SndRcvHisConsNo == sndRcvHisConsNo)
                    {
                        if (work.FileId.Equals(FILEID_CUSTOMER))
                        {
                            sndRcvEtrDic.Add(FILEID_CUSTOMER, work);
                        }
                        else if (work.FileId.Equals(FILEID_GOODS))
                        {
                            sndRcvEtrDic.Add(FILEID_GOODS, work);
                        }
                        else if (work.FileId.Equals(FILEID_STOCK))
                        {
                            sndRcvEtrDic.Add(FILEID_STOCK, work);
                        }
                        else if (work.FileId.Equals(FILEID_SUPPLIER))
                        {
                            sndRcvEtrDic.Add(FILEID_SUPPLIER, work);
                        }
                        else if (work.FileId.Equals(FILEID_RATE))
                        {
                            sndRcvEtrDic.Add(FILEID_RATE, work);
                        }
                        // --- ADD 2012/07/26 ---------------------------->>>>>
                        else if (work.FileId.Equals(FILEID_EMPLOYEE))
                        {
                            sndRcvEtrDic.Add(FILEID_EMPLOYEE, work);
                        }
                        else if (work.FileId.Equals(FILEID_JOINPARTSU))
                        {
                            sndRcvEtrDic.Add(FILEID_JOINPARTSU, work);
                        }
                        else if (work.FileId.Equals(FILEID_USERGDU))
                        {
                            sndRcvEtrDic.Add(FILEID_USERGDU, work);
                        }
                        // --- ADD 2012/07/26 ----------------------------<<<<<
                    }
                }
            }
        }

        /// <summary>
        /// マウス右クリック処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  :受信条件グリッドのマウス右クリック処理。</br>
        /// <br>Programmer  : 馮文雄</br>
        /// <br>Date        : 2011/07/25</br>
        /// </remarks>
        private void BCondition_Grid_MouseUp(object sender, MouseEventArgs e)
        {
            if (sender == this.BCondition_Grid && e.Button == MouseButtons.Right)
            {
                UltraGrid ug = (UltraGrid)sender;
                Infragistics.Win.UIElement aUIElement = ug.DisplayLayout.UIElement.ElementFromPoint(
                                 new Point(e.X, e.Y));

                if (aUIElement == null) return;

                // 当前行
                UltraGridRow aRow = (UltraGridRow)aUIElement.GetContext(typeof(UltraGridRow));
                // 当前cell
                UltraGridCell aCell = (UltraGridCell)aUIElement.GetContext(typeof(UltraGridCell));
            }
        }

        /// <summary>
        /// KeyDown処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : 送信情報グリッドのマウス右クリック処理。</br>
        /// <br>Programmer  : 馮文雄</br>
        /// <br>Date        : 2011/07/25</br>
        /// </remarks>
        private void Acc_Grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.tce_ExtractCondDiv.SelectedIndex == 1)
            {
                if (Acc_Grid.ActiveRow != null)
                {
                    if (e.KeyCode == Keys.Space)
                    {
                        // [削除]カラムの値を設定
                        bool flag = (bool)this.Acc_Grid.ActiveRow.Cells[this._updateResultDataTable.SendDestColumn.ColumnName].Value;
                        this.Acc_Grid.ActiveRow.Cells[this._updateResultDataTable.SendDestColumn.ColumnName].Value = !flag;
                    }
                }
            }
        }

        /// <summary>
        /// BeforeCellActivate処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : 送信情報グリッドのマウス右クリック処理。</br>
        /// <br>Programmer  : 馮文雄</br>
        /// <br>Date        : 2011/07/25</br>
        /// </remarks>
        private void Acc_Grid_BeforeCellActivate(object sender, CancelableCellEventArgs e)
        {
            if (this.tce_ExtractCondDiv.SelectedIndex == 1)
            {
                Acc_Grid.Selected.Rows.Clear();
                bool val = !((bool)e.Cell.Value);
                e.Cell.Value = val;

                if (Acc_Grid.Selected.Rows.Count == 0 || e.Cell.Row != Acc_Grid.Selected.Rows[0])
                    e.Cell.Row.Selected = true;
                e.Cancel = true;
            }
        }
        //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<

        /// <summary>
        /// 次入力可能セル移動処理
        /// </summary>
        /// <param name="activeCellCheck">true:ActiveCellが入力可能の場合はNextに移動させない false:ActiveCellに関係なくNextに移動させる</param>
        /// <param name="isShift">true:Shiftキーが押下される false:Shiftキーが押下されない</param>
        /// <returns>true:セル移動完了 false:セル移動失敗</returns>
        /// <remarks>
        /// <br>Note       : なし。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.05.20</br>
        /// </remarks>
		//private bool MoveNextAllowEditCell(bool activeCellCheck) // DEL 2011/07/25
		private bool MoveNextAllowEditCell(bool activeCellCheck, bool isShift)// ADD 2011/07/25
        {
            this.Condition_Grid.SuspendLayout();
            bool moved = false;
            bool performActionResult = false;

            if ((activeCellCheck) && (this.Condition_Grid.ActiveCell != null))
            {
                if ((!this.Condition_Grid.ActiveCell.Column.Hidden) &&
                    (this.Condition_Grid.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                    (this.Condition_Grid.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                {
                    moved = true;
                }
            }

            while (!moved)
            {
				//-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
				if (isShift)
				{
					performActionResult = this.Condition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab);
				}
				else
				{
				//-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
					performActionResult = this.Condition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell);
				}

                if (performActionResult)
                {
                    if ((this.Condition_Grid.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                        (this.Condition_Grid.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                    {
                        moved = true;
                    }
                    else
                    {
                        moved = false;
                    }
                }
                else
                {
                    break;
                }
            }

            if (moved)
            {
                this.Condition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
            }

            this.Condition_Grid.ResumeLayout();
            return performActionResult;
        }

        /// <summary>
        /// 次入力可能セル移動処理
        /// </summary>
        /// <param name="activeCellCheck">true:ActiveCellが入力可能の場合はNextに移動させない false:ActiveCellに関係なくNextに移動させる</param>
        /// <returns>true:セル移動完了 false:セル移動失敗</returns>
        /// <remarks>
        /// <br>Note       : なし。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.05.20</br>
        /// </remarks>
        private bool BMoveNextAllowEditCell(bool activeCellCheck)
        {
            this.Condition_Grid.SuspendLayout();
            bool moved = false;
            bool performActionResult = false;

            if ((activeCellCheck) && (this.Condition_Grid.ActiveCell != null))
            {
                if ((!this.BCondition_Grid.ActiveCell.Column.Hidden) &&
                    (this.BCondition_Grid.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                    (this.BCondition_Grid.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                {
                    moved = true;
                }
            }

            while (!moved)
            {
                performActionResult = this.BCondition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell);

                if (performActionResult)
                {
                    if ((this.BCondition_Grid.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                        (this.BCondition_Grid.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                    {
                        moved = true;
                    }
                    else
                    {
                        moved = false;
                    }
                }
                else
                {
                    break;
                }
            }

            if (moved)
            {
                this.BCondition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
            }

            this.BCondition_Grid.ResumeLayout();
            return performActionResult;
        }

        /// <summary>
        /// セルのデータチェック処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <returns/>
        /// <remarks>
        /// <br>Note       : なし。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.05.20</br>
        /// </remarks>
        private void Condition_Grid_CellDataError(object sender, CellDataErrorEventArgs e)
        {
            if (this.Condition_Grid.ActiveCell != null)
            {
                // 数値項目の場合
                if ((this.Condition_Grid.ActiveCell.Column.DataType == typeof(Int32)) ||
                    (this.Condition_Grid.ActiveCell.Column.DataType == typeof(Int64)) ||
                    (this.Condition_Grid.ActiveCell.Column.DataType == typeof(double)))
                {
                    Infragistics.Win.EmbeddableEditorBase editorBase = this.Condition_Grid.ActiveCell.EditorResolved;

                    // 未入力は0にする				
                    if (editorBase.CurrentEditText.Trim() == "")
                    {
                        editorBase.Value = 0;				// 0をセット
                        this.Condition_Grid.ActiveCell.Value = 0;
                    }
                    // 数値項目に「-」or「.」だけしか入ってなかったら駄目です				
                    else if ((editorBase.CurrentEditText.Trim() == "-") ||
                        (editorBase.CurrentEditText.Trim() == ".") ||
                        (editorBase.CurrentEditText.Trim() == "-."))
                    {
                        editorBase.Value = 0;				// 0をセット
                        this.Condition_Grid.ActiveCell.Value = 0;
                    }
                    // 通常入力				
                    else
                    {
                        try
                        {
                            editorBase.Value = Convert.ChangeType(editorBase.CurrentEditText.Trim(), this.Condition_Grid.ActiveCell.Column.DataType);
                            this.Condition_Grid.ActiveCell.Value = editorBase.Value;
                        }
                        catch
                        {
                            editorBase.Value = 0;
                            this.Condition_Grid.ActiveCell.Value = 0;
                        }
                    }
                    e.RaiseErrorEvent = false;			// エラーイベントは発生させない
                    e.RestoreOriginalValue = false;		// セルの値を元に戻さない	
                    e.StayInEditMode = false;			// 編集モードは抜ける
                }
                else if (this.Condition_Grid.ActiveCell.Column.DataType == typeof(TimeSpan))
                {
                    try
                    {
                        Infragistics.Win.EmbeddableEditorBase editorBase = this.Condition_Grid.ActiveCell.EditorResolved;

                        if (editorBase.TextLength == 6)
                        {
                            string value = editorBase.CurrentEditText;

                            editorBase.Value = new System.TimeSpan(Convert.ToInt32(value.Substring(0, 2)),
                                Convert.ToInt32(value.Substring(2, 2)), Convert.ToInt32(value.Substring(4, 2)));
                            this.Condition_Grid.ActiveCell.Value = new System.TimeSpan(Convert.ToInt32(value.Substring(0, 2)),
                                Convert.ToInt32(value.Substring(2, 2)), Convert.ToInt32(value.Substring(4, 2)));
                        }
                        else
                        {
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "データ値を更新できません:エディタの値は無効です。",
                                -1,
                                MessageBoxButtons.OK);

                            editorBase.Value = null;
                            this.Condition_Grid.ActiveCell.Value = null;
                        }
                    }
                    catch
                    {

                    }
                }
                else if (this.Condition_Grid.ActiveCell.Column.DataType == typeof(DateTime))
                {
                    try
                    {
                        Infragistics.Win.EmbeddableEditorBase editorBase = this.Condition_Grid.ActiveCell.EditorResolved;
                        Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.Condition_Grid.ActiveCell;

                        if (cell.Column.Key == this._extractionConditionDataTable.BeginningDateColumn.ColumnName)
                        {
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "開始日付は日付8桁で入力して下さい。",
                                -1,
                                MessageBoxButtons.OK);

                            if (this._preDataTime == DateTime.MinValue)
                            {
                                editorBase.Value = null;
                                this.Condition_Grid.ActiveCell.Value = null;
                            }
                            else
                            {
                                editorBase.Value = this._preDataTime;
                                this.Condition_Grid.ActiveCell.Value = this._preDataTime;
                            }
                        }
                        else if (cell.Column.Key == this._extractionConditionDataTable.EndDateColumn.ColumnName)
                        {
                            TMsgDisp.Show(
                               this,
                               emErrorLevel.ERR_LEVEL_INFO,
                               this.Name,
                               "終了日付は日付8桁で入力して下さい。",
                               -1,
                               MessageBoxButtons.OK);

                            if (this._preDataTime == DateTime.MinValue)
                            {
                                editorBase.Value = null;
                                this.Condition_Grid.ActiveCell.Value = null;
                            }
                            else
                            {
                                editorBase.Value = this._preDataTime;
                                this.Condition_Grid.ActiveCell.Value = this._preDataTime;
                            }
                        }
                    }
                    catch
                    {

                    }

                    e.RaiseErrorEvent = false;			// エラーイベントは発生させない
                    e.RestoreOriginalValue = false;		// セルの値を元に戻さない	
                }
            }
        }

        #endregion グリッド
    }
}