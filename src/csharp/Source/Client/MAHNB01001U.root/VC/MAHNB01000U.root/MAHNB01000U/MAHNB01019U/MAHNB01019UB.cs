using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using System.Xml;
//---ADD 2022/04/26 陳艶丹 PMKOBETSU-4208 電子帳簿対応--->>>>>
using Broadleaf.Application.Controller;
using Broadleaf.Xml.Serialization;
using Broadleaf.Library.Resources;
//---ADD 2022/04/26 陳艶丹 PMKOBETSU-4208 電子帳簿対応---<<<<<

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 売上入力用ユーザー設定クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上入力のユーザー設定情報を管理するクラスです。</br>
    /// <br>Programmer : 20056 對馬 大輔</br>
    /// <br>Date       : 2007.09.10</br>
    /// <br></br>
    /// <br>UpDate</br>
    /// <br>2009.06.17 21024 佐々木 健 MANTIS[0013539] 初期フォーカス位置のデフォルトを変更（担当者⇒得意先）</br>
    /// <br>2009.07.15 22018 鈴木 正臣 MANTIS[0013801] ＢＬコードガイドの初期表示モードを設定可能に変更。</br>
    /// <br>Update Note : 2009/12/23 張凱</br>
    /// <br>              PM.NS-5-A・PM.NS保守依頼④</br>
    /// <br>              出荷数入力最大桁数、受注数入力最大桁数を追加</br>
    /// <br>              フッタ部のフォーカス制御を追加</br>
    /// <br>Update Note  : 2010/01/27 高峰</br>
    /// <br>               PM1003-A・ＰＭ．ＮＳ　４次改良</br>
    /// <br>               ＰＭ．ＮＳ　４次改良の対応</br>
    /// <br>Update Note : 2010/02/26 對馬 大輔 </br>
    /// <br>              SCM対応</br>
    /// <br>Update Note  : 2010/06/15 山路 芳郎</br>
    /// <br>               RC連携対応</br>
    /// <br>               ①SCM情報自動展開の削除</br>
    /// <br>               ②RC連携用フォルダを追加</br>   
    /// <br>Update Note: 2010/08/06 20056 對馬 大輔 </br>
    /// <br>             担当者、受注者、発行者の表示制御を変更</br>
    /// <br>Update Note: 2010/10/26 21024　佐々木 健</br>
    /// <br>             明細行数の初期値変更(99→18)</br>
    /// <br>Update Note: 2011/08/08 連番1002 許雁波 </br>
    /// <br>             「入力後のカーソル位置」のドロプダアウを追加</br>
    /// <br>Update Note: 2011/08/09 連番4,979 梁森東</br>
    /// <br>               ユーザー設定の入力制御にアクティブ色項目を追加</br>
    /// <br>Update Note: 2012/04/11 No.594 脇田 靖之 </br>
    /// <br>             「商品検索後のフォーカス位置」項目追加</br>
    /// <br>Update Note: 2012/05/21 福田 康夫 </br>
    /// <br>             No.594障害対応不備のためもとに戻す</br>
    /// <br>Update Note: 2013/11/05 脇田 靖之</br>
    /// <br>             仕掛一覧№1492(№594)対応</br>
    /// <br>             「商品検索後のフォーカス位置」項目追加し、受注伝票を入力しやすくする</br>
    /// <br>Update Note: 2014/02/24 脇田 靖之</br>
    /// <br>             仕掛一覧 №2307</br>
    /// <br>             ユーザー設定に「伝票種別の記憶」項目追加</br>     
    /// <br>Update Note: 2018/09/04 譚洪</br>
    /// <br>管理番号   : 11470152-00</br>
    /// <br>           : 『設定』画面で画面制御タブの変更</br>
    /// <br>Update Note: 2021/03/16 陳艶丹</br>
    /// <br>管理番号   : 11770032-00</br>
    /// <br>           : PMKOBETSU-4133 売上伝票入力原価0円障害の対応</br>
    /// <br>Update Note: 2021/04/12 陳艶丹</br>
    /// <br>管理番号   : 11770021-00</br>
    /// <br>           : PMKOBETSU-4136 得意先ガイド表示項目設定の追加</br>
    /// <br>Update Note: 2021/09/10 呉元嘯</br>
    /// <br>管理番号   : 11770032-00</br>
    /// <br>           : PMKOBETSU-4172 原単価チェックと税率ログの制御ファイルの対応</br> 
    /// <br>Update Note: 2022/04/26 陳艶丹</br>
    /// <br>管理番号   : 11870080-00</br>
    /// <br>           : PMKOBETSU-4208 電子帳簿対応</br> 
    /// <br>Update Note: 2022/10/05 田村顕成功</br>
    /// <br>管理番号   : 11870141-00</br>
    /// <br>           : インボイス残対応</br>
    /// </remarks>
    [Serializable]
    public class SalesSlipInputConstruction
    {
        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        # region Private Members
        private int _focusPositionValue = DEFAULT_FocusPosition_VALUE;
        private int _dataInputCountValue = DEFAULT_DataInputCount_VALUE;
        private int _inputMonthValue = DEFAULT_InputMonthCount_VALUE;// ADD　2018/09/04 譚洪　『設定』画面で画面制御の変更
        private int _saveUnitCostCheckDivValue = DEFAULT_SAVECHECKDIV_VALUE;// ADD 2021/03/16 陳艶丹 FOR PMKOBETSU-4133
        private int _stockGoodsCdValue = DEFAULT_StockGoodsCd_VALUE;
        private int _accPayDivCdValue = DEFAULT_AccPayDivCd_VALUE;
        private int _fontSizeValue = DEFAULT_FontSize_VALUE;
        private int _colorsValue = DEFAULT_Colors_VALUE;                    // ADD 2011/08/09
        private int _clearAfterSave = DEFAULT_ClearAfterSave_VALUE;
        private int _ultraOptionSet = DEFAULT_UltraOptionSet_VALUE; // ADD 2010/01/27
        private int _saveInfoStore = DEFAULT_SaveInfoStore_VALUE;
        private int _partySaleSlipDiv = DEFAULT_PartySaleSlipDiv_VALUE;
        private HeaderFocusConstructionList _headerFocusConstructionList;
        private FunctionConstructionList _functionConstructionList; // ADD 2010/07/06
        private FunctionDetailConstructionList _functionDetailConstructionList; // ADD 2010/08/13        
        //>>>2010/08/06
        private int _employeeCdDiv = DEFAULT_EmployeeCdDiv_VALUE;
        private int _frontEmployeeCdDiv = DEFAULT_FrontEmployeeCdDiv_VALUE;
        private int _salesInputCdDiv = DEFAULT_SalesInputCdDiv_VALUE;
        private string _employeeCd = DEFAULT_EmployeeCd_VALUE;
        //<<<2010/08/06
        private string _frontEmployeeCd = DEFAULT_FrontEmployeeCd;
        private string _salesInputCd = DEFAULT_SalesInputCd;
        private int _searchUICntDivCd = DEFAULT_SearchUICntDivCd_VALUE;
        private int _enterProcDivCd = DEFAULT_EnterProcDivCd_VALUE;
        private int _partsNoSearchDivCd = DEFAULT_PartsNoSearchDivCd_VALUE;
        private string _partsJoinCntDivCd = DEFAULT_PartsJoinCntDivCd_VALUE;
        private int _focusPositionAfterCarSearch = DEFAULT_SaveInfoStore_VALUE;
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.15 ADD
        private int _blGuideMode = DEFAULT_BLGuideMode_VALUE;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.15 ADD
        private int _cursorPos = DEFAULT_CURSORPOS_VALUE;   // ADD 連番1002 2011/08/08
        // --- DEL 2012/05/21 ---------->>>>>
        //private int _focusPositionAfterBLCodeSearch = DEFAULT_FocusPositionAfterBLCodeSearch_VALUE;   // ADD 2012/04/11 No.594
        // --- DEL 2012/05/21 ----------<<<<<
        // --- ADD 2013/11/05 Y.Wakita ---------->>>>>
        private int _focusPositionAfterBLCodeSearch = DEFAULT_FocusPositionAfterBLCodeSearch_VALUE;
        // --- ADD 2013/11/05 Y.Wakita ----------<<<<<
        // --- ADD 2014/02/24 Y.Wakita ---------->>>>>
        private int _acptAnOdrStatusMemory = DEFAULT_AcptAnOdrStatusMemory_VALUE;
        // --- ADD 2014/02/24 Y.Wakita ----------<<<<<
        private int _customerGuidDisplay = DEFAULT_CustomerGuidDisplay_VALUE_NOTMAEHASHI; // ADD 2021/04/12 陳艶丹 FOR PMKOBETSU-4136
        // --- ADD 2009/12/23 ---------->>>>>
        private int _shipmentMaxCnt = DEFAULT_ShipmentMaxCnt_VALUE;
        private int _acceptAnOrderMaxCnt = DEFAULT_AcceptAnOrderMaxCnt_VALUE;
        private FooterFocusConstructionList _footerFocusConstructionList;
        // --- ADD 2009/12/23 ----------<<<<<
        private int _scm = DEFAULT_SCM_VALUE; // 2010/02/26

        // 2010/06/15 >>>
        private string _rcLinkDirectory = string.Empty;
        // 2010/06/15 <<<

        // 2009.06.17 >>>
        //private const int DEFAULT_FocusPosition_VALUE = 2;
        private const int DEFAULT_FocusPosition_VALUE = 1;
        // 2009.06.17 <<<
        // 2010/10/26 Sasaki >>>
        //private const int DEFAULT_DataInputCount_VALUE = 99;
        private const int DEFAULT_DataInputCount_VALUE = 18;
        // 2010/10/26 Sasaki <<<
        private const int DEFAULT_StockGoodsCd_VALUE = 0;
        private const int DEFAULT_AccPayDivCd_VALUE = 1;
        private const int DEFAULT_ProductNumberInput_VALUE = 1;
        private const int DEFAULT_BelongInfoAutoExec_VALUE = 1;
        private const int DEFAULT_FontSize_VALUE = 11;
        private const int DEFAULT_Colors_VALUE = 0;                 // ADD 2011/08/09
        private const int DEFAULT_ClearAfterSave_VALUE = 0;
        private const int DEFAULT_UltraOptionSet_VALUE = 1; // ADD 2010/01/27
        private const int DEFAULT_SaveInfoStore_VALUE = 0;
        private const int DEFAULT_PartySaleSlipDiv_VALUE = 0;
        private const int DEFAULT_FunctionMode_VALUE = 0;
        //>>>2010/08/06
        //private const string DEFAULT_FrontEmployeeCd = null;
        //private const string DEFAULT_SalesInputCd = null;
        private const int DEFAULT_EmployeeCdDiv_VALUE = 2;
        private const int DEFAULT_FrontEmployeeCdDiv_VALUE = 2;
        private const int DEFAULT_SalesInputCdDiv_VALUE = 2;
        private const string DEFAULT_EmployeeCd_VALUE = "";
        private const string DEFAULT_FrontEmployeeCd = "";
        private const string DEFAULT_SalesInputCd = "";
        //<<<2010/08/06
        private const int DEFAULT_SearchUICntDivCd_VALUE = 0;
        private const int DEFAULT_EnterProcDivCd_VALUE = 0;
        private const int DEFAULT_PartsNoSearchDivCd_VALUE = 0;
        private const string DEFAULT_PartsJoinCntDivCd_VALUE = ".";
        private const int DEFAULT_FocusPositionAfterCarSearch_VALUE = 2;
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.15 ADD
        private const int DEFAULT_BLGuideMode_VALUE = 0;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.15 ADD
        private const int DEFAULT_CURSORPOS_VALUE = 0;  //ADD 連番1002 2011/08/08
        // --- DEL 2012/05/21 ---------->>>>>
        //private const int DEFAULT_FocusPositionAfterBLCodeSearch_VALUE = 0;  //ADD 2012/04/11 No.594
        // --- DEL 2012/05/21 ----------<<<<<
        // --- ADD 2013/11/05 Y.Wakita ---------->>>>>
        private const int DEFAULT_FocusPositionAfterBLCodeSearch_VALUE = 0;
        // --- ADD 2013/11/05 Y.Wakita ----------<<<<<
        // --- ADD 2014/02/24 Y.Wakita ---------->>>>>
        private const int DEFAULT_AcptAnOdrStatusMemory_VALUE = 0;
        // --- ADD 2014/02/24 Y.Wakita ----------<<<<<
        // ------ ADD 2021/04/12 陳艶丹 FOR PMKOBETSU-4136-------->>>>>
        private const int DEFAULT_CustomerGuidDisplay_VALUE_NOTMAEHASHI = 1;
        private const int DEFAULT_CustomerGuidDisplay_VALUE_MAEHASHI = 0;
        // ------ ADD 2021/04/12 陳艶丹 FOR PMKOBETSU-4136--------<<<<<
        // --- ADD 2009/12/23 ---------->>>>>
        private const int DEFAULT_ShipmentMaxCnt_VALUE = 7;
        private const int DEFAULT_AcceptAnOrderMaxCnt_VALUE = 7;
        // --- ADD 2009/12/23 ----------<<<<<
        private const int DEFAULT_SCM_VALUE = 1; // 2010/02/26
        private const int DEFAULT_InputMonthCount_VALUE = 25;// ADD　2018/09/04 譚洪　『設定』画面で画面制御の変更
        // --- DEL 2021/09/10 呉元嘯 PMKOBETSU-4172 原単価チェックと税率ログの制御ファイルの対応--->>>>>
        //// ------ ADD 2021/03/16 陳艶丹 FOR PMKOBETSU-4133-------->>>>
        //// XMLファイル
        //private const string XML_NAME = "SaveUnitCostCheck.XML";
        //// 山形部品以外：しない
        //private const int DEFAULT_SAVECHECKDIV_VALUE = 0;
        //// 山形部品：する
        //private const int DEFAULT_YAMAGATA_VALUE = 1;
        //// ------ ADD 2021/03/16 陳艶丹 FOR PMKOBETSU-4133--------<<<<
        // --- DEL 2021/09/10 呉元嘯 PMKOBETSU-4172 原単価チェックと税率ログの制御ファイルの対応---<<<<<
        // --- ADD 2021/09/10 呉元嘯 PMKOBETSU-4172 原単価チェックと税率ログの制御ファイルの対応--->>>>>
        // 原単価チェック区分デフォルト値
        private const int DEFAULT_SAVECHECKDIV_VALUE = 0;
        // --- ADD 2021/09/10 呉元嘯 PMKOBETSU-4172 原単価チェックと税率ログの制御ファイルの対応---<<<<<
        // --- ADD 陳艶丹 2022/04/26 PMKOBETSU-4208 電子帳簿対応--->>>>>
        // PDF出力区分デフォルト値
        private const int DEFAULT_PDFOUTPUT_VALUE = 0;
        // 出力伝票区分_売上
        private const int DEFAULT_SALESOUTPUT_VALUE = 1;
        // 出力伝票区分_見積
        private const int DEFAULT_ESTIMATEOUTPUT_VALUE = 0;
        // PDFプリンター
        private const int DEFAULT_PRINTER_VALUE = 0;
        // PDFプリンターNo
        private const int DEFAULT_PRINTERNO_VALUE = 9999;
        // PDFプリンター待機時間
        private const int DEFAULT_PRINTERWAUTTIME_VALUE = 0;

        // PDF出力区分
        private int _outputMode = DEFAULT_PDFOUTPUT_VALUE;
        // 出力伝票区分_売上
        private int _salesOutputDiv = DEFAULT_SALESOUTPUT_VALUE;
        // 出力伝票区分_見積
        private int _estimateOutputDiv = DEFAULT_ESTIMATEOUTPUT_VALUE;
        // PDFプリンター
        private int _pdfPrinter = DEFAULT_PRINTER_VALUE;
        // PDFプリンターNo
        private int _pdfPrinterNumber = DEFAULT_PRINTERNO_VALUE;
        // PDFプリンター待機時間
        private int _pdfPrinterWait = DEFAULT_PRINTERWAUTTIME_VALUE;
        // --- ADD 陳艶丹 2022/04/26 PMKOBETSU-4208 電子帳簿対応---<<<<<
        //--- ADD 田村顕成 2022/10/05 インボイス残対応 ----->>>>>
        /// <summary>返品･赤伝制御設定XMLファイル</summary>
        private const string XML_RETURNREDSETTINGS = "MAHNB01001U_ReturnRedSetting.xml";
        /// <summary>返品･赤伝制御 備考欄使用モード</summary>
        private const int ReturnRedNote_BLANK = 0;//空白
        private const int ReturnRedNote_SLIPNUM = 1;//取引日付＋元黒伝票番号
        private const int ReturnRedNote_ORIGINAL = 2;//元黒伝票番号
        private const int ReturnRedNote_OPTIONAL = 3;//任意
        private int _returnRedNote1Mode = ReturnRedNote_ORIGINAL;
        private int _returnRedNote2Mode = ReturnRedNote_ORIGINAL;
        private int _returnRedNote3Mode = ReturnRedNote_ORIGINAL;
        private string _returnRedNote1 = string.Empty;
        private string _returnRedNote2 = string.Empty;
        private string _returnRedNote3 = string.Empty;
        /// <summary>返品･赤伝制御 備考欄空白チェックモード</summary>
        private const int ReturnRedBlankCheck_OFF = 0;//チェック無し
        private const int ReturnRedBlankCheck_ON = 1;//チェックあり
        private int _returnRedBlankCheckMode = ReturnRedBlankCheck_OFF;
        //--- ADD 田村顕成 2022/10/05 インボイス残対応 -----<<<<<
        # endregion

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region Constructors
        /// <summary>
        /// 売上入力用ユーザー設定クラス
        /// </summary>
        /// <remarks>
        /// <br>Note       : 売上入力用ユーザー設定クラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 20056 對馬 大輔</br>
        /// <br>Date       : 2007.09.10</br>
        /// <br>Programmer : 連番1002 許雁波</br>
        /// <br>Date       : 2011/08/08</br>
        /// <br>Programmer : 連番4,979 梁森東</br>
        /// <br>Date       : 2011/08/09</br>
        /// <br>Update Note: 2018/09/04 譚洪</br>
        /// <br>管理番号   : 11470152-00</br>
        /// <br>           : 『設定』画面で画面制御タブの変更</br>
        /// <br>Update Note: 2021/03/16 陳艶丹</br>
        /// <br>管理番号   : 11770032-00</br>
        /// <br>           : PMKOBETSU-4133 売上伝票入力原価0円障害の対応</br>
        /// <br>Update Note: 2021/04/12 陳艶丹</br>
        /// <br>管理番号   : 11770021-00</br>
        /// <br>           : PMKOBETSU-4136 得意先ガイド表示項目設定の追加</br>
        /// </remarks>
        public SalesSlipInputConstruction()
        {
            this._focusPositionValue = DEFAULT_FocusPosition_VALUE;
            this._dataInputCountValue = DEFAULT_DataInputCount_VALUE;
            this._inputMonthValue = DEFAULT_InputMonthCount_VALUE;// ADD　2018/09/04 譚洪　『設定』画面で画面制御の変更
            // ------ ADD 2021/04/12 陳艶丹 FOR PMKOBETSU-4136-------->>>>>
            Broadleaf.Application.Remoting.ParamData.PurchaseStatus ps;
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_MaehashiKyowaGuideCtl);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                // 前橋個別の場合、得意先ガイド表示区分デフォルト値：する
                this._customerGuidDisplay = DEFAULT_CustomerGuidDisplay_VALUE_MAEHASHI;
            }
            else
            {
                // 前橋個別以外の場合、得意先ガイド表示区分デフォルト値：しない
                this._customerGuidDisplay = DEFAULT_CustomerGuidDisplay_VALUE_NOTMAEHASHI;
            }
            // ------ ADD 2021/04/12 陳艶丹 FOR PMKOBETSU-4136--------<<<<<
            this._stockGoodsCdValue = DEFAULT_StockGoodsCd_VALUE;
            this._accPayDivCdValue = DEFAULT_AccPayDivCd_VALUE;
            this._fontSizeValue = DEFAULT_FontSize_VALUE;
            this._colorsValue = DEFAULT_Colors_VALUE;                // ADD 2011/08/09
            this._clearAfterSave = DEFAULT_ClearAfterSave_VALUE;
            this._saveInfoStore = DEFAULT_SaveInfoStore_VALUE;
            this._partySaleSlipDiv = DEFAULT_PartySaleSlipDiv_VALUE;
            this._headerFocusConstructionList = new HeaderFocusConstructionList();
            this._functionConstructionList = new FunctionConstructionList(); // ADD 2010/07/06
            this._functionDetailConstructionList = new FunctionDetailConstructionList(); // ADD 2010/08/13            
            //>>>2010/08/06
            this._employeeCdDiv = DEFAULT_EmployeeCdDiv_VALUE;
            this._frontEmployeeCdDiv = DEFAULT_FrontEmployeeCdDiv_VALUE;
            this._salesInputCdDiv = DEFAULT_SalesInputCdDiv_VALUE;
            this._employeeCd = DEFAULT_EmployeeCd_VALUE;
            //<<<2010/08/06
            this._frontEmployeeCd = DEFAULT_FrontEmployeeCd;
            this._salesInputCd = DEFAULT_SalesInputCd;
            this._searchUICntDivCd = DEFAULT_SearchUICntDivCd_VALUE;
            this._enterProcDivCd = DEFAULT_EnterProcDivCd_VALUE;
            this._partsNoSearchDivCd = DEFAULT_PartsNoSearchDivCd_VALUE;
            this._partsJoinCntDivCd = DEFAULT_PartsJoinCntDivCd_VALUE;
            this._focusPositionAfterCarSearch = DEFAULT_FocusPositionAfterCarSearch_VALUE;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.15 ADD
            this._blGuideMode = DEFAULT_BLGuideMode_VALUE;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.15 ADD
            this._cursorPos = DEFAULT_CURSORPOS_VALUE;    // ADD 連番1002 2011/08/08
            // --- ADD 2009/12/23 ---------->>>>>
            this._shipmentMaxCnt = DEFAULT_ShipmentMaxCnt_VALUE;
            this._acceptAnOrderMaxCnt = DEFAULT_AcceptAnOrderMaxCnt_VALUE;
            this._footerFocusConstructionList = new FooterFocusConstructionList();
            // --- ADD 2009/12/23 ----------<<<<<
            this._scm = DEFAULT_SCM_VALUE; // 2010/02/26

            // 2010/06/15 >>>
            this._rcLinkDirectory = Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
            // 2010/06/15 <<<
            // ------ ADD 2021/03/16 陳艶丹 FOR PMKOBETSU-4133-------->>>>
            // --- DEL 2021/09/10 呉元嘯 PMKOBETSU-4172 原単価チェックと税率ログの制御ファイルの対応--->>>>>
            //// あるXMLファイル(SaveUnitCostCheck.xml)を存在する場合(山形部品)
            //if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_NAME)))
            //{
            //    // 山形部品：する
            //    this._saveUnitCostCheckDivValue = DEFAULT_YAMAGATA_VALUE;
            //}
            //else
            //{
            //    // 山形部品以外：しない
            //    this._saveUnitCostCheckDivValue = DEFAULT_SAVECHECKDIV_VALUE;
            //}
            // --- DEL 2021/09/10 呉元嘯 PMKOBETSU-4172 原単価チェックと税率ログの制御ファイルの対応---<<<<<
            // ------ ADD 2021/03/16 陳艶丹 FOR PMKOBETSU-4133--------<<<<<
        }

        /// <summary>
        /// 売上入力用ユーザー設定クラス
        /// </summary>
        /// <param name="focusPositionValue">初期フォーカス位置</param>
        /// <param name="dataInputCountValue">データ入力行数</param>
        /// <param name="stockGoodsCdValue">商品区分</param>
        /// <param name="accPayDivCdValue">買掛区分</param>
        /// <param name="fontSizeValue">フォントサイズ</param>
        /// <param name="clearAfterSave">保存後初期化処理</param>
        /// <param name="saveInfoStore">保存情報の保持</param>
        /// <param name="partySaleSlipDiv">得意先注番明細展開</param>
        /// <param name="headerFocusConstructionList">ヘッダフォーカス設定リスト</param>
        /// <param name="frontEmployeeCd">受注者コード</param>
        /// <param name="salesInputCd">発行者コード</param>
        /// <param name="searchUICntDivCd">検索画面制御区分</param>
        /// <param name="enterProcDivCd">エンターキー処理区分</param>
        /// <param name="partsNoSearchDivCd">品番検索区分</param>
        /// <param name="partsJoinCntDivCd">品番結合制御区分</param>
        /// <param name="focusPositionAfterCarSearch">車両検索後のフォーカス位置</param>
        /// <param name="blGuideMode">ＢＬガイドモード</param>
        /// <param name="shipmentMaxCnt">出荷数入力最大桁数</param>
        /// <param name="acceptAnOrderMaxCnt">受注数入力最大桁数</param>
//>>>2010/08/06
//// 2010/06/15 >>>
////DEL        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.15 DEL
////DEL        //public SalesSlipInputConstruction(int focusPositionValue, int dataInputCountValue, int stockGoodsCdValue, int accPayDivCdValue, int fontSizeValue, int clearAfterSave, int saveInfoStore, int partySaleSlipDiv, HeaderFocusConstructionList headerFocusConstructionList, string frontEmployeeCd, string salesInputCd, int searchUICntDivCd, int enterProcDivCd, int partsNoSearchDivCd, string partsJoinCntDivCd, int focusPositionAfterCarSearch)
////DEL        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.15 DEL
////DEL        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.15 ADD
////DEL        // --- UPD 2009/12/23 ---------->>>>>
////DEL        //public SalesSlipInputConstruction( int focusPositionValue, int dataInputCountValue, int stockGoodsCdValue, int accPayDivCdValue, int fontSizeValue, int clearAfterSave, int saveInfoStore, int partySaleSlipDiv, HeaderFocusConstructionList headerFocusConstructionList, string frontEmployeeCd, string salesInputCd, int searchUICntDivCd, int enterProcDivCd, int partsNoSearchDivCd, string partsJoinCntDivCd, int focusPositionAfterCarSearch, int blGuideMode )
////DEL        public SalesSlipInputConstruction(int focusPositionValue, int dataInputCountValue, int stockGoodsCdValue, int accPayDivCdValue, int fontSizeValue, int clearAfterSave, int saveInfoStore, int partySaleSlipDiv, HeaderFocusConstructionList headerFocusConstructionList, string frontEmployeeCd, string salesInputCd, int searchUICntDivCd, int enterProcDivCd, int partsNoSearchDivCd, string partsJoinCntDivCd, int focusPositionAfterCarSearch, int blGuideMode, int shipmentMaxCnt, int acceptAnOrderMaxCnt, FooterFocusConstructionList footerFocusConstructionList)
////DEL        // --- UPD 2009/12/23 ----------<<<<<
////DEL        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.15 ADD
//        public SalesSlipInputConstruction(int focusPositionValue, int dataInputCountValue, int stockGoodsCdValue, int accPayDivCdValue, int fontSizeValue, int clearAfterSave, int saveInfoStore, int partySaleSlipDiv, HeaderFocusConstructionList headerFocusConstructionList, string frontEmployeeCd, string salesInputCd, int searchUICntDivCd, int enterProcDivCd, int partsNoSearchDivCd, string partsJoinCntDivCd, int focusPositionAfterCarSearch, int blGuideMode, int shipmentMaxCnt, int acceptAnOrderMaxCnt, FooterFocusConstructionList footerFocusConstructionList, string rcLinkDirectory, int scm)
//// 2010/06/15 <<<
        //----- UPD　2018/09/04 譚洪　『設定』画面で画面制御の変更------->>>>>
        // ------ UPD 連番1002 2011/08/08 ------>>>>>
        //public SalesSlipInputConstruction(int focusPositionValue, int dataInputCountValue, int stockGoodsCdValue, int accPayDivCdValue, int fontSizeValue, int clearAfterSave, int saveInfoStore, int partySaleSlipDiv, HeaderFocusConstructionList headerFocusConstructionList, int employeeCdDiv, int frontEmployeeCdDiv, int salesInputCdDiv,  string employeeCd, string frontEmployeeCd, string salesInputCd, int searchUICntDivCd, int enterProcDivCd, int partsNoSearchDivCd, string partsJoinCntDivCd, int focusPositionAfterCarSearch, int blGuideMode, int shipmentMaxCnt, int acceptAnOrderMaxCnt, FooterFocusConstructionList footerFocusConstructionList, string rcLinkDirectory, int scm)
        //public SalesSlipInputConstruction(int focusPositionValue, int dataInputCountValue, int stockGoodsCdValue, int accPayDivCdValue, int fontSizeValue, int colorsValue, int clearAfterSave, int saveInfoStore, int partySaleSlipDiv, HeaderFocusConstructionList headerFocusConstructionList, int employeeCdDiv, int frontEmployeeCdDiv, int salesInputCdDiv, string employeeCd, string frontEmployeeCd, string salesInputCd, int searchUICntDivCd, int enterProcDivCd, int partsNoSearchDivCd, string partsJoinCntDivCd, int focusPositionAfterCarSearch, int blGuideMode, int cursorPos, int shipmentMaxCnt, int acceptAnOrderMaxCnt, FooterFocusConstructionList footerFocusConstructionList, string rcLinkDirectory, int scm) // UPD 2011/08/09
        // ------ UPD 2021/04/12 陳艶丹 FOR PMKOBETSU-4136-------->>>>>
        //public SalesSlipInputConstruction(int focusPositionValue, int dataInputCountValue, int stockGoodsCdValue, int accPayDivCdValue, int fontSizeValue, int colorsValue, int clearAfterSave, int saveInfoStore, int partySaleSlipDiv, HeaderFocusConstructionList headerFocusConstructionList, int employeeCdDiv, int frontEmployeeCdDiv, int salesInputCdDiv, string employeeCd, string frontEmployeeCd, string salesInputCd, int searchUICntDivCd, int enterProcDivCd, int partsNoSearchDivCd, string partsJoinCntDivCd, int focusPositionAfterCarSearch, int blGuideMode, int cursorPos, int shipmentMaxCnt, int acceptAnOrderMaxCnt, FooterFocusConstructionList footerFocusConstructionList, string rcLinkDirectory, int scm, int inputMonthValue)
        // ------ UPD 2021/03/16 陳艶丹 FOR PMKOBETSU-4133-------->>>>
        //public SalesSlipInputConstruction(int focusPositionValue, int dataInputCountValue, int stockGoodsCdValue, int accPayDivCdValue, int fontSizeValue, int colorsValue, int clearAfterSave, int saveInfoStore, int partySaleSlipDiv, HeaderFocusConstructionList headerFocusConstructionList, int employeeCdDiv, int frontEmployeeCdDiv, int salesInputCdDiv, string employeeCd, string frontEmployeeCd, string salesInputCd, int searchUICntDivCd, int enterProcDivCd, int partsNoSearchDivCd, string partsJoinCntDivCd, int focusPositionAfterCarSearch, int blGuideMode, int cursorPos, int shipmentMaxCnt, int acceptAnOrderMaxCnt, FooterFocusConstructionList footerFocusConstructionList, string rcLinkDirectory, int customerGudiDisplay, int scm, int inputMonthValue)
        // --- UPD 陳艶丹 2022/04/26 PMKOBETSU-4208 電子帳簿対応 ----->>>>>
        //public SalesSlipInputConstruction(int focusPositionValue, int dataInputCountValue, int stockGoodsCdValue, int accPayDivCdValue, int fontSizeValue, int colorsValue, int clearAfterSave, int saveInfoStore, int partySaleSlipDiv, HeaderFocusConstructionList headerFocusConstructionList, int employeeCdDiv, int frontEmployeeCdDiv, int salesInputCdDiv, string employeeCd, string frontEmployeeCd, string salesInputCd, int searchUICntDivCd, int enterProcDivCd, int partsNoSearchDivCd, string partsJoinCntDivCd, int focusPositionAfterCarSearch, int blGuideMode, int cursorPos, int shipmentMaxCnt, int acceptAnOrderMaxCnt, FooterFocusConstructionList footerFocusConstructionList, string rcLinkDirectory, int customerGudiDisplay, int scm, int inputMonthValue, int saveCheckDivValue)
        public SalesSlipInputConstruction(int focusPositionValue, int dataInputCountValue, int stockGoodsCdValue, int accPayDivCdValue, int fontSizeValue, int colorsValue, int clearAfterSave, int saveInfoStore, int partySaleSlipDiv, HeaderFocusConstructionList headerFocusConstructionList, int employeeCdDiv, int frontEmployeeCdDiv, int salesInputCdDiv, string employeeCd, string frontEmployeeCd, string salesInputCd, int searchUICntDivCd, int enterProcDivCd, int partsNoSearchDivCd, string partsJoinCntDivCd, int focusPositionAfterCarSearch, int blGuideMode, int cursorPos, int shipmentMaxCnt, int acceptAnOrderMaxCnt, FooterFocusConstructionList footerFocusConstructionList, string rcLinkDirectory, int customerGudiDisplay, int scm, int inputMonthValue, int saveCheckDivValue
            , int outputMode, int salesOutputDiv, int estimateOutputDiv, int pdfPrinter, int pdfPrinterNumber, int pdfPrinterWait)
        // --- UPD 陳艶丹 2022/04/26 PMKOBETSU-4208 電子帳簿対応 ----->>>>>
        // ------ UPD 2021/03/16 陳艶丹 FOR PMKOBETSU-4133--------<<<<
        // ------ UPD 2021/04/12 陳艶丹 FOR PMKOBETSU-4136--------<<<<<
        // ------ UPD 連番1002 2011/08/08 ------<<<<<
        //----- UPD　2018/09/04 譚洪　『設定』画面で画面制御の変更-------<<<<<
//<<<2010/08/06
        {
            this._focusPositionValue = focusPositionValue;
            this._dataInputCountValue = dataInputCountValue;
            this._stockGoodsCdValue = stockGoodsCdValue;
            this._accPayDivCdValue = accPayDivCdValue;
            this._fontSizeValue = fontSizeValue;
            this._colorsValue = colorsValue;           // ADD 2011/08/09
            this._clearAfterSave = clearAfterSave;
            this._saveInfoStore = saveInfoStore;
            this._partySaleSlipDiv = partySaleSlipDiv;
            this._headerFocusConstructionList = headerFocusConstructionList;
            //>>>2010/08/06
            this._employeeCdDiv = employeeCdDiv;
            this._frontEmployeeCdDiv = frontEmployeeCdDiv;
            this._salesInputCdDiv = salesInputCdDiv;
            this._employeeCd = employeeCd;
            //<<<2010/08/06
            this._frontEmployeeCd = frontEmployeeCd;
            this._salesInputCd = salesInputCd;
            this._searchUICntDivCd = searchUICntDivCd;
            this._enterProcDivCd = enterProcDivCd;
            this._partsNoSearchDivCd = partsNoSearchDivCd;
            this._partsJoinCntDivCd = partsJoinCntDivCd;
            this._focusPositionAfterCarSearch = focusPositionAfterCarSearch;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.15 ADD
            this._blGuideMode = blGuideMode;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.15 ADD
            this._cursorPos = cursorPos;    // ADD 連番1002 2011/08/08
            // --- ADD 2009/12/23 ---------->>>>>
            this._shipmentMaxCnt = shipmentMaxCnt;
            this._acceptAnOrderMaxCnt = acceptAnOrderMaxCnt;
            this._footerFocusConstructionList = footerFocusConstructionList;
            // --- ADD 2009/12/23 ----------<<<<<
            this._scm = scm; // 2010/02/26

            // 2010/06/15 >>>
            this._rcLinkDirectory = rcLinkDirectory;
            // 2010/06/15 <<<
            this._inputMonthValue = inputMonthValue;// ADD　2018/09/04 譚洪　『設定』画面で画面制御の変更
            this._customerGuidDisplay = customerGudiDisplay;// ADD 2021/04/12 陳艶丹 FOR PMKOBETSU-4136
            this._saveUnitCostCheckDivValue = saveCheckDivValue;// ADD 2021/03/16 陳艶丹 FOR PMKOBETSU-4133
            // --- ADD 陳艶丹 2022/04/26 PMKOBETSU-4208 電子帳簿対応--->>>>>
            // 伝票PDF出力デフォルト値
            this._outputMode = outputMode;
            // 出力伝票区分_売上
            this._salesOutputDiv = salesOutputDiv;
            // 出力伝票区分_見積
            this._estimateOutputDiv = estimateOutputDiv;
            // PDFプリンター
            this._pdfPrinter = pdfPrinter;
            // PDFプリンターNo
            this._pdfPrinterNumber = pdfPrinterNumber;
            // PDFプリンター待機時間
            this._pdfPrinterWait = pdfPrinterWait;
            // --- ADD 陳艶丹 2022/04/26 PMKOBETSU-4208 電子帳簿対応---<<<<<
        }
        # endregion

        // ===================================================================================== //
        // プロパティ
        // ===================================================================================== //
        # region Properties
        /// <summary>初期フォーカス位置</summary>
        public int FocusPositionValue
        {
            get { return this._focusPositionValue; }
            set { this._focusPositionValue = value; }
        }

        /// <summary>データ入力行数</summary>
        public int DataInputCountValue
        {
            get { return this._dataInputCountValue; }
            set { this._dataInputCountValue = value; }
        }

        //----- ADD　2018/09/04 譚洪　『設定』画面で画面制御の変更------->>>>>
        /// <summary>データ入力行数</summary>
        public int InputMonthValue
        {
            get { return this._inputMonthValue; }
            set { this._inputMonthValue = value; }
        }
        //----- ADD　2018/09/04 譚洪　『設定』画面で画面制御の変更-------<<<<<

        // ------ ADD 2021/03/16 陳艶丹 FOR PMKOBETSU-4133-------->>>>
        /// <summary>保存時原価チェック区分</summary>
        public int SaveUnitCostCheckDivValue
        {
            get { return this._saveUnitCostCheckDivValue; }
            set { this._saveUnitCostCheckDivValue = value; }
        }
        // ------ ADD 2021/03/16 陳艶丹 FOR PMKOBETSU-4133--------<<<<<

        /// <summary>商品区分</summary>
        public int StockGoodsCdValue
        {
            get { return this._stockGoodsCdValue; }
            set { this._stockGoodsCdValue = value; }
        }

        /// <summary>買掛区分</summary>
        public int AccPayDivCdValue
        {
            get { return this._accPayDivCdValue; }
            set { this._accPayDivCdValue = value; }
        }

        /// <summary>フォントサイズ</summary>
        public int FontSizeValue
        {
            get { return this._fontSizeValue; }
            set { this._fontSizeValue = value; }
        }

        // ADD 2011/08/09------------->>>>>>
        ///<summary>選択色 </summary>
        public int ColorsValue
        {
            get { return this._colorsValue; }
            set { this._colorsValue = value;}
        }
        // ADD 2011/08/09-------------<<<<<<

        /// <summary>保存後初期化処理</summary>
        public int ClearAfterSave
        {
            get { return this._clearAfterSave; }
            set { this._clearAfterSave = value; }
        }

        // ---------- ADD 2010/01/27 ---------->>>>>>>>>>
        /// <summary>明細ボタン表示</summary>
        public int UltraOptionSet
        {
            get { return this._ultraOptionSet; }
            set { this._ultraOptionSet = value; }
        }
        // ---------- ADD 2010/01/27 ----------<<<<<<<<<<

        /// <summary>保存情報の記憶</summary>
        public int SaveInfoStoreValue
        {
            get { return this._saveInfoStore; }
            set { this._saveInfoStore = value; }
        }

        //>>>2010/02/26
        /// <summary>SCM情報自動展開確認</summary>
        public int ScmValue
        {
            get { return this._scm; }
            set { this._scm = value; }
        }
        //<<<2010/02/26

        // 2010/06/15 >>>
        /// <summary>RC連携ディレクトリ</summary>
        public string RCLinkDirectoryValue
        {
            get { return this._rcLinkDirectory; }
            set { this._rcLinkDirectory = value; }
        }
        // 2010/06/15 <<<

        /// <summary>得意先注番の明細展開</summary>
        public int PartySaleSlipValue
        {
            get { return this._partySaleSlipDiv; }
            set { this._partySaleSlipDiv = value; }
        }

        /// <summary>ヘッダフォーカス設定リスト</summary>
        public HeaderFocusConstructionList HeaderFocusConstructionList
        {
            get { return this._headerFocusConstructionList; }
            set { this._headerFocusConstructionList = value; }
        }

        //---2010/07/06---------->>>>>
        /// <summary>ファンクション設定リスト</summary>
        public FunctionConstructionList FunctionConstructionList
        {
            get { return this._functionConstructionList; }
            set { this._functionConstructionList = value; }
        }
        //---2010/07/06----------<<<<<

        //---2010/08/13---------->>>>>
        /// <summary>ファンクション設定リスト</summary>
        public FunctionDetailConstructionList FunctionDetailConstructionList
        {
            get { return this._functionDetailConstructionList; }
            set { this._functionDetailConstructionList = value; }
        }
        //---2010/08/13----------<<<<<

        //>>>2010/08/06
        /// <summary>担当者区分</summary>
        public int EmployeeCdDiv
        {
            get { return this._employeeCdDiv; }
            set { this._employeeCdDiv = value; }
        }
        /// <summary>受注者区分</summary>
        public int FrontEmployeeCdDiv
        {
            get { return this._frontEmployeeCdDiv; }
            set { this._frontEmployeeCdDiv = value; }
        }
        /// <summary>発行者区分</summary>
        public int SalesInputCdDiv
        {
            get { return this._salesInputCdDiv; }
            set { this._salesInputCdDiv = value; }
        }
        /// <summary>担当者</summary>
        public string EmployeeCd
        {
            get { return this._employeeCd; }
            set { this._employeeCd = value; }
        }
        //<<<2010/08/06

        /// <summary>受注者</summary>
        public string FrontEmployeeCd
        {
            get { return this._frontEmployeeCd; }
            set { this._frontEmployeeCd = value; }
        }

        /// <summary>発行者</summary>
        public string SalesInputCd
        {
            get { return this._salesInputCd; }
            set { this._salesInputCd = value; }
        }

        /// <summary>検索画面制御区分</summary>
        public int SearchUICntDivCd
        {
            get { return this._searchUICntDivCd; }
            set { this._searchUICntDivCd = value; }
        }

        /// <summary>エンターキー処理区分</summary>
        public int EnterProcDivCd
        {
            get { return this._enterProcDivCd; }
            set { this._enterProcDivCd = value; }
        }

        /// <summary>品番検索区分</summary>
        public int PartsNoSearchDivCd
        {
            get { return this._partsNoSearchDivCd; }
            set { this._partsNoSearchDivCd = value; }
        }

        /// <summary>品番検索制御区分</summary>
        public string PartsJoinCntDivCd
        {
            get { return this._partsJoinCntDivCd; }
            set { this._partsJoinCntDivCd = value; }
        }

        /// <summary>車両検索後のフォーカス位置</summary>
        public int FocusPositionAfterCarSearchValue
        {
            get { return this._focusPositionAfterCarSearch; }
            set { this._focusPositionAfterCarSearch = value; }
        }
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.15 ADD
        /// <summary>ＢＬガイドモード</summary>
        public int BLGuideMode
        {
            get { return _blGuideMode; }
            set { _blGuideMode = value; }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.15 ADD

        //-------- ADD 連番1002 2011/08/08 ----------------->>>>>
        /// <summary>入力後のカーソル位置</summary>
        public int CursorPos
        {
            get { return _cursorPos; }
            set { _cursorPos = value; }
        }
        //-------- ADD 連番1002 2011/08/08 -----------------<<<<<

        // --- DEL 2012/05/21 ---------->>>>>
        //// --- ADD 2012/04/11 No.594 ---------->>>>>
        ///// <summary>商品検索後のカーソル位置</summary>
        //public int FocusPositionAfterBLCodeSearchValue
        //{
        //    get { return this._focusPositionAfterBLCodeSearch; }
        //    set { this._focusPositionAfterBLCodeSearch = value; }
        //}
        //// --- ADD 2012/04/11 No.594 ----------<<<<<
        // --- DEL 2012/05/21 ----------<<<<<

        // --- ADD 2013/11/05 Y.Wakita ---------->>>>>
        /// <summary>商品検索後のカーソル位置</summary>
        public int FocusPositionAfterBLCodeSearchValue
        {
            get { return this._focusPositionAfterBLCodeSearch; }
            set { this._focusPositionAfterBLCodeSearch = value; }
        }
        // --- ADD 2013/11/05 Y.Wakita ----------<<<<<

        // --- ADD 2014/02/24 Y.Wakita ---------->>>>>
        /// <summary>伝票種別の記憶</summary>
        public int AcptAnOdrStatusMemoryValue
        {
            get { return this._acptAnOdrStatusMemory; }
            set { this._acptAnOdrStatusMemory = value; }
        }
        // --- ADD 2014/02/24 Y.Wakita ----------<<<<<

        // ------ ADD 2021/04/12 陳艶丹 FOR PMKOBETSU-4136-------->>>>>
        /// <summary>得意先ガイド表示</summary>
        public int CustomerGuidDisplayValue
        {
            get { return this._customerGuidDisplay; }
            set { this._customerGuidDisplay = value; }
        }
        // ------ ADD 2021/04/12 陳艶丹 FOR PMKOBETSU-4136--------<<<<<

        // --- ADD 2009/12/23 ---------->>>>>
        /// <summary>出荷数入力最大桁数</summary>
        public int ShipmentMaxCnt
        {
            get { return _shipmentMaxCnt; }
            set { _shipmentMaxCnt = value; }
        }

        /// <summary>受注数入力最大桁数</summary>
        public int AcceptAnOrderMaxCnt
        {
            get { return _acceptAnOrderMaxCnt; }
            set { _acceptAnOrderMaxCnt = value; }
        }

        /// <summary>フッタフォーカス設定リスト</summary>
        public FooterFocusConstructionList FooterFocusConstructionList
        {
            get { return this._footerFocusConstructionList; }
            set { this._footerFocusConstructionList = value; }
        }
        // --- ADD 2009/12/23 ----------<<<<<

        // --- ADD 陳艶丹 2022/04/26 PMKOBETSU-4208 電子帳簿対応--->>>>>
        /// <summary>伝票PDF出力</summary>
        public int OutputMode
        {
            get { return _outputMode; }
            set { _outputMode = value; }
        }

        /// <summary>出力伝票区分売上</summary>
        public int SalesOutputDiv
        {
            get { return _salesOutputDiv; }
            set { _salesOutputDiv = value; }
        }

        /// <summary>出力伝票区分_見積</summary>
        public int EstimateOutputDiv
        {
            get { return _estimateOutputDiv; }
            set { _estimateOutputDiv = value; }
        }

        /// <summary>PDFプリンター</summary>
        public int PdfPrinter
        {
            get { return _pdfPrinter; }
            set { _pdfPrinter = value; }
        }

        /// <summary>PDFプリンターNo</summary>
        public int PdfPrinterNumber
        {
            get { return _pdfPrinterNumber; }
            set { _pdfPrinterNumber = value; }
        }

        /// <summary>PDFプリンター待機時間</summary>
        public int PdfPrinterWait
        {
            get { return _pdfPrinterWait; }
            set { _pdfPrinterWait = value; }
        }
        // --- ADD 陳艶丹 2022/04/26 PMKOBETSU-4208 電子帳簿対応---<<<<<

        //--- ADD 田村顕成 2022/10/05 インボイス残対応 ----->>>>>
        /// <summary>返品・赤伝時備考1使用モード</summary>
        public int ReturnRedNote1Mode
        {
            get { return _returnRedNote1Mode; }
            set { _returnRedNote1Mode = value; }
        }
        public string ReturnRedNote1
        {
            get { return _returnRedNote1; }
            set { _returnRedNote1 = value; }
        }
        /// <summary>返品・赤伝時備考2使用モード</summary>
        public int ReturnRedNote2Mode
        {
            get { return _returnRedNote2Mode; }
            set { _returnRedNote2Mode = value; }
        }
        public string ReturnRedNote2
        {
            get { return _returnRedNote2; }
            set { _returnRedNote2 = value; }
        }
        /// <summary>返品・赤伝時備考3使用モード</summary>
        public int ReturnRedNote3Mode
        {
            get { return _returnRedNote3Mode; }
            set { _returnRedNote3Mode = value; }
        }
        public string ReturnRedNote3
        {
            get { return _returnRedNote3; }
            set { _returnRedNote3 = value; }
        }
        /// <summary>返品・赤伝時備考欄ブランクチェックモード</summary>
        public int ReturnRedBlankCheckMode
        {
            get { return _returnRedBlankCheckMode; }
            set { _returnRedBlankCheckMode = value; }
        }
        //--- ADD 田村顕成 2022/10/05 インボイス残対応 -----<<<<<
        # endregion

        // ===================================================================================== //
        // パブリックメソッド
        // ===================================================================================== //
        # region Public Methods
        /// <summary>
        /// 売上入力用ユーザー設定クラス複製処理
        /// </summary>
        /// <returns>売上入力用ユーザー設定クラス</returns>
        /// <br>Programmer : 連番1002 許雁波</br>
        /// <br>Date       : 2011/08/08</br>
        /// <br>Programmer : 連番4,979 梁森東</br>
        /// <br>Date       : 2011/08/09</br>
        public SalesSlipInputConstruction Clone()
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.15 DEL
            //return new SalesSlipInputConstruction(
            //    this._focusPositionValue,
            //    this._dataInputCountValue,
            //    this._stockGoodsCdValue,
            //    this._accPayDivCdValue,
            //    this._fontSizeValue,
            //    this._clearAfterSave,
            //    this._saveInfoStore,
            //    this._partySaleSlipDiv,
            //    this._headerFocusConstructionList,
            //    this._frontEmployeeCd,
            //    this._salesInputCd,
            //    this._searchUICntDivCd,
            //    this._enterProcDivCd,
            //    this._partsNoSearchDivCd,
            //    this._partsJoinCntDivCd,
            //    this._focusPositionAfterCarSearch);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.15 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.15 ADD
            return new SalesSlipInputConstruction(
                this._focusPositionValue,
                this._dataInputCountValue,
                this._stockGoodsCdValue,
                this._accPayDivCdValue,
                this._fontSizeValue,
                this._colorsValue,// ADD 2011/08/09
                this._clearAfterSave,
                this._saveInfoStore,
                this._partySaleSlipDiv,
                this._headerFocusConstructionList,
                //>>>2010/08/06
                this._employeeCdDiv,
                this._frontEmployeeCdDiv,
                this._salesInputCdDiv,
                this._employeeCd,
                //<<<2010/08/06
                this._frontEmployeeCd,
                this._salesInputCd,
                this._searchUICntDivCd,
                this._enterProcDivCd,
                this._partsNoSearchDivCd,
                this._partsJoinCntDivCd,
                this._focusPositionAfterCarSearch,
                this._blGuideMode ,
                this._cursorPos,  //ADD 連番1002 2011/08/08
                this._shipmentMaxCnt,//ADD 2009/12/23
                this._acceptAnOrderMaxCnt,//ADD 2009/12/23
                //this._footerFocusConstructionList);//ADD 2009/12/23
                this._footerFocusConstructionList, //ADD 2009/12/23
                // 2010/06/15 >>>
                this._rcLinkDirectory,
                // 2010/06/15 <<<
                this._customerGuidDisplay, // ADD 2021/04/12 陳艶丹 FOR PMKOBETSU-4136
                //----- UPD　2018/09/04 譚洪　『設定』画面で画面制御の変更------->>>>>
                //>>>2010/02/26
                //this._scm);
                //<<<2010/02/26
                this._scm,
                // ------ UPD 2021/03/16 陳艶丹 FOR PMKOBETSU-4133-------->>>>
                //this._inputMonthValue);
                this._inputMonthValue,
                // --- UPD 陳艶丹 2022/04/26 PMKOBETSU-4208 電子帳簿対応 ----->>>>>
                //this._saveUnitCostCheckDivValue);
                this._saveUnitCostCheckDivValue,
                this._outputMode,
                this._salesOutputDiv,
                this._estimateOutputDiv,
                this._pdfPrinter,
                this._pdfPrinterNumber,
                this._pdfPrinterWait);
                // --- UPD 陳艶丹 2022/04/26 PMKOBETSU-4208 電子帳簿対応 -----<<<<<
                // ------ UPD 2021/03/16 陳艶丹 FOR PMKOBETSU-4133--------<<<<
                //----- UPD　2018/09/04 譚洪　『設定』画面で画面制御の変更-------<<<<<

            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.15 ADD
        }
        # endregion
    }

    /// <summary>
    /// 売上入力用設定アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上入力のユーザー設定情報を管理するクラスです。</br>
    /// <br>Programmer : 20056 對馬 大輔</br>
    /// <br>Date       : 2007.09.10</br>
    /// <br></br>
    /// <br>UpDate</br>
    /// <br>2009.06.17 21024 佐々木 健 MANTIS[0013490] 初期導入時、ヘッダー項目でEnter押下時にグリッドにフォーカス移動する不具合の修正</br>
    /// <br>Update Note: 2021/09/10 呉元嘯</br>
    /// <br>管理番号   : 11770032-00</br>
    /// <br>           : PMKOBETSU-4172 原単価チェックと税率ログの制御ファイルの対応</br> 
    /// <br>Update Note: 2022/10/05 田村顕成</br>
    /// <br>管理番号   : 11870141-00</br>
    /// <br>           : インボイス残対応</br> 
    /// </remarks>
    public class SalesSlipInputConstructionAcs
    {
        // ===================================================================================== //
        // 外部に提供する定数群
        // ===================================================================================== //
        # region Public Const
        /// <summary>初期フォーカス位置（拠点）</summary>
        public const int FocusPosition_SectionCode = 0;

        /// <summary>初期フォーカス位置（得意先）</summary>
        public const int FocusPosition_CustomerCode = 1;

        /// <summary>初期フォーカス位置（担当者）</summary>
        public const int FocusPosition_SalesEmployeeCd = 2;

        /// <summary>初期フォーカス位置（受注者）</summary>
        public const int FocusPosition_FrontEmployeeCd = 3;

        /// <summary>初期フォーカス位置（発行者）</summary>
        public const int FocusPosition_SalesInputCd = 4;

        /// <summary>初期フォーカス位置（売上伝票番号）</summary>
        public const int FocusPosition_SalesSlipNum = 5;

        /// <summary>初期フォーカス位置（伝票種別）</summary>
        public const int FocusPosition_AcptAnOdrStatus = 6;


        /// <summary>保存後初期化処理（しない）</summary>
        public const int ClearAfterSave_OFF = 0;

        /// <summary>保存後初期化処理（する）</summary>
        public const int ClearAfterSave_ON = 1;

        /// <summary>保存時情報の記憶（しない）</summary>
        public const int SaveInfoStore_OFF = 0;

        /// <summary>保存時情報の記憶（する）</summary>
        public const int SaveInfoStore_ON = 1;

        /// <summary>明細部開始位置</summary>
        public const string ct_StartPosittion = "StartPosittion";

        /// <summary>明細部終了位置</summary>
        public const string ct_EndPosittion = "EndPosittion";

        /// <summary>得意先注番明細展開</summary>
        public enum PartySaleSlipDiv : int
        {
            /// <summary>する</summary>
            On = 1,
            /// <summary>しない</summary>
            Off = 0,
        }

        /// <summary>車両検索後のフォーカス位置（しない）</summary>
        public const int FocusPositionAfterCarSearch_Default = 0;
        /// <summary>車両検索後のフォーカス位置（年式）</summary>
        public const int FocusPositionAfterCarSearch_FirstEntryDate = 1;
        /// <summary>車両検索後のフォーカス位置（車台番号）</summary>
        public const int FocusPositionAfterCarSearch_ProduceFrameNo = 2;
        /// <summary>車両検索後のフォーカス位置（明細）</summary>
        public const int FocusPositionAfterCarSearch_Detail = 3;
        # endregion

        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        # region Private Members
        private SalesSlipInputConstruction _salesSlipInputConstruction;
        private static SalesSlipInputConstructionAcs _stockSlipInputConstructionAcs;
        private const string XML_FILE_NAME = "MAHNB01012A_Construction.XML";
        private Dictionary<string, EnterMoveValue> _enterMoveTable;
        private Dictionary<string, EnterMoveValue> _enterMoveTableInit;
        private Hashtable _nameTable;
        private ArrayList _effectiveList;
        private Dictionary<string, Control> _headerItemsDictionary;
        private Dictionary<string, Control> _functionItemsDictionary;// ADD 2010/07/06
        private Dictionary<string, Control> _functionDetailItemsDictionary;// ADD 2010/08/13        
        private Dictionary<string, Control> _footerItemsDictionary;// ADD 2009/12/23
        private bool _isLocalDBRead;
        private string _enterpriseCode;
        private ArrayList _endKeyNameList;
        private ArrayList _endKeyNameListInit;
        // --- ADD 2021/09/10 呉元嘯 PMKOBETSU-4172 原単価チェックと税率ログの制御ファイルの対応--->>>>>
        // 原単価チェック設定XMLファイル
        private const string XML_SaveUnitCostCheck = "MAHNB01013A_SaveUnitCostCheck.xml";
        // --- ADD 2021/09/10 呉元嘯 PMKOBETSU-4172 原単価チェックと税率ログの制御ファイルの対応---<<<<<
        // --- ADD 陳艶丹 2022/04/26 PMKOBETSU-4208 電子帳簿対応 --->>>>>
        // 電帳出力設定XMLファイル
        private const string XML_PDFOUTPUTSETTINGS = "MAHNB01001U_PDFOutputSettings.xml";
        private const string PRINTER_NORMAL = "Microsoft Print to PDF";
        private const string PRINTER_CUBE = "CubePDF";
        // --- ADD 陳艶丹 2022/04/26 PMKOBETSU-4208 電子帳簿対応 ---<<<<<
        /// <summary>返品･赤伝制御設定XMLファイル</summary>
        private const string XML_RETURNREDSETTINGS = "MAHNB01001U_ReturnRedSetting.xml";
        /// <summary>返品･赤伝制御 備考欄使用モード</summary>
        private const int ReturnRedNote_BLANK = 0;//空白
        private const int ReturnRedNote_SLIPNUM = 1;//取引日付＋元黒伝票番号
        private const int ReturnRedNote_ORIGINAL = 2;//元黒伝票番号
        private const int ReturnRedNote_OPTIONAL = 3;//任意
        private string _returnRedNote1 = string.Empty;
        private string _returnRedNote2 = string.Empty;
        private string _returnRedNote3 = string.Empty;
        /// <summary>返品･赤伝制御 備考欄空白チェックモード</summary>
        private const int ReturnRedBlankCheck_OFF = 0;//チェック無し
        private const int ReturnRedBlankCheck_ON = 1;//チェックあり
        //--- ADD 田村顕成 2022/10/05 インボイス残対応 -----<<<<<
        # endregion

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region Constructors
        /// <summary>
        /// 売上入力用ユーザー設定クラスアクセスクラス（Singletonデザインパターンを採用している為、privateとする）
        /// </summary>
        private SalesSlipInputConstructionAcs()
        {
            _salesSlipInputConstruction = new SalesSlipInputConstruction();
            _enterMoveTable = new Dictionary<string, EnterMoveValue>();
            _enterMoveTableInit = new Dictionary<string, EnterMoveValue>();
            _nameTable = new Hashtable();
            _effectiveList = new ArrayList();
            _headerItemsDictionary = new Dictionary<string, Control>();
            _functionItemsDictionary = new Dictionary<string, Control>();// ADD 2010/07/06
            _functionDetailItemsDictionary = new Dictionary<string, Control>();// ADD 2010/07/06
            _endKeyNameList = new ArrayList();
            _endKeyNameListInit = new ArrayList();
            _footerItemsDictionary = new Dictionary<string, Control>();// ADD 2009/12/23

            this.Deserialize();
            //----- ADD 陳艶丹 2022/04/26 PMKOBETSU-4208 電子帳簿対応------->>>>>
            // 電帳設定ファイル取得
            GetEBooksSettings();
            //----- ADD 陳艶丹 2022/04/26 PMKOBETSU-4208 電子帳簿対応-------<<<<<
            //--- ADD 田村顕成 2022/10/05 インボイス残対応 ----->>>>>
            // 返品･赤伝制御設定ファイル取得
            GetReturnRedSettings();
            //--- ADD 田村顕成 2022/10/05 インボイス残対応 -----<<<<<
        }

        //----- ADD 陳艶丹 2022/04/26 PMKOBETSU-4208 電子帳簿対応------->>>>>
        /// <summary>
        /// 電帳設定ファイル取得
        /// </summary>
        /// <remarks>
        /// <br>Note         : 電帳設定ファイル取得</br>
        /// <br>Programmer   : 陳艶丹</br>
        /// <br>Date         : 2022/04/26</br>
        /// </remarks>
        private void GetEBooksSettings()
        {
            try
            {
                eBooksOutputSetting eBooksOutputSetting = new eBooksOutputSetting();
                if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_PDFOUTPUTSETTINGS)))
                {
                    // 電帳設定を取得する
                    eBooksOutputSetting = UserSettingController.DeserializeUserSetting<eBooksOutputSetting>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_PDFOUTPUTSETTINGS));

                    // pdf出力区分
                    _salesSlipInputConstruction.OutputMode = eBooksOutputSetting.OutputMode;
                    // 出力伝票区分
                    GetOutputSlipType(eBooksOutputSetting.OutputSlipType);
                    // pdfプリンター
                    _salesSlipInputConstruction.PdfPrinter = eBooksOutputSetting.PDFPrinter;
                    // pdfプリンター番号
                    _salesSlipInputConstruction.PdfPrinterNumber = GetPrinterNumber(_salesSlipInputConstruction.PdfPrinter);
                    // pdfプリンター待機時間
                    _salesSlipInputConstruction.PdfPrinterWait = eBooksOutputSetting.PDFPrinterWait;
                }
                else
                {
                    // デフォルト値：Windows標準のpdfプリンター番号
                    _salesSlipInputConstruction.PdfPrinterNumber = GetPrinterNumber(0);
                }
            }
            catch
            {
                // デフォルト値：Windows標準のpdfプリンター番号
                _salesSlipInputConstruction.PdfPrinterNumber = GetPrinterNumber(0);
            }
        }
        /// <summary>
        /// pdfプリンター番号取得
        /// <param name="pDFPrinter">pdfプリンター</param>
        /// </summary>
        /// <returns>pdfプリンター番号</returns>
        /// <remarks>
        /// <br>Note         : pdfプリンター番号取得</br>
        /// <br>Programmer   : 陳艶丹</br>
        /// <br>Date         : 2022/04/26</br>
        /// </remarks>
        public int GetPrinterNumber(int pDFPrinter)
        {
            List<PrtManage> prtManageList = new List<PrtManage>();
            int printerNumber = 0;
            ArrayList retList = SearchAllPrtManage();
            foreach (PrtManage prtManage in retList)
            {
                if (prtManage.LogicalDeleteCode == 0)
                {
                    // Windows標準
                    if (pDFPrinter == 0 &&
                        prtManage.PrinterName.StartsWith(PRINTER_NORMAL))
                    {
                        printerNumber = Convert.ToInt32(prtManage.PrinterMngNo);
                    }
                    // その他
                    if (pDFPrinter == 1 &&
                        prtManage.PrinterName.StartsWith(PRINTER_CUBE))
                    {
                        printerNumber = Convert.ToInt32(prtManage.PrinterMngNo);
                    }
                }
            }
            return printerNumber;
        }
        /// <summary>
        /// XMLからプリンタ設定クラスへデシリアライズします
        /// </summary>
        /// <returns>プリンタ設定配列</returns>
        /// <remarks>
        /// <br>Note         : 出力伝票区分取得</br>
        /// <br>Programmer   : 陳艶丹</br>
        /// <br>Date         : 2022/04/26</br>
        /// </remarks>
        private PrtManage[] HybridXmlDeserialize()
        {
            string filePath = ConstantManagement_ClientDirectory.LocalApplicationData_AppSettingData + "\\PrtManage.xml";
            string fileName = "PrtManage.xml";
            //新パスにファイルがあるかチェック
            if (System.IO.File.Exists(filePath))
            {
                //新ファイルがあれば新ロジックを使用
                return (PrtManage[])UserSettingController.DeserializeUserSetting(filePath, typeof(PrtManage[]));
            }
            else
            {
                //新ファイルがないときは旧ロジック
                return (PrtManage[])XmlByteSerializer.Deserialize(fileName, typeof(PrtManage[]));
            }
        }

        /// <summary>
        /// プリンタ管理検索処理
        /// </summary>
        /// <returns>プリンタ設定配列</returns>
        /// <remarks>
        /// <br>Note         : 出力伝票区分取得</br>
        /// <br>Programmer   : 陳艶丹</br>
        /// <br>Date         : 2022/04/26</br>
        /// </remarks>
        private ArrayList SearchAllPrtManage()
        {

            ArrayList retList = new ArrayList();
            try
            {
                // ＸＭＬの読み込み
                PrtManage[] prtManages = HybridXmlDeserialize();

                // 全件リード
                for (int ix = 0; ix < prtManages.Length; ix++)
                {
                    // 読込結果コレクションに追加
                    if (checkTarGetData(prtManages[ix], ConstantManagement.LogicalMode.GetData01)) retList.Add(prtManages[ix]);
                }
            }
            catch (Exception)
            {
                // なし
            }
            return retList;
        }

        /// <summary>
        /// 対象データチェック
        /// </summary>
        /// <param name="prtManage">対象データ</param>
        /// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:全データ)</param>
        /// <returns>チェック結果（true:OK false:NG）</returns>
        /// <remarks>
        /// <br>Note         : 対象データチェック</br>
        /// <br>Programmer   : 陳艶丹</br>
        /// <br>Date         : 2022/04/26</br>
        /// </remarks>
        private bool checkTarGetData(PrtManage prtManage, ConstantManagement.LogicalMode logicalMode)
        {
            if (logicalMode == ConstantManagement.LogicalMode.GetData0)
            {
                if (prtManage.LogicalDeleteCode != 0) return false;
            }
            else if (logicalMode == ConstantManagement.LogicalMode.GetData1)
            {
                if (prtManage.LogicalDeleteCode != 1) return false;
            }

            return true;
        }
        /// <summary>
        /// 出力伝票区分取得
        /// <param name="outputSlipType">出力伝票区分</param>
        /// </summary>
        /// <remarks>
        /// <br>Note         : 出力伝票区分取得</br>
        /// <br>Programmer   : 陳艶丹</br>
        /// <br>Date         : 2022/04/26</br>
        /// </remarks>
        private void GetOutputSlipType(int outputSlipType)
        {
            // 出力伝票区分
            switch (outputSlipType)
			{
				case 0://両方選択なし
					{
						// 売上出力区分
               　　　　 _salesSlipInputConstruction.SalesOutputDiv = 0;
                        // 見積出力区分
                        _salesSlipInputConstruction.EstimateOutputDiv = 0;
                        break;
					}
				case 1://売上
					{
						// 売上出力区分
               　　　　 _salesSlipInputConstruction.SalesOutputDiv = 1;
                        // 見積出力区分
                        _salesSlipInputConstruction.EstimateOutputDiv = 0;
                        break;
					}
                case 2://見積
				{
				    // 売上出力区分
       　　　　     _salesSlipInputConstruction.SalesOutputDiv = 0;
                    // 見積出力区分
                    _salesSlipInputConstruction.EstimateOutputDiv = 1;
					break;
				}
                case 3://両方選択あり
				{
				    // 売上出力区分
       　　　　     _salesSlipInputConstruction.SalesOutputDiv = 1;
                    // 見積出力区分
                    _salesSlipInputConstruction.EstimateOutputDiv = 1;
					break;
				}
			}
        }

        /// <summary>
        /// 出力伝票区分取得
        /// <param name="salesOutputDiv">売上伝票区分</param>
        /// <param name="estimateOutputDiv">見積伝票区分</param>
        /// <param name="eBooksOutputSetting">PDFプリンタ項目設定情報</param>
        /// </summary>
        /// <remarks>
        /// <br>Note         : 出力伝票区分取得</br>
        /// <br>Programmer   : 陳艶丹</br>
        /// <br>Date         : 2022/04/26</br>
        /// </remarks>
        private void SetOutputSlipType(int salesOutputDiv, int estimateOutputDiv, ref eBooksOutputSetting eBooksOutputSetting)
        {
            if(salesOutputDiv == 0 && estimateOutputDiv == 0)
            {
                //0：両方選択なし
                eBooksOutputSetting.OutputSlipType = 0;
            }
            else if(salesOutputDiv == 1 && estimateOutputDiv == 0)
            {
                //1：売上
                eBooksOutputSetting.OutputSlipType = 1;
            }
            else if(salesOutputDiv == 0 && estimateOutputDiv == 1)
            {
                //2：見積
                eBooksOutputSetting.OutputSlipType = 2;
            }
            else if(salesOutputDiv == 1 && estimateOutputDiv == 1)
            {
                //3：両方選択あり
                eBooksOutputSetting.OutputSlipType = 3;
            }
        }
        //----- ADD 陳艶丹 2022/04/26 PMKOBETSU-4208 電子帳簿対応-------<<<<<

        //--- ADD 田村顕成 2022/10/05 インボイス残対応 ----->>>>>
        /// <summary>
        /// 返品･赤伝制御設定ファイル取得
        /// </summary>
        /// <remarks>
        /// <br>Note         : 返品･赤伝制御設定ファイル取得</br>
        /// <br>Programmer   : 田村顕成</br>
        /// <br>Date         : 2022/10/05</br>
        /// </remarks>
        public void GetReturnRedSettings()
        {
            try
            {
                ReturnRedControlSetting returnRedSetting = new ReturnRedControlSetting();
                if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_RETURNREDSETTINGS)))
                {
                    // 返品･赤伝制御設定を取得する
                    returnRedSetting = UserSettingController.DeserializeUserSetting<ReturnRedControlSetting>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_RETURNREDSETTINGS));

                    // 伝票備考1設定
                    _salesSlipInputConstruction.ReturnRedNote1Mode = returnRedSetting.ReturnRedNote1Mode;
                    _salesSlipInputConstruction.ReturnRedNote1 = returnRedSetting.ReturnRedNote1;
                    // 伝票備考2設定
                    _salesSlipInputConstruction.ReturnRedNote2Mode = returnRedSetting.ReturnRedNote2Mode;
                    _salesSlipInputConstruction.ReturnRedNote2 = returnRedSetting.ReturnRedNote2;
                    // 伝票備考3設定
                    _salesSlipInputConstruction.ReturnRedNote3Mode = returnRedSetting.ReturnRedNote3Mode;
                    _salesSlipInputConstruction.ReturnRedNote3 = returnRedSetting.ReturnRedNote3;
                    // 備考空欄チェック設定
                    _salesSlipInputConstruction.ReturnRedBlankCheckMode = returnRedSetting.ReturnRedBlankCheckMode;
                }
                else
                {
                    _salesSlipInputConstruction.ReturnRedNote1Mode = ReturnRedNote_ORIGINAL;
                    _salesSlipInputConstruction.ReturnRedNote1 = string.Empty;
                    _salesSlipInputConstruction.ReturnRedNote2Mode = ReturnRedNote_ORIGINAL;
                    _salesSlipInputConstruction.ReturnRedNote2 = string.Empty;
                    _salesSlipInputConstruction.ReturnRedNote3Mode = ReturnRedNote_ORIGINAL;
                    _salesSlipInputConstruction.ReturnRedNote3 = string.Empty;
                    _salesSlipInputConstruction.ReturnRedBlankCheckMode = ReturnRedBlankCheck_OFF;
                }
            }
            catch
            {
                _salesSlipInputConstruction.ReturnRedNote1Mode = ReturnRedNote_ORIGINAL;
                _salesSlipInputConstruction.ReturnRedNote1 = string.Empty;
                _salesSlipInputConstruction.ReturnRedNote2Mode = ReturnRedNote_ORIGINAL;
                _salesSlipInputConstruction.ReturnRedNote2 = string.Empty;
                _salesSlipInputConstruction.ReturnRedNote3Mode = ReturnRedNote_ORIGINAL;
                _salesSlipInputConstruction.ReturnRedNote3 = string.Empty;
                _salesSlipInputConstruction.ReturnRedBlankCheckMode = ReturnRedBlankCheck_OFF;
            }
        }
        //--- ADD 田村顕成 2022/10/05 インボイス残対応 -----<<<<<

        /// <summary>
        /// 売上入力用ユーザー設定アクセスクラス インスタンス取得処理
        /// </summary>
        /// <returns>売上入力用ユーザー設定アクセスクラス インスタンス</returns>
        public static SalesSlipInputConstructionAcs GetInstance()
        {
            if (_stockSlipInputConstructionAcs == null)
            {
                _stockSlipInputConstructionAcs = new SalesSlipInputConstructionAcs();
            }

            return _stockSlipInputConstructionAcs;
        }
        # endregion

        // ===================================================================================== //
        // イベント
        // ===================================================================================== //
        # region Event
        /// <summary>データ変更後発生イベント</summary>
        public event EventHandler DataChanged;
        # endregion

        // ===================================================================================== //
        // プロパティ
        // ===================================================================================== //
        # region Properties
        /// <summary>
        /// 売上入力用ユーザー設定クラス
        /// </summary>
        public SalesSlipInputConstruction SalesInputConstruction
        {
            get
            {
                if (_salesSlipInputConstruction == null)
                {
                    _salesSlipInputConstruction = new SalesSlipInputConstruction();
                }
                return _salesSlipInputConstruction.Clone();
            }
        }

        /// <summary>初期フォーカス位置</summary>
        public int FocusPositionValue
        {
            get
            {
                if (_salesSlipInputConstruction == null)
                {
                    _salesSlipInputConstruction = new SalesSlipInputConstruction();
                }
                return _salesSlipInputConstruction.FocusPositionValue;
            }
            set
            {
                if (_salesSlipInputConstruction == null)
                {
                    _salesSlipInputConstruction = new SalesSlipInputConstruction();
                }
                _salesSlipInputConstruction.FocusPositionValue = value;
            }
        }

        /// <summary>データ入力行数</summary>
        public int DataInputCountValue
        {
            get
            {
                if (_salesSlipInputConstruction == null)
                {
                    _salesSlipInputConstruction = new SalesSlipInputConstruction();
                }
                return _salesSlipInputConstruction.DataInputCountValue;
            }
            set
            {
                if (_salesSlipInputConstruction == null)
                {
                    _salesSlipInputConstruction = new SalesSlipInputConstruction();
                }
                _salesSlipInputConstruction.DataInputCountValue = value;
            }
        }

        //----- ADD　2018/09/04 譚洪　『設定』画面で画面制御の変更------->>>>>
        /// <summary>データ入力行数</summary>
        public int InputMonthValue
        {
            get
            {
                if (_salesSlipInputConstruction == null)
                {
                    _salesSlipInputConstruction = new SalesSlipInputConstruction();
                }
                return _salesSlipInputConstruction.InputMonthValue;
            }
            set
            {
                if (_salesSlipInputConstruction == null)
                {
                    _salesSlipInputConstruction = new SalesSlipInputConstruction();
                }
                _salesSlipInputConstruction.InputMonthValue = value;
            }
        }
        //----- ADD　2018/09/04 譚洪　『設定』画面で画面制御の変更-------<<<<<

        // ------ ADD 2021/03/16 陳艶丹 FOR PMKOBETSU-4133-------->>>>
        /// <summary>保存時原価チェック区分</summary>
        public int SaveUnitCostCheckDivValue
        {
            get
            {
                if (_salesSlipInputConstruction == null)
                {
                    _salesSlipInputConstruction = new SalesSlipInputConstruction();
                }
                return _salesSlipInputConstruction.SaveUnitCostCheckDivValue;
            }
            set
            {
                if (_salesSlipInputConstruction == null)
                {
                    _salesSlipInputConstruction = new SalesSlipInputConstruction();
                }
                _salesSlipInputConstruction.SaveUnitCostCheckDivValue = value;
            }
        }
        // ------ ADD 2021/03/16 陳艶丹 FOR PMKOBETSU-4133--------<<<<<

        /// <summary>商品区分</summary>
        public int StockGoodsCdValue
        {
            get
            {
                if (_salesSlipInputConstruction == null)
                {
                    _salesSlipInputConstruction = new SalesSlipInputConstruction();
                }
                return _salesSlipInputConstruction.StockGoodsCdValue;
            }
            set
            {
                if (_salesSlipInputConstruction == null)
                {
                    _salesSlipInputConstruction = new SalesSlipInputConstruction();
                }
                _salesSlipInputConstruction.StockGoodsCdValue = value;
            }
        }

        /// <summary>買掛区分</summary>
        public int AccPayDivCdValue
        {
            get
            {
                if (_salesSlipInputConstruction == null)
                {
                    _salesSlipInputConstruction = new SalesSlipInputConstruction();
                }
                return _salesSlipInputConstruction.AccPayDivCdValue;
            }
            set
            {
                if (_salesSlipInputConstruction == null)
                {
                    _salesSlipInputConstruction = new SalesSlipInputConstruction();
                }
                _salesSlipInputConstruction.AccPayDivCdValue = value;
            }
        }

        /// <summary>フォントサイズ</summary>
        public int FontSizeValue
        {
            get
            {
                if (_salesSlipInputConstruction == null)
                {
                    _salesSlipInputConstruction = new SalesSlipInputConstruction();
                }
                return _salesSlipInputConstruction.FontSizeValue;
            }
            set
            {
                if (_salesSlipInputConstruction == null)
                {
                    _salesSlipInputConstruction = new SalesSlipInputConstruction();
                }
                _salesSlipInputConstruction.FontSizeValue = value;
            }
        }

        // ADD 2011/08/09--------------------->>>>>>>>>>>>>>>>>
        /// <summary>選択色</summary>
        public int ColorsValue
        {
            get
            {
                if (_salesSlipInputConstruction == null)
                {
                    _salesSlipInputConstruction = new SalesSlipInputConstruction();
                }
                return _salesSlipInputConstruction.ColorsValue;
            }
            set
            {
                if (_salesSlipInputConstruction == null)
                {
                    _salesSlipInputConstruction = new SalesSlipInputConstruction();
                }
                _salesSlipInputConstruction.ColorsValue = value;
            }
        }
        // ADD 2011/08/09--------------------<<<<<<<<<<<<<<<<

        /// <summary>保存後初期化処理</summary>
        public int ClearAfterSaveValue
        {
            get
            {
                if (_salesSlipInputConstruction == null)
                {
                    _salesSlipInputConstruction = new SalesSlipInputConstruction();
                }
                return _salesSlipInputConstruction.ClearAfterSave;
            }
            set
            {
                if (_salesSlipInputConstruction == null)
                {
                    _salesSlipInputConstruction = new SalesSlipInputConstruction();
                }
                _salesSlipInputConstruction.ClearAfterSave = value;
            }
        }

        // ---------- ADD 2010/01/27 ---------->>>>>>>>>>
        /// <summary>明細ボタン表示</summary>
        public int UltraOptionSetValue
        {
            get
            {
                if (_salesSlipInputConstruction == null)
                {
                    _salesSlipInputConstruction = new SalesSlipInputConstruction();
                }
                return _salesSlipInputConstruction.UltraOptionSet;
            }
            set
            {
                if (_salesSlipInputConstruction == null)
                {
                    _salesSlipInputConstruction = new SalesSlipInputConstruction();
                }
                _salesSlipInputConstruction.UltraOptionSet = value;
            }
        }
        // ---------- ADD 2010/01/27 ----------<<<<<<<<<<

        /// <summary>保存時情報記憶</summary>
        public int SaveInfoStoreValue
        {
            get
            {
                if (_salesSlipInputConstruction == null)
                {
                    _salesSlipInputConstruction = new SalesSlipInputConstruction();
                }
                return _salesSlipInputConstruction.SaveInfoStoreValue;
            }
            set
            {
                if (_salesSlipInputConstruction == null)
                {
                    _salesSlipInputConstruction = new SalesSlipInputConstruction();
                }
                _salesSlipInputConstruction.SaveInfoStoreValue = value;
            }
        }

        /// <summary>得意先注番の明細展開</summary>
        public int PartySaleSlipValue
        {
            get
            {
                if (_salesSlipInputConstruction == null)
                {
                    _salesSlipInputConstruction = new SalesSlipInputConstruction();
                }
                return _salesSlipInputConstruction.PartySaleSlipValue;
            }
            set
            {
                if (_salesSlipInputConstruction == null)
                {
                    _salesSlipInputConstruction = new SalesSlipInputConstruction();
                }
                _salesSlipInputConstruction.PartySaleSlipValue = value;
            }
        }

        /// <summary>ヘッダフォーカス設定リスト</summary>
        public HeaderFocusConstructionList HeaderFocusConstructionListValue
        {
            get
            {
                if (_salesSlipInputConstruction == null)
                {
                    _salesSlipInputConstruction = new SalesSlipInputConstruction();
                }
                // 2009.06.17 Add >>>
                // フォーカスのリストが空の場合は、ヘッダー項目ディクショナリからセット
                if (_salesSlipInputConstruction.HeaderFocusConstructionList.headerFocusConstruction.Count == 0)
                {
                    SettingHeaderFocusConstructionListFromDictionary(this.HeaderItemsDictionary, out _salesSlipInputConstruction.HeaderFocusConstructionList.headerFocusConstruction);
                }
                // 2009.06.17 Add <<<
                return _salesSlipInputConstruction.HeaderFocusConstructionList;
            }
            set
            {
                if (_salesSlipInputConstruction == null)
                {
                    _salesSlipInputConstruction = new SalesSlipInputConstruction();
                }
                _salesSlipInputConstruction.HeaderFocusConstructionList = value;
            }
        }

        // --- ADD 2010/07/06 ---------->>>>>
        /// <summary>ヘッダフォーカス設定リスト</summary>
        public FunctionConstructionList FunctionConstructionListValue
        {
            get
            {
                if (_salesSlipInputConstruction == null)
                {
                    _salesSlipInputConstruction = new SalesSlipInputConstruction();
                }
                // フォーカスのリストが空の場合は、ヘッダー項目ディクショナリからセット
                if (_salesSlipInputConstruction.FunctionConstructionList.functionConstruction.Count == 0)
                {
                    SettingFunctionConstructionListFromDictionary(this.FunctionItemsDictionary, out _salesSlipInputConstruction.FunctionConstructionList.functionConstruction);
                }

                return _salesSlipInputConstruction.FunctionConstructionList;
            }
            set
            {
                if (_salesSlipInputConstruction == null)
                {
                    _salesSlipInputConstruction = new SalesSlipInputConstruction();
                }
                _salesSlipInputConstruction.FunctionConstructionList = value;
            }
        }
        // --- ADD 2010/07/06 ----------<<<<<

        // --- ADD 2010/08/13 ---------->>>>>
        /// <summary>ヘッダフォーカス設定リスト</summary>
        public FunctionDetailConstructionList FunctionDetailConstructionListValue
        {
            get
            {
                if (_salesSlipInputConstruction == null)
                {
                    _salesSlipInputConstruction = new SalesSlipInputConstruction();
                }
                // フォーカスのリストが空の場合は、ヘッダー項目ディクショナリからセット
                if (_salesSlipInputConstruction.FunctionDetailConstructionList.functionDetailConstruction.Count == 0)
                {
                    SettingFunctionDetailConstructionListFromDictionary(this.FunctionDetailItemsDictionary, out _salesSlipInputConstruction.FunctionDetailConstructionList.functionDetailConstruction);
                }

                return _salesSlipInputConstruction.FunctionDetailConstructionList;
            }
            set
            {
                if (_salesSlipInputConstruction == null)
                {
                    _salesSlipInputConstruction = new SalesSlipInputConstruction();
                }
                _salesSlipInputConstruction.FunctionDetailConstructionList = value;
            }
        }
        // --- ADD 2010/08/13 ----------<<<<<

        // --- ADD 2009/12/23 ---------->>>>>
        /// <summary>フッタフォーカス設定リスト</summary>
        public FooterFocusConstructionList FooterFocusConstructionListValue
        {
            get
            {
                if (_salesSlipInputConstruction == null)
                {
                    _salesSlipInputConstruction = new SalesSlipInputConstruction();
                }

                // フォーカスのリストが空の場合は、フッター項目ディクショナリからセット
                if (_salesSlipInputConstruction.FooterFocusConstructionList.footerFocusConstruction.Count == 0)
                {
                    SettingFooterFocusConstructionListFromDictionary(this.FooterItemsDictionary, out _salesSlipInputConstruction.FooterFocusConstructionList.footerFocusConstruction);
                }

                return _salesSlipInputConstruction.FooterFocusConstructionList;
            }
            set
            {
                if (_salesSlipInputConstruction == null)
                {
                    _salesSlipInputConstruction = new SalesSlipInputConstruction();
                }
                _salesSlipInputConstruction.FooterFocusConstructionList = value;
            }
        }
        // --- ADD 2009/12/23 ----------<<<<<

        //>>>2010/08/06
        /// <summary>担当者区分</summary>
        public int EmployeeCdDivValue
        {
            get
            {
                if (_salesSlipInputConstruction == null)
                {
                    _salesSlipInputConstruction = new SalesSlipInputConstruction();
                }
                return _salesSlipInputConstruction.EmployeeCdDiv;
            }
            set
            {
                if (_salesSlipInputConstruction == null)
                {
                    _salesSlipInputConstruction = new SalesSlipInputConstruction();
                }
                _salesSlipInputConstruction.EmployeeCdDiv = value;
            }
        }

        /// <summary>受注者区分</summary>
        public int FrontEmployeeCdDivValue
        {
            get
            {
                if (_salesSlipInputConstruction == null)
                {
                    _salesSlipInputConstruction = new SalesSlipInputConstruction();
                }
                return _salesSlipInputConstruction.FrontEmployeeCdDiv;
            }
            set
            {
                if (_salesSlipInputConstruction == null)
                {
                    _salesSlipInputConstruction = new SalesSlipInputConstruction();
                }
                _salesSlipInputConstruction.FrontEmployeeCdDiv = value;
            }
        }

        /// <summary>発行者区分</summary>
        public int SalesInputCdDivValue
        {
            get
            {
                if (_salesSlipInputConstruction == null)
                {
                    _salesSlipInputConstruction = new SalesSlipInputConstruction();
                }
                return _salesSlipInputConstruction.SalesInputCdDiv;
            }
            set
            {
                if (_salesSlipInputConstruction == null)
                {
                    _salesSlipInputConstruction = new SalesSlipInputConstruction();
                }
                _salesSlipInputConstruction.SalesInputCdDiv = value;
            }
        }

        /// <summary>担当者</summary>
        public string EmployeeCdValue
        {
            get
            {
                if (_salesSlipInputConstruction == null)
                {
                    _salesSlipInputConstruction = new SalesSlipInputConstruction();
                }
                return _salesSlipInputConstruction.EmployeeCd;
            }
            set
            {
                if (_salesSlipInputConstruction == null)
                {
                    _salesSlipInputConstruction = new SalesSlipInputConstruction();
                }
                _salesSlipInputConstruction.EmployeeCd = value;
            }
        }
        //<<<2010/08/06

        /// <summary>受注者</summary>
        public string FrontEmployeeCdValue
        {
            get
            {
                if (_salesSlipInputConstruction == null)
                {
                    _salesSlipInputConstruction = new SalesSlipInputConstruction();
                }
                return _salesSlipInputConstruction.FrontEmployeeCd;
            }
            set
            {
                if (_salesSlipInputConstruction == null)
                {
                    _salesSlipInputConstruction = new SalesSlipInputConstruction();
                }
                _salesSlipInputConstruction.FrontEmployeeCd = value;
            }
        }

        /// <summary>発行者</summary>
        public string SalesInputCdValue
        {
            get
            {
                if (_salesSlipInputConstruction == null)
                {
                    _salesSlipInputConstruction = new SalesSlipInputConstruction();
                }
                return _salesSlipInputConstruction.SalesInputCd;
            }
            set
            {
                if (_salesSlipInputConstruction == null)
                {
                    _salesSlipInputConstruction = new SalesSlipInputConstruction();
                }
                _salesSlipInputConstruction.SalesInputCd = value;
            }
        }

        /// <summary>検索画面制御区分</summary>
        public int SearchUICntDivCdValue
        {
            get
            {
                if (_salesSlipInputConstruction == null)
                {
                    _salesSlipInputConstruction = new SalesSlipInputConstruction();
                }
                // 2010/06/15 Add >>>
                // PM7固定
                _salesSlipInputConstruction.SearchUICntDivCd = 0;
                // 2010/06/15 Add <<<
                return _salesSlipInputConstruction.SearchUICntDivCd;
            }
            set
            {
                if (_salesSlipInputConstruction == null)
                {
                    _salesSlipInputConstruction = new SalesSlipInputConstruction();
                }
                _salesSlipInputConstruction.SearchUICntDivCd = value;
            }
        }

        /// <summary>エンターキー処理区分</summary>
        public int EnterProcDivCdValue
        {
            get
            {
                if (_salesSlipInputConstruction == null)
                {
                    _salesSlipInputConstruction = new SalesSlipInputConstruction();
                }
                // 2010/06/15 Add >>>
                // PM7固定
                _salesSlipInputConstruction.EnterProcDivCd = 0;
                // 2010/06/15 Add <<<
                return _salesSlipInputConstruction.EnterProcDivCd;
            }
            set
            {
                if (_salesSlipInputConstruction == null)
                {
                    _salesSlipInputConstruction = new SalesSlipInputConstruction();
                }
                _salesSlipInputConstruction.EnterProcDivCd = value;
            }
        }

        /// <summary>品番検索区分</summary>
        public int PartsNoSearchDivCdValue
        {
            get
            {
                if (_salesSlipInputConstruction == null)
                {
                    _salesSlipInputConstruction = new SalesSlipInputConstruction();
                }
                // 2010/06/15 Add >>>
                // PM7固定
                _salesSlipInputConstruction.PartsNoSearchDivCd = 0;
                // 2010/06/15 Add <<<
                return _salesSlipInputConstruction.PartsNoSearchDivCd;
            }
            set
            {
                if (_salesSlipInputConstruction == null)
                {
                    _salesSlipInputConstruction = new SalesSlipInputConstruction();
                }
                _salesSlipInputConstruction.PartsNoSearchDivCd = value;
            }
        }

        /// <summary>品番結合制御区分</summary>
        public string PartsJoinCntDivCdValue
        {
            get
            {
                if (_salesSlipInputConstruction == null)
                {
                    _salesSlipInputConstruction = new SalesSlipInputConstruction();
                }
                return _salesSlipInputConstruction.PartsJoinCntDivCd;
            }
            set
            {
                if (_salesSlipInputConstruction == null)
                {
                    _salesSlipInputConstruction = new SalesSlipInputConstruction();
                }
                _salesSlipInputConstruction.PartsJoinCntDivCd = value;
            }
        }

        /// <summary>車両検索後のフォーカス位置</summary>
        public int FocusPositionAfterCarSearchValue
        {
            get
            {
                if (_salesSlipInputConstruction == null)
                {
                    _salesSlipInputConstruction = new SalesSlipInputConstruction();
                }
                return _salesSlipInputConstruction.FocusPositionAfterCarSearchValue;

            }
            set
            {
                if (_salesSlipInputConstruction == null)
                {
                    _salesSlipInputConstruction = new SalesSlipInputConstruction();
                }
                _salesSlipInputConstruction.FocusPositionAfterCarSearchValue = value;
            }
        }
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.15 ADD
        /// <summary>ＢＬガイドモード</summary>
        public int BLGuideModeValue
        {
            get
            {
                if ( _salesSlipInputConstruction == null )
                {
                    _salesSlipInputConstruction = new SalesSlipInputConstruction();
                }
                return _salesSlipInputConstruction.BLGuideMode;
            }
            set
            {
                if ( _salesSlipInputConstruction == null )
                {
                    _salesSlipInputConstruction = new SalesSlipInputConstruction();
                }
                _salesSlipInputConstruction.BLGuideMode = value;
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.15 ADD

        //---------------- ADD 連番1002 2011/08/08 ------------------>>>>>
        /// <summary>入力後のカーソル位置</summary>
        public int CursorPosValue
        {
            get
            {
                if (_salesSlipInputConstruction == null)
                {
                    _salesSlipInputConstruction = new SalesSlipInputConstruction();
                }
                return _salesSlipInputConstruction.CursorPos;
            }
            set
            {
                if (_salesSlipInputConstruction == null)
                {
                    _salesSlipInputConstruction = new SalesSlipInputConstruction();
                }
                _salesSlipInputConstruction.CursorPos = value;
            }
        }
        //---------------- ADD 連番1002 2011/08/08 ------------------<<<<<

        // --- DEL 2012/05/21 ---------->>>>>
        //// --- ADD 2012/04/11 No.594 ---------->>>>>
        ///// <summary>商品検索後のカーソル位置</summary>
        //public int FocusPositionAfterBLCodeSearchValue
        //{
        //    get
        //    {
        //        if (_salesSlipInputConstruction == null)
        //        {
        //            _salesSlipInputConstruction = new SalesSlipInputConstruction();
        //        }
        //        return _salesSlipInputConstruction.FocusPositionAfterBLCodeSearchValue;
        //    }
        //    set
        //    {
        //        if (_salesSlipInputConstruction == null)
        //        {
        //            _salesSlipInputConstruction = new SalesSlipInputConstruction();
        //        }
        //        _salesSlipInputConstruction.FocusPositionAfterBLCodeSearchValue = value;
        //    }
        //}
        //// --- ADD 2012/04/11 No.594 ----------<<<<<
        // --- DEL 2012/05/21 ----------<<<<<

        // --- ADD 2013/11/05 Y.Wakita ---------->>>>>
        /// <summary>商品検索後のカーソル位置</summary>
        public int FocusPositionAfterBLCodeSearchValue
        {
            get
            {
                if (_salesSlipInputConstruction == null)
                {
                    _salesSlipInputConstruction = new SalesSlipInputConstruction();
                }
                return _salesSlipInputConstruction.FocusPositionAfterBLCodeSearchValue;
            }
            set
            {
                if (_salesSlipInputConstruction == null)
                {
                    _salesSlipInputConstruction = new SalesSlipInputConstruction();
                }
                _salesSlipInputConstruction.FocusPositionAfterBLCodeSearchValue = value;
            }
        }
        // --- ADD 2013/11/05 Y.Wakita ----------<<<<<

        // --- ADD 2014/02/24 Y.Wakita ---------->>>>>
        /// <summary>伝票種別の記憶</summary>
        public int AcptAnOdrStatusMemoryValue
        {
            get
            {
                if (_salesSlipInputConstruction == null)
                {
                    _salesSlipInputConstruction = new SalesSlipInputConstruction();
                }
                return _salesSlipInputConstruction.AcptAnOdrStatusMemoryValue;
            }
            set
            {
                if (_salesSlipInputConstruction == null)
                {
                    _salesSlipInputConstruction = new SalesSlipInputConstruction();
                }
                _salesSlipInputConstruction.AcptAnOdrStatusMemoryValue = value;
            }
        }
        // --- ADD 2014/02/24 Y.Wakita ----------<<<<<

        // ------ ADD 2021/04/12 陳艶丹 FOR PMKOBETSU-4136-------->>>>
        /// <summary>得意先ガイド表示</summary>
        public int CustomerGuidDisplayValue
        {
            get
            {
                if (_salesSlipInputConstruction == null)
                {
                    _salesSlipInputConstruction = new SalesSlipInputConstruction();
                }
                return _salesSlipInputConstruction.CustomerGuidDisplayValue;
            }
            set
            {
                if (_salesSlipInputConstruction == null)
                {
                    _salesSlipInputConstruction = new SalesSlipInputConstruction();
                }
                _salesSlipInputConstruction.CustomerGuidDisplayValue = value;
            }
        }
        // ------ ADD 2021/04/12 陳艶丹 FOR PMKOBETSU-4136--------<<<<<

        // --- ADD 2009/12/23 ---------->>>>>
        /// <summary>出荷数入力最大桁数</summary>
        public int ShipmentMaxCntValue
        {
            get
            {
                if (_salesSlipInputConstruction == null)
                {
                    _salesSlipInputConstruction = new SalesSlipInputConstruction();
                }
                return _salesSlipInputConstruction.ShipmentMaxCnt;
            }
            set
            {
                if (_salesSlipInputConstruction == null)
                {
                    _salesSlipInputConstruction = new SalesSlipInputConstruction();
                }
                _salesSlipInputConstruction.ShipmentMaxCnt = value;
            }
        }

        /// <summary>受注数入力最大桁数</summary>
        public int AcceptAnOrderMaxCntValue
        {
            get
            {
                if (_salesSlipInputConstruction == null)
                {
                    _salesSlipInputConstruction = new SalesSlipInputConstruction();
                }
                return _salesSlipInputConstruction.AcceptAnOrderMaxCnt;
            }
            set
            {
                if (_salesSlipInputConstruction == null)
                {
                    _salesSlipInputConstruction = new SalesSlipInputConstruction();
                }
                _salesSlipInputConstruction.AcceptAnOrderMaxCnt = value;
            }
        }
        // --- ADD 2009/12/23 ----------<<<<<

        //>>>2010/02/26
        /// <summary>SCM情報自動展開</summary>
        public int ScmValue
        {
            get
            {
                if (_salesSlipInputConstruction == null)
                {
                    _salesSlipInputConstruction = new SalesSlipInputConstruction();
                }
                return _salesSlipInputConstruction.ScmValue;
            }
            set
            {
                if (_salesSlipInputConstruction == null)
                {
                    _salesSlipInputConstruction = new SalesSlipInputConstruction();
                }
                _salesSlipInputConstruction.ScmValue = value;
            }
        }
        //<<<2010/02/26

        // 2010/06/15 Add >>>
        /// <summary>RCLinkDirectory</summary>
        public string RCLinkDirectoryValue
        {
            get
            {
                if (_salesSlipInputConstruction == null)
                {
                    _salesSlipInputConstruction = new SalesSlipInputConstruction();
                }
                return _salesSlipInputConstruction.RCLinkDirectoryValue;
            }
            set
            {
                if (_salesSlipInputConstruction == null)
                {
                    _salesSlipInputConstruction = new SalesSlipInputConstruction();
                }
                _salesSlipInputConstruction.RCLinkDirectoryValue = value;
            }
        }
        // 2010/06/15 Add <<<


        /// <summary>ローカルDB読込判定</summary>
        public bool IsLocalDBRead
        {
            get { return this._isLocalDBRead; }
            set { this._isLocalDBRead = value; }
        }

        /// <summary>企業コード</summary>
        public string EnterpriseCode
        {
            get { return this._enterpriseCode; }
            set { this._enterpriseCode = value; }
        }

        /// <summary>Enterキー入力時移動先テーブル</summary>
        public Dictionary<string, EnterMoveValue> EnterMoveTable
        {
            get { return this._enterMoveTable; }
            set { this._enterMoveTable = value; }
        }

        /// <summary>初期設定Enterキー入力時移動先テーブル</summary>
        public Dictionary<string, EnterMoveValue> EnterMoveTableInit
        {
            get { return this._enterMoveTableInit; }
            set { this._enterMoveTableInit = value; }
        }

        /// <summary>項目名称テーブル</summary>
        public Hashtable NameTable
        {
            get { return this._nameTable; }
            set { this._nameTable = value; }
        }

        /// <summary>有効項目テーブル</summary>
        public ArrayList EffectiveList
        {
            get { return this._effectiveList; }
            set { this._effectiveList = value; }
        }

        /// <summary>ヘッダ項目Dictionary</summary>
        public Dictionary<string, Control> HeaderItemsDictionary
        {
            get { return this._headerItemsDictionary; }
            set { this._headerItemsDictionary = value; }
        }

        // --- ADD 2010/07/06 ---------->>>>>
        /// <summary>ヘッダ項目Dictionary</summary>
        public Dictionary<string, Control> FunctionItemsDictionary
        {
            get { return this._functionItemsDictionary; }
            set { this._functionItemsDictionary = value; }
        }
        // --- ADD 2010/07/06 ----------<<<<<

        // --- ADD 2010/08/13 ---------->>>>>        
        /// <summary>ヘッダ項目Dictionary</summary>        
        public Dictionary<string, Control> FunctionDetailItemsDictionary       
        {       
            get { return this._functionDetailItemsDictionary; }     
            set { this._functionDetailItemsDictionary = value; }    
        }    
        // --- ADD 2010/08/13 ----------<<<<<    
        // --- UPD 2009/12/23 ---------->>>>>

        /// <summary>フッタ項目Dictionary</summary>
        public Dictionary<string, Control> FooterItemsDictionary
        {
            get { return this._footerItemsDictionary; }
            set { this._footerItemsDictionary = value; }
        }
        // --- UPD 2009/12/23 ----------<<<<<

        /// <summary>最終項目名称リスト</summary>
        public ArrayList EndKeyNameList
        {
            get { return this._endKeyNameList; }
            set { this._endKeyNameList = value; }
        }

        /// <summary>初期設定最終項目名称リスト</summary>
        public ArrayList EndKeyNameListInit
        {
            get { return this._endKeyNameListInit; }
            set { this._endKeyNameListInit = value; }
        }

        // --- ADD ADD 陳艶丹 2022/04/26 PMKOBETSU-4208 電子帳簿対応--->>>>>
        /// <summary>伝票PDF出力</summary>
        public int OutputMode
        {
            get
            {
                if (_salesSlipInputConstruction == null)
                {
                    _salesSlipInputConstruction = new SalesSlipInputConstruction();
                }
                return _salesSlipInputConstruction.OutputMode;
            }
            set
            {
                if (_salesSlipInputConstruction == null)
                {
                    _salesSlipInputConstruction = new SalesSlipInputConstruction();
                }
                _salesSlipInputConstruction.OutputMode = value;
            }
        }

        /// <summary>出力伝票区分_売上</summary>
        public int SalesOutputDiv
        {
            get
            {
                if (_salesSlipInputConstruction == null)
                {
                    _salesSlipInputConstruction = new SalesSlipInputConstruction();
                }
                return _salesSlipInputConstruction.SalesOutputDiv;
            }
            set
            {
                if (_salesSlipInputConstruction == null)
                {
                    _salesSlipInputConstruction = new SalesSlipInputConstruction();
                }
                _salesSlipInputConstruction.SalesOutputDiv = value;
            }
        }

        /// <summary>出力伝票区分_見積</summary>
        public int EstimateOutputDiv
        {
            get
            {
                if (_salesSlipInputConstruction == null)
                {
                    _salesSlipInputConstruction = new SalesSlipInputConstruction();
                }
                return _salesSlipInputConstruction.EstimateOutputDiv;
            }
            set
            {
                if (_salesSlipInputConstruction == null)
                {
                    _salesSlipInputConstruction = new SalesSlipInputConstruction();
                }
                _salesSlipInputConstruction.EstimateOutputDiv = value;
            }
        }

        /// <summary>PDFプリンター</summary>
        public int PdfPrinter
        {
            get
            {
                if (_salesSlipInputConstruction == null)
                {
                    _salesSlipInputConstruction = new SalesSlipInputConstruction();
                }
                return _salesSlipInputConstruction.PdfPrinter;
            }
            set
            {
                if (_salesSlipInputConstruction == null)
                {
                    _salesSlipInputConstruction = new SalesSlipInputConstruction();
                }
                _salesSlipInputConstruction.PdfPrinter = value;
            }
        }

        /// <summary>PDFプリンターNo</summary>
        public int PdfPrinterNumber
        {
            get
            {
                if (_salesSlipInputConstruction == null)
                {
                    _salesSlipInputConstruction = new SalesSlipInputConstruction();
                }
                return _salesSlipInputConstruction.PdfPrinterNumber;
            }
            set
            {
                if (_salesSlipInputConstruction == null)
                {
                    _salesSlipInputConstruction = new SalesSlipInputConstruction();
                }
                _salesSlipInputConstruction.PdfPrinterNumber = value;
            }
        }

        /// <summary>PDFプリンター待機時間</summary>
        public int PdfPrinterWait
        {
            get
            {
                if (_salesSlipInputConstruction == null)
                {
                    _salesSlipInputConstruction = new SalesSlipInputConstruction();
                }
                return _salesSlipInputConstruction.PdfPrinterWait;
            }
            set
            {
                if (_salesSlipInputConstruction == null)
                {
                    _salesSlipInputConstruction = new SalesSlipInputConstruction();
                }
                _salesSlipInputConstruction.PdfPrinterWait = value;
            }
        }
        // --- ADD ADD 陳艶丹 2022/04/26 PMKOBETSU-4208 電子帳簿対応---<<<<<

        //--- ADD 田村顕成 2022/10/05 インボイス残対応 ----->>>>>
        /// <summary>返品・赤伝時備考1使用モード</summary>
        public int ReturnRedNote1Mode
        {
            get
            {
                if (_salesSlipInputConstruction == null)
                {
                    _salesSlipInputConstruction = new SalesSlipInputConstruction();
                }
                return _salesSlipInputConstruction.ReturnRedNote1Mode;
            }
            set
            {
                if (_salesSlipInputConstruction == null)
                {
                    _salesSlipInputConstruction = new SalesSlipInputConstruction();
                }
                _salesSlipInputConstruction.ReturnRedNote1Mode = value;
            }
        }
        public string ReturnRedNote1
        {
            get
            {
                if (_salesSlipInputConstruction == null)
                {
                    _salesSlipInputConstruction = new SalesSlipInputConstruction();
                }
                return _salesSlipInputConstruction.ReturnRedNote1;
            }
            set
            {
                if (_salesSlipInputConstruction == null)
                {
                    _salesSlipInputConstruction = new SalesSlipInputConstruction();
                }
                _salesSlipInputConstruction.ReturnRedNote1 = value;
            }
        }

        /// <summary>返品・赤伝時備考2使用モード</summary>
        public int ReturnRedNote2Mode
        {
            get
            {
                if (_salesSlipInputConstruction == null)
                {
                    _salesSlipInputConstruction = new SalesSlipInputConstruction();
                }
                return _salesSlipInputConstruction.ReturnRedNote2Mode;
            }
            set
            {
                if (_salesSlipInputConstruction == null)
                {
                    _salesSlipInputConstruction = new SalesSlipInputConstruction();
                }
                _salesSlipInputConstruction.ReturnRedNote2Mode = value;
            }
        }
        public string ReturnRedNote2
        {
            get
            {
                if (_salesSlipInputConstruction == null)
                {
                    _salesSlipInputConstruction = new SalesSlipInputConstruction();
                }
                return _salesSlipInputConstruction.ReturnRedNote2;
            }
            set
            {
                if (_salesSlipInputConstruction == null)
                {
                    _salesSlipInputConstruction = new SalesSlipInputConstruction();
                }
                _salesSlipInputConstruction.ReturnRedNote2 = value;
            }
        }

        /// <summary>返品・赤伝時備考3使用モード</summary>
        public int ReturnRedNote3Mode
        {
            get
            {
                if (_salesSlipInputConstruction == null)
                {
                    _salesSlipInputConstruction = new SalesSlipInputConstruction();
                }
                return _salesSlipInputConstruction.ReturnRedNote3Mode;
            }
            set
            {
                if (_salesSlipInputConstruction == null)
                {
                    _salesSlipInputConstruction = new SalesSlipInputConstruction();
                }
                _salesSlipInputConstruction.ReturnRedNote3Mode = value;
            }
        }
        public string ReturnRedNote3
        {
            get
            {
                if (_salesSlipInputConstruction == null)
                {
                    _salesSlipInputConstruction = new SalesSlipInputConstruction();
                }
                return _salesSlipInputConstruction.ReturnRedNote3;
            }
            set
            {
                if (_salesSlipInputConstruction == null)
                {
                    _salesSlipInputConstruction = new SalesSlipInputConstruction();
                }
                _salesSlipInputConstruction.ReturnRedNote3 = value;
            }
        }

        /// <summary>返品・赤伝時備考欄ブランクチェックモード</summary>
        public int ReturnRedBlankCheckMode
        {
            get
            {
                if (_salesSlipInputConstruction == null)
                {
                    _salesSlipInputConstruction = new SalesSlipInputConstruction();
                }
                return _salesSlipInputConstruction.ReturnRedBlankCheckMode;
            }
            set
            {
                if (_salesSlipInputConstruction == null)
                {
                    _salesSlipInputConstruction = new SalesSlipInputConstruction();
                }
                _salesSlipInputConstruction.ReturnRedBlankCheckMode = value;
            }
        }
        //--- ADD 田村顕成 2022/10/05 インボイス残対応 -----<<<<<

        # endregion

        // ===================================================================================== //
        // パブリックメソッド
        // ===================================================================================== //
        # region Public Methods
        ///// <summary>
        ///// 売上入力用ユーザー設定クラスシリアライズ処理
        ///// </summary>
        ///// <remarks>
        ///// <br>Note       : 売上入力用ユーザー設定クラスのシリアライズを行います。</br>
        ///// <br>Programmer : 20056 對馬 大輔</br>
        ///// <br>Date       : 2007.09.10</br>
        ///// </remarks>
        //public void Serialize()
        //{
        //    UserSettingController.SerializeUserSetting(_salesSlipInputConstruction, Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME));

        //    if (DataChanged != null)
        //    {
        //        // データ変更後発生イベント実行
        //        DataChanged(this, new EventArgs());
        //    }
        //}

        /// <summary>
        /// 売上入力用ユーザー設定クラスシリアライズ処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 売上入力用ユーザー設定クラスのシリアライズを行います。</br>
        /// <br>Programmer : 20056 對馬 大輔</br>
        /// <br>Date       : 2007.09.10</br>
        /// <br>UpdateNote : 2010/03/01② 楊明俊 DOMより、読み込み方法を修正します。</br>
        /// <br>Programmer : 連番1002 許雁波</br>
        /// <br>Date       : 2011/08/08</br>
        /// <br>Update Note: 2018/09/04 譚洪</br>
        /// <br>管理番号   : 11470152-00</br>
        /// <br>           : 『設定』画面で画面制御タブの変更</br>
        /// <br>Update Note: 2021/03/16 陳艶丹</br>
        /// <br>管理番号   : 11770032-00</br>
        /// <br>           : PMKOBETSU-4133 売上伝票入力原価0円障害の対応</br>
        /// <br>Update Note: 2021/04/12 陳艶丹</br>
        /// <br>管理番号   : 11770021-00</br>
        /// <br>           : PMKOBETSU-4136 得意先ガイド表示項目設定の追加</br>
        /// </remarks>
        public void Serialize()
        {
            // --- DEL 2010/03/01② ---------->>>>>
            //UserSettingController.SerializeUserSetting(_salesSlipInputConstruction, Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME));
            // --- DEL 2010/03/01② ----------<<<<<

            // --- ADD 2010/03/01② ---------->>>>>
            XmlElement root = null;
            XmlDocument xmldoc = new XmlDocument();
            //ファイルがある場合、ファイルの読み
            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME)))
            {
                xmldoc.Load(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME));
                root = xmldoc.DocumentElement;
                root.RemoveAll();
            }
            //ファイルがない場合、ファイルの作成
            else
            {
                XmlDeclaration xmlDeclaration = xmldoc.CreateXmlDeclaration("1.0", null, null);
                XmlNode xmlNode = xmldoc.CreateNode(XmlNodeType.Element, "SalesSlipInputConstruction", "");
                xmldoc.AppendChild(xmlNode);
                xmldoc.InsertBefore(xmlDeclaration, xmlNode);
                root = xmldoc.DocumentElement;
            }

            root.SetAttribute("xmlns:xsi", @"http://www.w3.org/2001/XMLSchema-instance");
            root.SetAttribute("xmlns:xsd", @"http://www.w3.org/2001/XMLSchema");

            // FocusPositionValue
            XmlNode focusPositionValueNode = xmldoc.CreateNode(XmlNodeType.Element, "FocusPositionValue", "");
            focusPositionValueNode.InnerXml = _salesSlipInputConstruction.FocusPositionValue.ToString();

            // DataInputCountValue
            XmlNode dataInputCountValueNode = xmldoc.CreateNode(XmlNodeType.Element, "DataInputCountValue", "");
            dataInputCountValueNode.InnerXml = _salesSlipInputConstruction.DataInputCountValue.ToString();

            // StockGoodsCdValue
            XmlNode stockGoodsCdValueNode = xmldoc.CreateNode(XmlNodeType.Element, "StockGoodsCdValue", "");
            stockGoodsCdValueNode.InnerXml = _salesSlipInputConstruction.StockGoodsCdValue.ToString();

            // AccPayDivCdValue
            XmlNode accPayDivCdValueNode = xmldoc.CreateNode(XmlNodeType.Element, "AccPayDivCdValue", "");
            accPayDivCdValueNode.InnerXml = _salesSlipInputConstruction.AccPayDivCdValue.ToString();

            // FontSizeValue
            XmlNode fontSizeValueNode = xmldoc.CreateNode(XmlNodeType.Element, "FontSizeValue", "");
            fontSizeValueNode.InnerXml = _salesSlipInputConstruction.FontSizeValue.ToString();

            // ADD 2011/08/09----------->>>>>>>>
            // ColorsValue
            XmlNode colorsValueNode = xmldoc.CreateNode(XmlNodeType.Element, "ColorsValue", "");
            colorsValueNode.InnerXml = _salesSlipInputConstruction.ColorsValue.ToString();
            // ADD 2011/08/09-----------<<<<<<<<

            // ClearAfterSave
            XmlNode clearAfterSaveNode = xmldoc.CreateNode(XmlNodeType.Element, "ClearAfterSave", "");
            clearAfterSaveNode.InnerXml = _salesSlipInputConstruction.ClearAfterSave.ToString();

            // UltraOptionSet
            XmlNode ultraOptionSetNode = xmldoc.CreateNode(XmlNodeType.Element, "UltraOptionSet", "");
            ultraOptionSetNode.InnerXml = _salesSlipInputConstruction.UltraOptionSet.ToString();

            // SaveInfoStoreValue
            XmlNode saveInfoStoreValueNode = xmldoc.CreateNode(XmlNodeType.Element, "SaveInfoStoreValue", "");
            saveInfoStoreValueNode.InnerXml = _salesSlipInputConstruction.SaveInfoStoreValue.ToString();

            // PartySaleSlipValue
            XmlNode partySaleSlipValueNode = xmldoc.CreateNode(XmlNodeType.Element, "PartySaleSlipValue", "");
            partySaleSlipValueNode.InnerXml = _salesSlipInputConstruction.PartySaleSlipValue.ToString();

            XmlNode headerFocusConstructionListNode = xmldoc.CreateNode(XmlNodeType.Element, "HeaderFocusConstructionList", "");

            HeaderFocusConstructionList HeaderFocusConstructionList = _salesSlipInputConstruction.HeaderFocusConstructionList;
            List<HeaderFocusConstruction> hFocusConstructionList = HeaderFocusConstructionList.headerFocusConstruction;
            XmlNode hFocusConstructionListNode = xmldoc.CreateNode(XmlNodeType.Element, "headerFocusConstruction", "");

            foreach (HeaderFocusConstruction headerFocusConstruction in hFocusConstructionList)
            {
                XmlNode headerListNode = xmldoc.CreateNode(XmlNodeType.Element, "HeaderFocusConstruction", "");
                // Key
                XmlNode keyNode = xmldoc.CreateNode(XmlNodeType.Element, "Key", "");
                keyNode.InnerXml = headerFocusConstruction.Key;
                // Caption
                XmlNode captionNode = xmldoc.CreateNode(XmlNodeType.Element, "Caption", "");
                captionNode.InnerXml = headerFocusConstruction.Caption;
                // EnterStop
                XmlNode enterStopNode = xmldoc.CreateNode(XmlNodeType.Element, "EnterStop", "");
                enterStopNode.InnerXml = headerFocusConstruction.EnterStop.ToString().ToLower();

                headerListNode.AppendChild(keyNode);
                headerListNode.AppendChild(captionNode);
                headerListNode.AppendChild(enterStopNode);

                hFocusConstructionListNode.AppendChild(headerListNode);
            }
            headerFocusConstructionListNode.AppendChild(hFocusConstructionListNode);

            //>>>2010/08/06
            // EmployeeCdDiv
            XmlNode employeeCdDivNode = xmldoc.CreateNode(XmlNodeType.Element, "EmployeeCdDiv", "");
            employeeCdDivNode.InnerXml = _salesSlipInputConstruction.EmployeeCdDiv.ToString();

            // FrontEmployeeCdDiv
            XmlNode frontEmployeeCdDivNode = xmldoc.CreateNode(XmlNodeType.Element, "FrontEmployeeCdDiv", "");
            frontEmployeeCdDivNode.InnerXml = _salesSlipInputConstruction.FrontEmployeeCdDiv.ToString();

            // SalesInputCdDiv
            XmlNode salesInputCdDivNode = xmldoc.CreateNode(XmlNodeType.Element, "SalesInputCdDiv", "");
            salesInputCdDivNode.InnerXml = _salesSlipInputConstruction.SalesInputCdDiv.ToString();

            // EmployeeCd
            XmlNode employeeCdNode = xmldoc.CreateNode(XmlNodeType.Element, "EmployeeCd", "");
            employeeCdNode.InnerXml = _salesSlipInputConstruction.EmployeeCd;
            //<<<2010/08/06

            // FrontEmployeeCd
            XmlNode frontEmployeeCdNode = xmldoc.CreateNode(XmlNodeType.Element, "FrontEmployeeCd", "");
            frontEmployeeCdNode.InnerXml = _salesSlipInputConstruction.FrontEmployeeCd;

            // SalesInputCd
            XmlNode salesInputCdNode = xmldoc.CreateNode(XmlNodeType.Element, "SalesInputCd", "");
            salesInputCdNode.InnerXml = _salesSlipInputConstruction.SalesInputCd;

            // SearchUICntDivCd
            XmlNode searchUICntDivCdNode = xmldoc.CreateNode(XmlNodeType.Element, "SearchUICntDivCd", "");
            searchUICntDivCdNode.InnerXml = _salesSlipInputConstruction.SearchUICntDivCd.ToString();

            // EnterProcDivCd
            XmlNode enterProcDivCdNode = xmldoc.CreateNode(XmlNodeType.Element, "EnterProcDivCd", "");
            enterProcDivCdNode.InnerXml = _salesSlipInputConstruction.EnterProcDivCd.ToString();

            // PartsNoSearchDivCd
            XmlNode partsNoSearchDivCdNode = xmldoc.CreateNode(XmlNodeType.Element, "PartsNoSearchDivCd", "");
            partsNoSearchDivCdNode.InnerXml = _salesSlipInputConstruction.PartsNoSearchDivCd.ToString();

            // PartsJoinCntDivCd
            XmlNode partsJoinCntDivCdNode = xmldoc.CreateNode(XmlNodeType.Element, "PartsJoinCntDivCd", "");
            partsJoinCntDivCdNode.InnerXml = _salesSlipInputConstruction.PartsJoinCntDivCd;

            // FocusPositionAfterCarSearchValue
            XmlNode focusPositionAfterCarSearchValueNode = xmldoc.CreateNode(XmlNodeType.Element, "FocusPositionAfterCarSearchValue", "");
            focusPositionAfterCarSearchValueNode.InnerXml = _salesSlipInputConstruction.FocusPositionAfterCarSearchValue.ToString();

            // BLGuideMode
            XmlNode bLGuideModeNode = xmldoc.CreateNode(XmlNodeType.Element, "BLGuideMode", "");
            bLGuideModeNode.InnerXml = _salesSlipInputConstruction.BLGuideMode.ToString();

            // ------------ ADD 連番1002 2011/08/08 ----------------- >>>>>
            // CursorPos
            XmlNode cursorPosNode = xmldoc.CreateNode(XmlNodeType.Element, "CursorPos", "");
            cursorPosNode.InnerXml = _salesSlipInputConstruction.CursorPos.ToString();
            // ------------ ADD 連番1002 2011/08/08 ----------------- <<<<<

            // --- DEL 2012/05/21 ---------->>>>>
            //// --- ADD 2012/04/11 No.594 ---------->>>>>
            //// FocusPositionAfterBLCodeSearchValue
            //XmlNode focusPositionAfterBLCodeSearchValueNode = xmldoc.CreateNode(XmlNodeType.Element, "FocusPositionAfterBLCodeSearchValue", "");
            //focusPositionAfterBLCodeSearchValueNode.InnerXml = _salesSlipInputConstruction.FocusPositionAfterBLCodeSearchValue.ToString();
            //// --- ADD 2012/04/11 No.594 ----------<<<<<
            // --- DEL 2012/05/21 ----------<<<<<

            // --- ADD 2013/11/05 Y.Wakita ---------->>>>>
            // FocusPositionAfterBLCodeSearchValue
            XmlNode focusPositionAfterBLCodeSearchValueNode = xmldoc.CreateNode(XmlNodeType.Element, "FocusPositionAfterBLCodeSearchValue", "");
            focusPositionAfterBLCodeSearchValueNode.InnerXml = _salesSlipInputConstruction.FocusPositionAfterBLCodeSearchValue.ToString();
            // --- ADD 2013/11/05 Y.Wakita ----------<<<<<

            // --- ADD 2014/02/24 Y.Wakita ---------->>>>>
            // AcptAnOdrStatusMemory
            XmlNode acptAnOdrStatusMemoryNode = xmldoc.CreateNode(XmlNodeType.Element, "AcptAnOdrStatusMemory", "");
            acptAnOdrStatusMemoryNode.InnerXml = _salesSlipInputConstruction.AcptAnOdrStatusMemoryValue.ToString();
            // --- ADD 2014/02/24 Y.Wakita ----------<<<<<

            // ------ ADD 2021/04/12 陳艶丹 FOR PMKOBETSU-4136-------->>>>>
            // CustomerGuidDisplay
            XmlNode customerGuidDisplayNode = xmldoc.CreateNode(XmlNodeType.Element, "CustomerGuidDisplay", "");
            customerGuidDisplayNode.InnerXml = _salesSlipInputConstruction.CustomerGuidDisplayValue.ToString();
            // ------ ADD 2021/04/12 陳艶丹 FOR PMKOBETSU-4136--------<<<<<

            // ShipmentMaxCnt
            XmlNode shipmentMaxCntNode = xmldoc.CreateNode(XmlNodeType.Element, "ShipmentMaxCnt", "");
            shipmentMaxCntNode.InnerXml = _salesSlipInputConstruction.ShipmentMaxCnt.ToString();

//2010/06/15 yamaji ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            // rcLinkDirectory
            XmlNode rcLinkDirectory = xmldoc.CreateNode(XmlNodeType.Element, "rcLinkDirectory", "");
            rcLinkDirectory.InnerXml = _salesSlipInputConstruction.RCLinkDirectoryValue.ToString();
//2010/06/15 yamaji ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            // AcceptAnOrderMaxCnt
            XmlNode acceptAnOrderMaxCntNode = xmldoc.CreateNode(XmlNodeType.Element, "AcceptAnOrderMaxCnt", "");
            acceptAnOrderMaxCntNode.InnerXml = _salesSlipInputConstruction.AcceptAnOrderMaxCnt.ToString();
            //----- ADD　2018/09/04 譚洪　『設定』画面で画面制御タブの変更------->>>>>
            // InputMonthValue
            XmlNode InputMonthValueNode = xmldoc.CreateNode(XmlNodeType.Element, "InputMonthValue", "");
            InputMonthValueNode.InnerXml = _salesSlipInputConstruction.InputMonthValue.ToString();
            //----- ADD　2018/09/04 譚洪　『設定』画面で画面制御タブの変更-------<<<<<
            //----- ADD 2021/03/16 陳艶丹 FOR PMKOBETSU-4133------->>>>>
            // SaveUnitCostCheckDivValue
            XmlNode SaveUnitCostCheckDivValueNode = xmldoc.CreateNode(XmlNodeType.Element, "SaveUnitCostCheckDivValue", "");
            SaveUnitCostCheckDivValueNode.InnerXml = _salesSlipInputConstruction.SaveUnitCostCheckDivValue.ToString();
            //----- ADD 2021/03/16 陳艶丹 FOR PMKOBETSU-4133-------<<<<<
            // FooterFocusConstructionList
            XmlNode footerFocusConstructionListNode = xmldoc.CreateNode(XmlNodeType.Element, "FooterFocusConstructionList", "");

            FooterFocusConstructionList footerFocusConstructionList = _salesSlipInputConstruction.FooterFocusConstructionList;
            List<FooterFocusConstruction> fFocusConstructionList = footerFocusConstructionList.footerFocusConstruction;

            XmlNode fFocusConstructionNode = xmldoc.CreateNode(XmlNodeType.Element, "footerFocusConstruction", "");

            foreach (FooterFocusConstruction footerFocusConstruction in fFocusConstructionList)
            {
                XmlNode footerFocusConstructionNode = xmldoc.CreateNode(XmlNodeType.Element, "FooterFocusConstruction", "");

                // Key
                XmlNode fKeyNode = xmldoc.CreateNode(XmlNodeType.Element, "Key", "");
                fKeyNode.InnerXml = footerFocusConstruction.Key;
                // Caption
                XmlNode fCaptionNode = xmldoc.CreateNode(XmlNodeType.Element, "Caption", "");
                fCaptionNode.InnerXml = footerFocusConstruction.Caption;
                // EnterStop
                XmlNode fEnterStopNode = xmldoc.CreateNode(XmlNodeType.Element, "EnterStop", "");
                fEnterStopNode.InnerXml = footerFocusConstruction.EnterStop.ToString().ToLower();

                footerFocusConstructionNode.AppendChild(fKeyNode);
                footerFocusConstructionNode.AppendChild(fCaptionNode);
                footerFocusConstructionNode.AppendChild(fEnterStopNode);

                fFocusConstructionNode.AppendChild(footerFocusConstructionNode);
            }
            footerFocusConstructionListNode.AppendChild(fFocusConstructionNode);

            // ADD 2010/08/13 ---- >>>>
            // FunctionDetailConstructionList
            XmlNode functionDetailConstructionListNode = xmldoc.CreateNode(XmlNodeType.Element, "FunctionDetailConstructionList", "");

            FunctionDetailConstructionList functionDetailConstructionList = _salesSlipInputConstruction.FunctionDetailConstructionList;
            List<FunctionDetailConstruction> fFunctionDetailConstructionList = functionDetailConstructionList.functionDetailConstruction;

            XmlNode fFunctionDetailConstructionNode = xmldoc.CreateNode(XmlNodeType.Element, "functionDetailConstruction", "");

            foreach (FunctionDetailConstruction functionDetailConstruction in fFunctionDetailConstructionList)
            {
                XmlNode functionDetailConstructionNode = xmldoc.CreateNode(XmlNodeType.Element, "FunctionDetailConstruction", "");

                // Key
                XmlNode fKeyNode = xmldoc.CreateNode(XmlNodeType.Element, "Key", "");
                fKeyNode.InnerXml = functionDetailConstruction.Key;
                // Caption
                XmlNode fCaptionNode = xmldoc.CreateNode(XmlNodeType.Element, "Caption", "");
                fCaptionNode.InnerXml = functionDetailConstruction.Caption;

                // EnterStop
                XmlNode fEnterStopNode = xmldoc.CreateNode(XmlNodeType.Element, "EnterStop", "");
                fEnterStopNode.InnerXml = functionDetailConstruction.Checked.ToString().ToLower();

                functionDetailConstructionNode.AppendChild(fKeyNode);
                functionDetailConstructionNode.AppendChild(fCaptionNode);
                functionDetailConstructionNode.AppendChild(fEnterStopNode);

                fFunctionDetailConstructionNode.AppendChild(functionDetailConstructionNode);
            }
            functionDetailConstructionListNode.AppendChild(fFunctionDetailConstructionNode);
            // ADD 2010/08/13 ---- <<<<
            root.AppendChild(focusPositionValueNode);
            root.AppendChild(dataInputCountValueNode);
            root.AppendChild(stockGoodsCdValueNode);
            root.AppendChild(accPayDivCdValueNode);
            root.AppendChild(fontSizeValueNode);
            root.AppendChild(colorsValueNode);// ADD 2011/08/09
            root.AppendChild(clearAfterSaveNode);
            root.AppendChild(ultraOptionSetNode);
            root.AppendChild(saveInfoStoreValueNode);
            root.AppendChild(partySaleSlipValueNode);
            root.AppendChild(headerFocusConstructionListNode);
            //>>>2010/08/06
            root.AppendChild(employeeCdDivNode);
            root.AppendChild(frontEmployeeCdDivNode);
            root.AppendChild(salesInputCdDivNode);
            root.AppendChild(employeeCdNode);
            //<<<2010/08/06
            root.AppendChild(frontEmployeeCdNode);
            root.AppendChild(salesInputCdNode);
            root.AppendChild(searchUICntDivCdNode);
            root.AppendChild(enterProcDivCdNode);
            root.AppendChild(partsNoSearchDivCdNode);
            root.AppendChild(partsJoinCntDivCdNode);
            root.AppendChild(focusPositionAfterCarSearchValueNode);
            root.AppendChild(bLGuideModeNode);
            root.AppendChild(cursorPosNode);  // ADD 連番1002 2011/08/08
            // --- DEL 2012/05/21 ---------->>>>>
            //root.AppendChild(focusPositionAfterBLCodeSearchValueNode);  // ADD 2012/04/11 No.594
            // --- DEL 2012/05/21 ----------<<<<<
            root.AppendChild(shipmentMaxCntNode);
            root.AppendChild(rcLinkDirectory);     //2010/06/15 yamaji ADD
            root.AppendChild(acceptAnOrderMaxCntNode);
            root.AppendChild(footerFocusConstructionListNode);

            root.AppendChild(functionDetailConstructionListNode);// ADD 2010/08/13

            // --- ADD 2013/11/05 Y.Wakita ---------->>>>>
            root.AppendChild(focusPositionAfterBLCodeSearchValueNode);
            // --- ADD 2013/11/05 Y.Wakita ----------<<<<<

            // --- ADD 2014/02/24 Y.Wakita ---------->>>>>
            root.AppendChild(acptAnOdrStatusMemoryNode);
            // --- ADD 2014/02/24 Y.Wakita ----------<<<<<
            // ------ ADD 2021/04/12 陳艶丹 FOR PMKOBETSU-4136-------->>>>>
            root.AppendChild(customerGuidDisplayNode);
            // ------ ADD 2021/04/12 陳艶丹 FOR PMKOBETSU-4136--------<<<<<
            root.AppendChild(InputMonthValueNode);// ADD　2018/09/04 譚洪　『設定』画面で画面制御タブの変更
            root.AppendChild(SaveUnitCostCheckDivValueNode);// ADD 2021/03/16 陳艶丹 FOR PMKOBETSU-4133
            xmldoc.Save(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME));
            // --- ADD 2010/03/01② ---------->>>>>
            if (DataChanged != null)
            {
                // データ変更後発生イベント実行
                DataChanged(this, new EventArgs());
            }
        }

        /// <summary>
        /// 売上入力用ユーザー設定クラスデシリアライズ処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 売上入力用ユーザー設定クラスをデシリアライズします。</br>
        /// <br>Programmer : 連番1002 許雁波</br>
        /// <br>Date       : 2011/08/08</br>
        /// <br>Programmer : 連番4,979 梁森東</br>
        /// <br>Date       : 2011/08/09</br>
        /// <br>Update Note: 2018/09/04 譚洪</br>
        /// <br>管理番号   : 11470152-00</br>
        /// <br>           : 『設定』画面で画面制御タブの変更</br>
        /// <br>Update Note: 2021/03/16 陳艶丹</br>
        /// <br>管理番号   : 11770032-00</br>
        /// <br>           : PMKOBETSU-4133 売上伝票入力原価0円障害の対応</br>
        /// <br>Update Note: 2021/04/12 陳艶丹</br>
        /// <br>管理番号   : 11770021-00</br>
        /// <br>           : PMKOBETSU-4136 得意先ガイド表示項目設定の追加</br>
        /// </remarks>
        public void Deserialize()
        {
            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME)))
            {
                XmlElement root = null;
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.Load(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME));
                root = xmldoc.DocumentElement;

                //売上入力用ユーザー設定クラスの編集
                XmlNodeList xmlNodeList = root.ChildNodes;
                for (int i = 0; i < xmlNodeList.Count; i++)
                {
                    XmlNode node = xmlNodeList[i];
                    if (node.Name.ToLower() == "focuspositionvalue")
                    {
                        _salesSlipInputConstruction.FocusPositionValue = Int32.Parse(node.InnerXml);
                    }
                    else if (node.Name.ToLower() == "datainputcountvalue")
                    {
                        _salesSlipInputConstruction.DataInputCountValue = Int32.Parse(node.InnerXml);
                    }
                    else if (node.Name.ToLower() == "stockgoodscdvalue")
                    {
                        _salesSlipInputConstruction.StockGoodsCdValue = Int32.Parse(node.InnerXml);
                    }
                    else if (node.Name.ToLower() == "accpaydivcdvalue")
                    {
                        _salesSlipInputConstruction.AccPayDivCdValue = Int32.Parse(node.InnerXml);
                    }
                    else if (node.Name.ToLower() == "fontsizevalue")
                    {
                        _salesSlipInputConstruction.FontSizeValue = Int32.Parse(node.InnerXml);
                    }
                    // ADD 2011/08/09----------------->>>>>>>>>>>>>>
                    else if (node.Name.ToLower() == "colorsvalue")
                    {                                                            
                        _salesSlipInputConstruction.ColorsValue = Int32.Parse(node.InnerXml);
                    }
                    // ADD 2011/08/09-----------------<<<<<<<<<<<<<<
                    else if (node.Name.ToLower() == "clearaftersave")
                    {
                        _salesSlipInputConstruction.ClearAfterSave = Int32.Parse(node.InnerXml);
                    }
                    else if (node.Name.ToLower() == "ultraoptionset")
                    {
                        _salesSlipInputConstruction.UltraOptionSet = Int32.Parse(node.InnerXml);
                    }
                    else if (node.Name.ToLower() == "saveinfostorevalue")
                    {
                        _salesSlipInputConstruction.SaveInfoStoreValue = Int32.Parse(node.InnerXml);
                    }
                    else if (node.Name.ToLower() == "partysaleslipvalue")
                    {
                        _salesSlipInputConstruction.PartySaleSlipValue = Int32.Parse(node.InnerXml);
                    }

                    else if (node.Name.ToLower() == "headerfocusconstructionlist")
                    {
                        HeaderFocusConstructionList headerFocusConstructionList = new HeaderFocusConstructionList();
                        List<HeaderFocusConstruction> headerList = new List<HeaderFocusConstruction>();
                        if (node.HasChildNodes)
                        {
                            //売上入力用ユーザー設定クラス属性の編集
                            for (int n = 0; n < node.ChildNodes.Count; n++)
                            {
                                XmlNode node1 = node.ChildNodes[n];
                                if (node1.HasChildNodes)
                                {
                                    //HeaderFocusConstruction
                                    for (int m = 0; m < node1.ChildNodes.Count; m++)
                                    {
                                        XmlNode headerFocusConstructionNode = node1.ChildNodes[m];

                                        if (headerFocusConstructionNode.HasChildNodes)
                                        {
                                            HeaderFocusConstruction headerFocusConstruction = new HeaderFocusConstruction();
                                            for (int p = 0; p < headerFocusConstructionNode.ChildNodes.Count; p++)
                                            {
                                                XmlNode headerNode = headerFocusConstructionNode.ChildNodes[p];
                                                //
                                                if (headerNode.Name.ToLower() == "key")
                                                {
                                                    headerFocusConstruction.Key = headerNode.InnerXml;//update
                                                }
                                                //
                                                if (headerNode.Name.ToLower() == "caption")
                                                {
                                                    headerFocusConstruction.Caption = headerNode.InnerXml;
                                                }
                                                //
                                                if (headerNode.Name.ToLower() == "enterstop")
                                                {
                                                    headerFocusConstruction.EnterStop = Boolean.Parse(headerNode.InnerXml);
                                                }
                                            }
                                            headerList.Add(headerFocusConstruction);
                                        }
                                    }
                                }
                            }
                        }
                        headerFocusConstructionList.headerFocusConstruction = headerList;
                        _salesSlipInputConstruction.HeaderFocusConstructionList = headerFocusConstructionList;
                    }
                    //>>>2010/08/06
                    else if (node.Name == "EmployeeCdDiv")
                    {
                        _salesSlipInputConstruction.EmployeeCdDiv = Int32.Parse(node.InnerXml);
                    }
                    else if (node.Name == "FrontEmployeeCdDiv")
                    {
                        _salesSlipInputConstruction.FrontEmployeeCdDiv = Int32.Parse(node.InnerXml);
                    }
                    else if (node.Name == "SalesInputCdDiv")
                    {
                        _salesSlipInputConstruction.SalesInputCdDiv = Int32.Parse(node.InnerXml);
                    }
                    else if (node.Name == "EmployeeCd")
                    {
                        _salesSlipInputConstruction.EmployeeCd = node.InnerXml;
                    }
                    //<<<2010/08/06
                    else if (node.Name == "FrontEmployeeCd")
                    {
                        _salesSlipInputConstruction.FrontEmployeeCd = node.InnerXml;
                    }
                    else if (node.Name == "SalesInputCd")
                    {
                        _salesSlipInputConstruction.SalesInputCd = node.InnerXml;
                    }
                    else if (node.Name == "SearchUICntDivCd")
                    {
                        _salesSlipInputConstruction.SearchUICntDivCd = Int32.Parse(node.InnerXml);
                    }
                    else if (node.Name == "EnterProcDivCd")
                    {
                        _salesSlipInputConstruction.EnterProcDivCd = Int32.Parse(node.InnerXml);
                    }
                    else if (node.Name == "PartsNoSearchDivCd")
                    {
                        _salesSlipInputConstruction.PartsNoSearchDivCd = Int32.Parse(node.InnerXml);
                    }
                    else if (node.Name == "PartsJoinCntDivCd")
                    {
                        _salesSlipInputConstruction.PartsJoinCntDivCd = node.InnerXml;//update
                    }
                    else if (node.Name == "FocusPositionAfterCarSearchValue")
                    {
                        _salesSlipInputConstruction.FocusPositionAfterCarSearchValue = Int32.Parse(node.InnerXml);
                    }
                    else if (node.Name == "BLGuideMode")
                    {
                        _salesSlipInputConstruction.BLGuideMode = Int32.Parse(node.InnerXml);
                    }
                    // --------------- ADD 連番1002 2011/08/08 ----------------->>>>>
                    else if (node.Name == "CursorPos")
                    {
                        _salesSlipInputConstruction.CursorPos = Int32.Parse(node.InnerXml);
                    }
                    // --------------- ADD 連番1002 2011/08/08 -----------------<<<<<
                    // --- DEL 2012/05/21 ---------->>>>>
                    //// --- ADD 2012/04/11 No.594 ---------->>>>>
                    //else if (node.Name == "FocusPositionAfterBLCodeSearchValue")
                    //{
                    //    _salesSlipInputConstruction.FocusPositionAfterBLCodeSearchValue = Int32.Parse(node.InnerXml);
                    //}
                    //// --- ADD 2012/04/11 No.594 ----------<<<<<
                    // --- DEL 2012/05/21 ----------<<<<<
                    // --- ADD 2013/11/05 Y.Wakita ---------->>>>>
                    else if (node.Name == "FocusPositionAfterBLCodeSearchValue")
                    {
                        _salesSlipInputConstruction.FocusPositionAfterBLCodeSearchValue = Int32.Parse(node.InnerXml);
                    }
                    // --- ADD 2013/11/05 Y.Wakita ----------<<<<<
                    // --- ADD 2014/02/24 Y.Wakita ---------->>>>>
                    else if (node.Name == "AcptAnOdrStatusMemory")
                    {
                        _salesSlipInputConstruction.AcptAnOdrStatusMemoryValue = Int32.Parse(node.InnerXml);
                    }
                    // --- ADD 2014/02/24 Y.Wakita ----------<<<<<
                    // ------ ADD 2021/04/12 陳艶丹 FOR PMKOBETSU-4136-------->>>>>
                    else if (node.Name == "CustomerGuidDisplay")
                    {
                        _salesSlipInputConstruction.CustomerGuidDisplayValue = Int32.Parse(node.InnerXml);
                    }
                    // ------ ADD 2021/04/12 陳艶丹 FOR PMKOBETSU-4136--------<<<<<
                    else if (node.Name == "ShipmentMaxCnt")
                    {
                        _salesSlipInputConstruction.ShipmentMaxCnt = Int32.Parse(node.InnerXml);
                    }
                    else if (node.Name == "AcceptAnOrderMaxCnt")
                    {
                        _salesSlipInputConstruction.AcceptAnOrderMaxCnt = Int32.Parse(node.InnerXml);
                    }
                    //----- ADD　2018/09/04 譚洪　『設定』画面で画面制御タブの変更------->>>>>
                    else if (node.Name == "InputMonthValue")
                    {
                        _salesSlipInputConstruction.InputMonthValue = Int32.Parse(node.InnerXml);
                    }
                    //----- ADD　2018/09/04 譚洪　『設定』画面で画面制御タブの変更-------<<<<<
//2010/06/15 yamaji ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    else if (node.Name == "rcLinkDirectory")
                    {
                        _salesSlipInputConstruction.RCLinkDirectoryValue = node.InnerXml;
                    }
//2010/06/15 yamaji ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                    // ------ ADD 2021/03/16 陳艶丹 FOR PMKOBETSU-4133-------->>>>
                    else if (node.Name == "SaveUnitCostCheckDivValue")
                    {
                        _salesSlipInputConstruction.SaveUnitCostCheckDivValue = Int32.Parse(node.InnerXml);
                    }
                    // ------ ADD 2021/03/16 陳艶丹 FOR PMKOBETSU-4133--------<<<<
                    else if (node.Name == "FooterFocusConstructionList")
                    {
                        FooterFocusConstructionList footerFocusConstructionList = new FooterFocusConstructionList();
                        List<FooterFocusConstruction> footerList = new List<FooterFocusConstruction>();
                        if (node.HasChildNodes)
                        {
                            //売上入力用ユーザー設定クラス属性の編集
                            for (int j = 0; j < node.ChildNodes.Count; j++)
                            {
                                XmlNode footerListNode = node.ChildNodes[j];
                                if (footerListNode.HasChildNodes)
                                {
                                    for (int k = 0; k < footerListNode.ChildNodes.Count; k++)
                                    {
                                        XmlNode footerFocusConstructionNode = footerListNode.ChildNodes[k];
                                        if (footerFocusConstructionNode.HasChildNodes)
                                        {
                                            FooterFocusConstruction footerFocusConstruction = new FooterFocusConstruction();
                                            for (int l = 0; l < footerFocusConstructionNode.ChildNodes.Count; l++)
                                            {
                                                XmlNode footerNode = footerFocusConstructionNode.ChildNodes[l];
                                                //
                                                if (footerNode.Name.ToLower() == "key")
                                                {
                                                    footerFocusConstruction.Key = footerNode.InnerXml;//update
                                                }
                                                //
                                                if (footerNode.Name.ToLower() == "caption")
                                                {
                                                    footerFocusConstruction.Caption = footerNode.InnerXml;
                                                }
                                                //
                                                if (footerNode.Name.ToLower() == "enterstop")
                                                {
                                                    footerFocusConstruction.EnterStop = Boolean.Parse(footerNode.InnerXml);
                                                }
                                            }
                                            footerList.Add(footerFocusConstruction);
                                        }
                                    }
                                }
                            }
                        }
                        footerFocusConstructionList.footerFocusConstruction = footerList;
                        _salesSlipInputConstruction.FooterFocusConstructionList = footerFocusConstructionList;
                    }
                    // ADD 2010/08/13 ---- >>>>
                    else if (node.Name == "FunctionDetailConstructionList")
                    {
                        FunctionDetailConstructionList functionDetailConstructionList = new FunctionDetailConstructionList();
                        List<FunctionDetailConstruction> functionDetailList = new List<FunctionDetailConstruction>();
                        if (node.HasChildNodes)
                        {
                            //売上入力用ユーザー設定クラス属性の編集
                            for (int j = 0; j < node.ChildNodes.Count; j++)
                            {
                                XmlNode functionDetailListNode = node.ChildNodes[j];
                                if (functionDetailListNode.HasChildNodes)
                                {
                                    for (int k = 0; k < functionDetailListNode.ChildNodes.Count; k++)
                                    {
                                        XmlNode functionDetailConstructionNode = functionDetailListNode.ChildNodes[k];
                                        if (functionDetailConstructionNode.HasChildNodes)
                                        {
                                            FunctionDetailConstruction functionDetailConstruction = new FunctionDetailConstruction();
                                            for (int l = 0; l < functionDetailConstructionNode.ChildNodes.Count; l++)
                                            {
                                                XmlNode functionDetailNode = functionDetailConstructionNode.ChildNodes[l];
                                                //
                                                if (functionDetailNode.Name.ToLower() == "key")
                                                {
                                                    functionDetailConstruction.Key = functionDetailNode.InnerXml;//update
                                                }
                                                //
                                                if (functionDetailNode.Name.ToLower() == "caption")
                                                {
                                                    functionDetailConstruction.Caption = functionDetailNode.InnerXml;
                                                }
                                                //
                                                if (functionDetailNode.Name.ToLower() == "enterstop")
                                                {
                                                    functionDetailConstruction.Checked = Boolean.Parse(functionDetailNode.InnerXml);
                                                }
                                            }
                                            functionDetailList.Add(functionDetailConstruction);
                                        }
                                    }
                                }
                            }
                        }
                        functionDetailConstructionList.functionDetailConstruction = functionDetailList;
                        _salesSlipInputConstruction.FunctionDetailConstructionList = functionDetailConstructionList;
                    }
                    // ADD 2010/08/13 ---- <<<<
                    else
                    {
                        continue;
                    }
                }
            }
        }

        // --- ADD 2021/09/10 呉元嘯 PMKOBETSU-4172 原単価チェックと税率ログの制御ファイルの対応--->>>>>
        /// <summary>
        /// 原単価チェック設定ファイル更新
        /// </summary>
        /// <remarks>
        /// <br>Note       : 原単価チェック設定ファイル更新</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2021/09/10</br>
        /// </remarks>
        public void SaveUnitCostCheckSetting()
        {
            try
            {
                //ファイルがある場合、原単価チェック設定ファイル更新
                SaveUnitCostCheckXmlInfo saveUnitCostCheckXmlInfo = new SaveUnitCostCheckXmlInfo();
                //原単価チェックフラグ
                saveUnitCostCheckXmlInfo.SaveUnitCostCheckFlg = _salesSlipInputConstruction.SaveUnitCostCheckDivValue;
                UserSettingController.SerializeUserSetting(saveUnitCostCheckXmlInfo, Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_SaveUnitCostCheck));
            }
            catch
            {
                //既存影響しない
            }
        }
        // --- ADD 2021/09/10 呉元嘯 PMKOBETSU-4172 原単価チェックと税率ログの制御ファイルの対応---<<<<<

        // --- ADD ADD 陳艶丹 2022/04/26 PMKOBETSU-4208 電子帳簿対応--->>>>>
        /// <summary>
        /// 電子帳簿設定ファイル更新
        /// </summary>
        /// <remarks>
        /// <br>Note       : 電子帳簿設定ファイル更新</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2022/04/26</br>
        /// </remarks>
        public void SaveEBooksOutputSetting()
        {
            try
            {
                // 設定ファイル更新
                eBooksOutputSetting eBooksOutputSetting = new eBooksOutputSetting();
                // pdf出力区分
                eBooksOutputSetting.OutputMode = _salesSlipInputConstruction.OutputMode;
                // 伝票出力区分
                SetOutputSlipType(_salesSlipInputConstruction.SalesOutputDiv, _salesSlipInputConstruction.EstimateOutputDiv, ref eBooksOutputSetting);
                // pdfプリンター
                eBooksOutputSetting.PDFPrinter = _salesSlipInputConstruction.PdfPrinter;
                // pdfプリンター管理番号
                eBooksOutputSetting.PDFPrinterNumber = _salesSlipInputConstruction.PdfPrinterNumber;
                // pdfプリンター待機時間
                eBooksOutputSetting.PDFPrinterWait = _salesSlipInputConstruction.PdfPrinterWait;

                UserSettingController.SerializeUserSetting(eBooksOutputSetting, Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_PDFOUTPUTSETTINGS));
            }
            catch
            {
                //既存影響しない
            }
        }
        // --- ADD ADD 陳艶丹 2022/04/26 PMKOBETSU-4208 電子帳簿対応---<<<<<

        //--- ADD 田村顕成 2022/10/05 インボイス残対応 ----->>>>>
        /// <summary>
        /// 返品･赤伝制御設定ファイル更新
        /// </summary>
        /// <remarks>
        /// <br>Note       : 返品･赤伝制御設定ファイル更新</br>
        /// <br>Programmer : 田村顕成</br>
        /// <br>Date       : 2022/10/05</br>
        /// </remarks>
        public void SaveReturnRedControlSetting()
        {
            try
            {
                // 設定ファイル更新
                ReturnRedControlSetting returnRedSetting = new ReturnRedControlSetting();
                // 返品・赤伝時備考1使用モード
                returnRedSetting.ReturnRedNote1Mode = _salesSlipInputConstruction.ReturnRedNote1Mode;
                returnRedSetting.ReturnRedNote1 = _salesSlipInputConstruction.ReturnRedNote1;
                // 返品・赤伝時備考2使用モード
                returnRedSetting.ReturnRedNote2Mode = _salesSlipInputConstruction.ReturnRedNote2Mode;
                returnRedSetting.ReturnRedNote2 = _salesSlipInputConstruction.ReturnRedNote2;
                // 返品・赤伝時備考3使用モード
                returnRedSetting.ReturnRedNote3Mode = _salesSlipInputConstruction.ReturnRedNote3Mode;
                returnRedSetting.ReturnRedNote3 = _salesSlipInputConstruction.ReturnRedNote3;
                // 返品・赤伝時備考欄ブランクチェックモード
                returnRedSetting.ReturnRedBlankCheckMode = _salesSlipInputConstruction.ReturnRedBlankCheckMode;

                UserSettingController.SerializeUserSetting(returnRedSetting, Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_RETURNREDSETTINGS));
            }
            catch
            {
                //既存影響しない
            }
        }
        //--- ADD 田村顕成 2022/10/05 インボイス残対応 -----<<<<<

        # endregion


        // ===================================================================================== //
        // インターナルメソッド
        // ===================================================================================== //
        #region Internal Methods

        // 2009.06.17 Add >>>
        /// <summary>
        /// ヘッダ項目制御リスト設定処理(Dictionary)
        /// </summary>
        /// <param name="headerItemsDictionary"></param>
        /// <param name="headerFocusConstructionList"></param>
        internal static void SettingHeaderFocusConstructionListFromDictionary(Dictionary<string, Control> headerItemsDictionary, out List<HeaderFocusConstruction> headerFocusConstructionList)
        {
            headerFocusConstructionList = new List<HeaderFocusConstruction>();
            int index = 0;
            SortedDictionary<int, string> sortedDictionary = new SortedDictionary<int, string>();
            foreach (string key in headerItemsDictionary.Keys)
            {
                Control control = headerItemsDictionary[key];
                sortedDictionary.Add(index, key);
                index++;
            }

            foreach (int keyIndex in sortedDictionary.Keys)
            {
                string key = sortedDictionary[keyIndex];
                HeaderFocusConstruction headerFocusConstruction = new HeaderFocusConstruction();
                Control control = headerItemsDictionary[key];
                headerFocusConstruction.Key = control.Name;
                headerFocusConstruction.Caption = key;
                headerFocusConstruction.EnterStop = true;
                headerFocusConstructionList.Add(headerFocusConstruction);
            }
        }
        // 2009.06.17 Add <<<

        //---2010/07/06---------->>>>>
        /// <summary>
        /// ファンクション制御リスト設定処理(Dictionary)
        /// </summary>
        /// <param name="functionItemsDictionary"></param>
        /// <param name="functionConstructionList"></param>
        internal static void SettingFunctionConstructionListFromDictionary(Dictionary<string, Control> functionItemsDictionary, out List<FunctionConstruction> functionConstructionList)
        {
            functionConstructionList = new List<FunctionConstruction>();
            int index = 0;
            SortedDictionary<int, string> sortedDictionary = new SortedDictionary<int, string>();
            foreach (string key in functionItemsDictionary.Keys)
            {
                Control control = functionItemsDictionary[key];
                sortedDictionary.Add(index, key);
                index++;
            }

            foreach (int keyIndex in sortedDictionary.Keys)
            {
                string key = sortedDictionary[keyIndex];
                FunctionConstruction functionConstruction = new FunctionConstruction();
                Control control = functionItemsDictionary[key];
                functionConstruction.Key = control.Name;
                functionConstruction.Caption = key;
                functionConstruction.Checked = true;
                functionConstructionList.Add(functionConstruction);
            }
        }
        //---2010/07/06----------<<<<<

        //---2010/08/13---------->>>>>
        /// <summary>
        /// ファンクション制御リスト設定処理(Dictionary)
        /// </summary>
        /// <param name="functionItemsDictionary"></param>
        /// <param name="functionConstructionList"></param>
        internal static void SettingFunctionDetailConstructionListFromDictionary(Dictionary<string, Control> functionDetailItemsDictionary, out List<FunctionDetailConstruction> functionDetailConstructionList)
        {
            functionDetailConstructionList = new List<FunctionDetailConstruction>();
            int index = 0;
            SortedDictionary<int, string> sortedDictionary = new SortedDictionary<int, string>();
            foreach (string key in functionDetailItemsDictionary.Keys)
            {
                Control control = functionDetailItemsDictionary[key];
                sortedDictionary.Add(index, key);
                index++;
            }

            foreach (int keyIndex in sortedDictionary.Keys)
            {
                string key = sortedDictionary[keyIndex];
                FunctionDetailConstruction functionDetailConstruction = new FunctionDetailConstruction();
                Control control = functionDetailItemsDictionary[key];
                functionDetailConstruction.Key = control.Name;
                functionDetailConstruction.Caption = key;
                functionDetailConstruction.Checked = true;
                functionDetailConstructionList.Add(functionDetailConstruction);
            }
        }
        //---2010/08/13----------<<<<<

        // --- ADD 2009/12/23 ---------->>>>>
        /// <summary>
        /// フッタ項目制御リスト設定処理(Dictionary)
        /// </summary>
        /// <param name="headerItemsDictionary"></param>
        /// <param name="headerFocusConstructionList"></param>
        internal static void SettingFooterFocusConstructionListFromDictionary(Dictionary<string, Control> footerItemsDictionary, out List<FooterFocusConstruction> footerFocusConstructionList)
        {
            footerFocusConstructionList = new List<FooterFocusConstruction>();
            int index = 0;
            SortedDictionary<int, string> sortedDictionary = new SortedDictionary<int, string>();
            foreach (string key in footerItemsDictionary.Keys)
            {
                Control control = footerItemsDictionary[key];
                sortedDictionary.Add(index, key);
                index++;
            }

            foreach (int keyIndex in sortedDictionary.Keys)
            {
                string key = sortedDictionary[keyIndex];
                FooterFocusConstruction footerFocusConstruction = new FooterFocusConstruction();
                Control control = footerItemsDictionary[key];
                footerFocusConstruction.Key = control.Name;
                footerFocusConstruction.Caption = key;
                footerFocusConstruction.EnterStop = true;
                footerFocusConstructionList.Add(footerFocusConstruction);
            }
        }
        // --- ADD 2009/12/23 ----------<<<<<

        #endregion
    }

    // --- ADD 2021/09/10 呉元嘯 PMKOBETSU-4172 原単価チェックと税率ログの制御ファイルの対応--->>>>>
    # region
    /// <summary>
    /// 原単価チェック設定クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 原単価チェック設定クラス</br>
    /// <br>Programmer : 呉元嘯</br>
    /// <br>Date       : 2021/09/10</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class SaveUnitCostCheckXmlInfo
    {
        // 原単価チェック区分
        private int _saveUnitCostCheckFlg;

        /// <summary>
        /// 原単価チェック設定クラス
        /// </summary>
        public SaveUnitCostCheckXmlInfo()
        {

        }

        /// <summary>原単価チェック区分</summary>
        public Int32 SaveUnitCostCheckFlg
        {
            get { return this._saveUnitCostCheckFlg; }
            set { this._saveUnitCostCheckFlg = value; }
        }
    }
    # endregion
    // --- ADD 2021/09/10 呉元嘯 PMKOBETSU-4172 原単価チェックと税率ログの制御ファイルの対応---<<<<<

    // --- ADD 陳艶丹 2022/04/26 PMKOBETSU-4208 電子帳簿対応--->>>>>
    # region
    /// <summary>
    /// PDFプリンタ項目設定情報
    /// </summary>
    /// <remarks>
    /// <br>Note       : PDFプリンタ項目設定情報</br>
    /// <br>Programmer : 陳艶丹</br>
    /// <br>Date       : 2022/04/26</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class eBooksOutputSetting
    {
        /// <summary>PDFプリンタ項目設定情報</summary>
            public eBooksOutputSetting()
            {

            }

            /// <summary>伝票PDF出力</summary>
            private int _outputMode;
            /// <summary>出力伝票区分</summary>
            private int _outputSlipType;
            /// <summary>PDFプリンタ [Windows標準／その他] </summary>
            private int _pDFPrinter;
            /// <summary>割り当て済みのプリンタ管理番号 </summary>
            private int _pDFPrinterNumber;
            /// <summary>仮想プリンタ制御が終了するまでの待機時間</summary>
            private int _pDFPrinterWait;

            /// <summary>伝票PDF出力</summary>
            public Int32 OutputMode
            {
                get { return _outputMode; }
                set { _outputMode = value; }
            }

            /// <summary>出力伝票区分</summary>
            public Int32 OutputSlipType
            {
                get { return _outputSlipType; }
                set { _outputSlipType = value; }
            }
            /// <summary>PDFプリンタ [Windows標準／その他] </summary>
            public Int32 PDFPrinter
            {
                get { return _pDFPrinter; }
                set { _pDFPrinter = value; }
            }

            /// <summary>割り当て済みのプリンタ管理番号 </summary>
            public Int32 PDFPrinterNumber
            {
                get { return _pDFPrinterNumber; }
                set { _pDFPrinterNumber = value; }
            }

            /// <summary>仮想プリンタ制御が終了するまでの待機時間</summary>
            public Int32 PDFPrinterWait
            {
                get { return _pDFPrinterWait; }
                set { _pDFPrinterWait = value; }
            }
    }
    # endregion
    // --- ADD 陳艶丹 2022/04/26 PMKOBETSU-4208 電子帳簿対応---<<<<<

    //--- ADD 田村顕成 2022/10/05 インボイス残対応 ----->>>>>
    # region
    /// <summary>
    /// 返品・赤伝制御設定情報
    /// </summary>
    /// <remarks>
    /// <br>Note       : 返品・赤伝制御設定情報</br>
    /// <br>Programmer : 田村顕成</br>
    /// <br>Date       : 2022/10/05</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class ReturnRedControlSetting
    {
        /// <summary>返品・赤伝制御設定情報</summary>
        public ReturnRedControlSetting()
        {

        }

        /// <summary>返品・赤伝時備考1使用モード</summary>
        private int _returnRedNote1Mode;
        private string _returnRedNote1;
        /// <summary>返品・赤伝時備考2使用モード</summary>
        private int _returnRedNote2Mode;
        private string _returnRedNote2;
        /// <summary>返品・赤伝時備考3使用モード</summary>
        private int _returnRedNote3Mode;
        private string _returnRedNote3;
        /// <summary>返品・赤伝時備考欄ブランクチェックモード</summary>
        private int _returnRedBlankCheckMode;


        /// <summary>返品・赤伝時備考1使用モード</summary>
        public int ReturnRedNote1Mode
        {
            get { return _returnRedNote1Mode; }
            set { _returnRedNote1Mode = value; }
        }
        public string ReturnRedNote1
        {
            get { return _returnRedNote1; }
            set { _returnRedNote1 = value; }
        }

        /// <summary>返品・赤伝時備考2使用モード</summary>
        public int ReturnRedNote2Mode
        {
            get { return _returnRedNote2Mode; }
            set { _returnRedNote2Mode = value; }
        }
        public string ReturnRedNote2
        {
            get { return _returnRedNote2; }
            set { _returnRedNote2 = value; }
        }
        /// <summary>返品・赤伝時備考3使用モード</summary>
        public int ReturnRedNote3Mode
        {
            get { return _returnRedNote3Mode; }
            set { _returnRedNote3Mode = value; }
        }
        public string ReturnRedNote3
        {
            get { return _returnRedNote3; }
            set { _returnRedNote3 = value; }
        }
        /// <summary>返品・赤伝時備考欄ブランクチェックモード</summary>
        public int ReturnRedBlankCheckMode
        {
            get { return _returnRedBlankCheckMode; }
            set { _returnRedBlankCheckMode = value; }
        }
    }
    # endregion
    //--- ADD 田村顕成 2022/10/05 インボイス残対応 -----<<<<<
}
